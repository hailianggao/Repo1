<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TaoMeetting.Domain.FunctionType>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	添加功能
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>添加功能</h2>
    <%using (Html.BeginForm()){ %>
       <table>
         <tr><td>功能名称</td><td><%=Html.TextBoxFor(ft=>ft.FunName) %></td></tr>
         <tr><td>功能类别</td><td><select id="FunType" name="FunType">
            <option value="0" selected>普通功能</option>
             <option value="1">特殊功能</option>
         </select></td></tr>
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
