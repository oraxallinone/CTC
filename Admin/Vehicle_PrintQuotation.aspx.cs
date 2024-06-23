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
            if (Session["sino"] == null)
            {
                Response.Write("<script>alert('Your Session Time is Expired..!! Login to continue..!!')</script>");
                Response.Redirect("../SessionExpired.aspx");
            }
            fillbill();
            //lblsino.Text = Session["sino"].ToString();
            //lblsino.Text = Session["Branch"].ToString();
        }
    }


    decimal total = 0;
    decimal amount = 0;
    decimal discountamount = 0;
    public void fillbill()
    {
        string qno = Session["sino"].ToString();
        string branchname = Session["Branch"].ToString();
        int sino = Convert.ToInt32(qno);
        var v = (from c in db.AME_Vehicle_Quotation
                 join d in db.AME_Vehicle_QuotationList on c.Vq_Id equals d.Vq_Id
                 join e in db.AME_Master_VehicleModel on d.Mv_Id equals e.Mv_Id
                 where c.Vq_Id == sino && c.Branch_Name == branchname && d.Vq_Id == sino && d.Branch_Name == branchname
                 select new

                 {
                     c.Vq_sino,
                     c.Vq_PartyName,
                     c.Vq_Phone,
                     c.Vq_Address,
                     c.Vq_Id,
                     d.Mv_Id,
                     e.Mv_ModelName,
                     d.Vql_Rate,
                     d.Vql_Quantity,
                     d.Vql_netamount,
                     d.Vql_discount,
                     d.Vql_Amount,
                     c.Vq_Date,
                     d.Mv_VehicleType,
                     d.Vql_discountAmount,
                     c.Vq_refno,
                     e.Mv_Specification,
                 }).ToList();

        lbl_quotation.Text = v.First().Vq_sino.ToString();
        lblname.Text = v.First().Vq_PartyName;
        lbladress.Text = v.First().Vq_Address;
        lblphnno.Text = v.First().Vq_Phone;
        //lblsino.Text = Convert.ToString(v.First().Vq_Id);
        lblqprint.Text = v.First().Vq_refno;
        lblchalndate.Text = Convert.ToDateTime(v.First().Vq_Date).ToString("dd/MM/yyyy");
        lbldescription.Text = v.First().Mv_Specification;
        GridView1.DataSource = v.ToList();
        GridView1.DataBind();
        foreach (GridViewRow gr in GridView1.Rows)
        {
            Label lblnetamount = (Label)gr.FindControl("lblnetamount");
            Label lbltotalnetamount = (Label)GridView1.FooterRow.FindControl("lbltotalnetamount");
            decimal netamount = Convert.ToDecimal(lblnetamount.Text);
            total = total + netamount;
            lbltotalnetamount.Text = Convert.ToString(total);
            lblgtotal1.Text = Convert.ToString(total);

            Label lblamount = (Label)gr.FindControl("lblamount");
            decimal amount1 = Convert.ToDecimal(lblamount.Text);
            amount = amount + amount1;
            lbltotalamount1.Text = Convert.ToString(amount);

            Label lbldiscountamount = (Label)gr.FindControl("lbldiscountamount");
            decimal discount = Convert.ToDecimal(lbldiscountamount.Text);
            discountamount = discountamount + discount;
            lblsiscount1.Text = Convert.ToString(discountamount);

            double grandtotal = Convert.ToDouble(lbltotalnetamount.Text);
            double left = System.Math.Floor(grandtotal);
            double right = grandtotal - left;
            int firstValue = Convert.ToInt32(left);
            int secondValue = Convert.ToInt32(right);
            lblInWords.Text = "In Rupess: " + "&nbsp;&nbsp;" + SmitaClass.NumberToWords(firstValue) + " And " + SmitaClass.NumberToWords(secondValue) + " Paisa Only";

        }

    }

    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("Vehicle_QuotationDetailsDatewise.aspx");
    }
}