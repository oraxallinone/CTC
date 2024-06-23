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
                    Su_Code = c.Mc_code
                };
        ddl_customer.DataSource = v.ToList();
        ddl_customer.DataTextField = "Su_Name";
        ddl_customer.DataValueField = "Su_Code";
        ddl_customer.DataBind();
        ddl_customer.Items.Insert(0, "--Select One--");
    }

    public void FillGrid()
    {
        string Branch = Session["Branch"].ToString();
        string param = "@Fromdate,@Todate,@Branch,@Customercode";
        string paramvalue = Convert.ToDateTime(txt_FromDate.Text, SmitaClass.dateformat()).ToString("yyyy-MM-dd HH:mm:ss") + " , " + Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat()).ToString("yyyy-MM-dd HH:mm:ss") + "," + Branch+","+ddl_customer.SelectedValue;

        DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_Spare_SalesListPartywise", param, paramvalue);
        if(dtr.Rows.Count>0)
        {
        GridView1.DataSource = dtr;
        GridView1.DataBind();

        var zzz = from c in db.AME_Branch_Creation.ToList() where c.Branch_Name == Session["Branch"].ToString() select c;
        lbl_BranchAddress.Text = zzz.First().Branch_Address + ", " + zzz.First().Branch_PhoneNo;
        lbltinno.Text = zzz.First().Branch_TIN;
        lbl_from.Text = txt_FromDate.Text;
        lbl_to.Text = txt_ToDate.Text;
        Panel1.Visible = true;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('"+txt_FromDate.Text+"  To  "+txt_ToDate.Text+"  No Sales Are Entry..!!');", true);
            Panel1.Visible = false;
            txt_FromDate.Focus();
            return;
        }

    }
    protected void btn_Show_Click(object sender, EventArgs e)
    {
        try
        {
         if (ddl_customer.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Please Select Customer Name..!!');", true);
                ddl_customer.Focus();
                return;
            }

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
}
