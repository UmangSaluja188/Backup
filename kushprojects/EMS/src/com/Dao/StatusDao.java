package com.Dao;

import java.util.List;

import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.hibernate.cfg.Configuration;

import com.to.AddUser;

public class StatusDao {
	public void addStatus(int complianceId,int DepartmentId)
	{
		SessionFactory factory = new Configuration().configure("addCompliance.cfg.xml").buildSessionFactory();
		Session session = factory.openSession();
		Transaction transaction=session.beginTransaction();
		Query query = session.createQuery("select AddUser.userId,AddUser.deptId,Compliance.complianceId from AddUser,Compliance where "
				+ "Compliance.complianceId=:compId and AddUser.deptId=:deptId");
		query.setParameter("compId",complianceId);
		query.setParameter("deptId",DepartmentId);
		List<AddUser> userlist = query.getResultList();
	    transaction.commit();
        session.close();
        System.out.println(userlist);
	}
}
