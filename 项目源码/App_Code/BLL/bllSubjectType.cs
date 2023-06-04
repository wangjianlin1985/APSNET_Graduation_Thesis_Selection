using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*题目类型业务逻辑层*/
    public class bllSubjectType{
        /*添加题目类型*/
        public static bool AddSubjectType(ENTITY.SubjectType subjectType)
        {
            return DAL.dalSubjectType.AddSubjectType(subjectType);
        }

        /*根据typeId获取某条题目类型记录*/
        public static ENTITY.SubjectType getSomeSubjectType(int typeId)
        {
            return DAL.dalSubjectType.getSomeSubjectType(typeId);
        }

        /*更新题目类型*/
        public static bool EditSubjectType(ENTITY.SubjectType subjectType)
        {
            return DAL.dalSubjectType.EditSubjectType(subjectType);
        }

        /*删除题目类型*/
        public static bool DelSubjectType(string p)
        {
            return DAL.dalSubjectType.DelSubjectType(p);
        }

        /*查询题目类型*/
        public static System.Data.DataSet GetSubjectType(string strWhere)
        {
            return DAL.dalSubjectType.GetSubjectType(strWhere);
        }

        /*根据条件分页查询题目类型*/
        public static System.Data.DataTable GetSubjectType(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalSubjectType.GetSubjectType(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的题目类型*/
        public static System.Data.DataSet getAllSubjectType()
        {
            return DAL.dalSubjectType.getAllSubjectType();
        }
    }
}
