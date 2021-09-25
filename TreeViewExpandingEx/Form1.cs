using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeViewExpandingEx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void treeViewEx1_BeforeExpandingEx(object sender, TreeViewEx.BeforeExpandingExArgs e)
        {
            //xxoo
            e.Cancel = true;
        }
    }
}
