using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mine_Craft_Adminitrator.DataObject
{
    class MyStruct
    {
        public string Name { get; set; }
        public string Adres { get; set; }


        public MyStruct(string name, string adress)
        {
            Name = name;
            Adres = adress;
        }
    }
}
