using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace Web
{
    public class ImgeHandel
    {
        public enum FileExtension
        {
            Jpg = 255216,
            Gif = 7173,
            Bmp = 6677,
            Png = 13780,
            Rar = 8297,
            Exe = 7790,
            Xml = 6063,
            Html = 6033,
            Aspx = 239187,
            Cs = 117115,
            Js = 119105,
            Txt = 210187,
            Sql = 255254
        }
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>
        public  string MakeThumbPic(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            Image originalImage = Image.FromFile(originalImagePath);
            string imgsrc = "";

            int towidth = width;
            int toheight = height;


            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;


            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形）
                    break;
                case "W"://指定宽，高按比例
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                case "CutA"://指定高宽裁减（不变形）自定义
                    if (ow <= towidth && oh <= toheight)
                    {
                        x = -(towidth - ow) / 2;
                        y = -(toheight - oh) / 2;
                        ow = towidth;
                        oh = toheight;
                    }
                    else
                    {
                        if (ow > oh)//宽大于高 
                        {
                            x = 0;
                            y = -(ow - oh) / 2;
                            oh = ow;
                        }
                        else//高大于宽 
                        {
                            y = 0;
                            x = -(oh - ow) / 2;
                            ow = oh;
                        }
                    }
                    break;
                default:
                    break;
            }


            //新建一个bmp图片
            Image bitmap = new System.Drawing.Bitmap(towidth, toheight);
            //Image bitmap2 = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);


            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;


            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;


            //清空画布并以白色背景色填充
            g.Clear(Color.White);


            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
             new Rectangle(x, y, ow, oh),
             GraphicsUnit.Pixel);
            Bitmap bmp2 = new Bitmap(1024, 768, PixelFormat.Format16bppRgb555);
            //将第一个bmp拷贝到bmp2中
            Graphics draw = Graphics.FromImage(bmp2);
            draw.DrawImage(bitmap, 0, 0);
            bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Png);
            imgsrc = thumbnailPath;
            originalImage.Dispose();
            bitmap.Dispose();
            g.Dispose();
            return imgsrc;
            //try
            //{
            //    //以jpg格式保存缩略图
            //    bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Png);
            //}
            //catch (System.Exception e)
            //{
            //    throw e;
            //}
            //finally
            //{
            //    originalImage.Dispose();
            //    bitmap.Dispose();
            //    g.Dispose();
            //}
        }
        /// <summary>
        ///图片检测类    是否允许
        /// </summary>
        public static bool IsAllowedExtension(HttpPostedFile oFile, FileExtension[] fileEx)
        {
            int fileLen = oFile.ContentLength;
            var imgArray = new byte[fileLen];
            oFile.InputStream.Read(imgArray, 0, fileLen);
            var ms = new MemoryStream(imgArray);
            var br = new System.IO.BinaryReader(ms);
            string fileclass = "";
            try
            {
                byte buffer = br.ReadByte();
                fileclass = buffer.ToString(CultureInfo.InvariantCulture);
                buffer = br.ReadByte();
                fileclass += buffer.ToString(CultureInfo.InvariantCulture);
            }
            catch
            {
            }
            br.Close();
            ms.Close();
            foreach (FileExtension fe in fileEx)
            {
                if (Int32.Parse(fileclass) == (int)fe) return true;
            }
            return false;
        }
        /// <summary>
        /// 上传前检查图片是不是安全
        /// </summary>
        public static bool IsSecureUploadPhoto(HttpPostedFile oFile)
        {
            bool isPhoto = false;
            string fileExtension = System.IO.Path.GetExtension(oFile.FileName).ToLower();
            string[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg", ".bmp" };
            for (int i = 0; i < allowedExtensions.Length; i++)
            {
                if (fileExtension == allowedExtensions[i])
                {
                    isPhoto = true;
                    break;
                }
            }
            if (!isPhoto)
            {
                return false;
            }
            FileExtension[] fe = { FileExtension.Bmp, FileExtension.Gif, FileExtension.Jpg, FileExtension.Png };
            if (IsAllowedExtension(oFile, fe)) return true;
            else return false;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
    
}
