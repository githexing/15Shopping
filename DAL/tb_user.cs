using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using DataAccess;

namespace lgk.DAL
{
    /// <summary>
    /// 数据访问类:tb_user
    /// </summary>
    public partial class tb_user
    {
        /// <summary>
        /// 全局变量
        /// </summary>
        string strSunID = "";

        /// <summary>
        /// 全局变量
        /// </summary>
        string strRecommendID = "";

        public tb_user()
        { }
        #region  Method

        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_user");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt)};
            parameters[0].Value = UserID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion

        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="strUserCode"></param>
        /// <returns></returns>
        public bool Exists(string strUserCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM tb_user");
            strSql.Append(" WHERE UserCode=@UserCode");
            SqlParameter[] parameters = {
					new SqlParameter("@UserCode", SqlDbType.VarChar,20)};
            parameters[0].Value = strUserCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion

        #region 是否有子会员
        /// <summary>
        /// 是否有子会员
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool HasChildren(long userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_user");
            strSql.Append(" where parentID=@parentID");
            SqlParameter[] parameters = {
					new SqlParameter("@parentID", SqlDbType.BigInt)};
            parameters[0].Value = userID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion

        #region 判断给定的用户是否为报单中心
        /// <summary>
        /// 判断给定的用户是否为报单中心
        /// </summary>
        /// <param name="iUserID"></param>
        /// <returns></returns>
        public bool IsAgent(long iUserID)
        {
            int iIsAgent = 0;
            bool bFlag = false;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [IsAgent] FROM tb_user");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = iUserID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                iIsAgent = 0;
            }
            else
            {
                iIsAgent = int.Parse(obj.ToString());
            }

            if (iIsAgent == 0)
                bFlag = false;
            else
                bFlag = true;

            return bFlag;
        }
        #endregion

        #region 根据给定的用户ID，获取用户编号。
        /// <summary>
        /// 根据给定的用户ID，获取用户编号。
        /// </summary>
        /// <param name="iUserID">给定的用户ID</param>
        /// <returns></returns>
        public string GetUserCode(long iUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [UserCode] FROM tb_user");
            strSql.Append(" WHERE UserID=@UserID");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = iUserID;

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
        #endregion

        #region 根据给定额用户编号，获取用户ID
        /// <summary>
        /// 根据给定额用户编号，获取用户ID
        /// </summary>
        /// <param name="strUserCode">给定额用户编号</param>
        /// <returns></returns>
        public long GetUserID(string strUserCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [UserID] FROM tb_user");
            strSql.Append(" WHERE UserCode=@UserCode");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserCode", SqlDbType.VarChar,20)};
            parameters[0].Value = strUserCode;

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
        #endregion

        #region 根据给定手机号码，获取用户ID
        /// <summary>
        /// 根据给定手机号码，获取用户ID
        /// </summary>
        /// <param name="strUserCode"></param>
        /// <returns></returns>
        public long GetUserIDByPhoneNum(string PhoneNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [UserID] FROM tb_user");
            strSql.Append(" WHERE PhoneNum=@PhoneNum");
            SqlParameter[] parameters = {
                    new SqlParameter("@PhoneNum", SqlDbType.VarChar,50)};
            parameters[0].Value = PhoneNum;

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
        #endregion

        /// <summary>
        /// 获取给定会员ID的注册币。
        /// </summary>
        /// <param name="iUserID">给定的会员ID</param>
        /// <returns></returns>
        public decimal GetEMoney(long iUserID)
        {
            decimal dEMoney = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [Emoney] FROM tb_user");
            strSql.Append(" WHERE UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = iUserID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);

            if (obj != null)
            {
                dEMoney = decimal.Parse(obj.ToString());
            }

            return dEMoney;
        }

        /// <summary>
        /// 判断给定的推荐人和安置人是否在同一条线上。
        /// </summary>
        /// <param name="iRecommendID">给定的推荐人</param>
        /// <param name="iParentID">给定的安置人</param>
        /// <returns></returns>
        public bool OnSameLine(long iRecommendID, long iParentID)
        {
            bool bFlag = false;

            string strRecommendUserPath = GetUserPath(iRecommendID);//推荐人路径
            string strParentUserPath = GetUserPath(iParentID);//安置人路径

            if (strParentUserPath.Contains(strRecommendUserPath) || strRecommendUserPath.Contains(strParentUserPath))
                bFlag = true;
            else
                bFlag = false;

            return bFlag;
        }

        /// <summary>
        /// 获取给定会员的路径
        /// </summary>
        /// <param name="iUserID"></param>
        /// <returns></returns>
        public string GetUserPath(long iUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [UserPath] FROM tb_user");
            strSql.Append(" WHERE UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = iUserID;

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
        /// 获取给定会员ID的金币。
        /// </summary>
        /// <param name="iUserID">给定的会员ID</param>
        /// <returns></returns>
        public decimal GetMoney(long iUserID, string strFieldName)
        {
            decimal dMoney = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [" + strFieldName + "] FROM tb_user");
            strSql.Append(" WHERE UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = iUserID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);

            if (obj != null)
            {
                dMoney = decimal.Parse(obj.ToString());
            }

            return dMoney;
        }

        /// <summary>
        /// 获取给定会员ID的金币。
        /// </summary>
        /// <param name="iUserID">给定的会员ID</param>
        /// <returns></returns>
        public decimal GetBonusAccount(long iUserID)
        {
            decimal dAccount = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [emoney] FROM tb_user");
            strSql.Append(" WHERE UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt)};
            parameters[0].Value = iUserID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);

            if (obj != null)
            {
                dAccount = decimal.Parse(obj.ToString());
            }

            return dAccount;
        }

        #region 根据给定的条件，统计会员数量
        /// <summary>
        /// 根据给定的条件，统计会员数量
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(UserID) FROM tb_user");

            if (!string.IsNullOrEmpty(strWhere))
                strSql.Append(" WHERE " + strWhere + "");

            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        } 
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(lgk.Model.tb_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_user(");
            strSql.Append("UserCode,LevelID,RecommendID,RecommendCode,RecommendPath,RecommendGenera,ParentID,ParentCode,UserPath,Layer,Location,IsOpend,IsLock,IsAgent,AgentsID,Emoney,BonusAccount,AllBonusAccount,StockAccount,StockMoney,User003,ShopAccount,RegTime,OpenTime,RegMoney,BillCount,GLmoney,AddGLTime,Password,SecondPassword,ThreePassword,SafetyCodeQuestion,SafetyCodeAnswer,LeftScore,CenterScore,RightScore,LeftBalance,CenterBalance,RightBalance,LeftNewScore,CenterNewScore,RightNewScore,LeftZT,CenterZT,RightZT,BankAccount,BankAccountUser,BankName,BankBranch,BankInProvince,BankInCity,Address,TrueName,NiceName,IdenCode,PhoneNum,Gender,QQnumer,User001,User002,User004,User005,User006,User007,User008,User009,User010,User011,User012,User013,User014,User015,User016,User017,User018,Email,IsOut,Batch,SyncIMState,SyncIMTime,MachineNumLock)");
            strSql.Append(" values (");
            strSql.Append("@UserCode,@LevelID,@RecommendID,@RecommendCode,@RecommendPath,@RecommendGenera,@ParentID,@ParentCode,@UserPath,@Layer,@Location,@IsOpend,@IsLock,@IsAgent,@AgentsID,@Emoney,@BonusAccount,@AllBonusAccount,@StockAccount,@StockMoney,@User003,@ShopAccount,@RegTime,@OpenTime,@RegMoney,@BillCount,@GLmoney,@AddGLTime,@Password,@SecondPassword,@ThreePassword,@SafetyCodeQuestion,@SafetyCodeAnswer,@LeftScore,@CenterScore,@RightScore,@LeftBalance,@CenterBalance,@RightBalance,@LeftNewScore,@CenterNewScore,@RightNewScore,@LeftZT,@CenterZT,@RightZT,@BankAccount,@BankAccountUser,@BankName,@BankBranch,@BankInProvince,@BankInCity,@Address,@TrueName,@NiceName,@IdenCode,@PhoneNum,@Gender,@QQnumer,@User001,@User002,@User004,@User005,@User006,@User007,@User008,@User009,@User010,@User011,@User012,@User013,@User014,@User015,@User016,@User017,@User018,@Email,@IsOut,@Batch,@SyncIMState,@SyncIMTime,@MachineNumLock)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserCode", SqlDbType.VarChar,20),
                    new SqlParameter("@LevelID", SqlDbType.Int,4),
                    new SqlParameter("@RecommendID", SqlDbType.BigInt,8),
                    new SqlParameter("@RecommendCode", SqlDbType.VarChar,50),
                    new SqlParameter("@RecommendPath", SqlDbType.Text),
                    new SqlParameter("@RecommendGenera", SqlDbType.Int,4),
                    new SqlParameter("@ParentID", SqlDbType.BigInt,8),
                    new SqlParameter("@ParentCode", SqlDbType.VarChar,50),
                    new SqlParameter("@UserPath", SqlDbType.Text),
                    new SqlParameter("@Layer", SqlDbType.Int,4),
                    new SqlParameter("@Location", SqlDbType.Int,4),
                    new SqlParameter("@IsOpend", SqlDbType.Int,4),
                    new SqlParameter("@IsLock", SqlDbType.Int,4),
                    new SqlParameter("@IsAgent", SqlDbType.Int,4),
                    new SqlParameter("@AgentsID", SqlDbType.Int,4),
                    new SqlParameter("@Emoney", SqlDbType.Decimal,9),
                    new SqlParameter("@BonusAccount", SqlDbType.Decimal,9),
                    new SqlParameter("@AllBonusAccount", SqlDbType.Decimal,9),
                    new SqlParameter("@StockAccount", SqlDbType.Decimal,9),
                    new SqlParameter("@StockMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@User003", SqlDbType.Int,4),
                    new SqlParameter("@ShopAccount", SqlDbType.Decimal,9),
                    new SqlParameter("@RegTime", SqlDbType.DateTime),
                    new SqlParameter("@OpenTime", SqlDbType.DateTime),
                    new SqlParameter("@RegMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@BillCount", SqlDbType.Int,4),
                    new SqlParameter("@GLmoney", SqlDbType.Decimal,9),
                    new SqlParameter("@AddGLTime", SqlDbType.DateTime),
                    new SqlParameter("@Password", SqlDbType.VarChar,50),
                    new SqlParameter("@SecondPassword", SqlDbType.VarChar,50),
                    new SqlParameter("@ThreePassword", SqlDbType.VarChar,50),
                    new SqlParameter("@SafetyCodeQuestion", SqlDbType.VarChar,200),
                    new SqlParameter("@SafetyCodeAnswer", SqlDbType.VarChar,200),
                    new SqlParameter("@LeftScore", SqlDbType.Decimal,9),
                    new SqlParameter("@CenterScore", SqlDbType.Decimal,9),
                    new SqlParameter("@RightScore", SqlDbType.Decimal,9),
                    new SqlParameter("@LeftBalance", SqlDbType.Decimal,9),
                    new SqlParameter("@CenterBalance", SqlDbType.Decimal,9),
                    new SqlParameter("@RightBalance", SqlDbType.Decimal,9),
                    new SqlParameter("@LeftNewScore", SqlDbType.Decimal,9),
                    new SqlParameter("@CenterNewScore", SqlDbType.Decimal,9),
                    new SqlParameter("@RightNewScore", SqlDbType.Decimal,9),
                    new SqlParameter("@LeftZT", SqlDbType.Decimal,9),
                    new SqlParameter("@CenterZT", SqlDbType.Decimal,9),
                    new SqlParameter("@RightZT", SqlDbType.Decimal,9),
                    new SqlParameter("@BankAccount", SqlDbType.VarChar,50),
                    new SqlParameter("@BankAccountUser", SqlDbType.VarChar,50),
                    new SqlParameter("@BankName", SqlDbType.VarChar,50),
                    new SqlParameter("@BankBranch", SqlDbType.VarChar,50),
                    new SqlParameter("@BankInProvince", SqlDbType.VarChar,50),
                    new SqlParameter("@BankInCity", SqlDbType.VarChar,50),
                    new SqlParameter("@Address", SqlDbType.VarChar,50),
                    new SqlParameter("@TrueName", SqlDbType.VarChar,50),
                    new SqlParameter("@NiceName", SqlDbType.VarChar,50),
                    new SqlParameter("@IdenCode", SqlDbType.VarChar,50),
                    new SqlParameter("@PhoneNum", SqlDbType.VarChar,50),
                    new SqlParameter("@Gender", SqlDbType.Int,4),
                    new SqlParameter("@QQnumer", SqlDbType.VarChar,50),
                    new SqlParameter("@User001", SqlDbType.Int,4),
                    new SqlParameter("@User002", SqlDbType.BigInt,8),
                    new SqlParameter("@User004", SqlDbType.Int,4),
                    new SqlParameter("@User005", SqlDbType.VarChar,200),
                    new SqlParameter("@User006", SqlDbType.VarChar,200),
                    new SqlParameter("@User007", SqlDbType.VarChar,200),
                    new SqlParameter("@User008", SqlDbType.VarChar,200),
                    new SqlParameter("@User009", SqlDbType.VarChar,200),
                    new SqlParameter("@User010", SqlDbType.VarChar,200),
                    new SqlParameter("@User011", SqlDbType.Decimal,9),
                    new SqlParameter("@User012", SqlDbType.Decimal,9),
                    new SqlParameter("@User013", SqlDbType.Decimal,9),
                    new SqlParameter("@User014", SqlDbType.Decimal,9),
                    new SqlParameter("@User015", SqlDbType.Decimal,9),
                    new SqlParameter("@User016", SqlDbType.Decimal,9),
                    new SqlParameter("@User017", SqlDbType.Decimal,9),
                    new SqlParameter("@User018", SqlDbType.Decimal,9),
                    new SqlParameter("@Email", SqlDbType.VarChar,200),
                    new SqlParameter("@IsOut", SqlDbType.Int,4),
                    new SqlParameter("@Batch", SqlDbType.Int,4),
                    new SqlParameter("@SyncIMState", SqlDbType.Int,4),
                    new SqlParameter("@SyncIMTime", SqlDbType.DateTime),
                    new SqlParameter("@MachineNumLock", SqlDbType.Int,4)};
            parameters[0].Value = model.UserCode;
            parameters[1].Value = model.LevelID;
            parameters[2].Value = model.RecommendID;
            parameters[3].Value = model.RecommendCode;
            parameters[4].Value = model.RecommendPath;
            parameters[5].Value = model.RecommendGenera;
            parameters[6].Value = model.ParentID;
            parameters[7].Value = model.ParentCode;
            parameters[8].Value = model.UserPath;
            parameters[9].Value = model.Layer;
            parameters[10].Value = model.Location;
            parameters[11].Value = model.IsOpend;
            parameters[12].Value = model.IsLock;
            parameters[13].Value = model.IsAgent;
            parameters[14].Value = model.AgentsID;
            parameters[15].Value = model.Emoney;
            parameters[16].Value = model.BonusAccount;
            parameters[17].Value = model.AllBonusAccount;
            parameters[18].Value = model.StockAccount;
            parameters[19].Value = model.StockMoney;
            parameters[20].Value = model.User003;
            parameters[21].Value = model.ShopAccount;
            parameters[22].Value = model.RegTime;
            parameters[23].Value = model.OpenTime;
            parameters[24].Value = model.RegMoney;
            parameters[25].Value = model.BillCount;
            parameters[26].Value = model.GLmoney;
            parameters[27].Value = model.AddGLTime;
            parameters[28].Value = model.Password;
            parameters[29].Value = model.SecondPassword;
            parameters[30].Value = model.ThreePassword;
            parameters[31].Value = model.SafetyCodeQuestion;
            parameters[32].Value = model.SafetyCodeAnswer;
            parameters[33].Value = model.LeftScore;
            parameters[34].Value = model.CenterScore;
            parameters[35].Value = model.RightScore;
            parameters[36].Value = model.LeftBalance;
            parameters[37].Value = model.CenterBalance;
            parameters[38].Value = model.RightBalance;
            parameters[39].Value = model.LeftNewScore;
            parameters[40].Value = model.CenterNewScore;
            parameters[41].Value = model.RightNewScore;
            parameters[42].Value = model.LeftZT;
            parameters[43].Value = model.CenterZT;
            parameters[44].Value = model.RightZT;
            parameters[45].Value = model.BankAccount;
            parameters[46].Value = model.BankAccountUser;
            parameters[47].Value = model.BankName;
            parameters[48].Value = model.BankBranch;
            parameters[49].Value = model.BankInProvince;
            parameters[50].Value = model.BankInCity;
            parameters[51].Value = model.Address;
            parameters[52].Value = model.TrueName;
            parameters[53].Value = model.NiceName;
            parameters[54].Value = model.IdenCode;
            parameters[55].Value = model.PhoneNum;
            parameters[56].Value = model.Gender;
            parameters[57].Value = model.QQnumer;
            parameters[58].Value = model.User001;
            parameters[59].Value = model.User002;
            parameters[60].Value = model.User004;
            parameters[61].Value = model.User005;
            parameters[62].Value = model.User006;
            parameters[63].Value = model.User007;
            parameters[64].Value = model.User008;
            parameters[65].Value = model.User009;
            parameters[66].Value = model.User010;
            parameters[67].Value = model.User011;
            parameters[68].Value = model.User012;
            parameters[69].Value = model.User013;
            parameters[70].Value = model.User014;
            parameters[71].Value = model.User015;
            parameters[72].Value = model.User016;
            parameters[73].Value = model.User017;
            parameters[74].Value = model.User018;
            parameters[75].Value = model.Email;
            parameters[76].Value = model.IsOut;
            parameters[77].Value = model.Batch;
            parameters[78].Value = model.SyncIMState;
            parameters[79].Value = model.SyncIMTime;
            parameters[80].Value = model.MachineNumLock;

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
        #endregion

        #region 更新昵称
        /// <summary>
        /// 更新昵称
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateNiceName(lgk.Model.tb_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_user set ");
            strSql.Append("NiceName=@NiceName,");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
                new SqlParameter("@NiceName", SqlDbType.VarChar,50),
                new SqlParameter("@UserID", SqlDbType.BigInt,8),
            };
            parameters[0].Value = model.NiceName;
            parameters[1].Value = model.UserID;

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
        #endregion

        #region 更新性别
        /// <summary>
        /// 更新性别
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateGender(lgk.Model.tb_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_user set ");
            strSql.Append("Gender=@Gender,");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
              
                new SqlParameter("@Gender", SqlDbType.Int,4),
                new SqlParameter("@UserID", SqlDbType.BigInt,8),
            };
           
            parameters[0].Value = model.Gender;
            parameters[11].Value = model.UserID;

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
        #endregion

        #region 更新一条数据
        public bool Update(lgk.Model.tb_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_user set ");
            strSql.Append("UserCode=@UserCode,");
            strSql.Append("LevelID=@LevelID,");
            strSql.Append("RecommendID=@RecommendID,");
            strSql.Append("RecommendCode=@RecommendCode,");
            strSql.Append("RecommendPath=@RecommendPath,");
            strSql.Append("RecommendGenera=@RecommendGenera,");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("ParentCode=@ParentCode,");
            strSql.Append("UserPath=@UserPath,");
            strSql.Append("Layer=@Layer,");
            strSql.Append("Location=@Location,");
            strSql.Append("IsOpend=@IsOpend,");
            strSql.Append("IsLock=@IsLock,");
            strSql.Append("IsAgent=@IsAgent,");
            strSql.Append("AgentsID=@AgentsID,");
            strSql.Append("Emoney=@Emoney,");
            strSql.Append("BonusAccount=@BonusAccount,");
            strSql.Append("AllBonusAccount=@AllBonusAccount,");
            strSql.Append("StockAccount=@StockAccount,");
            strSql.Append("StockMoney=@StockMoney,");
            strSql.Append("User003=@User003,");
            strSql.Append("ShopAccount=@ShopAccount,");
            strSql.Append("RegTime=@RegTime,");
            strSql.Append("OpenTime=@OpenTime,");
            strSql.Append("RegMoney=@RegMoney,");
            strSql.Append("BillCount=@BillCount,");
            strSql.Append("GLmoney=@GLmoney,");
            strSql.Append("AddGLTime=@AddGLTime,");
            strSql.Append("Password=@Password,");
            strSql.Append("SecondPassword=@SecondPassword,");
            strSql.Append("ThreePassword=@ThreePassword,");
            strSql.Append("SafetyCodeQuestion=@SafetyCodeQuestion,");
            strSql.Append("SafetyCodeAnswer=@SafetyCodeAnswer,");
            strSql.Append("LeftScore=@LeftScore,");
            strSql.Append("CenterScore=@CenterScore,");
            strSql.Append("RightScore=@RightScore,");
            strSql.Append("LeftBalance=@LeftBalance,");
            strSql.Append("CenterBalance=@CenterBalance,");
            strSql.Append("RightBalance=@RightBalance,");
            strSql.Append("LeftNewScore=@LeftNewScore,");
            strSql.Append("CenterNewScore=@CenterNewScore,");
            strSql.Append("RightNewScore=@RightNewScore,");
            strSql.Append("LeftZT=@LeftZT,");
            strSql.Append("CenterZT=@CenterZT,");
            strSql.Append("RightZT=@RightZT,");
            strSql.Append("BankAccount=@BankAccount,");
            strSql.Append("BankAccountUser=@BankAccountUser,");
            strSql.Append("BankName=@BankName,");
            strSql.Append("BankBranch=@BankBranch,");
            strSql.Append("BankInProvince=@BankInProvince,");
            strSql.Append("BankInCity=@BankInCity,");
            strSql.Append("Address=@Address,");
            strSql.Append("TrueName=@TrueName,");
            strSql.Append("NiceName=@NiceName,");
            strSql.Append("IdenCode=@IdenCode,");
            strSql.Append("PhoneNum=@PhoneNum,");
            strSql.Append("Gender=@Gender,");
            strSql.Append("QQnumer=@QQnumer,");
            strSql.Append("User001=@User001,");
            strSql.Append("User002=@User002,");
            strSql.Append("User004=@User004,");
            strSql.Append("User005=@User005,");
            strSql.Append("User006=@User006,");
            strSql.Append("User007=@User007,");
            strSql.Append("User008=@User008,");
            strSql.Append("User009=@User009,");
            strSql.Append("User010=@User010,");
            strSql.Append("User011=@User011,");
            strSql.Append("User012=@User012,");
            strSql.Append("User013=@User013,");
            strSql.Append("User014=@User014,");
            strSql.Append("User015=@User015,");
            strSql.Append("User016=@User016,");
            strSql.Append("User017=@User017,");
            strSql.Append("User018=@User018,");
            strSql.Append("Email=@Email,");
            strSql.Append("IsOut=@IsOut,");
            strSql.Append("Batch=@Batch,");
            strSql.Append("SyncIMState=@SyncIMState,");
            strSql.Append("SyncIMTime=@SyncIMTime,");
            strSql.Append("MachineNumLock=@MachineNumLock");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserCode", SqlDbType.VarChar,20),
                    new SqlParameter("@LevelID", SqlDbType.Int,4),
                    new SqlParameter("@RecommendID", SqlDbType.BigInt,8),
                    new SqlParameter("@RecommendCode", SqlDbType.VarChar,50),
                    new SqlParameter("@RecommendPath", SqlDbType.Text),
                    new SqlParameter("@RecommendGenera", SqlDbType.Int,4),
                    new SqlParameter("@ParentID", SqlDbType.BigInt,8),
                    new SqlParameter("@ParentCode", SqlDbType.VarChar,50),
                    new SqlParameter("@UserPath", SqlDbType.Text),
                    new SqlParameter("@Layer", SqlDbType.Int,4),
                    new SqlParameter("@Location", SqlDbType.Int,4),
                    new SqlParameter("@IsOpend", SqlDbType.Int,4),
                    new SqlParameter("@IsLock", SqlDbType.Int,4),
                    new SqlParameter("@IsAgent", SqlDbType.Int,4),
                    new SqlParameter("@AgentsID", SqlDbType.Int,4),
                    new SqlParameter("@Emoney", SqlDbType.Decimal,9),
                    new SqlParameter("@BonusAccount", SqlDbType.Decimal,9),
                    new SqlParameter("@AllBonusAccount", SqlDbType.Decimal,9),
                    new SqlParameter("@StockAccount", SqlDbType.Decimal,9),
                    new SqlParameter("@StockMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@User003", SqlDbType.Int,4),
                    new SqlParameter("@ShopAccount", SqlDbType.Decimal,9),
                    new SqlParameter("@RegTime", SqlDbType.DateTime),
                    new SqlParameter("@OpenTime", SqlDbType.DateTime),
                    new SqlParameter("@RegMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@BillCount", SqlDbType.Int,4),
                    new SqlParameter("@GLmoney", SqlDbType.Decimal,9),
                    new SqlParameter("@AddGLTime", SqlDbType.DateTime),
                    new SqlParameter("@Password", SqlDbType.VarChar,50),
                    new SqlParameter("@SecondPassword", SqlDbType.VarChar,50),
                    new SqlParameter("@ThreePassword", SqlDbType.VarChar,50),
                    new SqlParameter("@SafetyCodeQuestion", SqlDbType.VarChar,200),
                    new SqlParameter("@SafetyCodeAnswer", SqlDbType.VarChar,200),
                    new SqlParameter("@LeftScore", SqlDbType.Decimal,9),
                    new SqlParameter("@CenterScore", SqlDbType.Decimal,9),
                    new SqlParameter("@RightScore", SqlDbType.Decimal,9),
                    new SqlParameter("@LeftBalance", SqlDbType.Decimal,9),
                    new SqlParameter("@CenterBalance", SqlDbType.Decimal,9),
                    new SqlParameter("@RightBalance", SqlDbType.Decimal,9),
                    new SqlParameter("@LeftNewScore", SqlDbType.Decimal,9),
                    new SqlParameter("@CenterNewScore", SqlDbType.Decimal,9),
                    new SqlParameter("@RightNewScore", SqlDbType.Decimal,9),
                    new SqlParameter("@LeftZT", SqlDbType.Decimal,9),
                    new SqlParameter("@CenterZT", SqlDbType.Decimal,9),
                    new SqlParameter("@RightZT", SqlDbType.Decimal,9),
                    new SqlParameter("@BankAccount", SqlDbType.VarChar,50),
                    new SqlParameter("@BankAccountUser", SqlDbType.VarChar,50),
                    new SqlParameter("@BankName", SqlDbType.VarChar,50),
                    new SqlParameter("@BankBranch", SqlDbType.VarChar,50),
                    new SqlParameter("@BankInProvince", SqlDbType.VarChar,50),
                    new SqlParameter("@BankInCity", SqlDbType.VarChar,50),
                    new SqlParameter("@Address", SqlDbType.VarChar,50),
                    new SqlParameter("@TrueName", SqlDbType.VarChar,50),
                    new SqlParameter("@NiceName", SqlDbType.VarChar,50),
                    new SqlParameter("@IdenCode", SqlDbType.VarChar,50),
                    new SqlParameter("@PhoneNum", SqlDbType.VarChar,50),
                    new SqlParameter("@Gender", SqlDbType.Int,4),
                    new SqlParameter("@QQnumer", SqlDbType.VarChar,50),
                    new SqlParameter("@User001", SqlDbType.Int,4),
                    new SqlParameter("@User002", SqlDbType.BigInt,8),
                    new SqlParameter("@User004", SqlDbType.Int,4),
                    new SqlParameter("@User005", SqlDbType.VarChar,200),
                    new SqlParameter("@User006", SqlDbType.VarChar,200),
                    new SqlParameter("@User007", SqlDbType.VarChar,200),
                    new SqlParameter("@User008", SqlDbType.VarChar,200),
                    new SqlParameter("@User009", SqlDbType.VarChar,200),
                    new SqlParameter("@User010", SqlDbType.VarChar,200),
                    new SqlParameter("@User011", SqlDbType.Decimal,9),
                    new SqlParameter("@User012", SqlDbType.Decimal,9),
                    new SqlParameter("@User013", SqlDbType.Decimal,9),
                    new SqlParameter("@User014", SqlDbType.Decimal,9),
                    new SqlParameter("@User015", SqlDbType.Decimal,9),
                    new SqlParameter("@User016", SqlDbType.Decimal,9),
                    new SqlParameter("@User017", SqlDbType.Decimal,9),
                    new SqlParameter("@User018", SqlDbType.Decimal,9),
                    new SqlParameter("@Email", SqlDbType.VarChar,200),
                    new SqlParameter("@IsOut", SqlDbType.Int,4),
                    new SqlParameter("@Batch", SqlDbType.Int,4),
                    new SqlParameter("@SyncIMState", SqlDbType.Int,4),
                    new SqlParameter("@SyncIMTime", SqlDbType.DateTime),
                    new SqlParameter("@MachineNumLock", SqlDbType.Int,4),
                    new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.UserCode;
            parameters[1].Value = model.LevelID;
            parameters[2].Value = model.RecommendID;
            parameters[3].Value = model.RecommendCode;
            parameters[4].Value = model.RecommendPath;
            parameters[5].Value = model.RecommendGenera;
            parameters[6].Value = model.ParentID;
            parameters[7].Value = model.ParentCode;
            parameters[8].Value = model.UserPath;
            parameters[9].Value = model.Layer;
            parameters[10].Value = model.Location;
            parameters[11].Value = model.IsOpend;
            parameters[12].Value = model.IsLock;
            parameters[13].Value = model.IsAgent;
            parameters[14].Value = model.AgentsID;
            parameters[15].Value = model.Emoney;
            parameters[16].Value = model.BonusAccount;
            parameters[17].Value = model.AllBonusAccount;
            parameters[18].Value = model.StockAccount;
            parameters[19].Value = model.StockMoney;
            parameters[20].Value = model.User003;
            parameters[21].Value = model.ShopAccount;
            parameters[22].Value = model.RegTime;
            parameters[23].Value = model.OpenTime;
            parameters[24].Value = model.RegMoney;
            parameters[25].Value = model.BillCount;
            parameters[26].Value = model.GLmoney;
            parameters[27].Value = model.AddGLTime;
            parameters[28].Value = model.Password;
            parameters[29].Value = model.SecondPassword;
            parameters[30].Value = model.ThreePassword;
            parameters[31].Value = model.SafetyCodeQuestion;
            parameters[32].Value = model.SafetyCodeAnswer;
            parameters[33].Value = model.LeftScore;
            parameters[34].Value = model.CenterScore;
            parameters[35].Value = model.RightScore;
            parameters[36].Value = model.LeftBalance;
            parameters[37].Value = model.CenterBalance;
            parameters[38].Value = model.RightBalance;
            parameters[39].Value = model.LeftNewScore;
            parameters[40].Value = model.CenterNewScore;
            parameters[41].Value = model.RightNewScore;
            parameters[42].Value = model.LeftZT;
            parameters[43].Value = model.CenterZT;
            parameters[44].Value = model.RightZT;
            parameters[45].Value = model.BankAccount;
            parameters[46].Value = model.BankAccountUser;
            parameters[47].Value = model.BankName;
            parameters[48].Value = model.BankBranch;
            parameters[49].Value = model.BankInProvince;
            parameters[50].Value = model.BankInCity;
            parameters[51].Value = model.Address;
            parameters[52].Value = model.TrueName;
            parameters[53].Value = model.NiceName;
            parameters[54].Value = model.IdenCode;
            parameters[55].Value = model.PhoneNum;
            parameters[56].Value = model.Gender;
            parameters[57].Value = model.QQnumer;
            parameters[58].Value = model.User001;
            parameters[59].Value = model.User002;
            parameters[60].Value = model.User004;
            parameters[61].Value = model.User005;
            parameters[62].Value = model.User006;
            parameters[63].Value = model.User007;
            parameters[64].Value = model.User008;
            parameters[65].Value = model.User009;
            parameters[66].Value = model.User010;
            parameters[67].Value = model.User011;
            parameters[68].Value = model.User012;
            parameters[69].Value = model.User013;
            parameters[70].Value = model.User014;
            parameters[71].Value = model.User015;
            parameters[72].Value = model.User016;
            parameters[73].Value = model.User017;
            parameters[74].Value = model.User018;
            parameters[75].Value = model.Email;
            parameters[76].Value = model.IsOut;
            parameters[77].Value = model.Batch;
            parameters[78].Value = model.SyncIMState;
            parameters[79].Value = model.SyncIMTime;
            parameters[80].Value = model.MachineNumLock;
            parameters[81].Value = model.UserID;

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
        #endregion

        /// <summary>
        /// 更新给定账号ID的复投次数(iTypeID:0减少，1增加)
        /// </summary>
        /// <param name="iUserID"></param>
        /// <param name="iTypeID"></param>
        /// <returns></returns>
        public bool UpdateBatch(long iUserID, int iTypeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE tb_user SET");
            strSql.Append(" IsOut = 0,");
            if (iTypeID == 0)
                strSql.Append(" Batch -= 1");
            else
                strSql.Append(" Batch += 1");
            strSql.Append(" WHERE UserID=" + iUserID + "");

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
        /// 开通空单
        /// </summary>
        /// <param name="iUserID"></param>
        /// <returns></returns>
        public bool UpdateEmpty(long iUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE tb_user SET IsOpend = 3");
            strSql.Append(" WHERE UserID=" + iUserID + "");

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
        /// 将给定的用户ID更新成报单中心
        /// </summary>
        /// <param name="iUserID">用户ID</param>
        /// <returns></returns>
        public bool UpdateAgent(long iUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_user set ");
            strSql.Append("IsAgent=@IsAgent");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@IsAgent", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = 1;
            parameters[1].Value = iUserID;

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
        /// 将给定的用户ID更新成报单中心
        /// </summary>
        /// <param name="iUserID">用户ID</param>
        /// <returns></returns>
        public bool UpdateAgent1(long iUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_user1 set ");
            strSql.Append("IsAgent=@IsAgent");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
                    new SqlParameter("@IsAgent", SqlDbType.Int,4),
                    new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = 1;
            parameters[1].Value = iUserID;

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
        /// 修改下线的报单中心信息
        /// </summary>
        public bool UpdateAgent(long iAgentsID, long iUserID, string strUserCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_user set ");
            strSql.Append("AgentsID=@AgentsID,");
            strSql.Append("User006=@User006");
            strSql.Append(" where RecommendID=@RecommendID");
            SqlParameter[] parameters = {
					new SqlParameter("@AgentsID", SqlDbType.Int,4),
					new SqlParameter("@User006", SqlDbType.VarChar,200),
					new SqlParameter("@RecommendID", SqlDbType.BigInt,8)};
            parameters[0].Value = iAgentsID;
            parameters[1].Value = strUserCode;
            parameters[2].Value = iUserID;

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

        #region 获取推荐人节点
        /// <summary>
        /// 根据给定的会员编号，获取其下面的所有会员。
        /// </summary>
        /// <param name="iUserID">根据给定的会员编号</param>
        /// <returns></returns>
        public string GetAllRecommendID(long iUserID)
        {
            strRecommendID = "";//全局变量，上面有定义

            strRecommendID = GetRecommend(iUserID);

            strRecommendID = strRecommendID.Substring(0, strRecommendID.Length - 1);

            return strRecommendID;
        }

        /// <summary>
        /// 根据给定的会员编号，获取其下面的所有会员ID。
        /// </summary>
        /// <param name="iUserID">给定的会员编号</param>
        /// <returns></returns>
        public string GetRecommend(long iRecommendID)
        {
            string strChildeeID = "", strRecomID = "";

            strChildeeID = GetRecommendID(iRecommendID);
            strRecommendID += strChildeeID + ",";

            string[] strChildID = strChildeeID.Split(',');

            int iLength = strChildID.Length;

            for (int i = 0; i < iLength; i++)
            {
                if (strChildID[i] != "")
                {
                    long m = Convert.ToInt64(strChildID[i]);
                    strRecomID = GetRecommendID(m);
                    if (strRecomID != "")
                    {
                        GetRecommend(m);
                    }
                }
            }
            return strRecommendID;
        }

        /// <summary>
        /// 获取下级推荐编号
        /// </summary>
        /// <param name="iUserID"></param>
        /// <returns></returns>
        public string GetRecommendID(long iRecommendID)
        {
            int iCount = 0;
            string strRecommendID = "";

            SortedList<string, lgk.Model.tb_user> myUser = new SortedList<string, lgk.Model.tb_user>();
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT [UserID] FROM [tb_user]");
            strSql.Append(" WHERE RecommendID=@RecommendID");
            SqlParameter[] parameters = {
                        new SqlParameter("@RecommendID", SqlDbType.BigInt,8)};
            parameters[0].Value = iRecommendID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lgk.Model.tb_user model = new lgk.Model.tb_user();

                    if (ds.Tables[0].Rows[i]["UserID"] != null && ds.Tables[0].Rows[i]["UserID"].ToString() != "")
                    {
                        model.UserID = long.Parse(ds.Tables[0].Rows[i]["UserID"].ToString());
                        myUser.Add(Convert.ToString(iCount), model);
                        iCount++;
                    }
                }
            }

            iCount = myUser.Count;

            if (iCount > 0)
            {
                for (int i = 0; i < iCount; i++)
                {
                    if (i == iCount - 1)
                    {
                        strRecommendID += myUser.Values[i].UserID;
                    }
                    else
                    {
                        strRecommendID += myUser.Values[i].UserID + ",";
                    }
                }
            }
            else
            {
                strRecommendID = "";
            }

            return strRecommendID;
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM tb_user");
            strSql.Append(" WHERE UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = UserID;

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
        #endregion

        #region 删除多条数据
        /// <summary>
        /// 删除多条数据
        /// </summary>
        public bool DeleteList(string UserIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM tb_user ");
            strSql.Append(" WHERE UserID IN (" + UserIDlist + ")  ");
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
        #endregion
        /// <summary>
        /// 查询语句
        /// </summary>
        /// <param name="pTable"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet getData_Chaxun(string pTable, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"" + pTable + "");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #region 根据ID查询一个对象实体
        /// <summary>
		/// 根据ID查询一个对象实体
		/// </summary>
		public lgk.Model.tb_user GetModel(long UserID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserID,UserCode,LevelID,RecommendID,RecommendCode,RecommendPath,RecommendGenera,ParentID,ParentCode,UserPath,Layer,Location,IsOpend,IsLock,IsAgent,AgentsID,Emoney,BonusAccount,AllBonusAccount,StockAccount,StockMoney,User003,ShopAccount,RegTime,OpenTime,RegMoney,BillCount,GLmoney,AddGLTime,Password,SecondPassword,ThreePassword,SafetyCodeQuestion,SafetyCodeAnswer,LeftScore,CenterScore,RightScore,LeftBalance,CenterBalance,RightBalance,LeftNewScore,CenterNewScore,RightNewScore,LeftZT,CenterZT,RightZT,BankAccount,BankAccountUser,BankName,BankBranch,BankInProvince,BankInCity,Address,TrueName,NiceName,IdenCode,PhoneNum,Gender,QQnumer,User001,User002,User004,User005,User006,User007,User008,User009,User010,User011,User012,User013,User014,User015,User016,User017,User018,Email,IsOut,Batch,SyncIMState,SyncIMTime,MachineNumLock from tb_user ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.BigInt)
            };
            parameters[0].Value = UserID;

            lgk.Model.tb_user model = new lgk.Model.tb_user();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public lgk.Model.tb_user DataRowToModel(DataRow row)
        {
            lgk.Model.tb_user model = new lgk.Model.tb_user();
            if (row != null)
            {
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(row["UserID"].ToString());
                }
                if (row["UserCode"] != null)
                {
                    model.UserCode = row["UserCode"].ToString();
                }
                if (row["LevelID"] != null && row["LevelID"].ToString() != "")
                {
                    model.LevelID = int.Parse(row["LevelID"].ToString());
                }
                if (row["RecommendID"] != null && row["RecommendID"].ToString() != "")
                {
                    model.RecommendID = long.Parse(row["RecommendID"].ToString());
                }
                if (row["RecommendCode"] != null)
                {
                    model.RecommendCode = row["RecommendCode"].ToString();
                }
                if (row["RecommendPath"] != null)
                {
                    model.RecommendPath = row["RecommendPath"].ToString();
                }
                if (row["RecommendGenera"] != null && row["RecommendGenera"].ToString() != "")
                {
                    model.RecommendGenera = int.Parse(row["RecommendGenera"].ToString());
                }
                if (row["ParentID"] != null && row["ParentID"].ToString() != "")
                {
                    model.ParentID = long.Parse(row["ParentID"].ToString());
                }
                if (row["ParentCode"] != null)
                {
                    model.ParentCode = row["ParentCode"].ToString();
                }
                if (row["UserPath"] != null)
                {
                    model.UserPath = row["UserPath"].ToString();
                }
                if (row["Layer"] != null && row["Layer"].ToString() != "")
                {
                    model.Layer = int.Parse(row["Layer"].ToString());
                }
                if (row["Location"] != null && row["Location"].ToString() != "")
                {
                    model.Location = int.Parse(row["Location"].ToString());
                }
                if (row["IsOpend"] != null && row["IsOpend"].ToString() != "")
                {
                    model.IsOpend = int.Parse(row["IsOpend"].ToString());
                }
                if (row["IsLock"] != null && row["IsLock"].ToString() != "")
                {
                    model.IsLock = int.Parse(row["IsLock"].ToString());
                }
                if (row["IsAgent"] != null && row["IsAgent"].ToString() != "")
                {
                    model.IsAgent = int.Parse(row["IsAgent"].ToString());
                }
                if (row["AgentsID"] != null && row["AgentsID"].ToString() != "")
                {
                    model.AgentsID = int.Parse(row["AgentsID"].ToString());
                }
                if (row["Emoney"] != null && row["Emoney"].ToString() != "")
                {
                    model.Emoney = decimal.Parse(row["Emoney"].ToString());
                }
                if (row["BonusAccount"] != null && row["BonusAccount"].ToString() != "")
                {
                    model.BonusAccount = decimal.Parse(row["BonusAccount"].ToString());
                }
                if (row["AllBonusAccount"] != null && row["AllBonusAccount"].ToString() != "")
                {
                    model.AllBonusAccount = decimal.Parse(row["AllBonusAccount"].ToString());
                }
                if (row["StockAccount"] != null && row["StockAccount"].ToString() != "")
                {
                    model.StockAccount = decimal.Parse(row["StockAccount"].ToString());
                }
                if (row["StockMoney"] != null && row["StockMoney"].ToString() != "")
                {
                    model.StockMoney = decimal.Parse(row["StockMoney"].ToString());
                }
                if (row["User003"] != null && row["User003"].ToString() != "")
                {
                    model.User003 = int.Parse(row["User003"].ToString());
                }
                if (row["ShopAccount"] != null && row["ShopAccount"].ToString() != "")
                {
                    model.ShopAccount = decimal.Parse(row["ShopAccount"].ToString());
                }
                if (row["RegTime"] != null && row["RegTime"].ToString() != "")
                {
                    model.RegTime = DateTime.Parse(row["RegTime"].ToString());
                }
                if (row["OpenTime"] != null && row["OpenTime"].ToString() != "")
                {
                    model.OpenTime = DateTime.Parse(row["OpenTime"].ToString());
                }
                if (row["RegMoney"] != null && row["RegMoney"].ToString() != "")
                {
                    model.RegMoney = decimal.Parse(row["RegMoney"].ToString());
                }
                if (row["BillCount"] != null && row["BillCount"].ToString() != "")
                {
                    model.BillCount = int.Parse(row["BillCount"].ToString());
                }
                if (row["GLmoney"] != null && row["GLmoney"].ToString() != "")
                {
                    model.GLmoney = decimal.Parse(row["GLmoney"].ToString());
                }
                if (row["AddGLTime"] != null && row["AddGLTime"].ToString() != "")
                {
                    model.AddGLTime = DateTime.Parse(row["AddGLTime"].ToString());
                }
                if (row["Password"] != null)
                {
                    model.Password = row["Password"].ToString();
                }
                if (row["SecondPassword"] != null)
                {
                    model.SecondPassword = row["SecondPassword"].ToString();
                }
                if (row["ThreePassword"] != null)
                {
                    model.ThreePassword = row["ThreePassword"].ToString();
                }
                if (row["SafetyCodeQuestion"] != null)
                {
                    model.SafetyCodeQuestion = row["SafetyCodeQuestion"].ToString();
                }
                if (row["SafetyCodeAnswer"] != null)
                {
                    model.SafetyCodeAnswer = row["SafetyCodeAnswer"].ToString();
                }
                if (row["LeftScore"] != null && row["LeftScore"].ToString() != "")
                {
                    model.LeftScore = decimal.Parse(row["LeftScore"].ToString());
                }
                if (row["CenterScore"] != null && row["CenterScore"].ToString() != "")
                {
                    model.CenterScore = decimal.Parse(row["CenterScore"].ToString());
                }
                if (row["RightScore"] != null && row["RightScore"].ToString() != "")
                {
                    model.RightScore = decimal.Parse(row["RightScore"].ToString());
                }
                if (row["LeftBalance"] != null && row["LeftBalance"].ToString() != "")
                {
                    model.LeftBalance = decimal.Parse(row["LeftBalance"].ToString());
                }
                if (row["CenterBalance"] != null && row["CenterBalance"].ToString() != "")
                {
                    model.CenterBalance = decimal.Parse(row["CenterBalance"].ToString());
                }
                if (row["RightBalance"] != null && row["RightBalance"].ToString() != "")
                {
                    model.RightBalance = decimal.Parse(row["RightBalance"].ToString());
                }
                if (row["LeftNewScore"] != null && row["LeftNewScore"].ToString() != "")
                {
                    model.LeftNewScore = decimal.Parse(row["LeftNewScore"].ToString());
                }
                if (row["CenterNewScore"] != null && row["CenterNewScore"].ToString() != "")
                {
                    model.CenterNewScore = decimal.Parse(row["CenterNewScore"].ToString());
                }
                if (row["RightNewScore"] != null && row["RightNewScore"].ToString() != "")
                {
                    model.RightNewScore = decimal.Parse(row["RightNewScore"].ToString());
                }
                if (row["LeftZT"] != null && row["LeftZT"].ToString() != "")
                {
                    model.LeftZT = decimal.Parse(row["LeftZT"].ToString());
                }
                if (row["CenterZT"] != null && row["CenterZT"].ToString() != "")
                {
                    model.CenterZT = decimal.Parse(row["CenterZT"].ToString());
                }
                if (row["RightZT"] != null && row["RightZT"].ToString() != "")
                {
                    model.RightZT = decimal.Parse(row["RightZT"].ToString());
                }
                if (row["BankAccount"] != null)
                {
                    model.BankAccount = row["BankAccount"].ToString();
                }
                if (row["BankAccountUser"] != null)
                {
                    model.BankAccountUser = row["BankAccountUser"].ToString();
                }
                if (row["BankName"] != null)
                {
                    model.BankName = row["BankName"].ToString();
                }
                if (row["BankBranch"] != null)
                {
                    model.BankBranch = row["BankBranch"].ToString();
                }
                if (row["BankInProvince"] != null)
                {
                    model.BankInProvince = row["BankInProvince"].ToString();
                }
                if (row["BankInCity"] != null)
                {
                    model.BankInCity = row["BankInCity"].ToString();
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["TrueName"] != null)
                {
                    model.TrueName = row["TrueName"].ToString();
                }
                if (row["NiceName"] != null)
                {
                    model.NiceName = row["NiceName"].ToString();
                }
                if (row["IdenCode"] != null)
                {
                    model.IdenCode = row["IdenCode"].ToString();
                }
                if (row["PhoneNum"] != null)
                {
                    model.PhoneNum = row["PhoneNum"].ToString();
                }
                if (row["Gender"] != null && row["Gender"].ToString() != "")
                {
                    model.Gender = int.Parse(row["Gender"].ToString());
                }
                if (row["QQnumer"] != null)
                {
                    model.QQnumer = row["QQnumer"].ToString();
                }
                if (row["User001"] != null && row["User001"].ToString() != "")
                {
                    model.User001 = int.Parse(row["User001"].ToString());
                }
                if (row["User002"] != null && row["User002"].ToString() != "")
                {
                    model.User002 = long.Parse(row["User002"].ToString());
                }
                if (row["User004"] != null && row["User004"].ToString() != "")
                {
                    model.User004 = int.Parse(row["User004"].ToString());
                }
                if (row["User005"] != null)
                {
                    model.User005 = row["User005"].ToString();
                }
                if (row["User006"] != null)
                {
                    model.User006 = row["User006"].ToString();
                }
                if (row["User007"] != null)
                {
                    model.User007 = row["User007"].ToString();
                }
                if (row["User008"] != null)
                {
                    model.User008 = row["User008"].ToString();
                }
                if (row["User009"] != null)
                {
                    model.User009 = row["User009"].ToString();
                }
                if (row["User010"] != null)
                {
                    model.User010 = row["User010"].ToString();
                }
                if (row["User011"] != null && row["User011"].ToString() != "")
                {
                    model.User011 = decimal.Parse(row["User011"].ToString());
                }
                if (row["User012"] != null && row["User012"].ToString() != "")
                {
                    model.User012 = decimal.Parse(row["User012"].ToString());
                }
                if (row["User013"] != null && row["User013"].ToString() != "")
                {
                    model.User013 = decimal.Parse(row["User013"].ToString());
                }
                if (row["User014"] != null && row["User014"].ToString() != "")
                {
                    model.User014 = decimal.Parse(row["User014"].ToString());
                }
                if (row["User015"] != null && row["User015"].ToString() != "")
                {
                    model.User015 = decimal.Parse(row["User015"].ToString());
                }
                if (row["User016"] != null && row["User016"].ToString() != "")
                {
                    model.User016 = decimal.Parse(row["User016"].ToString());
                }
                if (row["User017"] != null && row["User017"].ToString() != "")
                {
                    model.User017 = decimal.Parse(row["User017"].ToString());
                }
                if (row["User018"] != null && row["User018"].ToString() != "")
                {
                    model.User018 = decimal.Parse(row["User018"].ToString());
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["IsOut"] != null && row["IsOut"].ToString() != "")
                {
                    model.IsOut = int.Parse(row["IsOut"].ToString());
                }
                if (row["Batch"] != null && row["Batch"].ToString() != "")
                {
                    model.Batch = int.Parse(row["Batch"].ToString());
                }
                if (row["SyncIMState"] != null && row["SyncIMState"].ToString() != "")
                {
                    model.SyncIMState = int.Parse(row["SyncIMState"].ToString());
                }
                if (row["SyncIMTime"] != null && row["SyncIMTime"].ToString() != "")
                {
                    model.SyncIMTime = DateTime.Parse(row["SyncIMTime"].ToString());
                }
                if (row["MachineNumLock"] != null && row["MachineNumLock"].ToString() != "")
                {
                    model.MachineNumLock = int.Parse(row["MachineNumLock"].ToString());
                }
            }
            return model;
        } 
        #endregion

        #region 得到一个对象实体（用于商城用户注册）
        /// <summary>
        /// 得到一个对象实体（用于商城用户注册）
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public lgk.Model.tb_user GetModelForShop(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1 * FROM tb_user");
            strSql.Append(" WHERE " + strWhere);
            lgk.Model.tb_user model = new lgk.Model.tb_user();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public lgk.Model.tb_user GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1 * FROM tb_user");
            strSql.Append(" WHERE " + strWhere);
            lgk.Model.tb_user model = new lgk.Model.tb_user();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 根据用户编号得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public lgk.Model.tb_user GetModelByUserCode(string usercode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1 * FROM tb_user");
            strSql.Append(" WHERE UserCode=@UserCode");
            SqlParameter[] parameters = {
					new SqlParameter("@UserCode", SqlDbType.VarChar,50)};
            parameters[0].Value = usercode;

            lgk.Model.tb_user model = new lgk.Model.tb_user();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 根据手机号码得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="PhoneNum"></param>
        /// <returns></returns>
        public lgk.Model.tb_user GetModelByPhoneNum(string PhoneNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1 * FROM tb_user");
            strSql.Append(" WHERE PhoneNum=@PhoneNum");
            SqlParameter[] parameters = {
					new SqlParameter("@PhoneNum", SqlDbType.VarChar,50)};
            parameters[0].Value = PhoneNum;

            lgk.Model.tb_user model = new lgk.Model.tb_user();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 根据给定的会员编号，获取其下面的所有会员。
        /// <summary>
        /// 根据给定的会员编号，获取其下面的所有会员。
        /// </summary>
        /// <param name="iUserID">根据给定的会员编号</param>
        /// <returns></returns>
        public string GetAllChildrenID(long iUserID)
        {
            strSunID = "";//全局变量，上面有定义

            strSunID = GetChildID(iUserID);

            strSunID = strSunID.Substring(0, strSunID.Length - 1);

            return strSunID;
        }
        #endregion

        #region 根据给定的会员编号，获取其下面的所有会员。
        /// <summary>
        /// 根据给定的会员编号，获取其下面的所有会员。
        /// </summary>
        /// <param name="iUserID">给定的会员编号</param>
        /// <returns></returns>
        public string GetChildID(long iUserID)
        {
            string strChildeeID = "", strSunsID = "";

            strChildeeID = GetSunID(iUserID);
            strSunID += strChildeeID + ",";

            string[] strChildID = strChildeeID.Split(',');

            int iLength = strChildID.Length;

            for (int i = 0; i < iLength; i++)
            {
                if (strChildID[i] != "")
                {
                    int m = Convert.ToInt32(strChildID[i]);
                    strSunsID = GetSunID(m);
                    if (strSunsID != "")
                    {
                        GetChildID(m);
                    }
                }
            }
            return strSunID;
        }
        #endregion

        #region 根据给定的栏目编号，获取其下面的子栏目（一级子栏目）。
        /// <summary>
        /// 根据给定的栏目编号，获取其下面的子栏目（一级子栏目）。
        /// </summary>
        /// <param name="iColumnID">给定的栏目编号</param>
        /// <returns></returns>
        public string GetSunID(long iUserID)
        {
            int iCount = 0;
            string strSunID = "";

            SortedList<string, lgk.Model.tb_user> myUser = new SortedList<string, lgk.Model.tb_user>();
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT [UserID] FROM [tb_user]");
            strSql.Append(" WHERE ParentID=@ParentID");
            SqlParameter[] parameters = {
                        new SqlParameter("@ParentID", SqlDbType.BigInt,8)};
            parameters[0].Value = iUserID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lgk.Model.tb_user model = new lgk.Model.tb_user();

                    if (ds.Tables[0].Rows[i]["UserID"] != null && ds.Tables[0].Rows[i]["UserID"].ToString() != "")
                    {
                        model.UserID = long.Parse(ds.Tables[0].Rows[i]["UserID"].ToString());
                        myUser.Add(Convert.ToString(iCount), model);
                        iCount++;
                    }
                }
            }

            iCount = myUser.Count;

            if (iCount > 0)
            {
                for (int i = 0; i < iCount; i++)
                {
                    if (i == iCount - 1)
                    {
                        strSunID += myUser.Values[i].UserID;
                    }
                    else
                    {
                        strSunID += myUser.Values[i].UserID + ",";
                    }
                }
            }
            else
            {
                strSunID = "";
            }

            return strSunID;
        }
        #endregion

        #region 根据给定的会员编号，获取能安置会员的会员编号
        /// <summary>
        /// 根据给定的会员编号，获取能安置会员的会员编号
        /// </summary>
        /// <param name="iParentID"></param>
        /// <returns></returns>
        public long GetPlacementID(long iParentID)
        {
            long iUserID = 0;

            string strUserID = GetAllChildrenID(iParentID);
            if (strUserID != "")
            {
                lgk.Model.tb_user model = new lgk.Model.tb_user();

                string[] arryID = strUserID.Split(',');
                for (int i = 0; i < arryID.Length; i++)
                {
                    model = GetModel(long.Parse(arryID[i]));
                    if (FlagLoc(model.UserID, 1))
                        iUserID = 0;//左区域已有会员
                    else
                    {
                        iUserID = model.UserID;
                        break;
                    }
                }
            }
            else
            {
                iUserID = iParentID;
            }

            return Convert.ToInt64(iUserID);
        }
        #endregion

        public bool FlagLoc(long iParentID, int iLoc)
        {
            bool bFlag = false;
            string strSql = "";
            strSql = @"SELECT COUNT(1) FROM tb_user WHERE UserID =" + iParentID + " AND Location>=8";

            if (Convert.ToInt32(DbHelperSQL.GetSingle(strSql)) > 0)
                bFlag = true;
            else
                bFlag = false;

            return bFlag;
        }

        #region 根据给定的用户编号，获取其能安置下线的位置。
        /// <summary>
        /// 根据给定的用户编号，获取其能安置下线的位置。
        /// </summary>
        /// <param name="iUserID"></param>
        /// <returns></returns>
        public int GetLocation(long iUserID)
        {
            int iLoc = 0;

            int reNum = Convert.ToInt32(DbHelperSQL.GetSingle("select count(*) from tb_user where RecommendID=" + iUserID + ""));
            if (reNum == 0)
                iLoc = 1;
            else
                iLoc = 2;

            return iLoc;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM tb_user");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet RemitGetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT u.UserCode,u.NiceName,r.RemitMoney,r.Remit003,r.Remit004,r.BankName,r.BankAccount,r.BankAccountUser,r.State,r.AddDate,r.RechargeableDate,r.Remark,r.Remit001,r.passdate FROM tb_user u inner join tb_remit r on r.UserID=u.UserID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet RemitToProLevel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT u.UserCode,u.Truename,p.LastLevel,p.EndLevel,p.ProMoney,r.RemitMoney,r.Remit003,r.Remit004,r.BankName,r.BankAccount,r.BankAccountUser,r.State,r.AddDate,r.RechargeableDate,r.Remark,r.Remit001 FROM tb_user u inner join tb_userPro p on p.UserID=u.UserID inner join tb_remit r on r.UserID=u.UserID");
            if(strWhere.Trim()!="")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion

        #region 获得前几行字段
        /// <summary>
        /// 获得前几行字段
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="strField"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListField(int Top, string strField, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");
            if (Top > 0)
            {
                strSql.Append(" TOP " + Top.ToString() + " ");
            }
            strSql.Append(strField);
            strSql.Append(" FROM tb_user ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        /// <summary>
        /// 计算注册金额
        /// </summary>
        public decimal CountRegMoney(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ISNULL(SUM(OrderTotal),0) AS RegMoney");
            strSql.Append(" FROM tb_order ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            decimal dRegMoney = 0;
            if (obj != null)
            {
                decimal.TryParse(obj.ToString(), out dRegMoney);
            }
            return dRegMoney;
        }

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetOpenList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select tb_user.UserID,tb_user.RecommendCode,tb_user.UserCode,tb_user.TrueName,tb_user.LevelID,tb_user.Location,tb_user.GLmoney,tb_user.BillCount,tb_user.NiceName,");
            strSql.Append(@"tb_user.RegMoney,tb_Level.LevelName,tb_user.User006,tb_user.ParentCode,tb_user.User007,tb_user.IsOpend,tb_user.User003,tb_user.User015,tb_user.User001,");
            strSql.Append(@"tb_user.IsLock,tb_user.User002,tb_Level.Level03,tb_user.User008,User004,tb_user.RegTime,tb_user.OpenTime,tb_user.Emoney,tb_user.BonusAccount,");
            strSql.Append(@"tb_user.Email,tb_user.IsOut,tb_user.Batch,tb_user.User005 from tb_user left join tb_Level on tb_user.LevelID=tb_Level.LevelID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetDetailList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select tb_user.UserID,tb_user.UserCode,tb_user.TrueName,tb_user.LevelID,tb_Level.LevelName,tb_user.GLmoney,");
            strSql.Append(@"tb_user.RegMoney,tb_user.BankName,tb_user.BankAccount,tb_user.BankAccountUser,tb_user.IdenCode,tb_user.PhoneNum,");
            strSql.Append(@"tb_user.Address,tb_user.User005,tb_user.NiceName,tb_user.BonusAccount,tb_user.Emoney,tb_user.IsLock,tb_user.IsOpend,");
            strSql.Append(@"tb_user.Email,tb_user.IsOut,tb_user.Batch from tb_user join tb_Level on tb_user.LevelID=tb_Level.LevelID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");
            if (Top > 0)
            {
                strSql.Append(" TOP " + Top.ToString());
            }
            strSql.Append(" *");
            strSql.Append(" FROM tb_user ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" ORDER BY " + filedOrder);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 判断给定的会员是否已开通
        /// <summary>
        /// 判断给定的会员是否已开通
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public bool ExistsIsOpend(long UserID)
        {
            bool bFlag = false;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [IsOpend] FROM tb_user");
            strSql.Append(" WHERE UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = UserID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                bFlag = false;
            }
            else
            {
                int iIsOpend = int.Parse(obj.ToString());
                if (iIsOpend == 2)
                    bFlag = true;
                else
                    bFlag = false;
            }

            return bFlag;
        }
        #endregion

        /// <summary>
        /// 判断给定的父节点和区域是否已有开通的会员
        /// </summary>
        /// <param name="iParentID"></param>
        /// <param name="iLoc"></param>
        /// <returns></returns>
        //public bool FlagLoc(long iParentID, int iLoc)
        //{
        //    bool bFlag = false;
        //    string strSql = "";
        //    strSql = @"SELECT COUNT(0) FROM tb_user WHERE LevelID<8 and G_ParentID=" + iParentID + " AND G_Loaction=" + iLoc;

        //    if (Convert.ToInt32(DbHelperSQL.GetSingle(strSql)) > 0)
        //        bFlag = true;
        //    else
        //        bFlag = false;

        //    return bFlag;
        //}

        #region 获取已开通的父接点
        /// <summary>
        /// 获取已开通的父接点
        /// </summary>
        /// <returns></returns>
        public long GetParentID(long iUserID)
        {
            long iParentID = 0;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [RecommendID] FROM tb_user");
            strSql.Append(" WHERE UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = iUserID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                iParentID = 0;
            }
            else
            {
                iParentID = long.Parse(obj.ToString());
            }

            if (!ExistsIsOpend(iParentID))
                iParentID = GetParentID(iParentID);

            return iParentID;
        }
        #endregion

        #region 根据用户ID获取用户编号
        /// <summary>
        /// 根据用户ID获取用户编号
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public string GetUserCodeByUserID(long iUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT UserCode FROM tb_user");
            strSql.Append(" WHERE UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = iUserID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return "";
            }
        }
        #endregion

        /// <summary>
        /// 判断给定的推荐人和安置人是否在同一条线上。
        /// </summary>
        /// <param name="iRecommendID">给定的推荐人</param>
        /// <param name="iParentID">给定的安置人</param>
        /// <returns></returns>
        public bool OnRecommendSameLine(long iRecommendID, long iUserID)
        {
            bool bFlag = false;

            string strRecommendPathOne = GetRecommendPath(iRecommendID);
            string strRecommendPathTow = GetRecommendPath(iUserID);

            if (strRecommendPathTow.Contains(strRecommendPathOne) || strRecommendPathOne.Contains(strRecommendPathTow))
                bFlag = true;
            else
                bFlag = false;

            return bFlag;
        }

        /// <summary>
        /// 根据给定的用户ID，获取用户路径。
        /// </summary>
        /// <param name="iUserID">给定的用户ID</param>
        /// <returns></returns>
        public string GetRecommendPath(long iUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [RecommendPath] FROM tb_user");
            strSql.Append(" WHERE UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8)};
            parameters[0].Value = iUserID;

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

        #region 更新身份证与真实姓名
        /// <summary>
        /// 更新身份证与真实姓名
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="IdCard"></param>
        /// <param name="RealName"></param>
        /// <returns></returns>
        public bool UpdateIdCardAndTrueName(long UserID, string IdCard, string RealName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_user set ");
            strSql.Append("IdenCode=@IdenCode,TrueName=@TrueName ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
                new SqlParameter("@IdenCode", SqlDbType.VarChar,50),
                new SqlParameter("@TrueName", SqlDbType.VarChar,50),
                new SqlParameter("@UserID", SqlDbType.BigInt)
            };
            parameters[0].Value = IdCard;
            parameters[1].Value = RealName;
            parameters[2].Value = UserID;

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
        #endregion

        #region 注册会员
        /// <summary>
        /// 注册会员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string proc_RegisterUser(lgk.Model.tb_user model)
        {
            object[] obj = DbHelperSQLP.ExecuteSP_Param_Object("proc_RegisterUser", model.UserCode, model.Password, model.SecondPassword, model.LevelID,
                model.RecommendID, model.NiceName, model.TrueName, model.IdenCode, model.PhoneNum, model.User002, model.Location, model.RegTime, "");
            if (obj != null && obj[1] != null)
            {
                return obj[1].ToString();
            }
            else
            {
                return null;
            }
        } 
        #endregion

        #endregion  Method
    }
}

