using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using AutoMobileModel;

public partial class Admin_CustomerList : System.Web.UI.Page
{
    private static int PageSize = 50;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDummyRow();

        }
    }
    private void BindDummyRow()
    {
        DataTable dummy = new DataTable();
        dummy.Columns.Add("Mc_Id");
        dummy.Columns.Add("Mc_Name");
        dummy.Columns.Add("Mc_City");
        dummy.Columns.Add("Mc_code");
        dummy.Rows.Add();
        gvCustomers.DataSource = dummy;
        gvCustomers.DataBind();
    }

    [WebMethod]
    public static string GetCustomers(string searchTerm, int pageIndex)
    {
        string query = "[GetCustomers_Pager]";
        SqlCommand cmd = new SqlCommand(query);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SearchTerm", searchTerm);
        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
        cmd.Parameters.AddWithValue("@PageSize", PageSize);
        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
        return GetData(cmd, pageIndex).GetXml();
    }

    private static DataSet GetData(SqlCommand cmd, int pageIndex)
    {
        string strConnString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    sda.Fill(ds, "AME_Master_Customer");
                    DataTable dt = new DataTable("Pager");//div 
                    dt.Columns.Add("PageIndex");
                    dt.Columns.Add("PageSize");
                    dt.Columns.Add("RecordCount");
                    dt.Rows.Add();
                    dt.Rows[0]["PageIndex"] = pageIndex;
                    dt.Rows[0]["PageSize"] = PageSize;
                    dt.Rows[0]["RecordCount"] = cmd.Parameters["@RecordCount"].Value;
                    ds.Tables.Add(dt);
                    return ds;
                }
            }
        }
    }



    //data fill by id



    public class cutomerDetails
    {
        public int Mc_Id { get; set; }
        public string Mc_code { get; set; }
        public string Mc_Name { get; set; }
        public string Mc_Address { get; set; }
        public string Mc_City { get; set; }
        public string Mc_Pinno { get; set; }
        public string Mc_Mobileno { get; set; }
        public string Mc_Tin { get; set; }
        //public string Mc_Status { get; set; }


    }


    [System.Web.Services.WebMethod]

    public static List<cutomerDetails> getCutomerDetails(string cusId)
    {
        List<cutomerDetails> getlist = new List<cutomerDetails>();
        AutoMobileEntities db = new AutoMobileEntities();
        //string branchname = HttpContext.Current.Session["Branch"].ToString();



        var cDetails = db.AME_Master_Customer.Where(t => t.Mc_code == cusId).FirstOrDefault();



        cutomerDetails obj = new cutomerDetails();

        obj.Mc_Id = cDetails.Mc_Id;
        obj.Mc_code = cDetails.Mc_code;
        obj.Mc_Name = cDetails.Mc_Name;
        obj.Mc_Address = cDetails.Mc_Address;
        obj.Mc_City = cDetails.Mc_City;
        obj.Mc_Pinno = cDetails.Mc_Pinno;
        obj.Mc_Mobileno = cDetails.Mc_Mobileno;
        obj.Mc_Tin = cDetails.Mc_Tin;
        //obj.Mc_Status = cDetails.Mc_Status.ToString();


        getlist.Add(obj);

        return getlist;
    }



    [WebMethod]
    public static List<cutomerDetails> UpdateCustomer(string code, string name, string adress, string city, string pin, string mobile, string tin)
    {

        AutoMobileEntities db = new AutoMobileEntities();

        AME_Master_Customer cd = db.AME_Master_Customer.First(t => t.Mc_code == code);
        cd.Mc_Name = name;
        cd.Mc_Address = adress;
        cd.Mc_City = city;
        cd.Mc_Pinno = pin;
        cd.Mc_Mobileno = mobile;
        cd.Mc_Tin = tin;
        db.SaveChanges();



        List<cutomerDetails> getlist = new List<cutomerDetails>();
        var cDetails = db.AME_Master_Customer.Where(t => t.Mc_code == code).FirstOrDefault();

        cutomerDetails obj = new cutomerDetails();
        obj.Mc_Id = cDetails.Mc_Id;
        obj.Mc_code = cDetails.Mc_code;
        obj.Mc_Name = cDetails.Mc_Name;
        obj.Mc_Address = cDetails.Mc_Address;
        //obj.Mc_City = cDetails.Mc_City;
        obj.Mc_City = "";


        obj.Mc_Pinno = cDetails.Mc_Pinno;
        obj.Mc_Mobileno = cDetails.Mc_Mobileno;
        obj.Mc_Tin = cDetails.Mc_Tin;
        getlist.Add(obj);



        return getlist;
    }
}