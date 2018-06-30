/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-5-17 15:59:27 
 * 文 件 名：		zhuye.cs 
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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;

namespace Web.admin
{
    public partial class zhuye : AdminPageBase//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
 

        protected void lbtnSettle_Click(object sender, EventArgs e)
        {
            int iResult = bonusBLL.ExecProcedure("proc_bonusPay");

            if (iResult == 1)
            {
                MessageBox.Show(this, "奖金发放成功！");
            }
            else if (iResult == 0)
            {
                MessageBox.Show(this, "所有奖金已发放！");
            }
            else if (iResult == -1)
            {
                MessageBox.Show(this, "奖金发放失败！");
            }
        }

        protected void lbtnShareOut_Click(object sender, EventArgs e)
        {
            
            System.Data.SqlClient.SqlParameter[] param = {
                new System.Data.SqlClient.SqlParameter("@IsAuto",SqlDbType.Int,4)
            };
            param[0].Value = 1;//手动
            int iResult = bonusBLL.ExecProcedure("proc_Award_ShareBonus", param);

            if (iResult == 1)
            {
                MessageBox.Show(this, "发放日分红成功！");
            }
            else if (iResult == -1)
            {
                MessageBox.Show(this, "发放日分红失败！");
            }

           
        }

        protected void lbtnBuy_Click(object sender, EventArgs e)
        {
            //proc_StockBuyAuto
            if (stockIssueBLL.Exists())
            {
                int iResult = bonusBLL.ExecProcedure("proc_StockBuyAuto");

                if (iResult >= 0)
                {
                    MessageBox.Show(this, "购买成功！");
                }
                else
                {
                    MessageBox.Show(this, "购买失败！");
                }
            }
            else
            {
                MessageBox.Show(this, "股票未发行，请发行再试！");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            int iResult = bonusBLL.exExecProcedure("ClearPrice");

            if (iResult == 1)
            {
                MessageBox.Show(this, "清空成功！");
            }
            else if (iResult == 2)
            {
                MessageBox.Show(this, "清空失败！，条件不满足");
            }else if (iResult == -1)
            {
                MessageBox.Show(this, "存储过程异常！");
            }
        }
    }
}
