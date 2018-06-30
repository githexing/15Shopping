using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Web.APPService.Service
{
    public class MallService : AllCore
    {
        static string sconn = System.Configuration.ConfigurationManager.AppSettings["SocutDataLink"];
        #region 购买
        public bool GoodsCartPay(long userid, int paytype, long addrid, string strcid, string aa, out string msg)
        {
            string[] arr = strcid.Split(',');
            LogHelper.SaveLog(strcid, "GoodsCartPay");

            if (arr.Length <= 0)
            {
                msg = "传递的ID无数据";
                return false;
            }

            Random rand = new Random();
            string orderCode = DateTime.Now.ToString("yyyyMMddhhmmss") + rand.Next(10000, 99999); //订单编号
            string goodsname = string.Format("订单号{0}，", orderCode);
            decimal totalMoney = 0;
            int orderSum = 0;
            int insert = 0;
            DateTime dtime = DateTime.Now;


            if (!userBLL.Exists(userid))
            {
                msg = "用户不存在";
                return false;
            }
         
            if (paytype != 1)
            {
                msg = "支付类型错误";
                return false;
            }

            lgk.Model.tb_Address addrModel = addressBLL.GetModel(addrid);
            if (addrModel == null)
            {
                msg = "请选择收货地址";
                return false;
            }

            IList<lgk.Model.tb_goodsCar> listCar = new List<lgk.Model.tb_goodsCar>();

            #region 验证商品
            string errmsg = "";
            foreach (var strID in arr)
            {
                long id = 0;
                long.TryParse(strID, out id);
                lgk.Model.tb_goodsCar carModel = goodsCarBLL.GetModel(id);
                if (carModel != null)
                {
                    lgk.Model.tb_goods goodsModel = goodsBLL.GetModelAndOneName(carModel.GoodsID);//根据发布商品编号找到充值账号密码
                    if (goodsModel.StateType == 0) //判断是否 审核通过 0未审核
                    {
                        errmsg = "商品" + goodsModel.GoodsName + "审核未通过,请删除该商品!";
                        insert = 0;
                        break;
                    }
                    else if (goodsModel.Goods003 == "1") //判断是否 删除 1已经删除
                    {
                        errmsg = "商品" + goodsModel.GoodsName + "已被删除,请删除该商品!";
                        insert = 0;
                        break;
                    }
                    else if (goodsModel.Goods001 == 0) //判断是否 0下架
                    {
                        errmsg = "商品" + goodsModel.GoodsName + "已经下架,请删除该商品!";
                        insert = 0;
                        break;
                    }
                    else if (goodsModel.Goods002 < carModel.Goods006) //判断库存量
                    {
                        errmsg = "商品" + goodsModel.GoodsName + "库存不足,请重新修改数量!";
                        insert = 0;
                        break;
                    }
                    else if (carModel.BuyUser != userid) //判断库存量
                    {
                        errmsg = "用户不匹配，请刷新购物车再提交!";
                        insert = 0;
                        break;
                    }
                    listCar.Add(carModel);
                    insert += 1;
                }
                else
                {
                    msg = "购物出为空";
                    LogHelper.SaveLog(id.ToString() + "," + errmsg, "GoodsCartPay");
                    return false;
                }
            }

            if (insert == 0)
            {
                msg = errmsg;
                return false;
            }
            #endregion

            //总金额
            totalMoney += listCar.Sum(s => s.TotalMoney);
            lgk.Model.tb_user userModel = userBLL.GetModel(userid);
            //支付方式
            string[] aw = aa.Split('-');

            //if (!userBLL.Exists(long.Parse(aw[2])))
            //{
            //    msg = "运营中心不存在";
            //    return false;
            //}
            string sql = "select OrderID from tb_Order where UserID=" + userModel.UserID;
            var mo = userBLL.getData_Chaxun(sql, "").Tables[0];

            if (aw[0] == "1")
            {
                //if (mo.Rows.Count > 0)
                //{
                //    msg = "请选择复投产品";
                //    return false;
                //}
                if (aw[1] == "2")
                {
                    if (userModel.StockMoney < totalMoney / 2 || userModel.StockAccount < totalMoney / 2)
                    {
                        msg = "报单积分、电子积分余额不足";
                        return false;
                    }
                }
                else
                {
                    if (userModel.StockAccount < totalMoney)
                    {
                        msg = "报单积分余额不足";
                        return false;
                    }
                }
               
            }
            else if (aw[0] == "2")
            { 
                    if (userModel.AllBonusAccount < totalMoney)
                    {
                        msg = "种子积分余额不足";
                        return false;
                    } 
            }
            else if (aw[0] == "3")
            { 
                if (userModel.StockMoney < totalMoney / 2 || userModel.StockAccount < totalMoney / 2)
                {
                    msg = "报单积分、电子积分余额不足";
                    return false;
                }
            }
            else if (aw[0] == "4")
            { 
                if (userModel.BonusAccount < totalMoney)
                {
                    msg = "消费积分余额不足";
                    return false;
                }
            }

            #region 订单处理
            //总订单
            lgk.Model.tb_Order orderModel = new lgk.Model.tb_Order();//订单
            orderModel.UserID = userid;//用户
            orderModel.OrderCode = orderCode;//订单编号
            orderModel.OrderSum = orderSum;//订单数--
            orderModel.OrderTotal = totalMoney;//购买总金
            orderModel.PVTotal = totalMoney * getParamAmount("hongbao1");//
            orderModel.OrderDate = dtime;
            orderModel.IsSend = 1;
            orderModel.PayMethod = 1;//--
            orderModel.Order5 = "";//运营中心UserID
            orderModel.UserAddr = addrModel.Address;//发货地址
            orderModel.Order6 = addrModel.PhoneNum;//收货电话
            orderModel.Order7 = addrModel.MemberName;//收货姓名
            orderModel.OrderType = int.Parse(aw[0]);//1: 
            int fenrun = 0;
            foreach (var carModel in listCar)
            {
                lgk.Model.tb_goods goodsModel = goodsBLL.GetModelAndOneName(carModel.GoodsID);//根据发布商品编号找到充值账号密码
                lgk.Model.tb_goods goodsModel1 = goodsBLL.GetModel(carModel.GoodsID);                                                    //插入订单详细表
                lgk.Model.tb_OrderDetail orderDetailModel = new lgk.Model.tb_OrderDetail();
                orderDetailModel.OrderCode = orderCode;
                orderDetailModel.Price = carModel.RealityPrice;//单价--
                orderDetailModel.OrderSum = carModel.Goods006;//数量--
                orderDetailModel.OrderTotal = carModel.Goods006 * carModel.RealityPrice;//订单金额
                orderDetailModel.PV = 0;//
                orderDetailModel.PVTotal = 0;
                orderDetailModel.ProcudeID = carModel.GoodsID; //产品编号--
                orderDetailModel.ProcudeName = carModel.GoodsName;//名称--
                orderDetailModel.gColor = carModel.gColor;
                orderDetailModel.gSize = carModel.gSize;
                orderDetailModel.OrderDate = dtime;//
                orderDetailBLL.Add(orderDetailModel);//加入订单详情

                fenrun += goodsModel1.IsHave * carModel.Goods006;//计算分润单位
                //修改库存
                goodsModel.Goods002 = goodsModel.Goods002 - carModel.Goods006;//修改库存
                goodsModel.SaleNum += carModel.Goods006;
                goodsBLL.Update(goodsModel);

                //从购物篮减掉
                goodsCarBLL.Delete(carModel.ID);

                //商品名称 流水表记录用
                goodsname += orderDetailModel.ProcudeName + "|";

                orderSum += carModel.Goods006;
            }
            orderModel.BaodanOrder = fenrun;
            //if (aw[3]=="1")//自提
            //{

            //    orderModel.Order3 = "自提";
            //    orderModel.Order4 = "自提";
            //}
            #endregion
            //if (aw[1]=="2")//种子积分
            //{
            //    orderModel.Order3 = "种子积分购买无发货信息！";
            //    orderModel.Order4= "种子积分购买无发货信息！";
            //    orderModel.IsSend = 3;
            //    long iOrderID = orderBLL.Add(orderModel);//加入订单表
            //}
            //else
            //{
            long iOrderID = orderBLL.Add(orderModel);//加入订单表
            //}
           



            #region 写入到明细表
            if (aw[0] == "1")
            {
                if (aw[1]=="2")
                {
                    lgk.Model.tb_journal joModel = new lgk.Model.tb_journal();
                    joModel.UserID = userModel.UserID;
                    joModel.Remark = goodsname;//名称--;
                    joModel.InAmount = 0;//收入0;
                    joModel.OutAmount = totalMoney / 2;//购买价(支出金币)
                    joModel.JournalDate = DateTime.Now;
                    joModel.Journal01 = userModel.UserID;//
                    joModel.Journal02 = 99;//消费
                    joModel.Journal03 = orderCode;//订单编号
                    if (aw[0] == "2")//50%电子积分+50%消费积分
                    {
                        joModel.JournalType = 2;//币种
                        joModel.BalanceAmount = userModel.StockMoney - totalMoney / 2;//余额
                    }
                    journalBLL.Add(joModel);

                    ///---------------------------
                    joModel.UserID = userModel.UserID;
                    joModel.Remark = goodsname;//名称--;
                    joModel.InAmount = 0;//收入0;
                    joModel.OutAmount = totalMoney / 2;//购买价(支出金币)
                    joModel.JournalDate = DateTime.Now;
                    joModel.Journal01 = userModel.UserID;//
                    joModel.Journal02 = 99;//消费
                    joModel.Journal03 = orderCode;//订单编号
                    if (aw[0] == "2")//50%电子积分+50%消费积分
                    {
                        joModel.JournalType = 5;//币种
                        joModel.BalanceAmount = userModel.StockAccount - totalMoney / 2;//余额
                    }
                    journalBLL.Add(joModel);
                    UpdateAccount("StockMoney", userModel.UserID, totalMoney / 2, 0);
                    UpdateAccount("StockAccount", userModel.UserID, totalMoney / 2, 0);
                }
                else 
                {
                    lgk.Model.tb_journal joModel = new lgk.Model.tb_journal();
                    joModel.UserID = userModel.UserID;
                    joModel.Remark = goodsname;//名称--;
                    joModel.InAmount = 0;//收入0;
                    joModel.OutAmount = totalMoney;//购买价(支出金币)
                    joModel.JournalDate = DateTime.Now;
                    joModel.Journal01 = userModel.UserID;//
                    joModel.Journal02 = 99;//消费
                    joModel.Journal03 = orderCode;//订单编号 
                    joModel.JournalType = 5;//币种
                    joModel.BalanceAmount = userModel.StockAccount - totalMoney;//余额 
                    journalBLL.Add(joModel);
                    UpdateAccount("StockAccount", userModel.UserID, totalMoney, 0);
                }
               
            }
            else if (aw[0] == "2")
            {
                lgk.Model.tb_journal joModel = new lgk.Model.tb_journal();
                joModel.UserID = userModel.UserID;
                joModel.Remark = goodsname;//名称--;
                joModel.InAmount = 0;//收入0;
                joModel.OutAmount = totalMoney;//购买价(支出金币)
                joModel.JournalDate = DateTime.Now;
                joModel.Journal01 = userModel.UserID;//
                joModel.Journal02 = 99;//消费
                joModel.Journal03 = orderCode;//订单编号 
                joModel.JournalType = 4;//币种
                joModel.BalanceAmount = userModel.AllBonusAccount - totalMoney;//余额
                UpdateAccount("AllBonusAccount", userModel.UserID, totalMoney, 0); 
                journalBLL.Add(joModel); 
            }
            else if (aw[0] == "3")
            {
              
                    lgk.Model.tb_journal joModel = new lgk.Model.tb_journal();
                    joModel.UserID = userModel.UserID;
                    joModel.Remark = goodsname;//名称--;
                    joModel.InAmount = 0;//收入0;
                    joModel.OutAmount = totalMoney / 2;//购买价(支出金币)
                    joModel.JournalDate = DateTime.Now;
                    joModel.Journal01 = userModel.UserID;//
                    joModel.Journal02 = 99;//消费
                    joModel.Journal03 = orderCode;//订单编号 
                    joModel.JournalType = 2;//币种子电子积分
                    joModel.BalanceAmount = userModel.StockMoney - totalMoney / 2;//余额 
                    journalBLL.Add(joModel);

                    ///---------------------------报单积分扣钱
                    joModel.UserID = userModel.UserID;
                    joModel.Remark = goodsname;//名称--;
                    joModel.InAmount = 0;//收入0;
                    joModel.OutAmount = totalMoney / 2;//购买价(支出金币)
                    joModel.JournalDate = DateTime.Now;
                    joModel.Journal01 = userModel.UserID;//
                    joModel.Journal02 = 99;//消费
                    joModel.Journal03 = orderCode;//订单编号 
                    joModel.JournalType = 5;//币种
                    joModel.BalanceAmount = userModel.StockAccount - totalMoney / 2;//余额 
                    journalBLL.Add(joModel);
                    UpdateAccount("StockMoney", userModel.UserID, totalMoney / 2, 0);
                    UpdateAccount("StockAccount", userModel.UserID, totalMoney / 2, 0);
            }
            else if (aw[0] == "4")
            {
                lgk.Model.tb_journal joModel = new lgk.Model.tb_journal();
                joModel.UserID = userModel.UserID;
                joModel.Remark = goodsname;//名称--;
                joModel.InAmount = 0;//收入0;
                joModel.OutAmount = totalMoney;//购买价(支出金币)
                joModel.JournalDate = DateTime.Now;
                joModel.Journal01 = userModel.UserID;//
                joModel.Journal02 = 99;//消费
                joModel.Journal03 = orderCode;//订单编号 
                joModel.JournalType = 3;//币种
                joModel.BalanceAmount = userModel.BonusAccount - totalMoney;//余额
                UpdateAccount("BonusAccount", userModel.UserID, totalMoney, 0);
                journalBLL.Add(joModel);
            }
            else
            {
                msg = "支付失败，支付方式不正确！";
                return false;
            }
            //---激活会员
            lgk.Model.tb_user user = userBLL.GetModel(orderModel.UserID);
            if (user.IsOpend!=2)
            { 
                string a = Luodian(orderModel.UserID);
                string[] ID = a.Split('-');//ID[0]=UserID ID[1]=Location ID[2]=ParentID ID[3]=ParentCode  ID[4]=Layer
                var l = userBLL.GetModel(int.Parse(ID[2]));
                //user.RecommendPath = model_1.RecommendPath + "-" + user.UserID.ToString();

                user.ParentID = 0;//父节点ID
                user.ParentCode = "";//父节点編號
                user.UserPath = "";
                user.Layer = 0;//属于多少层
                user.Location = 0;

                user.ParentID = int.Parse(ID[2]);//父节点ID
                user.ParentCode = ID[3];//父节点編號
                user.UserPath = l.UserPath + "-" + user.UserID;
                user.Layer = int.Parse(ID[4]);//属于多少层
                user.Location = int.Parse(ID[1]);
                user.OpenTime = DateTime.Now;
                user.IsOpend = 2;
                userBLL.Update(user);
            }
            //开关报单  
            MySQL(string.Format(" exec proc_Kaiguan " + orderModel.UserID + "," + orderModel.OrderCode + ""));
           
            //报单开关
            //---激活会员
            if (aw[0] != "4")
            {
                
                MySQL(string.Format(" exec proc_YejiUp " + orderModel.UserID + "," + orderModel.OrderTotal + ""));//加业绩
                MySQL(string.Format(" exec proc_Fenxiangjiang " + orderModel.UserID + "," + orderModel.OrderTotal + ""));
                MySQL(string.Format(" exec proc_Xiaocengjiang " + orderModel.UserID + ""));
                MySQL(string.Format(" exec proc_Xiaoliangjiang " + orderModel.UserID + ""));
                MySQL(string.Format(" exec proc_Jiandianjiang " + orderModel.UserID + "," + orderModel.OrderTotal + ",1"));

                //发奖 
                #region 报单中心（20套）改为4万元
                if (orderModel.OrderTotal >= getParamInt("Fuwu2"))//报单中心（20套）
                {
                    int t = agentBLL.GetIDByIDUser(orderModel.UserID);
                    if (t == 0)//插入用户
                    {
                        var userModel1 = userBLL.GetModel(orderModel.UserID);
                        lgk.Model.tb_agent model = new lgk.Model.tb_agent();
                        model.UserID = userModel1.UserID;
                        model.AgentCode = userModel1.UserCode;
                        model.Flag = 1;
                        model.AgentType = 1;
                        model.Agent003 = userModel1.TrueName;
                        model.AppliTime = DateTime.Now;
                        model.JoinMoney = 0;
                        model.Agent004 = "";
                        model.Agent001 = 0;
                        model.Agent002 = 0;
                        model.PicLink = "";
                        agentBLL.Add(model);

                        var model1 = userBLL.GetModel(userModel1.UserID);
                        model1.AgentsID = agentBLL.GetIDByIDUser(userModel1.UserID);
                        model1.IsAgent = 1;
                        userBLL.Update(model1);

                        lgk.Model.tb_journal journalInfo = new lgk.Model.tb_journal();
                        journalInfo.UserID = userModel1.UserID;
                        journalInfo.Remark = "一次性购买 " + getParamInt("Fuwu2") + "元的产品，成为服务网点";
                        journalInfo.RemarkEn = "Cash withdrawal";
                        journalInfo.InAmount = 0;
                        journalInfo.OutAmount = 0;
                        journalInfo.BalanceAmount = userBLL.GetMoney(userModel1.UserID, "StockMoney");
                        journalInfo.JournalDate = DateTime.Now;
                        journalInfo.JournalType = 2;
                        journalInfo.Journal01 = userModel1.UserID;
                        journalBLL.Add(journalInfo);


                    }
                }
                userid = orderModel.UserID;
                totalMoney = orderModel.OrderTotal;
                #endregion
                if (getParamInt("Fuwu") == 1)
                {
                    //报单中心奖 

                    long BD_UserID = userBLL.GetUserID(userBLL.GetModel(orderModel.UserID).User006);
                    decimal BD = getParamAmount("Fuwu1") / 100 * totalMoney;

                    int isLock = userBLL.GetModel(BD_UserID).IsLock;
                    int Ag = userBLL.GetModel(BD_UserID).IsAgent;
                    if (isLock == 0 && Ag == 1)
                    {
                        decimal shouxufei = BD * getParamAmount("PingTai") / 100;
                        BD -= shouxufei;
                        decimal Gongyi = BD * getParamAmount("PingTai1") / 100;
                        BD -= Gongyi;

                        decimal jiangjin = getParamAmount("JJ");
                        decimal zhongzi = getParamAmount("ZZ");
                        decimal xiaofei = getParamAmount("XF");
                        decimal JJ = BD * jiangjin / 100;
                        decimal ZZ = BD * zhongzi / 100;
                        decimal XF = BD * xiaofei / 100;
                        UpdateAccount("Emoney", BD_UserID, JJ, 1);//奖金
                        UpdateAccount("StockMoney", BD_UserID, ZZ, 1);//电子

                        UpdateAccount("ShopAccount", BD_UserID, shouxufei, 1);//奖金
                        UpdateAccount("GLmoney", BD_UserID, Gongyi, 1);//电子
                        if (XF > 0)
                        {
                            UpdateAccount("BonusAccount", BD_UserID, XF, 1);//消费
                            lgk.Model.tb_journal journal1 = new lgk.Model.tb_journal();
                            journal1.UserID = BD_UserID;
                            journal1.Remark = "服务网点获得" + (BD + shouxufei + Gongyi) + ",其中扣除平台手续费" + shouxufei + ",扣除公益基金" + Gongyi + " ,剩余" + xiaofei + "%进入消费积分";
                            journal1.RemarkEn = "";
                            journal1.InAmount = XF;
                            journal1.OutAmount = 0;
                            journal1.BalanceAmount = userBLL.GetMoney(BD_UserID, "BonusAccount"); ;
                            journal1.JournalDate = DateTime.Now;
                            journal1.JournalType = 3;
                            journal1.Journal01 = 0;
                            journalBLL.Add(journal1);
                        }

                        lgk.Model.tb_journal journal = new lgk.Model.tb_journal();
                        journal.UserID = BD_UserID;
                        journal.Remark = "服务网点获得" + (BD + shouxufei + Gongyi) + ",其中扣除平台手续费" + shouxufei + ",扣除公益基金" + Gongyi + " ,剩余" + jiangjin + "%进入奖金积分";
                        journal.RemarkEn = "";
                        journal.InAmount = JJ;
                        journal.OutAmount = 0;
                        journal.BalanceAmount = userBLL.GetMoney(BD_UserID, "Emoney"); ;
                        journal.JournalDate = DateTime.Now;
                        journal.JournalType = 1;
                        journal.Journal01 = 0;
                        journalBLL.Add(journal);

                        journal.UserID = BD_UserID;
                        journal.Remark = "服务网点获得" + (BD + shouxufei + Gongyi) + ",其中扣除平台手续费" + shouxufei + ",扣除公益基金" + Gongyi + " ,剩余" + zhongzi + "%进入电子积分";
                        journal.RemarkEn = "";
                        journal.InAmount = ZZ;
                        journal.OutAmount = 0;
                        journal.BalanceAmount = userBLL.GetMoney(BD_UserID, "StockMoney"); ;
                        journal.JournalDate = DateTime.Now;
                        journal.JournalType = 2;
                        journal.Journal01 = 0;
                        journalBLL.Add(journal);

                        journal.UserID = BD_UserID;
                        journal.Remark = "服务网点获得" + (BD + shouxufei + Gongyi) + ",其中扣除平台手续费" + shouxufei + "";
                        journal.RemarkEn = "";
                        journal.InAmount = shouxufei;
                        journal.OutAmount = 0;
                        journal.BalanceAmount = userBLL.GetMoney(BD_UserID, "ShopAccount"); ;
                        journal.JournalDate = DateTime.Now;
                        journal.JournalType = 6;
                        journal.Journal01 = 0;
                        journalBLL.Add(journal);

                        journal.UserID = BD_UserID;
                        journal.Remark = "服务网点获得" + (BD + shouxufei + Gongyi) + ",其中扣除公益基金" + Gongyi + "";
                        journal.RemarkEn = "";
                        journal.InAmount = Gongyi;
                        journal.OutAmount = 0;
                        journal.BalanceAmount = userBLL.GetMoney(BD_UserID, "GLmoney"); ;
                        journal.JournalDate = DateTime.Now;
                        journal.JournalType = 7;
                        journal.Journal01 = 0;
                        journalBLL.Add(journal);


                        SqlConnection conn = new SqlConnection(sconn);
                        conn.Open();
                        string sql_Add = "insert into tb_bonus(UserID,TypeID,Amount,Revenue,sf,AddTime,IsSettled,Source,SourceEn,SttleTime,FromUserID,Bonus005,Bonus006)";
                        sql_Add += "values (" + BD_UserID + ",5," + (BD + shouxufei + Gongyi) + "," + shouxufei + "," + BD + ",getdate(),1,'" + journal.Remark + "','',getdate()," + userid + "," + jiangjin + "," + zhongzi + ");";
                        SqlCommand cmd = new SqlCommand(sql_Add, conn);
                        int reInt = cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }




            }
            else
            {
                MySQL(string.Format(" exec proc_Jiandianjiang " + orderModel.UserID + "," + orderModel.OrderTotal + ",2"));
            } 
            msg = "支付成功";
            return true;
        }
        #endregion

        #region 加入购物车
        public bool AddGoodCar(long userid, long goodsid, int buynum, out string msg)
        {
            if (!userBLL.Exists(userid))
            {
                msg = "用户不存在";
            }
            lgk.Model.tb_goods goodsInfo = goodsBLL.GetModel(goodsid);
            if (goodsInfo == null)
            {
                msg = "此商品不存在!";
                return false;
            }
            lgk.Model.tb_goodsCar goodsCarInfo = new lgk.Model.tb_goodsCar();
            if (goodsInfo.Goods002 <= 0)
            {
                msg = "商品库存不足!";
                return false;
            }
            if (goodsInfo.Goods002 < buynum)
            {
                msg = "商品库存不足!";
                return false;
            }
            goodsCarInfo.GoodsID = goodsInfo.ID;
            goodsCarInfo.GoodsCode = goodsInfo.GoodsCode;
            goodsCarInfo.GoodsName = goodsInfo.GoodsName;
            goodsCarInfo.Price = goodsInfo.Price;
            goodsCarInfo.RealityPrice = goodsInfo.RealityPrice;
            goodsCarInfo.ShopPrice = goodsInfo.ShopPrice;

            goodsCarInfo.TypeID = goodsInfo.TypeID;
            goodsCarInfo.TypeIDName = produceTypeBLL.GetTypeName(goodsInfo.TypeID);
            goodsCarInfo.GoodsType = goodsInfo.GoodsType;
            goodsCarInfo.GoodsTypeName = produceTypeBLL.GetTypeName(goodsInfo.GoodsType);
            goodsCarInfo.Pic1 = goodsInfo.Pic1;
            goodsCarInfo.Remarks = goodsInfo.Remarks;
            goodsCarInfo.Goods002 = goodsInfo.Goods002;
            goodsCarInfo.Goods005 = decimal.Parse(goodsInfo.Goods005.ToString());

            goodsCarInfo.Goods006 = buynum;//购买数量
            goodsCarInfo.BuyUser = userid;//购买者
            goodsCarInfo.TotalMoney = goodsCarInfo.Goods006 * goodsCarInfo.RealityPrice;//总金
            goodsCarInfo.TotalGoods006 = 0;//总积分
            goodsCarInfo.AddTime = DateTime.Now;
            //goodsCarInfo.gColor = hhcolor.Value.Trim();
            //goodsCarInfo.gSize = hhsize.Value.Trim();
            string where = string.Format(" BuyUser ={0} and GoodsID={1}", goodsCarInfo.BuyUser, goodsCarInfo.GoodsID);
            lgk.Model.tb_goodsCar _carModel = new lgk.Model.tb_goodsCar();
            _carModel = goodsCarBLL.GetModel(where);

            DataSet dsCount = goodsCarBLL.GetList("BuyUser=" + userid);
            if (dsCount.Tables[0].Rows.Count > 50)
            {
                msg = "购物车商品已经装满!";
                return false;
            }
            #region
            if (_carModel != null && _carModel.GoodsID > 0 && _carModel.RealityPrice == goodsInfo.RealityPrice && _carModel.Goods002 == goodsInfo.Goods002) //购物车中已经存在
            {
                _carModel.Goods006 += goodsCarInfo.Goods006;//加上原来的数量
                                                            // _carModel.Goods002 += carModel.Goods002;
                _carModel.TotalMoney += goodsCarInfo.TotalMoney;//总金额
                //_carModel.TotalGoods006 += goodsCarInfo.TotalGoods006;
                if (goodsCarBLL.Update(_carModel) == true)
                {
                    msg = "成功加入购物车";
                }
                else
                {
                    msg = "加入购物车失败,请重试!";
                    return false;
                }
            }
            else
            {
                if (goodsCarBLL.Add(goodsCarInfo) > 0)
                {
                    msg = "成功加入购物车";
                }
                else
                {
                    msg = "加入购物车失败,请重试!";
                    return false;
                }
            }
            #endregion

            return true;
        }
        #endregion

        #region 购物车数量管理
        public bool NumManage(long id, int type, out string msg)
        {
            lgk.Model.tb_goodsCar carModel = goodsCarBLL.GetModel(id);
            if (carModel == null)
            {
                msg = "数据不存在";
                return false;
            }
            if (carModel.Goods006 <= 1 && type == 1)
            {
                msg = "数量不可再减";
                return false;
            }

            if (type == 1)
            {
                carModel.Goods006 -= 1;
            }
            else if (type == 2)
            {
                carModel.Goods006 += 1;
                if (carModel.Goods006 + 1 > 50)
                {
                    msg = "一次性最多可购买50套产品";
                    return false;
                }
            }
            carModel.TotalMoney = carModel.Goods006 * carModel.RealityPrice;
            if (goodsCarBLL.Update(carModel))
            {
                if (type == 1)
                {
                    msg = "扣除数量成功";
                }
                else
                {
                    msg = "增加数量成功";
                }
                return true;
            }
            else
            {
                if (type == 1)
                {
                    msg = "扣除数量失败";
                }
                else
                {
                    msg = "增加数量失败";
                }
                return false;
            }
        }
        #endregion

        #region 删除购物车
        public bool GoodsCartDel(long id, out string msg)
        {
            lgk.Model.tb_goodsCar carModel = goodsCarBLL.GetModel(id);
            if (carModel == null)
            {
                msg = "该记录已删除";
                return false;
            }
            if (goodsCarBLL.Delete(carModel.ID))
            {
                msg = "删除成功";
                return true;
            }
            else
            {
                msg = "删除失败";
                return false;
            }
        }
        #endregion
        private string Luodian(long User)
        {

            lgk.Model.tb_user user = userBLL.GetModel(User);
           

            string UserID = user.RecommendID == 1 ? "1-" : "-" + user.RecommendID + "-";
            var model = userBLL.GetModel(user.RecommendID);//推荐人
            //string sconn = System.Configuration.ConfigurationManager.AppSettings["SocutDataLink"];
            string sql = " select count(userid)Count from tb_user ;";
            DataTable dt = userBLL.getData_Chaxun(sql, "").Tables[0];
            int Count = int.Parse(dt.Rows[0]["Count"].ToString());//总人数 

            var Gender = model.Gender;//点位方向
            if (Gender == 0)
            {
                UpdateAccount("Gender", model.UserID, 2, 1);//修改
                return model.UserID + "-1-" + model.UserID + "-" + model.UserCode + "-" + (model.Layer + 1);
            }
            else if (Gender == 1)//放左边
            {
                var mUserID = model.UserID;//推荐人UserID

                for (int i = 0; i < Count; i++)
                { 
                    var model1 = userBLL.GetList(" Location=1 and ParentID='" + mUserID + "' and IsOpend=2 ").Tables[0];//查Location=1的伞下会员 
                   
                        if (model1.Rows.Count > 0)//大于0 说明有人
                        {

                            mUserID = int.Parse(model1.Rows[0]["UserID"].ToString());
                            continue;
                        }
                        else//说明没人了 就落这个点位
                       {
                        model1 = userBLL.GetList(" UserID=" + mUserID + "").Tables[0];//查询上个会员

                        long userID = long.Parse(model1.Rows[0]["UserID"].ToString());//落在这个下边
                        string UserCode = model1.Rows[0]["UserCode"].ToString(); //落在这个下边的名字 
                        int Layer = int.Parse(model1.Rows[0]["Layer"].ToString());
                        Layer += 1; 
                        //ID[0]=UserID ID[1]=Location ID[2]=ParentID ID[3]=ParentCode  ID[4]=UserPath ID[5]=Layer 
                        UpdateAccount("Gender", model.UserID, 1, 1);//修改
                        return userID + "-1-" + userID + "-" + UserCode + "-" + Layer;
                        //break;
                    }
                }

            }
            else// 放右边，先找该会员右边的人， 在找Location=1的人
            {
                var mUserID = model.UserID;//推荐人UserID
                var model2 = userBLL.GetList(" Location=2 and ParentID='" + mUserID + "' and IsOpend=2 ").Tables[0];
                if (model2.Rows.Count == 0)//该会员右边的人（第一个）
                {
                    model2 = userBLL.GetList(" UserID=" + mUserID + "").Tables[0];//查询上个会员
                    long userID = long.Parse(model2.Rows[0]["UserID"].ToString());
                    string UserCode = model2.Rows[0]["UserCode"].ToString(); 
                    int Layer = int.Parse(model2.Rows[0]["Layer"].ToString());
                    Layer += 1;
                    UpdateAccount("Gender", model.UserID, 1, 0);//修改 
                    return userID + "-2-" + userID + "-" + UserCode + "-" + Layer;
                    //}
                }
                //重新赋值
                mUserID = int.Parse(model2.Rows[0]["UserID"].ToString());

                for (int i = 0; i < Count; i++)
                {

                    model2 = userBLL.GetList(" Location=1 and ParentID='" + mUserID + "'").Tables[0];//找右边会员 方向向左边的会员
                    if (model2.Rows.Count > 0)//大于0 说明有人
                    {

                        mUserID = int.Parse(model2.Rows[0]["UserID"].ToString());
                        continue;
                    }
                    else//说明没人了 就落这个点位
                    {
                        model2 = userBLL.GetList(" UserID=" + mUserID + "").Tables[0];//查询上个会员
                        long userID = long.Parse(model2.Rows[0]["UserID"].ToString());
                        string UserCode = model2.Rows[0]["UserCode"].ToString();

                        int Layer = int.Parse(model2.Rows[0]["Layer"].ToString());
                        Layer += 1; 
                        UpdateAccount("Gender", model.UserID, 1, 0);//修改
                                                                   
                        return userID + "-1-" + userID + "-" + UserCode + "-" + Layer; 
                    }
                }
            }
            return "";
             
        }
    }
}
#endregion