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
    public string uname, code;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txt_FromDate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
            txt_ToDate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
           // fillgrid();
        }
    }

    [System.Web.Services.WebMethod]
    public static string[] Getyear(string prefixText, int count)
    {

        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_FinacialYear.Where(n => n.finacialyear.Contains(prefixText)).OrderBy(n => n.finacialyear).Select(n => n.finacialyear).Distinct().Take(count).ToArray();
    }

    public void fillgrid()
    {
        string Branch = Session["Branch"].ToString();
        string year = txt_year.Text.Trim();
        string param = "@Fromdate,@Todate,@Branch,@year";

      //  string param = "@Fromdate,@Todate,@Branch";

        string paramvalue = Convert.ToDateTime(txt_FromDate.Text, SmitaClass.dateformat()).ToString("dd/MM/yyyy") + " , " + Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat()).ToString("dd/MM/yyyy") + "," + Branch + "," + year;

        DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_CancelFinalinvoiceDetails1", param, paramvalue);


        if (Convert.ToInt32(dtr.Rows.Count) > 0)
        {
            GridView1.DataSource = dtr;
            GridView1.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('" + txt_FromDate.Text + "  To  " + txt_ToDate.Text + "  No Bills Are Entry..!!');", true);
            txt_FromDate.Focus();
            return;
        }
    }

    protected void btn_Show_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_year.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Finacial Year Should not be blank...!!');", true);
                txt_ToDate.Focus();
                return;
            }
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

    protected void btncancel_Click(object sender, EventArgs e)
    {
        try
        {
            Button imgview = (Button)sender;
            int id = Convert.ToInt32(imgview.ToolTip);
           
            foreach (GridViewRow gr in GridView1.Rows)
            {
                Button cancel = (Button)gr.FindControl("btncancel");
                int cancelid = Convert.ToInt32(cancel.ToolTip);

                ImageButton imgbtnnot = (ImageButton)gr.FindControl("imgbtnprint1");
                code = imgbtnnot.ToolTip;
                if (cancelid == id)
                {
                    string Branch = Session["Branch"].ToString();
                   // string year = txt_year.Text.Trim();

                    string year = code;

                    string param = "@jobcardno,@branch,@year";

                    Label lbljcno = (Label)gr.FindControl("lbljcno");
                    int jcno = Convert.ToInt32(lbljcno.Text);


                    Label lblinvoiceno = (Label)gr.FindControl("lblinvno");
                    string invoiceno = lblinvoiceno.Text;

                   string paramvalue = id + "," + Branch + "," +year ;
                    DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_CancelJobcard", param, paramvalue);
                    
                        //AME_Daily_SpareSales_Report dsr = db.AME_Daily_SpareSales_Report.First(t=> t.JC_No==jcno && t.Branch_Name==Branch && t.jc_year==txt_year.Text.Trim() );
                    AME_Daily_SpareSales_Report dsr = db.AME_Daily_SpareSales_Report.First(t => t.JC_No == jcno && t.Branch_Name == Branch && t.jc_year == code);
                        dsr.DR_InvoiceNo = invoiceno;
                        dsr.DR_IDate = SmitaClass.IndianTime();
                        dsr.DR_InvType = "CANCEL";
                        dsr.DR_InvStatus = "SERVICE";
                        dsr.Dr_InvMode = "0";
                        dsr.JC_No =jcno;
                        dsr.Dr_Spare13_5 = 0;
                        dsr.Dr_Lub13_5 = 0;
                        dsr.Dr_Spare5 = 0;
                        //decimal discountamount = Convert.ToDecimal(txt_ADiscountAmount.Text);
                        dsr.Dr_DiscountAmount3_5 = 0;
                        dsr.Dr_DiscountAmount5 = 0;
                        //decimal spare13_5 = (Convert.ToDecimal(txt_AGrossAmount.Text) * Convert.ToDecimal(13 * 5)) / 100;
                        dsr.Dr_Output13_5 = 0;
                        dsr.Dr_Output5 = 0;
                        dsr.Dr_OtherCharges = 0;
                        dsr.Dr_Labourcharges = 0;
                        dsr.Dr_NetLabourcharges = 0;
                        dsr.Dr_Servtaxx12 = 0;
                        dsr.Dr_Ecess2 = 0;
                        dsr.Dr_Scess1 = 0;
                        dsr.Dr_Roundoff = 0;
                        dsr.Dr_Outsidejob =0;
                        dsr.Dr_InvoiceTotal = 0;
                        dsr.Dr_DisLabourcharges = 0;
                        dsr.Branch_Name = Session["Branch"].ToString();
                        db.SaveChanges();

                        cancel.Visible = true;

  //                      var ds6 = from c in db.AME_Service_JobCardEntry.Where(t => t.JC_No == jcno && t.Branch_Name == Branch && t.Ms_Status == "CLOSE" && t.JC_year == txt_year.Text.Trim()) select c;

  //                      if (ds6.Count() > 0)
  //                      {


  //                          AME_Service_JobCardEntry dsr1 = db.AME_Service_JobCardEntry.First(t => t.JC_No == jcno && t.Branch_Name == Branch && t.JC_year == txt_year.Text.Trim() && t.Ms_Status == "CLOSE");

  //                          dsr1.Ms_Status = "OPEN";
  //                          db.SaveChanges();
  //                      }

  //                      var ds7 = from c in db.AME_Service_JobCardServiceDetails.Where(t => t.JC_No == jcno && t.Branch_Name == Branch && t.JCS_Status == "CLOSE" && t.Jc_year == txt_year.Text.Trim()) select c;

  //                      if (ds7.Count() > 0)
  //                      {

  //                          foreach (var c in ds7)
  //                          {
  //                              AME_Service_JobCardServiceDetails dsr2 = db.AME_Service_JobCardServiceDetails.First(t => t.JC_No == jcno && t.Branch_Name == Branch && t.Jc_year == txt_year.Text.Trim() && t.JCS_Status == "CLOSE");

  //                              dsr2.JCS_Status = "OPEN";
  //                              db.SaveChanges();
  //                          }
                   
  //                      }

  //                    var ds8 = from c in db.AME_Service_JobcardSpareIssue.Where(t => t.JC_No == jcno && t.Branch_Name == Branch && t.Ms_Status == "CLOSE" && t.Jc_year == txt_year.Text.Trim()) select c;
  //                    if (ds8.Count() > 0)
  //                    {


  //                        foreach (var c in ds8)
  //                        {
  //                            AME_Service_JobcardSpareIssue dsr3 = db.AME_Service_JobcardSpareIssue.First(t => t.JC_No == jcno && t.Branch_Name == Branch && t.Jc_year == txt_year.Text.Trim() && t.Ms_Status == "CLOSE");
  //                            dsr3.Ms_Status = "OPEN";
  //                            db.SaveChanges();
  //                        }
  //                    }
  //                  var ds = from c in db.AME_Service_JobCardSpareReturn.Where(t => t.JC_No == jcno && t.Branch_Name == Branch && t.Ms_Status == "CLOSE") select c;
  //                  if (ds.Count() > 0)
  //                  {

  //                      foreach (var c in ds)
  //                      {

  //                          AME_Service_JobCardSpareReturn dsr4 = db.AME_Service_JobCardSpareReturn.First(t => t.JC_No == jcno && t.Branch_Name == Branch && t.Ms_Status == "CLOSE");

  //                          dsr4.Ms_Status = "OPEN";
  //                          db.SaveChanges();
  //                      }
  //                  }

  //                  var ds1 = from c in db.AME_Service_JobcardFinalInvoice.Where(t => t.FI_JcNo == jcno && t.Branch_Name == Branch && t.FI_Status == "CLOSE" && t.jc_year == txt_year.Text.Trim()) select c;

  //                  if (ds1.Count() > 0)
  //                  {

  //                      foreach (var c in ds1)
  //                      {
  //                          AME_Service_JobcardFinalInvoice dsr5 = db.AME_Service_JobcardFinalInvoice.First(t => t.FI_JcNo == jcno && t.Branch_Name == Branch && t.jc_year == txt_year.Text.Trim() && t.FI_Status == "CLOSE");
  //                          dsr5.FI_Status = "CANCEL";
  //                          db.SaveChanges();
  //                      }
  //                  }

  //                  var ds2 = from c in db.AME_Service_JobcardFinalPaymentDetails.Where(t => t.FI_JcNo == jcno && t.Branch_Name == Branch && t.FIP_Status == "CLOSE" && t.jc_year == txt_year.Text.Trim()) select c;

  //                  if (ds2.Count() > 0)
  //                  {

  //                      AME_Service_JobcardFinalPaymentDetails dsr6 = db.AME_Service_JobcardFinalPaymentDetails.First(t => t.FI_JcNo == jcno && t.Branch_Name == Branch && t.jc_year == txt_year.Text.Trim() && t.FIP_Status == "CLOSE");
  //                      dsr6.FIP_Status = "CANCEL";
  //                      db.SaveChanges();
  //                  }

  //                  var ds3 = from c in db.AME_Service_JobcardProformaInvoice.Where(t => t.PI_JcNo == jcno && t.Branch_Name == Branch && t.PI_Status == "CLOSE" && t.jc_year == txt_year.Text.Trim()) select c;

  //                  if (ds3.Count() > 0)
  //                  {

  //                      AME_Service_JobcardProformaInvoice dsr7 = db.AME_Service_JobcardProformaInvoice.First(t => t.PI_JcNo == jcno && t.Branch_Name == Branch && t.jc_year == txt_year.Text.Trim() && t.PI_Status == "CLOSE");
  //                      dsr7.PI_Status = "OPEN";
  //                      db.SaveChanges();
  //                  }

  //                  var ds4 = from c in db.AME_Service_JobcardProformaPaymentDetails.Where(t => t.PI_JcNo == jcno && t.Branch_Name == Branch && t.PIP_Status == "CLOSE" && t.jc_year == txt_year.Text.Trim()) select c;
  //                  if (ds4.Count() > 0)
  //                  {
  //                      AME_Service_JobcardProformaPaymentDetails dsr8 = db.AME_Service_JobcardProformaPaymentDetails.First(t => t.PI_JcNo == jcno && t.Branch_Name == Branch && t.jc_year == txt_year.Text.Trim() && t.PIP_Status == "CLOSE");
  //                      dsr8.PIP_Status = "OPEN";
  //                      db.SaveChanges();
  //                  }

  //                  var ds5 = from c in db.AME_Service_JobCardOutside_Service.Where(t => t.JC_No == jcno && t.Branch_Name == Branch && t.Ms_Status == "CLOSE") select c;
  //if (ds5.Count() > 0)
  //{



  //    AME_Service_JobCardOutside_Service dsr9 = db.AME_Service_JobCardOutside_Service.First(t => t.JC_No == jcno && t.Branch_Name == Branch && t.Ms_Status == "CLOSE");
  //    dsr9.Ms_Status = "OPEN";
  //    db.SaveChanges();
  //}












                        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Bill Canceled Sucessfully..!!');", true);
                        fillgrid();


                        break;
                    
                }
            }

        }
        catch
        {

        }
    }
  
}
