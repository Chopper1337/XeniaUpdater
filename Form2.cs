using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace XeniaUpdater_C
{
    public partial class Form2 : Form
    {
        //KEEP \N AT THE END. GITHUB RETURNS TEXT FILES WITH THIS FOR SOME REASON
        //UPDATE CHECK WILL NOT WORK IF REMOVED.
        public string buildDate = "Build date: 10/03/2023 1620 GMT\n";
        public Form2()
        {
            InitializeComponent();
            label3.Text = buildDate;
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
