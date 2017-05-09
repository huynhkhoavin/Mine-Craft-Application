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
    public partial class MainForm : Form
    {
        public Form loginForm;
        public MainForm()
        {
            InitializeComponent();
            CenterToScreen();
            lb_statusBar.Text = "";
        }

        public void upload_Item_Click(Object sender, EventArgs e)
        {
            lb_statusBar.Text = "Connecting... Please wait!";
            UploadForm uploadForm = new UploadForm();

            //set previous Form for Back Button Of Upload Form
            uploadForm.PreviousForm = this;
            this.Hide();
            lb_statusBar.Text = "";
            uploadForm.Show();
        }
        public void verify_Item_Click(Object sender, EventArgs e)
        {
            lb_statusBar.Text = "Connecting... Please wait!";
            ListUploadItemForm listItemForm = new ListUploadItemForm();
            listItemForm.PreviousForm = this;
            this.Hide();
            listItemForm.Show();
            //lb_statusBar.Text = "";
        }
        public void Log_Out_Click(Object sender, EventArgs e)
        {
            lb_statusBar.Text = "Connecting... Please wait!";
            this.Hide();
            loginForm.Show();
            //lb_statusBar.Text = "";
        }

        private void xml_Convert(object sender, EventArgs e)
        {
            lb_statusBar.Text = "Connecting... Please wait!";
            this.Hide();
            XmlForm xmlForm = new XmlForm();
            xmlForm.previousForm = this;
            xmlForm.Show();
            lb_statusBar.Text = "";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }
    }
}
