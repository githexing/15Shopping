using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using DataAccess;

namespace lgk.DAL  
{
	 	//tb_BonusPoly
		public partial class tb_BonusPoly
	{

        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_BonusPoly ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.BigInt)
            };
            parameters[0].Value = ID;
            
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(lgk.Model.tb_BonusPoly model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_BonusPoly(");			
            strSql.Append("SettleTime,TaskCompletedFlag,TaskCompletedTime,UserID,InvestOrderID,Bonus,ShareDay,ShareDate,ShowDate,Flag");
			strSql.Append(") values (");
            strSql.Append("@SettleTime,@TaskCompletedFlag,@TaskCompletedTime,@UserID,@InvestOrderID,@Bonus,@ShareDay,@ShareDate,@ShowDate,@Flag");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@SettleTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@TaskCompletedFlag", SqlDbType.Int,4) ,            
                        new SqlParameter("@TaskCompletedTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@UserID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@InvestOrderID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Bonus", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@ShareDay", SqlDbType.Int,4) ,            
                        new SqlParameter("@ShareDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@ShowDate", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@Flag", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.SettleTime;                        
            parameters[1].Value = model.TaskCompletedFlag;                        
            parameters[2].Value = model.TaskCompletedTime;                        
            parameters[3].Value = model.UserID;                        
            parameters[4].Value = model.InvestOrderID;                        
            parameters[5].Value = model.Bonus;                        
            parameters[6].Value = model.ShareDay;                        
            parameters[7].Value = model.ShareDate;                        
            parameters[8].Value = model.ShowDate;                        
            parameters[9].Value = model.Flag;                        
			   
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
		public bool Update(lgk.Model.tb_BonusPoly model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_BonusPoly set ");
			                                                
            strSql.Append(" SettleTime = @SettleTime , ");                                    
            strSql.Append(" TaskCompletedFlag = @TaskCompletedFlag , ");                                    
            strSql.Append(" TaskCompletedTime = @TaskCompletedTime , ");                                    
            strSql.Append(" UserID = @UserID , ");                                    
            strSql.Append(" InvestOrderID = @InvestOrderID , ");                                    
            strSql.Append(" Bonus = @Bonus , ");                                    
            strSql.Append(" ShareDay = @ShareDay , ");                                    
            strSql.Append(" ShareDate = @ShareDate , ");                                    
            strSql.Append(" ShowDate = @ShowDate , ");                                    
            strSql.Append(" Flag = @Flag  ");            			
			strSql.Append(" where ID=@ID ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@SettleTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@TaskCompletedFlag", SqlDbType.Int,4) ,            
                        new SqlParameter("@TaskCompletedTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@UserID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@InvestOrderID", SqlDbType.BigInt,8) ,            
                        new SqlParameter("@Bonus", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@ShareDay", SqlDbType.Int,4) ,            
                        new SqlParameter("@ShareDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@ShowDate", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@Flag", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.ID;                        
            parameters[1].Value = model.SettleTime;                        
            parameters[2].Value = model.TaskCompletedFlag;                        
            parameters[3].Value = model.TaskCompletedTime;                        
            parameters[4].Value = model.UserID;                        
            parameters[5].Value = model.InvestOrderID;                        
            parameters[6].Value = model.Bonus;                        
            parameters[7].Value = model.ShareDay;                        
            parameters[8].Value = model.ShareDate;                        
            parameters[9].Value = model.ShowDate;                        
            parameters[10].Value = model.Flag;                        
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
			strSql.Append("delete from tb_BonusPoly ");
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
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_BonusPoly ");
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
		public lgk.Model.tb_BonusPoly GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID, SettleTime, TaskCompletedFlag, TaskCompletedTime, UserID, InvestOrderID, Bonus, ShareDay, ShareDate, ShowDate, Flag  ");			
			strSql.Append("  from tb_BonusPoly ");
			strSql.Append(" where ID=@ID");
						SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
			parameters[0].Value = ID;

			
			lgk.Model.tb_BonusPoly model=new lgk.Model.tb_BonusPoly();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["SettleTime"].ToString()!="")
				{
					model.SettleTime=DateTime.Parse(ds.Tables[0].Rows[0]["SettleTime"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["TaskCompletedFlag"].ToString()!="")
				{
					model.TaskCompletedFlag=int.Parse(ds.Tables[0].Rows[0]["TaskCompletedFlag"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["TaskCompletedTime"].ToString()!="")
				{
					model.TaskCompletedTime=DateTime.Parse(ds.Tables[0].Rows[0]["TaskCompletedTime"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["UserID"].ToString()!="")
				{
					model.UserID=long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["InvestOrderID"].ToString()!="")
				{
					model.InvestOrderID=long.Parse(ds.Tables[0].Rows[0]["InvestOrderID"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["Bonus"].ToString()!="")
				{
					model.Bonus=decimal.Parse(ds.Tables[0].Rows[0]["Bonus"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["ShareDay"].ToString()!="")
				{
					model.ShareDay=int.Parse(ds.Tables[0].Rows[0]["ShareDay"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["ShareDate"].ToString()!="")
				{
					model.ShareDate=DateTime.Parse(ds.Tables[0].Rows[0]["ShareDate"].ToString());
				}
																																				model.ShowDate= ds.Tables[0].Rows[0]["ShowDate"].ToString();
																												if(ds.Tables[0].Rows[0]["Flag"].ToString()!="")
				{
					model.Flag=int.Parse(ds.Tables[0].Rows[0]["Flag"].ToString());
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
			strSql.Append("select * ");
			strSql.Append(" FROM tb_BonusPoly ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			strSql.Append(" * ");
			strSql.Append(" FROM tb_BonusPoly ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

