
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace lgk.BLL
{
    public partial class tb_BonusPoly
    {
        /// <summary>
		/// 得到一个对象实体
		/// </summary>
		public lgk.Model.tb_BonusPoly GetTask(long UserID)
        {
            return dal.GetTask(UserID);
        }


    }
}
