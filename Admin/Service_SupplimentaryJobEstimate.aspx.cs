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
            tbl_details.Visible = false;
            fillestimation();
            FillSEstimateNo();
        }
    }
    private void FillSEstimateNo()
    {
        string branchname = Session["Branch"].ToString();
        if ((from c in db.AME_Service_SupplementaryEstimateEntryDetails where c.Branch_Name == branchname select c.Se_SEstimateNo).Count() > 0)
        {
            int VNo = (int)(from c in db.AME_Service_SupplementaryEstimateEntryDetails where c.Branch_Name == branchname select c.Se_SEstimateNo).Max();
            txt_BEstimateNo.Text = Convert.ToString(VNo + 1);
        }
        else
        {
            txt_BEstimateNo.Text = "1";
        }
    }
     private void FillCustomer()
    {
         string Sale = Convert.ToString(Session["saletype"]);
         if (Session["saletype"] != null)
         {
             var v = from c in db.AME_Master_Customer.ToList().OrderBy(t => t.Mc_Name)
                     where c.Mc_Status = true && c.Branch_Name == Session["Branch"].ToString() && c.Mc_SaleStatus==Sale
                     select new
                     {
                         Cu_Name = c.Mc_Name + " - " + c.Mc_Mobileno,
                         Cu_Code = c.Mc_code
                     };
             ddl_BCustomer.DataSource = v.ToList();
             ddl_BCustomer.DataTextField = "Cu_Name";
             ddl_BCustomer.DataValueField = "Cu_Code";
             ddl_BCustomer.DataBind();
             ddl_BCustomer.Items.Insert(0, "--Select One--");
         }
         else
         {
             var v = from c in db.AME_Master_Customer.ToList().OrderBy(t => t.Mc_Name)
                     where c.Mc_Status = true && c.Branch_Name == Session["Branch"].ToString()
                     select new
                     {
                         Cu_Name = c.Mc_Name + " - " + c.Mc_Mobileno,
                         Cu_Code = c.Mc_code
                     };
             ddl_BCustomer.DataSource = v.ToList();
             ddl_BCustomer.DataTextField = "Cu_Name";
             ddl_BCustomer.DataValueField = "Cu_Code";
             ddl_BCustomer.DataBind();
             ddl_BCustomer.Items.Insert(0, "--Select One--");
         }
        
    }
     public void fillModelno()
     {
         string Sale = Convert.ToString(Session["saletype"]);
         if (Session["saletype"] != null)
         {
             string branch = Session["Branch"].ToString();
             var model = from c in db.AME_Master_VehicleModel.OrderBy(t => t.Mv_Id).Where(t => t.Branch_Name == branch && t.Mv_SaleStatus==Sale)
                         select new
                         {
                             mid = c.Mv_Code,
                             mname = c.Mv_ModelName
                         };
             ddl_BModel.DataSource = model.ToList();
             ddl_BModel.DataValueField = "mid";
             ddl_BModel.DataTextField = "mname";
             ddl_BModel.DataBind();
             ddl_BModel.Items.Insert(0, "..Select..");
         }
         else
         {
             string branch = Session["Branch"].ToString();
             var model = from c in db.AME_Master_VehicleModel.OrderBy(t => t.Mv_Id).Where(t => t.Branch_Name == branch)
                         select new
                         {
                             mid = c.Mv_Code,
                             mname = c.Mv_ModelName
                         };
             ddl_BModel.DataSource = model.ToList();
             ddl_BModel.DataValueField = "mid";
             ddl_BModel.DataTextField = "mname";
             ddl_BModel.DataBind();
             ddl_BModel.Items.Insert(0, "..Select..");
         }
            
       
     }
     [System.Web.Services.WebMethod]
     public static string[] GetPartNo(string prefixText, int count)
     {
         string branch = HttpContext.Current.Session["Branch"].ToString();
         AutoMobileEntities db = new AutoMobileEntities();
         return db.AME_Master_Item.Where(n => n.Itm_Partno.StartsWith(prefixText) && n.Branch_Name==branch).OrderBy(n => n.Itm_Partno).Select(n => n.Itm_Partno).Distinct().Take(count).ToArray();
     }

     [System.Web.Services.WebMethod]
     public static string[] GetPartDesc(string prefixText, int count)
     {
         string branch = HttpContext.Current.Session["Branch"].ToString();
         AutoMobileEntities db = new AutoMobileEntities();
         return db.AME_Master_Item.Where(n => n.Itm_PartDescrption.StartsWith(prefixText) && n.Branch_Name == branch).OrderBy(n => n.Itm_PartDescrption).Select(n => n.Itm_PartDescrption).Distinct().Take(count).ToArray();
     }

     [System.Web.Services.WebMethod]
     public static string[] GetServiceCode(string prefixText, int count)
     {
         string branch = HttpContext.Current.Session["Branch"].ToString();
         string Sale = HttpContext.Current.Session["saletype"].ToString();
         if (HttpContext.Current.Session["saletype"] != null)
         {
             AutoMobileEntities db = new AutoMobileEntities();
             return db.AME_Master_ServiceHead.Where(n => n.Mh_ServiceCode.StartsWith(prefixText) && n.Branch_Name == branch && n.Mh_SaleStatus == Sale).OrderBy(n => n.Mh_ServiceCode).Select(n => n.Mh_ServiceCode).Distinct().Take(count).ToArray();
         }
         else
         {
             AutoMobileEntities db = new AutoMobileEntities();
             return db.AME_Master_ServiceHead.Where(n => n.Mh_ServiceCode.StartsWith(prefixText) && n.Branch_Name == branch ).OrderBy(n => n.Mh_ServiceCode).Select(n => n.Mh_ServiceCode).Distinct().Take(count).ToArray();
         }
         
     }
    
    public void filldata()
    {
        string branchname = Session["Branch"].ToString();
        int id = Convert.ToInt32(ddlestimationno.Text);

          var isedit = from c in db.AME_Service_SupplementaryEstimateEntryDetails
                       .Where(t => t.Se_EstimateNo == id && t.Branch_Name == branchname)
                     select c;
        int counte = isedit.ToList().Count;
        if (counte <= 0)
        {
            var esimationdetails = from c in db.AME_Service_EstimateEntryDetails.Where(t => t.Se_EstimateNo == id && t.Branch_Name == branchname) select c;
            txt_BEstimateDate.Text = Convert.ToDateTime(esimationdetails.First().Se_EstimateDate).ToString("dd/MM/yyyy");
            FillCustomer();
            txt_BEstimateNo.Text = Convert.ToString(esimationdetails.First().Se_EstimateNo);
            ddl_BCustomer.Text = esimationdetails.First().Se_CustomerCode;
            fillModelno();
            ddl_BModel.Text = esimationdetails.First().Se_VehicleModel;
            txt_BSaleDate.Text = Convert.ToDateTime(esimationdetails.First().Se_SaleDate).ToString("dd/MM/yyyy");
            txt_BChasisNo.Text = esimationdetails.First().Se_ChasisNo;
            txt_BEngineNo.Text = esimationdetails.First().Se_EngineNo;
            txt_BKiloMeter.Text = esimationdetails.First().Se_Kilometer;
            txt_BRegdNo.Text = esimationdetails.First().Se_RegdNo;
            txt_AGrossAmount.Text = Convert.ToString(esimationdetails.First().Se_ServiceGrossAmount);
            txt_ALabDiscountPer.Text = Convert.ToString(esimationdetails.First().Se_ServiceDiscountPer);
            txt_ANetAmount.Text = Convert.ToString(esimationdetails.First().Se_ServiceNetAmount);
            txt_AVatAmount.Text = Convert.ToString(esimationdetails.First().Se_VatAmount);
            txt_ATotalSpareAmount.Text = Convert.ToString(esimationdetails.First().Se_TotalSpareAmount);
            //txt_ALabourCharges.Text = Convert.ToString(esimationdetails.First().Se_LabourCharges);
            //txt_ALabDiscountPer.Text = Convert.ToString(esimationdetails.First().Se_LabourDiscountPer);
            //txt_ALabDiscountAmount.Text = Convert.ToString(esimationdetails.First().Se_LabourDiscountAmount);
            //txt_ALabourChargesAftDisc.Text = Convert.ToString(esimationdetails.First().Se_NetLabourCharges);

            //txt_AServiceTaxPer.Text = Convert.ToString(esimationdetails.First().Se_ServiceTaxPer);
            //txt_AServiceTaxAmt.Text = Convert.ToString(esimationdetails.First().Se_ServiceTaxAmount);


            txt_ALabourCharges.Text = "0.0";
            txt_ALabDiscountPer.Text = "0.0";
            txt_ALabDiscountAmount.Text = "0.0";
            txt_ALabourChargesAftDisc.Text = "0.0";
            txt_AServiceTaxPer.Text = "0.0";
            txt_AServiceTaxAmt.Text = "0.0";


            txt_AOtherAmount.Text = Convert.ToString(esimationdetails.First().Se_OtherCharges);
            txt_ABillAmount.Text = Convert.ToString(esimationdetails.First().Se_BillAmount);
            txt_ASerDiscountAmount.Text = Convert.ToString(esimationdetails.First().Se_ServiceDiscountAmt);
            btn_Submit.ToolTip = Convert.ToString(esimationdetails.First().Se_EstimateNo);
        }
        else
        {
            var esimationdetails = from c in db.AME_Service_SupplementaryEstimateEntryDetails.Where(t => t.Se_EstimateNo == id && t.Branch_Name == branchname) select c;
            txt_BEstimateDate.Text = Convert.ToDateTime(esimationdetails.First().Se_EstimateDate).ToString("dd/MM/yyyy");
            FillCustomer();
            txt_BEstimateNo.Text = Convert.ToString(esimationdetails.First().Se_EstimateNo);
            ddl_BCustomer.Text = esimationdetails.First().Se_CustomerCode;
            fillModelno();
            ddl_BModel.Text = esimationdetails.First().Se_VehicleModel;
            txt_BSaleDate.Text = Convert.ToDateTime(esimationdetails.First().Se_SaleDate).ToString("dd/MM/yyyy");
            txt_BChasisNo.Text = esimationdetails.First().Se_ChasisNo;
            txt_BEngineNo.Text = esimationdetails.First().Se_EngineNo;
            txt_BKiloMeter.Text = esimationdetails.First().Se_Kilometer;
            txt_BRegdNo.Text = esimationdetails.First().Se_RegdNo;
            txt_AGrossAmount.Text = Convert.ToString(esimationdetails.First().Se_ServiceGrossAmount);
            txt_ALabDiscountPer.Text = Convert.ToString(esimationdetails.First().Se_ServiceDiscountPer);
            txt_ANetAmount.Text = Convert.ToString(esimationdetails.First().Se_ServiceNetAmount);
            txt_AVatAmount.Text = Convert.ToString(esimationdetails.First().Se_VatAmount);
            txt_ATotalSpareAmount.Text = Convert.ToString(esimationdetails.First().Se_TotalSpareAmount);
           
            //txt_ALabourCharges.Text = Convert.ToString(esimationdetails.First().Se_LabourCharges);
            //txt_ALabDiscountPer.Text = Convert.ToString(esimationdetails.First().Se_LabourDiscountPer);
            //txt_ALabDiscountAmount.Text = Convert.ToString(esimationdetails.First().Se_LabourDiscountAmount);
            //txt_ALabourChargesAftDisc.Text = Convert.ToString(esimationdetails.First().Se_NetLabourCharges);
            //txt_AServiceTaxPer.Text = Convert.ToString(esimationdetails.First().Se_ServiceTaxPer);
            //txt_AServiceTaxAmt.Text = Convert.ToString(esimationdetails.First().Se_ServiceTaxAmount);

            txt_ALabourCharges.Text = "0.0";
            txt_ALabDiscountPer.Text = "0.0";
            txt_ALabDiscountAmount.Text = "0.0";
            txt_ALabourChargesAftDisc.Text = "0.0";
            txt_AServiceTaxPer.Text = "0.0";
            txt_AServiceTaxAmt.Text = "0.0";
          
            txt_AOtherAmount.Text = Convert.ToString(esimationdetails.First().Se_OtherCharges);
            txt_ABillAmount.Text = Convert.ToString(esimationdetails.First().Se_BillAmount);
            txt_ASerDiscountAmount.Text = Convert.ToString(esimationdetails.First().Se_ServiceDiscountAmt);
            btn_Submit.ToolTip = Convert.ToString(esimationdetails.First().Se_EstimateNo);
        }
       
      
    }
    //spare details
    public void fillgridSparedata()
    {
        tbl_spareparts.Visible = false;
       
        string branchname=Session["Branch"].ToString();
        int id = Convert.ToInt32(ddlestimationno.Text);
        var pe = from c in db.AME_Service_EstimateSpareDetails
                      .Where(t => t.Se_EstimateNo == id && t.Branch_Name == branchname)
                 select c;
                      

        GridView2.DataSource = pe.ToList();
        GridView2.DataBind();
        foreach (GridViewRow gr in GridView2.Rows)
        {
            ImageButton edit = (ImageButton)gr.FindControl("imgbtn_edit");
            ImageButton delete = (ImageButton)gr.FindControl("imgbtn_PartDelete");
            edit.Visible = false;
            delete.Visible = false;

        }

    }
    //service details
    
    public void fillgridServicedetails()
    {
        tbl_service.Visible = false;
        string branchname = Session["Branch"].ToString();
        int id = Convert.ToInt32(ddlestimationno.Text);
        var isedit = from c in db.AME_Service_SupplementaryEstimateEntryDetails
                       .Where(t => t.Se_EstimateNo == id && t.Branch_Name == branchname)
                     select c;
        int counte = isedit.ToList().Count;
        if (counte <= 0)
        {
            var pe = from c in db.AME_Service_EstimateServiceDetails
                          .Where(t => t.Se_EstimateNo == id && t.Branch_Name == branchname)
                     select c;


            GridView1.DataSource = pe.ToList();
            GridView1.DataBind();
        }
        else
        {
            var pe = from c in db.AME_Service_SupplementaryEstimateServiceDetails
                              .Where(t => t.Se_EstimateNo == id && t.Branch_Name == branchname)
                     select c;


            GridView1.DataSource = pe.ToList();
            GridView1.DataBind();
        }
        foreach (GridViewRow gr in GridView1.Rows)
        {
            ImageButton edit = (ImageButton)gr.FindControl("imgbtn_SEdit");
            ImageButton delete = (ImageButton)gr.FindControl("imgbtn_SDelete");
            edit.Visible = false;
            delete.Visible = false;

        }

    }
    
    //service details
    decimal tots1 = 0;
    public void fillgridServiceEdit()
    {
        string branchname = Session["Branch"].ToString();
        int id = Convert.ToInt32(ddlestimationno.Text);
        var isedit = from c in db.AME_Service_SupplementaryEstimateEntryDetails
                       .Where(t => t.Se_EstimateNo == id && t.Branch_Name == branchname)
                     select c;
        int counte = isedit.ToList().Count;
        if (counte <= 0)
        {
            var pe = from c in db.AME_Service_EstimateServiceDetails
                          .Where(t => t.Se_EstimateNo == id && t.Branch_Name == branchname)
                     select c;


            GridView1.DataSource = pe.ToList();
            GridView1.DataBind();
        }
        else
        {
            var pe = from c in db.AME_Service_SupplementaryEstimateServiceDetails
                              .Where(t => t.Se_EstimateNo == id && t.Branch_Name == branchname)
                     select c;


            GridView1.DataSource = pe.ToList();
            GridView1.DataBind();
        }
        if (GridView1.Rows.Count > 0)
        {
            foreach (GridViewRow gr in GridView1.Rows)
            {
                Label lbl_Amount = (Label)gr.FindControl("Labels6");
                decimal TotAmt = Convert.ToDecimal(lbl_Amount.Text);

                tots1 = tots1 + TotAmt;

                txt_AGrossAmount.Text = Convert.ToString(SmitaClass.SignificantTruncate(tots1, 2));
                txt_ANetAmount.Text = Convert.ToString(Convert.ToDecimal(txt_AGrossAmount.Text) - Convert.ToDecimal(txt_ASerDiscountAmount.Text));

                decimal vatp = 0.145M;
                decimal netamt = Convert.ToDecimal(txt_ANetAmount.Text);
                decimal vat = netamt * vatp;
                txt_AVatAmount.Text = vat.ToString();

                txt_ALabourChargesAftDisc.Text = Convert.ToString(Convert.ToDecimal(txt_ALabourCharges.Text) - Convert.ToDecimal(txt_ALabDiscountAmount.Text));

                txt_ABillAmount.Text = Convert.ToString(Convert.ToDecimal(txt_ANetAmount.Text) + Convert.ToDecimal(txt_AVatAmount.Text) + Convert.ToDecimal(txt_ATotalSpareAmount.Text) + Convert.ToDecimal(txt_ALabourChargesAftDisc.Text) + Convert.ToDecimal(txt_AServiceTaxAmt.Text) + Convert.ToDecimal(txt_AOtherAmount.Text));


            }
        }
        else
        {
            txt_AGrossAmount.Text = "0.0";
            txt_ASerDiscountAmount.Text = "0.0";
            txt_ANetAmount.Text = "0.0";
            txt_AVatAmount.Text = "0.0";
            txt_ALabourChargesAftDisc.Text = Convert.ToString(Convert.ToDecimal(txt_ALabourCharges.Text) - Convert.ToDecimal(txt_ALabDiscountAmount.Text));
            txt_ABillAmount.Text = Convert.ToString(Convert.ToDecimal(txt_ANetAmount.Text) + Convert.ToDecimal(txt_AVatAmount.Text) + Convert.ToDecimal(txt_ATotalSpareAmount.Text) + Convert.ToDecimal(txt_ALabourChargesAftDisc.Text) + Convert.ToDecimal(txt_AServiceTaxAmt.Text) + Convert.ToDecimal(txt_AOtherAmount.Text));

        }

    }
    private void SetTextBoxReadOnly<T>(Control parent, bool readOnly) where T : TextBox
    {
        foreach (var tb in parent.Controls.OfType<T>())
            tb.ReadOnly = readOnly;

        foreach (Control c in parent.Controls)
            SetTextBoxReadOnly<T>(c, readOnly);
    }
   
     
    protected void imgbtn_PartDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgdelete = (ImageButton)sender;
        string sino = (imgdelete.ToolTip);
        int id = Convert.ToInt32(sino);
        AME_Service_SupplimentaryEstimateSpareDetails vq = db.AME_Service_SupplimentaryEstimateSpareDetails.ToList().First(t => t.Sp_Id == id);
        db.DeleteObject(vq);
        db.SaveChanges();
        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Data Deleted Sucessfully..!!');", true);

        string sino0 = Request.QueryString["id"];
        string type = Request.QueryString["Type"];
        fillgridSparepartEdit();

      
    }




    protected void txt_PartNo_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string branch = Session["Branch"].ToString();
            var v = from k in db.AME_Master_Item.ToList()
                    where (k.Itm_Partno.Equals(txt_PartNo.Text) && k.Branch_Name == branch)
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
            //txt_PartRate.Text = Convert.ToString(v.First().Itm_SalePrice);
            txt_PartVat.Text = Convert.ToString(v.First().Itm_VatPercent);
            // txt_PartQuantity.Focus();

            decimal vat = Convert.ToDecimal(txt_PartVat.Text);
            //decimal rate = Convert.ToDecimal(txt_PartRate.Text);
            decimal temp = Convert.ToDecimal(rate / (100 + vat));
            txt_PartAmount.Text = (temp * 100).ToString("0.00");
            txt_PartRate.Text = (temp * 100).ToString("0.00");
            ViewState["rate"] = rate;
            txt_PartQuantity.Focus();
            txt_PartQuantity.Text = "1";



            decimal amnt = temp * 100;

            decimal qty = Convert.ToDecimal(txt_PartQuantity.Text);
            txt_PartAmount.Text = (amnt * qty).ToString("0.00");
            txt_PartDiscount.Text = "0";
            //txt_PartDiscountper.Text = "0";
            decimal amnt1 = Convert.ToDecimal(txt_PartAmount.Text);
            decimal afterdisc = amnt1;
            txt_PartTaxAmount.Text = (afterdisc * (vat / 100)).ToString("0.00");

            decimal taxamnt = Convert.ToDecimal(txt_PartTaxAmount.Text);
            txt_PartTotal.Text = (afterdisc + taxamnt).ToString("0.00");
        }
        catch
        {
            txt_PartNo.Text = "";
            txt_PartDesc.Text = "";
            txt_PartRate.Text = "";
            txt_PartVat.Text = "";

            txt_PartDiscount.Text = "0";
            txt_PartQuantity.Focus();
            txt_PartQuantity.Text = "0";
        }
    }
    protected void txt_PartDesc_TextChanged(object sender, EventArgs e)
    {
        try
        {
            var v = from k in db.AME_Master_Item.ToList()
                    where (k.Itm_PartDescrption.Equals(txt_PartDesc.Text))
                    select new
                    {
                        k.Itm_Partno,
                        k.Itm_PartDescrption,
                        k.Itm_SalePrice,
                        k.Itm_VatPercent
                    };

            txt_PartNo.Text = v.First().Itm_Partno;
            txt_PartDesc.Text = Convert.ToString(v.First().Itm_PartDescrption);
            txt_PartRate.Text = Convert.ToString(v.First().Itm_SalePrice);
            txt_PartVat.Text = Convert.ToString(v.First().Itm_VatPercent);
            txt_PartQuantity.Focus();
        }
        catch
        {
            txt_PartNo.Text = "";
            txt_PartDesc.Text = "";
            txt_PartRate.Text = "";
            txt_PartVat.Text = "";
            txt_PartQuantity.Focus();
        }
    }
        protected void btn_ServiceAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_SCode.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Service Code Should Not Be Blank..!!'); </script>", false);
                    txt_SCode.Focus();
                    return;
                }
                if (txt_SDescription.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Description Should Not Be Blank..!!'); </script>", false);
                    txt_SDescription.Focus();
                    return;
                }

                if (txt_SQuantity.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Quantity Should Not Be Blank..!!'); </script>", false);
                    txt_SQuantity.Focus();
                    return;
                }

                if (txt_SRate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Rate Should Not Be Blank..!!'); </script>", false);
                    txt_SRate.Focus();
                    return;
                }
                if (txt_SAmount.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Amount Should Not Be Blank..!!'); </script>", false);
                    txt_SAmount.Focus();
                    return;
                }

                if (btn_ServiceAdd.Text == "Add")
                {
                    AME_Service_SupplementaryEstimateServiceDetails pr1 = new AME_Service_SupplementaryEstimateServiceDetails();
                    pr1.Se_SEstimateNo =Convert.ToInt32(txt_BEstimateNo.Text);
                    pr1.Mh_ServiceCode = txt_SCode.Text;
                    pr1.Mh_ServiceHead = txt_SDescription.Text;
                    pr1.Se_Quantity = Convert.ToDecimal(txt_SQuantity.Text);
                    pr1.Se_Rate = Convert.ToDecimal(txt_SRate.Text);
                    pr1.Se_Amount = Convert.ToDecimal(txt_SAmount.Text);
                    pr1.Status = true;
                    pr1.Branch_Name = Session["Branch"].ToString();
                    pr1.Created_By = Session["Uid"].ToString();
                    pr1.Created_Date = SmitaClass.IndianTime();
                    pr1.Se_EstimateNo = Convert.ToInt32(txt_BEstimateNo.Text);
                    db.AddToAME_Service_SupplementaryEstimateServiceDetails(pr1);
                    db.SaveChanges();

                    string sino0 = Request.QueryString["id"];
                    string type = Request.QueryString["Type"];
                    fillgridServiceEdit();

                    txt_SRate.Text = "";
                    txt_SQuantity.Text = "";
                    txt_SAmount.Text = "";
                    txt_SDescription.Text = "";
                    txt_SCode.Text = "";
                }
                else if (btn_ServiceAdd.Text == "Save")
                {
                    string id = btn_ServiceAdd.ToolTip;
                    int sino = Convert.ToInt32(id);
                    AME_Service_SupplementaryEstimateServiceDetails ses = db.AME_Service_SupplementaryEstimateServiceDetails.First(t => t.Ss_Id == sino);
                    ses.Mh_ServiceCode = txt_SCode.Text;
                    ses.Mh_ServiceHead = txt_SDescription.Text;
                    ses.Se_Quantity = Convert.ToDecimal(txt_SQuantity.Text);
                    ses.Se_Rate = Convert.ToDecimal(txt_SRate.Text);
                    ses.Se_Amount = Convert.ToDecimal(txt_SAmount.Text);
                    db.SaveChanges();
                    string sino0 = Request.QueryString["id"];
                    string type = Request.QueryString["Type"];
                    fillgridServiceEdit();
                   

                    txt_SRate.Text = "";
                    txt_SQuantity.Text = "";
                    txt_SAmount.Text = "";
                    txt_SDescription.Text = "";
                    txt_SCode.Text = "";
                    btn_ServiceAdd.Text = "Add";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Data Update sucessfully..!!'); </script>", false);
                    return;
                }
            }
            catch
            {

            }
        }
     decimal tot1 = 0, tot2 = 0, tot3 = 0, tot4 = 0;
     public void fillgridSparepartEdit()
     {
         tbl_service.Visible = true;
         tbl_spareparts.Visible = true;
         string branchname = Session["Branch"].ToString();
         int id = Convert.ToInt32(ddlestimationno.Text);

         var parts = from c in db.AME_Service_SupplimentaryEstimateSpareDetails
                       .Where(t => t.Se_EstimateNo == id && t.Branch_Name == branchname)
                  select c;


        GridView2.DataSource = parts.ToList();
        GridView2.DataBind();
        if (GridView2.Rows.Count > 0)
        {
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

                txt_ANetAmount.Text = Convert.ToString(Convert.ToDecimal(txt_AGrossAmount.Text) - Convert.ToDecimal(txt_ASerDiscountAmount.Text));
                txt_ATotalSpareAmount.Text = Convert.ToString(SmitaClass.SignificantTruncate(tot4, 2));
                txt_ALabourChargesAftDisc.Text = Convert.ToString(Convert.ToDecimal(txt_ALabourCharges.Text) - Convert.ToDecimal(txt_ALabDiscountAmount.Text));
                txt_ABillAmount.Text = Convert.ToString(Convert.ToDecimal(txt_ANetAmount.Text) + Convert.ToDecimal(txt_AVatAmount.Text) + Convert.ToDecimal(txt_ATotalSpareAmount.Text) + Convert.ToDecimal(txt_ALabourChargesAftDisc.Text) + Convert.ToDecimal(txt_AServiceTaxAmt.Text) + Convert.ToDecimal(txt_AOtherAmount.Text));
            }

        }
        else
        {

            txt_ATotalSpareAmount.Text = "0.0"; ;
            txt_ALabourChargesAftDisc.Text = Convert.ToString(Convert.ToDecimal(txt_ALabourCharges.Text) - Convert.ToDecimal(txt_ALabDiscountAmount.Text));
            txt_ABillAmount.Text = Convert.ToString(Convert.ToDecimal(txt_ANetAmount.Text) + Convert.ToDecimal(txt_AVatAmount.Text) + Convert.ToDecimal(txt_ATotalSpareAmount.Text) + Convert.ToDecimal(txt_ALabourChargesAftDisc.Text) + Convert.ToDecimal(txt_AServiceTaxAmt.Text) + Convert.ToDecimal(txt_AOtherAmount.Text));
        }
    }
        protected void btn_PartAdd_Click(object sender, EventArgs e)
        {
            try
            {

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

                if (txt_PartQuantity.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Quantity Should Not Be Blank..!!'); </script>", false);
                    txt_PartQuantity.Focus();
                    return;
                }

                if (txt_PartRate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Rate Should Not Be Blank..!!'); </script>", false);
                    txt_PartRate.Focus();
                    return;
                }
                if (txt_PartAmount.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Amount Should Not Be Blank..!!'); </script>", false);
                    txt_PartAmount.Focus();
                    return;
                }
                if (txt_PartDiscount.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Discount Should Not Be Blank..!!'); </script>", false);
                    txt_PartDiscount.Focus();
                    return;
                }
                if (txt_PartVat.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Vat Should Not Be Blank..!!'); </script>", false);
                    txt_PartVat.Focus();
                    return;
                }
                if (txt_PartTaxAmount.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Tax Amount Should Not Be Blank..!!'); </script>", false);
                    txt_PartTaxAmount.Focus();
                    return;
                }
                if (txt_PartTotal.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Total Should Not Be Blank..!!'); </script>", false);
                    txt_PartTotal.Focus();
                    return;
                }


                
                if (btn_PartAdd.Text == "Add")
                {
                    AME_Service_SupplimentaryEstimateSpareDetails sparepart = new AME_Service_SupplimentaryEstimateSpareDetails();
                    sparepart.Se_SEstimateNo = Convert.ToInt32(txt_BEstimateNo.Text);
                    sparepart.Branch_Name = Session["Branch"].ToString();
                    sparepart.Created_By = Session["Uid"].ToString();
                    sparepart.Created_Date = SmitaClass.IndianTime();
                    sparepart.Itm_PartDescrption = txt_PartDesc.Text;
                    sparepart.Itm_Partno = txt_PartNo.Text;
                    sparepart.Se_Amount = Convert.ToDecimal(txt_PartAmount.Text);
                    sparepart.Se_Rate = Convert.ToDecimal(txt_PartRate.Text);
                    sparepart.Se_Discount = Convert.ToDecimal(txt_PartDiscount.Text);
                    sparepart.Status = true;
                    sparepart.Se_EstimateNo = Convert.ToInt32(txt_BEstimateNo.Text);
                    sparepart.Se_Quantity = Convert.ToDecimal(txt_PartQuantity.Text);
                    sparepart.Se_TaxAmont = Convert.ToDecimal(txt_PartTaxAmount.Text);
                    sparepart.Se_Total = Convert.ToDecimal(txt_PartTotal.Text);
                    sparepart.Se_Vat = Convert.ToDecimal(txt_PartVat.Text);
                    db.AddToAME_Service_SupplimentaryEstimateSpareDetails(sparepart);
                    db.SaveChanges();

                    string sino0 = Request.QueryString["id"];
                    string type = Request.QueryString["Type"];
                    fillgridSparepartEdit();

                    txt_PartNo.Text = "";
                    txt_PartDesc.Text = "";
                    txt_PartQuantity.Text = "";
                    txt_PartRate.Text = "";
                    txt_PartAmount.Text = "";
                    
                    txt_PartVat.Text = "";
                    txt_PartTaxAmount.Text = "";
                    txt_PartTotal.Text = "";
                    int no = Convert.ToInt32(GridView2.Rows.Count);
                    txt_PartSlNo.Text = Convert.ToString(no);
                    txt_PartNo.Focus();
                }
                else if (btn_PartAdd.Text == "Save")
                {
                    string id = btn_PartAdd.ToolTip;
                    int sino = Convert.ToInt32(id);
                    AME_Service_SupplimentaryEstimateSpareDetails ses = db.AME_Service_SupplimentaryEstimateSpareDetails.First(t => t.Sp_Id == sino);
                    ses.Itm_Partno = txt_PartNo.Text;
                    ses.Itm_PartDescrption = txt_PartDesc.Text;
                    ses.Se_Quantity = Convert.ToDecimal(txt_PartQuantity.Text);
                    ses.Se_Rate = Convert.ToDecimal(txt_PartRate.Text);
                    ses.Se_Amount = Convert.ToDecimal(txt_PartAmount.Text);
                    ses.Se_Discount = Convert.ToDecimal(txt_PartDiscount.Text);
                    ses.Se_Vat = Convert.ToDecimal(txt_PartVat.Text);
                    ses.Se_TaxAmont = Convert.ToDecimal(txt_PartTaxAmount.Text);
                    ses.Se_Total = Convert.ToDecimal(txt_PartTotal.Text);
                    db.SaveChanges();
                    string sino0 = Request.QueryString["id"];
                    string type = Request.QueryString["Type"];
                    fillgridSparepartEdit();


                    txt_PartNo.Text = "";
                    txt_PartDesc.Text = "";
                    txt_PartQuantity.Text = "";
                    txt_PartRate.Text = "";
                    txt_PartAmount.Text = "";
                    txt_PartDiscount.Text = "0";
                    txt_PartVat.Text = "";
                    txt_PartTaxAmount.Text = "";
                    txt_PartTotal.Text = "";
                    int no = Convert.ToInt32(GridView2.Rows.Count);
                    txt_PartSlNo.Text = Convert.ToString(no);
                    txt_PartNo.Focus();
                    btn_PartAdd.Text = "Add";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Data Update sucessfully..!!'); </script>", false);
                    return;
                }
            }
            catch
            {

            }
}



        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {

                if (txt_BEstimateNo.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Voucher Number Should Not Be Blank..!!'); </script>", false);
                    txt_BEstimateNo.Focus();
                    return;
                }
                if (ddl_BCustomer.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Select Supplier Name..!!'); </script>", false);
                    ddl_BCustomer.Focus();
                    return;
                }
                if (txt_BEstimateDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Estimate Date Should Not Be Blank..!!'); </script>", false);
                    txt_BEstimateDate.Focus();
                    return;
                }
                if (txt_sedate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Supplimentary estimate Date should Not Be Blank ..!!'); </script>", false);
                    txt_sedate.Focus();
                    return;
                }
                if (ddl_BModel.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Select Model Name..!!'); </script>", false);
                    ddl_BModel.Focus();
                    return;
                }


                if (txt_AGrossAmount.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Gross Amount Should Not Be Blank..!!'); </script>", false);
                    txt_AGrossAmount.Focus();
                    return;
                }
                if (txt_ASerDiscountAmount.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Discount Amount Should Not Be Blank..!!'); </script>", false);
                    txt_ASerDiscountAmount.Focus();
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

                if (txt_AOtherAmount.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Other Amount Should Not Be Blank..!!'); </script>", false);
                    txt_AOtherAmount.Focus();
                    return;
                }
                if (txt_ABillAmount.Text == "" || txt_ABillAmount.Text == "0" || txt_ABillAmount.Text == "0.00")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Bill Amount Should Not Be Blank Or Zero..!!'); </script>", false);
                    txt_ABillAmount.Focus();
                    return;
                }
                string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy", "dd-MM-yyyy" };
                DateTime expectedDate;
                if (!DateTime.TryParseExact(txt_BEstimateDate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                    txt_BEstimateDate.Focus();
                    return;
                }
                if (!DateTime.TryParseExact(txt_sedate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                    txt_BEstimateDate.Focus();
                    return;
                }
                if (btn_Submit.Text == "Update")
                {
                    string eno = Convert.ToString(btn_Submit.ToolTip);
                    int estimationno = Convert.ToInt32(eno);

                    decimal billamount = Convert.ToDecimal(txt_ABillAmount.Text);
                    decimal no = Math.Round(billamount, 2);
                    AME_Service_SupplementaryEstimateEntryDetails see = db.AME_Service_SupplementaryEstimateEntryDetails.First(t => t.Se_EstimateNo == estimationno);

                    see.Se_EstimateDate = Convert.ToDateTime(txt_BEstimateDate.Text, SmitaClass.dateformat());
                    see.Se_CustomerCode = ddl_BCustomer.SelectedValue.ToString();
                    see.Se_VehicleModel = ddl_BModel.SelectedValue.ToString();
                    see.Se_RegdNo = txt_BRegdNo.Text;
                    see.Se_ChasisNo = txt_BChasisNo.Text;
                    see.Se_EngineNo = txt_BEngineNo.Text;
                    if (txt_BSaleDate.Text != "")
                    {
                        see.Se_SaleDate = Convert.ToDateTime(txt_BSaleDate.Text, SmitaClass.dateformat());
                    }
                    see.Se_Kilometer = txt_BKiloMeter.Text;
                    see.Se_ServiceGrossAmount = Convert.ToDecimal(txt_AGrossAmount.Text);
                    //see.Se_ServiceDiscountPer = Convert.ToDecimal(txt_ASerDiscountPer.Text);
                    see.Se_ServiceDiscountAmt = Convert.ToDecimal(txt_ASerDiscountAmount.Text);
                    see.Se_ServiceNetAmount = Convert.ToDecimal(txt_ANetAmount.Text);
                    see.Se_VatAmount = Convert.ToDecimal(txt_AVatAmount.Text);
                    see.Se_TotalSpareAmount = Convert.ToDecimal(txt_ATotalSpareAmount.Text);
                    see.Se_LabourCharges = Convert.ToDecimal(txt_ALabourCharges.Text);
                    see.Se_LabourDiscountPer = Convert.ToDecimal(txt_ALabDiscountPer.Text);
                    see.Se_LabourDiscountAmount = Convert.ToDecimal(txt_ALabDiscountAmount.Text);
                    see.Se_NetLabourCharges = Convert.ToDecimal(txt_ALabourChargesAftDisc.Text);
                    see.Se_ServiceTaxPer = Convert.ToDecimal(txt_AServiceTaxPer.Text);
                    see.Se_ServiceTaxAmount = Convert.ToDecimal(txt_AServiceTaxAmt.Text);
                    see.Se_OtherCharges = Convert.ToDecimal(txt_AOtherAmount.Text);
                    see.Se_BillAmount = no;
                    see.Se_SEstimateDate = Convert.ToDateTime(txt_sedate.Text, SmitaClass.dateformat());
                    db.SaveChanges();
                    //btn_Submit.Visible = false;
                  Session["Estimationno"]=txt_BEstimateNo.Text;
                    Response.Redirect("Service_ Print_SpupplimentaryJobEstimation.aspx");
                   
                    //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Data Update sucessfully..!!'); </script>", false);
                    //return;
                   
                }
                else if (btn_Submit.Text =="Add Supplimentary")
                {
                    int estimationno = Convert.ToInt32(ddlestimationno.SelectedValue);
                    string branch = Session["Branch"].ToString();
                    var eno = from c in db.AME_Service_SupplementaryEstimateEntryDetails.Where(t => t.Se_EstimateNo == estimationno && t.Branch_Name == branch) select c;
                    if (Convert.ToInt32(eno.Count()) > 0)
                    {

                        btn_Submit.Text = "Update";
                        fillgridSparepartEdit();
                        fillgridServiceEdit(); 
                    }
                    else
                    {
                        AME_Service_SupplementaryEstimateEntryDetails pd = new AME_Service_SupplementaryEstimateEntryDetails();
                        pd.Se_SEstimateNo = Convert.ToInt32(txt_BEstimateNo.Text);
                        pd.Se_EstimateNo = Convert.ToInt32(ddlestimationno.SelectedItem.Text);
                        pd.Se_EstimateDate = Convert.ToDateTime(txt_BEstimateDate.Text, SmitaClass.dateformat());
                        pd.Se_CustomerCode = ddl_BCustomer.SelectedValue.ToString();
                        pd.Se_VehicleModel = ddl_BModel.SelectedValue.ToString();
                        pd.Se_RegdNo = txt_BRegdNo.Text;
                        pd.Se_ChasisNo = txt_BChasisNo.Text;
                        pd.Se_EngineNo = txt_BEngineNo.Text;
                        if (txt_BSaleDate.Text != "")
                        {
                            pd.Se_SaleDate = Convert.ToDateTime(txt_BSaleDate.Text, SmitaClass.dateformat());
                        }
                        pd.Se_Kilometer = txt_BKiloMeter.Text;
                        pd.Se_ServiceGrossAmount = Convert.ToDecimal(txt_AGrossAmount.Text);
                        //pd.Se_ServiceDiscountPer = Convert.ToDecimal(txt_ASerDiscountPer.Text);
                        pd.Se_ServiceDiscountAmt = Convert.ToDecimal(txt_ASerDiscountAmount.Text);
                        pd.Se_ServiceNetAmount = Convert.ToDecimal(txt_ANetAmount.Text);
                        pd.Se_VatAmount = Convert.ToDecimal(txt_AVatAmount.Text);
                        pd.Se_TotalSpareAmount = Convert.ToDecimal(txt_ATotalSpareAmount.Text);
                        pd.Se_LabourCharges = Convert.ToDecimal(txt_ALabourCharges.Text);
                        pd.Se_LabourDiscountPer = Convert.ToDecimal(txt_ALabDiscountPer.Text);
                        pd.Se_LabourDiscountAmount = Convert.ToDecimal(txt_ALabDiscountAmount.Text);
                        pd.Se_NetLabourCharges = Convert.ToDecimal(txt_ALabourChargesAftDisc.Text);
                        pd.Se_ServiceTaxPer = Convert.ToDecimal(txt_AServiceTaxPer.Text);
                        pd.Se_ServiceTaxAmount = Convert.ToDecimal(txt_AServiceTaxAmt.Text);
                        pd.Se_OtherCharges = Convert.ToDecimal(txt_AOtherAmount.Text);
                        pd.Se_BillAmount = Convert.ToDecimal(txt_ABillAmount.Text);
                        pd.Status = true;

                        pd.Branch_Name = Session["Branch"].ToString();
                        pd.Created_By = Session["Uid"].ToString();
                        pd.Created_Date = SmitaClass.IndianTime();
                        pd.Se_SEstimateDate = Convert.ToDateTime(txt_sedate.Text, SmitaClass.dateformat());
                        db.AddToAME_Service_SupplementaryEstimateEntryDetails(pd);
                        db.SaveChanges();

                        foreach (GridViewRow gr in GridView2.Rows)
                        {
                            Label lbl_partno = (Label)gr.FindControl("Label10");
                            Label lbl_partDesc = (Label)gr.FindControl("Label12");
                            Label lbl_Quantity = (Label)gr.FindControl("Label11");
                            Label lbl_Rate = (Label)gr.FindControl("Label14");
                            Label lbl_Amount = (Label)gr.FindControl("Label13");
                            Label lbl_Discount = (Label)gr.FindControl("Label15");
                            Label lbl_Vat = (Label)gr.FindControl("Label16");
                            Label lbl_TaxAmt = (Label)gr.FindControl("Label17");
                            Label lbl_Total = (Label)gr.FindControl("Label18");

                            AME_Service_SupplimentaryEstimateSpareDetails pe = new AME_Service_SupplimentaryEstimateSpareDetails();
                            pe.Se_SEstimateNo = Convert.ToInt32(txt_BEstimateNo.Text);
                            pe.Se_EstimateNo = Convert.ToInt32(ddlestimationno.SelectedItem.Text);
                            pe.Itm_Partno = lbl_partno.Text;
                            pe.Itm_PartDescrption = lbl_partDesc.Text;
                            pe.Se_Quantity = Convert.ToDecimal(lbl_Quantity.Text);
                            pe.Se_Rate = Convert.ToDecimal(lbl_Rate.Text);
                            pe.Se_Amount = Convert.ToDecimal(lbl_Amount.Text);
                            pe.Se_Discount = Convert.ToDecimal(lbl_Discount.Text);
                            pe.Se_Vat = Convert.ToDecimal(lbl_Vat.Text);
                            pe.Se_TaxAmont = Convert.ToDecimal(lbl_TaxAmt.Text);
                            pe.Se_Total = Convert.ToDecimal(lbl_Total.Text);
                            pe.Status = true;

                            pe.Branch_Name = Session["Branch"].ToString();
                            pe.Created_By = Session["Uid"].ToString();
                            pe.Created_Date = SmitaClass.IndianTime();
                            db.AddToAME_Service_SupplimentaryEstimateSpareDetails(pe);
                            db.SaveChanges();
                        }

                        foreach (GridViewRow gr in GridView1.Rows)
                        {
                            Label lbl_ServiceCode = (Label)gr.FindControl("Labels2");
                            Label lbl_Desc = (Label)gr.FindControl("Labels3");
                            Label lbl_Quantity = (Label)gr.FindControl("Labels4");
                            Label lbl_Rate = (Label)gr.FindControl("Labels5");
                            Label lbl_Amount = (Label)gr.FindControl("Labels6");

                            AME_Service_SupplementaryEstimateServiceDetails spe = new AME_Service_SupplementaryEstimateServiceDetails();
                            spe.Se_SEstimateNo = Convert.ToInt32(txt_BEstimateNo.Text);
                            spe.Se_EstimateNo = Convert.ToInt32(ddlestimationno.SelectedItem.Text);
                            spe.Mh_ServiceCode = lbl_ServiceCode.Text;
                            spe.Mh_ServiceHead = lbl_Desc.Text;
                            spe.Se_Quantity = Convert.ToDecimal(lbl_Quantity.Text);
                            spe.Se_Rate = Convert.ToDecimal(lbl_Rate.Text);
                            spe.Se_Amount = Convert.ToDecimal(lbl_Amount.Text);
                            spe.Status = true;

                            spe.Branch_Name = Session["Branch"].ToString();
                            spe.Created_By = Session["Uid"].ToString();
                            spe.Created_Date = SmitaClass.IndianTime();
                            db.AddToAME_Service_SupplementaryEstimateServiceDetails(spe);
                            db.SaveChanges();
                        }
                        btn_Submit.Text = "Update";
                        fillgridSparepartEdit();
                        fillgridServiceEdit(); 
                    }
                   
                    //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('ESTIMATE Entry done SuccessFully..!!'); </script>", false);

                    //return;

                }
            }
            catch
            {

            }
        }
        protected void imgbtn_SEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string branchname = Session["Branch"].ToString();
                ImageButton imgbtnEdit = (ImageButton)sender;
                foreach (GridViewRow gr in GridView1.Rows)
                {
                    gr.BackColor = System.Drawing.Color.Transparent;
                }

                GridViewRow row = imgbtnEdit.NamingContainer as GridViewRow;
                row.BackColor = System.Drawing.Color.Pink;

                string sino = (imgbtnEdit.ToolTip);
                int id = Convert.ToInt32(sino);
                var quotationlist = from c in db.AME_Service_SupplementaryEstimateServiceDetails.ToList().Where(t => t.Ss_Id == id ) select c;
             
                txt_SRate.Text = Convert.ToString(quotationlist.First().Se_Rate);
                txt_SQuantity.Text = Convert.ToString(quotationlist.First().Se_Quantity);
                txt_SAmount.Text = Convert.ToString(quotationlist.First().Se_Amount);
                txt_SDescription.Text = quotationlist.First().Mh_ServiceHead;
                txt_SCode.Text = quotationlist.First().Mh_ServiceCode;
                btn_ServiceAdd.ToolTip = Convert.ToString(quotationlist.First().Ss_Id);
                
                btn_ServiceAdd.Text = "Save";
                btn_ServiceAdd.ForeColor = System.Drawing.Color.Black;

                

            }
            catch
            {

            }
        }
        protected void imgbtn_SDelete_Click1(object sender, ImageClickEventArgs e)
        {
            ImageButton imgdelete = (ImageButton)sender;
            string sino = (imgdelete.ToolTip);
            int id = Convert.ToInt32(sino);
            AME_Service_SupplementaryEstimateServiceDetails vq = db.AME_Service_SupplementaryEstimateServiceDetails.ToList().First(t => t.Ss_Id == id);
            db.DeleteObject(vq);
            db.SaveChanges();
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Data Deleted Sucessfully..!!');", true);
           
            string sino0 = Request.QueryString["id"];
            string type = Request.QueryString["Type"];
            fillgridServiceEdit();
        }
      
        protected void txt_SCode_TextChanged1(object sender, EventArgs e)
        {
            try
            {
                string branch = Session["Branch"].ToString();
                var v = from k in db.AME_Master_ServiceHead.ToList()
                        where (k.Mh_ServiceCode.Equals(txt_SCode.Text) && k.Branch_Name==branch)
                        select new
                        {
                            k.Mh_ServiceHead,
                            k.Mh_ServiceCode,
                            k.Mh_ServiceRate
                        };

                txt_SCode.Text = v.First().Mh_ServiceCode;
                txt_SDescription.Text = Convert.ToString(v.First().Mh_ServiceHead);
                txt_SRate.Text = Convert.ToString(v.First().Mh_ServiceRate);
                txt_SQuantity.Focus();
            }
            catch
            {
                txt_SCode.Text = "";
                txt_SDescription.Text = "";
                txt_SRate.Text = "";
                txt_SQuantity.Focus();
            }
        }
   
        protected void imgbtn_edit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string branchname = Session["Branch"].ToString();
                ImageButton imgbtnEdit = (ImageButton)sender;
                foreach (GridViewRow gr in GridView2.Rows)
                {
                    gr.BackColor = System.Drawing.Color.Transparent;
                }

                GridViewRow row = imgbtnEdit.NamingContainer as GridViewRow;
                row.BackColor = System.Drawing.Color.Cyan;

                string sino = (imgbtnEdit.ToolTip);
                int id = Convert.ToInt32(sino);
                var quotationlist = from c in db.AME_Service_SupplimentaryEstimateSpareDetails.ToList().Where(t => t.Sp_Id == id) select c;

                txt_PartNo.Text = quotationlist.First().Itm_Partno;
                txt_PartDesc.Text = quotationlist.First().Itm_PartDescrption;

                txt_PartRate.Text = Convert.ToString(quotationlist.First().Se_Rate);
                txt_PartQuantity.Text = Convert.ToString(quotationlist.First().Se_Quantity);
                txt_PartAmount.Text = Convert.ToString(quotationlist.First().Se_Amount);
                txt_PartDiscount.Text = Convert.ToString(quotationlist.First().Se_Discount);
                txt_AVatAmount.Text = Convert.ToString(quotationlist.First().Se_Vat);
                txt_PartTaxAmount.Text = Convert.ToString(quotationlist.First().Se_TaxAmont);
                txt_PartTotal.Text = Convert.ToString(quotationlist.First().Se_Total);
                txt_PartVat.Text = Convert.ToString(quotationlist.First().Se_Vat);
                btn_PartAdd.ToolTip = Convert.ToString(quotationlist.First().Sp_Id);
                btn_PartAdd.Text = "Save";
                btn_ServiceAdd.ForeColor = System.Drawing.Color.Black;


            }
            catch
            {

            }

        }
        protected void btn_back_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Service_JobEstimation_List.aspx");
        }
        public void fillestimation()
        {
            var v = from c in db.AME_Service_EstimateEntryDetails.ToList().OrderBy(t => t.Se_EstimateNo)
                    where  c.Branch_Name == Session["Branch"].ToString()
                    select new
                    {
                        estimationid=c.Se_EstimateNo,
                        estimationnmae = c.Se_EstimateNo

                    };
            ddlestimationno.DataSource = v.ToList();
            ddlestimationno.DataTextField = "estimationnmae";
            ddlestimationno.DataValueField = "estimationid";
            ddlestimationno.DataBind();
            ddlestimationno.Items.Insert(0, "--Select One--");
        }
        protected void btn_serch_Click(object sender, EventArgs e)
        {
            if(ddlestimationno.SelectedIndex==0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Please Select Estimation No ..!!');", true);
                return;
            }
            int estimationno=Convert.ToInt32(ddlestimationno.SelectedValue);
            string branch=Session["Branch"].ToString();
            var v = from c in db.AME_Service_EstimateEntryDetails.Where(t => t.Se_EstimateNo == estimationno && t.Branch_Name == branch) select c;
           
            if (Convert.ToInt32(v.Count()) > 0)
            {
                tbl_details.Visible = true;
                filldata();

                fillgridSparedata();
                //fillgridServiceReport();
                fillgridServicedetails();
              
            }

            else
            {
                tbl_details.Visible = false;
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Invalid Estimaion No..!!');", true);
                return;
            }
        }
        protected void txt_ALabDiscountPer_TextChanged(object sender, EventArgs e)
        {

        }
        protected void txt_PartQuantity_TextChanged(object sender, EventArgs e)
        {
            decimal vat = Convert.ToDecimal(txt_PartVat.Text);

            decimal rate = Convert.ToDecimal(ViewState["rate"]);
            decimal temp = Convert.ToDecimal(rate / (100 + vat));
            decimal amnt = temp * 100;

            decimal qty = Convert.ToDecimal(txt_PartQuantity.Text);
            txt_PartAmount.Text = (amnt * qty).ToString("0.00");
            txt_PartDiscount.Text = "0";
            //txt_PartDiscountper.Text = "0";
            decimal amnt1 = Convert.ToDecimal(txt_PartAmount.Text);
            decimal afterdisc = amnt1;
            txt_PartTaxAmount.Text = (afterdisc * (vat / 100)).ToString("0.00");

            decimal taxamnt = Convert.ToDecimal(txt_PartTaxAmount.Text);
            txt_PartTotal.Text = (afterdisc + taxamnt).ToString("0.00");
        }
        protected void txt_disc_TextChanged(object sender, EventArgs e)
        {
            decimal vat = Convert.ToDecimal(txt_PartVat.Text);
            decimal amnt = Convert.ToDecimal(txt_PartAmount.Text);
            //decimal disc = Convert.ToDecimal(txt_PartDiscountper.Text);
            //decimal per = disc / 100;
            //txt_PartDiscount.Text = (amnt * per).ToString("0.00");

            decimal descamnt = Convert.ToDecimal(txt_PartDiscount.Text);

            decimal amnt1 = Convert.ToDecimal(txt_PartAmount.Text);
            decimal afterdisc = amnt1 - descamnt;
            txt_PartTaxAmount.Text = (afterdisc * (vat / 100)).ToString("0.00");

            decimal taxamnt = Convert.ToDecimal(txt_PartTaxAmount.Text);
            txt_PartTotal.Text = (afterdisc + taxamnt).ToString("0.00");

        }
}

    
