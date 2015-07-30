using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data = System.Data.SqlClient;

/// <summary>
/// Summary description for Request
/// </summary>
public class Request: Database
{
    private String Query;

    public Request()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public User getCoordinator()
    {
        User _User = new User();
        Query = "SELECT [user].id, [user].name, [user].email, [user].contact, [user].logon, department.name, [user].confirmed " +
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
                _User.Role = null;
                _User.Confirmed = rd.GetBoolean(6);
            }

        }
        catch (Exception)
        {

            throw;
        }
        return (_User);
    }

    public User getUser(int RequestId, String Role)
    {
        User _User = new User();
        Query = "SELECT [user].id, [user].name, [user].email, [user].contact, [user].logon, department.name, [user].confirmed " +
            "FROM [user] INNER JOIN roleuser ON userrole.userid = [user].id " +
            "INNER JOIN department ON [user].departmentid = department.id " +
            "INNER JOIN role ON roleuser.roleid = role.id " +
            "INNER JOIN workflow.userid = user.id " +
            "WHERE role.name = '" + Role + "' AND workflow.requestid = " + RequestId;
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
                _User.Role = null;
                _User.Confirmed = rd.GetBoolean(6);
            }
        }
        catch (Exception)
        {

            throw;
        }
        return (_User);
    }

    public User getUser(int id)
    {
        User _User = new User();
        Query = "SELECT [user].id, [user].name, [user].email, [user].contact, [user].logon, department.name, [user].confirmed " +
            "FROM [user] INNER JOIN roleuser ON userrole.userid = [user].id " +
            "INNER JOIN department ON [user].departmentid = department.id " +
            "WHERE [user].id = " + id;
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
                _User.Role = _User.getRoles(rd.GetInt16(0));
                _User.Confirmed = rd.GetBoolean(6);
            }
        }
        catch (Exception)
        {

            throw;
        }
        return (_User);
    }

    public User getUser(String logon, String Role)
    {
        User _User = new User();
        Query = "SELECT [user].id, [user].name, [user].email, [user].contact, [user].logon, department.name, role.name, [user].confirmed " +
            "FROM [user] INNER JOIN roleuser ON userrole.userid = [user].id " +
            "INNER JOIN department ON [user].departmentid = department.id " +
            "INNER JOIN role ON roleuser.roleid = role.id " +
            "WHERE role.name = '" + Role + "' AND [user].logon = " + logon + "'";
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
                _User.Role = null;
                _User.Confirmed = rd.GetBoolean(7);
            }
        }
        catch (Exception)
        {

            throw;
        }
        return (_User);

    }

    public User getUser(String logon)
    {
        User _User = new User();
        Query = "SELECT [user].id, [user].name, [user].email, [user].contact, [user].logon, department.name, role.name, [user].confirmed " +
            "FROM [user] INNER JOIN roleuser ON userrole.userid = [user].id " +
            "INNER JOIN department ON [user].departmentid = department.id " +
            "INNER JOIN role ON roleuser.roleid = role.id " +
            "WHERE [user].logon = " + logon + "'";
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
                _User.Role = _User.getRoles(rd.GetInt16(0));
                _User.Confirmed = rd.GetBoolean(7);
            }
        }
        catch (Exception)
        {

            throw;
        }
        return (_User);

    }
}