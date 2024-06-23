using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Data;
using System.Globalization;
public partial class admin_EmployeeDetails : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    public string partno;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            txt_formdate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
            txt_todate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
            FillGrid();
            //GridView1.HeaderRow.Cells[6].Text = "Edit";
           
        }
    }

    public void FillGrid()
    {
        try
        {
            string Branch = Session["Branch"].ToString();
            string param = "@Fromdate,@Todate,@Branch";
            string paramvalue = Convert.ToDateTime(txt_formdate.Text, SmitaClass.dateformat()).ToString("yyyy-MM-dd HH:mm:ss") + " , " + Convert.ToDateTime(txt_todate.Text, SmitaClass.dateformat()).ToString("yyyy-MM-dd HH:mm:ss") + "," + Branch;

            DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_JobCardOutsideServiceList", param, paramvalue);
            GridView1.DataSource = dtr;
            GridView1.DataBind();

            foreach (GridViewRow gr in GridView1.Rows)
            {
                ImageButton edit = (ImageButton)gr.FindControl("imgbtnedit");
                ImageButton del = (ImageButton)gr.FindControl("imgbtndelete");


                 if (Session["saletype"] != null)
                    {
                        edit.Visible = false;
                        del.Visible = false;
                    }
            }
        }
        catch
        {

        }

    }

  


    protected void imgbtnview_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton img = (ImageButton)sender;
            string imgid = img.ToolTip;


            GridView1.Columns[4].HeaderText = "Edit";
         
            foreach (GridViewRow gr in GridView1.Rows)
            {
                ImageButton imgFc = (ImageButton)gr.FindControl("imgbtnview");
                string id = imgFc.ToolTip;
                int slno = Convert.ToInt32(id);
                if (imgid == id)
                {
                    TextBox txtamount = (TextBox)gr.FindControl("txtamount");
                    TextBox txtservicedetails = (TextBox)gr.FindControl("txtservicedetails");
                    //GridView1.Columns[6].HeaderText = "View";
                    string service = txtservicedetails.Text;
                    decimal amount = Convert.ToDecimal(txtamount.Text);

                    AME_Service_JobCardOutside_Service pc = db.AME_Service_JobCardOutside_Service.First(t => t.JCO_Id == slno);
                    pc.JCO_ServiceDetails = service;
                   
                    pc.JCO_Amount = amount;
                    db.SaveChanges();

                    ImageButton imgFcc = (ImageButton)gr.FindControl("imgbtnedit");
                 
                    txtamount.ReadOnly = true;
                    txtservicedetails.ReadOnly = true;
                    
                    imgFc.Visible = true;
                    imgFcc.Visible = false;
                    FillGrid();
                    GridView1.Columns[6].HeaderText = "";
                }

            }
        }
        catch
        {

        }
        
    }
    protected void imgbtnedit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            ImageButton edit = (ImageButton)sender;
            int id = Convert.ToInt32(edit.ToolTip);


            GridView1.Columns[6].HeaderText = "";
          
            foreach (GridViewRow gr in GridView1.Rows)
            {
                ImageButton imgFc = (ImageButton)gr.FindControl("imgbtnedit");
                int id1 = Convert.ToInt32(imgFc.ToolTip);
                if (id1 == id)
                {
                    TextBox txtamount = (TextBox)gr.FindControl("txtamount");
                    TextBox txtservicedetails = (TextBox)gr.FindControl("txtservicedetails");
                    //GridView1.Columns[6].HeaderText = "View";

                    ImageButton imgFcc = (ImageButton)gr.FindControl("imgbtnview");
                    txtamount.ReadOnly = false;
                    txtservicedetails.ReadOnly = false;
                    txtamount.BackColor = System.Drawing.Color.YellowGreen;
                    txtservicedetails.BackColor = System.Drawing.Color.Pink;
                   

                    imgFc.Visible = false;
                    imgFcc.Visible = true;
                    GridView1.Columns[6].HeaderText = "View";
                }
            }
        }
        catch
        {

        }
    }
    protected void imgbtndelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton delete = (ImageButton)sender;
            int id = Convert.ToInt32(delete.ToolTip);
            string branch = Session["Branch"].ToString();
            AME_Service_JobCardOutside_Service jse = db.AME_Service_JobCardOutside_Service.First(t => t.JCO_Id == id && t.Ms_Status == "OPEN" && t.Branch_Name==branch);
            db.DeleteObject(jse);
            db.SaveChanges();
            FillGrid();
          
        }
        catch
        {

        }
    }
 
  
    protected void btn_Show_Click(object sender, EventArgs e)
    {
        try
        {


            if (txt_formdate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('From Date SHOULD NOT BE BLANK...!!');", true);
                txt_formdate.Focus();
                return;
            }
            if (txt_todate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('To Date SHOULD NOT BE BLANK...!!');", true);
                txt_todate.Focus();
                return;
            }

            if (Convert.ToDateTime(txt_todate.Text, SmitaClass.dateformat()) < Convert.ToDateTime(txt_formdate.Text, SmitaClass.dateformat()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('To Date Must Be Greater Than From Date..!!');", true);
                txt_todate.Focus();
                return;
            }
            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy" };
            DateTime expectedDate;
            if (!DateTime.TryParseExact(txt_formdate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                txt_formdate.Focus();
                return;
            }
            if (!DateTime.TryParseExact(txt_todate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                txt_todate.Focus();
                return;
            }


            FillGrid();

        }
        catch
        {

        }
    }
}