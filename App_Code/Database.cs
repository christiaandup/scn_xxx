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
    public Data.SqlConnection cn;
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
}