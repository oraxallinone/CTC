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


            FillGrid();
            
        }
    }
    [System.Web.Services.WebMethod]
    public static string[] GetPartNo(string prefixText, int count)
    {
        string branch = HttpContext.Current.Session["Branch"].ToString();
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Service_JobCardEntry.Where(n => n.JC_Regno.StartsWith(prefixText) && n.Branch_Name == branch).OrderBy(n => n.JC_Regno).Select(n => n.JC_Regno).Distinct().Take(count).ToArray();
    }
    decimal total = 0;
    public void FillGrid()
    {
        try
        {
            string Branch = Session["Branch"].ToString();
            string regno = txtInput.Text;
            string param = "@Regno,@Branch";
            string paramvalue = regno + "," + Branch;

            DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_JobCardOutsideServiceListRegnowise", param, paramvalue);
            GridView1.DataSource = dtr;
            GridView1.DataBind();
            foreach (GridViewRow gr in GridView1.Rows)
            {
                Label lblamount = (Label)gr.FindControl("lblamount");
                decimal amount = Convert.ToDecimal(lblamount.Text);
               
                Label lbltotal = (Label)GridView1.FooterRow.FindControl("lbltotal");
                total = total + amount;
                lbltotal.Text = Convert.ToString(total);
                ImageButton del = (ImageButton)gr.FindControl("imgbtndelete");
                if (Session["saletype"] != null)
                {
                    del.Visible = false;
                }

            }
           
        }
        catch
        {

        }

    }
   
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            string Branch = Session["Branch"].ToString();
            if (txtInput.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Registration No Should Not Be Blank..!!!');</script>", false);
                txtInput.Focus();
                return;
            }
            if (txtInput.Text != "")
            {

                var query = from c in db.AME_Service_JobCardEntry.Where(t => t.JC_Regno == txtInput.Text && t.Branch_Name ==Branch ) select c;
                if (Convert.ToInt32(query.Count()) > 0)
                {

                    FillGrid();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invalid Registration No..!!!');</script>", false);
                    txtInput.Text = "";
                    txtInput.Focus();
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    return;
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
}