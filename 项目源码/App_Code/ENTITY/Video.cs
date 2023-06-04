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
    ///Video 的摘要说明：答辩视频实体
    /// </summary>

    public class Video
    {
        /*视频id*/
        private int _videoId;
        public int videoId
        {
            get { return _videoId; }
            set { _videoId = value; }
        }

        /*论文题目*/
        private int _subjectObj;
        public int subjectObj
        {
            get { return _subjectObj; }
            set { _subjectObj = value; }
        }

        /*答辩学生*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*答辩视频*/
        private string _videoFile;
        public string videoFile
        {
            get { return _videoFile; }
            set { _videoFile = value; }
        }

        /*视频时间*/
        private string _videoTime;
        public string videoTime
        {
            get { return _videoTime; }
            set { _videoTime = value; }
        }

        /*答辩日期*/
        private DateTime _videoDate;
        public DateTime videoDate
        {
            get { return _videoDate; }
            set { _videoDate = value; }
        }

        /*附加信息*/
        private string _videoMemo;
        public string videoMemo
        {
            get { return _videoMemo; }
            set { _videoMemo = value; }
        }

    }
}
