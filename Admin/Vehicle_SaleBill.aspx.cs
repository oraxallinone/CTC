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
                         quantity = e.Vse_Quantity,
                         amount = e.Vse_Amount,
                         invoicetype = c.Vs_InvType,
                         specification = f.Mv_Specification,
                         discount = e.Vse_DiscountAmount,
                         beforetax = e.Vse_GrossAmount,
                         vatamount = e.Vse_VatAmount,
                         billamount = e.Vse_Billamount,
                         hypth=c.Vs_Hyp
                     }).ToList();
            lbl_bnk.Text = v.First().hypth;
            lbl_partyname0.Text = v.First().partynm;
            lblengineno1.Text = v.First().engineno;
            lbldate.Text = v.First().billdate.ToString("dd/MM/yyyy");
            //lbldate1.Text = v.First().billdate.ToString("dd/MM/yyyy");
           
            lbladdress.Text = v.First().address;
            lblphoneno.Text = v.First().phoneno;
            lbltaxtype.Text = v.First().invoicetype;
            //lblpermanentads.Text = v.First().address1;
            //lblppin.Text = v.First().pinno1;
            //lblpcity.Text = v.First().city1;
            lblcity.Text = v.First().city;
            lbldiscount.Text = Convert.ToString(v.First().discount);
            lblmakersname.Text = v.First().makersname;
            lblchessisno0.Text = v.First().chessisno;
            lblbtax.Text = Convert.ToString(v.First().beforetax);
            lblvat.Text = Convert.ToString(v.First().vatamount);
            lblinvoicevalue.Text = Convert.ToString(v.First().billamount);
            lblinvoicevalue0.Text = Convert.ToString(v.First().billamount);
            lblinvoicetype.Text = v.First().invoicetype;
          
            if (Session["Branch"].ToString() == "Cuttack")
            {
                string date=DateTime.Now.ToString("dd/MM/yyyy");
                string date1=date.Substring(8,2);
                int after = Convert.ToInt32(date1);
                int after1 = after + 1;
                string final = date1 + "-" + after1.ToString();
                lbl_inv.Text = "RM" + "/" + "CTC" + "/" + Convert.ToString(Session["billno"]) + " " + " " + final;
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
                lblbillno.Text = "RM" + "/" + "BAM" + "/" + Convert.ToString(Session["billno"]) + " " + " " + final;
            }

            double grandtotal = Convert.ToDouble(v.First().billamount);
            double left = System.Math.Floor(grandtotal);
            double right = grandtotal - left;
            int firstValue = Convert.ToInt32(left);
            int secondValue = Convert.ToInt32(right);
            lblinwords.Text = "In Rupess: " + "&nbsp;&nbsp;" + SmitaClass.NumberToWords(firstValue) + " And " + SmitaClass.NumberToWords(secondValue) + " Paisa Only";

            GridView1.DataSource = v.ToList();
            GridView1.DataBind();
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