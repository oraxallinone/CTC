using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
using System.Data;
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
          //  FillGrid();
           

        }
    }

    [System.Web.Services.WebMethod]
    public static string[] Getyear(string prefixText, int count)
    {

        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_FinacialYear.Where(n => n.finacialyear.Contains(prefixText)).OrderBy(n => n.finacialyear).Select(n => n.finacialyear).Distinct().Take(count).ToArray();
    }
    public void FillGrid()
    {
        string Branch = Session["Branch"].ToString();
        string param = "@Fromdate,@Todate,@Branch";
        string paramvalue = Convert.ToDateTime(txt_FromDate.Text, SmitaClass.dateformat()).ToString("yyyy-MM-dd HH:mm:ss") + " , " + Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat()).ToString("yyyy-MM-dd HH:mm:ss") + "," + Branch;

        DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_Spare_SalesList", param, paramvalue);
        if(dtr.Rows.Count>0)
        {
        GridView1.DataSource = dtr;
        GridView1.DataBind();
        decimal tot1 = 0;
        foreach (GridViewRow gr in GridView1.Rows)
        {
            ImageButton edit = (ImageButton)gr.FindControl("imgbtnedit");

            if (Session["saletype"] != null)
            {
                edit.Visible = false;
            }

            Label lblamount0 = (Label)gr.FindControl("lbl008");

            decimal gamnt = Convert.ToDecimal(lblamount0.Text);

            tot1 = tot1 + gamnt;

            Label lbl_fgamnt = (Label)GridView1.FooterRow.FindControl("lbl_fgamnt");
            lbl_fgamnt.Text = tot1.ToString("0.00");
        }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('"+txt_FromDate.Text+"  To  "+txt_ToDate.Text+"  No Sales Are Entry..!!');", true);
            txt_FromDate.Focus();
            return;
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
            if (txt_year.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Finacial Year Shoul Not Be Blanck...!!');", true);
                txt_year.Focus();
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
        Response.Redirect("Spare_SalesEntryEdit.aspx?id=" + sino + "&No=" + imgedit.CommandArgument + "&year="+ txt_year.Text.Trim());
    }
    protected void imgbtnview_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgview = (ImageButton)sender;
        int sino = Convert.ToInt32(imgview.ToolTip);
        Response.Redirect("Spare_SalesEntryView.aspx?id=" + sino + "&No=" + imgview.CommandArgument + "&year=" + txt_year.Text.Trim());
    }

    //protected void imgbtndelete_Click(object sender, ImageClickEventArgs e)
    //{
    //    ImageButton imgdelete = (ImageButton)sender;
    //    int sino = Convert.ToInt32(imgdelete.ToolTip);
    //    string No = Convert.ToString(imgdelete.CommandArgument);

    //    AME_Spare_SalesEntryBillDetails vq = db.AME_Spare_SalesEntryBillDetails.ToList().First(t => t.Sp_Id == sino);
    //    db.DeleteObject(vq);

    //    db.AME_Spare_SalesEntry.ToList().Where(t => t.Sp_InvoiceNo == No && t.Branch_Name == Session["Branch"].ToString()).ToList().ForEach(db.AME_Spare_SalesEntry.DeleteObject);
    //    db.SaveChanges();

    //    ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Invoice Deleted Sucessfully..!!');", true);
    //    FillGrid();
    //}
    protected void imgbtn_print_Click(object sender, ImageClickEventArgs e)
    {

      
        ImageButton imgPrint = (ImageButton)sender;
        int sino = Convert.ToInt32(imgPrint.ToolTip);

        var check = from c in db.AME_Spare_SalesEntryBillDetails.Where(t => t.Sp_Id == sino) select c;

        if (check.First().gstflag == false)
        {


            Response.Redirect("Counter_SalePrint.aspx?id=" + sino + "&No=" + imgPrint.CommandArgument + "&year=" + txt_year.Text.Trim());
        
        
        }

        else
        {




            Response.Redirect("Spare_sale_print1.aspx?id=" + sino + "&No=" + imgPrint.CommandArgument + "&year=" + txt_year.Text.Trim());
        }
    }
}
