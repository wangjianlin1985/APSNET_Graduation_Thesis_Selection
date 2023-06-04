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
    ///ClassInfo 的摘要说明：班级实体
    /// </summary>

    public class ClassInfo
    {
        /*班级编号*/
        private string _classNo;
        public string classNo
        {
            get { return _classNo; }
            set { _classNo = value; }
        }

        /*班级名称*/
        private string _className;
        public string className
        {
            get { return _className; }
            set { _className = value; }
        }

        /*所属学院*/
        private string _college;
        public string college
        {
            get { return _college; }
            set { _college = value; }
        }

        /*所属专业*/
        private string _specialName;
        public string specialName
        {
            get { return _specialName; }
            set { _specialName = value; }
        }

        /*成立日期*/
        private DateTime _bornDate;
        public DateTime bornDate
        {
            get { return _bornDate; }
            set { _bornDate = value; }
        }

        /*班主任*/
        private string _mainTeacher;
        public string mainTeacher
        {
            get { return _mainTeacher; }
            set { _mainTeacher = value; }
        }

        /*班级备注*/
        private string _classMemo;
        public string classMemo
        {
            get { return _classMemo; }
            set { _classMemo = value; }
        }

    }
}
