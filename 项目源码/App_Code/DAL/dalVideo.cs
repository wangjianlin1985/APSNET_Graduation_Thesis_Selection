using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�����Ƶҵ���߼���ʵ��*/
    public class dalVideo
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��Ӵ����Ƶʵ��*/
        public static bool AddVideo(ENTITY.Video video)
        {
            string sql = "insert into Video(subjectObj,userObj,videoFile,videoTime,videoDate,videoMemo) values(@subjectObj,@userObj,@videoFile,@videoTime,@videoDate,@videoMemo)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@subjectObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@videoFile",SqlDbType.VarChar),
             new SqlParameter("@videoTime",SqlDbType.VarChar),
             new SqlParameter("@videoDate",SqlDbType.DateTime),
             new SqlParameter("@videoMemo",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = video.subjectObj; //������Ŀ
            parm[1].Value = video.userObj; //���ѧ��
            parm[2].Value = video.videoFile; //�����Ƶ
            parm[3].Value = video.videoTime; //��Ƶʱ��
            parm[4].Value = video.videoDate; //�������
            parm[5].Value = video.videoMemo; //������Ϣ

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����videoId��ȡĳ�������Ƶ��¼*/
        public static ENTITY.Video getSomeVideo(int videoId)
        {
            /*������ѯsql*/
            string sql = "select * from Video where videoId=" + videoId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Video video = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                video = new ENTITY.Video();
                video.videoId = Convert.ToInt32(DataRead["videoId"]);
                video.subjectObj = Convert.ToInt32(DataRead["subjectObj"]);
                video.userObj = DataRead["userObj"].ToString();
                video.videoFile = DataRead["videoFile"].ToString();
                video.videoTime = DataRead["videoTime"].ToString();
                video.videoDate = Convert.ToDateTime(DataRead["videoDate"].ToString());
                video.videoMemo = DataRead["videoMemo"].ToString();
            }
            return video;
        }

        /*���´����Ƶʵ��*/
        public static bool EditVideo(ENTITY.Video video)
        {
            string sql = "update Video set subjectObj=@subjectObj,userObj=@userObj,videoFile=@videoFile,videoTime=@videoTime,videoDate=@videoDate,videoMemo=@videoMemo where videoId=@videoId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@subjectObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@videoFile",SqlDbType.VarChar),
             new SqlParameter("@videoTime",SqlDbType.VarChar),
             new SqlParameter("@videoDate",SqlDbType.DateTime),
             new SqlParameter("@videoMemo",SqlDbType.VarChar),
             new SqlParameter("@videoId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = video.subjectObj;
            parm[1].Value = video.userObj;
            parm[2].Value = video.videoFile;
            parm[3].Value = video.videoTime;
            parm[4].Value = video.videoDate;
            parm[5].Value = video.videoMemo;
            parm[6].Value = video.videoId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ�������Ƶ*/
        public static bool DelVideo(string p)
        {
            string sql = "delete from Video where videoId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ�����Ƶ*/
        public static DataSet GetVideo(string strWhere)
        {
            try
            {
                string strSql = "select * from Video" + strWhere + " order by videoId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ�����Ƶ*/
        public static System.Data.DataTable GetVideo(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Video";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "videoId", strShow, strSql, strWhere, " videoId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllVideo()
        {
            try
            {
                string strSql = "select * from Video";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
