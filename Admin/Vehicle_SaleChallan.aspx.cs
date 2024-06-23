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
        try
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
                         partynm = d.Mc_Name,
                         billdate = c.Vs_Billdate,
                         modelname = f.Mv_ModelName,
                         address = d.Mc_Address,
                         city = d.Mc_City,
                         phoneno = c.Vq_Phone,
                         pinno = d.Mc_Pinno,
                         address1 = d.Mc_PAddress,
                         city1 = d.Mc_PCity,
                         pinno1 = d.Mc_PPinno,
                         engineno = e.Vp_Engineno,
                         makersname = e.Mv_Makers,
                         toolkit = e.Vse_Toolkit,
                         stephini = e.Vse_Stephny,
                         form21 = e.Vse_Form21,
                         chessisno = e.Vp_Chassisno,
                         ownersmannual = e.Vse_OwnersManual,
                         btrymakeno = e.Vse_BatteryDetails,
                         btrywarrenty = e.Vse_Warrenty,
                         tyremake = e.Vse_TyreMake,
                         fscbook = e.Vse_FscBook,
                         hypth=c.Vs_Hyp
                     }).ToList();
            lbl_bnk.Text = v.First().hypth;
            lbl_partyname0.Text = v.First().partynm;
            lbl_partyname1.Text = v.First().partynm;
            lbldate.Text = v.First().billdate.ToString("dd/MM/yyyy");
            lbldate0.Text = v.First().billdate.ToString("dd/MM/yyyy");
            lblmodel.Text = v.First().modelname;
            lbladdress.Text = v.First().address;
            lblphoneno.Text = v.First().phoneno;
            lbltoolkit.Text = v.First().toolkit;
            //lblpermanentads.Text = v.First().address1;
            lblpinno.Text = v.First().pinno;
            //lblpcity.Text = v.First().city1;
            lblcity.Text = v.First().city;
            lblstephini.Text = v.First().stephini;
            lblform21.Text = v.First().form21;
            lblengineno.Text = v.First().engineno;
            lblengineno0.Text = v.First().engineno;
            lblmakersname.Text = v.First().makersname;
            lblchessisno.Text = v.First().chessisno;
            lblownersmannual.Text = v.First().ownersmannual;
            lblbmno.Text = v.First().btrymakeno;
            lblbwc.Text = v.First().btrywarrenty;
            lblmtype.Text = v.First().tyremake;
            lblfscbook.Text = v.First().fscbook;
            lblmodel2.Text = v.First().modelname;
            lblchessisno2.Text = v.First().chessisno;
            lblbmno0.Text = v.First().btrymakeno;
            lblmtype0.Text = v.First().tyremake;
            //lblbillno.Text = Convert.ToString(Session["billno"]);
            if (Session["Branch"].ToString() == "Cuttack")
            {
                string date = DateTime.Now.ToString("dd/MM/yyyy");
                string date1 = date.Substring(8, 2);
                int after = Convert.ToInt32(date1);
                int after1 = after + 1;
                string final = date1 + "-" + after1.ToString();
                lbl_inv.Text = "RM" + "/" + "CTC" + "/" + Convert.ToString(Session["billno"]) + " " + " " + final;
                lblbillno0.Text = "RM" + "/" + "CTC" + "/" + Convert.ToString(Session["billno"]) + " " + " " + final;
                lblbillno.Text = "RM" + "/" + "CTC" + "/" + Convert.ToString(Session["billno"]) + " " + " " + final;
            }
            else if (Session["Branch"].ToString() == "Paradeep")
            {
                string date = DateTime.Now.ToString("dd/MM/yyyy");
                string date1 = date.Substring(8, 2);
                int after = Convert.ToInt32(date1);
                int after1 = after + 1;
                string final = date1 + "-" + after1.ToString();
                lbl_inv.Text = "RM" + "/" + "PRA" + "/" + Convert.ToString(Session["billno"]) + " " + " " + final;
                lblbillno0.Text = "RM" + "/" + "PRA" + "/" + Convert.ToString(Session["billno"]) + " " + " " + final;
                lblbillno.Text = "RM" + "/" + "PRA" + "/" + Convert.ToString(Session["billno"]) + " " + " " + final;
            }
            else if (Session["Branch"].ToString() == "Phulnakhara")
            {
                string date = DateTime.Now.ToString("dd/MM/yyyy");
                string date1 = date.Substring(8, 2);
                int after = Convert.ToInt32(date1);
                int after1 = after + 1;
                string final = date1 + "-" + after1.ToString();
                lbl_inv.Text = "RM" + "/" + "PHU" + "/" + Convert.ToString(Session["billno"]) + " " + " " + final;
                lblbillno0.Text = "RM" + "/" + "PHU" + "/" + Convert.ToString(Session["billno"]) + " " + " " + final;
                lblbillno.Text = "RM" + "/" + "PHU" + "/" + Convert.ToString(Session["billno"]) + " " + " " + final;
            }
            else
            {
                string date = DateTime.Now.ToString("dd/MM/yyyy");
                string date1 = date.Substring(8, 2);
                int after = Convert.ToInt32(date1);
                int after1 = after + 1;
                string final = date1 + "-" + after1.ToString();
                lbl_inv.Text = "RM" + "/" + "BAM" + "/" + Convert.ToString(Session["billno"]) + " " + " " + final;
                lblbillno0.Text = "RM" + "/" + "BAM" + "/" + Convert.ToString(Session["billno"]) + " " + " " + final;
                lblbillno.Text = "RM" + "/" + "BAM" + "/" + Convert.ToString(Session["billno"]) + " " + " " + final;
            }
        }
        catch
        {

        }
    }

    protected void btnback_Click(object sender, EventArgs e)
    {
        //int billno=Convert.ToInt32(lblbillno.Text);
        string billno = lblbillno.Text;
        Response.Redirect("Vehicle_SaleDetails.aspx"+"?billno1="+billno);
      
    }
}