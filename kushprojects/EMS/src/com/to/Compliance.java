package com.to;

import java.util.Date;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity

@Table
public class Compliance {

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	int complianceId;
	String RLType;
	String details;
	Date crdate;
	int deptid;
	String status;
	
	public String getStatus() {
		return status;
	}
	public void setStatus(String status) {
		this.status = status;
	}
	public Compliance()
	{
		
	}
	public Compliance(String rLType, String details, Date crdate, int deptid,String status) {
		//super();
		RLType = rLType;
		this.details = details;
		this.crdate = crdate;
		this.deptid = deptid;
		this.status=status;
	}
	public int getComplianceId() {
		return complianceId;
	}
	public void setComplianceId(int complianceId) {
		this.complianceId = complianceId;
	}
	public String getRLType() {
		return RLType;
	}
	public void setRLType(String rLType) {
		RLType = rLType;
	}
	public String getDetails() {
		return details;
	}
	public void setDetails(String details) {
		this.details = details;
	}
	public Date getCrdate() {
		return crdate;
	}
	public void setCrdate(Date crdate) {
		this.crdate = crdate;
	}
	public int getDeptid() {
		return deptid;
	}
	public void setDeptid(int deptid) {
		this.deptid = deptid;
	}
}
