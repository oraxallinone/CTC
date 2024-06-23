using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
public partial class Admin_Master_MachineRegstration : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    Clear cl = new Clear();
    public string BName;
    static List<Adddetails> modeldescription = new List<Adddetails>();
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Usertype"] == null || Session["Branch"] == null)
            {
                Response.Write("<script>alert('Your Session Time is Expired..!! Login to continue..!!')</script>");
                Response.Redirect("../SessionExpired.aspx");
            }
            txtdate.Text =SmitaClass.IndianTime().ToString("dd/MM/yyyy");

            fillsino();

            string branchname = Session["Branch"].ToString();
            string uid = Convert.ToString(Session["Uid"]);
            modeldescription.RemoveAll(t => t.userid == uid && t.branch == branchname);
        }
    }
    public void fillgrid()
    {
        string uid = Convert.ToString(Session["Uid"]);
        string branchname = Session["Branch"].ToString();
        GridView1.DataSource = modeldescription.ToList().Where(t => t.userid == uid && t.branch==branchname);
        GridView1.DataBind();
    }
    public void fillsino()
    {
        string branchname = Session["Branch"].ToString();
        var sino = from c in db.AME_Vehicle_Quotation.Where(t=>t.Branch_Name==branchname).OrderBy(t => t.Vq_Id) select c;
        if (Convert.ToInt32(sino.Count()) > 0)
        {
            int lastno = ((int)(from c in db.AME_Vehicle_Quotation.Where(t => t.Branch_Name == branchname) select c.Vq_Id).Max()) + 1;
            txtsino.Text = Convert.ToString(lastno);
        }
        else
        {
            txtsino.Text = "1";
        }
    }
    public void fillModelno()
    {
        string Sale = Convert.ToString(Session["saletype"]);
        if (Session["saletype"] != null)
        {
            string branchname = Session["Branch"].ToString();
            var model = from c in db.AME_Master_VehicleModel.Where(t => t.Mv_VehicleType == ddl_VType.SelectedValue && t.Branch_Name == branchname && t.Mv_SaleStatus == Sale).OrderBy(t => t.Mv_Id)
                        select new
                        {
                            mid = c.Mv_Id,
                            mname = c.Mv_ModelName
                        };
            ddlmodel.DataSource = model.ToList();
            ddlmodel.DataValueField = "mid";
            ddlmodel.DataTextField = "mname";
            ddlmodel.DataBind();
            ddlmodel.Items.Insert(0, "..Select..");
        }
        else
        {
            string branchname = Session["Branch"].ToString();
            var model = from c in db.AME_Master_VehicleModel.Where(t => t.Mv_VehicleType == ddl_VType.SelectedValue && t.Branch_Name == branchname).OrderBy(t => t.Mv_Id)
                        select new
                        {
                            mid = c.Mv_Id,
                            mname = c.Mv_ModelName
                        };
            ddlmodel.DataSource = model.ToList();
            ddlmodel.DataValueField = "mid";
            ddlmodel.DataTextField = "mname";
            ddlmodel.DataBind();
            ddlmodel.Items.Insert(0, "..Select..");
        }

    }
 
   
    private void SetTextBoxReadOnly<T>(Control parent, bool readOnly) where T : TextBox
    {
        foreach (var tb in parent.Controls.OfType<T>())
            tb.ReadOnly = readOnly;

        foreach (Control c in parent.Controls)
            SetTextBoxReadOnly<T>(c, readOnly);
    }
   

  
    protected void btn_cancel_Click(object sender, EventArgs e)
    {

        cl.Clear_All(this);
       
    }


    protected void btnSBAdd_Click(object sender, EventArgs e)
    {
        try
        {

            if (ddl_VType.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Vehicle Type..!!!');</script>", false);
                ddl_VType.Focus();
                return;
            }
            if (ddlmodel.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Model Type..!!!');</script>", false);
                ddlmodel.Focus();
                return;
            }

            if (txt_rate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Rate SHOULD NOT BE BLANK..!!!');</script>", false);
                txt_rate.Focus();
                return;
            }
            if (txt_quantity.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Quantity SHOULD NOT BE BLANK..!!!');</script>", false);
                txt_quantity.Focus();
                return;
            }
            if (txt_discount.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Discount SHOULD NOT BE BLANK..!!!');</script>", false);
                txt_quantity.Focus();
                return;
            }
            if (txt_netamount.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('NetAmount SHOULD NOT BE BLANK..!!!');</script>", false);
                txt_quantity.Focus();
                return;
            }
              var v = from c in modeldescription.OrderBy(t => t.sino) select c;
            if (Convert.ToInt32(v.Count()) > 0)
            {
                id = (int)(from c in modeldescription select c.sino).Max();
                id = id + 1;

            }
            else
            {
                id = 1;

            }
        
            Adddetails ad=new Adddetails();
            ad.sino=id;
            ad.rate=Convert.ToDecimal(txt_rate.Text);
            ad.quantity=Convert.ToDecimal(txt_quantity.Text);
            ad.amount=Convert.ToDecimal(txt_amount.Text);
            ad.modelname=ddlmodel.SelectedItem.Text;
            ad.mvalue =Convert.ToInt32(ddlmodel.SelectedValue);
            ad.userid = Convert.ToString(Session["Uid"]);
            ad.branch = Convert.ToString(Session["Branch"]);
            ad.discount = Convert.ToDecimal(txt_discount.Text);
            ad.netquantity = Convert.ToDecimal(txt_netamount.Text);
            ad.discountamount = Convert.ToDecimal(txt_discountamount.Text);
            ad.vehicletype = ddl_VType.SelectedItem.Text;
            modeldescription.Add(ad);
            fillgrid();
            txt_amount.Text =" 0";
            txt_quantity.Text ="0";
            txt_rate.Text ="0";
            txt_discount.Text = "0";
            txt_netamount.Text = "0";
            txt_discountamount.Text = "0";
            
            fillModelno();

        }
            catch
        {
            }
        }
     
    
    public class Adddetails
    {
        public string modelname { get; set; }
        public decimal rate { get; set; }
        public decimal quantity { get; set; }
        public decimal amount { get; set; }
        public int sino { get; set; }
        public int mvalue { get; set; }
        public string userid { get; set; }
        public decimal discount { get; set; }
        public decimal netquantity { get; set; }
        public decimal discountamount { get; set; }
        public string vehicletype { get; set; }
        public string branch { get; set; }
      
    }
    protected void imgbtn_SBDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        int img1 = Convert.ToInt32(img.ToolTip);
        string branchname = Session["Branch"].ToString();
        modeldescription.RemoveAll(t => t.sino == img1 && t.branch==branchname);
        fillgrid();
     
    }
    //search Text
    
      [System.Web.Services.WebMethod]
    
    public static string[] GetTagNames(string prefixText, int count)
    {

        string br = Convert.ToString(HttpContext.Current.Session["Branch"]);
        string Sale = Convert.ToString(HttpContext.Current.Session["saletype"]);
        if (HttpContext.Current.Session["saletype"]!=null)
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
    protected void btn_assign_Click(object sender, EventArgs e)
    {
        try
        {
            
            if (txtsino.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Serial No SHOULD NOT BE BLANK..!!!');</script>", false);
                txtsino.Focus();
                return;
            }
            if (txtdate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Date SHOULD NOT BE BLANK..!!!');</script>", false);
                txtdate.Focus();
                return;
            }
         
            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy", "dd-MM-yyyy" };
            DateTime expectedDate;
            if (!DateTime.TryParseExact(txtdate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                txtdate.Focus();
                return;
            }
            if (txtpartyname.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Party Name SHOULD NOT BE BLANK..!!!');</script>", false);
                txtpartyname.Focus();
                return;
            }
            if (txtaddress.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Address Should Not Be Blank..!!!');</script>", false);
                txtaddress.Focus();
                return;
            }
            if (txtphoneno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Phone No Should Not Be Blank..!!!');</script>", false);
                txtphoneno.Focus();
                return;
            }
            var v = from c in modeldescription.OrderBy(t => t.sino) select c;
            if (Convert.ToInt32(v.Count()) <= 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Add The Model Details..!!');</script>", false);
                ddlmodel.Focus();
                return;
            }
           foreach (GridViewRow gr in GridView1.Rows)
           {
               Label lblvechiletype = (Label)gr.FindControl("lblvechiletype");
               string vehicletype = lblvechiletype.Text;

               Label lblmodelname=(Label)gr.FindControl("lblmodelname");
               int model=Convert.ToInt32(lblmodelname.ToolTip);

               Label lblrate=(Label)gr.FindControl("lblrate");
               decimal rate=Convert.ToDecimal(lblrate.Text);

               Label lblquantity=(Label)gr.FindControl("lblquantity");
               decimal quantity=Convert.ToDecimal(lblquantity.Text);

               Label lblamount = (Label)gr.FindControl("lblamount");
               decimal amount = Convert.ToDecimal(lblamount.Text);

               Label lbldiscount = (Label)gr.FindControl("lbldiscount");
               decimal discount = Convert.ToDecimal(lbldiscount.Text);

               Label lblnetamount = (Label)gr.FindControl("lblnetamount");
               decimal netamount = Convert.ToDecimal(lblnetamount.Text);

               Label lbldiscountamount = (Label)gr.FindControl("lbldiscountamount");
               decimal discountamount = Convert.ToDecimal(lbldiscountamount.Text);

               AME_Vehicle_QuotationList aql = new AME_Vehicle_QuotationList();
               aql.Mv_Id = model;
               aql.Vq_Id =Convert.ToInt32(txtsino.Text);
               aql.Vql_Quantity = quantity;
               aql.Vql_Rate = rate;
               aql.Vql_Status = true;
               aql.Vql_Amount = amount;
               aql.Vql_discount = discount;
               aql.Vql_netamount = netamount;
               aql.Vql_NerQuantity = quantity;
               aql.Mv_VehicleType = vehicletype;
               aql.Vql_discountAmount = discountamount;
               aql.Branch_Name = Session["Branch"].ToString();
               aql.Created_By = Session["Uid"].ToString();
               aql.Created_Date = Convert.ToDateTime(txtdate.Text, SmitaClass.dateformat());
               db.AddToAME_Vehicle_QuotationList(aql);
              
               db.SaveChanges();
               }
            AME_Vehicle_Quotation vq = new AME_Vehicle_Quotation();
            vq.Branch_Name = Session["Branch"].ToString();
            vq.Created_By = Session["Uid"].ToString();
            vq.Vq_Address = txtaddress.Text;
            vq.Vq_Id = Convert.ToInt32(txtsino.Text);
            vq.Vq_Date = Convert.ToDateTime(txtdate.Text,SmitaClass.dateformat());
            vq.Vq_PartyName = txtpartyname.Text;
            vq.Vq_Phone = txtphoneno.Text;
            vq.Vq_Status = true;
            vq.Vq_refno = txt_referenceno.Text;
            vq.Created_Date = SmitaClass.IndianTime();
            db.AddToAME_Vehicle_Quotation(vq);

           

            db.SaveChanges();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Data Added Sucessfully..!!!');</script>", false);
            //cl.Clear_All(this);
            modeldescription.RemoveAll(t => t.modelname != "");
            GridView1.DataSource = null;
            GridView1.DataBind();
            //fillsino();
            txtdate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
            txt_amount.Text = " 0";
            txt_quantity.Text = "0";
            txt_rate.Text = "0";
            txt_discount.Text = "0";
            txt_netamount.Text = "0";

            Session["sino"] = txtsino.Text;
            Response.Redirect("Vehicle_PrintQuotation.aspx");
           
              }
        catch
        {

        }
    }
    protected void txtpartyname_TextChanged(object sender, EventArgs e)
    {
        var Custdetails = from c in db.AME_Master_Customer.ToList().Where(t => t.Mc_Name == txtpartyname.Text && t.Branch_Name == Session["Branch"].ToString()) select c;
        if (Convert.ToInt32(Custdetails.Count()) > 0)
        {
            txtaddress.Text = Custdetails.First().Mc_Address;
            txtphoneno.Text = Custdetails.First().Mc_Mobileno;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('First Registerd The Customer..!!!');</script>", false);
            txtpartyname.Text = "";
            txtpartyname.Focus();
        }
    }
    protected void ddlmodel_SelectedIndexChanged(object sender, EventArgs e)
    {
        string branchname = Session["Branch"].ToString();
        var Custdetails = from c in db.AME_Master_VehicleModel.ToList().Where(t => t.Mv_ModelName == ddlmodel.SelectedItem.Text && t.Branch_Name==branchname) select c;
        txt_rate.Text = Convert.ToString(Custdetails.First().Mv_Rate);
        txt_quantity.Focus();
    }
    protected void ddl_VType_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillModelno();
    }
}