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
    public int RequestId;
    public String Description;
    public String Reason;
    public String InitDate;
    public Narrative Narrative;
    public bool NarrativeUpdated;
    public Status Status;
    public bool TempChange;
    public String TempEnd;

    private String Query;

    public Request()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<User> getUsers(String Role)
    {
        List<User> _Users = new List<User>();
        Query = "SELECT [user].id, [user].name, [user].email, [user].contact, [user].logon, department.name, [user].confirmed " +
            "FROM [user] INNER JOIN roleuser ON userrole.userid = [user].id " +
            "INNER JOIN department ON [user].departmentid = department.id " +
            "INNER JOIN role ON roleuser.roleid = role.id " +
            "WHERE role.name = '" + Role + "'";
        try
        {
            Data.SqlCommand cm = new Data.SqlCommand();
            cm.CommandText = Query;
            Data.SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                 User _User = new User();
                _User.Id = rd.GetInt16(0);
                _User.Name = rd.GetString(1);
                _User.EMail = rd.GetString(2);
                _User.Phone = rd.GetString(3);
                _User.Logon = rd.GetString(4);
                _User.Department = _User.getDepartment(_User.Id);
                _User.Role = _User.getRoles(_User.Id);
                _User.Confirmed = rd.GetBoolean(6);
                _Users.Add(_User);
            }
            rd.Close();
        }
        catch (Exception)
        {

            throw;
        }
        return (_Users);
    }

    public List<User> getUsers(int RequestId, String Role)
    {
        List<User> _Users = new List<User>();
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
            while(rd.Read())
            {
                User _User = new User();
                _User.Id = rd.GetInt16(0);
                _User.Name = rd.GetString(1);
                _User.EMail = rd.GetString(2);
                _User.Phone = rd.GetString(3);
                _User.Logon = rd.GetString(4);
                _User.Department = _User.getDepartment(_User.Id);
                _User.Role = _User.getRoles(_User.Id);
                _User.Confirmed = rd.GetBoolean(6);
                _Users.Add(_User);
            }
            rd.Close();
        }
        catch (Exception)
        {

            throw;
        }
        return (_Users);
    }

    public User getUser(int Id)
    {
        User _User = new User();
        Query = "SELECT [user].id, [user].name, [user].email, [user].contact, [user].logon, department.name, [user].confirmed " +
                "FROM [user] WHERE [User].id = " + Id;
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
                _User.Department = _User.getDepartment(_User.Id);
                _User.Role = _User.getRoles(_User.Id);
                _User.Confirmed = rd.GetBoolean(6);
            }
            rd.Close();
        }
        catch (Exception)
        {

            throw;
        }
        return (_User);

    }

    public List<Narrative> getNarratives()
    {
        List<Narrative> _Narratives = new List<Narrative>();
        Query = "SELECT narrative.id, narrative.name, narrative.filename, narrative.description FROM Narrative ORDER BY narrative.name";
        try
        {
            Data.SqlCommand cm = new Data.SqlCommand();
            cm.CommandText = Query;
            Data.SqlDataReader rd = cm.ExecuteReader();
            while(rd.Read())
            {
                Narrative _Narrative = new Narrative();
                _Narrative.Id = rd.GetInt16(0);
                _Narrative.Name = rd.GetString(1);
                _Narrative.FileName = rd.GetString(2);
                _Narrative.Description = rd.GetString(3);
                _Narratives.Add(_Narrative);
            }
            rd.Close();
        }
        catch (Exception)
        {

            throw;
        }
        return (_Narratives);
    }

    public List<Narrative> getNarratives(int RequestId)
    {
        List<Narrative> _Narratives = new List<Narrative>();
        Query = "SELECT narrative.id, narrative.name, narrative.filename, narrative.description FROM Narrative INNER JOIN Request ON Request.NarrativeId = Narrative.Id WHERE Request.Id = " + RequestId + " ORDER BY Narrative.Name";
        try
        {
            Data.SqlCommand cm = new Data.SqlCommand();
            cm.CommandText = Query;
            Data.SqlDataReader rd = cm.ExecuteReader();
            while(rd.Read())
            {
                Narrative _Narrative = new Narrative();
                _Narrative.Id = rd.GetInt16(0);
                _Narrative.Name = rd.GetString(1);
                _Narrative.FileName = rd.GetString(2);
                _Narrative.Description = rd.GetString(3);
                _Narratives.Add(_Narrative);
            }
            rd.Close();
        }
        catch (Exception)
        {

            throw;
        }
        return (_Narratives);
    }

    public List<Status> getStatusses()
    {
        List<Status> _Statusses = new List<Status>();
        Query = "SELECT status.id, status.name FROM Status ORDER BY status.name";
        try
        {
            Data.SqlCommand cm = new Data.SqlCommand();
            cm.CommandText = Query;
            Data.SqlDataReader rd = cm.ExecuteReader();
            while(rd.Read())
            {
                Status _Status = new Status();
                _Status.Id = rd.GetInt16(0);
                _Status.Name = rd.GetString(1);
                _Statusses.Add(_Status);
            }
            rd.Close();
        }
        catch (Exception)
        {

            throw;
        }
        return (_Statusses);
    }

    public Status getStatus(int RequestId)
    {
        Status _Status = new Status();
        Query = "SELECT status.id, status.name FROM Request INNER JOIN Status ON Request.StatusId = Status.Id ORDER BY status.name";
        try
        {
            Data.SqlCommand cm = new Data.SqlCommand();
            cm.CommandText = Query;
            Data.SqlDataReader rd = cm.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                _Status.Id = rd.GetInt16(0);
                _Status.Name = rd.GetString(1);
            }
            rd.Close();
        }
        catch (Exception)
        {

            throw;
        }
        return (_Status);
    }

    public Status getStatusById(int Id)
    {
        Status _Status = new Status();
        Query = "SELECT status.id, status.name FROM Status ORDER BY status.name";
        try
        {
            Data.SqlCommand cm = new Data.SqlCommand();
            cm.CommandText = Query;
            Data.SqlDataReader rd = cm.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                _Status.Id = rd.GetInt16(0);
                _Status.Name = rd.GetString(1);
            }
            rd.Close();
        }
        catch (Exception)
        {

            throw;
        }
        return (_Status);
    }

    public List<Document> getDocuments(int RequestId)
    {
        List<Document> _Documents = new List<Document>();
        Query = "SELECT document.id, document.name, document.filename, document.description, document.datetime, document.UserId FROM Document INNER JOIN Request ON Request.Id = Document.RequestId WHERE Request.Id = " + RequestId + " ORDER BY Document.Name";
        try
        {
            Data.SqlCommand cm = new Data.SqlCommand();
            cm.CommandText = Query;
            Data.SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                Document _Document = new Document();
                _Document.Id = rd.GetInt16(0);
                _Document.Name = rd.GetString(1);
                _Document.FileName = rd.GetString(2);
                _Document.Description = rd.GetString(3);
                _Document.DateTime = rd.GetString(4);
                _Document.User = getUser(rd.GetInt16(5));
                _Documents.Add(_Document);
            }
            rd.Close();
        }
        catch (Exception)
        {

            throw;
        }
        return (_Documents);
    }

    public List<Comment> getComments(int RequestId)
    {
        List<Comment> _Comments = new List<Comment>();
        Query = "SELECT comment.id, comment.userid, comment.statusid, comment.text, comment.datetime FROM Comment WHERE Comment.Id = " + RequestId + " ORDER BY Comment.DateTime";
        try
        {
            Data.SqlCommand cm = new Data.SqlCommand();
            cm.CommandText = Query;
            Data.SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                Comment _Comment = new Comment();
                _Comment.Id = rd.GetInt16(0);
                _Comment.User = getUser(rd.GetInt16(1));
                _Comment.Status = getStatusById(rd.GetInt16(2));
                _Comment.Text = rd.GetString(3);
                _Comment.DateTime = rd.GetString(4);
                _Comments.Add(_Comment);
            }
            rd.Close();
        }
        catch (Exception)
        {

            throw;
        }
        return (_Comments);

    }

    public List<Workflow> getWorkflow(int RequestId)
    {
        List<Workflow> _Workflows = new List<Workflow>();
        Query = "SELECT workflow.Id, workflow.roleid, workflow.userid, workflow.datetime FROM workflow WHERE workflow.requestid = " + RequestId;
        try
        {
            Data.SqlCommand cm = new Data.SqlCommand();
            cm.CommandText = Query;
            Data.SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                Workflow _Workflow = new Workflow();
                _Workflow.Id = rd.GetInt16(0);
                _Workflow.User = getUser(rd.GetInt16(2));
                _Workflow.Role = _Workflow.getRole(rd.GetInt16(1));
                _Workflow.DateTime = rd.GetString(3);
                _Workflows.Add(_Workflow);
            }
            rd.Close();
        }
        catch (Exception)
        {

            throw;
        }
        return (_Workflows);

    }
}