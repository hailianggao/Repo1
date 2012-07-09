<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcContrib.Pagination.IPagination<TaoMeetting.Domain.BuyType>>" %>
<%@ Import Namespace="MvcContrib.UI.Pager" %>
<%@ Import Namespace="MvcContrib.UI.Grid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    购买方式列表
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%
    if (ViewBag.alertstr != null)
    {
        Response.Write(ViewBag.alertstr);
        ViewBag.alertstr = null;
    }
     %>
<h2>购买方式列表</h2>
 <%=Html.ActionLink("添加购买方式", "CreateBuytype")%>
<%=Html.Grid(Model).Columns(column => {
    column.For(bt =>bt.BuyTypeName).Named("id").Sortable(true);
    column.For(bt => Html.ActionLink("编辑", "EditBuytype", new { id = bt.id })).Named("编辑").DoNotEncode().Sortable(false);
    column.For(bt => Html.ActionLink("删除", "DeleteBuytype", new { id = bt.id })).Named("删除").DoNotEncode().Sortable(false);
})%>
<%=Html.Pager(Model) %>
</asp:Content>
