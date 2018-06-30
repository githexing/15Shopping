using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
    /// <summary>
    /// tb_userRecord:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tb_userRecord
    {
        public tb_userRecord()
        { }
        #region Model
        private int _id;
        private string _recordname;
        private DateTime _recordtime;
        private decimal _remoney;
        private int _retype;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string recordName
        {
            set { _recordname = value; }
            get { return _recordname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime recordTime
        {
            set { _recordtime = value; }
            get { return _recordtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal reMoney
        {
            set { _remoney = value; }
            get { return _remoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int reType
        {
            set { _retype = value; }
            get { return _retype; }
        }
        #endregion Model

    }
}
