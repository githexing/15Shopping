using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DataAccess;

namespace lgk.DAL
{
    //tb_InviteInfo
    public partial class tb_InviteInfo
    {

        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_InviteInfo");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_InviteInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_InviteInfo(");
            strSql.Append("InviteInfo,InviteRule,AppDownUrl,ModifyTime,Intro");
            strSql.Append(") values (");
            strSql.Append("@InviteInfo,@InviteRule,@AppDownUrl,@ModifyTime,@Intro");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@InviteInfo", SqlDbType.VarChar,500) ,
                        new SqlParameter("@InviteRule", SqlDbType.VarChar,-1) ,
                        new SqlParameter("@AppDownUrl", SqlDbType.VarChar,-1) ,
                        new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                        new SqlParameter("@Intro", SqlDbType.VarChar,500)

            };

            parameters[0].Value = model.InviteInfo;
            parameters[1].Value = model.InviteRule;
            parameters[2].Value = model.AppDownUrl;
            parameters[3].Value = model.ModifyTime;
            parameters[4].Value = model.Intro;

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
        public bool Update(lgk.Model.tb_InviteInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_InviteInfo set ");

            strSql.Append(" InviteInfo = @InviteInfo , ");
            strSql.Append(" InviteRule = @InviteRule , ");
            strSql.Append(" AppDownUrl = @AppDownUrl , ");
            strSql.Append(" ModifyTime = @ModifyTime,  ");
            strSql.Append(" Intro = @Intro  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
                        new SqlParameter("@Id", SqlDbType.Int,4) ,
                        new SqlParameter("@InviteInfo", SqlDbType.VarChar,500) ,
                        new SqlParameter("@InviteRule", SqlDbType.VarChar,-1) ,
                        new SqlParameter("@AppDownUrl", SqlDbType.VarChar,-1) ,
                        new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                       new SqlParameter("@Intro", SqlDbType.VarChar,500) ,
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.InviteInfo;
            parameters[2].Value = model.InviteRule;
            parameters[3].Value = model.AppDownUrl;
            parameters[4].Value = model.ModifyTime;
            parameters[5].Value = model.Intro;
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
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_InviteInfo ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;


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
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_InviteInfo ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
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
        public lgk.Model.tb_InviteInfo GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, InviteInfo, InviteRule, AppDownUrl, ModifyTime,Intro  ");
            strSql.Append("  from tb_InviteInfo ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;


            lgk.Model.tb_InviteInfo model = new lgk.Model.tb_InviteInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.InviteInfo = ds.Tables[0].Rows[0]["InviteInfo"].ToString();
                model.InviteRule = ds.Tables[0].Rows[0]["InviteRule"].ToString();
                model.AppDownUrl = ds.Tables[0].Rows[0]["AppDownUrl"].ToString();
                model.Intro = ds.Tables[0].Rows[0]["Intro"].ToString();
                if (ds.Tables[0].Rows[0]["ModifyTime"].ToString() != "")
                {
                    model.ModifyTime = DateTime.Parse(ds.Tables[0].Rows[0]["ModifyTime"].ToString());
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
            strSql.Append(" FROM tb_InviteInfo ");
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
            strSql.Append(" FROM tb_InviteInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


    }
}

