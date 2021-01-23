package com.servlet;

import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import com.Dao.LoginDao;

/**
 * Servlet implementation class login_servlet
 */
public class LoginServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public LoginServlet() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
//		response.getWriter().append("Served at: ").append(request.getContextPath());
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		if(request.getParameter("username")!="" && request.getParameter("password")!="")
		{
			String username = request.getParameter("username");
			String password = request.getParameter("password");
			String role = request.getParameter("role");
			RequestDispatcher rd = null;
			LoginDao dao = new LoginDao();
			boolean check = dao.getDetails(username,password,role);
			if(check == true)
			{
				HttpSession session = request.getSession();
				session.setAttribute("isUserLoggedIn", true);
				session.setAttribute("username", username);
				if(role.equals("Admin"))
				{
					rd = request.getRequestDispatcher("WelcomeAdmin.jsp");	
				}
				else
				{
					rd = request.getRequestDispatcher("WelcomeUser.jsp");
				}
				rd.forward(request, response);
			}
			else
			{
				rd = request.getRequestDispatcher("login.html");
				PrintWriter out = response.getWriter();
				out.print("Invalid User!!!");
				rd.include(request, response);
			}
		}
		else
		{
			PrintWriter out = response.getWriter();
			RequestDispatcher rd = request.getRequestDispatcher("login.html");
			if(request.getParameter("username")=="" && request.getParameter("password")=="")
			{
				out.println("Can not login with empty fields...");
			}
			else if(request.getParameter("password")=="")
			{
				out.println("password is empty");
			}
			else
			{
				out.println("username is empty");
			}
			rd.include(request, response);
		}
	}
}
