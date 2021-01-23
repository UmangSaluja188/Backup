package com.Dao;

import java.util.Date;
import java.util.List;

import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.hibernate.cfg.Configuration;

import com.to.Compliance;
import com.to.Department;

public class ComplianceDao {


	SessionFactory factory = new Configuration().configure("addCompliance.cfg.xml").buildSessionFactory();
	Session session = factory.openSession();
	Transaction transaction=session.beginTransaction();
	
	public boolean saveCompliance(String rlType, String rlDetails, int deptId, Date crDate,String status) {
		
		boolean flag = true;
		try {
		Compliance compliance = new Compliance(rlType,rlDetails,crDate,deptId,status);
		session.save(compliance);
		transaction.commit();
		session.close();
		}
		catch(Exception e)
		{
			flag = false;
		}
		return flag;
	}
	
	public List<Compliance> getCompliance()
	{
		Query query = session.createQuery("from Compliance");
		List<Compliance> complist = query.getResultList();
	    transaction.commit();
        session.close();
        return complist;
	}

}
