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
    public partial class ClassInfoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                string sqlstr = " where 1=1 ";
                if (Request["classNo"] != null && Request["classNo"].ToString() != "")
                {
                    sqlstr += "  and classNo like '%" + Request["classNo"].ToString() + "%'";
                    classNo.Text = Request["classNo"].ToString();
                }
                if (Request["className"] != null && Request["className"].ToString() != "")
                {
                    sqlstr += "  and className like '%" + Request["className"].ToString() + "%'";
                    className.Text = Request["className"].ToString();
                }
                if (Request["college"] != null && Request["college"].ToString() != "")
                {
                    sqlstr += "  and college like '%" + Request["college"].ToString() + "%'";
                    college.Text = Request["college"].ToString();
                }
                if (Request["specialName"] != null && Request["specialName"].ToString() != "")
                {
                    sqlstr += "  and specialName like '%" + Request["specialName"].ToString() + "%'";
                    specialName.Text = Request["specialName"].ToString();
                }
                if (Request["bornDate"] != null && Request["bornDate"].ToString() != "")
                {
                    sqlstr += "  and Convert(varchar,bornDate,120) like '" + Request["bornDate"].ToString() + "%'";
                    bornDate.Text = Request["bornDate"].ToString();
                }
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        protected void BtnClassInfoAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClassInfoEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllClassInfo.DelClassInfo(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "信息成功删除..", "ClassInfoList.aspx");
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
            DataTable dsLog = BLL.bllClassInfo.GetClassInfo(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
            RpClassInfo.DataSource = dsLog;
            RpClassInfo.DataBind();
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
        protected void RpClassInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllClassInfo.DelClassInfo((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除成功...", "ClassInfoList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除失败，请重试或联系管理人员...", "ClassInfoList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "删除失败...", "ClassInfoList.aspx");
                }
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClassInfoList.aspx?classNo=" + classNo.Text.Trim() + "&&className=" + className.Text.Trim()+ "&&college=" + college.Text.Trim()+ "&&specialName=" + specialName.Text.Trim()+ "&&bornDate=" + bornDate.Text.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet classInfoDataSet = BLL.bllClassInfo.GetClassInfo(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='6'>班级记录</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>班级编号</th>");
            sb.Append("<th>班级名称</th>");
            sb.Append("<th>所属学院</th>");
            sb.Append("<th>所属专业</th>");
            sb.Append("<th>成立日期</th>");
            sb.Append("<th>班主任</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < classInfoDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = classInfoDataSet.Tables[0].Rows[i];
                sb.Append("<tr class=content>");
                sb.Append("<td>" + dr["classNo"].ToString() + "</td>");
                sb.Append("<td>" + dr["className"].ToString() + "</td>");
                sb.Append("<td>" + dr["college"].ToString() + "</td>");
                sb.Append("<td>" + dr["specialName"].ToString() + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["bornDate"]).ToShortDateString() + "</td>");
                sb.Append("<td>" + dr["mainTeacher"].ToString() + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "班级记录.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
