using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
    /// <summary>
	/// tb_LoginToken:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class tb_LoginToken
    {
        public tb_LoginToken()
        { }
        #region Model
        private long _id;
        private long _userid = 0;
        private string _smscode;
        private string _tokencode;
        private DateTime? _addtime;
        private DateTime? _endtime;
        private int _isvalid = 0;
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
        public long UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SmsCode
        {
            set { _smscode = value; }
            get { return _smscode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TokenCode
        {
            set { _tokencode = value; }
            get { return _tokencode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? EndTime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsValid
        {
            set { _isvalid = value; }
            get { return _isvalid; }
        }
        #endregion Model

    }
}
