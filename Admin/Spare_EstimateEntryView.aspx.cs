using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;

public partial class Admin_Spare_PurchaseEntry : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    public string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null || Request.QueryString["No"] == null)
        {
            Response.Redirect("AccessDenied.aspx");
        }
        if (!IsPostBack)
        {
            FillModel();

            string sino = Request.QueryString["id"];
            string VNo = Request.QueryString["No"];
            filldata(sino, VNo);
            SetTextBoxReadOnly<TextBox>(Master.FindControl("form1"), true);
            ddl_BModel.Enabled = false;
        }
    }

    private void SetTextBoxReadOnly<T>(Control parent, bool readOnly) where T : TextBox
    {
        foreach (var tb in parent.Controls.OfType<T>())
            tb.ReadOnly = readOnly;

        foreach (Control c in parent.Controls)
            SetTextBoxReadOnly<T>(c, readOnly);
    }
    private void FillModel()
    {
        string Sale = Convert.ToString(Session["saletype"]);
        if (Session["saletype"] != null)
        {
            string branchname = Session["Branch"].ToString();
            var v = from c in db.AME_Master_VehicleModel.ToList()
                    where c.Status = true && c.Branch_Name == branchname && c.Mv_SaleStatus == Sale
                    select new
                    {
                        Mv_ModelName = c.Mv_ModelName,
                        Mv_Code = c.Mv_Code
                    };
            ddl_BModel.DataSource = v.ToList();
            ddl_BModel.DataTextField = "Mv_ModelName";
            ddl_BModel.DataValueField = "Mv_Code";
            ddl_BModel.DataBind();
            ddl_BModel.Items.Insert(0, "--Select One--");
        }
        else
        {
            string branchname = Session["Branch"].ToString();
            var v = from c in db.AME_Master_VehicleModel.ToList()
                    where c.Status = true && c.Branch_Name == branchname
                    select new
                    {
                        Mv_ModelName = c.Mv_ModelName,
                        Mv_Code = c.Mv_Code
                    };
            ddl_BModel.DataSource = v.ToList();
            ddl_BModel.DataTextField = "Mv_ModelName";
            ddl_BModel.DataValueField = "Mv_Code";
            ddl_BModel.DataBind();
            ddl_BModel.Items.Insert(0, "--Select One--");
        }

    }

    public void filldata(string sino, string VcNO)
    {
        int id = Convert.ToInt32(sino);
        int VouNo = Convert.ToInt32(VcNO);
        var v = from c in db.AME_Spare_EstimateEntryBillDetails.ToList().Where(t => t.Sp_Id == id && t.Sp_EstimationNo == VouNo && t.Branch_Name == Session["Branch"].ToString()) select c;
        txt_BVoucherNo.Text =Convert.ToString( v.First().Sp_EstimationNo);
        txt_BDate.Text = Convert.ToDateTime(v.First().Sp_EstimationDate).ToString("dd/MM/yyyy");
        ddl_BModel.SelectedValue = v.First().Mv_Code;
        txt_BName.Text = v.First().Sp_Name;
        txt_BAddress.Text = Convert.ToString(v.First().Sp_Address);
        txt_BMobileNo.Text = Convert.ToString(v.First().Sp_MobNo);
        txt_BRegdNo.Text = Convert.ToString(v.First().Sp_RegdNo);

        txt_AGrossAmount.Text = Convert.ToString(v.First().Sp_GrossAmount);
        txt_ADiscountAmount.Text = Convert.ToString(v.First().Sp_Discount);
        txt_ANetAmount.Text = Convert.ToString(v.First().Sp_NetAmount);
        txt_AVatAmount.Text = Convert.ToString(v.First().Sp_VatAmount);
        txt_ATotal.Text = Convert.ToString(v.First().Sp_TotalAmount);

        var details = (from c in db.AME_Spare_EstimateEntry.ToList()
                       where c.Sp_EstimationNo == VouNo && c.Branch_Name == Session["Branch"].ToString()
                       select c);

        GridView2.DataSource = details.ToList();
        GridView2.DataBind();

    }

}