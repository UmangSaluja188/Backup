package com.servlet;

import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import com.Dao.DepartmentDao;

/**
 * Servlet implementation class EditDeptServlet
 */
public class EditDeptServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public EditDeptServlet() {
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
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		//doGet(request, response);
		HttpSession session = request.getSession();
		if(session.getAttribute("isUserLoggedIn") != null)
		{
			int deptId = Integer.parseInt(request.getParameter("deptId"));
			String name = request.getParameter("name");
			DepartmentDao dao = new DepartmentDao();
			boolean check = dao.updateDept(deptId, name);
			RequestDispatcher rd = request.getRequestDispatcher("viewDepartment.jsp");
			PrintWriter out = response.getWriter();
			if(check==true)
			{
				out.print("department updated");
			}
			else
			{
				out.print("not update");
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
