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
            txt_jcyear.Text = "2017-18";
            txt_FromDate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
            txt_ToDate.Text = SmitaClass.IndianTime().AddDays(1).ToString("dd/MM/yyyy");
            FillGrid();
        }
    }

    public void FillGrid()
    {

        string Branch = Session["Branch"].ToString();
        string param = "@Fromdate,@Todate,@Branch";
        string paramvalue = Convert.ToDateTime(txt_FromDate.Text, SmitaClass.dateformat()).ToString("yyyy-MM-dd HH:mm:ss") + " , " + Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat()).ToString("yyyy-MM-dd HH:mm:ss") + "," + Branch;

        DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_Spare_PurchaseList", param, paramvalue);
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
    protected void btn_Show_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_jcyear.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Please Enter Finacila Year...!!');", true);
                txt_jcyear.Focus();
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



    protected void imgbtnedit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgedit = (ImageButton)sender;
        int sino = Convert.ToInt32(imgedit.ToolTip);
        Response.Redirect("Spare_PurchaseEntryEdit.aspx?id=" + sino + "&No=" + imgedit.CommandArgument + "&year=" + txt_jcyear.Text.Trim());
    }
    protected void imgbtnview_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgview = (ImageButton)sender;
        int sino = Convert.ToInt32(imgview.ToolTip);
        Response.Redirect("Spare_PurchaseEntryView.aspx?id=" + sino + "&No=" + imgview.CommandArgument + "&year=" + txt_jcyear.Text.Trim());
    }

    protected void imgbtndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgdelete = (ImageButton)sender;
        int sino = Convert.ToInt32(imgdelete.ToolTip);
        int No = Convert.ToInt32(imgdelete.CommandArgument);

        var check = from c in db.AME_Spare_PurchaseEntry.ToList() where c.Sp_VoucherNo == No && c.Branch_Name == Session["Branch"].ToString() && c.jc_year == txt_jcyear.Text.Trim() select c;
        foreach (var c in check)
        {
            if (Convert.ToDecimal(c.Ss_Quantity)  != Convert.ToDecimal(c.Ss_NetQuantity))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Error..!! Stock Already Used Now You Cant Delete Stock..!!');", true);
                return;
            }
        }

        AME_Spare_PurchaseEntryBillDetails vq = db.AME_Spare_PurchaseEntryBillDetails.ToList().First(t => t.Sp_Id == sino && t.Sp_VoucherNo == No && t.Branch_Name == Session["Branch"].ToString() && t.jc_year==txt_jcyear.Text.Trim()); 
        db.DeleteObject(vq);
        string bname=Session["Branch"].ToString();
        db.AME_Spare_PurchaseEntry.Where(t => t.Sp_VoucherNo == No && t.Ss_Status == "PE" && t.Branch_Name == bname && t.jc_year == txt_jcyear.Text.Trim()).ToList().ForEach(db.AME_Spare_PurchaseEntry.DeleteObject);
        db.SaveChanges();

        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Bill Deleted Sucessfully..!!');", true);
        FillGrid();
    }
    
}
