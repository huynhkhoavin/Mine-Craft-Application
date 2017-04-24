using Mine_Craft_Adminitrator.DataAccess;
using Mine_Craft_Adminitrator.DataObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mine_Craft_Adminitrator
{
    public partial class UploadForm : Form
    {

        List<ItemType> itemTypeList = General.getItemType();
        List<Category> categoryList = General.getCategory();
        string imageUrl = "";
        string fileUrl = "";
        public Form PreviousForm;
        
        public UploadForm()
        {
            
            InitializeComponent();
            CenterToScreen();
        }

        private void UploadForm_Load(object sender, EventArgs e)
        {
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
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            UploadItem uploadItem = new UploadItem();

            uploadItem.type_id = itemTypeList[cb_itemType.SelectedIndex].type_id;

            uploadItem.item_name = tb_itemName.Text;

            uploadItem.author_name = tb_author.Text;

            uploadItem.version = tb_version.Text;

            uploadItem.size = tb_size.Text;

            uploadItem.category_id = categoryList[cb_category.SelectedIndex].category_id;

            uploadItem.short_description = rt_short_desc.Text;

            uploadItem.description = rt_long_desc.Text;

            uploadItem.image_url = imageUrl;

            uploadItem.file_url = fileUrl;

            uploadItem.video_code = tb_videoCode.Text;

            uploadItem.hot_priority = tb_hotPriority.Text;

            //check info condition
            if (uploadItem.item_name == ""
                || uploadItem.author_name == ""
                || uploadItem.version == "" 
                || uploadItem.short_description == ""
                || uploadItem.description == ""
                || uploadItem.image_url == ""
                || uploadItem.file_url == ""
                || uploadItem.video_code == ""
                || uploadItem.hot_priority == "")
            {
                // Displays the MessageBox.

                if (MessageBox.Show("You must fill in all informations!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.None) == DialogResult.OK)
                {
                    return;
                }
            }
            else
            {
                ErrorCode errorCode = General.uploadItem(uploadItem);
                if (errorCode.ResponseCode == 200)
                {
                    if (MessageBox.Show("Upload Success!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.None) == DialogResult.OK)
                    {
                        return;
                    }
                }
            }
        }

        private void btn_imageBrowse_Click(object sender, EventArgs e)
        {
            System.Console.WriteLine(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Office Files|*.jpg;*.png;*.jpeg";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            Stream myStream = null;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {

                        string strfilename = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                            System.Console.WriteLine(strfilename);
                        imageUrl = strfilename;
                        tb_imageUrl.Text = imageUrl;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void btn_fileBrowse_Click(object sender, EventArgs e)
        {
            System.Console.WriteLine(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Zip Files|*.zip;*.rar";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            Stream myStream = null;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {

                        string strfilename = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                        System.Console.WriteLine(strfilename);
                        fileUrl = strfilename;
                        tb_fileUrl.Text = fileUrl;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void btn_Back(object sender, EventArgs e)
        {
            this.Hide();
            PreviousForm.Show();
        }
    }
}
