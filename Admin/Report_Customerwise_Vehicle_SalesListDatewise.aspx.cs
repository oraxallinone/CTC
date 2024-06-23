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
            txt_FromDate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
            txt_ToDate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
            //fillgrid();
            FillSupplier();
        }
    }


    private void FillSupplier()
    {
        var v = from c in db.AME_Master_Customer.ToList()
                where c.Mc_Status = true && c.Branch_Name == Session["Branch"].ToString()
                select new
                {
                    Su_Name = c.Mc_Name,
                    Su_Code = c.Mc_Id
                };
        ddl_customer.DataSource = v.ToList();
        ddl_customer.DataTextField = "Su_Name";
        ddl_customer.DataValueField = "Su_Code";
        ddl_customer.DataBind();
        ddl_customer.Items.Insert(0, "--Select One--");
    }

    public void fillgrid()
    {
        try
        {
            string Branch = Session["Branch"].ToString();
            DateTime fromDate = Convert.ToDateTime(txt_FromDate.Text, SmitaClass.dateformat());
            DateTime toDate = Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat());
            int cid = Convert.ToInt32(ddl_customer.SelectedValue);
            var query = (from c in db.AME_Vehicle_SaleEntryDetails
                         join f in db.AME_Vehicle_SaleEntry on new { Bno = c.Vs_Billno, Bname = c.Branch_Name } equals new { Bno = f.Vs_Billno, Bname = f.Branch_Name }
                         join d in db.AME_Master_Customer on c.Vq_PartyName equals d.Mc_Id
                         join e in db.AME_Master_VehicleModel on f.Mv_ModelName equals e.Mv_Id
                         where c.Vs_Billdate >= fromDate && c.Vs_Billdate <= toDate && c.Branch_Name == Branch && c.Vq_PartyName == cid
                         && c.Vq_Status == "SE"
                         select new
                         {
                             d.Mc_Name,
                             c.Vs_Billno,
                             c.Vs_Billdate,
                             d.Mc_Address,
                             d.Mc_Mobileno,
                             c.Vs_InvType,
                             c.Vs_TinNo,
                             c.Vs_Sino,
                             e.Mv_Rate,
                             f.Vp_Chassisno,
                             f.Vse_VatAmount,
                             e.Mv_ModelName,
                             f.Mv_VehicleType


                         }).Distinct().ToList();
            if (Convert.ToInt32(query.Count()) > 0)
            {
                GridView1.DataSource = query.ToList();
                GridView1.DataBind();

                var zzz = from c in db.AME_Branch_Creation.ToList() where c.Branch_Name == Session["Branch"].ToString() select c;
                lbl_BranchAddress.Text = zzz.First().Branch_Address + ", " + zzz.First().Branch_PhoneNo;
                lbltin.Text = zzz.First().Branch_TIN;
                lbl_from.Text = txt_FromDate.Text;
                lbl_to.Text = txt_ToDate.Text;
                Panel1.Visible = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('" + txt_FromDate.Text + "  To  " + txt_ToDate.Text + "  No Sales Are Entry..!!');", true);
                txt_FromDate.Focus();

                return;
            }
        }
        catch
        {

        }
    }

    protected void btn_Show_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_FromDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('From Date SHOULD NOT BE BLANK...!!');", true);
                txt_FromDate.Focus();
                return;
            }
            if (txt_ToDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('To Date SHOULD NOT BE BLANK...!!');", true);
                txt_ToDate.Focus();
                return;
            }

            if (Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat()) < Convert.ToDateTime(txt_FromDate.Text, SmitaClass.dateformat()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('To Date Must Be Greater Than From Date..!!');", true);
                txt_ToDate.Focus();
                return;
            }
            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy", "dd-MM-yyyy" };
            DateTime expectedDate;
            if (!DateTime.TryParseExact(txt_FromDate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                txt_FromDate.Focus();
                return;
            }
            if (!DateTime.TryParseExact(txt_ToDate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                txt_ToDate.Focus();
                return;
            }


            fillgrid();

        }
        catch
        {

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
            string attachment = "attachment; filename=" + lbl_InvoiceType.Text + "(" + Branch + ")" + "(" + txt_FromDate.Text + " " + "To" + " " + txt_ToDate.Text + ")" + ".xls";
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
