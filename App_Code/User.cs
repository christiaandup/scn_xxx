using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.WebPages.Html;
using System.ComponentModel;
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
    #region Role

    public List<Role> getRoles(int UserId)
    {
        List<Role> _Roles = new List<Role>();
        Query = "SELECT role.id, role.name " +
            "FROM role INNER JOIN userrole ON userrole.roleid = role.id " +
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
                _Role.Id = rd.GetInt32(0);
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
                _Role.Id = rd.GetInt32(0);
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

    public void assignRole(User _User, Role _Role)
    {
        Query = "INSERT INTO UserRole (userid, roleid) VALUES (" + _User.Id + "," + _Role.Id + ")";
        try
        {
            Data.SqlCommand cm = new Data.SqlCommand();
            cm.CommandText = Query;
            cm.Connection = cn;
            cm.ExecuteNonQuery();
        }
        catch (Exception)
        {
            
            throw;
        }
    }

    public void unassignRole(User _User, Role _Role)
    {
        Query = "DELETE FROM UserRole WHERE userid = " + _User.Id + " AND roleid = " + _Role.Id;
        try
        {
            Data.SqlCommand cm = new Data.SqlCommand();
            cm.CommandText = Query;
            cm.Connection = cn;
            cm.ExecuteNonQuery();
        }
        catch (Exception)
        {

            throw;
        }
    }
    
    #endregion

    #region Department

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
                _Department.Id = rd.GetInt32(0);
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
                "WHERE [User].Id = " + UserId + " ORDER BY department.name";
        try
        {
            Data.SqlCommand cm = new Data.SqlCommand();
            cm.CommandText = Query;
            cm.Connection = cn;
            Data.SqlDataReader rd = cm.ExecuteReader();
            rd.Read();
            if(rd.HasRows)
            {
                _Department.Id = rd.GetInt32(0);
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

    public IEnumerable<SelectListItem> fillDepartments()
    {
        IEnumerable<SelectListItem> _Items = new SelectListItem[]{};
        try
        {
            foreach(Department _dept in getDepartments())
            {
                SelectListItem item = new SelectListItem();
                item.Value = _dept.Id.ToString();
                item.Text = _dept.Name;
                _Items = Helper.Add<SelectListItem>(_Items, item);
            }

        }
        catch (Exception)
        {
            
            throw;
        }
        return (_Items);
    }

    public void addDepartment(Department _Department)
    {
        Query = "INSERT INTO Department (Name) VALUES ('" + _Department.Name + "')";
        try
        {
            Data.SqlCommand cm = new Data.SqlCommand();
            cm.CommandText = Query;
            cm.Connection = cn;
            cm.ExecuteNonQuery();
        }
        catch (Exception)
        {
            
            throw;
        }
    }

    public void modDepartment(Department _Department)
    {
        Query = "UPDATE Department SET Name = '" + _Department.Name + "' WHERE id = " + _Department.Id;
        try
        {
            Data.SqlCommand cm = new Data.SqlCommand();
            cm.CommandText = Query;
            cm.Connection = cn;
            cm.ExecuteNonQuery();
        }
        catch (Exception)
        {

            throw;
        }
    }

    #endregion
}