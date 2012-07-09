<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="TaoMeetting.Domain" %>
<table>
                <%
                    if (ViewData["basefuns"] != null)
                    {
                        string funobj = ViewData["funobj"].ToString();
                        List<FunctionType> datalist = ViewData["basefuns"] as List<FunctionType>;
                        if (datalist != null)
                        {
                            int rowcount = (datalist.Count + 1) % 6 == 0 ? (datalist.Count + 1) / 6 : (datalist.Count + 1) / 6 + 1;
                            int lesscount = (datalist.Count + 1) % 6;
                            int colspancount = 0;
                            int totalcount = datalist.Count;
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
                                       <td <%if(currentCount==totalcount-1){%> colspan="<%=colspancount%>" <%} %>><a style="margin-left:29px" href="#" onclick="SetBgForSingleObj(this,'<%=funobj%>')" class="<%=funobj%>" rel="<%=datalist[currentCount].id%>"><%=datalist[currentCount].FunName%></a></td>
                                    <%
                                                currentCount++;
                                                if (currentCount == totalcount)
                                                    break;
                                            }
                                            else
                                            {
                                                 %> 
                                       <td <%if(currentCount==totalcount-1){%> colspan="<%=colspancount%>" <%} %>><a style="margin-left:29px" href="#" onclick="SetBgForSingleObj(this,'<%=funobj%>')" class="<%=funobj%>" rel="0">不限</a></td>
                                    <% 
                                            }
                                        }
                                        else
                                        {
                                          
                                                   %> 
                                       <td <%if(currentCount==totalcount-1){%> colspan="<%=colspancount%>" <%} %>><a  href="#" onclick="SetBgForSingleObj(this,'<%=funobj%>')" class="<%=funobj%>" rel="<%=datalist[currentCount].id%>"><%=datalist[currentCount].FunName%></a></td>
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
                                            <td><a style="margin-left:29px" href="#" onclick="SetBgForSingleObj(this,'<%=funobj%>')" class="<%=funobj%>" rel="0">不限</a></td>
                                           <%
                                       }
                                       else
                                       {
                                          
                                           %>
                                            <td><a  href="#" onclick="SetBgForSingleObj(this,'<%=funobj%>')" class="<%=funobj%>" rel="<%=datalist[currentCount].id%>"><%=datalist[currentCount].FunName%></a></td>
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
                       <tr><td><span>无功能筛选条件</span></td></tr> 
                        <%
                    }
                     %>
                    </table>