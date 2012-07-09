<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TaoMeetting.Domain.BrandInfo>" %>
<%@ Import Namespace="TaoMeetting.Domain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	编辑品牌 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>编辑品牌</h2>
    <script src="../../../../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
     <script src="../../../../jquery.uploadify-v2.1.0/jquery.uploadify.v2.1.0.min.js" type="text/javascript"></script>
    <script src="../../../../jquery.uploadify-v2.1.0/swfobject.js" type="text/javascript"></script>
    <link href="../../../../jquery.uploadify-v2.1.0/uploadify.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#uploadify").uploadify({
                'uploader': '/jquery.uploadify-v2.1.0/uploadify.swf',
                'script': '/Handlers/UploadFile.ashx',
                'cancelImg': '/jquery.uploadify-v2.1.0/cancel.png',
                'folder': '/UpLoad/BrandPic',
                'queueID': 'fileQueue',
                'fileDesc': '图片文件',
                'fileExt': '*.jpg;*.bmp;*.png;*.gif',
                'auto': true,
                'multi': false,
                'onComplete': function (event, queueId, fileObj, response, data) {
                    //alert(fileObj.filePath);
                    //debugger;
                    $('#image').attr('src', '/UpLoad/BrandPic/' + response);
                    $('#image').fadeIn(500);
                    $('#BrandPic').val('/UpLoad/BrandPic/' + response);
                }
            });
           Init();
        });
        function Init() {
            $("#city").val('<%= ViewData["selectedcity"]%>');

        }
        function ShowPriceDiv(id) {
            //debugger;
            if ($("#ckbt" + id)[0].checked) {
                $("#pricediv" + id)[0].style.display = "block";
            } else {
                $("#pricediv" + id)[0].style.display = "none";
            }
        }
        function SetPrice(id, obj) {
            //debugger;
            $("#hdprice" + id).val(obj.value);
        }
        function checkInfo() {
            // debugger;
            if ($("#BrandName").val() == "" || $("#BrandName").val() == undefined) {
                alert("请填写名称");
                return false;
            }
            if ($('#BrandPic').val() == "" || $("#BrandPic").val() == undefined) {
                alert("请填上传图片");
                return false;
            }
            if ($('#city').val() == "" || $("#city").val() == undefined) {
                alert("请选择地址");
                return false;
            }
            //            var basefun = $("#ckftb");
            //            Boolean hasbasfun=false;
            //            for (var i = 0; i < basefun.length; i++) {
            //                if (basefun[i].checked) {
            //                 hasbasfun=true;
            //                }
            //            }
            //            if(!hasbasfun)
            //            {
            //                  alert("请选择基本功能");
            //                return false;
            //            }
        }
    </script>  
     <%using (Html.BeginForm()){ %>
       <table>
         <tr><td>品牌名称</td><td><%=Html.TextBoxFor(bi=>bi.BrandName) %></td></tr>
          <tr><td colspan="2">
        <img src='<%=ViewData["brandpic"]%>' id="image" name="image" />
         </td></tr>
         <tr><td>上传图片</td><td>
          <div id="fileQueue"></div>
        <input type="file" name="uploadify" id="uploadify" />
         </td></tr>
        
         <tr><td>地址</td><td><%=Html.DropDownList("city",ViewData["city"] as SelectList,"--请选择--",new{}) %></td></tr>
          <%if (ViewData["ftb"] != null)
            { %>
            <tr><td colspan="2"><hr /></td></tr>
          <tr><td>基本功能:</td><td>
               <table>
             <%
                foreach (FunctionType ft in ViewData["ftb"] as IList<FunctionType>)
                {
               %>
               <tr><td align="right">
               <div><span><%=ft.FunName%><input type="checkbox" id="BaseFuns" name="BaseFuns" value="<%=ft.id %>" <%if(ft.hascheck){%> checked<%} %> ></span></div>
               </td></tr>
               <%
                }
                  %>
                  </table>
          </td></tr>
          <%} if (ViewData["fts"] != null)
            { %>
              <tr><td colspan="2"><hr /></td></tr>
           <tr><td>特殊功能:</td><td>
           <table>
             <%
                foreach (FunctionType ft in ViewData["fts"] as IList<FunctionType>)
                {
               %>
               <tr><td align="right">
               <div><span><%=ft.FunName%><input type="checkbox" id="SpecFuns" name="SpecFuns" value="<%=ft.id %>" <%if(ft.hascheck){ %> checked<%} %>/></span></div>
               </td></tr>
               <%
                }
                  %>
                  </table>
          </td></tr>
          <%} %>
            <tr><td colspan="2"><hr /></td></tr>
           
            <%if (ViewData["product"] != null)
              { %>
               <tr> <td>产品用途:</td><td>
                  <%foreach (ProductType pt in ViewData["product"] as IList<ProductType>)
                    {
                        %>
              <div><span style="text-align:right">
              <%=pt.TypeName%>
              <input type="checkbox" id="BrandProducts" name="BrandProducts" value="<%=pt.id%>" <%if(pt.haschecked){ %> checked<%} %> /></span></div>
                        <%
                    } %>
               </td></tr>
            <%} %>
             <tr><td colspan="2"><hr /></td></tr>
             <%if (ViewData["buytype"] != null)
               { %>
                <tr> <td>购买方式:</td><td>
                <%foreach (BuyType bt in ViewData["buytype"] as IList<BuyType>)
                  {
                    %>
                    <div><%=bt.BuyTypeName %>
             <input type="checkbox" id="ckbt<%=bt.id%>" name="ckbt<%=bt.id%>"  onclick="ShowPriceDiv(<%=bt.id %>)" value='<%=bt.id %>' <%if(bt.haschecked){ %> checked <%} %>/><span id="pricediv<%=bt.id %>" <%if(bt.haschecked){ %> style="width:120px;"<%}else { %>style="display:none; width:120px;"<%} %>><input type="text" name="txtprice<%=bt.id%>" id="txtprice<%=bt.id%>" <%if(bt.haschecked){ %> value='<%=ViewData["bt"+bt.id] %>' <%} %> onchange="SetPrice(<%=bt.id%>,this)" style="width:50px;" />元/点/月</span></div>
                    <%
                  } %>
                </td></tr>
             <%} %>
              <tr><td>联系方式</td><td><%:Html.TextBoxFor(bi=>bi.Phone) %></td></tr>
              <tr><td>官网</td><td><%:Html.TextBoxFor(bi=>bi.Url) %></td></tr>
              <tr><td>基本功能评分</td><td><%:Html.TextBoxFor(bi=>bi.BaseFunScore) %></td></tr>
               <tr><td>特殊功能评分</td><td><%:Html.TextBoxFor(bi=>bi.SpecialFunScore) %></td></tr>
                 <tr><td>权重</td><td><%:Html.TextBoxFor(bi=>bi.Weight) %></td></tr>
         <tr>
           <td colspan="2"> <input type="submit" value="保存" onclick="return checkInfo()"  /></td>
         </tr>
         <tr><td colspan="2">  <%=Html.ActionLink("返回列表","Index") %></td></tr>
       </table>
       <%:Html.HiddenFor(bi=>bi.BrandPic)%>
    <%}%>
</asp:Content>
