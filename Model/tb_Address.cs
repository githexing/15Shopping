using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
    public partial class tb_Address
    {
        public tb_Address()
        { }
        #region tb_Address
        private long _ID;
        private long _UserID;
        private int _TypeID;
        private string _AreaInProvince;
        private string _AreaInCity;
        private string _Address;
        private string _PostCode;
        private string _MemberName;
        private string _PhoneNum;
        private string _Phone;
        private string _Mail;
        private string _Remark;
        private string _Address01;
        private string _Address02;
        private string _Address03;
        private string _Address04;


        public long ID
        {
            get {return _ID; }
            set { _ID = value; }
        }
        public long UserID
        {
            set { _UserID = value; }
            get { return _UserID; }
        }
        public int TypeID
        {
            set { _TypeID = value; }
            get { return _TypeID; }
        }
        public string AreaInProvince
        {
            set { _AreaInProvince = value; }
            get { return _AreaInProvince; }
        }
        public string AreaInCity
        {
            set { _AreaInCity = value; }
            get { return _AreaInCity; }
        }
        public string Address
        {
            set { _Address = value; }
            get { return _Address; }
        }
        public string PostCode
        {
            set { _PostCode = value; }
            get { return _PostCode; }
        }
        public string MemberName
        {
            set { _MemberName = value; }
            get { return _MemberName; }
        }
        public string PhoneNum
        {
            set { _PhoneNum = value; }
            get { return _PhoneNum; }
        }
        public string Phone
        {
            set { _Phone = value; }
            get { return _Phone; }
        }
        public string Mail
        {
            set { _Mail = value; }
            get { return _Mail; }
        }
        public string Remark
        {
            set { _Remark = value; }
            get { return _Remark; }
        }
        public string Address01
        {
            set { _Address01 = value; }
            get { return _Address01; }
        }
        public string Address02
        {
            set { _Address02 = value; }
            get { return _Address02; }

        }
        public string Address03
        {
            set { _Address03= value; }
            get { return _Address03; }

        }
        public string Address04
        {
            set { _Address04= value; }
            get { return _Address04; }

        }


          #endregion
    }
}
