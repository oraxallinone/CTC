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
        string Branch = Session["Branch"].ToString();
        string param = "@Fromdate,@Todate,@Branch";

       // string paramvalue = Convert.ToDateTime(txt_FromDate.Text, SmitaClass.dateformat()).ToString("yyyy-MM-dd HH:mm:ss") + " , " + Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat()).ToString("yyyy-MM-dd HH:mm:ss") + "," + Branch;
        string paramvalue = Convert.ToDateTime(txt_FromDate.Text, SmitaClass.dateformat()).ToString("dd/MM/yyyy") + " , " + Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat()).ToString("dd/MM/yyyy") + "," + Branch;
        //string paramvalue = txt_FromDate.Text + " , " + txt_ToDate.Text  + "," + Branch;

        DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_JobCardList_delete_JC", param, paramvalue);


        if (Convert.ToInt32(dtr.Rows.Count) > 0)
        {
            GridView1.DataSource = dtr;
            GridView1.DataBind();
            foreach (GridViewRow gr in GridView1.Rows)
            {
                ImageButton edit = (ImageButton)gr.FindControl("imgbtnedit");
                ImageButton del = (ImageButton)gr.FindControl("imgbtndelete");

                if (Session["saletype"] != null)
                {
                    //edit.Visible = false;
                    del.Visible = false;
                }
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('" + txt_FromDate.Text + "  To  " + txt_ToDate.Text + "  No Quotation Are Entry..!!');", true);
            txt_FromDate.Focus();
            return;
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
            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy","dd-MM-yyyy" };
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
        ImageButton imgedit = (ImageButton)sender;
        int sino = Convert.ToInt32(imgedit.ToolTip);

        string ye = imgedit.CommandArgument;
        //Response.Redirect("Service_JobcardEntryEdit.aspx?id=" + sino + "&Type=" + "Edit");
        Response.Redirect("Service_JobcardEntryEdit.aspx?id=" + sino + "&Type=" + "Edit" + "&year=" + ye);

    }
    protected void imgbtnview_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgview = (ImageButton)sender;
        int sino = Convert.ToInt32(imgview.ToolTip);
        string ye = imgview.CommandArgument;

      //  Response.Redirect("Service_JobcardEntryEdit.aspx?id=" + sino + "&Type=" + "View");

        Response.Redirect("Service_JobcardEntryEdit.aspx?id=" + sino + "&Type=" + "View" + "&year=" + ye);

    }
   
    protected void imgbtndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgdelete = (ImageButton)sender;
        int sino = Convert.ToInt32(imgdelete.ToolTip);
        string ye = imgdelete.CommandArgument; 
        string branchname = Session["Branch"].ToString();
        AME_Service_JobCardEntry vq = db.AME_Service_JobCardEntry.First(t => t.JC_No == sino && t.Branch_Name == branchname && t.JC_year==ye);
        db.DeleteObject(vq);

        db.AME_Service_JobCardServiceDetails.Where(t => t.JC_No == sino && t.Branch_Name == branchname).ToList().ForEach(db.AME_Service_JobCardServiceDetails.DeleteObject);

       

        db.SaveChanges();

        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Data Deleted Sucessfully..!!');", true);
        fillgrid();

      
    }
}
