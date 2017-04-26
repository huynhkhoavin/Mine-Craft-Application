using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mine_Craft_Adminitrator.Utils
{
    class Utilities
    {
        public static void splitUrl(string original, ref string s1, ref string s2)
        {
            Char charRange = '\\';
            int endIndex = original.LastIndexOf(charRange);
            s1 = original.Substring(0, endIndex);
            s2 = original.Substring(endIndex + 1);
            //Console.WriteLine("original: " + original + " s1: " + original.Substring(0, endIndex) + " s2:" + original.Substring(endIndex+1));
        }
        public static void Resize(string imageFile, string outputFile, double scaleFactor)
        {
            using (var srcImage = Image.FromFile(imageFile))
            {
                //var newWidth = (int)(srcImage.Width * scaleFactor);
                //var newHeight = (int)(srcImage.Height * scaleFactor);

                int newWidth = 300;
                int newHeight = 200;
                using (var newImage = new Bitmap(newWidth, newHeight))
                using (var graphics = Graphics.FromImage(newImage))
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    graphics.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight));
                    newImage.Save(outputFile);
                }
            }
        }
        public static bool CopyFile(string sourceFilePath, string desPath, string desFileName)
        {
            try
            {
                string sourceFolder = "";
                string sourceFileName = "";
                splitUrl(sourceFilePath, ref sourceFolder, ref sourceFileName);
                var source = Path.Combine(sourceFolder, sourceFileName);
                var destination = Path.Combine(desPath, desFileName);
                File.Copy(source, destination);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static string GetExtension(string path)
        {
            string myFileName = FileNameFromPath(path);
            string ext = Path.GetExtension(myFileName);
            return ext;
        }
        public static string FileNameFromPath(string path)
        {
            Char charRange = '\\';
            int endIndex = path.LastIndexOf(charRange);
            
            return path.Substring(endIndex + 1);
        }

        public static string FileNameWithoutExtension(string path)
        {
            path = FileNameFromPath(path);
            Char dotChar = '.';
            int endIndex = path.LastIndexOf(dotChar);
            string s =  path.Substring(0, endIndex);
            return s;
        }
        public static void CreateFolder(string FilePath)
        {
            try
            {
                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }
            }
            catch (Exception)
            {
                // handle them here
            }
        }
        public static string ConvertDateTime()
        {
            string name = "";
            DateTime datetime = DateTime.Now;
            name = datetime.Year.ToString() + datetime.Month.ToString() + datetime.Day.ToString();
            return name;
        }
        public static List<string> searchExtension(string fileName)
        {
            string base_dir = "D:\\Saved\\2017425\\";
            string file_dir = base_dir + "files";
            string image_dir = base_dir + "images";
            string thumb_dir = base_dir + "thumbs";

            String[] allfiles = System.IO.Directory.GetFiles(base_dir, "*.*", System.IO.SearchOption.AllDirectories);

            List<string> listFile = new List<string>();
            foreach (string item in allfiles)
            {
                string filename = FileNameFromPath(item);
                if (splitFileName(filename).Equals(fileName))
                {
                    listFile.Add(filename);
                }
            }
            return listFile;
        }
        public static string splitFileName(string filename)
        {
            Char charRange = '.';
            int endIndex = filename.LastIndexOf(charRange);

            return filename.Substring(0, endIndex);
        }
    }
}
