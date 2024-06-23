using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
public partial class Admin_Rpurchase : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    public string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txt_FromDate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
            txt_ToDate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
            FillGrid1();

        }

    }

    double tot1 = 0, tot2 = 0, tot3 = 0, tot4 = 0;
    //double vat14p, vat5p, vat2p;
    private void FillGrid1()
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

        string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy" };
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


        DateTime fromDate = Convert.ToDateTime(txt_FromDate.Text,SmitaClass.dateformat());
        DateTime toDate = Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat());
            string Branch = Session["Branch"].ToString();
       
        var data = (from c in db.AME_Spare_PurchaseEntryBillDetails.ToList()
                    join d in db.AME_Master_Supplier on c.Sp_SupplierCode equals d.Ms_code
                    join e in db.AME_Spare_PurchaseEntry on c.Sp_VoucherNo equals e.Sp_VoucherNo
                    where
                    Convert.ToDateTime(c.Created_Date, SmitaClass.dateformat()) >= fromDate
                    && Convert.ToDateTime(c.Created_Date, SmitaClass.dateformat()) <= toDate
                    && c.Branch_Name==Branch
                    && c.Sp_SupplierCode == d.Ms_code
                   && e.Branch_Name == Branch
                    select new
                    {
                        Sp_VoucherNo = e.Sp_VoucherNo,
                        Sp_InvoiceNo = c.Sp_InvoiceNo,
                        Sp_InvoiceDate = c.Sp_InvoiceDate,
                        Ms_Name = d.Ms_Name,
                        Sp_GrossAmount = c.Sp_GrossAmount,
                        Sp_Discount = c.Sp_Discount,
                        Ss_Vat14 = e.Ss_Vat,
                        Ss_Vat5 = e.Ss_Vat,
                        Ss_Vat2 = e.Ss_Vat,
                        Sp_VatAmount = e.Ss_TaxAmont,
                        Sp_TotalAmount = c.Sp_TotalAmount,
                        Sp_PackagingAmount = c.Sp_PackagingAmount,
                        Sp_OtherAmount = c.Sp_OtherAmount,
                        Sp_BillAmount = c.Sp_BillAmount
                        //Sp_VoucherNo = e.Sp_VoucherNo,
                        //Sp_InvoiceNo = c.Sp_InvoiceNo,
                        //Sp_InvoiceDate = c.Sp_InvoiceDate,
                        //Ms_Name = d.Ms_Name,
                        //Sp_GrossAmount = c.Sp_GrossAmount,
                        //Sp_Discount = c.Sp_Discount,
                        //Ss_Vat14 = e.Ss_Vat,
                        //Ss_Vat5 = e.Ss_Vat,
                        //Ss_Vat2 = e.Ss_Vat,
                        //Sp_VatAmount = c.Sp_VatAmount,
                        //Sp_TotalAmount = c.Sp_TotalAmount,
                        //Sp_PackagingAmount = c.Sp_PackagingAmount,
                        //Sp_OtherAmount = c.Sp_OtherAmount,
                        //Sp_BillAmount = c.Sp_BillAmount
                        //c.Su_Code,
                        //c.Opening_Balance,
                        //c.Trans_Details,
                        //c.Debited_Amount,
                        //c.Credited_Amount,
                        //c.Closing_Balance,
                        //c.Trans_Date,
                        //c.Trans_Id,
                        //Su_Name = d.Std_fname + "  " + d.Std_lname,

                    }).ToList();
        if (Convert.ToInt32(data.Count()) > 0)
        {
            GridView1.DataSource = data.ToList();
            GridView1.DataBind();

            foreach (GridViewRow gr in GridView1.Rows)
            {
                Label vatamound = (Label)gr.FindControl("lbl006");
                Label vat14 = (Label)gr.FindControl("lblvat14");
                Label vat5 = (Label)gr.FindControl("lblvat5");
                Label vat2 = (Label)gr.FindControl("lblvat2");
                double vatAmt = Convert.ToDouble(vatamound.Text);
                double vat14p = Convert.ToDouble(vat14.Text);
                double vat5p = Convert.ToDouble(vat5.Text);
                double vat2p = Convert.ToDouble(vat2.Text);

                if (vat14p == 14.50)
                {

                    tot2 = tot2 + vatAmt;
                    Label LabelF2 = (Label)gr.FindControl("lblvat14");
                   // Label LabelF2 = (Label)GridView1.FooterRow.FindControl("lblvat14");
                    double displayclosing = Math.Abs(tot2);
                    LabelF2.Text = displayclosing.ToString();
                    Label LabelF3 = (Label)gr.FindControl("lblvat5");

                    LabelF3.Text ="0.00";

                    Label LabelF11 = (Label)gr.FindControl("lblvat2");
                    LabelF11.Text = "0.00";

                }
                else if (vat5p == 5.00)
                {
                    tot3 = tot3 + vatAmt;
                    Label LabelF3 = (Label)gr.FindControl("lblvat5");

                   // Label LabelF3 = (Label)GridView1.FooterRow.FindControl("lblvat5");


                    double pay = Math.Abs(tot3);
                    LabelF3.Text = pay.ToString("0.00");


                    Label LabelF2 = (Label)gr.FindControl("lblvat14");

                    LabelF2.Text = "0.00";

                    Label LabelF11 = (Label)gr.FindControl("lblvat2");
                    LabelF11.Text = "0.00";

                }
                else if(vat2p == 2.00)
                {
                    tot4 = tot4 + vatAmt;
                    Label LabelF11 = (Label)gr.FindControl("lblvat2");

                    double clo = Math.Abs(tot4);
                    //Label LabelF11 = (Label)GridView1.FooterRow.FindControl("lblvat2");

                    LabelF11.Text = clo.ToString("0.00");


                    Label LabelF3 = (Label)gr.FindControl("lblvat5");

                    LabelF3.Text = "0.00";

                    Label LabelF2 = (Label)gr.FindControl("lblvat14");
                    LabelF2.Text = "0.00";

                }
               
                //decimal rest = tot3 - tot2;

               // Label LabelF2 = (Label)GridView1.FooterRow.FindControl("lblvat14");
              //  Label LabelF3 = (Label)GridView1.FooterRow.FindControl("lblvat5");
              //  Label LabelF11 = (Label)GridView1.FooterRow.FindControl("lblvat2");
                // LabelF11.Text = rest.ToString("0.00");
                // lbl_pmnt.Text = rest.ToString("0.00");
                // LabelF11.Text = Convert.ToString(AmlanClass.SignificantTruncate(tot4, 2));
                //double clo = Math.Abs(tot4);
                //LabelF11.Text = clo.ToString("0.00");

                //double pay = Math.Abs(tot3);
                //LabelF3.Text = pay.ToString("0.00");
                //  lbl_pmnt.Text = Convert.ToString(AmlanClass.SignificantTruncate(tot4, 2));
                //double displayclosing = Math.Abs(tot2);
                //LabelF2.Text = displayclosing.ToString();

                
            }
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }

    }
    protected void btn_Show_Click(object sender, EventArgs e)
    {
        FillGrid1();
    }
    protected void btn_excel_Click(object sender, EventArgs e)
    {
        if (GridView1.Rows.Count <= 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('There Is No Data To Download..!!');", true);

            return;
        }
        else
        {

            string Branch = Session["Branch"].ToString();
            string attachment = "attachment; filename=" + "PurchaseEntryList" + "(" + Branch + ")" + ".xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            HtmlForm frm = new HtmlForm();
            GridView1.Parent.Controls.Add(frm);
            frm.Attributes["runat"] = "server";
            frm.Controls.Add(GridView1);
            frm.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
    }
}