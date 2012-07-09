<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TaoMeetting.Domain.PriceRange>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    编辑价格区间
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>编辑价格区间</h2>
 <%using (Html.BeginForm()){ %>
       <table>
          <tr><td>最低价格</td><td><%=Html.TextBoxFor(pr => pr.lowprice)%></td></tr>
         <tr><td>最高价格</td><td><%=Html.TextBoxFor(pr => pr.highprice)%></td></tr>
         <tr>
           <td colspan="2"> <input type="submit" value="保存" /></td>
         </tr>
           <tr>
           <td colspan="2">
          <%=Html.ActionLink("返回列表","Index") %>
            </td>
         </tr>
       </table>
    <%}%>
</asp:Content>
