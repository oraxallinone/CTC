using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
using System.Data;

public partial class Admin_Vehicle_SalesInvoicePrint : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    public string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                string sino = Request.QueryString["id"];
                filldata(sino);
            }
            else
            {
                Server.Transfer("AccessDenied.aspx");
            }

        }
    }
    public void filldata(string sino)
    {

        string branchname = Session["Branch"].ToString();
        var SalesList = from c in db.AME_Vehicle_SaleEntryDetails
                        join d in db.AME_Master_Customer on c.Vq_PartyName equals d.Mc_Id
                        where c.Vs_Billno == sino && c.Branch_Name == branchname
                        select new { c, d };

        lbl_InvoiceNo.Text = SalesList.First().c.Vs_Billno;
        lbl_InvoiceDate.Text = SalesList.First().c.Vs_Billdate.ToString("dd/MM/yyyy");
        lbl_Name.Text = SalesList.First().d.Mc_Name;
        lbl_Address.Text = SalesList.First().c.Vq_Address;
        if (SalesList.First().c.Vs_InvType == "Vehicle_TaxSales")
        {
            lbl_BillType.Text = "TAX INVOICE";
            lbl_TinNo.Text = "TIN NO: "+SalesList.First().c.Vs_TinNo;
        }
        else
        {
            lbl_BillType.Text = "RETAIL INVOICE";
        }
        lbl_hyp.Text = SalesList.First().c.Vs_Hyp;


        var vehdtl = from c in db.AME_Vehicle_SaleEntry.ToList()
                     join d in db.AME_Master_VehicleModel on c.Mv_ModelName equals d.Mv_Id
                     where c.Vs_Billno == sino && c.Branch_Name == branchname
                     select new { c, d };

        lbl_Particulars.Text = vehdtl.First().d.Mv_ModelName;
        lbl_Qty.Text = Convert.ToString(vehdtl.First().c.Vse_Quantity);
        lbl_Amount.Text = Convert.ToString(vehdtl.First().c.Vse_Amount);
        lbl_Make.Text = vehdtl.First().c.Mv_Makers;
        lbl_Model.Text = vehdtl.First().d.Mv_ModelName;
        lbl_ChasisNo.Text = vehdtl.First().c.Vp_Chassisno;
        lbl_EngineNo.Text = vehdtl.First().c.Vp_Engineno;
        lbl_BatteryNo.Text = vehdtl.First().c.Vse_BatteryDetails;
        lbl_Type.Text = vehdtl.First().c.Vse_TyreMake;


        lbl_BeforeTax.Text = Convert.ToString(vehdtl.First().c.Vse_Amount);
        lbl_vatPer.Text = Convert.ToString(vehdtl.First().c.Vse_VatPercent);
        lbl_TaxAmount.Text = Convert.ToString(vehdtl.First().c.Vse_VatAmount);
        lbl_OtherCharges.Text = Convert.ToString(vehdtl.First().c.Vse_Other);
        lbl_BillAmount.Text = Convert.ToString(vehdtl.First().c.Vse_Billamount);
        lbl_NetPaybleAmount.Text = Convert.ToString(vehdtl.First().c.Vse_Billamount);

        double grandtotal = Convert.ToDouble(lbl_NetPaybleAmount.Text);
        double left = System.Math.Floor(grandtotal);
        double right = grandtotal - left;
        int firstValue = Convert.ToInt32(left);
        int secondValue = Convert.ToInt32(right);
        lbl_AmountInText.Text = " " + "&nbsp;&nbsp;" + SmitaClass.NumberToWords(firstValue) +" And "+SmitaClass.NumberToWords(secondValue)+"Paisa  Only";
        
    }
}