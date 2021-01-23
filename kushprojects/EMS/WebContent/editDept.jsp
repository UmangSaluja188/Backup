<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
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
<form action="EditDeptServlet" method="post">
<%
out.print("<a href='LogoutServlet'>Logout</a>");
out.println("<a href='WelcomeAdmin.jsp'>Home</a>");
	try{
		String query = "select * from Department where deptId = "+request.getParameter("id");
		rs = stmt.executeQuery(query);
		System.out.println("rs = " + rs.next());
	}catch(Exception e)
	{
		System.out.println("in catch");
	}
%>
		<input type="text" name="deptId" value="<%=rs.getString("deptId")%>" readonly="readonly">
		<input type="text" name="name" value="<%=rs.getString("deptName")%>">
		<input type="submit" value="update">
</form>
</body>
</html>