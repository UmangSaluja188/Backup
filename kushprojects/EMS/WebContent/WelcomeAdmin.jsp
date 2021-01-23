<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>Insert title here</title>
</head>
<body>
	<%String username = (String)session.getAttribute("username");%>
	<h1>Welcome <% out.print(username); %></h1>
	
	
	<% out.print("<table border='1'width='100%'");
	   out.print("<td><a href='LogoutServlet'>Logout</a></td>");
	   out.print("<td><a href='addUser.jsp'>Create User</a></td>");
	   out.print("<td><a href='addDept.html'>Add Department</a></td>");
	   out.print("<td><a href='addCompliance.jsp'>Add Compliance</a></td>");
	   out.print("<td><a href='viewUser.jsp'>View User</a></td>");
	   out.print("<td><a href='viewDepartment.jsp'>View Department</a></td>");
	   out.print("<td><a href='ViewCompliance.jsp'>View Compliance</a></td></tr>");
	   out.print("</table>");
	%>
	
</body>
</html>