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
    /// 数据访问类:tb_goods
    /// </summary>
    public partial class tb_goods_cxth
    {
        public tb_goods_cxth()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "tb_goods_cxth");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_goods_cxth");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_goods_cxth model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_goods_cxth(");
            strSql.Append("GoodsCode,GoodsName,Price,RealityPrice,TypeID,GoodsType,Pic1,Pic2,Pic3,Pic4,Pic5,Remarks,AddTime,Goods001,Goods002,Goods003,Goods004,Goods005,Goods006,Goods007,Goods008,[UploadUser],[SealCount],PareTopId,City,Purchase,SealPurchase,UserCode)");
            strSql.Append(" values (");
            strSql.Append("@GoodsCode,@GoodsName,@Price,@RealityPrice,@TypeID,@GoodsType,@Pic1,@Pic2,@Pic3,@Pic4,@Pic5,@Remarks,@AddTime,@Goods001,@Goods002,@Goods003,@Goods004,@Goods005,@Goods006,@Goods007,@Goods008,@UploadUser,@SealCount,@PareTopId,@City,@Purchase,@SealPurchase,@UserCode)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsCode", SqlDbType.VarChar,100),
					new SqlParameter("@GoodsName", SqlDbType.VarChar,100),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@RealityPrice", SqlDbType.Decimal,9),
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@GoodsType", SqlDbType.Int,4),
					new SqlParameter("@Pic1", SqlDbType.VarChar,100),
					new SqlParameter("@Pic2", SqlDbType.VarChar,100),
					new SqlParameter("@Pic3", SqlDbType.VarChar,100),
					new SqlParameter("@Pic4", SqlDbType.VarChar,100),
					new SqlParameter("@Pic5", SqlDbType.VarChar,100),
					new SqlParameter("@Remarks", SqlDbType.Text),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@Goods001", SqlDbType.Int,4),
					new SqlParameter("@Goods002", SqlDbType.Int,4),
					new SqlParameter("@Goods003", SqlDbType.Int),
					new SqlParameter("@Goods004", SqlDbType.VarChar,100),
					new SqlParameter("@Goods005", SqlDbType.Decimal,9),
					new SqlParameter("@Goods006", SqlDbType.Int),
					new SqlParameter("@Goods007", SqlDbType.DateTime),
					new SqlParameter("@Goods008", SqlDbType.DateTime),
                    new SqlParameter("@UploadUser", SqlDbType.Int),
                    new SqlParameter("@SealCount", SqlDbType.Int),
                    new SqlParameter("@PareTopId", SqlDbType.Int),
                    new SqlParameter("@City", SqlDbType.VarChar,20),
                    new SqlParameter("@Purchase", SqlDbType.Int),
                    new SqlParameter("@SealPurchase", SqlDbType.Int),
                    new SqlParameter("@UserCode", SqlDbType.VarChar,50)};
            parameters[0].Value = model.GoodsCode;
            parameters[1].Value = model.GoodsName;
            parameters[2].Value = model.Price;
            parameters[3].Value = model.RealityPrice;
            parameters[4].Value = model.TypeID;
            parameters[5].Value = model.GoodsType;
            parameters[6].Value = model.Pic1;
            parameters[7].Value = model.Pic2;
            parameters[8].Value = model.Pic3;
            parameters[9].Value = model.Pic4;
            parameters[10].Value = model.Pic5;
            parameters[11].Value = model.Remarks;
            parameters[12].Value = model.AddTime;
            parameters[13].Value = model.Goods001;
            parameters[14].Value = model.Goods002;
            parameters[15].Value = model.Goods003;
            parameters[16].Value = model.Goods004;
            parameters[17].Value = model.Goods005;
            parameters[18].Value = model.Goods006;
            parameters[19].Value = model.Goods007;
            parameters[20].Value = model.Goods008;
            parameters[21].Value = model.UploadUser;
            parameters[22].Value = model.SealCount;
            parameters[23].Value = model.PareTopId;
            parameters[24].Value = model.City;
            parameters[25].Value = model.Purchase;
            parameters[26].Value = model.SealPurchase;
            parameters[27].Value = model.UserCode;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(lgk.Model.tb_goods_cxth model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_goods_cxth set ");
            strSql.Append("GoodsCode=@GoodsCode,");
            strSql.Append("GoodsName=@GoodsName,");
            strSql.Append("Price=@Price,");
            strSql.Append("RealityPrice=@RealityPrice,");
            strSql.Append("Pic1=@Pic1,");
            strSql.Append("Pic2=@Pic2,");
            strSql.Append("Pic3=@Pic3,");
            strSql.Append("Pic4=@Pic4,");
            strSql.Append("Pic5=@Pic5,");
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
            strSql.Append("UserCode=@UserCode,");
            strSql.Append("SealCount=@SealCount,");
            strSql.Append("TypeID=@TypeID,");
            strSql.Append("GoodsType=@GoodsType,");
            strSql.Append("PareTopId=@PareTopId,");
            strSql.Append("City=@City,");
            strSql.Append("StateType=@StateType,");
            strSql.Append("Purchase=@Purchase,");
            strSql.Append("SealPurchase=@SealPurchase,");
            strSql.Append("UploadUser=@UploadUser,");
            strSql.Append("IsLucky=@IsLucky");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsCode", SqlDbType.VarChar,100),
					new SqlParameter("@GoodsName", SqlDbType.VarChar,100),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@RealityPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Pic1", SqlDbType.VarChar,100),
					new SqlParameter("@Pic2", SqlDbType.VarChar,100),
					new SqlParameter("@Pic3", SqlDbType.VarChar,100),
					new SqlParameter("@Pic4", SqlDbType.VarChar,100),
					new SqlParameter("@Pic5", SqlDbType.VarChar,100),
					new SqlParameter("@Remarks", SqlDbType.Text),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@Goods001", SqlDbType.Int,4),
					new SqlParameter("@Goods002", SqlDbType.Int,4),
					new SqlParameter("@Goods003", SqlDbType.Int),
					new SqlParameter("@Goods004", SqlDbType.VarChar,100),
					new SqlParameter("@Goods005", SqlDbType.Decimal,9),
					new SqlParameter("@Goods006", SqlDbType.Int),
					new SqlParameter("@Goods007", SqlDbType.DateTime),
					new SqlParameter("@Goods008", SqlDbType.DateTime),
                    new SqlParameter("@UserCode", SqlDbType.VarChar,50),
                    new SqlParameter("@SealCount", SqlDbType.Int),
                    new SqlParameter("@TypeID", SqlDbType.Int),
                    new SqlParameter("@GoodsType", SqlDbType.Int),
                    new SqlParameter("@PareTopId", SqlDbType.Int),
                    new SqlParameter("@City", SqlDbType.VarChar,20),
                    new SqlParameter("@StateType", SqlDbType.Int),
                    new SqlParameter("@Purchase", SqlDbType.Int),
                    new SqlParameter("@SealPurchase", SqlDbType.Int),
                    new SqlParameter("@UploadUser", SqlDbType.Int),
                    new SqlParameter("@IsLucky", SqlDbType.Int),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.GoodsCode;
            parameters[1].Value = model.GoodsName;
            parameters[2].Value = model.Price;
            parameters[3].Value = model.RealityPrice;
            parameters[4].Value = model.Pic1;
            parameters[5].Value = model.Pic2;
            parameters[6].Value = model.Pic3;
            parameters[7].Value = model.Pic4;
            parameters[8].Value = model.Pic5;
            parameters[9].Value = model.Remarks;
            parameters[10].Value = model.AddTime;
            parameters[11].Value = model.Goods001;
            parameters[12].Value = model.Goods002;
            parameters[13].Value = model.Goods003;
            parameters[14].Value = model.Goods004;
            parameters[15].Value = model.Goods005;
            parameters[16].Value = model.Goods006;
            parameters[17].Value = model.Goods007;
            parameters[18].Value = model.Goods008;
            parameters[19].Value = model.UserCode;
            parameters[20].Value = model.SealCount;
            parameters[21].Value = model.TypeID;
            parameters[22].Value = model.GoodsType;
            parameters[23].Value = model.PareTopId;
            parameters[24].Value = model.City;
            parameters[25].Value = model.StateType;
            parameters[26].Value = model.Purchase;
            parameters[27].Value = model.SealPurchase;
            parameters[28].Value = model.UploadUser;
            parameters[29].Value = model.IsLucky;
            parameters[30].Value = model.ID;

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
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_goods_cxth");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
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
        public bool Delete1(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_goods_cxth set Goods003 = 1");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
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
            strSql.Append("delete from tb_goods_cxth ");
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
        public lgk.Model.tb_goods_cxth GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from tb_goods_cxth");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = { new SqlParameter("@ID", SqlDbType.Int, 4) };
            parameters[0].Value = ID;

            lgk.Model.tb_goods_cxth model = new lgk.Model.tb_goods_cxth();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GoodsCode"] != null && ds.Tables[0].Rows[0]["GoodsCode"].ToString() != "")
                {
                    model.GoodsCode = ds.Tables[0].Rows[0]["GoodsCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["GoodsName"] != null && ds.Tables[0].Rows[0]["GoodsName"].ToString() != "")
                {
                    model.GoodsName = ds.Tables[0].Rows[0]["GoodsName"].ToString();
                }

                if (ds.Tables[0].Rows[0]["Price"] != null && ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RealityPrice"] != null && ds.Tables[0].Rows[0]["RealityPrice"].ToString() != "")
                {
                    model.RealityPrice = decimal.Parse(ds.Tables[0].Rows[0]["RealityPrice"].ToString());
                }

                if (ds.Tables[0].Rows[0]["TypeID"] != null && ds.Tables[0].Rows[0]["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(ds.Tables[0].Rows[0]["TypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GoodsType"] != null && ds.Tables[0].Rows[0]["GoodsType"].ToString() != "")
                {
                    model.GoodsType = int.Parse(ds.Tables[0].Rows[0]["GoodsType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PareTopId"] != null && ds.Tables[0].Rows[0]["PareTopId"].ToString() != "")
                {
                    model.PareTopId = int.Parse(ds.Tables[0].Rows[0]["PareTopId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Pic1"] != null && ds.Tables[0].Rows[0]["Pic1"].ToString() != "")
                {
                    model.Pic1 = ds.Tables[0].Rows[0]["Pic1"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Pic2"] != null && ds.Tables[0].Rows[0]["Pic2"].ToString() != "")
                {
                    model.Pic2 = ds.Tables[0].Rows[0]["Pic2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Pic3"] != null && ds.Tables[0].Rows[0]["Pic3"].ToString() != "")
                {
                    model.Pic3 = ds.Tables[0].Rows[0]["Pic3"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Pic4"] != null && ds.Tables[0].Rows[0]["Pic4"].ToString() != "")
                {
                    model.Pic4 = ds.Tables[0].Rows[0]["Pic4"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Pic5"] != null && ds.Tables[0].Rows[0]["Pic5"].ToString() != "")
                {
                    model.Pic5 = ds.Tables[0].Rows[0]["Pic5"].ToString();
                }

                if (ds.Tables[0].Rows[0]["Remarks"] != null && ds.Tables[0].Rows[0]["Remarks"].ToString() != "")
                {
                    model.Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
                }

                if (ds.Tables[0].Rows[0]["AddTime"] != null && ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Goods001"] != null && ds.Tables[0].Rows[0]["Goods001"].ToString() != "")
                {
                    model.Goods001 = int.Parse(ds.Tables[0].Rows[0]["Goods001"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Goods002"] != null && ds.Tables[0].Rows[0]["Goods002"].ToString() != "")
                {
                    model.Goods002 = int.Parse(ds.Tables[0].Rows[0]["Goods002"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Goods003"] != null && ds.Tables[0].Rows[0]["Goods003"].ToString() != "")
                {
                    model.Goods003 = int.Parse(ds.Tables[0].Rows[0]["Goods003"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Goods004"] != null && ds.Tables[0].Rows[0]["Goods004"].ToString() != "")
                {
                    model.Goods004 = ds.Tables[0].Rows[0]["Goods004"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Goods005"] != null && ds.Tables[0].Rows[0]["Goods005"].ToString() != "")
                {
                    model.Goods005 = decimal.Parse(ds.Tables[0].Rows[0]["Goods005"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Goods006"] != null && ds.Tables[0].Rows[0]["Goods006"].ToString() != "")
                {
                    model.Goods006 = int.Parse(ds.Tables[0].Rows[0]["Goods006"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Goods007"] != null && ds.Tables[0].Rows[0]["Goods007"].ToString() != "")
                {
                    model.Goods007 = DateTime.Parse(ds.Tables[0].Rows[0]["Goods007"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Goods008"] != null && ds.Tables[0].Rows[0]["Goods008"].ToString() != "")
                {
                    model.Goods008 = DateTime.Parse(ds.Tables[0].Rows[0]["Goods008"].ToString());
                }

                if (ds.Tables[0].Rows[0]["UploadUser"] != null && ds.Tables[0].Rows[0]["UploadUser"].ToString() != "")
                {
                    model.UploadUser = Convert.ToInt32(ds.Tables[0].Rows[0]["UploadUser"].ToString());
                }

                if (ds.Tables[0].Rows[0]["StateType"] != null && ds.Tables[0].Rows[0]["StateType"].ToString() != "")
                {
                    model.StateType = Convert.ToInt32(ds.Tables[0].Rows[0]["StateType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SealCount"] != null && ds.Tables[0].Rows[0]["SealCount"].ToString() != "")
                {
                    model.SealCount = Convert.ToInt32(ds.Tables[0].Rows[0]["SealCount"].ToString());
                }

                if (ds.Tables[0].Rows[0]["City"] != null && ds.Tables[0].Rows[0]["City"].ToString() != "")
                {
                    model.City = ds.Tables[0].Rows[0]["City"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Purchase"] != null && ds.Tables[0].Rows[0]["Purchase"].ToString() != "")
                {
                    model.Purchase = Convert.ToInt32(ds.Tables[0].Rows[0]["Purchase"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SealPurchase"] != null && ds.Tables[0].Rows[0]["SealPurchase"].ToString() != "")
                {
                    model.SealPurchase = Convert.ToInt32(ds.Tables[0].Rows[0]["SealPurchase"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserCode"] != null && ds.Tables[0].Rows[0]["UserCode"].ToString() != "")
                {
                    model.UserCode = ds.Tables[0].Rows[0]["UserCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IsLucky"] != null && ds.Tables[0].Rows[0]["IsLucky"].ToString() != "")
                {
                    model.IsLucky = Convert.ToInt32(ds.Tables[0].Rows[0]["IsLucky"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        public lgk.Model.tb_goods_cxth GetModel(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from tb_goods_cxth where " + where);

            lgk.Model.tb_goods_cxth model = new lgk.Model.tb_goods_cxth();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GoodsCode"] != null && ds.Tables[0].Rows[0]["GoodsCode"].ToString() != "")
                {
                    model.GoodsCode = ds.Tables[0].Rows[0]["GoodsCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["GoodsName"] != null && ds.Tables[0].Rows[0]["GoodsName"].ToString() != "")
                {
                    model.GoodsName = ds.Tables[0].Rows[0]["GoodsName"].ToString();
                }

                if (ds.Tables[0].Rows[0]["Price"] != null && ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RealityPrice"] != null && ds.Tables[0].Rows[0]["RealityPrice"].ToString() != "")
                {
                    model.RealityPrice = decimal.Parse(ds.Tables[0].Rows[0]["RealityPrice"].ToString());
                }


                if (ds.Tables[0].Rows[0]["TypeID"] != null && ds.Tables[0].Rows[0]["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(ds.Tables[0].Rows[0]["TypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GoodsType"] != null && ds.Tables[0].Rows[0]["GoodsType"].ToString() != "")
                {
                    model.GoodsType = int.Parse(ds.Tables[0].Rows[0]["GoodsType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PareTopId"] != null && ds.Tables[0].Rows[0]["PareTopId"].ToString() != "")
                {
                    model.PareTopId = Convert.ToInt32(ds.Tables[0].Rows[0]["PareTopId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Pic1"] != null && ds.Tables[0].Rows[0]["Pic1"].ToString() != "")
                {
                    model.Pic1 = ds.Tables[0].Rows[0]["Pic1"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Pic2"] != null && ds.Tables[0].Rows[0]["Pic2"].ToString() != "")
                {
                    model.Pic2 = ds.Tables[0].Rows[0]["Pic2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Pic3"] != null && ds.Tables[0].Rows[0]["Pic3"].ToString() != "")
                {
                    model.Pic3 = ds.Tables[0].Rows[0]["Pic3"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Pic4"] != null && ds.Tables[0].Rows[0]["Pic4"].ToString() != "")
                {
                    model.Pic4 = ds.Tables[0].Rows[0]["Pic4"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Pic5"] != null && ds.Tables[0].Rows[0]["Pic5"].ToString() != "")
                {
                    model.Pic5 = ds.Tables[0].Rows[0]["Pic5"].ToString();
                }

                if (ds.Tables[0].Rows[0]["Remarks"] != null && ds.Tables[0].Rows[0]["Remarks"].ToString() != "")
                {
                    model.Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
                }

                if (ds.Tables[0].Rows[0]["AddTime"] != null && ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Goods001"] != null && ds.Tables[0].Rows[0]["Goods001"].ToString() != "")
                {
                    model.Goods001 = int.Parse(ds.Tables[0].Rows[0]["Goods001"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Goods002"] != null && ds.Tables[0].Rows[0]["Goods002"].ToString() != "")
                {
                    model.Goods002 = int.Parse(ds.Tables[0].Rows[0]["Goods002"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Goods003"] != null && ds.Tables[0].Rows[0]["Goods003"].ToString() != "")
                {
                    model.Goods003 = int.Parse(ds.Tables[0].Rows[0]["Goods003"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Goods004"] != null && ds.Tables[0].Rows[0]["Goods004"].ToString() != "")
                {
                    model.Goods004 = ds.Tables[0].Rows[0]["Goods004"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Goods005"] != null && ds.Tables[0].Rows[0]["Goods005"].ToString() != "")
                {
                    model.Goods005 = decimal.Parse(ds.Tables[0].Rows[0]["Goods005"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Goods006"] != null && ds.Tables[0].Rows[0]["Goods006"].ToString() != "")
                {
                    model.Goods006 = int.Parse(ds.Tables[0].Rows[0]["Goods006"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Goods007"] != null && ds.Tables[0].Rows[0]["Goods007"].ToString() != "")
                {
                    model.Goods007 = DateTime.Parse(ds.Tables[0].Rows[0]["Goods007"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Goods008"] != null && ds.Tables[0].Rows[0]["Goods008"].ToString() != "")
                {
                    model.Goods008 = DateTime.Parse(ds.Tables[0].Rows[0]["Goods008"].ToString());
                }

                if (ds.Tables[0].Rows[0]["UploadUser"] != null && ds.Tables[0].Rows[0]["UploadUser"].ToString() != "")
                {
                    model.UploadUser = Convert.ToInt32(ds.Tables[0].Rows[0]["UploadUser"].ToString());
                }
               
                if (ds.Tables[0].Rows[0]["StateType"] != null && ds.Tables[0].Rows[0]["StateType"].ToString() != "")
                {
                    model.StateType = Convert.ToInt32(ds.Tables[0].Rows[0]["StateType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SealCount"] != null && ds.Tables[0].Rows[0]["SealCount"].ToString() != "")
                {
                    model.SealCount = Convert.ToInt32(ds.Tables[0].Rows[0]["SealCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["City"] != null && ds.Tables[0].Rows[0]["City"].ToString() != "")
                {
                    model.City = ds.Tables[0].Rows[0]["City"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Purchase"] != null && ds.Tables[0].Rows[0]["Purchase"].ToString() != "")
                {
                    model.Purchase = Convert.ToInt32(ds.Tables[0].Rows[0]["Purchase"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SealPurchase"] != null && ds.Tables[0].Rows[0]["SealPurchase"].ToString() != "")
                {
                    model.SealPurchase = Convert.ToInt32(ds.Tables[0].Rows[0]["SealPurchase"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserCode"] != null && ds.Tables[0].Rows[0]["UserCode"].ToString() != "")
                {
                    model.UserCode = ds.Tables[0].Rows[0]["UserCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IsLucky"] != null && ds.Tables[0].Rows[0]["IsLucky"].ToString() != "")
                {
                    model.IsLucky = Convert.ToInt32(ds.Tables[0].Rows[0]["IsLucky"].ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select g.*,t.TypeName typename1,p.TypeName typename2");
            strSql.Append(" from [tb_goods_cxth] as g join dbo.tb_produceType as t on t.ID=g.TypeID join tb_produceType as p on p.ID=g.GoodsType AND g.Goods003 <> 1");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        /// <param name="Top">前几行</param>
        /// <param name="strWhere">条件</param>
        /// <param name="filedOrder">排序方式</param>
        /// <returns></returns>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" g.*,t.TypeName typename1,p.TypeName typename2");
            strSql.Append(" from tb_goods_cxth as g join dbo.tb_produceType as t on t.ID=g.TypeID join tb_produceType as p on p.ID=g.GoodsType AND g.Goods003 <> 1 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            parameters[0].Value = "tb_goods";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        /// <summary>
        /// 促销商品一级分类列表
        /// </summary>
        /// <param cxType="促销类型,团购,秒杀"></param>
        /// <returns></returns>
        public DataSet GetGoodsOneName(int cxType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@" select COUNT(p.TypeID)as total, p.TypeID as OneTypeID, (SELECT TypeName FROM tb_produceType WHERE ID=p.TypeID) AS OneName
                from [tb_goods_cxth] p JOIN tb_produceType t
                ON  t.ParentID=p.TypeID AND t.ID = p.GoodsType AND p.Goods003 <> '1' and [Goods001]=1 and [StateType]=1 and  p.[TypeID]=" + cxType + @" group by TypeID  ");

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 促销商品二级分类列表
        /// </summary>
        /// <param cxType="促销类型,团购,秒杀"></param>
        /// <returns></returns>
        public DataSet GetGoodsTwoName(int cxType, int typeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"  select  p.TypeID, p.GoodsType, (SELECT TypeName FROM tb_produceType WHERE ID=p.GoodsType) AS TwoName,COUNT(p.GoodsType)as total
                from [tb_goods_cxth] p JOIN tb_produceType t
                ON  t.ParentID=p.TypeID AND t.ID = p.GoodsType AND p.Goods003 <> '1' and [Goods001]=1 and [StateType]=1 and  p.[GoodsType]=" + cxType + @" and  p.TypeID=" + typeID + " group by p.GoodsType , p.TypeID  ");

            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
    }
}
