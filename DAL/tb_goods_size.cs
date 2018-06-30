using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

using DataAccess;

namespace lgk.DAL
{
    //tb_goods_size
    public partial class tb_goods_size
    {

        public bool Exists(int SizeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_goods_size");
            strSql.Append(" where ");
            strSql.Append(" SizeID = @SizeID  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@SizeID", SqlDbType.Int,4)
            };
            parameters[0].Value = SizeID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_goods_size model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_goods_size(");
            strSql.Append("TypeID,Name");
            strSql.Append(") values (");
            strSql.Append("@TypeID,@Name");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@TypeID", SqlDbType.Int,4) ,
                        new SqlParameter("@Name", SqlDbType.VarChar,10)

            };

            parameters[0].Value = model.TypeID;
            parameters[1].Value = model.Name;

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
        public bool Update(lgk.Model.tb_goods_size model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_goods_size set ");

            strSql.Append(" TypeID = @TypeID , ");
            strSql.Append(" Name = @Name  ");
            strSql.Append(" where SizeID=@SizeID ");

            SqlParameter[] parameters = {
                        new SqlParameter("@SizeID", SqlDbType.Int,4) ,
                        new SqlParameter("@TypeID", SqlDbType.Int,4) ,
                        new SqlParameter("@Name", SqlDbType.VarChar,10)

            };

            parameters[0].Value = model.SizeID;
            parameters[1].Value = model.TypeID;
            parameters[2].Value = model.Name;
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
        public bool Delete(int SizeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_goods_size ");
            strSql.Append(" where SizeID=@SizeID");
            SqlParameter[] parameters = {
                    new SqlParameter("@SizeID", SqlDbType.Int,4)
            };
            parameters[0].Value = SizeID;


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
        public bool DeleteList(string SizeIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_goods_size ");
            strSql.Append(" where ID in (" + SizeIDlist + ")  ");
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
        public lgk.Model.tb_goods_size GetModel(int SizeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SizeID, TypeID, Name  ");
            strSql.Append("  from tb_goods_size ");
            strSql.Append(" where SizeID=@SizeID");
            SqlParameter[] parameters = {
                    new SqlParameter("@SizeID", SqlDbType.Int,4)
            };
            parameters[0].Value = SizeID;


            lgk.Model.tb_goods_size model = new lgk.Model.tb_goods_size();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SizeID"].ToString() != "")
                {
                    model.SizeID = int.Parse(ds.Tables[0].Rows[0]["SizeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(ds.Tables[0].Rows[0]["TypeID"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();

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
            strSql.Append(" FROM tb_goods_size ");
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
            strSql.Append(" FROM tb_goods_size ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


    }
}

