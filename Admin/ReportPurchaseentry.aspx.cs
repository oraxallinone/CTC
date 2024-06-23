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
public partial class Admin_ReportPurchaseentry : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    public string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //txt_FromDate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
            //txt_ToDate.Text = SmitaClass.IndianTime().AddDays(1).ToString("dd/MM/yyyy");
            //FillGrid();
        }
    }

    [System.Web.Services.WebMethod]
    public static string[] GetInvoice(string prefixText, int count)
    {

        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Master_Supplier.Where(n => n.Ms_Name.Contains(prefixText)).OrderBy(n => n.Ms_Name).Select(n => n.Ms_Name).Distinct().Take(count).ToArray();
    }
    public void FillGrid()
    {

        string Branch = Session["Branch"].ToString();
        string param = "@Fromdate,@Todate,@Branch";
        string paramvalue = Convert.ToDateTime(txt_FromDate.Text, SmitaClass.dateformat()).ToString("dd/MM/yyyy") + " , " + Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat()).ToString("dd/MM/yyyy") + "," + Branch;

        DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_Spare_PurchaseListvatwise", param, paramvalue);
        if (dtr.Rows.Count > 0)
        {
            GridView1.DataSource = dtr;
            GridView1.DataBind();
            foreach (GridViewRow gr in GridView1.Rows)
            {
                try
                {
                    ImageButton edit = (ImageButton)gr.FindControl("imgbtnedit");
                    ImageButton del = (ImageButton)gr.FindControl("imgbtndelete");

                    if (Session["saletype"] != null)
                    {
                        edit.Visible = false;
                        del.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    //  string str = ex.ToString();
                    //  throw;
                }

            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('" + txt_FromDate.Text + "  To  " + txt_ToDate.Text + "  No DATA fOUND..!!');", true);
            txt_FromDate.Focus();
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
            string attachment = "attachment; filename=" + "PurchaseEntryList" + "(" + Branch + ")" + ".xls";
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

    protected void  btn_Show_Click(object sender, EventArgs e)
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
            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy" };
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


    protected void btn_Show_Click1(object sender, EventArgs e)
    {

        try
        {
            if (txt_supp.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert(' SUPPLIER NAME SHOULD NOT BE BLANK...!!');", true);
                txt_supp.Focus();
                return;
            }
          

            FillGrid1();

        }
        catch
        {

        }

    }

    public void FillGrid1()
    {

        string Branch = Session["Branch"].ToString();
        string param = "@supp,@Branch";
        string paramvalue = txt_supp.Text.Trim()  + "," + Branch;

        DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_Spare_PurchaseListvatwise1", param, paramvalue);
        if (dtr.Rows.Count > 0)
        {
            GridView1.DataSource = dtr;
            GridView1.DataBind();
            foreach (GridViewRow gr in GridView1.Rows)
            {
                try
                {
                    ImageButton edit = (ImageButton)gr.FindControl("imgbtnedit");
                    ImageButton del = (ImageButton)gr.FindControl("imgbtndelete");

                    if (Session["saletype"] != null)
                    {
                        edit.Visible = false;
                        del.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    //  string str = ex.ToString();
                    //  throw;
                }

            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('" + txt_FromDate.Text + "  To  " + txt_ToDate.Text + "  No DATA fOUND..!!');", true);
            txt_FromDate.Focus();
            return;
        }

    }
}