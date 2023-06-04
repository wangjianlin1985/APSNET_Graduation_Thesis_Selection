using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��Ŀ����ҵ���߼���ʵ��*/
    public class dalSubjectType
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*�����Ŀ����ʵ��*/
        public static bool AddSubjectType(ENTITY.SubjectType subjectType)
        {
            string sql = "insert into SubjectType(typeName) values(@typeName)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@typeName",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = subjectType.typeName; //��������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����typeId��ȡĳ����Ŀ���ͼ�¼*/
        public static ENTITY.SubjectType getSomeSubjectType(int typeId)
        {
            /*������ѯsql*/
            string sql = "select * from SubjectType where typeId=" + typeId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.SubjectType subjectType = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                subjectType = new ENTITY.SubjectType();
                subjectType.typeId = Convert.ToInt32(DataRead["typeId"]);
                subjectType.typeName = DataRead["typeName"].ToString();
            }
            return subjectType;
        }

        /*������Ŀ����ʵ��*/
        public static bool EditSubjectType(ENTITY.SubjectType subjectType)
        {
            string sql = "update SubjectType set typeName=@typeName where typeId=@typeId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@typeName",SqlDbType.VarChar),
             new SqlParameter("@typeId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = subjectType.typeName;
            parm[1].Value = subjectType.typeId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����Ŀ����*/
        public static bool DelSubjectType(string p)
        {
            string sql = "delete from SubjectType where typeId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��Ŀ����*/
        public static DataSet GetSubjectType(string strWhere)
        {
            try
            {
                string strSql = "select * from SubjectType" + strWhere + " order by typeId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ��Ŀ����*/
        public static System.Data.DataTable GetSubjectType(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from SubjectType";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "typeId", strShow, strSql, strWhere, " typeId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllSubjectType()
        {
            try
            {
                string strSql = "select * from SubjectType";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
