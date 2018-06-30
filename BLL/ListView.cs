/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-1-12 14:01:09 
 * 文 件 名：		ListView.cs 
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
using lgk.Model;

namespace lgk.BLL
{
    public class ViewFind
    {
        private int _ParentID;
        private int _Location;
        public ViewFind(int _ParentID)
        {
            this._ParentID = _ParentID;
        }
        public ViewFind(int _ParentID, int _Location)
        {
            this._ParentID = _ParentID;
            this._Location = _Location;
        }
        public bool FindNode(lgk.Model.tb_user view)
        {
            if (view.ParentID == this._ParentID && view.Location == this._Location)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Find(lgk.Model.tb_user view)
        {
            if (view.ParentID == this._ParentID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool FindID(lgk.Model.tb_user view)
        {
            if (view.UserID == this._ParentID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class RowView : List<lgk.Model.tb_user>
    {
        public RowView() { }
        public bool Exist(int key)
        {
            lgk.Model.tb_user view = this.Find(new ViewFind(key).Find);
            if (view == default(lgk.Model.tb_user))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Exist(int ParentID, int Location, out int UserID)
        {
            lgk.Model.tb_user view = this.Find(new ViewFind(ParentID, Location).FindNode);
            if (view == default(lgk.Model.tb_user))
            {
                UserID = 0;
                return false;
            }
            else
            {

                UserID = Convert.ToInt32(view.UserID);
                return true;
            }
        }
        public lgk.Model.tb_user GetModel(int key)
        {
            lgk.Model.tb_user view = this.Find(new ViewFind(key).FindID);
            if (view == default(lgk.Model.tb_user))
            {
                return null;
            }
            else
            {
                return view;
            }
        }
    }
}
