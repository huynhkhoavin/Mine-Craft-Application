using Mine_Craft_Adminitrator.DataObject;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Mine_Craft_Adminitrator.DataAccess
{
    class General
    {
        private static int role = 0;
        public static string GetConnectionString()
        {
            Console.WriteLine(GetLocalIPAddress());
            return @"server=198.1.92.155;user id=mcpecent_dev02;password=dev02@pamobile;database=mine_craft_mods;persistsecurityinfo=True";
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
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
            cmd.Parameters.Add(new MySqlParameter("p_file_url", Utils.Constain.SERVER_BASE_URL+uploadItem.item_name + Utils.Utilities.GetExtension(uploadItem.file_url)));
            cmd.Parameters.Add(new MySqlParameter("p_image_url", Utils.Constain.SERVER_BASE_URL  + uploadItem.item_name + Utils.Utilities.GetExtension(uploadItem.image_url)));
            cmd.Parameters.Add(new MySqlParameter("p_thumb_url", Utils.Constain.SERVER_BASE_URL  + uploadItem.item_name + Utils.Utilities.GetExtension(uploadItem.image_url)));
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
        public static ErrorCode uploadXmlItem(UploadItem uploadItem)
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
        public static List<UploadItem> getAllUploadItem(string from, string to)
        {
            MySqlCommand cmd = new MySqlCommand("get_all_upload_item", new MySqlConnection(GetConnectionString()));
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new MySqlParameter("p_start_datetime", from));
            cmd.Parameters.Add(new MySqlParameter("p_end_datetime", to));

            cmd.Connection.Open();

            MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            List<UploadItem> listUploadItem = new List<UploadItem>();

            while (dr.Read())
            {
                UploadItem uploadItem = new UploadItem();

                uploadItem.item_id = Convert.ToInt32(dr["item_id"]);

                uploadItem.type_id = Convert.ToInt32(dr["type_id"]);

                uploadItem.category_id = Convert.ToInt32(dr["category_id"]);

                uploadItem.item_name = Convert.ToString(dr["item_name"]);

                uploadItem.file_url = Convert.ToString(dr["file_url"]);

                uploadItem.image_url = Convert.ToString(dr["image_url"]);

                uploadItem.thumb_url = Convert.ToString(dr["thumb_url"]);

                uploadItem.author_name = Convert.ToString(dr["author_name"]);

                uploadItem.version = Convert.ToString(dr["version"]);

                uploadItem.size = Convert.ToString(dr["size"]);

                uploadItem.description = Convert.ToString(dr["description"]);

                uploadItem.short_description = Convert.ToString(dr["short_description"]);

                uploadItem.hot_priority = Convert.ToString(dr["hot_priority"]);

                uploadItem.download_count = Convert.ToInt32(dr["download_count"]);

                uploadItem.video_code = Convert.ToString(dr["video_code"]);

                uploadItem.is_verify = Convert.ToInt32(dr["is_verify"]);

                DateTime addedDate = (DateTime)dr["create_time"];

                uploadItem.create_time = addedDate;
                //Convert DateTime
                listUploadItem.Add(uploadItem);
            }

            dr.Close();

            return listUploadItem;
        }
        public static void DateTimeConvert(string datetimeString)
        {

        }
        public static ErrorCode VerifyUploadItem(int item_id)
        {
            MySqlCommand cmd = new MySqlCommand("verify_upload_item", new MySqlConnection(GetConnectionString()));
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add(new MySqlParameter("p_upload_item_id", item_id));


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
        public static ErrorCode DeleteUploadItem(int item_id)
        {
            MySqlCommand cmd = new MySqlCommand("delete_upload_item", new MySqlConnection(GetConnectionString()));
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add(new MySqlParameter("p_item_id", item_id));


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
        public static bool CheckLogin(string userName, string password)
        {
            MySqlCommand cmd = new MySqlCommand("admin_authentication", new MySqlConnection(GetConnectionString()));

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new MySqlParameter("p_username", userName));
            cmd.Parameters.Add(new MySqlParameter("p_password", password));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            List<ErrorCode> ErrorItemlist = new List<ErrorCode>();
            while (dr.Read())
            {
                ErrorCode errorCode = new ErrorCode();
                errorCode.ResponseCode = Convert.ToInt32(dr["response_code"]);
                errorCode.Meaning = Convert.ToString(dr["meaning"]);
                ErrorItemlist.Add(errorCode);
            }
            dr.Close();
            return (ErrorItemlist[0].ResponseCode == 204);
        }

        public static void set_account_id(string Account_id)
        {
            //
            //account_id = Account_id;
        }

        public static int set_Role(string user_name)
        {
            MySqlCommand cmd = new MySqlCommand("get_admin_role", new MySqlConnection(GetConnectionString()));

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new MySqlParameter("p_user_name", user_name));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                role = Convert.ToInt32(dr["role"]);
                
            }
            dr.Close();
            return role;
        }
        public static int get_Role()
        {
            return role;
        }

    }
}
