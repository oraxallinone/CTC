using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
public partial class Admin_Form21 : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Session["billno"] == null)
            {
                Response.Write("<script>alert('Your Session Time is Expired..!! Login to continue..!!')</script>");
                Response.Redirect("../SessionExpired.aspx");
              
            }
            billno();
        }
    }

    public void billno()
    {
        string billno = Convert.ToString(Session["billno"]);
        string branchname = Session["Branch"].ToString();
        string sino = Convert.ToString(billno);
        var v = (from c in db.AME_Vehicle_SaleEntryDetails
                 join d in db.AME_Master_Customer on c.Vq_PartyName equals d.Mc_Id
                 join e in db.AME_Vehicle_SaleEntry on c.Vs_Billno equals e.Vs_Billno
                 join f in db.AME_Master_VehicleModel on e.Mv_ModelName equals f.Mv_Id
                 where c.Vs_Billno == sino && c.Branch_Name == branchname
                 select new
                 {
                   partynm=d.Mc_Name,
                   billdate=c.Vs_Billdate,
                   modelname=f.Mv_ModelName,
                   address=d.Mc_Address,
                   city=d.Mc_City,
                   phoneno=c.Vq_Phone,
                   pinno=d.Mc_Pinno,
                   address1=d.Mc_PAddress,
                   city1=d.Mc_PCity,
                   pinno1=d.Mc_PPinno,
                   frontAxel=f.Mv_FrontAxel,
                   rearexcel=f.Mv_RearAxel,
                   otheraxcel=f.Mv_OtherAxel,
                   tendemaxcel=f.Mv_TandemAxel,
                   hyp=c.Vs_Hyp,
                   cylinder=e.Mv_Cylinders
                   
                 }).ToList();
        lbl_partyname.Text = v.First().partynm;
        lbl_partyname0.Text = v.First().partynm;
        lbl_billdate.Text=v.First().billdate.ToString("dd/MM/yyyy");
        lbl_modelname.Text = v.First().modelname;
        lbladdress.Text = v.First().address;
        lblphoneno.Text = v.First().phoneno;
        lblfrontaxel.Text = v.First().frontAxel;
        lblrareexcel.Text = v.First().rearexcel;
        lblanyotherexcel.Text = v.First().otheraxcel;
        lbltendemexcel.Text = v.First().tendemaxcel;
        lblpermanentads.Text = v.First().address1;
        lblppin.Text = v.First().pinno1;
        lblpinno.Text = v.First().pinno;
        lblpcity.Text = v.First().city1;
        lblcity.Text = v.First().city;
        lblhyp.Text = v.First().hyp;
        lblnocylinders.Text = v.First().cylinder;
        var details = from c in db.AME_Vehicle_SaleEntry.Where(t => t.Vs_Billno == sino && t.Branch_Name == branchname) select c;
        lbltcno.Text = details.First().MV_TCNO;
        lblvehicletype.Text = details.First().Mv_VehicleType;
        lblmakersname.Text = details.First().Mv_Makers;
        lblchessisno.Text = details.First().Vp_Chassisno;
        lblengineno.Text = details.First().Vp_Engineno;
        lblhorsepwr.Text = details.First().Mv_HPower;
        lblfuelused.Text = details.First().Mv_FuelUsed;
        lblgrossvehicleweight.Text = details.First().Mv_GrossWeight;
        lblmfdate.Text = details.First().Vse_MfDate.ToString("dd/MM/yyyy");
        lblseatcapacity.Text = details.First().Mv_SeatCapacity;
        lblunldnweight.Text = details.First().Mv_UnladedWeight;
        lblcolour.Text = details.First().Vp_Color;
        lbltypeofbody.Text = details.First().Mv_BodyType;

        if (Session["Branch"].ToString() == "Cuttack")
        {
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            string date1 = date.Substring(8, 2);
            int after = Convert.ToInt32(date1);
            int after1 = after + 1;
            string final = date1 + "-" + after1.ToString();
            lblbillno.Text = "RM" + "/" + "CTC" + "/" + Convert.ToString(Session["billno"]) + " " + " " + final;
        }
        else if (Session["Branch"].ToString() == "Paradeep")
        {
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            string date1 = date.Substring(8, 2);
            int after = Convert.ToInt32(date1);
            int after1 = after + 1;
            string final = date1 + "-" + after1.ToString();
            lblbillno.Text = "RM" + "/" + "PAR" + "/" + Convert.ToString(Session["billno"]) + " " + " " + final;
        }
        else if (Session["Branch"].ToString() == "Phulnakhara")
        {
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            string date1 = date.Substring(8, 2);
            int after = Convert.ToInt32(date1);
            int after1 = after + 1;
            string final = date1 + "-" + after1.ToString();
            lblbillno.Text = "RM" + "/" + "PHU" + "/" + Convert.ToString(Session["billno"]) + " " + " " + final;
        }
        else
        {
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            string date1 = date.Substring(8, 2);
            int after = Convert.ToInt32(date1);
            int after1 = after + 1;
            string final = date1 + "-" + after1.ToString();
            lblbillno.Text = "RM" + "/" + "BAM" + "/" + Convert.ToString(Session["billno"]) + " " + " " + final;
        }

    }

    protected void btnback_Click(object sender, EventArgs e)
    {
        //int billno=Convert.ToInt32(lblbillno.Text);
        string billno = lblbillno.Text;
        Response.Redirect("Vehicle_SaleDetails.aspx"+"?billno1="+billno);
      
    }
}