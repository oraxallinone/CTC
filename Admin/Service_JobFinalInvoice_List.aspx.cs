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
    public string uname, code,no;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txt_FromDate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
            txt_ToDate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
            fillgrid();
            txt_year.Text = "2018-19";
        }
    }




    public void fillgrid()
    {
        string Branch = Session["Branch"].ToString();
        string year = txt_year.Text.Trim();
        string param = "@Fromdate,@Todate,@Branch,@year";

        string paramvalue = Convert.ToDateTime(txt_FromDate.Text, SmitaClass.dateformat()).ToString("yyyy-MM-dd HH:mm:ss") + " , " + Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat()).ToString("yyyy-MM-dd HH:mm:ss") + "," + Branch + ","+ year;

        DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_FinalinvoiceDetails1", param, paramvalue);


        if (Convert.ToInt32(dtr.Rows.Count) > 0)
        {
            GridView1.DataSource = dtr;
            GridView1.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('" + txt_FromDate.Text + "  To  " + txt_ToDate.Text + "  No Quotation Are Entry..!!');", true);
            txt_FromDate.Focus();
            return;
        }
    }

    protected void btn_Show_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_FromDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('From Date SHOULD NOT BE BLANK...!!');", true);
                txt_FromDate.Focus();
                return;
            }
            if (txt_ToDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('To Date SHOULD NOT BE BLANK...!!');", true);
                txt_ToDate.Focus();
                return;
            }
            
            if (Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat()) < Convert.ToDateTime(txt_FromDate.Text, SmitaClass.dateformat()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('To Date Must Be Greater Than From Date..!!');", true);
                txt_ToDate.Focus();
                return;
            }
            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy","dd-MM-yyyy" };
            DateTime expectedDate;
            if (!DateTime.TryParseExact(txt_FromDate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                txt_FromDate.Focus();
                return;
            }
            if (!DateTime.TryParseExact(txt_ToDate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                txt_ToDate.Focus();
                return;
            }


            fillgrid();

        }
        catch
        {

        }
    }

    //protected void imgbtnview_Click(object sender, ImageClickEventArgs e)
    //{
    //    ImageButton imgview = (ImageButton)sender;
    //    int sino = Convert.ToInt32(imgview.ToolTip);
    //    Session["PID"] = imgview.ToolTip;
    //    Session["JCN"] = imgview.CommandArgument;


    //    foreach (GridViewRow rw in GridView1.Rows)
    //    {
    //        ImageButton imgbtnnot = (ImageButton)rw.FindControl("imgbtnprint1");

    //        // ImageButton imgbtnnot = (ImageButton)sender;

    //        code = imgbtnnot.ToolTip;
    //        int no1 = Convert.ToInt32(imgbtnnot.CommandArgument);

    //        if (no1 == sino)
    //        {

      
          

    //        if (Session["Branch"].ToString() == "Paradeep")
    //        {

    //            //  Response.Redirect("Service_JobFinalInvoicePrint1.aspx?year=" + txt_year.Text.Trim());
    //            Response.Redirect("Service_JobFinalInvoicePrint1.aspx?year=" + code);

    //        }
    //        else if (Session["Branch"].ToString() == "Cuttack")
    //        {
    //            //Response.Redirect("Service_JobFinalInvoicePrint1_Cuttack.aspx?year=" + txt_year.Text.Trim());
    //            Response.Redirect("Service_JobFinalInvoicePrint1_Cuttack.aspx?year=" + code);

    //        }
    //        else if (Session["Branch"].ToString() == "Phulnakhara")
    //        {
    //            // Response.Redirect("Service_JobFinalInvoicePrint1_Phulnakhara.aspx?year=" + txt_year.Text.Trim());
    //            Response.Redirect("Service_JobFinalInvoicePrint1_Phulnakhara.aspx?year=" + code);

    //        }
    //        else
    //        {
    //            //  Response.Redirect("Service_JobFinalInvoicePrint1_Berhampur.aspx?year=" + txt_year.Text.Trim());
    //            Response.Redirect("Service_JobFinalInvoicePrint1_Berhampur.aspx?year=" + code);

    //        }

    //        return;


    //        }

    //    }

    //    //}
    //}
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
   
}
