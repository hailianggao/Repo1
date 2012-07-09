<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcContrib.Pagination.IPagination<TaoMeetting.Domain.FunctionType>>" %>
<%@ Import Namespace="MvcContrib.UI.Pager" %>
<%@ Import Namespace="MvcContrib.UI.Grid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	功能列表
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    function DelAlert() {
        return confirm("确定删除吗？");
    }
</script>
<%
    if (ViewBag.alertstr != null)
    {
        Response.Write(ViewBag.alertstr);
        ViewBag.alertstr = null;
    }
     %>
<h2>功能列表</h2>
<%=Html.ActionLink("添加功能","CreateFun") %>
<%=Html.Grid(Model).Columns(column => {
    column.For(ft => ft.id).Named("id").Sortable(true);
    column.For(ft => ft.FunName).Named("功能名称").Sortable(true);
    column.For(ft => ft.FunTypeName).Named("功能类型").Sortable(true);
    column.For(ft => Html.ActionLink("编辑", "EditFun", new { id = ft.id })).Named("编辑").DoNotEncode().Sortable(false);
    column.For(ft => Html.ActionLink("删除", "DeleteFun", new { id = ft.id }, new { onclick = "return DelAlert()" })).Named("删除").DoNotEncode().Sortable(false);
})%>
<%=Html.Pager(Model) %>
</asp:Content>
