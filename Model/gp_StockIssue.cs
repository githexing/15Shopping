using System;
namespace lgk.Model
{
	/// <summary>
	/// gp_StockIssue:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class gp_StockIssue
	{
		public gp_StockIssue()
		{}
		#region Model
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
        /// Issueamount
        /// </summary>		
        private decimal _issueamount;
        public decimal IssueAmount
        {
            get { return _issueamount; }
            set { _issueamount = value; }
        }
        /// <summary>
        /// Surplusamount
        /// </summary>		
        private decimal _surplusamount;
        public decimal SurplusAmount
        {
            get { return _surplusamount; }
            set { _surplusamount = value; }
        }
        /// <summary>
        /// Saleamount
        /// </summary>		
        private decimal _saleamount;
        public decimal SaleAmount
        {
            get { return _saleamount; }
            set { _saleamount = value; }
        }
        /// <summary>
        /// Addtime
        /// </summary>		
        private DateTime _addtime;
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }
		#endregion Model

	}
}

