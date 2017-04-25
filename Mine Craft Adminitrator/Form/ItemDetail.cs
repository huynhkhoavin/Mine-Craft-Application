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
    public partial class ItemDetail : Form
    {
        public Form PreviousForm;

        List<ItemType> itemTypeList = General.getItemType();
        List<Category> categoryList = General.getCategory();

        public UploadItem Item;
        public ItemDetail()
        {
            InitializeComponent();
            CenterToScreen();
        }
        private void ItemDetail_Load(object sender, EventArgs e)
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


            cb_itemType.SelectedIndex = Item.type_id-1;
            tb_itemName.Text = Item.item_name;
            tb_author.Text = Item.author_name;
            tb_version.Text = Item.version;
            tb_size.Text = Item.size;
            cb_category.SelectedIndex = Item.category_id-1;
            rt_short_desc.Text = Item.short_description;
            rt_long_desc.Text = Item.description;


            tb_imageUrl.Text = "http://azminecraftskins.com//mcpe//mcpedata//images//"+ Item.image_url;
            tb_fileUrl.Text = "http://azminecraftskins.com//mcpe//mcpedata//files//" + Item.file_url;


            tb_videoCode.Text = Item.video_code;
            tb_hotPriority.Text = Item.hot_priority;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            if (PreviousForm!=null)
            {
                PreviousForm.Show();
            }
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {

        }
    }
}
