<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Teacher_Left.aspx.cs" Inherits="WebSystem.Admin.Admin_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script src="JavaScript/Admin.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="LeftNote">
    <img src="Images/MenuTop.jpg"/><br /><img src="images/menu_topline.gif" alt=""/>
    
        

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;论文题目管理</div>
        <div class="MenuNote" style="display:none;" id="SubjectDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="SubjectTeacherAdd.aspx" target="main">发布论文题目</a></li>
                <li><a href="SubjectTeacherList.aspx" target="main">我发布论文题目</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;学生选题管理</div>
        <div class="MenuNote" style="display:none;" id="SubSelectDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="SubSelectTeacherList.aspx" target="main">我的学生选题查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;学生成果管理</div>
        <div class="MenuNote" style="display:none;" id="OpusDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="OpusTeacherList.aspx" target="main">学生成果审核评价</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;答辩视频管理</div>
        <div class="MenuNote" style="display:none;" id="VideoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="VideoEdit.aspx" target="main">添加答辩视频</a></li>
                <li><a href="VideoList.aspx" target="main">答辩视频查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;留言管理</div>
        <div class="MenuNote" style="display:none;" id="LeavewordDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="LeavewordEdit.aspx" target="main">添加留言</a></li>
                <li><a href="LeavewordList.aspx" target="main">留言查询</a></li> 
            </ul>
        </div>
         
 
  
       <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;系统信息管理</div>
        <div class="MenuNote" style="display:none;" id="sysDiv"  runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
           <li><a href="TeacherSelfEdit.aspx" target="main">修改个人信息</a></li>          
            </ul>
        </div>
        <asp:HiddenField ID="Hvalue" runat="server" />
    </div>
    </form>
</body>
</html>
