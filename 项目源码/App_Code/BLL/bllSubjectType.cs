using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��Ŀ����ҵ���߼���*/
    public class bllSubjectType{
        /*�����Ŀ����*/
        public static bool AddSubjectType(ENTITY.SubjectType subjectType)
        {
            return DAL.dalSubjectType.AddSubjectType(subjectType);
        }

        /*����typeId��ȡĳ����Ŀ���ͼ�¼*/
        public static ENTITY.SubjectType getSomeSubjectType(int typeId)
        {
            return DAL.dalSubjectType.getSomeSubjectType(typeId);
        }

        /*������Ŀ����*/
        public static bool EditSubjectType(ENTITY.SubjectType subjectType)
        {
            return DAL.dalSubjectType.EditSubjectType(subjectType);
        }

        /*ɾ����Ŀ����*/
        public static bool DelSubjectType(string p)
        {
            return DAL.dalSubjectType.DelSubjectType(p);
        }

        /*��ѯ��Ŀ����*/
        public static System.Data.DataSet GetSubjectType(string strWhere)
        {
            return DAL.dalSubjectType.GetSubjectType(strWhere);
        }

        /*����������ҳ��ѯ��Ŀ����*/
        public static System.Data.DataTable GetSubjectType(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalSubjectType.GetSubjectType(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е���Ŀ����*/
        public static System.Data.DataSet getAllSubjectType()
        {
            return DAL.dalSubjectType.getAllSubjectType();
        }
    }
}
