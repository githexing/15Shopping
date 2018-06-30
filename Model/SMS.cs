using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
    /// <summary>
    /// SMS:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SMS
    {
        public SMS()
        { }
        #region Model
        private long _id;
        private long _touserid = 0;
        private string _tousercode;
        private string _tophone;
        private string _smscontent;
        private DateTime? _publishtime;
        private string _scode;
        private DateTime? _validtime;
        private int _sendnum = 0;
        private int _isvalid = 0;
        private int _isdeleted = 0;
        private int _typeid = 0;

        /// <summary>
        /// 
        /// </summary>
        public long ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long ToUserID
        {
            set { _touserid = value; }
            get { return _touserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ToUserCode
        {
            set { _tousercode = value; }
            get { return _tousercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ToPhone
        {
            set { _tophone = value; }
            get { return _tophone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SMSContent
        {
            set { _smscontent = value; }
            get { return _smscontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PublishTime
        {
            set { _publishtime = value; }
            get { return _publishtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SCode
        {
            set { _scode = value; }
            get { return _scode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ValidTime
        {
            set { _validtime = value; }
            get { return _validtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SendNum
        {
            set { _sendnum = value; }
            get { return _sendnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsValid
        {
            set { _isvalid = value; }
            get { return _isvalid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsDeleted
        {
            set { _isdeleted = value; }
            get { return _isdeleted; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        #endregion Model

    }
}
