using System;

namespace Library
{
    /// <summary>
    /// upfile 的摘要说明。
    /// </summary>
    public class upfile
    {
        private string path = null;
        private string fileType = null;
        private int sizes = 0;
        /// <summary>
        /// 初始化变量
        /// </summary>
        public upfile()
        {
            path = @"\uploadimages\"; //上传路径
            fileType = "jpg|gif|bmp";
            sizes = 200; //传文件的大小,默认200KB
        }

        /// <summary>
        /// 设置上传路径,如:uploadimages\
        /// </summary>
        public string Path
        {
            set
            {
                path = @"/" + value + @"/";
            }
        }

        /// <summary>
        /// 设置上传文件大小,单位为KB
        /// </summary>
        public int Sizes
        {
            set
            {
                sizes = value * 1024;
            }
        }

        /// <summary>
        /// 设置上传文件的类型,如:jpg|gif|bmp
        /// </summary>
        public string FileType
        {
            set
            {
                fileType = value;
            }
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="name">上传控件名称</param>
        /// <param name="creatDirectory">true则以当前时间创建文件夹,false则为设置的文件夹</param>
        /// <returns>返回上传图片的相对路径</returns>
        public string fileSaveAs(System.Web.UI.HtmlControls.HtmlInputFile name, bool creatDirectory)
        {
            try
            {
                string filePath = null;
                //以当前时间修改图片的名字或创建文件夹的名字
                string modifyFileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                //获得站点的物理路径
                string uploadFilePath = null;
                //如果为true则以当前时间创建文件夹,否则为设置的文件夹
                if (creatDirectory)
                {
                    uploadFilePath = System.Web.HttpContext.Current.Server.MapPath(".") + @"\" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + @"\";
                }
                else
                {
                    uploadFilePath = System.Web.HttpContext.Current.Server.MapPath(".") + path;
                }
                //获得文件的上传的路径
                string sourcePath = name.Value.Trim();
                //判断上传文件是否为空
                if (sourcePath == "" || sourcePath == null)
                {
                    message("您没有上传数据呀，是不是搞错了呀!");
                    return null;
                }
                //获得文件扩展名
                string tFileType = sourcePath.Substring(sourcePath.LastIndexOf(".") + 1);
                //获得上传文件的大小
                long strLen = name.PostedFile.ContentLength;
                //分解允许上传文件的格式
                string[] temp = fileType.Split('|');
                //设置上传的文件是否是允许的格式
                bool flag = false;
                //判断上传文件大小
                if (strLen >= sizes)
                {

                    message("上传的文件不能大于" + sizes + "KB");
                    return null;
                }
                //判断上传的文件是否是允许的格式
                foreach (string data in temp)
                {
                    if (data == tFileType)
                    {
                        flag = true;
                        break;
                    }
                }
                //如果为真允许上传,为假则不允许上传
                if (!flag)
                {
                    message("目前本系统支持的格式为:" + fileType);
                    return null;
                }
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(uploadFilePath);
                //判断文件夹否存在,不存在则创建
                if (!dir.Exists)
                {
                    dir.Create();
                }
                filePath = uploadFilePath + modifyFileName + "." + tFileType;
                name.PostedFile.SaveAs(filePath);
                filePath = path + modifyFileName + "." + tFileType;

                return filePath;

            }
            catch
            {
                //异常
                message("出现未知错误！");
                return null;
            }
        }

        private void message(string msg, string url)
        {
            System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('" + msg + "');window.location='" + url + "'</script>");
        }

        private void message(string msg)
        {
            System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('" + msg + "');</script>");
        }
    }
}
