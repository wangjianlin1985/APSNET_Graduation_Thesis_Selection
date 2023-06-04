using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*学生成果业务逻辑层*/
    public class bllOpus{
        /*添加学生成果*/
        public static bool AddOpus(ENTITY.Opus opus)
        {
            return DAL.dalOpus.AddOpus(opus);
        }

        /*根据opusId获取某条学生成果记录*/
        public static ENTITY.Opus getSomeOpus(int opusId)
        {
            return DAL.dalOpus.getSomeOpus(opusId);
        }

        /*更新学生成果*/
        public static bool EditOpus(ENTITY.Opus opus)
        {
            return DAL.dalOpus.EditOpus(opus);
        }

        /*删除学生成果*/
        public static bool DelOpus(string p)
        {
            return DAL.dalOpus.DelOpus(p);
        }

        /*查询学生成果*/
        public static System.Data.DataSet GetOpus(string strWhere)
        {
            return DAL.dalOpus.GetOpus(strWhere);
        }

        /*根据条件分页查询学生成果*/
        public static System.Data.DataTable GetOpus(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalOpus.GetOpus(NowPage, PageSize, out AllPage, out DataCount, p);
        }

        /*根据条件分页查询学生成果*/
        public static System.Data.DataTable teacherGetOpus(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalOpus.teacherGetOpus(NowPage, PageSize, out AllPage, out DataCount, p);


        }
        /*查询所有的学生成果*/
        public static System.Data.DataSet getAllOpus()
        {
            return DAL.dalOpus.getAllOpus();
        }
    }
}
