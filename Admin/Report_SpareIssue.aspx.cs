using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
using System.Data;
public partial class Admin_Report_SpareIssue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            txt_FromDate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
            txt_ToDate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
        }
    }

    //[System.Web.Services.WebMethod]
    //public static string[] Getjcno(string prefixText, int count)
    //{
    //    string branch = HttpContext.Current.Session["Branch"].ToString();
    //    AutoMobileEntities db = new AutoMobileEntities();
    //    return db.AME_Service_JobCardEntry.Where(n => n.JC_No.Contains(prefixText) && n.Branch_Name == branch).OrderBy(n => n.JC_No).Select(n => n.JC_No).Distinct().Take(count).ToArray();


    //}
    protected void btn_Show_Click(object sender, EventArgs e)
    {
        try
        {
            string Branch = Session["Branch"].ToString();

            string param = "@Fromdate,@Todate,@Branch";

            string paramvalue = Convert.ToDateTime(txt_FromDate.Text, SmitaClass.dateformat()).ToString("yyyy-MM-dd") + "," + Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat()).ToString("yyyy-MM-dd") + "," + Branch;
            DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_reportspareissue", param, paramvalue);
            if (dtr.Rows.Count > 0)
            {
                GridView1.DataSource = dtr;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert(' No Data Are Found.!!');", true);
            }
        }
        catch (Exception ex)
        { }
    }

  
    protected void Button1_Click(object sender, EventArgs e)
    {

        fillgrid();
    }

    protected void fillgrid()
    {
        try
        {
            string Branch = Session["Branch"].ToString();

            string param = "@jc_no,@sparetype,@Branch";

            string paramvalue = txt_jcno.Text.Trim() + "," + drp_sparetype.SelectedItem.ToString() + "," + Branch;
            DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_reportspareissuesparewise", param, paramvalue);
            if (dtr.Rows.Count > 0)
            {
                GridView1.DataSource = dtr;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert(' No Data Are Found.!!');", true);
            }
        }
        catch (Exception ex)
        { }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        fillgrid1();
    }

    protected void fillgrid1()
    {
        try
        {
            string Branch = Session["Branch"].ToString();

            string param = "@jc_no,@Branch";

            string paramvalue = TextBox1.Text.Trim() + "," + Branch;
            DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_reportspareissuejc_no", param, paramvalue);
            if (dtr.Rows.Count > 0)
            {
                GridView1.DataSource = dtr;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert(' No Data Are Found.!!');", true);
            }
        }
        catch (Exception ex)
        { }

    }
}