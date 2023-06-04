using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*������Ŀҵ���߼���ʵ��*/
    public class dalSubject
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*���������Ŀʵ��*/
        public static bool AddSubject(ENTITY.Subject subject)
        {
            string sql = "insert into Subject(subjectName,subjectTypeObj,sujectContent,taskFile,otherFile,personNum,teacherObj,addTime) values(@subjectName,@subjectTypeObj,@sujectContent,@taskFile,@otherFile,@personNum,@teacherObj,@addTime)";
            /*����sql����*/
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
            /*��������ֵ*/
            parm[0].Value = subject.subjectName; //��Ŀ����
            parm[1].Value = subject.subjectTypeObj; //��Ŀ����
            parm[2].Value = subject.sujectContent; //��Ŀ����
            parm[3].Value = subject.taskFile; //�������ļ�
            parm[4].Value = subject.otherFile; //���������ļ�
            parm[5].Value = subject.personNum; //��ѡ����
            parm[6].Value = subject.teacherObj; //ָ����ʦ
            parm[7].Value = subject.addTime; //����ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����subjectId��ȡĳ��������Ŀ��¼*/
        public static ENTITY.Subject getSomeSubject(int subjectId)
        {
            /*������ѯsql*/
            string sql = "select * from Subject where subjectId=" + subjectId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Subject subject = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*����������Ŀʵ��*/
        public static bool EditSubject(ENTITY.Subject subject)
        {
            string sql = "update Subject set subjectName=@subjectName,subjectTypeObj=@subjectTypeObj,sujectContent=@sujectContent,taskFile=@taskFile,otherFile=@otherFile,personNum=@personNum,teacherObj=@teacherObj,addTime=@addTime where subjectId=@subjectId";
            /*����sql������Ϣ*/
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
            /*Ϊ������ֵ*/
            parm[0].Value = subject.subjectName;
            parm[1].Value = subject.subjectTypeObj;
            parm[2].Value = subject.sujectContent;
            parm[3].Value = subject.taskFile;
            parm[4].Value = subject.otherFile;
            parm[5].Value = subject.personNum;
            parm[6].Value = subject.teacherObj;
            parm[7].Value = subject.addTime;
            parm[8].Value = subject.subjectId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��������Ŀ*/
        public static bool DelSubject(string p)
        {
            string sql = "delete from Subject where subjectId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ������Ŀ*/
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

        /*��ѯ������Ŀ*/
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
