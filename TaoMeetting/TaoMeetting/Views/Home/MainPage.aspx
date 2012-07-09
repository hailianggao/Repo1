<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<TaoMeetting.Domain.BrandInfo>>" %>
<%@ Import Namespace="TaoMeetting.Domain" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<style type="text/css">

</style>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>搜索页面</title>
  <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script src="../../Scripts/FilterClick.js" type="text/javascript"></script>
<script type="text/javascript">

    $(document).ready(function () {
        //debugger;
        SetBgForProductObj($('#<%=ViewBag.objid%>')[0], 'productobj',true);
//         var objs = $(".productobj");
//       for (var i = 0; i < objs.length; i++) {
//          objs[i].style.filter = 'alpha(opacity=60)';
//         // objs[i].style.cssText="filter:progid:DXImageTransform.Microsoft.BasicImage(grayscale=1)";
//          //objs[i].style.setPorperty("filter","progid:DXImageTransform.Microsoft.BasicImage(grayscale=1)");
//          //objs[i].style.opacity=0.5;
//         }
//    $('#<%=ViewBag.objid%>')[0].style.filter = '';
   //$('#<%=ViewBag.objid%>')[0].style.opacity = '';
        OutPutData(<%=ViewBag.datastr%>);
    });
</script>
</head>

<body>
<!--header-->
<div id="header_2"><a href="/Home/Index"><img src="../../images/01.jpg"  title="返回首页"/></a></div>
<!--mb_2-->
<div id="mb_2">
	<!--mb_2_left-->
	<div class="mb_2_left">
    	<div class="left_content">
        	<h2 class="pro"><img class="jiantou" src="../../images/09.jpg" />用途分类</h2>
			<div class="button">
            <%
                if (ViewData["prolist"] != null)
                {
                    foreach (ProductType proitem in ViewData["prolist"] as List<ProductType>)
                    {
                        %>
<a href="#"><img src="<%=proitem.TypePic %>" id="<%=proitem.id%>" onclick="SetBgForProductObj(this,'productobj',false)" class="productobj" /></a>
                        <%
                    }
                      %>

                    <%
                }
                else
                {
                    %>
                <span>没有产品用途列表</span>    
                    <%
                }
                 %>
            </div>
        </div>
        <div class="left_content_2"><img src="../../images/r.jpg" /></div>
    </div><!--mb_2_left over-->
    <!--mb_2_right-->
    <div class="mb_2_right">
    	<div class="right_content_1">
        	<div class="word"><img class="jiantou jiantou1" src="../../images/09.jpg" />筛选条件<span onclick="ClearAllFilter()" style="margin-left:600px;cursor:pointer;">清除所选条件</span></div>
            <div class="none">
            <div class="none_0">
                	<p class="key">
                    <table><tr><td><span style=" margin-left:8px; margin-bottom:40px;">购买方式&nbsp;：</span></td>
                <td> 
                   <%
                       ViewDataDictionary buytypevdd = new ViewDataDictionary();
                       buytypevdd.Add("buytype", ViewData["buytypelist"] as List<BuyType>);
                        %>
                        <%=Html.Partial("BuyTypeList", buytypevdd)%>
                </td></tr></table>
                    </p>
                </div>
            <div class="none_1">
                	<p class="key">
                    <table><tr><td><span style=" margin-left:8px; margin-bottom:40px;">参考价格&nbsp;：</span></td>
                <td> 
                   <%
                       ViewDataDictionary pricerangevdd = new ViewDataDictionary();
                       pricerangevdd.Add("pricerange", ViewData["pricelist"] as List<PriceRange>);
                        %>
                        <%=Html.Partial("PriceRangeList", pricerangevdd)%>
                </td></tr></table>
                    </p>
                </div><!--none_1 over-->
            <div class="none_2">
                <p class="key key1">
                <table><tr><td><span style=" margin-left:8px; margin-bottom:40px;">所&nbsp;&nbsp;在&nbsp;&nbsp;地：</span></td>
                <td> 
                   <%
                       ViewDataDictionary addressvdd = new ViewDataDictionary();
                       addressvdd.Add("address", ViewData["adlist"] as List<Address>);
                        %>
                        <%=Html.Partial("AddressList",addressvdd) %>
                </td></tr></table>
                    </p>
                </div><!--none_2 over-->
            <div class="none_2">
                     <p class="key key3">
                      <table><tr><td><span style=" margin-left:8px; margin-bottom:20px;">基本功能&nbsp;：</span></td>
                <td> 
                   <%
                       ViewDataDictionary basefunvdd = new ViewDataDictionary();
                       basefunvdd.Add("basefuns", ViewData["basefun"] as List<FunctionType>);
                       basefunvdd.Add("funobj", "basefunobj");
                        %>
                        <%=Html.Partial("BaseFunList", basefunvdd)%>
                </td></tr></table>
                    </p>
                </div><!--none_3 over-->
            <div class="none_2 none_3">
                	 <p class="key key3"><table><tr><td><span style=" margin-left:8px; margin-bottom:20px;">特色功能&nbsp;：</span></td>
                <td> 
                   <%
                       ViewDataDictionary specfunvdd = new ViewDataDictionary();
                       specfunvdd.Add("basefuns", ViewData["specfun"] as List<FunctionType>);
                       specfunvdd.Add("funobj", "specfunobj");
                        %>
                        <%=Html.Partial("BaseFunList", specfunvdd)%>
                </td></tr></table></p>
                </div>
            </div><!--none over-->
        </div><!--right_content_1 over-->
      <div class="right_content_2">
        	<div class="word"><img class="jiantou jiantou1" src="../../images/09.jpg" />商家信息</div>	
            <div class="emp"><a style="margin-left:48px;">品牌</a><a>名称</a><a>所在地</a><a>参考价格</a></div>
            <div id="innerDiv" class="innerDiv">
              
            </div>

        </div><!--right_content_2 over-->
    </div><!--mb_2_right over-->
</div>
<div id="footer1"><span>&copy;2012 R&D</span> 京ICP备09103038号-8 </div>
</body>
</html>
