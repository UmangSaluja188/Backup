<%@page import="com.Dao.DepartmentDao"%>
<%@page import="com.to.Department" %>
<%@page import="java.util.List" %>
<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>Insert title here</title>
</head>
<body>
	<h2>Department List</h2>
	<%
	session = request.getSession();
	if(session.getAttribute("isUserLoggedIn") != null)
	{
		out.print("<a href='LogoutServlet'>Logout</a>");
		out.println("<a href='WelcomeAdmin.jsp'>Home</a>");
			DepartmentDao dao = new DepartmentDao();
			List<Department> list = dao.viewDept();
			out.print("<a href='LogoutServlet'>Logout</a>");
			out.print("<table border='1'width='100%'");
			for(Department e:list)
			{
				out.print("<tr><td>" + e.getDeptId()+ "</td><td>" + e.getDeptName()+ "</td><td> <a href='editDept.jsp?id=" 
						+ e.getDeptId()+"'>edit</a></td><td><a href='DeleteDept?id="+e.getDeptId()+"'>Delete</a></td>");
			}
			out.print("</table>");
	}
	%>
</body>
</html>