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
    ///Opus 的摘要说明：学生成果实体
    /// </summary>

    public class Opus
    {
        /*成果id*/
        private int _opusId;
        public int opusId
        {
            get { return _opusId; }
            set { _opusId = value; }
        }

        /*论文题目*/
        private int _subjectObj;
        public int subjectObj
        {
            get { return _subjectObj; }
            set { _subjectObj = value; }
        }

        /*提交学生*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*开题报告*/
        private string _ktbg;
        public string ktbg
        {
            get { return _ktbg; }
            set { _ktbg = value; }
        }

        /*外文文献翻译*/
        private string _wwwx;
        public string wwwx
        {
            get { return _wwwx; }
            set { _wwwx = value; }
        }

        /*论文初稿*/
        private string _lwcg;
        public string lwcg
        {
            get { return _lwcg; }
            set { _lwcg = value; }
        }

        /*论文终稿*/
        private string _lwzg;
        public string lwzg
        {
            get { return _lwzg; }
            set { _lwzg = value; }
        }

        /*其他文件*/
        private string _otherFile;
        public string otherFile
        {
            get { return _otherFile; }
            set { _otherFile = value; }
        }

        /*论文成绩*/
        private string _chengji;
        public string chengji
        {
            get { return _chengji; }
            set { _chengji = value; }
        }

        /*老师评价*/
        private string _evaluate;
        public string evaluate
        {
            get { return _evaluate; }
            set { _evaluate = value; }
        }

    }
}
