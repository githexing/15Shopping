/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-2-6 10:08:30 
 * 文 件 名：		SecondPws.cs 
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
    public class SecondPws
    {
        public int findpws(string SecondPassword, int ID)
        {
            string sqlstr = "select count(*) from tb_admin where SecondPassword=@SecondPassword and ID=@ID";
            SqlParameter[] p = new SqlParameter[]{
                             new SqlParameter("@SecondPassword",SqlDbType.VarChar,50),
                             new SqlParameter("@ID",SqlDbType.Int)};
            p[0].Value = SecondPassword;
            p[1].Value = ID;//78601782
            int re = Convert.ToInt32(DbHelperSQL.GetSingle(sqlstr, p));
            return re;
        }
        /// <summary>
        /// 验证管理员三级密码
        /// </summary>
        /// <param name="admin06">admin06</param>
        /// <param name="admin01">admin01</param>
        /// <returns></returns>
        public int findpws_admin1(string ThirdPassword, int ID)
        {
            string sqlstr = "select count(*) from tb_admin where ThirdPassword=@ThirdPassword and ID=@ID";
            SqlParameter[] p = new SqlParameter[]{
                             new SqlParameter("@ThirdPassword",SqlDbType.VarChar,200 ),
                             new SqlParameter("@ID",SqlDbType.NVarChar,50)};
            p[0].Value = ThirdPassword;
            p[1].Value = ID;//78601782
            int re = Convert.ToInt32(DbHelperSQL.GetSingle(sqlstr, p));
            return re;
        }

        /// <summary>
        /// 验证管理员高级密码的 
        /// </summary>
        /// <param name="admin06">admin06</param>
        /// <param name="admin01">admin01</param>
        /// <returns></returns>
        public int findpws_admin(string SecondPassword, int ID)
        {
            string sqlstr = "select count(*) from tb_admin where SecondPassword=@SecondPassword and ID=@ID";
            SqlParameter[] p = new SqlParameter[]{
                             new SqlParameter("@SecondPassword",SqlDbType.VarChar,200 ),
                             new SqlParameter("@ID",SqlDbType.NVarChar,50)};
            p[0].Value = SecondPassword;
            p[1].Value = ID;//78601782
            int re = Convert.ToInt32(DbHelperSQL.GetSingle(sqlstr, p));
            return re;
        }

        /// <summary>
        /// 用用户名验证管理员高级密码的 
        /// </summary>
        /// <param name="admin06">admin06</param>
        /// <param name="admin01">admin01</param>
        /// <returns></returns>
        public int findpws_admin(string SecondPassword, string username)
        {
            string sqlstr = "select count(*) from tb_admin where SecondPassword=@SecondPassword and username=@username";
            SqlParameter[] p = new SqlParameter[]{
                             new SqlParameter("@SecondPassword",SqlDbType.NVarChar,50 ),
                             new SqlParameter("@username",SqlDbType.NVarChar,50)};
            p[0].Value = SecondPassword;
            p[1].Value = username;//78601782
            int re = Convert.ToInt32(DbHelperSQL.GetSingle(sqlstr, p));
            return re;
        }

        /// <summary>
        /// 查询管理员三级密码
        /// </summary>
        /// <param name="pws"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int findpws1(string ThirdPassword, string username)
        {
            string sqlstr = "select count(*) from tb_admin where User005=@ThirdPassword and username=@username";
            SqlParameter[] p = new SqlParameter[]{
                             new SqlParameter("@ThirdPassword",SqlDbType.NVarChar,50 ),
                             new SqlParameter("@username",SqlDbType.NVarChar,50)};
            p[0].Value = ThirdPassword;
            p[1].Value = username;//78601782
            int re = Convert.ToInt32(DbHelperSQL.GetSingle(sqlstr, p));
            return re;
        }

        /// <summary>
        /// 查询二级密码 用的userid
        /// 
        /// </summary>
        /// <param name="pws"></param>
        /// <param name="type"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int findpws(string SecondPassword, int type, long UserID)
        {
            string sqlstr = "select count(*) from tb_user where SecondPassword=@pwd and UserID=@UserID";
            SqlParameter[] p = new SqlParameter[]{
                             new SqlParameter("@UserID",SqlDbType.BigInt,8),
                             new SqlParameter("@pwd",SqlDbType.VarChar,50)};
            p[0].Value = UserID;
            p[1].Value = SecondPassword;//78601782
            int re = Convert.ToInt32(DbHelperSQL.GetSingle(sqlstr, p));
            return re;
        }
        /// <summary>
        /// 查询三级密码 用的code
        /// </summary>
        /// <param name="pws"></param>
        /// <param name="type"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int findpwsCount(string strPwd, int type, long iUserID)
        {
            string sqlstr = "select count(*) from tb_user where ThreePassword=@pwd and UserID=@UserID";
            SqlParameter[] p = new SqlParameter[]{
                             new SqlParameter("@UserID",SqlDbType.Int ),
                             new SqlParameter("@pwd",SqlDbType.VarChar,50)};
            p[0].Value = iUserID;
            p[1].Value = strPwd;//78601782
            int re = Convert.ToInt32(DbHelperSQL.GetSingle(sqlstr, p));
            return re;
        }
        /// <summary>
        /// 查询二级密码  用的code
        /// </summary>
        /// <param name="pws"></param>
        /// <param name="type"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int findpws(string pws, int type, string ubh)
        {
            string sqlstr = "select count(*) from tb_user where SecondPassword=@psw and usercode=@ubh";
            SqlParameter[] p = new SqlParameter[]{
                             new SqlParameter("@ubh",SqlDbType.VarChar,50),
                             new SqlParameter("@psw",SqlDbType.VarChar,50)};
            p[0].Value = ubh;
            p[1].Value = pws;//78601782
            int re = Convert.ToInt32(DbHelperSQL.GetSingle(sqlstr, p));
            return re;
        }
        /// <summary>
        /// 这个应该是查询高级密码是否开启，暂封
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool sfpws(int type)
        {
            //string sqlstr = "select sencondp03 from sencondp where sencondp01=@type";
            //SqlParameter[] p = new SqlParameter[]{
            //                 new SqlParameter("@type",SqlDbType.Int )};
            //p[0].Value = type;
            //int re = Convert.ToInt32(DbHelperSQL.GetSingle(sqlstr, p));
            //if (re > 0)
            //{
            return true;
            //}
            //return false;
        }
        /// <summary>
        /// 更改二级密码        根据Id更新管理员的二级密码
        /// </summary>
        /// <param name="pws"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool uppws(string pws, int type)
        {
            string str = "update tb_admin set SecondPassword=@admin06 where id=@admin01";
            SqlParameter[] p = new SqlParameter[]{
                             new SqlParameter("@admin01",SqlDbType.Int ),
                             new SqlParameter("@admin06",SqlDbType.VarChar,50)};
            p[0].Value = type;
            p[1].Value = pws;//78601782
            if (DbHelperSQL.ExecuteSql(str, p) > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 开启关闭二级密码   //暂封
        /// </summary>
        /// <param name="c"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool openclosepws(int c, int type)
        {
            string str = "update SencondP set SencondP03=@c where SencondP01=@type";
            SqlParameter[] p = new SqlParameter[]{
                             new SqlParameter("@type",SqlDbType.Int ),
                             new SqlParameter("@c",SqlDbType.Int)};
            p[0].Value = type;
            p[1].Value = c;//78601782
            if (DbHelperSQL.ExecuteSql(str, p) > 0)
            {
                return true;
            }
            return false;
        }
    }
}
