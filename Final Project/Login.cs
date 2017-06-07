using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Final_Project
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "Username";
            txtUsername.ForeColor = Color.Gray;
            txtPassword.Text = "Password";
            txtPassword.ForeColor = Color.Gray;
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Gray;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "Username")
            {
                if (txtPassword.Text != "Password")
                {
                    bool login = false;
                    string username, password;
                    string inUsername, inPassword;
                    inUsername = txtUsername.Text;
                    inPassword = txtPassword.Text;

                    OleDbDataReader reader = Program.readData("SELECT  UserName, Password FROM tblStaff");

                    while (reader.Read())
                    {
                        username = reader[0].ToString();
                        password = reader[1].ToString();

                        if (username.Equals(inUsername) && password.Equals(inPassword))
                        {
                            login = true;
                            break;
                        }
                    }
                    reader.Close();
                    Program.con.Close();

                    if (login)
                    {
                        Main_Form f = new Main_Form();
                        f.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Username or Password!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUsername.Clear();
                        txtPassword.Clear();
                        txtUsername_Leave(sender, e);
                        txtPassword_Leave(sender, e);
                        txtUsername.Focus();
                    }
                }
                else
                {
                    txtPassword.BackColor = Color.Red;
                    MessageBox.Show("Please input Password!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtPassword.BackColor = Color.White;
                    txtPassword.SelectAll();
                    txtPassword.Focus();
                }
            }
            else
            {
                txtUsername.BackColor = Color.Red;
                MessageBox.Show("Please input Username!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtUsername.BackColor = Color.White;
                txtUsername.SelectAll();
                txtUsername.Focus();
            }            
        }
    }
}
