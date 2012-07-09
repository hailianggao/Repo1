<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TaoMeetting.Domain.ProductType>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	编辑产品用途
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../../../jquery.uploadify-v2.1.0/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="../../../../jquery.uploadify-v2.1.0/jquery.uploadify.v2.1.0.min.js"
        type="text/javascript"></script>
    <script src="../../../../jquery.uploadify-v2.1.0/swfobject.js" type="text/javascript"></script>
    <link href="../../../../jquery.uploadify-v2.1.0/uploadify.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#uploadify").uploadify({
                'uploader': '/jquery.uploadify-v2.1.0/uploadify.swf',
                'script': '/Handlers/UploadFile.ashx',
                'cancelImg': '/jquery.uploadify-v2.1.0/cancel.png',
                'folder': '/UpLoad/ProductPic',
                'queueID': 'fileQueue',
                'fileDesc': '图片文件',
                'fileExt': '*.jpg;*.bmp;*.png;*.gif',
                'auto': true,
                'multi': false,
                'onComplete': function (event, queueId, fileObj, response, data) {
                    //alert(fileObj.filePath);
                    //debugger;
                    $('#image').attr('src', '/UpLoad/ProductPic/' + response);
                    $('#image').fadeIn(500);
                    $('#TypePic').val('/UpLoad/ProductPic/' + response);
                }
            });
           
        });  
    </script>  
    <h2>编辑产品用途</h2>
     <%using (Html.BeginForm()){ %>
       <table>
         <tr><td>产品用途名称</td><td><%=Html.TextBoxFor(pt=>pt.TypeName) %></td></tr>
         <tr><td>上传图片</td><td>
          <div id="fileQueue"></div>
        <input type="file" name="uploadify" id="uploadify" />
         </td></tr>
         <tr><td colspan="2">
         <img src="<%=Model.TypePic!=null?Model.TypePic:"" %>" id="image" name="image" />
         </td></tr>
         <tr>
           <td colspan="2"> <input type="submit" value="保存" /></td>
         </tr>
         <tr><td colspan="2">  <%=Html.ActionLink("返回列表","Index") %></td></tr>
       </table>
       <%=Html.HiddenFor(pt=>pt.TypePic)%>
    <%}%>

</asp:Content>
