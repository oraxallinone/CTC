using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Data;
public partial class Admin_Form21 : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("AccessDenied.aspx");
            }
         
                string sino = Request.QueryString["id"];
               
                filldata(sino);           
            
        }
    }

    public void filldata(string sino)
    {
        try
        {
            string Branch = Session["Branch"].ToString();
            string sno =Request.QueryString["id"];
            string param = "@Branch,@inoiceno";

            string paramvalue = Branch + "," + sno;

            DataTable dtr = smitaDbAccess.SPReturnDataTable("Sp_Spare_ReturnPrint", param, paramvalue);
            if (Convert.ToInt32(dtr.Rows.Count) > 0)
            {
                lblpartyname.Text = dtr.Rows[0]["Mc_Name"].ToString();
                lblrsino.Text = dtr.Rows[0]["SR_id"].ToString();
                lbladdress.Text = dtr.Rows[0]["Mc_Address"].ToString();
                lblreturndate.Text = Convert.ToDateTime(dtr.Rows[0]["Sales_ReturnDate"]).ToString("dd/MM/yyyy");
                lblinvno.Text = dtr.Rows[0]["Sp_InvoiceNo"].ToString();
                lbldateofsale.Text = Convert.ToDateTime(dtr.Rows[0]["Sp_InvoiceDate"]).ToString("dd/MM/yyyy");
                
                grd_spare.DataSource = dtr;
                grd_spare.DataBind();
                decimal TotalCollection = 0;
                lblrupees.Visible = true;

                lblrupees.Text = "0";
                foreach (GridViewRow gr in grd_spare.Rows)
                {
                    Label txtTotal = (Label)gr.FindControl("lblnetamount");
                    decimal tot = Convert.ToDecimal(txtTotal.Text);
                    TotalCollection += tot;
                    ViewState["TotalCollection"] = TotalCollection;

                }
                lblrupees.Text = Convert.ToString(ViewState["TotalCollection"]);
               
            }
            var branchnm = from c in db.AME_Branch_Creation.Where(t => t.Branch_Name == Branch) select c;
            lblbranchaddress.Text = branchnm.First().Branch_Address;
            lblphno.Text = branchnm.First().Branch_PhoneNo;
            lblemail.Text = branchnm.First().Branch_Email;
            lbltinno.Text = branchnm.First().Branch_TIN;
        }
        catch
        {

        }
    }
   
    
   
}