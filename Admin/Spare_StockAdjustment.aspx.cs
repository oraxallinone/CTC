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
            txt_FromDate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
            txt_ToDate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
            fillgrid();
        }
    }



    public void fillgrid()
    {
        try
        {
            string Branch = Session["Branch"].ToString();
            string param = "@Fromdate,@Todate,@Branch";

            string paramvalue = Convert.ToDateTime(txt_FromDate.Text, SmitaClass.dateformat()).ToString("yyyy-MM-dd HH:mm:ss") + " , " + Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat()).ToString("yyyy-MM-dd HH:mm:ss") + "," + Branch;

            DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_SparestockAdjustment", param, paramvalue);


            if (Convert.ToInt32(dtr.Rows.Count) > 0)
            {
                GridView2.DataSource = dtr;
                GridView2.DataBind();

                var zzz = from c in db.AME_Branch_Creation.ToList() where c.Branch_Name == Session["Branch"].ToString() select c;
                lbl_BranchAddress.Text = zzz.First().Branch_Address + ", " + zzz.First().Branch_PhoneNo;

                lbl_from.Text = txt_FromDate.Text;
                lbl_to.Text = txt_ToDate.Text;
                Panel1.Visible = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('" + txt_FromDate.Text + "  To  " + txt_ToDate.Text + "  No Quotation Are Entry..!!');", true);
                Panel1.Visible = false;
                txt_FromDate.Focus();
                return;
            }
        }
        catch
        {

        }
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
            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy", "dd-MM-yyyy" };
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


            fillgrid();

        }
        catch
        {

        }
    }

    protected void imgbtnedit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton Img_edit = (ImageButton)sender;
        int imgid = Convert.ToInt32(Img_edit.ToolTip);

        foreach (GridViewRow gr in GridView2.Rows)
        {
            gr.BackColor = System.Drawing.Color.Transparent;
            ImageButton imgFc = (ImageButton)gr.FindControl("imgbtnedit");
           

            ImageButton imgFcc = (ImageButton)gr.FindControl("imgbtnupadte");

           

            imgFc.Visible = false;
            imgFcc.Visible = true;
        }
        GridViewRow row = Img_edit.NamingContainer as GridViewRow;
        row.BackColor = System.Drawing.Color.Pink;

    }
    protected void imgbtnupadte_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton img_update = (ImageButton)sender;
            int imgid = Convert.ToInt32(img_update.ToolTip);
            foreach (GridViewRow gr in GridView2.Rows)
            {
                ImageButton imgFc = (ImageButton)gr.FindControl("imgbtnupadte");
                int id = Convert.ToInt32(imgFc.ToolTip);
                if (imgid == id)
                {
                    
                    TextBox txtadjustquantity = (TextBox)gr.FindControl("txt_adjustquntity");
                    if (txtadjustquantity.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Adjust Quantity should Not Be Blank.!!');", true);
                        txtadjustquantity.Focus();
                        return;
                    }
                    decimal adquantity = Convert.ToDecimal(txtadjustquantity.Text);

                    Label lblquantity = (Label)gr.FindControl("lblquantity");
                    decimal lblquantity1 = Convert.ToDecimal(lblquantity.Text);

                    Label lblnetquantity = (Label)gr.FindControl("lblnetquantity");
                    decimal lblnetquantity1 = Convert.ToDecimal(lblnetquantity.Text);

                    Label lblinvoiceno = (Label)gr.FindControl("lblinvoiceno");
                    int lblinvoiceno1 = Convert.ToInt32(lblinvoiceno.Text);

                    Label lblpartno = (Label)gr.FindControl("lblpartno");
                    string lblpartno1 = lblpartno.Text;


                    Label lblpartdescrp = (Label)gr.FindControl("lblpartdescrp");
                    string lblpartdescrp1 = lblpartno.Text;

                    ImageButton imgFcc = (ImageButton)gr.FindControl("imgbtnedit");
                 
                    AME_Spare_PurchaseEntry ped = db.AME_Spare_PurchaseEntry.First(t => t.Ss_Id == id);
                    ped.Ss_Quantity = Convert.ToDecimal(adquantity + lblquantity1);
                    ped.Ss_NetQuantity = Convert.ToDecimal(adquantity + lblnetquantity1);
                    db.SaveChanges();

                    string Branch = Session["Branch"].ToString();
                    string uid = Convert.ToString(Session["Uid"]);
                    string param = "@Sp_VoucherNo,@Itm_Partno,@Itm_PartDescrption,@Ss_Quantity,@Ss_NetQuantity,@SSA_Adjustquantity,@Branch_Name,@Created_By,@Created_Date";
                    string paramvalue = lblinvoiceno1 + "," + lblpartno1 + "," + lblpartdescrp1 + "," + lblquantity1 + "," + lblnetquantity1 + "," + adquantity + "," + Branch + "," + uid + "," +SmitaClass.IndianTime().ToString("dd/MM/yyyy HH:mm:ss");
                     smitaDbAccess.insertprocedure("Sp_SpareStock_Insert", param, paramvalue);


                     imgFc.Visible = false;
                     imgFcc.Visible = true;
                     fillgrid();
                }

            }
            GridViewRow row = img_update.NamingContainer as GridViewRow;
            row.BackColor = System.Drawing.Color.Green;
        }
        catch
        {

        }
    }
}