using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�༶ҵ���߼���*/
    public class bllClassInfo{
        /*��Ӱ༶*/
        public static bool AddClassInfo(ENTITY.ClassInfo classInfo)
        {
            return DAL.dalClassInfo.AddClassInfo(classInfo);
        }

        /*����classNo��ȡĳ���༶��¼*/
        public static ENTITY.ClassInfo getSomeClassInfo(string classNo)
        {
            return DAL.dalClassInfo.getSomeClassInfo(classNo);
        }

        /*���°༶*/
        public static bool EditClassInfo(ENTITY.ClassInfo classInfo)
        {
            return DAL.dalClassInfo.EditClassInfo(classInfo);
        }

        /*ɾ���༶*/
        public static bool DelClassInfo(string p)
        {
            return DAL.dalClassInfo.DelClassInfo(p);
        }

        /*��ѯ�༶*/
        public static System.Data.DataSet GetClassInfo(string strWhere)
        {
            return DAL.dalClassInfo.GetClassInfo(strWhere);
        }

        /*����������ҳ��ѯ�༶*/
        public static System.Data.DataTable GetClassInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalClassInfo.GetClassInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еİ༶*/
        public static System.Data.DataSet getAllClassInfo()
        {
            return DAL.dalClassInfo.getAllClassInfo();
        }
    }
}
