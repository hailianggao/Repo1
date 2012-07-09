<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<TaoMeetting.Domain.ProductType>>" %>
<%@ Import Namespace="TaoMeetting.Domain" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.4.4.min.js" type="text/javascript"></script>
    <link href="../../style/default.css" rel="stylesheet" type="text/css" />
    <link href="../../style/home.css" rel="stylesheet" type="text/css" />
    <link href="../../style/style.css" rel="stylesheet" type="text/css" />
    	<!--[if lte IE 7]>
    <link href="../../style/styles_ie.css" rel="stylesheet" type="text/css" />
    <![endif]--> 
    <script src="../../Scripts/jquery.easing.1.3.js" type="text/javascript"></script>
    <script src="../../Scripts/home.js" type="text/javascript"></script>
<title>淘会议首页</title>
<script type="text/javascript">
    var oldh = "", oldw = "";
    function changestyle(obj, tag) {
        //debugger;
        //var oldtop = "";
        if (tag == "over") {
            // oldtop = obj.offsetTop;
            oldh = obj.height;
            //oldw = obj.width;
            obj.height = oldh + 4;
           // obj.width = oldw + 4;
           // obj.offsetTop =(oldtop- 3)+"px";
        }
        else {
            obj.height = oldh;
           // obj.width = oldw;
           // obj.offsetTop = oldtop+"px";
        }
        //obj.style.border = "3px";
    }
//    $(document).ready(function () {
//        var isie = navigator.userAgent.indexOf("MSIE") > 0 ? true : false;
//        if (isie) {
//            $("#da").addClass("daiedclass");
//        }
//        else {
//            $("#da").addClass("daggdclass");
//        }
//    });
</script>
</head>

<body onload="load_animations()">
<!--header-->
<div id="header">
	<a href="#"><img src="../../images/01.jpg"  /></a>
</div>
<!--mb-->
<div id="mainbody">
	<div class="mb_top">
    	<div class="container_12">
			<div class="slider">
				<div id="header_images" style="height: 250px; opacity: 1; ">
									<img src="../../images/banner1.jpg" class="header_image" color="#054065" alt="" link="###" target="_self" style="opacity: 1; ">
									<img src="../../images/banner2.jpg" class="header_image" color="#17191e" alt="" link="" target="_self">
									<img src="../../images/banner3.jpg" class="header_image" color="#3f0731" alt="" link="" target="_self">
								</div>
				<div class="header_controls">
					<a href="#" id="header_controls_left" style="opacity: 1; ">前一个</a>
					<a href="#" id="header_controls_right" style="opacity: 1; ">下一个</a>
				</div>
				<div id="overlay_bg" style="height:250px; "></div>
			</div>
		</div>


    </div>
    <div class="mb_bt">
    	<h2 class="qing"><img src="../../images/03.jpg" />请选择您的用途:</h2>
        <div class="btn">
        <%
            bool first = true;
            foreach (ProductType item in Model)
            {
                if (first)
                {
                    first = false;
                    %>
                    <a class="one" href="/Home/MainPage/<%=item.id%>"><img src="<%=item.TypePic %>" onmouseover="changestyle(this,'over')" onmouseout="changestyle(this,'out')"/></a>
                    <%
                }else
                {
                    %>
                     <a href="/Home/MainPage/<%=item.id%>"><img src="<%=item.TypePic %>" onmouseover="changestyle(this,'over')" onmouseout="changestyle(this,'out')"/></a>
                    <%
                }
            }
             %>
        </div>
    </div>
</div>
<!--footer-->
<div id="footer"><span>&copy;2012 R&D</span> 京ICP备09103038号-8 </div>
<script type="text/javascript">
//    var x =2;
//    //debugger;
//    function changePic() {
//        // debugger;
//        if (document.all) {
//            document.getElementById("pic").filters.revealTrans.Transition = 23;
//            document.getElementById("pic").filters.revealTrans.apply();
//            document.getElementById("pic").filters.revealTrans.play();
//        }
//        document.getElementById("pic").src = "../../images/banner" + x + ".jpg";
//        document.getElementById("pic").style.cursor = "pointer";
//        //        if (x == 1) {
//        //            document.getElementById("pic").setAttribute("onclick", "");
//        //            document.getElementById("pic").style.cursor = "pointer";
//        //        }
//        //        else if (x == 2) {
//        //            document.getElementById("pic").setAttribute("onclick", "");
//        //            document.getElementById("pic").style.cursor = "pointer";
//        //        }

//        for (i = 1; i < 4; i++) {
//            document.getElementById("a" + [i]).style.background = "#ffffff";
//        }
//        document.getElementById("a" + [x]).style.background = "#ffaff0";
//        x++
//        if (x > 3) { x = 1 }
//    }
//    var d
//    d = setInterval(changePic, 5000)

//    //debugger;
//    for (i = 1; i < 4; i++) {
//        document.getElementById("a" + i).onmouseover = function () {
//            // alert("abc");
//            clearInterval(d)
//            x = this.innerHTML
//            changePic()
//        }
//        document.getElementById("a" + i).onmouseout = function () {
//            d = setInterval(changePic, 5000)
//        }
//    }
</script>
</body>
</html>


