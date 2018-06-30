using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace lgk.Model
{
    //AppLog
    public class AppLog
    {

        /// <summary>
        /// ID
        /// </summary>		
        private long _id;
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// UserID
        /// </summary>		
        private long _userid;
        public long UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// UserCode
        /// </summary>		
        private string _usercode;
        public string UserCode
        {
            get { return _usercode; }
            set { _usercode = value; }
        }
        /// <summary>
        /// UserName
        /// </summary>		
        private string _username;
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        /// <summary>
        /// Longitude
        /// </summary>		
        private string _longitude;
        public string Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }
        /// <summary>
        /// MAC
        /// </summary>		
        private string _mac;
        public string MAC
        {
            get { return _mac; }
            set { _mac = value; }
        }
        /// <summary>
        /// PhoneVersion
        /// </summary>		
        private string _phoneversion;
        public string PhoneVersion
        {
            get { return _phoneversion; }
            set { _phoneversion = value; }
        }
        /// <summary>
        /// PhoneBrand
        /// </summary>		
        private string _phonebrand;
        public string PhoneBrand
        {
            get { return _phonebrand; }
            set { _phonebrand = value; }
        }
        /// <summary>
        /// PhoneSystem
        /// </summary>		
        private string _phonesystem;
        public string PhoneSystem
        {
            get { return _phonesystem; }
            set { _phonesystem = value; }
        }
        /// <summary>
        /// AddTime
        /// </summary>		
        private DateTime _addtime;
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }
        /// <summary>
        /// OpType
        /// </summary>		
        private int _optype;
        public int OpType
        {
            get { return _optype; }
            set { _optype = value; }
        }
        /// <summary>
        /// Msg
        /// </summary>		
        private string _msg;
        public string Msg
        {
            get { return _msg; }
            set { _msg = value; }
        }
        /// <summary>
        /// Mobile
        /// </summary>		
        private string _mobile;
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }

    }
}

