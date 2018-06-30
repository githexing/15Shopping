using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.IO;

/// <summary>
/// XmlManage 的摘要说明
/// </summary>
namespace Library
{

    public class XmlHelper
    {
        protected string strXmlFile;
        protected XmlDocument objXmlDoc = new XmlDocument();
        /// <summary>
        /// 实例化一个XML操作类
        /// </summary>
        /// <param name="XmlFile">XML文件的路径</param>
        public XmlHelper(string XmlFile)
        {
            //
            // TODO: 在这里加入建构函式的程式码
            //
            try
            {
                objXmlDoc.Load(XmlFile);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            strXmlFile = XmlFile;
        }
        /// <summary>
        /// 返回某种节点的个数
        /// </summary>
        /// <param name="xpath">节点路径</param>
        /// <returns></returns>
        public int GetNodeNumber(string xpath)
        {
            return objXmlDoc.SelectNodes(xpath).Count;
        }
        /// <summary>
        /// 查找数据。返回一个DataView
        /// </summary>
        /// <param name="XmlPathNode">节点路径</param>
        /// <returns></returns>
        public DataView GetData(string XmlPathNode)
        {
            DataSet ds = new DataSet();
            StringReader read = new StringReader(objXmlDoc.SelectSingleNode(XmlPathNode).OuterXml);
            ds.ReadXml(read);
            return ds.Tables[0].DefaultView;
        }
        /// <summary>
        /// 更新节点内容。
        /// </summary>
        /// <param name="XmlPathNode">节点路径</param>
        /// <param name="Content">内容</param>
        public void Replace(string XmlPathNode, string Content)
        {
            objXmlDoc.SelectSingleNode(XmlPathNode).InnerText = Content;
        }
        /// <summary>
        /// 更新节点属性，不带内容
        /// </summary>
        /// <param name="XmlPathNode">节点路径</param>
        /// <param name="Attribute">属性名称</param>
        /// <param name="AttributeContent">属性值</param>
        public void ReplaceAttribute(string XmlPathNode,string Attribute,string AttributeContent)
        {
            objXmlDoc.SelectSingleNode(XmlPathNode).Attributes[Attribute].InnerText = AttributeContent;
        }
        /// <summary>
        /// 获取节点的值
        /// </summary>
        /// <param name="XmlPathNode">节点路径</param>
        /// <param name="Content">内容</param>
        public string  GetNodes(string XmlPathNode)
        {
            return objXmlDoc.SelectSingleNode(XmlPathNode).InnerText;
        }
        /// <summary>
        /// 获取节点属性
        /// </summary>
        /// <param name="XmlPathNode">节点路径</param>
        /// <param name="Attribute">属性名</param>
        /// <returns>属性值</returns>
        public string GetNodeAttribute(string XmlPathNode, string Attribute)
        {
            return objXmlDoc.SelectSingleNode(XmlPathNode).Attributes[Attribute].InnerText;
        }
        /// <summary>
        /// 删除一个节点。
        /// </summary>
        /// <param name="Node"></param>
        public void Delete(string Node)
        {
            string mainNode = Node.Substring(0, Node.LastIndexOf("/"));
            XmlNode mnode=objXmlDoc.SelectSingleNode(mainNode);
            XmlNode delnode = objXmlDoc.SelectSingleNode(Node);
            if (mnode != null && delnode != null)
            {
                mnode.RemoveChild(delnode);
            }
        }

        public void InsertNode(string MainNode, string ChildNode, string Element, string Content)
        {
            //插入一节点和此节点的一子节点。
            XmlNode objRootNode = objXmlDoc.SelectSingleNode(MainNode);
            XmlElement objChildNode = objXmlDoc.CreateElement(ChildNode);
            objRootNode.AppendChild(objChildNode);
            XmlElement objElement = objXmlDoc.CreateElement(Element);
            objElement.InnerText = Content;
            objChildNode.AppendChild(objElement);
        }

        public void InsertElement(string MainNode, string Element, string Attrib, string AttribContent, string Content)
        {
            //插入一个节点，带一属性。
            XmlNode objNode = objXmlDoc.SelectSingleNode(MainNode);
            XmlElement objElement = objXmlDoc.CreateElement(Element);
            objElement.SetAttribute(Attrib, AttribContent);
            objElement.InnerText = Content;
            objNode.AppendChild(objElement);
        }
        /// <summary>
        /// 插入一个节点,只带属性不带Text
        /// </summary>
        /// <param name="MainNode"></param>
        /// <param name="Element"></param>
        /// <param name="Attrib"></param>
        /// <param name="AttribContent"></param>
        public void InsertElement(string MainNode, string Element, string Attrib, string AttribContent)
        {
            XmlNode objNode = objXmlDoc.SelectSingleNode(MainNode);
            XmlElement objElement = objXmlDoc.CreateElement(Element);
            objElement.SetAttribute(Attrib, AttribContent);
            objNode.AppendChild(objElement);
        }

        public void InsertElement(string MainNode, string Element, string Content)
        {
            //插入一个节点，不带属性。
            XmlNode objNode = objXmlDoc.SelectSingleNode(MainNode);
            XmlElement objElement = objXmlDoc.CreateElement(Element);
            objElement.InnerText = Content;
            objNode.AppendChild(objElement);
        }

        public void Save()
        {
            //保存文档。
            try
            {
                objXmlDoc.Save(strXmlFile);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            objXmlDoc = null;
        }
    }
}