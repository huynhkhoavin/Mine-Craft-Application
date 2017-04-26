using Mine_Craft_Adminitrator.DataAccess;
using Mine_Craft_Adminitrator.DataObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mine_Craft_Adminitrator
{
    public partial class ItemDetail : Form
    {
        public Form PreviousForm;

        List<ItemType> itemTypeList = General.getItemType();
        List<Category> categoryList = General.getCategory();

        FolderBrowserDialog folderBrowserDialog;
        public UploadItem Item;
        public ItemDetail()
        {
            InitializeComponent();
            CenterToScreen();
        }
        private void ItemDetail_Load(object sender, EventArgs e)
        {
            //Set default folder for save
            folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            folderBrowserDialog.SelectedPath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\Saved\\";
            tb_RootDirectory.Text = folderBrowserDialog.SelectedPath;

            //Item Type
            var itemTypeSource = new BindingSource();
            itemTypeSource.DataSource = itemTypeList;
            cb_itemType.DataSource = itemTypeSource;
            cb_itemType.DisplayMember = "type_name";

            //Category
            var categorySource = new BindingSource();
            categorySource.DataSource = categoryList;
            cb_category.DataSource = categorySource;
            cb_category.DisplayMember = "category_name";


            cb_itemType.SelectedIndex = Item.type_id - 1;
            tb_itemName.Text = Item.item_name;
            tb_author.Text = Item.author_name;
            tb_version.Text = Item.version;
            tb_size.Text = Item.size;
            cb_category.SelectedIndex = Item.category_id - 1;
            rt_short_desc.Text = Item.short_description;
            rt_long_desc.Text = Item.description;


            tb_fileUrl.Text = Item.file_url;

            tb_imageUrl.Text = Item.image_url;


            tb_videoCode.Text = Item.video_code;
            tb_hotPriority.Text = Item.hot_priority;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            if (PreviousForm != null)
            {
                PreviousForm.Show();
            }
        }

        private void btn_verify_Click(object sender, EventArgs e)
        {
            ErrorCode responseCode = General.VerifyUploadItem(Item.item_id);
            if (MessageBox.Show(responseCode.Meaning, "Alert", MessageBoxButtons.OK, MessageBoxIcon.None) == DialogResult.OK)
            {

                //Choose Folder Path to save
                return;
            }
        }


        private void btn_selectRoot_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {

                tb_RootDirectory.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to delete this item, this action can't be undo? ", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.None) == DialogResult.Yes)
                {
                    if (General.DeleteUploadItem(Item.item_id).ResponseCode == 200)
                    {

                        //DeleteUploadItem
                        string[] filePaths = Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.*",
                                                     SearchOption.AllDirectories);
                        foreach (string filename in filePaths)
                        {
                            Console.WriteLine(filename);
                            if (Utils.Utilities.FileNameWithoutExtension(filename).Equals(Item.item_name))
                            {
                                if ((System.IO.File.Exists(filename)))
                                {

                                    if (MessageBox.Show("Delete " + filename, "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.None) == DialogResult.Yes)
                                    {
                                        System.IO.File.Delete(filename);
                                    }
                                }
                            }

                        }
                        MessageBox.Show("Delete Success! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }

            }
            catch (IOException)
            {
                MessageBox.Show("Delete failed! Please check your root directory ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            
        }

        private void btn_ReUpload_Click(object sender, EventArgs e)
        {
            UploadForm uploadForm = new UploadForm();
            uploadForm.Item = Item;
            uploadForm.Item.file_url = "";
            uploadForm.Item.image_url = "";

            //set previous Form for Back Button Of Upload Form
            uploadForm.PreviousForm = this;
            this.Hide();
            uploadForm.Show();
        }
    }
}
