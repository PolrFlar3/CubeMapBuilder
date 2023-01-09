using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.IO;

namespace CubeMap_BUILDER_
{
    class CubeMapHandling
    {
        public CubeMapHandling()
        {
            Horzion();

            cleanUp();
            BlendFX blend = new BlendFX();

            BlendedHorizonCrop();

            buildCubeMap();
        }

        private int getImageSize()
        {
            string programFileFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cMapBuildFolder = programFileFolder + @"\cubemapBUILDER\temp\";
            Bitmap image = new Bitmap(cMapBuildFolder + "2.png");
            int imageWidth = image.Width;
            image.Dispose();
            return imageWidth;
        }

        private void Horzion()
        {
            string programFileFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cMapBuildFolder = programFileFolder + @"\cubemapBUILDER\temp\";

            int imageSize = getImageSize();
            Bitmap horizonCanvas = new Bitmap(imageSize, imageSize * 3);
            using (var graphics = Graphics.FromImage(horizonCanvas))
            {
                //clear
            }
            horizonCanvas.Save(cMapBuildFolder + "horizon_canvas.png");

            Bitmap top = new Bitmap(cMapBuildFolder + "6.png");
            Bitmap front = new Bitmap(cMapBuildFolder + "3.png");
            Bitmap bottom = new Bitmap(cMapBuildFolder + "2.png");
            Bitmap horizonSrc = new Bitmap(cMapBuildFolder + "horizon_canvas.png");

            using (var graphics = Graphics.FromImage(horizonSrc))
            {
                graphics.DrawImage(top, 0, 0, top.Width, top.Height);
                graphics.DrawImage(front, 0, horizonSrc.Height / 3, front.Width, front.Height);
                graphics.DrawImage(bottom, 0, (horizonSrc.Height * 2) / 3, bottom.Width, bottom.Height);
            }

            horizonSrc.Save(cMapBuildFolder + "horizon.png");

            HorizonCrop();
            HorizonMirror();

            horizonSrc.Dispose();
            horizonCanvas.Dispose();

            top.Dispose();
            front.Dispose();
            bottom.Dispose();
        }
        
        private void HorizonCrop()
        {
            string programFileFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cMapBuildFolder = programFileFolder + @"\cubemapBUILDER\temp\";

            Bitmap horizonHalf = new Bitmap(cMapBuildFolder + "horizon.png");
            Rectangle rect = new Rectangle(0, 0, horizonHalf.Width / 2, horizonHalf.Height);
            Bitmap crop = horizonHalf.Clone(rect, horizonHalf.PixelFormat);
            crop.Save(cMapBuildFolder + "horizon_half_1.png");
            crop.Dispose();

            rect = new Rectangle(horizonHalf.Width / 2, 0, horizonHalf.Width / 2, horizonHalf.Height);
            crop = horizonHalf.Clone(rect, horizonHalf.PixelFormat);
            crop.Save(cMapBuildFolder + "horizon_half_2.png");

            crop.Dispose();
            horizonHalf.Dispose();
        }

        private void HorizonMirror()
        {
            string programFileFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cMapBuildFolder = programFileFolder + @"\cubemapBUILDER\temp\";

            Bitmap horizonHalf = new Bitmap(cMapBuildFolder + "horizon_half_1.png");
            horizonHalf.RotateFlip(RotateFlipType.RotateNoneFlipX);
            horizonHalf.Save(cMapBuildFolder + "horizon_half_1.png");

            Bitmap horizonSrc = new Bitmap(cMapBuildFolder + "horizon.png");
            Bitmap mirrorHalf = new Bitmap(cMapBuildFolder + "horizon_half_1.png");

            using (var graphics = Graphics.FromImage(horizonSrc))
            {
                graphics.DrawImage(mirrorHalf, horizonSrc.Width / 2, 0, mirrorHalf.Width, mirrorHalf.Height);
            }

            horizonSrc.Save(cMapBuildFolder + "horizon_.png");
            horizonSrc.Dispose();
            horizonHalf.Dispose();
            mirrorHalf.Dispose();
        }

        private void cleanUp()
        {
            string programFileFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cMapBuildFolder = programFileFolder + @"\cubemapBUILDER\temp\";

            File.Delete(cMapBuildFolder + "horizon.png");
            File.Delete(cMapBuildFolder + "horizon_half_1.png");
            File.Delete(cMapBuildFolder + "horizon_canvas.png");

            File.Move(cMapBuildFolder + "horizon_.png", cMapBuildFolder + "horizon.png");
            File.Move(cMapBuildFolder + "horizon_half_2.png", cMapBuildFolder + "horizon_overlay.png");
        }

        private void BlendedHorizonCrop()
        {
            string programFileFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cMapBuildFolder = programFileFolder + @"\cubemapBUILDER\temp\";

            Bitmap image = new Bitmap(cMapBuildFolder + "back.png");
            int imageSize = image.Width;

            Bitmap horizon = new Bitmap(cMapBuildFolder + "horizon.png");
            Rectangle rect = new Rectangle(0, 0, imageSize, imageSize);
            Bitmap crop = horizon.Clone(rect, horizon.PixelFormat);
            crop.Save(cMapBuildFolder + "top.png");
            crop.Dispose();

            rect = new Rectangle(0, horizon.Height / 3, imageSize, imageSize);
            crop = horizon.Clone(rect, horizon.PixelFormat);
            crop.Save(cMapBuildFolder + "front.png");
            crop.Dispose();

            rect = new Rectangle(0, (2 * horizon.Height) / 3, imageSize, imageSize);
            crop = horizon.Clone(rect, horizon.PixelFormat);
            crop.Save(cMapBuildFolder + "bottom.png");
            crop.Dispose();
            horizon.Dispose();
            image.Dispose();

            File.Delete(cMapBuildFolder + "horizon.png");
        }

        private void buildCubeMap()
        {
            string programFileFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cMapBuildFolder = programFileFolder + @"\cubemapBUILDER\temp\";

            Bitmap image = new Bitmap(cMapBuildFolder + "back.png");
            int imageSize = image.Width;

            Bitmap cubemap_canvas = new Bitmap(imageSize * 3, imageSize * 2);
            int getCanvasWidth = cubemap_canvas.Width;
            int getCanvasHeight = cubemap_canvas.Height;
            Bitmap back = new Bitmap(cMapBuildFolder + "back.png");
            Bitmap bottom = new Bitmap(cMapBuildFolder + "bottom.png");
            Bitmap front = new Bitmap(cMapBuildFolder + "front.png");
            Bitmap left = new Bitmap(cMapBuildFolder + "left.png");
            Bitmap right = new Bitmap(cMapBuildFolder + "right.png");
            Bitmap top = new Bitmap(cMapBuildFolder + "top.png");

            File.Copy(cMapBuildFolder + "front.png", cMapBuildFolder + "cubemap_0.png");
            File.Copy(cMapBuildFolder + "right.png", cMapBuildFolder + "cubemap_1.png");
            File.Copy(cMapBuildFolder + "back.png", cMapBuildFolder + "cubemap_2.png");
            File.Copy(cMapBuildFolder + "left.png", cMapBuildFolder + "cubemap_3.png");
            File.Copy(cMapBuildFolder + "top.png", cMapBuildFolder + "cubemap_4.png");
            File.Copy(cMapBuildFolder + "bottom.png", cMapBuildFolder + "cubemap_5.png");

            using (var graphics = Graphics.FromImage(cubemap_canvas))
            {
                //clear
            }
            cubemap_canvas.Save(cMapBuildFolder + "cubemap_canvas.png");

            using (var graphics = Graphics.FromImage(cubemap_canvas))
            {
                graphics.DrawImage(bottom, 0, 0, imageSize, imageSize);
                graphics.DrawImage(top, getCanvasWidth / 3, 0, imageSize, imageSize);
                graphics.DrawImage(back, (2 * getCanvasWidth) / 3, 0, imageSize, imageSize);
                graphics.DrawImage(left, 0, getCanvasHeight / 2, imageSize, imageSize);
                graphics.DrawImage(front, getCanvasWidth / 3, getCanvasHeight / 2, imageSize, imageSize);
                graphics.DrawImage(right, (2 * getCanvasWidth) / 3, getCanvasHeight / 2, imageSize, imageSize);
            }

            cubemap_canvas.Save(cMapBuildFolder + "cubemap.png");
            cubemap_canvas.Dispose();
            back.Dispose();
            image.Dispose();
            bottom.Dispose();
            front.Dispose();
            left.Dispose();
            right.Dispose();
            top.Dispose();

            File.Copy(cMapBuildFolder + "front.png", cMapBuildFolder + "pack.png");

            //File.Delete(cMapBuildFolder + "input.jpg");
            File.Delete(cMapBuildFolder + "back.png");
            File.Delete(cMapBuildFolder + "bottom.png");
            File.Delete(cMapBuildFolder + "front.png");
            File.Delete(cMapBuildFolder + "left.png");
            File.Delete(cMapBuildFolder + "right.png");
            File.Delete(cMapBuildFolder + "top.png");
            File.Delete(cMapBuildFolder + "top.png");
            File.Delete(cMapBuildFolder + "cubemap_canvas.png");
        }
    }
}
