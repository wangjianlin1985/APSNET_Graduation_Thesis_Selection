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
    ///SubSelect ��ժҪ˵����ѧ��ѡ��ʵ��
    /// </summary>

    public class SubSelect
    {
        /*ѡ��id*/
        private int _selectId;
        public int selectId
        {
            get { return _selectId; }
            set { _selectId = value; }
        }

        /*������Ŀ*/
        private int _subjectObj;
        public int subjectObj
        {
            get { return _subjectObj; }
            set { _subjectObj = value; }
        }

        /*ѡ��ѧ��*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*ѡ��ʱ��*/
        private DateTime _selectTime;
        public DateTime selectTime
        {
            get { return _selectTime; }
            set { _selectTime = value; }
        }

        /*���״̬*/
        private string _shenHeState;
        public string shenHeState
        {
            get { return _shenHeState; }
            set { _shenHeState = value; }
        }

    }
}
