﻿using System;
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
public partial class Admin_Report_DailySalesReport2 : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    public string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txt_FromDate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
            txt_ToDate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
            txt_year.Text = "2017-18";
            FillGrid();

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
    tot20 = 0, tot21 = 0, tot22 = 0, tot23 = 0;

    double tot26 = 0, tot27 = 0, tot24 = 0, tot25 = 0, tot28 = 0, tot29 = 0, tot30 = 0, tot31 = 0, tot32 = 0, tot33 = 0, tot34 = 0, tot35 = 0, tot36 = 0, tot37 = 0, tot38 = 0, tot39 = 0;



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
            DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_DailySale_WithReturn_Reportgst", param, paramvalue);
            if (dtr.Rows.Count > 0)
            {
                GridView1.DataSource = dtr;
                GridView1.DataBind();
                foreach (GridViewRow gr in GridView1.Rows)
                {
                    //Label lblamount0 = (Label)gr.FindControl("lblinvoicetotal");
                    //decimal gamnt = Convert.ToDecimal(lblamount0.Text);


                    Label lbloutsidejob = (Label)gr.FindControl("lbloutsidejob");
                    decimal outsidejob = Convert.ToDecimal(lbloutsidejob.Text);
                    Label lblroundoff = (Label)gr.FindControl("lblroundoff");
                    decimal roundoff = Convert.ToDecimal(lblroundoff.Text);
                    //Label lblscess1 = (Label)gr.FindControl("lblscess1");
                    //decimal scess1 = Convert.ToDecimal(lblscess1.Text);
                    //Label lblecess2 = (Label)gr.FindControl("lblecess2");
                    //decimal ecess2 = Convert.ToDecimal(lblecess2.Text);
                    Label lblservtax12 = (Label)gr.FindControl("lblservtax12");
                    decimal servtax12 = Convert.ToDecimal(lblservtax12.Text);
                    Label lblnetlbrchrg = (Label)gr.FindControl("lblnetlbrchrg");
                    decimal netlbrchrg = Convert.ToDecimal(lblnetlbrchrg.Text);
                    Label lbldiscountlbrcharge = (Label)gr.FindControl("lbldiscountlbrcharge");
                    decimal discountlbrcharge = Convert.ToDecimal(lbldiscountlbrcharge.Text);
                    Label lbllabourcharges = (Label)gr.FindControl("lbllabourcharges");
                    decimal labourcharges = Convert.ToDecimal(lbllabourcharges.Text);
                    Label lblotherchrges = (Label)gr.FindControl("lblotherchrges");
                    decimal otherchrges = Convert.ToDecimal(lblotherchrges.Text);

                    //Label lbloutput135 = (Label)gr.FindControl("lbloutput135");
                    //decimal output135 = Convert.ToDecimal(lbloutput135.Text);

                    Label lbldis135 = (Label)gr.FindControl("lbldis135");
                    decimal dis135 = Convert.ToDecimal(lbldis135.Text);
                    
                    Label lbllub135 = (Label)gr.FindControl("lbllub135");
                    decimal lub135 = Convert.ToDecimal(lbllub135.Text);

                    Label lblspare135 = (Label)gr.FindControl("lblspare135");
                    decimal spare135 = Convert.ToDecimal(lblspare135.Text);

                    Label lbloutput135 = (Label)gr.FindControl("lbloutput135");
                    decimal output135 = Convert.ToDecimal( (lub135 + spare135) * 28/100);
                    lbloutput135.Text = Convert.ToDecimal( output135).ToString("0.00");

                    Label lblsparereturn = (Label)gr.FindControl("lblReturntotal");
                    decimal returnamt = 0;

                    Label lblfsgst14 = (Label)gr.FindControl("lblfsgst14");
                    decimal sgst14 = Convert.ToDecimal(lblfsgst14.Text);
                   

                    Label lblfcgst14 = (Label)gr.FindControl("lblfcgst14");
                    decimal cgst14 = Convert.ToDecimal(lblfcgst14.Text);

                    Label lblfigst28 = (Label)gr.FindControl("lblfigst28");
                    decimal igst28 = Convert.ToDecimal(lblfigst28.Text);


                    Label lblout14 = (Label)gr.FindControl("lblspare135");

                    double output14 = Convert.ToDouble(lblout14.Text);


                    Label lbllub14 = (Label)gr.FindControl("lbllub135");

                    double outputlub14 = Convert.ToDouble(lbllub14.Text);




                    Label lblnetlbrchrg1 = (Label)gr.FindControl("lblnetlbrchrg");
                    double netlbrchrg1 = Convert.ToDouble(lblnetlbrchrg1.Text);


                    Label lblservtax121 = (Label)gr.FindControl("lblservtax12");
                    double servtax121 = Convert.ToDouble(lblservtax121.Text);


                    Label lblamount0 = (Label)gr.FindControl("lblinvoicetotal");
                    double gamnt = Convert.ToDouble(lblamount0.Text);


                    Label lblroundoff1 = (Label)gr.FindControl("lblroundoff");
                    double roundoff1 = Convert.ToDouble(lblroundoff1.Text);



                    if (lblsparereturn.Text != null && lblsparereturn.Text != "")
                        returnamt = Convert.ToDecimal(lblsparereturn.Text);

                    //   tot1 = tot1 + gamnt;
                    tot2 = tot2 + outsidejob;
                    tot3 = tot3 + roundoff;



                    tot8 = tot8 + discountlbrcharge;
                    tot9 = tot9 + labourcharges;
                    tot10 = tot10 + otherchrges;

                    tot12 = tot12 + output135;

                    tot14 = tot14 + dis135;

                    tot16 = tot16 + lub135;

                    tot18 = tot18 + spare135;
                    tot19 = tot19 + returnamt;
                    tot30 = outputlub14 + output14;
                    tot20 = tot20 + sgst14;
                    tot21 = tot21 + cgst14;
                    tot22 = tot22 + igst28;


                    tot28 = tot28 + netlbrchrg1;
                    tot29 = tot29 + servtax121;

                    tot34 = netlbrchrg1;
                    tot35 = servtax121;



                    //lbloutput135.Text = tot24.ToString("0.00");   


                    tot26 = tot26 + tot24;
                    tot27 = tot27 + tot25;

                    //  tot39 =Convert.ToDouble( tot14 + tot13);

                    //tot32 = tot32 + (tot24 + tot25  + tot34 + tot35 + tot30 + tot31 - tot39);

                    //tot33 = tot24 + tot25 + tot34 + tot35 + tot30 + tot31 - tot39;


                    tot32 = tot32 + (Convert.ToDouble(output135) + tot34 + tot35 + tot30 + tot31 - Convert.ToDouble(dis135));

                    tot33 = Convert.ToDouble(output135) + tot34 + tot35 + tot30 + tot31 - Convert.ToDouble(dis135);

                   // lblamount0.Text = Math.Round(tot33).ToString("0.00");

                    tot36 = Convert.ToDouble(lblamount0.Text);
                    // tot37 = tot33 - tot36;
                    tot37 = tot36 - tot33;

                    lblroundoff1.Text = tot37.ToString("0.00");
                    tot38 = tot38 + tot37;

                    lbldis135.Text = "0.00";

                   

                    Label lbl_fgamnt = (Label)GridView1.FooterRow.FindControl("lbl_fgamnt");
                    lbl_fgamnt.Text = Math.Round(tot32).ToString("0.00");
                    Label lbl_foutsidejob = (Label)GridView1.FooterRow.FindControl("lbl_foutsidejob");
                    lbl_foutsidejob.Text = tot2.ToString("0.00");
                    Label lbl_froundoff = (Label)GridView1.FooterRow.FindControl("lbl_froundoff");
                    lbl_froundoff.Text = tot38.ToString("0.00");
                    //Label lbl_fscess1 = (Label)GridView1.FooterRow.FindControl("lbl_fscess1");
                    //lbl_fscess1.Text = tot4.ToString("0.00");
                    //Label lbl_fecess2 = (Label)GridView1.FooterRow.FindControl("lbl_fecess2");
                    //lbl_fecess2.Text = tot5.ToString("0.00");
                    Label lbl_fservtax12 = (Label)GridView1.FooterRow.FindControl("lbl_fservtax12");
                    lbl_fservtax12.Text = tot29.ToString("0.00");
                    Label lbl_fnetlbrchrg = (Label)GridView1.FooterRow.FindControl("lbl_fnetlbrchrg");
                    lbl_fnetlbrchrg.Text = tot28.ToString("0.00");
                    Label lbl_fdiscountlbrcharge = (Label)GridView1.FooterRow.FindControl("lbl_fdiscountlbrcharge");
                    lbl_fdiscountlbrcharge.Text = tot8.ToString("0.00");
                    Label lbl_flabourcharges = (Label)GridView1.FooterRow.FindControl("lbl_flabourcharges");
                    lbl_flabourcharges.Text = tot9.ToString("0.00");
                    Label lbl_fotherchrges = (Label)GridView1.FooterRow.FindControl("lbl_fotherchrges");
                    lbl_fotherchrges.Text = tot10.ToString("0.00");

                    Label lbl_foutput135 = (Label)GridView1.FooterRow.FindControl("lbl_foutput135");
                    lbl_foutput135.Text = tot26.ToString("0.00");

                    Label lbl_fdis135 = (Label)GridView1.FooterRow.FindControl("lbl_fdis135");
                    lbl_fdis135.Text = tot14.ToString("0.00");

                    Label lbl_flub135 = (Label)GridView1.FooterRow.FindControl("lbl_flub135");
                    lbl_flub135.Text = tot16.ToString("0.00");

                    Label lbl_fspare135 = (Label)GridView1.FooterRow.FindControl("lbl_fspare135");
                    lbl_fspare135.Text = tot18.ToString("0.00");
                    Label lbl_fsparertn = (Label)GridView1.FooterRow.FindControl("lbl_Returnamnt");
                    lbl_fsparertn.Text = tot19.ToString("0.00");
                    Label lbl_fsgst14 = (Label)GridView1.FooterRow.FindControl("lbl_fsgst14");
                    lbl_fsgst14.Text = tot20.ToString("0.00");
                    Label lbl_fcgst14 = (Label)GridView1.FooterRow.FindControl("lbl_fcgst14");
                    lbl_fcgst14.Text = tot21.ToString("0.00");
                    Label lbl_figst28 = (Label)GridView1.FooterRow.FindControl("lbl_figst28");
                    lbl_figst28.Text = tot22.ToString("0.00");


                    Label lblstate = (Label)gr.FindControl("lblstate");
                    string s = lblstate.Text;
                    if (s.Equals("False"))
                    {
                        igst28 = 0;
                        lblfigst28.Text = "0.00";
                    }

                    else
                    {
                        sgst14 = 0;
                        cgst14 = 0;
                        lblfsgst14.Text = "0.00";
                        lblfcgst14.Text = "0.00";

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