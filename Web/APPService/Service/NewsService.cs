using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Web.APPService.Service
{
    public class NewsService : AllCore
    {
        public List<NoticeModel> NoticList()
        {
            string strWhere1 = "1=1";

            var dt = newsBLL.GetList(strWhere1);

            return DataTableToList(dt.Tables[0]);
        }
        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<NoticeModel> DataTableToList(DataTable dt)
        {
            List<NoticeModel> modelList = new List<NoticeModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NoticeModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NoticeModel();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = dt.Rows[n]["ID"].ToString();
                    }
                    if (dt.Rows[n]["NewsContent"] != null && dt.Rows[n]["NewsContent"].ToString() != "")
                    {
                        model.NewsContent = dt.Rows[n]["NewsContent"].ToString();
                    }
                    if (dt.Rows[n]["NewsTitle"] != null && dt.Rows[n]["NewsTitle"].ToString() != "")
                    {
                        model.NewsTitle = dt.Rows[n]["NewsTitle"].ToString();
                    }
                    if (dt.Rows[n]["PublishTime"] != null && dt.Rows[n]["PublishTime"].ToString() != "")
                    {
                        model.PublishTime = dt.Rows[n]["PublishTime"].ToString();
                    }
                    if (dt.Rows[n]["Publisher"] != null && dt.Rows[n]["Publisher"].ToString() != "")
                    {
                        model.Publisher = dt.Rows[n]["Publisher"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion
        public NoticeModel NoticeDetail(int id)
        {
            lgk.Model.tb_news newInfo = newsBLL.GetModel(Convert.ToInt64(id));
            NoticeModel news = new NoticeModel();
            news.ID = newInfo.ID.ToString();
            news.NewsTitle = newInfo.NewsTitle;
            news.NewsContent = newInfo.NewsContent;
            news.PublishTime = newInfo.PublishTime.ToString();
            news.Publisher = newInfo.Publisher;
            return news;
        }
       
    }
}