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
            Fillsino();
            FillInvoiceNo();
            txt_invdate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");

            txt_jcyear.Text = "2018-19";
        }
    }

    //private void FillInvoiceNo()
    //{
    //    string branchname = Session["Branch"].ToString();
    //    string InvType = ddl_invtype.SelectedValue.ToString();
    //    if ((from c in db.AME_BillCounter where c.Branch_Name == branchname && c.BillType == InvType select c.BillCounter).Count() > 0)
    //    {
    //        int VNo = (int)(from c in db.AME_BillCounter where c.Branch_Name == branchname && c.BillType == InvType select c.BillCounter).Max();
    //        if (ddl_invtype.SelectedItem.Text == "Tax Invoice")
    //        {
    //            txt_invno.Text = "T/" + Convert.ToString(VNo + 1);
    //        }
    //        else
    //        {
    //            txt_invno.Text = "R/" + Convert.ToString(VNo + 1);
    //        }
    //    }
    //    else
    //    {
    //        txt_invno.Text = "Error";
    //    }
    //}


    private void FillInvoiceNo()
    {
        string branchname = Session["Branch"].ToString();
        string InvType = ddl_invtype.SelectedValue.ToString();
        if ((from c in db.AME_Service_JobcardProformaInvoice where c.Branch_Name == branchname && c.jc_year == txt_jcyear.Text select c.PI_InvoiceNo).Count() > 0)
        {
            int VNo = (from c in db.AME_Service_JobcardProformaInvoice where c.Branch_Name == branchname && c.jc_year == txt_jcyear.Text select c.PI_Sino).Max();

           int sino = Convert.ToInt32(VNo);
            
            
            //if (ddl_invtype.SelectedItem.Text == "Tax Invoice")
            //{
            //    txt_invno.Text = "T/" + Convert.ToString(sino + 1);
            //}
            //else
            //{
            //    txt_invno.Text = "R/" + Convert.ToString(sino + 1);
            //}
           if (branchname == "Cuttack")
           {
               txt_invno.Text = "LCTC/" + Convert.ToString(sino + 1) + "/2018-19";
           }
           if (branchname == "Phulnakhara")
           {
               txt_invno.Text = "LPHU/" + Convert.ToString(sino + 1) + "/2018-19";
           }
           if (branchname == "Berhampur")
           {
               txt_invno.Text = "LBRH/" + Convert.ToString(sino + 1) + "/2018-19";
           }
           if (branchname == "Paradeep")
           {
               txt_invno.Text = "PRD/" + Convert.ToString(sino + 1) + "/2018-19";
           }
        }
        else
        {
            //txt_invno.Text = "Error";
            if (branchname == "Cuttack")
            {
                txt_invno.Text = "LCTC/" + Convert.ToString(1) + "/2018-19";
            }
            if (branchname == "Phulnakhara")
            {
                txt_invno.Text = "LPHU/" + Convert.ToString(1) + "/2018-19";
            }
            if (branchname == "Berhampur")
            {
                txt_invno.Text = "LBRH/" + Convert.ToString(1) + "/2018-19";
            }
            if (branchname == "Paradeep")
            {
                txt_invno.Text = "PRD/" + Convert.ToString(1) + "/2018-19";
            }
        }
    }
    private void FillCustomer()
    {
        string Sale = Convert.ToString(Session["saletype"]);
        if (Session["saletype"] != null)
        {
            var v = from c in db.AME_Master_Customer.ToList().OrderBy(t => t.Mc_Name)
                    where c.Mc_Status = true && c.Branch_Name == Session["Branch"].ToString() && c.Mc_SaleStatus == Sale
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
   
    public void fillEdit()
    {
        string branchname = Session["Branch"].ToString();
        int sno = Convert.ToInt32(txt_jcno.Text);
        var v = (from c in db.AME_Service_JobcardSpareIssue
                 join e in db.AME_Service_JobCardEntry on new { c.JC_No, c.Branch_Name } equals new { e.JC_No, e.Branch_Name }
                 join d in db.AME_Master_VehicleModel on e.JC_Modelname equals d.Mv_Id

                 join f in db.AME_Master_Technician on e.JCTechnisianName equals f.Mt_Id
                 join h in db.AME_Master_Customer on e.JC_Customername equals h.Mc_Id
                 join g in db.AME_Master_Item on c.Itm_code equals g.Itm_code
                 where c.JC_No == sno && c.Branch_Name == branchname && c.SE_Quantity > 0 && c.Jc_year==txt_jcyear.Text && e.JC_year==txt_jcyear.Text && e.Branch_Name==branchname
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
                     c.SE_DiscountPer,
                     c.SE_Quantity,
                     c.SE_Rate,
                     c.SE_Taxamount,
                     c.SE_Total,
                     c.SE_Vat,
                     g.Itm_PartDescrption,
                     g.Itm_Partno,
                     d.Mv_ModelName,
                     c.SE_Id,

                 }).Distinct().ToList();



        GridView2.DataSource = v.ToList();
        GridView2.DataBind();

    }
    decimal tot1 = 0;
    decimal tot2 = 0;
    decimal tot3 = 0;
    decimal tot4 = 0, tot5 = 0, tot6 = 0, tot7 = 0, tot8 = 0;
    public void edit1()
    {
        foreach (GridViewRow gr in GridView2.Rows)
        {

            Label lbl_Partno = (Label)gr.FindControl("Label10");
            string partno = lbl_Partno.Text;
            var v = from c in db.AME_Master_Item.Where(t => t.Itm_Partno == partno) select c.Itm_CategoryName;
            string ctg = v.First();

            if (ctg == "Lubricants")
            {
                Label lbl_amnt = (Label)gr.FindControl("Label13");
                decimal amnt = Convert.ToDecimal(lbl_amnt.Text);

                Label lbl_Total = (Label)gr.FindControl("Label18");
                decimal Total = Convert.ToDecimal(lbl_Total.Text);

                Label lbl_disc = (Label)gr.FindControl("Label15");
                decimal disc = Convert.ToDecimal(lbl_disc.Text);

                Label lbl_tax = (Label)gr.FindControl("Label17");
                decimal tax = Convert.ToDecimal(lbl_tax.Text);

                tot5 = tot5 + Total;
                tot6 = tot6 + amnt;
                tot7 = tot7 + disc;
                tot8 = tot8 + tax;

                txt_LubricantVatAmount.Text = Convert.ToString(SmitaClass.SignificantTruncate(tot8, 2));
                txt_lubricantGross.Text = Convert.ToString(SmitaClass.SignificantTruncate(tot6, 2));
                txt_LubricantttotalAmount.Text = Convert.ToString(SmitaClass.SignificantTruncate(tot5, 2));
            }
            else
            {
                Label lbl_amnt = (Label)gr.FindControl("Label13");
                decimal amnt = Convert.ToDecimal(lbl_amnt.Text);

                Label lbl_Total = (Label)gr.FindControl("Label18");
                decimal Total = Convert.ToDecimal(lbl_Total.Text);

                Label lbl_disc = (Label)gr.FindControl("Label15");
                decimal disc = Convert.ToDecimal(lbl_disc.Text);

                Label lbl_tax = (Label)gr.FindControl("Label17");
                decimal tax = Convert.ToDecimal(lbl_tax.Text);

                tot1 = tot1 + Total;
                tot2 = tot2 + amnt;
                tot3 = tot3 + disc;
                tot4 = tot4 + tax;

                txt_SVatAmount.Text = Convert.ToString(SmitaClass.SignificantTruncate(tot4, 2));
                txt_SGrossAmount.Text = Convert.ToString(SmitaClass.SignificantTruncate(tot2, 2));
                txt_ttotalAmount.Text = Convert.ToString(SmitaClass.SignificantTruncate(tot1, 2));
            }

            txt_SerDiscountAmount.Text = (tot3 + tot7).ToString("0.00");
            txt_StotalAmount.Text = ((Convert.ToDecimal(txt_SGrossAmount.Text) - tot3)).ToString("0.00");
            txt_LubtotalAmount.Text = ((Convert.ToDecimal(txt_lubricantGross.Text)) - tot7).ToString("0.00");

            //txt_TotalSpareAmount.Text = txt_StotalAmount.Text;
        }

        txt_BillAmount.Text = (tot1 + tot5).ToString("0.00");
    }

    decimal total = 0;
    public void fillservice()
    {
        string branchname = Session["Branch"].ToString();
        int sno = Convert.ToInt32(txt_jcno.Text);
        var v = (from c in db.AME_Service_JobCardEntry
                 join g in db.AME_Service_JobCardServiceDetails on new { c.JC_No, c.Branch_Name } equals new { g.JC_No, g.Branch_Name }
                 where c.JC_No == sno && c.Branch_Name == branchname && c.JC_year==txt_jcyear.Text && g.Jc_year==txt_jcyear.Text && g.Branch_Name==branchname
                 select new

                 {
                     g.JCS_Amount,
                     g.JCS_Description,
                     g.JCS_Quantity,
                     g.JCS_Rate,
                     g.JCS_DisAmu,
                     g.JCS_Disper,
                     g.JCS_Servicecode,
                     g.JCS_Sino,
                     g.JSC_Labour
                 }).Distinct().ToList();
        if (Convert.ToInt32(v.Count()) > 0)
        {
            GridView1.DataSource = v.ToList();
            GridView1.DataBind();
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
                 where c.JC_No == sno && c.Branch_Name == branchname && c.JC_year==txt_jcyear.Text
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
                     c.JC_Date,
                     e.Ms_Name,
                     f.Mt_Name,
                     h.Mc_Name
                 }).Distinct().ToList();

        //txt_invdate.Text = v.First().JC_Date.ToString("dd/MM/yyyy");
        txt_jcno.Text = Convert.ToString(v.First().JC_No);
        //ddl_customer.SelectedValue = Convert.ToString(v.First().JC_Customername);
        txt_address.Text = v.First().JC_Caddress;
        txt_mobno.Text = v.First().JC_MobileNo;
        txt_model.Text = v.First().Mv_ModelName;
        string stype = v.First().JC_ServiceType;
        ddl_servicetype.SelectedValue = stype;
        txt_RegdNo.Text = v.First().JC_Regno;
        ddl_customer.SelectedItem.Text = v.First().Mc_Name;
        btn_Submit.ToolTip = Convert.ToString(v.First().JC_No);

        fillservice();
    }
    public void fillservicedetails1()
    {
        foreach (GridViewRow gr in GridView1.Rows)
        {
            TextBox lbl_Amount = (TextBox)gr.FindControl("Labels6");
            decimal TotAmt = Convert.ToDecimal(lbl_Amount.Text);


            Label lblgrandtotal = (Label)GridView1.FooterRow.FindControl("lblgrandtotal");



            total = total + TotAmt;

            lblgrandtotal.Text = Convert.ToString(SmitaClass.SignificantTruncate(total, 2));

            //txt_SGrossAmount.Text = Convert.ToString(SmitaClass.SignificantTruncate(total, 2));
            txt_LabourCharges.Text = Convert.ToString(SmitaClass.SignificantTruncate(total, 2));
            txt_LabourChargesAftDisc.Text = Convert.ToString(SmitaClass.SignificantTruncate(total, 2));
            //txt_StotalAmount.Text = Convert.ToString(SmitaClass.SignificantTruncate(total, 2));

            txt_ServiceTaxAmt.ReadOnly = false;
            //txteducessamount.ReadOnly = false;
            //txtSrhr.ReadOnly = false;
            decimal service = Convert.ToDecimal(txt_ServiceTaxPer.Text) / 100;

            decimal a = service * Convert.ToDecimal(txt_LabourChargesAftDisc.Text);
            txt_ServiceTaxAmt.Text = (SmitaClass.SignificantTruncate(a, 2)).ToString("0.00");

            decimal f = Convert.ToDecimal(txt_ttotalAmount.Text) + Convert.ToDecimal(txt_LubricantttotalAmount.Text) + Convert.ToDecimal(txt_LabourChargesAftDisc.Text) + Convert.ToDecimal(txt_ServiceTaxAmt.Text);
            txt_BillAmount.Text = (SmitaClass.SignificantTruncate(f, 2)).ToString("0.00");
            double a1 = Convert.ToDouble(txt_BillAmount.Text);
            string[] str = a1.ToString().Split('.');
            if (str.Length != 1)
            {
                double num1 = Convert.ToDouble("0." + str[1]);
                double res;
                if (num1 < 0.51)
                {
                    res = Math.Floor(a1);
                    txt_BillAmount.Text = res.ToString("0.00");
                }
                else
                {
                    res = Math.Round(a1);
                    txt_BillAmount.Text = res.ToString("0.00");
                }
            }

        }



    }
    public void fillpaymemtdetails()
    {

        string branch = Session["Branch"].ToString();

        int id1 = Convert.ToInt32(txt_jcno.Text);
        var details = from c in db.AME_Service_JobcardProformaPaymentDetails.Where(t => t.PI_JcNo == id1 && t.Branch_Name == branch && t.jc_year==txt_jcyear.Text.Trim()) select c;
        var pi = from c in db.AME_Service_JobcardProformaInvoice.Where(t => t.PI_JcNo == id1 && t.Branch_Name == branch && t.jc_year==txt_jcyear.Text.Trim()) select c;
        //txt_BillAmount.Text = Convert.ToString(details.First().PIP_BillAmount);
        //double tmp = Convert.ToDouble(txt_BillAmount.Text);
        //double help = (double)Math.Round(tmp, 1);
        //txt_BillAmount.Text = help.ToString("0.00");
        //txt_LabourCharges.Text = Convert.ToString(details.First().PIP_Labourcharges);
        //txt_outsidecharge.Text = Convert.ToString(details.First().PIP_OutsideService);
        //txt_sertaxamount.Text = Convert.ToString(details.First().PIP_ServiceTaxAmount);
        //txtSrhr.Text = Convert.ToString(details.First().PIP_SrHrEduCessAmount);
        //txteducessamount.Text = Convert.ToString(details.First().PIP_EduCess);
        txt_ServiceTaxAmt.Text = Convert.ToString(details.First().PIP_ServiceTax);
        txt_LabourChargesAftDisc.Text = Convert.ToString(details.First().PIP_LabourchargeAfterdis);
        txt_LabDiscountPer.Text = Convert.ToString(details.First().PIP_LabouechargeDiscountpercent);
        txt_LabDiscountAmount.Text = Convert.ToString(details.First().PIP_LabourchargeDiscountAmount);
        txt_LabourCharges.Text = Convert.ToString(details.First().PIP_Labourcharges);

        //txt_otherchrg.Text = Convert.ToString(details.First().PIP_OtherCharges);

        txt_ttotalAmount.Text = Convert.ToString(details.First().PIP_TotalSpareAmount);

        txt_SVatAmount.Text = Convert.ToString(details.First().PIP_VatAmount);
        txt_StotalAmount.Text = Convert.ToString(details.First().PIP_Total);
        //txt_TotalSpareAmount.Text = txt_StotalAmount.Text;
        txt_SerDiscountAmount.Text = Convert.ToString(details.First().PIP_DiscountAmount);
        //txt_SDiscountPer.Text = Convert.ToString(details.First().PIP_Discountpercent);
        txt_SGrossAmount.Text = Convert.ToString(details.First().PIP_Grossamount);
        txt_tin.Text = Convert.ToString(pi.First().PI_Tin);
        txt_BillAmount.Text = (details.First().PIP_BillAmount).ToString("0.00");
        double a1 = Convert.ToDouble(txt_BillAmount.Text);
        string[] str = a1.ToString().Split('.');
        if (str.Length != 1)
        {
            double num1 = Convert.ToDouble("0." + str[1]);
            double res;
            if (num1 < 0.51)
            {
                res = Math.Floor(a1);
                txt_BillAmount.Text = res.ToString("0.00");
            }
            else
            {
                res = Math.Round(a1);
                txt_BillAmount.Text = res.ToString("0.00");
            }
        }
        if (details.First().PIP_SrHrEduCessAmount != 0)
        {
            CheckBox1.Checked = true;
            CheckBox1.Enabled = false;
        }
    }
   
    private void Fillsino()
    {
        string branchname = Session["Branch"].ToString();
        if ((from c in db.AME_Service_JobcardProformaInvoice where c.Branch_Name == branchname select c.PI_Sino).Count() > 0)
        {
            int VNo = (int)(from c in db.AME_Service_JobcardProformaInvoice where c.Branch_Name == branchname select c.PI_Sino).Max();
            txt_serialno.Text = Convert.ToString(VNo + 1);
        }
        else
        {
            txt_serialno.Text = "1";
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
            //if (ddl_customer.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Customer Name..!!'); </script>", false);
            //    ddl_customer.Focus();
            //    return;
            //}
            //if (txt_tin.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Tin No  Should Not Be Blank..!!'); </script>", false);
            //    txt_tin.Focus();
            //    return;
            //}
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
            //if(txt_SDiscountPer.Text=="")
            //{

            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('DiscountPercentage Should Not Be Blank..!!'); </script>", false);
            //    txt_SDiscountPer.Focus();
            //    return;
            //}
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

            AME_Service_JobcardProformaInvoice pi = new AME_Service_JobcardProformaInvoice();
            pi.PI_Sino = Convert.ToInt32(txt_serialno.Text);
            pi.Branch_Name= Session["Branch"].ToString();
            pi.Created_By = Session["Uid"].ToString();
            pi.Created_Date = SmitaClass.IndianTime();
            pi.Pi_FinalIVstatus = false;
            pi.PI_InvoiceDate = Convert.ToDateTime(txt_invdate.Text,SmitaClass.dateformat());
            pi.PI_InvoiceNo = txt_invno.Text;
            pi.PI_JcNo = Convert.ToInt32(txt_jcno.Text);
            pi.jc_year = txt_jcyear.Text.Trim();
            pi.PI_PaymentType = ddl_paymenttype.SelectedItem.Text;
            pi.PI_ProfomaIVStatus = true;
            pi.PI_Status = "OPEN";
            pi.PI_TaxType = ddl_invtype.SelectedItem.Text;
            pi.PI_Tin = txt_tin.Text;
            db.AddToAME_Service_JobcardProformaInvoice(pi);
            db.SaveChanges();

            //insert data in performa paymentdetails

            AME_Service_JobcardProformaPaymentDetails pd = new AME_Service_JobcardProformaPaymentDetails();
            pd.PI_InvoiceNo = txt_invno.Text;
            pd.PIP_Sino = Convert.ToInt32(txt_serialno.Text);
            pd.Branch_Name = Session["Branch"].ToString();
            pd.Created_By = Session["Uid"].ToString();
            pd.Created_Date = SmitaClass.IndianTime();
            pd.PI_JcNo = Convert.ToInt32(txt_jcno.Text);
            pd.jc_year = txt_jcyear.Text.Trim();

            decimal billamount = Convert.ToDecimal(txt_BillAmount.Text);
            decimal no = Math.Round(billamount, 2);
            pd.PIP_BillAmount = no;
            pd.PIP_DiscountAmount = Convert.ToDecimal(txt_SerDiscountAmount.Text);
            //pd.PIP_Discountpercent = Convert.ToDecimal(txt_SDiscountPer.Text);
            pd.PIP_EduCessPercent = 0;
            pd.PIP_Grossamount = Convert.ToDecimal(txt_SGrossAmount.Text);
            pd.PIP_LabouechargeDiscountpercent = Convert.ToDecimal(txt_LabDiscountPer.Text);
            pd.PIP_LabourchargeAfterdis = Convert.ToDecimal(txt_LabourChargesAftDisc.Text);
            pd.PIP_LabourchargeDiscountAmount = Convert.ToDecimal(txt_LabDiscountAmount.Text);
            pd.PIP_LubGross = Convert.ToDecimal(txt_lubricantGross.Text);
            pd.PIP_LubVat = Convert.ToDecimal(txt_LubricantVatAmount.Text);
            pd.PIP_LubTotal = Convert.ToDecimal(txt_LubricantttotalAmount.Text);
            pd.PIP_LubTotallubricant = Convert.ToDecimal(txt_LubtotalAmount.Text);
            pd.PIP_Labourcharges = Convert.ToDecimal(txt_LabourCharges.Text);
            pd.PIP_OtherCharges = 0;
            pd.PIP_OutsideService = 0;
            pd.PIP_ServiceTax = Convert.ToDecimal(txt_ServiceTaxAmt.Text);
            pd.PIP_ServiceTaxAmount = Convert.ToDecimal(txt_ServiceTaxAmt.Text);
            pd.PIP_ServiceTaxPercent = Convert.ToDecimal(txt_ServiceTaxPer.Text);
            pd.PIP_EduCess = 0;
            pd.PIP_SrHrEduCessAmount = 0;
            pd.PIP_SrHrEduCessPercent = 0;
           
            pd.PIP_Status = "OPEN";
            pd.PIP_Total = Convert.ToDecimal(txt_StotalAmount.Text);
           // pd.PIP_TotalSpareAmount = Convert.ToDecimal(txt_TotalSpareAmount.Text);
            pd.Se_TotalDiscountPerSpare = Convert.ToDecimal(txt_tdiscper.Text);
           // pd.Se_TotalDiscountSpare = Convert.ToDecimal(txt_tdiscamnt.Text);
            pd.Se_GTotalOfSpare = Convert.ToDecimal(txt_ttotalAmount.Text);

            pd.PIP_VatAmount= Convert.ToDecimal(txt_SVatAmount.Text);
            db.AddToAME_Service_JobcardProformaPaymentDetails(pd);
            db.SaveChanges();

            Session["PID"] = txt_serialno.Text;
            Session["JCN"] = txt_jcno.Text;
            

            string branchname = Session["Branch"].ToString();
            string InvType = ddl_invtype.SelectedValue.ToString();
            int id = (int)(from c in db.AME_BillCounter where c.Branch_Name == branchname && c.BillType == "Spare_TaxSales" select c.BillCounter).Max();
            AME_BillCounter bc = db.AME_BillCounter.First(c => c.Branch_Name == branchname && c.BillType == "Spare_TaxSales");
            bc.BillCounter = id + 1;
            db.SaveChanges();

            

            if (Session["Branch"].ToString() == "Cuttack")
            {
                Response.Redirect("Service_JobPerformaInvoicePrint_Cuttack.aspx?year="+txt_jcyear.Text.Trim());
            }
            else if (Session["Branch"].ToString() == "Paradeep")
            {
                Response.Redirect("Service_JobPerformaInvoicePrint.aspx?year="+txt_jcyear.Text.Trim());
            }
            else if (Session["Branch"].ToString() == "Berhampur")
            {
                Response.Redirect("Service_JobPerformaInvoicePrint_Berhampur.aspx?year="+txt_jcyear.Text.Trim());
            }
            else
            {
                Response.Redirect("Service_JobPerformaInvoicePrint_Phulnakhara.aspx?year="+txt_jcyear.Text.Trim());
            }

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
            
               if( txt_jcyear.Text=="")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Enter Finacial Year..!!!');</script>", false);
                txt_jcyear.Focus();
                txt_jcyear.Text = "";
                return;
               
               }


            int sino = Convert.ToInt32(txt_jcno.Text);
            string branchname = Session["Branch"].ToString();
            var chkperforma = from c in db.AME_Service_JobcardFinalInvoice.Where(t => t.FI_JcNo == sino && t.Branch_Name == branchname && t.FI_Status == "CLOSE" && t.jc_year==txt_jcyear.Text.Trim() ) select c;
            if (Convert.ToInt32(chkperforma.Count()) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('This JobCard No Already Added Please Try Different..!!!');</script>", false);
                txt_jcno.Focus();
                txt_jcno.Text = "";
                return;
            }

            var checkstaus = from c in db.AME_Service_JobcardProformaInvoice.Where(t => t.PI_JcNo == sino && t.Branch_Name == branchname && t.PI_ProfomaIVStatus == true && t.jc_year==txt_jcyear.Text.Trim()) select c;
            if (Convert.ToInt32(checkstaus.Count()) > 0)
            {

                fillpaymemtdetails();
                fillEdit();
                edit1();
                fillservicedetails();
                fillservicedetails1();
            }
            else
            {
                var outsideservice = from c in db.AME_Service_JobCardOutside_Service.Where(t => t.JC_No == sino && t.Branch_Name == branchname) select c;
                var quotationdetails = from c in db.AME_Service_JobCardEntry.Where(t => t.JC_No == sino && t.Branch_Name == branchname && t.JC_year==txt_jcyear.Text.Trim()) select c;
                if (Convert.ToInt32(quotationdetails.Count()) > 0)
                {

                    fillEdit();
                    edit1();
                    fillservicedetails();
                    fillservicedetails1();
                    CheckBox1.Checked = true;
                    if (Convert.ToInt32(outsideservice.Count()) > 0)
                    {
                        var totalamount = from o in db.AME_Service_JobCardOutside_Service.Where(t => t.JC_No == sino && t.Branch_Name == branchname)
                                          group new { o } by new { o.JC_No } into outdoorservice
                                          let total = outdoorservice.Sum(s => s.o.JCO_Amount)
                                          select new
                                          {
                                              tot = total,

                                          };
                        //txt_outsidecharge.Text = Convert.ToString(totalamount.FirstOrDefault().tot);
                        txt_BillAmount.Text = Convert.ToString(Convert.ToDecimal(txt_LabourCharges.Text) + Convert.ToDecimal(txt_ttotalAmount.Text));
                        double a1 = Convert.ToDouble(txt_BillAmount.Text);
                        string[] str = a1.ToString().Split('.');
                        if (str.Length != 1)
                        {
                            double num1 = Convert.ToDouble("0." + str[1]);
                            double res;
                            if (num1 < 0.51)
                            {
                                res = Math.Floor(a1);
                                txt_BillAmount.Text = res.ToString("0.00");
                            }
                            else
                            {
                                res = Math.Round(a1);
                                txt_BillAmount.Text = res.ToString("0.00");
                            }
                        }
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
    public void check()
    {
        if (CheckBox1.Checked == true)
        {
            txt_ServiceTaxAmt.ReadOnly = false;
            decimal service = Convert.ToDecimal(txt_ServiceTaxPer.Text) / 100;

            decimal a = service * Convert.ToDecimal(txt_LabourChargesAftDisc.Text);
            txt_ServiceTaxAmt.Text = (SmitaClass.SignificantTruncate(a, 2)).ToString("0.00");



            decimal f = Convert.ToDecimal(txt_ttotalAmount.Text) + Convert.ToDecimal(txt_LubricantttotalAmount.Text) + Convert.ToDecimal(txt_LabourChargesAftDisc.Text) + Convert.ToDecimal(txt_ServiceTaxAmt.Text);
            txt_BillAmount.Text = (SmitaClass.SignificantTruncate(f, 2)).ToString("0.00");
            double a1 = Convert.ToDouble(txt_BillAmount.Text);
            string[] str = a1.ToString().Split('.');
            if (str.Length != 1)
            {
                double num1 = Convert.ToDouble("0." + str[1]);
                double res;
                if (num1 < 0.51)
                {
                    res = Math.Floor(a1);
                    txt_BillAmount.Text = res.ToString("0.00");
                }
                else
                {
                    res = Math.Round(a1);
                    txt_BillAmount.Text = res.ToString("0.00");
                }
            }
        }
        else
        {
            txt_ServiceTaxAmt.ReadOnly = true;

            txt_BillAmount.Text = Convert.ToString(Convert.ToDecimal(txt_BillAmount.Text) - Convert.ToDecimal(txt_ServiceTaxAmt.Text));
            txt_ServiceTaxAmt.Text = "0.00";
            double a1 = Convert.ToDouble(txt_BillAmount.Text);
            string[] str = a1.ToString().Split('.');
            if (str.Length != 1)
            {
                double num1 = Convert.ToDouble("0." + str[1]);
                double res;
                if (num1 < 0.51)
                {
                    res = Math.Floor(a1);
                    txt_BillAmount.Text = res.ToString("0.00");
                }
                else
                {
                    res = Math.Round(a1);
                    txt_BillAmount.Text = res.ToString("0.00");
                }
            }

        }
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        check();
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        string imgid = img.ToolTip;
        foreach (GridViewRow gr in GridView1.Rows)
        {
            ImageButton imgFc = (ImageButton)gr.FindControl("ImageButton1");
            string id = imgFc.ToolTip;
            if (imgid == id)
            {
                TextBox txtlabour = (TextBox)gr.FindControl("Labels6");



                ImageButton imgFcc = (ImageButton)gr.FindControl("ImageButton2");

                txtlabour.ReadOnly = false;


                txtlabour.BackColor = System.Drawing.Color.Cyan;


                imgFc.Visible = false;
                imgFcc.Visible = true;
            }
        }
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        string imgid = img.ToolTip;
        foreach (GridViewRow gr in GridView1.Rows)
        {
            ImageButton imgFc = (ImageButton)gr.FindControl("ImageButton2");
            string id = imgFc.ToolTip;
            int slno = Convert.ToInt32(id);
            if (imgid == id)
            {
                TextBox txtlabour = (TextBox)gr.FindControl("Labels6");
                decimal txt_labour = Convert.ToDecimal(txtlabour.Text);

                ImageButton imgFcc = (ImageButton)gr.FindControl("ImageButton1");


                AME_Service_JobCardServiceDetails mu = db.AME_Service_JobCardServiceDetails.First(t => t.JCS_Sino == slno);
                mu.JCS_Amount = txt_labour;


                mu.Created_Date = SmitaClass.IndianTime();
                db.SaveChanges();

                txtlabour.ReadOnly = true;


                imgFc.Visible = true;
                imgFcc.Visible = false;
                fillservicedetails();
                fillservicedetails1();

                txt_ServiceTaxAmt.ReadOnly = false;
                decimal service = Convert.ToDecimal(txt_ServiceTaxPer.Text) / 100;

                decimal a = service * Convert.ToDecimal(txt_LabourChargesAftDisc.Text);
                txt_ServiceTaxAmt.Text = (SmitaClass.SignificantTruncate(a, 2)).ToString("0.00");


                decimal f = Convert.ToDecimal(txt_ttotalAmount.Text) + Convert.ToDecimal(txt_LubricantttotalAmount.Text) + Convert.ToDecimal(txt_LabourChargesAftDisc.Text) + Convert.ToDecimal(txt_ServiceTaxAmt.Text) ;
                txt_BillAmount.Text = (SmitaClass.SignificantTruncate(f, 2)).ToString("0.00");
                double a1 = Convert.ToDouble(txt_BillAmount.Text);
                string[] str = a1.ToString().Split('.');
                if (str.Length != 1)
                {
                    double num1 = Convert.ToDouble("0." + str[1]);
                    double res;
                    if (num1 < 0.51)
                    {
                        res = Math.Floor(a1);
                        txt_BillAmount.Text = res.ToString("0.00");
                    }
                    else
                    {
                        res = Math.Round(a1);
                        txt_BillAmount.Text = res.ToString("0.00");
                    }
                }


                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Labour Charge Updated Sucessfully..!!!');</script>", false);
                return;
            }
        }
    }
    [System.Web.Services.WebMethod]
    public static string[] GetServiceCode(string prefixText, int count)
    {

        string Sale = Convert.ToString(HttpContext.Current.Session["saletype"]);
        string branch = HttpContext.Current.Session["Branch"].ToString();
        if (HttpContext.Current.Session["saletype"] != null)
        {

            AutoMobileEntities db = new AutoMobileEntities();
            return db.AME_Master_ServiceHead.Where(n => n.Mh_ServiceCode.Contains(prefixText) && n.Branch_Name == branch && n.Mh_SaleStatus == Sale).OrderBy(n => n.Mh_ServiceCode).Select(n => n.Mh_ServiceCode).Distinct().Take(count).ToArray();
        }
        else
        {

            AutoMobileEntities db = new AutoMobileEntities();
            return db.AME_Master_ServiceHead.Where(n => n.Mh_ServiceCode.Contains(prefixText) && n.Branch_Name == branch).OrderBy(n => n.Mh_ServiceCode).Select(n => n.Mh_ServiceCode).Distinct().Take(count).ToArray();
        }
    }
    [System.Web.Services.WebMethod]
    public static string[] GetServiceDesc(string prefixText, int count)
    {

        string Sale = HttpContext.Current.Session["saletype"].ToString();
        string branch = HttpContext.Current.Session["Branch"].ToString();
        if (HttpContext.Current.Session["saletype"] != null)
        {
            AutoMobileEntities db = new AutoMobileEntities();
            return db.AME_Master_ServiceHead.Where(n => n.Mh_ServiceHead.Contains(prefixText) && n.Branch_Name == branch && n.Mh_SaleStatus == Sale).OrderBy(n => n.Mh_ServiceHead).Select(n => n.Mh_ServiceHead).Distinct().Take(count).ToArray();
        }
        else
        {
            AutoMobileEntities db = new AutoMobileEntities();
            return db.AME_Master_ServiceHead.Where(n => n.Mh_ServiceHead.Contains(prefixText) && n.Branch_Name == branch).OrderBy(n => n.Mh_ServiceHead).Select(n => n.Mh_ServiceHead).Distinct().Take(count).ToArray();
        }

    }
    protected void btn_ServiceAdd_Click(object sender, EventArgs e)
    {
        if (txt_SCode.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Service Code Shouldnot Blank..!!!');</script>", false);
            txt_SCode.Focus();
            txt_SCode.Text = "";
            return;
        }
        if (txt_SDescription.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Description Shouldnot Blank..!!!');</script>", false);
            txt_SDescription.Focus();
            txt_SDescription.Text = "";
            return;
        }
        if (drp_labtype.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select labour Type..!!'); </script>", false);
            drp_labtype.Focus();
            return;
        }
        if (txt_SRate.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Rate Shouldnot Blank..!!!');</script>", false);
            txt_SRate.Focus();
            txt_SRate.Text = "";
            return;
        }
        if (txt_SRate.Text == "0")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Rate Shouldnot Zero..!!!');</script>", false);
            txt_SRate.Focus();
            txt_SRate.Text = "";
            return;
        }
        if (txt_SRate.Text == "0.00")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Rate Shouldnot Zero..!!!');</script>", false);
            txt_SRate.Focus();
            txt_SRate.Text = "";
            return;
        }
        if (txt_SQuantity.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Quantity Shouldnot Blank..!!!');</script>", false);
            txt_SQuantity.Focus();
            txt_SQuantity.Text = "";
            return;
        }
        if (txt_SQuantity.Text == "0")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Quantity Shouldnot Zero..!!!');</script>", false);
            txt_SQuantity.Focus();
            txt_SQuantity.Text = "";
            return;
        }
        if (txt_SAmount.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Amount Shouldnot Blank..!!!');</script>", false);
            txt_SAmount.Focus();
            txt_SAmount.Text = "";
            return;
        }
        AME_Service_JobCardServiceDetails asj = new AME_Service_JobCardServiceDetails();
        asj.Branch_Name = Session["Branch"].ToString();
        asj.Created_By = Session["Uid"].ToString();
        asj.Created_Date = SmitaClass.IndianTime();
        asj.JC_No = Convert.ToInt32(txt_jcno.Text);
        asj.JCS_Amount = Convert.ToDecimal(txt_SAmount.Text);
        asj.JCS_Description = txt_SDescription.Text;
        asj.JCS_Quantity = Convert.ToDecimal(txt_SQuantity.Text);
        asj.JCS_Rate = Convert.ToDecimal(txt_SRate.Text);
        asj.Jc_year = txt_jcyear.Text;
        asj.JCS_Servicecode = txt_SCode.Text;
        asj.JCS_SpareType = drp_labtype.SelectedItem.Text;
        asj.JCS_DisAmu = Convert.ToDecimal(txt_discamu.Text);
        asj.JCS_Disper = Convert.ToDecimal(txt_disc.Text);
        asj.JCS_Status = "OPEN";
        asj.JSC_Labour = 0;
        db.AddToAME_Service_JobCardServiceDetails(asj);
        db.SaveChanges();
        fillservicedetails();
        fillservicedetails1();
        txt_SAmount.Text = "";
        txt_SQuantity.Text = "";
        txt_SRate.Text = "";
        txt_SCode.Text = "";
        txt_SDescription.Text = "";
        drp_labtype.SelectedIndex = 0;
    }
    protected void txt_SCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            var v = from k in db.AME_Master_ServiceHead.ToList()
                    where (k.Mh_ServiceCode.Equals(txt_SCode.Text))
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
    protected void txt_SDescription_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string branch = Session["Branch"].ToString();
            var v = from k in db.AME_Master_ServiceHead.ToList()
                    where (k.Mh_ServiceHead.Equals(txt_SDescription.Text.Trim()) && k.Branch_Name == branch)
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

    protected void img_del_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton img_del = (ImageButton)sender;
            string id = Convert.ToString(img_del.ToolTip);
            int id1 = Convert.ToInt32(id);

            AME_Service_JobCardServiceDetails jse = db.AME_Service_JobCardServiceDetails.First(t => t.JCS_Sino == id1);
            db.DeleteObject(jse);
            db.SaveChanges();
            id = "";
            fillservicedetails();
            fillservicedetails1();

        }
        catch
        {

        }
    }
    protected void txt_LabDiscountPer_TextChanged(object sender, EventArgs e)
    {

    }

    protected void txt_tdiscper_TextChanged(object sender, EventArgs e)
    {

        decimal discper = Convert.ToDecimal(txt_tdiscper.Text);
        string branch = Session["Branch"].ToString();
        int jc = Convert.ToInt32(txt_jcno.Text.Trim());
        var v = from c in db.AME_Service_JobcardSpareIssue.Where(t => t.JC_No == jc && t.Branch_Name == branch) select c;
        if (Convert.ToInt32(v.Count()) > 0)
        {
            foreach (var a in v.ToList())
            {
                string itemcode = a.Itm_code.ToString();
                decimal amnt = Convert.ToDecimal(a.SE_Amount);
                decimal vat = Convert.ToDecimal(a.SE_Vat);
                decimal ab = discper / 100;
                decimal discamnt = amnt * ab;
                decimal net = amnt - discamnt;
                decimal abc = vat / 100;
                decimal vatamnt = net * abc;
                decimal total = net + vatamnt;
                int sl = a.SE_Id;

                AME_Service_JobcardSpareIssue pd = db.AME_Service_JobcardSpareIssue.First(t => t.JC_No == jc && t.SE_Id == sl && t.Itm_code == itemcode);

                pd.SE_Discount = discamnt;
                pd.SE_DiscountPer = discper;
                pd.SE_Taxamount = vatamnt;
                pd.SE_Total = total;
                pd.SE_Vat = vat;
                db.SaveChanges();
            }
        }
        fillEdit();
        edit1();
        fillservicedetails1();
    }

    protected void txt_disc_TextChanged(object sender, EventArgs e)
    {
        try
        {
            decimal qty = 0, rate = 0, amu = 0, dic = 0, dic1 = 0, tot = 0;


            if (drp_labtype.SelectedItem.Text == "WARRANTY")
            {
                //qty = Convert.ToDecimal(txt_SQuantity.Text);

                //rate = Convert.ToDecimal(txt_SRate.Text);

                //amu = qty * rate;

                //dic = Convert.ToDecimal(txt_disc.Text);

                //dic1 = (amu * dic) / 100;

                //tot = amu - dic1;

                txt_discamu.Text = "0.00";
                txt_SAmount.Text = "0.00";
                //txt_SAmount.Text = "0.00";

            }
            else if (drp_labtype.SelectedItem.Text == "AMC")
            {
                //qty = Convert.ToDecimal(txt_SQuantity.Text);

                //rate = Convert.ToDecimal(txt_SRate.Text);

                //amu = qty * rate;

                //dic = Convert.ToDecimal(txt_disc.Text);

                //dic1 = (amu * dic) / 100;

                //tot = amu - dic1;

                txt_discamu.Text = "0.00";
                txt_SAmount.Text = "0.00";
                //txt_SAmount.Text = "0.00";

            }
            else
            {

                qty = Convert.ToDecimal(txt_SQuantity.Text);

                rate = Convert.ToDecimal(txt_SRate.Text);

                amu = qty * rate;

                dic = Convert.ToDecimal(txt_disc.Text);

                dic1 = (amu * dic) / 100;

                tot = amu - dic1;

                txt_discamu.Text = dic1.ToString("0.00");
                txt_SAmount.Text = tot.ToString("0.00");

            }
            //qty = Convert.ToDecimal(txt_SQuantity.Text);

            //rate = Convert.ToDecimal(txt_SRate.Text);

            //amu = qty * rate;

            //dic = Convert.ToDecimal(txt_disc.Text);

            //dic1 = (amu * dic) / 100;

            //tot = amu - dic1;

            //txt_discamu.Text = dic1.ToString("0.00");
            //txt_SAmount.Text = tot.ToString("0.00");



        }
        catch (Exception ex)
        { }
    }
    protected void drp_labtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            decimal qty = 0, rate = 0, amu = 0, dic = 0, dic1 = 0, tot = 0;

            if (drp_labtype.SelectedItem.Text == "WARRANTY")
            {
                txt_discamu.Text = "0.00";
                txt_SAmount.Text = "0.00";

            }
            else if (drp_labtype.SelectedItem.Text == "AMC")
            {
                txt_discamu.Text = "0.00";
                txt_SAmount.Text = "0.00";

            }
            else if (drp_labtype.SelectedItem.Text == "FOC")
            {
                txt_discamu.Text = "0.00";
                txt_SAmount.Text = "0.00";

            }
            else
            {
                qty = Convert.ToDecimal(txt_SQuantity.Text);

                rate = Convert.ToDecimal(txt_SRate.Text);

                amu = qty * rate;

                dic = Convert.ToDecimal(txt_disc.Text);

                dic1 = (amu * dic) / 100;

                tot = amu - dic1;

                txt_discamu.Text = dic1.ToString("0.00");
                txt_SAmount.Text = tot.ToString("0.00");
                //decimal RAT = Convert.ToDecimal(txt_SRate.Text);

                //decimal qty = Convert.ToDecimal(txt_SQuantity.Text);

                //decimal amu1 = RAT * qty;
                //txt_SAmount.Text = amu1.ToString("0.00");

            }

        }
        catch (Exception ex)
        { }
    }
    protected void txt_SQuantity_TextChanged(object sender, EventArgs e)
    {
        try
        {
            decimal qty = 0, rate = 0, amu = 0, dic = 0, dic1 = 0, tot = 0;

            if (drp_labtype.SelectedItem.Text == "WARRANTY")
            {
                txt_discamu.Text = "0.00";
                txt_SAmount.Text = "0.00";

            }
            else if (drp_labtype.SelectedItem.Text == "AMC")
            {
                txt_discamu.Text = "0.00";
                txt_SAmount.Text = "0.00";

            }
            else if (drp_labtype.SelectedItem.Text == "FOC")
            {
                txt_discamu.Text = "0.00";
                txt_SAmount.Text = "0.00";

            }
            else
            {
                qty = Convert.ToDecimal(txt_SQuantity.Text);

                rate = Convert.ToDecimal(txt_SRate.Text);

                amu = qty * rate;

                dic = Convert.ToDecimal(txt_disc.Text);

                dic1 = (amu * dic) / 100;

                tot = amu - dic1;

                txt_discamu.Text = dic1.ToString("0.00");
                txt_SAmount.Text = tot.ToString("0.00");
                //decimal RAT = Convert.ToDecimal(txt_SRate.Text);

                //decimal qty = Convert.ToDecimal(txt_SQuantity.Text);

                //decimal amu1 = RAT * qty;
                //txt_SAmount.Text = amu1.ToString("0.00");

            }

        }
        catch (Exception ex)
        { }
    }
    protected void txt_SRate_TextChanged(object sender, EventArgs e)
    {
        try
        {

            decimal qty = 0, rate = 0, amu = 0, dic = 0, dic1 = 0, tot = 0;

            if (drp_labtype.SelectedItem.Text == "WARRANTY")
            {
                txt_discamu.Text = "0.00";
                txt_SAmount.Text = "0.00";

            }
            else if (drp_labtype.SelectedItem.Text == "AMC")
            {
                txt_discamu.Text = "0.00";
                txt_SAmount.Text = "0.00";

            }
            else if (drp_labtype.SelectedItem.Text == "FOC")
            {
                txt_discamu.Text = "0.00";
                txt_SAmount.Text = "0.00";

            }
            else
            {
                qty = Convert.ToDecimal(txt_SQuantity.Text);

                rate = Convert.ToDecimal(txt_SRate.Text);

                amu = qty * rate;

                dic = Convert.ToDecimal(txt_disc.Text);

                dic1 = (amu * dic) / 100;

                tot = amu - dic1;

                txt_discamu.Text = dic1.ToString("0.00");
                txt_SAmount.Text = tot.ToString("0.00");
                //decimal RAT = Convert.ToDecimal(txt_SRate.Text);

                //decimal qty = Convert.ToDecimal(txt_SQuantity.Text);

                //decimal amu1 = RAT * qty;
                //txt_SAmount.Text = amu1.ToString("0.00");

            }
            //if (drp_labtype.SelectedItem.Text == "WARRANTY")
            //{

            //    txt_SAmount.Text = "0.00";

            //}
            //else if (drp_labtype.SelectedItem.Text == "AMC")
            //{

            //    txt_SAmount.Text = "0.00";

            //}
            //else
            //{

            //    decimal RAT = Convert.ToDecimal(txt_SRate.Text);

            //    decimal qty = Convert.ToDecimal(txt_SQuantity.Text);

            //    decimal amu1 = RAT * qty;
            //    txt_SAmount.Text = amu1.ToString("0.00");

            //}

        }
        catch (Exception ex)
        { }
    }
}