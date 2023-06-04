using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*论文题目业务逻辑层实现*/
    public class dalSubject
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加论文题目实现*/
        public static bool AddSubject(ENTITY.Subject subject)
        {
            string sql = "insert into Subject(subjectName,subjectTypeObj,sujectContent,taskFile,otherFile,personNum,teacherObj,addTime) values(@subjectName,@subjectTypeObj,@sujectContent,@taskFile,@otherFile,@personNum,@teacherObj,@addTime)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@subjectName",SqlDbType.VarChar),
             new SqlParameter("@subjectTypeObj",SqlDbType.Int),
             new SqlParameter("@sujectContent",SqlDbType.VarChar),
             new SqlParameter("@taskFile",SqlDbType.VarChar),
             new SqlParameter("@otherFile",SqlDbType.VarChar),
             new SqlParameter("@personNum",SqlDbType.Int),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = subject.subjectName; //题目名称
            parm[1].Value = subject.subjectTypeObj; //题目类型
            parm[2].Value = subject.sujectContent; //题目内容
            parm[3].Value = subject.taskFile; //任务书文件
            parm[4].Value = subject.otherFile; //其他资料文件
            parm[5].Value = subject.personNum; //限选人数
            parm[6].Value = subject.teacherObj; //指导老师
            parm[7].Value = subject.addTime; //发布时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据subjectId获取某条论文题目记录*/
        public static ENTITY.Subject getSomeSubject(int subjectId)
        {
            /*构建查询sql*/
            string sql = "select * from Subject where subjectId=" + subjectId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Subject subject = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                subject = new ENTITY.Subject();
                subject.subjectId = Convert.ToInt32(DataRead["subjectId"]);
                subject.subjectName = DataRead["subjectName"].ToString();
                subject.subjectTypeObj = Convert.ToInt32(DataRead["subjectTypeObj"]);
                subject.sujectContent = DataRead["sujectContent"].ToString();
                subject.taskFile = DataRead["taskFile"].ToString();
                subject.otherFile = DataRead["otherFile"].ToString();
                subject.personNum = Convert.ToInt32(DataRead["personNum"]);
                subject.teacherObj = DataRead["teacherObj"].ToString();
                subject.addTime = Convert.ToDateTime(DataRead["addTime"].ToString());
            }
            return subject;
        }

        /*更新论文题目实现*/
        public static bool EditSubject(ENTITY.Subject subject)
        {
            string sql = "update Subject set subjectName=@subjectName,subjectTypeObj=@subjectTypeObj,sujectContent=@sujectContent,taskFile=@taskFile,otherFile=@otherFile,personNum=@personNum,teacherObj=@teacherObj,addTime=@addTime where subjectId=@subjectId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@subjectName",SqlDbType.VarChar),
             new SqlParameter("@subjectTypeObj",SqlDbType.Int),
             new SqlParameter("@sujectContent",SqlDbType.VarChar),
             new SqlParameter("@taskFile",SqlDbType.VarChar),
             new SqlParameter("@otherFile",SqlDbType.VarChar),
             new SqlParameter("@personNum",SqlDbType.Int),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime),
             new SqlParameter("@subjectId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = subject.subjectName;
            parm[1].Value = subject.subjectTypeObj;
            parm[2].Value = subject.sujectContent;
            parm[3].Value = subject.taskFile;
            parm[4].Value = subject.otherFile;
            parm[5].Value = subject.personNum;
            parm[6].Value = subject.teacherObj;
            parm[7].Value = subject.addTime;
            parm[8].Value = subject.subjectId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除论文题目*/
        public static bool DelSubject(string p)
        {
            string sql = "delete from Subject where subjectId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询论文题目*/
        public static DataSet GetSubject(string strWhere)
        {
            try
            {
                string strSql = "select * from Subject" + strWhere + " order by subjectId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询论文题目*/
        public static System.Data.DataTable GetSubject(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Subject";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "subjectId", strShow, strSql, strWhere, " subjectId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllSubject()
        {
            try
            {
                string strSql = "select * from Subject";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllSubject(String teacherNo)
        {
            try
            {
                string strSql = "select * from Subject where teacherObj='" + teacherNo + "'";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
