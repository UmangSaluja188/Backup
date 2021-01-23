package com.servlet;

import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import com.Dao.ViewUser;

/**
 * Servlet implementation class DeleteUser
 */
public class DeleteUser extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public DeleteUser() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method0 stub
		//response.getWriter().appen9d("Served at: ").append(request.getContextPath());
		HttpSession session = request.getSession();
		if(session.getAttribute("isUserLoggedIn") != null)
		{
			ViewUser user = new ViewUser();
			boolean check = user.deleteUser(Integer.parseInt(request.getParameter("id")));
			RequestDispatcher rd = request.getRequestDispatcher("viewUser.jsp");
			PrintWriter out= response.getWriter();
			if(check==true)
			{
				out.print("user Deleteed");
			}
			else
			{
				out.print("user not deleted");
			}
			rd.include(request, response);
	    }	
		else
		{
			RequestDispatcher rd = request.getRequestDispatcher("login.html");
			PrintWriter out = response.getWriter();
			out.print("login Here");
			rd.include(request, response);
		}
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		//doGet(request, response);
	}

}
