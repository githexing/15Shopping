using Library;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.APPService.Service;

namespace Web.APPService
{
    /// <summary>
    /// TrainTickets 的摘要说明
    /// </summary>
    public class TrainTickets : ServiceHandler
    {
        lgk.BLL.tb_CityCode city = new lgk.BLL.tb_CityCode();
        TrainTicketsService tts = new TrainTicketsService();
        public override void ProcessRequest(HttpContext context)
        {
            string train = context.Request["act"];
            string result = string.Empty;
            if (string.IsNullOrEmpty(train) || train.Trim() == string.Empty)
            {
                return;
            }
            else if (train.Equals("QueryCity"))
            {
                QueryCity(context);
            }
            else
            {
                result =RespondHandle(context);
            }
           
            context.Response.Write(result);
        }
        #region 选择城市
        /// <summary>
        /// 选择城市
        /// </summary>
        /// <param name="context"></param>
        public void QueryCity(HttpContext context)
        {
            try
            {
                string query = context.Request["query"].ToString().Trim();
                string rm = context.Request["str"].ToString().Trim();
                if (rm.Equals("热门"))
                {
                    context.Response.Write("[{\"name\":\"北京\",\"code\":\"BJP\"},{\"name\":\"上海\",\"code\":\"SHH\"},{\"name\":\"成都\",\"code\":\"CDW\"},{\"name\":\"重庆北\",\"code\":\"CUW\"},{\"name\":\"广州\",\"code\":\"GZQ\"}]");
                }
                else
                {
                    string str = "[";
                    List<lgk.Model.tb_CityCode> model = city.GetModelList(query);
                    if (model.Count > 0)
                    {
                        for (int i = 0; i < model.Count; i++)
                        {
                            str += "{\"name\":\"" + model[i].Name + "\",\"code\":\"" + model[i].Code + "\"}";
                            if (i != model.Count - 1)
                            {
                                str += ",";
                            }
                        }
                        str += "]";
                        context.Response.Write(str);
                    }
                    else
                    {
                        context.Response.Write("[{\"name\":\"没有找到相关数据\",\"code\":\"NONE\"}]");
                    }
                }
            }
            catch (Exception)
            {
                context.Response.Write("[{\"name\":\"没有找到相关数据\",\"code\":\"NONE\"}]");
            }
        }
        #endregion
        #region 处理接口请求响应数据
        /// <summary>
        /// 站点简码查询
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string RespondHandle(HttpContext context)
        {
            try
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                for (int i = 0; i < context.Request.Params.Count; i++)
                {
                    dic.Add(context.Request.Params.Keys[i].ToString(), context.Request.Params[i].ToString());//将请求参数添加到Dictionary<string, string>用作接口参数的遍历赋值
                }
                string responresult = tts.RequestBegin(dic);
                if (responresult != "error")
                {
                    var emResult = JsonConvert.DeserializeObject<respondResult>(responresult);
                    //string result = CheckCode(emResult.error_code);
                    if (emResult.error_code.Equals("0"))
                        return ResultJson(ResultType.success, "执行成功", responresult);
                    else if (emResult.error_code.Equals("1"))
                        return ResultJson(ResultType.error, "执行失败", emResult.info);
                    else 
                        return ResultJson(ResultType.error, "执行失败", emResult.reason);
                }
                else
                {
                    return ResultJson(ResultType.error, "执行失败", responresult);
                }
            }
            catch (Exception ex)
            {

                return ResultJson(ResultType.error, "执行失败", "系统异常，异常信息："+ex.Message);
            }
            
            //return result;
        }
        #endregion
        #region 返回代码
        /// <summary>
        /// 错误代码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string CheckCode(string code)
        {
            string result = "";
            switch (code)
            {
                case "217300":
                    result = "网络错误或内部错误";
                    break;
                case "217301":
                    result = "参数错误";
                    break;
                case "217302":
                    result = "订单处理错误或查询错误";
                    break;
                case "217303":
                    result = "无此订单号";
                    break;
                case "217304":
                    result = "只有占座成功的订单才可以支付";
                    break;
                case "217305":
                    result = "不存在这个站点";
                    break;
                case "217306":
                    result = "您输入的乘车日期有误，不在可预订日期范围内";
                    break;
                case "217307":
                    result = "您提交的无效订单较多，请两个小时后再试";
                    break;
                case "10001":
                    result = "错误的请求KEY";
                    break;
                case "10002":
                    result = "该KEY无请求权限";
                    break;
                case "10003":
                    result = "KEY过期";
                    break;
                case "10004":
                    result = "错误的OPENID";
                    break;
                case "10005":
                    result = "应用未审核超时，请提交认证";
                    break;
                case "10007":
                    result = "未知的请求源";
                    break;
                case "10008":
                    result = "被禁止的IP";
                    break;
                case "10009":
                    result = "被禁止的KEY";
                    break;
                case "10011":
                    result = "当前IP请求超过限制";
                    break;
                case "10012":
                    result = "请求超过次数限制";
                    break;
                case "10013":
                    result = "测试KEY超过请求限制";
                    break;
                case "10014":
                    result = "系统内部异常";
                    break;
                case "10020":
                    result = "接口维护";
                    break;
                case "10021":
                    result = "接口停用";
                    break;
                default:
                    result = "success";
                    break;
            }
            return result;
        }
        #endregion
    }
    public class respondResult
    {
        public string reason { set; get; }
        public string error_code { set; get; }
        public string info { set; get; }
    }
}