using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DataAccess;

namespace lgk.DAL
{
    //tb_UserMale
    public partial class tb_UserMale
    {

        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_UserMale");
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
        public int Add(lgk.Model.tb_UserMale model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_UserMale(");
            strSql.Append("ParentID,MyLeft,MyRight,UserMaleCode,UserMale001,UserMale002,OrderID,UserID,AddDate,IsOut,OutDate,UserPath,Layer,Location");
            strSql.Append(") values (");
            strSql.Append("@ParentID,@MyLeft,@MyRight,@UserMaleCode,@UserMale001,@UserMale002,@OrderID,@UserID,@AddDate,@IsOut,@OutDate,@UserPath,@Layer,@Location");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@ParentID", SqlDbType.Int,4) ,            
                        new SqlParameter("@MyLeft", SqlDbType.Int,4) ,            
                        new SqlParameter("@MyRight", SqlDbType.Int,4) ,            
                        new SqlParameter("@UserMaleCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@UserMale001", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@UserMale002", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@OrderID", SqlDbType.Int,4) ,            
                        new SqlParameter("@UserID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@AddDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@IsOut", SqlDbType.Int,4) ,            
                        new SqlParameter("@OutDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@UserPath", SqlDbType.Text) ,            
                        new SqlParameter("@Layer", SqlDbType.Int,4) ,            
                        new SqlParameter("@Location", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.ParentID;
            parameters[1].Value = model.MyLeft;
            parameters[2].Value = model.MyRight;
            parameters[3].Value = model.UserMaleCode;
            parameters[4].Value = model.UserMale001;
            parameters[5].Value = model.UserMale002;
            parameters[6].Value = model.OrderID;
            parameters[7].Value = model.UserID;
            parameters[8].Value = model.AddDate;
            parameters[9].Value = model.IsOut;
            parameters[10].Value = model.OutDate;
            parameters[11].Value = model.UserPath;
            parameters[12].Value = model.Layer;
            parameters[13].Value = model.Location;

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
        public bool Update(lgk.Model.tb_UserMale model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_UserMale set ");

            strSql.Append(" ParentID = @ParentID , ");
            strSql.Append(" MyLeft = @MyLeft , ");
            strSql.Append(" MyRight = @MyRight , ");
            strSql.Append(" UserMaleCode = @UserMaleCode , ");
            strSql.Append(" UserMale001 = @UserMale001 , ");
            strSql.Append(" UserMale002 = @UserMale002 , ");
            strSql.Append(" OrderID = @OrderID , ");
            strSql.Append(" UserID = @UserID , ");
            strSql.Append(" AddDate = @AddDate , ");
            strSql.Append(" IsOut = @IsOut , ");
            strSql.Append(" OutDate = @OutDate , ");
            strSql.Append(" UserPath = @UserPath , ");
            strSql.Append(" Layer = @Layer , ");
            strSql.Append(" Location = @Location  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ParentID", SqlDbType.Int,4) ,            
                        new SqlParameter("@MyLeft", SqlDbType.Int,4) ,            
                        new SqlParameter("@MyRight", SqlDbType.Int,4) ,            
                        new SqlParameter("@UserMaleCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@UserMale001", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@UserMale002", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@OrderID", SqlDbType.Int,4) ,            
                        new SqlParameter("@UserID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@AddDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@IsOut", SqlDbType.Int,4) ,            
                        new SqlParameter("@OutDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@UserPath", SqlDbType.Text) ,            
                        new SqlParameter("@Layer", SqlDbType.Int,4) ,            
                        new SqlParameter("@Location", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.ParentID;
            parameters[2].Value = model.MyLeft;
            parameters[3].Value = model.MyRight;
            parameters[4].Value = model.UserMaleCode;
            parameters[5].Value = model.UserMale001;
            parameters[6].Value = model.UserMale002;
            parameters[7].Value = model.OrderID;
            parameters[8].Value = model.UserID;
            parameters[9].Value = model.AddDate;
            parameters[10].Value = model.IsOut;
            parameters[11].Value = model.OutDate;
            parameters[12].Value = model.UserPath;
            parameters[13].Value = model.Layer;
            parameters[14].Value = model.Location;
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
            strSql.Append("delete from tb_UserMale ");
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetOpenList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select a.ID,a.IsOut,a.UserMaleCode,a.OutDate,b.usercode,b.TrueName,b.LevelID from tb_UserMale a left join tb_user b on a.userid=b.userid ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_UserMale ");
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
        public lgk.Model.tb_UserMale GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, ParentID, MyLeft, MyRight, UserMaleCode, UserMale001, UserMale002, OrderID, UserID, AddDate, IsOut, OutDate, UserPath, Layer, Location  ");
            strSql.Append("  from tb_UserMale ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;


            lgk.Model.tb_UserMale model = new lgk.Model.tb_UserMale();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MyLeft"].ToString() != "")
                {
                    model.MyLeft = int.Parse(ds.Tables[0].Rows[0]["MyLeft"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MyRight"].ToString() != "")
                {
                    model.MyRight = int.Parse(ds.Tables[0].Rows[0]["MyRight"].ToString());
                }
                model.UserMaleCode = ds.Tables[0].Rows[0]["UserMaleCode"].ToString();
                model.UserMale001 = ds.Tables[0].Rows[0]["UserMale001"].ToString();
                model.UserMale002 = ds.Tables[0].Rows[0]["UserMale002"].ToString();
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsOut"].ToString() != "")
                {
                    model.IsOut = int.Parse(ds.Tables[0].Rows[0]["IsOut"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OutDate"].ToString() != "")
                {
                    model.OutDate = DateTime.Parse(ds.Tables[0].Rows[0]["OutDate"].ToString());
                }
                model.UserPath = ds.Tables[0].Rows[0]["UserPath"].ToString();
                if (ds.Tables[0].Rows[0]["Layer"].ToString() != "")
                {
                    model.Layer = int.Parse(ds.Tables[0].Rows[0]["Layer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Location"].ToString() != "")
                {
                    model.Location = int.Parse(ds.Tables[0].Rows[0]["Location"].ToString());
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
        public lgk.Model.tb_UserMale GetModel(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, ParentID, MyLeft, MyRight, UserMaleCode, UserMale001, UserMale002, OrderID, UserID, AddDate, IsOut, OutDate, UserPath, Layer, Location  ");
            strSql.Append("  from tb_UserMale ");
            strSql.Append(" where " + strWhere);
            strSql.Append(" order by ID asc ");
            lgk.Model.tb_UserMale model = new lgk.Model.tb_UserMale();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MyLeft"].ToString() != "")
                {
                    model.MyLeft = int.Parse(ds.Tables[0].Rows[0]["MyLeft"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MyRight"].ToString() != "")
                {
                    model.MyRight = int.Parse(ds.Tables[0].Rows[0]["MyRight"].ToString());
                }
                model.UserMaleCode = ds.Tables[0].Rows[0]["UserMaleCode"].ToString();
                model.UserMale001 = ds.Tables[0].Rows[0]["UserMale001"].ToString();
                model.UserMale002 = ds.Tables[0].Rows[0]["UserMale002"].ToString();
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsOut"].ToString() != "")
                {
                    model.IsOut = int.Parse(ds.Tables[0].Rows[0]["IsOut"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OutDate"].ToString() != "")
                {
                    model.OutDate = DateTime.Parse(ds.Tables[0].Rows[0]["OutDate"].ToString());
                }
                model.UserPath = ds.Tables[0].Rows[0]["UserPath"].ToString();
                if (ds.Tables[0].Rows[0]["Layer"].ToString() != "")
                {
                    model.Layer = int.Parse(ds.Tables[0].Rows[0]["Layer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Location"].ToString() != "")
                {
                    model.Location = int.Parse(ds.Tables[0].Rows[0]["Location"].ToString());
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
            strSql.Append(" FROM tb_UserMale ");
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
            strSql.Append(" FROM tb_UserMale ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int GetLastGotoBAreaID()
        {
            string strSQL = "SELECT top 1 id FROM tb_UserMale WHERE IsOut<>1 ORDER BY AddDate DESC";
            object oj = DbHelperSQL.GetSingle(strSQL);
            if (oj != null)
            {
                return int.Parse(oj.ToString());
            }
            else
            { return 0; }
        }

        /// <summary>
        /// 查询正在公排的数量
        /// </summary>
        /// <returns></returns>
        public int CountPublicOrder()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ISNULL(count(ID),0) from tb_UserMale ");
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 当第11个公排号进来时将第一个踢出局，同时更新所有公排顺序
        /// </summary>
        /// <returns></returns>
        public int FirstOut()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_UserMale set OrderID=OrderID-1 where IsOut = 0 and OrderID > 0");
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 将出局的公排更新为已出局状态
        /// </summary>
        /// <returns></returns>
        public int UpdateOrderID()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_UserMale set IsOut=1,OutDate=getdate() where IsOut = 0 and OrderID = 0");
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 见点奖存储过程
        /// </summary>
        /// <param name="userid">会员ID</param>
        /// <returns></returns>
        public int Flag_JianDian4BNet(int userid)
        {
            int result;
            string prop = "proc_Award_Seesome";
            SqlParameter[] para = { new SqlParameter("@UserID", SqlDbType.Int) };
            para[0].Value = userid;
            DbHelperSQL.RunProcedure(prop, para, out result);
            return result;
        }

        #region 统计指定层数的公排个数
        /// <summary>
        /// 统计指定层数的B网公排个数
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        public int CountLayerNumber(int layer)
        {
            string strSQL = "select COUNT(ID) FROM tb_UserMale where IsOut = 0 and Layer =" + layer;
            object count = DbHelperSQL.GetSingle(strSQL);
            if (count != null)
            {
                return int.Parse(count.ToString());
            }
            else
            {
                return 0;
            }
        }
        #endregion
        #region 获取没有放满子节点的公排时间最早的节点
        /// <summary>
        /// 获取没有放满子节点的公排时间最早的节点
        /// </summary>
        /// <returns></returns>
        public lgk.Model.tb_UserMale GetNoFullChildNode()
        {
            string strSQL = "select top 1 ID,OrderID,UserID,AddDate,IsOut,OutDate,UserPath,Layer,Location,ParentID,MyLeft,MyRight,UserMaleCode,UserMale001,UserMale002 from tb_UserMale WHERE AddDate = (select MIN(AddDate) from tb_UserMale where (MyLeft = 0 OR MyRight = 0) AND IsOut <> 1)";
            lgk.Model.tb_UserMale model = new lgk.Model.tb_UserMale();
            DataSet ds = DbHelperSQL.Query(strSQL, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderID"] != null && ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddDate"] != null && ds.Tables[0].Rows[0]["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsOut"] != null && ds.Tables[0].Rows[0]["IsOut"].ToString() != "")
                {
                    model.IsOut = int.Parse(ds.Tables[0].Rows[0]["IsOut"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OutDate"] != null && ds.Tables[0].Rows[0]["OutDate"].ToString() != "")
                {
                    model.OutDate = DateTime.Parse(ds.Tables[0].Rows[0]["OutDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserPath"] != null && ds.Tables[0].Rows[0]["UserPath"].ToString() != "")
                {
                    model.UserPath = ds.Tables[0].Rows[0]["UserPath"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Layer"] != null && ds.Tables[0].Rows[0]["Layer"].ToString() != "")
                {
                    model.Layer = int.Parse(ds.Tables[0].Rows[0]["Layer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Location"] != null && ds.Tables[0].Rows[0]["Location"].ToString() != "")
                {
                    model.Location = int.Parse(ds.Tables[0].Rows[0]["Location"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentID"] != null && ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MyLeft"] != null && ds.Tables[0].Rows[0]["MyLeft"].ToString() != "")
                {
                    model.MyLeft = int.Parse(ds.Tables[0].Rows[0]["MyLeft"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MyRight"] != null && ds.Tables[0].Rows[0]["MyRight"].ToString() != "")
                {
                    model.MyRight = int.Parse(ds.Tables[0].Rows[0]["MyRight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserMaleCode"] != null && ds.Tables[0].Rows[0]["UserMaleCode"].ToString() != "")
                {
                    model.UserMaleCode = ds.Tables[0].Rows[0]["UserMaleCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UserMale001"] != null && ds.Tables[0].Rows[0]["UserMale001"].ToString() != "")
                {
                    model.UserMale001 = ds.Tables[0].Rows[0]["UserMale001"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UserMale002"] != null && ds.Tables[0].Rows[0]["UserMale002"].ToString() != "")
                {
                    model.UserMale002 = ds.Tables[0].Rows[0]["UserMale002"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion
        #region 根据条件获取一条数据
        /// <summary>
        /// 根据条件获取一条数据
        /// </summary>
        /// <returns></returns>
        public lgk.Model.tb_UserMale GetModelByWhere(string whereStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select top 1 ID,OrderID,UserID,AddDate,IsOut,OutDate,UserPath,Layer,Location,ParentID,MyLeft,MyRight,UserMaleCode,UserMale001,UserMale002 from tb_UserMale ");
            if (!string.IsNullOrEmpty(whereStr))
            {
                sb.Append(" where " + whereStr);
            }
            lgk.Model.tb_UserMale model = new lgk.Model.tb_UserMale();
            DataSet ds = DbHelperSQL.Query(sb.ToString(), null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderID"] != null && ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddDate"] != null && ds.Tables[0].Rows[0]["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsOut"] != null && ds.Tables[0].Rows[0]["IsOut"].ToString() != "")
                {
                    model.IsOut = int.Parse(ds.Tables[0].Rows[0]["IsOut"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OutDate"] != null && ds.Tables[0].Rows[0]["OutDate"].ToString() != "")
                {
                    model.OutDate = DateTime.Parse(ds.Tables[0].Rows[0]["OutDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserPath"] != null && ds.Tables[0].Rows[0]["UserPath"].ToString() != "")
                {
                    model.UserPath = ds.Tables[0].Rows[0]["UserPath"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Layer"] != null && ds.Tables[0].Rows[0]["Layer"].ToString() != "")
                {
                    model.Layer = int.Parse(ds.Tables[0].Rows[0]["Layer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Location"] != null && ds.Tables[0].Rows[0]["Location"].ToString() != "")
                {
                    model.Location = int.Parse(ds.Tables[0].Rows[0]["Location"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentID"] != null && ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MyLeft"] != null && ds.Tables[0].Rows[0]["MyLeft"].ToString() != "")
                {
                    model.MyLeft = int.Parse(ds.Tables[0].Rows[0]["MyLeft"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MyRight"] != null && ds.Tables[0].Rows[0]["MyRight"].ToString() != "")
                {
                    model.MyRight = int.Parse(ds.Tables[0].Rows[0]["MyRight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserMaleCode"] != null && ds.Tables[0].Rows[0]["UserMaleCode"].ToString() != "")
                {
                    model.UserMaleCode = ds.Tables[0].Rows[0]["UserMaleCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UserMale001"] != null && ds.Tables[0].Rows[0]["UserMale001"].ToString() != "")
                {
                    model.UserMale001 = ds.Tables[0].Rows[0]["UserMale001"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UserMale002"] != null && ds.Tables[0].Rows[0]["UserMale002"].ToString() != "")
                {
                    model.UserMale002 = ds.Tables[0].Rows[0]["UserMale002"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion
        #region 根据ID获取一条数据
        /// <summary>
        /// 根据ID获取一条数据
        /// </summary>
        /// <returns></returns>
        public lgk.Model.tb_UserMale GetModelByID(int ID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select top 1 ID,OrderID,UserID,AddDate,IsOut,OutDate,UserPath,Layer,Location,ParentID,MyLeft,MyRight,UserMaleCode,UserMale001,UserMale002 from tb_UserMale ");
            sb.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int, 4)
            };
            parameters[0].Value = ID;
            lgk.Model.tb_UserMale model = new lgk.Model.tb_UserMale();
            DataSet ds = DbHelperSQL.Query(sb.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderID"] != null && ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddDate"] != null && ds.Tables[0].Rows[0]["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsOut"] != null && ds.Tables[0].Rows[0]["IsOut"].ToString() != "")
                {
                    model.IsOut = int.Parse(ds.Tables[0].Rows[0]["IsOut"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OutDate"] != null && ds.Tables[0].Rows[0]["OutDate"].ToString() != "")
                {
                    model.OutDate = DateTime.Parse(ds.Tables[0].Rows[0]["OutDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserPath"] != null && ds.Tables[0].Rows[0]["UserPath"].ToString() != "")
                {
                    model.UserPath = ds.Tables[0].Rows[0]["UserPath"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Layer"] != null && ds.Tables[0].Rows[0]["Layer"].ToString() != "")
                {
                    model.Layer = int.Parse(ds.Tables[0].Rows[0]["Layer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Location"] != null && ds.Tables[0].Rows[0]["Location"].ToString() != "")
                {
                    model.Location = int.Parse(ds.Tables[0].Rows[0]["Location"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentID"] != null && ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MyLeft"] != null && ds.Tables[0].Rows[0]["MyLeft"].ToString() != "")
                {
                    model.MyLeft = int.Parse(ds.Tables[0].Rows[0]["MyLeft"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MyRight"] != null && ds.Tables[0].Rows[0]["MyRight"].ToString() != "")
                {
                    model.MyRight = int.Parse(ds.Tables[0].Rows[0]["MyRight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserMaleCode"] != null && ds.Tables[0].Rows[0]["UserMaleCode"].ToString() != "")
                {
                    model.UserMaleCode = ds.Tables[0].Rows[0]["UserMaleCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UserMale001"] != null && ds.Tables[0].Rows[0]["UserMale001"].ToString() != "")
                {
                    model.UserMale001 = ds.Tables[0].Rows[0]["UserMale001"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UserMale002"] != null && ds.Tables[0].Rows[0]["UserMale002"].ToString() != "")
                {
                    model.UserMale002 = ds.Tables[0].Rows[0]["UserMale002"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AgentCode"></param>
        /// <returns></returns>
        public int GetIDByUserCode(string GotoBAreaCode)
        {
            string strSQL = string.Format("select id FROM tb_UserMale where UserID=(select top 1 UserID from tb_user where UserCode='{0}')", GotoBAreaCode);
            object oj = DbHelperSQL.GetSingle(strSQL);
            if (oj != null)
            {
                return int.Parse(oj.ToString());
            }
            else
            { return 0; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int GetIDByIDUser(int userid)
        {
            string strSQL = "select ID FROM tb_UserMale WHERE UserID=" + userid;
            object oj = DbHelperSQL.GetSingle(strSQL);
            if (oj != null)
            {
                return int.Parse(oj.ToString());
            }
            else
            { return 0; }
        }
    }
}

