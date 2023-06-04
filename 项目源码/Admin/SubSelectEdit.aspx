<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SubSelectEdit.aspx.cs" Inherits="chengxusheji.Admin.SubSelectEdit" %>
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
            var selectTime = document.getElementById("selectTime").value;
            if (selectTime == "") {
                alert("������ѡ��ʱ��...");
                document.getElementById("selectTime").focus();
                return false;
            }

            var shenHeState = document.getElementById("shenHeState").value;
            if (shenHeState == "") {
                alert("���������״̬...");
                document.getElementById("shenHeState").focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">ѧ��ѡ����� �����༭ѧ��ѡ��</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    ������Ŀ��</td>
                    <td width="650px;">
                         <asp:DropDownList ID="subjectObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    ѡ��ѧ����</td>
                    <td width="650px;">
                         <asp:DropDownList ID="userObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  ѡ��ʱ�䣺</td>
                    <td width="650px;">
                          <asp:TextBox ID="selectTime"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd hh:mm:ss');"></asp:TextBox></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ���״̬��</td>
                    <td width="650px;">
                         <input id="shenHeState" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>���������״̬��</td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnSubSelectSave" runat="server" Text=" ������Ϣ "
                            OnClientClick="return CheckIn()" onclick="BtnSubSelectSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="ȡ��" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

