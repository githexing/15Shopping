using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace lgk.Model
{
    //tb_goods_property_color
    public class tb_goods_property_color
    {

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
        /// goodsID
        /// </summary>		
        private int _goodsid;
        public int goodsID
        {
            get { return _goodsid; }
            set { _goodsid = value; }
        }
        /// <summary>
        /// ColorName
        /// </summary>		
        private string _colorname;
        public string ColorName
        {
            get { return _colorname; }
            set { _colorname = value; }
        }
        /// <summary>
        /// Pic
        /// </summary>		
        private string _pic;
        public string Pic
        {
            get { return _pic; }
            set { _pic = value; }
        }

    }
}

