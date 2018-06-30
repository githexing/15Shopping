using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
namespace Library
{
    [DefaultProperty("Text"), ToolboxData("<{0}:CheckCode runat=server></{0}:CheckCode>")]
    public class CheckCode : WebControl, IRequiresSessionState
    {
        private string text;

        private void CreateCheckCodeImage(string checkCode)
        {
            if ((checkCode != null) && !(checkCode.Trim() == string.Empty))
            {
                Bitmap image = new Bitmap((int)Math.Ceiling(checkCode.Length * 12.5), 0x16);
                Graphics g = Graphics.FromImage(image);
                try
                {
                    int i;
                    Random random = new Random();
                    g.Clear(Color.White);
                    for (i = 0; i < 0x2; i++)
                    {
                        int x1 = random.Next(image.Width);
                        int x2 = random.Next(image.Width);
                        int y1 = random.Next(image.Height);
                        int y2 = random.Next(image.Height);
                        g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                    }
                    Font font = new Font("Arial", 12f, FontStyle.Italic | FontStyle.Bold);
                    LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Red, Color.BlueViolet, 1.2f, true);
                    g.DrawString(checkCode, font, brush, (float)2f, (float)2f);
                    for (i = 0; i < 50; i++)
                    {
                        int x = random.Next(image.Width);
                        int y = random.Next(image.Height);
                        image.SetPixel(x, y, Color.FromArgb(random.Next()));
                    }
                    //g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                    MemoryStream ms = new MemoryStream();
                    image.Save(ms, ImageFormat.Png);
                    HttpContext.Current.Response.ClearContent();
                    HttpContext.Current.Response.ContentType = "image/Png";
                    HttpContext.Current.Response.BinaryWrite(ms.ToArray());
                }
                finally
                {
                    g.Dispose();
                    image.Dispose();
                }
            }
        }

        private string GenerateCheckCode()
        {
            string checkCode = string.Empty;
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                char code;
                int number = random.Next();
                if ((number % 2) == 0)
                {
                    code = (char)(0x30 + ((ushort)(number % 10)));
                }
                else
                {
                    code = (char)(0x41 + ((ushort)(number % 0x1a)));
                }
                if (((code == '0') || (code == 'o')) || (code == 'O'))
                {
                    code = 'H';
                }
                checkCode = checkCode + code.ToString();
            }
            //string code;
            //int num = random.Next(0, 10);
            //code = num.ToString();
            //checkCode = code + code + code + code;

            return checkCode;
        }

        public static string GetCode()
        {
            return HttpContext.Current.Session["CheckCode"].ToString();
        }

        protected override void Render(HtmlTextWriter output)
        {
            string checkCode = this.GenerateCheckCode();
            HttpContext.Current.Session["CheckCode"] = checkCode;
            this.CreateCheckCodeImage(checkCode);
        }

        [DefaultValue(""), Bindable(true), Category("Appearance")]
        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
            }
        }
    }
}
