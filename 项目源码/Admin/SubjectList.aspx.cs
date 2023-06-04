using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace chengxusheji.Admin
{
    public partial class SubjectList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
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
                li = new ListItem(dr["typeName"].ToString(), dr["typeName"].ToString());
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
                li = new ListItem(dr["teacherName"].ToString(), dr["teacherName"].ToString());
                teacherObj.Items.Add(li);
            }
            teacherObj.SelectedValue = "";
        }

        protected void BtnSubjectAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("SubjectEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllSubject.DelSubject(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "信息成功删除..", "SubjectList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "error", "信息删除失败，请重试或联系管理人员..");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "error", "删除失败..");
                }
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
        protected void RpSubject_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllSubject.DelSubject((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除成功...", "SubjectList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除失败，请重试或联系管理人员...", "SubjectList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "删除失败...", "SubjectList.aspx");
                }
            }
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
            Response.Redirect("SubjectList.aspx?subjectName=" + subjectName.Text.Trim()  + "&&subjectTypeObj=" + subjectTypeObj.SelectedValue.Trim() + "&&teacherObj=" + teacherObj.SelectedValue.Trim()+ "&&addTime=" + addTime.Text.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet subjectDataSet = BLL.bllSubject.GetSubject(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='8'>论文题目记录</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>题目id</th>");
            sb.Append("<th>题目名称</th>");
            sb.Append("<th>题目类型</th>");
            sb.Append("<th>任务书文件</th>");
            sb.Append("<th>其他资料文件</th>");
            sb.Append("<th>限选人数</th>");
            sb.Append("<th>指导老师</th>");
            sb.Append("<th>发布时间</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < subjectDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = subjectDataSet.Tables[0].Rows[i];
                sb.Append("<tr class=content>");
                sb.Append("<td>" + dr["subjectId"].ToString() + "</td>");
                sb.Append("<td>" + dr["subjectName"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllSubjectType.getSomeSubjectType(Convert.ToInt32(dr["subjectTypeObj"])).typeName + "</td>");
                sb.Append("<td>" + dr["taskFile"].ToString() + "</td>");
                sb.Append("<td>" + dr["otherFile"].ToString() + "</td>");
                sb.Append("<td>" + dr["personNum"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllTeacher.getSomeTeacher(dr["teacherObj"].ToString()).teacherName + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["addTime"]).ToShortDateString() + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "论文题目记录.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
