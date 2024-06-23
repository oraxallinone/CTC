using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for dbaccess
/// </summary>
public class dbaccess
{
    public SqlConnection cn;
    public SqlCommand cm;
    public SqlDataAdapter da;
    public DataSet ds = new DataSet();

	public dbaccess()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void conn()
    {
        cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ToString());
        cn.Open();
    }
    public int r_val;
    public int dml_statement(string query)
    {
        cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ToString());
        cn.Open();
        cm = new SqlCommand(query, cn);
        r_val = cm.ExecuteNonQuery();
        cn.Close();
        return r_val;
    }

    public DataSet fetch(string query)
    {
        cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ToString());
        cn.Open();
        da = new SqlDataAdapter(query, cn);
        ds.Clear();
        ds.Reset();
        da.Fill(ds);
        return ds;
    }

    public DataTable sp_exe(string sp)
    {
        cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ToString());
        cn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sp, cn);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataTable dt = new DataTable();
        da.Fill(dt);
        cn.Close();
        return dt;

    }
    public DataSet sp_fetch1svalue(string sp, string param1, string value1)
    {

        cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ToString());
        cn.Open();
        SqlDataAdapter ad = new SqlDataAdapter(sp, cn);
        ad.SelectCommand.CommandType = CommandType.StoredProcedure;
        ad.SelectCommand.Parameters.Add(new SqlParameter(param1, SqlDbType.VarChar));
        ad.SelectCommand.Parameters[param1].Value = value1;
        //ad.SelectCommand.Parameters.Add(param1, SqlDbType.VarChar).Value = Convert.ToString(value1);
        ds.Clear();
        ds.Reset();
        ad.Fill(ds);
        cn.Close();
        return ds;
    }
    public DataTable sp_fetch1par(string sp, string param1, int value1)
    {

        cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ToString());
        cn.Open();
        SqlDataAdapter ad = new SqlDataAdapter(sp, cn);
        ad.SelectCommand.CommandType = CommandType.StoredProcedure;
        ad.SelectCommand.Parameters.Add(new SqlParameter(param1, SqlDbType.VarChar));
        ad.SelectCommand.Parameters[param1].Value = value1;
        DataTable dt = new DataTable();
        ad.Fill(dt);
        cn.Close();
        return dt;
    }
    public DataTable sp_fetch1date(string sp, string param1, DateTime value1)
    {

        cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ToString());
        cn.Open();
        SqlDataAdapter ad = new SqlDataAdapter(sp, cn);
        ad.SelectCommand.CommandType = CommandType.StoredProcedure;
        ad.SelectCommand.Parameters.Add(new SqlParameter(param1, SqlDbType.VarChar));
        ad.SelectCommand.Parameters[param1].Value = value1;
        DataTable dt = new DataTable();
        ad.Fill(dt);
        cn.Close();
        return dt;
    }
    public DataTable sp_fetch2par(string sp, string param1, string value1, string param2, string value2)
    {

        cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ToString());
        cn.Open();
        SqlDataAdapter ad = new SqlDataAdapter(sp, cn);
        ad.SelectCommand.CommandType = CommandType.StoredProcedure;
        ad.SelectCommand.Parameters.Add(new SqlParameter(param1, SqlDbType.VarChar));
        ad.SelectCommand.Parameters[param1].Value = value1;
        ad.SelectCommand.Parameters.Add(new SqlParameter(param2, SqlDbType.VarChar));
        ad.SelectCommand.Parameters[param2].Value = value2;
        DataTable dt = new DataTable();
        ad.Fill(dt);
        cn.Close();
        return dt;
    }
    public int stmt(string query)
    {
        cm = new SqlCommand(query, cn);
        r_val = cm.ExecuteNonQuery();
        return r_val;
    }

    public void grd(string query, GridView g1)
    {
        fetch(query);
        g1.DataSource = ds.Tables[0];
        g1.DataBind();
    }
    public DataTable sp_stddetails(string sp, string param1, string value1, string param2, int value2,string param3,int value3)
    {

        cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ToString());
        cn.Open();
        SqlDataAdapter ad = new SqlDataAdapter(sp, cn);
        ad.SelectCommand.CommandType = CommandType.StoredProcedure;
        ad.SelectCommand.Parameters.Add(new SqlParameter(param1, SqlDbType.VarChar));
        ad.SelectCommand.Parameters[param1].Value = value1;
        ad.SelectCommand.Parameters.Add(new SqlParameter(param2, SqlDbType.VarChar));
        ad.SelectCommand.Parameters[param2].Value = value2;
        ad.SelectCommand.Parameters.Add(new SqlParameter(param3, SqlDbType.VarChar));
        ad.SelectCommand.Parameters[param3].Value = value3;
        DataTable dt = new DataTable();
        ad.Fill(dt);
        cn.Close();
        return dt;
    }
       //Insert  Data
    public static void insertprocedure(string procedurename, string param, string paramobj)
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ToString());
        con.Open();
        string[] paramarr = param.Split(',');
        string[] paramobjarr = paramobj.Split(',');
        SqlCommand com = new SqlCommand(procedurename, con);
        com.CommandType = CommandType.StoredProcedure;
        for (int i = 0; i < paramarr.Length; i++)
        {
            com.Parameters.AddWithValue(paramarr[i], paramobjarr[i]);
        }
        com.ExecuteNonQuery();
        con.Close();
    }
    //Retrive Data
    
    public static DataTable SPReturnDataTable(string procedurename, string param, string paramobj)
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ToString());
        con.Open();
        string[] paramarr = param.Split(',');
        string[] paramobjarr = paramobj.Split(',');
        DataTable dt = new DataTable();
        SqlDataAdapter ada = new SqlDataAdapter(procedurename, con);
        ada.SelectCommand.CommandType = CommandType.StoredProcedure;
        for (int i = 0; i < paramarr.Length; i++)
        {
            ada.SelectCommand.Parameters.AddWithValue(paramarr[i], paramobjarr[i]);
        }
        ada.Fill(dt);
        con.Close();
        return dt;
    }
}