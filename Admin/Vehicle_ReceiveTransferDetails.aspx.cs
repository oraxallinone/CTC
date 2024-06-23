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

    public void viewExpensesDetails()
    {
       string Branch = Session["Branch"].ToString();
       string param = "@Fromdate,@Todate,@Branch";

       string paramvalue = Convert.ToDateTime(txt_FromDate.Text, SmitaClass.dateformat()).ToString("yyyy-MM-dd HH:mm:ss") + "," + Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat()).ToString("yyyy-MM-dd HH:mm:ss") + "," + Branch;

        DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_Vehicle_ReceiveStockTransferList", param, paramvalue);

        GridView2.DataSource = dtr;
        GridView2.DataBind();
       
    }
    protected void btn_Show_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_FromDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('From Date SHOULD NOT BE BLANK...!!');", true);
                txt_FromDate.Focus();
                return;
            }
            if (txt_ToDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('To Date SHOULD NOT BE BLANK...!!');", true);
                txt_ToDate.Focus();
                return;
            }
            
            if (Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat()) < Convert.ToDateTime(txt_FromDate.Text, SmitaClass.dateformat()))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('To Date Must Be Greater Than From Date..!!');", true);
                txt_ToDate.Focus();
                return;
            }
            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy" };
            DateTime expectedDate;
            if (!DateTime.TryParseExact(txt_FromDate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                txt_FromDate.Focus();
                return;
            }
            if (!DateTime.TryParseExact(txt_ToDate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                txt_ToDate.Focus();
                return;
            }
          

                viewExpensesDetails();

        }
        catch
        {

        }
    }


 
    //protected void imgbtnedit_Click(object sender, ImageClickEventArgs e)
    //{
    //    ImageButton imgedit = (ImageButton)sender;
    //    int sino = Convert.ToInt32(imgedit.ToolTip);
    //    Response.Redirect("Vehicle_QuotationEdit.aspx?id=" + sino + "&Type=" + "Edit");
    //}
    //protected void imgbtnview_Click(object sender, ImageClickEventArgs e)
    //{
    //    ImageButton imgview = (ImageButton)sender;
    //    int sino = Convert.ToInt32(imgview.ToolTip);
    //    Response.Redirect("Vehicle_QuotationEdit.aspx?id=" + sino + "&Type=" + "View");
    //}
   
    //protected void imgbtndelete_Click(object sender, ImageClickEventArgs e)
    //{

    //    ImageButton imgdelete = (ImageButton)sender;
    //    int sino = Convert.ToInt32(imgdelete.ToolTip);
    //    string branchname = Session["Branch"].ToString();
    //    AME_Vehicle_Quotation vq = db.AME_Vehicle_Quotation.First(t => t.Vq_Id == sino && t.Branch_Name == branchname);
    //    db.DeleteObject(vq);

    //    db.AME_Vehicle_QuotationList.Where(t => t.Vq_Id == sino).ToList().ForEach(db.AME_Vehicle_QuotationList.DeleteObject);
    //    db.SaveChanges();

    //    ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Data Deleted Sucessfully..!!');", true);
    //}


    protected void btn_receive_Click(object sender, EventArgs e)
    {
       
    
    }
    protected void btn_recive_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gr in GridView2.Rows)
        {
            Label lblbillno = (Label)gr.FindControl("lblbillno");
            int billno = Convert.ToInt32(lblbillno.Text);

            //Label lblmakers = (Label)gr.FindControl("lblmakers");
            //string makers = lblmakers.Text;

            Label lbltobranch = (Label)gr.FindControl("lbltobranch");
            string tobranch = lbltobranch.Text;

            Label lblfrombranch = (Label)gr.FindControl("lblfrombranch");
            string frombranch = lblfrombranch.Text;


            Label lblengno = (Label)gr.FindControl("lbltransferdt");
            string engineno = lblengno.Text;

            Label lblcolor = (Label)gr.FindControl("lbltransferdt");
            string color = lblcolor.Text;

            Label lblvechiletype = (Label)gr.FindControl("lblvechiletype");
            string vehicletype = lblvechiletype.Text;

            Label lblchessisno = (Label)gr.FindControl("lblchessisno");
            string chessisno = lblchessisno.Text;

            //Label lblkey = (Label)gr.FindControl("lblkey");
            //string keyno = lblkey.Text;

            //Label lblrate = (Label)gr.FindControl("lblrate");
            //decimal rate =Convert.ToDecimal(lblrate.Text);

            //Label lblquantity = (Label)gr.FindControl("lblquantity");
            //decimal quantity = Convert.ToDecimal(lblquantity.Text);

            //Label lblamount = (Label)gr.FindControl("lblamount");
            //decimal amount = Convert.ToDecimal(lblamount.Text);



            AME_Vehicle_PurchaseEntry avp = db.AME_Vehicle_PurchaseEntry.ToList().First(t => t.Vp_Chassisno == chessisno);
            avp.Vp_NetQuantity = 1;
            avp.Status = "SendTransfer";
            avp.Branch_Name = tobranch;
            avp.PendingStatus = "False";
            db.SaveChanges();

            //AME_Vehicle_PurchaseEntry Vp = new AME_Vehicle_PurchaseEntry();
            //Vp.Branch_Name =tobranch;
            //Vp.Created_By = Session["Uid"].ToString();
            //Vp.Created_Date = SmitaClass.IndianTime();
            //Vp.Mv_Makers = makers;
            //Vp.Mv_ModelName = modelname;
            //Vp.Vp_Amount = amount;
            //Vp.Vp_Chassisno = chessisno;
            //Vp.Vp_Color = color;
            //Vp.Vp_Engineno = engineno;
            //Vp.Vp_Keyno = keyno;
            //Vp.Vp_NetQuantity = quantity;
            //Vp.Vp_Quantity = quantity;
            //Vp.Vp_Rate = rate;
            //Vp.Vpd_Id = billno;
            //Vp.Mv_VehicleType = vehicletype;
            //Vp.Status = "PE";
            //db.AddToAME_Vehicle_PurchaseEntry(Vp);
            //db.SaveChanges();
            AME_VehicleTransfer vt = db.AME_VehicleTransfer.ToList().First(t => t.Vp_Chassisno == chessisno);

            vt.Status = "Receive Transfer";
            vt.ReceiveStatus = "Receive";
            
            db.SaveChanges();

        }
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Stock Receive Sucessfully..!!');</script>", false);
        GridView2.DataSource = null;
        GridView2.DataBind();
        return;
    }
}
