using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*ѧ���ɹ�ҵ���߼���*/
    public class bllOpus{
        /*���ѧ���ɹ�*/
        public static bool AddOpus(ENTITY.Opus opus)
        {
            return DAL.dalOpus.AddOpus(opus);
        }

        /*����opusId��ȡĳ��ѧ���ɹ���¼*/
        public static ENTITY.Opus getSomeOpus(int opusId)
        {
            return DAL.dalOpus.getSomeOpus(opusId);
        }

        /*����ѧ���ɹ�*/
        public static bool EditOpus(ENTITY.Opus opus)
        {
            return DAL.dalOpus.EditOpus(opus);
        }

        /*ɾ��ѧ���ɹ�*/
        public static bool DelOpus(string p)
        {
            return DAL.dalOpus.DelOpus(p);
        }

        /*��ѯѧ���ɹ�*/
        public static System.Data.DataSet GetOpus(string strWhere)
        {
            return DAL.dalOpus.GetOpus(strWhere);
        }

        /*����������ҳ��ѯѧ���ɹ�*/
        public static System.Data.DataTable GetOpus(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalOpus.GetOpus(NowPage, PageSize, out AllPage, out DataCount, p);
        }

        /*����������ҳ��ѯѧ���ɹ�*/
        public static System.Data.DataTable teacherGetOpus(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalOpus.teacherGetOpus(NowPage, PageSize, out AllPage, out DataCount, p);


        }
        /*��ѯ���е�ѧ���ɹ�*/
        public static System.Data.DataSet getAllOpus()
        {
            return DAL.dalOpus.getAllOpus();
        }
    }
}
