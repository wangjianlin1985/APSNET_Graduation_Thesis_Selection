using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��ʦҵ���߼���ʵ��*/
    public class dalTeacher
    {
        /*��ִ�е�sql���*/
        public static string sql = "";


        public static bool ulogin(global::ENTITY.CusUsers userlogin)
        {
            string sql = @"select teacherNo from Teacher where teacherNo =@teacherNo and password =@password";
            SqlParameter[] para = new SqlParameter[] { 
             new SqlParameter("@teacherNo",SqlDbType.VarChar),
             new SqlParameter("@password",SqlDbType.VarChar)
           };
            para[0].Value = userlogin.Customername;
            para[1].Value = userlogin.customerpwd; 
            return (DBHelp.ExecuteScalar(sql, para) != null) ? true : false;


        }
        /*��ӽ�ʦʵ��*/
        public static bool AddTeacher(ENTITY.Teacher teacher)
        {
            string sql = "insert into Teacher(teacherNo,password,teacherName,teacherSex,birthDate,teacherPhoto,zhicheng,telephone,teacherDesc) values(@teacherNo,@password,@teacherName,@teacherSex,@birthDate,@teacherPhoto,@zhicheng,@telephone,@teacherDesc)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@teacherNo",SqlDbType.VarChar),
             new SqlParameter("@password",SqlDbType.VarChar),
             new SqlParameter("@teacherName",SqlDbType.VarChar),
             new SqlParameter("@teacherSex",SqlDbType.VarChar),
             new SqlParameter("@birthDate",SqlDbType.DateTime),
             new SqlParameter("@teacherPhoto",SqlDbType.VarChar),
             new SqlParameter("@zhicheng",SqlDbType.VarChar),
             new SqlParameter("@telephone",SqlDbType.VarChar),
             new SqlParameter("@teacherDesc",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = teacher.teacherNo; //��ʦ���
            parm[1].Value = teacher.password; //��¼����
            parm[2].Value = teacher.teacherName; //��ʦ����
            parm[3].Value = teacher.teacherSex; //��ʦ�Ա�
            parm[4].Value = teacher.birthDate; //��������
            parm[5].Value = teacher.teacherPhoto; //��ʦ��Ƭ
            parm[6].Value = teacher.zhicheng; //��ʦְ��
            parm[7].Value = teacher.telephone; //��ϵ�绰
            parm[8].Value = teacher.teacherDesc; //��ʦ����

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����teacherNo��ȡĳ����ʦ��¼*/
        public static ENTITY.Teacher getSomeTeacher(string teacherNo)
        {
            /*������ѯsql*/
            string sql = "select * from Teacher where teacherNo='" + teacherNo + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Teacher teacher = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                teacher = new ENTITY.Teacher();
                teacher.teacherNo = DataRead["teacherNo"].ToString();
                teacher.password = DataRead["password"].ToString();
                teacher.teacherName = DataRead["teacherName"].ToString();
                teacher.teacherSex = DataRead["teacherSex"].ToString();
                teacher.birthDate = Convert.ToDateTime(DataRead["birthDate"].ToString());
                teacher.teacherPhoto = DataRead["teacherPhoto"].ToString();
                teacher.zhicheng = DataRead["zhicheng"].ToString();
                teacher.telephone = DataRead["telephone"].ToString();
                teacher.teacherDesc = DataRead["teacherDesc"].ToString();
            }
            return teacher;
        }

        /*���½�ʦʵ��*/
        public static bool EditTeacher(ENTITY.Teacher teacher)
        {
            string sql = "update Teacher set password=@password,teacherName=@teacherName,teacherSex=@teacherSex,birthDate=@birthDate,teacherPhoto=@teacherPhoto,zhicheng=@zhicheng,telephone=@telephone,teacherDesc=@teacherDesc where teacherNo=@teacherNo";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@password",SqlDbType.VarChar),
             new SqlParameter("@teacherName",SqlDbType.VarChar),
             new SqlParameter("@teacherSex",SqlDbType.VarChar),
             new SqlParameter("@birthDate",SqlDbType.DateTime),
             new SqlParameter("@teacherPhoto",SqlDbType.VarChar),
             new SqlParameter("@zhicheng",SqlDbType.VarChar),
             new SqlParameter("@telephone",SqlDbType.VarChar),
             new SqlParameter("@teacherDesc",SqlDbType.VarChar),
             new SqlParameter("@teacherNo",SqlDbType.VarChar)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = teacher.password;
            parm[1].Value = teacher.teacherName;
            parm[2].Value = teacher.teacherSex;
            parm[3].Value = teacher.birthDate;
            parm[4].Value = teacher.teacherPhoto;
            parm[5].Value = teacher.zhicheng;
            parm[6].Value = teacher.telephone;
            parm[7].Value = teacher.teacherDesc;
            parm[8].Value = teacher.teacherNo;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����ʦ*/
        public static bool DelTeacher(string p)
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
            sql = "delete from Teacher where teacherNo in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��ʦ*/
        public static DataSet GetTeacher(string strWhere)
        {
            try
            {
                string strSql = "select * from Teacher" + strWhere + " order by teacherNo asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ��ʦ*/
        public static System.Data.DataTable GetTeacher(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Teacher";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "teacherNo", strShow, strSql, strWhere, " teacherNo asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllTeacher()
        {
            try
            {
                string strSql = "select * from Teacher";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
