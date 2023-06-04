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
                /*���뱾��Ϣ���ҳ��ʾ��ͼ��ͼƬ*/
                this.TeacherPhotoImage.ImageUrl = "../FileUpload/NoImage.jpg";
                LoadData();
                
            }
        }
        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
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
                    Common.ShowMessage.myScriptMes(Page, "Suess", "alert(\"��Ϣ�޸ĳɹ�\");location.href=\"TeacherSelfEdit.aspx?teacherNo=" + Session["Customername"].ToString() + "\";");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Redirect("TeacherList.aspx");
        }
        protected void Btn_TeacherPhotoUpload_Click(object sender, EventArgs e)
        {
            /*����û��ϴ����ļ�*/
            if (this.TeacherPhotoUpload.PostedFile.ContentLength > 0)
            {
                /*��֤�ϴ����ļ���ʽ��ֻ��Ϊgif��jpeg��ʽ*/
                string mimeType = this.TeacherPhotoUpload.PostedFile.ContentType;
                if (String.Compare(mimeType, "image/gif", true) == 0 || String.Compare(mimeType, "image/pjpeg", true) == 0 || String.Compare(mimeType, "image/jpeg", true) == 0)
                {
                    this.teacherPhoto.Text = "�ϴ��ļ���....";
                    string extFileString = System.IO.Path.GetExtension(this.TeacherPhotoUpload.PostedFile.FileName); /*��ȡ�ļ���չ��*/
                    string saveFileName = DAL.Function.MakeFileName(extFileString); /*������չ�������ļ���*/
                    string imagePath = "FileUpload/" + saveFileName;/*ͼƬ·��*/
                    this.TeacherPhotoUpload.PostedFile.SaveAs(Server.MapPath("../" + imagePath));
                    this.TeacherPhotoImage.ImageUrl = "../" + imagePath;
                    this.teacherPhoto.Text = imagePath;
                }
                else
                {
                    Response.Write("<script>alert('�ϴ��ļ���ʽ����ȷ!');</script>");
                }
            }
        }
    }
}

