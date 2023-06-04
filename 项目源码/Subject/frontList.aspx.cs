using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Subject_frontList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindsubjectTypeObj();
            BindteacherObj();
            string sqlstr = " where 1=1 ";
            if (Request["subjectName"] != null && Request["subjectName"].ToString() != "")
            {
                sqlstr += "  and subjectName like '%" + Request["subjectName"].ToString() + "%'";
                subjectName.Text = Request["subjectName"].ToString();
            }
            if (Request["subjectTypeObj"] != null && Request["subjectTypeObj"].ToString() != "0")
            {
                    sqlstr += "  and subjectTypeObj=" + Request["subjectTypeObj"].ToString();
                    subjectTypeObj.SelectedValue = Request["subjectTypeObj"].ToString();
            }
            if (Request["teacherObj"] != null && Request["teacherObj"].ToString() != "")
            {
                sqlstr += "  and teacherObj='" + Request["teacherObj"].ToString() + "'";
                teacherObj.SelectedValue = Request["teacherObj"].ToString();
            }
            if (Request["addTime"] != null && Request["addTime"].ToString() != "")
            {
                sqlstr += "  and Convert(varchar,addTime,120) like '" + Request["addTime"].ToString() + "%'";
                addTime.Text = Request["addTime"].ToString();
            }
            HWhere.Value = sqlstr;
            BindData("");
       }
    }
    private void BindsubjectTypeObj()
    {
        ListItem li = new ListItem("不限制", "0");
        subjectTypeObj.Items.Add(li);
        DataSet subjectTypeObjDs = BLL.bllSubjectType.getAllSubjectType();
        for (int i = 0; i < subjectTypeObjDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = subjectTypeObjDs.Tables[0].Rows[i];
            li = new ListItem(dr["typeName"].ToString(),dr["typeId"].ToString());
            subjectTypeObj.Items.Add(li);
        }
        subjectTypeObj.SelectedValue = "0";
    }

    private void BindteacherObj()
    {
        ListItem li = new ListItem("不限制", "");
        teacherObj.Items.Add(li);
        DataSet teacherObjDs = BLL.bllTeacher.getAllTeacher();
        for (int i = 0; i < teacherObjDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = teacherObjDs.Tables[0].Rows[i];
            li = new ListItem(dr["teacherName"].ToString(),dr["teacherNo"].ToString());
            teacherObj.Items.Add(li);
        }
        teacherObj.SelectedValue = "";
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
        DataTable dsLog = BLL.bllSubject.GetSubject(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
        RpSubject.DataSource = dsLog;
        RpSubject.DataBind();
        PageMes.Text = string.Format("[每页<font color=green>{0}</font>条 第<font color=red>{1}</font>页／共<font color=green>{2}</font>页   共<font color=green>{3}</font>条]", PageSize, NowPage, AllPage, DataCount);
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
        public string GetSubjectTypesubjectTypeObj(string subjectTypeObj)
        {
            return BLL.bllSubjectType.getSomeSubjectType(int.Parse(subjectTypeObj)).typeName;
        }

        public string GetTeacherteacherObj(string teacherObj)
        {
            return BLL.bllTeacher.getSomeTeacher(teacherObj).teacherName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("frontList.aspx?subjectName=" + subjectName.Text.Trim()  + "&&subjectTypeObj=" + subjectTypeObj.SelectedValue.Trim() + "&&teacherObj=" + teacherObj.SelectedValue.Trim()+ "&&addTime=" + addTime.Text.Trim());
        }

}
