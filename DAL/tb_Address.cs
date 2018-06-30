using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;//Please add references

namespace lgk.DAL
{
    public partial class tb_Address
    {
        public tb_Address()
		{}
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "tb_Address");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Address");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_Address model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Address(");
            strSql.Append("UserID,TypeID,AreaInProvince,AreaInCity,Address,PostCode,MemberName,PhoneNum,Phone,Mail,Remark,Address01,Address02,Address03,Address04)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@TypeID,@AreaInProvince,@AreaInCity,@Address,@PostCode,@MemberName,@PhoneNum,@Phone,@Mail,@Remark,@Address01,@Address02,@Address03,@Address04)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@AreaInProvince", SqlDbType.VarChar,50),
					new SqlParameter("@AreaInCity", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,50),
					new SqlParameter("@PostCode", SqlDbType.VarChar,50),
                    new SqlParameter("@MemberName", SqlDbType.VarChar,50),
                    new SqlParameter("@PhoneNum", SqlDbType.VarChar,50),
                    new SqlParameter("@Phone", SqlDbType.VarChar,50),
                    new SqlParameter("@Mail", SqlDbType.VarChar,50),
                    new SqlParameter("@Remark", SqlDbType.VarChar,500),
                    new SqlParameter("@Address01", SqlDbType.VarChar,100),
                    new SqlParameter("@Address02", SqlDbType.VarChar,100),
                    new SqlParameter("@Address03", SqlDbType.VarChar,100),
					new SqlParameter("@Address04", SqlDbType.VarChar,100)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.TypeID;
            parameters[2].Value = model.AreaInProvince;
            parameters[3].Value = model.AreaInCity;
            parameters[4].Value = model.Address;
            parameters[5].Value = model.PostCode;
            parameters[6].Value = model.MemberName;
            parameters[7].Value = model.PhoneNum;
            parameters[8].Value = model.Phone;
            parameters[9].Value = model.Mail;
            parameters[10].Value = model.Remark;
            parameters[11].Value = model.Address01;
            parameters[12].Value = model.Address02;
            parameters[13].Value = model.Address03;
            parameters[14].Value = model.Address04;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(lgk.Model.tb_Address model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Address set ");
            strSql.Append("UserID=@UserID,");
            strSql.Append("TypeID=@TypeID,");
            strSql.Append("AreaInProvince=@AreaInProvince,");
            strSql.Append("AreaInCity=@AreaInCity,");
            strSql.Append("Address=@Address,");
            strSql.Append("PostCode=@PostCode,");
            strSql.Append("MemberName=@MemberName,");
            strSql.Append("PhoneNum=@PhoneNum,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("Mail=@Mail,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Address01=@Address01,");
            strSql.Append("Address02=@Address02,");
            strSql.Append("Address03=@Address03,");
            strSql.Append("Address04=@Address04 ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@AreaInProvince", SqlDbType.VarChar,50),
					new SqlParameter("@AreaInCity", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,50),
					new SqlParameter("@PostCode", SqlDbType.VarChar,50),
                    new SqlParameter("@MemberName", SqlDbType.VarChar,50),
                    new SqlParameter("@PhoneNum", SqlDbType.VarChar,50),
                    new SqlParameter("@Phone", SqlDbType.VarChar,50),
                    new SqlParameter("@Mail", SqlDbType.VarChar,50),
                    new SqlParameter("@Remark", SqlDbType.VarChar,50),
                    new SqlParameter("@Address01", SqlDbType.VarChar,50),
                    new SqlParameter("@Address02", SqlDbType.VarChar,50),
                    new SqlParameter("@Address03", SqlDbType.VarChar,50),
					new SqlParameter("@Address04", SqlDbType.VarChar,50),
                    new SqlParameter("@ID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.TypeID;
            parameters[2].Value = model.AreaInProvince;
            parameters[3].Value = model.AreaInCity;
            parameters[4].Value = model.Address;
            parameters[5].Value = model.PostCode;
            parameters[6].Value = model.MemberName;
            parameters[7].Value = model.PhoneNum;
            parameters[8].Value = model.Phone;
            parameters[9].Value = model.Mail;
            parameters[10].Value = model.Remark;
            parameters[11].Value = model.Address01;
            parameters[12].Value = model.Address02;
            parameters[13].Value = model.Address03;
            parameters[14].Value = model.Address04;
            parameters[15].Value = model.ID;

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
        public bool Delete(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Address ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
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
        /// 设置默认地址
        /// </summary>
        public bool SetDefault(long iUserID, long iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Address set Address01='0' where UserID=@UserID; update tb_Address set Address01='1' where UserID=@UserID and ID=@ID;");
            SqlParameter[] parameters = {
					new SqlParameter("@userID", SqlDbType.BigInt,8),
                    new SqlParameter("@ID", SqlDbType.BigInt,8)};
            parameters[0].Value = iUserID;
            parameters[1].Value = iID;

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
        /// 设置默认地址
        /// </summary>
        public bool SetDefault(long iUserID, string strAddress01)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Address set Address01=@Address01 where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
                    new SqlParameter("@Address01", SqlDbType.VarChar,100)};
            parameters[0].Value = iUserID;
            parameters[1].Value = strAddress01;

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
            strSql.Append("delete from tb_Address ");
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
        public lgk.Model.tb_Address GetModel(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from tb_Address");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
            parameters[0].Value = ID;

            lgk.Model.tb_Address model = new lgk.Model.tb_Address();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TypeID"] != null && ds.Tables[0].Rows[0]["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(ds.Tables[0].Rows[0]["TypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AreaInProvince"] != null && ds.Tables[0].Rows[0]["AreaInProvince"].ToString() != "")
                {
                    model.AreaInProvince = ds.Tables[0].Rows[0]["AreaInProvince"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Address"] != null && ds.Tables[0].Rows[0]["Address"].ToString() != "")
                {
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AreaInCity"] != null && ds.Tables[0].Rows[0]["AreaInCity"].ToString() != "")
                {
                    model.AreaInCity = ds.Tables[0].Rows[0]["AreaInCity"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PostCode"] != null && ds.Tables[0].Rows[0]["PostCode"].ToString() != "")
                {
                    model.PostCode = ds.Tables[0].Rows[0]["PostCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["MemberName"] != null && ds.Tables[0].Rows[0]["MemberName"].ToString() != "")
                {
                    model.MemberName = ds.Tables[0].Rows[0]["MemberName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PhoneNum"] != null && ds.Tables[0].Rows[0]["PhoneNum"].ToString() != "")
                {
                    model.PhoneNum = ds.Tables[0].Rows[0]["PhoneNum"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Phone"] != null && ds.Tables[0].Rows[0]["Phone"].ToString() != "")
                {
                    model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Mail"] != null && ds.Tables[0].Rows[0]["Mail"].ToString() != "")
                {
                    model.Mail = ds.Tables[0].Rows[0]["Mail"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null && ds.Tables[0].Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Address01"] != null && ds.Tables[0].Rows[0]["Address01"].ToString() != "")
                {
                    model.Address01 = ds.Tables[0].Rows[0]["Address01"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Address02"] != null && ds.Tables[0].Rows[0]["Address02"].ToString() != "")
                {
                    model.Address02 = ds.Tables[0].Rows[0]["Address02"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Address03"] != null && ds.Tables[0].Rows[0]["Address03"].ToString() != "")
                {
                    model.Address03 = ds.Tables[0].Rows[0]["Address03"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Address04"] != null && ds.Tables[0].Rows[0]["Address04"].ToString() != "")
                {
                    model.Address04 = ds.Tables[0].Rows[0]["Address04"].ToString();
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
            strSql.Append("select * FROM tb_Address ");
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
            strSql.Append(" * FROM tb_Address");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public long GetAddressID(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ID from tb_Address ");
            strSql.Append(" where " + strWhere);
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return Convert.ToInt64(obj);
            }
            else
            {
                return 0;
            }
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
            parameters[0].Value = "tb_admin";
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
