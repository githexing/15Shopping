using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Library
{
    public class ServiceHandler : IHttpHandler
    {
        public virtual void ProcessRequest(HttpContext context)
        {

        }
        public string ResultJson(ResultType resultType, string message, object data)
        {
            var Content = new AjaxResult { state = resultType.ToString(), message = message, data = data };
            IsoDateTimeConverter dtConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm':'ss" };
            return JsonConvert.SerializeObject(Content, dtConverter);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public bool upload(HttpContext context,string type, out string filenName)
        {
            filenName = "";
            var f = context.Request.Files["img"];
            if (context.Request.Files["img"] == null)
                return false;
            if (context.Request.Files["img"].ContentLength <= 0 )
                return false;
            try
            {
                string s = ".jpg";
                string filepath = context.Server.MapPath("/upload");
                string dateDir = DateTime.Now.ToString("yyyyMM");
                string name = Util.GetUniqueIndentifier(20);

                if (!Directory.Exists(filepath))
                    Directory.CreateDirectory(filepath);
                filepath += "/" + type;
                if (!Directory.Exists(filepath))
                    Directory.CreateDirectory(filepath);
                filepath += "/" + dateDir;
                if (!Directory.Exists(filepath))
                    Directory.CreateDirectory(filepath);

                filenName = string.Format("/upload/{0}/{1}/{2}{3}", type, dateDir, name , s);

                string path = context.Server.MapPath(filenName);
                context.Request.Files["img"].SaveAs(path);

                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
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
                    //context.Response.Write(folder + "/" + saveName);
                    return true;
                }
                else
                {
                    context.Response.Write("上传失败");
                    File.Delete(path); //删除文件  
                    LogHelper.SaveLog("上传的图片无效", "upload");
                    return false;
                }

                //if (new ImageThumbnail(path).ReducedImage(0.9, path))
                //{
                //    return true;
                //}
                //else if (File.Exists(path))
                //{
                //    File.Delete(path);
                //    LogHelper.SaveLog("上传的图片无效", "upload");
                //    return false;
                //}     
            }
            catch (Exception ex)
            {
                LogHelper.SaveLog(ex.ToString(), "upload");
            }
            
            return false;
        }
        //public bool upload(HttpContext context,out string path)
        //{
        //    HttpRequest Request = context.Request;
        //    string filenName = "";
        //    string re = "";
        //    path = "";
        //    try
        //    {
        //        using (context.Request.InputStream)
        //        {
        //            string s = ".jpg";
        //            byte[] bytes = new byte[Request.InputStream.Length];
        //            Request.InputStream.Read(bytes, 0, bytes.Length);
        //            Request.InputStream.Seek(0, SeekOrigin.Begin);//设置当前流的位置
        //                                                          //Request.InputStream.Position = 0;
        //            Request.InputStream.Flush();
        //            Request.InputStream.Close();
        //            Request.InputStream.Dispose();
        //            string name = Util.GetUniqueIndentifier(20);
        //            filenName = "/upload/" + name + s;
        //            path = context.Server.MapPath(filenName);
        //            FileStream fs = new FileStream(path, FileMode.Create);
        //            BinaryWriter bw = new BinaryWriter(fs);
        //            bw.Write(bytes);
        //            bw.Close();
        //            fs.Close();
        //            re = filenName;

        //            return true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelper.SaveLog(ex.ToString(),"upload");
        //        return false;
        //    }
        //}
    }
}
