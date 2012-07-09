<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="TaoMeetting.Domain" %>
<table>
                <%
                    //string strtag=string.Empty;
                    //if (ViewData["tag"] != null)
                    //{
                    //    switch (ViewData["tag"].ToString())
                    //    {
                    //        case "address":
                    //            strtag=
                    //        default:
                    //    }
                    //}
                    int totalNum = 4;
                    if (ViewData["pricerange"] != null)
                    {
                        List<PriceRange> datalist = ViewData["pricerange"] as List<PriceRange>;
                        if (datalist != null)
                        {
                            int rowcount = (datalist.Count + 1) % totalNum == 0 ? (datalist.Count + 1) / totalNum : (datalist.Count + 1) / totalNum + 1;
                            int lesscount = (datalist.Count + 1) % totalNum;
                            int colspancount = 0;
                            int totalcount = datalist.Count;
                            int currentCount = 0;
                            bool first = true;
                            if (lesscount != 0)
                            {
                                colspancount = totalNum - lesscount;
                            }
                            for (int i = 0; i < rowcount; i++)
                            {
                                 %>
                                    <tr>
                                   <%
                                first = true;
                                if (i == rowcount - 1)
                                {
                                    for (int j = 0; j < lesscount; j++)
                                    {
                                       
                                        if (first)
                                        {
                                            first = false;
                                            if (rowcount > 1)
                                            {
                                             
                                              %> 
                                       <td <%if(currentCount==totalcount-1){%> colspan="<%=colspancount%>" <%} %>>
                                         <a style="margin-left:30px" href="#"  onclick="SetBgForSingleObj(this,'pricerang')" class="pricerang" rel="<%=datalist[currentCount].id%>">
                                         <%=datalist[currentCount].lowprice%>-<%=datalist[currentCount].highprice%>元/点/月</a>  
                                       </td>
                                    <%
                                                currentCount++;
                                                if (currentCount == totalcount)
                                                    break;
                                            }
                                            else
                                            {
                                                 %> 
                                       <td <%if(currentCount==totalcount-1){%> colspan="<%=colspancount%>" <%} %>><a style="margin-left:30px" href="#"  class="pricerang" onclick="SetBgForSingleObj(this,'pricerang')" rel="0">不限</a></td>
                                    <% 
                                            }
                                        }
                                        else
                                        {
                                          
                                                   %> 
                                       <td <%if(currentCount==totalcount-1){%> colspan="<%=colspancount%>" <%} %>><a  href="#"  class="pricerang" onclick="SetBgForSingleObj(this,'pricerang')" rel="<%=datalist[currentCount].id%>">
                                         <%=datalist[currentCount].lowprice%>-<%=datalist[currentCount].highprice%>元/点/月</a></td>
                                    <%
                                            currentCount++;
                                            if (currentCount == totalcount)
                                                break;
                                        }

                                    }
                                  
                                }
                                else
                                {
                                    for (int k = 0; k < totalNum; k++)
                                   {
                                       if (first)
                                       {
                                           first = false;
                                           %>
                                            <td><a style="margin-left:30px" href="#"  class="pricerang" onclick="SetBgForSingleObj(this,'pricerang')" rel="0">不限</a></td>
                                           <%
                                       }
                                       else
                                       {
                                          
                                           %>
                                            <td><a  href="#"  class="pricerang" onclick="SetBgForSingleObj(this,'pricerang')" rel="<%=datalist[currentCount].id%>">
                                         <%=datalist[currentCount].lowprice%>-<%=datalist[currentCount].highprice%>元/点/月</a> </td>
                                           <%
                                           currentCount++;
                                           if (currentCount == totalcount)
                                               break;
                                       }
                                   }
                                }
                                  %>
                                     </tr>
                                     <%
                            }
                        }
                    }
                    else
                    {
                        %>
                       <tr><td><span>无价格筛选条件</span></td></tr> 
                        <%
                    }
                     %>
                    </table>