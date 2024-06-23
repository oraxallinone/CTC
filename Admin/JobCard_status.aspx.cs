using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
using System.Data;
public partial class Admin_JobCard_status : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    public string uname;
    string code;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
        }
    }
    [System.Web.Services.WebMethod]
    public static string[] Getregd(string prefixText, int count)
    {
        string branch = HttpContext.Current.Session["Branch"].ToString();
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Service_JobCardEntry.Where(n => n.JC_Regno.Contains(prefixText) && n.Branch_Name == branch && n.Ms_Status=="OPEN").OrderBy(n => n.JC_Regno).Select(n => n.JC_Regno).Distinct().Take(count).ToArray();


    }
    public void fillgrid()
    {
        try
        {
            string Branch = Session["Branch"].ToString();
            string param = "@Regdno,@Branch";
            string paramvalue = txt_regd.Text.Trim() + "," + Branch;



            DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_Jobcardstatus", param, paramvalue);



            if (Convert.ToInt32(dtr.Rows.Count) > 0)
            {
                GridView1.DataSource = dtr;
                GridView1.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('  " + txt_regd.Text + " Already Closed ..!!');", true);
                txt_regd.Focus();
                return;
            }
        }
        catch (Exception ex)
        { }
    }

    protected void btn_Show_Click(object sender, EventArgs e)
    {
        fillgrid();
    }

    protected void drpstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ImageButton btn = (ImageButton)sender;
        DropDownList btn = (DropDownList)sender;
       string jcno = btn.ToolTip;
        //int jcno = Convert.ToInt32(btn.ToolTip);
        foreach (GridViewRow rw in GridView1.Rows)
        {
            DropDownList imgbtn = (DropDownList)rw.FindControl("drpstatus");
            string code = imgbtn.ToolTip;
           // int code = Convert.ToInt32(imgbtn.ToolTip);


            if (jcno == code)
            {
                DropDownList unit = (DropDownList)rw.FindControl("drpstatus");
                  string Branch = Session["Branch"].ToString();

                //AME_Service_JobCardEntry s = db.AME_Service_JobCardEntry.First(t => t.JC_No == code && t.JC_year == "2016-17");
                  AME_Service_JobCardEntry s = db.AME_Service_JobCardEntry.First(t => t.JC_Regno == code && t.Branch_Name == Branch);

                s.Ms_Status = unit.SelectedValue;

                db.SaveChanges();

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Status Updated Sucesfully...!!');</script>", false);



            }
        }


    }
}