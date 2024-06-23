using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
using System.Data;
public partial class Admin_Part_Tracking : System.Web.UI.Page
{

    AutoMobileEntities db = new AutoMobileEntities();
    Clear cl = new Clear();
    public string Branch;
    public string Usertype;
    string id;
    string ValueType;
     decimal tot = 0, tot1 = 0,tot2=0, tot3 = 0, tot4 = 0, tot5 = 0, tot6 = 0 , tot7=0 , tot8=0, tot9=0,tot101=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          
        }
       

    }

    [System.Web.Services.WebMethod]
    public static string[] Getpartno(string prefixText, int count)
    {
        string branch = HttpContext.Current.Session["Branch"].ToString();
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Master_Item.Where(n => n.Itm_Partno.Contains(prefixText) && n.Ms_Status == true && n.Branch_Name == branch).OrderBy(n => n.Itm_Partno).Select(n => n.Itm_Partno).Distinct().Take(count).ToArray();
    }
    protected void txt_part_TextChanged(object sender, EventArgs e)
    {

        lbl_pshow.Text = "0.00";
        lbl_serissret.Text = "0.00";
        lbl_cousealret.Text = "0.00";
        lbl_stocktrans.Text = "0.00";
        lbl_countersale.Text = "0.00";
        lbl_spareissue.Text = "0.00";
        fill();

        fill1();

        fill2();

        fill3();

        fill4();
        fill5();
        fillStockadj();
        fillOpenStock();
        fillpurchasereturn();
        fillStockintransfer();

        DataSet ds = smitaDbAccess.returndataset("select SUM(Ss_NetQuantity) AS NetQuantity FROM AME_Spare_PurchaseEntry WHERE Itm_Partno='" + txt_part.Text + "' AND Branch_Name='" + Session["Branch"].ToString() + "'");
        if (ds.Tables[0].Rows[0].ItemArray[0].ToString() != "")
        {
            lbl_stock.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        else
        {
            lbl_stock.Text = "0";
        }

        tot7 = Convert.ToDecimal( lbl_pshow.Text )+ Convert.ToDecimal( lbl_serissret.Text) + Convert.ToDecimal( lbl_cousealret.Text);

        tot8 = Convert.ToDecimal( lbl_stocktrans.Text) + Convert.ToDecimal( lbl_countersale.Text) + Convert.ToDecimal( lbl_spareissue.Text);

        //tot9 = tot7 - tot8;

       // lbl_stockadj.Text =  (tot9 - Convert.ToDecimal( lbl_stock.Text)).ToString();

    }
    protected void fill()
    {

        string Branch = Session["Branch"].ToString();

        //string param = "@partno,@Branch";
      
        //string paramvalue = txt_part.Text.Trim() + "," + Branch ;
        //DataTable dt = dbaccess.SPReturnDataTable("Parttracking", param, paramvalue);
        string[] param = { "@partno","@Branch" };

        string[] paramvalue = { txt_part.Text.Trim(), Branch };

        DataTable dt = smitaDbAccess.SPReturnDataTable1("partTracking", param, paramvalue);

        if (dt.Rows.Count > 0)
        {
           
            grd_pent.DataSource = dt;
            grd_pent.DataBind();
            foreach (GridViewRow gr in grd_pent.Rows)
            {

                Label lbl_qty = (Label)gr.FindControl("lbl_qty");

                decimal qty = Convert.ToDecimal(lbl_qty.Text);

                tot = tot + qty;

                Label lbl_fwamu = (Label)grd_pent.FooterRow.FindControl("lbl_ftwpentry");
                lbl_fwamu.Text = tot.ToString("0.00");
                lbl_pshow.Text = tot.ToString("0.00");

            }
        }

        else

        {
            grd_pent.DataSource = null;
            grd_pent.DataBind();
       
        
        }




    }

    protected void fill1()
    {

        string Branch = Session["Branch"].ToString();

        //string param = "@partno,@Branch";

        //string paramvalue = txt_part.Text.Trim() + "," + Branch;
        //DataTable dt = dbaccess.SPReturnDataTable("partTracking1", param, paramvalue);

        string[] param = { "@partno","@Branch" };

        string[] paramvalue = { txt_part.Text.Trim(), Branch };

        DataTable dt = smitaDbAccess.SPReturnDataTable1("partTracking1", param, paramvalue);

        if (dt.Rows.Count > 0)
        {
           
            GridView1.DataSource = dt;
            GridView1.DataBind();
            foreach (GridViewRow gr in GridView1.Rows)
            {

                Label lbl_qty1 = (Label)gr.FindControl("lbl_qty1");

                decimal qty1 = Convert.ToDecimal(lbl_qty1.Text);

                tot1 = tot1 + qty1;

                Label lbl_fwtp = (Label)GridView1.FooterRow.FindControl("lbl_ftwpTransfer");
                lbl_fwtp.Text = tot1.ToString("0.00");

                lbl_stocktrans.Text = tot1.ToString("0.00");
            }
        }

        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();


        }
       

    }

    protected void fill2()
    {

        string Branch = Session["Branch"].ToString();

        //string param = "@partno,@Branch";

        //string paramvalue = txt_part.Text.Trim() + "," + Branch;
        //DataTable dt = dbaccess.SPReturnDataTable("partTracking2", param, paramvalue);

        string[] param = { "@partno","@Branch" };

        string[] paramvalue = { txt_part.Text.Trim(), Branch };

        DataTable dt = smitaDbAccess.SPReturnDataTable1("partTracking2", param, paramvalue);

        if (dt.Rows.Count > 0)
        {
           
            GridView2.DataSource = dt;
            GridView2.DataBind();
            foreach (GridViewRow gr in GridView2.Rows)
            {

                Label lbl_qty2 = (Label)gr.FindControl("lbl_qty2");

                decimal qty2 = Convert.ToDecimal(lbl_qty2.Text);

                tot2 = tot2 + qty2;

                Label lbl_fwcs = (Label)GridView2.FooterRow.FindControl("lbl_ftwpcounterSaleetry");
                lbl_fwcs.Text = tot2.ToString("0.00");
                lbl_countersale.Text = tot2.ToString("0.00");

            }
        }

        else
        {
            GridView2.DataSource = null;
            GridView2.DataBind();


        }


    }


    protected void fill3()
    {

        string Branch = Session["Branch"].ToString();

        //string param = "@partno,@Branch";

        //string paramvalue = txt_part.Text.Trim() + "," + Branch;
        //DataTable dt = dbaccess.SPReturnDataTable("Parttracking3", param, paramvalue);

        string[] param = { "@partno","@Branch" };

        string[] paramvalue = { txt_part.Text.Trim(), Branch };

        DataTable dt = smitaDbAccess.SPReturnDataTable1("partTracking3", param, paramvalue);

        if (dt.Rows.Count > 0)
        {
            

            GridView3.DataSource = dt;
            GridView3.DataBind();
            foreach (GridViewRow gr in GridView3.Rows)
            {

                Label lbl_qty11 = (Label)gr.FindControl("lbl_qty11");

                decimal qty3 = Convert.ToDecimal(lbl_qty11.Text);

                tot3 = tot3 + qty3;

                Label lbl_fwis = (Label)GridView3.FooterRow.FindControl("lbl_ftwpIssueetry");
                lbl_fwis.Text = tot3.ToString("0.00");
                lbl_spareissue.Text = tot3.ToString("0.00");

            }
        }

        else
        {
            GridView3.DataSource = null;
            GridView3.DataBind();


        }


    }

    protected void fill4()
    {

        string Branch = Session["Branch"].ToString();

        //string param = "@partno,@Branch";

        //string paramvalue = txt_part.Text.Trim() + "," + Branch;
        //DataTable dt = dbaccess.SPReturnDataTable("Parttracking4", param, paramvalue);

        string[] param = { "@partno","@Branch" };

        string[] paramvalue = { txt_part.Text.Trim(), Branch };

        DataTable dt = smitaDbAccess.SPReturnDataTable1("partTracking4", param, paramvalue);

        if (dt.Rows.Count > 0)
        {
           
            GridView4.DataSource = dt;
            GridView4.DataBind();
            foreach (GridViewRow gr in GridView4.Rows)
            {

                Label lbl_ret4 = (Label)gr.FindControl("lbl_ret4");

                decimal qty4 = Convert.ToDecimal(lbl_ret4.Text);

                tot4 = tot4 + qty4;

                Label lbl_fwise = (Label)GridView4.FooterRow.FindControl("lbl_ftwpseretry");
                lbl_fwise.Text = tot4.ToString("0.00");

                lbl_serissret.Text = tot4.ToString("0.00");
            }
        }

        else
        {
            GridView4.DataSource = null;
            GridView4.DataBind();


        }


    }

    protected void fill5()
    {

        string Branch = Session["Branch"].ToString();

        //string param = "@partno,@Branch";

        //string paramvalue = txt_part.Text.Trim() + "," + Branch;
        //DataTable dt = dbaccess.SPReturnDataTable("Parttracking5", param, paramvalue);

        string[] param = { "@partno","@Branch" };

        string[] paramvalue = { txt_part.Text.Trim(), Branch };

        DataTable dt = smitaDbAccess.SPReturnDataTable1("partTracking5", param, paramvalue);

        if (dt.Rows.Count > 0)
        {
            
            GridView5.DataSource = dt;
            GridView5.DataBind();
            foreach (GridViewRow gr in GridView5.Rows)
            {

                Label lbl_ret5 = (Label)gr.FindControl("lbl_ret5");

                decimal qty5 = Convert.ToDecimal(lbl_ret5.Text);

                tot5 = tot5 + qty5;

                Label lbl_fwcsee = (Label)GridView5.FooterRow.FindControl("lbl_ftwpcounterslae1etry");
                lbl_fwcsee.Text = tot5.ToString("0.00");

                lbl_cousealret.Text = tot5.ToString("0.00");

            }
        }

        else
        {
            GridView5.DataSource = null;
            GridView5.DataBind();


        }


    }


    protected void fillStockadj()
    {

        string Branch = Session["Branch"].ToString();

        //string param = "@partno,@Branch";

        //string paramvalue = txt_part.Text.Trim() + "," + Branch;
        //DataTable dt = dbaccess.SPReturnDataTable("Parttracking5", param, paramvalue);

        string[] param = { "@partno", "@Branch" };

        string[] paramvalue = { txt_part.Text.Trim(), Branch };

        DataTable dt = smitaDbAccess.SPReturnDataTable1("sp_stock_adj_Report_Parttrack", param, paramvalue);

        if (dt.Rows.Count > 0)
        {

            GridView6.DataSource = dt;
            GridView6.DataBind();
        }

        else
        {
            GridView6.DataSource = null;
            GridView6.DataBind();
        }
    }

    protected void fillOpenStock()
    {

        string Branch = Session["Branch"].ToString();

        //string param = "@partno,@Branch";

        //string paramvalue = txt_part.Text.Trim() + "," + Branch;
        //DataTable dt = dbaccess.SPReturnDataTable("Parttracking5", param, paramvalue);

        string[] param = { "@partno", "@Branch" };

        string[] paramvalue = { txt_part.Text.Trim(), Branch };

        DataTable dt = smitaDbAccess.SPReturnDataTable1("sp_openstockgetdetails", param, paramvalue);

        if (dt.Rows.Count > 0)
        {

            GridView7.DataSource = dt;
            GridView7.DataBind();
        }

        else
        {
            GridView7.DataSource = null;
            GridView7.DataBind();
        }
    }
    protected void fillpurchasereturn()
    {

        string Branch = Session["Branch"].ToString();

        //string param = "@partno,@Branch";

        //string paramvalue = txt_part.Text.Trim() + "," + Branch;
        //DataTable dt = dbaccess.SPReturnDataTable("Parttracking5", param, paramvalue);

        string[] param = { "@partno", "@Branch" };

        string[] paramvalue = { txt_part.Text.Trim(), Branch };

        DataTable dt = smitaDbAccess.SPReturnDataTable1("sp_purchasereturn", param, paramvalue);

        if (dt.Rows.Count > 0)
        {

            GridView8.DataSource = dt;
            GridView8.DataBind();
        }

        else
        {
            GridView8.DataSource = null;
            GridView8.DataBind();
        }
    }

    protected void fillStockintransfer()
    {

        string Branch = Session["Branch"].ToString();

        string[] param = { "@partno", "@Branch" };

        string[] paramvalue = { txt_part.Text.Trim(), Branch };

        DataTable dt = smitaDbAccess.SPReturnDataTable1("sp_brachstock_in_transfer", param, paramvalue);

        if (dt.Rows.Count > 0)
        {

            GridView9.DataSource = dt;
            GridView9.DataBind();
            foreach (GridViewRow gr in GridView9.Rows)
            {

                Label lbl_rettrin = (Label)gr.FindControl("lbl_retsindsf");

                decimal qty101 = Convert.ToDecimal(lbl_rettrin.Text);

                tot101 = tot101 + qty101;

                Label lbl_fwisesin = (Label)GridView9.FooterRow.FindControl("lbl_ftwpcounterslae1etrysin");
                lbl_fwisesin.Text = tot101.ToString("0.00");
                
            }
        }

        else
        {
            GridView9.DataSource = null;
            GridView9.DataBind();


        }


    }
}