using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;

public partial class Admin_CreateUser : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    Clear cl = new Clear();
    public string uname;
    protected void Page_Load(object sender, EventArgs e)
    {

        //if (Session["Usertype"] !=null)
        //{
        //    Response.Redirect("AccessDenied.aspx");
        //}
        if (!IsPostBack)
        {
            FillGrid();
        }
      
    }

   
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        if (btn_submit.Text == "Submit")
        {
            cl.Clear_All(this);
            FillGrid();
        }
        else if (btn_submit.Text == "Update")
        {
            cl.Clear_All(this);
            FillGrid();
            btn_submit.Text = "Submit";
        }
    }


    protected void btn_submit_Click(object sender, EventArgs e)
    {
        string Branch = Convert.ToString(Session["Branch"]);
        string Sale = Session["saletype"].ToString();
        if (txt_category.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('CATEGORY SHOULD NOT BE BLANK..!!!');</script>", false);
            txt_category.Focus();
            return;
        }
        if (txt_ModelName.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('MODEL NAME SHOULD NOT BE BLANK..!!!');</script>", false);
            txt_ModelName.Focus();
            return;
        }
        if (txt_Specification.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('SPECIFICATION SHOULD NOT BE BLANK..!!!');</script>", false);
            txt_Specification.Focus();
            return;
        }
        if (txt_HPower.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('H POWER Should Not Be Blank..!!!');</script>", false);
            txt_HPower.Focus();
            return;
        }
        //if (ddl_FuelUsed.SelectedIndex == 0)
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Fuel Used..!!!');</script>", false);
        //    ddl_FuelUsed.Focus();
        //    return;
        //}
        if (txt_vehicledescription.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Vehicle Description Should Not Be Blank..!!!');</script>", false);
            txt_vehicledescription.Focus();
            return;
        }
        if (txt_UnladedWeight.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Unloaden Should Not Be Blank..!!!');</script>", false);
            txt_UnladedWeight.Focus();
            return;
        }
        if (btn_submit.Text == "Submit")
        {
            var check = from c in db.AME_Master_VehicleModel.Where(t => t.Mv_ModelName == txt_ModelName.Text && t.Branch_Name == Branch && t.Mv_SaleStatus==Sale) select c;
            if (Convert.ToInt32(check.Count()) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Model Name Already Exist,Please Try Different..!!!');</script>", false);
                txt_ModelName.Focus();
                return;
            }

            AME_Master_VehicleModel vm = new AME_Master_VehicleModel();
            vm.Mv_VehicleType = ddl_VType.SelectedValue;
            vm.Mv_Category = txt_category.Text;
            vm.Mv_ModelName = txt_ModelName.Text;
            vm.Mv_Specification = txt_Specification.Text;
            vm.Mv_Makers = ddl_VMaker.SelectedValue;
            vm.Mv_HPower = txt_HPower.Text;
            vm.Mv_FrontAxel = txt_FrontAxel.Text;
            vm.Mv_RearAxel = txt_RearAxel.Text;
            vm.Mv_OtherAxel = txt_OtherAxel.Text;
            vm.Mv_TandemAxel = txt_TandemAxel.Text;
            vm.Mv_FuelUsed = ddl_FuelUsed.SelectedValue;
            vm.Mv_Cylinders = txt_Cylinders.Text;
            vm.Mv_SeatCapacity = txt_SeatCapacity.Text;
            vm.Mv_UnladedWeight = txt_UnladedWeight.Text;
            vm.Mv_GrossWeight = txt_GrossWeight.Text;
            vm.Mv_Rate = txt_MrpRate.Text;
            vm.Status = true;
            vm.Mv_SaleStatus = Sale;
            vm.Branch_Name = Session["Branch"].ToString();
            vm.Created_By = Session["Uid"].ToString();
            vm.Created_Date = SmitaClass.IndianTime();
            db.AddToAME_Master_VehicleModel(vm);
            db.SaveChanges();

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Model Created Successfully..!!!');</script>", false);
            cl.Clear_All(this);
            FillGrid();
        }
        else if (btn_submit.Text == "Update")
        {
            int ModelId = Convert.ToInt32(btn_submit.ToolTip);
            var check = from c in db.AME_Master_VehicleModel.Where(t => t.Mv_ModelName == txt_ModelName.Text && t.Mv_Id!=ModelId) select c;
            if (Convert.ToInt32(check.Count()) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Model Name Already Exist,Please Try Different..!!!');</script>", false);
                txt_ModelName.Focus();
                return;
            }

            AME_Master_VehicleModel vm = db.AME_Master_VehicleModel.First(t => t.Mv_Id == ModelId);
            vm.Mv_VehicleType = ddl_VType.SelectedValue;
            vm.Mv_Category = txt_category.Text;
            vm.Mv_ModelName = txt_ModelName.Text;
            vm.Mv_Specification = txt_Specification.Text;
            vm.Mv_Makers = ddl_VMaker.SelectedValue;
            vm.Mv_HPower = txt_HPower.Text;
            vm.Mv_FrontAxel = txt_FrontAxel.Text;
            vm.Mv_RearAxel = txt_RearAxel.Text;
            vm.Mv_OtherAxel = txt_OtherAxel.Text;
            vm.Mv_TandemAxel = txt_TandemAxel.Text;
            vm.Mv_FuelUsed = ddl_FuelUsed.SelectedValue;
            vm.Mv_Cylinders = txt_Cylinders.Text;
            vm.Mv_SeatCapacity = txt_SeatCapacity.Text;
            vm.Mv_UnladedWeight = txt_UnladedWeight.Text;
            vm.Mv_GrossWeight = txt_GrossWeight.Text;
            vm.Mv_Rate = txt_MrpRate.Text;
            vm.Status = true;

            vm.Branch_Name = Session["Branch"].ToString();
            vm.Created_By = Session["Uid"].ToString();
            vm.Created_Date = SmitaClass.IndianTime();
            db.SaveChanges();

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Model Details Updated Successfully..!!!');</script>", false);
            cl.Clear_All(this);
            FillGrid();
            btn_submit.Text = "Submit";
            btn_submit.ToolTip = "";
        }


    }
    private void FillGrid()
    {
        string Branch = Convert.ToString(Session["Branch"]);
        string Sale = Session["saletype"].ToString();
        if (Session["saletype"] != null)
        {
            var v = from c in db.AME_Master_VehicleModel.ToList().Where(t => t.Branch_Name == Branch && t.Mv_SaleStatus == Sale) select c;
            GridView1.DataSource = v.ToList();
            GridView1.DataBind();

            foreach (GridViewRow gr in GridView1.Rows)
            {
                ImageButton edit = (ImageButton)gr.FindControl("imgbtnedit");

                    edit.Visible = false;
                   
                
            }
        }
        else
        {
            var v = from c in db.AME_Master_VehicleModel.ToList().Where(t => t.Branch_Name == Branch) select c;
            GridView1.DataSource = v.ToList();
            GridView1.DataBind();
        }
        
    }
    protected void imgbtnedit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton Img_edit = (ImageButton)sender;
        int ModelId = Convert.ToInt32(Img_edit.ToolTip);

        foreach (GridViewRow gr in GridView1.Rows)
        {
            gr.BackColor = System.Drawing.Color.Transparent;
        }

        GridViewRow row = Img_edit.NamingContainer as GridViewRow;
        row.BackColor = System.Drawing.Color.Pink;
       
        var v = from c in db.AME_Master_VehicleModel.ToList() where c.Mv_Id == ModelId select c;

        ddl_VType.SelectedValue=v.First().Mv_VehicleType.ToString();
        txt_category.Text = v.First().Mv_Category.ToString();
        txt_ModelName.Text = v.First().Mv_ModelName.ToString();
        txt_Specification.Text = v.First().Mv_Specification.ToString();
        ddl_VMaker.SelectedValue = v.First().Mv_Makers.ToString();
        txt_HPower.Text = v.First().Mv_HPower.ToString();
        txt_FrontAxel.Text = v.First().Mv_FrontAxel.ToString();
        txt_RearAxel.Text = v.First().Mv_RearAxel.ToString();
        txt_OtherAxel.Text = v.First().Mv_OtherAxel.ToString();
        txt_TandemAxel.Text = v.First().Mv_TandemAxel.ToString();
        ddl_FuelUsed.SelectedValue = v.First().Mv_FuelUsed.ToString();
        txt_Cylinders.Text = v.First().Mv_Cylinders.ToString();
        txt_SeatCapacity.Text = v.First().Mv_SeatCapacity.ToString();
        txt_UnladedWeight.Text = v.First().Mv_UnladedWeight.ToString();
        txt_GrossWeight.Text = v.First().Mv_GrossWeight.ToString();
        txt_MrpRate.Text = v.First().Mv_Rate.ToString();

        btn_submit.Text = "Update";
        btn_submit.ToolTip = ModelId.ToString();
    }
}