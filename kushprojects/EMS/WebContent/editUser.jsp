<%@page import="java.text.SimpleDateFormat"%>
<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
     <%@page import="java.util.Collections" %>
     <%@page import="java.util.List" %>
     <%@page import="java.util.ArrayList" %>
     <%@page import="java.sql.*" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>Insert title here</title>
</head>
<body>
<%
Class.forName("com.mysql.jdbc.Driver").newInstance();
Connection conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/emsdata","root","root");
Statement stmt =conn.createStatement();
ResultSet rs = null;
%>
	<form action="EditUserServlet" method="post">
	<%
	out.print("<a href='LogoutServlet'>Logout</a>");
	out.println("<a href='WelcomeAdmin.jsp'>Home</a>");
	try{
		String query = "select * from adduser where userId = "+request.getParameter("id");
		rs = stmt.executeQuery(query);
		System.out.println("rs = " + rs.next());
	}catch(Exception e)
	{
		System.out.println("in catch");
	}
	%>
		UserId		  : <input type="text" name="userId" value="<%=rs.getString("userId")%>" readonly="readonly">
		FirstName     : <input type="text" name="fname" value="<%=rs.getString("FirstName")%>"><br>
		LastName      : <input type="text" name="lname" value="<%=rs.getString("LastName")%>"><br>
		DOB           :
						<% 
						Date date = rs.getDate("DOB");
						SimpleDateFormat dd = new SimpleDateFormat("dd");
						SimpleDateFormat mm = new SimpleDateFormat("MM");
						SimpleDateFormat yy = new SimpleDateFormat("yyyy");
						List<Integer> list = new ArrayList<Integer>();%>
						<select name = "dd" style="width: 40px">
						<option><%=dd.format(date)%></option>
							<% for(int i=1;i<=31;i++) 
							{
									list.add(i);%>
							<option>
							 <%=list.get(i-1)%>
							</option>
							<%
							}
							%>
						</select>	
						<select name="mm">
						<option><%=mm.format(date)%></option>
							<option>01</option><option>02</option><option>03</option><option>04</option><option>05</option>
							<option>06</option><option>07</option><option>08</option><option>09</option><option>10</option>
							<option>11</option><option>12</option>
						</select>
						
						<input type="text" name="yy" value="<%=yy.format(date)%>"><br>
						
		e-Mail        :<input type="text" name="email" value="<%=rs.getString("email")%>"><br>
		Department :
						<select name="dept">
						<%
						try{
							String query = "select * from department";
							rs = stmt.executeQuery(query);
							while(rs.next())
							{
								%>
								<option value="<%=rs.getInt("deptId")%>"><%=rs.getString("deptName") %>
								</option>
								<% 
							}
						}catch(SQLException e)
						{
							out.print(e);
						}
						%>
						</select>
		
		<input type="submit" value="Update">
		</form>
</body>
</html>