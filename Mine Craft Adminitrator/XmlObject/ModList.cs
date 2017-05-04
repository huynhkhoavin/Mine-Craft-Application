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
    [XmlRoot(ElementName = "list")]
    public class ModList
    {
        [XmlElement(ElementName = "mod")]
        public List<Mod> Mod { get; set; }
        [XmlElement(ElementName = "data")]
        public Data Data { get; set; }
    }
    [XmlRoot(ElementName = "mod")]
    public class Mod : XmlItem
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "author")]
        public string Author { get; set; }
        [XmlElement(ElementName = "hot")]
        public string Hot { get; set; }
        [XmlElement(ElementName = "type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "version")]
        public string Version { get; set; }
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
            uploadItem.type_id = XmlUtils.getTypeIdByName("Seed");
            uploadItem.category_id = XmlUtils.getCategoryIdByName("None");
            uploadItem.item_name = Name;
            uploadItem.author_name = Author;
            if (Type.Equals("addon"))
            {
                uploadItem.type_id = XmlUtils.getTypeIdByName("AddOn");
            }
            else
                uploadItem.type_id = XmlUtils.getTypeIdByName("Mod");

            uploadItem.version = Version;
            uploadItem.description = Desc;
            uploadItem.thumb_url = Thumb_url;
            uploadItem.image_url = Img_url;
            uploadItem.file_url = File_url;
            uploadItem.video_code = Video_code;
            return uploadItem;
        }
    }
}
