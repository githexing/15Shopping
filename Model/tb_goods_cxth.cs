using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
 
   /// <summary>
   /// tb_goods:实体类(属性说明自动提取数据库字段的描述信息)
   /// </summary>
   [Serializable]
   public partial class tb_goods_cxth
   {
       public tb_goods_cxth()
       { }
       #region Model
       private int _id;
       private string _goodscode;
       private string _goodsname;

       private decimal _price;
       private decimal _realityprice;
      
   
       private int _typeid;
       private int _goodstype;
       private string _pic1;
       private string _pic2;
       private string _pic3;
       private string _pic4;
       private string _pic5;
    
       private string _remarks;
   
       private DateTime _addtime;
       private int _goods001;
       private int _goods002;
       private int _goods003;
       private string _goods004;
       private decimal? _goods005;
       private int _goods006;
       private DateTime? _goods007;
       private DateTime? _goods008;
       private int _uploadUser;//上传用户
       private int _stateType;//审核状态
       private int _sealCount;//卖出数量
       private int _pareTopId;//顶级栏目
       private string _city;
       private int _purchase;
       private int _sealpurchase;
       private string _userCode;
       private int _islucky;

        public string City
       {
           get { return _city; }
           set { _city = value; }
       }

       public int PareTopId
       {
           get { return _pareTopId; }
           set { _pareTopId = value; }
       }
       private int _pareTopChild;//顶级子栏目

       public int PareTopChild
       {
           get { return _pareTopChild; }
           set { _pareTopChild = value; }
       }
       public int SealCount
       {
           get { return _sealCount; }
           set { _sealCount = value; }
       }


       public int StateType
       {
           get { return _stateType; }
           set { _stateType = value; }
       }

       public int UploadUser
       {
           get { return _uploadUser; }
           set { _uploadUser = value; }
       }
       /// <summary>
       /// 
       /// </summary>
       public int ID
       {
           set { _id = value; }
           get { return _id; }
       }
       /// <summary>
       /// 
       /// </summary>
       public string GoodsCode
       {
           set { _goodscode = value; }
           get { return _goodscode; }
       }
       /// <summary>
       /// 
       /// </summary>
       public string GoodsName
       {
           set { _goodsname = value; }
           get { return _goodsname; }
       }
 
       /// <summary>
       /// 
       /// </summary>
       public decimal Price
       {
           set { _price = value; }
           get { return _price; }
       }
       /// <summary>
       /// 
       /// </summary>
       public decimal RealityPrice
       {
           set { _realityprice = value; }
           get { return _realityprice; }
       }


       /// <summary>
       /// 
       /// </summary>
       public int TypeID
       {
           set { _typeid = value; }
           get { return _typeid; }
       }
       /// <summary>
       /// 
       /// </summary>
       public int GoodsType
       {
           set { _goodstype = value; }
           get { return _goodstype; }
       }
       /// <summary>
       /// 
       /// </summary>
       public string Pic1
       {
           set { _pic1 = value; }
           get { return _pic1; }
       }
       /// <summary>
       /// 
       /// </summary>
       public string Pic2
       {
           set { _pic2 = value; }
           get { return _pic2; }
       }
       /// <summary>
       /// 
       /// </summary>
       public string Pic3
       {
           set { _pic3 = value; }
           get { return _pic3; }
       }
       /// <summary>
       /// 
       /// </summary>
       public string Pic4
       {
           set { _pic4 = value; }
           get { return _pic4; }
       }
       /// <summary>
       /// 
       /// </summary>
       public string Pic5
       {
           set { _pic5 = value; }
           get { return _pic5; }
       }

       /// <summary>
       /// 
       /// </summary>
       public string Remarks
       {
           set { _remarks = value; }
           get { return _remarks; }
       }

       /// <summary>
       /// 
       /// </summary>
       public DateTime AddTime
       {
           set { _addtime = value; }
           get { return _addtime; }
       }
       /// <summary>
       /// 
       /// </summary>
       public int Goods001
       {
           set { _goods001 = value; }
           get { return _goods001; }
       }
       /// <summary>
       /// 
       /// </summary>
       public int Goods002
       {
           set { _goods002 = value; }
           get { return _goods002; }
       }
       /// <summary>
       /// 
       /// </summary>
       public int Goods003
       {
           set { _goods003 = value; }
           get { return _goods003; }
       }
       /// <summary>
       /// 
       /// </summary>
       public string Goods004
       {
           set { _goods004 = value; }
           get { return _goods004; }
       }
       /// <summary>
       /// 
       /// </summary>
       public decimal? Goods005
       {
           set { _goods005 = value; }
           get { return _goods005; }
       }
       /// <summary>
       /// 
       /// </summary>
       public int Goods006
       {
           set { _goods006 = value; }
           get { return _goods006; }
       }
       /// <summary>
       /// 
       /// </summary>
       public DateTime? Goods007
       {
           set { _goods007 = value; }
           get { return _goods007; }
       }
       /// <summary>
       /// 
       /// </summary>
       public DateTime? Goods008
       {
           set { _goods008 = value; }
           get { return _goods008; }
       }
        /// <summary>
        /// 竞拍次数
        /// </summary>
        public int Purchase
        {
            set { _purchase = value; }
            get { return _purchase; }
        }
       /// <summary>
        /// 已竞拍次数
        /// </summary>
        public int SealPurchase
        {
            set { _sealpurchase = value; }
            get { return _sealpurchase; }
        }
       
        /// <summary>
        /// 推荐人编号
        /// </summary>
        public string UserCode
        {
            set { _userCode = value; }
            get { return _userCode; }
        }
       /// <summary>
        /// 是否已抽奖
        /// </summary>
        public int IsLucky
        {
            set { _islucky = value; }
            get { return _islucky; }
        }
        #endregion Model

    }
}
