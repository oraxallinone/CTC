using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
using System.Data;
public partial class Admin_Spare_PurchaseEntry : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();

    static List<PartDetails> SPE = new List<PartDetails>();
   static string[] duplicates;
    Clear cl = new Clear();
    public string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            try
            {
                if (ViewState["ran_Key"] != null)
                {
                    SPE.RemoveAll(t => t.key == ViewState["ran_Key"].ToString());
                }


                string ran_Key = CreateRandomPassword1(5);

                ViewState["ran_Key"] = ran_Key;
                var mx = SPE.ToList();
                int slmax = 0;


                if (DebasishGlobal.s4 > 0)
                {

                    slmax = DebasishGlobal.s4 + 1;
                    DebasishGlobal.s4 = slmax;
                }

                else
                {
                    slmax = 1;
                    DebasishGlobal.s4 = 1;
                }
                ViewState["maxs"] = Convert.ToString(slmax);
                //var mx = SPE.ToList();
                //int slmax = 0;
                //if (mx.Count > 0)
                //    slmax = (mx.Max(t => t.maxslno) + 1);
                //else
                //    slmax = 1;
                //ViewState["maxs"] = Convert.ToString(slmax);
                FillTechnisian();
                //SPE.RemoveAll(t => t.UserId == Session["Uid"].ToString());
                FillSpareissueNo();
                txt_date.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
                FillSlno();

                txt_PartVat.Attributes.Add("readonly", "readonly");
                txt_PartTaxAmount.Attributes.Add("readonly", "readonly");
                txt_PartTotal.Attributes.Add("readonly", "readonly");
            }
            catch (Exception ex)
            { }

        }
    }

    public static string CreateRandomPassword1(int PasswordLength)
    {
        string _allowedChars = "0123456789";
        Random randNum = new Random();
        char[] chars = new char[PasswordLength];
        int allowedCharCount = _allowedChars.Length;
        for (int i = 0; i < PasswordLength; i++)
        {
            chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
        }
        return new string(chars);
    }

    [System.Web.Services.WebMethod]
    public static string[] GetPartNo(string prefixText, int count)
    {
        string branch = HttpContext.Current.Session["Branch"].ToString();
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Master_Item.Where(n => n.Itm_Partno.Contains(prefixText) && n.Branch_Name == branch).OrderBy(n => n.Itm_Partno).Select(n => n.Itm_Partno).Distinct().Take(count).ToArray();
    }
    
    //[System.Web.Services.WebMethod]
    //public static string[] GetPartNo(string prefixText, int count)
    //{
    //    AutoMobileEntities db = new AutoMobileEntities();
    //    return db.AME_Spare_PurchaseEntry.Where(n => n.Itm_Partno.StartsWith(prefixText)).OrderBy(n => n.Itm_Partno).Select(n => n.Itm_Partno).Distinct().Take(count).ToArray();
    //}
    [System.Web.Services.WebMethod]
    public static string[] GetPartId(string prefixText, int count)
    {
        string branch = HttpContext.Current.Session["Branch"].ToString();
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Master_Item.Where(n => n.Itm_code.StartsWith(prefixText) && n.Branch_Name == branch).OrderBy(n => n.Itm_code).Select(n => n.Itm_code).Distinct().Take(count).ToArray();
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
 

  
    private void FillSpareissueNo()
    {
        string branchname = Session["Branch"].ToString();
        if ((from c in db.AME_Service_JobcardSpareIssue where c.Branch_Name == branchname select c.SE_Sino).Count() > 0)
        {
           // int VNo = (int)(from c in db.AME_Service_JobCardEntry where c.Branch_Name == branchname select c.JC_No).Max();
            int VNo = (int)(from c in db.AME_Service_JobCardEntry where c.Branch_Name == branchname select c.JC_No).Count();

            txt_sino.Text = Convert.ToString(VNo + 1);
        }
        else
        {
            txt_sino.Text = "1";
        }
    }
    
   
   
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        cl.Clear_All(this);
    }
    decimal tot1;
    private void FillGrid()
    {
        try
        {
            uname = Session["Uid"].ToString();
            int mx = Convert.ToInt32(ViewState["maxs"].ToString());
            string key11 = ViewState["ran_Key"].ToString();
            string branch = Session["Branch"].ToString();
            var prd = (from c in SPE.ToList()
                      // where c.UserId == uname && c.branch == branch && c.maxslno == mx
                       where c.key == key11
                       select c).ToList();
            GridView2.DataSource = prd.ToList();
            GridView2.DataBind();

            foreach (GridViewRow gr in GridView2.Rows)
            {


                Label lbl_Total = (Label)gr.FindControl("Label18");
                decimal Total = Convert.ToDecimal(lbl_Total.Text);

                tot1 = tot1 + Total;
                Label1.Text = Convert.ToString(tot1);
            }
        }
        catch (Exception ex)
        { }
    }
    public void fillmandatoryfield()
    {
        //if (txt_date.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Date Should Not Be Blank ..!!'); </script>", false);
        //    txt_date.Focus();
        //    return;
        //}
        //if (txt_sino.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Serial Number Should Not Be Blank..!!'); </script>", false);
        //    txt_sino.Focus();
        //    return;
        //}
        //if (txt_jcno.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Job Card Number Should Not Be Blank..!!'); </script>", false);
        //    txt_jcno.Focus();
        //    return;
        //}
        //if (txt_jcdate.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Job Card DateShould Not Be Blank..!!'); </script>", false);
        //    txt_jcdate.Focus();
        //    return;
        //}

        //if (txt_regdno.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Reg No Should Not Be Blank..!!'); </script>", false);
        //    txt_regdno.Focus();
        //    return;
        //}

        //if (txt_engineno.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Engine No Should Not Be Blank ..!!'); </script>", false);
        //    txt_engineno.Focus();
        //    return;
        //}
        //if (txt_modelname.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Engine No Should Not Be Blank ..!!'); </script>", false);
        //    txt_modelname.Focus();
        //    return;
        //}


        //if (txt_name.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Name  Should Not Be Blank..!!'); </script>", false);
        //    txt_name.Focus();
        //    return;
        //}
        //if (txt_address.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Address  Should Not Be Blank..!!'); </script>", false);
        //    txt_address.Focus();
        //    return;
        //}
        //if (ddl_technisian.SelectedIndex == 0)
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Technisian Name ..!!'); </script>", false);
        //    ddl_technisian.Focus();
        //    return;
        //}


        string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy", "dd-MM-yyyy" };
        DateTime expectedDate;
        if (!DateTime.TryParseExact(txt_date.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
            txt_date.Focus();
            return;
        }
        if (!DateTime.TryParseExact(txt_jcdate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
            txt_jcdate.Focus();
            return;
        }
    }
    
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {

            string scode = ViewState["statecode"].ToString();
            fillmandatoryfield();

            if (GridView2.Rows.Count <= 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Please Add Spare Details..!!');", true);
                txt_sino.Focus();
                return;
            }
           
            foreach (GridViewRow gr in GridView2.Rows)
            {
                Label lbl_partno = (Label)gr.FindControl("Label10");
                Label lbl_partcode = (Label)gr.FindControl("lbl_Itmcode");
                Label lbl_partDesc = (Label)gr.FindControl("Label12");
                Label lbl_Quantity = (Label)gr.FindControl("Label11");
                Label lbl_Rate = (Label)gr.FindControl("Label14");
                Label lbl_Amount = (Label)gr.FindControl("Label13");
                Label lbl_Discount = (Label)gr.FindControl("Label15");
                Label lbl_discper = (Label)gr.FindControl("lbl_discper");
                Label lbl_Vat = (Label)gr.FindControl("Label16");
                Label lbl_TaxAmt = (Label)gr.FindControl("Label17");
                Label lbl_Total = (Label)gr.FindControl("Label18");
                Label lblsparetype = (Label)gr.FindControl("lblsparetype");
                Label sflag = (Label)gr.FindControl("lbl_flag");


                string branch = Session["Branch"].ToString();
                int jno = Convert.ToInt32(txt_jcno.Text);
                var v = from c in db.AME_Service_JobcardSpareIssue.Where(t => t.Itm_code == lbl_partcode.Text.Trim() && t.JC_No == jno && t.Branch_Name == branch && t.Jc_year==txt_jcyear.Text) select c;
                if (Convert.ToInt32(v.Count()) > 0)
                {
                    var jeca = v.ToArray();
                    AME_Service_JobcardSpareIssue jec = jeca[0];
                    if (jec.SE_ReturnQuantity > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Some Parts Returned  you added again  .!!'); </script>", false);
                        //txt_PartNo.Focus();
                        //return;
                    }
                    else
                    {
                      //  ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('This Part No Already Exist.!!'); </script>", false);
                      //  txt_PartNo.Focus();
                      //  return;
                    }
                }


                AME_Service_JobcardSpareIssue pd = new AME_Service_JobcardSpareIssue();
                pd.Branch_Name = Session["Branch"].ToString();
                pd.Created_By = Session["Uid"].ToString();
                pd.Created_Date = SmitaClass.IndianTime();
                pd.Itm_code = lbl_partcode.Text;
                pd.JC_No = Convert.ToInt32(txt_jcno.Text);
                pd.Jc_year = txt_jcyear.Text;
                pd.Ms_Status = "OPEN";
                pd.JC_Regno = txt_regdno.Text;
                pd.SE_Sino = Convert.ToInt32(txt_sino.Text);
                pd.SE_Amount = Convert.ToDecimal(lbl_Amount.Text);
                pd.SE_Date = Convert.ToDateTime(txt_date.Text, SmitaClass.dateformat());
                pd.SE_Discount = Convert.ToDecimal(lbl_Discount.Text);
                pd.SE_DiscountPer = Convert.ToDecimal(lbl_discper.Text);
                pd.SE_Quantity = Convert.ToDecimal(lbl_Quantity.Text);
                pd.SE_Rate = Convert.ToDecimal(lbl_Rate.Text);
                pd.SE_Sparetype = lblsparetype.Text;
                pd.SE_Taxamount = Convert.ToDecimal(lbl_TaxAmt.Text);
                pd.SE_Total = Convert.ToDecimal(lbl_Total.Text);
                pd.SE_Vat = Convert.ToDecimal(lbl_Vat.Text);

                if (sflag.Text == "1")
                {
                    pd.cat_flag = true;
                }
                else
                {
                    pd.cat_flag = false;
                }
                pd.SE_ReturnQuantity = 0;
                pd.Statecode = scode;
                if (scode.Equals("21"))
                {

                    pd.scodeflag = false;
                
                
                }

                else
                {
                    pd.scodeflag = true;
                }
                pd.gstflag = true;

                db.AddToAME_Service_JobcardSpareIssue(pd);
                db.SaveChanges();

                //AME_Daily_SpareSales_Report dsr = new AME_Daily_SpareSales_Report();
                //dsr.JC_No = Convert.ToInt32(txt_jcno.Text);
                //dsr.Part_No = lbl_partno.Text;
                //dsr.DR_IDate = Convert.ToDateTime(txt_jcdate.Text, SmitaClass.dateformat());
                //dsr.SE_Quantity = Convert.ToDecimal(lbl_Quantity.Text);
                //dsr.SE_Rate = Convert.ToDecimal(lbl_Rate.Text);
                //dsr.SE_Amount = Convert.ToDecimal(lbl_Amount.Text);
                //dsr.SE_Discount = Convert.ToDecimal(lbl_Discount.Text);
                //dsr.SE_Vat = Convert.ToDecimal(lbl_Vat.Text);
                // dsr.Branch_Name=Session["Branch"].ToString();
                //dsr.Ms_Status = "SERVICE";
                //db.AddToAME_Daily_SpareSales_Report(dsr);
                //db.SaveChanges();

                decimal qntity=Convert.ToDecimal(lbl_Quantity.Text);
                string partno=lbl_partno.Text;
                ////string param = "@Branch,@Req_Qntity,@ItmPartno";
                ////string paramvalue = branch + "," + qntity + "," + partno;
                string[] param ={ "@Branch","@Req_Qntity","@ItmPartno"};
                string[] paramvalue = { branch , qntity.ToString() ,  partno};
                smitaDbAccess.insertprocedurestockcoma("Sp_StockdispatchInSpareIssue", param, paramvalue);
               // FillGrid();
            }

            FillSpareissueNo();

           
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('SpareIssue  done SuccessFully..!!'); </script>", false);


            SPE.RemoveAll(t => t.UserId == Session["Uid"].ToString());
            FillGrid();

         
            cl.Clear_All(this);
        }
        catch(Exception ex)
        {

        }


        
       
    }

    protected void txt_PartNo_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string branch = Session["Branch"].ToString();
            //var v = from k in db.AME_Master_Item.ToList()
            //        where (k.Itm_Partno.Equals(txt_PartNo.Text) && k.Branch_Name==branch)
            //        select new
            //        {
            //            k.Itm_Partno,
            //            k.Itm_PartDescrption,
            //            k.Itm_SalePrice,
            //            k.Itm_VatPercent,
            //            k.Itm_code,
            //            k.Itm_CategoryName
            //        };

            //txt_PartNo.Text = v.First().Itm_Partno;
            //txt_PartDesc.Text = Convert.ToString(v.First().Itm_PartDescrption);
            //lbl_cat.Text = v.First().Itm_CategoryName;
            //decimal rate = v.First().Itm_SalePrice;
            //txt_PartRate.Text = Convert.ToString(v.First().Itm_SalePrice);

            string param1 = "@partname,@branch";
            string paramvalue1 = txt_PartNo.Text + "," + branch;
            DataSet ds43= smitaDbAccess.SPReturnDataSet("Sp_rtndetailsitem", param1, paramvalue1);

            txt_PartNo.Text = ds43.Tables[0].Rows[0][0].ToString();
            txt_PartDesc.Text = ds43.Tables[0].Rows[0][1].ToString();
            lbl_cat.Text = ds43.Tables[0].Rows[0][5].ToString();
            decimal rate = Convert.ToDecimal(ds43.Tables[0].Rows[0][2].ToString());




            if (ddlsparetype.SelectedItem.Text == "WARRANTY")
            {
                //txt_PartVat.Text = Convert.ToString(v.First().Itm_VatPercent);
                //txt_PartNo.ToolTip = v.First().Itm_code;

                txt_PartVat.Text = ds43.Tables[0].Rows[0][3].ToString();
                txt_PartNo.ToolTip = ds43.Tables[0].Rows[0][4].ToString();
                
                
                
                txt_PartQuantity.Focus();

                DataSet ds = smitaDbAccess.returndataset("select SUM(Ss_NetQuantity) AS NetQuantity FROM AME_Spare_PurchaseEntry WHERE Itm_Partno='" + txt_PartNo.Text + "' AND Branch_Name='" + Session["Branch"].ToString() + "'");
                if (ds.Tables[0].Rows[0].ItemArray[0].ToString() != "")
                {
                    txt_AvlQty.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                }
                else
                {
                    txt_AvlQty.Text = "0";
                }

                decimal vat = Convert.ToDecimal(txt_PartVat.Text);
                //decimal rate = Convert.ToDecimal(txt_PartRate.Text);
                decimal temp = Convert.ToDecimal(rate / (100 + vat));
                txt_PartAmount.Text = "0";
                txt_PartRate.Text = (temp * 100).ToString("0.00");

                txt_PartQuantity.Focus();
                txt_PartQuantity.Text = "1";

                txt_PartDiscount.Text = "0";
                txt_PartDiscountper.Text = "0";
                txt_PartTaxAmount.Text = "0";
                txt_PartTotal.Text = "0";



               
            }
            else
            {
                //txt_PartVat.Text = Convert.ToString(v.First().Itm_VatPercent);
                //txt_PartNo.ToolTip = v.First().Itm_code;

                txt_PartVat.Text = ds43.Tables[0].Rows[0][3].ToString();
                txt_PartNo.ToolTip = ds43.Tables[0].Rows[0][4].ToString();

                txt_PartQuantity.Focus();

                DataSet ds = smitaDbAccess.returndataset("select SUM(Ss_NetQuantity) AS NetQuantity FROM AME_Spare_PurchaseEntry WHERE Itm_Partno='" + txt_PartNo.Text + "' AND Branch_Name='" + Session["Branch"].ToString() + "'");
                if (ds.Tables[0].Rows[0].ItemArray[0].ToString() != "")
                {
                    txt_AvlQty.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                }
                else
                {
                    txt_AvlQty.Text = "0";
                }

                decimal vat = Convert.ToDecimal(txt_PartVat.Text);
                //decimal rate = Convert.ToDecimal(txt_PartRate.Text);
                decimal temp = Convert.ToDecimal(rate / (100 + vat));
                txt_PartAmount.Text = (temp * 100).ToString("0.00");
                txt_PartRate.Text = (temp * 100).ToString("0.00");
                ViewState["rate"] = rate;
              
                txt_PartQuantity.Focus();
                txt_PartQuantity.Text = "1";



                decimal amnt = temp * 100;

                decimal qty = Convert.ToDecimal(txt_PartQuantity.Text);
                txt_PartAmount.Text = (amnt * qty).ToString("0.00");
                txt_PartDiscount.Text = "0";
                txt_PartDiscountper.Text = "0";
                decimal amnt1 = Convert.ToDecimal(txt_PartAmount.Text);
                decimal afterdisc = amnt1;
                txt_PartTaxAmount.Text = (afterdisc * (vat / 100)).ToString("0.00");

                decimal taxamnt = Convert.ToDecimal(txt_PartTaxAmount.Text);
                txt_PartTotal.Text = (afterdisc + taxamnt).ToString("0.00");
            }

            
        }
        catch(Exception ex)
        {
            txt_PartNo.Text = "";
            txt_PartDesc.Text = "";
            txt_PartRate.Text = "";
            txt_PartVat.Text = "";
            txt_PartDiscount.Text = "0";
            txt_PartQuantity.Focus();
            txt_PartQuantity.Text = "0";
        }
    }
    private void FillSlno()
    {
        var v = SPE.ToList();
        if (v.Count() > 0)
        {
            txt_PartSlNo.Text = (v.Count() + 1).ToString();
        }
        else
        {
            txt_PartSlNo.Text = "1";
        }
    }
    protected void btn_PartAdd_Click(object sender, EventArgs e)
    {
        Boolean localisse = false;
        try
        {
            string branch = Session["Branch"].ToString();
            fillmandatoryfield();
            if (txt_PartVat.Text == "" || txt_PartVat.Text == "0" || txt_PartVat.Text == "0.00")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('enter gst % first..!!'); </script>", false);
                txt_PartVat.Focus();
                return;
            }






            //if (txt_PartDesc.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Part Description Should Not Be Blank..!!'); </script>", false);
            //    txt_PartDesc.Focus();
            //    return;
            //}

            //if (txt_PartQuantity.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Quantity Should Not Be Blank..!!'); </script>", false);
            //    txt_PartQuantity.Focus();
            //    return;
            //}

            //if (txt_PartRate.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Rate Should Not Be Blank..!!'); </script>", false);
            //    txt_PartRate.Focus();
            //    return;
            //}
            //if (txt_PartAmount.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Amount Should Not Be Blank..!!'); </script>", false);
            //    txt_PartAmount.Focus();
            //    return;
            //}
            //if (txt_PartDiscount.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Discount Should Not Be Blank..!!'); </script>", false);
            //    txt_PartDiscount.Focus();
            //    return;
            //}
            //if (txt_PartVat.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Vat Should Not Be Blank..!!'); </script>", false);
            //    txt_PartVat.Focus();
            //    return;
            //}
            //if (txt_PartVat.Text == "0.00")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Vat Should Not Be Blank..!!'); </script>", false);
            //   // txt_PartVat.Focus();
            //    return;
            //}
            //if (txt_PartTaxAmount.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Tax Amount Should Not Be Blank..!!'); </script>", false);
            //    txt_PartTaxAmount.Focus();
            //    return;
            //}
            //if (txt_PartTotal.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Total Should Not Be Blank..!!'); </script>", false);
            //    txt_PartTotal.Focus();
            //    return;
            //}
           
            //if (ddlsparetype.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Spare Type.!!'); </script>", false);
            //    ddlsparetype.Focus();
            //    return;
            //}
            if (Convert.ToDecimal(txt_PartQuantity.Text) > Convert.ToDecimal(txt_AvlQty.Text))
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Your Available Quantity is Not Valid !!'); </script>", false);
                txt_PartQuantity.Focus();
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Your Available Quantity is '" + txt_AvlQty.Text + "' ..!!'); </script>", false);
                //ddl_technisian.Focus();
                return;
            }
            int mx = Convert.ToInt32(ViewState["maxs"].ToString());
            var v = SPE.Where(t => t.Itm_Partno == txt_PartNo.Text.Trim() && t.branch == branch && t.maxslno == mx);
            if(Convert.ToInt32(v.Count())>0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Part No : " + txt_PartNo.Text.Trim() + " Already Exist.!!'); </script>", false);
                localisse = true;
                //  txt_PartNo.Focus();
              //  return;
            }
            if (!localisse)
            {
                AutoMobileEntities ndb = new AutoMobileEntities();
                 string bran = Session["Branch"].ToString();
        //int sno = Convert.ToInt32(sino);
                 int jno = Convert.ToInt32(txt_jcno.Text);
                    var vd = (from c in ndb.AME_Service_JobcardSpareIssue
                             join di in ndb.AME_Master_Item on c.Itm_code equals di.Itm_code 
                              //where c.Branch_Name.Equals(bran) && c.JC_No == Convert.ToInt32(txt_jcno.Text) && di.Itm_Partno.Equals(txt_PartNo.Text) 
                              where c.Branch_Name.Equals(bran) && c.JC_No == jno && di.Itm_Partno.Equals(txt_PartNo.Text) 
                              select c.Itm_code).ToList();
                if(vd.Count > 0)
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Part No : " + txt_PartNo.Text.Trim() + " Already added Before.!!'); </script>", false);
           
                //if (duplicates.Length > 0)
                //{
                //    for (int i = 0; i < duplicates.Length; i++)
                //    {
                //        if (duplicates[i].Equals(txt_PartNo.Text.Trim()))
                //        {
                //            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Part No : " + txt_PartNo.Text.Trim() + " Already added Before.!!'); </script>", false);
                //            break;
                //        }
                //    }
                //}
            }
            PartDetails pr1 = new PartDetails();
            var pv = SPE.ToList();
            int max = 0;
            if (pv.Count > 0)
                max = pv.Max(t => t.slno);
            pr1.slno = max + 1;
            pr1.Itm_Partno = txt_PartNo.Text.Trim();
            pr1.Itm_PartDescrption = txt_PartDesc.Text;
            pr1.Ss_Quantity = Convert.ToDecimal(txt_PartQuantity.Text);
            pr1.Ss_Rate = Convert.ToDecimal(txt_PartRate.Text);
            pr1.Ss_Amount = Convert.ToDecimal(txt_PartAmount.Text);
            pr1.Ss_Discount = Convert.ToDecimal(txt_PartDiscount.Text);
            pr1.Ss_DiscountPer = Convert.ToDecimal(txt_PartDiscountper.Text);
            pr1.Ss_Vat = Convert.ToDecimal(txt_PartVat.Text);
            pr1.Ss_TaxAmont = Convert.ToDecimal(txt_PartTaxAmount.Text);
            pr1.Ss_Total = Convert.ToDecimal(txt_PartTotal.Text);
            pr1.Itm_code = txt_PartNo.ToolTip;
            pr1.sparetype = ddlsparetype.SelectedItem.Text;
            pr1.UserId = Session["Uid"].ToString();
            pr1.branch = Session["Branch"].ToString();
            pr1.maxslno = Convert.ToInt32(ViewState["maxs"].ToString());
            pr1.key = ViewState["ran_Key"].ToString();
            if (lbl_cat.Text == "Lubricants")
            {
                pr1.cat_flag = 0;
            }
            else
            {
                pr1.cat_flag = 1;
            }

            SPE.Add(pr1);

            FillGrid();

            txt_PartNo.Text = "";
            txt_PartDesc.Text = "";
            txt_PartQuantity.Text = "";
            txt_PartRate.Text = "";
            txt_PartAmount.Text = "";
            txt_PartDiscount.Text = "0";
            txt_PartDiscountper.Text = "0";
            txt_PartVat.Text = "";
            txt_PartTaxAmount.Text = "";
            txt_PartTotal.Text = "";
            txt_PartNo.ToolTip = "";
            lbl_cat.Text = "";
            ddlsparetype.SelectedIndex = 0;
            txt_AvlQty.Text = "";
            FillSlno();
            txt_PartNo.Focus();
        }
        catch(Exception ex)
        {

        }
    }
 
    public void fillsparedetails()
    {
        try
        {
            string branchname = Session["Branch"].ToString();
            int no = Convert.ToInt32(txt_jcno.Text);
            var jcno = (from c in db.AME_Service_JobCardEntry
                        join d in db.AME_Master_Customer on c.JC_Customername equals d.Mc_Id
                        join f in db.AME_Master_VehicleModel on c.JC_Modelname equals f.Mv_Id
                        where c.JC_No == no && c.Branch_Name == branchname && c.Ms_Status == "OPEN"
                        select new
                        {
                            c.JC_Date,
                            c.JC_year,
                            c.JC_Caddress,
                            c.JC_Engineno,
                            c.JC_Chassisno,
                            f.Mv_ModelName,
                            c.JC_Regno,
                            d.Mc_Name,
                            d.Mc_Mobileno,
                            c.JCTechnisianName
                        }).ToList();

            txt_jcdate.Text = Convert.ToDateTime(jcno.First().JC_Date).ToString("dd/MM/yyyy");
            txt_regdno.Text = jcno.First().JC_Regno;
            txt_jcyear.Text = jcno.First().JC_year;
            txt_chassisno.Text = jcno.First().JC_Chassisno;
            txt_engineno.Text = jcno.First().JC_Engineno;
            txt_modelname.Text = jcno.First().Mv_ModelName;
            ddl_technisian.SelectedValue = Convert.ToString(jcno.First().JCTechnisianName);
            txt_name.Text = jcno.First().Mc_Name;
            txt_address.Text = jcno.First().JC_Caddress;
            txt_mob.Text = jcno.First().Mc_Mobileno;
        }
        catch (Exception ex)
        { }
    }


    public void fillsparedetails1()
    {
        try
        {
            string branchname = Session["Branch"].ToString();
            int no = Convert.ToInt32(txt_jcno.Text);
            var jcno = (from c in db.AME_Service_JobCardEntry
                        join d in db.AME_Master_Customer on c.JC_Customername equals d.Mc_Id
                        join f in db.AME_Master_VehicleModel on c.JC_Modelname equals f.Mv_Id
                        where c.JC_No == no && c.Branch_Name == branchname && c.Ms_Status == "OPEN" && c.JC_year == txt_jcyear.Text.Trim()
                        select new
                        {
                            c.JC_Date,
                            c.JC_year,
                            c.JC_Caddress,
                            c.JC_Engineno,
                            c.JC_Chassisno,
                            f.Mv_ModelName,
                            c.JC_Regno,
                            d.Mc_Name,
                            d.Mc_Mobileno,
                            c.JCTechnisianName
                        }).ToList();

            txt_jcdate.Text = Convert.ToDateTime(jcno.First().JC_Date).ToString("dd/MM/yyyy");
            txt_regdno.Text = jcno.First().JC_Regno;
            txt_jcyear.Text = jcno.First().JC_year;
            txt_chassisno.Text = jcno.First().JC_Chassisno;
            txt_engineno.Text = jcno.First().JC_Engineno;
            txt_modelname.Text = jcno.First().Mv_ModelName;
            ddl_technisian.SelectedValue = Convert.ToString(jcno.First().JCTechnisianName);
            txt_name.Text = jcno.First().Mc_Name;
            txt_address.Text = jcno.First().JC_Caddress;
            txt_mob.Text = jcno.First().Mc_Mobileno;
        }
        catch (Exception ex)
        { }
    }

    //public void fillspareissue()
    //{
    //    int no = Convert.ToInt32(txt_jcno.Text);
    //    var details = from c in db.AME_Service_JobcardSpareIssue.Where(t => t.JC_No == no) select c;


    //}
    public void fillspareissuedetails(int sino)
    {
        try
        {
            string branchname = Session["Branch"].ToString();
            //int sno = Convert.ToInt32(sino);
            var v = (from c in db.AME_Service_JobcardSpareIssue
                     join e in db.AME_Service_JobCardEntry on c.JC_No equals e.JC_No
                     join g in db.AME_Master_Item on c.Itm_code equals g.Itm_code
                     //where c.JC_No == sino && c.Branch_Name == branchname && (c.SE_Quantity - c.SE_ReturnQuantity) > 0 && c.SE_Quantity > 0
                     //where c.JC_No == sino && c.Branch_Name == branchname && (c.SE_Quantity - c.SE_ReturnQuantity) > 0 && c.SE_Quantity > 0 && c.JC_Regno == e.JC_Regno


                     where c.JC_No == sino && c.Branch_Name == branchname && c.SE_Quantity > 0 && c.JC_Regno == e.JC_Regno && c.Ms_Status == "OPEN" && c.Jc_year == txt_jcyear.Text && e.JC_year == txt_jcyear.Text

                     select new
                     {
                         c.Itm_code,
                         g.Itm_Partno,
                         g.Itm_PartDescrption,
                         c.SE_Quantity,
                         c.SE_Rate,
                         c.SE_Amount,
                         c.SE_Discount,
                         Ss_DiscountPer = c.SE_DiscountPer,
                         c.SE_Vat,
                         c.SE_ReturnQuantity,
                         qnty = c.SE_Quantity,
                         // qnty = (c.SE_ReturnQuantity == null) ? c.SE_Quantity : c.SE_Quantity - c.SE_ReturnQuantity, 
                         c.SE_Taxamount,
                         c.SE_Total,
                         c.SE_Id
                     }).ToList();
            //}).Distinct().ToList();
            GridView3.DataSource = v.ToList();
            GridView3.DataBind();
        }
        catch (Exception ex)
        { }
    }
    protected void txt_jcno_TextChanged(object sender, EventArgs e)
    {
        try
        {
        FillTechnisian();
        int jno = Convert.ToInt32(txt_jcno.Text);
        string branchname = Session["Branch"].ToString();
             var jcno = from c in db.AME_Service_JobCardEntry.Where(t => t.JC_No == jno && t.Branch_Name==branchname && t.Ms_Status=="OPEN" ) select c;
             var spareissue = from c in db.AME_Service_JobcardSpareIssue.Where(t => t.JC_No == jno && t.Branch_Name == branchname) select c;
             if (Convert.ToInt32(jcno.Count()) > 0)
             {
                 if (jcno.First().Ms_Status == "CLOSE")
                 {
                     ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('CaN Not Return Sale Because Of Job Card Is Closed..!!!');</script>", false);
                     txt_jcno.Focus();
                     txt_jcno.Text = "";

                    
                 }
                 if (Convert.ToInt32(spareissue.Count()) > 0)
                     {
                         string statecode = jcno.First().Statecode;
                         ViewState["statecode"] = statecode;
                         fillsparedetails();
                         fillspareissuedetails(jno);
                     }
                 else
                 {
                     string statecode = jcno.First().Statecode;
                     ViewState["statecode"] = statecode;
                     fillsparedetails();
                 }
             }

             else
             {
                 
                 ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invalid Si Jobcardno..!!!');</script>", false);
                 txt_jcno.Focus();
                 txt_jcno.Text = "";
                 return;
             }
             
        }
        catch(Exception ex)
        {

        }
    }

    public class PartDetails
    {
        public int slno { get; set; }
        public string Itm_Partno { get; set; }

        public string sparetype { get; set; }

        public string Itm_code { get; set; }

        public string Itm_PartDescrption { get; set; }

        public decimal Ss_Quantity { get; set; }

        public decimal Ss_Rate { get; set; }

        public decimal Ss_Amount { get; set; }

        public decimal Ss_DiscountPer { get; set; }

        public decimal Ss_Discount { get; set; }

        public decimal Ss_Vat { get; set; }

        public decimal Ss_TaxAmont { get; set; }

        public decimal Ss_Total { get; set; }

        public string UserId { get; set; }

        public string branch { get; set; }

        public int maxslno { get; set; }
        public int cat_flag { get; set; }
        public string key { get; set; }

    }
   
   
    protected void imgbtn_PartDelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton img_delete = (ImageButton)sender;
            string branch = Session["Branch"].ToString();
            int mx = Convert.ToInt32(ViewState["maxs"].ToString());
            int deleteno = 0;
            //foreach (GridViewRow gr in GridView2.Rows)
            //{
            //    Label lbl_delete_Sl = (Label)gr.FindControl("lbl_SL_NO_Delete");
            //     deleteno = Convert.ToInt32(lbl_delete_Sl.Text);
            //}
            GridViewRow row = (GridViewRow)img_delete.NamingContainer;
            //int rowind = row.RowIndex;
            Label deletelbl = (Label)row.FindControl("lbl_SL_NO_Delete");
            deleteno = Convert.ToInt32(deletelbl.Text);
            //SPE.RemoveAll(t => t.Itm_Partno == img_delete.ToolTip && t.branch==branch && t.slno == 1);
            if (deleteno > 0)
                SPE.RemoveAll(t => t.Itm_Partno == img_delete.ToolTip && t.branch == branch && t.slno == deleteno && t.maxslno == mx);
            FillGrid();
        }
        catch (Exception ex)
        { }
    }
    protected void txt_PartQuantity_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlsparetype.SelectedItem.Text == "WARRANTY")
            {
                txt_PartAmount.Text = "0";
                txt_PartDiscount.Text = "0";
                txt_PartDiscountper.Text = "0";
                txt_PartTaxAmount.Text = "0";
                txt_PartTotal.Text = "0";


            }
            else if (ddlsparetype.SelectedItem.Text == "FOC")
            {

                txt_PartAmount.Text = "0";
                txt_PartDiscount.Text = "0";
                txt_PartDiscountper.Text = "0";
                txt_PartTaxAmount.Text = "0";
                txt_PartTotal.Text = "0";

            }
            else
            {

                decimal vat = Convert.ToDecimal(txt_PartVat.Text);

                decimal rate = Convert.ToDecimal(ViewState["rate"]);
                decimal rate1 = Convert.ToDecimal(txt_PartRate.Text);


                decimal temp = Convert.ToDecimal(rate / (100 + vat));
                decimal amnt = temp * 100;

                decimal qty = Convert.ToDecimal(txt_PartQuantity.Text);
                //  txt_PartAmount.Text = (amnt * qty).ToString("0.00");
                txt_PartAmount.Text = (rate1 * qty).ToString("0.00");

                txt_PartDiscount.Text = "0";
                txt_PartDiscountper.Text = "0";
                decimal amnt1 = Convert.ToDecimal(txt_PartAmount.Text);
                decimal afterdisc = amnt1;
                txt_PartTaxAmount.Text = (afterdisc * (vat / 100)).ToString("0.00");

                decimal taxamnt = Convert.ToDecimal(txt_PartTaxAmount.Text);
                txt_PartTotal.Text = (afterdisc + taxamnt).ToString("0.00");
            }
        }
        catch (Exception ex)
        { }
        
    }
    protected void txt_PartDiscountper_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlsparetype.SelectedItem.Text == "WARRANTY")
            {
                txt_PartDiscount.Text = "0";
                txt_PartTaxAmount.Text = "0";
                txt_PartTotal.Text = "0";
            }

            else if (ddlsparetype.SelectedItem.Text == "FOC")
            {

                txt_PartDiscount.Text = "0";
                txt_PartTaxAmount.Text = "0";
                txt_PartTotal.Text = "0";

            }
            else
            {
                decimal vat = Convert.ToDecimal(txt_PartVat.Text);
                decimal amnt = Convert.ToDecimal(txt_PartAmount.Text);
                decimal disc = Convert.ToDecimal(txt_PartDiscountper.Text);
                decimal per = disc / 100;
                txt_PartDiscount.Text = (amnt * per).ToString("0.00");

                decimal descamnt = Convert.ToDecimal(txt_PartDiscount.Text);

                decimal amnt1 = Convert.ToDecimal(txt_PartAmount.Text);
                decimal afterdisc = amnt1 - descamnt;
                txt_PartTaxAmount.Text = (afterdisc * (vat / 100)).ToString("0.00");

                decimal taxamnt = Convert.ToDecimal(txt_PartTaxAmount.Text);
                txt_PartTotal.Text = (afterdisc + taxamnt).ToString("0.00");


            }
        }
        catch (Exception ex)
        { }
        
    }
    protected void ddlsparetype_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlsparetype.SelectedItem.Text == "WARRANTY")
            {
                txt_PartAmount.Text = "0";
                txt_PartDiscount.Text = "0";
                txt_PartDiscountper.Text = "0";
                txt_PartTaxAmount.Text = "0";
                txt_PartTotal.Text = "0";
            }
            else if (ddlsparetype.SelectedItem.Text == "FOC")
            {

                txt_PartAmount.Text = "0";
                txt_PartDiscount.Text = "0";
                txt_PartDiscountper.Text = "0";
                txt_PartTaxAmount.Text = "0";
                txt_PartTotal.Text = "0";

            }
            else
            {
                decimal vat = Convert.ToDecimal(txt_PartVat.Text);

                decimal rate = Convert.ToDecimal(ViewState["rate"]);
                decimal rate1 = Convert.ToDecimal(txt_PartRate.Text);
                decimal temp = Convert.ToDecimal(rate / (100 + vat));
                decimal amnt = temp * 100;

                decimal qty = Convert.ToDecimal(txt_PartQuantity.Text);
                // txt_PartAmount.Text = (amnt * qty).ToString("0.00");
                txt_PartAmount.Text = (rate1 * qty).ToString("0.00");

                txt_PartDiscount.Text = "0";
                txt_PartDiscountper.Text = "0";
                decimal amnt1 = Convert.ToDecimal(txt_PartAmount.Text);
                decimal afterdisc = amnt1;
                txt_PartTaxAmount.Text = (afterdisc * (vat / 100)).ToString("0.00");

                decimal taxamnt = Convert.ToDecimal(txt_PartTaxAmount.Text);
                txt_PartTotal.Text = (afterdisc + taxamnt).ToString("0.00");
            }
        }
        catch (Exception ex)
        { }
        
    }


    protected void txt_jcyear_TextChanged(object sender, EventArgs e)
    {

        GridView3.DataSource = null;
        GridView3.DataBind();

        try
        {
            FillTechnisian();
            int jno = Convert.ToInt32(txt_jcno.Text);
            string branchname = Session["Branch"].ToString();
            var jcno = from c in db.AME_Service_JobCardEntry.Where(t => t.JC_No == jno && t.Branch_Name == branchname && t.Ms_Status == "OPEN" && t.JC_year==txt_jcyear.Text.Trim()) select c;
            var spareissue = from c in db.AME_Service_JobcardSpareIssue.Where(t => t.JC_No == jno && t.Branch_Name == branchname && t.Jc_year==txt_jcyear.Text.Trim()) select c;
            if (Convert.ToInt32(jcno.Count()) > 0)
            {
                if (jcno.First().Ms_Status == "CLOSE")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('CaN Not Return Sale Because Of Job Card Is Closed..!!!');</script>", false);
                    txt_jcno.Focus();
                    txt_jcno.Text = "";
                   
                }
                if (Convert.ToInt32(spareissue.Count()) > 0)
                {
                    string statecode = jcno.First().Statecode;
                    ViewState["statecode"] = statecode;
                    fillsparedetails1();
                    fillspareissuedetails(jno);
                }
                else
                {
                    string statecode = jcno.First().Statecode;
                    ViewState["statecode"] = statecode;
                    fillsparedetails1();
                }
            }

            else
            {

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Invalid Si Jobcardno..!!!');</script>", false);
                txt_jcno.Focus();
                txt_jcno.Text = "";
                return;
            }

        }
        catch(Exception ex)
        {

        }

    }
}