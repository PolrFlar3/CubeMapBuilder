using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeMap_BUILDER_
{
    class BedrockCompiler
    {
        public BedrockCompiler()
        {
            packBuilder();
        }

        private void packBuilder()
        {
            string programFileFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cMapBuildFolder = programFileFolder + @"\cubemapBUILDER\temp\";

            string uuid_ = UUIDHandling.getUUID();
            string packName = uuid_ + "_§9sky overlay[BE]";

            string packNameFolder = cMapBuildFolder + packName;
            string packNameFolderFull = cMapBuildFolder + packName + @"\textures\environment\overworld_cubemap\";
            Directory.CreateDirectory(packNameFolderFull);

            string bedrockFolder = programFileFolder + @"\cBUILD_assets\bedrock\";
            File.Copy(bedrockFolder + "manifest.json", packNameFolder + "\\manifest.json");

            Guid uuid1 = Guid.NewGuid();
            string uuid1_ = uuid1.ToString();

            Guid uuid2 = Guid.NewGuid();
            string uuid2_ = uuid2.ToString();

            string[] fileLine = File.ReadAllLines(packNameFolder + "\\manifest.json");
            fileLine[4] = "\t\t\"name\": \"" + packName + "\",";
            fileLine[5] = "\t\t\"uuid\": \"" + uuid1 + "\",";
            fileLine[13] = "\t\t\"uuid\": \"" + uuid2 + "\",";
            File.WriteAllLines(packNameFolder + "\\manifest.json", fileLine);

            File.Move(cMapBuildFolder + "cubemap_0.png", packNameFolderFull + "cubemap_0.png");
            File.Move(cMapBuildFolder + "cubemap_1.png", packNameFolderFull + "cubemap_1.png");
            File.Move(cMapBuildFolder + "cubemap_2.png", packNameFolderFull + "cubemap_2.png");
            File.Move(cMapBuildFolder + "cubemap_3.png", packNameFolderFull + "cubemap_3.png");
            File.Move(cMapBuildFolder + "cubemap_4.png", packNameFolderFull + "cubemap_4.png");
            File.Move(cMapBuildFolder + "cubemap_5.png", packNameFolderFull + "cubemap_5.png");

            File.Move(cMapBuildFolder + "pack.png", packNameFolder + @"\pack_icon.png");

            string startPath = cMapBuildFolder + packName;
            string zipPath = cMapBuildFolder + packName + ".zip";

            ZipFile.CreateFromDirectory(startPath, zipPath);
            File.Move(cMapBuildFolder + packName + ".zip", cMapBuildFolder + packName + ".mcpack");

            string desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            File.Move(cMapBuildFolder + packName + ".mcpack", DirectoryHandling.getDirectory() + @"\" + packName + ".mcpack");
            File.Delete(cMapBuildFolder + "cubemap.png");

            Directory.Delete(cMapBuildFolder + packName, true);
        }
    }
}
