using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:tb_leaveMsg
	/// </summary>
	public partial class tb_leaveMsg
	{
		public tb_leaveMsg()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_leaveMsg");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(lgk.Model.tb_leaveMsg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_leaveMsg(");
			strSql.Append("MsgTitle,MsgContent,LeaveTime,IsRead,IsReply,FromUserType,UserID,UserCode,FromIDIsDel,ToUserType,ToUserID,ToUserCode,ToIDIsDel,MsgType,Pic)");
			strSql.Append(" values (");
			strSql.Append("@MsgTitle,@MsgContent,@LeaveTime,@IsRead,@IsReply,@FromUserType,@UserID,@UserCode,@FromIDIsDel,@ToUserType,@ToUserID,@ToUserCode,@ToIDIsDel,@MsgType,@Pic)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MsgTitle", SqlDbType.VarChar,100),
					new SqlParameter("@MsgContent", SqlDbType.Text),
					new SqlParameter("@LeaveTime", SqlDbType.DateTime),
					new SqlParameter("@IsRead", SqlDbType.Int,4),
					new SqlParameter("@IsReply", SqlDbType.Int,4),
					new SqlParameter("@FromUserType", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@UserCode", SqlDbType.VarChar,20),
					new SqlParameter("@FromIDIsDel", SqlDbType.Int,4),
					new SqlParameter("@ToUserType", SqlDbType.Int,4),
					new SqlParameter("@ToUserID", SqlDbType.BigInt,8),
					new SqlParameter("@ToUserCode", SqlDbType.VarChar,20),
					new SqlParameter("@ToIDIsDel", SqlDbType.Int,4),
                    new SqlParameter("@MsgType", SqlDbType.Int,4),
                    new SqlParameter("@Pic", SqlDbType.VarChar,200)};
			parameters[0].Value = model.MsgTitle;
			parameters[1].Value = model.MsgContent;
			parameters[2].Value = model.LeaveTime;
			parameters[3].Value = model.IsRead;
			parameters[4].Value = model.IsReply;
			parameters[5].Value = model.FromUserType;
			parameters[6].Value = model.UserID;
			parameters[7].Value = model.UserCode;
			parameters[8].Value = model.FromIDIsDel;
			parameters[9].Value = model.ToUserType;
			parameters[10].Value = model.ToUserID;
			parameters[11].Value = model.ToUserCode;
			parameters[12].Value = model.ToIDIsDel;
            parameters[13].Value = model.MsgType;
            parameters[14].Value = model.Pic;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt64(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(lgk.Model.tb_leaveMsg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_leaveMsg set ");
			strSql.Append("MsgTitle=@MsgTitle,");
			strSql.Append("MsgContent=@MsgContent,");
			strSql.Append("LeaveTime=@LeaveTime,");
			strSql.Append("IsRead=@IsRead,");
			strSql.Append("IsReply=@IsReply,");
			strSql.Append("FromUserType=@FromUserType,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("UserCode=@UserCode,");
			strSql.Append("FromIDIsDel=@FromIDIsDel,");
			strSql.Append("ToUserType=@ToUserType,");
			strSql.Append("ToUserID=@ToUserID,");
			strSql.Append("ToUserCode=@ToUserCode,");
            strSql.Append("ToIDIsDel=@ToIDIsDel,");
            strSql.Append("MsgType=@MsgType");
            strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@MsgTitle", SqlDbType.VarChar,100),
					new SqlParameter("@MsgContent", SqlDbType.Text),
					new SqlParameter("@LeaveTime", SqlDbType.DateTime),
					new SqlParameter("@IsRead", SqlDbType.Int,4),
					new SqlParameter("@IsReply", SqlDbType.Int,4),
					new SqlParameter("@FromUserType", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@UserCode", SqlDbType.VarChar,20),
					new SqlParameter("@FromIDIsDel", SqlDbType.Int,4),
					new SqlParameter("@ToUserType", SqlDbType.Int,4),
					new SqlParameter("@ToUserID", SqlDbType.BigInt,8),
					new SqlParameter("@ToUserCode", SqlDbType.VarChar,20),
                    new SqlParameter("@ToIDIsDel", SqlDbType.Int,4),
                    new SqlParameter("@MsgType", SqlDbType.Int,4),
                    new SqlParameter("@ID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.MsgTitle;
			parameters[1].Value = model.MsgContent;
			parameters[2].Value = model.LeaveTime;
			parameters[3].Value = model.IsRead;
			parameters[4].Value = model.IsReply;
			parameters[5].Value = model.FromUserType;
			parameters[6].Value = model.UserID;
			parameters[7].Value = model.UserCode;
			parameters[8].Value = model.FromIDIsDel;
			parameters[9].Value = model.ToUserType;
			parameters[10].Value = model.ToUserID;
			parameters[11].Value = model.ToUserCode;
            parameters[12].Value = model.ToIDIsDel;
            parameters[13].Value = model.MsgType;
            parameters[14].Value = model.ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_leaveMsg ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
			strSql.Append("delete from tb_leaveMsg ");
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
		public lgk.Model.tb_leaveMsg GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,MsgTitle,MsgContent,LeaveTime,IsRead,IsReply,FromUserType,UserID,UserCode,FromIDIsDel,ToUserType,ToUserID,ToUserCode,ToIDIsDel,MsgType,Pic from tb_leaveMsg ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
};
			parameters[0].Value = ID;

			lgk.Model.tb_leaveMsg model=new lgk.Model.tb_leaveMsg();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MsgTitle"]!=null && ds.Tables[0].Rows[0]["MsgTitle"].ToString()!="")
				{
					model.MsgTitle=ds.Tables[0].Rows[0]["MsgTitle"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MsgContent"]!=null && ds.Tables[0].Rows[0]["MsgContent"].ToString()!="")
				{
					model.MsgContent=ds.Tables[0].Rows[0]["MsgContent"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LeaveTime"]!=null && ds.Tables[0].Rows[0]["LeaveTime"].ToString()!="")
				{
					model.LeaveTime=DateTime.Parse(ds.Tables[0].Rows[0]["LeaveTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRead"]!=null && ds.Tables[0].Rows[0]["IsRead"].ToString()!="")
				{
					model.IsRead=int.Parse(ds.Tables[0].Rows[0]["IsRead"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsReply"]!=null && ds.Tables[0].Rows[0]["IsReply"].ToString()!="")
				{
					model.IsReply=int.Parse(ds.Tables[0].Rows[0]["IsReply"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FromUserType"]!=null && ds.Tables[0].Rows[0]["FromUserType"].ToString()!="")
				{
					model.FromUserType=int.Parse(ds.Tables[0].Rows[0]["FromUserType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserID"]!=null && ds.Tables[0].Rows[0]["UserID"].ToString()!="")
				{
					model.UserID=long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserCode"]!=null && ds.Tables[0].Rows[0]["UserCode"].ToString()!="")
				{
					model.UserCode=ds.Tables[0].Rows[0]["UserCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["FromIDIsDel"]!=null && ds.Tables[0].Rows[0]["FromIDIsDel"].ToString()!="")
				{
					model.FromIDIsDel=int.Parse(ds.Tables[0].Rows[0]["FromIDIsDel"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ToUserType"]!=null && ds.Tables[0].Rows[0]["ToUserType"].ToString()!="")
				{
					model.ToUserType=int.Parse(ds.Tables[0].Rows[0]["ToUserType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ToUserID"]!=null && ds.Tables[0].Rows[0]["ToUserID"].ToString()!="")
				{
					model.ToUserID=long.Parse(ds.Tables[0].Rows[0]["ToUserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ToUserCode"]!=null && ds.Tables[0].Rows[0]["ToUserCode"].ToString()!="")
				{
					model.ToUserCode=ds.Tables[0].Rows[0]["ToUserCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ToIDIsDel"]!=null && ds.Tables[0].Rows[0]["ToIDIsDel"].ToString()!="")
				{
					model.ToIDIsDel=int.Parse(ds.Tables[0].Rows[0]["ToIDIsDel"].ToString());
				}
                if (ds.Tables[0].Rows[0]["MsgType"] != null && ds.Tables[0].Rows[0]["MsgType"].ToString() != "")
                {
                    model.MsgType = int.Parse(ds.Tables[0].Rows[0]["MsgType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Pic"] != null && ds.Tables[0].Rows[0]["Pic"].ToString() != "")
                {
                    model.Pic = ds.Tables[0].Rows[0]["Pic"].ToString();
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,MsgTitle,MsgContent,LeaveTime,IsRead,IsReply,FromUserType,UserID,UserCode,FromIDIsDel,ToUserType,ToUserID,ToUserCode,ToIDIsDel ,MsgType");
			strSql.Append(" FROM tb_leaveMsg ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetRecordList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from v_Msg ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,MsgTitle,MsgContent,LeaveTime,IsRead,IsReply,FromUserType,UserID,UserCode,FromIDIsDel,ToUserType,ToUserID,ToUserCode,ToIDIsDel ,MsgType");
			strSql.Append(" FROM tb_leaveMsg ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			parameters[0].Value = "tb_leaveMsg";
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

