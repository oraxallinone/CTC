using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
public partial class Report_ProjectExpensesDetailsCodeDatewise : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    public string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            FillGrid();
          
        }
    }


    decimal tot1 = 0, tot2 = 0, tot3 = 0, tot4 = 0, tot5 = 0;
    public void FillGrid()
    {
        string Branch = Session["Branch"].ToString();
        string param = "@Branch";
        string paramvalue =  Branch;

        DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_Sparestock", param, paramvalue);
        if(dtr.Rows.Count>0)
        {
        GridView1.DataSource = dtr;
        GridView1.DataBind();

        foreach (GridViewRow gr in GridView1.Rows)
        {
            Label lbl_netqty = (Label)gr.FindControl("lblnetquantity");
            decimal qty = Convert.ToDecimal(lbl_netqty.Text);
            Label rate = (Label)gr.FindControl("lblrate1");
            decimal rate1 = Convert.ToDecimal(rate.Text);

            Label lblamount = (Label)gr.FindControl("lblamount");
            decimal lblamount1 = Convert.ToDecimal(lblamount.Text);
            Label lblrate2 = (Label)gr.FindControl("lblrate2");
            decimal rate2 = Convert.ToDecimal(lblrate2.Text);
            Label lblsaleamnt = (Label)gr.FindControl("lblsaleamnt");
            decimal lblsaleamnt1 = Convert.ToDecimal(lblsaleamnt.Text);
            

            Label lblgrandtotal = (Label)GridView1.FooterRow.FindControl("lblgrandtotal");


            lblamount1 = rate1 * qty;
            lblsaleamnt1 = rate2 * qty;
            lblamount.Text = lblamount1.ToString("0.00");
            lblsaleamnt.Text = lblsaleamnt1.ToString("0.00");

            //Label1.Text = Convert.ToString(SmitaClass.SignificantTruncate(tots1, 2));
        }

        foreach (GridViewRow gr in GridView1.Rows)
        {
            Label lblrate1 = (Label)gr.FindControl("lblrate1");
            Label lblrate2 = (Label)gr.FindControl("lblrate2");
            Label lblnetquantity = (Label)gr.FindControl("lblnetquantity");
            Label lblamount = (Label)gr.FindControl("lblamount");
            Label lblsaleamnt = (Label)gr.FindControl("lblsaleamnt");

            decimal purprice = Convert.ToDecimal(lblrate1.Text);
            decimal saleprice = Convert.ToDecimal(lblrate2.Text);
            decimal netqty = Convert.ToDecimal(lblnetquantity.Text);
            decimal amnt = Convert.ToDecimal(lblamount.Text);
            decimal samnt = Convert.ToDecimal(lblsaleamnt.Text);

            tot1 = tot1 + purprice;
            tot2 = tot2 + saleprice;
            tot3 = tot3 + netqty;
            tot4 = tot4 + amnt;
            tot5 = tot5 + samnt;

            Label lbl_fpurprice = (Label)GridView1.FooterRow.FindControl("lbl_fpurprice");
            lbl_fpurprice.Text = tot1.ToString("0.00");
            Label lbl_fsaleprice = (Label)GridView1.FooterRow.FindControl("lbl_fsaleprice");
            lbl_fsaleprice.Text = tot2.ToString("0.00");
            Label lbl_fnetqty = (Label)GridView1.FooterRow.FindControl("lbl_fnetqty");
            lbl_fnetqty.Text = tot3.ToString("0.00");
            Label lbl_ftotamnt = (Label)GridView1.FooterRow.FindControl("lbl_ftotamnt");
            lbl_ftotamnt.Text = tot4.ToString("0.00");
            Label lbl_flblsaleamnt = (Label)GridView1.FooterRow.FindControl("lbl_flblsaleamnt");
            lbl_flblsaleamnt.Text = tot5.ToString("0.00");
        }
        var zzz = from c in db.AME_Branch_Creation.ToList() where c.Branch_Name == Session["Branch"].ToString() select c;
        lbl_BranchAddress.Text = zzz.First().Branch_Address + ", " + zzz.First().Branch_PhoneNo;
        lbltin.Text = zzz.First().Branch_TIN;
       
        Panel1.Visible = true;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('There Is No Stock Are Available..!!');", true);
            Panel1.Visible = false;
           
            return;
        }

    }


    protected void btn_excel_Click(object sender, EventArgs e)
    {
        if (GridView1.Rows.Count <= 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('There Is No Data To Download..!!');", true);

            return;
        }
        else
        {

            string Branch = Session["Branch"].ToString();
            string attachment = "attachment; filename=" + "Stock(" + Branch + ")" + ".xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            HtmlForm frm = new HtmlForm();
            GridView1.Parent.Controls.Add(frm);
            frm.Attributes["runat"] = "server";
            frm.Controls.Add(GridView1);
            frm.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
    }
   
}
