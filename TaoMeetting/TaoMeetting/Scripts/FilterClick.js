var isie = navigator.userAgent.indexOf("MSIE") > 0 ? true : false;
function showDiv(obj) {
  // debugger;
    SetUlVisble(obj, "tanchu");
    SetUlVisble(obj, "yc");
}
function SetUlVisble(obj, name) {
    var objs = $("."+name);
    for (var i = 0; i < objs.length; i++) {
        if (objs[i].id == name + obj)
            continue;
        objs[i].style.display = "none";
    }
    $("#"+name+ obj)[0].style.display = $("#"+name+ obj)[0].style.display == "block" ? "none" : "block";
 }
 function SetBgForSingleObj(obj, classname) {
     //  var v = obj.rel;
    //debugger;
     var objs = $("." + classname);
     for (var i = 0; i < objs.length; i++) {
         objs[i].style.backgroundColor = "";
         objs[i].style.color = "#37759e";
     }
     obj.style.backgroundColor = "#37759e";
     obj.style.color = "white";
     SendData();
 }

 function SetBgForMultiObj(obj, classname) {
     //debugger;
     var objs = $("." + classname);

     if (obj.rel == 0) {
         for (var i = 0; i < objs.length; i++) {
             if (objs[i] == obj)
                 continue;
             objs[i].style.backgroundColor = "";
             objs[i].style.color = "#37759e";
         }
     }
     else {
         $("." + classname + "[rel=0]")[0].style.backgroundColor = "";
         $("." + classname + "[rel=0]")[0].style.color = "#37759e";
     }
     obj.style.backgroundColor = obj.style.backgroundColor == "rgb(55, 117, 158)" ? "" : "#37759e";
     obj.style.color = obj.style.color == "white" ? "#37759e" : "white";
     SendData();
 }
 function ClearAllFilter() {
     var objs = $(".addressobj");
     ClearAll(objs);
     objs = $(".basefunobj");
     ClearAll(objs);
     objs = $(".specfunobj");
     ClearAll(objs);
     objs = $(".buytype");
     ClearAll(objs);
     objs = $(".pricerang");
     ClearAll(objs);
     SendData();
 }
 function  ClearAll(objs)
 {
     for (var i = 0; i < objs.length; i++) {
             objs[i].style.backgroundColor = "";
             objs[i].style.color = "#37759e";
         }
 }
function SetBgForProductObj(obj, classname, init) {
    //debugger;
    var objs = $("." + classname);
    for (var i = 0; i < objs.length; i++) {
        if (isie) {
            //objs[i].style.filter = 'progid:DXImageTransform.Microsoft.BasicImage(grayscale=1)';
            objs[i].style.filter = 'alpha(opacity=60)';
        }
        else {
            objs[i].style.opacity = 0.6;
        }
    }
    if (isie) {
        obj.style.filter = '';
    }
    else {
        obj.style.opacity = '';
    }
    if (!init) {
        SendData();
    }
}
function MakeStar(fullcount, halfcount) {
    var htmls = "";
    for (var i = 0; i < fullcount; i++) {
        htmls += '<img src="../../images/fullstar.jpg"/>';
    }
    if (halfcount > 0) {
        htmls += '<img src="../../images/halfstar.jpg"/>';
    }
    if (halfcount + fullcount < 5) {
        for (var i = 0; i < 5 - fullcount - halfcount; i++) {
            htmls += '<img src="../../images/nullstar.jpg"/>';
        }
    }
    return htmls;
}
function OutPutData(data) {
    var preenable = true, nextenable = true, haspager = false, noData = false, currentPage = "", totalPage = "", totalCount = "";
    var obj = eval(data);
    var htmlstr = "";
    if (obj == undefined || obj == null || obj == "" || obj == "[]") {
        htmlstr = '<div style="margin-top:10px; margin-left:20px; font-family:arial,宋体,sans-serif; font-size:14px; margin-bottom:15px;" align="center"><b>没有符合条件的数据</b></div>';
        noData = true;
    }
    else {
        $.each(obj, function (index, objval) {
            haspager = false;
            if ((objval.PrevEnable != null && objval.PrevEnable != undefined && objval.PrevEnable != "")
              || (objval.NextEnable != null && objval.NextEnable != undefined && objval.NextEnable != "")) {
                if (objval.PrevEnable == 1) {
                    preenable = true;
                }
                else {
                    preenable = false;
                }
                if (objval.NextEnable == 1) {
                    nextenable = true;
                }
                else {
                    nextenable = false;
                }
                currentPage = objval.CurrentPage;
                totalPage = objval.TotalPage;
                totalCount = objval.TotalCount;
                haspager = true;
            }
            if (!haspager) {
                htmlstr += '<ul class="pinpai">';
                htmlstr += '<li class="pic12"><img src="' + objval.BrandPic + '"/></li>';
                htmlstr += '<li class="word2">' + objval.BrandName;
                htmlstr += '</li>';
                htmlstr += '<li class="word4">' + objval.Address + '</li>';
                htmlstr += '<li class="word3">';
                var addspan = false;
                if (objval.Buytypes == undefined ||
                        objval.Buytypes == null ||
                        objval.Buytypes == ""
                         || objval.Buytypes == "[]") {
                    htmlstr += '<span>暂无购买方式</span>';
                }
                else {
                    htmlstr += "<table align='center'>";
                    for (var i = 0; i < objval.Buytypes.length; i++) {
                        htmlstr += "<tr><td>";
                        if (addspan) {
                            htmlstr += "<span>";
                        }
                        htmlstr += objval.Buytypes[i].BuyName + ":" + objval.Buytypes[i].Price;
                        htmlstr += "元/点/月<br>";
                        if (addspan) {
                            htmlstr += "</span>";
                            addspan = false;
                        }
                        else {
                            addspan = true;
                        }
                        htmlstr += "</tr></td>";
                    }
                    htmlstr += "</table>";
                }
                htmlstr += '</li>';

                htmlstr += '<li class="word5">'
                               + '<img src="../../images/13.jpg" onclick="showDiv(' + objval.id + ')" /></li>';
                htmlstr += '</ul>';
                htmlstr += '<ul class="tanchu" id="tanchu' + objval.id + '" style="display:none;"><img src="../../images/14.jpg"/>';
                htmlstr += '<li class="xin"><a style="margin-left:39px;">产品用途</a><a>基本功能</a><a>特色功能</a><a>联系方式</a></li></ul>';
                htmlstr += '<ul class="yc" id="yc' + objval.id + '" style="display:none;">';
                htmlstr += '<li class="pic15">';
                if (objval.Products != null)
                    for (var i = 0; i < objval.Products.length; i++) {
                        htmlstr += objval.Products[i].ProName;
                        if (i != objval.Products.length - 1) {
                            htmlstr += "<br>";
                        }
                    }
              //  debugger;
                htmlstr += '</li>';
                var bfullstarcount = Math.floor(objval.BaseFunScore);
                var sfullstarcount = Math.floor(objval.SpecialFunScore);
                if (objval.BaseFunScore > bfullstarcount) {
                    bhalfstarcount = 1;
                }
                else {
                    bhalfstarcount = 0;
                }

                if (objval.SpecialFunScore > sfullstarcount) {
                    shalfstarcount = 1;
                }
                else {
                    shalfstarcount = 0;
                }
                htmlstr += '<li class="pic16">';
                htmlstr += MakeStar(bfullstarcount, bhalfstarcount);
                htmlstr += '</li>';
                htmlstr += '<li class="pic16 pic17">';
                htmlstr += MakeStar(sfullstarcount, shalfstarcount);
                htmlstr += '</li>';
                htmlstr += '<li class="word8">' + objval.Phone + '</li>';
                htmlstr += '<li class="word9"><a href="' + objval.Url + '" target="_blank">进入官网</a></li>';
                // htmlstr += '</li>';
                htmlstr += '</ul>';
            }
        });
    }
    $(".innerDiv").html("");
    if (!noData) {
        htmlstr += "<div align='center' style='margin-top:20px; margin-bottom:60px;'><div align='center' style='margin-left:10px; float:left;'>第<span style='color:red;'>" + currentPage + "</span>页<span style='margin-left:10px;'>共" + totalPage + "页</span><span style='margin-left:10px;'>共" + totalCount + "条</span></div>"; //<table style='margin-right:10px;'><tr align='center'><td>
        //        if (preenable) {
        //            htmlstr += '<span onclick="Pager(\'prev\')" style="color:#37759E;cursor:pointer;">上一页</span>';
        //        }
        //        else {
        //            htmlstr += "<span style='color:gray'>上一页</span>";
        //        }
        //        htmlstr += "</td><td>";
        //        if (nextenable) {
        //            htmlstr += '<span style="color:#37759E;cursor:pointer;" onclick="Pager(\'next\')">下一页</span>';
        //        }
        //        else {
        //            htmlstr += '<span style="color:gray">下一页</span>';
        //        }
        htmlstr += "<div id='pager' style='position:absolute;";
        if (isie) {
            htmlstr+="right:410px;"
        }
        else {
            htmlstr += "right:445px;";
        }
        htmlstr+="'>";
        for (var i = 1; i <= totalPage; i++) {
            htmlstr += "<a class='pagera' style='text-align:center;";
            if (i == currentPage) {
                htmlstr += "background-color:#37759e;color:White;"
            }
            htmlstr += "' onclick='Pager(" + i + ")'>" + i + "</a>";
        }
        htmlstr += "</div>";
        htmlstr += "</div>"; //</tr></table>
    }
    $(".innerDiv").html(htmlstr);
}
function Pager(action) {
 //  debugger;
//    var objs = $(".pagera");
//    for (var i = 0; i < objs.length; i++) {
//        objs[i].style.backgroundColor = "";
//        objs[i].style.color = "#37759e";
//    }
//    obj.style.backgroundColor = "#37759e";
//    obj.style.color = "white";

    $.ajax({
        type: 'post',
        url: '/Home/Pager/',
        datatype: 'json',
        data: 'pageIndex=' + action + '&rnd=' + Math.random(),
        success: function (data, type) {
            //debugger;
            OutPutData(data);
        }
    });
}
var lastproid = "", lastpriceid = "", lastbasefunid = "", lastspecfunid = "", lastaddressid = "",lastbuytypeid="";
function SendData() {
    //debugger;
    var proid = "", priceid = "",buytypeid="", basefunid = "", specfunid = "", addressid = "";
    var haschange = false;
    $.each($('.productobj'), function (i, v){
        //debugger;
          if(isie)
         {
           if (v.style.filter == "") {
            proid = v.id;
             }
        }
        else
        {
             if (v.style.opacity == "")
             {
                 proid = v.id;
             }
        }
    });
    if (proid != lastproid) {
        lastproid = proid;
        haschange = true;
    }
    // proid = proid.substring(0, proid.length - 1);
    $.each($('.pricerang'), function (i, v) {
        //debugger;
        if (v.style.backgroundColor != "") {
            priceid = v.rel;
        }
    });
    if (priceid != lastpriceid) {
        lastpriceid = priceid;
        haschange = true;
    }
     $.each($('.buytype'), function (i, v) {
        //debugger;
        if (v.style.backgroundColor != "") {
            buytypeid=v.rel;
        }
    });
   // debugger;
    if (buytypeid != lastbuytypeid) {
        lastbuytypeid = buytypeid;
        haschange = true;
    }
   // buytypeid = buytypeid.substring(0, buytypeid.length - 1);
    // priceid = priceid.substring(0, priceid.length - 1);
    $.each($('.basefunobj'), function (i, v) {
        if (v.style.backgroundColor != "") {
            basefunid = v.rel;
        }
    });

    //basefunid = basefunid.substring(0, basefunid.length - 1);
    $.each($('.specfunobj'), function (i, v) {
        if (v.style.backgroundColor != "") {
            specfunid = v.rel;
        }
    });
    if (basefunid != lastbasefunid) {
        lastbasefunid = basefunid;
        haschange = true;
    }
    if (specfunid != lastspecfunid) {
        lastspecfunid = specfunid;
        haschange = true;
    }
    //specfunid = specfunid.substring(0, specfunid.length - 1);
  // basefunid = basefunid.substring(0, basefunid.length - 1);
    //basefunid = basefunid.split(',');
    $.each($('.addressobj'), function (i, v) {
        //debugger;
        if (v.style.backgroundColor != "") {
            addressid = v.rel;
        }
    });
    if (addressid != lastaddressid) {
        lastaddressid = addressid;
        haschange = true;
    }
    if (priceid == "") {
        priceid = 0;
    }
    if (buytypeid == "") {
        buytypeid = 0;
    }
    if (basefunid == "") {
        basefunid = 0;
    }
    if (specfunid == "") {
        specfunid = 0;
    }
    //addressid = addressid.substring(0, addressid.length - 1);
    //alert("proid=" + proid + ",priceid=" + priceid + ",basefunid=" + basefunid + ",specfunid=" + specfunid + ",addressid=" + addressid);
    //debugger;
    if (haschange) {
        //debugger;
        $.ajax({
            type: 'post',
            url: '/Home/GetSearchData/',
            datatype: 'json',
            data: 'productid=' + proid + '&pricerangeid=' + priceid + '&buytypeid=' + buytypeid + '&basefun=' + basefunid + "&specfunid=" + specfunid + '&address=' + addressid + '&rnd=' + Math.random(),

            success: function (data, type) {
                //debugger;
                OutPutData(data);
            }
        });
    }
    //    $.getJSON('/Post/GetSearchData', { productid: proid, pricerangeid: priceid, basefun: basefunid, address: addressid },
    //    function (revData) {
    //        debugger;
    //        alert(revData);
    //    });
    // var addresses = $('.addressobj');
}