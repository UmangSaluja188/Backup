package com.Dao;

import java.util.List;

import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.hibernate.cfg.Configuration;

import com.to.AddUser;
import com.to.Department;

public class DepartmentDao {
	
	SessionFactory factory = new Configuration().configure("deptHibernate.cfg.xml").buildSessionFactory();
	Session session = factory.openSession();
	Transaction transaction=session.beginTransaction();
	public boolean addDept(String name)
	{
		boolean flag = true;
		try {
		Department dept = new Department();
		dept.setDeptName(name);
		session.save(dept);
		transaction.commit();
		session.close();
		}catch(Exception e)
		{
			System.out.println("not added");
			flag=false;
		}
		return flag;
	}
	
	public Department getDept(int deptId)
	{
		try {
			Query query = session.createQuery("from Department where deptId=:deptId");
			query.setParameter("deptId", deptId);
			List<Department> deptlist = query.list();
			return deptlist.get(0);			
		}catch(Exception e)
		{
			return null;
		}
	}
	
	public List<Department> viewDept()
	{
		Query query = session.createQuery("from Department where not deptId="+0);
		List<Department> deptlist = query.getResultList();
	    transaction.commit();
        session.close();
        return deptlist;
	}
	
	public boolean updateDept(int deptId,String name)
	{
		boolean flag = true;
		try {
		Department dept = session.get(Department.class,deptId);
		dept.setDeptName(name);
		transaction.commit();
		session.close();
	    }catch(Exception e)
		{
			flag = false;
		}
	
		return flag;
	}
	
	public boolean deleteDept(int deptId)
	{
		boolean flag = true;
		try {
		Department dept = session.get(Department.class,deptId);
		session.delete(dept);
		transaction.commit();
		session.close();
		}catch(Exception e)
		{
			flag = false;
		}
		
		return flag;
	}
}
