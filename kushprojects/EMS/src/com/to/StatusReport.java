package com.to;

import java.util.Date;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity

@Table
public class StatusReport {

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	int statusId;
	int complianceId;
	int empId;
	String comments;
	Date crDate;
	int departmentId;
	
	public StatusReport()
	{
		
	}

	public int getStatusId() {
		return statusId;
	}

	public void setStatusId(int statusId) {
		this.statusId = statusId;
	}

	public int getComplianceId() {
		return complianceId;
	}

	public void setComplianceId(int complianceId) {
		this.complianceId = complianceId;
	}

	public int getEmpId() {
		return empId;
	}

	public void setEmpId(int empId) {
		this.empId = empId;
	}

	public String getComments() {
		return comments;
	}

	public void setComments(String comments) {
		this.comments = comments;
	}

	public Date getCrDate() {
		return crDate;
	}

	public void setCrDate(Date crDate) {
		this.crDate = crDate;
	}

	public int getDepartmentId() {
		return departmentId;
	}

	public void setDepartmentId(int departmentId) {
		this.departmentId = departmentId;
	}

	public StatusReport(int complianceId, int empId, String comments, Date crDate, int departmentId) {
		//super();
		this.complianceId = complianceId;
		this.empId = empId;
		this.comments = comments;
		this.crDate = crDate;
		this.departmentId = departmentId;
	}
}
