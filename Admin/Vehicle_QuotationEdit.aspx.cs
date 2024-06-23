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
   
   
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Branch"] == null || Session["Uid"] == null || Session["Uname"] == null)
            {
                Response.Write("<script>alert('Your Session Time is Expired..!! Login to continue..!!')</script>");
                Response.Redirect("../SessionExpired.aspx");
            }
            string sino = Request.QueryString["id"];
            string type = Request.QueryString["Type"];
            if (type =="View")
            {
                filldata(sino,type);
                //fillgriddata(sino, type);
                SetTextBoxReadOnly<TextBox>(Master.FindControl("form1"), true);
                tbl_Product.Visible = false;
            }
            if (type == "Edit")
            {
                fillEdit(sino, type);
                //fillgridEditdata(sino, type);
                btn_PDSave.Visible = true;
                tbl_Product.Visible = true;
               
            }
          
           
        }
    }

    public void filldata(string sino, string type)
    {
        string branchname = Session["Branch"].ToString();
        int id = Convert.ToInt32(sino);
        var Quotation = from c in db.AME_Vehicle_Quotation.Where(t=>t.Vq_Id==id) select c;
        txtdate.Text = Quotation.First().Vq_Date.ToString("dd/MM/yyyy");
        txtpartyname.Text = Quotation.First().Vq_PartyName;
        txtphoneno.Text = Quotation.First().Vq_Phone;
        txtaddress.Text = Quotation.First().Vq_Address;
        txt_refno.Text = Quotation.First().Vq_refno;
        txtsino.Text = Convert.ToString(Quotation.First().Vq_Id);
        var details = (from c in db.AME_Vehicle_QuotationList
                       join d in db.AME_Master_VehicleModel on c.Mv_Id equals d.Mv_Id
                       where c.Vq_Id == id && c.Branch_Name == branchname
                       select new
                       {
                           c.Vql_Amount,
                           c.Vql_Rate,
                           c.Vql_Quantity,
                           c.Vql_id,
                           c.Mv_Id,
                           d.Mv_ModelName,
                           c.Vql_discount,
                           c.Vql_netamount,
                          c.Mv_VehicleType,
                          c.Vql_discountAmount,
                       }).ToList();

        GridView1.DataSource = details.ToList();
        GridView1.DataBind();
        foreach (GridViewRow gr in GridView1.Rows)
        {
            ImageButton edit = (ImageButton)gr.FindControl("imgbtn_Edit");
            ImageButton delete = (ImageButton)gr.FindControl("imgbtn_SBDelete");
            edit.Visible = false;
            delete.Visible = false;
                
        }
       
    }
  

    public void fillEdit(string sino, string type)
    {
        string branchname = Session["Branch"].ToString();
        int id = Convert.ToInt32(sino);
        var Quotation = from c in db.AME_Vehicle_Quotation.Where(t => t.Vq_Id == id) select c;
        txtdate.Text = Quotation.First().Vq_Date.ToString("dd/MM/yyyy");
        txtpartyname.Text = Quotation.First().Vq_PartyName;
        txtphoneno.Text = Quotation.First().Vq_Phone;
        txtaddress.Text = Quotation.First().Vq_Address;
        txtsino.Text = Convert.ToString(Quotation.First().Vq_Id);
        txt_refno.Text = Quotation.First().Vq_refno;
        btn_update.ToolTip = Convert.ToString(Quotation.First().Vq_Id);
        var details = (from c in db.AME_Vehicle_QuotationList
                       join d in db.AME_Master_VehicleModel on c.Mv_Id equals d.Mv_Id
                       where c.Vq_Id == id && c.Branch_Name == branchname
                       select new
                       {
                           c.Vql_Amount,
                           c.Vql_Rate,
                           c.Vql_Quantity,
                           c.Vql_id,
                           c.Mv_Id,
                           d.Mv_ModelName,
                           c.Vql_discount,
                           c.Vql_netamount,
                           c.Mv_VehicleType,
                           c.Vql_discountAmount
                       }).ToList();

        GridView1.DataSource = details.ToList();
        GridView1.DataBind();

    }
    //public void fillgridEditdata(string sino, string type)
    //{
    //    int id = Convert.ToInt32(sino);

    //    var details = (from c in db.AME_Vehicle_QuotationList
    //                   join d in db.AME_Master_VehicleModel on c.Mv_Id equals d.Mv_Id
    //                   where c.Vq_Id == id
    //                   select new
    //                   {
    //                       c.Vql_Amount,
    //                       c.Vql_Rate,
    //                       c.Vql_Quantity,
    //                       c.Vql_id,
    //                       c.Mv_Id,
    //                       d.Mv_ModelName
    //                   }).ToList();

    //    GridView1.DataSource = details.ToList();
    //    GridView1.DataBind();
       
    //}

  
    public void fillsino()
    {
        string branchname = Session["Branch"].ToString();
        var sino = from c in db.AME_Vehicle_Quotation.Where(t=>t.Branch_Name == branchname).OrderBy(t => t.Vq_Id) select c;
        if (Convert.ToInt32(sino.Count()) > 0)
        {
            int lastno =( (int)(from c in db.AME_Vehicle_Quotation select c.Vq_Id).Max())+1;
            txtsino.Text = Convert.ToString(lastno);
        }
        else
        {
            txtsino.Text = "1";
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
            
            fillsino();
            txtdate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
            txt_amount.Text = " 0";
            txt_quantity.Text = "0";
            txt_rate.Text = "0";
        
              }
        catch
        {

        }
    }
    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("Vehicle_QuotationDetailsDatewise.aspx");
    }
    protected void imgbtn_SBDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgdelete = (ImageButton)sender;
        string sino = (imgdelete.ToolTip);
        int id = Convert.ToInt32(sino);
        string branchname = Session["Branch"].ToString();
        AME_Vehicle_QuotationList vq = db.AME_Vehicle_QuotationList.ToList().First(t => t.Vql_id == id && t.Branch_Name==branchname) ;
        db.DeleteObject(vq);
        db.SaveChanges();
        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Data Deleted Sucessfully..!!');", true);

        string sino0 = Request.QueryString["id"];
        string type = Request.QueryString["Type"];
        filldata(sino0, type);
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
      
    }
    protected void imgbtn_Edit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string branchname = Session["Branch"].ToString();
            ImageButton imgbtnEdit = (ImageButton)sender;
            foreach (GridViewRow gr in GridView1.Rows)
            {
                gr.BackColor = System.Drawing.Color.Transparent;
            }

            GridViewRow row = imgbtnEdit.NamingContainer as GridViewRow;
            row.BackColor = System.Drawing.Color.Pink;

            string sino = (imgbtnEdit.ToolTip);
            int id = Convert.ToInt32(sino);
            var quotationlist = from c in db.AME_Vehicle_QuotationList.ToList().Where(t => t.Vql_id == id && t.Branch_Name==branchname) select c;
          
            ddl_VType.SelectedItem.Text = quotationlist.First().Mv_VehicleType;
            fillModelno();
            ddlmodel.SelectedValue = Convert.ToString(quotationlist.First().Mv_Id);
            txt_rate.Text = Convert.ToString(quotationlist.First().Vql_Rate);
            txt_quantity.Text = Convert.ToString(quotationlist.First().Vql_Quantity);
            txt_amount.Text = Convert.ToString(quotationlist.First().Vql_Amount);
            txt_discountamount.Text = Convert.ToString(quotationlist.First().Vql_discountAmount);
            btn_PDSave.ToolTip = Convert.ToString(quotationlist.First().Vql_id);
            txt_discount.Text = Convert.ToString(quotationlist.First().Vql_discount);
            txt_netamount.Text = Convert.ToString(quotationlist.First().Vql_netamount);
            btn_PDSave.Text = "Update";
            btn_PDSave.ForeColor = System.Drawing.Color.Black;
            btn_PDSave.ToolTip = Convert.ToString(quotationlist.First().Vql_id);
            btn_PDSave.CommandArgument = quotationlist.First().Branch_Name;
           
           

        }
        catch
        {

        }
    }
    protected void btn_PDSave_Click(object sender, EventArgs e)
    {
       
    }
    protected void ddlmodel_SelectedIndexChanged(object sender, EventArgs e)
    {
        string branchname = Session["Branch"].ToString();
        var Custdetails = from c in db.AME_Master_VehicleModel.ToList().Where(t => t.Mv_ModelName == ddlmodel.SelectedItem.Text && t.Branch_Name==branchname) select c;
        txt_rate.Text = Convert.ToString(Custdetails.First().Mv_Rate);
    }
    protected void ddl_VType_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillModelno();
    }
    protected void btn_PDSave_Click1(object sender, EventArgs e)
    {
        try
        {

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
            if (btn_PDSave.Text == "Update")
            {
                //string branchname = Session["Branch"].ToString();
                string branchname = btn_PDSave.CommandArgument;
                int sino = Convert.ToInt32(btn_PDSave.ToolTip);
                AME_Vehicle_QuotationList vqu = db.AME_Vehicle_QuotationList.First(t => t.Vql_id == sino && t.Branch_Name == branchname);
                vqu.Mv_Id = Convert.ToInt32(ddlmodel.SelectedValue);
                vqu.Vql_Amount = Convert.ToDecimal(txt_amount.Text);
                vqu.Vql_Quantity = Convert.ToDecimal(txt_quantity.Text);
                vqu.Vql_NerQuantity = Convert.ToDecimal(txt_quantity.Text);
                vqu.Vql_Rate = Convert.ToDecimal(txt_rate.Text);
                vqu.Vql_discount = Convert.ToDecimal(txt_discount.Text);
                vqu.Vql_netamount = Convert.ToDecimal(txt_netamount.Text);
                db.SaveChanges();

                string sino0 = Request.QueryString["id"];
                string type = Request.QueryString["Type"];
                fillEdit(sino0, type);
                txt_amount.Text = " 0";
                txt_quantity.Text = "0";
                txt_rate.Text = "0";
                txt_discount.Text = "0";
                txt_netamount.Text = "0";
                ddlmodel.SelectedIndex = -1;
                btn_PDSave.Text = "Save";
            }
            else if (btn_PDSave.Text == "Save")
            {

                AME_Vehicle_QuotationList aql = new AME_Vehicle_QuotationList();
                aql.Mv_VehicleType = ddl_VType.SelectedItem.Text;
                aql.Mv_Id = Convert.ToInt32(ddlmodel.SelectedValue);
                aql.Vq_Id = Convert.ToInt32(txtsino.Text);
                aql.Vql_Quantity = Convert.ToDecimal(txt_quantity.Text);
                aql.Vql_Rate = Convert.ToDecimal(txtsino.Text);
                aql.Vql_Status = true;
                aql.Vql_Amount = Convert.ToDecimal(txt_amount.Text);
                aql.Vql_discount = Convert.ToDecimal(txt_discount.Text);
                aql.Vql_discountAmount = Convert.ToDecimal(txt_discountamount.Text);
                aql.Vql_netamount = Convert.ToDecimal(txt_netamount.Text);
                aql.Vql_NerQuantity = Convert.ToDecimal(txt_quantity.Text);
                aql.Branch_Name = Session["Branch"].ToString();
                aql.Created_By = Session["Uid"].ToString();
                aql.Vql_Status = true;
                aql.Created_Date = SmitaClass.IndianTime();
                db.AddToAME_Vehicle_QuotationList(aql);

                db.SaveChanges();

                string sino0 = Request.QueryString["id"];
                string type = Request.QueryString["Type"];
                fillEdit(sino0, type);
                txt_amount.Text = " 0";
                txt_quantity.Text = "0";
                txt_rate.Text = "0";
                txt_discount.Text = "0";
                txt_netamount.Text = "0";
                ddlmodel.SelectedIndex = -1;
                btn_PDSave.Text = "Save";
            }
        }
        catch
        {
        }
    }
}