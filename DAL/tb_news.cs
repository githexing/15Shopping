using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references
namespace lgk.DAL
{
	/// <summary>
	/// 数据访问类:tb_news
	/// </summary>
	public partial class tb_news
	{
		public tb_news()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_news");
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
		public long Add(lgk.Model.tb_news model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_news(");
			strSql.Append("NewsTitle,NewsContent,NewsType,PublishTime,Publisher,ImageURL,NewType,Classify,Tags,Click,New01,New02,New03,New04,New05,New06)");
			strSql.Append(" values (");
			strSql.Append("@NewsTitle,@NewsContent,@NewsType,@PublishTime,@Publisher,@ImageURL,@NewType,@Classify,@Tags,@Click,@New01,@New02,@New03,@New04,@New05,@New06)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsTitle", SqlDbType.VarChar,100),
					new SqlParameter("@NewsContent", SqlDbType.Text),
					new SqlParameter("@NewsType", SqlDbType.Int,4),
					new SqlParameter("@PublishTime", SqlDbType.DateTime),
					new SqlParameter("@Publisher", SqlDbType.VarChar,50),
					new SqlParameter("@ImageURL", SqlDbType.VarChar,50),
					new SqlParameter("@NewType", SqlDbType.Int,4),
					new SqlParameter("@Classify", SqlDbType.VarChar,100),
					new SqlParameter("@Tags", SqlDbType.VarChar,500),
					new SqlParameter("@Click", SqlDbType.Int,4),
					new SqlParameter("@New01", SqlDbType.Int,4),
					new SqlParameter("@New02", SqlDbType.Int,4),
					new SqlParameter("@New03", SqlDbType.Decimal,9),
					new SqlParameter("@New04", SqlDbType.Decimal,9),
					new SqlParameter("@New05", SqlDbType.VarChar,500),
					new SqlParameter("@New06", SqlDbType.VarChar,500)};
			parameters[0].Value = model.NewsTitle;
			parameters[1].Value = model.NewsContent;
			parameters[2].Value = model.NewsType;
			parameters[3].Value = model.PublishTime;
			parameters[4].Value = model.Publisher;
			parameters[5].Value = model.ImageURL;
			parameters[6].Value = model.NewType;
			parameters[7].Value = model.Classify;
			parameters[8].Value = model.Tags;
			parameters[9].Value = model.Click;
			parameters[10].Value = model.New01;
			parameters[11].Value = model.New02;
			parameters[12].Value = model.New03;
			parameters[13].Value = model.New04;
			parameters[14].Value = model.New05;
			parameters[15].Value = model.New06;

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
		public bool Update(lgk.Model.tb_news model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_news set ");
			strSql.Append("NewsTitle=@NewsTitle,");
			strSql.Append("NewsContent=@NewsContent,");
			strSql.Append("NewsType=@NewsType,");
			strSql.Append("PublishTime=@PublishTime,");
			strSql.Append("Publisher=@Publisher,");
			strSql.Append("ImageURL=@ImageURL,");
			strSql.Append("NewType=@NewType,");
			strSql.Append("Classify=@Classify,");
			strSql.Append("Tags=@Tags,");
			strSql.Append("Click=@Click,");
			strSql.Append("New01=@New01,");
			strSql.Append("New02=@New02,");
			strSql.Append("New03=@New03,");
			strSql.Append("New04=@New04,");
			strSql.Append("New05=@New05,");
			strSql.Append("New06=@New06");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsTitle", SqlDbType.VarChar,100),
					new SqlParameter("@NewsContent", SqlDbType.Text),
					new SqlParameter("@NewsType", SqlDbType.Int,4),
					new SqlParameter("@PublishTime", SqlDbType.DateTime),
					new SqlParameter("@Publisher", SqlDbType.VarChar,50),
					new SqlParameter("@ImageURL", SqlDbType.VarChar,50),
					new SqlParameter("@NewType", SqlDbType.Int,4),
					new SqlParameter("@Classify", SqlDbType.VarChar,100),
					new SqlParameter("@Tags", SqlDbType.VarChar,500),
					new SqlParameter("@Click", SqlDbType.Int,4),
					new SqlParameter("@New01", SqlDbType.Int,4),
					new SqlParameter("@New02", SqlDbType.Int,4),
					new SqlParameter("@New03", SqlDbType.Decimal,9),
					new SqlParameter("@New04", SqlDbType.Decimal,9),
					new SqlParameter("@New05", SqlDbType.VarChar,500),
					new SqlParameter("@New06", SqlDbType.VarChar,500),
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.NewsTitle;
			parameters[1].Value = model.NewsContent;
			parameters[2].Value = model.NewsType;
			parameters[3].Value = model.PublishTime;
			parameters[4].Value = model.Publisher;
			parameters[5].Value = model.ImageURL;
			parameters[6].Value = model.NewType;
			parameters[7].Value = model.Classify;
			parameters[8].Value = model.Tags;
			parameters[9].Value = model.Click;
			parameters[10].Value = model.New01;
			parameters[11].Value = model.New02;
			parameters[12].Value = model.New03;
			parameters[13].Value = model.New04;
			parameters[14].Value = model.New05;
			parameters[15].Value = model.New06;
			parameters[16].Value = model.ID;

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
			strSql.Append("delete from tb_news ");
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
			strSql.Append("delete from tb_news ");
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
		public lgk.Model.tb_news GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,NewsTitle,NewsContent,NewsType,PublishTime,Publisher,ImageURL,NewType,Classify,Tags,Click,New01,New02,New03,New04,New05,New06 from tb_news ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
};
			parameters[0].Value = ID;

			lgk.Model.tb_news model=new lgk.Model.tb_news();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NewsTitle"]!=null && ds.Tables[0].Rows[0]["NewsTitle"].ToString()!="")
				{
					model.NewsTitle=ds.Tables[0].Rows[0]["NewsTitle"].ToString();
				}
				if(ds.Tables[0].Rows[0]["NewsContent"]!=null && ds.Tables[0].Rows[0]["NewsContent"].ToString()!="")
				{
					model.NewsContent=ds.Tables[0].Rows[0]["NewsContent"].ToString();
				}
				if(ds.Tables[0].Rows[0]["NewsType"]!=null && ds.Tables[0].Rows[0]["NewsType"].ToString()!="")
				{
					model.NewsType=int.Parse(ds.Tables[0].Rows[0]["NewsType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PublishTime"]!=null && ds.Tables[0].Rows[0]["PublishTime"].ToString()!="")
				{
					model.PublishTime=DateTime.Parse(ds.Tables[0].Rows[0]["PublishTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Publisher"]!=null && ds.Tables[0].Rows[0]["Publisher"].ToString()!="")
				{
					model.Publisher=ds.Tables[0].Rows[0]["Publisher"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ImageURL"]!=null && ds.Tables[0].Rows[0]["ImageURL"].ToString()!="")
				{
					model.ImageURL=ds.Tables[0].Rows[0]["ImageURL"].ToString();
				}
				if(ds.Tables[0].Rows[0]["NewType"]!=null && ds.Tables[0].Rows[0]["NewType"].ToString()!="")
				{
					model.NewType=int.Parse(ds.Tables[0].Rows[0]["NewType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Classify"]!=null && ds.Tables[0].Rows[0]["Classify"].ToString()!="")
				{
					model.Classify=ds.Tables[0].Rows[0]["Classify"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Tags"]!=null && ds.Tables[0].Rows[0]["Tags"].ToString()!="")
				{
					model.Tags=ds.Tables[0].Rows[0]["Tags"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Click"]!=null && ds.Tables[0].Rows[0]["Click"].ToString()!="")
				{
					model.Click=int.Parse(ds.Tables[0].Rows[0]["Click"].ToString());
				}
				if(ds.Tables[0].Rows[0]["New01"]!=null && ds.Tables[0].Rows[0]["New01"].ToString()!="")
				{
					model.New01=int.Parse(ds.Tables[0].Rows[0]["New01"].ToString());
				}
				if(ds.Tables[0].Rows[0]["New02"]!=null && ds.Tables[0].Rows[0]["New02"].ToString()!="")
				{
					model.New02=int.Parse(ds.Tables[0].Rows[0]["New02"].ToString());
				}
				if(ds.Tables[0].Rows[0]["New03"]!=null && ds.Tables[0].Rows[0]["New03"].ToString()!="")
				{
					model.New03=decimal.Parse(ds.Tables[0].Rows[0]["New03"].ToString());
				}
				if(ds.Tables[0].Rows[0]["New04"]!=null && ds.Tables[0].Rows[0]["New04"].ToString()!="")
				{
					model.New04=decimal.Parse(ds.Tables[0].Rows[0]["New04"].ToString());
				}
				if(ds.Tables[0].Rows[0]["New05"]!=null && ds.Tables[0].Rows[0]["New05"].ToString()!="")
				{
					model.New05=ds.Tables[0].Rows[0]["New05"].ToString();
				}
				if(ds.Tables[0].Rows[0]["New06"]!=null && ds.Tables[0].Rows[0]["New06"].ToString()!="")
				{
					model.New06=ds.Tables[0].Rows[0]["New06"].ToString();
				}
				return model;
			}
			else
			{
				return null;
			}
		}

       /// <summary>
       /// 根据新闻类型与语音种类获取新闻
       /// </summary>
       /// <param name="typeId"></param>
       /// <param name="langType"></param>
       /// <returns></returns>
        public lgk.Model.tb_news GetModelByNewType(int typeId, int langType)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,NewsTitle,NewsContent,NewsType,PublishTime,Publisher,ImageURL,NewType,Classify,Tags,Click,New01,New02,New03,New04,New05,New06 from tb_news ");
            strSql.Append(" where NewType=@NewType and New01=@New01 order by PublishTime desc");
            SqlParameter[] parameters = {
					new SqlParameter("@NewType", SqlDbType.BigInt),
                    new SqlParameter("@New01", SqlDbType.BigInt)
};
            parameters[0].Value = typeId;
            parameters[1].Value = langType;

            lgk.Model.tb_news model = new lgk.Model.tb_news();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NewsTitle"] != null && ds.Tables[0].Rows[0]["NewsTitle"].ToString() != "")
                {
                    model.NewsTitle = ds.Tables[0].Rows[0]["NewsTitle"].ToString();
                }
                if (ds.Tables[0].Rows[0]["NewsContent"] != null && ds.Tables[0].Rows[0]["NewsContent"].ToString() != "")
                {
                    model.NewsContent = ds.Tables[0].Rows[0]["NewsContent"].ToString();
                }
                if (ds.Tables[0].Rows[0]["NewsType"] != null && ds.Tables[0].Rows[0]["NewsType"].ToString() != "")
                {
                    model.NewsType = int.Parse(ds.Tables[0].Rows[0]["NewsType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PublishTime"] != null && ds.Tables[0].Rows[0]["PublishTime"].ToString() != "")
                {
                    model.PublishTime = DateTime.Parse(ds.Tables[0].Rows[0]["PublishTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Publisher"] != null && ds.Tables[0].Rows[0]["Publisher"].ToString() != "")
                {
                    model.Publisher = ds.Tables[0].Rows[0]["Publisher"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ImageURL"] != null && ds.Tables[0].Rows[0]["ImageURL"].ToString() != "")
                {
                    model.ImageURL = ds.Tables[0].Rows[0]["ImageURL"].ToString();
                }
                if (ds.Tables[0].Rows[0]["NewType"] != null && ds.Tables[0].Rows[0]["NewType"].ToString() != "")
                {
                    model.NewType = int.Parse(ds.Tables[0].Rows[0]["NewType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Classify"] != null && ds.Tables[0].Rows[0]["Classify"].ToString() != "")
                {
                    model.Classify = ds.Tables[0].Rows[0]["Classify"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Tags"] != null && ds.Tables[0].Rows[0]["Tags"].ToString() != "")
                {
                    model.Tags = ds.Tables[0].Rows[0]["Tags"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Click"] != null && ds.Tables[0].Rows[0]["Click"].ToString() != "")
                {
                    model.Click = int.Parse(ds.Tables[0].Rows[0]["Click"].ToString());
                }
                if (ds.Tables[0].Rows[0]["New01"] != null && ds.Tables[0].Rows[0]["New01"].ToString() != "")
                {
                    model.New01 = int.Parse(ds.Tables[0].Rows[0]["New01"].ToString());
                }
                if (ds.Tables[0].Rows[0]["New02"] != null && ds.Tables[0].Rows[0]["New02"].ToString() != "")
                {
                    model.New02 = int.Parse(ds.Tables[0].Rows[0]["New02"].ToString());
                }
                if (ds.Tables[0].Rows[0]["New03"] != null && ds.Tables[0].Rows[0]["New03"].ToString() != "")
                {
                    model.New03 = decimal.Parse(ds.Tables[0].Rows[0]["New03"].ToString());
                }
                if (ds.Tables[0].Rows[0]["New04"] != null && ds.Tables[0].Rows[0]["New04"].ToString() != "")
                {
                    model.New04 = decimal.Parse(ds.Tables[0].Rows[0]["New04"].ToString());
                }
                if (ds.Tables[0].Rows[0]["New05"] != null && ds.Tables[0].Rows[0]["New05"].ToString() != "")
                {
                    model.New05 = ds.Tables[0].Rows[0]["New05"].ToString();
                }
                if (ds.Tables[0].Rows[0]["New06"] != null && ds.Tables[0].Rows[0]["New06"].ToString() != "")
                {
                    model.New06 = ds.Tables[0].Rows[0]["New06"].ToString();
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
			strSql.Append("select ROW_NUMBER() OVER( ORDER BY PublishTime desc) AS XH,ID,NewsTitle,NewsContent,NewsType,PublishTime,Publisher,ImageURL,NewType,Classify,Tags,Click,New01,New02,New03,New04,New05,New06 ");
			strSql.Append(" FROM tb_news ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" order by  PublishTime desc");
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
			strSql.Append(" ID,NewsTitle,NewsContent,NewsType,PublishTime,Publisher,ImageURL,NewType,Classify,Tags,Click,New01,New02,New03,New04,New05,New06 ");
			strSql.Append(" FROM tb_news ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}
        /// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList_Rank(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append("   c.* from (select ROW_NUMBER()OVER(ORDER BY Total_Suanli desc)RankID,b.* from (select u.NiceName Name ,IsNull(a.RandMoney,0) Jine ,u.UserID, u.User004 as Kuangji, u.User012 as Total_Suanli from tb_user as u left join (select UserID,SUM(RandMoney) RandMoney  from tb_Rand where Flag=2 group by UserID) a on u.UserID=a.UserID) as b) as c order by c.RankID ");
           
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
			parameters[0].Value = "tb_news";
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

