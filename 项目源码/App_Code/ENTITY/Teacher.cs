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
    ///Teacher 的摘要说明：教师实体
    /// </summary>

    public class Teacher
    {
        /*教师编号*/
        private string _teacherNo;
        public string teacherNo
        {
            get { return _teacherNo; }
            set { _teacherNo = value; }
        }

        /*登录密码*/
        private string _password;
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        /*教师姓名*/
        private string _teacherName;
        public string teacherName
        {
            get { return _teacherName; }
            set { _teacherName = value; }
        }

        /*教师性别*/
        private string _teacherSex;
        public string teacherSex
        {
            get { return _teacherSex; }
            set { _teacherSex = value; }
        }

        /*出生日期*/
        private DateTime _birthDate;
        public DateTime birthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        /*教师照片*/
        private string _teacherPhoto;
        public string teacherPhoto
        {
            get { return _teacherPhoto; }
            set { _teacherPhoto = value; }
        }

        /*教师职称*/
        private string _zhicheng;
        public string zhicheng
        {
            get { return _zhicheng; }
            set { _zhicheng = value; }
        }

        /*联系电话*/
        private string _telephone;
        public string telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        /*教师介绍*/
        private string _teacherDesc;
        public string teacherDesc
        {
            get { return _teacherDesc; }
            set { _teacherDesc = value; }
        }

    }
}
