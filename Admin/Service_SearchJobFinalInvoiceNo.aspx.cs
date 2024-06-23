using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
using System.Data;
public partial class Admin_Spare_PurchaseEntry : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
   
    Clear cl = new Clear();
    public string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fillsino();
            FillInvoiceNo();
           
        }
    }

    private void FillInvoiceNo()
    {
        string branchname = Session["Branch"].ToString();
        string InvType = ddl_invtype.SelectedValue.ToString();
        if ((from c in db.AME_BillCounter where c.Branch_Name == branchname && c.BillType == InvType select c.BillCounter).Count() > 0)
        {
            int VNo = (int)(from c in db.AME_BillCounter where c.Branch_Name == branchname && c.BillType == InvType select c.BillCounter).Max();
            if (ddl_invtype.SelectedItem.Text == "Tax Invoice")
            {
                txt_invno.Text = "T/" + Convert.ToString(VNo + 1);
            }
            else
            {
                txt_invno.Text = "R/" + Convert.ToString(VNo + 1);
            }
        }
        else
        {
            if (ddl_invtype.SelectedItem.Text == "Tax Invoice")
            {
                txt_invno.Text = "T/1";
            }
            else
            {
                txt_invno.Text = "R/1";
            }
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
                        Cu_Code = c.Mc_Id
                    };
            ddl_customer.DataSource = v.ToList();
            ddl_customer.DataTextField = "Cu_Name";
            ddl_customer.DataValueField = "Cu_Code";
            ddl_customer.DataBind();
            ddl_customer.Items.Insert(0, "--Select One--");
        }
        else
        {
            var v = from c in db.AME_Master_Customer.ToList().OrderBy(t => t.Mc_Name)
                    where c.Mc_Status = true && c.Branch_Name == Session["Branch"].ToString()
                    select new
                    {
                        Cu_Name = c.Mc_Name + " - " + c.Mc_Mobileno,
                        Cu_Code = c.Mc_Id
                    };
            ddl_customer.DataSource = v.ToList();
            ddl_customer.DataTextField = "Cu_Name";
            ddl_customer.DataValueField = "Cu_Code";
            ddl_customer.DataBind();
            ddl_customer.Items.Insert(0, "--Select One--");
        }
       
    }
    decimal tot1 = 0;
    public void fillEdit()
    {
     string branchname = Session["Branch"].ToString();
     int sno = Convert.ToInt32(txt_jcno.Text);
        var v = (from c in db.AME_Service_JobcardSpareIssue
                 join e in db.AME_Service_JobCardEntry on c.JC_No equals e.JC_No
                 join d in db.AME_Master_VehicleModel on e.JC_Modelname equals d.Mv_Id

                 join f in db.AME_Master_Technician on e.JCTechnisianName equals f.Mt_Id
                 join h in db.AME_Master_Customer on e.JC_Customername equals h.Mc_Id
                 join g in db.AME_Master_Item on c.Itm_code equals g.Itm_code
                 where c.JC_No == sno && c.Branch_Name == branchname
                 select new

                 {


                     c.JC_No,
                     c.SE_Sino,
                     c.SE_Date,
                     e.JC_Date,
                     e.JC_Regno,
                     e.JC_Engineno,
                     c.SE_Sparetype,
                     h.Mc_Name,
                     e.JC_Caddress,
                     e.JC_Chassisno,
                     e.JCTechnisianName,
                     c.Itm_code,
                     c.SE_Amount,
                     c.SE_Discount,
                     c.SE_Quantity,
                     c.SE_Rate,
                     c.SE_Taxamount,
                     c.SE_Total,
                     c.SE_Vat,
                     g.Itm_PartDescrption,
                     g.Itm_Partno,
                     d.Mv_ModelName,
                     c.SE_Id,

                 }).ToList();


     
        GridView2.DataSource = v.ToList();
        GridView2.DataBind();
    
    }
    public void edit1()
    {
        foreach (GridViewRow gr in GridView2.Rows)
        {


            Label lbl_Total = (Label)gr.FindControl("Label18");
            decimal Total = Convert.ToDecimal(lbl_Total.Text);

            tot1 = tot1 + Total;
            txt_TotalSpareAmount.Text = Convert.ToString(SmitaClass.SignificantTruncate(tot1, 2));
            txt_BillAmount.Text = Convert.ToString(Convert.ToDecimal(txt_StotalAmount.Text) + Convert.ToDecimal(txt_TotalSpareAmount.Text));
        }
    }
    public void fillservicedetails()
    {
        FillCustomer();
        string branchname = Session["Branch"].ToString();
        int sno = Convert.ToInt32(txt_jcno.Text);
        var v = (from c in db.AME_Service_JobCardEntry

                 join d in db.AME_Master_VehicleModel on c.JC_Modelname equals d.Mv_Id
                 join e in db.AME_Master_Supervisor on c.JC_SupervisorName equals e.Ms_Id
                 join f in db.AME_Master_Technician on c.JCTechnisianName equals f.Mt_Id
                 join h in db.AME_Master_Customer on c.JC_Customername equals h.Mc_Id
                 join g in db.AME_Service_JobCardServiceDetails on c.JC_No equals g.JC_No
                 where c.JC_No == sno && c.Branch_Name == branchname
                 select new

                 {
                     c.JC_No,
                     c.JC_Caddress,
                     c.JC_Deliverydate,
                     d.Mv_ModelName,
                     c.JC_Engineno,
                     c.JC_Grandtotal,
                     c.JC_Keyno,
                     c.JC_Regno,
                     c.JC_Kmcovered,
                     c.JC_MobileNo,
                     c.JC_Phoneno,
                     c.JCTechnisianName,
                     c.JC_SupervisorName,
                     c.JC_Modelname,
                     c.JC_Customername,
                     c.JC_SaleDate,
                     c.JC_ServiceType,
                     e.Ms_Name,
                     f.Mt_Name,
                     h.Mc_Name,
                     g.JCS_Amount,
                     g.JCS_Description,
                     g.JCS_Quantity,
                     g.JCS_Rate,
                     g.JCS_Servicecode,
                     g.JCS_Sino
                 }).ToList();


        txt_jcno.Text = Convert.ToString(v.First().JC_No);
        ddl_customer.SelectedValue = Convert.ToString(v.First().JC_Customername);
        txt_address.Text = v.First().JC_Caddress;
        txt_mobno.Text = v.First().JC_MobileNo;
        txt_model.Text = v.First().Mv_ModelName;
        ddl_servicetype.Text = v.First().JC_ServiceType;
        txt_RegdNo.Text = v.First().JC_Regno;
        ddl_customer.SelectedItem.Text = v.First().Mc_Name;
        btn_Submit.ToolTip = Convert.ToString(v.First().JC_No);
        GridView1.DataSource = v.ToList();
        GridView1.DataBind();
      

    }
    public void fillservicedetails1()
    {
        decimal total = 0;
        foreach (GridViewRow gr in GridView1.Rows)
        {
            Label lbl_Amount = (Label)gr.FindControl("Labels6");
            decimal TotAmt = Convert.ToDecimal(lbl_Amount.Text);

            Label lblgrandtotal = (Label)GridView1.FooterRow.FindControl("lblgrandtotal");


            total = total + TotAmt;

            txt_SGrossAmount.Text = Convert.ToString(SmitaClass.SignificantTruncate(total, 2));
            txt_StotalAmount.Text = Convert.ToString(SmitaClass.SignificantTruncate(total, 2));
            txt_BillAmount.Text = Convert.ToString(Convert.ToDecimal(txt_StotalAmount.Text) + Convert.ToDecimal(txt_TotalSpareAmount.Text) + Convert.ToDecimal(txt_outsidecharge.Text));

        }

    }
    private void Fillsino()
    {
        string branchname = Session["Branch"].ToString();
        if ((from c in db.AME_Service_JobcardFinalInvoice where c.Branch_Name == branchname select c.FI_Sino).Count() > 0)
        {
            int VNo = (int)(from c in db.AME_Service_JobcardFinalInvoice where c.Branch_Name == branchname select c.FI_Sino).Max();
            txt_serialno.Text = Convert.ToString(VNo + 1);
        }
        else
        {
            txt_serialno.Text = "1";
        }
    }


    public void fillpaymemtdetails()
    {

        string branch = Session["Branch"].ToString();

        int id1 = Convert.ToInt32(txt_jcno.Text);
        var details = from c in db.AME_Service_JobcardProformaPaymentDetails.Where(t => t.PI_JcNo == id1 && t.Branch_Name==branch) select c;
        var pi = from c in db.AME_Service_JobcardProformaInvoice.Where(t => t.PI_JcNo == id1 && t.Branch_Name == branch) select c;
        txt_BillAmount.Text = Convert.ToString(details.First().PIP_BillAmount);
        //txt_LabourCharges.Text = Convert.ToString(details.First().PIP_Labourcharges);
        txt_outsidecharge.Text = Convert.ToString(details.First().PIP_OutsideService);
        txt_sertaxamount.Text = Convert.ToString(details.First().PIP_ServiceTaxAmount);
        txtSrhr.Text = Convert.ToString(details.First().PIP_SrHrEduCessAmount);
        txteducessamount.Text = Convert.ToString(details.First().PIP_EduCess);
        txt_ServiceTaxAmt.Text = Convert.ToString(details.First().PIP_ServiceTax);
        txt_LabourChargesAftDisc.Text = Convert.ToString(details.First().PIP_LabourchargeAfterdis);
        txt_LabDiscountPer.Text = Convert.ToString(details.First().PIP_LabouechargeDiscountpercent);
        txt_LabDiscountAmount.Text = Convert.ToString(details.First().PIP_LabourchargeDiscountAmount);
        txt_LabourCharges.Text = Convert.ToString(details.First().PIP_Labourcharges);

        txt_otherchrg.Text = Convert.ToString(details.First().PIP_OtherCharges);
        txt_TotalSpareAmount.Text = Convert.ToString(details.First().PIP_TotalSpareAmount);
        txt_SVatAmount.Text = Convert.ToString(details.First().PIP_VatAmount);
        txt_StotalAmount.Text = Convert.ToString(details.First().PIP_Total);
        txt_SerDiscountAmount.Text = Convert.ToString(details.First().PIP_DiscountAmount);
        txt_SDiscountPer.Text = Convert.ToString(details.First().PIP_Discountpercent);
        txt_SGrossAmount.Text = Convert.ToString(details.First().PIP_Grossamount);
        txt_tin.Text = Convert.ToString(pi.First().PI_Tin);
        txt_BillAmount.Text = Convert.ToString(details.First().PIP_BillAmount);
        if(details.First().PIP_SrHrEduCessAmount!=0)
        {
            CheckBox1.Checked = true;
            CheckBox1.Enabled = false;
        }
    }
   
    //decimal tot1 = 0, tot2 = 0, tot3 = 0, tot4 = 0;
   

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_serialno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Serial Number Should Not Be Blank..!!'); </script>", false);
                txt_serialno.Focus();
                return;
            }
            if (txt_invno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invoice Number Should Not Be Blank..!!'); </script>", false);
                txt_invno.Focus();
                return;
            }
            if (txt_invdate.Text =="")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invoice Date ShouldNot Be Blank ..!!'); </script>", false);
                txt_invdate.Focus();
                return;
            }

            if (txt_jcno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('JobCard No  ShouldNot Be Blank ..!!'); </script>", false);
                txt_jcno.Focus();
                return;
            }
          
            if (ddl_servicetype.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Service Type..!!'); </script>", false);
                ddl_servicetype.Focus();
                return;
            }

            if (txt_RegdNo.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Registration No ShouldNot Be Blank ..!!'); </script>", false);
                txt_RegdNo.Focus();
                return;
            }
            if (ddl_customer.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Customer Name..!!'); </script>", false);
                ddl_customer.Focus();
                return;
            }
            if (txt_tin.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Tin No  Should Not Be Blank..!!'); </script>", false);
                txt_tin.Focus();
                return;
            }
            if (txt_model.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Model Name  Should Not Be Blank..!!'); </script>", false);
                txt_model.Focus();
                return;
            }
            if (txt_address.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Address Should Not Be Blank..!!'); </script>", false);
                txt_address.Focus();
                return;
            }
            if (txt_model.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Model Name Should Not Be Blank..!!'); </script>", false);
                txt_model.Focus();
                return;
            }
            if (txt_SGrossAmount.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Gross Amount Should Not Be Blank..!!'); </script>", false);
                txt_SGrossAmount.Focus();
                return;
            }
            if (txt_SerDiscountAmount.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Discount Amount Should Not Be Blank..!!'); </script>", false);
                txt_SerDiscountAmount.Focus();
                return;
            }
            if (txt_StotalAmount.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Net Amount Should Not Be Blank..!!'); </script>", false);
                txt_StotalAmount.Focus();
                return;
            }
            if (txt_SVatAmount.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Vat Amount Should Not Be Blank..!!'); </script>", false);
                txt_SVatAmount.Focus();
                return;
            }
            if(txt_SDiscountPer.Text=="")
            {

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('DiscountPercentage Should Not Be Blank..!!'); </script>", false);
                txt_SDiscountPer.Focus();
                return;
            }
            if (txt_SVatAmount.Text == "")
            {

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Vat Amount Should Not Be Blank..!!'); </script>", false);
                txt_SVatAmount.Focus();
                return;
            }
            if (txt_LabourCharges.Text == "")
            {

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('LabourChargs Should Not Be Blank..!!'); </script>", false);
                txt_LabourCharges.Focus();
                return;
            }
            if (txt_LabDiscountPer.Text == "")
            {

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('labour DiscountPercentage Should Not Be Blank..!!'); </script>", false);
                txt_LabDiscountPer.Focus();
                return;
            }
            if (txt_ServiceTaxAmt.Text == "")
            {

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('labour DiscountPercentage Should Not Be Blank..!!'); </script>", false);
                txt_ServiceTaxAmt.Focus();
                return;
            }
            if (txt_ServiceTaxAmt.Text == "")
            {

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('labour DiscountPercentage Should Not Be Blank..!!'); </script>", false);
                txt_ServiceTaxAmt.Focus();
                return;
            }
            if (txt_otherchrg.Text == "")
            {

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('labour DiscountPercentage Should Not Be Blank..!!'); </script>", false);
                txt_otherchrg.Focus();
                return;
            }
            int id1 = Convert.ToInt32(txt_jcno.Text);
            AME_Service_JobcardFinalInvoice pi = new AME_Service_JobcardFinalInvoice();
            pi.FI_Sino = Convert.ToInt32(txt_serialno.Text);
            pi.Branch_Name = Session["Branch"].ToString();
            pi.Created_By = Session["Uid"].ToString();
            pi.Created_Date = SmitaClass.IndianTime();
            pi.FI_FinalIVstatus = true;
            pi.FI_InvoiceDate = Convert.ToDateTime(txt_invdate.Text, SmitaClass.dateformat());
            pi.FI_InvoiceNo = txt_invno.Text;
            pi.FI_JcNo = Convert.ToInt32(txt_jcno.Text);
            pi.FI_PaymentType = ddl_paymenttype.SelectedItem.Text;
            pi.FI_FinalIVstatus = true;

            pi.FI_Status = "CLOSE";
            var dd = from c in db.AME_Service_JobcardProformaInvoice.Where(t => t.PI_JcNo == id1) select c;
            if (Convert.ToInt32(dd.Count()) > 0)
            {
                pi.FI_ProfomaIVStatus = true;
            }
            pi.FI_ProfomaIVStatus = false;
            pi.FI_TaxType = ddl_invtype.SelectedItem.Text;
            pi.FI_Tin = txt_tin.Text;
            db.AddToAME_Service_JobcardFinalInvoice(pi);
            db.SaveChanges();

            //insert data in performa paymentdetails

            AME_Service_JobcardFinalPaymentDetails pd = new AME_Service_JobcardFinalPaymentDetails();
            pd.PI_InvoiceNo = txt_invno.Text;
            pd.FIP_Sino = Convert.ToInt32(txt_serialno.Text);
            pd.Branch_Name = Session["Branch"].ToString();
            pd.Created_By = Session["Uid"].ToString();
            pd.Created_Date = SmitaClass.IndianTime();
            pd.FIP_BillAmount = Convert.ToDecimal(txt_BillAmount.Text);
            pd.FIP_DiscountAmount = Convert.ToDecimal(txt_SerDiscountAmount.Text);
            pd.FIP_Discountpercent = Convert.ToDecimal(txt_SDiscountPer.Text);
            pd.FIP_EduCessPercent = Convert.ToDecimal(txt_edutaxpercent.Text);
            pd.FIP_Grossamount = Convert.ToDecimal(txt_SGrossAmount.Text);
            pd.FIP_LabouechargeDiscountpercent = Convert.ToDecimal(txt_LabDiscountPer.Text);
            pd.FIP_LabourchargeAfterdis = Convert.ToDecimal(txt_LabourChargesAftDisc.Text);
            pd.FIP_LabourchargeDiscountAmount = Convert.ToDecimal(txt_LabDiscountAmount.Text);
            pd.FIP_Labourcharges = Convert.ToDecimal(txt_LabourCharges.Text);
            pd.FIP_OtherCharges = Convert.ToDecimal(txt_otherchrg.Text);
            pd.FIP_OutsideService = Convert.ToDecimal(txt_outsidecharge.Text);
            pd.FIP_ServiceTax = Convert.ToDecimal(txt_ServiceTaxAmt.Text);
            pd.FIP_ServiceTaxAmount = Convert.ToDecimal(txt_sertaxamount.Text);
            pd.FIP_ServiceTaxPercent = Convert.ToDecimal(txt_ServiceTaxPer.Text);
            pd.FIP_EduCess = Convert.ToDecimal(txteducessamount.Text);
            pd.FIP_SrHrEduCessAmount = Convert.ToDecimal(txtSrhr.Text);
            pd.FIP_SrHrEduCessPercent = Convert.ToDecimal(txt_hredupercent.Text);
            pd.FI_JcNo = Convert.ToInt32(txt_jcno.Text);
            pd.FIP_Status = "CLOSE";
            pd.FIP_Total = Convert.ToDecimal(txt_StotalAmount.Text);
            pd.FIP_TotalSpareAmount = Convert.ToDecimal(txt_TotalSpareAmount.Text);
            pd.FIP_VatAmount = Convert.ToDecimal(txt_SVatAmount.Text);
            db.AddToAME_Service_JobcardFinalPaymentDetails(pd);
            db.SaveChanges();
            //billcounter
            string branchname = Session["Branch"].ToString();
            string InvType = ddl_invtype.SelectedValue.ToString();
            int id = (int)(from c in db.AME_BillCounter where c.Branch_Name == branchname && c.BillType == InvType select c.BillCounter).Max();
            AME_BillCounter bc = db.AME_BillCounter.First(c => c.Branch_Name == branchname && c.BillType == InvType);
            bc.BillCounter = id + 1;
            db.SaveChanges();

            string Branch = Session["Branch"].ToString();
            int cno = Convert.ToInt32(txt_jcno.Text);
            string param = "@Jcno,@Branch";
            string paramvalue = cno + "," + Branch;
            DataSet ds1 = smitaDbAccess.SPReturnDataSet("sp_ServiceJobcard_FinalCheck", param, paramvalue);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                AME_Service_JobcardProformaInvoice piv = db.AME_Service_JobcardProformaInvoice.First(t => t.PI_JcNo == id1 && t.Branch_Name == branchname);
                piv.PI_Status = "CLOSE";
                db.SaveChanges();
            }

            if (ds1.Tables[1].Rows.Count > 0)
            {
                AME_Service_JobcardProformaPaymentDetails pivp = db.AME_Service_JobcardProformaPaymentDetails.First(t => t.PI_JcNo == id1 && t.Branch_Name == branchname);
                pivp.PIP_Status = "CLOSE";
                db.SaveChanges();
            }

      //Job card Outside Service
            var v = from c in db.AME_Service_JobCardOutside_Service.ToList() where c.JC_No == id1 && c.Branch_Name == branchname select c;
            if (Convert.ToInt32(v.Count()) > 0)
            {
                foreach (var c in v)
                {
                    AME_Service_JobCardOutside_Service sjs = db.AME_Service_JobCardOutside_Service.First(t => t.JC_No == id1 && t.Branch_Name == branchname);
                    c.Ms_Status = "CLOSE";
                    db.SaveChanges();
                }
            }
            ////update jobcard entry
            AME_Service_JobCardEntry jce = db.AME_Service_JobCardEntry.First(t => t.JC_No == id1 && t.Branch_Name == branchname);
            jce.Ms_Status = "CLOSE";
            db.SaveChanges();
            //update jobcardservice details
            var jcs = from c in db.AME_Service_JobCardServiceDetails.ToList().Where(t => t.JC_No == id1 && t.Branch_Name == branchname)
                      select c;

            foreach (var c1 in jcs)
            {
                AME_Service_JobCardEntry jcs1 = db.AME_Service_JobCardEntry.First(t => t.JC_No == id1 && t.Branch_Name == branchname);
                     c1.JCS_Status = "CLOSE";
                db.SaveChanges();

            }
            ////update spareparts
            var sp = from c in db.AME_Service_JobcardSpareIssue.ToList().Where(t => t.JC_No == id1 && t.Branch_Name == branchname)
                     select c;

            foreach (var c2 in sp)
            {
                AME_Service_JobCardEntry sp1 = db.AME_Service_JobCardEntry.First(t => t.JC_No == id1 && t.Branch_Name == branchname);
                c2.Ms_Status = "CLOSE";
               db.SaveChanges();

            }
           
            ////Upadte Spare return
            var sr = from c in db.AME_Service_JobCardSpareReturn.Where(t => t.JC_No == id1 && t.Branch_Name == branchname)
                     select c;

            foreach (var c3 in sr)
            {
                AME_Service_JobCardSpareReturn sr1 = db.AME_Service_JobCardSpareReturn.First(t => t.JC_No == id1 && t.Branch_Name == branchname);
                c3.Ms_Status = "CLOSE";
                db.SaveChanges();
            }
           
            Session["PID"] = txt_serialno.Text;
            Session["JCN"] = txt_jcno.Text;
            Response.Redirect("Service_JobFinalInvoicePrint.aspx");

            //cl.Clear_All(this);
            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Data Added Sucessfully..!!'); </script>", false);
            
            //return;

        }
        catch
        {

        }
    }
   
   
    protected void ddl_invtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillInvoiceNo();
    }
    protected void txt_jcno_TextChanged(object sender, EventArgs e)
    {
        try
        {

            int sino = Convert.ToInt32(txt_jcno.Text);
            string branchname = Session["Branch"].ToString();
            var chkperforma = from c in db.AME_Service_JobcardFinalInvoice.Where(t => t.FI_JcNo == sino && t.Branch_Name == branchname && t.FI_Status == "CLOSE") select c;
            if (Convert.ToInt32(chkperforma.Count()) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('This JobCard No Already Added Please Try Different..!!!');</script>", false);
                txt_jcno.Focus();
                txt_jcno.Text = "";
                return;
            }

            var checkstaus = from c in db.AME_Service_JobcardProformaInvoice.Where(t => t.PI_JcNo == sino && t.Branch_Name == branchname && t.PI_ProfomaIVStatus == true) select c;
            if (Convert.ToInt32(checkstaus.Count()) > 0)
            {

                fillservicedetails();
                fillEdit();
                fillpaymemtdetails();
            }
            else
            {
                var outsideservice = from c in db.AME_Service_JobCardOutside_Service.Where(t => t.JC_No == sino && t.Branch_Name == branchname) select c;
                var quotationdetails = from c in db.AME_Service_JobCardEntry.Where(t => t.JC_No == sino && t.Branch_Name == branchname) select c;
                if (Convert.ToInt32(quotationdetails.Count()) > 0)
                {

                    fillservicedetails();
                    fillservicedetails1();
                    fillEdit();
                    edit1();
                    if (Convert.ToInt32(outsideservice.Count()) > 0)
                    {
                        var totalamount = from o in db.AME_Service_JobCardOutside_Service.Where(t => t.JC_No == sino && t.Branch_Name == branchname)
                                          group new { o } by new { o.JC_No } into outdoorservice
                                          let total = outdoorservice.Sum(s => s.o.JCO_Amount)
                                          select new
                                          {
                                              tot = total,

                                          };
                        txt_outsidecharge.Text = Convert.ToString(totalamount.FirstOrDefault().tot);
                        txt_BillAmount.Text = Convert.ToString(Convert.ToDecimal(txt_StotalAmount.Text) + Convert.ToDecimal(txt_TotalSpareAmount.Text) + Convert.ToDecimal(txt_outsidecharge.Text));
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invalid Job Card no..!!!');</script>", false);
                    txt_jcno.Focus();
                    txt_jcno.Text = "";
                    return;
                }
            }
        }
        catch
        {

        }
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked == true)
        {
            txt_ServiceTaxAmt.ReadOnly = false;
            txteducessamount.ReadOnly = false;
            txtSrhr.ReadOnly = false;
            txt_StotalAmount.Text = Convert.ToString(Convert.ToDecimal(txt_SGrossAmount.Text) - Convert.ToDecimal(txt_SerDiscountAmount.Text));
          
            txt_ServiceTaxAmt.Text = Convert.ToString(Convert.ToDecimal(txt_StotalAmount.Text) * Convert.ToDecimal(txt_ServiceTaxPer.Text) / 100);
            txteducessamount.Text = Convert.ToString(Convert.ToDecimal(txt_StotalAmount.Text) * Convert.ToDecimal(txt_edutaxpercent.Text) / 100);
            txtSrhr.Text = Convert.ToString(Convert.ToDecimal(txt_StotalAmount.Text) * Convert.ToDecimal(txt_hredupercent.Text) / 100);
            txt_sertaxamount.Text = Convert.ToString(Convert.ToDecimal(txt_ServiceTaxAmt.Text) + Convert.ToDecimal(txteducessamount.Text) + Convert.ToDecimal(txtSrhr.Text));
            txt_BillAmount.Text = Convert.ToString(Convert.ToDecimal(txt_StotalAmount.Text) + Convert.ToDecimal(txt_SVatAmount.Text) + Convert.ToDecimal(txt_TotalSpareAmount.Text) + Convert.ToDecimal(txt_LabourChargesAftDisc.Text) + Convert.ToDecimal(txt_outsidecharge.Text) + Convert.ToDecimal(txt_otherchrg.Text) + Convert.ToDecimal(txt_sertaxamount.Text));
            //txt_BillAmount.Text = Convert.ToString(Convert.ToDecimal(txt_BillAmount.Text) + Convert.ToDecimal(txt_sertaxamount.Text));
        }
        else
        {
            txt_ServiceTaxAmt.ReadOnly = true;
            txteducessamount.ReadOnly = true;
            txtSrhr.ReadOnly = true;
            txt_ServiceTaxAmt.Text = "0.00";
            txteducessamount.Text = "0.00";
            txtSrhr.Text = "0.00";
            txt_BillAmount.Text = Convert.ToString(Convert.ToDecimal(txt_BillAmount.Text) - Convert.ToDecimal(txt_sertaxamount.Text));
            txt_sertaxamount.Text = "0.00";
        }
    }
  
}