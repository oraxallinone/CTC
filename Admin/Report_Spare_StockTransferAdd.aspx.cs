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
using System.Data;
using System.Data.SqlClient;

public partial class Admin_Report_Spare_StockTransferAdd : System.Web.UI.Page
{
    List<StockAddedByTransfer> st = new List<StockAddedByTransfer>();
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




    public class StockAddedByTransfer
    {
        public string Voucher_No { get; set; }
        public string Itm_Partno { get; set; }
        public string Itm_PartDesc { get; set; }
        public string St_TransferQuantity { get; set; }
        public string St_Rate { get; set; }
        public string St_Amount { get; set; }
        public string St_Transferdate { get; set; }
        public string St_FromBranch { get; set; }
        public string St_ToBranch { get; set; }

    }

    private void getdataAllBranch()
    {
        string Branch = Session["Branch"].ToString();
        string fromDate= Convert.ToDateTime(txt_FromDate.Text, SmitaClass.dateformat()).ToString("yyyy-MM-dd HH:mm:ss");
        string toDate=Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat()).ToString("yyyy-MM-dd HH:mm:ss");





        //Cuttack connection
        string strConCtc = "data source=198.71.227.2;initial catalog=R2_Cuttack;uid=uCuttack1;pwd=pwd_Ctc2018;";
        DataTable dtctc = new DataTable();
        SqlConnection conCtc = new SqlConnection(strConCtc);
        conCtc.Open();
        SqlCommand cmdCtc = new SqlCommand("select se.St_Transferdate, se.Itm_Partno, se.St_TransferQuantity, se.St_FromBranch, se.St_ToBranch, se.Itm_PartDesc, se.St_Rate, se.St_Amount, se.Voucher_No from dbo.AME_SparepartsTransfer as se  where se.St_Transferdate >='" + fromDate + "'  and se.St_Transferdate<='" + toDate + "' and se.St_ToBranch='Paradeep'", conCtc);
        SqlDataAdapter daCtc = new SqlDataAdapter(cmdCtc);
        daCtc.Fill(dtctc);
        if (dtctc.Rows.Count > 0)
        {
            for (int i = 0; i < dtctc.Rows.Count; i++)
            {
                StockAddedByTransfer stockinfo = new StockAddedByTransfer();
                stockinfo.Voucher_No = dtctc.Rows[i]["Voucher_No"].ToString();
                stockinfo.Itm_Partno = dtctc.Rows[i]["Itm_Partno"].ToString();
                stockinfo.Itm_PartDesc = dtctc.Rows[i]["Itm_PartDesc"].ToString();
                stockinfo.St_TransferQuantity = dtctc.Rows[i]["St_TransferQuantity"].ToString();
                stockinfo.St_Rate = dtctc.Rows[i]["St_Rate"].ToString();
                stockinfo.St_Amount = dtctc.Rows[i]["St_Amount"].ToString();
                stockinfo.St_Transferdate = dtctc.Rows[i]["St_Transferdate"].ToString();
                stockinfo.St_FromBranch = dtctc.Rows[i]["St_FromBranch"].ToString();
                stockinfo.St_ToBranch = dtctc.Rows[i]["St_ToBranch"].ToString();
                st.Add(stockinfo);
            }
        }





        //Phul connection
        string strConPhul = "data source=198.71.227.2;initial catalog=R2_Phul;uid=uPhul1;pwd=pwd_Phul2018;";
        DataTable dtPhul = new DataTable();
        SqlConnection conPhul = new SqlConnection(strConPhul);
        conPhul.Open();
        SqlCommand cmdPhul = new SqlCommand("select se.St_Transferdate, se.Itm_Partno, se.St_TransferQuantity, se.St_FromBranch, se.St_ToBranch, se.Itm_PartDesc, se.St_Rate, se.St_Amount, se.Voucher_No from dbo.AME_SparepartsTransfer as se  where se.St_Transferdate >='" + fromDate + "'  and se.St_Transferdate<='" + toDate + "' and se.St_ToBranch='Paradeep'", conPhul);
        SqlDataAdapter daPhul = new SqlDataAdapter(cmdPhul);
        daPhul.Fill(dtPhul);
        if (dtPhul.Rows.Count > 0)
        {
            for (int i = 0; i < dtPhul.Rows.Count; i++)
            {
                StockAddedByTransfer stockinfo = new StockAddedByTransfer();
                stockinfo.Voucher_No = dtPhul.Rows[i]["Voucher_No"].ToString();
                stockinfo.Itm_Partno = dtPhul.Rows[i]["Itm_Partno"].ToString();
                stockinfo.Itm_PartDesc = dtPhul.Rows[i]["Itm_PartDesc"].ToString();
                stockinfo.St_TransferQuantity = dtPhul.Rows[i]["St_TransferQuantity"].ToString();
                stockinfo.St_Rate = dtPhul.Rows[i]["St_Rate"].ToString();
                stockinfo.St_Amount = dtPhul.Rows[i]["St_Amount"].ToString();
                stockinfo.St_Transferdate = dtPhul.Rows[i]["St_Transferdate"].ToString();
                stockinfo.St_FromBranch = dtPhul.Rows[i]["St_FromBranch"].ToString();
                stockinfo.St_ToBranch = dtPhul.Rows[i]["St_ToBranch"].ToString();
                st.Add(stockinfo);
            }
        }




        //Berham connection
        string strConBerhm = "data source=198.71.227.2;initial catalog=R2_Berhm;uid=uBerhm1;pwd=pwd_Berhm2018;";
        DataTable dtBerhm = new DataTable();
        SqlConnection conBerhm = new SqlConnection(strConBerhm);
        conBerhm.Open();
        SqlCommand cmdBerhm = new SqlCommand("select se.St_Transferdate, se.Itm_Partno, se.St_TransferQuantity, se.St_FromBranch, se.St_ToBranch, se.Itm_PartDesc, se.St_Rate, se.St_Amount, se.Voucher_No from dbo.AME_SparepartsTransfer as se  where se.St_Transferdate >='" + fromDate + "'  and se.St_Transferdate<='" + toDate + "' and se.St_ToBranch='Paradeep'", conBerhm);
        SqlDataAdapter daBerhm = new SqlDataAdapter(cmdBerhm);
        daBerhm.Fill(dtBerhm);
        if (dtBerhm.Rows.Count > 0)
        {
            for (int i = 0; i < dtBerhm.Rows.Count; i++)
            {
                StockAddedByTransfer stockinfo = new StockAddedByTransfer();
                stockinfo.Voucher_No = dtBerhm.Rows[i]["Voucher_No"].ToString();
                stockinfo.Itm_Partno = dtBerhm.Rows[i]["Itm_Partno"].ToString();
                stockinfo.Itm_PartDesc = dtBerhm.Rows[i]["Itm_PartDesc"].ToString();
                stockinfo.St_TransferQuantity = dtBerhm.Rows[i]["St_TransferQuantity"].ToString();
                stockinfo.St_Rate = dtBerhm.Rows[i]["St_Rate"].ToString();
                stockinfo.St_Amount = dtBerhm.Rows[i]["St_Amount"].ToString();
                stockinfo.St_Transferdate = dtBerhm.Rows[i]["St_Transferdate"].ToString();
                stockinfo.St_FromBranch = dtBerhm.Rows[i]["St_FromBranch"].ToString();
                stockinfo.St_ToBranch = dtBerhm.Rows[i]["St_ToBranch"].ToString();
                st.Add(stockinfo);
            }
        }








        //Paradeep connection
        string strConParadeep = "data source=198.71.227.2;initial catalog=R2_Paradeep;uid=uParadeep1;pwd=pwd_Berhm2018;";
        DataTable dtParadeep = new DataTable();
        SqlConnection conParadeep = new SqlConnection(strConParadeep);
        conParadeep.Open();
        SqlCommand cmdParadeep = new SqlCommand("select se.St_Transferdate, se.Itm_Partno, se.St_TransferQuantity, se.St_FromBranch, se.St_ToBranch, se.Itm_PartDesc, se.St_Rate, se.St_Amount, se.Voucher_No from dbo.AME_SparepartsTransfer as se  where se.St_Transferdate >='" + fromDate + "'  and se.St_Transferdate<='" + toDate + "' and se.St_ToBranch='Paradeep'", conParadeep);
        SqlDataAdapter daParadeep = new SqlDataAdapter(cmdParadeep);
        daParadeep.Fill(dtParadeep);
        if (dtParadeep.Rows.Count > 0)
        {
            for (int i = 0; i < dtParadeep.Rows.Count; i++)
            {
                StockAddedByTransfer stockinfo = new StockAddedByTransfer();
                stockinfo.Voucher_No = dtParadeep.Rows[i]["Voucher_No"].ToString();
                stockinfo.Itm_Partno = dtParadeep.Rows[i]["Itm_Partno"].ToString();
                stockinfo.Itm_PartDesc = dtParadeep.Rows[i]["Itm_PartDesc"].ToString();
                stockinfo.St_TransferQuantity = dtParadeep.Rows[i]["St_TransferQuantity"].ToString();
                stockinfo.St_Rate = dtParadeep.Rows[i]["St_Rate"].ToString();
                stockinfo.St_Amount = dtParadeep.Rows[i]["St_Amount"].ToString();
                stockinfo.St_Transferdate = dtParadeep.Rows[i]["St_Transferdate"].ToString();
                stockinfo.St_FromBranch = dtParadeep.Rows[i]["St_FromBranch"].ToString();
                stockinfo.St_ToBranch = dtParadeep.Rows[i]["St_ToBranch"].ToString();
                st.Add(stockinfo);
            }
        }



        conPhul.Close();
        conParadeep.Close();
        conPhul.Close();
        conCtc.Close();
    }

    
    
    
    
    

    
    
    
    
    
    
    
    public void FillGrid()
    {


        getdataAllBranch();


        var Listcount = from s in st.ToList() select s;




        if (Listcount.Count() > 0)
        {
            GridView1.DataSource = st.ToList();
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
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('" + txt_FromDate.Text + "  To  " + txt_ToDate.Text + "  No Data Are Found..!!');", true);
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