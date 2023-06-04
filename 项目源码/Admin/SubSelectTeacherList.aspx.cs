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
    public partial class SubSelectList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindsubjectObj();
                BinduserObj();
                string sqlstr = " where 1=1 ";
                if (Request["subjectObj"] != null && Request["subjectObj"].ToString() != "0")
                {
                    sqlstr += "  and subjectObj=" + Request["subjectObj"].ToString();
                    subjectObj.SelectedValue = Request["subjectObj"].ToString();
                }
                if (Request["userObj"] != null && Request["userObj"].ToString() != "")
                {
                    sqlstr += "  and userObj='" + Request["userObj"].ToString() + "'";
                    userObj.SelectedValue = Request["userObj"].ToString();
                }
                if (Request["selectTime"] != null && Request["selectTime"].ToString() != "")
                {
                    sqlstr += "  and Convert(varchar,selectTime,120) like '" + Request["selectTime"].ToString() + "%'";
                    selectTime.Text = Request["selectTime"].ToString();
                }
                if (Request["shenHeState"] != null && Request["shenHeState"].ToString() != "")
                {
                    sqlstr += "  and shenHeState like '%" + Request["shenHeState"].ToString() + "%'";
                    shenHeState.Text = Request["shenHeState"].ToString();
                }

                sqlstr += " and teacherObj = '" + Session["Customername"].ToString() +  "'";

                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void BindsubjectObj()
        {
            ListItem li = new ListItem("不限制", "0");
            subjectObj.Items.Add(li);
            DataSet subjectObjDs = BLL.bllSubject.getAllSubject(Session["Customername"].ToString());
            for (int i = 0; i < subjectObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = subjectObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["subjectName"].ToString(), dr["subjectName"].ToString());
                subjectObj.Items.Add(li);
            }
            subjectObj.SelectedValue = "0";
        }

        private void BinduserObj()
        {
            ListItem li = new ListItem("不限制", "");
            userObj.Items.Add(li);
            DataSet userObjDs = BLL.bllUserInfo.getAllUserInfo();
            for (int i = 0; i < userObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = userObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["name"].ToString(), dr["name"].ToString());
                userObj.Items.Add(li);
            }
            userObj.SelectedValue = "";
        }

        protected void BtnSubSelectAdd_Click(object sender, EventArgs e)
        {
           // Response.Redirect("SubSelectEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllSubSelect.DelSubSelect(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "信息成功删除..", "SubSelectTeacherList.aspx");
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
            DataTable dsLog = BLL.bllSubSelect.teacherGetSubSelect(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
            RpSubSelect.DataSource = dsLog;
            RpSubSelect.DataBind();
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
        protected void RpSubSelect_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllSubSelect.DelSubSelect((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除成功...", "SubSelectTeacherList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除失败，请重试或联系管理人员...", "SubSelectTeacherList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "删除失败...", "SubSelectTeacherList.aspx");
                }
            }
        }
        public string GetSubjectsubjectObj(string subjectObj)
        {
            return BLL.bllSubject.getSomeSubject(int.Parse(subjectObj)).subjectName;
        }

        public string GetUserInfouserObj(string userObj)
        {
            return BLL.bllUserInfo.getSomeUserInfo(userObj).name;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("SubSelectTeacherList.aspx?subjectObj=" + subjectObj.SelectedValue.Trim() + "&&userObj=" + userObj.SelectedValue.Trim()+ "&&selectTime=" + selectTime.Text.Trim()+ "&&shenHeState=" + shenHeState.Text.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet subSelectDataSet = BLL.bllSubSelect.GetSubSelect(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='5'>学生选题记录</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>选题id</th>");
            sb.Append("<th>论文题目</th>");
            sb.Append("<th>选题学生</th>");
            sb.Append("<th>选题时间</th>");
            sb.Append("<th>审核状态</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < subSelectDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = subSelectDataSet.Tables[0].Rows[i];
                sb.Append("<tr class=content>");
                sb.Append("<td>" + dr["selectId"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllSubject.getSomeSubject(Convert.ToInt32(dr["subjectObj"])).subjectName + "</td>");
                sb.Append("<td>" + BLL.bllUserInfo.getSomeUserInfo(dr["userObj"].ToString()).name + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["selectTime"]).ToShortDateString() + "</td>");
                sb.Append("<td>" + dr["shenHeState"].ToString() + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "学生选题记录.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
