using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
using System.Data;
public partial class Report_ProjectExpensesDetailsCodeDatewise : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    public string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
          
        }
    }

    public void fillgrid()
    {
        string Branch = Session["Branch"].ToString();
       
        var query = (from c in db.AME_Vehicle_SaleEntryDetails
                    join d in db.AME_Master_Customer on c.Vq_PartyName equals  d.Mc_Id
                     where c.Vs_InvType==ddl_invtype.SelectedItem.Text && c.Branch_Name == Branch
                     && c.Vq_Status == "SE"
                    select new
                    {
                        d.Mc_Name,
                        c.Vs_Billno,
                        c.Vs_Billdate,
                         d.Mc_Address,
                         d.Mc_Mobileno,
                        c.Vs_InvType,
                        c.Vs_TinNo,
                        c.Vs_Sino

                    }).ToList();
       
            GridView1.DataSource = query.ToList();
            GridView1.DataBind();
      
    }

   
  
    protected void imgbtnview_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgview = (ImageButton)sender;
        string sino = Convert.ToString(imgview.ToolTip);
        Response.Redirect("Vehicle_SaleEntry.aspx?id=" + sino + "&Type=" + "View");
    }
   
    protected void imgbtndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgdelete = (ImageButton)sender;
        string sino = Convert.ToString(imgdelete.ToolTip);
        string branchname = Session["Branch"].ToString();
        AME_Vehicle_SaleEntry vq = db.AME_Vehicle_SaleEntry.First(t => t.Vs_Billno == sino && t.Branch_Name == branchname);
        vq.Status = "SEC";
        AME_Vehicle_SaleEntryDetails vqs = db.AME_Vehicle_SaleEntryDetails.First(t => t.Vs_Billno == sino && t.Branch_Name == branchname);
        vqs.Vq_Status = "SEC";
        db.SaveChanges();
        var cancelstock = (from c in db.AME_Vehicle_SaleEntry
                           join d in db.AME_Vehicle_PurchaseEntry on c.Vp_Chassisno equals d.Vp_Chassisno
                           where c.Branch_Name == d.Branch_Name && c.Mv_VehicleType == d.Mv_VehicleType && c.Mv_ModelName == d.Mv_ModelName
                           select new

                           {
                               squantity=c.Vse_Quantity,
                               pquantity=d.Vp_NetQuantity,
                               branchname=c.Branch_Name,
                               vehicletype=c.Mv_VehicleType,
                               modelname=c.Mv_ModelName,
                               chessisno=c.Vp_Chassisno,
                           }
                           ).First();
        string branch = cancelstock.branchname;
        string vtype = cancelstock.vehicletype;
        int mname =Convert.ToInt32(cancelstock.modelname);
        string chesssisno=cancelstock.chessisno;
        decimal quantity=cancelstock.squantity;
        AME_Vehicle_PurchaseEntry vpe = db.AME_Vehicle_PurchaseEntry.First(t => t.Branch_Name == branch && t.Mv_VehicleType == vtype && t.Mv_ModelName == mname && t.Vp_Chassisno == chesssisno);
        vpe.Vp_NetQuantity = quantity;
        db.SaveChanges();
       
        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Data Cancel Sucessfully..!!');", true);
        fillgrid();
    }
    protected void ddl_invtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
}
