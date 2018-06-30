using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
    /// <summary>
    /// tb_StockIssue:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tb_StockIssue
    {
        public tb_StockIssue()
		{}
        #region Model
        /// <summary>
        /// 编号
        /// </summary>		
        private int _issueid;
        public int IssueID
        {
            get { return _issueid; }
            set { _issueid = value; }
        }
        /// <summary>
        /// 发行量
        /// </summary>		
        private decimal _issueamount;
        public decimal IssueAmount
        {
            get { return _issueamount; }
            set { _issueamount = value; }
        }
        /// <summary>
        /// 剩余量
        /// </summary>		
        private decimal _surplusamount;
        public decimal SurplusAmount
        {
            get { return _surplusamount; }
            set { _surplusamount = value; }
        }
        /// <summary>
        /// 发行价格
        /// </summary>		
        private decimal _issueprice;
        public decimal IssuePrice
        {
            get { return _issueprice; }
            set { _issueprice = value; }
        }
        /// <summary>
        /// 发行期数
        /// </summary>		
        private int _periods;
        public int Periods
        {
            get { return _periods; }
            set { _periods = value; }
        }
        /// <summary>
        /// 发行时间
        /// </summary>		
        private DateTime _adddate;
        public DateTime AddDate
        {
            get { return _adddate; }
            set { _adddate = value; }
        }
        /// <summary>
        /// 是否在销售
        /// </summary>		
        private int _issell;
        public int IsSell
        {
            get { return _issell; }
            set { _issell = value; }
        }
        #endregion Model
    }
}
