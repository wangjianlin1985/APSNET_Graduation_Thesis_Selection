using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�༶ҵ���߼���ʵ��*/
    public class dalClassInfo
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��Ӱ༶ʵ��*/
        public static bool AddClassInfo(ENTITY.ClassInfo classInfo)
        {
            string sql = "insert into ClassInfo(classNo,className,college,specialName,bornDate,mainTeacher,classMemo) values(@classNo,@className,@college,@specialName,@bornDate,@mainTeacher,@classMemo)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@classNo",SqlDbType.VarChar),
             new SqlParameter("@className",SqlDbType.VarChar),
             new SqlParameter("@college",SqlDbType.VarChar),
             new SqlParameter("@specialName",SqlDbType.VarChar),
             new SqlParameter("@bornDate",SqlDbType.DateTime),
             new SqlParameter("@mainTeacher",SqlDbType.VarChar),
             new SqlParameter("@classMemo",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = classInfo.classNo; //�༶���
            parm[1].Value = classInfo.className; //�༶����
            parm[2].Value = classInfo.college; //����ѧԺ
            parm[3].Value = classInfo.specialName; //����רҵ
            parm[4].Value = classInfo.bornDate; //��������
            parm[5].Value = classInfo.mainTeacher; //������
            parm[6].Value = classInfo.classMemo; //�༶��ע

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����classNo��ȡĳ���༶��¼*/
        public static ENTITY.ClassInfo getSomeClassInfo(string classNo)
        {
            /*������ѯsql*/
            string sql = "select * from ClassInfo where classNo='" + classNo + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.ClassInfo classInfo = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                classInfo = new ENTITY.ClassInfo();
                classInfo.classNo = DataRead["classNo"].ToString();
                classInfo.className = DataRead["className"].ToString();
                classInfo.college = DataRead["college"].ToString();
                classInfo.specialName = DataRead["specialName"].ToString();
                classInfo.bornDate = Convert.ToDateTime(DataRead["bornDate"].ToString());
                classInfo.mainTeacher = DataRead["mainTeacher"].ToString();
                classInfo.classMemo = DataRead["classMemo"].ToString();
            }
            return classInfo;
        }

        /*���°༶ʵ��*/
        public static bool EditClassInfo(ENTITY.ClassInfo classInfo)
        {
            string sql = "update ClassInfo set className=@className,college=@college,specialName=@specialName,bornDate=@bornDate,mainTeacher=@mainTeacher,classMemo=@classMemo where classNo=@classNo";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@className",SqlDbType.VarChar),
             new SqlParameter("@college",SqlDbType.VarChar),
             new SqlParameter("@specialName",SqlDbType.VarChar),
             new SqlParameter("@bornDate",SqlDbType.DateTime),
             new SqlParameter("@mainTeacher",SqlDbType.VarChar),
             new SqlParameter("@classMemo",SqlDbType.VarChar),
             new SqlParameter("@classNo",SqlDbType.VarChar)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = classInfo.className;
            parm[1].Value = classInfo.college;
            parm[2].Value = classInfo.specialName;
            parm[3].Value = classInfo.bornDate;
            parm[4].Value = classInfo.mainTeacher;
            parm[5].Value = classInfo.classMemo;
            parm[6].Value = classInfo.classNo;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ���༶*/
        public static bool DelClassInfo(string p)
        {
            string sql = "";
            string[] ids = p.Split(',');
            for(int i=0;i<ids.Length;i++)
            {
                if(i != ids.Length-1)
                  sql += "'" + ids[i] + "',";
                else
                  sql += "'" + ids[i] + "'";
            }
            sql = "delete from ClassInfo where classNo in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ�༶*/
        public static DataSet GetClassInfo(string strWhere)
        {
            try
            {
                string strSql = "select * from ClassInfo" + strWhere + " order by classNo asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ�༶*/
        public static System.Data.DataTable GetClassInfo(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from ClassInfo";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "classNo", strShow, strSql, strWhere, " classNo asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllClassInfo()
        {
            try
            {
                string strSql = "select * from ClassInfo";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
