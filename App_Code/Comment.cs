using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Comment
/// </summary>
public class Comment
{
    public int Id;
    public User User;
    public Status Status;
    public String Text;
    public String DateTime;

	public Comment()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}