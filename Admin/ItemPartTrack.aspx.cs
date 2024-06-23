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
public partial class Admin_ItemPartTrack : System.Web.UI.Page
{

    AutoMobileEntities db = new AutoMobileEntities();
    public string uname;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [System.Web.Services.WebMethod]
    public static string[] GetPartNo(string prefixText, int count)
    {
        string branch = HttpContext.Current.Session["Branch"].ToString();
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Master_Item.Where(n => n.Itm_Partno.Contains(prefixText) && n.Branch_Name == branch).OrderBy(n => n.Itm_Partno).Select(n => n.Itm_Partno).Distinct().Take(count).ToArray();
    }


    protected void txt_PartNo_TextChanged(object sender, EventArgs e)
    {
        FillGrid();
    }


    public void FillGrid()
    {
        string Branch = Session["Branch"].ToString();
        string param = "@Branch,@partno";
        string paramvalue = Branch + "," + txt_PartNo.Text;

        DataTable dtr = smitaDbAccess.SPReturnDataTable("SalesItem_Track", param, paramvalue);
        if (dtr.Rows.Count > 0)
        {
            GridView2.DataSource = dtr;
            GridView2.DataBind();

            var zzz = from c in db.AME_Branch_Creation.ToList() where c.Branch_Name == Session["Branch"].ToString() select c;
            lbl_BranchAddress.Text = zzz.First().Branch_Address + ", " + zzz.First().Branch_PhoneNo;
            lbltin.Text = zzz.First().Branch_TIN;

            Panel1.Visible = true;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('There Is No Stock Are Available..!!');", true);
            Panel1.Visible = true;

            return;
        }

    }
}