package com.servlet;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.Date;
import java.text.SimpleDateFormat;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import com.Dao.LoginDao;
import com.Dao.ViewUser;
import com.sun.org.apache.xerces.internal.impl.xpath.regex.ParseException;


/**
 * Servlet implementation class UserServlet
 */
public class UserServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public UserServlet() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		//response.getWriter().append("Served at: ").append(request.getContextPath());
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException ,ParseException {
		// TODO Auto-generated method stub
		HttpSession session = request.getSession();
		if(session.getAttribute("isUserLoggedIn") != null)
		{
			String fname = request.getParameter("fname");
			String lname = request.getParameter("lname");
			String email = request.getParameter("email");
			int deptId = Integer.parseInt(request.getParameter("dept"));
			String dd = request.getParameter("dd");
			String mm = request.getParameter("mm");
			String yy = request.getParameter("yy");
			
			Date date=null;
			String date_s = dd + "-" + mm + "-" + yy;
			SimpleDateFormat dt = new SimpleDateFormat("dd-MM-yyyy");
			try {
				date = dt.parse(date_s);
			} catch (java.text.ParseException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			
			ViewUser userDao = new ViewUser();
			boolean check = userDao.saveUser(fname,lname,date,email,deptId);
			
			RequestDispatcher rd = request.getRequestDispatcher("addUser.jsp");
			PrintWriter out = response.getWriter();
			if(check == true)
			{
				LoginDao loginDao = new LoginDao();
				loginDao.generateUserPass(fname,lname,email,dd,mm);
				out.print("User added");
			}
			else
			{
				out.print("User not addded");
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

}
