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

    int submitcheck = 0;
    Clear cl = new Clear();
    public string uname;
    decimal lbls18 = 0, lbls28 = 0, lblls18 = 0, lblls28 = 0, lblst18 = 0, lblst28 = 0, lbllt18 = 0, lbllt28 = 0, lblsd18 = 0, lblsd28 = 0, lblld18 = 0, lblld28 = 0, lblds18 = 0, lblds28 = 0, lbldl18 = 0, lbldl28 = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //string script = "$(document).ready(function () { $('[id*=btn_Submit]').click(); });";
            //ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);

            Fillsino();
            FillInvoiceNo();
            txt_invdate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
            txt_jcyear.Text = "2018-19";
            //CheckBox1.Checked = true;
        }
    }









    //---ajax start

    public class RotPartNumberWise
    {
        public string Itm_code { get; set; }

        public string Itm_PartDescrption { get; set; }


        public decimal Mh_ServiceRate { get; set; }

    }


    [System.Web.Services.WebMethod]

    public static List<RotPartNumberWise> GetAllitems(string partno)
    {
        List<RotPartNumberWise> getlist = new List<RotPartNumberWise>();
        AutoMobileEntities db = new AutoMobileEntities();
        string branchname = HttpContext.Current.Session["Branch"].ToString();
        var part = db.AME_Master_ServiceHead.Where(t => t.Branch_Name == branchname && t.Mh_ServiceCode == partno).FirstOrDefault();



        RotPartNumberWise obj = new RotPartNumberWise();
        obj.Itm_code = part.Mh_ServiceCode;
        obj.Itm_PartDescrption = part.Mh_ServiceHead;
        obj.Mh_ServiceRate = Convert.ToDecimal(part.Mh_ServiceRate);
        getlist.Add(obj);

        return getlist;
    }


    [System.Web.Services.WebMethod]

    public static List<RotPartNumberWise> GetAllitemsbyDesc(string partdesc)
    {
        List<RotPartNumberWise> getlist = new List<RotPartNumberWise>();
        AutoMobileEntities db = new AutoMobileEntities();
        string branchname = HttpContext.Current.Session["Branch"].ToString();
        var part = db.AME_Master_ServiceHead.Where(t => t.Branch_Name == branchname && t.Mh_ServiceHead == partdesc).FirstOrDefault();



        RotPartNumberWise obj = new RotPartNumberWise();
        obj.Itm_code = part.Mh_ServiceCode;
        obj.Itm_PartDescrption = part.Mh_ServiceHead;
        obj.Mh_ServiceRate = Convert.ToDecimal(part.Mh_ServiceRate);
        getlist.Add(obj);

        return getlist;
    }





    //--ajax end
































    [System.Web.Services.WebMethod]
    public static string[] GetServiceDesc(string prefixText, int count)
    {
        string Sale = Convert.ToString(HttpContext.Current.Session["saletype"]);
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
    private void FillInvoiceNo()
    {
        string branchname = Session["Branch"].ToString();
        string InvType = ddl_invtype.SelectedValue.ToString();
        if ((from c in db.AME_BillCounter where c.Branch_Name == branchname && c.BillType == "Spare_TaxSales" select c.BillCounter).Count() > 0)
        {
            int VNo = (int)(from c in db.AME_BillCounter where c.Branch_Name == branchname && c.BillType == "Spare_TaxSales" select c.BillCounter).Max();
            //if (ddl_invtype.SelectedItem.Text == "Tax Invoice")
            //{
            //    txt_invno.Text = "T/" + Convert.ToString(VNo + 1);
            //}


            if (branchname == "Cuttack")
            {
                txt_invno.Text = "LCTC/" + Convert.ToString(VNo + 1) + "/2018-19";
            }
            if (branchname == "Phulnakhara")
            {
                txt_invno.Text = "LPHU/" + Convert.ToString(VNo + 1) + "/2018-19";
            }
            if (branchname == "Berhampur")
            {
                txt_invno.Text = "LBRH/" + Convert.ToString(VNo + 1) + "/2018-19";
            }
            if (branchname == "Paradeep")
            {
                txt_invno.Text = "PRD/" + Convert.ToString(VNo + 1) + "/2018-19";
            }









            //{
            //    txt_invno.Text = "R/" + Convert.ToString(VNo + 1);
            //}
        }
        else
        {
            txt_invno.Text = "Error";
        }
    }

    private Boolean checkjcno()
    {

        Boolean checkfinal = true;
        string branchname = Session["Branch"].ToString();
        string year = txt_jcyear.Text.Trim();
        string jcno = txt_jcno.Text.Trim();
        string invo = txt_invno.Text.Trim();
        string param = "@branchname,@year,@jcno,@invo";

        string paramvalue = branchname + "," + year + "," + jcno + "," + invo;
        DataSet ds = smitaDbAccess.SPReturnDataSet("sp_checkfinal", param, paramvalue);
        int VNo = 0;
        try
        {
            VNo = int.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString());

            if (VNo > 0)
            {
                checkfinal = false;

            }
        }
        catch (Exception)
        {
            checkfinal = false;
            //throw;
        }



        return checkfinal;

    }

    private Boolean FillInvoiceNosubmit()
    {
        Boolean isupdae = true;
        string branchname = Session["Branch"].ToString();
        string InvType = ddl_invtype.SelectedValue.ToString();
        if ((from c in db.AME_BillCounter where c.Branch_Name == branchname && c.BillType == "Spare_TaxSales" select c.BillCounter).Count() > 0)
        {
            string param = "@Billtype,@Branch,@Jcno,@billno";

            string paramvalue = InvType + "," + branchname + "," + txt_jcno.Text + "," + txt_invno.Text;

            DataSet ds = smitaDbAccess.SPReturnDataSet("Getmaxinvoiceno", param, paramvalue);
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
                //if (ddl_invtype.SelectedItem.Text == "Tax Invoice")
                //{
                //    txt_invno.Text = "T/" + Convert.ToString(VNo + 1);
                //}
                //else
                //{
                //    txt_invno.Text = "R/" + Convert.ToString(VNo + 1);
                //}
                if (branchname == "Cuttack")
                {
                    txt_invno.Text = "LCTC/" + Convert.ToString(VNo + 1) + "/2018-19";
                }
                if (branchname == "Phulnakhara")
                {
                    txt_invno.Text = "LPHU/" + Convert.ToString(VNo + 1) + "/2018-19";
                }
                if (branchname == "Berhampur")
                {
                    txt_invno.Text = "LBRH/" + Convert.ToString(VNo + 1) + "/2018-19";
                }
                if (branchname == "Paradeep")
                {
                    txt_invno.Text = "PRD/" + Convert.ToString(VNo + 1) + "/2018-19";
                }
            }
        }
        else
        {
            txt_invno.Text = "Error";
        }
        return isupdae;
    }
    private void FillCustomer()
    {
        string Sale = Convert.ToString(Session["saletype"]);
        if (Session["saletype"] != null)
        {


            DataSet ds = smitaDbAccess.returndataset("select (Mc_Name + Mc_Mobileno) AS Cu_Name , Mc_Id As Cu_Code FROM AME_Master_Customer WHERE  Branch_Name='" + Session["Branch"].ToString() + "' AND Mc_Status= '" + true + "'  AND Mc_SaleStatus= '" + Sale + "' ");

            ddl_customer.DataSource = ds;
            ddl_customer.DataTextField = "Cu_Name";
            ddl_customer.DataValueField = "Cu_Code";
            ddl_customer.DataBind();
            ddl_customer.Items.Insert(0, "--Select One--");





            //var v = from c in db.AME_Master_Customer.ToList().OrderBy(t => t.Mc_Name)
            //        where c.Mc_Status = true && c.Branch_Name == Session["Branch"].ToString() && c.Mc_SaleStatus == Sale
            //        select new
            //        {
            //            Cu_Name = c.Mc_Name + " - " + c.Mc_Mobileno,
            //            Cu_Code = c.Mc_Id
            //        };
            //ddl_customer.DataSource = v.ToList();
            //ddl_customer.DataTextField = "Cu_Name";
            //ddl_customer.DataValueField = "Cu_Code";
            //ddl_customer.DataBind();
            //ddl_customer.Items.Insert(0, "--Select One--");
        }
        else
        {

            DataSet ds = smitaDbAccess.returndataset("select (Mc_Name + Mc_Mobileno) AS Cu_Name , Mc_Id As Cu_Code FROM AME_Master_Customer WHERE  Branch_Name='" + Session["Branch"].ToString() + "' AND Mc_Status = '" + true + "'   ");
            

            ddl_customer.DataSource = ds;

            ddl_customer.DataTextField = "Cu_Name";
            ddl_customer.DataValueField = "Cu_Code";
            ddl_customer.DataBind();
            ddl_customer.Items.Insert(0, "--Select One--");









            //var v = from c in db.AME_Master_Customer.ToList().OrderBy(t => t.Mc_Name)
            //        where c.Mc_Status = true && c.Branch_Name == Session["Branch"].ToString()
            //        select new
            //        {
            //            Cu_Name = c.Mc_Name + " - " + c.Mc_Mobileno,
            //            Cu_Code = c.Mc_Id
            //        };
            //ddl_customer.DataSource = v.ToList();
            //ddl_customer.DataTextField = "Cu_Name";
            //ddl_customer.DataValueField = "Cu_Code";
            //ddl_customer.DataBind();
            //ddl_customer.Items.Insert(0, "--Select One--");
        }

    }
    public void fillEdit()
    {
        //string branchname = Session["Branch"].ToString();


        int sno = Convert.ToInt32(txt_jcno.Text);
        string Branch = Session["Branch"].ToString();
        string year = txt_jcyear.Text.Trim();
        string param = "@JC_No,@Branch,@year";
        string paramvalue = sno + "," + Branch + "," + year;


        DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_finalinvspareShow", param, paramvalue);
        if (dtr.Rows.Count > 0)
        {

            GridView2.DataSource = dtr;
            GridView2.DataBind();

        }

        else
        {

            GridView2.DataSource = null;
            GridView2.DataBind();
        }




        //var v = (from c in db.AME_Service_JobcardSpareIssue
        //         join e in db.AME_Service_JobCardEntry on new { c.JC_No, c.Branch_Name } equals new { e.JC_No, e.Branch_Name }
        //         join d in db.AME_Master_VehicleModel on e.JC_Modelname equals d.Mv_Id

        //         join f in db.AME_Master_Technician on e.JCTechnisianName equals f.Mt_Id
        //         join h in db.AME_Master_Customer on e.JC_Customername equals h.Mc_Id
        //         join g in db.AME_Master_Item on c.Itm_code equals g.Itm_code
        //         where c.JC_No == sno && c.Branch_Name == branchname && c.SE_Quantity > 0 && c.Ms_Status=="OPEN" && e.Ms_Status=="OPEN" && c.Jc_year==txt_jcyear.Text.Trim() && e.JC_year==txt_jcyear.Text.Trim() && e.Branch_Name==branchname
        //         && h.Branch_Name== branchname && f.Branch_Name==branchname && d.Branch_Name==branchname
        //         select new
        //         {
        //             c.JC_No,
        //             c.SE_Sino,
        //             c.SE_Date,
        //             e.JC_Date,
        //             e.JC_Regno,
        //             e.JC_Engineno,
        //             c.SE_Sparetype,
        //             h.Mc_Name,
        //             e.JC_Caddress,
        //             e.JC_Chassisno,
        //             e.JCTechnisianName,
        //             c.Itm_code,
        //             c.SE_Amount,
        //             c.SE_Discount,
        //             c.SE_DiscountPer,
        //             c.SE_Quantity,
        //             c.SE_Rate,
        //             c.SE_Taxamount,
        //             c.SE_Total,
        //             c.SE_Vat,
        //             g.Itm_PartDescrption,
        //             g.Itm_Partno,
        //             d.Mv_ModelName,
        //             c.SE_Id,
        //             g.Itm_CategoryName
        //         }).Distinct().ToList();



        //GridView2.DataSource = v.ToList();
        //GridView2.DataBind();

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
            //laxmidhar code

            //txt_TotalSpareAmount.Text = txt_StotalAmount.Text;
        }
        try
        {
            txt_tdiscper.Text = fillDiscountPersent(Convert.ToDecimal(txt_SGrossAmount.Text), Convert.ToDecimal(txt_SerDiscountAmount.Text));
        }
        catch (Exception)
        {

            //  throw;
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
                 where c.JC_No == sno && c.Branch_Name == branchname && c.Ms_Status == "OPEN" && g.JCS_Status == "OPEN" && c.JC_year == txt_jcyear.Text.Trim() && g.Jc_year == txt_jcyear.Text.Trim() && g.Branch_Name == branchname
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
        //string sno = txt_jcno.Text;
        string year = txt_jcyear.Text.Trim();
        string param = "@JC_No,@Branch,@year";
        string paramvalue = sno + "," + branchname + "," + year;


        DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_finalinvesShowDetails", param, paramvalue);

        txt_jcno.Text = dtr.Rows[0].ItemArray[0].ToString();
        txt_address.Text = dtr.Rows[0].ItemArray[2].ToString();
        txt_jcyear.Text = dtr.Rows[0].ItemArray[1].ToString();
        txt_mobno.Text = dtr.Rows[0].ItemArray[10].ToString();
        txt_model.Text = dtr.Rows[0].ItemArray[4].ToString();
        string stype = dtr.Rows[0].ItemArray[17].ToString();
        ddl_servicetype.SelectedValue = stype;
        txt_RegdNo.Text = dtr.Rows[0].ItemArray[8].ToString();
        ddl_customer.SelectedItem.Text = dtr.Rows[0].ItemArray[21].ToString();
        btn_Submit.ToolTip = dtr.Rows[0].ItemArray[0].ToString();
        txt_tin.Text = dtr.Rows[0].ItemArray[22].ToString(); 





        //var v = (from c in db.AME_Service_JobCardEntry

        //         join d in db.AME_Master_VehicleModel on c.JC_Modelname equals d.Mv_Id
        //         join e in db.AME_Master_Supervisor on c.JC_SupervisorName equals e.Ms_Id
        //         join f in db.AME_Master_Technician on c.JCTechnisianName equals f.Mt_Id
        //         join h in db.AME_Master_Customer on c.JC_Customername equals h.Mc_Id
        //         where c.JC_No == sno && c.Branch_Name == branchname && c.Ms_Status == "OPEN" && c.JC_year == txt_jcyear.Text.Trim()
        //         select new

        //         {
        //             c.JC_No,
        //             c.JC_year,
        //             c.JC_Caddress,
        //             c.JC_Deliverydate,
        //             d.Mv_ModelName,
        //             c.JC_Engineno,
        //             c.JC_Grandtotal,
        //             c.JC_Keyno,
        //             c.JC_Regno,
        //             c.JC_Kmcovered,
        //             c.JC_MobileNo,
        //             c.JC_Phoneno,
        //             c.JCTechnisianName,
        //             c.JC_SupervisorName,
        //             c.JC_Modelname,
        //             c.JC_Customername,
        //             c.JC_SaleDate,
        //             c.JC_ServiceType,
        //             c.JC_Date,
        //             e.Ms_Name,
        //             f.Mt_Name,
        //             h.Mc_Name,
        //             h.Mc_Tin
        //         }).Distinct().ToList();

        ////txt_invdate.Text = v.First().JC_Date.ToString("dd/MM/yyyy");
        //txt_jcno.Text = Convert.ToString(v.First().JC_No);
        ////ddl_customer.SelectedValue = Convert.ToString(v.First().JC_Customername);
        //txt_address.Text = v.First().JC_Caddress;
        //txt_jcyear.Text = v.First().JC_year;
        //txt_mobno.Text = v.First().JC_MobileNo;
        //txt_model.Text = v.First().Mv_ModelName;
        //string stype = v.First().JC_ServiceType;
        //ddl_servicetype.SelectedValue = stype;
        //txt_RegdNo.Text = v.First().JC_Regno;
        //ddl_customer.SelectedItem.Text = v.First().Mc_Name;
        //btn_Submit.ToolTip = Convert.ToString(v.First().JC_No);
        //txt_tin.Text = v.First().Mc_Tin;

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
                if (num1 < 0.50)
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

    private string fillDiscountPersent(decimal Amount, decimal discountamt)
    {
        string disper = "0";
        decimal lubricantamt = 0;
        try
        {
            lubricantamt = Convert.ToDecimal(txt_lubricantGross.Text);
        }
        catch (Exception)
        {

            //  throw;
        }
        try
        {


            disper = (Math.Round(((discountamt / (Amount + lubricantamt)) * 100), 2)).ToString();

        }
        catch (Exception)
        {

            // throw;
        }
        return disper;
    }
    public void fillpaymemtdetails()
    {

        string branch = Session["Branch"].ToString();

        int id1 = Convert.ToInt32(txt_jcno.Text);
        var details = from c in db.AME_Service_JobcardProformaPaymentDetails.Where(t => t.PI_JcNo == id1 && t.Branch_Name == branch && t.jc_year == txt_jcyear.Text.Trim()) select c;
        var pi = from c in db.AME_Service_JobcardProformaInvoice.Where(t => t.PI_JcNo == id1 && t.Branch_Name == branch && t.jc_year == txt_jcyear.Text.Trim()) select c;

        txt_ServiceTaxAmt.Text = Convert.ToString(details.First().PIP_ServiceTax);
        txt_LabourChargesAftDisc.Text = Convert.ToString(details.First().PIP_LabourchargeAfterdis);
        txt_LabDiscountPer.Text = Convert.ToString(details.First().PIP_LabouechargeDiscountpercent);
        txt_LabDiscountAmount.Text = Convert.ToString(details.First().PIP_LabourchargeDiscountAmount);
        txt_LabourCharges.Text = Convert.ToString(details.First().PIP_Labourcharges);

        txt_ttotalAmount.Text = Convert.ToString(details.First().PIP_TotalSpareAmount);
        txt_SVatAmount.Text = Convert.ToString(details.First().PIP_VatAmount);
        txt_StotalAmount.Text = Convert.ToString(details.First().PIP_Total);

        txt_SerDiscountAmount.Text = Convert.ToString(details.First().PIP_DiscountAmount);

        txt_SGrossAmount.Text = Convert.ToString(details.First().PIP_Grossamount);

        // laxmidhar code

        txt_tdiscper.Text = fillDiscountPersent(details.First().PIP_Grossamount, details.First().PIP_DiscountAmount);

        //txt_tin.Text = Convert.ToString(pi.First().PI_Tin);
        txt_BillAmount.Text = (details.First().PIP_BillAmount).ToString("0.00");
        double a1 = Convert.ToDouble(txt_BillAmount.Text);
        string[] str = a1.ToString().Split('.');
        if (str.Length != 1)
        {
            double num1 = Convert.ToDouble("0." + str[1]);
            double res;
            if (num1 < 0.50)
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

    //decimal tot1 = 0, tot2 = 0, tot3 = 0, tot4 = 0;
    decimal countS18 = 0, countS28 = 0, countL18 = 0, countL28 = 0, countLv18 = 0, countLv28 = 0, countV28 = 0, countV18 = 0;
    decimal countds18 = 0, countds28 = 0, countdl18 = 0, countdl28 = 0;
    decimal sparetot = 0, lubvaluetot = 0;
    public void fillgrid()
    {

        foreach (GridViewRow gr in GridView2.Rows)
        {
            Label lbl_partno = (Label)gr.FindControl("Label10");
            Label lbl_partDesc = (Label)gr.FindControl("Label12");
            Label lbl_Quantity = (Label)gr.FindControl("Label11");
            Label lbl_Rate = (Label)gr.FindControl("Label14");
            Label lbl_Amount = (Label)gr.FindControl("Label13");
            Label lbl_Discountp = (Label)gr.FindControl("lbl_discper");
            Label lbl_Discount = (Label)gr.FindControl("Label15");
            Label lbl_Vat = (Label)gr.FindControl("Label16");
            Label lbl_TaxAmt = (Label)gr.FindControl("Label17");
            Label lbl_Total = (Label)gr.FindControl("Label18");
            Label lblcategory = (Label)gr.FindControl("lblcategory");

            decimal vat = Convert.ToDecimal(lbl_Vat.Text);
            decimal spre5amount = Convert.ToDecimal(lbl_Amount.Text);



            if ((lblcategory.Text == "Spareparts" || lblcategory.Text == "Accessories" || lblcategory.Text == "Other") && lbl_Vat.Text == "18.00")
            {

                decimal vat18 = Convert.ToDecimal(lbl_TaxAmt.Text);
                decimal lubvalue18 = Convert.ToDecimal(lbl_Amount.Text);
                decimal dic18 = Convert.ToDecimal(lbl_Discount.Text);
                countV18 = Convert.ToDecimal(countV18 + vat18);
                countS18 = Convert.ToDecimal(countS18 + lubvalue18);
                countds18 = Convert.ToDecimal(countds18 + dic18);

                lblst18 = Convert.ToDecimal(countV18);
                lbls18 = Convert.ToDecimal(countS18);
                lblds18 = Convert.ToDecimal(countds18);
            }


            else if ((lblcategory.Text == "Spareparts" || lblcategory.Text == "Accessories" || lblcategory.Text == "Other") && lbl_Vat.Text == "28.00")
            {

                decimal vat28 = Convert.ToDecimal(lbl_TaxAmt.Text);
                decimal lubvalue28 = Convert.ToDecimal(lbl_Amount.Text);
                decimal dic28 = Convert.ToDecimal(lbl_Discount.Text);

                countV28 = Convert.ToDecimal(countV28 + vat28);
                countS28 = Convert.ToDecimal(countS28 + lubvalue28);
                countds28 = Convert.ToDecimal(countds28 + dic28);
                lblst28 = Convert.ToDecimal(countV28);
                lbls28 = Convert.ToDecimal(countS28);
                lblds28 = Convert.ToDecimal(countds28);

            }

            else if (lblcategory.Text == "Lubricants" && lbl_Vat.Text == "28.00")
            {


                decimal vatl28 = Convert.ToDecimal(lbl_TaxAmt.Text);
                decimal lubvaluel28 = Convert.ToDecimal(lbl_Amount.Text);
                decimal dicl28 = Convert.ToDecimal(lbl_Discount.Text);

                countL28 = Convert.ToDecimal(countL28 + lubvaluel28);
                countLv28 = Convert.ToDecimal(countLv28 + vatl28);
                countdl28 = Convert.ToDecimal(countdl28 + dicl28);
                lblls28 = Convert.ToDecimal(countL28);
                lbllt28 = Convert.ToDecimal(countLv28);
                lbldl28 = Convert.ToDecimal(countdl28);


            }
            else if (lblcategory.Text == "Lubricants" && lbl_Vat.Text == "18.00")
            {
                decimal vatl18 = Convert.ToDecimal(lbl_TaxAmt.Text);
                decimal lubvaluel18 = Convert.ToDecimal(lbl_Amount.Text);
                decimal dicl18 = Convert.ToDecimal(lbl_Discount.Text);
                countL18 = Convert.ToDecimal(countL18 + lubvaluel18);
                countLv18 = Convert.ToDecimal(countLv18 + vatl18);
                countdl18 = Convert.ToDecimal(countdl18 + dicl18);
                lblls18 = Convert.ToDecimal(countL18);
                lbllt18 = Convert.ToDecimal(countLv18);
                lbldl18 = Convert.ToDecimal(countdl18);


            }


        }
    }























    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            string scode = ViewState["statecode"].ToString();
            System.Threading.Thread.Sleep(2000);



            if (!checkjcno())
            {

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Alredy Jcno Or Billno Exits..!!'); </script>", false);

            }


            string branchname = Session["Branch"].ToString();
            var ChkInvoice = from c in db.AME_Spare_SalesEntry.Where(t => t.Sp_InvoiceNo == txt_invno.Text && t.Branch_Name == branchname) select c;

            if (Convert.ToInt32(ChkInvoice.Count()) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Press Submit button Again..!!!');</script>", false);

            }

            if (FillInvoiceNosubmit() == false)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Job Card Or Bill No already Closed..!!!');</script>", false);
                return;
            }

            fillgrid();
            submitcheck = submitcheck + 1;
            int id1 = Convert.ToInt32(txt_jcno.Text);
            AME_Service_JobcardFinalInvoice pi = new AME_Service_JobcardFinalInvoice();
            pi.FI_Sino = Convert.ToInt32(txt_serialno.Text);
            pi.Branch_Name = Session["Branch"].ToString();
            pi.jc_year = txt_jcyear.Text.Trim();
            pi.Created_By = Session["Uid"].ToString();
            pi.Created_Date = SmitaClass.IndianTime();
            pi.FI_FinalIVstatus = true;
            pi.FI_InvoiceDate = Convert.ToDateTime(txt_invdate.Text, SmitaClass.dateformat());
            pi.FI_InvoiceNo = txt_invno.Text;
            pi.FI_JcNo = Convert.ToInt32(txt_jcno.Text);
            pi.FI_PaymentType = ddl_paymenttype.SelectedItem.Text;
            pi.FI_FinalIVstatus = true;

            pi.FI_Status = "CLOSE";
            pi.Statecode = scode;
            if (scode.Equals("21"))
            {

                pi.scodeflag = false;


            }

            else
            {
                pi.scodeflag = true;
            }
            pi.gstflag = true;
            var dd = from c in db.AME_Service_JobcardProformaInvoice.Where(t => t.PI_JcNo == id1 && t.jc_year == txt_jcyear.Text.Trim()) select c;
            if (Convert.ToInt32(dd.Count()) > 0)
            {
                pi.FI_ProfomaIVStatus = true;
            }
            pi.FI_ProfomaIVStatus = false;
            pi.FI_TaxType = ddl_invtype.SelectedItem.Text;
            pi.FI_Tin = txt_tin.Text;
            pi.Submittedby = txt_submittedby.Text.Trim();
            db.AddToAME_Service_JobcardFinalInvoice(pi);
            db.SaveChanges();

            //insert data in performa paymentdetails

            AME_Service_JobcardFinalPaymentDetails pd = new AME_Service_JobcardFinalPaymentDetails();
            pd.PI_InvoiceNo = txt_invno.Text;
            pd.FIP_Sino = Convert.ToInt32(txt_serialno.Text);
            pd.Branch_Name = Session["Branch"].ToString();
            pd.Created_By = Session["Uid"].ToString();
            pd.Created_Date = SmitaClass.IndianTime();
            pd.jc_year = txt_jcyear.Text.Trim();
            decimal billamount = Convert.ToDecimal(txt_BillAmount.Text);
            decimal no = Math.Round(billamount, 2);
            pd.FIP_BillAmount = no;
            pd.FIP_DiscountAmount = Convert.ToDecimal(txt_SerDiscountAmount.Text);
            //pd.FIP_Discountpercent = Convert.ToDecimal(txt_SDiscountPer.Text);
            pd.FIP_EduCessPercent = 0;
            pd.FIP_Grossamount = Convert.ToDecimal(txt_SGrossAmount.Text);
            pd.FIP_LabouechargeDiscountpercent = Convert.ToDecimal(txt_LabDiscountPer.Text);
            pd.FIP_LabourchargeAfterdis = Convert.ToDecimal(txt_LabourChargesAftDisc.Text);
            pd.FIP_LabourchargeDiscountAmount = Convert.ToDecimal(txt_LabDiscountAmount.Text);
            pd.PIP_LubGross = Convert.ToDecimal(txt_lubricantGross.Text);
            pd.PIP_LubVat = Convert.ToDecimal(txt_LubricantVatAmount.Text);
            pd.PIP_LubTotal = Convert.ToDecimal(txt_LubricantttotalAmount.Text);
            pd.PIP_LubTotallubricant = Convert.ToDecimal(txt_LubtotalAmount.Text);

            pd.FIP_Labourcharges = Convert.ToDecimal(txt_LabourCharges.Text);
            pd.FIP_OtherCharges = 0;
            pd.FIP_OutsideService = 0;
            pd.FIP_ServiceTax = Convert.ToDecimal(txt_ServiceTaxAmt.Text);
            pd.FIP_ServiceTaxAmount = Convert.ToDecimal(txt_ServiceTaxAmt.Text);
            pd.FIP_ServiceTaxPercent = Convert.ToDecimal(txt_ServiceTaxPer.Text);
            pd.FIP_EduCess = 0;
            pd.FIP_SrHrEduCessAmount = 0;
            pd.FIP_SrHrEduCessPercent = 0;
            pd.FI_JcNo = Convert.ToInt32(txt_jcno.Text);
            pd.FIP_Status = "CLOSE";
            pd.FIP_Total = Convert.ToDecimal(txt_StotalAmount.Text);
            //pd.FIP_TotalSpareAmount = Convert.ToDecimal(txt_TotalSpareAmount.Text);
            pd.Se_TotalDiscountPerSpare = Convert.ToDecimal(txt_tdiscper.Text);
            //pd.Se_TotalDiscountSpare = Convert.ToDecimal(txt_tdiscamnt.Text);
            pd.Se_GTotalOfSpare = Convert.ToDecimal(txt_ttotalAmount.Text);
            pd.Statecode = scode;
            if (scode.Equals("21"))
            {

                pd.scodeflag = false;


            }

            else
            {
                pd.scodeflag = true;
            }
            pd.gstflag = true;
            pd.FIP_VatAmount = Convert.ToDecimal(txt_SVatAmount.Text);
            db.AddToAME_Service_JobcardFinalPaymentDetails(pd);
            db.SaveChanges();

            //billcounter
            string InvType = ddl_invtype.SelectedValue.ToString();
            int id = (int)(from c in db.AME_BillCounter where c.Branch_Name == branchname && c.BillType == "Spare_TaxSales" select c.BillCounter).Max();
            AME_BillCounter bc = db.AME_BillCounter.First(c => c.Branch_Name == branchname && c.BillType == "Spare_TaxSales");
            bc.BillCounter = id + 1;
            db.SaveChanges();

            string Branch = Session["Branch"].ToString();
            int cno = Convert.ToInt32(txt_jcno.Text);
            string year = txt_jcyear.Text.Trim();
            string param = "@Jcno,@Branch,@year";
            string paramvalue = cno + "," + Branch + " ," + year;
            DataSet ds1 = smitaDbAccess.SPReturnDataSet("sp_ServiceJobcard_FinalCheck", param, paramvalue);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                AME_Service_JobcardProformaInvoice piv = db.AME_Service_JobcardProformaInvoice.First(t => t.PI_JcNo == id1 && t.Branch_Name == branchname && t.jc_year == txt_jcyear.Text.Trim());
                piv.PI_Status = "CLOSE";
                db.SaveChanges();
            }

            if (ds1.Tables[1].Rows.Count > 0)
            {
                AME_Service_JobcardProformaPaymentDetails pivp = db.AME_Service_JobcardProformaPaymentDetails.First(t => t.PI_JcNo == id1 && t.Branch_Name == branchname && t.jc_year == txt_jcyear.Text.Trim());
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
            AME_Service_JobCardEntry jce = db.AME_Service_JobCardEntry.First(t => t.JC_No == id1 && t.Branch_Name == branchname && t.Ms_Status == "OPEN" && t.JC_year == txt_jcyear.Text.Trim());


            //AME_Service_JobCardEntry jce = db.AME_Service_JobCardEntry.First(t => t.JC_No == id1 && t.Branch_Name == branchname && t.Ms_Status == "OPEN" );

            jce.Ms_Status = "CLOSE";
            db.SaveChanges();
            //update jobcardservice details

            var jcs = from c in db.AME_Service_JobCardServiceDetails.ToList().Where(t => t.JC_No == id1 && t.Branch_Name == branchname && t.JCS_Status == "OPEN" && t.Jc_year == txt_jcyear.Text.Trim())
                      select c;

            //var jcs = from c in db.AME_Service_JobCardServiceDetails.ToList().Where(t => t.JC_No == id1 && t.Branch_Name == branchname && t.JCS_Status == "OPEN" )
            //          select c;
            foreach (var c1 in jcs)
            {
                AME_Service_JobCardServiceDetails jcs1 = db.AME_Service_JobCardServiceDetails.First(t => t.JC_No == id1 && t.Branch_Name == branchname && t.JCS_Status == "OPEN" && t.Jc_year == txt_jcyear.Text.Trim());

                //AME_Service_JobCardEntry jcs1 = db.AME_Service_JobCardEntry.First(t => t.JC_No == id1 && t.Branch_Name == branchname && t.Ms_Status == "OPEN" );

                c1.JCS_Status = "CLOSE";
                db.SaveChanges();

            }
            ////update spareparts    
            //   var sp = from c in db.AME_Service_JobcardSpareIssue.ToList().Where(t => t.JC_No == id1 && t.Branch_Name == branchname && t.Jc_year==txt_jcyear.Text.Trim())

            var sp = from c in db.AME_Service_JobcardSpareIssue.ToList().Where(t => t.JC_No == id1 && t.Branch_Name == branchname && t.Jc_year == txt_jcyear.Text.Trim())

                     select c;

            foreach (var c2 in sp)
            {
                AME_Service_JobcardSpareIssue sp1 = db.AME_Service_JobcardSpareIssue.First(t => t.JC_No == id1 && t.Branch_Name == branchname && t.Ms_Status == "OPEN" && t.Jc_year == txt_jcyear.Text.Trim());
                //AME_Service_JobCardEntry sp1 = db.AME_Service_JobCardEntry.First(t => t.JC_No == id1 && t.Branch_Name == branchname && t.Ms_Status=="OPEN" && t.JC_year==txt_jcyear.Text.Trim());


                c2.Ms_Status = "CLOSE";


                db.SaveChanges();

            }

            ////Upadte Spare return
            // var sr = from c in db.AME_Service_JobCardSpareReturn.Where(t => t.JC_No == id1 && t.Branch_Name == branchname)
            //          select c;
            //if(Convert.ToInt32(sr.Count())>0)
            //{
            // foreach (var c3 in sr)
            // {
            //     AME_Service_JobCardSpareReturn sr1 = db.AME_Service_JobCardSpareReturn.First(t => t.JC_No == id1 && t.Branch_Name == branchname);
            //     c3.Ms_Status = "CLOSE";
            //     db.SaveChanges();
            // }
            //}
            // daily Sales Report Dtaa insert
            decimal tspare = Convert.ToDecimal(txt_StotalAmount.Text);
            decimal tlub = Convert.ToDecimal(txt_LubtotalAmount.Text);
            string tax = "28";
            decimal op = Convert.ToDecimal(tax);
            decimal opp = op / 100;
            decimal ospare13_5 = tspare * opp;










            AME_Daily_SpareSales_Report dsr = new AME_Daily_SpareSales_Report();
            dsr.DR_InvoiceNo = txt_invno.Text;
            dsr.DR_IDate = Convert.ToDateTime(txt_invdate.Text, SmitaClass.dateformat());
            dsr.DR_InvType = ddl_invtype.SelectedItem.Text;
            dsr.DR_InvStatus = "SERVICE";
            dsr.Dr_InvMode = ddl_paymenttype.SelectedValue.ToString();
            dsr.JC_No = Convert.ToInt32(txt_jcno.Text);
            dsr.jc_year = txt_jcyear.Text.Trim();
            //dsr.Dr_Spare13_5 = tspare;
            //dsr.Dr_Lub13_5 = tlub;
            //dsr.Dr_Lub5 = 0;
            //dsr.Dr_Spare5 = 0;

            dsr.Dr_Spare13_5 = lbls28;
            dsr.Dr_Lub13_5 = lblls28;
            dsr.Dr_Lub5 = lblls18;
            dsr.Dr_Spare5 = lbls18;

            dsr.Dr_DiscountAmount3_5 = lblds28 + lbldl28;
            dsr.Dr_DiscountAmount5 = lblds18 + lbldl18;

            dsr.Dr_Output13_5 = (lblst28 + lbllt28);
            dsr.Dr_Output5 = (lblst18 + lbllt18);
            //decimal discountamount = Convert.ToDecimal(txt_ADiscountAmount.Text);
            //dsr.Dr_DiscountAmount3_5 = 0;
            //dsr.Dr_DiscountAmount5 = 0;
            //decimal spare13_5 = (Convert.ToDecimal(txt_AGrossAmount.Text) * Convert.ToDecimal(13 * 5)) / 100;
            //  dsr.Dr_Output13_5 = Convert.ToDecimal(txt_SVatAmount.Text);


            // dsr.Dr_Output5 = 0;
            dsr.Dr_OtherCharges = 0;
            dsr.Dr_Labourcharges = Convert.ToDecimal(txt_LabourCharges.Text);
            dsr.Dr_NetLabourcharges = Convert.ToDecimal(txt_LabourChargesAftDisc.Text);
            dsr.Dr_Servtaxx12 = Convert.ToDecimal(txt_ServiceTaxAmt.Text);
            dsr.Dr_Ecess2 = 0;
            dsr.Dr_Scess1 = 0;
            dsr.Dr_Roundoff = 0;
            dsr.Dr_Outsidejob = 0;
            dsr.Dr_InvoiceTotal = Convert.ToDecimal(txt_BillAmount.Text);

            dsr.Dr_DisLabourcharges = Convert.ToDecimal(txt_LabDiscountAmount.Text);
            dsr.Statecode = scode;
            if (scode.Equals("21"))
            {

                dsr.scodeflag = false;


            }

            else
            {
                dsr.scodeflag = true;
            }
            dsr.gstflag = true;
            dsr.Branch_Name = Session["Branch"].ToString();
            db.AddToAME_Daily_SpareSales_Report(dsr);
            db.SaveChanges();

            Session["PID"] = txt_serialno.Text;
            Session["JCN"] = txt_jcno.Text;
            if (Session["Branch"].ToString() == "Paradeep")
            {

                Response.Redirect("Service_JobFinalInvoicePrint.aspx?year=" + txt_jcyear.Text.Trim() + "&jcno=" + txt_jcno.Text.Trim() + "&infno=" + txt_invno.Text.Trim());
            }
            else if (Session["Branch"].ToString() == "Cuttack")
            {
                Response.Redirect("Service_JobFinalInvoicePrint_Cuttack.aspx?year=" + txt_jcyear.Text.Trim() + "&jcno=" + txt_jcno.Text.Trim() + "&infno=" + txt_invno.Text.Trim());
            }
            else if (Session["Branch"].ToString() == "Berhampur")
            {
                Response.Redirect("Service_JobFinalInvoicePrint_Berhampur.aspx?year=" + txt_jcyear.Text.Trim() + "&jcno=" + txt_jcno.Text.Trim() + "&infno=" + txt_invno.Text.Trim());
            }
            else
            {
                Response.Redirect("Service_JobFinalInvoicePrint_Phulnakhara.aspx?year=" + txt_jcyear.Text.Trim() + "&jcno=" + txt_jcno.Text.Trim() + "&infno=" + txt_invno.Text.Trim());
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

            int sino = Convert.ToInt32(txt_jcno.Text);
            string branchname = Session["Branch"].ToString();
            var chkperforma = from c in db.AME_Service_JobcardFinalInvoice.Where(t => t.FI_JcNo == sino && t.Branch_Name == branchname && t.FI_Status == "CLOSE" && t.jc_year == txt_jcyear.Text) select c;
            if (Convert.ToInt32(chkperforma.Count()) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('This JobCard No Already Added Please Try Different..!!!');</script>", false);
                txt_jcno.Focus();
                txt_jcno.Text = "";
                return;
            }

            var checkstaus = from c in db.AME_Service_JobcardProformaInvoice.Where(t => t.PI_JcNo == sino && t.Branch_Name == branchname && t.PI_ProfomaIVStatus == true && t.jc_year == txt_jcyear.Text.Trim()) select c;
            if (Convert.ToInt32(checkstaus.Count()) > 0)
            {
                var quotationdetails = from c in db.AME_Service_JobCardEntry.Where(t => t.JC_No == sino && t.Branch_Name == branchname && t.JC_year == txt_jcyear.Text.Trim()) select c;

                string statecode = quotationdetails.First().Statecode;
                ViewState["statecode"] = statecode;
                fillpaymemtdetails();
                fillEdit();
                edit1();
                fillservicedetails();
                fillservicedetails1();
            }
            else
            {
                var outsideservice = from c in db.AME_Service_JobCardOutside_Service.Where(t => t.JC_No == sino && t.Branch_Name == branchname) select c;
                var quotationdetails = from c in db.AME_Service_JobCardEntry.Where(t => t.JC_No == sino && t.Branch_Name == branchname && t.JC_year == txt_jcyear.Text.Trim()) select c;
                if (Convert.ToInt32(quotationdetails.Count()) > 0)
                {
                    string statecode = quotationdetails.First().Statecode;
                    ViewState["statecode"] = statecode;
                    fillEdit();
                    edit1();
                    fillservicedetails();
                    fillservicedetails1();

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
                            if (num1 < 0.50)
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
                if (num1 < 0.50)
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
                if (num1 < 0.50)
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

                TextBox txtdicp = (TextBox)gr.FindControl("Labels55");

                ImageButton imgFcc = (ImageButton)gr.FindControl("ImageButton2");

                txtlabour.ReadOnly = true;
                txtdicp.ReadOnly = false;

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

                TextBox Labels55 = (TextBox)gr.FindControl("Labels55");
                decimal txt_dispr = Convert.ToDecimal(Labels55.Text);

                Label Labels56 = (Label)gr.FindControl("Labels56");
                decimal txt_disamu = Convert.ToDecimal(Labels56.Text);

                ImageButton imgFcc = (ImageButton)gr.FindControl("ImageButton1");


                AME_Service_JobCardServiceDetails mu = db.AME_Service_JobCardServiceDetails.First(t => t.JCS_Sino == slno && t.Jc_year == txt_jcyear.Text.Trim());
                mu.JCS_Amount = txt_labour;
                mu.JCS_Disper = txt_dispr;
                mu.JCS_DisAmu = txt_disamu;

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

                decimal f = Convert.ToDecimal(txt_ttotalAmount.Text) + Convert.ToDecimal(txt_LubricantttotalAmount.Text) + Convert.ToDecimal(txt_LabourChargesAftDisc.Text) + Convert.ToDecimal(txt_ServiceTaxAmt.Text);
                txt_BillAmount.Text = (SmitaClass.SignificantTruncate(f, 2)).ToString("0.00");
                double a1 = Convert.ToDouble(txt_BillAmount.Text);
                string[] str = a1.ToString().Split('.');
                if (str.Length != 1)
                {
                    double num1 = Convert.ToDouble("0." + str[1]);
                    double res;
                    if (num1 < 0.50)
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


    protected void Labels55_TextChanged(object sender, EventArgs e)
    {
        try
        {

            TextBox img = (TextBox)sender;
            string imgid = img.ToolTip;
            foreach (GridViewRow gr in GridView1.Rows)
            {
                TextBox imgFc = (TextBox)gr.FindControl("Labels55");
                string id = imgFc.ToolTip;
                if (imgid == id)
                {

                    Label Labels4 = (Label)gr.FindControl("Labels4");

                    Label Labels5 = (Label)gr.FindControl("Labels5");

                    Label Labels56 = (Label)gr.FindControl("Labels56");

                    TextBox txtlabour = (TextBox)gr.FindControl("Labels6");
                    TextBox txtdicp = (TextBox)gr.FindControl("Labels55");


                    decimal qty = 0, rate = 0, amu = 0, dic = 0, dic1 = 0, tot = 0;
                    qty = Convert.ToDecimal(Labels4.Text);

                    rate = Convert.ToDecimal(Labels5.Text);

                    amu = qty * rate;

                    dic = Convert.ToDecimal(txtdicp.Text);

                    dic1 = (amu * dic) / 100;

                    tot = amu - dic1;

                    Labels56.Text = dic1.ToString("0.00");
                    txtlabour.Text = tot.ToString("0.00");


                }
            }






        }
        catch (Exception ex)
        { }
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
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Rate Shouldnot Blank..!!!');</script>", false);
            txt_SRate.Focus();
            txt_SRate.Text = "";
            return;
        }
        if (txt_SRate.Text == "0.00")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Rate Shouldnot Blank..!!!');</script>", false);
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
        if (txt_disc.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Discount Per. Shouldnot Blank..!!!');</script>", false);
            txt_disc.Focus();
            txt_disc.Text = "";
            return;
        }
        AME_Service_JobCardServiceDetails asj = new AME_Service_JobCardServiceDetails();
        asj.Branch_Name = Session["Branch"].ToString();
        asj.Created_By = Session["Uid"].ToString();
        asj.Created_Date = SmitaClass.IndianTime();
        asj.JC_No = Convert.ToInt32(txt_jcno.Text);
        asj.Jc_year = txt_jcyear.Text.Trim();
        asj.JCS_Amount = Convert.ToDecimal(txt_SAmount.Text);
        asj.JCS_Description = txt_SDescription.Text;
        asj.JCS_Quantity = Convert.ToDecimal(txt_SQuantity.Text);
        asj.JCS_Rate = Convert.ToDecimal(txt_SRate.Text);
        asj.JCS_Servicecode = txt_SCode.Text;
        asj.JCS_Disper = Convert.ToDecimal(txt_disc.Text);
        asj.JCS_DisAmu = Convert.ToDecimal(txt_discamu.Text);
        asj.JCS_SpareType = drp_labtype.SelectedItem.Text;
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
        txt_disc.Text = "0";
        txt_discamu.Text = "0";
    }
    protected void txt_SCode_TextChanged(object sender, EventArgs e)
    {
        try
        {




            string[] param = { "@ServiceName" };
            string[] paramvalue = { txt_SCode.Text };

            DataTable dt6 = smitaDbAccess.SPReturnDataTable1("sp_getSErvideDetails1", param, paramvalue);


            txt_SCode.Text = dt6.Rows[0][1].ToString();
            txt_SDescription.Text = dt6.Rows[0][0].ToString();
            txt_SRate.Text = dt6.Rows[0][2].ToString();
            txt_SQuantity.Focus();



            //var v = from k in db.AME_Master_ServiceHead.ToList()
            //        where (k.Mh_ServiceCode.Equals(txt_SCode.Text))
            //        select new
            //        {
            //            k.Mh_ServiceHead,
            //            k.Mh_ServiceCode,
            //            k.Mh_ServiceRate
            //        };

            //txt_SCode.Text = v.First().Mh_ServiceCode;
            //txt_SDescription.Text = Convert.ToString(v.First().Mh_ServiceHead);
            //txt_SRate.Text = Convert.ToString(v.First().Mh_ServiceRate);
            //txt_SQuantity.Focus();
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
    protected void txt_SDescription_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string branch = Session["Branch"].ToString();


            string[] param = { "@Servicedecs", "@branch" };
            string[] paramvalue = { txt_SDescription.Text, branch };

            DataTable dt61 = smitaDbAccess.SPReturnDataTable1("sp_getSErvideDetailsbydesc", param, paramvalue);


            txt_SCode.Text = dt61.Rows[0][1].ToString();
            txt_SDescription.Text = dt61.Rows[0][0].ToString();
            txt_SRate.Text = dt61.Rows[0][2].ToString();
            txt_SQuantity.Focus();


            //var v = from k in db.AME_Master_ServiceHead.ToList()
            //        where (k.Mh_ServiceHead.Equals(txt_SDescription.Text) && k.Branch_Name == branch)
            //        select new
            //        {
            //            k.Mh_ServiceHead,
            //            k.Mh_ServiceCode,
            //            k.Mh_ServiceRate
            //        };

            //txt_SCode.Text = v.First().Mh_ServiceCode;
            //txt_SDescription.Text = Convert.ToString(v.First().Mh_ServiceHead);
            //txt_SRate.Text = Convert.ToString(v.First().Mh_ServiceRate);
            //txt_SQuantity.Focus();
        }
        catch
        {
            txt_SCode.Text = "";
            txt_SDescription.Text = "";
            txt_SRate.Text = "";
            txt_SQuantity.Focus();
        }
    }
    protected void txt_tdiscper_TextChanged(object sender, EventArgs e)
    {
        decimal discper = Convert.ToDecimal(txt_tdiscper.Text);
        string branch = Session["Branch"].ToString();
        int jc = Convert.ToInt32(txt_jcno.Text.Trim());
        var v = from c in db.AME_Service_JobcardSpareIssue.Where(t => t.JC_No == jc && t.Branch_Name == branch && t.Jc_year == txt_jcyear.Text.Trim()) select c;
        //var v = from c in db.AME_Service_JobcardSpareIssue
        //        join d in db.AME_Master_Item on c.Itm_code equals d.Itm_code 
        //        where c.JC_No ==jc && c.Branch_Name == branch && d.Itm_CategoryName != "Lubricants"
        //        select c;
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


                AME_Service_JobcardSpareIssue pd = db.AME_Service_JobcardSpareIssue.First(t => t.JC_No == jc && t.SE_Id == sl && t.Itm_code == itemcode && t.Jc_year == txt_jcyear.Text.Trim() && t.Branch_Name == branch && t.SE_Quantity > 0);

                pd.SE_Discount = discamnt;
                pd.SE_DiscountPer = discper;
                pd.SE_Taxamount = vatamnt;
                // pd.SE_Total = Math.Round(total);
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
            //decimal qty = 0, rate = 0, amu = 0, dic = 0, dic1 = 0, tot = 0;
            //qty = Convert.ToDecimal(txt_SQuantity.Text);

            //rate = Convert.ToDecimal(txt_SRate.Text);

            //amu = qty * rate;

            //dic = Convert.ToDecimal(txt_disc.Text);

            //dic1 = (amu * dic) / 100;

            //tot = amu - dic1;

            //txt_discamu.Text = dic1.ToString("0.00");
            //txt_SAmount.Text = tot.ToString("0.00");

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
        }
        catch (Exception ex)
        { }
    }

    protected void drp_labtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
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
        }
        catch (Exception ex)
        { }
    }
}