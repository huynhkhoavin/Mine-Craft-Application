using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mine_Craft_Adminitrator.DataObject
{
    public class UploadItem
    {
        public int item_id { get; set; }
        public int type_id { get; set; }
        public int category_id { get; set; }
        public string item_name { get; set; }
        public string file_url { get; set; }
        public string image_url { get; set; }
        public string thumb_url { get; set; }
        public string author_name { get; set; }
        public string version { get; set; }
        public string size { get; set; }
        public string description { get; set; }
        public string short_description { get; set; }
        public string hot_priority { get; set; }
        public int download_count { get; set; }
        public int is_verify { get; set; }
        public DateTime create_time { get; set; }
        public string video_code { get; set; }
    }
}
