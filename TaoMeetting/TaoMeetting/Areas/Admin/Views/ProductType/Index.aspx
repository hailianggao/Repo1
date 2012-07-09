<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcContrib.Pagination.IPagination<TaoMeetting.Domain.ProductType>>" %>
<%@ Import Namespace="MvcContrib.UI.Pager" %>
<%@ Import Namespace="MvcContrib.UI.Grid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	产品用途列表
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%
    if (ViewBag.alertstr != null)
    {
        Response.Write(ViewBag.alertstr);
        ViewBag.alertstr = null;
    }
     %>
    <h2>产品用途列表</h2>
    <%=Html.ActionLink("添加用途","CreatePro") %>
<%=Html.Grid(Model).Columns(column => {
    column.For(pt => pt.id).Named("id").Sortable(true);
    column.For(pt => pt.TypeName).Named("用途名称").Sortable(true);
    column.For(pt =>Html.ActionLink("图片","",new {pic=pt.TypePic},new {style="background-image:"+pt.TypePic})).Named("图片").Sortable(true);
    column.For(pt => Html.ActionLink("编辑", "EditPro", new { id = pt.id })).Named("编辑").DoNotEncode().Sortable(false);
    column.For(pt => Html.ActionLink("删除", "DeletePro", new { id = pt.id })).Named("删除").DoNotEncode().Sortable(false);
})%>
<%=Html.Pager(Model) %>
</asp:Content>
