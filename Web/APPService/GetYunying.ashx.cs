using System.Linq;
using System.Web;
using Library;
using System.Web.Script.Serialization;
using System.Data.SqlClient;
using System.Data;
using Web.APPService.Service;
using Web.APPService.ViewModel;
using System;
using System.Collections.Generic;

namespace Web.APPService
{
    /// <summary>
    /// GetYunying 的摘要说明
    /// </summary>
    public class GetYunying : ServiceHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string result = string.Empty;

            result = GetSuanLiList(context);
            context.Response.Write(result);
        }

        public string GetSuanLiList(HttpContext context)
        { 
            
            AllCore AC = new AllCore();
         
            var model = AC.agent1BLL.GetList(" Flag=1 ").Tables[0]; 
            List<GetModel> list = new List<GetModel>();
            for (int i = 0; i < model.Rows.Count; i++)
            {
                list.Add(new GetModel { UserCode = model.Rows[i]["AgentCode"].ToString()});

            } 
            return ResultJson(ResultType.success, "", list);
        }
        public class GetModel
        {
            public string UserCode { get; set; }
        


        }

    }
}