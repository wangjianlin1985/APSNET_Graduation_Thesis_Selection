using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�û�ҵ���߼���ʵ��*/
    public class dalUserInfo
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*����û�ʵ��*/
        public static bool AddUserInfo(ENTITY.UserInfo userInfo)
        {
            string sql = "insert into UserInfo(user_name,password,classObj,name,gender,birthDate,userPhoto,telephone,regTime,email,address) values(@user_name,@password,@classObj,@name,@gender,@birthDate,@userPhoto,@telephone,@regTime,@email,@address)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@user_name",SqlDbType.VarChar),
             new SqlParameter("@password",SqlDbType.VarChar),
             new SqlParameter("@classObj",SqlDbType.VarChar),
             new SqlParameter("@name",SqlDbType.VarChar),
             new SqlParameter("@gender",SqlDbType.VarChar),
             new SqlParameter("@birthDate",SqlDbType.DateTime),
             new SqlParameter("@userPhoto",SqlDbType.VarChar),
             new SqlParameter("@telephone",SqlDbType.VarChar),
             new SqlParameter("@regTime",SqlDbType.DateTime),
             new SqlParameter("@email",SqlDbType.VarChar),
             new SqlParameter("@address",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = userInfo.user_name; //ѧ��
            parm[1].Value = userInfo.password; //��¼����
            parm[2].Value = userInfo.classObj; //���ڰ༶
            parm[3].Value = userInfo.name; //����
            parm[4].Value = userInfo.gender; //�Ա�
            parm[5].Value = userInfo.birthDate; //��������
            parm[6].Value = userInfo.userPhoto; //ѧ����Ƭ
            parm[7].Value = userInfo.telephone; //��ϵ�绰
            parm[8].Value = userInfo.regTime; //ע��ʱ��
            parm[9].Value = userInfo.email; //����
            parm[10].Value = userInfo.address; //��ͥ��ַ

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����user_name��ȡĳ���û���¼*/
        public static ENTITY.UserInfo getSomeUserInfo(string user_name)
        {
            /*������ѯsql*/
            string sql = "select * from UserInfo where user_name='" + user_name + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.UserInfo userInfo = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                userInfo = new ENTITY.UserInfo();
                userInfo.user_name = DataRead["user_name"].ToString();
                userInfo.password = DataRead["password"].ToString();
                userInfo.classObj = DataRead["classObj"].ToString();
                userInfo.name = DataRead["name"].ToString();
                userInfo.gender = DataRead["gender"].ToString();
                userInfo.birthDate = Convert.ToDateTime(DataRead["birthDate"].ToString());
                userInfo.userPhoto = DataRead["userPhoto"].ToString();
                userInfo.telephone = DataRead["telephone"].ToString();
                userInfo.regTime = Convert.ToDateTime(DataRead["regTime"].ToString());
                userInfo.email = DataRead["email"].ToString();
                userInfo.address = DataRead["address"].ToString();
            }
            return userInfo;
        }

        /*�����û�ʵ��*/
        public static bool EditUserInfo(ENTITY.UserInfo userInfo)
        {
            string sql = "update UserInfo set password=@password,classObj=@classObj,name=@name,gender=@gender,birthDate=@birthDate,userPhoto=@userPhoto,telephone=@telephone,regTime=@regTime,email=@email,address=@address where user_name=@user_name";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@password",SqlDbType.VarChar),
             new SqlParameter("@classObj",SqlDbType.VarChar),
             new SqlParameter("@name",SqlDbType.VarChar),
             new SqlParameter("@gender",SqlDbType.VarChar),
             new SqlParameter("@birthDate",SqlDbType.DateTime),
             new SqlParameter("@userPhoto",SqlDbType.VarChar),
             new SqlParameter("@telephone",SqlDbType.VarChar),
             new SqlParameter("@regTime",SqlDbType.DateTime),
             new SqlParameter("@email",SqlDbType.VarChar),
             new SqlParameter("@address",SqlDbType.VarChar),
             new SqlParameter("@user_name",SqlDbType.VarChar)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = userInfo.password;
            parm[1].Value = userInfo.classObj;
            parm[2].Value = userInfo.name;
            parm[3].Value = userInfo.gender;
            parm[4].Value = userInfo.birthDate;
            parm[5].Value = userInfo.userPhoto;
            parm[6].Value = userInfo.telephone;
            parm[7].Value = userInfo.regTime;
            parm[8].Value = userInfo.email;
            parm[9].Value = userInfo.address;
            parm[10].Value = userInfo.user_name;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ���û�*/
        public static bool DelUserInfo(string p)
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
            sql = "delete from UserInfo where user_name in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ�û�*/
        public static DataSet GetUserInfo(string strWhere)
        {
            try
            {
                string strSql = "select * from UserInfo" + strWhere + " order by user_name asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ�û�*/
        public static System.Data.DataTable GetUserInfo(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from UserInfo";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "user_name", strShow, strSql, strWhere, " user_name asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllUserInfo()
        {
            try
            {
                string strSql = "select * from UserInfo";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
