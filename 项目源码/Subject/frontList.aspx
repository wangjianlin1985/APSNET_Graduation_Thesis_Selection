<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="Subject_frontList" %>
<%@ Register Src="../header.ascx" TagName="header" TagPrefix="uc" %>
<%@ Register Src="../footer.ascx" TagName="footer" TagPrefix="uc" %>
<%
    String path = Request.ApplicationPath;
    String basePath = path + "/"; 
%>
<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1 , user-scalable=no">
<title>论文题目查询</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
 <form id="form2" runat="server">
	<div class="row"> 
		<div class="col-md-9 wow fadeInDown" data-wow-duration="0.5s">
			<div>
				<!-- Nav tabs -->
				<ul class="nav nav-tabs" role="tablist">
			    	<li><a href="../index.aspx">首页</a></li>
			    	<li role="presentation" class="active"><a href="#subjectListPanel" aria-controls="subjectListPanel" role="tab" data-toggle="tab">论文题目列表</a></li>
			    	<li role="presentation" ><a href="frontAdd.aspx" style="display:none;">添加论文题目</a></li>
				</ul>
			  	<!-- Tab panes -->
			  	<div class="tab-content">
				    <div role="tabpanel" class="tab-pane active" id="subjectListPanel">
				    		<div class="row">
				    			<div class="col-md-12 top5">
				    				<div class="table-responsive">
				    				<table class="table table-condensed table-hover">
				    					<tr class="success bold"><td>序号</td><td>题目id</td><td>题目名称</td><td>题目类型</td><td>任务书文件</td><td>其他资料文件</td><td>限选人数</td><td>指导老师</td><td>发布时间</td><td>操作</td></tr>
				    					<asp:Repeater ID="RpSubject" runat="server">
 										<ItemTemplate>
 										<tr>
 											<td><%#(Container.ItemIndex + 1)%></td>
 											<td><%#Eval("subjectId")%></td>
 											<td><%#Eval("subjectName")%></td>
 											<td><%#GetSubjectTypesubjectTypeObj(Eval("subjectTypeObj").ToString())%></td>
 											<td><%#Eval("taskFile").ToString() == ""?"暂无文件":"<a href='../" + Eval("taskFile").ToString() + "' target='_blank'>" + Eval("taskFile").ToString() +  "</a>" %></td>
 											<td><%#Eval("otherFile").ToString() == ""?"暂无文件":"<a href='../" + Eval("otherFile").ToString() + "' target='_blank'>" + Eval("otherFile").ToString() +  "</a>" %></td>
 											<td><%#Eval("personNum")%></td>
 											<td><%#GetTeacherteacherObj(Eval("teacherObj").ToString())%></td>
 											<td><%#Eval("addTime")%></td>
 											<td>
 												<a href="frontshow.aspx?subjectId=<%#Eval("subjectId")%>"><i class="fa fa-info"></i>&nbsp;查看</a>&nbsp;
 												<a href="#" onclick="subjectEdit('<%#Eval("subjectId")%>');" style="display:none;"><i class="fa fa-pencil fa-fw"></i>编辑</a>&nbsp;
 												<a href="#" onclick="subjectDelete('<%#Eval("subjectId")%>');" style="display:none;"><i class="fa fa-trash-o fa-fw"></i>删除</a>
 											</td> 
 										</tr>
 										</ItemTemplate>
 										</asp:Repeater>
				    				</table>
				    				</div>
				    			</div>
				    		</div>

				    		<div class="row">
					            <div class="col-md-12">
						            <nav class="pull-left">
						                <ul class="pagination">
						                    <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn"
						                      onclick="LBHome_Click">[首页]</asp:LinkButton>
						                    <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
						                      onclick="LBUp_Click">[上一页]</asp:LinkButton>
						                    <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn"
						                      onclick="LBNext_Click">[下一页]</asp:LinkButton>
						                    <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn"
						                      onclick="LBEnd_Click">[尾页]</asp:LinkButton>
						                    <asp:HiddenField ID="HSelectID" runat="server" Value=""/>
						                    <asp:HiddenField ID="HWhere" runat="server" Value=""/>
						                    <asp:HiddenField ID="HNowPage" runat="server" Value="1"/>
						                    <asp:HiddenField ID="HPageSize" runat="server" Value="8"/>
						                    <asp:HiddenField ID="HAllPage" runat="server" Value="0"/>
						                </ul>
						            </nav>
						            <div class="pull-right" style="line-height:75px;" ><asp:Label runat="server" ID="PageMes"></asp:Label></div>
					            </div>
				            </div> 
				    </div>
				</div>
			</div>
		</div>
	<div class="col-md-3 wow fadeInRight">
		<div class="page-header">
    		<h1>论文题目查询</h1>
		</div>
			<div class="form-group">
				<label for="subjectName">题目名称:</label>
				<asp:TextBox ID="subjectName" runat="server"  CssClass="form-control" placeholder="请输入题目名称"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="subjectTypeObj_subjectId">题目类型：</label>
                <asp:DropDownList ID="subjectTypeObj" runat="server"  CssClass="form-control" placeholder="请选择题目类型"></asp:DropDownList>
            </div>
            <div class="form-group">
            	<label for="teacherObj_subjectId">指导老师：</label>
                <asp:DropDownList ID="teacherObj" runat="server"  CssClass="form-control" placeholder="请选择指导老师"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="addTime">发布时间:</label>
				<asp:TextBox ID="addTime"  runat="server" CssClass="form-control" placeholder="请选择发布时间" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
            <input type=hidden name=currentPage value="" />
            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>

	</div>
 </form>
</div> 
<div id="subjectEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;论文题目信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="subjectEditForm" id="subjectEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="subject_subjectId_edit" class="col-md-3 text-right">题目id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="subject_subjectId_edit" name="subject.subjectId" class="form-control" placeholder="请输入题目id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="subject_subjectName_edit" class="col-md-3 text-right">题目名称:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="subject_subjectName_edit" name="subject.subjectName" class="form-control" placeholder="请输入题目名称">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="subject_subjectTypeObj_typeId_edit" class="col-md-3 text-right">题目类型:</label>
		  	 <div class="col-md-9">
			    <select id="subject_subjectTypeObj_typeId_edit" name="subject.subjectTypeObj.typeId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="subject_sujectContent_edit" class="col-md-3 text-right">题目内容:</label>
		  	 <div class="col-md-9">
			    <textarea id="subject_sujectContent_edit" name="subject.sujectContent" rows="8" class="form-control" placeholder="请输入题目内容"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="subject_taskFile_edit" class="col-md-3 text-right">任务书文件:</label>
		  	 <div class="col-md-9">
			    <a id="subject_taskFileA" target="_blank"></a><br/>
			    <input type="hidden" id="subject_taskFile" name="subject.taskFile"/>
			    <input id="taskFileFile" name="taskFileFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="subject_otherFile_edit" class="col-md-3 text-right">其他资料文件:</label>
		  	 <div class="col-md-9">
			    <a id="subject_otherFileA" target="_blank"></a><br/>
			    <input type="hidden" id="subject_otherFile" name="subject.otherFile"/>
			    <input id="otherFileFile" name="otherFileFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="subject_personNum_edit" class="col-md-3 text-right">限选人数:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="subject_personNum_edit" name="subject.personNum" class="form-control" placeholder="请输入限选人数">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="subject_teacherObj_teacherNo_edit" class="col-md-3 text-right">指导老师:</label>
		  	 <div class="col-md-9">
			    <select id="subject_teacherObj_teacherNo_edit" name="subject.teacherObj.teacherNo" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="subject_addTime_edit" class="col-md-3 text-right">发布时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date subject_addTime_edit col-md-12" data-link-field="subject_addTime_edit">
                    <input class="form-control" id="subject_addTime_edit" name="subject.addTime" size="16" type="text" value="" placeholder="请选择发布时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		</form> 
	    <style>#subjectEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxSubjectModify();">提交</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap-datetimepicker.min.js"></script>
<script src="<%=basePath %>plugins/locales/bootstrap-datetimepicker.zh-CN.js"></script>
<script type="text/javascript" src="<%=basePath %>js/jsdate.js"></script>
<script>
var basePath = "<%=basePath%>";
/*弹出修改论文题目界面并初始化数据*/
function subjectEdit(subjectId) {
	$.ajax({
		url :  basePath + "Subject/SubjectController.aspx?action=getSubject&subjectId=" + subjectId,
		type : "get",
		dataType: "json",
		success : function (subject, response, status) {
			if (subject) {
				$("#subject_subjectId_edit").val(subject.subjectId);
				$("#subject_subjectName_edit").val(subject.subjectName);
				$.ajax({
					url: basePath + "SubjectType/SubjectTypeController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(subjectTypes,response,status) { 
						$("#subject_subjectTypeObj_typeId_edit").empty();
						var html="";
		        		$(subjectTypes).each(function(i,subjectType){
		        			html += "<option value='" + subjectType.typeId + "'>" + subjectType.typeName + "</option>";
		        		});
		        		$("#subject_subjectTypeObj_typeId_edit").html(html);
		        		$("#subject_subjectTypeObj_typeId_edit").val(subject.subjectTypeObjPri);
					}
				});
				$("#subject_sujectContent_edit").val(subject.sujectContent);
				$("#subject_taskFile").val(subject.taskFile);
				$("#subject_taskFileA").text(subject.taskFile);
				$("#subject_taskFileA").attr("href", basePath +　subject.taskFile);
				$("#subject_otherFile").val(subject.otherFile);
				$("#subject_otherFileA").text(subject.otherFile);
				$("#subject_otherFileA").attr("href", basePath +　subject.otherFile);
				$("#subject_personNum_edit").val(subject.personNum);
				$.ajax({
					url: basePath + "Teacher/TeacherController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(teachers,response,status) { 
						$("#subject_teacherObj_teacherNo_edit").empty();
						var html="";
		        		$(teachers).each(function(i,teacher){
		        			html += "<option value='" + teacher.teacherNo + "'>" + teacher.teacherName + "</option>";
		        		});
		        		$("#subject_teacherObj_teacherNo_edit").html(html);
		        		$("#subject_teacherObj_teacherNo_edit").val(subject.teacherObjPri);
					}
				});
				$("#subject_addTime_edit").val(subject.addTime);
				$('#subjectEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除论文题目信息*/
function subjectDelete(subjectId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Subject/SubjectController.aspx?action=delete",
			data : {
				subjectId : subjectId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
					$("#btnSearch").click();
					//location.href= basePath + "Subject/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交论文题目信息表单给服务器端修改*/
function ajaxSubjectModify() {
	$.ajax({
		url :  basePath + "Subject/SubjectController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#subjectEditForm")[0]),
		success : function (obj, response, status) {
            if(obj.success){
                alert("信息修改成功！");
                $("#btnSearch").click();
            }else{
                alert(obj.message);
            } 
		},
		processData: false,
		contentType: false,
	});
}

$(function(){
	/*小屏幕导航点击关闭菜单*/
    $('.navbar-collapse a').click(function(){
        $('.navbar-collapse').collapse('hide');
    });
    new WOW().init();

    /*发布时间组件*/
    $('.subject_addTime_edit').datetimepicker({
    	language:  'zh-CN',  //语言
    	format: 'yyyy-mm-dd hh:ii:ss',
    	weekStart: 1,
    	todayBtn:  1,
    	autoclose: 1,
    	minuteStep: 1,
    	todayHighlight: 1,
    	startView: 2,
    	forceParse: 0
    });
})
</script>
</body>
</html>

