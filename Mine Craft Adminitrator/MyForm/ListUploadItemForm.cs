using Mine_Craft_Adminitrator.DataAccess;
using Mine_Craft_Adminitrator.DataObject;
using Mine_Craft_Adminitrator.MyForm;
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
            //role
            if(General.get_Role() == 2)
            {
                btn_multiple.Enabled = false;
            }
            gridView.Refresh();
        }
        
        public void btnShow_Click(object sender, EventArgs e)
        {
            Reload();
        }

        public void Reload()
        {
            //Reset History Data
            gridView.DataSource = null;
            gridView.Refresh();
            displayItems.Clear();
            gridView.Columns.Clear();
            //Reload
            string fromDateTime = dt_from.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string toDateTime = dt_to.Value.ToString("yyyy-MM-dd HH:mm:ss");

            list = General.getAllUploadItem(fromDateTime, toDateTime);

            int i = 1;
            foreach (UploadItem uploadItem in list)
            {
                int type_id = uploadItem.type_id;
                string typeName = itemTypeList[type_id-1].type_name;
                displayItems.Add(new DisplayItem(i, typeName, uploadItem.item_name));
                i++;
            }
            source.DataSource = displayItems;
            gridView.DataSource = source;

            //if (isAddButton == false)
            {
                addColumnButton();
                isAddButton = true;
            }
        }

        DataGridViewButtonColumn buttonView;
        private void addColumnButton()
        {
            buttonView = new DataGridViewButtonColumn();

            buttonView.HeaderText = "Action";
            buttonView.Text = "View";
            buttonView.UseColumnTextForButtonValue = true;
            buttonView.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            buttonView.FlatStyle = FlatStyle.Standard;
            buttonView.CellTemplate.Style.BackColor = Color.Honeydew;
            
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
                string typeName = itemTypeList[type_id-1].type_name;
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
        List<int> selectedRow = new List<int>();
        public bool checkExist(int a)
        {
            foreach(int x in selectedRow)
            {
                if (x == a)
                {
                    return true;
                }
            }
            return false;
        }

        private void btn_multiple_Click(object sender, EventArgs e)
        {
            var selectedCellList = new List<CellData>();

            foreach (DataGridViewCell cell in gridView.SelectedCells)
            {
                selectedCellList.Add(new CellData { ColumnName = cell.OwningColumn.Name, Value = cell.Value });
                if (checkExist(cell.RowIndex) == false)
                {
                    selectedRow.Add(cell.RowIndex);
                    
                }
            }
            // Verify Item in selected list
            AlertForm f = new AlertForm();
            foreach(int index in selectedRow)
            {
                try
                {
                    ErrorCode responseCode = General.VerifyUploadItem(list[index].item_id);
                    if (responseCode.ResponseCode == 200)
                    {
                        f.addContent(" Verify " + responseCode.Meaning + list[index].item_name, true);
                    }
                    else
                        f.addContent(" Verify " + responseCode.Meaning + list[index].item_name, false);
                    Reload();
                }
                catch (Exception)
                {

                }
                
            }
            f.Show();
        }
    }
    public class CellData
    {
        public string ColumnName { get; set; }
        public object Value { get; set; }
    }
}
