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
            string cs = @"Server=localhost;Database=mine_craft_mods;Uid=root;";

            MySqlConnection conn = new MySqlConnection(cs);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM item_comment";
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.Out.WriteLine(reader.GetString(1));
                }
            }
        }

        private void btnClick(object sender, EventArgs e)
        {
            if (CheckLogin(tb_username.Text, Utils.Encript.MD5Hash(tb_password.Text))){
                MainForm mainform = new MainForm();
                mainform.loginForm = this;
                mainform.Show();
                this.Hide();
            }
            else
            {
                string message = "Wrong Username or Password! Please Try Again!";
                string caption = "Alert";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.No)
                {

                    // Closes the parent form.

                    this.Close();

                }
                else
                {
                    return;
                }
            }
        }

        public string GetConnectionString()
        {
            return @"Server=localhost;Database=mine_craft_mods;Uid=root;";
        }
        private void getErrorCode()
        {
            MySqlCommand cmd = new MySqlCommand("get_error_code", new MySqlConnection(GetConnectionString()));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            List<ErrorCode> ErrorItemlist = new List<ErrorCode>();
            while (dr.Read())
            {
                ErrorCode errorCode = new ErrorCode();
                errorCode.ResponseCode = Convert.ToInt32(dr["response_code"]);
                errorCode.Meaning = Convert.ToString(dr["meaning"]);
                ErrorItemlist.Add(errorCode);
            }
            dr.Close();
            //return ErrorItemlist;
        }

        private bool CheckLogin(string userName, string password)
        {
            MySqlCommand cmd = new MySqlCommand("admin_authentication", new MySqlConnection(GetConnectionString()));

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new MySqlParameter("p_username", userName));
            cmd.Parameters.Add(new MySqlParameter("p_password", password));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            List<ErrorCode> ErrorItemlist = new List<ErrorCode>();
            while (dr.Read())
            {
                ErrorCode errorCode = new ErrorCode();
                errorCode.ResponseCode = Convert.ToInt32(dr["response_code"]);
                errorCode.Meaning = Convert.ToString(dr["meaning"]);
                ErrorItemlist.Add(errorCode);
            }
            dr.Close();
            return (ErrorItemlist[0].ResponseCode == 204);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
