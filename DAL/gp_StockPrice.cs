using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:gp_StockPrice
	/// </summary>
	public partial class gp_StockPrice
	{
		public gp_StockPrice()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from gp_StockPrice");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(lgk.Model.gp_StockPrice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into gp_StockPrice(");
			strSql.Append("PriceType,BusinessTime,UpPrice,OpenMoney,Price,Up_DropDayNumber,LastOpenMoney,LastUp_DropDayNumber,AddTime,Price01,Price02,Price03,Price04,Price05,Price06,Price07,Price08)");
			strSql.Append(" values (");
			strSql.Append("@PriceType,@BusinessTime,@UpPrice,@OpenMoney,@Price,@Up_DropDayNumber,@LastOpenMoney,@LastUp_DropDayNumber,@AddTime,@Price01,@Price02,@Price03,@Price04,@Price05,@Price06,@Price07,@Price08)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PriceType", SqlDbType.Int,4),
					new SqlParameter("@BusinessTime", SqlDbType.DateTime),
					new SqlParameter("@UpPrice", SqlDbType.Decimal,9),
					new SqlParameter("@OpenMoney", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@Up_DropDayNumber", SqlDbType.Int,4),
					new SqlParameter("@LastOpenMoney", SqlDbType.Decimal,9),
					new SqlParameter("@LastUp_DropDayNumber", SqlDbType.DateTime),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@Price01", SqlDbType.Int,4),
					new SqlParameter("@Price02", SqlDbType.Int,4),
					new SqlParameter("@Price03", SqlDbType.Int,4),
					new SqlParameter("@Price04", SqlDbType.DateTime),
					new SqlParameter("@Price05", SqlDbType.DateTime),
					new SqlParameter("@Price06", SqlDbType.Decimal,9),
					new SqlParameter("@Price07", SqlDbType.Decimal,9),
					new SqlParameter("@Price08", SqlDbType.Decimal,9)};
			parameters[0].Value = model.PriceType;
			parameters[1].Value = model.BusinessTime;
			parameters[2].Value = model.UpPrice;
			parameters[3].Value = model.OpenMoney;
			parameters[4].Value = model.Price;
			parameters[5].Value = model.Up_DropDayNumber;
			parameters[6].Value = model.LastOpenMoney;
			parameters[7].Value = model.LastUp_DropDayNumber;
			parameters[8].Value = model.AddTime;
			parameters[9].Value = model.Price01;
			parameters[10].Value = model.Price02;
			parameters[11].Value = model.Price03;
			parameters[12].Value = model.Price04;
			parameters[13].Value = model.Price05;
			parameters[14].Value = model.Price06;
			parameters[15].Value = model.Price07;
			parameters[16].Value = model.Price08;

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
		public bool Update(lgk.Model.gp_StockPrice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update gp_StockPrice set ");
			strSql.Append("PriceType=@PriceType,");
			strSql.Append("BusinessTime=@BusinessTime,");
			strSql.Append("UpPrice=@UpPrice,");
			strSql.Append("OpenMoney=@OpenMoney,");
			strSql.Append("Price=@Price,");
			strSql.Append("Up_DropDayNumber=@Up_DropDayNumber,");
			strSql.Append("LastOpenMoney=@LastOpenMoney,");
			strSql.Append("LastUp_DropDayNumber=@LastUp_DropDayNumber,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("Price01=@Price01,");
			strSql.Append("Price02=@Price02,");
			strSql.Append("Price03=@Price03,");
			strSql.Append("Price04=@Price04,");
			strSql.Append("Price05=@Price05,");
			strSql.Append("Price06=@Price06,");
			strSql.Append("Price07=@Price07,");
			strSql.Append("Price08=@Price08");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@PriceType", SqlDbType.Int,4),
					new SqlParameter("@BusinessTime", SqlDbType.DateTime),
					new SqlParameter("@UpPrice", SqlDbType.Decimal,9),
					new SqlParameter("@OpenMoney", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@Up_DropDayNumber", SqlDbType.Int,4),
					new SqlParameter("@LastOpenMoney", SqlDbType.Decimal,9),
					new SqlParameter("@LastUp_DropDayNumber", SqlDbType.DateTime),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@Price01", SqlDbType.Int,4),
					new SqlParameter("@Price02", SqlDbType.Int,4),
					new SqlParameter("@Price03", SqlDbType.Int,4),
					new SqlParameter("@Price04", SqlDbType.DateTime),
					new SqlParameter("@Price05", SqlDbType.DateTime),
					new SqlParameter("@Price06", SqlDbType.Decimal,9),
					new SqlParameter("@Price07", SqlDbType.Decimal,9),
					new SqlParameter("@Price08", SqlDbType.Decimal,9),
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.PriceType;
			parameters[1].Value = model.BusinessTime;
			parameters[2].Value = model.UpPrice;
			parameters[3].Value = model.OpenMoney;
			parameters[4].Value = model.Price;
			parameters[5].Value = model.Up_DropDayNumber;
			parameters[6].Value = model.LastOpenMoney;
			parameters[7].Value = model.LastUp_DropDayNumber;
			parameters[8].Value = model.AddTime;
			parameters[9].Value = model.Price01;
			parameters[10].Value = model.Price02;
			parameters[11].Value = model.Price03;
			parameters[12].Value = model.Price04;
			parameters[13].Value = model.Price05;
			parameters[14].Value = model.Price06;
			parameters[15].Value = model.Price07;
			parameters[16].Value = model.Price08;
			parameters[17].Value = model.ID;

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
			strSql.Append("delete from gp_StockPrice ");
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
			strSql.Append("delete from gp_StockPrice ");
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
		public lgk.Model.gp_StockPrice GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,PriceType,BusinessTime,UpPrice,OpenMoney,Price,Up_DropDayNumber,LastOpenMoney,LastUp_DropDayNumber,AddTime,Price01,Price02,Price03,Price04,Price05,Price06,Price07,Price08 from gp_StockPrice ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
};
			parameters[0].Value = ID;

			lgk.Model.gp_StockPrice model=new lgk.Model.gp_StockPrice();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PriceType"]!=null && ds.Tables[0].Rows[0]["PriceType"].ToString()!="")
				{
					model.PriceType=int.Parse(ds.Tables[0].Rows[0]["PriceType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BusinessTime"]!=null && ds.Tables[0].Rows[0]["BusinessTime"].ToString()!="")
				{
					model.BusinessTime=DateTime.Parse(ds.Tables[0].Rows[0]["BusinessTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpPrice"]!=null && ds.Tables[0].Rows[0]["UpPrice"].ToString()!="")
				{
					model.UpPrice=decimal.Parse(ds.Tables[0].Rows[0]["UpPrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OpenMoney"]!=null && ds.Tables[0].Rows[0]["OpenMoney"].ToString()!="")
				{
					model.OpenMoney=decimal.Parse(ds.Tables[0].Rows[0]["OpenMoney"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"]!=null && ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Up_DropDayNumber"]!=null && ds.Tables[0].Rows[0]["Up_DropDayNumber"].ToString()!="")
				{
					model.Up_DropDayNumber=int.Parse(ds.Tables[0].Rows[0]["Up_DropDayNumber"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LastOpenMoney"]!=null && ds.Tables[0].Rows[0]["LastOpenMoney"].ToString()!="")
				{
					model.LastOpenMoney=decimal.Parse(ds.Tables[0].Rows[0]["LastOpenMoney"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LastUp_DropDayNumber"]!=null && ds.Tables[0].Rows[0]["LastUp_DropDayNumber"].ToString()!="")
				{
					model.LastUp_DropDayNumber=DateTime.Parse(ds.Tables[0].Rows[0]["LastUp_DropDayNumber"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AddTime"]!=null && ds.Tables[0].Rows[0]["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price01"]!=null && ds.Tables[0].Rows[0]["Price01"].ToString()!="")
				{
					model.Price01=int.Parse(ds.Tables[0].Rows[0]["Price01"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price02"]!=null && ds.Tables[0].Rows[0]["Price02"].ToString()!="")
				{
					model.Price02=int.Parse(ds.Tables[0].Rows[0]["Price02"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price03"]!=null && ds.Tables[0].Rows[0]["Price03"].ToString()!="")
				{
					model.Price03=int.Parse(ds.Tables[0].Rows[0]["Price03"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price04"]!=null && ds.Tables[0].Rows[0]["Price04"].ToString()!="")
				{
					model.Price04=DateTime.Parse(ds.Tables[0].Rows[0]["Price04"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price05"]!=null && ds.Tables[0].Rows[0]["Price05"].ToString()!="")
				{
					model.Price05=DateTime.Parse(ds.Tables[0].Rows[0]["Price05"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price06"]!=null && ds.Tables[0].Rows[0]["Price06"].ToString()!="")
				{
					model.Price06=decimal.Parse(ds.Tables[0].Rows[0]["Price06"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price07"]!=null && ds.Tables[0].Rows[0]["Price07"].ToString()!="")
				{
					model.Price07=decimal.Parse(ds.Tables[0].Rows[0]["Price07"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price08"]!=null && ds.Tables[0].Rows[0]["Price08"].ToString()!="")
				{
					model.Price08=decimal.Parse(ds.Tables[0].Rows[0]["Price08"].ToString());
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
        public lgk.Model.gp_StockPrice GetModel(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,PriceType,BusinessTime,UpPrice,OpenMoney,Price,Up_DropDayNumber,LastOpenMoney,LastUp_DropDayNumber,AddTime,Price01,Price02,Price03,Price04,Price05,Price06,Price07,Price08 from gp_StockPrice ");
            strSql.Append(" where " + strWhere);


            lgk.Model.gp_StockPrice model = new lgk.Model.gp_StockPrice();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PriceType"] != null && ds.Tables[0].Rows[0]["PriceType"].ToString() != "")
                {
                    model.PriceType = int.Parse(ds.Tables[0].Rows[0]["PriceType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BusinessTime"] != null && ds.Tables[0].Rows[0]["BusinessTime"].ToString() != "")
                {
                    model.BusinessTime = DateTime.Parse(ds.Tables[0].Rows[0]["BusinessTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpPrice"] != null && ds.Tables[0].Rows[0]["UpPrice"].ToString() != "")
                {
                    model.UpPrice = decimal.Parse(ds.Tables[0].Rows[0]["UpPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OpenMoney"] != null && ds.Tables[0].Rows[0]["OpenMoney"].ToString() != "")
                {
                    model.OpenMoney = decimal.Parse(ds.Tables[0].Rows[0]["OpenMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price"] != null && ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Up_DropDayNumber"] != null && ds.Tables[0].Rows[0]["Up_DropDayNumber"].ToString() != "")
                {
                    model.Up_DropDayNumber = int.Parse(ds.Tables[0].Rows[0]["Up_DropDayNumber"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastOpenMoney"] != null && ds.Tables[0].Rows[0]["LastOpenMoney"].ToString() != "")
                {
                    model.LastOpenMoney = decimal.Parse(ds.Tables[0].Rows[0]["LastOpenMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastUp_DropDayNumber"] != null && ds.Tables[0].Rows[0]["LastUp_DropDayNumber"].ToString() != "")
                {
                    model.LastUp_DropDayNumber = DateTime.Parse(ds.Tables[0].Rows[0]["LastUp_DropDayNumber"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddTime"] != null && ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price01"] != null && ds.Tables[0].Rows[0]["Price01"].ToString() != "")
                {
                    model.Price01 = int.Parse(ds.Tables[0].Rows[0]["Price01"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price02"] != null && ds.Tables[0].Rows[0]["Price02"].ToString() != "")
                {
                    model.Price02 = int.Parse(ds.Tables[0].Rows[0]["Price02"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price03"] != null && ds.Tables[0].Rows[0]["Price03"].ToString() != "")
                {
                    model.Price03 = int.Parse(ds.Tables[0].Rows[0]["Price03"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price04"] != null && ds.Tables[0].Rows[0]["Price04"].ToString() != "")
                {
                    model.Price04 = DateTime.Parse(ds.Tables[0].Rows[0]["Price04"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price05"] != null && ds.Tables[0].Rows[0]["Price05"].ToString() != "")
                {
                    model.Price05 = DateTime.Parse(ds.Tables[0].Rows[0]["Price05"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price06"] != null && ds.Tables[0].Rows[0]["Price06"].ToString() != "")
                {
                    model.Price06 = decimal.Parse(ds.Tables[0].Rows[0]["Price06"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price07"] != null && ds.Tables[0].Rows[0]["Price07"].ToString() != "")
                {
                    model.Price07 = decimal.Parse(ds.Tables[0].Rows[0]["Price07"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price08"] != null && ds.Tables[0].Rows[0]["Price08"].ToString() != "")
                {
                    model.Price08 = decimal.Parse(ds.Tables[0].Rows[0]["Price08"].ToString());
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
			strSql.Append("select ID,PriceType,BusinessTime,UpPrice,OpenMoney,Price,Up_DropDayNumber,LastOpenMoney,LastUp_DropDayNumber,AddTime,Price01,Price02,Price03,Price04,Price05,Price06,Price07,Price08 ");
			strSql.Append(" FROM gp_StockPrice ");
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
			strSql.Append(" ID,PriceType,BusinessTime,UpPrice,OpenMoney,Price,Up_DropDayNumber,LastOpenMoney,LastUp_DropDayNumber,AddTime,Price01,Price02,Price03,Price04,Price05,Price06,Price07,Price08 ");
			strSql.Append(" FROM gp_StockPrice ");
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
			parameters[0].Value = "gp_StockPrice";
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

