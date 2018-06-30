using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.APPService.Service;

namespace Web.APPService
{
    /// <summary>
    /// Mall 的摘要说明
    /// </summary>
    public class Mall : ServiceHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string result = string.Empty;

            string str_act = context.Request["act"].ToString();
            switch (str_act)
            {
                case "minus":
                    result = NumManage(context, 1);
                    break;
                case "add":
                    result = NumManage(context, 2);
                    break;
                case "pay":
                    result = GoodsCartPay(context);
                    break;
                case "buy":
                    result = GoodsCartAdd(context);
                    break;
                case "del":
                    result = GoodsCartDel(context);
                    break;
                default:
                    result = ResultJson(ResultType.error, "参数异常", "Invest");
                    break;
            }
            context.Response.Write(result);
        }

        #region 购物车添加管理
        /// <summary>
        /// 购物车添加管理
        /// </summary>
        /// <param name="context"></param>
        /// <param name="iType"></param>
        public string GoodsCartAdd(HttpContext context)
        {
            string struserid = context.Request.Params["uid"].ToString();
            string strgid = context.Request.Params["gid"].ToString();
            string strbuynum = (context.Request.Params["buynum"] ?? "1").ToString();

            #region 用户ID
            long userid;
            if (string.IsNullOrEmpty(struserid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            if (!long.TryParse(struserid, out userid))
            {
                return ResultJson(ResultType.error, "请输入有效的用户ID", "");
            }
            #endregion

            #region 产品ID
            long goodsid;
            if (!long.TryParse(strgid, out goodsid))
            {
                return ResultJson(ResultType.error, "请输入有效的商品id", "");
            }
            #endregion

            #region 产品ID
            int buynum;
            if (!int.TryParse(strbuynum, out buynum))
            {
                return ResultJson(ResultType.error, "请输入有效的购买数量", "");
            }
            if (buynum <= 0)
            {
                return ResultJson(ResultType.error, "购买数量必须大于0", "");
            }
            #endregion

            string message = string.Empty;
            MallService svc = new MallService();
            bool result = svc.AddGoodCar(userid, goodsid, buynum, out message);
            if (result)
            {
                return ResultJson(ResultType.success, message, "");
            }
            else
                return ResultJson(ResultType.error, message, "");
        }
        #endregion

        #region 购物车数量管理
        /// <summary>
        /// 购物车数量管理
        /// </summary>
        /// <param name="context"></param>
        /// <param name="iType"></param>
        public string NumManage(HttpContext context, int type)
        {
            string strcid = context.Request.Params["cartid"].ToString();

            long id = 0;
            if (!long.TryParse(strcid, out id))
            {
                return ResultJson(ResultType.error, "传递的数据错误", "");
            }
            
            string message = string.Empty;
            MallService svc = new MallService();
            bool result = svc.NumManage(id, type, out message);
            if (result)
            {
                return ResultJson(ResultType.success, message, "");
            }
            else
                return ResultJson(ResultType.error, message, "");
        }
        #endregion

        #region 购物车支付管理
        /// <summary>
        /// 购物车支付管理
        /// </summary>
        /// <param name="context"></param>
        /// <param name="iType"></param>
        public string GoodsCartPay(HttpContext context)
        {
            string strcid = context.Request.Params["cartidlist"].ToString();
            string struserid = context.Request.Params["uid"].ToString(); 
            string strtype = context.Request.Params["paytype"].ToString();
            string straddrid = context.Request.Params["addrid"].ToString();
            string Checked = context.Request.Params["checked"].ToString();

            #region 支付方式
            string[] a = Checked.Split('-');
            if (a.Count()!=2)
            {
                return ResultJson(ResultType.error, "支付方式不正确", "");
            }
            int X;//类型
            if (!int.TryParse(a[0],out X))
            {
                return ResultJson(ResultType.error, "支付方式不正确", "");
            }
            if (X!=1 && X!=2 && X != 3 && X != 4)
            {
                return ResultJson(ResultType.error, "支付方式不正确", "");
            }
            int XX;//选项
            if (!int.TryParse(a[1], out XX))
            {
                return ResultJson(ResultType.error, "支付方式不正确", "");
            }
            if (XX != 1 && XX != 2)
            {
                return ResultJson(ResultType.error, "支付方式不正确", "");
            }
            //int XXX;//送货
            //if (!int.TryParse(a[3], out XXX))
            //{
            //    return ResultJson(ResultType.error, "送货方式不正确", "");
            //}
            //if (XXX != 1 && XXX != 2)
            //{
            //    return ResultJson(ResultType.error, "送货方式不正确", "");
            //}
            string aa = a[0] + "-" + a[1];//复投方式-支付方式-运营中心-送货方式
            #endregion


            #region 用户ID
            long userid;
            if (string.IsNullOrEmpty(struserid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            if (!long.TryParse(struserid, out userid))
            {
                return ResultJson(ResultType.error, "请输入有效的用户ID", "");
            }
            #endregion

            #region 支付类型
            int paytype;
            if (string.IsNullOrEmpty(strtype))
            {
                return ResultJson(ResultType.error, "请输入支付类型", "");
            }
            if (!int.TryParse(strtype, out paytype))
            {
                return ResultJson(ResultType.error, "请输入有效的支付类型", "");
            }
            #endregion

            #region 收货地址ID
            long addrid;
            if (string.IsNullOrEmpty(straddrid))
            {
                return ResultJson(ResultType.error, "请选择收货地址", "");
            }
            if (!long.TryParse(straddrid, out addrid))
            {
                return ResultJson(ResultType.error, "请选择收货地址", "");
            }
            #endregion

            string message = string.Empty;
            MallService svc = new MallService();
            bool result = svc.GoodsCartPay(userid, paytype, addrid, strcid, aa, out message);
            if (result)
            {
                return ResultJson(ResultType.success, message, "");
            }
            else
                return ResultJson(ResultType.error, message, "");
        }
        #endregion

        #region 删除购物车
        /// <summary>
        /// 删除购物车
        /// </summary>
        /// <param name="context"></param>
        public string GoodsCartDel(HttpContext context)
        {
            string strcid = context.Request.Params["cartid"].ToString();
            
            long id = 0;
            if (!long.TryParse(strcid, out id))
            {
                return ResultJson(ResultType.error, "传递的数据错误", "");
            }
            
            string message = string.Empty;
            MallService svc = new MallService();
            bool result = svc.GoodsCartDel(id, out message);
            if (result)
            {
                return ResultJson(ResultType.success, message, "");
            }
            else
                return ResultJson(ResultType.error, message, "");
        }
        #endregion

    }
}