using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CubeMap_BUILDER_
{
    class FileHandling
    {
        public FileHandling()
        {
            string programFileFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cMapBuildFolder = programFileFolder + @"\cubemapBUILDER\temp\";
            string pcInfoFolder = @"C:\pcinfo\";

            System.IO.DirectoryInfo mainFolder = new DirectoryInfo(cMapBuildFolder);

            if (!Directory.Exists(cMapBuildFolder))
            {
                Directory.CreateDirectory(cMapBuildFolder);
            }

            if (!Directory.Exists(pcInfoFolder))
            {
                Directory.CreateDirectory(pcInfoFolder);
            }

            string pcUser = pcInfoFolder + @"pcUser.txt";
            string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string userName = userPath.Remove(0, 9);
            using (FileStream fs = File.Create(pcUser)) 
            {
                string dataString = userName;
                byte[] info = new UTF8Encoding(true).GetBytes(dataString);
                fs.Write(info, 0, info.Length);
            }

            string dirConfig = programFileFolder + @"\cubemapBUILDER\directory.txt";

            if (!File.Exists(dirConfig))
            {
                using (FileStream fs = File.Create(dirConfig)) { }
            }
            string directoryCustom = DirectoryHandling.getDirectory();
            using (FileStream fs = File.Create(dirConfig))
            {
                string dataString = directoryCustom;
                byte[] info = new UTF8Encoding(true).GetBytes(dataString);
                fs.Write(info, 0, info.Length);
            }

            foreach (string filename in Directory.GetFiles(cMapBuildFolder))
            {
                System.IO.File.Delete(filename);
            }

            foreach (DirectoryInfo dir in mainFolder.GetDirectories())
            {
                dir.Delete(true);
            }

            string statusFile = cMapBuildFolder + @"status.txt";
            using (FileStream fs = File.Create(statusFile)) { }
        }
        public static double getStorageSpace()
        {
            DriveInfo pcInfo = new DriveInfo("C");

            double usedStorageMB = (pcInfo.AvailableFreeSpace) / 1000000;
            return usedStorageMB;
        }
    }
}
