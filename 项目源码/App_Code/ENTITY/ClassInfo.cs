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
    ///ClassInfo ��ժҪ˵�����༶ʵ��
    /// </summary>

    public class ClassInfo
    {
        /*�༶���*/
        private string _classNo;
        public string classNo
        {
            get { return _classNo; }
            set { _classNo = value; }
        }

        /*�༶����*/
        private string _className;
        public string className
        {
            get { return _className; }
            set { _className = value; }
        }

        /*����ѧԺ*/
        private string _college;
        public string college
        {
            get { return _college; }
            set { _college = value; }
        }

        /*����רҵ*/
        private string _specialName;
        public string specialName
        {
            get { return _specialName; }
            set { _specialName = value; }
        }

        /*��������*/
        private DateTime _bornDate;
        public DateTime bornDate
        {
            get { return _bornDate; }
            set { _bornDate = value; }
        }

        /*������*/
        private string _mainTeacher;
        public string mainTeacher
        {
            get { return _mainTeacher; }
            set { _mainTeacher = value; }
        }

        /*�༶��ע*/
        private string _classMemo;
        public string classMemo
        {
            get { return _classMemo; }
            set { _classMemo = value; }
        }

    }
}
