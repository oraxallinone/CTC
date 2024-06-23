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
   
    Clear cl = new Clear();
    public string uname;
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            if (Session["Branch"] == null || Session["Uid"] == null || Session["Uname"] == null)
            {
                Response.Write("<script>alert('Your Session Time is Expired..!! Login to continue..!!')</script>");
                Response.Redirect("../SessionExpired.aspx");
            }
            string sino = Request.QueryString["id"];
            string type = Request.QueryString["Type"];
            string year = Request.QueryString["year"];

            if (type == "View")
            {
                
               fillEdit(sino, type,year);
              
               
                SetTextBoxReadOnly<TextBox>(Master.FindControl("form1"), true);
                 tbl_spareparts.Visible=false;
              
                btn_Submit.Visible = false;
                btn_Cancel.Visible = false;

                fillgridSparedata(sino, type);
                
            }
            if (type == "Edit")
            {
                Label19.Text = "Job Estimate Edit/Update";
                
                fillEdit(sino, type,year);

                tbl_spareparts.Visible = true;

                btn_Submit.Visible = false;
                btn_Submit.Text = "Update";
                btn_Cancel.Visible = false;
              
                int no = Convert.ToInt32(GridView2.Rows.Count);
                txt_PartSlNo.Text = Convert.ToString(no);
            }
           
        }
    }
    private void FillTechnisian()
    {
        var v = from c in db.AME_Master_Technician.ToList().OrderBy(t => t.Mt_Name)
                where c.Status = true && c.Branch_Name == Session["Branch"].ToString()
                select new
                {
                    Cu_Name = c.Mt_Name,
                    Cu_Code = c.Mt_Id
                };
        ddl_technisian.DataSource = v.ToList();
        ddl_technisian.DataTextField = "Cu_Name";
        ddl_technisian.DataValueField = "Cu_Code";
        ddl_technisian.DataBind();
        ddl_technisian.Items.Insert(0, "--Select One--");
    }

    [System.Web.Services.WebMethod]
    public static string[] GetPartNo(string prefixText, int count)
    {
        string branch = HttpContext.Current.Session["Branch"].ToString();
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Master_Item.Where(n => n.Itm_Partno.StartsWith(prefixText) && n.Branch_Name == branch).OrderBy(n => n.Itm_Partno).Select(n => n.Itm_Partno).Distinct().Take(count).ToArray();
    }
    [System.Web.Services.WebMethod]
    public static string[] GetPartId(string prefixText, int count)
    {
        string branch = HttpContext.Current.Session["Branch"].ToString();
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Master_Item.Where(n => n.Itm_code.StartsWith(prefixText) && n.Branch_Name == branch).OrderBy(n => n.Itm_code).Select(n => n.Itm_code).Distinct().Take(count).ToArray();
    }


     public decimal tot1;
     public void fillEdit(string sino, string type,string year)
     {
       
         FillTechnisian();
       

         string branchname = Session["Branch"].ToString();
         int sno = Convert.ToInt32(sino);
         var v = (from c in db.AME_Service_JobcardSpareIssue
                  join e in db.AME_Service_JobCardEntry on c.JC_No equals e.JC_No
                  join d in db.AME_Master_VehicleModel on e.JC_Modelname equals d.Mv_Id
                
                  join f in db.AME_Master_Technician on e.JCTechnisianName equals f.Mt_Id
                  join h in db.AME_Master_Customer on e.JC_Customername equals h.Mc_Id
                join g in db.AME_Master_Item on c.Itm_code equals g.Itm_code
                  where c.JC_No == sno && c.Branch_Name == branchname && e.Branch_Name == branchname && c.Jc_year == year && e.JC_year == year
                  select new

                  {

                      c.Jc_year,
                      c.JC_No,
                      c.SE_Sino,
                      c.SE_Date,
                      e.JC_Date,
                      e.JC_Regno,
                      e.JC_Engineno,
                      c.SE_Sparetype,
                      h.Mc_Name,
                      e.JC_Caddress,
                      e.JC_Chassisno,
                      e.JCTechnisianName,
                      c.Itm_code,
                      c.SE_Amount,
                      c.SE_Discount,
                      c.SE_Quantity,
                      c.SE_Rate,
                     
                       c.SE_Taxamount,
                      c.SE_Total,
                      c.SE_Vat,
                      g.Itm_PartDescrption,
                      g.Itm_Partno,
                    d.Mv_ModelName,
                    c.SE_Id,

                  }).Distinct().ToList();


         txt_date.Text = Convert.ToDateTime(v.First().SE_Date).ToString("dd/MM/yyyy");
         txt_sino.Text =Convert.ToString(v.First().SE_Sino);
         txt_jcno.Text = Convert.ToString(v.First().JC_No);
         txt_jcyear.Text = v.First().Jc_year;
         txt_jcdate.Text = Convert.ToDateTime(v.First().JC_Date).ToString("dd/MM/yyyy");
         txt_regdno.Text = v.First().JC_Regno;
         txt_engineno.Text = v.First().JC_Engineno;
         txt_modelname.Text = v.First().Mv_ModelName;
         txt_chassisno.Text = v.First().JC_Chassisno;
         ddl_servicetype.SelectedItem.Text = v.First().SE_Sparetype;
         txt_name.Text = v.First().Mc_Name;
         txt_address.Text = v.First().JC_Caddress;
         ddl_technisian.SelectedValue=Convert.ToString(v.First().JCTechnisianName);
         btn_Submit.ToolTip = Convert.ToString(v.First().SE_Sino);
         GridView2.DataSource = v.ToList();
         GridView2.DataBind();
         foreach (GridViewRow gr in GridView2.Rows)
         {


             Label lbl_Total = (Label)gr.FindControl("Label18");
             decimal Total = Convert.ToDecimal(lbl_Total.Text);

             tot1 = tot1 + Total;
             Label20.Text = Convert.ToString(tot1);
         }
       

     }
    //spare details
    public void fillgridSparedata(string sino, string type)
    {
       
        foreach (GridViewRow gr in GridView2.Rows)
        {
            ImageButton edit = (ImageButton)gr.FindControl("imgbtn_edit");
            ImageButton delete = (ImageButton)gr.FindControl("imgbtn_PartDelete");
            edit.Visible = false;
            delete.Visible = false;

        }

    }
    //service details
  
    
    //service details
    decimal tots1 = 0;
 
    private void SetTextBoxReadOnly<T>(Control parent, bool readOnly) where T : TextBox
    {
        foreach (var tb in parent.Controls.OfType<T>())
            tb.ReadOnly = readOnly;

        foreach (Control c in parent.Controls)
            SetTextBoxReadOnly<T>(c, readOnly);
    }
   
     
    protected void imgbtn_PartDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgdelete = (ImageButton)sender;
        string sino = (imgdelete.ToolTip);
        int id = Convert.ToInt32(sino);
        AME_Service_JobcardSpareIssue vq = db.AME_Service_JobcardSpareIssue.ToList().First(t => t.SE_Id == id);
        db.DeleteObject(vq);
        db.SaveChanges();
        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Data Deleted Sucessfully..!!');", true);

        string sino0 = Request.QueryString["id"];
        string type = Request.QueryString["Type"];
        string year=Request.QueryString["year"];
        fillEdit(sino0, type,year);

     
    }

    protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Vehicle_PurchaseDetailsDatewise.aspx");
        }
       
        protected void ddl_VType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fillModelno();
        }
        protected void txt_PartNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string branch = Session["Branch"].ToString();
                var v = from k in db.AME_Master_Item.ToList()
                        where (k.Itm_Partno.Equals(txt_PartNo.Text) && k.Branch_Name==branch)
                        select new
                        {
                            k.Itm_Partno,
                            k.Itm_PartDescrption,
                            k.Itm_SalePrice,
                            k.Itm_VatPercent,
                            k.Itm_code,
                        };

                txt_PartNo.Text = v.First().Itm_Partno;
                txt_PartDesc.Text = Convert.ToString(v.First().Itm_PartDescrption);
                txt_PartRate.Text = Convert.ToString(v.First().Itm_SalePrice);
                txt_PartVat.Text = Convert.ToString(v.First().Itm_VatPercent);
                txt_partid.Text = v.First().Itm_code;
                txt_PartQuantity.Focus();
            }
            catch
            {
                txt_PartNo.Text = "";
                txt_PartDesc.Text = "";
                txt_PartRate.Text = "";
                txt_PartVat.Text = "";
                txt_PartQuantity.Focus();
            }
        }
        protected void txt_PartDesc_TextChanged(object sender, EventArgs e)
        {

        }
    
   
        protected void btn_PartAdd_Click(object sender, EventArgs e)
        {
            try
            {

                if (txt_PartNo.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Part Number Should Not Be Blank..!!'); </script>", false);
                    txt_PartNo.Focus();
                    return;
                }
                if (txt_PartDesc.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Part Description Should Not Be Blank..!!'); </script>", false);
                    txt_PartDesc.Focus();
                    return;
                }

                if (txt_PartQuantity.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Quantity Should Not Be Blank..!!'); </script>", false);
                    txt_PartQuantity.Focus();
                    return;
                }

                if (txt_PartRate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Rate Should Not Be Blank..!!'); </script>", false);
                    txt_PartRate.Focus();
                    return;
                }
                if (txt_PartAmount.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Amount Should Not Be Blank..!!'); </script>", false);
                    txt_PartAmount.Focus();
                    return;
                }
                if (txt_PartDiscount.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Discount Should Not Be Blank..!!'); </script>", false);
                    txt_PartDiscount.Focus();
                    return;
                }
                if (txt_PartVat.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Vat Should Not Be Blank..!!'); </script>", false);
                    txt_PartVat.Focus();
                    return;
                }
                if (txt_PartTaxAmount.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Tax Amount Should Not Be Blank..!!'); </script>", false);
                    txt_PartTaxAmount.Focus();
                    return;
                }
                if (txt_PartTotal.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Total Should Not Be Blank..!!'); </script>", false);
                    txt_PartTotal.Focus();
                    return;
                }


                
                if (btn_PartAdd.Text == "Add")
                {
                    AME_Service_JobcardSpareIssue sparepart = new AME_Service_JobcardSpareIssue();
                    sparepart.Branch_Name = Session["Branch"].ToString();
                    sparepart.Created_By = Session["Uid"].ToString();
                    sparepart.Created_Date = SmitaClass.IndianTime();
                    sparepart.Itm_code = txt_partid.Text;
                    sparepart.JC_No =Convert.ToInt32(txt_jcno.Text);
                    sparepart.Jc_year = txt_jcyear.Text;
                    sparepart.SE_Amount = Convert.ToDecimal(txt_PartAmount.Text);
                    sparepart.SE_Rate = Convert.ToDecimal(txt_PartRate.Text);
                    sparepart.SE_Discount = Convert.ToDecimal(txt_PartDiscount.Text);
                    sparepart.Ms_Status = "OPEN";
                    sparepart.SE_Sparetype = ddl_servicetype.SelectedItem.Text;
                    sparepart.SE_Date = Convert.ToDateTime(txt_date.Text,SmitaClass.dateformat());
                    sparepart.SE_Quantity = Convert.ToDecimal(txt_PartQuantity.Text);
                    sparepart.SE_Taxamount = Convert.ToDecimal(txt_PartTaxAmount.Text);
                    sparepart.SE_Total = Convert.ToDecimal(txt_PartTotal.Text);
                    sparepart.SE_Vat = Convert.ToDecimal(txt_PartVat.Text);
                    sparepart.SE_Sino = Convert.ToInt32(txt_sino.Text);
                    db.AddToAME_Service_JobcardSpareIssue(sparepart);
                    db.SaveChanges();

                    string sino0 = Request.QueryString["id"];
                    string type = Request.QueryString["Type"];
                    string year=Request.QueryString["year"];
                    fillEdit(sino0, type,year);

                    txt_PartNo.Text = "";
                    txt_PartDesc.Text = "";
                    txt_PartQuantity.Text = "";
                    txt_PartRate.Text = "";
                    txt_PartAmount.Text = "";
                    txt_partid.Text = "";
                    txt_PartVat.Text = "";
                    txt_PartTaxAmount.Text = "";
                    txt_PartTotal.Text = "";
                    int no = Convert.ToInt32(GridView2.Rows.Count);
                    txt_PartSlNo.Text = Convert.ToString(no);
                    txt_PartNo.Focus();
                }
                else if (btn_PartAdd.Text == "Save")
                {
                    string id = btn_PartAdd.ToolTip;
                    int sino = Convert.ToInt32(id);
                    AME_Service_JobcardSpareIssue ses = db.AME_Service_JobcardSpareIssue.First(t => t.SE_Id == sino);
                    ses.Itm_code = txt_partid.Text;
                
                    ses.SE_Quantity = Convert.ToDecimal(txt_PartQuantity.Text);
                    ses.SE_Rate = Convert.ToDecimal(txt_PartRate.Text);
                    ses.SE_Amount = Convert.ToDecimal(txt_PartAmount.Text);
                    ses.SE_Discount = Convert.ToDecimal(txt_PartDiscount.Text);
                    ses.SE_Vat = Convert.ToDecimal(txt_PartVat.Text);
                    ses.SE_Taxamount = Convert.ToDecimal(txt_PartTaxAmount.Text);
                    ses.SE_Total = Convert.ToDecimal(txt_PartTotal.Text);
                    db.SaveChanges();
                    string sino0 = Request.QueryString["id"];
                    string type = Request.QueryString["Type"];
                    string year=Request.QueryString["year"];
                    fillEdit(sino0, type,year);

                    txt_partid.Text = "";
                    txt_PartNo.Text = "";
                    txt_PartDesc.Text = "";
                    txt_PartQuantity.Text = "";
                    txt_PartRate.Text = "";
                    txt_PartAmount.Text = "";
                    txt_PartDiscount.Text = "0";
                    txt_PartVat.Text = "";
                    txt_PartTaxAmount.Text = "";
                    txt_PartTotal.Text = "";
                    int no = Convert.ToInt32(GridView2.Rows.Count);
                    txt_PartSlNo.Text = Convert.ToString(no);
                    txt_PartNo.Focus();
                    btn_PartAdd.Text = "Add";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Data Update sucessfully..!!'); </script>", false);
                    return;
                }
            }
            catch
            {

            }
}



     
   
   
        protected void btn_back_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Service_JobEstimation_List.aspx");
        }
        protected void txt_partid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string branch = Session["Branch"].ToString();
                var v = from k in db.AME_Master_Item.ToList()
                        where (k.Itm_code.Equals(txt_partid.Text) && k.Branch_Name==branch)
                        select new
                        {
                            k.Itm_Partno,
                            k.Itm_PartDescrption,
                            k.Itm_SalePrice,
                            k.Itm_VatPercent,
                            k.Itm_code,
                        };

                txt_PartNo.Text = v.First().Itm_Partno;
                txt_PartDesc.Text = Convert.ToString(v.First().Itm_PartDescrption);
                txt_PartRate.Text = Convert.ToString(v.First().Itm_SalePrice);
                txt_PartVat.Text = Convert.ToString(v.First().Itm_VatPercent);
                txt_partid.Text = v.First().Itm_code;
                txt_PartQuantity.Focus();
            }
            catch
            {
                txt_PartNo.Text = "";
                txt_PartDesc.Text = "";
                txt_PartRate.Text = "";
                txt_PartVat.Text = "";
                txt_PartQuantity.Focus();
            }
        }
        protected void btn_Submit_Click(object sender, EventArgs e)
        {

        }
        protected void btn_Cancel_Click(object sender, EventArgs e)
        {

        }
        protected void imgbtn_edit_Click1(object sender, ImageClickEventArgs e)
        {
            try
            {
                string branchname = Session["Branch"].ToString();
                ImageButton imgbtnEdit = (ImageButton)sender;
                foreach (GridViewRow gr in GridView2.Rows)
                {
                    gr.BackColor = System.Drawing.Color.Transparent;
                }

                GridViewRow row = imgbtnEdit.NamingContainer as GridViewRow;
                row.BackColor = System.Drawing.Color.Cyan;

                string sino = (imgbtnEdit.ToolTip);
                int id = Convert.ToInt32(sino);
                var quotationlist = from c in db.AME_Service_JobcardSpareIssue.ToList()
                                       join g in db.AME_Master_Item on c.Itm_code equals g.Itm_code
                                       where c.SE_Id==id select new
                                       {
                                           c.SE_Total,
                                           c.SE_Vat,
                                           c.SE_Taxamount,
                                           c.SE_Rate,
                                           c.SE_Quantity,
                                           g.Itm_Partno,
                                           g.Itm_PartDescrption,
                                           c.Itm_code,
                                           c.SE_Amount,
                                          c.SE_Discount,
                                          c.SE_Id,
                                         
                                       };

                txt_PartNo.Text = quotationlist.First().Itm_Partno;
                txt_PartDesc.Text = quotationlist.First().Itm_PartDescrption;
                txt_partid.Text = quotationlist.First().Itm_code;
                txt_PartTaxAmount.Text = Convert.ToString(quotationlist.First().SE_Taxamount);
                txt_PartTotal.Text = Convert.ToString(quotationlist.First().SE_Total);
                txt_PartRate.Text = Convert.ToString(quotationlist.First().SE_Rate);
                txt_PartQuantity.Text = Convert.ToString(quotationlist.First().SE_Quantity);
                txt_PartAmount.Text = Convert.ToString(quotationlist.First().SE_Amount);
                txt_PartDiscount.Text = Convert.ToString(quotationlist.First().SE_Discount);
                txt_PartVat.Text = Convert.ToString(quotationlist.First().SE_Vat);

                btn_PartAdd.ToolTip = Convert.ToString(quotationlist.First().SE_Id);
                btn_PartAdd.Text = "Save";
               


            }
            catch
            {

            }
        }
      
        protected void btn_back_Click2(object sender, EventArgs e)
        {
            Response.Redirect("Service_JobSpareIssue_List.aspx");
        }
}

    
