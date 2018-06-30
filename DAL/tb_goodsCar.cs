using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
using System.Data;
namespace lgk.DAL
{

    /// <summary>
    /// 数据访问类:tb_goodsCar
    /// </summary>
    public partial class tb_goodsCar
    {
        public tb_goodsCar()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_goodsCar");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8)
            };
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_goodsCar model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_goodsCar(");
            strSql.Append("GoodsID,GoodsCode,GoodsName,Price,RealityPrice,TypeID,TypeIDName,GoodsType,GoodsTypeName,Pic1,Remarks,AddTime,Goods002,Goods005,Goods006,BuyUser,TotalMoney,TotalGoods006,ShopPrice,gColor,gSize)");
            strSql.Append(" values (");
            strSql.Append("@GoodsID,@GoodsCode,@GoodsName,@Price,@RealityPrice,@TypeID,@TypeIDName,@GoodsType,@GoodsTypeName,@Pic1,@Remarks,@AddTime,@Goods002,@Goods005,@Goods006,@BuyUser,@TotalMoney,@TotalGoods006,@ShopPrice,@gColor,@gSize)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsCode", SqlDbType.VarChar,100),
					new SqlParameter("@GoodsName", SqlDbType.VarChar,100),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@RealityPrice", SqlDbType.Decimal,9),
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@TypeIDName", SqlDbType.VarChar,100),
					new SqlParameter("@GoodsType", SqlDbType.Int,4),
					new SqlParameter("@GoodsTypeName", SqlDbType.VarChar,100),
					new SqlParameter("@Pic1", SqlDbType.VarChar,100),
					new SqlParameter("@Remarks", SqlDbType.VarChar,-1),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@Goods002", SqlDbType.Int,4),
					new SqlParameter("@Goods005", SqlDbType.Decimal,9),
					new SqlParameter("@Goods006", SqlDbType.Int,4),
					new SqlParameter("@BuyUser", SqlDbType.BigInt,8),
					new SqlParameter("@TotalMoney", SqlDbType.Decimal,9),
					new SqlParameter("@TotalGoods006", SqlDbType.Int,4),
					new SqlParameter("@ShopPrice", SqlDbType.Decimal,9),
					new SqlParameter("@gColor", SqlDbType.VarChar,20),
					new SqlParameter("@gSize", SqlDbType.VarChar,20)};
            parameters[0].Value = model.GoodsID;
            parameters[1].Value = model.GoodsCode;
            parameters[2].Value = model.GoodsName;
            parameters[3].Value = model.Price;
            parameters[4].Value = model.RealityPrice;
            parameters[5].Value = model.TypeID;
            parameters[6].Value = model.TypeIDName;
            parameters[7].Value = model.GoodsType;
            parameters[8].Value = model.GoodsTypeName;
            parameters[9].Value = model.Pic1;
            parameters[10].Value = model.Remarks;
            parameters[11].Value = model.AddTime;
            parameters[12].Value = model.Goods002;
            parameters[13].Value = model.Goods005;
            parameters[14].Value = model.Goods006;
            parameters[15].Value = model.BuyUser;
            parameters[16].Value = model.TotalMoney;
            parameters[17].Value = model.TotalGoods006;
            parameters[18].Value = model.ShopPrice;
            parameters[19].Value = model.gColor;
            parameters[20].Value = model.gSize;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(obj);
            }
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_goodsCar model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_goodsCar set ");
            strSql.Append("GoodsID=@GoodsID,");
            strSql.Append("GoodsCode=@GoodsCode,");
            strSql.Append("GoodsName=@GoodsName,");
            strSql.Append("Price=@Price,");
            strSql.Append("RealityPrice=@RealityPrice,");
            strSql.Append("TypeID=@TypeID,");
            strSql.Append("TypeIDName=@TypeIDName,");
            strSql.Append("GoodsType=@GoodsType,");
            strSql.Append("GoodsTypeName=@GoodsTypeName,");
            strSql.Append("Pic1=@Pic1,");
            strSql.Append("Remarks=@Remarks,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Goods002=@Goods002,");
            strSql.Append("Goods005=@Goods005,");
            strSql.Append("Goods006=@Goods006,");
            strSql.Append("BuyUser=@BuyUser,");
            strSql.Append("TotalMoney=@TotalMoney,");
            strSql.Append("TotalGoods006=@TotalGoods006,");
            strSql.Append("ShopPrice=@ShopPrice,");
            strSql.Append("gColor=@gColor,");
            strSql.Append("gSize=@gSize");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsCode", SqlDbType.VarChar,100),
					new SqlParameter("@GoodsName", SqlDbType.VarChar,100),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@RealityPrice", SqlDbType.Decimal,9),
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@TypeIDName", SqlDbType.VarChar,100),
					new SqlParameter("@GoodsType", SqlDbType.Int,4),
					new SqlParameter("@GoodsTypeName", SqlDbType.VarChar,100),
					new SqlParameter("@Pic1", SqlDbType.VarChar,100),
					new SqlParameter("@Remarks", SqlDbType.VarChar,-1),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@Goods002", SqlDbType.Int,4),
					new SqlParameter("@Goods005", SqlDbType.Decimal,9),
					new SqlParameter("@Goods006", SqlDbType.Int,4),
					new SqlParameter("@BuyUser", SqlDbType.BigInt,8),
					new SqlParameter("@TotalMoney", SqlDbType.Decimal,9),
					new SqlParameter("@TotalGoods006", SqlDbType.Int,4),
					new SqlParameter("@ShopPrice", SqlDbType.Decimal,9),
					new SqlParameter("@gColor", SqlDbType.VarChar,20),
					new SqlParameter("@gSize", SqlDbType.VarChar,20),
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.GoodsID;
            parameters[1].Value = model.GoodsCode;
            parameters[2].Value = model.GoodsName;
            parameters[3].Value = model.Price;
            parameters[4].Value = model.RealityPrice;
            parameters[5].Value = model.TypeID;
            parameters[6].Value = model.TypeIDName;
            parameters[7].Value = model.GoodsType;
            parameters[8].Value = model.GoodsTypeName;
            parameters[9].Value = model.Pic1;
            parameters[10].Value = model.Remarks;
            parameters[11].Value = model.AddTime;
            parameters[12].Value = model.Goods002;
            parameters[13].Value = model.Goods005;
            parameters[14].Value = model.Goods006;
            parameters[15].Value = model.BuyUser;
            parameters[16].Value = model.TotalMoney;
            parameters[17].Value = model.TotalGoods006;
            parameters[18].Value = model.ShopPrice;
            parameters[19].Value = model.gColor;
            parameters[20].Value = model.gSize;
            parameters[21].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_goodsCar ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
            parameters[0].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_goodsCar ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public lgk.Model.tb_goodsCar GetModel(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,GoodsID,GoodsCode,GoodsName,Price,RealityPrice,TypeID,TypeIDName,GoodsType,GoodsTypeName,Pic1,Remarks,AddTime,Goods002,Goods005,Goods006,BuyUser,TotalMoney,TotalGoods006,ShopPrice,gColor,gSize from tb_goodsCar ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
            parameters[0].Value = ID;

            lgk.Model.tb_goodsCar model = new lgk.Model.tb_goodsCar();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_goodsCar DataRowToModel(DataRow row)
        {
            lgk.Model.tb_goodsCar model = new lgk.Model.tb_goodsCar();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = long.Parse(row["ID"].ToString());
                }
                if (row["GoodsID"] != null && row["GoodsID"].ToString() != "")
                {
                    model.GoodsID = long.Parse(row["GoodsID"].ToString());
                }
                if (row["GoodsCode"] != null)
                {
                    model.GoodsCode = row["GoodsCode"].ToString();
                }
                if (row["GoodsName"] != null)
                {
                    model.GoodsName = row["GoodsName"].ToString();
                }
                if (row["Price"] != null && row["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(row["Price"].ToString());
                }
                if (row["RealityPrice"] != null && row["RealityPrice"].ToString() != "")
                {
                    model.RealityPrice = decimal.Parse(row["RealityPrice"].ToString());
                }
                if (row["TypeID"] != null && row["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(row["TypeID"].ToString());
                }
                if (row["TypeIDName"] != null)
                {
                    model.TypeIDName = row["TypeIDName"].ToString();
                }
                if (row["GoodsType"] != null && row["GoodsType"].ToString() != "")
                {
                    model.GoodsType = int.Parse(row["GoodsType"].ToString());
                }
                if (row["GoodsTypeName"] != null)
                {
                    model.GoodsTypeName = row["GoodsTypeName"].ToString();
                }
                if (row["Pic1"] != null)
                {
                    model.Pic1 = row["Pic1"].ToString();
                }
                if (row["Remarks"] != null)
                {
                    model.Remarks = row["Remarks"].ToString();
                }
                if (row["AddTime"] != null && row["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(row["AddTime"].ToString());
                }
                if (row["Goods002"] != null && row["Goods002"].ToString() != "")
                {
                    model.Goods002 = int.Parse(row["Goods002"].ToString());
                }
                if (row["Goods005"] != null && row["Goods005"].ToString() != "")
                {
                    model.Goods005 = decimal.Parse(row["Goods005"].ToString());
                }
                if (row["Goods006"] != null && row["Goods006"].ToString() != "")
                {
                    model.Goods006 = int.Parse(row["Goods006"].ToString());
                }
                if (row["BuyUser"] != null && row["BuyUser"].ToString() != "")
                {
                    model.BuyUser = long.Parse(row["BuyUser"].ToString());
                }
                if (row["TotalMoney"] != null && row["TotalMoney"].ToString() != "")
                {
                    model.TotalMoney = decimal.Parse(row["TotalMoney"].ToString());
                }
                if (row["TotalGoods006"] != null && row["TotalGoods006"].ToString() != "")
                {
                    model.TotalGoods006 = int.Parse(row["TotalGoods006"].ToString());
                }
                if (row["ShopPrice"] != null && row["ShopPrice"].ToString() != "")
                {
                    model.ShopPrice = decimal.Parse(row["ShopPrice"].ToString());
                }
                if (row["gColor"] != null)
                {
                    model.gColor = row["gColor"].ToString();
                }
                if (row["gSize"] != null)
                {
                    model.gSize = row["gSize"].ToString();
                }
            }
            return model;
        }
        #endregion

        /// <summary>
        /// 根据条件得到一个对象实体
        /// </summary>
        public lgk.Model.tb_goodsCar GetModel(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from tb_goodsCar ");
            strSql.Append(" where " + where);

            lgk.Model.tb_goodsCar model = new lgk.Model.tb_goodsCar();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere, int level)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,GoodsID,GoodsCode,GoodsName,Price,RealityPrice,TypeID,TypeIDName,GoodsType,GoodsTypeName,Pic1,Remarks,AddTime,Goods002,Goods005,Goods006,BuyUser,case when " + level + " >= 1 then Goods006 * RealityPrice else Goods006  * ShopPrice end as [TotalMoney1] ,TotalMoney  ,Goods006 * Goods002 as TotalGoods006,ShopPrice,gColor,gSize from tb_goodsCar");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,GoodsID,GoodsCode,GoodsName,Price,RealityPrice,TypeID,TypeIDName,GoodsType,GoodsTypeName,Pic1,Remarks,AddTime,Goods002,Goods005,Goods006,BuyUser,TotalMoney,TotalGoods006,ShopPrice,gColor,gSize ");
            strSql.Append(" FROM tb_goodsCar ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,GoodsID,GoodsCode,GoodsName,Price,RealityPrice,TypeID,TypeIDName,GoodsType,GoodsTypeName,Pic1,Remarks,AddTime,Goods002,Goods005,Goods006,BuyUser,TotalMoney,TotalGoods006,ShopPrice,gColor,gSize ");
            strSql.Append(" FROM tb_goodsCar ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tb_goodsCar ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from tb_goodsCar T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
    }
}
