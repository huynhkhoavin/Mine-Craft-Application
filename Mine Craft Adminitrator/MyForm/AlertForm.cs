using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mine_Craft_Adminitrator.MyForm
{
    public partial class AlertForm : Form
    {
        public AlertForm()
        {
            InitializeComponent();
        }

        private void AlertForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }
        public void addContent(string content, bool result)
        {
            int start = rt_content.TextLength;
            rt_content.AppendText(content+"\n");

            rt_content.SelectionStart = start;
            rt_content.SelectionLength = content.Length;

            if (result == true)
            {
                rt_content.SelectionColor = Color.Green;

            }
            else
            {
                rt_content.SelectionColor = Color.Red;
            }
            rt_content.DeselectAll();
        }
    }
}
