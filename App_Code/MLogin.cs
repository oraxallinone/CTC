using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for MLogin
/// </summary>
public class MLogin
{
	public MLogin()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static void CallSession(string UserId,string Branch,string UserType,string UName)
    {
        HttpContext.Current.Session["Uid"] = UserId;
        HttpContext.Current.Session["Branch"] = Branch;
        HttpContext.Current.Session["Usertype"] = UserType;
        HttpContext.Current.Session["Uname"] = UName;
        HttpContext.Current.Session.Timeout = 500;
    }
}