using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data = System.Data.SqlClient;


/// <summary>
/// Summary description for UserInfo
/// </summary>
public class User: Database
{
    public int Id;
    public String Name;
    public String EMail;
    public String Phone;
    public String Logon;
    public Department Department;
    public List<Role> Role;
    public bool Confirmed;
    public bool CalloutLog;
    
    private String Query;

    public User()
	{

    }

    public List<Role> getRoles(int UserId)
    {
        List<Role> _Roles = new List<Role>();
        Query = "SELECT role.id, role.name " +
            "FROM role INNER JOIN roleuser ON userrole.roleid = role.id " +
            "INNER JOIN [user] ON [user].id = userrole.userid " +
            "WHERE [user].id = " + UserId;
        try
        {
            Data.SqlCommand cm = new Data.SqlCommand();
            cm.CommandText = Query;
            cm.Connection = cn;
            Data.SqlDataReader rd = cm.ExecuteReader();
            while(rd.Read())
            {
                Role _Role = new Role();
                _Role.Id = rd.GetInt16(0);
                _Role.Name = rd.GetString(1);
                _Roles.Add(_Role);
            }
            rd.Close();
            cm = null;
            
        }
        catch (Exception)
        {

            throw;
        }
        return (_Roles);
    }

    public List<Role> getRoles()
    {
        List<Role> _Roles = new List<Role>();
        Query = "SELECT role.id, role.name FROM role";
        try
        {
            Data.SqlCommand cm = new Data.SqlCommand();
            cm.CommandText = Query;
            cm.Connection = cn;
            Data.SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                Role _Role = new Role();
                _Role.Id = rd.GetInt16(0);
                _Role.Name = rd.GetString(1);
                _Roles.Add(_Role);
            }
            rd.Close();
            cm = null;
        }
        catch (Exception)
        {

            throw;
        }
        return (_Roles);
    }

    public List<Department> getDepartments()
    {
        List<Department> _Departments = new List<Department>();
        Query = "SELECT department.id, department.name " +
                "FROM department ORDER BY department.name";
        try
        {
            Data.SqlCommand cm = new Data.SqlCommand();
            cm.CommandText = Query;
            cm.Connection = cn;
            Data.SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                Department _Department = new Department();
                _Department.Id = rd.GetInt16(0);
                _Department.Name = rd.GetString(1);
                _Departments.Add(_Department);
            }
            rd.Close();
            cm = null;

        }
        catch (Exception)
        {

            throw;
        }
        return (_Departments);

    }

    public Department getDepartment(int UserId)
    {
        Department _Department = new Department();
        Query = "SELECT department.id, department.name " +
                "FROM department INNER JOIN [User] ON [User].departmentid = department.id " +
                "WHERE User.Id = " + UserId + " ORDER BY department.name";
        try
        {
            Data.SqlCommand cm = new Data.SqlCommand();
            cm.CommandText = Query;
            cm.Connection = cn;
            Data.SqlDataReader rd = cm.ExecuteReader();
            rd.Read();
            if(rd.HasRows)
            {
                _Department.Id = rd.GetInt16(0);
                _Department.Name = rd.GetString(1);
            }
            rd.Close();
            cm = null;

        }
        catch (Exception)
        {

            throw;
        }
        return (_Department);

    }
}