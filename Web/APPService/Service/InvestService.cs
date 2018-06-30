using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Web.APPService.ViewModel;

namespace Web.APPService.Service
{
    public class InvestService :AllCore
    {
        public bool Invest(long userid, int num,string paypassword,out string message)
        {
            var user = userBLL.GetModel(userid);
            if (user == null)
            {
                message = "用户ID不存在";
                return false;
            }
            
            if (!ValidPassword(user.SecondPassword, paypassword))
            {
                message = "支付密码错误";
                return false;
            }

            if (user.IsLock == 1)
            {
                message = "账户已冻结，购买失败";
                return false;
            }

            decimal price = getParamAmount("InvestPrice");
            decimal amount = price * num;
            if (user.Emoney < amount)
            {
                message =  "原始币余额不足";//原始币余额不足
                return false;
            }

            //string maxdate = GetInvestMaxDate(LoginUser.UserID);
            //if (!string.IsNullOrEmpty(maxdate))
            //{
            //    int InvestPrimaryInterval = getParamInt("InvestPrimaryInterval");
            //    if (DateTime.Now.Subtract(DateTime.Parse(maxdate)).TotalHours < InvestPrimaryInterval) //用投资积分投单每 3 天投一单)
            //    {
            //        MessageBox.ShowBox(this.Page, string.Format("用投资积分投单每{0}小时投一单", InvestPrimaryInterval), Library.Enums.ModalTypes.warning);//用投资积分投单每 3 天投一单
            //        return;
            //    }
            //}

            //decimal lastMaxAmount = GetInvestMaxAmount(LoginUser.UserID);
            //if (InvestPrimaryAmount < lastMaxAmount)
            //{
            //    MessageBox.ShowBox(this.Page, GetLanguage("MustLastMaxAmount"), Library.Enums.ModalTypes.warning);//额度要大于或者等于上次投资的额度。
            //    return;
            //}

            int flag = proc_BuyMachine(user.UserID, num);

            if (flag == 2)
            {
                message = "购买成功";
                return true;
            }
            else
            {
                message = "购买失败";
                return false;
            }
        }

        public object InvestList(long userid, int PageIndex, int PageSize, string FindKey)
        {
            lgk.BLL.tb_BuyMachine buyMachineBLL = new lgk.BLL.tb_BuyMachine();

            int PageCount;
            int TotalCount;

            //PageCount 总页数
            //TotalCount 总记录数
            var ds = buyMachineBLL.GetListByPage(userid, PageIndex, PageSize, out PageCount, out TotalCount, FindKey);

            var list = FillBuyMachineList(ds.Tables[0]);

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("pagecount", PageCount.ToString());
            dic.Add("totalcount", TotalCount.ToString());
            dic.Add("list", list);

            return dic;


            //var list = buyMachineBLL.GetModelList("userid ="+userid);
            //return list.Select(s => new { s.Price,s.Num, s.Amount, s.BuyTime ,s.CalcPower }).OrderByDescending(s=>s.BuyTime).ToList();
        }

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BuyMachineListModel> FillBuyMachineList(DataTable dt)
        {
            List<BuyMachineListModel> modelList = new List<BuyMachineListModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BuyMachineListModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new BuyMachineListModel();
                    if (dt.Rows[n]["Price"] != null && dt.Rows[n]["Price"].ToString() != "")
                    {
                        model.Price = dt.Rows[n]["Price"].ToString();
                    }
                    if (dt.Rows[n]["Num"] != null && dt.Rows[n]["Num"].ToString() != "")
                    {
                        model.Num = dt.Rows[n]["Num"].ToString();
                    }
                    if (dt.Rows[n]["Amount"] != null && dt.Rows[n]["Amount"].ToString() != "")
                    {
                        model.Amount = dt.Rows[n]["Amount"].ToString();
                    }

                    if (dt.Rows[n]["BuyTime"] != null && dt.Rows[n]["BuyTime"].ToString() != "")
                    {
                        model.BuyTime = dt.Rows[n]["BuyTime"].ToString();
                    }
                    if (dt.Rows[n]["CalcPower"] != null && dt.Rows[n]["CalcPower"].ToString() != "")
                    {
                        model.CalcPower = dt.Rows[n]["CalcPower"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BuyMachineActiveListModel> FillBuyMachineActiveList(DataTable dt)
        {
            List<BuyMachineActiveListModel> modelList = new List<BuyMachineActiveListModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BuyMachineActiveListModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new BuyMachineActiveListModel();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = dt.Rows[n]["ID"].ToString();
                    }
                    
                    if (dt.Rows[n]["BuyTime"] != null && dt.Rows[n]["BuyTime"].ToString() != "")
                    {
                        model.BuyTime = DateTime.Parse(dt.Rows[n]["BuyTime"].ToString()).ToShortDateString();   
                    }
                    if (dt.Rows[n]["IsActive"] != null && dt.Rows[n]["IsActive"].ToString() != "")
                    {
                        model.IsActive = dt.Rows[n]["IsActive"].ToString();
                    }
                    model.ActiveTime = "";

                    if (model.IsActive == "0")
                    {
                        model.StateText = "未激活";
                    }
                    else if (model.IsActive == "1")
                    {
                        model.StateText = "已激活";
                        if (dt.Rows[n]["ActiveTime"] != null && dt.Rows[n]["ActiveTime"].ToString() != "")
                        {
                            model.ActiveTime = DateTime.Parse(dt.Rows[n]["ActiveTime"].ToString()).ToShortDateString();
                        }
                    }
                    else if (dt.Rows[n]["IsTransfer"].ToString() =="1")
                    {
                        model.StateText = "已转让";
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

        public decimal GetMachinePrice( )
        {
            decimal price = getParamAmount("InvestPrice"); ;
            return price;
        }

        public bool TransferMachine(long userid, string ToUserCode, int num, string paypwd, out string message)
        {
            long ToUserID = userBLL.GetUserID(ToUserCode);
            if (ToUserID <= 0)
            {
                message = "转入对象不存在";
                return false;
            }

            lgk.Model.tb_user userModel = userBLL.GetModel(userid);
            
            if (!ValidPassword(userModel.SecondPassword, paypwd))
            {
                message = "支付密码错误";
                return false;
            }

            string remsg = transferMachineBLL.proc_Transfer_Machine(userid, ToUserID, num);
            if (remsg == "ok")
            {
                message = "矿机转移成功";
                return true;
            }
            else if (!string.IsNullOrEmpty(remsg))
            {
                message = remsg;
                return false;
            }
            else
            {
                message = "转移失败";
                return false;
            }
        }

        public List<TransferMachineModel> GetListByPage(long UserID, int PageIndex, int PageSize, out int PageCount, out int TotalCount, string FindKey)
        {
            DataSet ds = transferMachineBLL.GetListByPageProc(UserID, PageIndex, PageSize, out PageCount, out TotalCount, FindKey);
            return TransferMachineList(ds.Tables[0]);
        }

        public List<TransferMachineModel> TransferMachineList(DataTable dt)
        {
            List<TransferMachineModel> modelList = new List<TransferMachineModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TransferMachineModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TransferMachineModel();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = Convert.ToInt64(dt.Rows[n]["ID"]);
                    }
                    if (dt.Rows[n]["TransferNum"] != null && dt.Rows[n]["TransferNum"].ToString() != "")
                    {
                        model.Number = Convert.ToInt32(dt.Rows[n]["TransferNum"]);
                    }
                    if (dt.Rows[n]["TypeName"] != null && dt.Rows[n]["TypeName"].ToString() != "")
                    {
                        model.TypeName = dt.Rows[n]["TypeName"].ToString();
                    }
                    if (dt.Rows[n]["Remark"] != null && dt.Rows[n]["Remark"].ToString() != "")
                    {
                        model.Remark = dt.Rows[n]["Remark"].ToString(); 
                    }
                    if (dt.Rows[n]["TransferTime"] != null && dt.Rows[n]["TransferTime"].ToString() != "")
                    {
                        model.TransferTime = dt.Rows[n]["TransferTime"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        //激活列表
        public object ActiveList(long userid, int PageIndex, int PageSize, string FindKey)
        {
            lgk.BLL.tb_BuyMachine buyMachineBLL = new lgk.BLL.tb_BuyMachine();

            int PageCount;
            int TotalCount;

            //PageCount 总页数
            //TotalCount 总记录数
            var ds = buyMachineBLL.GetListActiveByPage(userid, PageIndex, PageSize, out PageCount, out TotalCount, FindKey);

            var list = FillBuyMachineActiveList(ds.Tables[0]);

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("pagecount", PageCount.ToString());
            dic.Add("totalcount", TotalCount.ToString());
            dic.Add("list", list);

            return dic;


            //var list = buyMachineBLL.GetModelList("userid ="+userid);
            //return list.Select(s => new { s.Price,s.Num, s.Amount, s.BuyTime ,s.CalcPower }).OrderByDescending(s=>s.BuyTime).ToList();
        }

        //激活列表
        public object GetInfo(long userid)
        {
           // string ActiveNum, NotActiveNum;
            //lgk.BLL.tb_BuyMachine buyMachineBLL = new lgk.BLL.tb_BuyMachine();

            // buyMachineBLL.GetInfo(userid, out ActiveNum, out NotActiveNum);
            lgk.Model.tb_user userModel = userBLL.GetModel(userid);

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("ActiveNum", userModel.User004);
            dic.Add("NotActiveNum", userModel.MachineNumLock);

            return dic;
        }

        //激活
        public bool Active(long userid, long machineid, out string message)
        {
            message = "";

            long ID = machineid;
            lgk.Model.tb_MachineDetail machineModel = machineDetailBLL.GetModel(ID);
            if (machineModel == null)
            {
                message = "该条记录不存在";
                return false;
            }
            lgk.Model.tb_user userModel = userBLL.GetModel(userid);
            if (string.IsNullOrEmpty(userModel.IdenCode))
            {
                message = "需先验证身份证，才能激活矿机";
                return false;
            }

            if (machineModel.IsActive == 1)
            {
                message = "该记录已激活，无需再激活";
                return false;
            }
            if (machineModel.IsTransfer == 1)
            {
                message = "该记录已转让，不能激活";
                return false;
            }
            int result = machineDetailBLL.proc_MachineActive(machineModel.ID);

            if (result == 2)
            {
                message = "激活成功";
                return true;
            }
            else
            {
                message = "激活失败";
                return false;
            }

        }
    }
}