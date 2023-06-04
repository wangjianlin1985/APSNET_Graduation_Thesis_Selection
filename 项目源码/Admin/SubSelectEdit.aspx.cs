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
    public partial class SubSelectEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindSubjectsubjectObj();
                BindUserInfouserObj();
                if (Request["selectId"] != null)
                {
                    LoadData();
                }
            }
        }
        private void BindSubjectsubjectObj()
        {
            subjectObj.DataSource = BLL.bllSubject.getAllSubject();
            subjectObj.DataTextField = "subjectName";
            subjectObj.DataValueField = "subjectId";
            subjectObj.DataBind();
        }

        private void BindUserInfouserObj()
        {
            userObj.DataSource = BLL.bllUserInfo.getAllUserInfo();
            userObj.DataTextField = "name";
            userObj.DataValueField = "user_name";
            userObj.DataBind();
        }

        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "selectId")))
            {
                ENTITY.SubSelect subSelect = BLL.bllSubSelect.getSomeSubSelect(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "selectId")));
                subjectObj.SelectedValue = subSelect.subjectObj.ToString();
                userObj.SelectedValue = subSelect.userObj;
                selectTime.Text = subSelect.selectTime.ToShortDateString() + " " + subSelect.selectTime.ToLongTimeString();
                shenHeState.Value = subSelect.shenHeState;
            }
        }

        protected void BtnSubSelectSave_Click(object sender, EventArgs e)
        {
            ENTITY.SubSelect subSelect = new ENTITY.SubSelect();
            subSelect.subjectObj = int.Parse(subjectObj.SelectedValue);
            subSelect.userObj = userObj.SelectedValue;
            subSelect.selectTime = Convert.ToDateTime(selectTime.Text);
            subSelect.shenHeState = shenHeState.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "selectId")))
            {
                subSelect.selectId = int.Parse(Request["selectId"]);
                if (BLL.bllSubSelect.EditSubSelect(subSelect))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"SubSelectEdit.aspx?selectId=" + Request["selectId"] + "\"} else  {location.href=\"SubSelectList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                if (BLL.bllSubSelect.AddSubSelect(subSelect))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"SubSelectEdit.aspx\"} else  {location.href=\"SubSelectList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("SubSelectList.aspx");
        }
    }
}

