<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcContrib.Pagination.IPagination<TaoMeetting.Domain.BrandInfo>>" %>

<%@ Import Namespace="MvcContrib.UI.Pager" %>
<%@ Import Namespace="MvcContrib.UI.Grid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	品牌列表
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>品牌列表</h2>
    <%=Html.ActionLink("添加品牌", "CreateBrand")%>
<%=Html.Grid(Model).Columns(column => {
    column.For(bd =>bd.id).Named("id").Sortable(true);
    column.For(bd => bd.BrandName).Named("品牌名称").Sortable(true);
    column.For(bd=>bd.BrandPic).Named("图片").Sortable(true);
    column.For(bd => bd.Address.Name).Named("地址").Sortable(true);
    column.For(bd =>bd.Products).Named("产品用途").Sortable(true);
    column.For(bd => bd.Phone).Named("联系方式").Sortable(true);
    column.For(bd => bd.Url).Named("官网").Sortable(true);
    column.For(bd => bd.BFunctions).Named("基本功能").Sortable(true);
    column.For(bd => bd.SFunctions).Named("特殊功能").Sortable(true);
    column.For(bd => bd.BaseFunScore).Named("基本功能评分").Sortable(true);
    column.For(bd => bd.SpecialFunScore).Named("特殊功能评分").Sortable(true);
    column.For(bd => bd.Buytypes).Named("购买方式").Sortable(true); 
    column.For(bd => bd.Weight).Named("权重").Sortable(true);
    column.For(ft => Html.ActionLink("编辑", "EditBrand", new { id = ft.id })).Named("编辑").DoNotEncode().Sortable(false);
    column.For(ft => Html.ActionLink("删除", "DeleteBrand", new { id = ft.id })).Named("删除").DoNotEncode().Sortable(false);
})%>
<%=Html.Pager(Model) %>
</asp:Content>
