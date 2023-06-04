<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeacherSelfEdit.aspx.cs" Inherits="chengxusheji.Admin.TeacherEdit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script type="text/javascript" src="JavaScript/Admin.js"></script>
    <script type="text/javascript" src="../js/jsdate.js"></script>
    <script type="text/javascript">
        function CheckIn() {
            var re = /^[0-9]+.?[0-9]*$/;
            var resc=/^[1-9]+[0-9]*]*$/ ;
            var teacherNo = document.getElementById("teacherNo").value;
            if (teacherNo == "") {
                alert("请输入教师编号...");
                document.getElementById("teacherNo").focus();
                return false;
            }

            var password = document.getElementById("password").value;
            if (password == "") {
                alert("请输入登录密码...");
                document.getElementById("password").focus();
                return false;
            }

            var teacherName = document.getElementById("teacherName").value;
            if (teacherName == "") {
                alert("请输入教师姓名...");
                document.getElementById("teacherName").focus();
                return false;
            }

            var teacherSex = document.getElementById("teacherSex").value;
            if (teacherSex == "") {
                alert("请输入教师性别...");
                document.getElementById("teacherSex").focus();
                return false;
            }

            var birthDate = document.getElementById("birthDate").value;
            if (birthDate == "") {
                alert("请输入出生日期...");
                document.getElementById("birthDate").focus();
                return false;
            }

            var zhicheng = document.getElementById("zhicheng").value;
            if (zhicheng == "") {
                alert("请输入教师职称...");
                document.getElementById("zhicheng").focus();
                return false;
            }

            var telephone = document.getElementById("telephone").value;
            if (telephone == "") {
                alert("请输入联系电话...");
                document.getElementById("telephone").focus();
                return false;
            }

            var teacherDesc = document.getElementById("teacherDesc").value;
            if (teacherDesc == "") {
                alert("请输入教师介绍...");
                document.getElementById("teacherDesc").focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">教师管理 》》修改个人信息</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   教师编号：</td>
                    <td width="650px;">
                         <input id="teacherNo" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入教师编号！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   登录密码：</td>
                    <td width="650px;">
                         <input id="password" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入登录密码！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   教师姓名：</td>
                    <td width="650px;">
                         <input id="teacherName" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入教师姓名！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   教师性别：</td>
                    <td width="650px;">
                         <input id="teacherSex" type="text"   style="width:40px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入教师性别！</td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  出生日期：</td>
                    <td width="650px;">
                          <asp:TextBox ID="birthDate"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd');"></asp:TextBox></td>                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   教师照片：</td>
                    <td width="650px;">
                       <table cellpadding="0px" cellspacing="0px" width="90%">
                        <tr><td width="400px">
                         图片路径：<asp:TextBox ID="teacherPhoto" runat="server" ReadOnly="True" Width="228px" Enabled="False"></asp:TextBox> &nbsp; &nbsp; &nbsp
                         <br />
                         <br />
                         上传图片：<asp:FileUpload ID="TeacherPhotoUpload" runat="server" Width="237px" />&nbsp;
                         <asp:Button ID="Btn_TeacherPhotoUpload" runat="server" Text="上传" OnClick="Btn_TeacherPhotoUpload_Click" /></td><td>
                         <asp:Image ID="TeacherPhotoImage" runat="server" Height="90px" Width="99px" />
                         </td></tr>
                       </table>
                    </td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   教师职称：</td>
                    <td width="650px;">
                         <input id="zhicheng" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入教师职称！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   联系电话：</td>
                    <td width="650px;">
                         <input id="telephone" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入联系电话！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   教师介绍：</td>
                    <td width="650px;">
                        <textarea id="teacherDesc" rows=6 cols=80 runat="server"></textarea><span class="WarnMes">*</span>请输入教师介绍！</td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnTeacherSave" runat="server" Text=" 修改个人信息 "
                            OnClientClick="return CheckIn()" onclick="BtnTeacherSave_Click"  />
                         </td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

