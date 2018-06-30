using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:tb_goods
	/// </summary>
	public partial class tb_goods
	{
		public tb_goods()
		{}
		#region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_goods");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_goods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_goods(");
            strSql.Append("GoodsCode,GoodsName,Price,RealityPrice,Standard,IsHave,TypeID,GoodsType,Pic1,Pic2,Pic3,Pic4,Pic5,Summary,Remarks,AddTime,Goods001,Goods002,Goods003,Goods004,Goods005,Goods006,Goods007,Goods008,GoodsName_en,Remarks_en,StateType,City,ShopPrice,Inventory,SaleNum)");
            strSql.Append(" values (");
            strSql.Append("@GoodsCode,@GoodsName,@Price,@RealityPrice,@Standard,@IsHave,@TypeID,@GoodsType,@Pic1,@Pic2,@Pic3,@Pic4,@Pic5,@Summary,@Remarks,@AddTime,@Goods001,@Goods002,@Goods003,@Goods004,@Goods005,@Goods006,@Goods007,@Goods008,@GoodsName_en,@Remarks_en,@StateType,@City,@ShopPrice,@Inventory,@SaleNum)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsCode", SqlDbType.VarChar,100),
					new SqlParameter("@GoodsName", SqlDbType.VarChar,100),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@RealityPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Standard", SqlDbType.VarChar,100),
					new SqlParameter("@IsHave", SqlDbType.Int,4),
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@GoodsType", SqlDbType.Int,4),
					new SqlParameter("@Pic1", SqlDbType.VarChar,100),
					new SqlParameter("@Pic2", SqlDbType.VarChar,100),
					new SqlParameter("@Pic3", SqlDbType.VarChar,100),
					new SqlParameter("@Pic4", SqlDbType.VarChar,100),
					new SqlParameter("@Pic5", SqlDbType.VarChar,100),
					new SqlParameter("@Summary", SqlDbType.VarChar,100),
					new SqlParameter("@Remarks", SqlDbType.VarChar,-1),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@Goods001", SqlDbType.Int,4),
					new SqlParameter("@Goods002", SqlDbType.Int,4),
					new SqlParameter("@Goods003", SqlDbType.VarChar,100),
					new SqlParameter("@Goods004", SqlDbType.VarChar,100),
					new SqlParameter("@Goods005", SqlDbType.Decimal,9),
					new SqlParameter("@Goods006", SqlDbType.Decimal,9),
					new SqlParameter("@Goods007", SqlDbType.DateTime),
					new SqlParameter("@Goods008", SqlDbType.DateTime),
					new SqlParameter("@GoodsName_en", SqlDbType.VarChar,100),
					new SqlParameter("@Remarks_en", SqlDbType.VarChar,-1),
					new SqlParameter("@StateType", SqlDbType.Int,4),
					new SqlParameter("@City", SqlDbType.VarChar,50),
					new SqlParameter("@ShopPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Inventory", SqlDbType.Int,4),
					new SqlParameter("@SaleNum", SqlDbType.Int,4)};
            parameters[0].Value = model.GoodsCode;
            parameters[1].Value = model.GoodsName;
            parameters[2].Value = model.Price;
            parameters[3].Value = model.RealityPrice;
            parameters[4].Value = model.Standard;
            parameters[5].Value = model.IsHave;
            parameters[6].Value = model.TypeID;
            parameters[7].Value = model.GoodsType;
            parameters[8].Value = model.Pic1;
            parameters[9].Value = model.Pic2;
            parameters[10].Value = model.Pic3;
            parameters[11].Value = model.Pic4;
            parameters[12].Value = model.Pic5;
            parameters[13].Value = model.Summary;
            parameters[14].Value = model.Remarks;
            parameters[15].Value = model.AddTime;
            parameters[16].Value = model.Goods001;
            parameters[17].Value = model.Goods002;
            parameters[18].Value = model.Goods003;
            parameters[19].Value = model.Goods004;
            parameters[20].Value = model.Goods005;
            parameters[21].Value = model.Goods006;
            parameters[22].Value = model.Goods007;
            parameters[23].Value = model.Goods008;
            parameters[24].Value = model.GoodsName_en;
            parameters[25].Value = model.Remarks_en;
            parameters[26].Value = model.StateType;
            parameters[27].Value = model.City;
            parameters[28].Value = model.ShopPrice;
            parameters[29].Value = model.Inventory;
            parameters[30].Value = model.SaleNum;

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
        public bool Update(lgk.Model.tb_goods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_goods set ");
            strSql.Append("GoodsCode=@GoodsCode,");
            strSql.Append("GoodsName=@GoodsName,");
            strSql.Append("Price=@Price,");
            strSql.Append("RealityPrice=@RealityPrice,");
            strSql.Append("Standard=@Standard,");
            strSql.Append("IsHave=@IsHave,");
            strSql.Append("TypeID=@TypeID,");
            strSql.Append("GoodsType=@GoodsType,");
            strSql.Append("Pic1=@Pic1,");
            strSql.Append("Pic2=@Pic2,");
            strSql.Append("Pic3=@Pic3,");
            strSql.Append("Pic4=@Pic4,");
            strSql.Append("Pic5=@Pic5,");
            strSql.Append("Summary=@Summary,");
            strSql.Append("Remarks=@Remarks,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Goods001=@Goods001,");
            strSql.Append("Goods002=@Goods002,");
            strSql.Append("Goods003=@Goods003,");
            strSql.Append("Goods004=@Goods004,");
            strSql.Append("Goods005=@Goods005,");
            strSql.Append("Goods006=@Goods006,");
            strSql.Append("Goods007=@Goods007,");
            strSql.Append("Goods008=@Goods008,");
            strSql.Append("GoodsName_en=@GoodsName_en,");
            strSql.Append("Remarks_en=@Remarks_en,");
            strSql.Append("StateType=@StateType,");
            strSql.Append("City=@City,");
            strSql.Append("ShopPrice=@ShopPrice,");
            strSql.Append("Inventory=@Inventory,");
            strSql.Append("SaleNum=@SaleNum");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsCode", SqlDbType.VarChar,100),
					new SqlParameter("@GoodsName", SqlDbType.VarChar,100),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@RealityPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Standard", SqlDbType.VarChar,100),
					new SqlParameter("@IsHave", SqlDbType.Int,4),
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@GoodsType", SqlDbType.Int,4),
					new SqlParameter("@Pic1", SqlDbType.VarChar,100),
					new SqlParameter("@Pic2", SqlDbType.VarChar,100),
					new SqlParameter("@Pic3", SqlDbType.VarChar,100),
					new SqlParameter("@Pic4", SqlDbType.VarChar,100),
					new SqlParameter("@Pic5", SqlDbType.VarChar,100),
					new SqlParameter("@Summary", SqlDbType.VarChar,100),
					new SqlParameter("@Remarks", SqlDbType.VarChar,-1),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@Goods001", SqlDbType.Int,4),
					new SqlParameter("@Goods002", SqlDbType.Int,4),
					new SqlParameter("@Goods003", SqlDbType.VarChar,100),
					new SqlParameter("@Goods004", SqlDbType.VarChar,100),
					new SqlParameter("@Goods005", SqlDbType.Decimal,9),
					new SqlParameter("@Goods006", SqlDbType.Decimal,9),
					new SqlParameter("@Goods007", SqlDbType.DateTime),
					new SqlParameter("@Goods008", SqlDbType.DateTime),
					new SqlParameter("@GoodsName_en", SqlDbType.VarChar,100),
					new SqlParameter("@Remarks_en", SqlDbType.VarChar,-1),
					new SqlParameter("@StateType", SqlDbType.Int,4),
					new SqlParameter("@City", SqlDbType.VarChar,50),
					new SqlParameter("@ShopPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Inventory", SqlDbType.Int,4),
					new SqlParameter("@SaleNum", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.GoodsCode;
            parameters[1].Value = model.GoodsName;
            parameters[2].Value = model.Price;
            parameters[3].Value = model.RealityPrice;
            parameters[4].Value = model.Standard;
            parameters[5].Value = model.IsHave;
            parameters[6].Value = model.TypeID;
            parameters[7].Value = model.GoodsType;
            parameters[8].Value = model.Pic1;
            parameters[9].Value = model.Pic2;
            parameters[10].Value = model.Pic3;
            parameters[11].Value = model.Pic4;
            parameters[12].Value = model.Pic5;
            parameters[13].Value = model.Summary;
            parameters[14].Value = model.Remarks;
            parameters[15].Value = model.AddTime;
            parameters[16].Value = model.Goods001;
            parameters[17].Value = model.Goods002;
            parameters[18].Value = model.Goods003;
            parameters[19].Value = model.Goods004;
            parameters[20].Value = model.Goods005;
            parameters[21].Value = model.Goods006;
            parameters[22].Value = model.Goods007;
            parameters[23].Value = model.Goods008;
            parameters[24].Value = model.GoodsName_en;
            parameters[25].Value = model.Remarks_en;
            parameters[26].Value = model.StateType;
            parameters[27].Value = model.City;
            parameters[28].Value = model.ShopPrice;
            parameters[29].Value = model.Inventory;
            parameters[30].Value = model.SaleNum;
            parameters[31].Value = model.ID;

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
            strSql.Append("delete from tb_goods ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
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
        /// 删除一条数据(只是隐藏）
        /// </summary>
        public bool Delete1(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_goods set Goods003 = '1'");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)};
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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_goods ");
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
        public lgk.Model.tb_goods GetModel(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,GoodsCode,GoodsName,Price,RealityPrice,Standard,IsHave,TypeID,GoodsType,Pic1,Pic2,Pic3,Pic4,Pic5,Summary,Remarks,AddTime,Goods001,Goods002,Goods003,Goods004,Goods005,Goods006,Goods007,Goods008,GoodsName_en,Remarks_en,StateType,City,ShopPrice,Inventory,SaleNum from tb_goods ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
            parameters[0].Value = ID;

            lgk.Model.tb_goods model = new lgk.Model.tb_goods();
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
        public lgk.Model.tb_goods DataRowToModel(DataRow row)
        {
            lgk.Model.tb_goods model = new lgk.Model.tb_goods();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = long.Parse(row["ID"].ToString());
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
                if (row["Standard"] != null)
                {
                    model.Standard = row["Standard"].ToString();
                }
                if (row["IsHave"] != null && row["IsHave"].ToString() != "")
                {
                    model.IsHave = int.Parse(row["IsHave"].ToString());
                }
                if (row["TypeID"] != null && row["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(row["TypeID"].ToString());
                }
                if (row["GoodsType"] != null && row["GoodsType"].ToString() != "")
                {
                    model.GoodsType = int.Parse(row["GoodsType"].ToString());
                }
                if (row["Pic1"] != null)
                {
                    model.Pic1 = row["Pic1"].ToString();
                }
                if (row["Pic2"] != null)
                {
                    model.Pic2 = row["Pic2"].ToString();
                }
                if (row["Pic3"] != null)
                {
                    model.Pic3 = row["Pic3"].ToString();
                }
                if (row["Pic4"] != null)
                {
                    model.Pic4 = row["Pic4"].ToString();
                }
                if (row["Pic5"] != null)
                {
                    model.Pic5 = row["Pic5"].ToString();
                }
                if (row["Summary"] != null)
                {
                    model.Summary = row["Summary"].ToString();
                }
                if (row["Remarks"] != null)
                {
                    model.Remarks = row["Remarks"].ToString();
                }
                if (row["AddTime"] != null && row["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(row["AddTime"].ToString());
                }
                if (row["Goods001"] != null && row["Goods001"].ToString() != "")
                {
                    model.Goods001 = int.Parse(row["Goods001"].ToString());
                }
                if (row["Goods002"] != null && row["Goods002"].ToString() != "")
                {
                    model.Goods002 = int.Parse(row["Goods002"].ToString());
                }
                if (row["Goods003"] != null)
                {
                    model.Goods003 = row["Goods003"].ToString();
                }
                if (row["Goods004"] != null)
                {
                    model.Goods004 = row["Goods004"].ToString();
                }
                if (row["Goods005"] != null && row["Goods005"].ToString() != "")
                {
                    model.Goods005 = decimal.Parse(row["Goods005"].ToString());
                }
                if (row["Goods006"] != null && row["Goods006"].ToString() != "")
                {
                    model.Goods006 = decimal.Parse(row["Goods006"].ToString());
                }
                if (row["Goods007"] != null && row["Goods007"].ToString() != "")
                {
                    model.Goods007 = DateTime.Parse(row["Goods007"].ToString());
                }
                if (row["Goods008"] != null && row["Goods008"].ToString() != "")
                {
                    model.Goods008 = DateTime.Parse(row["Goods008"].ToString());
                }
                if (row["GoodsName_en"] != null)
                {
                    model.GoodsName_en = row["GoodsName_en"].ToString();
                }
                if (row["Remarks_en"] != null)
                {
                    model.Remarks_en = row["Remarks_en"].ToString();
                }
                if (row["StateType"] != null && row["StateType"].ToString() != "")
                {
                    model.StateType = int.Parse(row["StateType"].ToString());
                }
                if (row["City"] != null)
                {
                    model.City = row["City"].ToString();
                }
                if (row["ShopPrice"] != null && row["ShopPrice"].ToString() != "")
                {
                    model.ShopPrice = decimal.Parse(row["ShopPrice"].ToString());
                }
                if (row["Inventory"] != null && row["Inventory"].ToString() != "")
                {
                    model.Inventory = int.Parse(row["Inventory"].ToString());
                }
                if (row["SaleNum"] != null && row["SaleNum"].ToString() != "")
                {
                    model.SaleNum = int.Parse(row["SaleNum"].ToString());
                }
            }
            return model;
        } 
        #endregion

        public lgk.Model.tb_goods GetModel(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,GoodsCode,GoodsName,Price,RealityPrice,Standard,IsHave,TypeID,GoodsType,Pic1,Pic2,Pic3,Pic4,Pic5,Summary,Remarks,AddTime,Goods001,Goods002,Goods003,Goods004,Goods005,Goods006,Goods007,Goods008,GoodsName_en,Remarks_en,StateType,City,ShopPrice,Inventory,SaleNum from tb_goods ");
            strSql.Append(" where "+where);

            lgk.Model.tb_goods model = new lgk.Model.tb_goods();
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

        #region 得到一个对象实体,只有一级名称
        /// <summary>
        /// 得到一个对象实体,只有一级名称
        /// </summary>
        public lgk.Model.tb_goods GetModelAndOneName(long ID)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select g.*,t.TypeName");
            strSql.Append(" from tb_goods as g join dbo.tb_produceType as t on t.ID=g.TypeID AND g.Goods003 <> 1");
            strSql.Append(" where g.ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)};
            parameters[0].Value = ID;

            lgk.Model.tb_goods model = new lgk.Model.tb_goods();
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
        #endregion

        #region 得到一个对象实体,包括一级，二级名称
        /// <summary>
        /// 得到一个对象实体,包括一级，二级名称
        /// </summary>
        public lgk.Model.tb_goods GetModelAndName(long ID)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select g.*,t.TypeName typename1,p.TypeName typename2");
            strSql.Append(" from tb_goods as g join dbo.tb_produceType as t on t.ID=g.TypeID join tb_produceType as p on p.ID=g.GoodsType AND g.Goods003 <> 1");
            strSql.Append(" where g.ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)};
            parameters[0].Value = ID;

            lgk.Model.tb_goods model = new lgk.Model.tb_goods();
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
        #endregion

        #region 只有一级名称
        /// <summary>
        /// 得到一个对象实体,只有一级名称
        /// </summary>
        public DataSet GetModelAndOneNameList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select g.*,t.TypeName");
            strSql.Append(" from tb_goods as g join dbo.tb_produceType as t on t.ID=g.TypeID AND g.Goods003 <> 1");

            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from tb_goods");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tb_goods ");
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
        /// 获得前几行数据
        /// </summary>
        /// <param name="Top">前几行</param>
        /// <param name="strWhere">条件</param>
        /// <param name="filedOrder">排序方式</param>
        /// <returns></returns>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
            strSql.Append(" g.*,t.TypeName typename1,p.TypeName typename2");
            strSql.Append(" from tb_goods as g join dbo.tb_produceType as t on t.ID=g.TypeID join tb_produceType as p on p.ID=g.GoodsType AND g.Goods003 <> '1' ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 促销商品一级分类列表
        /// </summary>
        /// <param cxType="促销类型,团购,秒杀"></param>
        /// <returns></returns>
        public DataSet GetGoodsOneName(int cxType, string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@" select COUNT(p.TypeID)as total, p.TypeID as OneTypeID, (SELECT TypeName FROM tb_produceType WHERE ID=p.TypeID) AS OneName
                from [tb_goods] p JOIN tb_produceType t
                ON  t.ParentID=p.TypeID AND t.ID = p.GoodsType AND p.Goods003 <> '1' and [Goods001]=1 and p.[TypeID]=" + cxType + "  " + where + " group by TypeID  ");

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 促销商品二级分类列表
        /// </summary>
        /// <param cxType="促销类型,团购,秒杀"></param>
        /// <returns></returns>
        public DataSet GetGoodsTwoName(int cxType, string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"  select  p.TypeID, p.GoodsType, (SELECT TypeName FROM tb_produceType WHERE ID=p.GoodsType) AS TwoName,COUNT(p.GoodsType)as total
                from [tb_goods] p JOIN tb_produceType t
                ON  t.ParentID=p.TypeID AND t.ID = p.GoodsType AND p.Goods003 <> '1' and [Goods001]=1 and  p.[TypeID]=" + cxType + "  " + where + "  group by p.GoodsType , p.TypeID  ");

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 商品列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetGoodsList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select p.ID,p.GoodsCode,p.GoodsName,p.Price,p.RealityPrice,
                p.Standard,p.IsHave,p.TypeID,p.GoodsType,p.Pic1,p.Pic2,p.Pic3,p.Pic4,p.Pic5,
                p.Summary,p.Remarks,p.AddTime,p.Goods001,p.Goods002,p.Goods003,p.Goods004,p.Goods005,p.ShopPrice,
                p.Goods006,p.Goods007,p.Goods008,p.StateType,p.City,
                (SELECT TypeName FROM tb_produceType WHERE ID=p.TypeID) AS OneName,
                (SELECT TypeName FROM tb_produceType WHERE ID=p.GoodsType) AS TypeName,
       (SELECT TypeName FROM tb_produceType WHERE ID=p.Goods006) AS SypeName from tb_goods p JOIN tb_produceType t ON  t.ParentID=p.TypeID AND t.ID = p.GoodsType AND p.Goods003 <> '1'");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
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
			parameters[0].Value = "tb_goods";
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

