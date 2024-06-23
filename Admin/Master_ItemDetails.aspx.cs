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
    public string partno;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //string partno = Request.QueryString["partno"];
            //txtInput.Text = partno;
            FillGrid(0);
        }
    }

    private void FillGrid(int pno)
    {
        string Branch =Convert.ToString(Session["Branch"]);
        if (txtInput.Text != "")
        {
            partno = txtInput.Text;
            var query = from c in db.AME_Master_Item.Where(t => t.Itm_Partno == partno && t.Ms_Status == true && t.Branch_Name == Branch)
                        select new
                        {
                            itamcode = c.Itm_code,
                            categoryname = c.Itm_CategoryName,
                         //  Itm_Partno=c.Itm_Partno,
                            status = c.Ms_Status,
                            Pno = c.Itm_Partno
                        };
            GridView1.DataSource = query.ToList();
            GridView1.PageIndex = pno;
            GridView1.DataBind();

            //foreach (GridViewRow gr in GridView1.Rows)
            //{
            //    ImageButton edit = (ImageButton)gr.FindControl("imgbtnedit");
            //    ImageButton del = (ImageButton)gr.FindControl("imgbtndelete");

            //    if (Session["saletype"] != null)
            //    {
            //        edit.Visible = false;
            //        del.Visible = false;
            //    }
            //}
        }
        else
        {
            var query = from c in db.AME_Master_Item.Where(t => t.Ms_Status == true && t.Branch_Name == Branch)
                        select new
                        {
                            itamcode = c.Itm_code,
                            categoryname = c.Itm_CategoryName,
                           // Itm_Partno = c.Itm_Partno,
                           
                            status = c.Ms_Status,
                            Pno=c.Itm_Partno
                        };
            GridView1.DataSource = query.ToList();
            GridView1.PageIndex = pno;

            GridView1.DataBind();
            //foreach (GridViewRow gr in GridView1.Rows)
            //{
            //    ImageButton edit = (ImageButton)gr.FindControl("imgbtnedit");
            //    ImageButton del = (ImageButton)gr.FindControl("imgbtndelete");

            //    if (Session["saletype"] != null)
            //    {
            //        edit.Visible = false;
            //        del.Visible = false;
            //    }
            //}

        }
            foreach (GridViewRow gr in GridView1.Rows)
            {
                Label lblavilable = (Label)gr.FindControl("lblavilable");
                string staus = Convert.ToString(lblavilable.ToolTip);
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

  


    protected void imgbtnview_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton view = (ImageButton)sender;
        string id = Convert.ToString(view.ToolTip);
        Response.Redirect("Master_Item.aspx?id=" + id + "&Type=" + "View");
    }
    protected void imgbtnedit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton view = (ImageButton)sender;
        string id = Convert.ToString(view.ToolTip);

        Response.Redirect("Master_Item.aspx?id=" + id + "&Type=" + "Edit");
    }
    protected void imgbtndelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton view = (ImageButton)sender;
            string id = Convert.ToString(view.ToolTip);
          
            AME_Master_Item jse = db.AME_Master_Item.First(t => t.Itm_code == id && t.Ms_Status == true);
            jse.Ms_Status = false;
            db.SaveChanges();
            FillGrid(0);
            txtInput.Text = "";
           
        }
        catch
        {

        }
    }
    //search Text
    [System.Web.Services.WebMethod]
    public static string[] GetTagNames(string prefixText, int count)
    {
        AutoMobileEntities db = new AutoMobileEntities();

        return db.AME_Master_Item.Where(n => n.Itm_Partno.StartsWith(prefixText)).OrderBy(n => n.Itm_Partno).Select(n => n.Itm_Partno).Distinct().Take(count).ToArray();
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            
            if (txtInput.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Part No Should Not Be Blank..!!!');</script>", false);
                txtInput.Focus();
                return;
            }
            if(txtInput.Text !="")
            {
               
                var query = from c in db.AME_Master_Item.Where(t => t.Itm_Partno==txtInput.Text && t.Ms_Status == true) select c;
                if (Convert.ToInt32(query.Count()) > 0)
                {
                    
                    FillGrid(0);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invalid Part No..!!!');</script>", false);
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
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        FillGrid(e.NewPageIndex);
    }
}