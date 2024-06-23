using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Data;
public partial class Admin_ServiceEstimation : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Panel2.Style.Add(HtmlTextWriterStyle.Display, "none");
        }
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        if (txt_estimationno.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Estimation No shouldnot bE blank..!!'); </script>", false);
            txt_estimationno.Focus();
            return;
        }
        string branchname = Session["Branch"].ToString();
        int id = Convert.ToInt32(txt_estimationno.Text);
        var SalesList = from c in db.AME_Service_EstimateEntryDetails.Where(t => t.Se_EstimateNo == id && t.Branch_Name == branchname)
                        select c;
        if (Convert.ToInt32(SalesList.Count()) > 0)
        {
            Panel2.Style.Add(HtmlTextWriterStyle.Display, "show");
            string Branch = Session["Branch"].ToString();

            int sino = Convert.ToInt32(txt_estimationno.Text);
            string param = "@Branch,@EstimationNo";

            string paramvalue = Branch + "," + sino;

            DataSet ds = smitaDbAccess.SPReturnDataSet("sp_JobEsimation", param, paramvalue);
            lblestimationno.Text = ds.Tables[0].Rows[0]["Se_EstimateNo"].ToString();
            lbldate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Se_EstimateDate"]).ToString("dd/MMM/yyyy");
            lblname.Text = ds.Tables[0].Rows[0]["Mc_Name"].ToString();
            lbladdress.Text = ds.Tables[0].Rows[0]["Mc_Address"].ToString();
            lblpinno.Text = ds.Tables[0].Rows[0]["Mc_Pinno"].ToString();
            lblphoneno.Text = ds.Tables[0].Rows[0]["Mc_Mobileno"].ToString();
            lblregno.Text = ds.Tables[0].Rows[0]["Se_RegdNo"].ToString();
            lblchassisno.Text = ds.Tables[0].Rows[0]["Se_ChasisNo"].ToString();
            lblmodelname.Text = ds.Tables[0].Rows[0]["Mv_ModelName"].ToString();
            lblengineno.Text = ds.Tables[0].Rows[0]["Se_EngineNo"].ToString();
            lblkilomtr.Text = ds.Tables[0].Rows[0]["Se_Kilometer"].ToString();


            GridView1.DataSource = ds.Tables[1];
            GridView1.DataBind();

            GridView3.DataSource = ds.Tables[2];
            GridView3.DataBind();

            lblgross.Text = ds.Tables[0].Rows[0]["Se_ServiceGrossAmount"].ToString();
            //lbldiscountpercent.Text = ds.Tables[0].Rows[0]["Se_ServiceDiscountPer"].ToString();
            lbldiscount.Text = ds.Tables[0].Rows[0]["Se_ServiceDiscountAmt"].ToString();
            lblnetamount.Text = ds.Tables[0].Rows[0]["Se_ServiceNetAmount"].ToString();
            lblspareamount.Text = ds.Tables[0].Rows[0]["Se_TotalSpareAmount"].ToString();
            //lbl_tdiscper.Text = ds.Tables[0].Rows[0]["Se_TotalDiscountPerSpare"].ToString();
            //lbl_tdisc.Text = ds.Tables[0].Rows[0]["Se_TotalDiscountSpare"].ToString();
            //lbl_Gspareamount.Text = ds.Tables[0].Rows[0]["Se_GTotalOfSpare"].ToString();

            lbllabourcharge.Text = ds.Tables[0].Rows[0]["Se_LabourCharges"].ToString();
            lbllbrdiscount.Text = ds.Tables[0].Rows[0]["Se_LabourDiscountPer"].ToString();
            lbldiscountamount.Text = ds.Tables[0].Rows[0]["Se_LabourDiscountAmount"].ToString();
            lblstax.Text = ds.Tables[0].Rows[0]["Se_ServiceTaxAmount"].ToString();
            lbllabourchargeafterdiscount.Text = ds.Tables[0].Rows[0]["Se_LabourCharges"].ToString();
            lblvat.Text = ds.Tables[0].Rows[0]["Se_VatAmount"].ToString();
            lbltotal.Text = ds.Tables[0].Rows[0]["totalamount"].ToString();
            lblothercharg.Text = ds.Tables[0].Rows[0]["Se_OtherCharges"].ToString();
            lbltnetamount.Text = ds.Tables[0].Rows[0]["Se_BillAmount"].ToString();
            if (Session["Branch"].ToString() == "Cuttack")
            {
                td_esti.Visible = true;
            }
            else if (Session["Branch"].ToString() == "Paradeep")
            {
                td_anugul.Visible = true;
            }
            else if (Session["Branch"].ToString() == "Berhampur")
            {
                td_bam.Visible = true;
            }
            else 
            {
                td_phul.Visible = true;
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invalid Estimation No..!!'); </script>", false);
            
            Panel2.Style.Add(HtmlTextWriterStyle.Display, "none");

            txt_estimationno.Text = "";

            return;
        }
    }
}