using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.APPService.Service;

namespace Web
{
    public partial class tt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtip.Text =  Request.ServerVariables.Get("Local_Addr").ToString();
        }

        protected void btnParse_Click(object sender, EventArgs e)
        {

            try
            {
                string respon = "{\"reason\":\"查询订单状态成功\",\"result\":{\"orderid\":\"JH152274297936739\",\"user_orderid\":\"ZX201804031609\",\"msg\":\"订单提交成功，正在处理\",\"orderamount\":\"\",\"status\":\"0\",\"passengers\":[{\"passengerid\":1,\"passengersename\":\"陆志英\",\"piaotype\":1,\"piaotypename\":\"成人票\",\"passporttypeseid\":1,\"passporttypeseidname\":\"二代身份证\",\"passportseno\":\"45212619821225061X\",\"price\":\"5.5\",\"zwcode\":\"O\",\"zwname\":\"二等座\",\"insurance\":[]}],\"checi\":\"D3920\",\"ordernumber\":\"\",\"submit_time\":\"2018-04-03 16:09:39\",\"deal_time\":\"\",\"cancel_time\":\"\",\"pay_time\":\"\",\"finished_time\":\"\",\"refund_time\":\"\",\"juhe_refund_time\":\"\",\"start_time\":\"\",\"arrive_time\":\"\",\"runtime\":\"\",\"train_date\":\"2018-04-03\",\"from_station_name\":\"南宁\",\"from_station_code\":\"NNZ\",\"to_station_name\":\"南宁东\",\"to_station_code\":\"NFZ\",\"refund_money\":\"\"},\"error_code\":0}";
                JsonConvert.DeserializeObject<OrderQuery>(respon);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}