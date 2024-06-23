using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
using System.Data;

public partial class Admin_Vehicle_SalesInvoicePrint : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    public string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                string sino = Request.QueryString["id"];
                string VNo = Request.QueryString["No"];
                filldata(sino, VNo);
            }
            else
            {
                Server.Transfer("AccessDenied.aspx");
            }

        }
    }

    decimal tot1 = 0;
    public void filldata(string sino, string VcNO)
    {
        int id = Convert.ToInt32(sino);
        int VouNo = Convert.ToInt32(VcNO);

        var v = from c in db.AME_Spare_EstimateEntryBillDetails.ToList()
                join d in db.AME_Master_VehicleModel on c.Mv_Code equals d.Mv_Code
                where c.Sp_Id == id && c.Branch_Name == Session["Branch"].ToString()
                select new { c, d };
        lbl_EstimateNo.Text = Convert.ToString(v.First().c.Sp_EstimationNo);
        lbl_EstimateDate.Text = Convert.ToDateTime(v.First().c.Sp_EstimationDate).ToString("dd/MM/yyyy");
        lbl_ModelNo.Text = v.First().d.Mv_ModelName;
        lbl_Name.Text = v.First().c.Sp_Name;
        lbl_Address.Text = Convert.ToString(v.First().c.Sp_Address) + ", " + Convert.ToString(v.First().c.Sp_MobNo);
        lbl_RegdNo.Text = Convert.ToString(v.First().c.Sp_RegdNo);


        var details = (from c in db.AME_Spare_EstimateEntry.ToList()
                       where c.Sp_EstimationNo == VouNo && c.Branch_Name == Session["Branch"].ToString()
                       select c);

        GridView2.DataSource = details.ToList();
        GridView2.DataBind();
        foreach (GridViewRow gr in GridView2.Rows)
        {
            Label lblTotQty = (Label)gr.FindControl("Label11");
            decimal TotQty = Convert.ToDecimal(lblTotQty.Text);
            tot1 = tot1 + TotQty;

            Label LabelF1 = (Label)GridView2.FooterRow.FindControl("lbl_F2");
            Label LabelF2 = (Label)GridView2.FooterRow.FindControl("lbl_F3");
            Label LabelF3 = (Label)GridView2.FooterRow.FindControl("lbl_F4");
            Label LabelF4 = (Label)GridView2.FooterRow.FindControl("lbl_F5");
            Label LabelF5 = (Label)GridView2.FooterRow.FindControl("lbl_F6");

            LabelF1.Text = Convert.ToString(tot1);
            LabelF2.Text = Convert.ToString(v.First().c.Sp_GrossAmount);
            LabelF3.Text = Convert.ToString(v.First().c.Sp_Discount);
            LabelF4.Text = Convert.ToString(v.First().c.Sp_VatAmount);
            LabelF5.Text = Convert.ToString(v.First().c.Sp_TotalAmount);
        }

        var zzz = from c in db.AME_Branch_Creation.ToList() where c.Branch_Name == Session["Branch"].ToString() select c;
        lbl_BranchAddress.Text = zzz.First().Branch_Address + ", " + zzz.First().Branch_PhoneNo;
    }
}