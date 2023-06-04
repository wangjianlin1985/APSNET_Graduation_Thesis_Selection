using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*题目类型业务逻辑层实现*/
    public class dalSubjectType
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加题目类型实现*/
        public static bool AddSubjectType(ENTITY.SubjectType subjectType)
        {
            string sql = "insert into SubjectType(typeName) values(@typeName)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@typeName",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = subjectType.typeName; //类型名称

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据typeId获取某条题目类型记录*/
        public static ENTITY.SubjectType getSomeSubjectType(int typeId)
        {
            /*构建查询sql*/
            string sql = "select * from SubjectType where typeId=" + typeId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.SubjectType subjectType = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                subjectType = new ENTITY.SubjectType();
                subjectType.typeId = Convert.ToInt32(DataRead["typeId"]);
                subjectType.typeName = DataRead["typeName"].ToString();
            }
            return subjectType;
        }

        /*更新题目类型实现*/
        public static bool EditSubjectType(ENTITY.SubjectType subjectType)
        {
            string sql = "update SubjectType set typeName=@typeName where typeId=@typeId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@typeName",SqlDbType.VarChar),
             new SqlParameter("@typeId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = subjectType.typeName;
            parm[1].Value = subjectType.typeId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除题目类型*/
        public static bool DelSubjectType(string p)
        {
            string sql = "delete from SubjectType where typeId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询题目类型*/
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

        /*查询题目类型*/
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
