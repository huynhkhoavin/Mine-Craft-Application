using Mine_Craft_Adminitrator.DataAccess;
using Mine_Craft_Adminitrator.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mine_Craft_Adminitrator.XmlObject
{
    class XmlUtils
    {
        public static List<Category> categoryList = General.getCategory();
        public static List<ItemType> itemTypeList = General.getItemType();
        public static int getCategoryIdByName(string categoryName)
        {
            for (int i = 0; i < categoryList.Count; i++)
            {
                if (categoryList[i].category_name.Equals(categoryName))
                {
                    return (i + 1);
                }
            }
            return 0;
        }
        public static int getTypeIdByName(string typeName)
        {
            for (int i = 0; i < itemTypeList.Count; i++)
            {
                if (itemTypeList[i].type_name.Equals(typeName))
                {
                    return (i + 1);
                }
            }
            return 0;
        }
    }
}
