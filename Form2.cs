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

        private void label7_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/xenia-project");
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.com/invite/Q9mxZf9");
        }
    }
}
