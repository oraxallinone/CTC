using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
public partial class Admin_Report_LabIssue : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    public string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txt_FromDate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
            txt_ToDate.Text = SmitaClass.IndianTime().AddDays(1).ToString("dd/MM/yyyy");
           

        }

    }
    //[System.Web.Services.WebMethod]
    //public static string[] Getjcno(string prefixText, int count)
    //{
    //    string branch = HttpContext.Current.Session["Branch"].ToString();
    //    AutoMobileEntities db = new AutoMobileEntities();
    //    return db.AME_Service_JobCardEntry.Where(n => n.JC_No.Contains(prefixText) && n.Branch_Name == branch).OrderBy(n => n.JC_No).Select(n => n.JC_No).Distinct().Take(count).ToArray();


    //}
  

    protected void btn_excel_Click(object sender, EventArgs e)
    {
        try {

            if (GridView1.Rows.Count <= 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('There Is No Data To Download..!!');", true);

                return;
            }
            else
            {

                string Branch = Session["Branch"].ToString();
                string attachment = "attachment; filename=" + "Dailylabissue" + "(" + Branch + ")" + ".xls";
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                HtmlForm frm = new HtmlForm();
                GridView1.Parent.Controls.Add(frm);
                frm.Attributes["runat"] = "server";
                frm.Controls.Add(GridView1);
                frm.RenderControl(htw);
                Response.Write(sw.ToString());
                Response.End();
            }
        }
        catch (Exception ex)
        { }
    }
   
   
    protected void fillgrid()
    {
        try
        {
            string Branch = Session["Branch"].ToString();

            string param = "@jc_no,@sparetype,@Branch";

            string paramvalue = txt_jcno.Text.Trim() + "," + drp_sparetype.SelectedItem.ToString() + "," + Branch;
            DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_reportlabissuetypewise", param, paramvalue);
            if (dtr.Rows.Count > 0)
            {
                GridView1.DataSource = dtr;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert(' No Data Are Found.!!');", true);
            }
        }
        catch (Exception ex)
        { }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        fillgrid1();
    }
    protected void fillgrid1()
    {
        try
        {
            string Branch = Session["Branch"].ToString();

            string param = "@jc_no,@Branch";

            string paramvalue = TextBox1.Text.Trim() + "," + Branch;
            DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_reportlabissuejcwise", param, paramvalue);
            if (dtr.Rows.Count > 0)
            {
                GridView1.DataSource = dtr;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert(' No Data Are Found.!!');", true);
            }
        }
        catch (Exception ex)
        { }

    }

    protected void btn_Show_Click(object sender, EventArgs e)
    {
        try
        {
            string Branch = Session["Branch"].ToString();

            string param = "@Fromdate,@Todate,@Branch";

            string paramvalue = Convert.ToDateTime(txt_FromDate.Text, SmitaClass.dateformat()).ToString("yyyy-MM-dd") + "," + Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat()).ToString("yyyy-MM-dd") + "," + Branch;
            DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_reportlabissue", param, paramvalue);
            if (dtr.Rows.Count > 0)
            {
                GridView1.DataSource = dtr;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert(' No Data Are Found.!!');", true);
            }
        }
        catch (Exception ex)
        { }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        fillgrid();
    }
    protected void btn_excel_Click1(object sender, EventArgs e)
    {
        try
        {

            if (GridView1.Rows.Count <= 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('There Is No Data To Download..!!');", true);

                return;
            }
            else
            {

                string Branch = Session["Branch"].ToString();
                string attachment = "attachment; filename=" + "DailyLabourReport" + "(" + Branch + ")" + ".xls";
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                HtmlForm frm = new HtmlForm();
                GridView1.Parent.Controls.Add(frm);
                frm.Attributes["runat"] = "server";
                frm.Controls.Add(GridView1);
                frm.RenderControl(htw);
                Response.Write(sw.ToString());
                Response.End();
            }
        }
        catch (Exception ex)
        { }
    }
}