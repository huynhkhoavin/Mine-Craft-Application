using Mine_Craft_Adminitrator.DataAccess;
using Mine_Craft_Adminitrator.DataObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        FolderBrowserDialog folderBrowserDialog;
        List<ItemType> itemTypeList = General.getItemType();
        List<Category> categoryList = General.getCategory();
        string imageUrl = "";
        string fileUrl = "";
        public Form PreviousForm;
        public UploadItem Item;
        public string filterString = "Addon Files|*.addon";
        public UploadForm()
        {
            InitializeComponent();
            CenterToScreen();
            lb_statusBar.Text = "";
        }

        private void UploadForm_Load(object sender, EventArgs e)
        {
            //Set default folder for save
            folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = true;
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
            cb_category.SelectedIndex = categoryList.Count - 1;
            if(Item!=null)
            Reload();
        }
        protected override void OnShown(EventArgs e)
        {
            
        }
        public void Reload()
        {
            if (Item == null)
                return;
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


            tb_imageUrl.Text = Item.image_url;
            tb_fileUrl.Text = Item.file_url;


            tb_videoCode.Text = Item.video_code;
            tb_hotPriority.Text = Item.hot_priority;
            tb_price.Text = Item.price.ToString();
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            lb_statusBar.Text = "Connecting... Please wait!";
            UploadItem uploadItem = new UploadItem();
            try
            {
                uploadItem.type_id = itemTypeList[cb_itemType.SelectedIndex].type_id;

            uploadItem.item_name = tb_itemName.Text;

            uploadItem.author_name = tb_author.Text;

            uploadItem.version = tb_version.Text;

            uploadItem.size = tb_size.Text;

            uploadItem.category_id = categoryList[cb_category.SelectedIndex].category_id;

            uploadItem.short_description = rt_short_desc.Text;

            uploadItem.description = rt_long_desc.Text;

                uploadItem.price = Int32.Parse(tb_price.Text);

                uploadItem.image_url = Utils.Constain.SERVER_BASE_URL + "images/" + Utils.Utilities.FileNameFromPath(imageUrl);

                uploadItem.file_url = Utils.Constain.SERVER_BASE_URL + "files/" + Utils.Utilities.FileNameFromPath(fileUrl);

                uploadItem.thumb_url = Utils.Constain.SERVER_BASE_URL + "thumbs/" + Utils.Utilities.FileNameFromPath(imageUrl);
            
            uploadItem.video_code = tb_videoCode.Text;

            uploadItem.hot_priority = tb_hotPriority.Text;
            //check info condition
            if (tb_itemName.Text==""
                || tb_author.Text==""
                || rt_long_desc.Text==""
                || tb_imageUrl.Text==""
                || tb_fileUrl.Text==""
                )
            {
                // Displays the MessageBox.

                if (MessageBox.Show("You must fill in at least: ItemName, ItemAuthor, Description, File, Image", "Alert", MessageBoxButtons.OK, MessageBoxIcon.None) == DialogResult.OK)
                {
                        lb_statusBar.Text = "";
                        return;
                }
            }
            else
            {
                ErrorCode errorCode = General.uploadItem(uploadItem);
                if (errorCode.ResponseCode == 200)
                {
                    if (folderBrowserDialog.SelectedPath.Equals(""))
                    {
                        DialogResult result = folderBrowserDialog.ShowDialog();
                        if (result == DialogResult.OK)
                        {

                            tb_RootDirectory.Text = folderBrowserDialog.SelectedPath;
                        }
                    }
                    
                    string selectedFolderPath = tb_RootDirectory.Text;
                    Console.WriteLine(selectedFolderPath);

                    string subFolder = selectedFolderPath + Utils.Utilities.ConvertDateTime();
                    Utils.Utilities.CreateFolder(subFolder);
                    string fileFolder = subFolder + "\\files";
                    Utils.Utilities.CreateFolder(fileFolder);
                    string imageFolder = subFolder + "\\images";
                    Utils.Utilities.CreateFolder(imageFolder);
                    string thumbFolder = subFolder + "\\thumbs";
                    Utils.Utilities.CreateFolder(thumbFolder);

                    Utils.Utilities.CopyFile(imageUrl, imageFolder, uploadItem.item_name + Utils.Utilities.GetExtension(imageUrl));
                    Utils.Utilities.CopyFile(fileUrl, fileFolder, uploadItem.item_name + Utils.Utilities.GetExtension(fileUrl));
                    Utils.Utilities.Resize(imageUrl, thumbFolder + "\\" + uploadItem.item_name + Utils.Utilities.GetExtension(imageUrl), 0.5);

                    if (MessageBox.Show("Upload success and saved to: " + subFolder + "\n", "Alert", MessageBoxButtons.OK, MessageBoxIcon.None) == DialogResult.OK)
                    {
                            lb_statusBar.Text = "";
                            tb_itemName.Text = "";
                            tb_author.Text = "";
                            tb_version.Text = "";
                            tb_size.Text = "";
                            rt_long_desc.Text = "";
                            rt_short_desc.Text = "";
                            tb_imageUrl.Text = "";
                            tb_fileUrl.Text = "";
                            tb_videoCode.Text = "";
                            tb_hotPriority.Text = "1";
                        return;
                    }
                }
                if (errorCode.ResponseCode == 206)
                {
                    if (MessageBox.Show("Item name exist!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.None) == DialogResult.OK)
                    {
                            lb_statusBar.Text = "";
                            return;
                    }
                }

            }
            }
            catch (Exception)
            {
                MessageBox.Show("Error when process information, please fill all missing fields!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        private void btn_imageBrowse_Click(object sender, EventArgs e)
        {
            System.Console.WriteLine(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Office Files|*.jpg;";
            //*.png;*.jpeg";
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
            openFileDialog1.Filter = filterString;
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
            this.Close();
            PreviousForm.Show();
        }

        private void getFileName()
        {
            if (imageUrl == "" || fileUrl == "")
            {
                return;
            }
            else
            {

            }
        }

        private void cb_itemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = cb_itemType.SelectedIndex;
            if (id == 0) //addon
            {
                filterString = "Addon Files|*.addon";
            }
            else if (id == 1) //Mod
            {
                filterString = "Mod Files|*.zip;*.js";
            }
            else if (id == 2 || id == 4 || id == 5)
            {
                filterString = "Zip Files|*.zip";
            }
            else if (id == 3)
            {
                filterString = "Skin Files|*.png";
            }
            tb_imageUrl.Text = "";
            tb_fileUrl.Text = "";
        }

        private void btn_selectRoot_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                
                tb_RootDirectory.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btn_OpenDir_Click(object sender, EventArgs e)
        {
            Process.Start(tb_RootDirectory.Text);
        }

        private void tb_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
