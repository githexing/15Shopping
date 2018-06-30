using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
    /// <summary>
	/// tb_TransferMachine:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class tb_TransferMachine
    {
        public tb_TransferMachine()
        { }
        #region Model
        private long _id;
        private long _userid = 0;
        private long _touserid = 0;
        private int _transfernum = 0;
        private DateTime? _transfertime;
        private int _transfertype = 0;
        private string _remark;
        private string _remarken;
        private string _toremark;
        private string _toremarken;
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
        public long ToUserID
        {
            set { _touserid = value; }
            get { return _touserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int TransferNum
        {
            set { _transfernum = value; }
            get { return _transfernum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? TransferTime
        {
            set { _transfertime = value; }
            get { return _transfertime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int TransferType
        {
            set { _transfertype = value; }
            get { return _transfertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RemarkEn
        {
            set { _remarken = value; }
            get { return _remarken; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ToRemark
        {
            set { _toremark = value; }
            get { return _toremark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ToRemarkEn
        {
            set { _toremarken = value; }
            get { return _toremarken; }
        }
        #endregion Model

    }
}
