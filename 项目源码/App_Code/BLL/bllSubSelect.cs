using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*ѧ��ѡ��ҵ���߼���*/
    public class bllSubSelect{
        /*���ѧ��ѡ��*/
        public static bool AddSubSelect(ENTITY.SubSelect subSelect)
        {
            return DAL.dalSubSelect.AddSubSelect(subSelect);
        }

        /*����selectId��ȡĳ��ѧ��ѡ���¼*/
        public static ENTITY.SubSelect getSomeSubSelect(int selectId)
        {
            return DAL.dalSubSelect.getSomeSubSelect(selectId);
        }

        /*����ѧ��ѡ��*/
        public static bool EditSubSelect(ENTITY.SubSelect subSelect)
        {
            return DAL.dalSubSelect.EditSubSelect(subSelect);
        }

        /*ɾ��ѧ��ѡ��*/
        public static bool DelSubSelect(string p)
        {
            return DAL.dalSubSelect.DelSubSelect(p);
        }

        /*��ѯѧ��ѡ��*/
        public static System.Data.DataSet GetSubSelect(string strWhere)
        {
            return DAL.dalSubSelect.GetSubSelect(strWhere);
        }

        /*����������ҳ��ѯѧ��ѡ��*/
        public static System.Data.DataTable GetSubSelect(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalSubSelect.GetSubSelect(NowPage, PageSize, out AllPage, out DataCount, p);
        }

        /*��ʦ����������ҳ��ѯѧ��ѡ��*/
        public static System.Data.DataTable teacherGetSubSelect(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalSubSelect.teacherGetSubSelect(NowPage, PageSize, out AllPage, out DataCount, p);


        }
        /*��ѯ���е�ѧ��ѡ��*/
        public static System.Data.DataSet getAllSubSelect()
        {
            return DAL.dalSubSelect.getAllSubSelect();
        }
    }
}
