using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Web.APPService.ViewModel;

namespace Web.APPService.Service
{
    public class IndexService : AllCore
    {

        public List<IndexModel> IndexList()
        {
            DataTable dt = new lgk.BLL.tb_Link().GetList( "Link001=2", "Status desc").Tables[0];
             return DataTableToList(dt); ;
        }

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<IndexModel> DataTableToList(DataTable dt)
        {
            List<IndexModel> modelList = new List<IndexModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                IndexModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new IndexModel();
                    if (dt.Rows[n]["LinkImage"] != null && dt.Rows[n]["LinkImage"].ToString() != "")
                    {
                        model.LinkUrl = WebHelper.HttpDomain + "/upload/Banner/" + dt.Rows[n]["LinkImage"].ToString();
                    }
                  
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

        //释放币值
        public object Poly(long userid, out string message)
        {
            lgk.Model.tb_user userInfo = userBLL.GetModel(userid);

            SortedDictionary<string, object> values = new SortedDictionary<string, object>();
            values.Add("BonusAccount", userInfo.BonusAccount.ToString("0.00"));
            values.Add("exchange", getParamAmount("Exchange"));
            values.Add("Emoney", userInfo.Emoney.ToString("0.00"));
            values.Add("SafeAccount", userInfo.User017.ToString("0.00"));

            message = "";
            return values;
        }

    }
}