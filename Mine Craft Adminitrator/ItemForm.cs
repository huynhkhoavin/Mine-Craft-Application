using Mine_Craft_Adminitrator.DataObject;
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
    public partial class ItemForm : Form
    {
        public ItemForm()
        {
            InitializeComponent();

            var source = new BindingSource();
            List<MyStruct> list = new List<MyStruct> { new MyStruct("fff", "b"), new MyStruct("c", "d") };
            source.DataSource = list;
            gridView.DataSource = source;
            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            {
                buttons.HeaderText = "Sales";
                buttons.Text = "View";
                buttons.UseColumnTextForButtonValue = true;
                buttons.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                buttons.FlatStyle = FlatStyle.Standard;
                buttons.CellTemplate.Style.BackColor = Color.Honeydew;

            }
            gridView.Columns.Add(buttons);
        }
    }
}
