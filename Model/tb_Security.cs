using System;

namespace lgk.Model
{
    /// <summary>
    /// tb_Security:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tb_Security
    {
        public tb_Security()
		{}
		#region Model

        /// <summary>
        /// 编号
        /// </summary>		
        private int _securityid;
        public int SecurityID
        {
            get { return _securityid; }
            set { _securityid = value; }
        }
        /// <summary>
        /// 密保问题
        /// </summary>		
        private string _question;
        public string Question
        {
            get { return _question; }
            set { _question = value; }
        }
        /// <summary>
        /// 添加者ID
        /// </summary>		
        private int _adduserid;
        public int AddUserID
        {
            get { return _adduserid; }
            set { _adduserid = value; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>		
        private DateTime _adddate;
        public DateTime AddDate
        {
            get { return _adddate; }
            set { _adddate = value; }
        }
        /// <summary>
        /// 修改者ID
        /// </summary>		
        private int _edituserid;
        public int EditUserID
        {
            get { return _edituserid; }
            set { _edituserid = value; }
        }
        /// <summary>
        /// 修改时间
        /// </summary>		
        private DateTime _editdate;
        public DateTime EditDate
        {
            get { return _editdate; }
            set { _editdate = value; }
        }
        /// <summary>
        /// 状态
        /// </summary>		
        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        #endregion
    }
}
