using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Data;
public partial class admin_StockDetails : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    public string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGrid();
        }
    }

    private void FillGrid()
    {
        string branchname = Session["Branch"].ToString();
         string param = "@Branch";
            string paramvalue = branchname;
            DataSet ds1 = smitaDbAccess.SPReturnDataSet("Sp_vehiclenetstochreport", param, paramvalue);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds1;
                GridView1.DataBind();

            }
       
        var zzz = from c in db.AME_Branch_Creation.ToList() where c.Branch_Name == Session["Branch"].ToString() select c;
        lbl_BranchAddress.Text = zzz.First().Branch_Address + ", " + zzz.First().Branch_PhoneNo;
        lbltin.Text = zzz.First().Branch_TIN;
       
        Panel1.Visible = true;
        foreach (GridViewRow gr in GridView1.Rows)
        {
            Label Label31 = (Label)gr.FindControl("Label31");
            string rankno = Label31.ToolTip;

            Label Label30 = (Label)gr.FindControl("Label30");
            Label lblreno = (Label)gr.FindControl("lblreno");
            Label lblSlNo = (Label)gr.FindControl("lblSlNo");
           

            if (rankno != "1")
            {
                Label31.Visible = false;
                Label30.Visible = false;
                
            }
            else
            {
                Label31.Visible = true;
                Label30.Visible = true;
               

            }
        }
    }
    protected void btnexcel_Click(object sender, EventArgs e)
    {
        if (GridView1.Rows.Count <= 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('There Is No Data To Download..!!');", true);

            return;
        }
        else
        {

            string Branch = Session["Branch"].ToString();
            string attachment = "attachment; filename=" + lbl_InvoiceType.Text + "(" + Branch + ")" + ".xls";
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