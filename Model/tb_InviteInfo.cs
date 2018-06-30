using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace lgk.Model
{
    //tb_InviteInfo
    public class tb_InviteInfo
    {

        /// <summary>
        /// Id
        /// </summary>		
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// InviteInfo
        /// </summary>		
        private string _inviteinfo;
        public string InviteInfo
        {
            get { return _inviteinfo; }
            set { _inviteinfo = value; }
        }
        /// <summary>
        /// InviteRule
        /// </summary>		
        private string _inviterule;
        public string InviteRule
        {
            get { return _inviterule; }
            set { _inviterule = value; }
        }
        /// <summary>
        /// AppDownUrl
        /// </summary>		
        private string _appdownurl;
        public string AppDownUrl
        {
            get { return _appdownurl; }
            set { _appdownurl = value; }
        }
        /// <summary>
        /// ModifyTime
        /// </summary>		
        private DateTime _modifytime;
        public DateTime ModifyTime
        {
            get { return _modifytime; }
            set { _modifytime = value; }
        }
        /// <summary>
        /// Intro
        /// </summary>		
        private string _intro;
        public string Intro
        {
            get { return _intro; }
            set { _intro = value; }
        }
    }
}

