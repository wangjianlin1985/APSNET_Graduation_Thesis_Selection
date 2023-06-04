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
    ///Teacher ��ժҪ˵������ʦʵ��
    /// </summary>

    public class Teacher
    {
        /*��ʦ���*/
        private string _teacherNo;
        public string teacherNo
        {
            get { return _teacherNo; }
            set { _teacherNo = value; }
        }

        /*��¼����*/
        private string _password;
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        /*��ʦ����*/
        private string _teacherName;
        public string teacherName
        {
            get { return _teacherName; }
            set { _teacherName = value; }
        }

        /*��ʦ�Ա�*/
        private string _teacherSex;
        public string teacherSex
        {
            get { return _teacherSex; }
            set { _teacherSex = value; }
        }

        /*��������*/
        private DateTime _birthDate;
        public DateTime birthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        /*��ʦ��Ƭ*/
        private string _teacherPhoto;
        public string teacherPhoto
        {
            get { return _teacherPhoto; }
            set { _teacherPhoto = value; }
        }

        /*��ʦְ��*/
        private string _zhicheng;
        public string zhicheng
        {
            get { return _zhicheng; }
            set { _zhicheng = value; }
        }

        /*��ϵ�绰*/
        private string _telephone;
        public string telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        /*��ʦ����*/
        private string _teacherDesc;
        public string teacherDesc
        {
            get { return _teacherDesc; }
            set { _teacherDesc = value; }
        }

    }
}
