using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data = System.Data.SqlClient;

/// <summary>
/// Summary description for Database
/// </summary>
public class Database
{
    private Data.SqlConnection cn;
    private const String CONNSTRING = "Data Source=aisrbmrweb01;Initial Catalog=webserver;Persist Security Info=True;User ID=webuser;Password=webuser";
    private String Query;
    public String ExceptionString;

	public Database()
	{
        try
        {
		    cn=new Data.SqlConnection();
            cn.ConnectionString = CONNSTRING;
            cn.Open();
        }
        catch (Exception)
        {
            
            throw;
        }
	}

    public ~Database()
    {
        try
        {
            cn.Close();
        }
        catch (Exception)
        {
            
            throw;
        }
    }

    public User getCoordinator()
    {
        User _User = new User();
        Query = "SELECT [user].id, [user].name, [user].email, [user].contact, [user].logon, department.name, role.name, [user].confirmed " +
            "FROM [user] INNER JOIN roleuser ON userrole.userid = [user].id " + 
            "INNER JOIN department ON [user].departmentid = department.id " +
            "INNER JOIN role ON roleuser.roleid = role.id " +
            "WHERE role.name = 'Coordinator'";
        try
        {
            Data.SqlCommand cm = new Data.SqlCommand();
            cm.CommandText = Query;
            Data.SqlDataReader rd = cm.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                _User.Id = rd.GetInt16(0);
                _User.Name = rd.GetString(1);
                _User.EMail = rd.GetString(2);
                _User.Phone = rd.GetString(3);
                _User.Logon = rd.GetString(4);
                _User.Department = rd.GetString(5);
                _User.Access = rd.GetString(6);
                _User.Confirmed = rd.GetBoolean(7);
                _User.CalloutLog = rd.GetBoolean(8);
            }

        }
        catch (Exception)
        {
            
            throw;
        }
        return (_User);
    }

    public User getRequester(int RequestId)
    {
        User _User = new User();
        Query = "SELECT [user].user_id, [user].user_name, [user].user_email, [user].user_contact, [user].login_name, department.department_name, access_name, [user].user_confirmed, [user].callout_report " +
            "FROM [user] INNER JOIN request ON [user].user_id = request.user_id " +
            "INNER JOIN access ON [user].access_id = access.access_id " +
            "INNER JOIN department ON [user].department_id = department.department_id " +
            "WHERE request.req_id = " + RequestId;
        try
        {
            Data.SqlCommand cm = new Data.SqlCommand();
            cm.CommandText = Query;
            Data.SqlDataReader rd = cm.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                _User.Id = rd.GetInt16(0);
                _User.Name = rd.GetString(1);
                _User.EMail = rd.GetString(2);
                _User.Phone = rd.GetString(3);
                _User.Logon = rd.GetString(4);
                _User.Department = rd.GetString(5);
                _User.Access = rd.GetString(6);
                _User.Confirmed = rd.GetBoolean(7);
                _User.CalloutLog = rd.GetBoolean(8);
            }

        }
        catch (Exception)
        {

            throw;
        }
        return (_User);
    }

    public User getMetSup(int RequestId)
    {
        User _User = new User();
        Query = "SELECT [user].user_id, [user].user_name, [user].user_email, [user].user_contact, [user].login_name, department.department_name, access_name, [user].user_confirmed, [user].callout_report " +
            "FROM [user] INNER JOIN change ON [user].user_id = change.au_user_id " +
            "INNER JOIN access ON [user].access_id = access.access_id " +
            "INNER JOIN department ON [user].department_id = department.department_id " +
            "WHERE change.request_id = " + RequestId;
        try
        {
            Data.SqlCommand cm = new Data.SqlCommand();
            cm.CommandText = Query;
            Data.SqlDataReader rd = cm.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                _User.Id = rd.GetInt16(0);
                _User.Name = rd.GetString(1);
                _User.EMail = rd.GetString(2);
                _User.Phone = rd.GetString(3);
                _User.Logon = rd.GetString(4);
                _User.Department = rd.GetString(5);
                _User.Access = rd.GetString(6);
                _User.Confirmed = rd.GetBoolean(7);
                _User.CalloutLog = rd.GetBoolean(8);
            }

        }
        catch (Exception)
        {

            throw;
        }
        return (_User);
    }

    public User getEngineer(int RequestId)
    {
        User _User = new User();
        Query = "SELECT [user].user_id, [user].user_name, [user].user_email, [user].user_contact, [user].login_name, department.department_name, access_name, [user].user_confirmed, [user].callout_report " +
            "FROM [user] INNER JOIN change ON [user].user_id = change.en_user_id " +
            "INNER JOIN access ON [user].access_id = access.access_id " +
            "INNER JOIN department ON [user].department_id = department.department_id " +
            "WHERE change.request_id = " + RequestId;
        try
        {
            Data.SqlCommand cm = new Data.SqlCommand();
            cm.CommandText = Query;
            Data.SqlDataReader rd = cm.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                _User.Id = rd.GetInt16(0);
                _User.Name = rd.GetString(1);
                _User.EMail = rd.GetString(2);
                _User.Phone = rd.GetString(3);
                _User.Logon = rd.GetString(4);
                _User.Department = rd.GetString(5);
                _User.Access = rd.GetString(6);
                _User.Confirmed = rd.GetBoolean(7);
                _User.CalloutLog = rd.GetBoolean(8);
            }

        }
        catch (Exception)
        {

            throw;
        }
        return (_User);
    }
    
    public User getTechSup(int RequestId)
    {
        User _User = new User();
        Query = "SELECT [user].user_id, [user].user_name, [user].user_email, [user].user_contact, [user].login_name, department.department_name, access_name, [user].user_confirmed, [user].callout_report " +
            "FROM [user] INNER JOIN change ON [user].user_id = change.ta_user_id " +
            "INNER JOIN access ON [user].access_id = access.access_id " +
            "INNER JOIN department ON [user].department_id = department.department_id " +
            "WHERE change.request_id = " + RequestId;
        try
        {
            Data.SqlCommand cm = new Data.SqlCommand();
            cm.CommandText = Query;
            Data.SqlDataReader rd = cm.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                _User.Id = rd.GetInt16(0);
                _User.Name = rd.GetString(1);
                _User.EMail = rd.GetString(2);
                _User.Phone = rd.GetString(3);
                _User.Logon = rd.GetString(4);
                _User.Department = rd.GetString(5);
                _User.Access = rd.GetString(6);
                _User.Confirmed = rd.GetBoolean(7);
                _User.CalloutLog = rd.GetBoolean(8);
            }

        }
        catch (Exception)
        {

            throw;
        }
        return (_User);
    }

    public User getInstEng(int RequestId)
    {
        User _User = new User();
        Query = "SELECT [user].user_id, [user].user_name, [user].user_email, [user].user_contact, [user].login_name, department.department_name, access_name, [user].user_confirmed, [user].callout_report " +
            "FROM [user] INNER JOIN change ON [user].user_id = change.ac_user_id " +
            "INNER JOIN access ON [user].access_id = access.access_id " +
            "INNER JOIN department ON [user].department_id = department.department_id " +
            "WHERE change.request_id = " + RequestId;
        try
        {
            Data.SqlCommand cm = new Data.SqlCommand();
            cm.CommandText = Query;
            Data.SqlDataReader rd = cm.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                _User.Id = rd.GetInt16(0);
                _User.Name = rd.GetString(1);
                _User.EMail = rd.GetString(2);
                _User.Phone = rd.GetString(3);
                _User.Logon = rd.GetString(4);
                _User.Department = rd.GetString(5);
                _User.Access = rd.GetString(6);
                _User.Confirmed = rd.GetBoolean(7);
                _User.CalloutLog = rd.GetBoolean(8);
            }

        }
        catch (Exception)
        {

            throw;
        }
        return (_User);
    }

    public User getSysEng(int RequestId)
    {
        User _User = new User();
        Query = "SELECT [user].user_id, [user].user_name, [user].user_email, [user].user_contact, [user].login_name, department.department_name, access_name, [user].user_confirmed, [user].callout_report " +
            "FROM [user] INNER JOIN change ON [user].user_id = change.pr_user_id " +
            "INNER JOIN access ON [user].access_id = access.access_id " +
            "INNER JOIN department ON [user].department_id = department.department_id " +
            "WHERE change.request_id = " + RequestId;
        try
        {
            Data.SqlCommand cm = new Data.SqlCommand();
            cm.CommandText = Query;
            Data.SqlDataReader rd = cm.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                _User.Id = rd.GetInt16(0);
                _User.Name = rd.GetString(1);
                _User.EMail = rd.GetString(2);
                _User.Phone = rd.GetString(3);
                _User.Logon = rd.GetString(4);
                _User.Department = rd.GetString(5);
                _User.Access = rd.GetString(6);
                _User.Confirmed = rd.GetBoolean(7);
                _User.CalloutLog = rd.GetBoolean(8);
            }

        }
        catch (Exception)
        {

            throw;
        }
        return (_User);
    }

    public User getCompTech(int RequestId)
    {
        User _User = new User();
        Query = "SELECT [user].user_id, [user].user_name, [user].user_email, [user].user_contact, [user].login_name, department.department_name, access_name, [user].user_confirmed, [user].callout_report " +
            "FROM [user] INNER JOIN change ON [user].user_id = change.ct_user_id " +
            "INNER JOIN access ON [user].access_id = access.access_id " +
            "INNER JOIN department ON [user].department_id = department.department_id " +
            "WHERE change.request_id = " + RequestId;
        try
        {
            Data.SqlCommand cm = new Data.SqlCommand();
            cm.CommandText = Query;
            Data.SqlDataReader rd = cm.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                _User.Id = rd.GetInt16(0);
                _User.Name = rd.GetString(1);
                _User.EMail = rd.GetString(2);
                _User.Phone = rd.GetString(3);
                _User.Logon = rd.GetString(4);
                _User.Department = rd.GetString(5);
                _User.Access = rd.GetString(6);
                _User.Confirmed = rd.GetBoolean(7);
                _User.CalloutLog = rd.GetBoolean(8);
            }

        }
        catch (Exception)
        {

            throw;
        }
        return (_User);
    }

    public User getOverInspect(int RequestId)
    {
        User _User = new User();
        Query = "SELECT [user].user_id, [user].user_name, [user].user_email, [user].user_contact, [user].login_name, department.department_name, access_name, [user].user_confirmed, [user].callout_report " +
            "FROM [user] INNER JOIN change ON [user].user_id = change.ov_user_id " +
            "INNER JOIN access ON [user].access_id = access.access_id " +
            "INNER JOIN department ON [user].department_id = department.department_id " +
            "WHERE change.request_id = " + RequestId;
        try
        {
            Data.SqlCommand cm = new Data.SqlCommand();
            cm.CommandText = Query;
            Data.SqlDataReader rd = cm.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                _User.Id = rd.GetInt16(0);
                _User.Name = rd.GetString(1);
                _User.EMail = rd.GetString(2);
                _User.Phone = rd.GetString(3);
                _User.Logon = rd.GetString(4);
                _User.Department = rd.GetString(5);
                _User.Access = rd.GetString(6);
                _User.Confirmed = rd.GetBoolean(7);
                _User.CalloutLog = rd.GetBoolean(8);
            }

        }
        catch (Exception)
        {

            throw;
        }
        return (_User);

    }
}