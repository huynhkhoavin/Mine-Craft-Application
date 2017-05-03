﻿using Mine_Craft_Adminitrator.DataAccess;
using Mine_Craft_Adminitrator.DataObject;
using Mine_Craft_Adminitrator.TestXml;
using Mine_Craft_Adminitrator.XmlObject;
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
using System.Xml;
using System.Xml.Serialization;

namespace Mine_Craft_Adminitrator
{
    public partial class XmlForm : Form
    {
        public Form loginForm;

        List<ItemType> itemTypeList = General.getItemType();

        List<XmlItem> listConvertedItem = new List<XmlItem>();

        List<DisplayItem> listDisplay = new List<DisplayItem>();

        List<UploadItem> listUploadItem = new List<UploadItem>();
        public XmlForm()
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

        private void XmlForm_Load(object sender, EventArgs e)
        {
            //Item Type
            var itemTypeSource = new BindingSource();
            itemTypeSource.DataSource = itemTypeList;
            cb_itemType.DataSource = itemTypeSource;
            cb_itemType.DisplayMember = "type_name";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listUploadItem.Clear();
            listConvertedItem.Clear();
            string data = rt_xmlContent.Text;
            try
            {
                switch (cb_itemType.SelectedIndex)
                {
                    case 0: // Addon
                        {

                            break;
                        }
                    case 1: //Mod
                        {

                            break;
                        }
                    case 2: //Map
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(MapList));
                            using (TextReader reader = new StringReader(data))
                            {
                                MapList result = (MapList)serializer.Deserialize(reader);
                                foreach(Map map in result.Map)
                                {
                                    listConvertedItem.Add(map);
                                }
                            }

                            break;
                        }
                    case 3: //Skin
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(SkinList));
                            using (TextReader reader = new StringReader(data))
                            {
                                SkinList result = (SkinList)serializer.Deserialize(reader);
                                foreach (Skin map in result.Skin)
                                {
                                    listConvertedItem.Add(map);
                                }
                            }
                            
                            break;
                        }
                    case 4: //Texture
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(TextureList));
                            using (TextReader reader = new StringReader(data))
                            {
                                TextureList result = (TextureList)serializer.Deserialize(reader);
                                foreach (Texture map in result.Texture)
                                {
                                    listConvertedItem.Add(map);
                                }
                            }
                            break;
                        }
                    case 5: //Seed
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(SeedList));
                            using (TextReader reader = new StringReader(data))
                            {
                                SeedList result = (SeedList)serializer.Deserialize(reader);
                                foreach (Seed map in result.Seed)
                                {
                                    listConvertedItem.Add(map);
                                }
                            }
                            break;
                        }
                    default:
                        break;
                }

                foreach(XmlItem item in listConvertedItem)
                {
                    listUploadItem.Add(item.convert());
                }
                BindingSource source = new BindingSource();
                source.DataSource = listUploadItem;
                gridView.DataSource = source;
                label2.Text = "Total: "+listUploadItem.Count.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong XML Format!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listUploadItem.Clear();
            gridView.DataSource = null;
            gridView.Refresh();
        }
    }
}
