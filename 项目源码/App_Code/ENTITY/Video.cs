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
    ///Video ��ժҪ˵���������Ƶʵ��
    /// </summary>

    public class Video
    {
        /*��Ƶid*/
        private int _videoId;
        public int videoId
        {
            get { return _videoId; }
            set { _videoId = value; }
        }

        /*������Ŀ*/
        private int _subjectObj;
        public int subjectObj
        {
            get { return _subjectObj; }
            set { _subjectObj = value; }
        }

        /*���ѧ��*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*�����Ƶ*/
        private string _videoFile;
        public string videoFile
        {
            get { return _videoFile; }
            set { _videoFile = value; }
        }

        /*��Ƶʱ��*/
        private string _videoTime;
        public string videoTime
        {
            get { return _videoTime; }
            set { _videoTime = value; }
        }

        /*�������*/
        private DateTime _videoDate;
        public DateTime videoDate
        {
            get { return _videoDate; }
            set { _videoDate = value; }
        }

        /*������Ϣ*/
        private string _videoMemo;
        public string videoMemo
        {
            get { return _videoMemo; }
            set { _videoMemo = value; }
        }

    }
}
