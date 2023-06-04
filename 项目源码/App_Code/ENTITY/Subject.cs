using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ENTITY
{
    /// <summary>
    ///Subject 的摘要说明：论文题目实体
    /// </summary>

    public class Subject
    {
        /*题目id*/
        private int _subjectId;
        public int subjectId
        {
            get { return _subjectId; }
            set { _subjectId = value; }
        }

        /*题目名称*/
        private string _subjectName;
        public string subjectName
        {
            get { return _subjectName; }
            set { _subjectName = value; }
        }

        /*题目类型*/
        private int _subjectTypeObj;
        public int subjectTypeObj
        {
            get { return _subjectTypeObj; }
            set { _subjectTypeObj = value; }
        }

        /*题目内容*/
        private string _sujectContent;
        public string sujectContent
        {
            get { return _sujectContent; }
            set { _sujectContent = value; }
        }

        /*任务书文件*/
        private string _taskFile;
        public string taskFile
        {
            get { return _taskFile; }
            set { _taskFile = value; }
        }

        /*其他资料文件*/
        private string _otherFile;
        public string otherFile
        {
            get { return _otherFile; }
            set { _otherFile = value; }
        }

        /*限选人数*/
        private int _personNum;
        public int personNum
        {
            get { return _personNum; }
            set { _personNum = value; }
        }

        /*指导老师*/
        private string _teacherObj;
        public string teacherObj
        {
            get { return _teacherObj; }
            set { _teacherObj = value; }
        }

        /*发布时间*/
        private DateTime _addTime;
        public DateTime addTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }

    }
}
