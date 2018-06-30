using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DataAccess;

namespace lgk.DAL
{
    //tb_goods_property
    public partial class tb_goods_property
    {

        public bool Exists(int PropertyID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_goods_property");
            strSql.Append(" where ");
            strSql.Append(" PropertyID = @PropertyID  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@PropertyID", SqlDbType.Int,4)
            };
            parameters[0].Value = PropertyID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_goods_property model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_goods_property(");
            strSql.Append("goodsID,ColorID,Qry");
            strSql.Append(") values (");
            strSql.Append("@goodsID,@ColorID,@Qry");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@goodsID", SqlDbType.Int,4) ,
                        new SqlParameter("@ColorID", SqlDbType.VarChar,20) ,
                        new SqlParameter("@Qry", SqlDbType.Int,4)

            };

            parameters[0].Value = model.goodsID;
            parameters[1].Value = model.ColorID;
            parameters[2].Value = model.Qry;

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
        public bool Update(lgk.Model.tb_goods_property model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_goods_property set ");

            strSql.Append(" goodsID = @goodsID , ");
            strSql.Append(" ColorID = @ColorID , ");
            strSql.Append(" Qry = @Qry  ");
            strSql.Append(" where PropertyID=@PropertyID ");

            SqlParameter[] parameters = {
                        new SqlParameter("@PropertyID", SqlDbType.Int,4) ,
                        new SqlParameter("@goodsID", SqlDbType.Int,4) ,
                        new SqlParameter("@ColorID", SqlDbType.VarChar,20) ,
                        new SqlParameter("@Qry", SqlDbType.Int,4)

            };

            parameters[0].Value = model.PropertyID;
            parameters[1].Value = model.goodsID;
            parameters[2].Value = model.ColorID;
            parameters[3].Value = model.Qry;
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
        public bool Delete(int PropertyID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_goods_property ");
            strSql.Append(" where PropertyID=@PropertyID");
            SqlParameter[] parameters = {
                    new SqlParameter("@PropertyID", SqlDbType.Int,4)
            };
            parameters[0].Value = PropertyID;


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
        public bool DeleteList(string PropertyIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_goods_property ");
            strSql.Append(" where ID in (" + PropertyIDlist + ")  ");
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
        public lgk.Model.tb_goods_property GetModel(int PropertyID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PropertyID, goodsID, ColorID, Qry  ");
            strSql.Append("  from tb_goods_property ");
            strSql.Append(" where PropertyID=@PropertyID");
            SqlParameter[] parameters = {
                    new SqlParameter("@PropertyID", SqlDbType.Int,4)
            };
            parameters[0].Value = PropertyID;


            lgk.Model.tb_goods_property model = new lgk.Model.tb_goods_property();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PropertyID"].ToString() != "")
                {
                    model.PropertyID = int.Parse(ds.Tables[0].Rows[0]["PropertyID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["goodsID"].ToString() != "")
                {
                    model.goodsID = int.Parse(ds.Tables[0].Rows[0]["goodsID"].ToString());
                }
                model.ColorID = ds.Tables[0].Rows[0]["ColorID"].ToString();
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
            strSql.Append(" FROM tb_goods_property ");
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
            strSql.Append(" FROM tb_goods_property ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


    }
}

