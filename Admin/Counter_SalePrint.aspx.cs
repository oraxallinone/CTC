﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
using System.Data;
public partial class Admin_Counter_SalePrint : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    public string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null || Request.QueryString["No"] == null)
        {
            Response.Redirect("AccessDenied.aspx");
        }
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                string sino = Request.QueryString["id"];
                string VNo = Request.QueryString["No"];
                string year = Request.QueryString["year"];


                filldata(sino, VNo, year);
            }
            else
            {
                Server.Transfer("AccessDenied.aspx");
            }

        }
    }

    decimal tot1 = 0;
    public void filldata(string sino, string VcNO, string year)
    {
        int id = Convert.ToInt32(sino);
        string VouNo = Convert.ToString(VcNO);

        var v = (from c in db.AME_Spare_SalesEntryBillDetails.ToList()
                 join d in db.AME_Master_Customer on c.Sp_Mc_code equals d.Mc_code
                 where c.Sp_Id == id && c.Branch_Name == Session["Branch"].ToString() && d.Branch_Name == Session["Branch"].ToString() && c.jc_year == year
                 select new { c, d }).Distinct().ToList();
        lbltinno.Text = "21041300795";
        //  lbl_BillNo.Text = Convert.ToString(v.First().c.Sp_InvoiceNo);

        // lbl_BillNo.Text = Convert.ToString(v.First().c.Sp_InvoiceNo);

        lbl_BillNo.Text = VouNo;

        lbl_BillDate.Text = Convert.ToDateTime(v.First().c.Sp_InvoiceDate).ToString("dd/MM/yyyy");
        lbl_Name.Text = v.First().d.Mc_Name;
        lbl_Address.Text = Convert.ToString(v.First().d.Mc_Address) + ", " + Convert.ToString(v.First().d.Mc_Mobileno);
        lbl_vehicle.Text = v.First().c.Sp_Vehicleno;
        lblsaleby.Text = v.First().c.Sp_SaleBy;
        if (v.First().c.Sp_InvoiceType == "Spare_TaxSales")
        {
            lbl_InvoiceType.Text = "TAX INVOICE";
            lbl_TinNo.Text = "TIN NO: " + v.First().d.Mc_Tin;
            if (v.First().c.Sp_SaleBy == "FOC")
            {

                Label1.Visible = true;
            }

        }
        else
        {
            lbl_InvoiceType.Text = "RETAIL INVOICE";
            Label1.Visible = false;
        }

        /////////////////GATE PASS
        lbl_BillNo0.Text = Convert.ToString(v.First().c.Sp_InvoiceNo);
        lbl_BillDate0.Text = Convert.ToDateTime(v.First().c.Sp_InvoiceDate).ToString("dd/MM/yyyy");
        lbl_Name0.Text = v.First().d.Mc_Name;
        lbl_Address0.Text = Convert.ToString(v.First().d.Mc_Address) + ", " + Convert.ToString(v.First().d.Mc_Mobileno);
        /////////////////////
        var details = (from c in db.AME_Spare_SalesEntry.ToList()
                       where c.Sp_InvoiceNo == VouNo && c.Branch_Name == Session["Branch"].ToString()
                       && c.jc_year == year
                       select c).Distinct().ToList();

        GridView2.DataSource = details.ToList();
        GridView2.DataBind();

        lbl_GrossAmount.Text = Convert.ToString(v.First().c.Sp_GrossAmount);
        lbl_DiscountAmount.Text = Convert.ToString(v.First().c.Sp_Discount);
        lbl_VatAmount.Text = Convert.ToString(v.First().c.Sp_VatAmount);
        lbl_PfAmount.Text = Convert.ToString(v.First().c.Sp_PackagingAmount);
        lbl_OtherCharges.Text = Convert.ToString(v.First().c.Sp_OtherAmount);
        lbl_net.Text = Convert.ToString(v.First().c.Sp_NetAmount);
        lbl_BillAmount.Text = (Math.Round(v.First().c.Sp_FinalAmount)).ToString("0.00");
        ///////////
        lbl_BillAmount0.Text = (Math.Round(v.First().c.Sp_FinalAmount)).ToString("0.00");

        double grandtotal = Convert.ToDouble(lbl_BillAmount.Text);
        double left = System.Math.Floor(grandtotal);
        double right = grandtotal - left;
        int firstValue = Convert.ToInt32(left);
        int secondValue = Convert.ToInt32(right);
        lbl_AmountInText.Text = " " + "&nbsp;&nbsp;" + SmitaClass.NumberToWords(firstValue) + "  Only";

        var zzz = from c in db.AME_Branch_Creation.ToList() where c.Branch_Name == Session["Branch"].ToString() select c;
        lbl_BranchAddress.Text = zzz.First().Branch_Address;
        lbl_brmail.Text = zzz.First().Branch_Email + ", " + zzz.First().Branch_PhoneNo;
    }
}