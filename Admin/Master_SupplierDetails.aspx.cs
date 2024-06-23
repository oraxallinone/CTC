using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;


public partial class admin_EmployeeDetails : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    string id = "";
    string ValueType = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            id = "";
            ValueType = "";
            FillGrid(id, ValueType);

        }
    }

    private void FillGrid(string id, string ValueType)
    {

        if (ValueType == "Name")
        {
            var query = from c in db.AME_Master_Supplier.ToList().Where(t => t.Ms_Name.StartsWith(id) && t.Ms_Status == true)
                        where c.Branch_Name == Session["Branch"].ToString()
                        select new
                        {
                            empid = c.Ms_Id,
                            empcode = c.Ms_code,
                            empName = c.Ms_Name,
                            empcontNo = c.Ms_Mobileno,
                            empstatus=c.Ms_Status

                        };
            GridView1.DataSource = query;
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
        else if (ValueType == "Code")
        {
            var query = from c in db.AME_Master_Supplier.ToList().Where(t => t.Ms_code.StartsWith(id) && t.Ms_Status == true)
                        where c.Branch_Name == Session["Branch"].ToString()
                        select new
                        {
                            empid = c.Ms_Id,
                            empcode = c.Ms_code,
                            empName = c.Ms_Name,
                            empcontNo = c.Ms_Mobileno,
                            empstatus = c.Ms_Status
                        };
            GridView1.DataSource = query;
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
        else if (ValueType == "Contact No")
        {
            var query = from c in db.AME_Master_Supplier.ToList().Where(t => t.Ms_Mobileno.StartsWith(id) && t.Ms_Status == true)
                        where c.Branch_Name == Session["Branch"].ToString()
                        select new
                        {
                            empid = c.Ms_Id,
                            empcode = c.Ms_code,
                            empName = c.Ms_Name,
                            empcontNo = c.Ms_Mobileno,
                            empstatus = c.Ms_Status

                        };
            GridView1.DataSource = query;
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
        else if (ValueType == "")
        {
            var query = from c in db.AME_Master_Supplier.ToList().OrderBy(t => t.Ms_Id).Where(t => t.Ms_Status == true)
                        where c.Branch_Name == Session["Branch"].ToString()
                        select new
                        {
                            empid = c.Ms_Id,
                            empcode = c.Ms_code,
                            empName = c.Ms_Name,
                            empcontNo = c.Ms_Mobileno,
                            empstatus = c.Ms_Status
                        };

            GridView1.DataSource = query.ToList();
            GridView1.DataBind();
           
            foreach (GridViewRow gr in GridView1.Rows)
            {
                Label lblavilable = (Label)gr.FindControl("lblavilable");
                string staus = Convert.ToString(lblavilable.ToolTip);

                ImageButton edit = (ImageButton)gr.FindControl("imgbtnedit");
                ImageButton del = (ImageButton)gr.FindControl("imgbtndelete");
                if (Session["saletype"] != null)
                {
                    edit.Visible = false;
                    del.Visible = false;
                }

                if (staus == "True")
                {
                    lblavilable.Text = "Available";
                    lblavilable.ForeColor = System.Drawing.Color.SeaGreen;
                   
                }
                else
                {

                   
                    lblavilable.Text = "NotAvailable";
                    lblavilable.ForeColor = System.Drawing.Color.Red;

                }
            }


        }
    }

  


    protected void imgbtnview_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton view = (ImageButton)sender;
        string id = Convert.ToString(view.ToolTip);
        Response.Redirect("Master_SupplierRegistration.aspx?id=" + id + "&Type=" + "View");
    }
    protected void imgbtnedit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton view = (ImageButton)sender;
        string id = Convert.ToString(view.ToolTip);

        Response.Redirect("Master_SupplierRegistration.aspx?id=" + id + "&Type=" + "Edit");
    }
    protected void imgbtndelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton view = (ImageButton)sender;
            string id = Convert.ToString(view.ToolTip);
            int id1 = Convert.ToInt32(id);

            AME_Master_Supplier jse = db.AME_Master_Supplier.First(t => t.Ms_Id == id1 && t.Ms_Status == true);
            jse.Ms_Status = false;
            db.SaveChanges();
            id = "";
            ValueType = "";
            FillGrid(id, ValueType);
        }
        catch
        {

        }
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtInput.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Give Your SupplierCode OR Name OR Contact No..!!!');</script>", false);
                txtInput.Focus();
                return;
            }
            if (rbnName.Checked == true)
            {
                ValueType = "Name";
                id = txtInput.Text;
                FillGrid(id, ValueType);
            }
            else if (rbnCode.Checked == true)
            {
                ValueType = "Code";
                id = txtInput.Text;
                FillGrid(id, ValueType);
            }
            else if (rbnContact.Checked == true)
            {
                ValueType = "Contact No";
                id = txtInput.Text;
                FillGrid(id, ValueType);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('First Select Search By Option Then Search...!!!'); </script>", false);
            }
        }
        catch
        {

        }
    }
}