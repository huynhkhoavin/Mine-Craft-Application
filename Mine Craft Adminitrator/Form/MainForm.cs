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
        }

        public void upload_Item_Click(Object sender, EventArgs e)
        {
            UploadForm uploadForm = new UploadForm();

            //set previous Form for Back Button Of Upload Form
            uploadForm.PreviousForm = this;
            this.Hide();
            uploadForm.Show();
        }
        public void verify_Item_Click(Object sender, EventArgs e)
        {
            ListUploadItemForm listItemForm = new ListUploadItemForm();
            listItemForm.PreviousForm = this;
            this.Hide();
            listItemForm.Show();
        }
        public void Log_Out_Click(Object sender, EventArgs e)
        {
            this.Hide();
            loginForm.Show();
        }

        private void xml_Convert(object sender, EventArgs e)
        {
            this.Hide();
            XmlForm xmlForm = new XmlForm();
            xmlForm.Show();
        }
    }
}
