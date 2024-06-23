using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;

public partial class Admin_VehicleSale_Modify : System.Web.UI.Page
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

            //FillParty();
            //fillsino();
            string bill = Request.QueryString["billno1"];
            txt_billno.Text = bill;
            if (txt_billno.Text != "")
            {
                tbl_details.Visible = true;
            }
            else
            {
                tbl_details.Visible = false;
            }
        }
    }


    private void SetTextBoxReadOnly<T>(Control parent, bool readOnly) where T : TextBox
    {
        foreach (var tb in parent.Controls.OfType<T>())
            tb.ReadOnly = readOnly;

        foreach (Control c in parent.Controls)
            SetTextBoxReadOnly<T>(c, readOnly);
    }
    private void FillParty()
    {
        var v = from c in db.AME_Master_Customer.ToList()
                where c.Mc_Status = true && c.Branch_Name == Session["Branch"].ToString()
                select new
                {
                    partyname = c.Mc_Name,
                    id = c.Mc_Id,
                };
        ddl_partyname.DataSource = v.ToList();
        ddl_partyname.DataTextField = "partyname";
        ddl_partyname.DataValueField = "id";
        ddl_partyname.DataBind();
        ddl_partyname.Items.Insert(0, "--Select One--");
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

    public void fillchassisno()
    {
        int modelname = Convert.ToInt32(ddl_model.SelectedValue);
        string branchname = Session["Branch"].ToString();
        var chessisno = from c in db.AME_Vehicle_PurchaseEntry.ToList().Where(t => t.Mv_VehicleType == ddl_VType.SelectedItem.Text && t.Mv_ModelName == modelname && t.Branch_Name == branchname && t.Vp_NetQuantity != 0).OrderBy(t => t.Vpd_Id)
                        select new
                        {
                            mid = c.Vp_Id,
                            chassisno = c.Vp_Chassisno
                        };
        ddl_chessisno.DataSource = chessisno.ToList();
        ddl_chessisno.DataValueField = "mid";
        ddl_chessisno.DataTextField = "chassisno";
        ddl_chessisno.DataBind();
        ddl_chessisno.Items.Insert(0, "..Select..");
    }
    public void fillsino()
    {
        string branchname = Session["Branch"].ToString();
        var sino = from c in db.AME_Vehicle_SaleEntry.Where(t => t.Branch_Name == branchname).OrderBy(t => t.Vse_Id) select c;
        if (Convert.ToInt32(sino.Count()) > 0)
        {
            int lastno = ((int)(from c in db.AME_Vehicle_SaleEntry.Where(t => t.Branch_Name == branchname) select c.Vse_Id).Max()) + 1;
            txt_billno.Text = Convert.ToString(lastno);
        }
        else
        {
            txt_billno.Text = "1";
        }
    }



    protected void ddl_model_SelectedIndexChanged(object sender, EventArgs e)
    {
        string branchname = Session["Branch"].ToString();
        var modeldetails = from c in db.AME_Master_VehicleModel.ToList().Where(t => t.Mv_ModelName == ddl_model.SelectedItem.Text && t.Branch_Name == branchname) select c;
        txt_makers.Text = modeldetails.First().Mv_Makers;
        txt_rate.Text = Convert.ToString(modeldetails.First().Mv_Rate);
        txt_category.Text = modeldetails.First().Mv_Category;
        txt_horsepwr.Text = modeldetails.First().Mv_HPower;
        txt_fuelused.Text = modeldetails.First().Mv_FuelUsed;
        txt_nocylinder.Text = modeldetails.First().Mv_Cylinders;
        txt_grossweight.Text = modeldetails.First().Mv_GrossWeight;
        txt_uldnweight.Text = modeldetails.First().Mv_UnladedWeight;
        txt_Seat.Text = modeldetails.First().Mv_SeatCapacity;
        fillchassisno();
    }



    protected void ddl_VType_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillModelno();
    }
    protected void ddl_partyname_SelectedIndexChanged(object sender, EventArgs e)
    {
        string branchname = Session["Branch"].ToString();
        var PartyDetails = from c in db.AME_Master_Customer.Where(t => t.Mc_Name == ddl_partyname.SelectedItem.Text && t.Branch_Name == branchname) select c;
        txt_address.Text = PartyDetails.First().Mc_Address;
        txt_phoneno.Text = PartyDetails.First().Mc_Mobileno;
    }
    protected void ddl_chessisno_SelectedIndexChanged(object sender, EventArgs e)
    {
        string branchname = Session["Branch"].ToString();
        var chessis = from c in db.AME_Vehicle_PurchaseEntry.Where(t => t.Vp_Chassisno == ddl_chessisno.SelectedItem.Text && t.Branch_Name == branchname && t.Vp_NetQuantity != 0) select c;
        txt_engineno.Text = chessis.First().Vp_Engineno;
        txt_color.Text = chessis.First().Vp_Color;
        txt_keyno.Text = chessis.First().Vp_Keyno;

        var netstock = from c in db.AME_Vehicle_PurchaseEntry.Where(t => t.Vp_Chassisno == ddl_chessisno.SelectedItem.Text && t.Branch_Name == branchname && t.Vp_NetQuantity != 0)
                       group new { c } by new { c.Vp_Chassisno } into quantity
                       let total = quantity.Sum(s => s.c.Vp_Quantity)
                       select new
                       {
                           tot = total,

                       };
        txt_AvailQuantity.Text = Convert.ToString(netstock.First().tot);

    }
    protected void txt_Quantity_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(txt_Quantity.Text) != 1)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Quantity Must be 1.!!!');</script>", false);
            txt_Quantity.Text = "";

            return;
        }

    }


    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("Vehicle_SalesListDatewise.aspx");
    }
    protected void txt_billno_TextChanged(object sender, EventArgs e)
    {
        if (txt_billno.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Bill No shouldnot bE blank..!!'); </script>", false);
            txt_billno.Focus();
            tbl_details.Visible = false;
            return;
        }
        string branchname = Session["Branch"].ToString();
        string id = Convert.ToString(txt_billno.Text);
        var SalesList = from c in db.AME_Vehicle_SaleEntryDetails.Where(t => t.Vs_Billno == id && t.Branch_Name == branchname)
                        select c;

        if (Convert.ToInt32(SalesList.Count()) > 0)
        {
            if (SalesList.First().Vq_Status == "SEC")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('This Bill Is Canceled..!!'); </script>", false);
                txt_billno.Focus();
                txt_billno.Text = "";
                return;

            }
            if (SalesList.First().Vq_Status == "SalesReturn")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('This Bill Is Returned..!!'); </script>", false);
                txt_billno.Focus();
                txt_billno.Text = "";
                return;

            }
            FillParty();
            Label1.Text = Convert.ToString(SalesList.First().Vs_Billno);
            ddl_invtype.SelectedItem.Text = SalesList.First().Vs_InvType;
            ddl_partyname.SelectedValue = Convert.ToString(SalesList.First().Vq_PartyName);
            txt_billdate.Text = SalesList.First().Vs_Billdate.ToString("dd/MM/yyyy");
            txt_sdname.Text = SalesList.First().Vs_SdName;
            txt_tinno.Text = SalesList.First().Vs_TinNo;
            txt_address.Text = SalesList.First().Vq_Address;
            txt_do.Text = SalesList.First().Vs_Do;
            txt_phoneno.Text = SalesList.First().Vq_Phone;
            txt_hyp.Text = SalesList.First().Vs_Hyp;
            var SalesEntry = from c in db.AME_Vehicle_SaleEntry.Where(t => t.Vs_Billno == id && t.Branch_Name == branchname)
                             select c;

            ddl_VType.SelectedItem.Text = SalesEntry.First().Mv_VehicleType;
            fillModelno();
            ddl_model.SelectedValue = Convert.ToString(SalesEntry.First().Mv_ModelName);
            fillchassisno();

            txt_category.Text = SalesEntry.First().Mv_Category;
            txt_makers.Text = SalesEntry.First().Mv_Makers;
            ddl_chessisno.SelectedItem.Text = SalesEntry.First().Vp_Chassisno;
            txt_engineno.Text = SalesEntry.First().Vp_Engineno;
            txt_color.Text = SalesEntry.First().Vp_Color;
            txt_keyno.Text = SalesEntry.First().Vp_Keyno;
            txt_batterydetails.Text = SalesEntry.First().Vse_BatteryDetails;
            txt_horsepwr.Text = SalesEntry.First().Mv_HPower;
            txt_fuelused.Text = SalesEntry.First().Mv_FuelUsed;
            txt_nocylinder.Text = SalesEntry.First().Mv_Cylinders;
            txt_mfdate.Text = SalesEntry.First().Vse_MfDate.ToString("dd/MM/yyyy");
            txt_uldnweight.Text = SalesEntry.First().Mv_UnladedWeight;
            txt_Seat.Text = SalesEntry.First().Mv_SeatCapacity;
            txt_Bodytype.Text = SalesEntry.First().Mv_BodyType;
            txt_grossweight.Text = SalesEntry.First().Mv_GrossWeight;
            txt_tyremake.Text = SalesEntry.First().Vse_TyreMake;
            txt_trademarkno.Text = SalesEntry.First().Vse_TradeMarkno;
            ddl_toolkit.SelectedItem.Text = SalesEntry.First().Vse_Toolkit;
            txt_form.Text = SalesEntry.First().Vse_Form21;
            ddl_stepeny.SelectedItem.Text = SalesEntry.First().Vse_Stephny;
            ddl_owner.SelectedItem.Text = SalesEntry.First().Vse_OwnersManual;
            ddl_baterywarenty.SelectedItem.Text = SalesEntry.First().Vse_Warrenty;
            ddl_fscbook.SelectedItem.Text = SalesEntry.First().Vse_FscBook;
            ddl_insurance.SelectedItem.Text = SalesEntry.First().Vse_insurance;
            txt_insurancecompany.Text = SalesEntry.First().Vse_InsuranceCompany;
            txt_rate.Text = Convert.ToString(SalesEntry.First().Vse_Rate);
            txt_Quantity.Text = Convert.ToString(SalesEntry.First().Vse_Quantity);
            txt_amount.Text = Convert.ToString(SalesEntry.First().Vse_Amount);
            txt_GrossAmount.Text = Convert.ToString(SalesEntry.First().Vse_GrossAmount);
            txt_DiscountAmount.Text = Convert.ToString(SalesEntry.First().Vse_DiscountAmount);
            txtvat.Text = Convert.ToString(SalesEntry.First().Vse_VatPercent);
            txt_vatamount.Text = Convert.ToString(SalesEntry.First().Vse_VatAmount);
            txt_other.Text = Convert.ToString(SalesEntry.First().Vse_Other);
            txt_billamount.Text = Convert.ToString(SalesEntry.First().Vse_Billamount);
            tbl_details.Visible = true;
        }

        else
        {
            txt_billno.Text = "";
            tbl_details.Visible = false;

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invalid Bill No..!!'); </script>", false);
            txt_billno.Focus();
            return;

        }
    }

    protected void btn_update_Click(object sender, EventArgs e)
    {
        try
        {

            if (txt_billno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Bill Number Should Not Be Blank..!!'); </script>", false);
                txt_billno.Focus();
                return;
            }
            

        }
        catch
        {

        }
    }

}