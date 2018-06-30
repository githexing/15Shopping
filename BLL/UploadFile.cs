/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-2-21 14:34:24 
 * 文 件 名：		b_upload.cs 
 * CLR 版本: 		2.0.50727.3053 
 * 创 建 人：		黎胜刚
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 备注描述：
**********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web.UI.WebControls; 
namespace BLL
{
    public class UploadFile
    {
        public static bool IsAllowedExtension(FileUpload fu, FileExtension[] fileEx)          
        {   
            int fileLen = fu.PostedFile.ContentLength;            
            byte[] imgArray = new byte[fileLen];             
            fu.PostedFile.InputStream.Read(imgArray, 0, fileLen);   
            MemoryStream ms = new MemoryStream(imgArray);          
            System.IO.BinaryReader br = new System.IO.BinaryReader(ms);    
            string fileclass = "";            
            byte buffer;             
            try           
            {   
                buffer = br.ReadByte();   
                fileclass = buffer.ToString();   
                buffer = br.ReadByte();   
                fileclass += buffer.ToString();   
            }   
            catch           
            {   
            }   
            br.Close();   
            ms.Close();   
            foreach (FileExtension fe in fileEx)         
            {   
                if (Int32.Parse(fileclass) == (int)fe)         
                    return true;            
            }   
            return false;         
        }   
    }

    public enum FileExtension
    {
        JPG = 255216,
        GIF = 7173,
        PNG = 13780,
        //SWF = 6787,
        RAR = 8297,
        WMV=4838,
        //ZIP = 8075,
        //_7Z = 55122
        // 255216 jpg;     
        // 7173 gif;     
        // 6677 bmp,     
        // 13780 png;     
        // 6787 swf     
        // 7790 exe dll,     
        // 8297 rar     
        // 8075 zip     
        // 55122 7z     
        // 6033 html     
        // 6063 xml     
        // 239187 aspx     
        // 117115 cs     
        // 119105 js     
        // 102100 txt     
        // 255254 sql  
    }
}

