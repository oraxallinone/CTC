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
        if (txt_Name.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('TECHNICIAN NAME SHOULD NOT BE BLANK..!!!');</script>", false);
            txt_Name.Focus();
            return;
        }
        if (txt_MobileNo.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('MOBILE NO SHOULD NOT BE BLANK..!!!');</script>", false);
            txt_MobileNo.Focus();
            return;
        }
        

        if (btn_submit.Text == "Submit")
        {
            var check = from c in db.AME_Master_Technician.Where(t => t.Mt_Name == txt_Name.Text && t.Branch_Name == Branch) select c;
            if (Convert.ToInt32(check.Count()) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Name Already Exist,Please Try Different..!!!');</script>", false);
                txt_Name.Focus();
                return;
            }

            AME_Master_Technician vm = new AME_Master_Technician();
            vm.Mt_Name = txt_Name.Text;
            vm.Mt_Mobile = txt_MobileNo.Text;
            vm.Status = true;

            vm.Branch_Name = Session["Branch"].ToString();
            vm.Created_By = Session["Uid"].ToString();
            vm.Created_Date = SmitaClass.IndianTime();
            db.AddToAME_Master_Technician(vm);
            db.SaveChanges();

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('TECHNICIAN ADDED Successfully..!!!');</script>", false);
            cl.Clear_All(this);
            FillGrid();
        }
        else if (btn_submit.Text == "Update")
        {
            int ModelId = Convert.ToInt32(btn_submit.ToolTip);
            var check = from c in db.AME_Master_Technician.Where(t => t.Mt_Name == txt_Name.Text && t.Mt_Id != ModelId) select c;
            if (Convert.ToInt32(check.Count()) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Name Already Exist,Please Try Different..!!!');</script>", false);
                txt_Name.Focus();
                return;
            }

            AME_Master_Technician vm = db.AME_Master_Technician.First(t => t.Mt_Id == ModelId);
            vm.Mt_Name = txt_Name.Text;
            vm.Mt_Mobile = txt_MobileNo.Text;
            vm.Status = true;

            vm.Branch_Name = Session["Branch"].ToString();
            vm.Created_By = Session["Uid"].ToString();
            vm.Created_Date = SmitaClass.IndianTime();
            db.SaveChanges();

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Details Updated Successfully..!!!');</script>", false);
            cl.Clear_All(this);
            FillGrid();
            btn_submit.Text = "Submit";
            btn_submit.ToolTip = "";
        }


    }
    private void FillGrid()
    {
        var v = from c in db.AME_Master_Technician.ToList()
                where c.Branch_Name == Session["Branch"].ToString()
                select c;
        GridView1.DataSource = v.ToList();
        GridView1.DataBind();
        foreach (GridViewRow gr in GridView1.Rows)
        {
            ImageButton edit = (ImageButton)gr.FindControl("imgbtnedit");

            if (Session["saletype"] != null)
            {
                edit.Visible = false;
            }
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

        var v = from c in db.AME_Master_Technician.ToList() where c.Mt_Id == ModelId select c;

        txt_Name.Text = v.First().Mt_Name.ToString();
        txt_MobileNo.Text = v.First().Mt_Mobile.ToString();

        btn_submit.Text = "Update";
        btn_submit.ToolTip = ModelId.ToString();
    }
}