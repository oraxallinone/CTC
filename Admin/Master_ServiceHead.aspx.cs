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

        if (txt_SCode.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('SERVICE CODE SHOULD NOT BE BLANK..!!!');</script>", false);
            txt_SCode.Focus();
            return;
        }
        if (txt_SName.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('SERVICE NAME SHOULD NOT BE BLANK..!!!');</script>", false);
            txt_SName.Focus();
            return;
        }
        if (txt_SRate.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('RATE SHOULD NOT BE BLANK..!!!');</script>", false);
            txt_SRate.Focus();
            return;
        }
        

        if (btn_submit.Text == "Submit")
        {
            string Branch = Convert.ToString(Session["Branch"]);
            string Sale = Session["saletype"].ToString();
            var check = from c in db.AME_Master_ServiceHead.Where(t => t.Mh_ServiceCode == txt_SCode.Text && t.Branch_Name == Branch && t.Mh_SaleStatus == Sale) select c;
            if (Convert.ToInt32(check.Count()) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Code Already Exist,Please Try Different..!!!');</script>", false);
                txt_SCode.Focus();
                return;
            }
            var check1 = from c in db.AME_Master_ServiceHead.Where(t => t.Mh_ServiceHead == txt_SName.Text && t.Branch_Name == Branch && t.Mh_SaleStatus==Sale ) select c;
            if (Convert.ToInt32(check.Count()) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Head Already Exist,Please Try Different..!!!');</script>", false);
                txt_SName.Focus();
                return;
            }

            AME_Master_ServiceHead vm = new AME_Master_ServiceHead();
            vm.Mh_ServiceCode = txt_SCode.Text;
            vm.Mh_ServiceHead = txt_SName.Text;
            vm.Mh_ServiceRate = Convert.ToDecimal(txt_SRate.Text);
            vm.saccode =  txt_sac.Text;
            vm.Status = true;
            vm.Mh_SaleStatus = Sale;
            vm.Branch_Name = Session["Branch"].ToString();
            vm.Created_By = Session["Uid"].ToString();
            vm.Created_Date = SmitaClass.IndianTime();
            db.AddToAME_Master_ServiceHead(vm);
            db.SaveChanges();

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('SERVICE HEAD ADDED Successfully..!!!');</script>", false);
            cl.Clear_All(this);
            FillGrid();
        }
        else if (btn_submit.Text == "Update")
        {
            int ModelId = Convert.ToInt32(btn_submit.ToolTip);
            //var check = from c in db.AME_Master_ServiceHead.Where(t => t.Mh_ServiceCode == txt_SCode.Text && t.Mh_Id != ModelId) select c;
            //if (Convert.ToInt32(check.Count()) > 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Code Already Exist,Please Try Different..!!!');</script>", false);
            //    txt_SCode.Focus();
            //    return;
            //}
            //var check1 = from c in db.AME_Master_ServiceHead.Where(t => t.Mh_ServiceHead == txt_SName.Text && t.Mh_Id != ModelId) select c;
            //if (Convert.ToInt32(check.Count()) > 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Head Already Exist,Please Try Different..!!!');</script>", false);
            //    txt_SName.Focus();
            //    return;
            //}

            AME_Master_ServiceHead vm = db.AME_Master_ServiceHead.First(t => t.Mh_Id == ModelId);
            vm.Mh_ServiceCode = txt_SCode.Text;
            vm.Mh_ServiceHead = txt_SName.Text;
            vm.Mh_ServiceRate = Convert.ToDecimal(txt_SRate.Text);
            vm.saccode = txt_sac.Text;
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
        string Branch = Convert.ToString(Session["Branch"]);
        string Sale = Session["saletype"].ToString();
        if (Session["saletype"] != null)
        {
            var v = from c in db.AME_Master_ServiceHead.ToList()
                    where c.Branch_Name == Branch && c.Mh_SaleStatus == Sale
                    select c;
            GridView1.DataSource = v.ToList();
            GridView1.DataBind();

            //foreach (GridViewRow gr in GridView1.Rows)
            //{
            //    ImageButton edit = (ImageButton)gr.FindControl("imgbtnedit");

              
            //        edit.Visible = false;
                
            //}
        }
        else
        {
            var v = from c in db.AME_Master_ServiceHead.ToList()
                    where c.Branch_Name == Branch
                    select c;
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

        var v = from c in db.AME_Master_ServiceHead.ToList() where c.Mh_Id == ModelId select c;

        txt_SCode.Text = v.First().Mh_ServiceCode.ToString();
        txt_SName.Text = v.First().Mh_ServiceHead.ToString();
        txt_SRate.Text = v.First().Mh_ServiceRate.ToString();
        txt_sac.Text = v.First().saccode.ToString();
        btn_submit.Text = "Update";
        btn_submit.ToolTip = ModelId.ToString();
    }
}