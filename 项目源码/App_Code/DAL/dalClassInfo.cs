using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*班级业务逻辑层实现*/
    public class dalClassInfo
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加班级实现*/
        public static bool AddClassInfo(ENTITY.ClassInfo classInfo)
        {
            string sql = "insert into ClassInfo(classNo,className,college,specialName,bornDate,mainTeacher,classMemo) values(@classNo,@className,@college,@specialName,@bornDate,@mainTeacher,@classMemo)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@classNo",SqlDbType.VarChar),
             new SqlParameter("@className",SqlDbType.VarChar),
             new SqlParameter("@college",SqlDbType.VarChar),
             new SqlParameter("@specialName",SqlDbType.VarChar),
             new SqlParameter("@bornDate",SqlDbType.DateTime),
             new SqlParameter("@mainTeacher",SqlDbType.VarChar),
             new SqlParameter("@classMemo",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = classInfo.classNo; //班级编号
            parm[1].Value = classInfo.className; //班级名称
            parm[2].Value = classInfo.college; //所属学院
            parm[3].Value = classInfo.specialName; //所属专业
            parm[4].Value = classInfo.bornDate; //成立日期
            parm[5].Value = classInfo.mainTeacher; //班主任
            parm[6].Value = classInfo.classMemo; //班级备注

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据classNo获取某条班级记录*/
        public static ENTITY.ClassInfo getSomeClassInfo(string classNo)
        {
            /*构建查询sql*/
            string sql = "select * from ClassInfo where classNo='" + classNo + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.ClassInfo classInfo = null;
            /*如果查询存在记录，就包装到对象中返回*/
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

        /*更新班级实现*/
        public static bool EditClassInfo(ENTITY.ClassInfo classInfo)
        {
            string sql = "update ClassInfo set className=@className,college=@college,specialName=@specialName,bornDate=@bornDate,mainTeacher=@mainTeacher,classMemo=@classMemo where classNo=@classNo";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@className",SqlDbType.VarChar),
             new SqlParameter("@college",SqlDbType.VarChar),
             new SqlParameter("@specialName",SqlDbType.VarChar),
             new SqlParameter("@bornDate",SqlDbType.DateTime),
             new SqlParameter("@mainTeacher",SqlDbType.VarChar),
             new SqlParameter("@classMemo",SqlDbType.VarChar),
             new SqlParameter("@classNo",SqlDbType.VarChar)
            };
            /*为参数赋值*/
            parm[0].Value = classInfo.className;
            parm[1].Value = classInfo.college;
            parm[2].Value = classInfo.specialName;
            parm[3].Value = classInfo.bornDate;
            parm[4].Value = classInfo.mainTeacher;
            parm[5].Value = classInfo.classMemo;
            parm[6].Value = classInfo.classNo;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除班级*/
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


        /*查询班级*/
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

        /*查询班级*/
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
