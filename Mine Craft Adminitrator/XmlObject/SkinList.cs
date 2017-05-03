using Mine_Craft_Adminitrator.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Mine_Craft_Adminitrator.XmlObject
{
    [XmlRoot(ElementName = "skin")]
    public class Skin : XmlItem
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "author")]
        public string Author { get; set; }
        [XmlElement(ElementName = "category")]
        public string Category { get; set; }
        [XmlElement(ElementName = "desc")]
        public string Desc { get; set; }
        [XmlElement(ElementName = "thumb_url")]
        public string Thumb_url { get; set; }
        [XmlElement(ElementName = "img_url")]
        public string Img_url { get; set; }
        [XmlElement(ElementName = "file_url")]
        public string File_url { get; set; }

        public UploadItem convert()
        {
            UploadItem uploadItem = new UploadItem();
            uploadItem.type_id = XmlUtils.getTypeIdByName("Skin");
            uploadItem.category_id = XmlUtils.getCategoryIdByName(Category);
            uploadItem.item_name = Name;
            uploadItem.file_url = File_url;
            uploadItem.image_url = Img_url;
            uploadItem.thumb_url = Thumb_url;
            uploadItem.author_name = Author;
            uploadItem.version = "";
            uploadItem.size = "";
            uploadItem.description = Desc;
            uploadItem.short_description = "";
            uploadItem.hot_priority = "1";
            uploadItem.download_count = 0;
            uploadItem.is_verify = 0;
            uploadItem.video_code = "";
            return uploadItem;
        }
    }
    [XmlRoot(ElementName = "list")]
    public class SkinList
    {
        [XmlElement(ElementName = "skin")]
        public List<Skin> Skin { get; set; }
        [XmlElement(ElementName = "data")]
        public Data Data { get; set; }
    }

}
