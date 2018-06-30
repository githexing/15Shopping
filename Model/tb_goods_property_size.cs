using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace lgk.Model
{
    //tb_goods_property_size
    public class tb_goods_property_size
    {

        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// goodsID
        /// </summary>		
        private int _goodsid;
        public int goodsID
        {
            get { return _goodsid; }
            set { _goodsid = value; }
        }
        /// <summary>
        /// ColorID
        /// </summary>		
        private int _colorid;
        public int ColorID
        {
            get { return _colorid; }
            set { _colorid = value; }
        }
        /// <summary>
        /// SizeName
        /// </summary>		
        private string _sizename;
        public string SizeName
        {
            get { return _sizename; }
            set { _sizename = value; }
        }
        /// <summary>
        /// Qry
        /// </summary>		
        private int _qry;
        public int Qry
        {
            get { return _qry; }
            set { _qry = value; }
        }

    }
}

