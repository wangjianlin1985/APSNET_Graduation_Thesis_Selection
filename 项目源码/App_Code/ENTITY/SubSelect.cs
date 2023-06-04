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
    ///SubSelect 的摘要说明：学生选题实体
    /// </summary>

    public class SubSelect
    {
        /*选题id*/
        private int _selectId;
        public int selectId
        {
            get { return _selectId; }
            set { _selectId = value; }
        }

        /*论文题目*/
        private int _subjectObj;
        public int subjectObj
        {
            get { return _subjectObj; }
            set { _subjectObj = value; }
        }

        /*选题学生*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*选题时间*/
        private DateTime _selectTime;
        public DateTime selectTime
        {
            get { return _selectTime; }
            set { _selectTime = value; }
        }

        /*审核状态*/
        private string _shenHeState;
        public string shenHeState
        {
            get { return _shenHeState; }
            set { _shenHeState = value; }
        }

    }
}
