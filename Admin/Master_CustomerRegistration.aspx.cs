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
    public string Usertype;
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
                CheckBox1.Checked = true;

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
        var Edetails = from c in db.AME_Master_Customer.Where(t => t.Mc_Id == Sino) select c;
        txt_address.Text = Edetails.First().Mc_Address;
        txt_scode.Text = Edetails.First().Mc_code;
        txt_phno.Text = Edetails.First().Mc_Mobileno;
        txt_sname.Text = Edetails.First().Mc_Name;
        txt_tinno.Text = Edetails.First().Mc_Tin;
        txt_city.Text = Edetails.First().Mc_City;
        txt_pin.Text= Edetails.First().Mc_Pinno;
        btn_update.ToolTip =Convert.ToString(Edetails.First().Mc_Id);
        txt_city2.Text = Edetails.First().Mc_PCity;
        txt_pin3.Text = Edetails.First().Mc_PPinno;
        txt_address0.Text = Edetails.First().Mc_PAddress;
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
        var query = from c in db.AME_Master_Customer.OrderByDescending(t => t.Mc_Id)
                    select new
                    {
                        qid = c.Mc_code
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
                txt_scode.Text = "PTY000" + number;
            }
            else if ((number >= 9) && (number < 99))
            {
                number = number + 1;
                txt_scode.Text = "PTY00" + number;
            }
            else if ((number >= 99) && (number < 999))
            {
                number = number + 1;
                txt_scode.Text = "PTY0" + number;
            }
            else if (number >= 999)
            {
                number = number + 1;
                txt_scode.Text = "PTY" + number;
            }
        }
        else
        {
            txt_scode.Text = "PTY0001";
        }

    }
    public void clerall()
    {
        txt_address.Text = "";
        txt_city.Text = "";
        txt_phno.Text = "";
        txt_pin.Text = "";
        txt_sname.Text = "";
        txt_phno.Text = "";
        txt_address0.Text = "";
        txt_pin3.Text = "";
        txt_city2.Text = "";
        txt_tinno.Text = "";
        
    }
    protected void btn_assign_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_scode.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Party Code SHOULD NOT BE BLANK..!!!');</script>", false);
                txt_scode.Focus();
                return;
            }
            if (txt_sname.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Party Name SHOULD NOT BE BLANK..!!!');</script>", false);
                txt_sname.Focus();
                return;
            }
            if (txt_address.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Party Address  SHOULD NOT BE BLANK..!!!');</script>", false);
                txt_address.Focus();
                return;
            }
            //if (txt_city.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('City Name Should Not Be Blank..!!!');</script>", false);
            //    txt_city.Focus();
            //    return;
            //}
            //if (txt_pin.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Pin  No Should Not Be Blank..!!!');</script>", false);
            //    txt_pin.Focus();
            //    return;
            //}
            if (txt_phno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Phone  No Should Not Be Blank..!!!');</script>", false);
                txt_phno.Focus();
                return;
            }
         
            //if (txt_tinno.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Tinno  SHOULD NOT BE BLANK..!!!');</script>", false);
            //    txt_tinno.Focus();
            //    return;
            //}

            Usertype = Session["Uid"].ToString();
            Branch = Session["Branch"].ToString();
            string Sale = Session["saletype"].ToString();
            var checkEmpName = from c in db.AME_Master_Customer.Where(t => t.Mc_Name == txt_sname.Text && t.Branch_Name==Branch && t.Mc_SaleStatus==Sale) select c;
            if (Convert.ToInt32(checkEmpName.Count()) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Customer Name Already Exist,Please Try Different..!!!');</script>", false);
                txt_sname.Focus();
                return;
            }

           
            AME_Master_Customer EmpUpdate = new AME_Master_Customer();
            EmpUpdate.Branch_Name = Branch;
            EmpUpdate.Created_By = Usertype;
            EmpUpdate.Mc_Address = txt_address.Text;
            EmpUpdate.Created_Date = SmitaClass.IndianTime();
            EmpUpdate.Mc_PAddress = txt_address0.Text;
            EmpUpdate.Mc_PCity = txt_city2.Text;
            EmpUpdate.Mc_PPinno = txt_pin3.Text;
            EmpUpdate.Mc_City = txt_city.Text;
            EmpUpdate.Mc_code = txt_scode.Text;
            EmpUpdate.Mc_Mobileno = txt_phno.Text;
            EmpUpdate.Mc_SaleStatus = Sale;
            
            EmpUpdate.Mc_Name = txt_sname.Text;
            EmpUpdate.Mc_Pinno = txt_pin.Text;
            EmpUpdate.Mc_Status = true;
            EmpUpdate.Mc_Tin = txt_tinno.Text;
            db.AddToAME_Master_Customer(EmpUpdate);
            db.SaveChanges();
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Customer Registered Sucessfully..!!');", true);
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
        Response.Redirect("Master_CustomerDetails.aspx");
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
        string vb = btn_update.ToolTip;
        string Branch = Convert.ToString(Session["Branch"]);
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
        if (txt_phno.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Contact Person SHOULD NOT BE BLANK..!!!');</script>", false);
            txt_phno.Focus();
            return;
        }
        if (txt_tinno.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Tinno  SHOULD NOT BE BLANK..!!!');</script>", false);
            txt_tinno.Focus();
            return;
        }

        var checkEmpName = from c in db.AME_Master_Customer.Where(t => t.Mc_Name == txt_sname.Text && t.Mc_Id != sino && t.Branch_Name == Branch) select c;
        if (Convert.ToInt32(checkEmpName.Count()) > 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Customer Name Already Exist,Please Try Different..!!!');</script>", false);
            txt_sname.Focus();
            return;
        }
        AME_Master_Customer EmpUpdate1 = db.AME_Master_Customer.First(t => t.Mc_Id == sino);
        EmpUpdate1.Mc_Address = txt_address.Text;

        EmpUpdate1.Mc_City = txt_city.Text;
        EmpUpdate1.Mc_code = txt_scode.Text;
        EmpUpdate1.Mc_Mobileno = txt_phno.Text;
        EmpUpdate1.Mc_Name = txt_sname.Text;
        EmpUpdate1.Mc_Pinno = txt_pin.Text;
        EmpUpdate1.Mc_Tin = txt_tinno.Text;
        EmpUpdate1.Mc_PAddress = txt_address0.Text;
        EmpUpdate1.Mc_PPinno = txt_pin3.Text;
        EmpUpdate1.Mc_PCity = txt_city2.Text;
        db.SaveChanges();
       
        btn_update.Visible = false;
        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Customer Data Update Sucessfully..!!');", true);
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked == true)
        {
            txt_address0.Text = txt_address.Text;
            txt_pin3.Text = txt_pin.Text;
            txt_city2.Text = txt_city.Text;
        }
        else
        {
            txt_address0.Text = "";
            txt_pin3.Text = "";
            txt_city2.Text = "";
        }
    }
}