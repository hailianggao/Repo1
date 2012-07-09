<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcContrib.Pagination.IPagination<TaoMeetting.Domain.PriceRange>>" %>
<%@ Import Namespace="MvcContrib.UI.Pager" %>
<%@ Import Namespace="MvcContrib.UI.Grid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    价格区间列表
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>价格区间列表</h2>
<%=Html.ActionLink("添加价格区间", "CreatePriceRange")%>
<%=Html.Grid(Model).Columns(column => {
    column.For(pr => pr.id).Named("id").Sortable(true);
    column.For(pr=> pr.lowprice).Named("最低价格").Sortable(true);
    column.For(pr => pr.highprice).Named("最高价格").Sortable(true);
    column.For(pr => Html.ActionLink("编辑", "EditPriceRange", new { id = pr.id })).Named("编辑").DoNotEncode().Sortable(false);
    column.For(pr => Html.ActionLink("删除", "DeletePriceRange", new { id = pr.id })).Named("删除").DoNotEncode().Sortable(false);
})%>
<%=Html.Pager(Model) %>
</asp:Content>
