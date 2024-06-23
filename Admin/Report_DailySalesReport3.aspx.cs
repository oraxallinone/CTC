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
public partial class Admin_Report_DailySalesReport3 : System.Web.UI.Page
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
    decimal tot1 = 0, tot2 = 0, tot3 = 0, tot4 = 0, tot5 = 0, tot6 = 0, tot7 = 0, tot8 = 0,
    tot9 = 0, tot10 = 0, tot11 = 0, tot12 = 0, tot13 = 0, tot14 = 0, tot15 = 0, tot16 = 0, tot17 = 0, tot18 = 0, tot19 = 0,
    tot20 = 0, tot21 = 0, tot22 = 0, tot23 = 0, tot26 = 0, tot27 = 0, tot24 = 0, tot25 = 0;

    double tot28 = 0, tot29 = 0, tot30 = 0, tot31 = 0, tot32 = 0, tot33 = 0, tot34 = 0, tot35 = 0, tot36 = 0, tot37 = 0, tot38 = 0, tot39 = 0;



    public void FillGrid()
    {
        try
        {
            string Branch = Session["Branch"].ToString();

            string param = "@Fromdate,@Todate,@Branch,@year";
            string year = txt_year.Text.Trim();
            string paramvalue = Convert.ToDateTime(txt_FromDate.Text, SmitaClass.dateformat()).ToString("yyyy-MM-dd") + " , " + Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat()).ToString("yyyy-MM-dd") + "," + Branch + "," + year;
            //string paramvalue = Convert.ToDateTime(txt_FromDate.Text, SmitaClass.dateformat()).ToString("yyyy-dd-MM HH:mm:ss") + " , " + Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat()).ToString("yyyy-dd-MM HH:mm:ss") + "," + Branch;

            //DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_DailySpareSales_Report", param, paramvalue);
            //DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_DailySale_WithReturn_Reportgst1", param, paramvalue);

            //DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_DailySale_WithReturn_Reportgst1SBK", param, paramvalue);
            //DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_DailySale_WithReturn_Reportgst1SBKLatest1", param, paramvalue);
            //DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_DailySale_WithReturn_Reportgst1SBKLatest12", param, paramvalue);

            DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_DailySale_WithReturn_Reportgst1SBKLatest1223", param, paramvalue);





            //DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_latestjobdetails", param, paramvalue);
            if (dtr.Rows.Count > 0)
            {
                GridView1.DataSource = dtr;
                GridView1.DataBind();
                foreach (GridViewRow gr in GridView1.Rows)
                {








                    Label lblamount0 = (Label)gr.FindControl("lblinvoicetotal");
                    decimal gamnt = Convert.ToDecimal(lblamount0.Text);


                    Label lbloutsidejob = (Label)gr.FindControl("lbloutsidejob");
                    decimal outsidejob = Convert.ToDecimal(lbloutsidejob.Text);

                    Label lblroundoff = (Label)gr.FindControl("lblroundoff");
                    decimal roundoff = (Convert.ToDecimal(lblroundoff.Text == "" ? "0.00" : lblroundoff.Text));



                    Label lblservtax12 = (Label)gr.FindControl("lblservtax18");
                    decimal servtax12 = Convert.ToDecimal(lblservtax12.Text);
                    Label lblnetlbrchrg = (Label)gr.FindControl("lblnetlbrchrg");
                    decimal netlbrchrg = Convert.ToDecimal(lblnetlbrchrg.Text);
                    Label lbldiscountlbrcharge = (Label)gr.FindControl("lbldiscountlbrcharge");
                    decimal discountlbrcharge = Convert.ToDecimal(lbldiscountlbrcharge.Text);
                    Label lbllabourcharges = (Label)gr.FindControl("lbllabourcharges");
                    decimal labourcharges = Convert.ToDecimal(lbllabourcharges.Text);
                    Label lblotherchrges = (Label)gr.FindControl("lblotherchrges");
                    decimal otherchrges = Convert.ToDecimal(lblotherchrges.Text);


                    Label lblservtax18 = (Label)gr.FindControl("lblservtax18");
                    decimal servicetax18 = Convert.ToDecimal(lblservtax18.Text == "" ? "0.00" : lblservtax18.Text);

                    Label lblservtaxsgst9 = (Label)gr.FindControl("lblfsgst9");
                    decimal servicetaxsgst9 = Convert.ToDecimal(lblservtaxsgst9.Text == "" ? "0.00" : lblservtaxsgst9.Text);

                    Label lblservtaxcgst9 = (Label)gr.FindControl("lblfcgst9");
                    decimal servicetaxcgst9 = Convert.ToDecimal(lblservtaxcgst9.Text == "" ? "0.00" : lblservtaxcgst9.Text);


                    Label lblservtaxigst18 = (Label)gr.FindControl("lblfigst18");
                    decimal servicetaxigst18 = Convert.ToDecimal(lblservtaxigst18.Text == "" ? "0.00" : lblservtaxigst18.Text);











                    Label LBL_lubruri_sgst14 = (Label)gr.FindControl("lblsgstX");
                    decimal lubri_sgst14 = Convert.ToDecimal(LBL_lubruri_sgst14.Text == "" ? "0.00" : LBL_lubruri_sgst14.Text);


                    Label LBL_lubruri_Cgst14 = (Label)gr.FindControl("lblcgstX");
                    decimal lubri_Cgst14 = Convert.ToDecimal(LBL_lubruri_Cgst14.Text == "" ? "0.00" : LBL_lubruri_Cgst14.Text);

                    Label LBL_lubruri_sgst9 = (Label)gr.FindControl("lblsgst9X");
                    decimal lubri_sgst9 = Convert.ToDecimal(LBL_lubruri_sgst9.Text == "" ? "0.00" : LBL_lubruri_sgst9.Text);

                    Label LBL_lubruri_cgst9 = (Label)gr.FindControl("lblcgst9X");
                    decimal lubri_cgst9 = Convert.ToDecimal(LBL_lubruri_cgst9.Text == "" ? "0.00" : LBL_lubruri_cgst9.Text);










                    Label lbldis28 = (Label)gr.FindControl("lbldis28");
                    decimal dis28 = Convert.ToDecimal(lbldis28.Text == "" ? "0.00" : lbldis28.Text);

                    Label lbldis18 = (Label)gr.FindControl("lbldis18");
                    decimal dis18 = Convert.ToDecimal(lbldis18.Text == "" ? "0.00" : lbldis18.Text);

                    Label lbloutput28 = (Label)gr.FindControl("lbloutput28");
                    decimal output28 = Convert.ToDecimal(lbloutput28.Text == "" ? "0.00" : lbloutput28.Text);


                    Label lblsgst = (Label)gr.FindControl("lblsgst");
                    decimal outputsgst = Convert.ToDecimal(lblsgst.Text == "" ? "0.00" : lblsgst.Text);


                    Label lblcgst = (Label)gr.FindControl("lblcgst");
                    decimal outputcgst = Convert.ToDecimal(lblcgst.Text == "" ? "0.00" : lblcgst.Text);



                    Label lbligst = (Label)gr.FindControl("lbligst");
                    decimal outputigst = Convert.ToDecimal(lbligst.Text == "" ? "0.00" : lbligst.Text);



                    Label lbligstX = (Label)gr.FindControl("lbligstX");
                    decimal lubigst28 = Convert.ToDecimal(lbligstX.Text == "" ? "0.00" : lbligstX.Text);

                    Label lbligst18X = (Label)gr.FindControl("lbligst18X");
                    decimal lubigst18 = Convert.ToDecimal(lbligstX.Text == "" ? "0.00" : lbligstX.Text);








                    Label lblOutPut18 = (Label)gr.FindControl("lblOutPut18");
                    decimal output18 = Convert.ToDecimal(lblOutPut18.Text == "" ? "0.00" : lblOutPut18.Text);

                    Label lblsgst9 = (Label)gr.FindControl("lblsgst9");
                    decimal outputsgst9 = Convert.ToDecimal(lblsgst9.Text == "" ? "0.00" : lblsgst9.Text);

                    Label lblcgst9 = (Label)gr.FindControl("lblcgst9");
                    decimal outputcgst9 = Convert.ToDecimal(lblcgst9.Text == "" ? "0.00" : lblcgst9.Text);


                    Label lbligst18 = (Label)gr.FindControl("lbligst18");
                    decimal outputigst18 = Convert.ToDecimal(lbligst18.Text == "" ? "0.00" : lbligst18.Text);

                    Label lblspare28 = (Label)gr.FindControl("lblspare28");
                    decimal spare28 = Convert.ToDecimal(lblspare28.Text == "" ? "0.00" : lblspare28.Text);



                    Label lblspare18 = (Label)gr.FindControl("lblspare18");
                    decimal spare18 = Convert.ToDecimal(lblspare18.Text == "" ? "0.00" : lblspare18.Text);

                    Label lbllub28 = (Label)gr.FindControl("lbllub28");
                    decimal lub28 = Convert.ToDecimal(lbllub28.Text == "" ? "0.00" : lbllub28.Text);

                    Label lbllub18 = (Label)gr.FindControl("lbllub18");
                    decimal lub18 = Convert.ToDecimal(lbllub18.Text == "" ? "0.00" : lbllub18.Text);




                    Label lblsparereturn = (Label)gr.FindControl("lblReturntotal");
                    decimal returnamt = 0;


                    //Label lblfsgst14 = (Label)gr.FindControl("lblfsgst14");
                    //decimal sgst14 = Convert.ToDecimal(lblfsgst14.Text  == "" ? "0.00" : lblfsgst14.Text );


                    //Label lblfcgst14 = (Label)gr.FindControl("lblfcgst14");
                    //decimal cgst14 = Convert.ToDecimal(lblfcgst14.Text  == "" ? "0.00" : lblfcgst14.Text);

                    //Label lblfigst28 = (Label)gr.FindControl("lblfigst28");
                    //decimal igst28 = Convert.ToDecimal(lblfigst28.Text  == "" ? "0.00" : lblfigst28.Text);


                    Label lblfsgst9 = (Label)gr.FindControl("lblfsgst9");
                    decimal sgst9 = Convert.ToDecimal(lblfsgst9.Text == "" ? "0.00" : lblfsgst9.Text);

                    Label lblfcgst9 = (Label)gr.FindControl("lblfcgst9");
                    decimal cgst9 = Convert.ToDecimal(lblfcgst9.Text == "" ? "0.00" : lblfcgst9.Text);

                    Label lblfigst18 = (Label)gr.FindControl("lblfigst18");
                    decimal igst9 = Convert.ToDecimal(lblfigst18.Text == "" ? "0.00" : lblfigst18.Text);

                    Label lblcANCELsTATUS = (Label)gr.FindControl("lblinvoicetype");

                    Label lbloutput28X = (Label)gr.FindControl("lbloutput28X");
                    Label lblOutPut18X = (Label)gr.FindControl("lblOutPut18X");
                    

                        



                    if (lblcANCELsTATUS.Text != "CANCEL")
                    {


                        tot1 = tot1 + gamnt;
                        tot2 = tot2 + outsidejob;
                        tot3 = tot3 + returnamt;

                        tot4 = tot4 + spare28;
                        tot5 = tot5 + spare18;

                        tot6 = tot6 + lub28;

                        tot7 = tot7 + lub18;

                        tot8 = tot8 + dis28;

                        tot9 = tot9 + dis18;

                        tot10 = tot10 + output28;

                        tot11 = tot11 + outputsgst;

                        tot12 = tot12 + outputcgst;

                        tot13 = tot13 + outputigst;

                        tot14 = tot14 + output18;

                        tot15 = tot15 + outputsgst9;

                        tot16 = tot16 + outputcgst9;

                        tot17 = tot17 + outputigst18;

                        tot18 = tot18 + otherchrges;

                        tot19 = tot19 + labourcharges;

                        tot20 = tot20 + netlbrchrg;

                        tot21 = tot21 + servicetax18;

                        tot22 = tot22 + servicetaxsgst9;

                        tot23 = tot23 + servicetaxcgst9;
                        tot24 = tot24 + servicetaxigst18;
                        tot25 = tot25 + discountlbrcharge;

                        tot26 = roundoff + netlbrchrg + servicetax18 - gamnt;

                        //decimal run = roundoff;

                        //if (gamnt == 0)
                        //{
                        //    lblroundoff.Text = "0.00";
                        //}

                        //else
                        //{
                        //    //lblroundoff.Text = (run + netlbrchrg + servicetax18 - gamnt).ToString("0.00");

                        //    decimal c = (run + netlbrchrg + servicetax18 - gamnt);
                        //    if (c > 0)
                        //    {
                        //        decimal d = c * (-1);
                        //        lblroundoff.Text = d.ToString();

                        //    }
                        //    else
                        //    {
                        //        lblroundoff.Text = Math.Abs((run + netlbrchrg + servicetax18 - (gamnt))).ToString("0.00");


                        //    }
                        //}





                        //tot36 = Convert.ToDouble(lblamount0.Text);
                        //// tot37 = tot33 - tot36;
                        //tot37 = tot36 - tot33;

                        //lblroundoff.Text = tot37.ToString("0.00");
                        //tot38 = tot38 + tot37;

                        //  lbldis28.Text = "0.00";



                        Label lbl_fgamnt = (Label)GridView1.FooterRow.FindControl("lbl_fgamnt");
                        lbl_fgamnt.Text = Math.Round(tot1).ToString("0.00");

                        Label lbl_foutsidejob = (Label)GridView1.FooterRow.FindControl("lbl_foutsidejob");
                        lbl_foutsidejob.Text = tot2.ToString("0.00");


                        Label lbl_froundoff = (Label)GridView1.FooterRow.FindControl("lbl_froundoff");
                        lbl_froundoff.Text = tot26.ToString("0.00");

                        Label lbl_fspare28 = (Label)GridView1.FooterRow.FindControl("lbl_fspare28");
                        lbl_fspare28.Text = tot4.ToString("0.00");

                        Label lbl_spare18 = (Label)GridView1.FooterRow.FindControl("lbl_spare18");
                        lbl_spare18.Text = tot5.ToString("0.00");

                        Label lbl_flub28 = (Label)GridView1.FooterRow.FindControl("lbl_flub28");
                        lbl_flub28.Text = tot6.ToString("0.00");

                        Label lbl_flub18 = (Label)GridView1.FooterRow.FindControl("lbl_flub18");
                        lbl_flub18.Text = tot7.ToString("0.00");

                        Label lbl_fdis28 = (Label)GridView1.FooterRow.FindControl("lbl_fdis28");
                        lbl_fdis28.Text = tot8.ToString("0.00");

                        Label lbl_fdis18 = (Label)GridView1.FooterRow.FindControl("lbl_fdis18");
                        lbl_fdis18.Text = tot9.ToString("0.00");

                        Label lbl_foutput28 = (Label)GridView1.FooterRow.FindControl("lbl_foutput28");
                        lbl_foutput28.Text = tot10.ToString("0.00");

                        Label lbl_sgst14 = (Label)GridView1.FooterRow.FindControl("lbl_sgst14");
                        lbl_sgst14.Text = tot11.ToString("0.00");

                        Label lbl_cgst14 = (Label)GridView1.FooterRow.FindControl("lbl_cgst14");
                        lbl_cgst14.Text = tot12.ToString("0.00");

                        Label lbl_igst28 = (Label)GridView1.FooterRow.FindControl("lbl_igst28");
                        lbl_igst28.Text = tot13.ToString("0.00");


                        Label lbl_OutPut18 = (Label)GridView1.FooterRow.FindControl("lbl_OutPut18");
                        lbl_OutPut18.Text = tot14.ToString("0.00");

                        Label lbl_sgst9 = (Label)GridView1.FooterRow.FindControl("lbl_sgst9");
                        lbl_sgst9.Text = tot15.ToString("0.00");

                        Label lbl_cgst9 = (Label)GridView1.FooterRow.FindControl("lbl_cgst9");
                        lbl_cgst9.Text = tot16.ToString("0.00");

                        Label lbl_igst18 = (Label)GridView1.FooterRow.FindControl("lbl_igst18");
                        lbl_igst18.Text = tot17.ToString("0.00");

                        Label lbl_fotherchrges = (Label)GridView1.FooterRow.FindControl("lbl_fotherchrges");
                        lbl_fotherchrges.Text = tot18.ToString("0.00");

                        Label lbl_flabourcharges = (Label)GridView1.FooterRow.FindControl("lbl_flabourcharges");
                        lbl_flabourcharges.Text = tot19.ToString("0.00");

                        Label lbl_fnetlbrchrg = (Label)GridView1.FooterRow.FindControl("lbl_fnetlbrchrg");
                        lbl_fnetlbrchrg.Text = tot20.ToString("0.00");

                        Label lbl_fservtax18 = (Label)GridView1.FooterRow.FindControl("lbl_fservtax18");
                        lbl_fservtax18.Text = tot21.ToString("0.00");

                        Label lbl_fsgst9 = (Label)GridView1.FooterRow.FindControl("lbl_fsgst9");
                        lbl_fsgst9.Text = tot22.ToString("0.00");

                        Label lbl_fcgst9 = (Label)GridView1.FooterRow.FindControl("lbl_fcgst9");
                        lbl_fcgst9.Text = tot23.ToString("0.00");

                        Label lbl_figst18 = (Label)GridView1.FooterRow.FindControl("lbl_figst18");
                        lbl_figst18.Text = tot24.ToString("0.00");

                        Label lbl_fdiscountlbrcharge = (Label)GridView1.FooterRow.FindControl("lbl_fdiscountlbrcharge");
                        lbl_fdiscountlbrcharge.Text = tot25.ToString("0.00");




                        Label lblstate = (Label)gr.FindControl("lblstate");
                        string s = lblstate.Text;
                        if (s.Equals("False"))
                        {
                            lbligst.Text = "0.00";
                            lbligst18.Text = "0.00";
                            lbligstX.Text = "0.00";
                            lbligst18X.Text = "0.00";
                            lblfigst18.Text = "0.00";
                            lblsgst.Text = outputsgst.ToString("0.00");
                            lblcgst.Text = outputcgst.ToString("0.00");
                            lblsgst9.Text = outputsgst9.ToString("0.00");
                            lblcgst9.Text = outputcgst9.ToString("0.00");
                            lblfsgst9.Text = sgst9.ToString("0.00");
                            lblfcgst9.Text = cgst9.ToString("0.00");
                            LBL_lubruri_sgst14.Text = lubri_sgst14.ToString("0.00");
                        }

                        else
                        {
                            lblsgst.Text = "0.00";
                            lblcgst.Text = "0.00";

                            lblsgst9.Text = "0.00";
                            lblcgst9.Text = "0.00";

                            lblfsgst9.Text = "0.00";

                            lblfcgst9.Text = "0.00";

                        }
                    }
                    else
                    {

                        lblamount0.Text = "0.00";
                        lbloutsidejob.Text = "0.00";

                        lblroundoff.Text = "0.00";
                        lblservtax12.Text = "0.00";
                        lblnetlbrchrg.Text = "0.00";
                        lbldiscountlbrcharge.Text = "0.00";
                        lbllabourcharges.Text = "0.00";
                        lblotherchrges.Text = "0.00";
                        lblservtax18.Text = "0.00";
                        lblservtaxsgst9.Text = "0.00";
                        lblservtaxcgst9.Text = "0.00";
                        lblservtaxigst18.Text = "0.00";

                        LBL_lubruri_sgst14.Text = "0.00";
                        LBL_lubruri_Cgst14.Text = "0.00";
                        LBL_lubruri_sgst9.Text = "0.00";
                        LBL_lubruri_cgst9.Text = "0.00";
                        lbldis28.Text = "0.00";
                        lbldis18.Text = "0.00";
                        lbloutput28.Text = "0.00";
                        lblsgst.Text = "0.00";
                        lblcgst.Text = "0.00";
                        lbligst.Text = "0.00";
                        lbligstX.Text = "0.00";
                        lbligst18X.Text = "0.00";
                        lblOutPut18.Text = "0.00";
                        lblsgst9.Text = "0.00";
                        lblcgst9.Text = "0.00";
                        lbligst18.Text = "0.00";
                        lblspare28.Text = "0.00";
                        lblspare18.Text = "0.00";
                        lbllub28.Text = "0.00";
                        lbllub18.Text = "0.00";
                        lblsparereturn.Text = "0.00";
                        lblfsgst9.Text = "0.00";
                        lblfcgst9.Text = "0.00";
                        lblfigst18.Text = "0.00";
                       lbloutput28X.Text = "0.00";
                       lblOutPut18X.Text = "0.00";


                    }



                }
                var zzz = from c in db.AME_Branch_Creation.ToList() where c.Branch_Name == Session["Branch"].ToString() select c;
                lbl_BranchAddress.Text = zzz.First().Branch_Address + ", " + zzz.First().Branch_PhoneNo;
                lbltin.Text = zzz.First().Branch_TIN;

                Panel1.Visible = true;
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert(' No Data Are Found.!!');", true);
                Panel1.Visible = false;

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
            string attachment = "attachment; filename=" + "DailySalesReport" + "(" + Branch + ")" + ".xls";
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