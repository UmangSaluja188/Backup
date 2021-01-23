<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"
    %>
 <%@page import="java.util.List"%>  
 <%@page import="java.sql.*" %>  
 <%@page import="java.lang.Class" %>
  <%@page import="java.util.ArrayList"%>   
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>Insert title here</title>
</head>
<body>
out.print("<a href='LogoutServlet'>Logout</a>");
out.println("<a href='WelcomeAdmin.jsp'>Home</a>");
	<form action="UserServlet" method="post">
		FirstName     : <input type="text" name="fname"><br>
		LastName      : <input type="text" name="lname"><br>
		DOB           :
						<% List<Integer> list = new ArrayList<Integer>();%>
						<select name = "dd" style="width: 40px">
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
							<option>01</option><option>02</option><option>03</option><option>04</option><option>05</option>
							<option>06</option><option>07</option><option>08</option><option>09</option><option>10</option>
							<option>11</option><option>12</option>
						</select>
						<input type="text" name="yy" value="year"><br>
		e-Mail        :<input type="text" name="email"><br>
		Department :
						<select name="dept">
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
		
		<input type="submit" value="submit">
		</form>
</body>
</html>