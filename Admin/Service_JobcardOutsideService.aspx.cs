using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;

public partial class Admin_Spare_PurchaseEntry : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
   
   
    Clear cl = new Clear();
    public string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            txt_date.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
            txt_Invdate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
            FillsidNo();

            FillCustomer();
           
        }
    }

    
    [System.Web.Services.WebMethod]
    public static string[] GetServiceCode(string prefixText, int count)
    {

        string Sale = HttpContext.Current.Session["saletype"].ToString();
        string branch = HttpContext.Current.Session["Branch"].ToString();
        if (HttpContext.Current.Session["saletype"] != null)
        {
            AutoMobileEntities db = new AutoMobileEntities();
            return db.AME_Master_ServiceHead.Where(n => n.Mh_ServiceCode.StartsWith(prefixText) && n.Branch_Name == branch && n.Mh_SaleStatus == Sale).OrderBy(n => n.Mh_ServiceCode).Select(n => n.Mh_ServiceCode).Distinct().Take(count).ToArray();
        }
        else
        {
            AutoMobileEntities db = new AutoMobileEntities();
            return db.AME_Master_ServiceHead.Where(n => n.Mh_ServiceCode.StartsWith(prefixText) && n.Branch_Name == branch).OrderBy(n => n.Mh_ServiceCode).Select(n => n.Mh_ServiceCode).Distinct().Take(count).ToArray();
        }
        
    }

   

    private void FillCustomer()
    {
        string Sale = Convert.ToString(Session["saletype"]);
        if (Session["saletype"] != null)
        {
            var v = from c in db.AME_Master_Customer.ToList().OrderBy(t => t.Mc_Name)
                    where c.Mc_Status = true && c.Branch_Name == Session["Branch"].ToString() && c.Mc_SaleStatus == Sale
                    select new
                    {
                        Cu_Name = c.Mc_Name,
                        Cu_Code = c.Mc_Id
                    };
            ddl_partyname.DataSource = v.ToList();
            ddl_partyname.DataTextField = "Cu_Name";
            ddl_partyname.DataValueField = "Cu_Code";
            ddl_partyname.DataBind();
            ddl_partyname.Items.Insert(0, "--Select One--");
        }
        else
        {
            var v = from c in db.AME_Master_Customer.ToList().OrderBy(t => t.Mc_Name)
                    where c.Mc_Status = true && c.Branch_Name == Session["Branch"].ToString() 
                    select new
                    {
                        Cu_Name = c.Mc_Name,
                        Cu_Code = c.Mc_Id
                    };
            ddl_partyname.DataSource = v.ToList();
            ddl_partyname.DataTextField = "Cu_Name";
            ddl_partyname.DataValueField = "Cu_Code";
            ddl_partyname.DataBind();
            ddl_partyname.Items.Insert(0, "--Select One--");
        }
        
    }
  
    private void  FillsidNo()
    {
        string branchname = Session["Branch"].ToString();
        if ((from c in db.AME_Service_JobCardOutside_Service where c.Branch_Name == branchname select c.JCO_Id).Count() > 0)
        {
            int VNo = (int)(from c in db.AME_Service_JobCardOutside_Service where c.Branch_Name == branchname select c.JCO_Id).Max();
            txt_sino.Text = Convert.ToString(VNo + 1);
        }
        else
        {
            txt_sino.Text = "1";
        }
    }
    
   
   
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        cl.Clear_All(this);
    }

   
    protected void imgbtn_SDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgbtn_SDelete = (ImageButton)sender;

    }
  
  
    public void fillEdit(int sino)
    {
        string branchname = Session["Branch"].ToString();
      

        var v = (
                 from c in db.AME_Service_JobCardEntry 
                 join d in db.AME_Master_VehicleModel on c.JC_Modelname equals d.Mv_Id
                 join h in db.AME_Master_Customer on c.JC_Customername equals h.Mc_Id
                 where c.JC_No == sino && c.Branch_Name == branchname
                 select new

                 {

                     c.JC_No,
                    c.JC_Date,
                    c.JC_Regno,
                    c.JC_Engineno,
                    d.Mv_ModelName,
                    c.JC_Chassisno,
                    h.Mc_Name,
                    c.JC_Customername
                   
                   

                 }).ToList();

        txt_jcdate.Text = Convert.ToDateTime(v.First().JC_Date).ToString("dd/MM/yyyy");
       

        txt_regdno.Text = v.First().JC_Regno;
        txt_engineno.Text = v.First().JC_Engineno;
        txt_modelname.Text = v.First().Mv_ModelName;
        txt_chassisno.Text = v.First().JC_Chassisno;
        FillCustomer();
        ddl_partyname.SelectedValue = Convert.ToString(v.First().JC_Customername);
       
    }
   

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_sino.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Serial Number Should Not Be Blank..!!'); </script>", false);
                txt_sino.Focus();
                return;
            }
            if (txt_jcdate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('JobCard Date Should Not Be Blank..!!'); </script>", false);
                txt_jcdate.Focus();
                return;
            }
            if (txt_jcno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('JobCard No Should Not Be Blank..!!'); </script>", false);
                txt_jcno.Focus();
                return;
            }
            if (txt_Invdate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invoice Date Should Not Be Blank..!!'); </script>", false);
                txt_Invdate.Focus();
                return;
            }
            if (txt_Invno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invoice Number Should Not Be Blank..!!'); </script>", false);
                txt_Invno.Focus();
                return;
            }
            if (txt_engineno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Engine No Should Not Be Blank ..!!'); </script>", false);
                txt_engineno.Focus();
                return;
            }
            if (txt_regdno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Reg No Should Not Be Blank..!!'); </script>", false);
                txt_regdno.Focus();
                return;
            }
            if (txt_chassisno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Chessis No Should Not Be Blank ..!!'); </script>", false);
                txt_chassisno.Focus();
                return;
            }
            if (txt_modelname.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Model Name Should Not Be Blank ..!!'); </script>", false);
                txt_modelname.Focus();
                return;
            }
            if (ddl_partyname.SelectedIndex==-1)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Select Party Name ..!!'); </script>", false);
                ddl_partyname.Focus();
                return;
            }
            if (txt_amount.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Amount Should Not Be Blank ..!!'); </script>", false);
                txt_amount.Focus();
                return;
            }
            if (txt_date.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Date Should Not Be Blank ..!!'); </script>", false);
                txt_date.Focus();
                return;
            }
            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy", "dd-MM-yyyy" };
            DateTime expectedDate;
            if (!DateTime.TryParseExact(txt_jcdate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                txt_jcdate.Focus();
                return;
            }
            if (!DateTime.TryParseExact(txt_Invdate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                txt_Invdate.Focus();
                return;
            }
            if (!DateTime.TryParseExact(txt_date.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                txt_date.Focus();
                return;
            }
           string  Usertype = Session["Uid"].ToString();
           string  Branch = Session["Branch"].ToString();
            AME_Service_JobCardOutside_Service sjs = new AME_Service_JobCardOutside_Service();
            sjs.JC_No = Convert.ToInt32(txt_jcno.Text);
            sjs.JCO_Amount = Convert.ToDecimal(txt_amount.Text);
            sjs.JCO_Date = Convert.ToDateTime(txt_date.Text,SmitaClass.dateformat());
            sjs.JCO_Partyname =Convert.ToInt32(ddl_partyname.SelectedValue);
            sjs.JCO_ServiceDetails = txt_servicedetails.Text;
            sjs.Ms_Status = "OPEN";
            sjs.Created_By = Usertype;
            sjs.Branch_Name = Branch;
            sjs.Created_Date = Convert.ToDateTime(SmitaClass.IndianTime());
            db.AddToAME_Service_JobCardOutside_Service(sjs);
            db.SaveChanges();
            cl.Clear_All(this);
            FillsidNo();
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Outside Service Added Sucessfully..!!');", true);
            return;

            txt_date.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        catch
        {

        }
    }
    protected void txt_jcno_TextChanged1(object sender, EventArgs e)
    {
        string branch = Session["Branch"].ToString();
        int jno = Convert.ToInt32(txt_jcno.Text);
        var details = from c in db.AME_Service_JobCardOutside_Service.Where(t => t.JC_No == jno && t.Ms_Status == "OPEN" && t.Branch_Name == branch) select c;

        var jcno = from c in db.AME_Service_JobCardEntry.Where(t => t.JC_No == jno && t.Ms_Status == "OPEN" && t.Branch_Name == branch) select c;
        if (Convert.ToInt32(jcno.Count()) > 0)
        {
            if (Convert.ToInt32(details.Count()) <= 0)
            {
                fillEdit(jno);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Already OutService Add..!!!');</script>", false);
                txt_jcno.Text = "";
                txt_jcno.Focus();
               
                return;
            }
            
            
        }
        else
        {

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invalid Si no Or This Job Card Already Exist..!!!');</script>", false);
            txt_jcno.Text = "";
            txt_jcno.Focus();
            return;
        }
    }
}