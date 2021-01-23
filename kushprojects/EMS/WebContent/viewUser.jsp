<%@page import="java.text.SimpleDateFormat"%>
<%@page import="java.io.PrintWriter"%>
<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
    <%@page import="com.to.AddUser"%>
     <%@page import="com.Dao.ViewUser"%>
     <%@page import="java.util.List"%>
     <%@page import="java.util.Collections" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>Insert title here</title>

</head>
<body>
<h2>User List</h2>`
	<%
	session = request.getSession();
	if(session.getAttribute("isUserLoggedIn") != null)
	{
		out.print("<a href='LogoutServlet'>Logout</a>");
		out.println("<a href='WelcomeAdmin.jsp'>Home</a>");
		SimpleDateFormat dt = new SimpleDateFormat("dd/MM/yyyy");
		ViewUser user = new ViewUser();
		List<AddUser> list = user.getUsers();
		out.print("<table border='1'width='100%'");
		for(AddUser e:list)
		{
			out.print("<tr><td>" + e.getUserId() + "</td><td>" + e.getFirstName() + " " + e.getLastName() + "</td><td>" + dt.format(e.getDOB()) + "</td><td>"+
						e.getEmail() + "</td><td>" + e.getDeptId() + "</td><td> <a href='editUser.jsp?id=" + e.getUserId()+"'>edit</a></td><td><a href='DeleteUser?id="+e.getUserId()+"'>Delete</a></td>");
		}
		out.print("</table>");
	}
	else
	{
		RequestDispatcher rd = request.getRequestDispatcher("login.html");
		rd.forward(request, response);
	}
	%>
	
	
</body>
</html>