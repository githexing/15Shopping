using System;
using System.Collections.Generic;
using System.Text;

namespace Library {
    public class FileUpDownLoad {
        public static void DownloadFile(System.Web.HttpResponse response, string filePath) {
            response.Clear();
            response.ContentType = "application/x-zip-compressed";
            response.TransmitFile(filePath);
            response.End();
        }
        /// <summary>
        /// 上传文件并获得服务器上的文件名
        /// </summary>
        /// <param name="inputFile">上传控件</param>
        /// <param name="strAbsolutePath">绝对路径</param>
        /// <returns></returns>
        public static string UpLoadFile(System.Web.UI.HtmlControls.HtmlInputFile inputFile, string strAbsolutePath) {
            string strOldFilePath = inputFile.PostedFile.FileName;
            string strExtension = string.Empty;
            string strNewFilePath = string.Empty;
            if (strOldFilePath != null) {
                strNewFilePath = GetNewFileName(strOldFilePath);
                try {
                    inputFile.PostedFile.SaveAs(GetSavePath(strNewFilePath, strAbsolutePath));
                } catch {
                    throw new Exception(string.Format("{0}文件上传失败", strOldFilePath));
                }
            } else {
                throw new Exception("文件不存在，无法上传！");
            }
            return strNewFilePath;
        }
        
        /// <summary>
        /// 删除指定的文件
        /// </summary>
        /// <param name="absolutePath">文件不存在不会引发异常</param>
        public static void DeleteFile(string absolutePath) {
            System.IO.File.Delete(absolutePath);
        }
        /// <summary>
        /// 删除指定的文件
        /// </summary>
        /// <param name="fileName">文件不存在不会引发异常</param>
        /// <param name="absolutepath">文件不存在不会引发异常</param>
        public static void DeleteFile(string fileName, string absolutepath) {
            DeleteFile(GetSavePath(fileName, absolutepath));
        }
        /// <summary>
        /// 获得文件名的扩展名
        /// </summary>
        /// <param name="pathString"></param>
        /// <returns></returns>
        public static string GetPathStringExtension(string pathString) {
            if (pathString.Length > 0) {
                return pathString.Substring(pathString.LastIndexOf('.'));
            } else {
                throw new Exception("文件名为空，无法获取其扩展名！");
            }
        }
        /// <summary>
        /// 拼接文件绝对路径
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="absolutePath"></param>
        /// <returns></returns>
        public static string GetSavePath(string fileName, string absolutePath) {
            string savePath = string.Empty;
            if (absolutePath.LastIndexOf("\\") == absolutePath.Length) {
                savePath = absolutePath + fileName;
            } else {
                savePath = absolutePath + "\\" + fileName;
            }
            return savePath;
        }
        /// <summary>
        /// 获得一个唯一的文件名
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetNewFileName(string fileName) {
            string newFileName = string.Empty;
            string extension = GetPathStringExtension(fileName);
            return DateTime.Now.ToString("yyyyMMddHHmmss") +extension;

        }
        /// <summary>
        /// 修改上传的文件
        /// </summary>
        /// <param name="ffFile"></param>
        /// <param name="strAbsolutePath"></param>
        /// <param name="strOldFileName"></param>
        /// <returns></returns>
        public static string CoverFile(System.Web.UI.HtmlControls.HtmlInputFile ffFile, string strAbsolutePath, string strOldFileName) {
            if (ffFile.PostedFile.FileName != string.Empty) {
                if (strOldFileName != string.Empty) {
                    DeleteFile(strOldFileName, strAbsolutePath);
                }
                return UpLoadFile(ffFile, strAbsolutePath);
            } else {
                throw new Exception("文件不存在，无法上传！");
            }
        }
    }
}
