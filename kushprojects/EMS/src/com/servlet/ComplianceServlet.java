package com.servlet;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.Date;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import com.Dao.ComplianceDao;

/**
 * Servlet implementation class ComplianceServlet
 */
public class ComplianceServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public ComplianceServlet() {
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
		HttpSession session = request.getSession();
		if(session.getAttribute("isUserLoggedIn") != null)
		{
			String rlType = request.getParameter("rltype");
			String rlDetails = request.getParameter("rldetails");
			int deptId = Integer.parseInt(request.getParameter("dept"));
			String status = "pending";
			Date crDate=new Date();
			ComplianceDao dao = new ComplianceDao();
			boolean check = dao.saveCompliance(rlType,rlDetails,deptId,crDate,status);
			RequestDispatcher rd = request.getRequestDispatcher("addCompliance.jsp");
			PrintWriter out = response.getWriter();
			if(check == true)
			{
				out.print("compliance added");
			}
			else
			{
				out.print("compliance not addded");
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
