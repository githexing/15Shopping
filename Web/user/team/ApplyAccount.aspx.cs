using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web.user.team
{
    public partial class ApplyAccount : PageCore
    {
        public decimal p_amount = 0; //投资额度
        public int p_recnum = 0; //直推人数
        public int p_trans = 0; //释放币

        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();

            if (!IsPostBack)
            {
                btnApply.Text = GetLanguage("ApplyOpenAccount");//开通分号
            }
        }

        private void BindData()
        {
            p_amount = getParamAmount("SecondAccountAmount"); //投资额度
            p_recnum = getParamInt("SecondAccountRecNum"); //直推人数
            p_trans = getParamInt("SecondAccountTransCode"); //释放币
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            var usermodel = userBLL.GetModel(LoginUser.UserID);
            if(usermodel.User001 == 1)
            {
                MessageBox.ShowBox(this.Page,"您已开通分号", Library.Enums.ModalTypes.info);//您已开通分号
                return;
            }

            if (usermodel.IsOpend == 0)
            {
                MessageBox.ShowBox(this.Page, GetLanguage("AccountNoActiveInfo"), Library.Enums.ModalTypes.error);//您的帐号未激活
                return;
            }

            if (usermodel.IsLock == 1)
            {
                MessageBox.ShowBox(this.Page, GetLanguage("AccountLock"), GetLanguage("AccountLockInfo"), Library.Enums.ModalTypes.error);//您的帐号已冻结，不能进行操作
                return;
            }
            decimal amount = GetInvestAmount(LoginUser.UserID);
            if (amount < p_amount)
            {
                MessageBox.ShowBox(this.Page,"投资额度不足", Library.Enums.ModalTypes.warning);//投资额度不足
                return;
            }

            int recnum = usermodel.User003;
            if (recnum < p_recnum)
            {
                MessageBox.ShowBox(this.Page,"直推人数不足", Library.Enums.ModalTypes.warning);//直推人数不足
                return;
            }

            decimal trans = usermodel.ShopAccount;
            if (trans < p_trans)
            {
                MessageBox.ShowBox(this.Page,"释放币不足", Library.Enums.ModalTypes.warning);//释放币不足
                return;
            }

            usermodel.User001 = 1;
            userBLL.Update(usermodel);

            UpdateAccount("ShopAccount", usermodel.UserID, trans, 0);//
            //加入流水账表(现金币增加)
            lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal()
            {
                UserID = usermodel.UserID,
                Remark = "开通分号使用释放币",
                RemarkEn = "Open Account ",
                InAmount = 0,
                OutAmount = p_trans,
                BalanceAmount = userBLL.GetMoney(usermodel.UserID, "ShopAccount"),
                JournalDate = DateTime.Now,
                JournalType = 2,
                Journal01 = usermodel.UserID
            };
            journalBLL.Add(journalInfo);

            #region 日志
            string ip = Page.Request.UserHostAddress;

            lgk.Model.SysLog log = new lgk.Model.SysLog();//日志
            lgk.BLL.SysLog syslogBLL = new lgk.BLL.SysLog();
            log.LogMsg = "";
            log.LogType = 22;//
            log.LogLeve = 0;//
            log.LogDate = DateTime.Now;
            log.LogCode = "开通分号";//
            log.IsDeleted = 0;
            log.Log1 = usermodel.UserID.ToString();//用户UserID
            log.Log2 = ip;// 
            log.Log3 = "";
            log.Log4 = "";
            syslogBLL.Add(log);
            #endregion
            MessageBox.ShowBox(this.Page,"开通分号成功", Library.Enums.ModalTypes.success);//开通分号成功
        }
    }
}