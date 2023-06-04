using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*论文题目业务逻辑层*/
    public class bllSubject{
        /*添加论文题目*/
        public static bool AddSubject(ENTITY.Subject subject)
        {
            return DAL.dalSubject.AddSubject(subject);
        }

        /*根据subjectId获取某条论文题目记录*/
        public static ENTITY.Subject getSomeSubject(int subjectId)
        {
            return DAL.dalSubject.getSomeSubject(subjectId);
        }

        /*更新论文题目*/
        public static bool EditSubject(ENTITY.Subject subject)
        {
            return DAL.dalSubject.EditSubject(subject);
        }

        /*删除论文题目*/
        public static bool DelSubject(string p)
        {
            return DAL.dalSubject.DelSubject(p);
        }

        /*查询论文题目*/
        public static System.Data.DataSet GetSubject(string strWhere)
        {
            return DAL.dalSubject.GetSubject(strWhere);
        }

        /*根据条件分页查询论文题目*/
        public static System.Data.DataTable GetSubject(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalSubject.GetSubject(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的论文题目*/
        public static System.Data.DataSet getAllSubject()
        {
            return DAL.dalSubject.getAllSubject();
        }

        /*老师查询所有的论文题目*/
        public static System.Data.DataSet getAllSubject(String teacherNo)
        {
            return DAL.dalSubject.getAllSubject(teacherNo);
        }

    }
}
