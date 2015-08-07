using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data = System.Data.SqlClient;

/// <summary>
/// Summary description for Workflow
/// </summary>
public class Workflow:Database
{
    public int Id;
    public Role Role;
    public User User;
    public String DateTime;

    private String Query;

	public Workflow()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Role getRole(int Id)
    {
        Role _Role = new Role();
        Query = "SELECT role.id, role.name FROM role WHERE Role.Id = " + Id;
        try
        {
            Data.SqlCommand cm = new Data.SqlCommand();
            cm.CommandText = Query;
            cm.Connection = cn;
            Data.SqlDataReader rd = cm.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                _Role.Id = rd.GetInt32(0);
                _Role.Name = rd.GetString(1);
            }
            rd.Close();
            cm = null;
        }
        catch (Exception)
        {

            throw;
        }
        return (_Role);
    }

    public void addRole(Role _Role)
    {
        Query = "INSERT INTO Role (name) VALUES ('" + _Role.Name + "')";
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

    public void modRole(Role _Role)
    {
        Query = "UPDATE Role SET name = '" + _Role.Name + "' WHERE id = " + _Role.Id;
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
    } //Might Not Be Needed
}