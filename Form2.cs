using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace XeniaUpdater_C
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Process.Start("https://xenia.jp");
        }
    }
}
