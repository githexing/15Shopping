using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
    /// <summary>
	/// tb_LockPosition:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class tb_LockPosition
    {
        public tb_LockPosition()
        { }
        #region Model
        private long _id;
        private long _userid = 0;
        private decimal _amount = 0M;
        private decimal _surplusamount = 0M;
        private decimal _releasemoney = 0M;
        private long _machineid = 0;
        private DateTime? _addtime;
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
        public decimal Amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal SurplusAmount
        {
            set { _surplusamount = value; }
            get { return _surplusamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal ReleaseMoney
        {
            set { _releasemoney = value; }
            get { return _releasemoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long MachineID
        {
            set { _machineid = value; }
            get { return _machineid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        #endregion Model

    }
}
