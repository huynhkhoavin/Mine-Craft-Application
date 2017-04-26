using Mine_Craft_Adminitrator.DataAccess;
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
    public partial class ListUploadItemForm : Form
    {
        List<ItemType> itemTypeList = General.getItemType();
        List<Category> categoryList = General.getCategory();
        public Form PreviousForm;

        BindingSource source = new BindingSource();
        List<DisplayItem> displayItems = new List<DisplayItem>();

        List<UploadItem> list;

        bool isAddButton = false;
        public ListUploadItemForm()
        {
            InitializeComponent();
            CenterToScreen();   
        }
        private void ItemForm_Load(object sender, EventArgs e)
        {
            
            gridView.Refresh();
        }
        
        private void btnShow_Click(object sender, EventArgs e)
        {
            gridView.Refresh();
            string fromDateTime = dt_from.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string toDateTime = dt_to.Value.ToString("yyyy-MM-dd HH:mm:ss");
            
            list = General.getAllUploadItem(fromDateTime,toDateTime);
            
            int i = 1;
            foreach(UploadItem uploadItem in list)
            {
                int type_id = uploadItem.type_id;
                string typeName = itemTypeList[type_id].type_name;
                displayItems.Add(new DisplayItem(i, typeName, uploadItem.item_name));
                    i++;
            }
            source.DataSource = displayItems;
            gridView.DataSource = source;

            if (isAddButton == false)
            {
                addColumnButton();
                isAddButton = true;
            }
        }
        public void show()
        {

        }
        private void addColumnButton()
        {
            DataGridViewButtonColumn buttonView = new DataGridViewButtonColumn();
            {
                buttonView.HeaderText = "Action";
                buttonView.Text = "View";
                buttonView.UseColumnTextForButtonValue = true;
                buttonView.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                buttonView.FlatStyle = FlatStyle.Standard;
                buttonView.CellTemplate.Style.BackColor = Color.Honeydew;

            }
            gridView.Columns.Add(buttonView);
        }
        private void gridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            System.Console.WriteLine("Position:(" + gridView.CurrentCell.RowIndex.ToString() + " ," + gridView.CurrentCell.ColumnIndex.ToString()+")");

            switch (gridView.CurrentCell.ColumnIndex)
            {
                case 3:
                    {
                        ItemDetail itemDetail = new ItemDetail();
                        itemDetail.PreviousForm = this;
                        itemDetail.Item = list[gridView.CurrentCell.RowIndex];
                        this.Hide();
                        itemDetail.Show();
                        break;
                    }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            if (PreviousForm!=null)
            {
                PreviousForm.Show();
            }
        }

        private void ListUploadItemForm_Shown(object sender, EventArgs e)
        {
            gridView.Refresh();
            string fromDateTime = dt_from.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string toDateTime = dt_to.Value.ToString("yyyy-MM-dd HH:mm:ss");

            list = General.getAllUploadItem(fromDateTime, toDateTime);

            int i = 1;
            foreach (UploadItem uploadItem in list)
            {
                int type_id = uploadItem.type_id;
                string typeName = itemTypeList[type_id].type_name;
                displayItems.Add(new DisplayItem(i, typeName, uploadItem.item_name));
                i++;
            }
            source.DataSource = displayItems;
            gridView.DataSource = source;

            if (isAddButton == false)
            {
                addColumnButton();
                isAddButton = true;
            }
        }
    }
}
