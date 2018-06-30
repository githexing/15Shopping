using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace lgk.Model
{
    //tb_goods_size
    public class tb_goods_size
    {

        /// <summary>
        /// SizeID
        /// </summary>		
        private int _sizeid;
        public int SizeID
        {
            get { return _sizeid; }
            set { _sizeid = value; }
        }
        /// <summary>
        /// TypeID
        /// </summary>		
        private int _typeid;
        public int TypeID
        {
            get { return _typeid; }
            set { _typeid = value; }
        }
        /// <summary>
        /// Name
        /// </summary>		
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}

