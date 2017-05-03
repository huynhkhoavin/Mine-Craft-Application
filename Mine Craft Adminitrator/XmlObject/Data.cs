using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Mine_Craft_Adminitrator.XmlObject
{
    [XmlRoot(ElementName = "data")]
    public class Data
    {
        [XmlElement(ElementName = "file_version")]
        public string File_version { get; set; }
    }
}
