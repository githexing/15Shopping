using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DataAccess;

namespace lgk.DAL
{
    //tb_goods_property_color
    public partial class tb_goods_property_color
    {

        public bool Exists(int ColorID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_goods_property_color");
            strSql.Append(" where ");
            strSql.Append(" ColorID = @ColorID  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ColorID", SqlDbType.Int,4)
            };
            parameters[0].Value = ColorID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool Exists(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_goods_property_color where " + strWhere + "");

            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_goods_property_color model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_goods_property_color(");
            strSql.Append("goodsID,ColorName,Pic");
            strSql.Append(") values (");
            strSql.Append("@goodsID,@ColorName,@Pic");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@goodsID", SqlDbType.Int,4) ,
                        new SqlParameter("@ColorName", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Pic", SqlDbType.VarChar,200)

            };

            parameters[0].Value = model.goodsID;
            parameters[1].Value = model.ColorName;
            parameters[2].Value = model.Pic;

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
        public bool Update(lgk.Model.tb_goods_property_color model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_goods_property_color set ");

            strSql.Append(" goodsID = @goodsID , ");
            strSql.Append(" ColorName = @ColorName , ");
            strSql.Append(" Pic = @Pic  ");
            strSql.Append(" where ColorID=@ColorID ");

            SqlParameter[] parameters = {
                        new SqlParameter("@ColorID", SqlDbType.Int,4) ,
                        new SqlParameter("@goodsID", SqlDbType.Int,4) ,
                        new SqlParameter("@ColorName", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Pic", SqlDbType.VarChar,200)

            };

            parameters[0].Value = model.ColorID;
            parameters[1].Value = model.goodsID;
            parameters[2].Value = model.ColorName;
            parameters[3].Value = model.Pic;
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
        public bool Delete(int ColorID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_goods_property_color ");
            strSql.Append(" where ColorID=@ColorID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ColorID", SqlDbType.Int,4)
            };
            parameters[0].Value = ColorID;


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
        public bool DeleteList(string ColorIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_goods_property_color ");
            strSql.Append(" where ID in (" + ColorIDlist + ")  ");
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
        public lgk.Model.tb_goods_property_color GetModel(int ColorID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ColorID, goodsID, ColorName, Pic  ");
            strSql.Append("  from tb_goods_property_color ");
            strSql.Append(" where ColorID=@ColorID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ColorID", SqlDbType.Int,4)
            };
            parameters[0].Value = ColorID;


            lgk.Model.tb_goods_property_color model = new lgk.Model.tb_goods_property_color();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ColorID"].ToString() != "")
                {
                    model.ColorID = int.Parse(ds.Tables[0].Rows[0]["ColorID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["goodsID"].ToString() != "")
                {
                    model.goodsID = int.Parse(ds.Tables[0].Rows[0]["goodsID"].ToString());
                }
                model.ColorName = ds.Tables[0].Rows[0]["ColorName"].ToString();
                model.Pic = ds.Tables[0].Rows[0]["Pic"].ToString();

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
            strSql.Append(" FROM tb_goods_property_color ");
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
            strSql.Append(" FROM tb_goods_property_color ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


    }
}

