package com.Dao;

import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.hibernate.cfg.Configuration;

import java.util.List;

import org.hibernate.Query;
import com.to.Login;


public class LoginDao {

	SessionFactory factory = new Configuration().configure("loginHibernate.cfg.xml").buildSessionFactory();
	Session session = factory.openSession();
	Transaction transaction=session.beginTransaction();
	public boolean getDetails(String user, String pass, String role) {
		// TODO Auto-generated method stub\
		
		boolean flag = true;
		Query query = session.createQuery("from Login where username=:username and password=:password and role=:role");
		query.setParameter("username", user);
		query.setParameter("password", pass);
		query.setParameter("role", role);
		List<Login> loginlist = query.list();
		
		if(loginlist.size()!=1)
			flag=false;
		
		transaction.commit();
        session.close();
        return flag;
	}
	
	public void generateUserPass(String fname, String lname, String email, String dd, String mm)
	{
		String password = fname.substring(0,2) + mm + dd + lname.substring(lname.length()-2); 
		Login login = new Login(email,password,"User");
		session.save(login);
		transaction.commit();
		session.close();
	}
}
