/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-5-22 16:07:27 
 * 文 件 名：		tb_flag.cs 
 * CLR 版本: 		2.0.50727.3053 
 * 创 建 人：		King
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 备注描述：         
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace lgk.BLL
{
    public class tb_flag
    {
        private readonly lgk.DAL.tb_flag dal = new lgk.DAL.tb_flag();
        private readonly lgk.DAL.tb_leaveMsg lm = new lgk.DAL.tb_leaveMsg();

        /// <summary>
        /// 获取层数
        /// </summary>
        /// <param name="Users01">ID</param>
        /// <returns></returns>
        public int NodeNun(long UserID)
        {
            return dal.NodeNun(UserID);
        }
    }
}
