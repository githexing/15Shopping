using System;
using System.Collections.Generic;
using System.Text;
//添加命名空间
using System.Net.Mail;
using System.Net;

namespace Library
{
    /**/

    /// <summary>
    /// 发送电子邮件类
    /// </summary>
    public class MailHelper
    {
        /**/
        private string _txtHost;
        private string _UserName;
        private string _xtFrom;
        private string _txtPass;
        private string _txtTo;
        private string _txtSubject;
        private string _txtBody;
        private bool _isBodyHtml;
        private MailPriority _priority;
        private Encoding _encoding;
        private string[] _files;
        /// <summary>
        /// 电子邮件服务主机名称
        /// </summary>
        public string txtHost
        {
            get { return _txtHost; }
            set { _txtHost = value; }
        }
        /// <summary>
        /// 发件人用户名
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        /// <summary>
        /// 发送人地址
        /// </summary>
        public string xtFrom
        {
            get { return _xtFrom; }
            set { _xtFrom = value; }
        }
        /// <summary>
        /// 发信人密码
        /// </summary>
        public string txtPass
        {
            get { return _txtPass; }
            set { _txtPass = value; }
        }
        /// <summary>
        /// 收信人地址
        /// </summary>
        public string txtTo
        {
            get { return _txtTo; }
            set { _txtTo = value; }
        }
        /// <summary>
        /// 邮件标题
        /// </summary>
        public string txtSubject
        {
            get { return _txtSubject; }
            set { _txtSubject = value; }
        }
        /// <summary>
        /// 邮件内容
        /// </summary>
        public string txtBody
        {
            get { return _txtBody; }
            set { _txtBody = value; }
        }
        /// <summary>
        /// 是否采用HTML编码
        /// </summary>
        public bool isBodyHtml
        {
            get { return _isBodyHtml; }
            set { _isBodyHtml = value; }
        }
        /// <summary>
        /// 电子邮件的优先级别
        /// </summary>
        public MailPriority priority
        {
            get { return _priority; }
            set { _priority = value; }
        }
        /// <summary>
        /// 内容采用的编码方式
        /// </summary>
        public Encoding encoding
        {
            get { return _encoding; }
            set { _encoding = value; }
        }
        /// <summary>
        /// 附件
        /// </summary>
        public string[] files
        {
            get { return _files; }
            set { _files = value; }
        }
        /// <summary>
        /// 发送电子邮件函数
        /// </summary>
        public string SendMail()
        {
            //电子邮件附件
            Attachment data = null;
            //传送的电子邮件类
            MailMessage message = new MailMessage(xtFrom, txtTo);
            //设置标题
            message.Subject = txtSubject;
            //设置内容
            message.Body = txtBody;
            //是否采用HTML编码
            message.IsBodyHtml = isBodyHtml;
            //电子邮件的优先级别
            message.Priority = priority;
            //内容采用的编码方式
            message.BodyEncoding = encoding;
            try
            {
                //添加附件
                if (files.Length > 0 && files != null)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        //实例话电子邮件附件，并设置类型
                        data = new Attachment(files[i], System.Net.Mime.MediaTypeNames.Application.Octet);
                        //实例邮件内容
                        System.Net.Mime.ContentDisposition disposition = data.ContentDisposition;
                        //取得建档日期
                        disposition.CreationDate = System.IO.File.GetCreationTime(files[i]);
                        //取得附件修改日期
                        disposition.ModificationDate = System.IO.File.GetLastWriteTime(files[i]);
                        //取得读取日期
                        disposition.ReadDate = System.IO.File.GetLastAccessTime(files[i]);
                        //设定文件名称
                        System.IO.FileInfo fi = new System.IO.FileInfo(files[i]);
                        disposition.FileName = fi.Name.ToString();
                        //添加附件
                        message.Attachments.Add(data);
                    }
                }
                //实例从送电子邮件类
                SmtpClient client = new SmtpClient("465");
                //设置电子邮件主机名称
                client.Host = txtHost;
                client.EnableSsl = true;
                //取得寄信人认证
                client.Credentials = new NetworkCredential(UserName, txtPass);
                //发送电子邮件
                client.Send(message);
                return "邮件发送成功";
            }
            catch (Exception Err)
            {
                //返回错误信息
                return Err.Message;
            }
            finally
            {
                //销毁电子邮件附件
                if (data != null)
                {
                    data.Dispose();
                }
                //销毁传送的电子邮件实例
                message.Dispose();
            }
        }
    }
}

/*string[] a ={  };
        MailHelper nh = new MailHelper();
        nh.encoding = System.Text.ASCIIEncoding.UTF8;
        nh.files = a;
        nh.isBodyHtml = true;
        nh.priority = System.Net.Mail.MailPriority.Normal;
        nh.txtBody = "SDK 实现程序自删除注入IE后使用内存不过4500K 一个完整的DLL远程注入函数 一段仿真PE加载器行为的程序vc编写自己的壳之一：对pe文件OEP的修改Net Frame Work SDK 为在VB.Net实现个性化ListBox提供的工具 Wave文件格式VB程序最小化到系统托盘C#正则表达式小结c#读取XML参数Silverlight 完全中文解決方案Asp.Net 如何在Server端如何使用非系统默认安装字体?发送电子邮件类 文章出处：http://www.diybl.com/course/4_webprogram/asp.net/netjs/20071020/78364.html";
        nh.txtHost = "smtp.gmail.com";
        nh.txtPass = "13977196894";
        nh.txtSubject = "测试邮件";
        nh.txtTo = "ak9990@hotmail.com";
        nh.UserName = "maxuserid";
        nh.xtFrom = "maxuserid@gmail.com";
        nh.SendMail();*/