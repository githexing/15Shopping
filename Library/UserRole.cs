using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

namespace Library
{
    /// <summary>
    /// GetUserRole 的摘要说明
    /// </summary>
    public class UserRole
    {
        public UserRole()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        private static readonly string conn = System.Configuration.ConfigurationManager.AppSettings["SocutDataLink"].ToString();
        public static bool GetRole(Hashtable UroleList, int PageRole)
        {
            return UroleList.ContainsKey(PageRole);
        }
        public static int GetUserID(string UserName)
        {
            using (SqlConnection scn = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    SqlParameter sp = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
                    sp.Value = UserName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetUserID";
                    cmd.Connection = scn;
                    cmd.Parameters.Add(sp);
                    cmd.Connection.Open();
                    object obj = cmd.ExecuteScalar();
                    cmd.Connection.Close();
                    return obj == null ? 0 : int.Parse(obj.ToString());
                }
            }
        }
        public static int GetManageID(string UserName)
        {
            using (SqlConnection scn = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    SqlParameter sp = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
                    sp.Value = UserName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetManageID";
                    cmd.Connection = scn;
                    cmd.Parameters.Add(sp);
                    cmd.Connection.Open();
                    object obj = cmd.ExecuteScalar();
                    cmd.Connection.Close();
                    return obj == null ? 0 : int.Parse(obj.ToString());
                }
            }
        }
        public static Hashtable UroleList(int UserID, int UserType)
        {
            Hashtable htable = new Hashtable();
            using (SqlConnection scn = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    SqlParameter sp = new SqlParameter("@UserID", SqlDbType.Int, 4);
                    SqlParameter sp2 = new SqlParameter("@UserType", SqlDbType.Int, 4);
                    sp.Value = UserID;
                    sp2.Value = UserType;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "UroleList";
                    cmd.Connection = scn;
                    cmd.Parameters.Add(sp);
                    cmd.Parameters.Add(sp2);
                    cmd.Connection.Open();
                    object obj = cmd.ExecuteScalar();
                    cmd.Connection.Close();
                    if (obj != null)
                    {
                        string[] ss = obj.ToString().Split(',');
                        foreach (string s in ss)
                        {
                            if (!htable.Contains(int.Parse(s)))
                            {
                                htable.Add(int.Parse(s), string.Empty);
                            }
                        }
                    }
                }
            }
            return htable;
        }

        public static void ErrorRecord(string err1, string err2, string err3)
        {
            using (SqlConnection scn = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    SqlParameter e1 = new SqlParameter("@ErrPageState02", SqlDbType.NVarChar, 300);
                    SqlParameter e2 = new SqlParameter("@ErrPageState03", SqlDbType.NVarChar, 300);
                    SqlParameter e3 = new SqlParameter("@ErrPageState04", SqlDbType.NVarChar, 300);
                    e1.Value = err1;
                    e2.Value = err2;
                    e3.Value = err3;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SetERR";
                    cmd.Connection = scn;
                    cmd.Parameters.Add(e1);
                    cmd.Parameters.Add(e2);
                    cmd.Parameters.Add(e3);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
        }
    }
}
