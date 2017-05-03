using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Mine_Craft_Adminitrator.DataObject;
using Mine_Craft_Adminitrator.DataAccess;

namespace Mine_Craft_Adminitrator.XmlObject
{
    [XmlRoot(ElementName = "map")]
    public class Map : XmlItem
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
        [XmlElement(ElementName = "video_code")]
        public string Video_code { get; set; }

        public UploadItem convert()
        {
            UploadItem uploadItem = new UploadItem();
            uploadItem.type_id = XmlUtils.getTypeIdByName("Map");
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
            uploadItem.video_code = Video_code;
            return uploadItem;
        }
        
    }
    [XmlRoot(ElementName = "list")]
    public class MapList
    {
        [XmlElement(ElementName = "map")]
        public List<Map> Map { get; set; }
        [XmlElement(ElementName = "data")]
        public Data Data { get; set; }
    }
}
