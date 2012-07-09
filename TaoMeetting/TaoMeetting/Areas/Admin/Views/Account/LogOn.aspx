<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    登陆
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    function check() {
        //debugger;
        if ($("#username").val() == "" || $("#username").val() == undefined) {
            alert("请填写用户名");
            return false;
        }
        if ($("#pwd").val() == "" || $("#pwd").val() == undefined) {
            alert("请填写密码");
            return false;
        }
        if ($("#username").val() == "tmadmin" && $("#pwd").val() == "tmadmin") {
            return true;
        }
        else {
            alert('用户名或密码错误');
            $("#username").val("");
            $("#pwd").val("");
            return false;
        }
    }
</script>
<h2>登陆</h2>
  <%using (Html.BeginForm())
    { %>
       <table>
       <tr><td align="right">用户名:</td><td><input type="text" id="username" name="username" /></td></tr>
         <tr><td align="right">密码:</td><td><input type="password" id="pwd" name="pwd" /></td></tr>
         <tr>
         <td colspan="2">
         <input type="submit" value="登陆" onclick="return check()" />
         </td>
         </tr>
       </table>
  <%} %>
</asp:Content>
