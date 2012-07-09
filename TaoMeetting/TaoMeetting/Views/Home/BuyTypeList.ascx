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
                    int totalnum = 4;
                    if (ViewData["buytype"] != null)
                    {

                        List<BuyType> datalist = ViewData["buytype"] as List<BuyType>;
                        if (datalist != null)
                        {
                            int rowcount = (datalist.Count + 1) % totalnum == 0 ? (datalist.Count + 1) / totalnum : (datalist.Count + 1) / totalnum + 1;
                            int lesscount = (datalist.Count + 1) % totalnum;
                            int colspancount = 0;
                            int totalcount = datalist.Count;
                            int currentCount = 0;
                            bool first = true;
                            if (lesscount != 0)
                            {
                                colspancount = totalnum - lesscount;
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
                                         <a style="margin-left:28px" href="#"  onclick="SetBgForSingleObj(this,'buytype')" class="buytype" rel="<%=datalist[currentCount].id%>">
                                         <%=datalist[currentCount].BuyTypeName%></a>  
                                       </td>
                                    <%
                                                currentCount++;
                                                if (currentCount == totalcount)
                                                    break;
                                            }
                                            else
                                            {
                                                 %> 
                                       <td <%if(currentCount==totalcount-1){%> colspan="<%=colspancount%>" <%} %>><a style="margin-left:28px" href="#"  class="buytype" onclick="SetBgForSingleObj(this,'buytype')" rel="0">不限</a></td>
                                    <% 
                                            }
                                        }
                                        else
                                        {
                                          
                                                   %> 
                                       <td <%if(currentCount==totalcount-1){%> colspan="<%=colspancount%>" <%} %>><a  href="#"  class="buytype" onclick="SetBgForSingleObj(this,'buytype')" rel="<%=datalist[currentCount].id%>">
                                         <%=datalist[currentCount].BuyTypeName%></a></td>
                                    <%
                                            currentCount++;
                                            if (currentCount == totalcount)
                                                break;
                                        }

                                    }
                                  
                                }
                                else
                                {
                                    for (int k = 0; k < totalnum; k++)
                                   {
                                       if (first)
                                       {
                                           first = false;
                                           %>
                                            <td><a style="margin-left:28px" href="#"  class="buytype" onclick="SetBgForSingleObj(this,'buytype')" rel="0">不限</a></td>
                                           <%
                                       }
                                       else
                                       {
                                          
                                           %>
                                            <td><a  href="#"  class="buytype" onclick="SetBgForSingleObj(this,'buytype')" rel="<%=datalist[currentCount].id%>">
                                         <%=datalist[currentCount].BuyTypeName%></a> </td>
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
                       <tr><td><span>无购买方式筛选条件</span></td></tr> 
                        <%
                    }
                     %>
                    </table>