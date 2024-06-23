using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;

public partial class Admin_Spare_PurchaseEntry : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    static List<PartDetails> vpd = new List<PartDetails>();
    Clear cl = new Clear();
    public string uname;
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Branch"] == null || Session["Uid"] == null || Session["Uname"] == null)
            {
                Response.Write("<script>alert('Your Session Time is Expired..!! Login to continue..!!')</script>");
                Response.Redirect("../SessionExpired.aspx");
            }
            FillSupplier();
           
            fillsino();
            txt_billdate.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy");
            txt_invoicedate.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy");
            string uid = Convert.ToString(Session["Uid"]);
            vpd.RemoveAll(t => t.userid == uid);
        }
    }


    private void FillSupplier()
    {
        var v = from c in db.AME_Master_Supplier.ToList()
                where c.Ms_Status = true && c.Branch_Name == Session["Branch"].ToString()
                select new
                {
                    Su_Name = c.Ms_Name,
                    id = c.Ms_Id,
                };
        ddl_supplier.DataSource = v.ToList();
        ddl_supplier.DataTextField = "Su_Name";
        ddl_supplier.DataValueField = "id";
        ddl_supplier.DataBind();
        ddl_supplier.Items.Insert(0, "--Select One--");
    }
    public void fillModelno()
    {
        string Sale = Convert.ToString(Session["saletype"]);
        if (Session["saletype"] != null)
        {
            string branchname = Session["Branch"].ToString();
            var model = from c in db.AME_Master_VehicleModel.Where(t => t.Mv_VehicleType == ddl_VType.SelectedValue && t.Branch_Name == branchname && t.Mv_SaleStatus==Sale).OrderBy(t => t.Mv_Id)
                        select new
                        {
                            mid = c.Mv_Id,
                            mname = c.Mv_ModelName
                        };
            ddl_model.DataSource = model.ToList();
            ddl_model.DataValueField = "mid";
            ddl_model.DataTextField = "mname";
            ddl_model.DataBind();
            ddl_model.Items.Insert(0, "..Select..");
        }
        else
        {
            string branchname = Session["Branch"].ToString();
            var model = from c in db.AME_Master_VehicleModel.Where(t => t.Mv_VehicleType == ddl_VType.SelectedValue && t.Branch_Name == branchname).OrderBy(t => t.Mv_Id)
                        select new
                        {
                            mid = c.Mv_Id,
                            mname = c.Mv_ModelName
                        };
            ddl_model.DataSource = model.ToList();
            ddl_model.DataValueField = "mid";
            ddl_model.DataTextField = "mname";
            ddl_model.DataBind();
            ddl_model.Items.Insert(0, "..Select..");
        }
        
    }


    public void fillsino()
    {
        string branchname = Session["Branch"].ToString();
        var sino = from c in db.AME_Vehicle_PurchaseEntryDetails.Where(t=>t.Branch_Name==branchname).OrderBy(t => t.Vpd_Id) select c;
        if (Convert.ToInt32(sino.Count()) > 0)
        {
            int lastno = ((int)(from c in db.AME_Vehicle_PurchaseEntryDetails.Where(t => t.Branch_Name == branchname) select c.Vpd_Id).Max()) + 1;
            txt_sino.Text = Convert.ToString(lastno);
        }
        else
        {
            txt_sino.Text = "1";
        }
    }
    protected void imgbtn_PartDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        int img1 = Convert.ToInt32(img.ToolTip);
        string branchname = Session["Branch"].ToString();
        vpd.RemoveAll(t => t.sino == img1 && t.branch==branchname);
      
        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Data Delete Sucessfully.!!');", true);
        fillgrid();
    }

    public class PartDetails
    {
        public string modelname { get; set; }

        public int modelvalue { get; set; }

        public string makersname { get; set; }

        public string chassisno { get; set; }

        public string engineno { get; set; }

        public string color { get; set; }

        public string keyno { get; set; }

        public decimal rate { get; set; }

        public decimal quantity { get; set; }

        public decimal amount { get; set; }

        public int sino { get; set; }

        public string userid { get; set; }

        public string vehicletype { get; set; }

        public string branch { get; set; }
    }
    protected void ddl_supplier_SelectedIndexChanged(object sender, EventArgs e)
    {
         string branchname = Session["Branch"].ToString();
         var supplierDetails = from c in db.AME_Master_Supplier.Where(t => t.Ms_Name == ddl_supplier.SelectedItem.Text && t.Branch_Name == branchname) select c;
         txt_address.Text = supplierDetails.First().Ms_Address;
         txt_phoneno.Text = supplierDetails.First().Ms_Mobileno;
    }
    protected void ddl_model_SelectedIndexChanged(object sender, EventArgs e)
    {
        string branchname = Session["Branch"].ToString();
        var modeldetails = from c in db.AME_Master_VehicleModel.ToList().Where(t => t.Mv_ModelName == ddl_model.SelectedItem.Text && t.Branch_Name==branchname) select c;
        txt_makers.Text = modeldetails.First().Mv_Makers;
        txt_rate.Text = Convert.ToString(modeldetails.First().Mv_Rate);
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        try
        {
        if (ddl_model.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select ..!!'); </script>", false);
            ddl_model.Focus();
            return;
        }
        if (txt_makers.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Makers Name Should Not Be Blank..!!'); </script>", false);
            txt_makers.Focus();
            return;
        }

        if (txt_chessisno.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Chassis Name Should Not Be Blank..!!'); </script>", false);
            txt_chessisno.Focus();
            return;
        }

        if (txt_engineno.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Engine No Should Not Be Blank..!!'); </script>", false);
            txt_engineno.Focus();
            return;
        }
        if (txt_color.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Color name Should Not Be Blank..!!'); </script>", false);
            txt_color.Focus();
            return;
        }
       
        if (txt_rate.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Rate Should Not Be Blank..!!'); </script>", false);
            txt_rate.Focus();
            return;
        }
        if (txt_quantity.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Quantity Should Not Be Blank..!!'); </script>", false);
            txt_quantity.Focus();
            return;
        }
        if (txt_amount.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Amount Should Not Be Blank..!!'); </script>", false);
            txt_amount.Focus();
            return;
        }
              var v = from c in vpd.OrderBy(t => t.sino) select c;
            if (Convert.ToInt32(v.Count()) > 0)
            {
                id = (int)(from c in vpd select c.sino).Max();
                id = id + 1;

            }
            else
            {
                id = 1;

            }
            PartDetails ad=new PartDetails();
            ad.sino=id;
            ad.rate=Convert.ToDecimal(txt_rate.Text);
            ad.quantity=Convert.ToDecimal(txt_quantity.Text);
            ad.amount=Convert.ToDecimal(txt_amount.Text);
            ad.modelname=ddl_model.SelectedItem.Text;
            ad.modelvalue =Convert.ToInt32(ddl_model.SelectedValue);
            ad.userid = Convert.ToString(Session["Uid"]);
            ad.branch = Convert.ToString(Session["Branch"]);
            ad.makersname=txt_makers.Text;
            ad.chassisno=txt_chessisno.Text;
            ad.engineno = txt_engineno.Text;
            ad.keyno = txt_keyno.Text;
            ad.color = txt_color.Text;
            ad.vehicletype = ddl_VType.SelectedItem.Text;
            vpd.Add(ad);
         
           
            fillgrid();
            txt_amount.Text = " 0";
            txt_quantity.Text = "0";
            txt_rate.Text = "0";
            ddl_model.SelectedIndex = 0;
            txt_makers.Text = "";
            txt_chessisno.Text = "";
            txt_engineno.Text = "";
            txt_color.Text = "";
            
            txt_keyno.Text = "";
           
        }
        catch
        {

        }
        }
        decimal tot1 = 0;
        private void fillgrid()
        {
            uname = Session["Uid"].ToString(); 
            string branchname = Session["Branch"].ToString();
            var prd = (from c in vpd.ToList()
                       where c.userid == uname && c.branch==branchname
                       select c).ToList();
            GridView2.DataSource = prd.ToList();
            GridView2.DataBind();

            foreach (GridViewRow gr in GridView2.Rows)
            {
                Label lblTotAmt = (Label)gr.FindControl("lblamount");
                decimal TotAmt = Convert.ToDecimal(lblTotAmt.Text);

                tot1 = tot1 + TotAmt;
                txt_AGrossAmount.Text =Convert.ToString(tot1);
                txt_billamount.Text = Convert.ToString(tot1);
                    }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_sino.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Voucher Number Should Not Be Blank..!!'); </script>", false);
                    txt_sino.Focus();
                    return;
                }
                if (txt_billdate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Enter BillDate..!!'); </script>", false);
                    txt_billdate.Focus();
                    return;
                }
                if (txt_invoiceno.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invoice Number Should Not Be Blank..!!'); </script>", false);
                    txt_invoiceno.Focus();
                    return;
                }
                if (txt_invoicedate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invoice Date Should Not Be Blank..!!'); </script>", false);
                    txt_invoicedate.Focus();
                    return;
                }

                if (ddl_supplier.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Supplier Name..!!'); </script>", false);
                    ddl_supplier.Focus();
                    return;
                }

                //////////////////////////////////

                if (txt_address.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Address Should Not Be Blank..!!'); </script>", false);
                    txt_address.Focus();
                    return;
                }
                //if (txt_phoneno.Text == "")
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Phone No Should Not Be Blank..!!'); </script>", false);
                //    txt_phoneno.Focus();
                //    return;
                //}

                string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy" };
                DateTime expectedDate;
                if (!DateTime.TryParseExact(txt_billdate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                    txt_billdate.Focus();
                    return;
                }
                if (!DateTime.TryParseExact(txt_invoicedate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                    txt_invoicedate.Focus();
                    return;
                }
                var v = from c in vpd.OrderBy(t => t.sino) select c;
                if (Convert.ToInt32(v.Count()) <= 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Add The Model Details..!!');</script>", false);
                    txt_quantity.Focus();
                    return;
                }
                foreach (GridViewRow gr in GridView2.Rows)
                {

                    Label lblvechiletype = (Label)gr.FindControl("lblvechiletype");
                    string vehicletype = lblvechiletype.Text;

                    Label lblmodelname = (Label)gr.FindControl("lblmodelname");
                    int model = Convert.ToInt32(lblmodelname.ToolTip);

                    Label lblmakersname = (Label)gr.FindControl("lblmakersname");
                    string makersname =lblmakersname.Text;

                    Label lblchassisno = (Label)gr.FindControl("lblchassisno");
                    string chassisno = lblchassisno.Text;

                    Label lblengineno = (Label)gr.FindControl("lblengineno");
                    string engineno = lblengineno.Text;

                    Label lblcolor = (Label)gr.FindControl("lblcolor");
                    string color = lblcolor.Text;

                    Label lblkeyno = (Label)gr.FindControl("lblkeyno");
                    string keyno = lblkeyno.Text;

                    Label lblrate = (Label)gr.FindControl("lblrate");
                    decimal rate = Convert.ToDecimal(lblrate.Text);

                    Label lblquantity = (Label)gr.FindControl("lblquantity");
                    decimal quantity = Convert.ToDecimal(lblquantity.Text);

                    Label lblamount = (Label)gr.FindControl("lblamount");
                    decimal amount = Convert.ToDecimal(lblamount.Text);

                    AME_Vehicle_PurchaseEntry Vp = new AME_Vehicle_PurchaseEntry();
                    Vp.Branch_Name = Session["Branch"].ToString();
                    Vp.Created_By = Session["Uid"].ToString();
                    Vp.Created_Date = SmitaClass.IndianTime();
                    Vp.Mv_Makers = makersname;
                    Vp.Mv_ModelName = model;
                    Vp.Vp_Amount = amount;
                    Vp.Vp_Chassisno = chassisno;
                    Vp.Vp_Color = color;
                    Vp.Vp_Engineno = engineno;
                    Vp.Vp_Keyno = keyno;
                    Vp.Vp_NetQuantity = quantity;
                    Vp.Vp_Quantity = quantity;
                    Vp.Vp_Rate = rate;
                    Vp.Vpd_Id = Convert.ToInt32(txt_sino.Text);
                    Vp.Mv_VehicleType = vehicletype;
                    Vp.Status = "PE";
                    Vp.PendingStatus = "False";
                    db.AddToAME_Vehicle_PurchaseEntry(Vp);
                    db.SaveChanges();
                }



                AME_Vehicle_PurchaseEntryDetails avp = new AME_Vehicle_PurchaseEntryDetails();
                avp.Vp_Billdate = Convert.ToDateTime(txt_billdate.Text, SmitaClass.dateformat());
                avp.Vp_BillAmount = Convert.ToDecimal(txt_billamount.Text);
                avp.Vp_Address = txt_address.Text;
                avp.Vp_CstAmount = Convert.ToDecimal(txt_cstamount.Text);
                avp.Vp_CstPercent = Convert.ToDecimal(txtcst.Text);
                avp.Vp_Discount = Convert.ToDecimal(txt_ADiscountAmount.Text);
                avp.Vp_GrossAmount = Convert.ToDecimal(txt_AGrossAmount.Text);
                avp.Vp_InvoiceDate = Convert.ToDateTime(txt_invoicedate.Text, SmitaClass.dateformat());
                avp.Vp_Invoiceno = txt_invoiceno.Text; ;
                avp.Vp_Other = Convert.ToDecimal(txt_other.Text); ;
                avp.Vp_Phno = txt_phoneno.Text;
                avp.Vp_Supplier = Convert.ToInt32(ddl_supplier.SelectedValue);
                avp.Vp_VatAmount = Convert.ToDecimal(txt_vatamount.Text);
                avp.Vp_VatPercent = Convert.ToDecimal(txtvat.Text);
                avp.Branch_Name = Session["Branch"].ToString();
                avp.Created_By = Session["Uid"].ToString();
                avp.Created_Date = SmitaClass.IndianTime();
                avp.Vpd_Id = Convert.ToInt32(txt_sino.Text);
                
                avp.Status = "PE";
                db.AddToAME_Vehicle_PurchaseEntryDetails(avp);
                db.SaveChanges();

               
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Vechile Purchase Entry Sucessfully..!!!');</script>", false);
                cl.Clear_All(this);
                vpd.RemoveAll(t => t.modelname != "");
                GridView2.DataSource = null;
                GridView2.DataBind();
                fillsino();
                txt_ADiscountAmount.Text = "0";
                txt_vatamount.Text = "0";
                txt_cstamount.Text = "0";
                txt_other.Text = "0";
                txt_billamount.Text = "0";
                txtvat.Text = "0";
                txtcst.Text = "0";
                txt_amount.Text = "0";
                txt_quantity.Text = "0";
            }
            catch
            {

            }
        }
        protected void ddl_VType_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillModelno();
        }
       
}

    
