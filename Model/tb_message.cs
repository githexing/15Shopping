using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
   /// <summary>
	/// tb_message:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
    [Serializable]
    public partial class tb_message
    {
        public tb_message()
        { }
        #region Model
        private int _mid;
        private int? _userid;
        private string _mobilenum;
        private string _mcontent;
        private string _flag;
        /// <summary>
        /// 
        /// </summary>
        public int MID
        {
            set { _mid = value; }
            get { return _mid; }
        }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int? Userid
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MobileNum
        {
            set { _mobilenum = value; }
            get { return _mobilenum; }
        }
        /// <summary>
        /// 发送内容
        /// </summary>
        public string Mcontent
        {
            set { _mcontent = value; }
            get { return _mcontent; }
        }
        /// <summary>
        /// 发送是否成功 1 是
        /// </summary>
        public string Flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
        #endregion Model
    }
}
