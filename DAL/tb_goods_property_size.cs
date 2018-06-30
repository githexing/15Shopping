using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DataAccess;

namespace lgk.DAL
{
    //tb_goods_property_size
    public partial class tb_goods_property_size
    {

        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_goods_property_size");
            strSql.Append(" where ");
            strSql.Append(" ID = @ID  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_goods_property_size model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_goods_property_size(");
            strSql.Append("goodsID,ColorID,SizeName,Qry");
            strSql.Append(") values (");
            strSql.Append("@goodsID,@ColorID,@SizeName,@Qry");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@goodsID", SqlDbType.Int,4) ,
                        new SqlParameter("@ColorID", SqlDbType.Int,4) ,
                        new SqlParameter("@SizeName", SqlDbType.VarChar,10) ,
                        new SqlParameter("@Qry", SqlDbType.Int,4)

            };

            parameters[0].Value = model.goodsID;
            parameters[1].Value = model.ColorID;
            parameters[2].Value = model.SizeName;
            parameters[3].Value = model.Qry;

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
        public bool Update(lgk.Model.tb_goods_property_size model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_goods_property_size set ");

            strSql.Append(" goodsID = @goodsID , ");
            strSql.Append(" ColorID = @ColorID , ");
            strSql.Append(" SizeName = @SizeName , ");
            strSql.Append(" Qry = @Qry  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
                        new SqlParameter("@ID", SqlDbType.Int,4) ,
                        new SqlParameter("@goodsID", SqlDbType.Int,4) ,
                        new SqlParameter("@ColorID", SqlDbType.Int,4) ,
                        new SqlParameter("@SizeName", SqlDbType.VarChar,10) ,
                        new SqlParameter("@Qry", SqlDbType.Int,4)

            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.goodsID;
            parameters[2].Value = model.ColorID;
            parameters[3].Value = model.SizeName;
            parameters[4].Value = model.Qry;
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
            strSql.Append("delete from tb_goods_property_size ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_goods_property_size ");
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
        public lgk.Model.tb_goods_property_size GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, goodsID, ColorID, SizeName, Qry  ");
            strSql.Append("  from tb_goods_property_size ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;


            lgk.Model.tb_goods_property_size model = new lgk.Model.tb_goods_property_size();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["goodsID"].ToString() != "")
                {
                    model.goodsID = int.Parse(ds.Tables[0].Rows[0]["goodsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ColorID"].ToString() != "")
                {
                    model.ColorID = int.Parse(ds.Tables[0].Rows[0]["ColorID"].ToString());
                }
                model.SizeName = ds.Tables[0].Rows[0]["SizeName"].ToString();
                if (ds.Tables[0].Rows[0]["Qry"].ToString() != "")
                {
                    model.Qry = int.Parse(ds.Tables[0].Rows[0]["Qry"].ToString());
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
            strSql.Append("select * ");
            strSql.Append(" FROM tb_goods_property_size ");
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
            strSql.Append(" * ");
            strSql.Append(" FROM tb_goods_property_size ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


    }
}

