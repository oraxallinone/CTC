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
            string sino = Request.QueryString["id"];
            string type = Request.QueryString["Type"];
            if (type == "View")
            {
                filldata(sino, type);
                fillgriddata(sino,type);
                SetTextBoxReadOnly<TextBox>(Master.FindControl("form1"), true);
                tbl_PurchaseDetails.Visible = false;
            }
            if (type == "Edit")
            {
                filldata(sino, type);
                fillgridEditdata(sino,type);
                tbl_PurchaseDetails.Visible = true;
                fillModelno();
                btn_update.Visible = true;
                btnprint.Visible = false;
            }
            FillSupplier();
        }
    }

    public void filldata(string sino, string type)
    {
        string branchname = Session["Branch"].ToString();
        int id = Convert.ToInt32(sino);
        var PurchaseDetails = from c in db.AME_Vehicle_PurchaseEntryDetails.Where(t => t.Vpd_Id == id && t.Branch_Name==branchname) select c;
        txt_invoicedate.Text = PurchaseDetails.First().Vp_InvoiceDate.ToString("dd/MM/yyyy");
        txt_sino.Text =Convert.ToString(PurchaseDetails.First().Vpd_Id);
        txt_invoiceno.Text = PurchaseDetails.First().Vp_Invoiceno;
        txt_billdate.Text = PurchaseDetails.First().Vp_Billdate.ToString("dd/MM/yyyy");
        ddl_supplier.SelectedValue =Convert.ToString(PurchaseDetails.First().Vp_Supplier);
        txt_address.Text =PurchaseDetails.First().Vp_Address;
        txt_phoneno.Text = PurchaseDetails.First().Vp_Phno;
        txt_AGrossAmount.Text =Convert.ToString(PurchaseDetails.First().Vp_GrossAmount);
        txt_ADiscountAmount.Text = Convert.ToString(PurchaseDetails.First().Vp_Discount);
        txt_billamount.Text = Convert.ToString(PurchaseDetails.First().Vp_BillAmount);
        txtvat.Text = Convert.ToString(PurchaseDetails.First().Vp_VatPercent);
        txtcst.Text = Convert.ToString(PurchaseDetails.First().Vp_CstPercent);
        txt_cstamount.Text = Convert.ToString(PurchaseDetails.First().Vp_CstAmount);
        txt_vatamount.Text =Convert.ToString(PurchaseDetails.First().Vp_VatAmount);
        txt_other.Text =Convert.ToString(PurchaseDetails.First().Vp_Other);
    }
    public void fillgriddata(string sino, string type)
    {
        string branchname=Session["Branch"].ToString();
        int id = Convert.ToInt32(sino);
        var pe = (from c in db.AME_Vehicle_PurchaseEntry
                       join d in db.AME_Master_VehicleModel on c.Mv_ModelName equals d.Mv_Id
                  where c.Vpd_Id == id && c.Branch_Name == branchname
                       select new
                       {
                          d.Mv_ModelName,
                          d.Mv_Id,
                          c.Mv_Makers,
                          c.Vp_Chassisno,
                          c.Vp_Engineno,
                          c.Vp_Color,
                          c.Vp_Keyno,
                          c.Vp_Rate,
                          c.Vp_Quantity,
                          c.Vp_Amount,
                          c.Vp_Id,
                          c.Mv_VehicleType,

                       }).ToList();

        GridView2.DataSource = pe.ToList();
        GridView2.DataBind();
        foreach (GridViewRow gr in GridView2.Rows)
        {
            ImageButton edit = (ImageButton)gr.FindControl("imgbtn_Edit");
            ImageButton delete = (ImageButton)gr.FindControl("imgbtn_PartDelete");
            edit.Visible = false;
            delete.Visible = false;

        }

    }
    public void fillgridEditdata(string sino, string type)
    {
        string branchname = Session["Branch"].ToString();
        int id = Convert.ToInt32(sino);
        var pe = (from c in db.AME_Vehicle_PurchaseEntry
                  join d in db.AME_Master_VehicleModel on c.Mv_ModelName equals d.Mv_Id
                  where c.Vpd_Id == id && c.Branch_Name == branchname
                  select new
                  {
                      d.Mv_ModelName,
                      d.Mv_Id,
                      c.Mv_Makers,
                      c.Vp_Chassisno,
                      c.Vp_Engineno,
                      c.Vp_Color,
                      c.Vp_Keyno,
                      c.Vp_Rate,
                      c.Vp_Quantity,
                      c.Vp_Amount,
                      c.Vp_Id,
                      c.Mv_VehicleType,

                  }).ToList();

        GridView2.DataSource = pe.ToList();
        GridView2.DataBind();
       

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
            var model = from c in db.AME_Master_VehicleModel.Where(t => t.Mv_VehicleType == ddl_VType.SelectedValue && t.Branch_Name == branchname && t.Mv_SaleStatus == Sale).OrderBy(t => t.Mv_Id)
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

    private void SetTextBoxReadOnly<T>(Control parent, bool readOnly) where T : TextBox
    {
        foreach (var tb in parent.Controls.OfType<T>())
            tb.ReadOnly = readOnly;

        foreach (Control c in parent.Controls)
            SetTextBoxReadOnly<T>(c, readOnly);
    }
    public void fillsino()
    {
        string branchname = Session["Branch"].ToString();
        var sino = from c in db.AME_Vehicle_PurchaseEntry.Where(t => t.Branch_Name == branchname).OrderBy(t => t.Vp_Id) select c;
        if (Convert.ToInt32(sino.Count()) > 0)
        {
            int lastno = ((int)(from c in db.AME_Vehicle_PurchaseEntry select c.Vp_Id).Max()) + 1;
            txt_sino.Text = Convert.ToString(lastno);
        }
        else
        {
            txt_sino.Text = "1";
        }
    }
      decimal tot1 = 0;
    protected void imgbtn_PartDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        int img1 = Convert.ToInt32(img.ToolTip);

        string branchname = Session["Branch"].ToString();
        AME_Vehicle_PurchaseEntry vq = db.AME_Vehicle_PurchaseEntry.ToList().First(t => t.Vp_Id == img1 && t.Branch_Name==branchname);
        db.DeleteObject(vq);
        db.SaveChanges();
        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Data Deleted Sucessfully..!!');", true);

        string sino0 = Request.QueryString["id"];
        string type = Request.QueryString["Type"];
        fillgridEditdata(sino0, type);
          foreach (GridViewRow gr in GridView2.Rows)
            {
                Label lblTotAmt = (Label)gr.FindControl("lblamount");
                decimal TotAmt = Convert.ToDecimal(lblTotAmt.Text);

                tot1 = tot1 + TotAmt;
                txt_AGrossAmount.Text =Convert.ToString(tot1);
                txt_billamount.Text = Convert.ToString(tot1);
             }
        

      
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

        if (btn_add.Text == "Update")
        {
           string branchname = Session["Branch"].ToString();
           
            int sino = Convert.ToInt32(btn_add.ToolTip);
            AME_Vehicle_PurchaseEntry vqu = db.AME_Vehicle_PurchaseEntry.First(t => t.Vp_Id == sino && t.Branch_Name == branchname);
            vqu.Mv_ModelName = Convert.ToInt32(ddl_model.SelectedValue);
            vqu.Mv_Makers = txt_makers.Text;
            vqu.Vp_Chassisno = txt_chessisno.Text;
            vqu.Vp_Engineno = txt_engineno.Text;
            vqu.Vp_Color = txt_color.Text;
            vqu.Vp_Keyno = txt_keyno.Text;
            vqu.Vp_Rate = Convert.ToDecimal(txt_rate.Text);
            vqu.Vp_Quantity = Convert.ToDecimal(txt_quantity.Text);
            vqu.Vp_NetQuantity = Convert.ToDecimal(txt_quantity.Text);
            vqu.Vp_Amount = Convert.ToDecimal(txt_amount.Text);
            vqu.Mv_VehicleType = ddl_VType.SelectedItem.Text;
            vqu.Status = "PE";
            db.SaveChanges();

            string sino0 = Request.QueryString["id"];
            string type = Request.QueryString["Type"];
            fillgridEditdata(sino0, type);
            foreach (GridViewRow gr in GridView2.Rows)
            {
                Label lblTotAmt = (Label)gr.FindControl("lblamount");
                decimal TotAmt = Convert.ToDecimal(lblTotAmt.Text);

                tot1 = tot1 + TotAmt;
                txt_AGrossAmount.Text = Convert.ToString(tot1);
                txt_billamount.Text = Convert.ToString(tot1);
            }
            txt_amount.Text = " 0";
            txt_quantity.Text = "0";
            txt_rate.Text = "0";
            txt_chessisno.Text = "";
            txt_engineno.Text = "";
            txt_keyno.Text = "";
            txt_makers.Text = "";
            ddl_model.SelectedIndex = -1;
            btn_add.Text = "Save";
            txt_color.Text = "";
        }
        else if (btn_add.Text == "Save")
        {
            AME_Vehicle_PurchaseEntry vqu = new AME_Vehicle_PurchaseEntry();
            vqu.Vpd_Id = Convert.ToInt32(txt_sino.Text);
            vqu.Mv_VehicleType = ddl_VType.SelectedItem.Text;
            vqu.Mv_ModelName = Convert.ToInt32(ddl_model.SelectedValue);
            vqu.Mv_Makers = txt_makers.Text;
            vqu.Vp_Chassisno = txt_chessisno.Text;
            vqu.Vp_Engineno = txt_engineno.Text;
            vqu.Vp_Color = txt_color.Text;
            vqu.Vp_Keyno = txt_keyno.Text;
            vqu.Vp_Rate = Convert.ToDecimal(txt_rate.Text);
            vqu.Vp_Quantity = Convert.ToDecimal(txt_quantity.Text);
            vqu.Vp_Amount = Convert.ToDecimal(txt_amount.Text);
            vqu.Vp_NetQuantity = Convert.ToDecimal(txt_quantity.Text);
            vqu.Branch_Name = Session["Branch"].ToString();
            vqu.Created_By = Session["Uid"].ToString();
            vqu.Created_Date = SmitaClass.IndianTime();
            vqu.Status = "PE";
            db.AddToAME_Vehicle_PurchaseEntry(vqu);
            db.SaveChanges();

            string sino0 = Request.QueryString["id"];
            string type = Request.QueryString["Type"];
            fillgridEditdata(sino0, type);

            foreach (GridViewRow gr in GridView2.Rows)
            {
                Label lblTotAmt = (Label)gr.FindControl("lblamount");
                decimal TotAmt = Convert.ToDecimal(lblTotAmt.Text);

                tot1 = tot1 + TotAmt;
                txt_AGrossAmount.Text = Convert.ToString(tot1);
                txt_billamount.Text = Convert.ToString(tot1);
            }
            txt_amount.Text = " 0";
            txt_quantity.Text = "0";
            txt_rate.Text = "0";
            txt_chessisno.Text = "";
            txt_engineno.Text = "";
            txt_keyno.Text = "";
            txt_makers.Text = "";
            ddl_model.SelectedIndex = -1;
            btn_add.Text = "Save";
            txt_color.Text = "";
        }


        }

        catch
        {

        }
        }
 

  
        protected void btn_update_Click(object sender, EventArgs e)
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
                if (txt_phoneno.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Phone No Should Not Be Blank..!!'); </script>", false);
                    txt_phoneno.Focus();
                    return;
                }

                string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy","dd-MM-yyyy" };
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

                if (GridView2.Rows.Count <=0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Please Add The Model Details..!!');", true);
                    txt_chessisno.Focus();
                    return;
                }
                string branchname = Session["Branch"].ToString();
                int sino = Convert.ToInt32(txt_sino.Text);
                AME_Vehicle_PurchaseEntryDetails avp = db.AME_Vehicle_PurchaseEntryDetails.First(t => t.Vpd_Id == sino && t.Branch_Name == branchname);
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

                db.SaveChanges();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Data Update Sucessfully..!!'); </script>", false);
                ddl_VType.Focus();
                return;
            }
            catch
            {

            }
        }
        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Vehicle_PurchaseDetailsDatewise.aspx");
        }
        protected void imgbtn_edit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgbtnEdit = (ImageButton)sender;
                string sino = (imgbtnEdit.ToolTip);
                int id = Convert.ToInt32(sino);
                foreach (GridViewRow gr in GridView2.Rows)
                {
                    gr.BackColor = System.Drawing.Color.Transparent;
                }

                GridViewRow row = imgbtnEdit.NamingContainer as GridViewRow;
                row.BackColor = System.Drawing.Color.Pink;
                var pursedentry = from c in db.AME_Vehicle_PurchaseEntry.Where(t => t.Vp_Id == id && t.Status=="PE") select c;
                if (Convert.ToDecimal(pursedentry.First().Vp_Quantity) != Convert.ToDecimal(pursedentry.First().Vp_NetQuantity))
                {

                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('You already Use This Stock,So You Cant Edit This..!!'); </script>", false);
                    ddl_VType.SelectedIndex =-1;

                    ddl_model.SelectedIndex = -1;
                    txt_makers.Text ="";
                    txt_chessisno.Text = "";
                    txt_engineno.Text = "";
                    txt_color.Text = "";
                    txt_keyno.Text = "";
                    txt_rate.Text ="0";
                    txt_quantity.Text ="0";
                    txt_amount.Text = "0";
                   
                    return;
                }
                else
                {
                    ddl_VType.SelectedItem.Text = pursedentry.First().Mv_VehicleType;
                    fillModelno();
                    ddl_model.SelectedValue = Convert.ToString(pursedentry.First().Mv_ModelName);
                    txt_makers.Text = Convert.ToString(pursedentry.First().Mv_Makers);
                    txt_chessisno.Text = Convert.ToString(pursedentry.First().Vp_Chassisno);
                    txt_engineno.Text = Convert.ToString(pursedentry.First().Vp_Engineno);
                    txt_color.Text = Convert.ToString(pursedentry.First().Vp_Color);
                    txt_keyno.Text = Convert.ToString(pursedentry.First().Vp_Keyno);
                    txt_rate.Text = Convert.ToString(pursedentry.First().Vp_Rate);
                    txt_quantity.Text = Convert.ToString(pursedentry.First().Vp_Quantity);
                    txt_amount.Text = Convert.ToString(pursedentry.First().Vp_Amount);
                    btn_add.ToolTip = Convert.ToString(pursedentry.First().Vp_Id);
                    
                    btn_add.Text = "Update";
                }
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

    
