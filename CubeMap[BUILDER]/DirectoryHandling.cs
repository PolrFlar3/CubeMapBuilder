using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeMap_BUILDER_
{
    class DirectoryHandling
    {
        public static string getDirectory()
        {
            string programFileFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cMapBuildFolder = programFileFolder + @"\cubemapBUILDER\temp\";

            string dirConfig = programFileFolder + @"\cubemapBUILDER\directory.txt";
            string dirContent = "";
            using (StreamReader sr = new StreamReader(dirConfig))
            {
                for (int i = 0; i < 1; i++)
                {
                    dirContent = sr.ReadLine();
                }
            }

            if (new FileInfo(dirConfig).Length == 0)
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            else
            {
                return dirContent;
            }
        }
    }
}
