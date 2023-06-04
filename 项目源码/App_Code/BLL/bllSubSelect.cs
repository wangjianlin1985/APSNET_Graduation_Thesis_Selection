using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*学生选题业务逻辑层*/
    public class bllSubSelect{
        /*添加学生选题*/
        public static bool AddSubSelect(ENTITY.SubSelect subSelect)
        {
            return DAL.dalSubSelect.AddSubSelect(subSelect);
        }

        /*根据selectId获取某条学生选题记录*/
        public static ENTITY.SubSelect getSomeSubSelect(int selectId)
        {
            return DAL.dalSubSelect.getSomeSubSelect(selectId);
        }

        /*更新学生选题*/
        public static bool EditSubSelect(ENTITY.SubSelect subSelect)
        {
            return DAL.dalSubSelect.EditSubSelect(subSelect);
        }

        /*删除学生选题*/
        public static bool DelSubSelect(string p)
        {
            return DAL.dalSubSelect.DelSubSelect(p);
        }

        /*查询学生选题*/
        public static System.Data.DataSet GetSubSelect(string strWhere)
        {
            return DAL.dalSubSelect.GetSubSelect(strWhere);
        }

        /*根据条件分页查询学生选题*/
        public static System.Data.DataTable GetSubSelect(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalSubSelect.GetSubSelect(NowPage, PageSize, out AllPage, out DataCount, p);
        }

        /*老师根据条件分页查询学生选题*/
        public static System.Data.DataTable teacherGetSubSelect(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalSubSelect.teacherGetSubSelect(NowPage, PageSize, out AllPage, out DataCount, p);


        }
        /*查询所有的学生选题*/
        public static System.Data.DataSet getAllSubSelect()
        {
            return DAL.dalSubSelect.getAllSubSelect();
        }
    }
}
