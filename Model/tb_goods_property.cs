using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace lgk.Model
{
    //tb_goods_property
    public class tb_goods_property
    {

        /// <summary>
        /// PropertyID
        /// </summary>		
        private int _propertyid;
        public int PropertyID
        {
            get { return _propertyid; }
            set { _propertyid = value; }
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
        private string _colorid;
        public string ColorID
        {
            get { return _colorid; }
            set { _colorid = value; }
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

