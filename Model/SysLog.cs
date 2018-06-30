using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lgk.Model
{
    public class SysLog
    {
        /// <summary>
        /// ID
        /// </summary>		
        private long _id;
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// LogType
        /// </summary>		
        private int _logtype;
        public int LogType
        {
            get { return _logtype; }
            set { _logtype = value; }
        }
        /// <summary>
        /// LogLeve
        /// </summary>		
        private int _logleve;
        public int LogLeve
        {
            get { return _logleve; }
            set { _logleve = value; }
        }
        /// <summary>
        /// LogCode
        /// </summary>		
        private string _logcode;
        public string LogCode
        {
            get { return _logcode; }
            set { _logcode = value; }
        }
        /// <summary>
        /// DataInt
        /// </summary>		
        private decimal _dataint;
        public decimal DataInt
        {
            get { return _dataint; }
            set { _dataint = value; }
        }
        /// <summary>
        /// DataStr
        /// </summary>		
        private string _datastr;
        public string DataStr
        {
            get { return _datastr; }
            set { _datastr = value; }
        }
        /// <summary>
        /// LogMsg
        /// </summary>		
        private string _logmsg;
        public string LogMsg
        {
            get { return _logmsg; }
            set { _logmsg = value; }
        }
        /// <summary>
        /// LogDate
        /// </summary>		
        private DateTime _logdate;
        public DateTime LogDate
        {
            get { return _logdate; }
            set { _logdate = value; }
        }
        /// <summary>
        /// Log1
        /// </summary>		
        private string _log1;
        public string Log1
        {
            get { return _log1; }
            set { _log1 = value; }
        }
        /// <summary>
        /// Log2
        /// </summary>		
        private string _log2;
        public string Log2
        {
            get { return _log2; }
            set { _log2 = value; }
        }
        /// <summary>
        /// Log3
        /// </summary>		
        private string _log3;
        public string Log3
        {
            get { return _log3; }
            set { _log3 = value; }
        }
        /// <summary>
        /// Log4
        /// </summary>		
        private string _log4;
        public string Log4
        {
            get { return _log4; }
            set { _log4 = value; }
        }
        /// <summary>
        /// IsDeleted
        /// </summary>		
        private int _isdeleted;
        public int IsDeleted
        {
            get { return _isdeleted; }
            set { _isdeleted = value; }
        }        
    }
}
