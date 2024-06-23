using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
public partial class Admin_Vehicle_StockAdjustment : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

        }
    }
    public void fillModelno()
    {
        string Sale = Convert.ToString(Session["saletype"]);
        if (Session["saletype"] != null)
        {
            string branchname = Session["Branch"].ToString();
            var model = from c in db.AME_Master_VehicleModel.Where(t => t.Mv_VehicleType == ddl_VType.SelectedValue && t.Branch_Name == branchname && t.Mv_SaleStatus == Sale).OrderBy(t => t.Mv_Id)
                        select new
                        {
                            mid = c.Mv_Id,
                            mname = c.Mv_ModelName
                        };
            ddl_Modelname.DataSource = model.ToList();
            ddl_Modelname.DataValueField = "mid";
            ddl_Modelname.DataTextField = "mname";
            ddl_Modelname.DataBind();
            ddl_Modelname.Items.Insert(0, "..Select..");
        }
        else
        {
            string branchname = Session["Branch"].ToString();
            var model = from c in db.AME_Master_VehicleModel.Where(t => t.Mv_VehicleType == ddl_VType.SelectedValue && t.Branch_Name == branchname).OrderBy(t => t.Mv_Id)
                        select new
                        {
                            mid = c.Mv_Id,
                            mname = c.Mv_ModelName
                        };
            ddl_Modelname.DataSource = model.ToList();
            ddl_Modelname.DataValueField = "mid";
            ddl_Modelname.DataTextField = "mname";
            ddl_Modelname.DataBind();
            ddl_Modelname.Items.Insert(0, "..Select..");
        }

    }
   
    protected void ddl_VType_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillModelno();
    }
    protected void ddl_Modelname_SelectedIndexChanged(object sender, EventArgs e)
    {
        int modelname = Convert.ToInt32(ddl_Modelname.SelectedValue);
        string branchname = Session["Branch"].ToString();
        var details = (from c in db.AME_Vehicle_PurchaseEntry
                            join d in db.AME_Master_VehicleModel on c.Mv_ModelName equals d.Mv_Id
                       where (c.Mv_ModelName == modelname && c.Branch_Name == branchname && c.Status == "PE")
                            
                        select new
                        {
                            vehicletype = c.Mv_VehicleType,
                            modelname = d.Mv_ModelName,
                            chessisno=c.Vp_Chassisno,
                            engineno=c.Vp_Engineno,
                            quantity=c.Vp_NetQuantity,
                            rate=c.Vp_Rate,
                            mid = c.Mv_ModelName,
                            billno=c.Vpd_Id,
                        }).ToList();
        GridView1.DataSource = details.ToList();
        GridView1.DataBind();

    }
    [System.Web.Services.WebMethod]
    public static string[] GetServiceCode(string prefixText, int count)
    {
        string branch = HttpContext.Current.Session["Branch"].ToString();
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Vehicle_PurchaseEntry.Where(n => n.Vp_Chassisno.StartsWith(prefixText) && n.Branch_Name == branch).OrderBy(n => n.Vp_Id).Select(n => n.Vp_Chassisno).Distinct().Take(count).ToArray();
    }
    public void fillgrid()
    {

        int modelname = Convert.ToInt32(ddl_Modelname.SelectedValue);
        string branchname = Session["Branch"].ToString();
        if (txtchessisno.Text == "")
        {
            var details = (from c in db.AME_Vehicle_PurchaseEntry
                           join d in db.AME_Master_VehicleModel on c.Mv_ModelName equals d.Mv_Id
                           where (c.Mv_ModelName == modelname  && c.Branch_Name == branchname && c.Status == "PE")

                           select new
                           {
                               vehicletype = c.Mv_VehicleType,
                               modelname = d.Mv_ModelName,
                               chessisno = c.Vp_Chassisno,
                               engineno = c.Vp_Engineno,
                               quantity = c.Vp_NetQuantity,
                               mid=c.Mv_ModelName,
                               rate = c.Vp_Rate,
                               billno = c.Vpd_Id,
                           }).ToList();

            GridView1.DataSource = details.ToList();
            GridView1.DataBind();
        }
        else
        {
            var details = (from c in db.AME_Vehicle_PurchaseEntry
                           join d in db.AME_Master_VehicleModel on c.Mv_ModelName equals d.Mv_Id
                           where (c.Mv_ModelName == modelname && c.Vp_Chassisno == txtchessisno.Text && c.Branch_Name == branchname && c.Status == "PE")

                           select new
                           {
                               vehicletype = c.Mv_VehicleType,
                               modelname = d.Mv_ModelName,
                               chessisno = c.Vp_Chassisno,
                               engineno = c.Vp_Engineno,
                               quantity = c.Vp_NetQuantity,
                               mid = c.Mv_ModelName,
                               rate = c.Vp_Rate,
                               billno = c.Vpd_Id,
                           }).ToList();

            GridView1.DataSource = details.ToList();
            GridView1.DataBind();
        }
    }
    protected void btn_show_Click(object sender, EventArgs e)
    {
          try
        {

            if (ddl_VType.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select vehicle Type.!!'); </script>", false);
                return;
            }
            if (ddl_Modelname.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Model Name.!!'); </script>", false);
                return;
            }
              if(txtchessisno.Text=="")
              {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Chessis No Shoud Not Be Blank..!!'); </script>", false);
                return;
              }
              int modelname = Convert.ToInt32(ddl_Modelname.SelectedValue);
              string branchname = Session["Branch"].ToString();
              var details = (from c in db.AME_Vehicle_PurchaseEntry
                             join d in db.AME_Master_VehicleModel on c.Mv_ModelName equals d.Mv_Id
                             where (c.Mv_ModelName == modelname && c.Vp_Chassisno == txtchessisno.Text && c.Branch_Name == branchname && c.Status=="PE")

                             select new
                             {
                                 vehicletype = c.Mv_VehicleType,
                                 modelname = d.Mv_ModelName,
                                 chessisno = c.Vp_Chassisno,
                                 engineno = c.Vp_Engineno,
                                 quantity = c.Vp_NetQuantity,
                                 mid = c.Mv_ModelName,
                                 rate = c.Vp_Rate,
                                 billno = c.Vpd_Id,
                             }).ToList();
              if (Convert.ToInt32(details.Count()) > 0)
              {
                  GridView1.DataSource = details.ToList();
                  GridView1.DataBind();
              }
              else
              {
                  ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invalid Chessis No..!!'); </script>", false);
                  GridView1.DataSource = null;
                  GridView1.DataBind();
                  txtchessisno.Focus();
                  return;

              }
        }
        catch
        {

        }
    }
    protected void imgbtn_edit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
        ImageButton edit = (ImageButton)sender;
        string edit1 = edit.ToolTip;
        foreach (GridViewRow gr in GridView1.Rows)
        {
            gr.BackColor = System.Drawing.Color.Transparent;

            ImageButton show = (ImageButton)gr.FindControl("imgbtn_edit");
            string sino1 = Convert.ToString(show.ToolTip);
            if (sino1 == edit1)
            {

                TextBox txtnetquantity = (TextBox)gr.FindControl("txtnetquantity");
                decimal netqunatity = Convert.ToDecimal(txtnetquantity.Text);
                txtnetquantity.BackColor = System.Drawing.Color.Aqua;
                txtnetquantity.ReadOnly = false;
                ImageButton hide = (ImageButton)gr.FindControl("imgbtn_save");
                hide.Visible = true;
                show.Visible = false;
            }
        }
           
        }
        catch
        {

            }
        
    }
    protected void imgbtn_save_Click(object sender, ImageClickEventArgs e)
    {
        //try
        //{
             
            ImageButton edit = (ImageButton)sender;
            string edit1 = edit.ToolTip;
            foreach (GridViewRow gr in GridView1.Rows)
            {

                string branchname = Session["Branch"].ToString();
                 string uid = Convert.ToString(Session["Uid"]);
                ImageButton show = (ImageButton)gr.FindControl("imgbtn_save");
                string sino1 = Convert.ToString(show.ToolTip);
                if (sino1 == edit1)
                {
                    
                    Label lblbillno=(Label)gr.FindControl("lblbillno");
                    int billno=Convert.ToInt32(lblbillno.Text);

                    Label lblvechiletype=(Label)gr.FindControl("lblvechiletype");
                    string vechiletype=lblvechiletype.Text;

                    Label lblmodelname=(Label)gr.FindControl("lblmodelname");
                    int modelname=Convert.ToInt32(lblmodelname.ToolTip);

                    Label lblchessisno=(Label)gr.FindControl("lblchessisno");
                    string chessisno=lblchessisno.Text;

                    Label lblengineno=(Label)gr.FindControl("lblengineno");
                    string engineno=lblengineno.Text;

                    
                    Label lblrate=(Label)gr.FindControl("lblrate");
                    decimal rate=Convert.ToDecimal(lblrate.Text);

                    TextBox txtnetquantity = (TextBox)gr.FindControl("txtnetquantity");
                    decimal netqunatity = Convert.ToDecimal(txtnetquantity.Text);
                    decimal PrevNetqunatity = Convert.ToDecimal(txtnetquantity.ToolTip);


                    ImageButton hide = (ImageButton)gr.FindControl("imgbtn_edit");
                    hide.Visible = true;
                    show.Visible = false;
                    txtnetquantity.ReadOnly = true;
                 

                    AME_Vechicle_Adjustment va = new AME_Vechicle_Adjustment();
                    va.Branch_Name = branchname;
                    va.Created_By = uid;
                    va.Created_Date = SmitaClass.IndianTime();
                    va.Mv_VehicleType=vechiletype;
                    va.Mv_ModelName = modelname;
                    va.Vp_Rate = rate;
                    va.Vp_Engineno = engineno;
                    va.Vp_Chassisno = chessisno;
                    va.SA_PrevQuantity = PrevNetqunatity;
                    va.SA_ModifyQuantity = netqunatity;
                    va.Vpd_Id = billno;
                    va.Status = "ST";
                    db.AddToAME_Vechicle_Adjustment(va);
                    db.SaveChanges();


                    AME_Vehicle_PurchaseEntry vpe = db.AME_Vehicle_PurchaseEntry.First(t => t.Vp_Chassisno == sino1 && t.Branch_Name == branchname);
                    vpe.Vp_NetQuantity = netqunatity;
                    db.SaveChanges();

                    fillgrid();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Vehicle Adjustment Sucessfully..!!');</script>", false);
                    return;
                }

            }
        //}
        //catch
        //{

        //}
    }
   
}
