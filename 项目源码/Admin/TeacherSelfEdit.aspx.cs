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
    public partial class TeacherEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                /*进入本信息添加页显示无图的图片*/
                this.TeacherPhotoImage.ImageUrl = "../FileUpload/NoImage.jpg";
                LoadData();
                
            }
        }
        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
        private void LoadData()
        {
           
                ENTITY.Teacher teacher = BLL.bllTeacher.getSomeTeacher(Session["Customername"].ToString());
                teacherNo.Value = teacher.teacherNo;
                password.Value = teacher.password;
                teacherName.Value = teacher.teacherName;
                teacherSex.Value = teacher.teacherSex;
                birthDate.Text = teacher.birthDate.ToShortDateString();
                teacherPhoto.Text = teacher.teacherPhoto;
                if (teacher.teacherPhoto != "") this.TeacherPhotoImage.ImageUrl = "../" + teacher.teacherPhoto;
                zhicheng.Value = teacher.zhicheng;
                telephone.Value = teacher.telephone;
                teacherDesc.Value = teacher.teacherDesc;
            
        }

        protected void BtnTeacherSave_Click(object sender, EventArgs e)
        {
            ENTITY.Teacher teacher = new ENTITY.Teacher();
            teacher.teacherNo = this.teacherNo.Value;
            teacher.password = password.Value;
            teacher.teacherName = teacherName.Value;
            teacher.teacherSex = teacherSex.Value;
            teacher.birthDate = Convert.ToDateTime(birthDate.Text);
            if (teacherPhoto.Text == "") teacherPhoto.Text = "FileUpload/NoImage.jpg";
            teacher.teacherPhoto = teacherPhoto.Text;
            teacher.zhicheng = zhicheng.Value;
            teacher.telephone = telephone.Value;
            teacher.teacherDesc = teacherDesc.Value;
            
                if (BLL.bllTeacher.EditTeacher(teacher))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "alert(\"信息修改成功\");location.href=\"TeacherSelfEdit.aspx?teacherNo=" + Session["Customername"].ToString() + "\";");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Redirect("TeacherList.aspx");
        }
        protected void Btn_TeacherPhotoUpload_Click(object sender, EventArgs e)
        {
            /*如果用户上传了文件*/
            if (this.TeacherPhotoUpload.PostedFile.ContentLength > 0)
            {
                /*验证上传的文件格式，只能为gif和jpeg格式*/
                string mimeType = this.TeacherPhotoUpload.PostedFile.ContentType;
                if (String.Compare(mimeType, "image/gif", true) == 0 || String.Compare(mimeType, "image/pjpeg", true) == 0 || String.Compare(mimeType, "image/jpeg", true) == 0)
                {
                    this.teacherPhoto.Text = "上传文件中....";
                    string extFileString = System.IO.Path.GetExtension(this.TeacherPhotoUpload.PostedFile.FileName); /*获取文件扩展名*/
                    string saveFileName = DAL.Function.MakeFileName(extFileString); /*根据扩展名生成文件名*/
                    string imagePath = "FileUpload/" + saveFileName;/*图片路径*/
                    this.TeacherPhotoUpload.PostedFile.SaveAs(Server.MapPath("../" + imagePath));
                    this.TeacherPhotoImage.ImageUrl = "../" + imagePath;
                    this.teacherPhoto.Text = imagePath;
                }
                else
                {
                    Response.Write("<script>alert('上传文件格式不正确!');</script>");
                }
            }
        }
    }
}

