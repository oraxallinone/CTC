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
            txt_billdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            FillParty();
            fillsino();
            string sino = Request.QueryString["id"];
            string type = Request.QueryString["Type"];
            if (type == "View")
            {
                filldata(sino, type);
                ddl_partyname.Enabled = true;
                ddl_invtype.Enabled = true;
                btn_Submit.Visible = false;
                btnBookAdd.Visible = true;
                btn_Cancel.Visible = false;
                btn_back.Visible = true;
                SetTextBoxReadOnly<TextBox>(Master.FindControl("form1"), true);
                
            }
            if (type == "Edit")
            {
                filldata(sino, type);
                ddl_partyname.Enabled = true;
                ddl_invtype.Enabled = true;
                btn_Submit.Visible = false;
                btnBookAdd.Visible = true;
                btn_Cancel.Visible = false;
                btn_back.Visible = true;
                txt_billno.ReadOnly = true;
                btn_update.Visible = true;
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
    public void filldata(string sino, string type)
    {
        string branchname = Session["Branch"].ToString();
        string id = Convert.ToString(sino);
        var SalesList = from c in db.AME_Vehicle_SaleEntryDetails.Where(t=>t.Vs_Billno==id && t.Branch_Name==branchname)
                            select c;
        FillParty();
        txt_billno.Text =Convert.ToString(SalesList.First().Vs_Billno);
        ddl_invtype.SelectedValue = SalesList.First().Vs_InvType;
        ddl_partyname.SelectedValue=Convert.ToString(SalesList.First().Vq_PartyName);
        txt_billdate.Text = SalesList.First().Vs_Billdate.ToString("dd/MM/yyyy");
        txt_sdname.Text = SalesList.First().Vs_SdName;
        txt_tinno.Text = SalesList.First().Vs_TinNo;
        txt_address.Text = SalesList.First().Vq_Address;
        txt_do.Text = SalesList.First().Vs_Do;
        txt_phoneno.Text = SalesList.First().Vq_Phone;
        txt_hyp.Text = SalesList.First().Vs_Hyp;
        var SalesEntry = from c in db.AME_Vehicle_SaleEntry.Where(t => t.Vs_Billno == id && t.Branch_Name == branchname)
                        select c;
       
        ddl_VType.SelectedValue = SalesEntry.First().Mv_VehicleType;
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
        txt_mfdate.Text = SalesEntry.First().Vse_MfDate.ToString("MM/yyyy");
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
        txt_rate.Text =Convert.ToString(SalesEntry.First().Vse_Rate);
        txt_Quantity.Text = Convert.ToString(SalesEntry.First().Vse_Quantity);
        txt_amount.Text = Convert.ToString(SalesEntry.First().Vse_Amount);
        txt_GrossAmount.Text =Convert.ToString(SalesEntry.First().Vse_GrossAmount);
        txt_DiscountAmount.Text = Convert.ToString(SalesEntry.First().Vse_DiscountAmount);
        txtvat.Text = Convert.ToString(SalesEntry.First().Vse_VatPercent);
        txt_vatamount.Text = Convert.ToString(SalesEntry.First().Vse_VatAmount);
        txt_other.Text = Convert.ToString(SalesEntry.First().Vse_Other);
        txt_billamount.Text = Convert.ToString(SalesEntry.First().Vse_Billamount);
    }
    private void FillParty()
    {
        string Sale = Convert.ToString(Session["saletype"]);
        if (Session["saletype"] != null)
        {
            var v = from c in db.AME_Master_Customer.ToList()
                    where c.Mc_Status = true && c.Branch_Name == Session["Branch"].ToString() && c.Mc_SaleStatus==Sale
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
        else {

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
        var chessisno = from c in db.AME_Vehicle_PurchaseEntry.ToList().Where(t => t.Mv_VehicleType == ddl_VType.SelectedItem.Text && t.Mv_ModelName == modelname && t.Branch_Name == branchname && t.Vp_NetQuantity!=0 && t.PendingStatus=="False").OrderBy(t => t.Vpd_Id)
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
        string InvType = ddl_invtype.SelectedValue.ToString();

        if ((from c in db.AME_BillCounter where c.Branch_Name == branchname && c.BillType == InvType select c.BillCounter).Count() > 0)
        {
            int VNo = (int)(from c in db.AME_BillCounter where c.Branch_Name == branchname && c.BillType == InvType select c.BillCounter).Max();
            if (ddl_invtype.SelectedItem.Text == "Tax Invoice")
            {
                txt_billno.Text = "T/" + Convert.ToString(VNo + 1);
            }
            else
            {
                txt_billno.Text = "R/" + Convert.ToString(VNo + 1);
            }
        }
        else
        {
            txt_billno.Text = "Error";
        }
    }
   

 
 
    protected void ddl_model_SelectedIndexChanged(object sender, EventArgs e)
    {
        string branchname = Session["Branch"].ToString();
        var modeldetails = from c in db.AME_Master_VehicleModel.ToList().Where(t => t.Mv_ModelName == ddl_model.SelectedItem.Text && t.Branch_Name==branchname) select c;
        txt_makers.Text = modeldetails.First().Mv_Makers;
       
       
        txt_category.Text = modeldetails.First().Mv_Category;
        txt_horsepwr.Text = modeldetails.First().Mv_HPower;
        txt_fuelused.Text = modeldetails.First().Mv_FuelUsed;
        txt_nocylinder.Text = modeldetails.First().Mv_Cylinders;
        txt_grossweight.Text = modeldetails.First().Mv_GrossWeight;
        txt_uldnweight.Text = modeldetails.First().Mv_UnladedWeight;
        txt_Seat.Text = modeldetails.First().Mv_SeatCapacity;
        fillchassisno();
    }


        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_billno.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Bill Number Should Not Be Blank..!!'); </script>", false);
                    txt_billno.Focus();
                    return;
                }
              
                if (ddl_partyname.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Party name ..!!'); </script>", false);
                    ddl_partyname.Focus();
                    return;
                }
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
                if (txt_billdate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Bill date Should Not Be Blank..!!'); </script>", false);
                    txt_billdate.Focus();
                    return;
                }
                //if (txt_tinno.Text == "")
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Tin No Should Not Be Blank..!!'); </script>", false);
                //    txt_tinno.Focus();
                //    return;
                //}
                if (txt_hyp.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('HYP Should Not Be Blank..!!'); </script>", false);
                    txt_hyp.Focus();
                    return;
                }

         

                //////////////////////////////////

                if (ddl_VType.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Vehicle Type ..!!'); </script>", false);
                    ddl_VType.Focus();
                    return;
                }
              
               
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

                if (ddl_chessisno.SelectedIndex ==0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Chessis No..!!'); </script>", false);
                    ddl_chessisno.Focus();
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
                if (txt_horsepwr.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Horse Power Should Not Be Blank..!!'); </script>", false);
                    txt_horsepwr.Focus();
                    return;
                }

                if (txt_fuelused.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Fuel Used Should Not Be Blank..!!'); </script>", false);
                    txt_fuelused.Focus();
                    return;
                }
                if (txt_nocylinder.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('No Of Cylinders Should Not Be Blank..!!'); </script>", false);
                    txt_nocylinder.Focus();
                    return;
                }
                if (txt_mfdate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Magnified Date Should Not Be Blank..!!'); </script>", false);
                    txt_mfdate.Focus();
                    return;
                }
                if (txt_uldnweight.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Unloaded Weight  Should Not Be Blank..!!'); </script>", false);
                    txt_uldnweight.Focus();
                    return;
                }
                if (txt_Seat.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Seat No Should Not Be Blank..!!'); </script>", false);
                    txt_Seat.Focus();
                    return;
                }
                if (txt_grossweight.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Gross Weight  Should Not Be Blank..!!'); </script>", false);
                    txt_grossweight.Focus();
                    return;
                }
                if (ddl_toolkit.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Toolkit ..!!'); </script>", false);
                    ddl_toolkit.Focus();
                    return;
                }
                if (txt_form.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Form Name  Should Not Be Blank..!!'); </script>", false);
                    txt_form.Focus();
                    return;
                }
                if (ddl_stepeny.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select One For Stephny ..!!'); </script>", false);
                    ddl_stepeny.Focus();
                    return;
                }
                if (ddl_owner.SelectedItem.Text == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select One For Owners  ..!!'); </script>", false);
                    ddl_owner.Focus();
                    return;
                }
                if (ddl_baterywarenty.SelectedItem.Text == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Battery warrenty ..!!'); </script>", false);
                    ddl_baterywarenty.Focus();
                    return;
                }
                if (ddl_fscbook.SelectedItem.Text == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Fsc  ..!!'); </script>", false);
                    ddl_fscbook.Focus();
                    return;
                }
                if (ddl_insurance.SelectedItem.Text == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Insurance  ..!!'); </script>", false);
                    ddl_insurance.Focus();
                    return;
                }
                if (txt_insurancecompany.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Enter Insurance Company Name  ..!!'); </script>", false);
                    txt_insurancecompany.Focus();
                    return;
                }

                if (txt_rate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Rate Should Not Be Blank..!!'); </script>", false);
                    txt_rate.Focus();
                    return;
                }
                if (txt_Quantity.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Quantity Should Not Be Blank..!!'); </script>", false);
                    txt_Quantity.Focus();
                    return;
                }
                if (txt_amount.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Amount Should Not Be Blank..!!'); </script>", false);
                    txt_amount.Focus();
                    return;
                }
                if (txt_GrossAmount.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Gross Amount Should Not Be Blank..!!'); </script>", false);
                    txt_GrossAmount.Focus();
                    return;
                }
                if (txt_DiscountAmount.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Discount Amount Should Not Be Blank..!!'); </script>", false);
                    txt_DiscountAmount.Focus();
                    return;
                }
                if (txtvat.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Vat Percent Should Not Be Blank..!!'); </script>", false);
                    txtvat.Focus();
                    return;
                }
                if (txt_vatamount.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Vat Amount Should Not Be Blank..!!'); </script>", false);
                    txt_vatamount.Focus();
                    return;
                }
                if (txt_other.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Other Amount Should Not Be Blank..!!'); </script>", false);
                    txt_other.Focus();
                    return;
                }
                if (txt_billamount.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Other Amount Should Not Be Blank..!!'); </script>", false);
                    txt_billamount.Focus();
                    return;
                }
                if (txt_tcno.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('T.C No Should Not Be Blank..!!'); </script>", false);
                    txt_tcno.Focus();
                    return;
                }
                string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy" };
                DateTime expectedDate;
                if (!DateTime.TryParseExact(txt_billdate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                    txt_billdate.Focus();
                    return;
                }
                string[] formats1 = { "MM/yyyy", "M/yyyy", "MMM/yyyy" };
                if (!DateTime.TryParseExact(txt_mfdate.Text, formats1, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (MMM/YYYY)..!!');", true);
                    txt_mfdate.Focus();
                    return;
                }
                if (Convert.ToDecimal(txt_AvailQuantity.Text) == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('You Cant sale It Your Stock Amount Is 0.!!!');</script>", false);
                    txt_Quantity.Text = "";
                    return;
                }


                AME_Vehicle_SaleEntryDetails vsd = new AME_Vehicle_SaleEntryDetails();
                vsd.Branch_Name = Session["Branch"].ToString();
                vsd.Created_By = Session["Uid"].ToString();
                vsd.Created_Date = SmitaClass.IndianTime();
                vsd.Vq_Address = txt_address.Text;
                vsd.Vq_PartyName =Convert.ToInt32(ddl_partyname.SelectedValue);
                vsd.Vq_Phone = txt_phoneno.Text;
                vsd.Vq_Status = "SE";
                vsd.Vs_Billdate = Convert.ToDateTime(txt_billdate.Text, SmitaClass.dateformat());
                vsd.Vs_Billno = Convert.ToString(txt_billno.Text);
                vsd.Vs_Do = txt_do.Text;
                vsd.Vs_Hyp = txt_hyp.Text;
                vsd.Vs_InvType = ddl_invtype.SelectedItem.Text;
                vsd.Vs_SdName = txt_sdname.Text;
                vsd.Vs_TinNo = txt_tinno.Text;
                db.AddToAME_Vehicle_SaleEntryDetails(vsd);
                db.SaveChanges();

                //fill sales entry table
                AME_Vehicle_SaleEntry vse = new AME_Vehicle_SaleEntry();
                vse.Branch_Name = Session["Branch"].ToString();
                vse.Created_By = Session["Uid"].ToString();
                vse.Created_Date = SmitaClass.IndianTime();
                vse.Mv_BodyType = txt_Bodytype.Text;
                vse.Mv_Category = txt_category.Text;
                vse.Mv_Cylinders = txt_nocylinder.Text;
                vse.Mv_FuelUsed = txt_fuelused.Text;
                vse.Mv_GrossWeight = txt_grossweight.Text;
                vse.Mv_HPower = txt_horsepwr.Text;
                vse.Mv_Makers = txt_makers.Text;
                vse.Mv_ModelName =Convert.ToInt32(ddl_model.SelectedValue);
                vse.Mv_SeatCapacity = txt_Seat.Text;
                vse.Mv_UnladedWeight = txt_uldnweight.Text;
                vse.Mv_VehicleType = ddl_VType.SelectedItem.Text;
                vse.Status = "SE";
                vse.Mv_LcvType = ddl_lcvtype.SelectedValue.ToString();
                vse.MV_TCNO = txt_tcno.Text;
                vse.Vp_Chassisno = ddl_chessisno.SelectedItem.Text;
                vse.Vp_Color = txt_color.Text;
                vse.Vp_Engineno = txt_engineno.Text;
                vse.Vp_Keyno = txt_keyno.Text;
                vse.Vs_Billno = Convert.ToString(txt_billno.Text);
                vse.Vse_Amount = Convert.ToDecimal(txt_amount.Text);
                vse.Vse_BatteryDetails = txt_batterydetails.Text;
                vse.Vse_Billamount = Convert.ToDecimal(txt_billamount.Text);
                vse.Vse_DiscountAmount = Convert.ToDecimal(txt_DiscountAmount.Text);
                vse.Vse_Form21 = txt_form.Text;
                vse.Vse_FscBook = ddl_fscbook.SelectedItem.Text;
                vse.Vse_GrossAmount = Convert.ToDecimal(txt_GrossAmount.Text);
                vse.Vse_insurance = ddl_insurance.SelectedItem.Text;
                vse.Vse_InsuranceCompany = txt_insurancecompany.Text;
                vse.Vse_MfDate = Convert.ToDateTime(txt_mfdate.Text, SmitaClass.dateformat());
                vse.Vse_Other = Convert.ToDecimal(txt_other.Text);
                vse.Vse_OwnersManual = ddl_owner.SelectedItem.Text;
                vse.Vse_Quantity = Convert.ToDecimal(txt_Quantity.Text);
                vse.Vse_Rate = Convert.ToDecimal(txt_rate.Text);
                vse.Vse_Stephny = ddl_stepeny.SelectedItem.Text;
                vse.Vse_Toolkit = ddl_toolkit.SelectedItem.Text;
                vse.Vse_TradeMarkno = txt_trademarkno.Text;
                vse.Vse_TyreMake = txt_tyremake.Text;
                vse.Vse_VatAmount = Convert.ToDecimal(txt_vatamount.Text);
                vse.Vse_VatPercent = Convert.ToDecimal(txtvat.Text);
                vse.Vse_Warrenty = ddl_baterywarenty.SelectedItem.Text;
                db.AddToAME_Vehicle_SaleEntry(vse);
                db.SaveChanges();


                //update purchaseentry table

                int modelname = Convert.ToInt32(ddl_model.SelectedValue);
                string branchname = Session["Branch"].ToString();
                AME_Vehicle_PurchaseEntry vp = db.AME_Vehicle_PurchaseEntry.ToList().First(t => t.Mv_VehicleType == ddl_VType.SelectedItem.Text && t.Mv_ModelName == modelname && t.Branch_Name == branchname && t.Vp_Chassisno == ddl_chessisno.SelectedItem.Text);
                vp.Vp_NetQuantity = 0;
               
                db.SaveChanges();

                //Bill Counter
                string InvType = ddl_invtype.SelectedValue.ToString();
                int id123 = (int)(from c in db.AME_BillCounter where c.Branch_Name == branchname && c.BillType == InvType select c.BillCounter).Max();
                AME_BillCounter OR = db.AME_BillCounter.First(t => t.Branch_Name == branchname && t.BillType == InvType);
                OR.BillCounter = id123 + 1;
                db.SaveChanges();       
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Sales Done Sucessfully..!!!');</script>", false);
                cl.Clear_All(this);


                fillsino();
            }
            catch
            {

            }
        }
        protected void ddl_VType_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillModelno();
            if (ddl_VType.SelectedValue == "HCV")
            {
                Label3.Visible = false;
                ddl_lcvtype.Visible = false;
                txt_tcno.Text = "T.C NO-OR05-0367 valid upto 14.10.2015";
            }
            else
            {
                Label3.Visible = true;
                ddl_lcvtype.Visible = true;
            }
        }
        protected void ddl_partyname_SelectedIndexChanged(object sender, EventArgs e)
        {
            string branchname = Session["Branch"].ToString();
            var PartyDetails = from c in db.AME_Master_Customer.Where(t => t.Mc_Name == ddl_partyname.SelectedItem.Text && t.Branch_Name == branchname) select c;
            if (PartyDetails.Count() > 0)
            {
                txt_address.Text = PartyDetails.First().Mc_Address;
                txt_phoneno.Text = PartyDetails.First().Mc_Mobileno;
                txt_tinno.Text = PartyDetails.First().Mc_Tin;
            }
            else
            {
                txt_address.Text = "";
                txt_phoneno.Text = "";
                txt_tinno.Text = "";
            }
        }
        protected void ddl_chessisno_SelectedIndexChanged(object sender, EventArgs e)
        {
             string branchname = Session["Branch"].ToString();
             var chessis = from c in db.AME_Vehicle_PurchaseEntry.Where(t=>t.Vp_Chassisno == ddl_chessisno.SelectedItem.Text && t.Branch_Name == branchname && t.Vp_NetQuantity!=0) select c;
             txt_engineno.Text = chessis.First().Vp_Engineno;
             txt_color.Text = chessis.First().Vp_Color;
             txt_keyno.Text = chessis.First().Vp_Keyno;


             var model = from c in db.AME_Vehicle_PurchaseEntry.ToList().Where(t => t.Vp_Chassisno == ddl_chessisno.SelectedItem.Text) select c;
             txt_rate.Text = Convert.ToString(model.First().Vp_Rate);
             txt_amount.Text = Convert.ToString(model.First().Vp_Rate);
             txt_billamount.Text = Convert.ToString(model.First().Vp_Rate);
             txt_vatamount.Text = Convert.ToString(Convert.ToDecimal(txt_billamount.Text) * Convert.ToDecimal(txtvat.Text) / 100);

             txt_GrossAmount.Text = Convert.ToString(Convert.ToDecimal(txt_billamount.Text) - Convert.ToDecimal(txt_vatamount.Text));


            var netstock = from c in db.AME_Vehicle_PurchaseEntry.Where(t => t.Vp_Chassisno == ddl_chessisno.SelectedItem.Text && t.Branch_Name == branchname && t.Vp_NetQuantity!=0)
                           group new { c } by new { c.Vp_Chassisno } into quantity
                           let total = quantity.Sum(s => s.c.Vp_Quantity)
                           select new
                           {
                               tot = total,

                           };
            txt_AvailQuantity.Text =Convert.ToString(netstock.First().tot);
           
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

        protected void ddl_invtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillsino();
        }
        protected void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
             string branchname = Session["Branch"].ToString();
             AME_Vehicle_SaleEntryDetails vsdu = db.AME_Vehicle_SaleEntryDetails.First(t => t.Vs_Billno == txt_billno.Text && t.Branch_Name == branchname);


                vsdu.Vq_PartyName = Convert.ToInt32(ddl_partyname.SelectedValue);

                vsdu.Vs_Billdate = Convert.ToDateTime(txt_billdate.Text, SmitaClass.dateformat());

                vsdu.Vs_TinNo = txt_tinno.Text;

                db.SaveChanges();

                //fill sales entry table
                AME_Vehicle_SaleEntry vseupdate = db.AME_Vehicle_SaleEntry.First(t => t.Vs_Billno == txt_billno.Text && t.Branch_Name == branchname);

                vseupdate.Mv_BodyType = txt_Bodytype.Text;
                vseupdate.Mv_Category = txt_category.Text;
                vseupdate.Mv_Cylinders = txt_nocylinder.Text;
                vseupdate.Mv_FuelUsed = txt_fuelused.Text;
                vseupdate.Mv_GrossWeight = txt_grossweight.Text;
                vseupdate.Mv_HPower = txt_horsepwr.Text;
                vseupdate.Mv_Makers = txt_makers.Text;
                vseupdate.Mv_ModelName = Convert.ToInt32(ddl_model.SelectedValue);
                vseupdate.Mv_SeatCapacity = txt_Seat.Text;
                vseupdate.Mv_UnladedWeight = txt_uldnweight.Text;
                vseupdate.Mv_VehicleType = ddl_VType.SelectedItem.Text;
                vseupdate.Status = "SE";
                vseupdate.Vp_Chassisno = ddl_chessisno.SelectedItem.Text;
                vseupdate.Vp_Color = txt_color.Text;
                vseupdate.Vp_Engineno = txt_engineno.Text;
                vseupdate.Vp_Keyno = txt_keyno.Text;

                vseupdate.Vse_Amount = Convert.ToDecimal(txt_amount.Text);
                vseupdate.Vse_BatteryDetails = txt_batterydetails.Text;
                vseupdate.Vse_Billamount = Convert.ToDecimal(txt_billamount.Text);
                vseupdate.Vse_DiscountAmount = Convert.ToDecimal(txt_DiscountAmount.Text);
                vseupdate.Vse_Form21 = txt_form.Text;
                vseupdate.Vse_FscBook = ddl_fscbook.SelectedItem.Text;
                vseupdate.Vse_GrossAmount = Convert.ToDecimal(txt_GrossAmount.Text);
                vseupdate.Vse_insurance = ddl_insurance.SelectedItem.Text;
                vseupdate.Vse_InsuranceCompany = txt_insurancecompany.Text;
                vseupdate.Vse_MfDate = Convert.ToDateTime(txt_mfdate.Text, SmitaClass.dateformat());
                vseupdate.Vse_Other = Convert.ToDecimal(txt_other.Text);
                vseupdate.Vse_OwnersManual = ddl_owner.SelectedItem.Text;
                vseupdate.Vse_Quantity = Convert.ToDecimal(txt_Quantity.Text);
                vseupdate.Vse_Rate = Convert.ToDecimal(txt_rate.Text);
                vseupdate.Vse_Stephny = ddl_stepeny.SelectedItem.Text;
                vseupdate.Vse_Toolkit = ddl_toolkit.SelectedItem.Text;
                vseupdate.Vse_TradeMarkno = txt_trademarkno.Text;
                vseupdate.Vse_TyreMake = txt_tyremake.Text;
                vseupdate.Vse_VatAmount = Convert.ToDecimal(txt_vatamount.Text);
                vseupdate.Vse_VatPercent = Convert.ToDecimal(txtvat.Text);
                vseupdate.Vse_Warrenty = ddl_baterywarenty.SelectedItem.Text;
               
                db.SaveChanges();

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Vehicle sale Update Sucessfully.!!!');</script>", false);

                return;
            }
            catch
            {

            }
        }
        protected void ddl_lcvtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_lcvtype.SelectedValue == "Commercial" && ddl_VType.SelectedValue == "LCV")
             
            {

                txt_tcno.Text ="T.C NO-0394 VALID UPTO 21.12.2015";

            }
            else if (ddl_lcvtype.SelectedValue == "Passenger" && ddl_VType.SelectedValue == "LCV")
            {
            txt_tcno.Text = "T.C NO-0382 VALID UPTO 24.01.2015";
            }
        }
}

    
