using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:tb_produceType
	/// </summary>
    public partial class tb_produceType
    {
        public tb_produceType()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "tb_produceType");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_produceType");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(lgk.Model.tb_produceType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_produceType(");
            strSql.Append("ParentID,TypeName,Type01,Type02,Type03,Type04,Type05,Type06)");
            strSql.Append(" values (");
            strSql.Append("@ParentID,@TypeName,@Type01,@Type02,@Type03,@Type04,@Type05,@Type06)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@TypeName", SqlDbType.VarChar,50),
					new SqlParameter("@Type01", SqlDbType.Int,4),
					new SqlParameter("@Type02", SqlDbType.Int,4),
					new SqlParameter("@Type03", SqlDbType.Decimal,9),
					new SqlParameter("@Type04", SqlDbType.Decimal,9),
					new SqlParameter("@Type05", SqlDbType.VarChar,100),
					new SqlParameter("@Type06", SqlDbType.VarChar,100)};
            parameters[0].Value = model.ParentID;
            parameters[1].Value = model.TypeName;
            parameters[2].Value = model.Type01;
            parameters[3].Value = model.Type02;
            parameters[4].Value = model.Type03;
            parameters[5].Value = model.Type04;
            parameters[6].Value = model.Type05;
            parameters[7].Value = model.Type06;

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
        public bool Update(lgk.Model.tb_produceType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_produceType set ");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("TypeName=@TypeName,");
            strSql.Append("Type01=@Type01,");
            strSql.Append("Type02=@Type02,");
            strSql.Append("Type03=@Type03,");
            strSql.Append("Type04=@Type04,");
            strSql.Append("Type05=@Type05,");
            strSql.Append("Type06=@Type06");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@TypeName", SqlDbType.VarChar,50),
					new SqlParameter("@Type01", SqlDbType.Int,4),
					new SqlParameter("@Type02", SqlDbType.Int,4),
					new SqlParameter("@Type03", SqlDbType.Decimal,9),
					new SqlParameter("@Type04", SqlDbType.Decimal,9),
					new SqlParameter("@Type05", SqlDbType.VarChar,100),
					new SqlParameter("@Type06", SqlDbType.VarChar,100),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.ParentID;
            parameters[1].Value = model.TypeName;
            parameters[2].Value = model.Type01;
            parameters[3].Value = model.Type02;
            parameters[4].Value = model.Type03;
            parameters[5].Value = model.Type04;
            parameters[6].Value = model.Type05;
            parameters[7].Value = model.Type06;
            parameters[8].Value = model.ID;

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
        /// 更新商品为隐藏
        /// </summary>
        public bool DeleteForHide(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_goods set Goods003 = 1");
            strSql.Append(" where GoodsType=@ID");
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
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_produceType ");
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
            strSql.Append("delete from tb_produceType ");
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
        public lgk.Model.tb_produceType GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ParentID,TypeName,Type01,Type02,Type03,Type04,Type05,Type06 from tb_produceType ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            lgk.Model.tb_produceType model = new lgk.Model.tb_produceType();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentID"] != null && ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TypeName"] != null && ds.Tables[0].Rows[0]["TypeName"].ToString() != "")
                {
                    model.TypeName = ds.Tables[0].Rows[0]["TypeName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Type01"] != null && ds.Tables[0].Rows[0]["Type01"].ToString() != "")
                {
                    model.Type01 = int.Parse(ds.Tables[0].Rows[0]["Type01"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Type02"] != null && ds.Tables[0].Rows[0]["Type02"].ToString() != "")
                {
                    model.Type02 = int.Parse(ds.Tables[0].Rows[0]["Type02"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Type03"] != null && ds.Tables[0].Rows[0]["Type03"].ToString() != "")
                {
                    model.Type03 = decimal.Parse(ds.Tables[0].Rows[0]["Type03"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Type04"] != null && ds.Tables[0].Rows[0]["Type04"].ToString() != "")
                {
                    model.Type04 = decimal.Parse(ds.Tables[0].Rows[0]["Type04"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Type05"] != null && ds.Tables[0].Rows[0]["Type05"].ToString() != "")
                {
                    model.Type05 = ds.Tables[0].Rows[0]["Type05"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Type06"] != null && ds.Tables[0].Rows[0]["Type06"].ToString() != "")
                {
                    model.Type06 = ds.Tables[0].Rows[0]["Type06"].ToString();
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
        public lgk.Model.tb_produceType GetModel(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ParentID,TypeName,Type01,Type02,Type03,Type04,Type05,Type06 from tb_produceType ");

            if (where != "")
                strSql.Append(" where " + where);

            lgk.Model.tb_produceType model = new lgk.Model.tb_produceType();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentID"] != null && ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TypeName"] != null && ds.Tables[0].Rows[0]["TypeName"].ToString() != "")
                {
                    model.TypeName = ds.Tables[0].Rows[0]["TypeName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Type01"] != null && ds.Tables[0].Rows[0]["Type01"].ToString() != "")
                {
                    model.Type01 = int.Parse(ds.Tables[0].Rows[0]["Type01"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Type02"] != null && ds.Tables[0].Rows[0]["Type02"].ToString() != "")
                {
                    model.Type02 = int.Parse(ds.Tables[0].Rows[0]["Type02"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Type03"] != null && ds.Tables[0].Rows[0]["Type03"].ToString() != "")
                {
                    model.Type03 = decimal.Parse(ds.Tables[0].Rows[0]["Type03"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Type04"] != null && ds.Tables[0].Rows[0]["Type04"].ToString() != "")
                {
                    model.Type04 = decimal.Parse(ds.Tables[0].Rows[0]["Type04"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Type05"] != null && ds.Tables[0].Rows[0]["Type05"].ToString() != "")
                {
                    model.Type05 = ds.Tables[0].Rows[0]["Type05"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Type06"] != null && ds.Tables[0].Rows[0]["Type06"].ToString() != "")
                {
                    model.Type06 = ds.Tables[0].Rows[0]["Type06"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取类型名称
        /// </summary>
        public string GetTypeName(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [TypeName] FROM tb_produceType");
            strSql.Append(" WHERE ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
            parameters[0].Value = ID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ParentID,TypeName,Type01,Type02,Type03,Type04,Type05,Type06 ");
            strSql.Append(" FROM tb_produceType ");
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
            strSql.Append(" ID,ParentID,TypeName,Type01,Type02,Type03,Type04,Type05,Type06 ");
            strSql.Append(" FROM tb_produceType ");
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
            parameters[0].Value = "tb_produceType";
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

