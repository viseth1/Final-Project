using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void staffManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Staff f = new Staff();
            f.MdiParent = this;
            f.Dock = DockStyle.Fill;
            f.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Privilege f = new Privilege();
            f.MdiParent = this;
            f.Dock = DockStyle.Fill;
            f.Show();
        }

        private void productToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Category f = new Category();
            f.MdiParent = this;
            f.Dock = DockStyle.Fill;
            f.Show();
        }

        private void productToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Product f = new Product();
            f.MdiParent = this;
            f.Dock = DockStyle.Fill;
            f.Show();
        }

        private void sellToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Sell f = new Sell();
            f.Show();
            this.Hide();
        }
    }
}
