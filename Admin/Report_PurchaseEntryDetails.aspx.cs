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
public partial class Admin_Report_PurchaseEntryDetails : System.Web.UI.Page
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

    
    double tot1 = 0, tot2 = 0, tot3 = 0, tot4 = 0, tot5 = 0, tot6 = 0, tot7 = 0, tot8 = 0,
        tot9 = 0, tot10 = 0, tot11 = 0, tot12 = 0, tot13 = 0, tot14 = 0, tot15 = 0, tot16 = 0, tot17 = 0, tot18 = 0, tot19 = 0;
    public void FillGrid()
    {
        try
        {
            string Branch = Session["Branch"].ToString();
            string param = "@Fromdate,@Todate,@Branch";
            string paramvalue = Convert.ToDateTime(txt_FromDate.Text, SmitaClass.dateformat()).ToString("dd/MM/yyyy") + " , " + Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat()).ToString("dd/MM/yyyy") + "," + Branch;

            DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_purchaseentrydetails", param, paramvalue);
            if (dtr.Rows.Count > 0)
            {
                GridView1.DataSource = dtr;
                GridView1.DataBind();
                foreach (GridViewRow gr in GridView1.Rows)
                {



                    Label lblamount0 = (Label)gr.FindControl("lblvat14");
                    //  decimal vat14 = Convert.ToDecimal(lblamount0.Text);
                    double vat14 = Convert.ToDouble(lblamount0.Text);

                    Label lbloutsidejob = (Label)gr.FindControl("lbl006");
                    double vat = Convert.ToDouble(lbloutsidejob.Text);
                    //Label lblroundoff = (Label)gr.FindControl("lblvat2");
                    //double vat2 = Convert.ToDouble(lblroundoff.Text);

                    if (vat14 == 14.50)
                    {
                        tot1 = tot1 + vat;
                        Label lbl_fspare14 = (Label)GridView1.FooterRow.FindControl("lbl_fdiscount14");
                        lbl_fspare14.Text = tot1.ToString("0.00");

                    }
                    else if (vat14 == 5.00)
                    {
                        tot2 = tot2 + vat;
                        Label lbl_fspare5 = (Label)GridView1.FooterRow.FindControl("lbl_fdiscount5");
                        lbl_fspare5.Text = tot1.ToString("0.00");


                    }
                    else if (vat14 == 2.00)
                    {
                        tot3 = tot3 + vat;
                        Label lbl_fspare2 = (Label)GridView1.FooterRow.FindControl("lbl_fspare5");
                        lbl_fspare2.Text = tot17.ToString("0.00");


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
        catch (Exception ex)
        { }

    }
    //public void FillGrid()
    //{

    //    string Branch = Session["Branch"].ToString();
    //    string param = "@Fromdate,@Todate,@Branch";
    //    string paramvalue = Convert.ToDateTime(txt_FromDate.Text, SmitaClass.dateformat()).ToString("dd/MM/yyyy") + " , " + Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat()).ToString("dd/MM/yyyy") + "," + Branch;

    //    DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_purchaseentrydetails", param, paramvalue);
    //    if (dtr.Rows.Count > 0)
    //    {
    //        GridView1.DataSource = dtr;
    //        GridView1.DataBind();
    //        foreach (GridViewRow gr in GridView1.Rows)
    //        {
    //            try
    //            {
    //                ImageButton edit = (ImageButton)gr.FindControl("imgbtnedit");
    //                ImageButton del = (ImageButton)gr.FindControl("imgbtndelete");

    //                if (Session["saletype"] != null)
    //                {
    //                    edit.Visible = false;
    //                    del.Visible = false;
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                string str = ex.ToString();
    //                throw;
    //            }

    //        }
    //    }
    //    else
    //    {
    //        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('" + txt_FromDate.Text + "  To  " + txt_ToDate.Text + "  No DATA fOUND..!!');", true);
    //        txt_FromDate.Focus();
    //        return;
    //    }

    //}

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
}