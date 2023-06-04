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
    ///Subject ��ժҪ˵����������Ŀʵ��
    /// </summary>

    public class Subject
    {
        /*��Ŀid*/
        private int _subjectId;
        public int subjectId
        {
            get { return _subjectId; }
            set { _subjectId = value; }
        }

        /*��Ŀ����*/
        private string _subjectName;
        public string subjectName
        {
            get { return _subjectName; }
            set { _subjectName = value; }
        }

        /*��Ŀ����*/
        private int _subjectTypeObj;
        public int subjectTypeObj
        {
            get { return _subjectTypeObj; }
            set { _subjectTypeObj = value; }
        }

        /*��Ŀ����*/
        private string _sujectContent;
        public string sujectContent
        {
            get { return _sujectContent; }
            set { _sujectContent = value; }
        }

        /*�������ļ�*/
        private string _taskFile;
        public string taskFile
        {
            get { return _taskFile; }
            set { _taskFile = value; }
        }

        /*���������ļ�*/
        private string _otherFile;
        public string otherFile
        {
            get { return _otherFile; }
            set { _otherFile = value; }
        }

        /*��ѡ����*/
        private int _personNum;
        public int personNum
        {
            get { return _personNum; }
            set { _personNum = value; }
        }

        /*ָ����ʦ*/
        private string _teacherObj;
        public string teacherObj
        {
            get { return _teacherObj; }
            set { _teacherObj = value; }
        }

        /*����ʱ��*/
        private DateTime _addTime;
        public DateTime addTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }

    }
}
