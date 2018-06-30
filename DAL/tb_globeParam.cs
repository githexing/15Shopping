using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;

namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:tb_globeParam
	/// </summary>
	public partial class tb_globeParam
	{
		public tb_globeParam()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_globeParam");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(lgk.Model.tb_globeParam model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_globeParam(");
            strSql.Append("ParamName,ParamAmount,ParamInt,ParamVarchar,Remark,EndRemark,ParamType,IsEdit)");
			strSql.Append(" values (");
            strSql.Append("@ParamName,@ParamAmount,@ParamInt,@ParamVarchar,@Remark,@EndRemark,@ParamType,@IsEdit)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ParamName", SqlDbType.VarChar,50),
					new SqlParameter("@ParamAmount", SqlDbType.Decimal,9),
					new SqlParameter("@ParamInt", SqlDbType.Int,4),
					new SqlParameter("@ParamVarchar", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar),
					new SqlParameter("@EndRemark", SqlDbType.VarChar),
					new SqlParameter("@ParamType", SqlDbType.Int,4),
                    new SqlParameter("@IsEdit", SqlDbType.Int,4)};
			parameters[0].Value = model.ParamName;
			parameters[1].Value = model.ParamAmount;
			parameters[2].Value = model.ParamInt;
			parameters[3].Value = model.ParamVarchar;
			parameters[4].Value = model.Remark;
			parameters[5].Value = model.EndRemark;
			parameters[6].Value = model.ParamType;
            parameters[7].Value = model.IsEdit;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt64(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_globeParam model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_globeParam set ");
			strSql.Append("ParamName=@ParamName,");
			strSql.Append("ParamAmount=@ParamAmount,");
			strSql.Append("ParamInt=@ParamInt,");
			strSql.Append("ParamVarchar=@ParamVarchar,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("EndRemark=@EndRemark,");
			strSql.Append("ParamType=@ParamType");
            strSql.Append(" WHERE IsEdit=@IsEdit");
			strSql.Append(" AND ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ParamName", SqlDbType.VarChar,50),
					new SqlParameter("@ParamAmount", SqlDbType.Decimal,9),
					new SqlParameter("@ParamInt", SqlDbType.Int,4),
					new SqlParameter("@ParamVarchar", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar),
					new SqlParameter("@EndRemark", SqlDbType.VarChar),
					new SqlParameter("@ParamType", SqlDbType.Int,4),
                    new SqlParameter("@IsEdit", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.ParamName;
			parameters[1].Value = model.ParamAmount;
			parameters[2].Value = model.ParamInt;
			parameters[3].Value = model.ParamVarchar;
			parameters[4].Value = model.Remark;
			parameters[5].Value = model.EndRemark;
			parameters[6].Value = model.ParamType;
            parameters[7].Value = 1;
			parameters[8].Value = model.ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_globeParam ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_globeParam ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public lgk.Model.tb_globeParam GetModel(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ParamName,ParamAmount,ParamInt,ParamVarchar,Remark,EndRemark,ParamType,IsEdit from tb_globeParam ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)};
            parameters[0].Value = ID;

            lgk.Model.tb_globeParam model = new lgk.Model.tb_globeParam();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParamName"] != null && ds.Tables[0].Rows[0]["ParamName"].ToString() != "")
                {
                    model.ParamName = ds.Tables[0].Rows[0]["ParamName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ParamAmount"] != null && ds.Tables[0].Rows[0]["ParamAmount"].ToString() != "")
                {
                    model.ParamAmount = decimal.Parse(ds.Tables[0].Rows[0]["ParamAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParamInt"] != null && ds.Tables[0].Rows[0]["ParamInt"].ToString() != "")
                {
                    model.ParamInt = int.Parse(ds.Tables[0].Rows[0]["ParamInt"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParamVarchar"] != null && ds.Tables[0].Rows[0]["ParamVarchar"].ToString() != "")
                {
                    model.ParamVarchar = ds.Tables[0].Rows[0]["ParamVarchar"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null && ds.Tables[0].Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EndRemark"] != null && ds.Tables[0].Rows[0]["EndRemark"].ToString() != "")
                {
                    model.EndRemark = ds.Tables[0].Rows[0]["EndRemark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ParamType"] != null && ds.Tables[0].Rows[0]["ParamType"].ToString() != "")
                {
                    model.ParamType = int.Parse(ds.Tables[0].Rows[0]["ParamType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsEdit"] != null && ds.Tables[0].Rows[0]["IsEdit"].ToString() != "")
                {
                    model.IsEdit = int.Parse(ds.Tables[0].Rows[0]["IsEdit"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_globeParam GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID,ParamName,ParamAmount,ParamInt,ParamVarchar,Remark,EndRemark,ParamType,IsEdit from tb_globeParam");
            if (strWhere.Trim() != "")
                strSql.Append(" where " + strWhere);

            lgk.Model.tb_globeParam model = new lgk.Model.tb_globeParam();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParamName"] != null && ds.Tables[0].Rows[0]["ParamName"].ToString() != "")
                {
                    model.ParamName = ds.Tables[0].Rows[0]["ParamName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ParamAmount"] != null && ds.Tables[0].Rows[0]["ParamAmount"].ToString() != "")
                {
                    model.ParamAmount = decimal.Parse(ds.Tables[0].Rows[0]["ParamAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParamInt"] != null && ds.Tables[0].Rows[0]["ParamInt"].ToString() != "")
                {
                    model.ParamInt = int.Parse(ds.Tables[0].Rows[0]["ParamInt"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParamVarchar"] != null && ds.Tables[0].Rows[0]["ParamVarchar"].ToString() != "")
                {
                    model.ParamVarchar = ds.Tables[0].Rows[0]["ParamVarchar"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null && ds.Tables[0].Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EndRemark"] != null && ds.Tables[0].Rows[0]["EndRemark"].ToString() != "")
                {
                    model.EndRemark = ds.Tables[0].Rows[0]["EndRemark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ParamType"] != null && ds.Tables[0].Rows[0]["ParamType"].ToString() != "")
                {
                    model.ParamType = int.Parse(ds.Tables[0].Rows[0]["ParamType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsEdit"] != null && ds.Tables[0].Rows[0]["IsEdit"].ToString() != "")
                {
                    model.IsEdit = int.Parse(ds.Tables[0].Rows[0]["IsEdit"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select ID,ParamName,ParamAmount,ParamInt,ParamVarchar,Remark,EndRemark,ParamType,IsEdit ");
			strSql.Append(" FROM tb_globeParam ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
            strSql.Append(" ID,ParamName,ParamAmount,ParamInt,ParamVarchar,Remark,EndRemark,ParamType,IsEdit ");
			strSql.Append(" FROM tb_globeParam ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "tb_globeParam";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

