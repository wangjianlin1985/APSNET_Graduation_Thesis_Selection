using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*ѧ���ɹ�ҵ���߼���ʵ��*/
    public class dalOpus
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*���ѧ���ɹ�ʵ��*/
        public static bool AddOpus(ENTITY.Opus opus)
        {
            string sql = "insert into Opus(subjectObj,userObj,ktbg,wwwx,lwcg,lwzg,otherFile,chengji,evaluate) values(@subjectObj,@userObj,@ktbg,@wwwx,@lwcg,@lwzg,@otherFile,@chengji,@evaluate)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@subjectObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@ktbg",SqlDbType.VarChar),
             new SqlParameter("@wwwx",SqlDbType.VarChar),
             new SqlParameter("@lwcg",SqlDbType.VarChar),
             new SqlParameter("@lwzg",SqlDbType.VarChar),
             new SqlParameter("@otherFile",SqlDbType.VarChar),
             new SqlParameter("@chengji",SqlDbType.VarChar),
             new SqlParameter("@evaluate",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = opus.subjectObj; //������Ŀ
            parm[1].Value = opus.userObj; //�ύѧ��
            parm[2].Value = opus.ktbg; //���ⱨ��
            parm[3].Value = opus.wwwx; //�������׷���
            parm[4].Value = opus.lwcg; //���ĳ���
            parm[5].Value = opus.lwzg; //�����ո�
            parm[6].Value = opus.otherFile; //�����ļ�
            parm[7].Value = opus.chengji; //���ĳɼ�
            parm[8].Value = opus.evaluate; //��ʦ����

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����opusId��ȡĳ��ѧ���ɹ���¼*/
        public static ENTITY.Opus getSomeOpus(int opusId)
        {
            /*������ѯsql*/
            string sql = "select * from Opus where opusId=" + opusId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Opus opus = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                opus = new ENTITY.Opus();
                opus.opusId = Convert.ToInt32(DataRead["opusId"]);
                opus.subjectObj = Convert.ToInt32(DataRead["subjectObj"]);
                opus.userObj = DataRead["userObj"].ToString();
                opus.ktbg = DataRead["ktbg"].ToString();
                opus.wwwx = DataRead["wwwx"].ToString();
                opus.lwcg = DataRead["lwcg"].ToString();
                opus.lwzg = DataRead["lwzg"].ToString();
                opus.otherFile = DataRead["otherFile"].ToString();
                opus.chengji = DataRead["chengji"].ToString();
                opus.evaluate = DataRead["evaluate"].ToString();
            }
            return opus;
        }

        /*����ѧ���ɹ�ʵ��*/
        public static bool EditOpus(ENTITY.Opus opus)
        {
            string sql = "update Opus set subjectObj=@subjectObj,userObj=@userObj,ktbg=@ktbg,wwwx=@wwwx,lwcg=@lwcg,lwzg=@lwzg,otherFile=@otherFile,chengji=@chengji,evaluate=@evaluate where opusId=@opusId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@subjectObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@ktbg",SqlDbType.VarChar),
             new SqlParameter("@wwwx",SqlDbType.VarChar),
             new SqlParameter("@lwcg",SqlDbType.VarChar),
             new SqlParameter("@lwzg",SqlDbType.VarChar),
             new SqlParameter("@otherFile",SqlDbType.VarChar),
             new SqlParameter("@chengji",SqlDbType.VarChar),
             new SqlParameter("@evaluate",SqlDbType.VarChar),
             new SqlParameter("@opusId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = opus.subjectObj;
            parm[1].Value = opus.userObj;
            parm[2].Value = opus.ktbg;
            parm[3].Value = opus.wwwx;
            parm[4].Value = opus.lwcg;
            parm[5].Value = opus.lwzg;
            parm[6].Value = opus.otherFile;
            parm[7].Value = opus.chengji;
            parm[8].Value = opus.evaluate;
            parm[9].Value = opus.opusId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��ѧ���ɹ�*/
        public static bool DelOpus(string p)
        {
            string sql = "delete from Opus where opusId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯѧ���ɹ�*/
        public static DataSet GetOpus(string strWhere)
        {
            try
            {
                string strSql = "select * from Opus" + strWhere + " order by opusId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯѧ���ɹ�*/
        public static System.Data.DataTable GetOpus(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Opus";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "opusId", strShow, strSql, strWhere, " opusId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /*��ʦ��ѯѧ���ɹ�*/
        public static System.Data.DataTable teacherGetOpus(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from OpusTeacherView";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "opusId", strShow, strSql, strWhere, " opusId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllOpus()
        {
            try
            {
                string strSql = "select * from Opus";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
