using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AutoMobileModel;


public partial class Admin_Update_SalesPrice : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
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

    [System.Web.Services.WebMethod]
    public static string[] GetPartNo2(string prefixText, int count)
    {
        string branch = HttpContext.Current.Session["Branch"].ToString();
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Master_Item.Where(n => n.Itm_Partno.Contains(prefixText) && n.Branch_Name == branch).OrderBy(n => n.Itm_Partno).Select(n => n.Itm_Partno).Distinct().Take(count).ToArray();
    }






    protected void btn_update_Click(object sender, EventArgs e)
    {
        decimal newsaleprice = Convert.ToDecimal(txt_saleprice.Text);
        string patname = txt_Partnumber.Text;
        smitaDbAccess.execute("update AME_Master_Item set Itm_SalePrice=" + newsaleprice + " where Itm_Partno='" + patname + "' ");
        GridBinding();
        txt_saleprice.Text = "";
        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert(' Itm_SalePrice Updated.!!');", true);




    }
    protected void txt_Partnumber_TextChanged(object sender, EventArgs e)
    {
        GridBinding();

    }

    public void GridBinding()
    {
        string patname = txt_Partnumber.Text;
        DataSet ds1 = smitaDbAccess.returndataset("select * from AME_Master_Item where Itm_Partno='" + patname + "'");
        if (ds1.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds1;
            GridView1.DataBind();
        }
        else
        {
            txt_Partnumber.Text = "";
            GridView1.DataSource = null;
            GridView1.DataBind();
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert(' No Data Are Found.!!');", true);

        }

    }
    protected void txtpartnum2_TextChanged(object sender, EventArgs e)
    {
        string partnumber = txtpartnum2.Text.Trim();
        string branch = Session["Branch"].ToString();
        DataSet ds1 = smitaDbAccess.returndataset("select Itm_Partno,Itm_PartDescrption,Branch_Name from AME_Master_Item where Itm_Partno='" + partnumber + "' and    Branch_Name='" + branch + "' ");

        lblpnumber.Text = ds1.Tables[0].Rows[0][0].ToString();
        partdestxt.Text = ds1.Tables[0].Rows[0][1].ToString();
        lblBranch.Text = ds1.Tables[0].Rows[0][2].ToString();
    }
    protected void btnupdatedescription_Click(object sender, EventArgs e)
    {
        string partnumber = txtpartnum2.Text.Trim();
        string branch = Session["Branch"].ToString();
        string desc = partdestxt.Text.Trim();

        smitaDbAccess.execute("update AME_Master_Item set Itm_PartDescrption='" + desc + "' where  Itm_Partno='" + partnumber + "' and    Branch_Name='" + branch + "' ");

        txtpartnum2.Text="";
        partdestxt.Text = "";

        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Updated Successfully'); </script>", false);
    }
}