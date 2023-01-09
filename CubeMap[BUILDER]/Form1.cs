using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace CubeMap_BUILDER_
{
    public partial class CubeMap_UI : Form
    {
        public CubeMap_UI()
        {
            InitializeComponent();
        }


        System.Windows.Forms.Timer refresher = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer statusCheck = new System.Windows.Forms.Timer();
        private void CubeMap_UI_Load(object sender, EventArgs e)
        {
            FileHandling setup = new FileHandling();

            double availableSpace = FileHandling.getStorageSpace();
            Debug.WriteLine(availableSpace);
            Debug.WriteLine(Environment.UserName);
            if (availableSpace < 1000)
            {
                MessageBox.Show("There is not enough space\nNeed atleast 1000MB of freespace", "File Error");
                Application.ExitThread();
            }

            refresher.Interval = 1000;
            refresher.Tick += new System.EventHandler(refresh);
            refresher.Start();

            statusCheck.Interval = 10;
            statusCheck.Tick += new System.EventHandler(status);
            statusCheck.Start();
        }

        int bedrock = 0;
        int java = 0;
        bool fileEnabled = true;
        int imageWidth;
        int imageHeight;

        private void file_button_Click(object sender, EventArgs e)
        {
            if (fileEnabled == false)
            {
                MessageBox.Show("Currently building pack", "Build Cooldown");
            }
            else
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Image Files(*.JPG)|*.JPG|All files (*.*)|*.*";
                    ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                    ofd.Multiselect = false;
                    //int fileCount = 0;

                    string programFileFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    string cMapBuildFolder = programFileFolder + @"\cubemapBUILDER\temp\";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string filename in ofd.FileNames)
                        {
                            console_label.Text = Path.GetFileName(filename) + "\n\n";
                            System.IO.File.Copy(filename, cMapBuildFolder + "input.jpg");
                            Debug.WriteLine((filename));

                            imageWidth = ImageHandling.getImageWidth();
                            imageHeight = ImageHandling.getImageHeight();
                        }
                    }
                }
            }         
        }
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private void build_button_Click(object sender, EventArgs e)
        {
            string programFileFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cMapBuildFolder = programFileFolder + @"\cubemapBUILDER\temp\";
            string statusFile = cMapBuildFolder + @"status.txt";

            string statusContent = "";
            using (StreamReader sr = new StreamReader(statusFile))
            {
                for (int i = 0; i < 1; i++)
                {
                    statusContent = sr.ReadLine();
                }
            }

            //////////////////////////

            if (statusContent == "building")
            {
                MessageBox.Show("Your pack is still being built", "Building");
            }
            else
            {
                if (imageWidth < 3840 && imageHeight < 2160)
                {
                    MessageBox.Show("Image is too small to be converted\nImage has to be 3840x2160 or higher", "Image Error");
                    System.IO.File.Delete(cMapBuildFolder + "input.jpg");
                }
                else
                {
                    string inputJPG = cMapBuildFolder + "input.jpg";
                    if (!System.IO.File.Exists(inputJPG))
                    {
                        MessageBox.Show("Insert an image", "No Image");
                    }
                    else
                    {
                        using (StreamWriter config = new StreamWriter(statusFile))
                        {
                            config.WriteLine("building");
                        }
                        console_label.Text = "building...";
                        console_label.ForeColor = Color.FromArgb(0, 0, 255);
                        Task.Run(() => buildMsg());
                        timer.Interval = 1000;
                        timer.Tick += button_cooldown;
                        timer.Start();
                        build_button.Enabled = false;
                        refresher.Start();

                        Process.Start(@"C:\cBUILD_assets\compiler\cubemapCOMPILER");
                    }
                }     
            }
        }

        private void buildMsg()
        {
            MessageBox.Show("Your pack is currently being built", "Sucessful Build");
        }

        void button_cooldown(object sender, System.EventArgs e)
        {
            build_button.Enabled = true;
            fileEnabled = true;
            timer.Stop();
        }

        private void refresh(object sender, EventArgs e)
        {
            string programFileFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cMapBuildFolder = programFileFolder + @"\cubemapBUILDER\temp\";

            Debug.WriteLine("*");
            int fileCount = 0;
            foreach (string filename in Directory.GetFiles(cMapBuildFolder))
            {
                if (filename.Contains("base64") == true || filename.Contains("complete") == true)
                {
                    fileCount += 1;
                }
            }
            if (fileCount == 7)
            {
                Process[] _proceses = null;
                _proceses = Process.GetProcessesByName("cubemapCOMPILER");
                foreach (Process proces in _proceses)
                {
                    proces.Kill();
                }
                Task.Run(() => build());
                refresher.Stop();
            }
        }

        private void status(object sender, EventArgs e)
        {
            string programFileFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cMapBuildFolder = programFileFolder + @"\cubemapBUILDER\temp\";
            string statusFile = cMapBuildFolder + @"status.txt";

            string statusContent = "";
            using (StreamReader sr = new StreamReader(statusFile))
            {
                for (int i = 0; i < 1; i++)
                {
                    statusContent = sr.ReadLine();
                }
            }

            if (statusContent == "pack created")
            {
                console_label.Text = "pack created";
                console_label.ForeColor = Color.FromArgb(0, 0, 255);
            }
        }

        private void build()
        {
            string programFileFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cMapBuildFolder = programFileFolder + @"\cubemapBUILDER\temp\";
            string statusFile = cMapBuildFolder + @"status.txt";

            Debug.WriteLine("building...");

            ImageHandling imageHandling = new ImageHandling();
            CubeMapHandling buildCube = new CubeMapHandling();
            if (bedrock == 0 && java == 0)
            {
                BedrockCompiler bedrockCompiler = new BedrockCompiler();
            }
            else if (bedrock == 1 && java == 0)
            {
                BedrockCompiler bedrockCompiler = new BedrockCompiler();
            }
            else if (bedrock == 0 && java == 1)
            {
                JavaCompiler javaCompiler = new JavaCompiler();
            }
            else if (bedrock == 1 && java == 1)
            {
                JavaCompiler javaCompiler = new JavaCompiler();
                BedrockCompiler bedrockCompiler = new BedrockCompiler();
            }

            System.IO.File.Delete(cMapBuildFolder + "input.jpg");
            using (StreamWriter config = new StreamWriter(statusFile))
            {
                config.WriteLine("pack created");
            }
        }

        private void bedrock_option_CheckStateChanged(object sender, EventArgs e)
        {
            if (bedrock_option.CheckState == check.CheckState)
            {
                bedrock = 1;
            }
            if (bedrock_option.CheckState == uncheck.CheckState)
            {
                bedrock = 0;
            }
        }

        private void java_option_CheckStateChanged(object sender, EventArgs e)
        {
            if (java_option.CheckState == check.CheckState)
            {
                java = 1;
            }
            if (java_option.CheckState == uncheck.CheckState)
            {
                java = 0;
            }
        }
    }
}
