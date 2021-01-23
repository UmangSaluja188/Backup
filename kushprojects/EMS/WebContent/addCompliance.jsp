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
out.print("<a href='LogoutServlet'>Logout</a>");
out.println("<a href='WelcomeAdmin.jsp'>Home</a>");
	<form action="ComplianceServlet" method="post">
		RL Type    : <input type="text" name="rltype"><br>
		RL Details : <input type="text" name="rldetails"><br>
		
		Department : <select name="dept">
						<%
						try{
							String query = "select * from department";
							Class.forName("com.mysql.jdbc.Driver").newInstance();
							Connection conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/emsdata","root","root");
							Statement stmt =conn.createStatement();
							ResultSet rs = stmt.executeQuery(query);
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
		<br><input type="submit" value="Add">				
						
	</form>
</body>
</html>