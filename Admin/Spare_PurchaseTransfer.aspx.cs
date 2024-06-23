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
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;
public partial class Admin_Spare_PurchaseEntry : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    static List<PartDetails> SPE = new List<PartDetails>();
    Clear cl = new Clear();
    public string uname;
    public static List<Item_Description_Details> lstItemDescList = new List<Item_Description_Details>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (FillInvoiceNosubmit())
            //{
            //    FillSupplier();
            //    // FillVoucherNo();
            //    SPE.RemoveAll(t => t.UserId == Session["Uid"].ToString());
            //    FillGrid();
            //    FillSlno();
            //    filldata();
            //}

            if (ViewState["ran_Key"] != null)
            {
                SPE.RemoveAll(t => t.key == ViewState["ran_Key"].ToString());
            }


            string ran_Key = CreateRandomPassword1(5);

            ViewState["ran_Key"] = ran_Key;


            var mx = SPE.ToList();
            int slmax = 0;

            if (DebasishGlobal.s6 > 0)
            {

                slmax = DebasishGlobal.s6 + 1;
                DebasishGlobal.s6 = slmax;
            }

            else
            {
                slmax = 1;
                DebasishGlobal.s6 = 1;
            }
            ViewState["maxs"] = Convert.ToString(slmax);

            txt_year.Text = "2018-19";
            vcoun();
        }
    }
    public static string CreateRandomPassword1(int PasswordLength)
    {
        string _allowedChars = "0123456789";
        Random randNum = new Random();
        char[] chars = new char[PasswordLength];
        int allowedCharCount = _allowedChars.Length;
        for (int i = 0; i < PasswordLength; i++)
        {
            chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
        }
        return new string(chars);
    }
    protected void vcoun()
    {
        string branch = HttpContext.Current.Session["Branch"].ToString();

        var asdf = from c in db.AME_SparepartsTransfer.Where(t => t.Branch_Name == branch && t.jc_year == txt_year.Text.Trim()) select c;
        if (asdf.Count() > 0)
        {
            FillInvoiceNosubmit();

            FillSupplier();
            // FillVoucherNo();
            // SPE.RemoveAll(t => t.UserId == Session["Uid"].ToString());
            FillGrid();
            FillSlno();
            filldata();

            // FillInvoiceNosubmit();
        }
        else
        {
            txt_BVoucherNo.Text = "1";
            txt_BinvoiceNo.Text = "R/1";
            //  SPE.RemoveAll(t => t.UserId == Session["Uid"].ToString());
            FillGrid();
            FillSlno();
            filldata();
        }

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
        ddl_tobranch.DataValueField = "id";
        ddl_tobranch.DataTextField = "name";

        ddl_tobranch.DataSource = branchdetails.ToList();
        ddl_tobranch.DataBind();
        ddl_tobranch.Items.Insert(0, "~Select~");

        txt_transferdate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
        txt_BLrDate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
        txt_BOrderDate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
    }
    private void FillSupplier()
    {
        var v = from c in db.AME_Master_Supplier.ToList()
                where c.Ms_Status = true && c.Branch_Name == Session["Branch"].ToString()
                select new
                {
                    Su_Name = c.Ms_Name,
                    Su_Code = c.Ms_code
                };
        ddl_tobranch.DataSource = v.ToList();
        ddl_tobranch.DataTextField = "Su_Name";
        ddl_tobranch.DataValueField = "Su_Code";
        ddl_tobranch.DataBind();
        ddl_tobranch.Items.Insert(0, "--Select One--");
    }
    private Boolean FillInvoiceNosubmit()
    {
        Boolean isupdae = true;
        string branchname = Session["Branch"].ToString();
        string year = txt_year.Text.Trim();
        if ((from c in db.AME_SparepartsTransfer where c.Branch_Name == branchname select c.Voucher_No).Count() > 0)
        {
            string param = "@Branch,@year";

            string paramvalue = branchname + "," + year;

            DataSet ds = smitaDbAccess.SPReturnDataSet("Getmaxinvoiceno_Spare_Transfer", param, paramvalue);
            int VNo = 0;
            try
            {
                VNo = int.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString());
            }
            catch (Exception)
            {
                isupdae = false;
                //throw;
            }
            //int VNo = (int)(from c in db.AME_BillCounter where c.Branch_Name == branchname && c.BillType == InvType select c.BillCounter).Max();
            if (isupdae == true)
            {

                txt_BVoucherNo.Text = Convert.ToString(VNo + 1);

                txt_BinvoiceNo.Text = "R/" + Convert.ToString(VNo + 1);

            }
        }
        else
        {
            txt_BVoucherNo.Text = "Error";
        }
        return isupdae;
    }



    private void FillVoucherNo()
    {
        string branchname = Session["Branch"].ToString();
        if ((from c in db.AME_SparepartsTransfer where c.Branch_Name == branchname select c.Voucher_No).Count() > 0)
        {
            var v = from c in db.AME_SparepartsTransfer
                    where c.Branch_Name == branchname

                    orderby c.Sr_id descending
                    select c.Voucher_No;


            //AME_SparepartsTransfer ST = (AME_SparepartsTransfer)v.ToList().Last();
            //  string ST = v.ToString();

            int VNo = (Convert.ToInt32(v.ToList().Last()));
            // int VNo = (Convert.ToInt32(v.ToArray()[0]));
            txt_BVoucherNo.Text = Convert.ToString(VNo + 1);
            txt_BinvoiceNo.Text = "R/" + Convert.ToString(VNo + 1);
        }
        else
        {
            txt_BVoucherNo.Text = "1";
            txt_BinvoiceNo.Text = "R/1";
        }
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
    private void FillSlno()
    {
        var v = SPE.ToList();
        if (v.Count() > 0)
        {
            txt_PartSlNo.Text = (v.Count() + 1).ToString();
        }
        else
        {
            txt_PartSlNo.Text = "1";
        }
    }
    protected void txt_PartNo_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string branchname = Session["Branch"].ToString();

            string param3 = "@txt_PartNo,@branchname";
            string paramvalue3 = txt_PartNo.Text + "," + branchname;
            DataSet dsall = smitaDbAccess.SPReturnDataSet("sp_GetDataNavlqty", param3, paramvalue3);
            //k.Itm_Partno,0
            //            k.Itm_PartDescrption,1
            //            k.Itm_SalePrice,2
            //            k.Itm_VatPercent,3
            //            k.Itm_CategoryName4


            txt_PartNo.Text = dsall.Tables[0].Rows[0][0].ToString();
            txt_PartDesc.Text = dsall.Tables[0].Rows[0][1].ToString();
            decimal rate = Convert.ToDecimal(dsall.Tables[0].Rows[0][2].ToString());
            txt_vat.Text = "0";

            Txt_mrp.Text = (Convert.ToDecimal(dsall.Tables[0].Rows[0][2] == "" ? "0" : dsall.Tables[0].Rows[0][2])).ToString();


            //var v = from k in db.AME_Master_Item.ToList()
            //        where (k.Itm_Partno.Equals(txt_PartNo.Text) && k.Branch_Name==branchname)
            //        select new
            //        {
            //            k.Itm_Partno,
            //            k.Itm_PartDescrption,
            //            k.Itm_SalePrice,
            //            k.Itm_VatPercent
            //        };

            //txt_PartNo.Text = v.First().Itm_Partno;
            //txt_PartDesc.Text = Convert.ToString(v.First().Itm_PartDescrption);
            //decimal rate = v.First().Itm_SalePrice;
            ////txt_rate.Text = Convert.ToString(v.First().Itm_SalePrice);
            //txt_vat.Text = "0";


            //DataSet ds = smitaDbAccess.returndataset("select SUM(Ss_NetQuantity) AS NetQuantity FROM AME_Spare_PurchaseEntry WHERE Itm_Partno='" + txt_PartNo.Text + "' AND Branch_Name='" + Session["Branch"].ToString() + "'");


            if (dsall.Tables[1].Rows[0][0] != "")
            {
                txt_avlquantity.Text = dsall.Tables[1].Rows[0][0].ToString();
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
            //if (!DateTime.TryParseExact(txt_BInvoiceDate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
            //    txt_BInvoiceDate.Focus();
            //    return;
            //}
            //if (!DateTime.TryParseExact(txt_BRcvDate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
            //    txt_BRcvDate.Focus();
            //    return;
            //}
            if (!DateTime.TryParseExact(txt_transferdate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                txt_transferdate.Focus();
                return;
            }
            //string branchname = Session["Branch"].ToString();
            //var v = from c in SPE.OrderBy(t => t.Itm_Partno).Where(t => t.branch == branchname && t.Itm_Partno == txt_PartNo.Text) select c;
            //if (Convert.ToInt32(v.Count()) > 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('This Partno Already Exist,Please Add Different..!!');</script>", false);
            //    txt_PartNo.Text = "";
            //    txt_PartNo.Text = "";
            //    txt_rate.Text = "";
            //    txt_amount.Text = "";
            //    txt_vat.Text = "";
            //    txt_taxamount.Text = "";
            //    txt_total.Text = "";

            //    return;
            //}

            //var cheq = from c in SPE.Where(t => t.Itm_Partno == txt_PartNo.Text && t.UserId== UserId) select c;
            //if (cheq.Count() > 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('This Partno Already Exist,Please Add Different..!!');</script>", false);
            //}















            PartDetails pr1 = new PartDetails();
            pr1.Itm_Partno = txt_PartNo.Text;
            pr1.Itm_PartDescrption = txt_PartDesc.Text;
            pr1.Ss_Quantity = Convert.ToDecimal(txt_transfer.Text);
            pr1.Ss_Rate = Convert.ToDecimal(txt_rate.Text);
            pr1.Ss_MRP = Convert.ToDecimal(Txt_mrp.Text);
            pr1.Ss_Amount = Convert.ToDecimal(txt_amount.Text);
            pr1.Ss_Discount = Convert.ToDecimal(txt_discount.Text);
            pr1.Ss_Vat = Convert.ToDecimal(txt_vat.Text);
            pr1.Ss_TaxAmont = Convert.ToDecimal(txt_taxamount.Text);
            pr1.Ss_Total = Convert.ToDecimal(txt_total.Text);
            pr1.UserId = Session["Uid"].ToString();
            pr1.branch = Session["Branch"].ToString();
            pr1.maxslno = Convert.ToInt32(ViewState["maxs"].ToString());
            pr1.key = ViewState["ran_Key"].ToString();
            SPE.Add(pr1);

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
            FillSlno();
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
        int mx = Convert.ToInt32(ViewState["maxs"].ToString());
        uname = Session["Uid"].ToString();
        string key11 = ViewState["ran_Key"].ToString();
        var prd = (from c in SPE.ToList()
                   //where c.UserId == uname && c.branch==branchname
                   // where c.UserId == uname && c.branch == branchname && c.maxslno == mx
                   where c.key == key11
                   select c).ToList();
        GridView2.DataSource = prd.ToList();
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
        int mx = Convert.ToInt32(ViewState["maxs"].ToString());
        string branchname = Session["Branch"].ToString();
        //  SPE.RemoveAll(t => t.Itm_Partno == img_delete.ToolTip && t.branch==branchname);
        SPE.RemoveAll(t => t.Itm_Partno == img_delete.ToolTip && t.branch == branchname && t.maxslno == mx);
        FillGrid();
    }






























    public class Item_Description_Details
    {
        public string ItemPartNo { get; set; }
        public string ItemPartDescription { get; set; }
        public string AvailableQty { get; set; }
        public string TransferQty { get; set; }
        public string Rate { get; set; }
        public string MRP { get; set; }
        public string Amount { get; set; }
        public string Discount { get; set; }
        public string GST { get; set; }
        public string GSTAmount { get; set; }
        public string Total { get; set; }

        public string Itm_VehicleType { get; set; }
        public string Itm_CategoryName { get; set; }
        public string Itm_PurchasePrice { get; set; }
        public string Itm_SalePrice { get; set; }
        public string Itm_Selfno { get; set; }
        public string Itm_Unit { get; set; }
        public string hsncode { get; set; }


    }
    public class Transfer_Details
    {
        public string ConnectionString { get; set; }//connection string
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string VoucherNo { get; set; }
        public string jc_year { get; set; }
        public string FromBranch { get; set; }
        public string ToBranch { get; set; }
        public string OrderNo { get; set; }
        public string OrderDate { get; set; }
        public string InvoiceNo { get; set; }
        public string TransferDate { get; set; }
        public string LrNo { get; set; }
        public string LrDate { get; set; }
        public string Status { get; set; }
        public string ItemCount { get; set; }

        public string GrossAmount { get; set; }
        public string DiscountAmount { get; set; }
        public string NetAmount { get; set; }
        public string GSTAmount { get; set; }
        public string Total { get; set; }
        public string Packaging { get; set; }
        public string Other { get; set; }
        public string BillAmount { get; set; }
        public List<Item_Description_Details> lstItemDetailsList { get; set; }

    }




    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        string Tobranch = ddl_tobranch.SelectedItem.Text;
        string returnMsg = "";
        string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy" };
        DateTime expectedDate;


        if (!DateTime.TryParseExact(txt_transferdate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
            txt_transferdate.Focus();
            return;
        }



        if (FillInvoiceNosubmit() == false)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('VOUCHER NO Already Exist.. please refresh the page and submit again!!!');</script>", false);
            return;
        }

        try
        {

            btn_Submit.Visible = false;

            //string apiUrl = "http://rmadmin.in/api/transaction";




            string apiUrl = "http://localhost:8828/api/transaction";

            //string apiUrl = "http://aamatv.com/api/transfer";

            //string apiUrl = "http://localhost:1859/api/Home";

            string conn = "";
            if (Tobranch == "Berhampur")
            {
                //conn = @"data source=DESKTOP-BU119QS\SQLEXPRESS;initial catalog=A2_berhm;integrated security=true;";
                //conn = @"data source=198.71.227.2;initial catalog=R2_Berhm;uid=uBerhm1;pwd=pwd_Berhm2018;";
            }
            else if (Tobranch == "Cuttack")
            {
                //conn = @"data source=DESKTOP-BU119QS\SQLEXPRESS;initial catalog=A2_cuttack;integrated security=true;";
                //conn = @"data source=198.71.227.2;initial catalog=R2_Cuttack;uid=uCuttack1;pwd=pwd_Ctc2018;";
            }
            else if (Tobranch == "Paradeep")
            {
                //conn = @"data source=DESKTOP-BU119QS\SQLEXPRESS;initial catalog=test;integrated security=true;";
                //conn = @"data source=198.71.227.2;initial catalog=R2_Paradeep;uid=uParadeep1;pwd=pwd_Berhm2018;";
            }
            else if (Tobranch == "Phulnakhara")
            {
                //conn = @"data source=DESKTOP-BU119QS\SQLEXPRESS;initial catalog=test;integrated security=true;";
                //conn = @"data source=198.71.227.2;initial catalog=R2_Phul;uid=uPhul1;pwd=pwd_Phul2018;";
            }
            Transfer_Details transDetails = new Transfer_Details();

            transDetails.ConnectionString = conn;

            transDetails.CreatedBy = Session["Uid"].ToString();
            transDetails.CreatedDate = SmitaClass.IndianTime().ToString();
            transDetails.VoucherNo = txt_BVoucherNo.Text;
            transDetails.jc_year = txt_year.Text;
            transDetails.FromBranch = Session["Branch"].ToString();
            transDetails.ToBranch = ddl_tobranch.SelectedItem.Text;
            transDetails.OrderNo = txt_BOrderNo.Text;
            transDetails.OrderDate = txt_BOrderDate.Text;
            transDetails.InvoiceNo = txt_BinvoiceNo.Text;
            transDetails.TransferDate = txt_transferdate.Text;
            transDetails.LrNo = txt_BLrNo.Text;
            transDetails.LrDate = txt_BLrDate.Text;
            transDetails.Status = "false";

            transDetails.GrossAmount = txt_AGrossAmount.Text;
            transDetails.DiscountAmount = txt_ADiscountAmount.Text;
            transDetails.NetAmount = txt_ANetAmount.Text;
            transDetails.GSTAmount = txt_AVatAmount.Text;
            transDetails.Total = txt_ATotal.Text;
            transDetails.Packaging = txt_APackagingAmt.Text;
            transDetails.Other = txt_AOtherAmount.Text;
            transDetails.BillAmount = txt_ABillAmount.Text;
            transDetails.ItemCount = GridView2.Rows.Count.ToString();

            lstItemDescList.Clear();
            foreach (GridViewRow gr in GridView2.Rows)
            {
                Label lbl_partno = (Label)gr.FindControl("lblpartno");
                Label lbl_partDesc = (Label)gr.FindControl("lblpartdescription");
                Label lbl_TQuantity = (Label)gr.FindControl("lbltransfer");
                Label lbl_Rate = (Label)gr.FindControl("lblrate");
                Label lbl_mrp = (Label)gr.FindControl("lblmrp");
                Label lbl_Amount = (Label)gr.FindControl("lblamount");
                Label lbl_Discount = (Label)gr.FindControl("lbldiscount");
                Label lbl_Vat = (Label)gr.FindControl("lblvat");
                Label lbl_TaxAmt = (Label)gr.FindControl("lbltaxamount");
                Label lbl_Total = (Label)gr.FindControl("lbltotal");

                string Branch_Name = Session["Branch"].ToString();
                var v2 = (from c in db.AME_Master_Item.Where(t => t.Branch_Name == Branch_Name && t.Itm_Partno == lbl_partno.Text.Trim())
                          select new
                          {
                              Itm_VehicleType = c.Itm_VehicleType,
                              Itm_CategoryName = c.Itm_CategoryName,
                              Itm_PurchasePrice = c.Itm_PurchasePrice,
                              Itm_SalePrice = c.Itm_SalePrice,
                              Itm_Selfno = c.Itm_Selfno,
                              Itm_Unit = c.Itm_Unit,
                              hsncode = c.hsncode
                          }).ToList().First();

                Item_Description_Details itemDescDetails = new Item_Description_Details();
                itemDescDetails.ItemPartNo = lbl_partno.Text;
                itemDescDetails.ItemPartDescription = lbl_partDesc.Text;
                itemDescDetails.AvailableQty = lbl_TQuantity.Text;
                itemDescDetails.TransferQty = lbl_TQuantity.Text;
                itemDescDetails.Rate = lbl_Rate.Text;
                itemDescDetails.MRP = lbl_mrp.Text;
                itemDescDetails.Amount = lbl_Amount.Text;
                itemDescDetails.Discount = lbl_Discount.Text;
                itemDescDetails.GST = lbl_Vat.Text;
                itemDescDetails.GSTAmount = lbl_TaxAmt.Text;
                itemDescDetails.Total = lbl_Total.Text;
                itemDescDetails.Itm_VehicleType = v2.Itm_VehicleType;// check data null or not
                itemDescDetails.Itm_CategoryName = v2.Itm_CategoryName;
                itemDescDetails.Itm_PurchasePrice = v2.Itm_PurchasePrice.ToString();
                itemDescDetails.Itm_SalePrice = v2.Itm_SalePrice.ToString();
                itemDescDetails.Itm_Selfno = v2.Itm_Selfno;
                itemDescDetails.Itm_Unit = v2.Itm_Unit;
                itemDescDetails.hsncode = v2.hsncode;
                lstItemDescList.Add(itemDescDetails);

            }

            transDetails.lstItemDetailsList = lstItemDescList;
            var input = new
            {
                conString = "conString",
                param = "param",
                lstItemDescList
            };

            string inputJson = (new JavaScriptSerializer()).Serialize(transDetails);
            HttpClient client = new HttpClient();
            HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(apiUrl, inputContent).Result;
            returnMsg = response.IsSuccessStatusCode.ToString();

            if (response.IsSuccessStatusCode)
            {
                returnMsg = response.Content.ReadAsStringAsync().Result;

                string json = new JavaScriptSerializer().Serialize(returnMsg);

                JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                ResponseModel routes_list = json_serializer.Deserialize<ResponseModel>(returnMsg);


                //JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                //ResposeMsg routes_list = (ResposeMsg)json_serializer.DeserializeObject(returnMsg);
                //var result = JsonConvert.DeserializeObject<ResponseModel>(returnMsg);

                returnMsg = routes_list.message;

                if (returnMsg == "Transaction Successful")
                {

                    #region FromBranch Entry
                    foreach (GridViewRow gr in GridView2.Rows)
                    {
                        Label lbl_partno = (Label)gr.FindControl("lblpartno");
                        Label lbl_partDesc = (Label)gr.FindControl("lblpartdescription");
                        Label lbl_TQuantity = (Label)gr.FindControl("lbltransfer");
                        Label lbl_Rate = (Label)gr.FindControl("lblrate");
                        Label lbl_mrp = (Label)gr.FindControl("lblmrp");
                        Label lbl_Amount = (Label)gr.FindControl("lblamount");
                        Label lbl_Discount = (Label)gr.FindControl("lbldiscount");
                        Label lbl_Vat = (Label)gr.FindControl("lblvat");
                        Label lbl_TaxAmt = (Label)gr.FindControl("lbltaxamount");
                        Label lbl_Total = (Label)gr.FindControl("lbltotal");

                        decimal tquantity = Convert.ToDecimal(lbl_TQuantity.Text);

                        string[] param1 = {
                                      "@CreatedBy","@VoucherNo","@ItemPartNo",
                                      "@jc_year", "@ItemPartDescription", "@Branch_Name",
                                      "@Ss_NetQuantity", "@Rate",
                                       "@Amount", "@FromBranch","@Transferdate"
                                   };




                        string TransferDate = Convert.ToDateTime(transDetails.TransferDate, SmitaClass.dateformat()).ToString("MM/dd/yyyy");

                        string[] paramValue1 = {
                                           Session["Uid"].ToString(), txt_BVoucherNo.Text,lbl_partno.Text.Trim(),
                                           txt_year.Text,lbl_partDesc.Text, ddl_tobranch.SelectedItem.Text,
                                           lbl_TQuantity.Text, lbl_mrp.Text,
                                           lbl_Total.Text, Session["Branch"].ToString(),
                                           txt_transferdate.Text==""?null:TransferDate
                                       };

                        smitaDbAccess.insertprocedurestockcoma("Sp_StockTrasferItemDetails_FromBranch", param1, paramValue1);


                    }
                    #endregion


                    btn_Submit.Visible = true;
                    Response.Redirect("Report_Spare_StockTransfer.aspx");
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('" + returnMsg + "'); </script>", false);
                }
                //gvCustomers.DataSource = customers;
                //gvCustomers.DataBind();
            }
        }
        catch (WebException webex)
        {
            WebResponse errResp = webex.Response;
            using (Stream respStream = errResp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(respStream);
                string text = reader.ReadToEnd();
            }

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('" + errResp + "'); </script>", false);
        }
        //--cpy





    }

    public class ResponseModel
    {
        public string message { set; get; }
        public HttpStatusCode status { set; get; }

    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        cl.Clear_All(this);
    }

    public class PartDetails
    {
        public string Itm_Partno { get; set; }

        public string Itm_PartDescrption { get; set; }

        public decimal Ss_Quantity { get; set; }

        public decimal Ss_Rate { get; set; }
        public decimal Ss_MRP { get; set; }

        public decimal Ss_Amount { get; set; }

        public decimal Ss_Discount { get; set; }

        public decimal Ss_Vat { get; set; }

        public decimal Ss_TaxAmont { get; set; }

        public decimal Ss_Total { get; set; }

        public string UserId { get; set; }

        public string branch { get; set; }


        public int maxslno { get; set; }
        public string key { get; set; }

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


}