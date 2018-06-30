using System;
namespace lgk.Model
{
	/// <summary>
	/// gp_globeParam:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class gp_globeParam
	{
		public gp_globeParam()
		{}

		#region Model
        /// <summary>
        /// Id
        /// </summary>		
        private long _id;
        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// ParamName
        /// </summary>		
        private string _paramname;
        public string ParamName
        {
            get { return _paramname; }
            set { _paramname = value; }
        }
        /// <summary>
        /// ParamAmount
        /// </summary>		
        private decimal _paramamount;
        public decimal ParamAmount
        {
            get { return _paramamount; }
            set { _paramamount = value; }
        }
        /// <summary>
        /// ParamInt
        /// </summary>		
        private int _paramint;
        public int ParamInt
        {
            get { return _paramint; }
            set { _paramint = value; }
        }
        /// <summary>
        /// ParamVarchar
        /// </summary>		
        private string _paramvarchar;
        public string ParamVarchar
        {
            get { return _paramvarchar; }
            set { _paramvarchar = value; }
        }
        /// <summary>
        /// Remark
        /// </summary>		
        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        /// <summary>
        /// ParamType
        /// </summary>		
        private int _paramtype;
        public int ParamType
        {
            get { return _paramtype; }
            set { _paramtype = value; }
        }
        /// <summary>
        /// EndRemark
        /// </summary>		
        private string _endremark;
        public string EndRemark
        {
            get { return _endremark; }
            set { _endremark = value; }
        }
        /// <summary>
        /// IsEdit
        /// </summary>		
        private int _isedit;
        public int IsEdit
        {
            get { return _isedit; }
            set { _isedit = value; }
        }
		#endregion Model

	}
}

