using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeMap_BUILDER_
{
    class JavaCompiler
    {
        public JavaCompiler()
        {
            packBuilder();
        }

        private void packBuilder()
        {
            string programFileFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cMapBuildFolder = programFileFolder + @"\cubemapBUILDER\temp\";
            string statusFile = cMapBuildFolder + @"status.txt";

            string uuid_ = UUIDHandling.getUUID();
            string packName = uuid_ + "_§9sky overlay";

            string packNameFolder = cMapBuildFolder + packName + @"\assets\minecraft\mcpatcher\sky\world0\";
            Directory.CreateDirectory(packNameFolder);

            string packMcMeta = cMapBuildFolder + packName + "\\pack.mcmeta";
            string skyProp = packNameFolder + @"\sky6.properties";

            using (StreamWriter config = new StreamWriter(statusFile))
            {
                config.WriteLine("creating pack.mcmeta...");
            }

            using (FileStream fs = File.Create(packMcMeta)) { }
            using (StreamWriter config = new StreamWriter(packMcMeta))
            {
                config.WriteLine("{");
                config.WriteLine("\t" + "\"pack\":  {" );
                config.WriteLine("\t\t" + "\"pack_format\": 1,");
                config.WriteLine("\t\t" + "\"description\": \"§7cubemap_builder §b[swim services]\"");
                config.WriteLine("\t" + "}");
                config.WriteLine("}");
            }

            File.Move(cMapBuildFolder + "cubemap.png", packNameFolder + "starfield03.png");
            File.Copy(packNameFolder + "starfield03.png", packNameFolder + "cloud1.png");
            File.Copy(packNameFolder + "starfield03.png", packNameFolder + "cloud2.png");

            using (StreamWriter config = new StreamWriter(statusFile))
            {
                config.WriteLine("creating starfield03.png...");
            }

            string mcpatcherFolder = programFileFolder + @"\cBUILD_assets\mcpatcher\";
            File.Copy(mcpatcherFolder + "sky1.properties", packNameFolder + "sky1.properties");
            File.Copy(mcpatcherFolder + "sky2.properties", packNameFolder + "sky2.properties");
            File.Copy(mcpatcherFolder + "sky3.properties", packNameFolder + "sky3.properties");
            File.Copy(mcpatcherFolder + "sky4.properties", packNameFolder + "sky4.properties");
            File.Copy(mcpatcherFolder + "sky6.properties", packNameFolder + "sky6.properties");
            File.Copy(mcpatcherFolder + "sky7.properties", packNameFolder + "sky7.properties");
            File.Copy(mcpatcherFolder + "sky8.properties", packNameFolder + "sky8.properties");
            File.Copy(mcpatcherFolder + "sky_sunflare.png", packNameFolder + "sky_sunflare.png");
            File.Copy(mcpatcherFolder + "starfield01.png", packNameFolder + "starfield01.png");

            using (StreamWriter config = new StreamWriter(statusFile))
            {
                config.WriteLine("adding constant sky.properties...");
            }

            File.Copy(cMapBuildFolder + "pack.png", cMapBuildFolder + packName + @"\pack.png");

            using (StreamWriter config = new StreamWriter(statusFile))
            {
                config.WriteLine("adding pack.png...");
            }

            string startPath = cMapBuildFolder + packName;
            string zipPath = cMapBuildFolder + packName + ".zip";

            using (StreamWriter config = new StreamWriter(statusFile))
            {
                config.WriteLine("zipping " + packName + "...");
            }

            ZipFile.CreateFromDirectory(startPath, zipPath);

            string desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            File.Move(cMapBuildFolder + packName + ".zip", DirectoryHandling.getDirectory() + @"\" + packName + ".zip");

            Directory.Delete(cMapBuildFolder + packName, true);
        }
    }
}
