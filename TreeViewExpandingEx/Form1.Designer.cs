
namespace TreeViewExpandingEx
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("节点19");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("节点20");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("节点21");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("节点0", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("节点6");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("节点7");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("节点15");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("节点16");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("节点17");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("节点18");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("节点8", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("节点9");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("节点10");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("节点1", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode11,
            treeNode12,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("节点11");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("节点12");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("节点13");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("节点14");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("节点2", new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("节点3");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("节点4");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("节点5");
            this.treeViewEx1 = new TreeViewExpandingEx.TreeViewEx();
            this.SuspendLayout();
            // 
            // treeViewEx1
            // 
            this.treeViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewEx1.Location = new System.Drawing.Point(0, 0);
            this.treeViewEx1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.treeViewEx1.Name = "treeViewEx1";
            treeNode1.Name = "节点19";
            treeNode1.Text = "节点19";
            treeNode2.Name = "节点20";
            treeNode2.Text = "节点20";
            treeNode3.Name = "节点21";
            treeNode3.Text = "节点21";
            treeNode4.Name = "节点0";
            treeNode4.Text = "节点0";
            treeNode5.Name = "节点6";
            treeNode5.Text = "节点6";
            treeNode6.Name = "节点7";
            treeNode6.Text = "节点7";
            treeNode7.Name = "节点15";
            treeNode7.Text = "节点15";
            treeNode8.Name = "节点16";
            treeNode8.Text = "节点16";
            treeNode9.Name = "节点17";
            treeNode9.Text = "节点17";
            treeNode10.Name = "节点18";
            treeNode10.Text = "节点18";
            treeNode11.Name = "节点8";
            treeNode11.Text = "节点8";
            treeNode12.Name = "节点9";
            treeNode12.Text = "节点9";
            treeNode13.Name = "节点10";
            treeNode13.Text = "节点10";
            treeNode14.Name = "节点1";
            treeNode14.Text = "节点1";
            treeNode15.Name = "节点11";
            treeNode15.Text = "节点11";
            treeNode16.Name = "节点12";
            treeNode16.Text = "节点12";
            treeNode17.Name = "节点13";
            treeNode17.Text = "节点13";
            treeNode18.Name = "节点14";
            treeNode18.Text = "节点14";
            treeNode19.Name = "节点2";
            treeNode19.Text = "节点2";
            treeNode20.Name = "节点3";
            treeNode20.Text = "节点3";
            treeNode21.Name = "节点4";
            treeNode21.Text = "节点4";
            treeNode22.Name = "节点5";
            treeNode22.Text = "节点5";
            this.treeViewEx1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode14,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22});
            this.treeViewEx1.Size = new System.Drawing.Size(459, 526);
            this.treeViewEx1.TabIndex = 0;
            this.treeViewEx1.BeforeExpandingEx += new System.EventHandler<TreeViewExpandingEx.TreeViewEx.BeforeExpandingExArgs>(this.treeViewEx1_BeforeExpandingEx);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 526);
            this.Controls.Add(this.treeViewEx1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private TreeViewEx treeViewEx1;
    }
}

