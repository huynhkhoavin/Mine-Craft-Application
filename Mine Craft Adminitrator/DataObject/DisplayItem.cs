using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mine_Craft_Adminitrator.DataObject
{
    class DisplayItem
    {
        public int SequenceNumber { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        
        public DisplayItem(int sequence, string type, string name)
        {
            this.SequenceNumber = sequence;
            this.Type = type;
            this.Name = name;
        }
    }
}
