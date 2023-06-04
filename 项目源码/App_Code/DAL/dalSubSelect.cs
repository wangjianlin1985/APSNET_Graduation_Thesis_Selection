using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*学生选题业务逻辑层实现*/
    public class dalSubSelect
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加学生选题实现*/
        public static bool AddSubSelect(ENTITY.SubSelect subSelect)
        {
            string sql = "insert into SubSelect(subjectObj,userObj,selectTime,shenHeState) values(@subjectObj,@userObj,@selectTime,@shenHeState)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@subjectObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@selectTime",SqlDbType.DateTime),
             new SqlParameter("@shenHeState",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = subSelect.subjectObj; //论文题目
            parm[1].Value = subSelect.userObj; //选题学生
            parm[2].Value = subSelect.selectTime; //选题时间
            parm[3].Value = subSelect.shenHeState; //审核状态

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据selectId获取某条学生选题记录*/
        public static ENTITY.SubSelect getSomeSubSelect(int selectId)
        {
            /*构建查询sql*/
            string sql = "select * from SubSelect where selectId=" + selectId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.SubSelect subSelect = null;
            /*如果查询存在记录，就包装到对象中返回*/
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

        /*更新学生选题实现*/
        public static bool EditSubSelect(ENTITY.SubSelect subSelect)
        {
            string sql = "update SubSelect set subjectObj=@subjectObj,userObj=@userObj,selectTime=@selectTime,shenHeState=@shenHeState where selectId=@selectId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@subjectObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@selectTime",SqlDbType.DateTime),
             new SqlParameter("@shenHeState",SqlDbType.VarChar),
             new SqlParameter("@selectId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = subSelect.subjectObj;
            parm[1].Value = subSelect.userObj;
            parm[2].Value = subSelect.selectTime;
            parm[3].Value = subSelect.shenHeState;
            parm[4].Value = subSelect.selectId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除学生选题*/
        public static bool DelSubSelect(string p)
        {
            string sql = "delete from SubSelect where selectId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询学生选题*/
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

        /*查询学生选题*/
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



        /*老师查询学生选题*/
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
