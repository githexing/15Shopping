/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-4-19 10:52:06 
 * 文 件 名：		gp_operation.cs 
 * CLR 版本: 		2.0.50727.3053 
 * 创 建 人：		King
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 备注描述：         
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DataAccess;
using System.Data;

namespace lgk.DAL
{
    public class gp_operation
    {
        /// <summary>
        /// 更新股票发行量
        /// </summary>
        /// <param name="id">发行量ID</param>
        /// <param name="money">股票数</param>
        /// <param name="where">0-减少 1-增加</param>
        /// <returns></returns>
        public int UpdateSurplusAmount(int id, decimal money, int where)
        {
            string sql = "";

            if (where == 0)
            {
                sql = "update gp_StockIssue set SurplusAmount=SurplusAmount-" + money + " where  ID=" + id;
            }
            else
            {
                sql = "update gp_StockIssue set SurplusAmount=SurplusAmount+" + money + " where  ID=" + id;
            }
            return DbHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 拆股前(返还待卖出股数)
        /// </summary>
        /// <returns></returns>
        public int chaigu()
        {
            return Convert.ToInt32(DbHelperSQL.GetSingle("exec gp_cg_hanhuan"));
        }
        /// <summary>
        ///判断是否进入贡献仓
        /// </summary>
        /// <returns></returns>
        public int gxc()
        {
            return Convert.ToInt32(DbHelperSQL.GetSingle("exec gp_gxc"));
        }
        /// <summary>
        /// 拆股
        /// </summary>
        /// <param name="open_money">开盘价</param>
        /// <param name="cg_rate">拆分比率</param>
        /// <returns></returns>
        public int chaigu(decimal open_money, decimal cg_rate)
        {
            int result;
            string prop = "gp_cg_Split";
            SqlParameter[] para = { new SqlParameter("@open_money", SqlDbType.Decimal),
                                   new SqlParameter("@cg_rate", SqlDbType.Decimal)};
            para[0].Value = open_money;
            para[1].Value = cg_rate;
            DbHelperSQL.RunProcedure(prop, para, out result);
            return result;
        }
        /// <summary>
        /// 强制回购会员股票或贡献仓
        /// </summary>
        /// <param name="userid">会员ID</param>
        /// <param name="zh_type">1-股票 2-贡献仓</param>
        /// <param name="amount">交易价格</param>
        /// <returns></returns>
        public int flag_HuiGou(int userid, int zh_type, decimal amount)
        {
            int result;
            string prop = "gp_HuiGou";
            SqlParameter[] para = { new SqlParameter("@userid", SqlDbType.Int),
                                   new SqlParameter("@zh_type", SqlDbType.Int),
                                   new SqlParameter("@amount", SqlDbType.Decimal)};
            para[0].Value = userid;
            para[1].Value = zh_type;
            para[2].Value = amount;
            DbHelperSQL.RunProcedure(prop, para, out result);
            return result;
        }
        /// <summary>
        /// 回购全部
        /// </summary>
        /// <returns></returns>
        public int flag_HuiGou(decimal amount)
        {
            int result;
            string prop = "gp_HuiGouALL";
            SqlParameter[] para = { 
                                   new SqlParameter("@amount", SqlDbType.Decimal)};
            para[0].Value = amount;
            DbHelperSQL.RunProcedure(prop, para, out result);
            return result;
            //return Convert.ToInt32(DbHelperSQL.GetSingle("exec gp_HuiGouALL"));
        }
        /// <summary>
        /// 后台管理员买股
        /// </summary>
        /// <param name="num"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int A_SaleIn(int num, decimal amount)
        {
            int result;
            string prop = "gp_a_NewSalein";
            SqlParameter[] para = { 
                new SqlParameter ("@num",SqlDbType.Int ),
                new SqlParameter ("@amount",SqlDbType.Decimal ) };
            para[0].Value = num;
            para[1].Value = amount;
            DbHelperSQL.RunProcedure(prop, para, out result);
            return result;
        }

        /// <summary>
        /// 后台管理员卖股
        /// </summary>
        /// <param name="num"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int A_SaleOut(int num, decimal amount)
        {
            int result;
            string prop = "gp_a_Newsaleout";
            SqlParameter[] para = { 
                new SqlParameter ("@num",SqlDbType.Int ),
                new SqlParameter ("@amount",SqlDbType.Decimal ) };
            para[0].Value = num;
            para[1].Value = amount;
            DbHelperSQL.RunProcedure(prop, para, out result);
            return result;
        }
        /// <summary>
        /// 前台会员卖股
        /// </summary>
        /// <param name="num"></param>
        /// <param name="amount"></param>
        /// <param name="ucode"></param>
        /// <returns></returns>
        public bool U_MaiGu(int num, decimal amount, long uid, string ucode, int zh_type)
        {
            SqlParameter[] sqlPar = new SqlParameter[]
            {
                new SqlParameter ("@num",num ),
                new SqlParameter ("@amount",amount ),
                new SqlParameter ("@userid",uid ),
                new SqlParameter ("@usercode",ucode ),
                new SqlParameter ("@zh_type",zh_type ),
            };
            //return SqlHelper.ExecuteNonQuery(SqlHelper.connStrs, CommandType.StoredProcedure, "gp_u_saleout", sqlPar) > 0;
            return SqlHelper.ExecuteNonQuery(SqlHelper.connStrs, CommandType.StoredProcedure, "gp_u_Newsaleout", sqlPar) > 0;
        }

        /// <summary>
        /// 前台会员买股
        /// </summary>
        /// <param name="num"></param>
        /// <param name="amount"></param>
        /// <param name="ucode"></param>
        /// <returns></returns>
        public bool U_MaiGuOut(int num, decimal amount, long uid, string ucode)
        {
            SqlParameter[] sqlPar = new SqlParameter[]
            {
                new SqlParameter ("@num",num ),
                new SqlParameter ("@amount",amount ),
                new SqlParameter ("@userid",uid ),
                new SqlParameter ("@usercode",ucode )
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.connStrs, CommandType.StoredProcedure, "gp_u_Newsalein", sqlPar) > 0;
        }
        /// <summary>
        /// 行情图
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDtForPic(int num)
        {
            string sqlnum = "select count(*) from gp_StockPrice";
            int i = Convert.ToInt32(DbHelperSQL.GetSingle(sqlnum));
            if (i < num)
            {
                num = i;
            }
            string sql = "select top " + num + " p.OpenMoney,convert(nvarchar(10),p.BusinessTime,120) as DayTime,a.BusinessAmount  from gp_StockPrice as p join dbo.gp_BusinessAmount as a on convert(nvarchar(10),p.BusinessTime,120)=convert(nvarchar(10),a.BusinessTime,120) where convert(nvarchar(10),p.BusinessTime,120)<=convert(nvarchar(10),getdate(),120) order by convert(nvarchar(10),p.BusinessTime,120) desc";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 当天价格、成交量图
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetPic(int num)
        {
            string sqlnum = "select count(*) from gp_BusinessNotes where BusinessType=1 and Status=2";
            int i = Convert.ToInt32(DbHelperSQL.GetSingle(sqlnum));
            if (i < num)
            {
                num = i;
            }
            string sql = "select top " + num + " SucTime,BusinessPrice,BusinessAmount from gp_BusinessNotes where BusinessType=1 and Status=2 and convert(nvarchar(10),SucTime,120)=convert(nvarchar(10),getdate(),120) order by convert(nvarchar(10),SucTime,120) desc";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 查出数据库中是否存在今天的记录
        /// </summary>
        /// <returns></returns>
        public bool IsHasPrice()
        {
            //string sql = "select count(*) from gp_stockprice where convert(varchar(10),businesstime,120) = convert(varchar(10),getdate(),120)";
            string sql = "select count(*) from gp_BusinessNotes where BusinessType=1 and Status=2 and convert(varchar(10),SucTime,120) = convert(varchar(10),getdate(),120)";
            int i = Convert.ToInt32(DbHelperSQL.GetSingle(sql));
            return i > 0 ? true : false;
        }
        /// <summary>
        /// 查出最后发不价格的时间
        /// </summary>
        /// <returns></returns>
        public int Enbtn()
        {
            string sql = "select count(*) from gp_StockPrice where convert(nvarchar(10),BusinessTime,120)=convert(nvarchar(10),getdate(),120)";
            return Convert.ToInt32(DbHelperSQL.GetSingle(sql));
        }

        public void ExecProc(string procName)
        {
            DbHelperSQL.GetSingle("exec " + procName);
        }
    }
}
