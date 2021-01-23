<%@page import="java.text.SimpleDateFormat"%>
<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
    <%@page import="java.util.Date"%>
    <%@page import="com.Dao.ComplianceDao" %>
    <%@page import="java.util.List" %>
    <%@page import="com.to.Compliance" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>Insert title here</title>
</head>
<body>
	<h2>Compliances</h2>
	<%
	session = request.getSession();
	if(session.getAttribute("isUserLoggedIn") != null)
	{
		out.print("<a href='LogoutServlet'>Logout</a>");
		out.println("<a href='WelcomeAdmin.jsp'>Home</a>");
		SimpleDateFormat dt = new SimpleDateFormat("dd/MM/yyyy");
		ComplianceDao dao = new ComplianceDao();
		List<Compliance> list = dao.getCompliance();
		out.print("<table border='1'width='100%'");
		for(Compliance e:list)
		{
			out.print("<tr><td>" + e.getComplianceId() + "</td><td>" + e.getRLType() + "</td><td> " + e.getDetails() + "</td><td>" + dt.format(e.getCrdate()) + "</td><td>"+
						e.getDeptid()+ "</td>");
		}
		out.print("</table>");
	}
	%>
</body>
</html>