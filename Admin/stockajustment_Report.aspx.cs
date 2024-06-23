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
public partial class Admin_stockajustment_Report : System.Web.UI.Page
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
        }
    }

    public void fillgrid()
    {
        try
        {
            string Branch = Session["Branch"].ToString();
            string param = "@Fromdate,@Todate,@Branch";
          //  string param = "@itm_partno,@Branch";
            string paramvalue = Convert.ToDateTime(txt_FromDate.Text.Trim(), SmitaClass.dateformat()).ToString("yyyy-MM-dd") + "," + Convert.ToDateTime(txt_ToDate.Text.Trim(), SmitaClass.dateformat()).ToString("yyyy-MM-dd") + "," + Branch;
          
            
            // string paramvalue = txt_partno.Text.Trim() + "," + Branch;
            DataTable dt = smitaDbAccess.SPReturnDataTable("sp_stock_adj_Report", param, paramvalue);


            if (Convert.ToInt32(dt.Rows.Count) > 0)
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();

                var zzz = from c in db.AME_Branch_Creation.ToList() where c.Branch_Name == Session["Branch"].ToString() select c;
                lbl_BranchAddress.Text = zzz.First().Branch_Address + ", " + zzz.First().Branch_PhoneNo;

                //lbl_from.Text = txt_FromDate.Text;
                //lbl_to.Text = txt_ToDate.Text;
                Panel1.Visible = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('No Quotation Are Entry..!!');", true);
                Panel1.Visible = false;
               
                return;
            }
        }
        catch
        {

        }
    }
    //protected void btn_Show_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (txt_FromDate.Text == "")
    //        {
    //            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('From Date SHOULD NOT BE BLANK...!!');", true);
    //            txt_FromDate.Focus();
    //            return;
    //        }
    //        if (txt_ToDate.Text == "")
    //        {
    //            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('To Date SHOULD NOT BE BLANK...!!');", true);
    //            txt_ToDate.Focus();
    //            return;
    //        }

    //        if (Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat()) < Convert.ToDateTime(txt_FromDate.Text, SmitaClass.dateformat()))
    //        {
    //            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('To Date Must Be Greater Than From Date..!!');", true);
    //            txt_ToDate.Focus();
    //            return;
    //        }
    //        string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy", "dd-MM-yyyy" };
    //        DateTime expectedDate;
    //        if (!DateTime.TryParseExact(txt_FromDate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
    //        {
    //            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
    //            txt_FromDate.Focus();
    //            return;
    //        }
    //        if (!DateTime.TryParseExact(txt_ToDate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
    //        {
    //            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
    //            txt_ToDate.Focus();
    //            return;
    //        }


    //        fillgrid();

    //    }
    //    catch
    //    {

    //    }
    //}
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    fillgrid();
    //}
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
        catch(Exception ex)
        {

        }
    
        }
}