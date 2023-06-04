using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*������Ŀҵ���߼���*/
    public class bllSubject{
        /*���������Ŀ*/
        public static bool AddSubject(ENTITY.Subject subject)
        {
            return DAL.dalSubject.AddSubject(subject);
        }

        /*����subjectId��ȡĳ��������Ŀ��¼*/
        public static ENTITY.Subject getSomeSubject(int subjectId)
        {
            return DAL.dalSubject.getSomeSubject(subjectId);
        }

        /*����������Ŀ*/
        public static bool EditSubject(ENTITY.Subject subject)
        {
            return DAL.dalSubject.EditSubject(subject);
        }

        /*ɾ��������Ŀ*/
        public static bool DelSubject(string p)
        {
            return DAL.dalSubject.DelSubject(p);
        }

        /*��ѯ������Ŀ*/
        public static System.Data.DataSet GetSubject(string strWhere)
        {
            return DAL.dalSubject.GetSubject(strWhere);
        }

        /*����������ҳ��ѯ������Ŀ*/
        public static System.Data.DataTable GetSubject(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalSubject.GetSubject(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�������Ŀ*/
        public static System.Data.DataSet getAllSubject()
        {
            return DAL.dalSubject.getAllSubject();
        }

        /*��ʦ��ѯ���е�������Ŀ*/
        public static System.Data.DataSet getAllSubject(String teacherNo)
        {
            return DAL.dalSubject.getAllSubject(teacherNo);
        }

    }
}
