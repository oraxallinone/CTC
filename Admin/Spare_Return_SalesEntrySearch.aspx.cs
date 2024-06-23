using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
using System.Data;

public partial class admin_StockMaster : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    public string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            //FillGrid();
        }
    }
    //search partyname
    [System.Web.Services.WebMethod]

    public static string[] GetTagNames(string prefixText, int count)
    {

        
        string br = Convert.ToString(HttpContext.Current.Session["Branch"]);
        string Sale = Convert.ToString(HttpContext.Current.Session["saletype"]);
        if (HttpContext.Current.Session["saletype"] != null)
        {
            AutoMobileEntities db = new AutoMobileEntities();

            return db.AME_Master_Customer.Where(n => n.Mc_Name.StartsWith(prefixText) && n.Branch_Name == br && n.Mc_SaleStatus==Sale).OrderBy(n => n.Mc_Name).Select(n => n.Mc_Name).Distinct().Take(count).ToArray();

        }
        else
        {
            AutoMobileEntities db = new AutoMobileEntities();

            return db.AME_Master_Customer.Where(n => n.Mc_Name.StartsWith(prefixText) && n.Branch_Name == br).OrderBy(n => n.Mc_Name).Select(n => n.Mc_Name).Distinct().Take(count).ToArray();

        }
        
    }
    [System.Web.Services.WebMethod]
    public static string[] GetServiceCode(string prefixText, int count)
    {
        string Branch = HttpContext.Current.Session["Branch"].ToString();

        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Spare_SaleReturn.Where(n => n.Sp_InvoiceNo.Contains(prefixText)).Where(n => n.Branch_Name == Branch).OrderBy(n => n.SR_id).Select(n => n.Sp_InvoiceNo).Distinct().Take(count).ToArray();

    }

  



    protected void btn_Show_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_bilno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('From Date SHOULD NOT BE BLANK...!!');", true);
                txt_bilno.Focus();
                return;
            }
            if (txtpartyname.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('To Date SHOULD NOT BE BLANK...!!');", true);
                txtpartyname.Focus();
                return;
            }
            string Branch = Session["Branch"].ToString();
            var v = from c in db.AME_Spare_SaleReturn.ToList().Where(t => t.Branch_Name == Branch && t.Sp_InvoiceNo == txt_bilno.Text && t.Sp_PartyCode == txtpartyname.ToolTip) select c;
            if (Convert.ToInt32(v.Count()) > 0)
            {
                var SR =(AME_Spare_SaleReturn) v.ToArray()[0];
                string spid = SR.Sp_Id.ToString();
                //Response.Redirect("Spare_SalesReturnPrint.aspx?id=" + txt_bilno.Text + "");
                Response.Redirect("Spare_SalesReturnPrint.aspx?id=" + spid + "");
            }

        }
        catch
        {

        }
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgview = (ImageButton)sender;
        int sino = Convert.ToInt32(imgview.ToolTip);



    }


    protected void txt_bilno_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string branchname = Session["Branch"].ToString();
            var partyname = from c in db.AME_Spare_SaleReturn
                            join d in db.AME_Master_Customer on c.Sp_PartyCode equals d.Mc_code
                            where c.Sp_InvoiceNo == txt_bilno.Text && c.Branch_Name == branchname
                            select new
                            {
                                cnm = d.Mc_Name,
                                cid = d.Mc_code
                            };
            txtpartyname.Text = partyname.First().cnm;
            txtpartyname.ToolTip = partyname.First().cid;
        }
        catch (Exception)
        {
            
           // throw;
        }
      
    }
}