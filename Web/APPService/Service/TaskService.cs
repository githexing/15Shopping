using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService.Service
{
    public class TaskService : AllCore
    {
        //获取任务
        public Dictionary<string, string> GetTask(long userid)
        {
            string message;
            long taskid;
            int state = Task(userid, out taskid);

            if (state == 0) message = "没有任务";
            else if (state == 1) message = "未完成";
            else if (state == 2) message = "已完成";
            else message = "任务异常";

            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("state", state.ToString());//状态,0:没有任务,1:未完成,2:已完成
            dic.Add("statetext", message); //状态说明 
            dic.Add("taskkey", AESEncrypt.Encrypt(taskid.ToString())); //任务KEY
            dic.Add("task", getParamVarchar("RunTask")); //任务步数
            LogHelper.SaveLog(string.Format("获取任务 taskkey:{0} ,taskid:{1}", AESEncrypt.Encrypt(taskid.ToString()), taskid), "task");
            return dic;
        }

        //完成任务 timelong:时长 ,donenum:完成步数
        public bool DoneTask(long userid, string taskkey ,string timelong,string donenum, out string message)
        {
            long _taskid;

            int state = Task(userid, out _taskid);

            //if (state == 0) message = "任务超时";
            //else if (state == 1) message = "未完成";
            //else if (state == 2) message = "已完成";
            //else message = "任务异常";
            LogHelper.SaveLog(string.Format("完成任务 taskkey:{0} ,taskid:{1}", taskkey, AESEncrypt.Encrypt(_taskid.ToString())), "task");
            if (taskkey != AESEncrypt.Encrypt(_taskid.ToString()))
            {
                message = "任务已过期";
                return false;
            }

            if (state != 1)
            {
                message = "任务不存在";
                return false;
            }

            int cheat = getParamInt("RunTaskCheatSwith");
            if (cheat == 1)
            {
                message = getParamVarchar("RunTaskCheatTip");
                return false;
            }

            int result = flag_Award_TaskDone(userid, _taskid, timelong, donenum);
            if (result == 0)
                message = "任务成功完成";
            else if (result == 1)
            {
                message = "任务不存在，奖金已发完";
                return false;
            }
            else if (result == 2)
            {
                message = "任务不存在，或任务已完成";
                return false;
            }
            else
            {
                message = getParamVarchar("RunTaskCheatTip");
                return false;
            }

            return true;
        }
        //任务记录
        public object ListTask(long userid)
        {
            DateTime now = DateTime.Now;
            int task = getParamInt("RunTask");
            lgk.BLL.tb_BonusPoly polyBll = new lgk.BLL.tb_BonusPoly();
            var list = polyBll.GetModelList("userid=" + userid + " and ShareDate < GETDATE()").Select(s => new
            {
                ExpTime = s.ShareDate,
                State = s.TaskCompletedFlag == 1 ? 1 : s.ShareDate < now || s.Flag == 1 ? -1 : 0,
                StateText = s.TaskCompletedFlag == 1 ? "已完成" : s.ShareDate < now || s.Flag == 1 ? "已过期" : "未跑步",
                Task = task,
                Bonus = s.Bonus,
                TimeLong = "",
                DoneNum = 0 ,
                FreeBonus = s.TaskCompletedFlag == 1 ? s.TaskBonus : 0
            }).OrderByDescending(b=>b.ExpTime).ToList();

            var list2 = polyBll.GetModelList("userid=" + userid + " and ShareDate > GETDATE()").Select(s => new
            {
                ExpTime = s.ShareDate,
                State = s.TaskCompletedFlag == 1 ? 1 : s.ShareDate < now || s.Flag == 1  ? -1 : 0,
                StateText = s.TaskCompletedFlag == 1 ? "已完成" : s.ShareDate < now || s.Flag == 1 ? "已过期" : "未跑步",
                Task = task,
                Bonus = s.Bonus,
                TimeLong = "",
                DoneNum = 0,
                FreeBonus = s.TaskCompletedFlag == 1 ? s.TaskBonus : 0
            }).OrderBy(b => b.ExpTime).ToList();

            if (list2.Count > 0)
            {
                list.AddRange(list2.Take(1));
            }

            return list.OrderByDescending(s=>s.ExpTime) ;
        }
        private int Task(long userid, out long taskid)
        {
            int state;
            taskid = 0;

            lgk.BLL.tb_BonusPoly poly = new lgk.BLL.tb_BonusPoly();
            var task = poly.GetTask(userid);
            

            if (task == null)
            {
                state = 0;
            }
            else if (task.TaskCompletedFlag == 0)
            {
                taskid = task.ID;
                state = 1;
            }
            else
            {
                state = 2;
            }
            
            return state;
        }
    }
}