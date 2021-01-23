package com.to;

import java.util.Date;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity

@Table
public class AddUser {
	
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	int userId;
	String FirstName;
	String LastName;
	Date DOB;
	String email;
	int deptId;
	
	public int getDeptId() {
		return deptId;
	}
	public void setDeptId(int deptId) {
			this.deptId = deptId;
	}
	public String getFirstName() {
		return FirstName;
	}
	public void setFirstName(String firstName) {
		FirstName = firstName;
	}
	public String getLastName() {
		return LastName;
	}
	public int getUserId() {
		return userId;
	}
	public void setUserId(int userId) {
		this.userId = userId;
	}
	public void setLastName(String lastName) {
		LastName = lastName;
	}
	public Date getDOB() {
		return DOB;
	}
	public void setDOB(Date dOB) {
		DOB = dOB;
	}
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	public AddUser(String firstName, String lastName, Date dOB, String email,int deptId) {
		//super();
		FirstName = firstName;
		LastName = lastName;
		DOB = dOB;
		this.email = email;
		this.deptId = deptId;
	}
	public AddUser() {
		// TODO Auto-generated constructor stub
	}
}
