using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*学生成果业务逻辑层实现*/
    public class dalOpus
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加学生成果实现*/
        public static bool AddOpus(ENTITY.Opus opus)
        {
            string sql = "insert into Opus(subjectObj,userObj,ktbg,wwwx,lwcg,lwzg,otherFile,chengji,evaluate) values(@subjectObj,@userObj,@ktbg,@wwwx,@lwcg,@lwzg,@otherFile,@chengji,@evaluate)";
            /*构建sql参数*/
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
            /*给参数赋值*/
            parm[0].Value = opus.subjectObj; //论文题目
            parm[1].Value = opus.userObj; //提交学生
            parm[2].Value = opus.ktbg; //开题报告
            parm[3].Value = opus.wwwx; //外文文献翻译
            parm[4].Value = opus.lwcg; //论文初稿
            parm[5].Value = opus.lwzg; //论文终稿
            parm[6].Value = opus.otherFile; //其他文件
            parm[7].Value = opus.chengji; //论文成绩
            parm[8].Value = opus.evaluate; //老师评价

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据opusId获取某条学生成果记录*/
        public static ENTITY.Opus getSomeOpus(int opusId)
        {
            /*构建查询sql*/
            string sql = "select * from Opus where opusId=" + opusId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Opus opus = null;
            /*如果查询存在记录，就包装到对象中返回*/
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

        /*更新学生成果实现*/
        public static bool EditOpus(ENTITY.Opus opus)
        {
            string sql = "update Opus set subjectObj=@subjectObj,userObj=@userObj,ktbg=@ktbg,wwwx=@wwwx,lwcg=@lwcg,lwzg=@lwzg,otherFile=@otherFile,chengji=@chengji,evaluate=@evaluate where opusId=@opusId";
            /*构建sql参数信息*/
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
            /*为参数赋值*/
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
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除学生成果*/
        public static bool DelOpus(string p)
        {
            string sql = "delete from Opus where opusId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询学生成果*/
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

        /*查询学生成果*/
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



        /*教师查询学生成果*/
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
