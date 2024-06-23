using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
using System.Data;

public partial class Admin_Service_JobFinalInvoice_List_InvoiceNo : System.Web.UI.Page
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
    public static string[] GetInvoice(string prefixText, int count)
    {
        string branch = HttpContext.Current.Session["Branch"].ToString();
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Service_JobcardFinalInvoice.Where(n => n.FI_InvoiceNo.Contains(prefixText) && n.Branch_Name == branch).OrderBy(n => n.FI_InvoiceNo).Select(n => n.FI_InvoiceNo).Distinct().Take(count).ToArray();

    }
    
    
    
    public void fillgrid()
    {
        string Branch = Session["Branch"].ToString();
        string param = "@InvoiceNo,@Branch,@year";
        string year = txt_year.Text.Trim();
        string paramvalue = txt_invoice.Text.Trim() + "," + Branch + " ," + year;

        //string param = "@InvoiceNo,@Branch";
        //string paramvalue = txt_invoice.Text.Trim() + "," + Branch ;
        //DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_FinalinvoiceDetails_Invoice", param, paramvalue);

        DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_FinalinvoiceDetails_Invoice_No2", param, paramvalue);

        //DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_FinalinvoiceDetails_Invoice_No1", param, paramvalue);

        if (Convert.ToInt32(dtr.Rows.Count) > 0)
        {
            GridView1.DataSource = dtr;
            GridView1.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('  "+txt_invoice.Text + "  No Invoice Are Entry..!!');", true);
            txt_invoice.Focus();
            return;
        }
    }

    protected void btn_Show_Click(object sender, EventArgs e)
    {


        //if (txt_year.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Please Enter Finacial Year..!!');", true);
        //    txt_year.Focus();
        //    return;
        
        //}
        try
        {
            fillgrid();

        }
        catch
        {

        }
    }

    protected void imgbtnview_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgview = (ImageButton)sender;
        int sino = Convert.ToInt32(imgview.ToolTip);
        string Branch = Session["Branch"].ToString();
    
        Session["PID"] = imgview.ToolTip;
        Session["JCN"] = imgview.CommandArgument;
      
            foreach (GridViewRow rw in GridView1.Rows)
            {
                ImageButton imgbtnnot = (ImageButton)rw.FindControl("imgbtnprint1");
                code = imgbtnnot.ToolTip;

                var check = from c in db.AME_Service_JobcardFinalInvoice.Where(t => t.FI_Sino == sino && t.jc_year == code && t.Branch_Name == Branch) select c;

        if (check.First().gstflag == false)

        {

                //  code = txt_year.Text.Trim();
                if (Session["Branch"].ToString() == "Paradeep")
                {

                    //  Response.Redirect("Service_JobFinalInvoicePrint1.aspx?year=" + txt_year.Text.Trim());
                    Response.Redirect("Service_JobFinalInvoicePrint2.aspx?year=" + code);

                }
                else if (Session["Branch"].ToString() == "Cuttack")
                {
                    // Response.Redirect("Service_JobFinalInvoicePrint1_Cuttack.aspx?year=" + txt_year.Text.Trim());

                    Response.Redirect("Service_JobFinalInvoicePrint2_Cuttack.aspx?year=" + code);

                }
                else if (Session["Branch"].ToString() == "Phulnakhara")
                {
                    //  Response.Redirect("Service_JobFinalInvoicePrint1_Phulnakhara.aspx?year=" + txt_year.Text.Trim());

                    Response.Redirect("Service_JobFinalInvoicePrint2_Phulnakhara.aspx?year=" + code);

                }
                else
                {
                    //  Response.Redirect("Service_JobFinalInvoicePrint1_Berhampur.aspx?year=" + txt_year.Text.Trim());

                    Response.Redirect("Service_JobFinalInvoicePrint2_Berhampur.aspx?year=" + code);

                }

                return;
            }

        
        

        else
        {

            //  code = txt_year.Text.Trim();
            if (Session["Branch"].ToString() == "Paradeep")
            {

                //  Response.Redirect("Service_JobFinalInvoicePrint1.aspx?year=" + txt_year.Text.Trim());
                Response.Redirect("Service_JobFinalInvoicePrint1.aspx?year=" + code);

            }
            else if (Session["Branch"].ToString() == "Cuttack")
            {
                // Response.Redirect("Service_JobFinalInvoicePrint1_Cuttack.aspx?year=" + txt_year.Text.Trim());

                Response.Redirect("Service_JobFinalInvoicePrint1_Cuttack.aspx?year=" + code);

            }
            else if (Session["Branch"].ToString() == "Phulnakhara")
            {
                //  Response.Redirect("Service_JobFinalInvoicePrint1_Phulnakhara.aspx?year=" + txt_year.Text.Trim());

                Response.Redirect("Service_JobFinalInvoicePrint1_Phulnakhara.aspx?year=" + code);

            }
            else
            {
                //  Response.Redirect("Service_JobFinalInvoicePrint1_Berhampur.aspx?year=" + txt_year.Text.Trim());

                Response.Redirect("Service_JobFinalInvoicePrint1_Berhampur.aspx?year=" + code);

            }

            return;
        }

        }
        
    }
    protected void fillgrid1()
    {

        string Branch = Session["Branch"].ToString();
        string param = "@jcNo,@Branch,@year";
        string year = TextBox2.Text.Trim();
        string paramvalue = txt_jcno.Text.Trim() + "," + Branch + " ," + year;

        //string param = "@InvoiceNo,@Branch";
        //string paramvalue = txt_invoice.Text.Trim() + "," + Branch ;
        //DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_FinalinvoiceDetails_Invoice", param, paramvalue);

        DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_FinalinvoiceSearchJcNOwise", param, paramvalue);

        //DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_FinalinvoiceDetails_Invoice_No1", param, paramvalue);

        if (Convert.ToInt32(dtr.Rows.Count) > 0)
        {
            GridView1.DataSource = dtr;
            GridView1.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('  " + txt_jcno.Text + "  No JCNO Are Entry..!!');", true);
            txt_jcno.Focus();
            return;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        try
        {
            fillgrid1();

        }
        catch
        {

        }
    }
}