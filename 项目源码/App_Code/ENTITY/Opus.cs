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
    ///Opus ��ժҪ˵����ѧ���ɹ�ʵ��
    /// </summary>

    public class Opus
    {
        /*�ɹ�id*/
        private int _opusId;
        public int opusId
        {
            get { return _opusId; }
            set { _opusId = value; }
        }

        /*������Ŀ*/
        private int _subjectObj;
        public int subjectObj
        {
            get { return _subjectObj; }
            set { _subjectObj = value; }
        }

        /*�ύѧ��*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*���ⱨ��*/
        private string _ktbg;
        public string ktbg
        {
            get { return _ktbg; }
            set { _ktbg = value; }
        }

        /*�������׷���*/
        private string _wwwx;
        public string wwwx
        {
            get { return _wwwx; }
            set { _wwwx = value; }
        }

        /*���ĳ���*/
        private string _lwcg;
        public string lwcg
        {
            get { return _lwcg; }
            set { _lwcg = value; }
        }

        /*�����ո�*/
        private string _lwzg;
        public string lwzg
        {
            get { return _lwzg; }
            set { _lwzg = value; }
        }

        /*�����ļ�*/
        private string _otherFile;
        public string otherFile
        {
            get { return _otherFile; }
            set { _otherFile = value; }
        }

        /*���ĳɼ�*/
        private string _chengji;
        public string chengji
        {
            get { return _chengji; }
            set { _chengji = value; }
        }

        /*��ʦ����*/
        private string _evaluate;
        public string evaluate
        {
            get { return _evaluate; }
            set { _evaluate = value; }
        }

    }
}
