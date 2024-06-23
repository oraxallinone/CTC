using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
public partial class Admin_Service_JobFinalInvoicePrint2_Cuttack : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["PID"] == null && Session["JCN"] == null)
            {
                Response.Write("<script>alert('Your Session Time is Expired..!! Login to continue..!!')</script>");
                Response.Redirect("../SessionExpired.aspx");
            }
            fillpaymemtdetails();
            fillEdit();
            fillservice();
            fillservicedetails();
            string id = Session["PID"].ToString();
            lbl_gBillDate.Text = lbldate.Text;
            string year = Request.QueryString["year"].ToString();


        }
    }


    public void fillpaymemtdetails()
    {
        try
        {
            string year = Request.QueryString["year"].ToString();


            string id = Session["PID"].ToString();
            int id1 = Convert.ToInt32(id);
            string jcno = Session["JCN"].ToString();
            int jcno1 = Convert.ToInt32(jcno);
            string branch = Session["Branch"].ToString();
            var details = from c in db.AME_Service_JobcardFinalPaymentDetails.Where(t => t.FI_JcNo == jcno1 && t.FIP_Sino == id1 && t.Branch_Name == branch && t.jc_year == year) select c;
            var pi = from c in db.AME_Service_JobcardFinalInvoice.Where(t => t.FI_JcNo == jcno1 && t.FI_Sino == id1 && t.Branch_Name == branch && t.jc_year == year) select c;
            lblbillamount.Text = Convert.ToString(details.First().FIP_BillAmount);
            //lblothercharg.Text = Convert.ToString(details.First().FIP_OtherCharges);
            //lbloutsideservice.Text = Convert.ToString(details.First().FIP_OutsideService);
            //lblhreduamount.Text = Convert.ToString(details.First().FIP_SrHrEduCessAmount);
            //lbleducssamount.Text = Convert.ToString(details.First().FIP_EduCess);

            lblafdamount.Text = Convert.ToString(details.First().FIP_LabourchargeAfterdis);
            lblsevtaxamnt.Text = Convert.ToString(details.First().FIP_ServiceTax);

            lblservicetaxamount.Text = (Convert.ToDecimal(lblafdamount.Text) + Convert.ToDecimal(lblsevtaxamnt.Text)).ToString("0.00");
            lbldpercent.Text = Convert.ToString(details.First().FIP_LabouechargeDiscountpercent);
            lblldiscamount.Text = Convert.ToString(details.First().FIP_LabourchargeDiscountAmount);
            lbllabourcharges.Text = Convert.ToString(details.First().FIP_Labourcharges);

            lbl_Gspareamount.Text = Convert.ToString(details.First().Se_GTotalOfSpare);

            if (details.First().PIP_LubGross != null)
            {
                lbl_lubgrossamount.Text = Convert.ToString(details.First().PIP_LubGross);
            }
            else
            {
                lbl_lubgrossamount.Text = "0.00";
            }
            if (details.First().PIP_LubVat != null)
            {
                lbl_lubvatamount.Text = Convert.ToString(details.First().PIP_LubVat);
            }
            else
            {
                lbl_lubvatamount.Text = "0.00";
            }
            if (details.First().PIP_LubTotal != null)
            {
                lbl_lubGspareamount.Text = Convert.ToString(details.First().PIP_LubTotal);
            }
            else
            {
                lbl_lubGspareamount.Text = "0.00";
            }
            if (details.First().PIP_LubTotallubricant != null)
            {
                lbl_lubttl.Text = Convert.ToString(details.First().PIP_LubTotallubricant);
            }
            else
            {
                lbl_lubttl.Text = "0.00";
            }

            //lbl_tdiscamount.Text = Convert.ToString(details.First().Se_TotalDiscountSpare);
            lbl_tdiscper.Text = Convert.ToString(details.First().Se_TotalDiscountPerSpare);

            //lblspareamount.Text = Convert.ToString(details.First().PIP_TotalSpareAmount);
            lblvatamount.Text = Convert.ToString(details.First().FIP_VatAmount);
            lbltotal.Text = Convert.ToString(details.First().FIP_Total);
            lbldiscountamount.Text = Convert.ToString(details.First().FIP_DiscountAmount);
            //lblsdiscountpercent.Text = Convert.ToString(details.First().FIP_Discountpercent);
            lblgrossamount.Text = Convert.ToString(details.First().FIP_Grossamount);
            lbltinno.Text = "21041300795";
            lblbillno.Text = Convert.ToString(pi.First().FI_InvoiceNo);
            if (pi.First().FI_PaymentType == "Cash")
            {
                lbl_cas.Text = "Cash";

            }
            else
            {
                lbl_cas.Text = "CREDIT";
            }
            //-------Gate Pass---------------//

            lbl_gBillNo.Text = Convert.ToString(pi.First().FI_InvoiceNo);
            lbl_gBillAmount.Text = Convert.ToString(details.First().FIP_BillAmount);

            lblfinalinvoice.Text = pi.First().FI_TaxType;
            lbltime.Text = Convert.ToDateTime(pi.First().Created_Date).ToString("hh:mm:ss tt");
            lbldate.Text = Convert.ToDateTime(pi.First().FI_InvoiceDate).ToString("dd/MM/yyyy");


            double grndtotal = Convert.ToDouble(lblbillamount.Text);
            double left = System.Math.Floor(grndtotal);
            double right = grndtotal - left;
            int firstValue = Convert.ToInt32(left);
            int secondValue = Convert.ToInt32(right);
            lblInWords.Text = "In Rupess: " + "&nbsp;&nbsp;" + SmitaClass.NumberToWords(firstValue) + " And " + SmitaClass.NumberToWords(secondValue) + " Paisa Only";
        }
        catch
        {

        }
    }

    decimal tot1 = 0, tot2 = 0, tot3 = 0, tot4 = 0;
    public void fillEdit()
    {
        try
        {
            string year = Request.QueryString["year"].ToString();


            string branchname = Session["Branch"].ToString();
            string sno = Session["JCN"].ToString();
            int sino = Convert.ToInt32(sno);
            var v = (from c in db.AME_Service_JobcardSpareIssue
                     //join e in db.AME_Service_JobCardEntry on c.JC_No equals e.JC_No
                     //join d in db.AME_Master_VehicleModel on e.JC_Modelname equals d.Mv_Id

                     //join f in db.AME_Master_Technician on e.JCTechnisianName equals f.Mt_Id
                     //join h in db.AME_Master_Customer on e.JC_Customername equals h.Mc_Id
                     join g in db.AME_Master_Item on c.Itm_code equals g.Itm_code
                     where c.JC_No == sino && c.Branch_Name == branchname && c.SE_Quantity > 0 && c.Jc_year == year
                     select new

                     {


                         //c.JC_No,
                         //c.SE_Sino,
                         //c.SE_Date,
                         //e.JC_Date,
                         //e.JC_Regno,
                         //e.JC_Engineno,
                         //c.SE_Sparetype,
                         //h.Mc_Name,
                         //e.JC_Caddress,
                         //e.JC_Chassisno,
                         //e.JCTechnisianName,
                         c.Itm_code,
                         c.SE_Amount,
                         c.SE_DiscountPer,
                         c.SE_Discount,
                         c.SE_Quantity,
                         c.SE_Rate,
                         c.SE_Taxamount,
                         c.SE_Total,
                         c.SE_Vat,
                         g.Itm_PartDescrption,
                         g.Itm_Partno
                         //d.Mv_ModelName,
                         //c.SE_Id,

                     }).ToList();



            //grd_spare.DataSource = v.Distinct().ToList();
            grd_spare.DataSource = v.ToList();
            grd_spare.DataBind();

        }
        catch
        {

        }

    }
    public void fillservice()
    {
        try
        {
            string year = Request.QueryString["year"].ToString();


            string branchname = Session["Branch"].ToString();
            string sno = Session["JCN"].ToString();
            int sino = Convert.ToInt32(sno);
            var v = (from c in db.AME_Service_JobCardEntry
                     join g in db.AME_Service_JobCardServiceDetails on new { c.JC_No, c.Branch_Name } equals new { g.JC_No, g.Branch_Name }
                     where c.JC_No == sino && c.Branch_Name == branchname && c.JC_year == year && g.Jc_year == year && g.Branch_Name == branchname
                     select new

                     {
                         c.JC_No,
                         c.JC_Caddress,
                         c.JC_Deliverydate,
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
                         g.JCS_Amount,
                         g.JCS_Description,
                         g.JCS_Quantity,
                         g.JCS_Rate,
                         g.JCS_Servicecode,
                         g.JCS_Sino,
                         c.JC_Date,
                         c.JC_Time,

                         c.JC_Chassisno
                     }).Distinct().ToList();

            if (Convert.ToInt32(v.Count()) > 0)
            {
                grd_service.DataSource = v.ToList();
                grd_service.DataBind();
            }


        }
        catch
        {

        }
    }
    public void fillservicedetails()
    {
        try
        {
            string year = Request.QueryString["year"].ToString();


            string branchname = Session["Branch"].ToString();
            string sno = Session["JCN"].ToString();
            int sino = Convert.ToInt32(sno);
            var v = (from c in db.AME_Service_JobCardEntry

                     join d in db.AME_Master_VehicleModel on c.JC_Modelname equals d.Mv_Id
                     join e in db.AME_Master_Supervisor on c.JC_SupervisorName equals e.Ms_Id
                     join f in db.AME_Master_Technician on c.JCTechnisianName equals f.Mt_Id
                     join h in db.AME_Master_Customer on c.JC_Customername equals h.Mc_Id
                     where c.JC_No == sino && c.Branch_Name == branchname && c.JC_year == year
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
                         c.JC_Date,
                         c.JC_Time,

                         c.JC_Chassisno
                     }).Distinct().ToList();


            lbljcardno.Text = Convert.ToString(v.First().JC_No);
            lblpartyname.Text = Convert.ToString(v.First().Mc_Name);
            lbladdress.Text = v.First().JC_Caddress;
            lblphnno.Text = v.First().JC_MobileNo;
            lblmodel.Text = v.First().Mv_ModelName;
            lblregno.Text = v.First().JC_Regno;
            lblchessisno.Text = v.First().JC_Chassisno;
            lblengno.Text = v.First().JC_Engineno;
            lbl_servicetype.Text = v.First().JC_ServiceType;

            lbldateofsale.Text = Convert.ToDateTime(v.First().JC_SaleDate).ToString("dd/MM/yyyy");
            lblkilomtr.Text = v.First().JC_Kmcovered;
            //----------Gate Pass--------//
            // lbl_gBillDate.Text = Convert.ToDateTime(v.First().JC_Deliverydate).ToString("dd/MM/yyyy");
            lbl_gname.Text = Convert.ToString(v.First().Mc_Name);
            lbl_gchasis1.Text = v.First().JC_Chassisno;
            lbl_gregno.Text = v.First().JC_Regno;
            lbl_gjcno.Text = v.First().JC_No.ToString();
        }
        catch
        {

        }
    }
}