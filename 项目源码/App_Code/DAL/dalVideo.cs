using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*答辩视频业务逻辑层实现*/
    public class dalVideo
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加答辩视频实现*/
        public static bool AddVideo(ENTITY.Video video)
        {
            string sql = "insert into Video(subjectObj,userObj,videoFile,videoTime,videoDate,videoMemo) values(@subjectObj,@userObj,@videoFile,@videoTime,@videoDate,@videoMemo)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@subjectObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@videoFile",SqlDbType.VarChar),
             new SqlParameter("@videoTime",SqlDbType.VarChar),
             new SqlParameter("@videoDate",SqlDbType.DateTime),
             new SqlParameter("@videoMemo",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = video.subjectObj; //论文题目
            parm[1].Value = video.userObj; //答辩学生
            parm[2].Value = video.videoFile; //答辩视频
            parm[3].Value = video.videoTime; //视频时间
            parm[4].Value = video.videoDate; //答辩日期
            parm[5].Value = video.videoMemo; //附加信息

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据videoId获取某条答辩视频记录*/
        public static ENTITY.Video getSomeVideo(int videoId)
        {
            /*构建查询sql*/
            string sql = "select * from Video where videoId=" + videoId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Video video = null;
            /*如果查询存在记录，就包装到对象中返回*/
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

        /*更新答辩视频实现*/
        public static bool EditVideo(ENTITY.Video video)
        {
            string sql = "update Video set subjectObj=@subjectObj,userObj=@userObj,videoFile=@videoFile,videoTime=@videoTime,videoDate=@videoDate,videoMemo=@videoMemo where videoId=@videoId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@subjectObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@videoFile",SqlDbType.VarChar),
             new SqlParameter("@videoTime",SqlDbType.VarChar),
             new SqlParameter("@videoDate",SqlDbType.DateTime),
             new SqlParameter("@videoMemo",SqlDbType.VarChar),
             new SqlParameter("@videoId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = video.subjectObj;
            parm[1].Value = video.userObj;
            parm[2].Value = video.videoFile;
            parm[3].Value = video.videoTime;
            parm[4].Value = video.videoDate;
            parm[5].Value = video.videoMemo;
            parm[6].Value = video.videoId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除答辩视频*/
        public static bool DelVideo(string p)
        {
            string sql = "delete from Video where videoId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询答辩视频*/
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

        /*查询答辩视频*/
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
