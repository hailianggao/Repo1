<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TaoMeetting.Domain.BuyType>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    添加购买方式
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>添加购买方式</h2>
 <%using (Html.BeginForm()){ %>
       <table>
         <tr><td>购买方式名称</td><td><%=Html.TextBoxFor(ft=>ft.BuyTypeName) %></td></tr>
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
