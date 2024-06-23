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
    public string Branch;
    public string Userid;
    string id;
    string ValueType;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FilEmpCode();
           
            string type = Request.QueryString["Type"];
            string id = Request.QueryString["id"];
            if (type == "View")
            {
                filldata(id, type);
                SetTextBoxReadOnly<TextBox>(Master.FindControl("form1"), true);

            }
            if (type == "Edit")
            {
                filldata(id, type);
                btn_assign.Visible = false;
                btn_cancel.Visible = false;
                btn_update.Visible = true;
                btn_back.Visible = true;

            }
        }
    }
    public void filldata(string id, string type)
    {
        int Sino = Convert.ToInt32(id);
        var Edetails = from c in db.AME_Master_Supplier.Where(t => t.Ms_Id == Sino) select c;
        txt_address.Text = Edetails.First().Ms_Address;
        txt_balance.Text = Convert.ToString(Edetails.First().Ms_Balance);
        txt_scode.Text = Edetails.First().Ms_code;
        txt_phno.Text = Edetails.First().Ms_Mobileno;
        txt_sname.Text = Edetails.First().Ms_Name;
        txt_tinno.Text = Edetails.First().Ms_Tin;
        txt_city.Text = Edetails.First().Ms_City;
        txt_pin.Text= Edetails.First().Ms_Pin;
        txt_fax.Text = Edetails.First().Ms_Fax;
        txt_cperson.Text = Edetails.First().Ms_Contactperson;
        btn_update.ToolTip = Convert.ToString(Edetails.First().Ms_Id);
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
   
    private void FilEmpCode()
    {
        var query = from c in db.AME_Master_Supplier.ToList().OrderByDescending(t => t.Ms_Id)
                    select new
                    {
                        qid = c.Ms_code
                    };

        int cto = query.Count();
        if (cto > 0)
        {

            string first_sl_no = query.First().qid;
            string sl_no = first_sl_no.Substring(3, 4);
            int number = Convert.ToInt32(sl_no);

            if ((number >= 0) && (number < 9))
            {
                number = number + 1;
                txt_scode.Text = "SUP000" + number;
            }
            else if ((number >= 9) && (number < 99))
            {
                number = number + 1;
                txt_scode.Text = "SUP00" + number;
            }
            else if ((number >= 99) && (number < 999))
            {
                number = number + 1;
                txt_scode.Text = "SUP0" + number;
            }
            else if (number >= 999)
            {
                number = number + 1;
                txt_scode.Text = "SUP" + number;
            }
        }
        else
        {
            txt_scode.Text = "SUP0001";
        }

    }
    public void clerall()
    {
        txt_address.Text = "";
        txt_city.Text = "";
        txt_cperson.Text = "";
        txt_pin.Text = "";
        txt_sname.Text = "";
        txt_phno.Text = "";
        txt_fax.Text = "";
        txt_tinno.Text = "";
        txt_balance.Text = "";
    }
    protected void btn_assign_Click(object sender, EventArgs e)
    {
        try
        {
            string Branch = Convert.ToString(Session["Branch"]);
            if (txt_scode.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Supplier Code SHOULD NOT BE BLANK..!!!');</script>", false);
                txt_scode.Focus();
                return;
            }
            if (txt_sname.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Supplier Name SHOULD NOT BE BLANK..!!!');</script>", false);
                txt_sname.Focus();
                return;
            }
            if (txt_address.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Supplier Address  SHOULD NOT BE BLANK..!!!');</script>", false);
                txt_address.Focus();
                return;
            }
            if (txt_city.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('City Name Should Not Be Blank..!!!');</script>", false);
                txt_city.Focus();
                return;
            }
            //if (txt_pin.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Pin  No Should Not Be Blank..!!!');</script>", false);
            //    txt_pin.Focus();
            //    return;
            //}
            //if (txt_phno.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Phone  No Should Not Be Blank..!!!');</script>", false);
            //    txt_phno.Focus();
            //    return;
            //}
            //if (txt_cperson.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Contact Person SHOULD NOT BE BLANK..!!!');</script>", false);
            //    txt_cperson.Focus();
            //    return;
            //}
            //if (txt_tinno.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Tinno  SHOULD NOT BE BLANK..!!!');</script>", false);
            //    txt_tinno.Focus();
            //    return;
            //}
            if (txt_balance.Text == "")
            {
                txt_balance.Text = "0";
                
            }

            var checkEmpName = from c in db.AME_Master_Supplier.Where(t => t.Ms_Name == txt_sname.Text && t.Branch_Name == Branch) select c;
            if (Convert.ToInt32(checkEmpName.Count()) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Employee Name Already Exist,Please Try Different..!!!');</script>", false);
                txt_sname.Focus();
                return;
            }
          
              Userid = Session["Uid"].ToString();
          
            Branch= Session["Branch"].ToString();
            AME_Master_Supplier EmpUpdate = new AME_Master_Supplier();
            EmpUpdate.Branch_Name = Branch;
            EmpUpdate.Created_By = Userid;
            EmpUpdate.Ms_Address = txt_address.Text;
            EmpUpdate.Created_Date = SmitaClass.IndianTime();
            EmpUpdate.Ms_Balance = Convert.ToDecimal(txt_balance.Text);
            EmpUpdate.Ms_City = txt_city.Text;
            EmpUpdate.Ms_code = txt_scode.Text;
            EmpUpdate.Ms_Contactperson = txt_cperson.Text;
            EmpUpdate.Ms_Fax = txt_fax.Text;
            EmpUpdate.Ms_Mobileno = txt_phno.Text;
            EmpUpdate.Ms_Name = txt_sname.Text;
            EmpUpdate.Ms_Pin = txt_pin.Text;
            EmpUpdate.Ms_Status = true;
            EmpUpdate.Ms_Tin = txt_tinno.Text;
            db.AddToAME_Master_Supplier(EmpUpdate);
            db.SaveChanges();
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Supplier Registered Sucessfully..!!');", true);
            FilEmpCode();
            clerall();
        }
        catch
        {

        }
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        cl.Clear_All(this);
        FilEmpCode();
    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("Master_SupplierDetails.aspx");
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
        string vb = btn_update.ToolTip;
        int sino = Convert.ToInt32(btn_update.ToolTip);
        if (txt_sname.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Supplier Name SHOULD NOT BE BLANK..!!!');</script>", false);
            txt_sname.Focus();
            return;
        }
        if (txt_address.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Supplier Address  SHOULD NOT BE BLANK..!!!');</script>", false);
            txt_address.Focus();
            return;
        }
        if (txt_city.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('City Name Should Not Be Blank..!!!');</script>", false);
            txt_city.Focus();
            return;
        }
        if (txt_pin.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Pin  No Should Not Be Blank..!!!');</script>", false);
            txt_pin.Focus();
            return;
        }
        if (txt_phno.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Phone  No Should Not Be Blank..!!!');</script>", false);
            txt_phno.Focus();
            return;
        }
        if (txt_cperson.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Contact Person SHOULD NOT BE BLANK..!!!');</script>", false);
            txt_cperson.Focus();
            return;
        }
        if (txt_tinno.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Tinno  SHOULD NOT BE BLANK..!!!');</script>", false);
            txt_tinno.Focus();
            return;
        }
        if (txt_balance.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Balance  SHOULD NOT BE BLANK..!!!');</script>", false);
            txt_balance.Focus();
            return;
        }
        var checkEmpName = from c in db.AME_Master_Supplier.Where(t => t.Ms_Name == txt_sname.Text && t.Ms_Id!= sino) select c;
        if (Convert.ToInt32(checkEmpName.Count()) > 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Employee Name Already Exist,Please Try Different..!!!');</script>", false);
            txt_sname.Focus();
            return;
        }
        AME_Master_Supplier EmpUpdate = db.AME_Master_Supplier.First(t => t.Ms_Id == sino);
        EmpUpdate.Ms_Address = txt_address.Text;
        EmpUpdate.Ms_Balance = Convert.ToDecimal(txt_balance.Text);
        EmpUpdate.Ms_City = txt_city.Text;
        EmpUpdate.Ms_code = txt_scode.Text;
        EmpUpdate.Ms_Contactperson = txt_cperson.Text;
        EmpUpdate.Ms_Fax = txt_fax.Text;
        EmpUpdate.Ms_Mobileno = txt_phno.Text;
        EmpUpdate.Ms_Name = txt_sname.Text;
        EmpUpdate.Ms_Pin = txt_pin.Text;
      
        EmpUpdate.Ms_Tin = txt_tinno.Text;
        db.SaveChanges();
      
        btn_update.Visible = false;
        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Supplier Data UpdatSucessfully..!!');", true);
    } 
}