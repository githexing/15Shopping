using Library;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Web.APPService.Service;
 
namespace Web.user.Ticket
{
    public partial class TicketList : System.Web.UI.Page
    {
        public string fromcityname, tocityname,type,fromtime, toomtime;
        public TicketService tServer=new TicketService();
        protected void Page_Load(object sender, EventArgs e)
        {
            fromcityname = Request.Form["formcityname"].ToString();
            tocityname = Request.Form["tocityname"].ToString();
            type = Request.Form["type"].ToString();
            ticket_formdate.Value= fromtime = Request.Form["fromtime"].ToString();
            ticket_todate.Value=toomtime = Request.Form["tomtime"].ToString();
            from_code.Value = Request.Form["fromcode"].ToString();
            to_code.Value = Request.Form["tocode"].ToString();
          

        //    Dictionary<string, object> dic = new Dictionary<string, object>();
        //    dic.Add("act", "getfligtlistweb");
        //    dic.Add("action", "getfligtlistweb");
        //    dic.Add("depdate", Request["fromtime"].ToString());
        //    dic.Add("depcity", Request["fromcode"].ToString());
        //    dic.Add("arrcity", Request["tocode"].ToString());
        //    dic.Add("aircode", "");
        //    string spond = tServer.RequestBegin(dic);
        //    dynamic dy = ConvertJson(spond);
        //    //航班日期
        //    var Days = dy.result.D;
        //    //机场信息
        //    var Plays = dy.result.P;
        //    //航空公司信息
        //    var Airs = dy.result.A;
        //    //航班信息列表
        //    var Fltnums = dy.result.F;
        //    //航班仓位信息列表
        //    var fltsps = dy.result.H;
        //    //退改签信息列表
        //    var Exits = dy.result.T;
           
        //   // Response.Write(dy.successcode);
        //}
        //public static dynamic ConvertJson(string json)
        //{
        //    JavaScriptSerializer jss = new JavaScriptSerializer();
        //    jss.RegisterConverters(new JavaScriptConverter[] { new DynamicJsonConverter() });
        //    dynamic dy = jss.Deserialize(json, typeof(object)) as dynamic;
        //    return dy;
        //}
    }
  public string FlightNum { set; get; }
    }
    //public class DynamicJsonConverter : JavaScriptConverter
    //{
    //    public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
    //    {
    //        if (dictionary == null)
    //            throw new ArgumentNullException("dictionary");

    //        if (type == typeof(object))
    //        {
    //            return new DynamicJsonObject(dictionary);
    //        }

    //        return null;
    //    }

    //    public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override IEnumerable<Type> SupportedTypes
    //    {
    //        get { return new ReadOnlyCollection<Type>(new List<Type>(new Type[] { typeof(object) })); }
    //    }
    //}
    //public class DynamicJsonObject : DynamicObject
    //{
    //    private IDictionary<string, object> Dictionary { get; set; }

    //    public DynamicJsonObject(IDictionary<string, object> dictionary)
    //    {
    //        this.Dictionary = dictionary;
    //    }

    //    public override bool TryGetMember(GetMemberBinder binder, out object result)
    //    {
    //        result = this.Dictionary[binder.Name];

    //        if (result is IDictionary<string, object>)
    //        {
    //            result = new DynamicJsonObject(result as IDictionary<string, object>);
    //        }
    //        else if (result is ArrayList && (result as ArrayList) is IDictionary<string, object>)
    //        {
    //            result = new List<DynamicJsonObject>((result as ArrayList).ToArray().Select(x => new DynamicJsonObject(x as IDictionary<string, object>)));
    //        }
    //        else if (result is ArrayList)
    //        {
    //            result = new List<object>((result as ArrayList).ToArray());
    //        }

    //        return this.Dictionary.ContainsKey(binder.Name);
    //    }
    //}

}