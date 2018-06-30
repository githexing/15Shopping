using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace lgk.BLL
{
    public partial class tb_journal
    {

        public DataSet GetListByPage(long UserID, int PageIndex, int PageSize, out int PageCount, out int TotalCount,string FindKey,int _type)
        {
            return dal.GetListByPage(UserID, PageIndex, PageSize, out PageCount, out TotalCount, FindKey,_type);
        }
        public DataSet GetListYTByPage(long UserID, int PageIndex, int PageSize, out int PageCount, out int TotalCount, string FindKey, int _type)
        {
            return dal.GetListYTByPage(UserID, PageIndex, PageSize, out PageCount, out TotalCount, FindKey, _type);
        }
    }
}
