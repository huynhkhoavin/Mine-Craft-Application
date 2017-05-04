using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Mine_Craft_Adminitrator.DataObject;

namespace Mine_Craft_Adminitrator.XmlObject
{
    [XmlRoot(ElementName = "seed")]
    public class Seed : XmlItem
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "biomes")]
        public string Biomes { get; set; }
        [XmlElement(ElementName = "code")]
        public string Code { get; set; }
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
            uploadItem.type_id = XmlUtils.getTypeIdByName("Seed");
            uploadItem.category_id = XmlUtils.getCategoryIdByName("None");
            uploadItem.item_name = Name;
            uploadItem.file_url = File_url;
            uploadItem.image_url = Img_url;
            uploadItem.thumb_url = Thumb_url;
            uploadItem.version = "";
            uploadItem.size = "";
            uploadItem.description = Desc;
            uploadItem.short_description = "";
            uploadItem.hot_priority = "1";
            uploadItem.download_count = 0;
            uploadItem.is_verify = 0;
            uploadItem.video_code = Code;
            return uploadItem;
        }
    }
    [XmlRoot(ElementName = "list")]
    public class SeedList
    {
        [XmlElement(ElementName = "seed")]
        public List<Seed> Seed { get; set; }
        [XmlElement(ElementName = "data")]
        public Data Data { get; set; }
    }
}
