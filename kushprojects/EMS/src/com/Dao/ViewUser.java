package com.Dao;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.hibernate.cfg.Configuration;

import com.to.AddUser;
import com.to.Department;


public class ViewUser {

	SessionFactory factory = new Configuration().configure("addUser.cfg.xml").buildSessionFactory();
	Session session = factory.openSession();
	Transaction transaction=session.beginTransaction();
	
	public boolean saveUser(String fname, String lname, Date dob, String email, int deptId) {
		// TODO Auto-generated method stub
		boolean flag = true;
		try {
		AddUser user = new AddUser(fname,lname,dob,email,deptId);
		session.save(user);
		transaction.commit();
		session.close();
		}
		catch(Exception e)
		{
			flag = false;
		}
		return flag;
	}
	
	public List<AddUser> getUsers()
	{
		 
			Query query = session.createQuery("from AddUser");
			List<AddUser> userlist = query.getResultList();
		    transaction.commit();
            session.close();
            return userlist;
	}
	
	public boolean updateUser(int userId,String fname, String lname, Date date, String email, int deptId) {
		boolean flag=true;
		try {
		AddUser user = session.get(AddUser.class, userId);
		user.setFirstName(fname);
		user.setLastName(lname);
		user.setEmail(email);
		user.setDOB(date);
		user.setDeptId(deptId);
		transaction.commit();
		session.close();	
		}
		catch(Exception e)
		{
			flag = false;
		}
		return flag;
	}

	public boolean deleteUser(int userId) {
		// TODO Auto-generated method stub
		boolean flag=true;
		try {
		AddUser user = session.get(AddUser.class, userId);
		session.delete(user);
		transaction.commit();
		session.close();
		}
		catch(Exception e)
		{
			flag = false;
		}
		return flag;
	}
}
