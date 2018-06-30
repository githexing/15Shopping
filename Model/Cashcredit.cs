using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
    /// <summary>
    /// Cashcredit:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Cashcredit
    {
        public Cashcredit()
        { }
        #region Model

        /// <summary>
        /// 编号
        /// </summary>		
        private long _creditid;
        public long CreditID
        {
            get { return _creditid; }
            set { _creditid = value; }
        }
        /// <summary>
        /// 会员编号
        /// </summary>		
        private long _userid;
        public long UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        /// <summary>
        /// 购买数量
        /// </summary>		
        private int _bnumber;
        public int BNumber
        {
            get { return _bnumber; }
            set { _bnumber = value; }
        }
        /// <summary>
        /// 购买成交数量(单)
        /// </summary>		
        private int _btradenum;
        public int BTradeNum
        {
            get { return _btradenum; }
            set { _btradenum = value; }
        }
        /// <summary>
        /// 购买终止数量(单)
        /// </summary>		
        private int _bendnum;
        public int BEndNum
        {
            get { return _bendnum; }
            set { _bendnum = value; }
        }
        /// <summary>
        /// 购买信用值
        /// </summary>		
        private int _bvalues;
        public int BValues
        {
            get { return _bvalues; }
            set { _bvalues = value; }
        }
        /// <summary>
        /// 销售数量
        /// </summary>		
        private int _snumber;
        public int SNumber
        {
            get { return _snumber; }
            set { _snumber = value; }
        }
        /// <summary>
        /// 销售成交数量(单)
        /// </summary>		
        private int _stradenum;
        public int STradeNum
        {
            get { return _stradenum; }
            set { _stradenum = value; }
        }
        /// <summary>
        /// 销售终止数量(单)
        /// </summary>		
        private int _sendnum;
        public int SEndNum
        {
            get { return _sendnum; }
            set { _sendnum = value; }
        }
        /// <summary>
        /// 销售信用值
        /// </summary>		
        private int _svalues;
        public int SValues
        {
            get { return _svalues; }
            set { _svalues = value; }
        }

        #endregion
    }
}
