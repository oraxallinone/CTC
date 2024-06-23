using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
using System.Data;
public partial class Admin_Master_MachineRegstration : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    Clear cl = new Clear();
    public string Branch;
    public string Usertype;
    string id;
    string ValueType;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            string type = Request.QueryString["Type"];
            string id = Request.QueryString["id"];
            if (type == "View")
            {
                filldata(id, type);
                SetTextBoxReadOnly<TextBox>(Master.FindControl("form1"), true);
                return;
            }
            if (type == "Edit")
            {
                filldata(id, type);
                txt_stock.Enabled = false;
                btn_assign.Visible = false;
                btn_cancel.Visible = false;
                btn_update.Visible = true;
                btn_back.Visible = true;
                return;
            }
            FillSlNo();
        }
    }
    public void FillSlNo()
    {
        if ((from c in db.AME_Master_Item select c.Itm_Id).Count() > 0)
        {
            int VNo = (int)(from c in db.AME_Master_Item select c.Itm_Id).Max();
            txt_partno.ToolTip = Convert.ToString(VNo + 1);
        }
        else
        {
            txt_partno.ToolTip = "1";
        }
    }
    public void filldata(string id, string type)
    {
        string Sino = id;
        var Edetails = from c in db.AME_Master_Item.Where(t => t.Itm_code == Sino) select c;
        txt_description.Text = Edetails.First().Itm_PartDescrption;
      //  txt_stock.Text = Convert.ToString(Edetails.First().Itm_OpStock);
        ddlcategory.SelectedItem.Text = Edetails.First().Itm_CategoryName;
        txt_salesprice.Text =Convert.ToString(Edetails.First().Itm_SalePrice);
        txt_hsn.Text = Edetails.First().hsncode;
        txt_alternatepart.Text = Edetails.First().Itm_AlternatePart;
        txt_partno.Text = Edetails.First().Itm_Partno;
        ddl_VType.SelectedValue = Edetails.First().Itm_VehicleType;
        txt_unit.Text = Edetails.First().Itm_Unit;
        txt_purchaseprice.Text = Convert.ToString(Edetails.First().Itm_PurchasePrice);
        if (Convert.ToDecimal(Edetails.First().Itm_VatPercent) == Convert.ToDecimal(28.00))
        {
            ddl_vat.SelectedIndex = 1;
        }
        else if (Convert.ToDecimal(Edetails.First().Itm_VatPercent) == Convert.ToDecimal(18.00))
        {
            ddl_vat.SelectedIndex = 2;
        }
       
        txt_selfno.Text = Edetails.First().Itm_Selfno;
        btn_update.ToolTip = Convert.ToString(Edetails.First().Itm_code);

        DataSet ds = smitaDbAccess.returndataset("select SUM(Ss_NetQuantity) AS NetQuantity FROM AME_Spare_PurchaseEntry WHERE Itm_Partno='" + txt_partno.Text + "' AND Branch_Name='" + Session["Branch"].ToString() + "'");
        if (ds.Tables[0].Rows[0].ItemArray[0].ToString() != "")
        {
            txt_stock.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        else
        {
            txt_stock.Text = "0";
        }
        btn_assign.Visible = false;
        btn_cancel.Visible = false;
        btn_update.Visible = false;
        btn_back.Visible = true;
    }
   
    private void SetTextBoxReadOnly<T>(Control parent, bool readOnly) where T : TextBox
    {
        foreach (var tb in parent.Controls.OfType<T>())
            tb.ReadOnly = readOnly;

        foreach (Control c in parent.Controls)
            SetTextBoxReadOnly<T>(c, readOnly);
    }
   
   

    protected void btn_assign_Click(object sender, EventArgs e)
    {
        try
        {
            //System.Threading.Thread.Sleep(20000);
            string Branch = Convert.ToString(Session["Branch"]);
            if (ddl_VType.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Vehicle Type..!!!');</script>", false);
                ddl_VType.Focus();
                return;
            }
          
            if (txt_partno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Part No. Should Not Be Blank..!!!');</script>", false);
                txt_partno.Focus();
                return;
            }
            if (txt_hsn.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Hsn No. Should Not Be Blank..!!!');</script>", false);
                txt_hsn.Focus();
                return;
            }
            //if (txt_unit.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Unit Should Not Be Blank..!!!');</script>", false);
            //    txt_unit.Focus();
            //    return;
            //}
            if (txt_purchaseprice.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Purchase amount Should Not Be Blank..!!!');</script>", false);
                txt_purchaseprice.Focus();
                return;
            }
            if (txt_salesprice.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Sales Price Should Not Be Blank..!!!');</script>", false);
                txt_salesprice.Focus();
                return;
            }
            //if (txt_vat.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Vat Should Not Be Blank..!!!');</script>", false);
            //    txt_vat.Focus();
            //    return;
            //}
            //if (txt_selfno.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Self No SHOULD NOT BE BLANK..!!!');</script>", false);
            //    txt_selfno.Focus();
            //    return;
            //}
           
            //if (txt_stock.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Opening Stock SHOULD NOT BE BLANK..!!!');</script>", false);
            //    txt_stock.Focus();
            //    return;
            //}
            if (txt_stock.Text == "")
            {
                txt_stock.Text = "0";
            }
            var checkEmpName = from c in db.AME_Master_Item.Where(t => t.Itm_Partno == txt_partno.Text && t.Branch_Name == Branch) select c;
            if (Convert.ToInt32(checkEmpName.Count()) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Part No Already Exist,Please Try Different..!!!');</script>", false);
                txt_partno.Focus();
                return;
            }

            Usertype = Session["Uid"].ToString();
            Branch= Session["Branch"].ToString();
            AME_Master_Item Ami = new AME_Master_Item();
            Ami.Branch_Name = Branch;
            Ami.Created_By = Usertype;
            Ami.Itm_VehicleType = ddl_VType.SelectedItem.Text;
            Ami.Created_Date = SmitaClass.IndianTime();
           
            Ami.Itm_CategoryName = ddlcategory.SelectedItem.Text;
            Ami.Itm_OpStock =Convert.ToDecimal(txt_stock.Text);
            Ami.Itm_PartDescrption = txt_description.Text;
            Ami.Itm_Partno = txt_partno.Text;
            Ami.Itm_PurchasePrice =Convert.ToDecimal(txt_purchaseprice.Text);
            Ami.Itm_SalePrice = Convert.ToDecimal(txt_salesprice.Text);
            Ami.Itm_Selfno = txt_selfno.Text;
            Ami.Itm_Unit = txt_unit.Text;
            Ami.Itm_VatPercent = Convert.ToDecimal(ddl_vat.SelectedItem.Text);
            Ami.hsncode = txt_hsn.Text;
            Ami.Ms_Status = true;
            db.AddToAME_Master_Item(Ami);
            db.SaveChanges();

            //if (Convert.ToDecimal(txt_stock.Text) > 0)
            //{
                AME_Spare_PurchaseEntry pe = new AME_Spare_PurchaseEntry();
                pe.Sp_VoucherNo = Convert.ToInt32(txt_partno.ToolTip);
                pe.Itm_Partno = txt_partno.Text;
                pe.Itm_PartDescrption = txt_description.Text;
                pe.Ss_Quantity = Convert.ToDecimal(txt_stock.Text);
                pe.Ss_NetQuantity = Convert.ToDecimal(txt_stock.Text);
                pe.Ss_Rate = Convert.ToDecimal(txt_purchaseprice.Text);
                pe.Ss_Amount = Convert.ToDecimal(txt_purchaseprice.Text) * Convert.ToDecimal(txt_stock.Text);
                pe.Ss_Discount = Convert.ToDecimal(0);
                pe.Ss_Vat = Convert.ToDecimal(ddl_vat.SelectedItem.Text);
                pe.Ss_TaxAmont = ((Convert.ToDecimal(txt_purchaseprice.Text) * Convert.ToDecimal(txt_stock.Text)) / 100) * Convert.ToDecimal(ddl_vat.SelectedItem.Text);
                pe.Ss_Total = (Convert.ToDecimal(txt_purchaseprice.Text) * Convert.ToDecimal(txt_stock.Text)) + ((Convert.ToDecimal(txt_purchaseprice.Text) * Convert.ToDecimal(txt_stock.Text)) / 100) * Convert.ToDecimal(ddl_vat.SelectedItem.Text);
                pe.Ss_Status = "OS";
                pe.Status = true;
                pe.jc_year = "2017-18";
                pe.Branch_Name = Session["Branch"].ToString();
                pe.Created_By = Session["Uid"].ToString();
                pe.Created_Date = SmitaClass.IndianTime();
                db.AddToAME_Spare_PurchaseEntry(pe);
                db.SaveChanges();
            //}
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Item Inserted Sucessfully..!!');", true);
            cl.Clear_All(this);
            txt_stock.Text = "0";
        }
        catch
        {

        }
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        cl.Clear_All(this);
    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        //string partno = txt_partno.Text;
        //Response.Redirect("ItemDetails.aspx?partno="+partno+"");
        Response.Redirect("Master_ItemDetails.aspx");
        
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
        try
        {
            string Branch = Convert.ToString(Session["Branch"]);
            string vb = btn_update.ToolTip;
            if (ddl_VType.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Vehicle Type..!!!');</script>", false);
                ddl_VType.Focus();
                return;
            }

         
           
            if (txt_partno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Part No. Should Not Be Blank..!!!');</script>", false);
                txt_partno.Focus();
                return;
            }

            if (txt_hsn.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Hsn No. Should Not Be Blank..!!!');</script>", false);
                txt_hsn.Focus();
                return;
            }
            

            if (txt_unit.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Unit Should Not Be Blank..!!!');</script>", false);
                txt_unit.Focus();
                return;
            }
            if (txt_purchaseprice.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Purchase amount Should Not Be Blank..!!!');</script>", false);
                txt_purchaseprice.Focus();
                return;
            }
            if (txt_salesprice.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Sales Price Should Not Be Blank..!!!');</script>", false);
                txt_salesprice.Focus();
                return;
            }
            if (txt_selfno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Self No SHOULD NOT BE BLANK..!!!');</script>", false);
                txt_selfno.Focus();
                return;
            }

            if (txt_stock.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Opening Stock SHOULD NOT BE BLANK..!!!');</script>", false);
                txt_stock.Focus();
                return;
            }

            var checkEmpName = from c in db.AME_Master_Item.Where(t => t.Itm_Partno == txt_partno.Text && t.Itm_code != vb && t.Branch_Name == Branch) select c;
            if (Convert.ToInt32(checkEmpName.Count()) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Part No Already Exist,Please Try Different..!!!');</script>", false);
                txt_partno.Focus();
                return;
            }
            AME_Master_Item Ami = db.AME_Master_Item.First(t => t.Itm_code == vb);
            
            Ami.Created_Date = SmitaClass.IndianTime();
            Ami.Itm_AlternatePart = txt_alternatepart.Text;
           
            Ami.Itm_CategoryName = ddlcategory.SelectedItem.Text;
         //   Ami.Itm_OpStock = Convert.ToDecimal(txt_stock.Text);
            Ami.Itm_PartDescrption = txt_description.Text;
            Ami.Itm_Partno = txt_partno.Text;
            Ami.Itm_PurchasePrice = Convert.ToDecimal(txt_purchaseprice.Text);
            Ami.Itm_SalePrice = Convert.ToDecimal(txt_salesprice.Text);
            Ami.Itm_Selfno = txt_selfno.Text;
            Ami.Itm_Unit = txt_unit.Text;
            Ami.Itm_VatPercent = Convert.ToDecimal(ddl_vat.SelectedItem.Text);
            Ami.Itm_VehicleType = ddl_VType.SelectedItem.Text;
            Ami.hsncode = txt_hsn.Text;
            db.SaveChanges();

            DataSet ds = smitaDbAccess.returndataset("select SUM(Ss_NetQuantity) AS NetQuantity FROM AME_Spare_PurchaseEntry WHERE Itm_Partno='" + txt_partno.Text + "' AND Branch_Name='" + Session["Branch"].ToString() + "'");
            if (ds.Tables[0].Rows[0].ItemArray[0].ToString() != "")
            {
                txt_stock.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            else
            {
                txt_stock.Text = "0";
            }
            btn_update.Visible = false;
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Item Data UpdatSucessfully..!!');", true);
        }
        catch
        {

        }
    }
    
}