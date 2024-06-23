using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
using System.Data;
public partial class Report_ProjectExpensesDetailsCodeDatewise : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    public string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            tbldetails.Visible = false;
            fillgrid();
        }
    }

    [System.Web.Services.WebMethod]
    public static string[] GetServiceCode(string prefixText, int count)
    {
        string branch = HttpContext.Current.Session["Branch"].ToString();
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Service_JobCardEntry.Where(n => n.JC_Regno.Contains(prefixText) && n.Branch_Name==branch).OrderBy(n => n.SI_No).Select(n => n.JC_Regno).Distinct().Take(count).ToArray();
    }
    [System.Web.Services.WebMethod]
    public static string[] GetEnginee(string prefixText, int count)
    {
        string branch = HttpContext.Current.Session["Branch"].ToString();
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Service_JobCardEntry.Where(n => n.JC_Engineno.Contains(prefixText) && n.Branch_Name == branch).OrderBy(n => n.SI_No).Select(n => n.JC_Engineno).Distinct().Take(count).ToArray();
    }

    public void fillgrid()
    {
        string Branch = Session["Branch"].ToString();
        string registno = txtregst.Text;
        string param = "@VRegno,@Branch";

        string paramvalue = registno+ "," + Branch;

        DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_JCServiceHistory", param, paramvalue);
        //DataSet ds = smitaDbAccess.SPReturnDataSet("sp_JCServiceHistory", param, paramvalue);
        //if(Convert.ToInt32(ds.Tables[0].Rows.Count)>0)
        //{
        //    lblchessisno.Text = ds.Tables[0].Rows[0].ItemArray["JC_Chassisno"].ToString();
        //}

        if (Convert.ToInt32(dtr.Rows.Count) > 0)
        {
            lblchessisno.Text = dtr.Rows[0]["JC_Chassisno"].ToString();
            lblownername.Text = dtr.Rows[0]["Mc_Name"].ToString();
            lblmodelno.Text = dtr.Rows[0]["Mv_ModelName"].ToString();
            lblengineno.Text = dtr.Rows[0]["JC_Engineno"].ToString();
            tbldetails.Visible = true;
            display.Style.Add(HtmlTextWriterStyle.Display, "show");
            //GridView1.DataSource = dtr;
            //GridView1.DataBind();
        }
        else
        {
            display.Style.Add(HtmlTextWriterStyle.Display, "none");
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Registration No Dont Contain Any Spareparts...!!');", true);
            //ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Registration No Dont Contain Any '"+dtr.Rows[0].ItemArray[0].ToString()+"'...!!');", true);
            txtregst.Focus();
            return;
        }
    }
    public void fillgridenginee()
    {
        string Branch = Session["Branch"].ToString();
        string registno = txtnginee.Text;
        string param = "@enginee,@Branch";

        string paramvalue = registno + "," + Branch;

        DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_JCServiceHistoryenginee", param, paramvalue);
        //DataSet ds = smitaDbAccess.SPReturnDataSet("sp_JCServiceHistory", param, paramvalue);
        //if(Convert.ToInt32(ds.Tables[0].Rows.Count)>0)
        //{
        //    lblchessisno.Text = ds.Tables[0].Rows[0].ItemArray["JC_Chassisno"].ToString();
        //}

        if (Convert.ToInt32(dtr.Rows.Count) > 0)
        {
            lblchessisno.Text = dtr.Rows[0]["JC_Chassisno"].ToString();
            lblownername.Text = dtr.Rows[0]["Mc_Name"].ToString();
            lblmodelno.Text = dtr.Rows[0]["Mv_ModelName"].ToString();
            lblengineno.Text = dtr.Rows[0]["JC_Engineno"].ToString();
            tbldetails.Visible = true;
            display.Style.Add(HtmlTextWriterStyle.Display, "show");
            //GridView1.DataSource = dtr;
            //GridView1.DataBind();
        }
        else
        {
            display.Style.Add(HtmlTextWriterStyle.Display, "none");
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Enginee No. No Dont Contain Any Spareparts...!!');", true);
            //ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Registration No Dont Contain Any '"+dtr.Rows[0].ItemArray[0].ToString()+"'...!!');", true);
            txtnginee.Focus();
            return;
        }
    }
    protected void btn_Show_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtregst.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Registration No SHOULD NOT BE BLANK...!!');", true);
                txtregst.Focus();
                return;
            }
          
            
          

            fillgrid();
            txtnginee.Text = "";

        }
        catch
        {

        }
    }


 
    protected void imgbtnedit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgedit = (ImageButton)sender;
        int sino = Convert.ToInt32(imgedit.ToolTip);
        Response.Redirect("Service_JobcardEntryEdit.aspx?id=" + sino + "&Type=" + "Edit");
    }
    protected void imgbtnview_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgview = (ImageButton)sender;
        int sino = Convert.ToInt32(imgview.ToolTip);
        Response.Redirect("Service_JobcardEntryEdit.aspx?id=" + sino + "&Type=" + "View");
    }
   
    protected void imgbtndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgdelete = (ImageButton)sender;
        int sino = Convert.ToInt32(imgdelete.ToolTip);
        string branchname = Session["Branch"].ToString();
        AME_Service_JobCardEntry vq = db.AME_Service_JobCardEntry.First(t => t.JC_No == sino && t.Branch_Name == branchname);
        db.DeleteObject(vq);

        db.AME_Service_JobCardServiceDetails.Where(t => t.JC_No == sino && t.Branch_Name == branchname).ToList().ForEach(db.AME_Service_JobCardServiceDetails.DeleteObject);

       

        db.SaveChanges();

        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Data Deleted Sucessfully..!!');", true);
        fillgrid();

      
    }
    protected void btn_show_Click(object sender, EventArgs e)
    {
        if (txtnginee.Text == "")
        {
            string Branch = Session["Branch"].ToString();
            string registno = txtregst.Text;
            string param = "@VRegno,@Branch";

            string paramvalue = registno + "," + Branch;

            DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_JCSpareServiceHistory", param, paramvalue);
            if (Convert.ToInt32(dtr.Rows.Count) > 0)
            {
                Session["Rgno"] = txtregst.Text;


                Response.Redirect("Service_ServiceHistoryPrint.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert(' No Spareparts Are Issue In this Job Caard...!!');", true);
                txtregst.Focus();
                return;

            }
        }
        else
        {
            string Branch = Session["Branch"].ToString();
            string registno = txtnginee.Text;
            string param = "@enginee,@Branch";

            string paramvalue = registno + "," + Branch;

            DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_JCSpareServiceHistoryenginee", param, paramvalue);
            if (Convert.ToInt32(dtr.Rows.Count) > 0)
            {
                Session["enginee"] = txtnginee.Text;


                Response.Redirect("Service_ServiceHistoryPrint.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert(' No Spareparts Are Issue In this Enginee No...!!');", true);
                txtnginee.Focus();
                return;

            }
        }
        
       
    }
    protected void btn_Showengn_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtnginee.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Enginee No SHOULD NOT BE BLANK...!!');", true);
                txtnginee.Focus();
                return;
            }

            fillgridenginee();
            txtregst.Text = "";

        }
        catch
        {

        }
    }
}
