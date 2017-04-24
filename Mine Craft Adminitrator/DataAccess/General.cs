using Mine_Craft_Adminitrator.DataObject;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mine_Craft_Adminitrator.DataAccess
{
    class General
    {
        public static string GetConnectionString()
        {
            return @"Server=localhost;Database=mine_craft_mods;Uid=root;";
        }
        public static List<ItemType> getItemType()
        {
            MySqlCommand cmd = new MySqlCommand("get_all_item_type", new MySqlConnection(GetConnectionString()));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            List<ItemType> itemTypeList = new List<ItemType>();
            while (dr.Read())
            {
                ItemType itemType = new ItemType();
                itemType.type_id = Convert.ToInt32(dr["type_id"]);
                itemType.type_name = Convert.ToString(dr["type_name"]);
                itemTypeList.Add(itemType);
            }
            dr.Close();
            return itemTypeList;
        }
        public static List<Category> getCategory()
        {
            MySqlCommand cmd = new MySqlCommand("get_all_categories", new MySqlConnection(GetConnectionString()));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            List<Category> categoryList = new List<Category>();
            while (dr.Read())
            {
                Category category = new Category();
                category.category_id = Convert.ToInt32(dr["category_id"]);
                category.category_name = Convert.ToString(dr["category_name"]);
                categoryList.Add(category);
            }
            dr.Close();
            return categoryList;
        }
        public static ErrorCode uploadItem(UploadItem uploadItem)
        {
            MySqlCommand cmd = new MySqlCommand("add_new_upload_item", new MySqlConnection(GetConnectionString()));
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add(new MySqlParameter("p_type_id", uploadItem.type_id));
            cmd.Parameters.Add(new MySqlParameter("p_category_id", uploadItem.category_id));
            cmd.Parameters.Add(new MySqlParameter("p_item_name", uploadItem.item_name));
            cmd.Parameters.Add(new MySqlParameter("p_file_url", uploadItem.file_url));
            cmd.Parameters.Add(new MySqlParameter("p_image_url", uploadItem.image_url));
            cmd.Parameters.Add(new MySqlParameter("p_thumb_url", uploadItem.thumb_url));
            cmd.Parameters.Add(new MySqlParameter("p_author_name", uploadItem.author_name));
            cmd.Parameters.Add(new MySqlParameter("p_version", uploadItem.version));
            cmd.Parameters.Add(new MySqlParameter("p_size", uploadItem.size));
            cmd.Parameters.Add(new MySqlParameter("p_description", uploadItem.description));
            cmd.Parameters.Add(new MySqlParameter("p_short_description", uploadItem.short_description));
            cmd.Parameters.Add(new MySqlParameter("p_hot_priority", uploadItem.hot_priority));
            cmd.Parameters.Add(new MySqlParameter("p_video_code", uploadItem.video_code));
            cmd.Parameters.Add(new MySqlParameter("p_download_count", uploadItem.download_count));
            cmd.Parameters.Add(new MySqlParameter("p_is_verify", uploadItem.is_verify));

      
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            ErrorCode errorCode = new ErrorCode();
            while (dr.Read())
            {
                errorCode.ResponseCode = Convert.ToInt32(dr["response_code"]);
                errorCode.Meaning = Convert.ToString(dr["meaning"]);
            }
            dr.Close();
            return errorCode;
        }
    }
}
