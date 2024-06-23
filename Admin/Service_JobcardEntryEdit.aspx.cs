using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
using System.Data;
public partial class Admin_Spare_PurchaseEntry : System.Web.UI.Page
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
            string year = Request.QueryString["year"];
            if (type == "View")
            {
                filldata(sino, type,year);
                //fillgriddata(sino, type);
                SetTextBoxReadOnly<TextBox>(Master.FindControl("form1"), true);
                tbl_details.Visible = false;
                btn_Submit.Visible = false;
                btn_Cancel.Visible = false;
            }
            if (type == "Edit")
            {

                if (Session["Uid"].ToString() == "User1" || Session["Uid"].ToString() == "User2")
                {

                    fillEdit(sino, type, year);
                    //fillgridEditdata(sino, type);
                    btn_Submit.Visible = true;
                    tbl_details.Visible = true;
                    btn_Cancel.Visible = false;
                    btn_Submit.Text = "Update";

                    int jcno = Convert.ToInt32( txt_jcno.Text);
                    string branch = Session["Branch"].ToString();
                    string jcyear = txt_jcyear.Text;
                    DataSet ds5 = smitaDbAccess.returndataset("select Ms_Status from AME_Service_JobCardEntry where  JC_No=" + jcno + " and Branch_Name='" + branch + "' and JC_year='" + jcyear + "'");
                    if (ds5.Tables[0].Rows[0][0].ToString() == "CLOSE")
                    {
                        ddl_customer.Enabled = false;
                        ddl_Model.Enabled = false;
                        ddl_servicetype.Enabled = false;
                        ddl_supervisor.Enabled = false;
                        //ddlstate.Enabled = false;
                        ddl_technisian.Enabled = false;
                        //if (txtakref.Text == "")
                        //{
                        //    txtakref.ReadOnly = false;
                        //}
                        txt_kcovered.Enabled = false;
                        txt_deliverydate.Enabled = false;
                        txt_SCode.Enabled = false;
                        txt_SDescription.Enabled = false;
                        txt_SQuantity.Enabled = false;
                        txt_SRate.Enabled = false;
                        txt_SAmount.Enabled = false;
                        txt_date.Enabled = false;
                        txt_keyno.Enabled = false;
                        txt_time.Enabled = false;
                        txt_address.Enabled = false;
                        txt_phoneno.Enabled = false;
                        txt_engineno.Enabled = false;
                            txt_chassisno.Enabled = false;
                            txt_saledate.Enabled = false;
                            foreach (GridViewRow gr in GridView1.Rows)
                            {
                                ImageButton id1 = (ImageButton)gr.FindControl("imgbtn_edit");
                                ImageButton id2 = (ImageButton)gr.FindControl("imgbtn_SDelete");
                                id1.Visible = false;
                                id2.Visible = false;

                            }
                    }





                }
                else {

                    fillEdit(sino, type, year);
                    //fillgridEditdata(sino, type);
                    btn_Submit.Visible = true;
                    tbl_details.Visible = true;
                    btn_Cancel.Visible = false;
                    btn_Submit.Text = "Update";
                
                
                }

              

            }


        }
    }
    private void FillSupervisor()
    {
        string Sale = Convert.ToString(Session["saletype"]);
        if (Session["saletype"] != null)
        {
            var v = from c in db.AME_Master_Supervisor.ToList().OrderBy(t => t.Ms_Name)
                    where c.Status = true && c.Branch_Name == Session["Branch"].ToString() && c.Ms_SaleStatus == Sale
                    select new
                    {
                        Cu_Name = c.Ms_Name,
                        Cu_Code = c.Ms_Id
                    };
            ddl_supervisor.DataSource = v.ToList();
            ddl_supervisor.DataTextField = "Cu_Name";
            ddl_supervisor.DataValueField = "Cu_Code";
            ddl_supervisor.DataBind();
            ddl_supervisor.Items.Insert(0, "--Select One--");
        }
        else
        {
            var v = from c in db.AME_Master_Supervisor.ToList().OrderBy(t => t.Ms_Name)
                    where c.Status = true && c.Branch_Name == Session["Branch"].ToString()
                    select new
                    {
                        Cu_Name = c.Ms_Name,
                        Cu_Code = c.Ms_Id
                    };
            ddl_supervisor.DataSource = v.ToList();
            ddl_supervisor.DataTextField = "Cu_Name";
            ddl_supervisor.DataValueField = "Cu_Code";
            ddl_supervisor.DataBind();
            ddl_supervisor.Items.Insert(0, "--Select One--");
        }
        
    }
    private void FillTechnisian()
    {
        var v = from c in db.AME_Master_Technician.ToList().OrderBy(t => t.Mt_Name)
                where c.Status = true && c.Branch_Name == Session["Branch"].ToString()
                select new
                {
                    Cu_Name = c.Mt_Name,
                    Cu_Code = c.Mt_Id
                };
        ddl_technisian.DataSource = v.ToList();
        ddl_technisian.DataTextField = "Cu_Name";
        ddl_technisian.DataValueField = "Cu_Code";
        ddl_technisian.DataBind();
        ddl_technisian.Items.Insert(0, "--Select One--");
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
            ddl_customer.DataSource = v.ToList();
            ddl_customer.DataTextField = "Cu_Name";
            ddl_customer.DataValueField = "Cu_Code";
            ddl_customer.DataBind();
            ddl_customer.Items.Insert(0, "--Select One--");
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
            ddl_customer.DataSource = v.ToList();
            ddl_customer.DataTextField = "Cu_Name";
            ddl_customer.DataValueField = "Cu_Code";
            ddl_customer.DataBind();
            ddl_customer.Items.Insert(0, "--Select One--");
        }
        
    }

    private void FillVModel()
    {
        string Sale = Convert.ToString(Session["saletype"]);
        if (Session["saletype"] != null)
        {
            var v = from c in db.AME_Master_VehicleModel.ToList().OrderBy(t => t.Mv_ModelName)
                    where c.Status = true && c.Mv_SaleStatus == Sale
                    select new
                    {
                        Cu_Name = c.Mv_ModelName,
                        Cu_Code = c.Mv_Id
                    };
            ddl_Model.DataSource = v.ToList();
            ddl_Model.DataTextField = "Cu_Name";
            ddl_Model.DataValueField = "Cu_Code";
            ddl_Model.DataBind();
            ddl_Model.Items.Insert(0, "--Select One--");
        }
        else
        {
            var v = from c in db.AME_Master_VehicleModel.ToList().OrderBy(t => t.Mv_ModelName)
                    where c.Status = true
                    select new
                    {
                        Cu_Name = c.Mv_ModelName,
                        Cu_Code = c.Mv_Id
                    };
            ddl_Model.DataSource = v.ToList();
            ddl_Model.DataTextField = "Cu_Name";
            ddl_Model.DataValueField = "Cu_Code";
            ddl_Model.DataBind();
            ddl_Model.Items.Insert(0, "--Select One--");
        }
      
    }
    public void fillservice()
    {
        string branchname = Session["Branch"].ToString();
        int sno = Convert.ToInt32(txt_jcno.Text);
        string year=txt_jcyear.Text;
        var v = (from c in db.AME_Service_JobCardEntry
                 join g in db.AME_Service_JobCardServiceDetails on new { c.JC_No, c.Branch_Name } equals new { g.JC_No, g.Branch_Name }
                 where c.JC_No == sno && c.Branch_Name == branchname && g.Jc_year==year
                 select new

                 {
                     g.JCS_Amount,
                     g.JCS_Description,
                     g.JCS_Quantity,
                     g.JCS_Rate,
                     g.JCS_Servicecode,
                     g.JCS_Sino,
                     g.JSC_Labour
                 }).Distinct().ToList();
        if (Convert.ToInt32(v.Count()) > 0)
        {
            GridView1.DataSource = v.ToList();
            GridView1.DataBind();
        }



    }

    public void filldata(string sino, string type, string year)
    {
        FillSupervisor();
        FillCustomer();
        FillTechnisian();
        FillVModel();
        
        string branchname = Session["Branch"].ToString();
        int sno = Convert.ToInt32(sino);
        var v = (from c in db.AME_Service_JobCardEntry

                 join d in db.AME_Master_VehicleModel on c.JC_Modelname equals d.Mv_Id
                 join e in db.AME_Master_Supervisor on c.JC_SupervisorName equals e.Ms_Id
                 join f in db.AME_Master_Technician on c.JCTechnisianName equals f.Mt_Id
                 join h in db.AME_Master_Customer on c.JC_Customername equals h.Mc_Id

                  join g in db.AME_Service_JobCardServiceDetails on c.JC_No equals g.JC_No

                 where c.JC_No == sno && c.Branch_Name == branchname && c.JC_year ==year && g.Jc_year==year && c.Branch_Name == branchname && g.Branch_Name == branchname
                 select new

                 {
                     c.JC_year,
                     c.JC_No,
                     c.JC_Chassisno,
                     c.JC_Date,
                     c.JC_Caddress,
                     c.JC_Deliverydate,
                     d.Mv_ModelName,
                     c.JC_Engineno,
                     c.JC_Grandtotal,
                     c.JC_Keyno,
                     c.JC_Regno,
                     c.JC_Kmcovered,
                     c.JC_MobileNo,
                     c.JC_Phoneno,
                     c.JCTechnisianName,
                     c.JC_SupervisorName,
                     c.JC_Modelname,
                     c.JC_Customername,
                     c.JC_SaleDate,
                     c.JC_ServiceType,
                     e.Ms_Name,
                     c.JC_Time,
                     f.Mt_Name,
                     h.Mc_Name

                 }).Distinct().ToList();

        
        txt_time.Text = v.First().JC_Time;
        txt_jcno.Text = Convert.ToString(v.First().JC_No);
        txt_jcyear.Text = v.First().JC_year;
        ddl_customer.SelectedValue =Convert.ToString(v.First().JC_Customername);
        txt_address.Text = v.First().JC_Caddress;
        txt_phoneno.Text = v.First().JC_MobileNo;
        ddl_Model.SelectedValue = Convert.ToString(v.First().JC_Modelname);
        txt_chassisno.Text = v.First().JC_Chassisno;
        txt_kcovered.Text = v.First().JC_Kmcovered;
        ddl_servicetype.Text = v.First().JC_ServiceType;
        ddl_supervisor.SelectedValue =Convert.ToString(v.First().JC_SupervisorName);
        ddl_technisian.SelectedValue = Convert.ToString(v.First().JCTechnisianName); 
        txt_saledate.Text = Convert.ToDateTime(v.First().JC_SaleDate).ToString("dd/MM/yyyy");
        txt_regdno.Text = v.First().JC_Regno;
        txt_engineno.Text = v.First().JC_Engineno;
        txt_keyno.Text = v.First().JC_Keyno;
        txt_deliverydate.Text = Convert.ToDateTime(v.First().JC_Deliverydate).ToString("dd/MM/yyyy");
        try
        {
            txt_date.Text = Convert.ToDateTime(v.First().JC_Date).ToString("dd/MM/yyyy");
        }
        catch (Exception ex)
        { }
        fillservice();
        foreach (GridViewRow gr in GridView1.Rows)
        {
            ImageButton edit = (ImageButton)gr.FindControl("imgbtn_edit");
            ImageButton delete = (ImageButton)gr.FindControl("imgbtn_SDelete");
            edit.Visible = false;
            delete.Visible = false;

        }

    }
    public decimal total;
    public void fillEdit(string sino, string type, string year)
    {
        FillSupervisor();
        FillCustomer();
        FillTechnisian();
        FillVModel();

        string branchname = Session["Branch"].ToString();
        int sno = Convert.ToInt32(sino);
        
        var v = (from c in db.AME_Service_JobCardEntry

                 join d in db.AME_Master_VehicleModel on c.JC_Modelname equals d.Mv_Id
                 join e in db.AME_Master_Supervisor on c.JC_SupervisorName equals e.Ms_Id
                 join f in db.AME_Master_Technician on c.JCTechnisianName equals f.Mt_Id
                 join h in db.AME_Master_Customer on c.JC_Customername equals h.Mc_Id
                 join g in db.AME_Service_JobCardServiceDetails on c.JC_No equals g.JC_No 
                 where c.JC_No == sno && c.Branch_Name == branchname && e.Branch_Name == branchname && f.Branch_Name == branchname
                 && h.Branch_Name == branchname && g.Branch_Name == branchname && c.JC_year == year && g.Jc_year== year && c.Branch_Name == branchname && g.Branch_Name == branchname
                 select new

                 {
                    
                   c.JC_year,
                     c.JC_No,
                     c.JC_Chassisno,
                     c.JC_Date,
                     c.JC_Caddress,
                     c.JC_Deliverydate,
                     d.Mv_ModelName,
                     c.JC_Engineno,
                     c.JC_Grandtotal,
                     c.JC_Keyno,
                     c.JC_Regno,
                     c.JC_Kmcovered,
                     c.JC_MobileNo,
                     c.JC_Phoneno,
                     c.JCTechnisianName,
                     c.JC_SupervisorName,
                     c.JC_Modelname,
                     c.JC_Customername,
                     c.JC_SaleDate,
                     c.JC_ServiceType,
                     e.Ms_Name,
                     c.JC_Time,
                     f.Mt_Name,
                     h.Mc_Name,
                     g.JCS_Amount,
                     g.JCS_Description,
                     g.JCS_Quantity,
                     g.JCS_Rate,
                     g.JCS_Servicecode,
                     g.JCS_Sino
                     

                 }).Distinct().ToList();

       
       txt_date.Text = Convert.ToDateTime(v.First().JC_Date).ToString("dd/MM/yyyy");
        txt_time.Text = v.First().JC_Time;
        txt_jcno.Text = Convert.ToString(v.First().JC_No);
        txt_jcyear.Text = v.First().JC_year;
        ddl_customer.SelectedValue = Convert.ToString(v.First().JC_Customername);
        txt_address.Text = v.First().JC_Caddress;
        txt_phoneno.Text = v.First().JC_MobileNo;
        ddl_Model.SelectedValue = Convert.ToString(v.First().JC_Modelname);
        txt_chassisno.Text = v.First().JC_Chassisno;
        txt_kcovered.Text = v.First().JC_Kmcovered;
        ddl_servicetype.Text = v.First().JC_ServiceType;
        ddl_supervisor.SelectedValue = Convert.ToString(v.First().JC_SupervisorName);
        ddl_technisian.SelectedValue = Convert.ToString(v.First().JCTechnisianName);
        txt_saledate.Text = Convert.ToDateTime(v.First().JC_SaleDate).ToString("dd/MM/yyyy");
        txt_regdno.Text = v.First().JC_Regno;
        txt_engineno.Text = v.First().JC_Engineno;
        txt_keyno.Text = v.First().JC_Keyno;
        txt_deliverydate.Text = Convert.ToDateTime(v.First().JC_Deliverydate).ToString("dd/MM/yyyy");
      
       btn_Submit.ToolTip=Convert.ToString(v.First().JC_No);
        GridView1.DataSource = v.ToList();
        GridView1.DataBind();
        foreach (GridViewRow gr in GridView1.Rows)
        {
            Label lbl_Amount = (Label)gr.FindControl("Labels6");
            decimal TotAmt = Convert.ToDecimal(lbl_Amount.Text);

            Label lblgrandtotal = (Label)GridView1.FooterRow.FindControl("lblgrandtotal");


            total = total + TotAmt;
            lblgrandtotal.Text = Convert.ToString(SmitaClass.SignificantTruncate(total, 2));
            Label1.Text = Convert.ToString(SmitaClass.SignificantTruncate(total, 2));
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

   




    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("Vehicle_QuotationDetailsDatewise.aspx");
    }
    
    protected void imgbtn_SBDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgdelete = (ImageButton)sender;
        string sino = (imgdelete.ToolTip);
        int id = Convert.ToInt32(sino);
        AME_Vehicle_QuotationList vq = db.AME_Vehicle_QuotationList.ToList().First(t => t.Vql_id == id);
        db.DeleteObject(vq);
        db.SaveChanges();
        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Data Deleted Sucessfully..!!');", true);

        string sino0 = Request.QueryString["id"];
        string type = Request.QueryString["Type"];
        string year = Request.QueryString["year"];
        filldata(sino0, type,year);
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {

    }
  
 



    protected void btn_ServiceAdd_Click(object sender, EventArgs e)
    {
        try
        {
            //if (txt_jcno.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Voucher Number Should Not Be Blank..!!'); </script>", false);
            //    txt_jcno.Focus();
            //    return;
            //}
            //if (txt_date.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Date Should Not Be Blank ..!!'); </script>", false);
            //    txt_date.Focus();
            //    return;
            //}
            //if (txt_regdno.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Reg No Should Not Be Blank..!!'); </script>", false);
            //    txt_regdno.Focus();
            //    return;
            //}

            //if (txt_engineno.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Engine No Should Not Be Blank ..!!'); </script>", false);
            //    ddl_Model.Focus();
            //    return;
            //}
            //if (ddl_Model.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Engine No Should Not Be Blank ..!!'); </script>", false);
            //    ddl_Model.Focus();
            //    return;
            //}
            //if (txt_kcovered.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Km. Covered  Should Not Be Blank ..!!'); </script>", false);
            //    txt_kcovered.Focus();
            //    return;
            //}
            //if (ddl_servicetype.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Service Type ..!!'); </script>", false);
            //    ddl_servicetype.Focus();
            //    return;
            //}
            //if (ddl_supervisor.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Superviser Name ..!!'); </script>", false);
            //    ddl_supervisor.Focus();
            //    return;
            //}
            //if (ddl_technisian.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Technisian Name ..!!'); </script>", false);
            //    ddl_technisian.Focus();
            //    return;
            //}
            //if (txt_time.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Time  Should Not Be Blank..!!'); </script>", false);
            //    txt_time.Focus();
            //    return;
            //}
            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy", "dd-MM-yyyy" };
            DateTime expectedDate;
            if (!DateTime.TryParseExact(txt_date.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                txt_date.Focus();
                return;
            }
            if (!DateTime.TryParseExact(txt_deliverydate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                txt_deliverydate.Focus();
                return;
            }

            ////////////////////////////////

            //if (txt_SCode.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Service Code Should Not Be Blank..!!'); </script>", false);
            //    txt_SCode.Focus();
            //    return;
            //}
            //if (txt_SDescription.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Description Should Not Be Blank..!!'); </script>", false);
            //    txt_SDescription.Focus();
            //    return;
            //}

            //if (txt_SQuantity.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Quantity Should Not Be Blank..!!'); </script>", false);
            //    txt_SQuantity.Focus();
            //    return;
            //}

            //if (txt_SRate.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Rate Should Not Be Blank..!!'); </script>", false);
            //    txt_SRate.Focus();
            //    return;
            //}
            //if (txt_SAmount.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Amount Should Not Be Blank..!!'); </script>", false);
            //    txt_SAmount.Focus();
            //    return;
            //}

            if (btn_ServiceAdd0.Text == "Add")
            {
                AME_Service_JobCardServiceDetails pr1 = new AME_Service_JobCardServiceDetails();
                pr1.Branch_Name = Session["Branch"].ToString();
                pr1.Created_By = Session["Uid"].ToString();
                pr1.Created_Date = SmitaClass.IndianTime();
                pr1.JC_No = Convert.ToInt32(txt_jcno.Text);
                pr1.Jc_year = txt_jcyear.Text;
                pr1.JCS_Amount = Convert.ToDecimal(txt_SAmount.Text);
                pr1.JCS_Description = txt_SDescription.Text;
                pr1.JCS_Quantity = Convert.ToDecimal(txt_SQuantity.Text);
                pr1.JCS_Rate = Convert.ToDecimal(txt_SRate.Text);
                pr1.JCS_Servicecode = txt_SCode.Text;
                pr1.JCS_Status = "OPEN";
                db.AddToAME_Service_JobCardServiceDetails(pr1);
                db.SaveChanges();
                string sino = Request.QueryString["id"];
                string type = Request.QueryString["Type"];
                string year=Request.QueryString["year"];
                fillEdit(sino, type,year);


                txt_SCode.Text = "";
                txt_SDescription.Text = "";
                txt_SQuantity.Text = "";
                txt_SRate.Text = "";
                txt_SAmount.Text = "";
                txt_SCode.Focus();
            }
            if (btn_ServiceAdd0.Text == "Update")
            {
                string branchname = btn_ServiceAdd0.CommandArgument;
                int sino = Convert.ToInt32(btn_ServiceAdd0.ToolTip);
                AME_Service_JobCardServiceDetails sd = db.AME_Service_JobCardServiceDetails.First(t => t.JCS_Sino == sino && t.Branch_Name == branchname && t.Jc_year== txt_jcyear.Text);
                sd.JCS_Amount = Convert.ToDecimal(txt_SAmount.Text);
                sd.JCS_Description = txt_SDescription.Text;
                sd.JCS_Quantity = Convert.ToDecimal(txt_SQuantity.Text);
                sd.JCS_Rate = Convert.ToDecimal(txt_SRate.Text);
                sd.JCS_Servicecode = txt_SCode.Text;
                db.SaveChanges();
                btn_ServiceAdd0.Text = "Add";
                string sino0 = Request.QueryString["id"];
                string type = Request.QueryString["Type"];
                string year=Request.QueryString["year"];
                fillEdit(sino0, type,year);
            }

        }
        catch
        {

        }
    }
    protected void imgbtn_SDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgdelete = (ImageButton)sender;
        int sino = Convert.ToInt32(imgdelete.ToolTip);
        string branchname = Session["Branch"].ToString();
        AME_Service_JobCardServiceDetails vq = db.AME_Service_JobCardServiceDetails.First(t => t.JCS_Sino == sino && t.Branch_Name == branchname && t.Jc_year==txt_jcyear.Text);
        db.DeleteObject(vq);
        db.SaveChanges();
        string sino0 = Request.QueryString["id"];
        string type = Request.QueryString["Type"];
        string year = Request.QueryString["year"];
        fillEdit(sino0, type,year);

    }

    [System.Web.Services.WebMethod]
    public static string[] GetServiceCode(string prefixText, int count)
    {
        string branch = HttpContext.Current.Session["Branch"].ToString();
        string Sale = HttpContext.Current.Session["saletype"].ToString();
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
    protected void txt_SCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string branch = Session["Branch"].ToString();
            var v = from k in db.AME_Master_ServiceHead.ToList()
                    where (k.Mh_ServiceCode.Equals(txt_SCode.Text) && k.Branch_Name==branch)
                    select new
                    {
                        k.Mh_ServiceHead,
                        k.Mh_ServiceCode,
                        k.Mh_ServiceRate
                    };

            txt_SCode.Text = v.First().Mh_ServiceCode;
            txt_SDescription.Text = Convert.ToString(v.First().Mh_ServiceHead);
            txt_SRate.Text = Convert.ToString(v.First().Mh_ServiceRate);
            txt_SQuantity.Focus();
        }
        catch
        {
            txt_SCode.Text = "";
            txt_SDescription.Text = "";
            txt_SRate.Text = "";
            txt_SQuantity.Focus();
        }
    }
    protected void ddl_customer_SelectedIndexChanged(object sender, EventArgs e)
    {
        int cid = Convert.ToInt32(ddl_customer.SelectedValue);
        var v = from c in db.AME_Master_Customer.Where(t => t.Mc_Id == cid) select c;
        txt_address.Text = v.First().Mc_Address + "," + v.First().Mc_Pinno;
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {

            //if (txt_jcno.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Voucher Number Should Not Be Blank..!!'); </script>", false);
            //    txt_jcno.Focus();
            //    return;
            //}
            //if (txt_date.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Date Should Not Be Blank ..!!'); </script>", false);
            //    txt_date.Focus();
            //    return;
            //}
            //if (txt_regdno.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Reg No Should Not Be Blank..!!'); </script>", false);
            //    txt_regdno.Focus();
            //    return;
            //}

            //if (txt_engineno.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Engine No Should Not Be Blank ..!!'); </script>", false);
            //    ddl_Model.Focus();
            //    return;
            //}
            //if (ddl_Model.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Engine No Should Not Be Blank ..!!'); </script>", false);
            //    ddl_Model.Focus();
            //    return;
            //}
            //if (txt_kcovered.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Km. Covered  Should Not Be Blank ..!!'); </script>", false);
            //    txt_kcovered.Focus();
            //    return;
            //}
            //if (ddl_servicetype.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Service Type ..!!'); </script>", false);
            //    ddl_servicetype.Focus();
            //    return;
            //}
            //if (ddl_supervisor.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Superviser Name ..!!'); </script>", false);
            //    ddl_supervisor.Focus();
            //    return;
            //}
            //if (ddl_technisian.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Technisian Name ..!!'); </script>", false);
            //    ddl_technisian.Focus();
            //    return;
            //}
            //if (txt_time.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Time  Should Not Be Blank..!!'); </script>", false);
            //    txt_time.Focus();
            //    return;
            //}
            //if (ddl_technisian.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Technisian Name ..!!'); </script>", false);
            //    ddl_technisian.Focus();
            //    return;
            //}
            //if (ddl_customer.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Customer Name ..!!'); </script>", false);
            //    ddl_customer.Focus();
            //    return;
            //}
            //if (txt_address.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Address Shoul Not Be Blank ..!!'); </script>", false);
            //    txt_address.Focus();
            //    return;
            //}
            //if (txt_phoneno.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Phone No Shoul Not Be Blank ..!!'); </script>", false);
            //    txt_phoneno.Focus();
            //    return;
            //}
            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy", "dd-MM-yyyy" };
            DateTime expectedDate;
            if (!DateTime.TryParseExact(txt_date.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                txt_date.Focus();
                return;
            }
            if (!DateTime.TryParseExact(txt_deliverydate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                txt_deliverydate.Focus();
                return;
            }
            if(GridView1.Rows.Count<=0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Please Add Service Details..!!');", true);
               
                return;

            }
           

                int jcno=Convert.ToInt32(btn_Submit.ToolTip);
            string bname =  Session["Branch"].ToString();
                AME_Service_JobCardEntry jce = db.AME_Service_JobCardEntry.First(t => t.JC_No == jcno && t.Branch_Name == bname && t.JC_year== txt_jcyear.Text );
               
                jce.JC_Chassisno = txt_chassisno.Text;
                jce.JC_Date = Convert.ToDateTime(txt_date.Text, SmitaClass.dateformat());

                jce.JC_Deliverydate = Convert.ToDateTime(txt_deliverydate.Text, SmitaClass.dateformat());
                jce.JC_Engineno = txt_engineno.Text;
                jce.JC_Keyno = txt_keyno.Text;
                jce.JC_Kmcovered = txt_kcovered.Text;
                jce.JC_MobileNo = txt_phoneno.Text;
                jce.JC_Modelname = Convert.ToInt32(ddl_Model.SelectedValue);
                jce.JC_No = Convert.ToInt32(txt_jcno.Text);
                jce.JC_year = txt_jcyear.Text;
                jce.JC_Phoneno = txt_phoneno0.Text;
                jce.JC_Regno = txt_regdno.Text;
                jce.JC_Residenceno = txt_phoneno1.Text;
                jce.JC_SaleDate = Convert.ToDateTime(txt_saledate.Text, SmitaClass.dateformat());
                jce.JC_ServiceType = ddl_servicetype.SelectedItem.Text;
                jce.JC_SupervisorName = Convert.ToInt32(ddl_supervisor.SelectedValue);
                jce.JCTechnisianName = Convert.ToInt32(ddl_technisian.SelectedValue);
                jce.JC_Time = txt_time.Text;
                jce.Ms_Status = "OPEN";
                jce.JC_Grandtotal =Convert.ToDecimal(Label1.Text);
                jce.JC_Customername = Convert.ToInt32(ddl_customer.SelectedValue);
                jce.JC_Caddress = txt_address.Text;
                
                db.SaveChanges();


               

                Session["sino"] = txt_jcno.Text;
                //Response.Redirect("Service_Print_Jobcard.aspx");
                //ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Data Added Sucessfuly)..!!');", true);

                if (Session["Branch"].ToString() == "Cuttack")
                {

                  

                    Response.Redirect("Service_Print_Jobcard.aspx", false);        //write redirect
                    HttpContext.Current.ApplicationInstance.CompleteRequest(); // end response
                    // ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Data Added Sucessfuly)..!!');", true);
                    // Response.Redirect("Service_Print_Jobcard.aspx");
                }
                else if (Session["Branch"].ToString() == "Paradeep")
                {
                    // ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Data Added Sucessfuly)..!!');", true);
                   
                    Response.Redirect("Service_Print_Jobcard_Anugul.aspx", false);        //write redirect
                    HttpContext.Current.ApplicationInstance.CompleteRequest(); // end response
                    // Response.Redirect("Service_Print_Jobcard_Anugul.aspx");
                }
                else if (Session["Branch"].ToString() == "Berhampur")
                {
                    // ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Data Added Sucessfuly)..!!');", true);
                   
                    Response.Redirect("Service_Print_Jobcard_Berhampur.aspx", false);        //write redirect
                    HttpContext.Current.ApplicationInstance.CompleteRequest(); // end response
                    //  Response.Redirect("Service_Print_Jobcard_Berhampur.aspx");
                }
                else
                {
                    // ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Data Added Sucessfuly)..!!');", true);
                  
                    Response.Redirect("Service_Print_Jobcard_Phulnakhara.aspx", false);        //write redirect
                    HttpContext.Current.ApplicationInstance.CompleteRequest(); // end response
                    //  Response.Redirect("Service_Print_Jobcard_Phulnakhara.aspx");
                }

            }

        catch(Exception ex)
        {
           // string s = ex.ToString();
        }
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {

    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("Service_JobEntry_List.aspx");
    }
    protected void imgbtn_edit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string branchname = Session["Branch"].ToString();
            ImageButton imgbtnEdit = (ImageButton)sender;
            string sno=imgbtnEdit.ToolTip;
            foreach (GridViewRow gr in GridView1.Rows)
            {
                gr.BackColor = System.Drawing.Color.Transparent;
            }

            GridViewRow row = imgbtnEdit.NamingContainer as GridViewRow;
            row.BackColor = System.Drawing.Color.Pink;
            int no=Convert.ToInt32(sno);
            var service = from c in db.AME_Service_JobCardServiceDetails.Where(t => t.JCS_Sino == no && t.Branch_Name == branchname && t.Jc_year == txt_jcyear.Text) select c;
            txt_SCode.Text = service.First().JCS_Servicecode;
            txt_SDescription.Text = service.First().JCS_Description;
            txt_SQuantity.Text =Convert.ToString(service.First().JCS_Quantity);
            txt_SRate.Text = Convert.ToString(service.First().JCS_Rate);
            txt_SAmount.Text = Convert.ToString(service.First().JCS_Amount);
            btn_ServiceAdd0.ToolTip = Convert.ToString(service.First().JCS_Sino);
            btn_ServiceAdd0.CommandArgument = service.First().Branch_Name;
            btn_ServiceAdd0.Text = "Update";
        }
        catch
        {

        }
    }
}