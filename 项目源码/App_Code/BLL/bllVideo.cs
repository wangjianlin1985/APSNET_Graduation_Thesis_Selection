using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�����Ƶҵ���߼���*/
    public class bllVideo{
        /*��Ӵ����Ƶ*/
        public static bool AddVideo(ENTITY.Video video)
        {
            return DAL.dalVideo.AddVideo(video);
        }

        /*����videoId��ȡĳ�������Ƶ��¼*/
        public static ENTITY.Video getSomeVideo(int videoId)
        {
            return DAL.dalVideo.getSomeVideo(videoId);
        }

        /*���´����Ƶ*/
        public static bool EditVideo(ENTITY.Video video)
        {
            return DAL.dalVideo.EditVideo(video);
        }

        /*ɾ�������Ƶ*/
        public static bool DelVideo(string p)
        {
            return DAL.dalVideo.DelVideo(p);
        }

        /*��ѯ�����Ƶ*/
        public static System.Data.DataSet GetVideo(string strWhere)
        {
            return DAL.dalVideo.GetVideo(strWhere);
        }

        /*����������ҳ��ѯ�����Ƶ*/
        public static System.Data.DataTable GetVideo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalVideo.GetVideo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĴ����Ƶ*/
        public static System.Data.DataSet getAllVideo()
        {
            return DAL.dalVideo.getAllVideo();
        }
    }
}
