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
           FillGrid();
        }
    }
    [System.Web.Services.WebMethod]
    public static string[] GetPartNo(string prefixText, int count)
    {
        string branch = HttpContext.Current.Session["Branch"].ToString();
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Master_Item.Where(n => n.Itm_Partno.Contains(prefixText) && n.Branch_Name == branch).OrderBy(n => n.Itm_Partno).Select(n => n.Itm_Partno).Distinct().Take(count).ToArray();
    }

    [System.Web.Services.WebMethod]
    public static string[] Getfyear(string prefixText, int count)
    {

        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_FinacialYear.Where(n => n.finacialyear.Contains(prefixText)).OrderBy(n => n.finacialyear).Select(n => n.finacialyear).Distinct().Take(count).ToArray();
    }

    public void FillGrid()
    {
        string Branch = Session["Branch"].ToString();
       // string year = txt_year.Text.Trim();
        string param = "@Fromdate,@Todate,@Branch";
        string paramvalue = Convert.ToDateTime(txt_FromDate.Text, SmitaClass.dateformat()).ToString("yyyy-MM-dd HH:mm:ss") + " , " + Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat()).ToString("yyyy-MM-dd HH:mm:ss") + "," + Branch ;
        tr_frm.Visible = true;
        DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_Sparestocktransfer", param, paramvalue);
        if(dtr.Rows.Count>0)
        {
        GridView1.DataSource = dtr;
        GridView1.DataBind();
        decimal tot12 = 0;
        foreach (GridViewRow gr in GridView1.Rows)
        {
            Label lblttl = (Label)gr.FindControl("lblttl");
            if (lblttl.Text != "")
            {
                decimal ttl = Convert.ToDecimal(lblttl.Text);
                tot12 = tot12 + ttl;

                Label flblttl = (Label)GridView1.FooterRow.FindControl("flblttl");
                flblttl.Text = tot12.ToString("0.00");
            }
           
        }
        var zzz = from c in db.AME_Branch_Creation.ToList() where c.Branch_Name == Session["Branch"].ToString() select c;
        lbl_BranchAddress.Text = zzz.First().Branch_Address + ", " + zzz.First().Branch_PhoneNo;
        lbltin.Text = zzz.First().Branch_TIN;
        lbl_from.Text = txt_FromDate.Text;
        lbl_to.Text = txt_ToDate.Text;
        Panel1.Visible = true;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('"+txt_FromDate.Text+"  To  "+txt_ToDate.Text+"  No Data Are Found..!!');", true);
            Panel1.Visible = false;
            txt_FromDate.Focus();
            return;
        }

    }
    protected void btn_Show_Click(object sender, EventArgs e)
    {
        try
        {

            //if (txt_year.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Year SHOULD NOT BE BLANK...!!');", true);
            //    txt_year.Focus();
            //    return;
            //}
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
            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy","dd-MM-yyyy" };
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


            FillGrid();

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
    protected void btn_view_Click(object sender, EventArgs e)
    {
        if (txt_year.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Year SHOULD NOT BE BLANK...!!');", true);
            txt_year.Focus();
            return;
        }

        string Branch = Session["Branch"].ToString();
        string year = txt_year.Text.Trim();
        string param = "@Voucher,@Branch,@year";
        string paramvalue = txt_voucher.Text.Trim() + "," + Branch+ "," + year;
        tr_frm.Visible = false;
        DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_SparestocktransferVoucher", param, paramvalue);
        if (dtr.Rows.Count > 0)
        {
            GridView1.DataSource = dtr;
            GridView1.DataBind();
            Panel1.Visible = true;
            decimal tot1 = 0;
            foreach (GridViewRow gr in GridView1.Rows)
            {
                Label lblttl = (Label)gr.FindControl("lblttl");
                decimal ttl = Convert.ToDecimal(lblttl.Text);
                tot1 = tot1 + ttl;

                Label flblttl = (Label)GridView1.FooterRow.FindControl("flblttl");
                flblttl.Text = tot1.ToString("0.00");
            }
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string Branch = Session["Branch"].ToString();
        string param = "@partno,@Branch";
        string paramvalue = TextBox1.Text.Trim() + "," + Branch;
        tr_frm.Visible = false;
        DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_Sparestocktransferpartno", param, paramvalue);
        if (dtr.Rows.Count > 0)
        {
            GridView1.DataSource = dtr;
            GridView1.DataBind();
            Panel1.Visible = true;
            decimal tot1 = 0;
            foreach (GridViewRow gr in GridView1.Rows)
            {
                Label lblttl = (Label)gr.FindControl("lblttl");
                decimal ttl = Convert.ToDecimal(lblttl.Text);
                tot1 = tot1 + ttl;

                Label flblttl = (Label)GridView1.FooterRow.FindControl("flblttl");
                flblttl.Text = tot1.ToString("0.00");
            }
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
    }
}
