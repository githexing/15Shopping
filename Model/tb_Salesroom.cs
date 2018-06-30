using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
    /// <summary>
	/// tb_Salesroom:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
    [Serializable]
    public partial class tb_Salesroom
    {
        public tb_Salesroom()
        { }
        #region Model
        private int _said;
        private int? _saprid;
        private string _saprname;
        private string _saprname_en;
        private string _saprconent;
        private string _saprconent_en;
        private decimal? _saprusually;
        private string _saprimage;
        private decimal? _saprice;
        private string _sanumber;
        private int? _satypeid = 0;
        private int? _sajinpaisate = 0;
        private int? _satargetpoint;
        private int? _saweipoint;
        private int? _sasanpoint;
        private int? _sasantargetpoint;
        private int? _saweitargetpoint;
        private int? _sastate;
        private DateTime? _sabegintime;
        private DateTime? _saturnovertime = DateTime.Now;
        private int? _saclaptime;
        private string _sa001;
        private decimal? _sa002;
        private DateTime? _saaddtime;
        private int? _successuserid;
        private DateTime? _regtime1;
        private DateTime? _regtime2;
        /// <summary>
        ///  编号
        /// </summary>
        public int SaID
        {
            set { _said = value; }
            get { return _said; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SaPrId
        {
            set { _saprid = value; }
            get { return _saprid; }
        }
        /// <summary>
        /// 拍品名称
        /// </summary>
        public string SaPrName
        {
            set { _saprname = value; }
            get { return _saprname; }
        }
        /// <summary>
        /// 拍品描述
        /// </summary>
        public string SaPrConent
        {
            set { _saprconent = value; }
            get { return _saprconent; }
        }
        /// <summary>
        /// 拍品名称en
        /// </summary>
        public string SaPrName_en
        {
            set { _saprname_en = value; }
            get { return _saprname_en; }
        }
        /// <summary>
        /// 拍品描述en
        /// </summary>
        public string SaPrConent_en
        {
            set { _saprconent_en = value; }
            get { return _saprconent_en; }
        }
        /// <summary>
        /// 竞拍价
        /// </summary>
        public decimal? SaPrUsually
        {
            set { _saprusually = value; }
            get { return _saprusually; }
        }
        /// <summary>
        /// 默认图片
        /// </summary>
        public string SaPrImage
        {
            set { _saprimage = value; }
            get { return _saprimage; }
        }
        /// <summary>
        /// 市价
        /// </summary>
        public decimal? SaPrice
        {
            set { _saprice = value; }
            get { return _saprice; }
        }
        /// <summary>
        /// 拍品编号
        /// </summary>
        public string SaNumber
        {
            set { _sanumber = value; }
            get { return _sanumber; }
        }
        /// <summary>
        /// 一级类别
        /// </summary>
        public int? SaTypeID
        {
            set { _satypeid = value; }
            get { return _satypeid; }
        }
        /// <summary>
        /// 竞拍类型 0、自动 1、手动
        /// </summary>
        public int? SaJinpaiSate
        {
            set { _sajinpaisate = value; }
            get { return _sajinpaisate; }
        }
        /// <summary>
        /// 二级类别
        /// </summary>
        public int? SaTargetPoint
        {
            set { _satargetpoint = value; }
            get { return _satargetpoint; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SaWeiPoint
        {
            set { _saweipoint = value; }
            get { return _saweipoint; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SaSanPoint
        {
            set { _sasanpoint = value; }
            get { return _sasanpoint; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SaSanTargetPoint
        {
            set { _sasantargetpoint = value; }
            get { return _sasantargetpoint; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SaWeiTargetPoint
        {
            set { _saweitargetpoint = value; }
            get { return _saweitargetpoint; }
        }
        /// <summary>
        /// 状态（0下架，1上架，2已成交，3已失败）
        /// </summary>
        public int? SaState
        {
            set { _sastate = value; }
            get { return _sastate; }
        }
        /// <summary>
        /// 竞拍倒计时
        /// </summary>
        public DateTime? SaBeginTime
        {
            set { _sabegintime = value; }
            get { return _sabegintime; }
        }
        /// <summary>
        /// 成交时间
        /// </summary>
        public DateTime? SaTurnoverTime
        {
            set { _saturnovertime = value; }
            get { return _saturnovertime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SaClapTime
        {
            set { _saclaptime = value; }
            get { return _saclaptime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Sa001
        {
            set { _sa001 = value; }
            get { return _sa001; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Sa002
        {
            set { _sa002 = value; }
            get { return _sa002; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? SaAddTime
        {
            set { _saaddtime = value; }
            get { return _saaddtime; }
        }
        /// <summary>
        /// 手动竞拍设置成功用户ID
        /// </summary>
        public int? SuccessUserID
        {
            set { _successuserid = value; }
            get { return _successuserid; }
        }
        /// <summary>
        /// 自动竞拍用户激活开始时间
        /// </summary>
        public DateTime? RegTime1
        {
            set { _regtime1 = value; }
            get { return _regtime1; }
        }
        /// <summary>
        /// 自动竞拍用户激活结束时间
        /// </summary>
        public DateTime? RegTime2
        {
            set { _regtime2 = value; }
            get { return _regtime2; }
        }
        #endregion Model
    }
}
