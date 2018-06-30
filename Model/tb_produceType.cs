using System;
namespace lgk.Model
{
	/// <summary>
	/// tb_produceType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_produceType
	{
		public tb_produceType()
		{}
		#region Model
		private int _id;
		private int _parentid;
		private string _typename;
		private int? _type01;
		private int? _type02;
		private decimal? _type03;
		private decimal? _type04;
		private string _type05;
		private string _type06;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TypeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Type01
		{
			set{ _type01=value;}
			get{return _type01;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Type02
		{
			set{ _type02=value;}
			get{return _type02;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Type03
		{
			set{ _type03=value;}
			get{return _type03;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Type04
		{
			set{ _type04=value;}
			get{return _type04;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Type05
		{
			set{ _type05=value;}
			get{return _type05;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Type06
		{
			set{ _type06=value;}
			get{return _type06;}
		}
		#endregion Model

	}
}

