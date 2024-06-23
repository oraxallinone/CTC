using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
using System.Data;
public partial class Admin_Counter_BillCancel : System.Web.UI.Page
{

    AutoMobileEntities db = new AutoMobileEntities();
    Clear cl = new Clear();
    public string uname;
    decimal tot1 = 0, tot2 = 0, tot3 = 0, tot4 = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null )
        {
            Response.Redirect("AccessDenied.aspx");
        }
        if (!IsPostBack)
        {
            string VNo = Request.QueryString["id"];
            

            filldata( VNo);
            //FillGrid();
           
        }
    }
    public void filldata( string VcNO)
    {
     
        string VouNo = Convert.ToString(VcNO);
        var v = from c in db.AME_Spare_SalesEntryBillDetails.ToList().Where(t => t.Sp_InvoiceNo == VouNo && t.Branch_Name == Session["Branch"].ToString()) select c;
        txt_BVoucherNo.Text = Convert.ToString(v.First().Sp_InvoiceNo);
        txt_BDate.Text = Convert.ToDateTime(v.First().Sp_InvoiceDate).ToString("dd/MM/yyyy");
        ddl_BSaleBy.SelectedValue = Convert.ToString(v.First().Sp_SaleBy);
        ddl_BSaleType.SelectedValue = v.First().Sp_SaleType;
        txt_BChalanNo0.Text = v.First().Sp_ChalanNo;
        txt_BChallanDate.Text = Convert.ToDateTime(v.First().Sp_ChalanDate).ToString("dd/MM/yyyy");
        //txt_BOrderNo.Text = Convert.ToString(v.First().Sp_OrderNo);
        //txt_BOrderDate.Text = Convert.ToDateTime(v.First().Sp_InvoiceDate).ToString("dd/MM/yyyy");
        ddl_invtype.SelectedValue = Convert.ToString(v.First().Sp_InvoiceType);
        txt_BTinSrinNo.Text = v.First().Sp_Mc_Tin;
        txt_BName.Text = v.First().Sp_Mc_Name;
        txt_BName.ToolTip = v.First().Sp_Mc_code;
        txt_tooltip.Text = v.First().Sp_Mc_code;
        txt_AGrossAmount.Text = Convert.ToString(v.First().Sp_GrossAmount);
        txt_ADiscountAmount.Text = Convert.ToString(v.First().Sp_Discount);
        txt_ANetAmount.Text = Convert.ToString(v.First().Sp_NetAmount);
        txt_AVatAmount.Text = Convert.ToString(v.First().Sp_VatAmount);
        txt_ATotal.Text = Convert.ToString(v.First().Sp_TotalAmount);
        txt_APackagingAmt.Text = Convert.ToString(v.First().Sp_PackagingAmount);
        txt_AOtherAmt.Text = Convert.ToString(v.First().Sp_OtherAmount);
        txt_AFinalAmount.Text = Convert.ToString(v.First().Sp_FinalAmount);
        string year = v.First().jc_year;

        ViewState["jcyear"] = year;
        var details = (from c in db.AME_Spare_SalesEntry.ToList()
                       where c.Sp_InvoiceNo == VouNo && c.jc_year.Equals(year) && c.Branch_Name == Session["Branch"].ToString()
                       select c);
        GridView2.DataSource = details.ToList();
        GridView2.DataBind();

    }
    private void FillGrid()
    {
        string year1 = ViewState["jcyear"].ToString();
        string VNo = Convert.ToString(Request.QueryString["No"]);
        var details = (from c in db.AME_Spare_SalesEntry.ToList()
                       where c.Sp_InvoiceNo == VNo && c.Ss_Status == "SE"
                       && c.Branch_Name == Session["Branch"].ToString()

                       && c.jc_year == year1
                       select c);
        GridView2.DataSource = details.ToList();
        GridView2.DataBind();

        foreach (GridViewRow gr in GridView2.Rows)
        {
            Label lbl_Amount = (Label)gr.FindControl("Label13");
            decimal TotAmt = Convert.ToDecimal(lbl_Amount.Text);

            Label lbl_Discount = (Label)gr.FindControl("Label15");
            decimal TotDiscount = Convert.ToDecimal(lbl_Discount.Text);

            Label lbl_TaxAmt = (Label)gr.FindControl("Label17");
            decimal TaxAmt = Convert.ToDecimal(lbl_TaxAmt.Text);

            Label lbl_Total = (Label)gr.FindControl("Label18");
            decimal Total = Convert.ToDecimal(lbl_Total.Text);

            tot1 = tot1 + TotAmt;
            tot2 = tot2 + TotDiscount;
            tot3 = tot3 + TaxAmt;
            tot4 = tot4 + Total;

            txt_AGrossAmount.Text = Convert.ToString(SmitaClass.SignificantTruncate(tot1, 2));
            txt_ADiscountAmount.Text = Convert.ToString(SmitaClass.SignificantTruncate(tot2, 2));
            txt_ANetAmount.Text = Convert.ToString(Convert.ToDecimal(txt_AGrossAmount.Text) - Convert.ToDecimal(txt_ADiscountAmount.Text));
            txt_AVatAmount.Text = Convert.ToString(SmitaClass.SignificantTruncate(tot3, 2));
            txt_ATotal.Text = Convert.ToString(SmitaClass.SignificantTruncate(tot4, 2));
            txt_AFinalAmount.Text = Convert.ToString(Convert.ToDecimal(txt_ATotal.Text) + Convert.ToDecimal(txt_APackagingAmt.Text) + Convert.ToDecimal(txt_AOtherAmt.Text));
        }
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {


            foreach (GridViewRow gr in GridView2.Rows)
            {
                Label lbl_id = (Label)gr.FindControl("lbl_ss_ID");
                Label lbl_partno = (Label)gr.FindControl("Label10");
                Label lbl_partDesc = (Label)gr.FindControl("Label12");
                Label lbl_Quantity = (Label)gr.FindControl("Label11");
                Label lbl_Rate = (Label)gr.FindControl("Label14");
                Label lbl_Amount = (Label)gr.FindControl("Label13");
                Label lbl_Discount = (Label)gr.FindControl("Label15");
                Label lbl_Vat = (Label)gr.FindControl("Label16");
                Label lbl_TaxAmt = (Label)gr.FindControl("Label17");
                Label lbl_Total = (Label)gr.FindControl("Label18");
                Label lbl_cat = (Label)gr.FindControl("Label19");
                Label lbl_year = (Label)gr.FindControl("Label20");


                AME_Spare_SaleReturn ob = new AME_Spare_SaleReturn();

                ob.Sp_Id = Convert.ToInt16(lbl_id.Text);
                ob.Sp_InvoiceNo = txt_BVoucherNo.Text;
                ob.Sp_PartyCode = txt_tooltip.Text;
                ob.Itm_Partno = lbl_partno.Text;
                ob.Itm_PartDescrption = lbl_partDesc.Text;
                ob.Ss_Rate = Convert.ToDecimal( lbl_Rate.Text);
                ob.Ss_Quantity = Convert.ToDecimal(lbl_Quantity.Text);
                ob.Ss_ReturnQuantity = Convert.ToDecimal(lbl_Quantity.Text);
                ob.Ss_Amount = Convert.ToDecimal(lbl_Amount.Text);
                ob.Ss_Discount = Convert.ToDecimal(lbl_Discount.Text);
                ob.Ss_Vat = Convert.ToDecimal(lbl_Vat.Text);
                ob.Ss_TaxAmont = Convert.ToDecimal(lbl_TaxAmt.Text);
                ob.Ss_Total = Convert.ToDecimal(lbl_Total.Text);
                ob.Sales_ReturnDate = Convert.ToDateTime(txt_returndate.Text,SmitaClass.dateformat());
                ob.Status = true;
                ob.Branch_Name = Session["Branch"].ToString();
                ob.Created_By = Session["Uid"].ToString();
                ob.Created_Date = SmitaClass.IndianTime();
                db.AddToAME_Spare_SaleReturn(ob);
                db.SaveChanges();
                

              
                decimal vat = Convert.ToDecimal(lbl_Vat.Text);
                int sid=Convert.ToInt16(lbl_id.Text);
                AME_Spare_SalesEntry pe = db.AME_Spare_SalesEntry.Where(t => t.Ss_Id == sid).First();
                pe.Sp_InvoiceNo = txt_BVoucherNo.Text;
                pe.Itm_Partno = lbl_partno.Text;
                pe.Itm_PartDescrption = lbl_partDesc.Text;
              
                    pe.Ss_Quantity = 0;
                
                pe.Ss_Rate = 0;
                // pe.jc_year = txt_year.Text.Trim();

                pe.Ss_Amount = 0;
                pe.Ss_Discountper = 0;
                pe.Ss_Discount = 0;
                pe.Ss_Vat = 0;
                pe.Ss_TaxAmont = 0;
                pe.Ss_Total = 0;
                pe.Ss_Status = "SERETURN";
                pe.Status = false;
             
                pe.Branch_Name = Session["Branch"].ToString();
                pe.Created_By = Session["Uid"].ToString();
                pe.Created_Date = SmitaClass.IndianTime();
              
                db.SaveChanges();




               

                string[] CWParam1 = { "@Branch", "@Req_Qntity", "@ItmPartno" };
                string[] CWParamValue1 = { Session["Branch"].ToString(), lbl_Quantity.Text, lbl_partno.Text };



                smitaDbAccess.insertprocedurestockcoma("Sp_StockdispatchInSpareIssue1", CWParam1, CWParamValue1);


                



            }


            string Bname = Session["Branch"].ToString();


            AME_Spare_SalesEntryBillDetails pd = db.AME_Spare_SalesEntryBillDetails.First(t => t.Sp_InvoiceNo == txt_BVoucherNo.Text && t.Branch_Name == Bname);
            pd.Sp_InvoiceDate = Convert.ToDateTime(txt_BDate.Text, SmitaClass.dateformat());

            pd.Sp_GrossAmount = 0;
            pd.Sp_Discount = 0;
            pd.Sp_NetAmount =0;
            pd.Sp_VatAmount = 0;
            pd.Sp_TotalAmount = 0;
            pd.Sp_PackagingAmount = 0;
            pd.Sp_OtherAmount = 0;
            pd.Sp_FinalAmount = 0;



            pd.Branch_Name = Session["Branch"].ToString();
            pd.Created_By = Session["Uid"].ToString();
            pd.Created_Date = SmitaClass.IndianTime();
            db.SaveChanges();
           
            AME_Daily_SpareSales_Report chan = db.AME_Daily_SpareSales_Report.First(t => t.DR_InvoiceNo == txt_BVoucherNo.Text && t.Branch_Name == Bname );

            chan.Dr_InvoiceTotal = 0;
            chan.Dr_Output13_5 = 0;
            chan.Dr_Spare13_5 = 0;
            chan.DR_InvType = "CANCEL";
            chan.Dr_Spare5 = 0;
            chan.Dr_Lub13_5 = 0;
            chan.Dr_Lub5 = 0;
            chan.Dr_DiscountAmount3_5 = 0;
            chan.Dr_DiscountAmount5 = 0;
            chan.Dr_Output5 = 0;
            chan.Dr_OtherCharges = 0;
            chan.Dr_InvoiceTotal = 0;
            db.SaveChanges();


            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Bill Cancel  done SuccessFully..!!'); </script>", false);


            GridView2.DataSource = null;
            GridView2.DataBind();
            cl.Clear_All(this);
        
        }

        catch (Exception ex)
        { }






    }
}