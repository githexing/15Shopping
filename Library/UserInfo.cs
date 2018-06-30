using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

namespace Library
{
    /// <summary>
    /// UserInfo 的摘要说明
    /// </summary>
    public class UserInfo
    {
        private int _UserID;
        private string _UserName;
        private Hashtable _role;
        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        public Hashtable role
        {
            get { return _role; }
            set { _role = value; }
        }
        public UserInfo(string UserName,int UserType)
        {
            //if (UserType == 1)
            //{
                this.UserName = UserName;
                this.UserID = UserRole.GetManageID(UserName);
                this.role = UserRole.UroleList(UserID,UserType);
            //}
            //else
            //{
            //    this.UserID = UserRole.GetUserID(UserName);
            //    this.UserName = UserName;
            //    this.role = UserRole.UroleList(UserID);
            //}
        }
    }
}