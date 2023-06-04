using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*ѧ��ѡ��ҵ���߼���ʵ��*/
    public class dalSubSelect
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*���ѧ��ѡ��ʵ��*/
        public static bool AddSubSelect(ENTITY.SubSelect subSelect)
        {
            string sql = "insert into SubSelect(subjectObj,userObj,selectTime,shenHeState) values(@subjectObj,@userObj,@selectTime,@shenHeState)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@subjectObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@selectTime",SqlDbType.DateTime),
             new SqlParameter("@shenHeState",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = subSelect.subjectObj; //������Ŀ
            parm[1].Value = subSelect.userObj; //ѡ��ѧ��
            parm[2].Value = subSelect.selectTime; //ѡ��ʱ��
            parm[3].Value = subSelect.shenHeState; //���״̬

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����selectId��ȡĳ��ѧ��ѡ���¼*/
        public static ENTITY.SubSelect getSomeSubSelect(int selectId)
        {
            /*������ѯsql*/
            string sql = "select * from SubSelect where selectId=" + selectId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.SubSelect subSelect = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                subSelect = new ENTITY.SubSelect();
                subSelect.selectId = Convert.ToInt32(DataRead["selectId"]);
                subSelect.subjectObj = Convert.ToInt32(DataRead["subjectObj"]);
                subSelect.userObj = DataRead["userObj"].ToString();
                subSelect.selectTime = Convert.ToDateTime(DataRead["selectTime"].ToString());
                subSelect.shenHeState = DataRead["shenHeState"].ToString();
            }
            return subSelect;
        }

        /*����ѧ��ѡ��ʵ��*/
        public static bool EditSubSelect(ENTITY.SubSelect subSelect)
        {
            string sql = "update SubSelect set subjectObj=@subjectObj,userObj=@userObj,selectTime=@selectTime,shenHeState=@shenHeState where selectId=@selectId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@subjectObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@selectTime",SqlDbType.DateTime),
             new SqlParameter("@shenHeState",SqlDbType.VarChar),
             new SqlParameter("@selectId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = subSelect.subjectObj;
            parm[1].Value = subSelect.userObj;
            parm[2].Value = subSelect.selectTime;
            parm[3].Value = subSelect.shenHeState;
            parm[4].Value = subSelect.selectId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��ѧ��ѡ��*/
        public static bool DelSubSelect(string p)
        {
            string sql = "delete from SubSelect where selectId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯѧ��ѡ��*/
        public static DataSet GetSubSelect(string strWhere)
        {
            try
            {
                string strSql = "select * from SubSelect" + strWhere + " order by selectId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯѧ��ѡ��*/
        public static System.Data.DataTable GetSubSelect(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from SubSelect";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "selectId", strShow, strSql, strWhere, " selectId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /*��ʦ��ѯѧ��ѡ��*/
        public static System.Data.DataTable teacherGetSubSelect(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from SubSelectTeacherView";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "selectId", strShow, strSql, strWhere, " selectId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllSubSelect()
        {
            try
            {
                string strSql = "select * from SubSelect";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
