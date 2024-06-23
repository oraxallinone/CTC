using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
using System.Data;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;

public partial class Admin_Spare_PurchaseTransfer_Edit : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    Clear cl = new Clear();
    public string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            filldata();
        }
    }


    [System.Web.Services.WebMethod]
    public static string[] Getyear(string prefixText, int count)
    {

        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_FinacialYear.Where(n => n.finacialyear.Contains(prefixText)).OrderBy(n => n.finacialyear).Select(n => n.finacialyear).Distinct().Take(count).ToArray();
    }
    [System.Web.Services.WebMethod]
    public static string[] GetPartNo(string prefixText, int count)
    {
        string branch = HttpContext.Current.Session["Branch"].ToString();
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Master_Item.Where(n => n.Itm_Partno.Contains(prefixText) && n.Branch_Name == branch).OrderBy(n => n.Itm_Partno).Select(n => n.Itm_Partno).Distinct().Take(count).ToArray();
    }

    [System.Web.Services.WebMethod]
    public static string[] GetPartDesc(string prefixText, int count)
    {
        string branch = HttpContext.Current.Session["Branch"].ToString();
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Master_Item.Where(n => n.Itm_PartDescrption.Contains(prefixText) && n.Branch_Name == branch).OrderBy(n => n.Itm_PartDescrption).Select(n => n.Itm_PartDescrption).Distinct().Take(count).ToArray();
    }

    [System.Web.Services.WebMethod]
    public static string[] GetCustomers(string country)
    {
        string[] det = { };
        string query = string.Format("SELECT [Itm_Partno], [Itm_PartDescrption]," +
                 " [Itm_SalePrice], [Itm_VatPercent] From AME_Master_Item" +
                   "WHERE Itm_Partno = '0'", country);

        using (SqlConnection con =
                new SqlConnection("data source=.;initial catalog=AutoMobile; integrated security=true;"))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string partno = reader.GetString(0);
                    string PartDes = reader.GetString(1);
                    string SalePrice = reader.GetString(2);
                    string VatPercent = reader.GetString(3);
                    det[0] = partno;
                    det[1] = PartDes;
                    det[2] = SalePrice;
                    det[3] = VatPercent;

                }
            }
        }
        return det.ToArray();
    }



    public void filldata()
    {
        string branchname = Session["Branch"].ToString();
        txt_frombranch.Text = branchname;
        txt_frombranch.ReadOnly = true;
        var branchdetails = from c in db.AME_Branch_Creation.Where(t => t.Branch_Name != branchname)
                            select new
                            {
                                id = c.Branch_Id,
                                name = c.Branch_Name
                            };
        ddl_tobranch.DataValueField = "name";
        ddl_tobranch.DataTextField = "name";

        ddl_tobranch.DataSource = branchdetails.ToList();
        ddl_tobranch.DataBind();
        ddl_tobranch.Items.Insert(0, "~Select~");

        txt_transferdate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
        txt_BLrDate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
        txt_BOrderDate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
    }
  

    //private void FillInvoiceNo()
    //{
    //    string branchname = Session["Branch"].ToString();
    //    if ((from c in db.AME_BillCounter where c.Branch_Name == branchname && c.BillType == InvType select c.BillCounter).Count() > 0)
    //    {
    //        int VNo = (int)(from c in db.AME_BillCounter where c.Branch_Name == branchname && c.BillType == InvType select c.BillCounter).Max();
    //        if (ddl_invtype.SelectedItem.Text == "Tax Invoice")
    //        {
    //            txt_invno.Text = "T/" + Convert.ToString(VNo + 1);
    //        }
    //    }
    //    else
    //    {
    //        txt_invno.Text = "Error";
    //    }
    //}
    private void Fillvoucher()
    {
        string branchname = Session["Branch"].ToString();
        string uname = Session["Uid"].ToString();
        int vouvher = Convert.ToInt32(txt_BVoucherNo.Text.Trim());
        //var v = from c in db.AME_Spare_PurchaseEntryBillDetails.Where(t => t.Sp_VoucherNo == vouvher && t.Created_By == uname && t.jc_year == txt_year.Text.Trim() && t.Status == false && t.Sp_SupplierCode == branchname) select c;

        var v = from c in db.AME_Spare_PurchaseEntryBillDetails.Where(t => t.Sp_VoucherNo == vouvher &&  t.jc_year == txt_year.Text.Trim() && t.Status == false && t.Sp_SupplierCode == branchname) select c;
        if (Convert.ToInt32(v.Count()) > 0)
        {
            string tobra = v.First().Branch_Name.ToString();
            ddl_tobranch.SelectedValue = tobra;
            txt_BinvoiceNo.Text = v.First().Sp_InvoiceNo;
            txt_BLrNo.Text = v.First().Sp_LrNo;
            txt_BLrDate.Text = Convert.ToDateTime(v.First().Sp_LrDate).ToString("dd/MM/yyyy");
            txt_BOrderDate.Text = Convert.ToDateTime(v.First().Sp_OrderDate).ToString("dd/MM/yyyy");
            txt_AGrossAmount.Text = v.First().Sp_GrossAmount.ToString();
            txt_ADiscountAmount.Text = v.First().Sp_Discount.ToString();
            txt_ANetAmount.Text = v.First().Sp_NetAmount.ToString();
            txt_AVatAmount.Text = v.First().Sp_VatAmount.ToString();
            txt_ATotal.Text = v.First().Sp_TotalAmount.ToString();
            txt_APackagingAmt.Text = v.First().Sp_PackagingAmount.ToString();
            txt_AOtherAmount.Text = v.First().Sp_OtherAmount.ToString();
            txt_ABillAmount.Text = v.First().Sp_BillAmount.ToString();
            txt_frombranch.Text = v.First().Sp_SupplierCode.ToString();

        }
        else
        {

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Record Not Found..!!'); </script>", false);
           
            return;
        }
    }
    protected void txt_PartNo_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string branchname = Session["Branch"].ToString();
            var v = from k in db.AME_Master_Item.ToList()
                    where (k.Itm_Partno.Equals(txt_PartNo.Text) && k.Branch_Name == branchname)
                    select new
                    {
                        k.Itm_Partno,
                        k.Itm_PartDescrption,
                        k.Itm_SalePrice,
                        k.Itm_VatPercent
                    };

            txt_PartNo.Text = v.First().Itm_Partno;
            txt_PartDesc.Text = Convert.ToString(v.First().Itm_PartDescrption);
            decimal rate = v.First().Itm_SalePrice;
            //txt_rate.Text = Convert.ToString(v.First().Itm_SalePrice);
            txt_vat.Text = "0";


            DataSet ds = smitaDbAccess.returndataset("select SUM(Ss_NetQuantity) AS NetQuantity FROM AME_Spare_PurchaseEntry WHERE Itm_Partno='" + txt_PartNo.Text + "' AND Branch_Name='" + Session["Branch"].ToString() + "'");
            if (ds.Tables[0].Rows[0].ItemArray[0].ToString() != "")
            {
                txt_avlquantity.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            else
            {
                txt_avlquantity.Text = "0";
            }
            decimal vat = Convert.ToDecimal(txt_vat.Text);
            //decimal rate = Convert.ToDecimal(txt_PartRate.Text);
            decimal temp = Convert.ToDecimal(rate / (100 + vat));
            //txt_PartAmount.Text = (temp * 100).ToString("0.00");
            txt_rate.Text = (temp * 100).ToString("0.00");


        }
        catch
        {
            txt_PartNo.Text = "";
            txt_PartDesc.Text = "";
            txt_rate.Text = "";
            txt_vat.Text = "";
            txt_transfer.Focus();
        }
    }
    protected void txt_PartDesc_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string branchname = Session["Branch"].ToString();
            var v = from k in db.AME_Master_Item.ToList()
                    where (k.Itm_PartDescrption.Equals(txt_PartDesc.Text) && k.Branch_Name == branchname)
                    select new
                    {
                        k.Itm_Partno,
                        k.Itm_PartDescrption,
                        k.Itm_SalePrice,
                        k.Itm_VatPercent
                    };

            txt_PartNo.Text = v.First().Itm_Partno;
            txt_PartDesc.Text = Convert.ToString(v.First().Itm_PartDescrption);
            txt_rate.Text = Convert.ToString(v.First().Itm_SalePrice);
            txt_vat.Text = Convert.ToString(v.First().Itm_VatPercent);

            DataSet ds = smitaDbAccess.returndataset("select SUM(Ss_NetQuantity) AS NetQuantity FROM AME_Spare_PurchaseEntry WHERE Itm_Partno='" + txt_PartNo.Text + "' AND Branch_Name='" + Session["Branch"].ToString() + "'");
            if (ds.Tables[0].Rows[0].ItemArray[0].ToString() != "")
            {
                txt_avlquantity.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            else
            {
                txt_avlquantity.Text = "0";
            }

        }
        catch
        {
            txt_PartNo.Text = "";
            txt_PartDesc.Text = "";
            txt_rate.Text = "";
            txt_vat.Text = "";
            txt_avlquantity.Focus();
        }
    }
    protected void btn_PartAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_BVoucherNo.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Voucher Number Should Not Be Blank..!!'); </script>", false);
                txt_BVoucherNo.Focus();
                return;
            }
            if (ddl_tobranch.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Select Supplier Name..!!'); </script>", false);
                ddl_tobranch.Focus();
                return;
            }
            if (txt_BinvoiceNo.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invoice Number Should Not Be Blank..!!'); </script>", false);
                txt_BinvoiceNo.Focus();
                return;
            }
            //if (txt_BInvoiceDate.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invoice Date Should Not Be Blank..!!'); </script>", false);
            //    txt_BInvoiceDate.Focus();
            //    return;
            //}

            //if (txt_BRcvDate.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Recieving Date Should Not Be Blank..!!'); </script>", false);
            //    txt_BRcvDate.Focus();
            //    return;
            //}
            if (txt_transferdate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('TransferDate Date Should Not Be Blank..!!'); </script>", false);
                txt_transferdate.Focus();
                return;
            }
            //////////////////////////////////

            if (txt_PartNo.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Part Number Should Not Be Blank..!!'); </script>", false);
                txt_PartNo.Focus();
                return;
            }
            if (txt_PartDesc.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Part Description Should Not Be Blank..!!'); </script>", false);
                txt_PartDesc.Focus();
                return;
            }

            if (txt_avlquantity.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Available Quantity Should Not Be Blank..!!'); </script>", false);
                txt_avlquantity.Focus();
                return;
            }
            if (txt_transfer.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Transfer Quantity Should Not Be Blank..!!'); </script>", false);
                txt_transfer.Focus();
                return;
            }
            if (txt_rate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Rate Should Not Be Blank..!!'); </script>", false);
                txt_rate.Focus();
                return;
            }
            if (txt_amount.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Amount Should Not Be Blank..!!'); </script>", false);
                txt_amount.Focus();
                return;
            }
            if (txt_discount.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Discount Should Not Be Blank..!!'); </script>", false);
                txt_discount.Focus();
                return;
            }
            if (txt_vat.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Vat Should Not Be Blank..!!'); </script>", false);
                txt_vat.Focus();
                return;
            }
            if (txt_taxamount.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Tax Amount Should Not Be Blank..!!'); </script>", false);
                txt_taxamount.Focus();
                return;
            }


            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy" };
            DateTime expectedDate;
            
            if (!DateTime.TryParseExact(txt_transferdate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                txt_transferdate.Focus();
                return;
            }
            int vouvher = Convert.ToInt32(txt_BVoucherNo.Text.Trim());
            string branchname = Session["Branch"].ToString();
            var v = from c in db.AME_Spare_PurchaseEntry.OrderBy(t => t.Itm_Partno).Where(t => t.Branch_Name == branchname && t.Itm_Partno == txt_PartNo.Text && t.Sp_VoucherNo==vouvher) select c;
            if (Convert.ToInt32(v.Count()) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('This Partno Already Exist,Please Add Different..!!');</script>", false);
                txt_PartNo.Text = "";
                txt_PartNo.Text = "";
                txt_rate.Text = "";
                txt_amount.Text = "";
                txt_vat.Text = "";
                txt_taxamount.Text = "";
                txt_total.Text = "";

                return;
            }
            AME_Spare_PurchaseEntry pr1 = new AME_Spare_PurchaseEntry();
            pr1.Sp_VoucherNo = Convert.ToInt32(txt_BVoucherNo.Text);
            pr1.Itm_Partno = txt_PartNo.Text;
            pr1.jc_year = txt_year.Text;
            pr1.Itm_PartDescrption = txt_PartDesc.Text;
            pr1.Ss_Quantity = Convert.ToDecimal(txt_transfer.Text);
            pr1.Ss_NetQuantity = Convert.ToDecimal(txt_transfer.Text);
            pr1.Ss_Rate = Convert.ToDecimal(txt_rate.Text);
            pr1.Ss_Amount = Convert.ToDecimal(txt_amount.Text);
            pr1.Ss_Discount = Convert.ToDecimal(txt_discount.Text);
            pr1.Ss_Vat = Convert.ToDecimal(txt_vat.Text);
            pr1.Ss_TaxAmont = Convert.ToDecimal(txt_taxamount.Text);
            pr1.Ss_Total = Convert.ToDecimal(txt_total.Text);
            pr1.Ss_Status = "PE";
            pr1.Status = false;
            pr1.Branch_Name = ddl_tobranch.SelectedItem.Text;
            pr1.Created_By = Session["Uid"].ToString();
            pr1.Created_Date = SmitaClass.IndianTime();
            db.AddToAME_Spare_PurchaseEntry(pr1);
            db.SaveChanges();
            string brn = Session["Branch"].ToString();
            string tobrn = ddl_tobranch.SelectedItem.Text;
            var v3 = from c in db.AME_Master_Item.Where(t => t.Branch_Name == tobrn && t.Itm_Partno == txt_PartNo.Text.Trim()) select c;
            if (Convert.ToInt32(v3.Count()) > 0)
            {
                //AME_Master_Item Ami = db.AME_Master_Item.First(t => t.Branch_Name == tobrn && t.Itm_Partno == lbl_partno.Text.Trim());

                //Ami.Itm_OpStock = Convert.ToDecimal(Ami.Itm_OpStock) + Convert.ToDecimal(lbl_TQuantity.Text);

                //db.SaveChanges();
            }
            else
            {
                var v2 = from c in db.AME_Master_Item.Where(t => t.Branch_Name == brn && t.Itm_Partno == txt_PartNo.Text.Trim()) select c;

                AME_Master_Item Ami = new AME_Master_Item();
                Ami.Branch_Name = tobrn;
                Ami.Created_By = Session["Uid"].ToString();
                Ami.Itm_VehicleType = v2.First().Itm_VehicleType;
                Ami.Created_Date = SmitaClass.IndianTime();
                Ami.Itm_CategoryName = v2.First().Itm_CategoryName;
                Ami.Itm_OpStock = Convert.ToDecimal(txt_transfer.Text);
                Ami.Itm_PartDescrption = txt_PartDesc.Text;
                Ami.Itm_Partno = txt_PartNo.Text;
                Ami.Itm_PurchasePrice = Convert.ToDecimal(v2.First().Itm_PurchasePrice);
                Ami.Itm_SalePrice = Convert.ToDecimal(v2.First().Itm_SalePrice);
                Ami.Itm_Selfno = v2.First().Itm_Selfno;
                Ami.Itm_Unit = v2.First().Itm_Unit;
                Ami.Itm_VatPercent = Convert.ToDecimal(txt_total.Text);
                Ami.Ms_Status = true;
                db.AddToAME_Master_Item(Ami);
                db.SaveChanges();
            }


            AME_SparepartsTransfer st = new AME_SparepartsTransfer();
            st.Branch_Name = Session["Branch"].ToString();
            st.Created_By = Session["Uid"].ToString();
            st.Created_Date = SmitaClass.IndianTime();
            st.Itm_Partno = txt_PartNo.Text;
            st.jc_year = txt_year.Text.Trim();
            st.St_FromBranch = txt_frombranch.Text;
            st.St_ToBranch = ddl_tobranch.SelectedItem.Text;
            st.St_Transferdate = Convert.ToDateTime(txt_transferdate.Text, SmitaClass.dateformat());
            st.St_TransferQuantity = Convert.ToDecimal(txt_transfer.Text);
            st.Status = "Receive Transfer";

            st.Voucher_No = txt_BVoucherNo.Text.Trim();
            st.Itm_PartDesc = txt_PartDesc.Text;
            st.St_Rate = Convert.ToDecimal(txt_rate.Text);
            st.St_Amount = Convert.ToDecimal(txt_total.Text);

            db.AddToAME_SparepartsTransfer(st);
            db.SaveChanges();


            string branch = Session["Branch"].ToString();
            decimal qntity = Convert.ToDecimal(txt_transfer.Text);
            string partno = txt_PartNo.Text;
            string param = "@Branch,@Req_Qntity,@ItmPartno";
            string paramvalue = branch + "," + qntity + "," + partno;
            smitaDbAccess.insertprocedure("Sp_StockdispatchInSpareIssue", param, paramvalue);

            FillGrid();

            txt_PartNo.Text = "";
            txt_PartDesc.Text = "";
            txt_transfer.Text = "";
            txt_rate.Text = "";
            txt_amount.Text = "";
            txt_discount.Text = "";
            txt_vat.Text = "";
            txt_taxamount.Text = "";
            txt_total.Text = "";
            txt_PartNo.Focus();
        }
        catch
        {

        }
    }
    decimal tot1 = 0, tot2 = 0, tot3 = 0, tot4 = 0;

    private void FillGrid()
    {
        string branchname = Session["Branch"].ToString();
        uname = Session["Uid"].ToString();

        int vouvher = Convert.ToInt32(txt_BVoucherNo.Text.Trim());
        var v1 = from d in db.AME_Spare_PurchaseEntry.Where(t => t.Sp_VoucherNo == vouvher && t.jc_year==txt_year.Text.Trim() && t.Status==false) select d;

        GridView2.DataSource = v1.ToList();
        GridView2.DataBind();

        foreach (GridViewRow gr in GridView2.Rows)
        {
            Label lbl_Amount = (Label)gr.FindControl("lbltotal");
            decimal TotAmt = Convert.ToDecimal(lbl_Amount.Text);

            Label lbl_Discount = (Label)gr.FindControl("lbldiscount");
            decimal TotDiscount = Convert.ToDecimal(lbl_Discount.Text);

            Label lbl_TaxAmt = (Label)gr.FindControl("lbltaxamount");
            decimal TaxAmt = Convert.ToDecimal(lbl_TaxAmt.Text);

            Label lbl_Total = (Label)gr.FindControl("lbltotal");
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
            txt_ABillAmount.Text = Convert.ToString(Convert.ToDecimal(txt_ATotal.Text) + Convert.ToDecimal(txt_APackagingAmt.Text) + Convert.ToDecimal(txt_AOtherAmount.Text));
        }
    }

    protected void imgbtn_PartDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img_delete = (ImageButton)sender;
        string branchname = Session["Branch"].ToString();
        int VNo = Convert.ToInt32(txt_BVoucherNo.Text);
        AME_Spare_PurchaseEntry pe = db.AME_Spare_PurchaseEntry.ToList().First(t => t.Sp_VoucherNo == VNo && t.Itm_Partno == img_delete.ToolTip && t.Branch_Name == branchname && t.jc_year==txt_year.Text);
        db.DeleteObject(pe);
        db.SaveChanges();
        FillGrid();
       
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        string branchname = Session["Branch"].ToString();
        if (txt_BVoucherNo.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Voucher Number Should Not Be Blank..!!'); </script>", false);
            txt_BVoucherNo.Focus();
            return;
        }
        if (ddl_tobranch.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Select Supplier Name..!!'); </script>", false);
            ddl_tobranch.Focus();
            return;
        }
        if (txt_BinvoiceNo.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invoice Number Should Not Be Blank..!!'); </script>", false);
            txt_BinvoiceNo.Focus();
            return;
        }
        
        if (txt_transferdate.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('TransferDate Date Should Not Be Blank..!!'); </script>", false);
            txt_transferdate.Focus();
            return;
        }
        if (txt_AGrossAmount.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Gross Amount Should Not Be Blank..!!'); </script>", false);
            txt_AGrossAmount.Focus();
            return;
        }
        if (txt_ADiscountAmount.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Discount Amount Should Not Be Blank..!!'); </script>", false);
            txt_ADiscountAmount.Focus();
            return;
        }
        if (txt_ANetAmount.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Net Amount Should Not Be Blank..!!'); </script>", false);
            txt_ANetAmount.Focus();
            return;
        }
        if (txt_AVatAmount.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Vat Amount Should Not Be Blank..!!'); </script>", false);
            txt_AVatAmount.Focus();
            return;
        }
        if (txt_ATotal.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Total Amount Should Not Be Blank..!!'); </script>", false);
            txt_ATotal.Focus();
            return;
        }
        if (txt_APackagingAmt.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Packaging Amount Should Not Be Blank..!!'); </script>", false);
            txt_APackagingAmt.Focus();
            return;
        }
        if (txt_AOtherAmount.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Other Amount Should Not Be Blank..!!'); </script>", false);
            txt_AOtherAmount.Focus();
            return;
        }
        if (txt_ABillAmount.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Bill Amount Should Not Be Blank..!!'); </script>", false);
            txt_ABillAmount.Focus();
            return;
        }
        string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy" };
        DateTime expectedDate;
      
        if (!DateTime.TryParseExact(txt_transferdate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
            txt_transferdate.Focus();
            return;
        }
        
        //if purchaseentry stock is transfer its staus is false otherwise true
        AME_Spare_PurchaseEntryBillDetails pd = new AME_Spare_PurchaseEntryBillDetails();
        pd.Sp_VoucherNo = Convert.ToInt32(txt_BVoucherNo.Text);
        pd.Sp_SupplierCode = ddl_tobranch.SelectedValue.ToString();
        pd.Sp_InvoiceNo = txt_BinvoiceNo.Text;
        pd.jc_year = txt_year.Text;
        // pd.Sp_InvoiceDate = Convert.ToDateTime(txt_BInvoiceDate.Text, SmitaClass.dateformat());
        //pd.Sp_ReceiptDate = Convert.ToDateTime(txt_BRcvDate.Text, SmitaClass.dateformat());
        pd.Sp_LrNo = txt_BLrNo.Text;
        if (txt_BLrDate.Text != "")
        {
            pd.Sp_LrDate = Convert.ToDateTime(txt_BLrDate.Text, SmitaClass.dateformat());
        }
        pd.Sp_OrderNo = txt_BOrderNo.Text;
        if (txt_BOrderDate.Text != "")
        {
            pd.Sp_OrderDate = Convert.ToDateTime(txt_BOrderDate.Text, SmitaClass.dateformat());
        }
        pd.Sp_GrossAmount = Convert.ToDecimal(txt_AGrossAmount.Text);
        pd.Sp_Discount = Convert.ToDecimal(txt_ADiscountAmount.Text);
        pd.Sp_NetAmount = Convert.ToDecimal(txt_ANetAmount.Text);
        pd.Sp_VatAmount = Convert.ToDecimal(txt_AVatAmount.Text);
        pd.Sp_TotalAmount = Convert.ToDecimal(txt_ATotal.Text);
        pd.Sp_PackagingAmount = Convert.ToDecimal(txt_APackagingAmt.Text);
        pd.Sp_OtherAmount = Convert.ToDecimal(txt_AOtherAmount.Text);
        pd.Sp_BillAmount = Convert.ToDecimal(txt_ABillAmount.Text);
        pd.Status = false;
        pd.Sp_SupplierCode = txt_frombranch.Text;
        pd.Branch_Name = ddl_tobranch.SelectedItem.Text;
        pd.Created_By = Session["Uid"].ToString();
        pd.Created_Date = SmitaClass.IndianTime();
        db.AddToAME_Spare_PurchaseEntryBillDetails(pd);
        db.SaveChanges();

        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Stock Transfer Update SuccessFully..!!'); </script>", false);
        cl.Clear_All(this);
        filldata();
        GridView2.DataSource = null;
        GridView2.DataBind();
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        cl.Clear_All(this);
    }




    protected void txt_APackagingAmt_TextChanged(object sender, EventArgs e)
    {
        decimal total = Convert.ToDecimal(txt_ATotal.Text);
        decimal package = Convert.ToDecimal(txt_APackagingAmt.Text);
        decimal other = Convert.ToDecimal(txt_AOtherAmount.Text);
        txt_ABillAmount.Text = Math.Round(total + package + other).ToString("0.00");
    }
    protected void txt_AOtherAmount_TextChanged(object sender, EventArgs e)
    {
        decimal total = Convert.ToDecimal(txt_ATotal.Text);
        decimal package = Convert.ToDecimal(txt_APackagingAmt.Text);
        decimal other = Convert.ToDecimal(txt_AOtherAmount.Text);
        txt_ABillAmount.Text = Math.Round(total + package + other).ToString("0.00");
    }

    protected void txt_BVoucherNo_TextChanged(object sender, EventArgs e)
    {
        if (txt_year.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Year SHOULD NOT BE BLANK...!!');", true);
            txt_year.Focus();
            return;
        }

        Fillvoucher();
        FillGrid();
    }
}