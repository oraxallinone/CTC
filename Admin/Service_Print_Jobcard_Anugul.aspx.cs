using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;

public partial class Admin_Service_Print_Jobcard_Anugul : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["sino"] == null)
            {
                Response.Write("<script>alert('Your Session Time is Expired..!! Login to continue..!!')</script>");
                Response.Redirect("../SessionExpired.aspx");
            }
            fillbill();

        }
    }


    decimal total = 0;
    decimal amount = 0;
    decimal discountamount = 0;
    public void fillbill()
    {
        try
        {
            string qno = Session["sino"].ToString();
            string branchname = Session["Branch"].ToString();
            int sino = Convert.ToInt32(qno);
            var v = (from c in db.AME_Service_JobCardEntry

                     join d in db.AME_Master_VehicleModel on c.JC_Modelname equals d.Mv_Id
                     join e in db.AME_Master_Supervisor on c.JC_SupervisorName equals e.Ms_Id
                     join f in db.AME_Master_Technician on c.JCTechnisianName equals f.Mt_Id
                     join h in db.AME_Master_Customer on c.JC_Customername equals h.Mc_Id
                     join g in db.AME_Service_JobCardServiceDetails on new { c.JC_No, c.Branch_Name } equals new { g.JC_No, g.Branch_Name }
                     where c.JC_No == sino && c.Branch_Name == branchname && c.Ms_Status != "STOP" && c.JC_year == g.Jc_year && c.Ms_Status == "OPEN"
                     select new

                     {
                         c.JC_No,
                         c.JC_Chassisno,
                         c.JC_Date,
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

                         c.JC_SaleDate,
                         c.JC_ServiceType,
                         e.Ms_Name,
                         c.JC_Time,
                         f.Mt_Name,
                         h.Mc_Name,
                         g.JCS_Amount,
                         g.JCS_Description,
                         g.JCS_Quantity,
                         g.JCS_Rate,
                         g.JCS_Servicecode,
                         c.RepairType,
                         c.hrmeter,
                         c.CustomerComplain
                     }).Distinct().ToList();


            lbldate.Text = Convert.ToDateTime(v.First().JC_Date).ToString("dd/MM/yyyy");
            lbltime.Text = v.First().JC_Time;
            lbljobcardno.Text = Convert.ToString(v.First().JC_No);
            lblcname.Text = v.First().Mc_Name;
            lbladdress.Text = v.First().JC_Caddress;
            lblmno.Text = v.First().JC_MobileNo;
            lblmodel.Text = v.First().Mv_ModelName;
            lblchessisno.Text = v.First().JC_Chassisno;
            lblkilomtr.Text = v.First().JC_Kmcovered;
            lblservice.Text = v.First().JC_ServiceType;
            lblsupervisorname.Text = v.First().Ms_Name;
            lbl_repair.Text = v.First().RepairType;

            lbl_hr.Text = v.First().hrmeter;

            lbl_cuscomplain.Text = v.First().CustomerComplain;
            lbldateofsale.Text = Convert.ToDateTime(v.First().JC_SaleDate).ToString("dd/MM/yyyy");
            lblregno.Text = v.First().JC_Regno;
            lblengno.Text = v.First().JC_Engineno;
            lblkeyno.Text = v.First().JC_Keyno;
            lbldeliverydate.Text = Convert.ToDateTime(v.First().JC_Deliverydate).ToString("dd/MM/yyyy");
            GridView2.DataSource = v.ToList();
            GridView2.DataBind();
            foreach (GridViewRow gr in GridView2.Rows)
            {
                Label lblnetamount = (Label)gr.FindControl("Labels6");

                decimal netamount = Convert.ToDecimal(lblnetamount.Text);
                total = total + netamount;

                lblgtotal1.Text = Convert.ToString(total);
                double gtotal = Convert.ToDouble(lblgtotal1.Text);
                double left = System.Math.Floor(gtotal);
                double right = gtotal - left;
                int firstValue = Convert.ToInt32(left);
                int secondValue = Convert.ToInt32(right);
                lblInWords.Text = "In Rupess: " + "&nbsp;&nbsp;" + SmitaClass.NumberToWords(firstValue) + " And " + SmitaClass.NumberToWords(secondValue) + " Paisa Only";

            }

        }
        catch
        {

        }
    }
    
}