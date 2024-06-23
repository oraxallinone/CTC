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
            //id = "";
            //ValueType = "";
            //FillGrid(id, ValueType);

        }
    }




    //---ajax start

    public class CutomerList
    {
        public int empid { get; set; }

        public string empName { get; set; }

        public string empcontNo { get; set; }

        public bool empstatus { get; set; }
    }





    [System.Web.Services.WebMethod]

    public static List<CutomerList> GetAllitems(string partno)
    {
        List<CutomerList> getlistCus = new List<CutomerList>();
        AutoMobileEntities db = new AutoMobileEntities();
        string branchname = HttpContext.Current.Session["Branch"].ToString();
        var cusList = from c in db.AME_Master_Customer.ToList().Where(t =>  t.Mc_Status == true)
                   where c.Branch_Name == branchname 
                   select new
                   {
                       empid = c.Mc_Id,
                       empcode = c.Mc_code,
                       empName = c.Mc_Name,
                       empcontNo = c.Mc_Mobileno,
                       empstatus = c.Mc_Status

                   };

        foreach (var list in cusList)
        {
            CutomerList obj = new CutomerList();
            obj.empid = list.empid;
            obj.empName = list.empcode;
            obj.empcontNo = list.empcontNo;
            obj.empstatus = list.empstatus;
            getlistCus.Add(obj);
        }




        return getlistCus;
    }




























    private void FillGrid(string id, string ValueType)
    {
        string Branch = Convert.ToString(Session["Branch"]);
        string sale = Convert.ToString(Session["saletype"]);
        if (Session["saletype"] != null)
        {
            if (ValueType == "Name")
            {
                var query = from c in db.AME_Master_Customer.ToList().Where(t => t.Mc_Name.StartsWith(id) && t.Mc_Status == true)
                            where c.Branch_Name == Branch && c.Mc_SaleStatus == sale
                            select new
                            {
                                empid = c.Mc_Id,
                                empcode = c.Mc_code,
                                empName = c.Mc_Name,
                                empcontNo = c.Mc_Mobileno,
                                empstatus = c.Mc_Status

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
                var query = from c in db.AME_Master_Customer.ToList().Where(t => t.Mc_code.StartsWith(id) && t.Mc_Status == true)
                            where c.Branch_Name == Branch && c.Mc_SaleStatus == sale
                            select new
                            {
                                empid = c.Mc_Id,
                                empcode = c.Mc_code,
                                empName = c.Mc_Name,
                                empcontNo = c.Mc_Mobileno,
                                empstatus = c.Mc_Status
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
                var query = from c in db.AME_Master_Customer.ToList().Where(t => t.Mc_Mobileno.StartsWith(id) && t.Mc_Status == true)
                            where c.Branch_Name == Branch && c.Mc_SaleStatus == sale
                            select new
                            {
                                empid = c.Mc_Id,
                                empcode = c.Mc_code,
                                empName = c.Mc_Name,
                                empcontNo = c.Mc_Mobileno,
                                empstatus = c.Mc_Status

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
                var query = from c in db.AME_Master_Customer.ToList().OrderBy(t => t.Mc_Id).Where(t => t.Mc_Status == true)
                            where c.Branch_Name == Branch && c.Mc_SaleStatus == sale
                            select new
                            {
                                empid = c.Mc_Id,
                                empcode = c.Mc_code,
                                empName = c.Mc_Name,
                                empcontNo = c.Mc_Mobileno,
                                empstatus = c.Mc_Status
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
        else
        {
            if (ValueType == "Name")
            {
                var query = from c in db.AME_Master_Customer.ToList().Where(t => t.Mc_Name.StartsWith(id) && t.Mc_Status == true)
                            where c.Branch_Name == Branch 
                            select new
                            {
                                empid = c.Mc_Id,
                                empcode = c.Mc_code,
                                empName = c.Mc_Name,
                                empcontNo = c.Mc_Mobileno,
                                empstatus = c.Mc_Status

                            };
                GridView1.DataSource = query;
                GridView1.DataBind();
                foreach (GridViewRow gr in GridView1.Rows)
                {
                    Label lblavilable = (Label)gr.FindControl("lblavilable");
                    string staus = Convert.ToString(lblavilable.ToolTip);


                   // ImageButton edit = (ImageButton)gr.FindControl("imgbtnedit");
                    ImageButton del = (ImageButton)gr.FindControl("imgbtndelete");
                    del.Visible = false;
                   
                }
            }
            else if (ValueType == "Code")
            {
                var query = from c in db.AME_Master_Customer.ToList().Where(t => t.Mc_code.StartsWith(id) && t.Mc_Status == true)
                            where c.Branch_Name == Branch 
                            select new
                            {
                                empid = c.Mc_Id,
                                empcode = c.Mc_code,
                                empName = c.Mc_Name,
                                empcontNo = c.Mc_Mobileno,
                                empstatus = c.Mc_Status
                            };
                GridView1.DataSource = query;
                GridView1.DataBind();
                foreach (GridViewRow gr in GridView1.Rows)
                {
                    Label lblavilable = (Label)gr.FindControl("lblavilable");
                    string staus = Convert.ToString(lblavilable.ToolTip);


                    // ImageButton edit = (ImageButton)gr.FindControl("imgbtnedit");
                    ImageButton del = (ImageButton)gr.FindControl("imgbtndelete");
                    del.Visible = false;

                }
            }
            else if (ValueType == "Contact No")
            {
                var query = from c in db.AME_Master_Customer.ToList().Where(t => t.Mc_Mobileno.StartsWith(id) && t.Mc_Status == true)
                            where c.Branch_Name == Branch
                            select new
                            {
                                empid = c.Mc_Id,
                                empcode = c.Mc_code,
                                empName = c.Mc_Name,
                                empcontNo = c.Mc_Mobileno,
                                empstatus = c.Mc_Status

                            };
                GridView1.DataSource = query;
                GridView1.DataBind();
                foreach (GridViewRow gr in GridView1.Rows)
                {
                    Label lblavilable = (Label)gr.FindControl("lblavilable");
                    string staus = Convert.ToString(lblavilable.ToolTip);


                    // ImageButton edit = (ImageButton)gr.FindControl("imgbtnedit");
                    ImageButton del = (ImageButton)gr.FindControl("imgbtndelete");
                    del.Visible = false;

                }
            }
            else if (ValueType == "")
            {
                var query = from c in db.AME_Master_Customer.ToList().OrderBy(t => t.Mc_Id).Where(t => t.Mc_Status == true)
                            where c.Branch_Name == Branch 
                            select new
                            {
                                empid = c.Mc_Id,
                                empcode = c.Mc_code,
                                empName = c.Mc_Name,
                                empcontNo = c.Mc_Mobileno,
                                empstatus = c.Mc_Status
                            };

                GridView1.DataSource = query.ToList();
                GridView1.DataBind();
                foreach (GridViewRow gr in GridView1.Rows)
                {
                    Label lblavilable = (Label)gr.FindControl("lblavilable");
                    string staus = Convert.ToString(lblavilable.ToolTip);
                    ImageButton del = (ImageButton)gr.FindControl("imgbtndelete");
                    del.Visible = false;
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
       
    }

  


    protected void imgbtnview_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton view = (ImageButton)sender;
        string id = Convert.ToString(view.ToolTip);
        Response.Redirect("Master_CustomerRegistration.aspx?id=" + id + "&Type=" + "View");
    }
    protected void imgbtnedit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton view = (ImageButton)sender;
        string id = Convert.ToString(view.ToolTip);

        Response.Redirect("Master_CustomerRegistration.aspx?id=" + id + "&Type=" + "Edit");
    }
    protected void imgbtndelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton view = (ImageButton)sender;
            string id = Convert.ToString(view.ToolTip);
            int id1 = Convert.ToInt32(id);

            AME_Master_Customer jse = db.AME_Master_Customer.First(t => t.Mc_Id == id1 && t.Mc_Status == true);
            jse.Mc_Status = false;
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