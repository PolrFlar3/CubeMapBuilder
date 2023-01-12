using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace CubeMap_BUILDER_
{
    class ImageHandling
    {
        public ImageHandling()
        {
            string programFileFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cMapBuildFolder = programFileFolder + @"\cubemapBUILDER\temp\";
            string statusFile = cMapBuildFolder + @"status.txt";

            int count = 0;
            string base64 = "";
            foreach (string filename in Directory.GetFiles(cMapBuildFolder))
            {
                if (filename.Contains("base64") == true)
                {
                    count += 1;
                    using (StreamReader sr = new StreamReader(filename))
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            base64 = sr.ReadLine();
                        }
                    }

                    base64 = base64.Remove(0, 22);
                    string filePath = programFileFolder + @"\cubemapBUILDER\temp\" + count + @".png";
                    File.WriteAllBytes(filePath, Convert.FromBase64String(base64));
                }
            }

            /*
                        File.Move(cMapBuildFolder + "1.png", cMapBuildFolder + "back.png");
                        File.Move(cMapBuildFolder + "2.png", cMapBuildFolder + "bottom.png");
                        File.Move(cMapBuildFolder + "3.png", cMapBuildFolder + "front.png");
                        File.Move(cMapBuildFolder + "4.png", cMapBuildFolder + "left.png");
                        File.Move(cMapBuildFolder + "5.png", cMapBuildFolder + "right.png");
                        File.Move(cMapBuildFolder + "6.png", cMapBuildFolder + "top.png");*/

            File.Delete(cMapBuildFolder + "back_base64.txt");
            File.Delete(cMapBuildFolder + "bottom_base64.txt");
            File.Delete(cMapBuildFolder + "front_base64.txt");
            File.Delete(cMapBuildFolder + "left_base64.txt");
            File.Delete(cMapBuildFolder + "right_base64.txt");
            File.Delete(cMapBuildFolder + "top_base64.txt");
            File.Delete(cMapBuildFolder + "complete.txt");
        }
        public static int getImageWidth()
        {
            string programFileFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cMapBuildFolder = programFileFolder + @"\cubemapBUILDER\temp\";

            Bitmap image = new Bitmap(cMapBuildFolder + "input.jpg");
            return image.Width;
        }
        public static int getImageHeight()
        {
            string programFileFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cMapBuildFolder = programFileFolder + @"\cubemapBUILDER\temp\";

            Bitmap image = new Bitmap(cMapBuildFolder + "input.jpg");
            return image.Height;
        }
    }
}
