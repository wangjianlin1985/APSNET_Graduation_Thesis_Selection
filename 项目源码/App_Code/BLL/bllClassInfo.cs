using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*班级业务逻辑层*/
    public class bllClassInfo{
        /*添加班级*/
        public static bool AddClassInfo(ENTITY.ClassInfo classInfo)
        {
            return DAL.dalClassInfo.AddClassInfo(classInfo);
        }

        /*根据classNo获取某条班级记录*/
        public static ENTITY.ClassInfo getSomeClassInfo(string classNo)
        {
            return DAL.dalClassInfo.getSomeClassInfo(classNo);
        }

        /*更新班级*/
        public static bool EditClassInfo(ENTITY.ClassInfo classInfo)
        {
            return DAL.dalClassInfo.EditClassInfo(classInfo);
        }

        /*删除班级*/
        public static bool DelClassInfo(string p)
        {
            return DAL.dalClassInfo.DelClassInfo(p);
        }

        /*查询班级*/
        public static System.Data.DataSet GetClassInfo(string strWhere)
        {
            return DAL.dalClassInfo.GetClassInfo(strWhere);
        }

        /*根据条件分页查询班级*/
        public static System.Data.DataTable GetClassInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalClassInfo.GetClassInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的班级*/
        public static System.Data.DataSet getAllClassInfo()
        {
            return DAL.dalClassInfo.getAllClassInfo();
        }
    }
}
