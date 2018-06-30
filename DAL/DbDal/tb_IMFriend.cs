using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace lgk.DAL
{
    public partial class tb_IMFriend
    {
        /// <summary>
        /// 得到好友ID
        /// </summary>
        public long GetID(long UserID, long FriendID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [ID] FROM tb_IMFriend");
            strSql.Append(" where (UserID=@UserID and FriendID=@FriendID)");
            strSql.Append(" or (UserID=@FriendID and FriendID=@UserID)");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt),
                    new SqlParameter("@FriendID", SqlDbType.BigInt)
            };
            parameters[0].Value = UserID;
            parameters[1].Value = FriendID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return long.Parse(obj.ToString());
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_IMFriend GetModel(long UserID, long FriendID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, UserID, UserCode, FriendCode, FriendID, AddTime  ");
            strSql.Append("  from tb_IMFriend ");
            strSql.Append(" where UserID=@UserID and FriendID=@FriendID");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt),
                    new SqlParameter("@FriendID", SqlDbType.BigInt)
            };
            parameters[0].Value = UserID;
            parameters[1].Value = FriendID;

            lgk.Model.tb_IMFriend model = new lgk.Model.tb_IMFriend();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.UserCode = ds.Tables[0].Rows[0]["UserCode"].ToString();
                model.FriendCode = ds.Tables[0].Rows[0]["FriendCode"].ToString();
                if (ds.Tables[0].Rows[0]["FriendID"].ToString() != "")
                {
                    model.FriendID = long.Parse(ds.Tables[0].Rows[0]["FriendID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 好友列表
        /// </summary>
        public DataSet GetFriendList(long UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select u.userid, u.UserCode as FriendCode,u.User009 as Pic,u.NiceName,u.PhoneNum from tb_user u  ");
            strSql.Append(" right join (SELECT FriendID, FriendCode from tb_IMFriend where UserID = @UserID ");
            strSql.Append(" union all ");
            strSql.Append(" SELECT UserID, UserCode from tb_IMFriend where FriendID = @UserID) f ");
            strSql.Append(" on u.UserID = f.FriendID");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt)
            };
            parameters[0].Value = UserID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return ds;
        }
        /// <summary>
        /// 好友列表
        /// </summary>
        public DataSet GetTeamList(long UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select UserCode as TeamCode,  ");
            strSql.Append("   User011 as Speed  ,cast(User015 as int) as TeamNum ");
            strSql.Append("  from tb_user t ");
            strSql.Append(" where RecommendID  = @UserID");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt)
            };
            parameters[0].Value = UserID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return ds;
        }

        public DataSet GetListByPage(long UserID, int PageIndex, int PageSize, out int PageCount, out int TotalCount)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageCount", SqlDbType.Int),
                    new SqlParameter("@TotalCount", SqlDbType.Int)
            };
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;

            parameters[0].Value = UserID;
            parameters[1].Value = PageIndex;
            parameters[2].Value = PageSize;

            string proc = "proc_Page_FriendDynamic";
            DataSet ds = DbHelperSQL.RunProcedure(proc, parameters, "poly");

            PageCount = int.Parse(parameters[3].Value.ToString());
            TotalCount = int.Parse(parameters[4].Value.ToString());

            return ds;
        }
        public DataSet GetListPersonalByPage(long UserID, int PageIndex, int PageSize, out int PageCount, out int TotalCount)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageCount", SqlDbType.Int),
                    new SqlParameter("@TotalCount", SqlDbType.Int)
            };
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;

            parameters[0].Value = UserID;
            parameters[1].Value = PageIndex;
            parameters[2].Value = PageSize;

            string proc = "proc_Page_PersonalDynamic";
            DataSet ds = DbHelperSQL.RunProcedure(proc, parameters, "poly");

            PageCount = int.Parse(parameters[3].Value.ToString());
            TotalCount = int.Parse(parameters[4].Value.ToString());

            return ds;
        }
        /// <summary>
        /// 评论
        /// </summary>
        /// <param name="DynamicID"></param>
        /// <returns></returns>
        public DataSet GetComment(long DynamicID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select a.ID,u.UserCode as ReUserCode, u.NiceName as ReName,u.userid as ReUserID,t.UserCode as ToUserCode,t.userid as ToUserID,case when t.NiceName is null then '' else t.nicename end as ToName ,a.Content,a.AddTime ");
            strSql.Append(" from tb_FriendDynamicComment a ");
            strSql.Append(" left  join tb_user u on a.UserID = u.UserID ");
            strSql.Append(" left  join tb_user t on a.toUserID = t.UserID ");
            strSql.Append(" where a.DynamicID = @DynamicID");

            SqlParameter[] parameters = {
                    new SqlParameter("@DynamicID", SqlDbType.BigInt)
            };
            parameters[0].Value = DynamicID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return ds;
        }
    }
}
