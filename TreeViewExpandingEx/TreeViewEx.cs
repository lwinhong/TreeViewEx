using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TreeViewExpandingEx
{
    public partial class TreeViewEx : TreeView
    {
        private Func<IntPtr, TreeNode> _getNodeByHandle;//根据句柄获取树点击，这里是直接反射拿到这个方法
        private BitVector32 _treeViewState;
        public TreeViewEx()
        {
            var nodeFormHandleMethod = GetType().GetMethod("NodeFromHandle", BindingFlags.Instance | BindingFlags.NonPublic, null,
                 CallingConventions.Any, new Type[] { typeof(IntPtr) }, null);

            //只有一个方法可以用这个行； 如果方法有重载的话需要用上面那个方法
            //nodeFormHandleMethod = GetType().GetMethod("NodeFromHandle", BindingFlags.Instance | BindingFlags.NonPublic);

            //根据句柄获取树节点方法实例
            if (!(nodeFormHandleMethod is null))
                _getNodeByHandle =
                    (Func<IntPtr, TreeNode>)Delegate.CreateDelegate(typeof(Func<IntPtr, TreeNode>), this,
                        nodeFormHandleMethod);

            _treeViewState = new BitVector32(TREEVIEWSTATE_doubleclickFired);
        }

        /// <summary>释放由 <see cref="T:System.Windows.Forms.TreeView" /> 占用的非托管资源，还可以另外再释放托管资源。</summary>
        /// <param name="disposing">
        /// <see langword="true" /> 表示释放托管资源和非托管资源；<see langword="false" /> 表示仅释放非托管资源。</param>
        protected override void Dispose(bool disposing)
        {
            _getNodeByHandle = null;
            base.Dispose(disposing);
        }

        /// <summary>重写 <see cref="M:System.Windows.Forms.Control.WndProc(System.Windows.Forms.Message@)" />。</summary>
        /// <param name="m">要处理的 Windows <see cref="T:System.Windows.Forms.Message" />。</param>
        protected unsafe override void WndProc(ref Message m)
        {
            if (WndProcUnsafe(ref m))
            {
                return;
            }

            base.WndProc(ref m);
        }

        private unsafe bool WndProcUnsafe(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NOTIFY + WM_REFLECT
                    when WmNotify(ref m):
                    return true;
                case WM_LBUTTONDBLCLK:
                    var node = GetNodeAt(new Point((int)m.LParam));
                    if (node.Nodes.Count > 0)//有子节点的才记录
                        _treeViewState[TREEVIEWSTATE_doubleclickFired] = true;//记录双击
                    break;
            }

            return false;
        }

        private unsafe bool WmNotify(ref Message m)
        {
            var nmhdr = (NMHDR*)m.LParam;
            if ((nmhdr->code == NM_CUSTOMDRAW))//这里是自定义绘制
            {
                return false;
            }

            var nmtv = (NMTREEVIEW*)m.LParam;
            switch (nmtv->nmhdr.code)
            {
                case TVN_ITEMEXPANDINGA:
                case TVN_ITEMEXPANDINGW:
                    {
                        if (_treeViewState[TREEVIEWSTATE_doubleclickFired])//是否是双击
                        {
                            _treeViewState[TREEVIEWSTATE_doubleclickFired] = false;
                            var item = nmtv->itemNew;
                            //这里判断是否要展开或者折叠
                            if (OnBeforeExpandingEx(_getNodeByHandle(item.hItem)))
                            {
                                m.Result = (IntPtr)1;
                                return true;
                            }
                        }

                        break;
                    }
            }

            return false;
        }

        /// <summary>
        ///     这里可以给其他子类重写（也可以使用属性，事件的方式多外公开）
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected virtual bool OnBeforeExpandingEx(TreeNode node)
        {
            //do some thing
            //true 标识 不折叠/展开， false 不做任何处理
            //return false;

            var args = new BeforeExpandingExArgs(node);
            BeforeExpandingEx?.Invoke(this, args);
            return args.Cancel;
        }

        /// <summary>
        ///     提供个事件给外部进行处理
        /// </summary>
        public event EventHandler<BeforeExpandingExArgs> BeforeExpandingEx;

        public class BeforeExpandingExArgs : EventArgs
        {
            /// <summary>初始化 <see cref="T:System.EventArgs" /> 类的新实例。</summary>
            public BeforeExpandingExArgs(TreeNode node)
            {
                Node = node;
            }
            public TreeNode Node { get; }
            public bool Cancel { get; set; }
        }

        #region 消息相关

        public const int
            TVN_ITEMEXPANDINGA = ((0 - 400) - 5),
            TVN_ITEMEXPANDINGW = ((0 - 400) - 54),
            TREEVIEWSTATE_doubleclickFired = 0x00000800;

        public const int WM_LBUTTONDBLCLK = 0x203,//双击鼠标左键 
            WM_USER = 0x0400,
            WM_NOTIFY = 0x004E,
            WM_REFLECT = WM_USER + 0x1C00,
            NM_CUSTOMDRAW = ((0 - 0) - 12);

        //WM_USER = 0x0400,

        [StructLayout(LayoutKind.Sequential)]
        public struct NMHDR
        {
            public IntPtr hwndFrom;
            public IntPtr idFrom; //This is declared as UINT_PTR in winuser.h
            public int code;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct NMTREEVIEW
        {
            public NMHDR nmhdr;
            public int action;
            public TV_ITEM itemOld;
            public TV_ITEM itemNew;
            public int ptDrag_X; // This should be declared as POINT
            public int ptDrag_Y; // we use unsafe blocks to manipulate 
            // NMTREEVIEW quickly, and POINT is declared
            // as a class.  Too much churn to change POINT
            // now.
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct TV_ITEM
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            public IntPtr /* LPTSTR */ pszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public IntPtr lParam;
        }

        #endregion
    }
}
