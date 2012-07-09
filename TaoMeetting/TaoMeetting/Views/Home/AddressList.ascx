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

                    if (ViewData["address"] != null)
                    {
                        List<Address> adlist = ViewData["address"] as List<Address>;
                        if (adlist != null)
                        {
                            int rowcount = (adlist.Count + 1) % 6 == 0 ? (adlist.Count + 1) / 6 : (adlist.Count + 1) / 6 + 1;
                            int lesscount = (adlist.Count + 1) % 6;
                            int colspancount = 0;
                            int totalcount = adlist.Count;
                            int currentCount = 0;
                            bool first = true;
                            if (lesscount != 0)
                            {
                                colspancount = 6 - lesscount;
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
                                       <td <%if(currentCount==totalcount-1){%> colspan="<%=colspancount%>" <%} %>><a style="margin-left:30px" href="#" onclick="SetBgForSingleObj(this,'addressobj')" class="addressobj" rel="<%=adlist[currentCount].ZipCode%>"><%=adlist[currentCount].Name%></a></td>
                                    <%
                                                currentCount++;
                                                if (currentCount == totalcount)
                                                    break;
                                            }
                                            else
                                            {
                                                 %> 
                                       <td <%if(currentCount==totalcount-1){%> colspan="<%=colspancount%>" <%} %>><a style="margin-left:30px" href="#" onclick="SetBgForSingleObj(this,'addressobj')" class="addressobj" rel="0">不限</a></td>
                                    <% 
                                            }
                                        }
                                        else
                                        {
                                          
                                                   %> 
                                       <td <%if(currentCount==totalcount-1){%> colspan="<%=colspancount%>" <%} %>><a  href="#" onclick="SetBgForSingleObj(this,'addressobj')" class="addressobj" rel="<%=adlist[currentCount].ZipCode%>"><%=adlist[currentCount].Name%></a></td>
                                    <%
                                            currentCount++;
                                            if (currentCount == totalcount)
                                                break;
                                        }

                                    }
                                  
                                }
                                else
                                {
                                   for (int k = 0; k < 6; k++)
                                   {
                                       if (first)
                                       {
                                           first = false;
                                           %>
                                            <td><a style="margin-left:30px" href="#" onclick="SetBgForSingleObj(this,'addressobj')" class="addressobj" rel="0">不限</a></td>
                                           <%
                                       }
                                       else
                                       {
                                          
                                           %>
                                            <td><a  href="#" onclick="SetBgForSingleObj(this,'addressobj')" class="addressobj" rel="<%=adlist[currentCount].ZipCode%>"><%=adlist[currentCount].Name%></a></td>
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
                       <tr><td><span>无地址筛选条件</span></td></tr> 
                        <%
                    }
                     %>
                    </table>