using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace CubeMap_BUILDER_
{
    class BlendFX
    {
        public BlendFX()
        {
            BlendCrop();
            Blender();
            BlendMerge();
            Blend();
            cleanUp();
        }

        private void BlendCrop()
        {
            string programFileFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cMapBuildFolder = programFileFolder + @"\cubemapBUILDER\temp\";

            Bitmap horizonHalf = new Bitmap(cMapBuildFolder + "horizon_overlay.png");
            Rectangle rect = new Rectangle(0, 0, horizonHalf.Width / 2, horizonHalf.Height);
            Bitmap crop = horizonHalf.Clone(rect, horizonHalf.PixelFormat);
            crop.Save(cMapBuildFolder + "horizon_overlay_.png");

            horizonHalf.Dispose();
            crop.Dispose();

        }

        private void Blender()
        {
            string programFileFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cMapBuildFolder = programFileFolder + @"\cubemapBUILDER\temp\";


            Bitmap image = new Bitmap(cMapBuildFolder + "horizon_overlay_.png");
            //Debug.WriteLine(image.Width + ", " + image.Height);
            double alpha = 0;

            if (image.Width >= 256)
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        int blend = image.Width / 256;

                        if (x == 0)
                        {
                            //
                        }
                        else
                        {
                            if (x % blend == 0)
                            {
                                if (alpha < 255)
                                {
                                    alpha += 1;
                                }
                                else { }
                            }
                        }

                        for (int y = 0; y < image.Height; y++)
                        {
                            Color colorGrab = image.GetPixel(x, y);
                            int red = colorGrab.R;
                            int green = colorGrab.G;
                            int blue = colorGrab.B;

                            Color color = Color.FromArgb(Convert.ToInt32(alpha), red, green, blue);
                            image.SetPixel(x, y, color);
                        }
                    }
                }
            }
            else
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        int blend = 1;

                        if (x == 0)
                        {
                            //
                        }
                        else
                        {
                            if (x % blend == 0)
                            {
                                if (alpha < 255)
                                {
                                    alpha += 1;
                                }
                                else { }
                            }
                        }

                        for (int y = 0; y < image.Height; y++)
                        {
                            Color colorGrab = image.GetPixel(x, y);
                            int red = colorGrab.R;
                            int green = colorGrab.G;
                            int blue = colorGrab.B;

                            Color color = Color.FromArgb(Convert.ToInt32(alpha), red, green, blue);
                            image.SetPixel(x, y, color);
                        }
                    }
                }
            }
            
            image.Save(cMapBuildFolder + "horizon_blend.png");
            image.Dispose();

            image = new Bitmap(cMapBuildFolder + "horizon_overlay.png");
            using (var graphics = Graphics.FromImage(image))
            {
                for (int x = 0; x < image.Width / 2; x++)
                {
                    for (int y = 0; y < image.Height; y++)
                    {
                        image.SetPixel(x, y, Color.Transparent);
                    }
                }
            }

            image.Save(cMapBuildFolder + "horizon_blend_.png");

            image.Dispose();
        }

        private void BlendMerge()
        {
            string programFileFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cMapBuildFolder = programFileFolder + @"\cubemapBUILDER\temp\";

            Bitmap horizonSrc = new Bitmap(cMapBuildFolder + "horizon_blend_.png");
            Bitmap horizonBlend = new Bitmap(cMapBuildFolder + "horizon_blend.png");

            using (var graphics = Graphics.FromImage(horizonSrc))
            {
                graphics.DrawImage(horizonBlend, 0, 0, horizonBlend.Width, horizonBlend.Height);
            }

            horizonSrc.Save(cMapBuildFolder + "horizonMerge.png");
            horizonSrc.Dispose();
            horizonBlend.Dispose();
        }

        private void Blend()
        {
            string programFileFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cMapBuildFolder = programFileFolder + @"\cubemapBUILDER\temp\";

            Bitmap horizonSrc = new Bitmap(cMapBuildFolder + "horizon.png");
            Bitmap horizonBlend = new Bitmap(cMapBuildFolder + "horizonMerge.png");

            using (var graphics = Graphics.FromImage(horizonSrc))
            {
                graphics.DrawImage(horizonBlend, horizonSrc.Width / 2, 0, horizonBlend.Width, horizonBlend.Height);
            }

            horizonSrc.Save(cMapBuildFolder + "horizonBLEND.png");

            horizonSrc.Dispose();
            horizonBlend.Dispose();
        }

        private void cleanUp()
        {
            string programFileFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cMapBuildFolder = programFileFolder + @"\cubemapBUILDER\temp\";

            File.Delete(cMapBuildFolder + "horizon.png");
            File.Delete(cMapBuildFolder + "horizonMerge.png");
            File.Delete(cMapBuildFolder + "horizon_overlay_.png");
            File.Delete(cMapBuildFolder + "horizon_blend.png");
            File.Delete(cMapBuildFolder + "horizon_blend_.png");
            File.Delete(cMapBuildFolder + "horizon_overlay.png");
            File.Delete(cMapBuildFolder + "6.png");
            File.Delete(cMapBuildFolder + "3.png");
            File.Delete(cMapBuildFolder + "2.png");

            File.Move(cMapBuildFolder + "horizonBLEND.png", cMapBuildFolder + "horizon.png");

            Bitmap left = new Bitmap(cMapBuildFolder + "4.png");
            Bitmap right = new Bitmap(cMapBuildFolder + "5.png");
            Bitmap back = new Bitmap(cMapBuildFolder + "1.png");

            left.Save(cMapBuildFolder + "left.png");
            right.Save(cMapBuildFolder + "right.png");
            back.Save(cMapBuildFolder + "back.png");

            left.Dispose();
            right.Dispose();
            back.Dispose();

            File.Delete(cMapBuildFolder + "4.png");
            File.Delete(cMapBuildFolder + "5.png");
            File.Delete(cMapBuildFolder + "1.png");

            
        }
    }
}
