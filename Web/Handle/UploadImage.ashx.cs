using Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Web.Handle
{
    /// <summary>
    /// UploadImage 的摘要说明
    /// </summary>
    public class UploadImage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request.Files.Count <= 0)
            {
                context.Response.Write("上传失败");
                return;
            }
            HttpPostedFile file = context.Request.Files[0];
            if (file != null)
            {
                try
                {
                    //图片保存的文件夹路径
                    string path = context.Server.MapPath("~/upload/");
                    //每天上传的图片一个文件夹
                    string folder = DateTime.Now.ToString("yyyyMMdd");
                    //如果文件夹不存在，则创建

                    if (!Directory.Exists(path + folder))
                    {
                        Directory.CreateDirectory(path + folder);
                    }
                    //上传图片的扩展名
                    string type = file.FileName.Substring(file.FileName.LastIndexOf('.'));
                    //保存图片的文件名
                    string saveName = Guid.NewGuid().ToString() + type;
                    //保存图片
                    file.SaveAs(path + folder + "/" + saveName);
                    string imgPath = path + folder + "/" + saveName;

                    FileStream fs = new FileStream(imgPath, FileMode.Open, FileAccess.Read);
                    BinaryReader reader = new BinaryReader(fs);
                    string fileClass;
                    byte buffer;
                    byte[] b = new byte[2];
                    buffer = reader.ReadByte();
                    b[0] = buffer;
                    fileClass = buffer.ToString();
                    buffer = reader.ReadByte();
                    b[1] = buffer;
                    fileClass += buffer.ToString();
                    reader.Close();
                    fs.Close();

                    if (fileClass == "255216" || fileClass == "7173" || fileClass == "6677" || fileClass == "13780")
                    {
                        //255216是jpg;7173是gif;6677是BMP,13780是PNG;7790是exe,8297是rar     
                        //Response.Write("图片可用");     
                        //保存到数据库中    
                        context.Response.Write(folder + "/" + saveName);
                    }
                    else
                    {
                        context.Response.Write("上传失败");
                        File.Delete(imgPath); //删除文件    
                        return;
                    }
                   
                }
                catch(Exception ex)
                {
                    LogHelper.SaveLog(ex.ToString(),"UploadImage");
                    context.Response.Write("上传失败");
                }
            }
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