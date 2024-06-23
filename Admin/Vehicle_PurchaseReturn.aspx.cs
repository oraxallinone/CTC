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

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["Branch"] == null || Session["Uid"] == null || Session["Uname"] == null)
            {
                Response.Write("<script>alert('Your Session Time is Expired..!! Login to continue..!!')</script>");
                Response.Redirect("../SessionExpired.aspx");
            }

            Panel1.Visible = false;
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
    public void filldata()
    {
        FillSupplier();
        string branchname = Session["Branch"].ToString();
        string sino = txt_billno.Text;
        int id = Convert.ToInt32(sino);
        var PurchaseDetails = from c in db.AME_Vehicle_PurchaseEntryDetails.Where(t => t.Vpd_Id == id && t.Branch_Name == branchname) select c;
        txt_invoicedate.Text = PurchaseDetails.First().Vp_InvoiceDate.ToString("dd/MM/yyyy");
        txt_sino.Text = Convert.ToString(PurchaseDetails.First().Vpd_Id);
        txt_invoiceno.Text = PurchaseDetails.First().Vp_Invoiceno;
        txt_billdate.Text = PurchaseDetails.First().Vp_Billdate.ToString("dd/MM/yyyy");
        ddl_supplier.SelectedValue = Convert.ToString(PurchaseDetails.First().Vp_Supplier);
        txt_address.Text = PurchaseDetails.First().Vp_Address;
        txt_phoneno.Text = PurchaseDetails.First().Vp_Phno;
        txt_AGrossAmount.Text = Convert.ToString(PurchaseDetails.First().Vp_GrossAmount);
        txt_ADiscountAmount.Text = Convert.ToString(PurchaseDetails.First().Vp_Discount);
        txt_billamount.Text = Convert.ToString(PurchaseDetails.First().Vp_BillAmount);
        txtvat.Text = Convert.ToString(PurchaseDetails.First().Vp_VatPercent);
        txtcst.Text = Convert.ToString(PurchaseDetails.First().Vp_CstPercent);
        txt_cstamount.Text = Convert.ToString(PurchaseDetails.First().Vp_CstAmount);
        txt_vatamount.Text = Convert.ToString(PurchaseDetails.First().Vp_VatAmount);
        txt_other.Text = Convert.ToString(PurchaseDetails.First().Vp_Other);
        btn_update.ToolTip = Convert.ToString(PurchaseDetails.First().Vpd_Id);
    }
    public void fillgriddata()
    {
        string branchname = Session["Branch"].ToString();
        string sino = txt_billno.Text;
        int id = Convert.ToInt32(sino);
        var pe = (from c in db.AME_Vehicle_PurchaseEntry
                  join d in db.AME_Master_VehicleModel on c.Mv_ModelName equals d.Mv_Id
                  where c.Vpd_Id == id && c.Branch_Name == branchname && c.Status == "PE"
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

   


    private void SetTextBoxReadOnly<T>(Control parent, bool readOnly) where T : TextBox
    {
        foreach (var tb in parent.Controls.OfType<T>())
            tb.ReadOnly = readOnly;

        foreach (Control c in parent.Controls)
            SetTextBoxReadOnly<T>(c, readOnly);
    }

    protected void btn_update_Click(object sender, EventArgs e)
    {

        try
        {


        }
        catch
        {

        }
    }


    protected void btn_return_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_returndate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Return Date SHOULD NOT BE BLANK...!!');", true);
                txt_returndate.Focus();
                return;
            }
            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy" };
            DateTime expectedDate;
            if (!DateTime.TryParseExact(txt_returndate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                txt_returndate.Focus();
                return;
            }
            Button imgbtnEdit = (Button)sender;
            string sino = (imgbtnEdit.ToolTip);
            int id = Convert.ToInt32(sino);
            foreach (GridViewRow gr in GridView2.Rows)
             {
            gr.BackColor = System.Drawing.Color.Transparent;

            Label lblmodelname = (Label)gr.FindControl("lblmodelname");
            int modelname =Convert.ToInt32(lblmodelname.ToolTip);

            Label lblvechiletype = (Label)gr.FindControl("lblvechiletype");
            string vechiletype = lblvechiletype.Text;

            Label lblchassisno = (Label)gr.FindControl("lblchassisno");
            string chassisno = lblchassisno.Text;

            Label lblengineno = (Label)gr.FindControl("lblengineno");
            string engineno = lblengineno.Text;

            Label lblquantity = (Label)gr.FindControl("lblquantity");
            decimal quantity =Convert.ToDecimal(lblquantity.Text);
            string branchname = Session["Branch"].ToString();
            var pursedentry = from c in db.AME_Vehicle_PurchaseEntry.Where(t => t.Vp_Id == id && t.Status == "PE" && t.Branch_Name==branchname) select c;
            if (Convert.ToDecimal(pursedentry.First().Vp_Quantity) != Convert.ToDecimal(pursedentry.First().Vp_NetQuantity))
            {

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('You already Use This Stock,So You Cant Reurnit..!!'); </script>", false);

                GridViewRow row = imgbtnEdit.NamingContainer as GridViewRow;
                row.BackColor = System.Drawing.Color.Pink;
                return;
            }
          
            else
            {
                   
                    Button view = (Button)gr.FindControl("btn_return");
                    int sino1 = Convert.ToInt32(view.ToolTip);
                    if (sino1 == id)
                    {

                       
                        Label lblamount = (Label)gr.FindControl("lblamount");
                        decimal amount = Convert.ToDecimal(lblamount.Text);
                        lbldiscount.Text = txt_AGrossAmount.Text;
                        txt_AGrossAmount.Text = Convert.ToString(SmitaClass.SignificantTruncate((Convert.ToDecimal(txt_AGrossAmount.Text) - Convert.ToDecimal(amount)), 2));
                        txt_ADiscountAmount.Text = Convert.ToString(SmitaClass.SignificantTruncate((Convert.ToDecimal(txt_ADiscountAmount.Text) * Convert.ToDecimal(txt_AGrossAmount.Text) / Convert.ToDecimal(lbldiscount.Text)), 2));
                        txt_billamount.Text = Convert.ToString(SmitaClass.SignificantTruncate((Convert.ToDecimal(txt_AGrossAmount.Text) - Convert.ToDecimal(txt_ADiscountAmount.Text)), 2));
                        txt_vatamount.Text = Convert.ToString(SmitaClass.SignificantTruncate((Convert.ToDecimal(txt_billamount.Text) * Convert.ToDecimal(txtvat.Text) / 100), 2));
                        txt_cstamount.Text = Convert.ToString(SmitaClass.SignificantTruncate((Convert.ToDecimal(txt_billamount.Text) * Convert.ToDecimal(txtcst.Text) / 100), 2));
                        txt_billamount.Text = Convert.ToString(SmitaClass.SignificantTruncate((Convert.ToDecimal(txtvat.Text) + Convert.ToDecimal(txt_vatamount.Text) + Convert.ToDecimal(txt_other.Text)), 2));

                        //update purchase Entry Table
                        AME_Vehicle_PurchaseEntry vpe = db.AME_Vehicle_PurchaseEntry.First(t => t.Vp_Id == sino1);
                        vpe.Status = "PurchaseReturn";
                        vpe.Vp_NetQuantity = 0;
                        db.SaveChanges();

                        //update purchase Entry Details Table
                        string billno = btn_update.ToolTip;
                        int billno1 = Convert.ToInt32(btn_update.ToolTip);
                        AME_Vehicle_PurchaseEntryDetails vped = db.AME_Vehicle_PurchaseEntryDetails.First(t=>t.Vpd_Id==billno1);
                        vped.Vp_GrossAmount = Convert.ToDecimal(txt_AGrossAmount.Text);
                        vped.Vp_Discount = Convert.ToDecimal(txt_ADiscountAmount.Text);
                        vped.Vp_VatPercent = Convert.ToDecimal(txtvat.Text);
                        vped.Vp_VatAmount = Convert.ToDecimal(txt_vatamount.Text);
                        vped.Vp_CstPercent = Convert.ToDecimal(txtcst.Text);
                        vped.Vp_CstAmount = Convert.ToDecimal(txt_cstamount.Text);
                        vped.Vp_Other = Convert.ToDecimal(txt_other.Text);
                        vped.Vp_BillAmount = Convert.ToDecimal(txt_billamount.Text);
                        db.SaveChanges();

                        //insert vehicle Purchase Return table

                        AME_VehiclePurchase_Return vpr = new AME_VehiclePurchase_Return();
                        vpr.Branch_Name = Session["Branch"].ToString();
                        vpr.Created_By = Session["Uid"].ToString();
                        vpr.Created_Date = SmitaClass.IndianTime();
                        vpr.Mv_ModelName = modelname;
                        vpr.Mv_VehicleType = vechiletype;
                        vpr.Status = "PurchaseReturn";
                        vpr.Vp_Chassisno = chassisno;
                        vpr.Vp_Engineno = engineno;
                        vpr.Vp_Quantity = quantity;
                        vpr.Vr_returndate = Convert.ToDateTime(txt_returndate.Text,SmitaClass.dateformat());
                        vpr.Vpd_Id = Convert.ToInt32(btn_update.ToolTip);
                        db.AddToAME_VehiclePurchase_Return(vpr);
                        db.SaveChanges();
                        fillgriddata();
                        
                    }
                    
                }
               
            }

            GridViewRow row1 = imgbtnEdit.NamingContainer as GridViewRow;
            row1.BackColor = System.Drawing.Color.Pink;

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Purchase Return sucessfully.!!'); </script>", false);
            return;
        }
        catch
        {

        }
    }
    protected void txt_billno_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txt_billno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Bill No shouldnot bE blank..!!'); </script>", false);
                txt_billno.Focus();
                Panel1.Visible = false;
                return;
            }
            string branchname = Session["Branch"].ToString();
            int id = Convert.ToInt32(txt_billno.Text);
            var PurchaseList = from c in db.AME_Vehicle_PurchaseEntryDetails.Where(t => t.Vpd_Id == id && t.Branch_Name == branchname)
                               select c;

            if (Convert.ToInt32(PurchaseList.Count()) > 0)
            {
                Panel1.Visible = true;
                filldata();
                fillgriddata();
            }
            else
            {

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invalid Bill No..!!'); </script>", false);
                txt_billno.Text = "";
                cl.Clear_All(this);
                GridView2.DataSource = null;
                GridView2.DataBind();
                txt_billno.Focus();
                return;

            }
        }
        catch
        {

        }
    }
    
}


