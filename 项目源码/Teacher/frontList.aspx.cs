using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Teacher_frontList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string sqlstr = " where 1=1 ";
            if (Request["teacherNo"] != null && Request["teacherNo"].ToString() != "")
            {
                sqlstr += "  and teacherNo like '%" + Request["teacherNo"].ToString() + "%'";
                teacherNo.Text = Request["teacherNo"].ToString();
            }
            if (Request["teacherName"] != null && Request["teacherName"].ToString() != "")
            {
                sqlstr += "  and teacherName like '%" + Request["teacherName"].ToString() + "%'";
                teacherName.Text = Request["teacherName"].ToString();
            }
            if (Request["birthDate"] != null && Request["birthDate"].ToString() != "")
            {
                sqlstr += "  and Convert(varchar,birthDate,120) like '" + Request["birthDate"].ToString() + "%'";
                birthDate.Text = Request["birthDate"].ToString();
            }
            if (Request["zhicheng"] != null && Request["zhicheng"].ToString() != "")
            {
                sqlstr += "  and zhicheng like '%" + Request["zhicheng"].ToString() + "%'";
                zhicheng.Text = Request["zhicheng"].ToString();
            }
            if (Request["telephone"] != null && Request["telephone"].ToString() != "")
            {
                sqlstr += "  and telephone like '%" + Request["telephone"].ToString() + "%'";
                telephone.Text = Request["telephone"].ToString();
            }
            HWhere.Value = sqlstr;
            BindData("");
       }
    }
    private void BindData(string strClass)
    {
        int DataCount = 0;
        int NowPage = 1;
        int AllPage = 0;
        int PageSize = Convert.ToInt32(HPageSize.Value);
        switch (strClass)
        {
            case "next":
                NowPage = Convert.ToInt32(HNowPage.Value) + 1;
                break;
            case "up":
                NowPage = Convert.ToInt32(HNowPage.Value) - 1;
                break;
            case "end":
                NowPage = Convert.ToInt32(HAllPage.Value);
                break;
            default:
                break;
        }
        DataTable dsLog = BLL.bllTeacher.GetTeacher(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
        if (dsLog.Rows.Count == 0 || AllPage == 1)
        {
            LBEnd.Enabled = false;
            LBHome.Enabled = false;
            LBNext.Enabled = false;
            LBUp.Enabled = false;
        }
        else if (NowPage == 1)
        {
            LBHome.Enabled = false;
            LBUp.Enabled = false;
            LBNext.Enabled = true;
            LBEnd.Enabled = true;
        }
        else if (NowPage == AllPage)
        {
            LBHome.Enabled = true;
            LBUp.Enabled = true;
            LBNext.Enabled = false;
            LBEnd.Enabled = false;
        }
        else
        {
            LBEnd.Enabled = true;
            LBHome.Enabled = true;
            LBNext.Enabled = true;
            LBUp.Enabled = true;
        }
        RpTeacher.DataSource = dsLog;
        RpTeacher.DataBind();
        PageMes.Text = string.Format("[ÿҳ<font color=green>{0}</font>�� ��<font color=red>{1}</font>ҳ����<font color=green>{2}</font>ҳ   ��<font color=green>{3}</font>��]", PageSize, NowPage, AllPage, DataCount);
        HNowPage.Value = Convert.ToString(NowPage++);
        HAllPage.Value = AllPage.ToString();
    }

    protected void LBHome_Click(object sender, EventArgs e)
    {
        BindData("");
    }
    protected void LBUp_Click(object sender, EventArgs e)
    {
        BindData("up");
    }
    protected void LBNext_Click(object sender, EventArgs e)
    {
        BindData("next");
    }
    protected void LBEnd_Click(object sender, EventArgs e)
    {
        BindData("end");
    }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("frontList.aspx?teacherNo=" + teacherNo.Text.Trim() + "&&teacherName=" + teacherName.Text.Trim()+ "&&birthDate=" + birthDate.Text.Trim()+ "&&zhicheng=" + zhicheng.Text.Trim()+ "&&telephone=" + telephone.Text.Trim());
        }

}
