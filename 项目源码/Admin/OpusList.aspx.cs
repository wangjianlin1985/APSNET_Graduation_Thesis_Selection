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
    public partial class OpusList : System.Web.UI.Page
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
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void BindsubjectObj()
        {
            ListItem li = new ListItem("������", "0");
            subjectObj.Items.Add(li);
            DataSet subjectObjDs = BLL.bllSubject.getAllSubject();
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
            ListItem li = new ListItem("������", "");
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

        protected void BtnOpusAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("OpusEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllOpus.DelOpus(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "��Ϣ�ɹ�ɾ��..", "OpusList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "error", "��Ϣɾ��ʧ�ܣ������Ի���ϵ������Ա..");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "error", "ɾ��ʧ��..");
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
            DataTable dsLog = BLL.bllOpus.GetOpus(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
            RpOpus.DataSource = dsLog;
            RpOpus.DataBind();
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
        protected void RpOpus_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllOpus.DelOpus((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "��Ϣɾ���ɹ�...", "OpusList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "��Ϣɾ��ʧ�ܣ������Ի���ϵ������Ա...", "OpusList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "ɾ��ʧ��...", "OpusList.aspx");
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
            Response.Redirect("OpusList.aspx?subjectObj=" + subjectObj.SelectedValue.Trim() + "&&userObj=" + userObj.SelectedValue.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet opusDataSet = BLL.bllOpus.GetOpus(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='10'>ѧ���ɹ���¼</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>�ɹ�id</th>");
            sb.Append("<th>������Ŀ</th>");
            sb.Append("<th>�ύѧ��</th>");
            sb.Append("<th>���ⱨ��</th>");
            sb.Append("<th>�������׷���</th>");
            sb.Append("<th>���ĳ���</th>");
            sb.Append("<th>�����ո�</th>");
            sb.Append("<th>�����ļ�</th>");
            sb.Append("<th>���ĳɼ�</th>");
            sb.Append("<th>��ʦ����</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < opusDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = opusDataSet.Tables[0].Rows[i];
                sb.Append("<tr class=content>");
                sb.Append("<td>" + dr["opusId"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllSubject.getSomeSubject(Convert.ToInt32(dr["subjectObj"])).subjectName + "</td>");
                sb.Append("<td>" + BLL.bllUserInfo.getSomeUserInfo(dr["userObj"].ToString()).name + "</td>");
                sb.Append("<td>" + dr["ktbg"].ToString() + "</td>");
                sb.Append("<td>" + dr["wwwx"].ToString() + "</td>");
                sb.Append("<td>" + dr["lwcg"].ToString() + "</td>");
                sb.Append("<td>" + dr["lwzg"].ToString() + "</td>");
                sb.Append("<td>" + dr["otherFile"].ToString() + "</td>");
                sb.Append("<td>" + dr["chengji"].ToString() + "</td>");
                sb.Append("<td>" + dr["evaluate"].ToString() + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "ѧ���ɹ���¼.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
