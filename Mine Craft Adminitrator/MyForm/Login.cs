using Mine_Craft_Adminitrator.DataAccess;
using Mine_Craft_Adminitrator.DataObject;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mine_Craft_Adminitrator
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void btnClick(object sender, EventArgs e)
        {
            lb_statusBar.Text = "Please waiting...";
            if (General.CheckLogin(tb_username.Text, Utils.Encript.MD5Hash(tb_password.Text))){

                General.set_Role(tb_username.Text);
                                
                MainForm mainform = new MainForm();

                mainform.loginForm = this;
                
                mainform.Show();

                lb_statusBar.Text = "";

                this.Hide();
                
            }
            else
            {
                lb_statusBar.Text = "";
                string message = "Wrong Username or Password! Please Try Again!";
                string caption = "Alert";
                if (MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.None) == DialogResult.OK)
                {
                    return;
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tb_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (General.CheckLogin(tb_username.Text, Utils.Encript.MD5Hash(tb_password.Text)))
                {

                    General.set_Role(tb_username.Text);

                    MainForm mainform = new MainForm();

                    mainform.loginForm = this;

                    mainform.Show();

                    this.Hide();

                }
                else
                {
                    string message = "Wrong Username or Password! Please Try Again!";
                    string caption = "Alert";
                    if (MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.None) == DialogResult.OK)
                    {
                        return;
                    }
                }
            }
        }
    }
}
