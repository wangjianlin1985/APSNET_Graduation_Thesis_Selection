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
                alert("�������ʦ���...");
                document.getElementById("teacherNo").focus();
                return false;
            }

            var password = document.getElementById("password").value;
            if (password == "") {
                alert("�������¼����...");
                document.getElementById("password").focus();
                return false;
            }

            var teacherName = document.getElementById("teacherName").value;
            if (teacherName == "") {
                alert("�������ʦ����...");
                document.getElementById("teacherName").focus();
                return false;
            }

            var teacherSex = document.getElementById("teacherSex").value;
            if (teacherSex == "") {
                alert("�������ʦ�Ա�...");
                document.getElementById("teacherSex").focus();
                return false;
            }

            var birthDate = document.getElementById("birthDate").value;
            if (birthDate == "") {
                alert("�������������...");
                document.getElementById("birthDate").focus();
                return false;
            }

            var zhicheng = document.getElementById("zhicheng").value;
            if (zhicheng == "") {
                alert("�������ʦְ��...");
                document.getElementById("zhicheng").focus();
                return false;
            }

            var telephone = document.getElementById("telephone").value;
            if (telephone == "") {
                alert("��������ϵ�绰...");
                document.getElementById("telephone").focus();
                return false;
            }

            var teacherDesc = document.getElementById("teacherDesc").value;
            if (teacherDesc == "") {
                alert("�������ʦ����...");
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
    <div class="Body_Title">��ʦ���� �����޸ĸ�����Ϣ</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��ʦ��ţ�</td>
                    <td width="650px;">
                         <input id="teacherNo" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�������ʦ��ţ�</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��¼���룺</td>
                    <td width="650px;">
                         <input id="password" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�������¼���룡</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��ʦ������</td>
                    <td width="650px;">
                         <input id="teacherName" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�������ʦ������</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��ʦ�Ա�</td>
                    <td width="650px;">
                         <input id="teacherSex" type="text"   style="width:40px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�������ʦ�Ա�</td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  �������ڣ�</td>
                    <td width="650px;">
                          <asp:TextBox ID="birthDate"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd');"></asp:TextBox></td>                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��ʦ��Ƭ��</td>
                    <td width="650px;">
                       <table cellpadding="0px" cellspacing="0px" width="90%">
                        <tr><td width="400px">
                         ͼƬ·����<asp:TextBox ID="teacherPhoto" runat="server" ReadOnly="True" Width="228px" Enabled="False"></asp:TextBox> &nbsp; &nbsp; &nbsp
                         <br />
                         <br />
                         �ϴ�ͼƬ��<asp:FileUpload ID="TeacherPhotoUpload" runat="server" Width="237px" />&nbsp;
                         <asp:Button ID="Btn_TeacherPhotoUpload" runat="server" Text="�ϴ�" OnClick="Btn_TeacherPhotoUpload_Click" /></td><td>
                         <asp:Image ID="TeacherPhotoImage" runat="server" Height="90px" Width="99px" />
                         </td></tr>
                       </table>
                    </td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��ʦְ�ƣ�</td>
                    <td width="650px;">
                         <input id="zhicheng" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�������ʦְ�ƣ�</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��ϵ�绰��</td>
                    <td width="650px;">
                         <input id="telephone" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>��������ϵ�绰��</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��ʦ���ܣ�</td>
                    <td width="650px;">
                        <textarea id="teacherDesc" rows=6 cols=80 runat="server"></textarea><span class="WarnMes">*</span>�������ʦ���ܣ�</td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnTeacherSave" runat="server" Text=" �޸ĸ�����Ϣ "
                            OnClientClick="return CheckIn()" onclick="BtnTeacherSave_Click"  />
                         </td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

