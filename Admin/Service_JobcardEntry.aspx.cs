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
   
    static List<ServiceDetails> SD = new List<ServiceDetails>();
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
                    SD.RemoveAll(t => t.key == ViewState["ran_Key"].ToString());
                }


                string ran_Key = CreateRandomPassword1(5);

                ViewState["ran_Key"] = ran_Key;
                var mx = SD.ToList();
                int slmax = 0;

                if (DebasishGlobal.s2 > 0)
                {

                    slmax = DebasishGlobal.s2 + 1;
                    DebasishGlobal.s2 = slmax;
                }

                else
                {
                    slmax = 1;
                    DebasishGlobal.s2 = 1;
                }
                ViewState["maxs"] = Convert.ToString(slmax);
                //var mx = SD.ToList();
                //int slmax = 0;
                //if (mx.Count > 0)
                //    slmax = (mx.Max(t => t.maxslno) + 1);
                //else
                //    slmax = 1;
                //ViewState["maxs"] = Convert.ToString(slmax);
                // filljobcard();
                // fillDetails();
              //  SD.RemoveAll(t => t.UserId == Session["Uid"].ToString());
              //  FillServiceGrid();
                txt_date.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
                txt_saledate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
                txt_deliverydate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
                //txt_time.Text = DateTime.Now.ToString("hh:mm:ss tt");

                // txt_jcyear.Text = "2017-18";
            }

            catch (Exception ex)
            { }

        }
    }








    //---ajax start

    public class RotPartNumberWise
    {
        public string Itm_code { get; set; }

        public string Itm_PartDescrption { get; set; }


        public decimal Mh_ServiceRate { get; set; }

    }


    [System.Web.Services.WebMethod]

    public static List<RotPartNumberWise> GetAllitems(string partno)
    {
        List<RotPartNumberWise> getlist = new List<RotPartNumberWise>();
        AutoMobileEntities db = new AutoMobileEntities();
        string branchname = HttpContext.Current.Session["Branch"].ToString();
        var part = db.AME_Master_ServiceHead.Where(t => t.Branch_Name == branchname && t.Mh_ServiceCode == partno).FirstOrDefault();



        RotPartNumberWise obj = new RotPartNumberWise();
        obj.Itm_code = part.Mh_ServiceCode;
        obj.Itm_PartDescrption = part.Mh_ServiceHead;
        obj.Mh_ServiceRate = Convert.ToDecimal(part.Mh_ServiceRate);
        getlist.Add(obj);

        return getlist;
    }


    [System.Web.Services.WebMethod]

    public static List<RotPartNumberWise> GetAllitemsbyDesc(string partdesc)
    {
        List<RotPartNumberWise> getlist = new List<RotPartNumberWise>();
        AutoMobileEntities db = new AutoMobileEntities();
        string branchname = HttpContext.Current.Session["Branch"].ToString();
        var part = db.AME_Master_ServiceHead.Where(t => t.Branch_Name == branchname && t.Mh_ServiceHead == partdesc).FirstOrDefault();



        RotPartNumberWise obj = new RotPartNumberWise();
        obj.Itm_code = part.Mh_ServiceCode;
        obj.Itm_PartDescrption = part.Mh_ServiceHead;
        obj.Mh_ServiceRate = Convert.ToDecimal(part.Mh_ServiceRate);
        getlist.Add(obj);

        return getlist;
    }





    //--ajax end






















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
    public static string[] Getfinacial(string prefixText, int count)
    {
      
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_FinacialYear.Where(n => n.finacialyear.Contains(prefixText)).OrderBy(n => n.finacialyear).Select(n => n.finacialyear).Distinct().Take(count).ToArray();
    }

    protected void filljobcard()
    {
        try
        {
            string branch = HttpContext.Current.Session["Branch"].ToString();
            string year = txt_jcyear.SelectedValue.ToString();
            var job = from c in db.AME_Service_JobCardEntry.Where(t => t.Branch_Name == branch && t.JC_year == year) select c;
            if (job.Count() > 0)
            {
                fillDetails();
            }
            else
            {

                fillDetails1();
            }
        }
        catch (Exception ex)
        { }




    }

    protected void filljobcard12()
    {
        try
        {
            string branch = HttpContext.Current.Session["Branch"].ToString();
            string year = txt_jcyear.SelectedValue.ToString();

            var job = from c in db.AME_Service_JobCardEntry.Where(t => t.Branch_Name == branch && t.JC_year == year) select c;
            if (job.Count() > 0)
            {
                fillDetails();
            }
            else
            {

                fillDetails1();
            }
        }
        catch (Exception ex)
        { }




    }

    protected void filljobcard11()
    {
        try
        {
            string branch = HttpContext.Current.Session["Branch"].ToString();
            string year = txt_jcyear.SelectedValue.ToString();

            var job = from c in db.AME_Service_JobCardEntry.Where(t => t.Branch_Name == branch && t.JC_year == year) select c;
            if (job.Count() > 0)
            {
                filldetailsumit();
            }
            else
            {

                filldetailsumit1();
            }
        }
        catch (Exception ex)
        { }




    }
    [System.Web.Services.WebMethod]
    public static string[] GetServiceCode(string prefixText, int count)
    {
        string Sale = Convert.ToString(HttpContext.Current.Session["saletype"]);
        string branch = HttpContext.Current.Session["Branch"].ToString();
        if (HttpContext.Current.Session["saletype"] != null)
        {
            
            AutoMobileEntities db = new AutoMobileEntities();
            return db.AME_Master_ServiceHead.Where(n => n.Mh_ServiceCode.Contains(prefixText) && n.Branch_Name == branch && n.Mh_SaleStatus == Sale).OrderBy(n => n.Mh_ServiceCode).Select(n => n.Mh_ServiceCode).Distinct().Take(count).ToArray();
        }
        else
        {
           
            AutoMobileEntities db = new AutoMobileEntities();
            return db.AME_Master_ServiceHead.Where(n => n.Mh_ServiceCode.Contains(prefixText) && n.Branch_Name == branch).OrderBy(n => n.Mh_ServiceCode).Select(n => n.Mh_ServiceCode).Distinct().Take(count).ToArray();
        }
        
    }
    [System.Web.Services.WebMethod]
    public static string[] GetServiceDesc(string prefixText, int count)
    {
        string Sale = Convert.ToString(HttpContext.Current.Session["saletype"]);
        string branch = HttpContext.Current.Session["Branch"].ToString();
        if (HttpContext.Current.Session["saletype"] != null)
        {

            AutoMobileEntities db = new AutoMobileEntities();
            return db.AME_Master_ServiceHead.Where(n => n.Mh_ServiceHead.Contains(prefixText) && n.Branch_Name == branch && n.Mh_SaleStatus == Sale).OrderBy(n => n.Mh_ServiceHead).Select(n => n.Mh_ServiceHead).Distinct().Take(count).ToArray();
        }
        else
        {

            AutoMobileEntities db = new AutoMobileEntities();
            return db.AME_Master_ServiceHead.Where(n => n.Mh_ServiceHead.Contains(prefixText) && n.Branch_Name == branch).OrderBy(n => n.Mh_ServiceHead).Select(n => n.Mh_ServiceHead).Distinct().Take(count).ToArray();
        }

    }
        
    [System.Web.Services.WebMethod]
    public static string[] Getengineno(string prefixText, int count)
    {
        string br = Convert.ToString(HttpContext.Current.Session["Branch"]);
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Service_JobCardEntry.Where(n => n.JC_Engineno.Contains(prefixText) && n.Branch_Name == br).OrderBy(n => n.JC_Engineno).Select(n => n.JC_Engineno).Distinct().Take(count).ToArray();
    }

    [System.Web.Services.WebMethod]
    public static string[] Getchasisno(string prefixText, int count)
    {
        string br = Convert.ToString(HttpContext.Current.Session["Branch"]);
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Service_JobCardEntry.Where(n => n.JC_Chassisno.Contains(prefixText) && n.Branch_Name == br).OrderBy(n => n.JC_Chassisno).Select(n => n.JC_Chassisno).Distinct().Take(count).ToArray();
    }
    [System.Web.Services.WebMethod]
    public static string[] Getregisno(string prefixText, int count)
    {
        string br = Convert.ToString(HttpContext.Current.Session["Branch"]);
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Service_JobCardEntry.Where(n => n.JC_Regno.Contains(prefixText) && n.Branch_Name == br).OrderBy(n => n.JC_Regno).Select(n => n.JC_Regno).Distinct().Take(count).ToArray();
    }

    private void filldetailsumit()
    {
        try
        {
            string Branch = Session["Branch"].ToString();
            // string year = txt_jcyear.Text.Trim();

            string year = txt_jcyear.SelectedValue.ToString();

            string Sale = Convert.ToString(Session["saletype"]);
            if (Session["saletype"] != null)
            {
                string param = "@action,@Sale,@Branch,@year";

                string paramvalue = "a" + "," + Sale + "," + Branch + "," + year;

                DataSet ds = smitaDbAccess.SPReturnDataSet("sp_fillJobcardEntry_Details", param, paramvalue);

                //ddl_supervisor.DataSource = ds.Tables[0];
                //ddl_supervisor.DataTextField = "Ms_Name";
                //ddl_supervisor.DataValueField = "Ms_Id";
                //ddl_supervisor.DataBind();
                //ddl_supervisor.Items.Insert(0, "--Select One--");

                //ddl_technisian.DataSource = ds.Tables[1];
                //ddl_technisian.DataTextField = "Mt_Name";
                //ddl_technisian.DataValueField = "Mt_Id";
                //ddl_technisian.DataBind();
                //ddl_technisian.Items.Insert(0, "--Select One--");

                //ddl_customer.DataSource = ds.Tables[2];
                //ddl_customer.DataTextField = "Mc_Name";
                //ddl_customer.DataValueField = "Mc_Id";
                //ddl_customer.DataBind();
                //ddl_customer.Items.Insert(0, "--Select One--");

                //ddl_Model.DataSource = ds.Tables[3];
                //ddl_Model.DataTextField = "Mv_ModelName";
                //ddl_Model.DataValueField = "Mv_Id";
                //ddl_Model.DataBind();
                //ddl_Model.Items.Insert(0, "--Select One--");

                if (Convert.ToInt32(ds.Tables[4].Rows[0].ItemArray[0].ToString()) > 0)
                {
                    int VNo = Convert.ToInt32(ds.Tables[4].Rows[0].ItemArray[0].ToString());
                    txt_jcno.Text = Convert.ToString(VNo + 1);
                }
                else
                {
                    txt_jcno.Text = "1";
                }
            }
            else
            {
                string param = "@action,@Sale,@Branch,@year";

                string paramvalue = "ab" + "," + Sale + "," + Branch + "," + year;

                DataSet ds = smitaDbAccess.SPReturnDataSet("sp_fillJobcardEntry_Details", param, paramvalue);

                //ddl_supervisor.DataSource = ds.Tables[0];
                //ddl_supervisor.DataTextField = "Ms_Name";
                //ddl_supervisor.DataValueField = "Ms_Id";
                //ddl_supervisor.DataBind();
                //ddl_supervisor.Items.Insert(0, "--Select One--");

                //ddl_technisian.DataSource = ds.Tables[1];
                //ddl_technisian.DataTextField = "Mt_Name";
                //ddl_technisian.DataValueField = "Mt_Id";
                //ddl_technisian.DataBind();
                //ddl_technisian.Items.Insert(0, "--Select One--");

                //ddl_customer.DataSource = ds.Tables[2];
                //ddl_customer.DataTextField = "Mc_Name";
                //ddl_customer.DataValueField = "Mc_Id";
                //ddl_customer.DataBind();
                //ddl_customer.Items.Insert(0, "--Select One--");

                //ddl_Model.DataSource = ds.Tables[3];
                //ddl_Model.DataTextField = "Mv_ModelName";
                //ddl_Model.DataValueField = "Mv_Id";
                //ddl_Model.DataBind();
                //ddl_Model.Items.Insert(0, "--Select One--");

                if (Convert.ToInt32(ds.Tables[4].Rows[0].ItemArray[0].ToString()) > 0)
                {
                    int VNo = Convert.ToInt32(ds.Tables[4].Rows[0].ItemArray[0].ToString());
                    txt_jcno.Text = Convert.ToString(VNo + 1);
                }
                else
                {
                    txt_jcno.Text = "1";
                }
            }
        }
        catch (Exception ex)
        { }

    }

    private void filldetailsumit1()
    {

        try
        {
            string Branch = Session["Branch"].ToString();
            // string year = txt_jcyear.Text.Trim();
            string year = txt_jcyear.SelectedValue.ToString();

            string Sale = Convert.ToString(Session["saletype"]);
            if (Session["saletype"] != null)
            {
                string param = "@action,@Sale,@Branch,@year";

                string paramvalue = "a" + "," + Sale + "," + Branch + "," + year;

                DataSet ds = smitaDbAccess.SPReturnDataSet("sp_fillJobcardEntry_Details", param, paramvalue);
                txt_jcno.Text = "1";

                //if (Convert.ToInt32(ds.Tables[4].Rows[0].ItemArray[0].ToString()) > 0)
                //{
                //    int VNo = Convert.ToInt32(ds.Tables[4].Rows[0].ItemArray[0].ToString());
                //    txt_jcno.Text = Convert.ToString(VNo + 1);
                //}
                //else
                //{
                //    txt_jcno.Text = "1";
                //}


                //ddl_supervisor.DataSource = ds.Tables[0];
                //ddl_supervisor.DataTextField = "Ms_Name";
                //ddl_supervisor.DataValueField = "Ms_Id";
                //ddl_supervisor.DataBind();
                //ddl_supervisor.Items.Insert(0, "--Select One--");

                //ddl_technisian.DataSource = ds.Tables[1];
                //ddl_technisian.DataTextField = "Mt_Name";
                //ddl_technisian.DataValueField = "Mt_Id";
                //ddl_technisian.DataBind();
                //ddl_technisian.Items.Insert(0, "--Select One--");

                //ddl_customer.DataSource = ds.Tables[2];
                //ddl_customer.DataTextField = "Mc_Name";
                //ddl_customer.DataValueField = "Mc_Id";
                //ddl_customer.DataBind();
                //ddl_customer.Items.Insert(0, "--Select One--");

                //ddl_Model.DataSource = ds.Tables[3];
                //ddl_Model.DataTextField = "Mv_ModelName";
                //ddl_Model.DataValueField = "Mv_Id";
                //ddl_Model.DataBind();
                //ddl_Model.Items.Insert(0, "--Select One--");

                //if (Convert.ToInt32(ds.Tables[4].Rows[0].ItemArray[0].ToString()) > 0)
                //{
                //    int VNo = Convert.ToInt32(ds.Tables[4].Rows[0].ItemArray[0].ToString());
                //    txt_jcno.Text = Convert.ToString(VNo + 1);
                //}
                //else
                //{
                //    txt_jcno.Text = "1";
                //}
            }
            else
            {
                string param = "@action,@Sale,@Branch,@year";

                string paramvalue = "ab" + "," + Sale + "," + Branch + " ," + year;

                DataSet ds = smitaDbAccess.SPReturnDataSet("sp_fillJobcardEntry_Details", param, paramvalue);
                txt_jcno.Text = "1";


                //if (Convert.ToInt32(ds.Tables[4].Rows[0].ItemArray[0].ToString()) > 0)
                //{
                //    int VNo = Convert.ToInt32(ds.Tables[4].Rows[0].ItemArray[0].ToString());
                //    txt_jcno.Text = Convert.ToString(VNo + 1);
                //}
                //else
                //{
                //    txt_jcno.Text = "1";
                //}

                //ddl_supervisor.DataSource = ds.Tables[0];
                //ddl_supervisor.DataTextField = "Ms_Name";
                //ddl_supervisor.DataValueField = "Ms_Id";
                //ddl_supervisor.DataBind();
                //ddl_supervisor.Items.Insert(0, "--Select One--");

                //ddl_technisian.DataSource = ds.Tables[1];
                //ddl_technisian.DataTextField = "Mt_Name";
                //ddl_technisian.DataValueField = "Mt_Id";
                //ddl_technisian.DataBind();
                //ddl_technisian.Items.Insert(0, "--Select One--");

                //ddl_customer.DataSource = ds.Tables[2];
                //ddl_customer.DataTextField = "Mc_Name";
                //ddl_customer.DataValueField = "Mc_Id";
                //ddl_customer.DataBind();
                //ddl_customer.Items.Insert(0, "--Select One--");

                //ddl_Model.DataSource = ds.Tables[3];
                //ddl_Model.DataTextField = "Mv_ModelName";
                //ddl_Model.DataValueField = "Mv_Id";
                //ddl_Model.DataBind();
                //ddl_Model.Items.Insert(0, "--Select One--");

                //if (Convert.ToInt32(ds.Tables[4].Rows[0].ItemArray[0].ToString()) > 0)
                //{
                //    int VNo = Convert.ToInt32(ds.Tables[4].Rows[0].ItemArray[0].ToString());
                //    txt_jcno.Text = Convert.ToString(VNo + 1);
                //}
                //else
                //{
                //    txt_jcno.Text = "1";
                //}
            }
        }
        catch (Exception ex)
        { }

    }

    private void fillDetails()
    {
        try
        {
            //string year = txt_jcyear.Text.Trim();
            string year = txt_jcyear.SelectedValue.ToString();

            string Branch = Session["Branch"].ToString();
            string Sale = Convert.ToString(Session["saletype"]);
            if (Session["saletype"] != null)
            {
                string param = "@action,@Sale,@Branch,@year";

                string paramvalue = "a" + "," + Sale + "," + Branch + "," + year;

                DataSet ds = smitaDbAccess.SPReturnDataSet("sp_fillJobcardEntry_Details", param, paramvalue);

                ddl_supervisor.DataSource = ds.Tables[0];
                ddl_supervisor.DataTextField = "Ms_Name";
                ddl_supervisor.DataValueField = "Ms_Id";
                ddl_supervisor.DataBind();
                ddl_supervisor.Items.Insert(0, "--Select One--");

                ddl_technisian.DataSource = ds.Tables[1];
                ddl_technisian.DataTextField = "Mt_Name";
                ddl_technisian.DataValueField = "Mt_Id";
                ddl_technisian.DataBind();
                ddl_technisian.Items.Insert(0, "--Select One--");

                ddl_customer.DataSource = ds.Tables[2];
                ddl_customer.DataTextField = "Mc_Name";
                ddl_customer.DataValueField = "Mc_Id";
                ddl_customer.DataBind();
                ddl_customer.Items.Insert(0, "--Select One--");

                ddl_Model.DataSource = ds.Tables[3];
                ddl_Model.DataTextField = "Mv_ModelName";
                ddl_Model.DataValueField = "Mv_Id";
                ddl_Model.DataBind();
                ddl_Model.Items.Insert(0, "--Select One--");

                if (Convert.ToInt32(ds.Tables[4].Rows[0].ItemArray[0].ToString()) > 0)
                {
                    int VNo = Convert.ToInt32(ds.Tables[4].Rows[0].ItemArray[0].ToString());
                    txt_jcno.Text = Convert.ToString(VNo + 1);
                }
                else
                {
                    txt_jcno.Text = "1";
                }
            }
            else
            {
                string param = "@action,@Sale,@Branch,@year";

                string paramvalue = "ab" + "," + Sale + "," + Branch + "," + year;

                DataSet ds = smitaDbAccess.SPReturnDataSet("sp_fillJobcardEntry_Details", param, paramvalue);

                ddl_supervisor.DataSource = ds.Tables[0];
                ddl_supervisor.DataTextField = "Ms_Name";
                ddl_supervisor.DataValueField = "Ms_Id";
                ddl_supervisor.DataBind();
                ddl_supervisor.Items.Insert(0, "--Select One--");

                ddl_technisian.DataSource = ds.Tables[1];
                ddl_technisian.DataTextField = "Mt_Name";
                ddl_technisian.DataValueField = "Mt_Id";
                ddl_technisian.DataBind();
                ddl_technisian.Items.Insert(0, "--Select One--");

                ddl_customer.DataSource = ds.Tables[2];
                ddl_customer.DataTextField = "Mc_Name";
                ddl_customer.DataValueField = "Mc_Id";
                ddl_customer.DataBind();
                ddl_customer.Items.Insert(0, "--Select One--");

                ddl_Model.DataSource = ds.Tables[3];
                ddl_Model.DataTextField = "Mv_ModelName";
                ddl_Model.DataValueField = "Mv_Id";
                ddl_Model.DataBind();
                ddl_Model.Items.Insert(0, "--Select One--");

                if (Convert.ToInt32(ds.Tables[4].Rows[0].ItemArray[0].ToString()) > 0)
                {
                    int VNo = Convert.ToInt32(ds.Tables[4].Rows[0].ItemArray[0].ToString());
                    txt_jcno.Text = Convert.ToString(VNo + 1);
                }
                else
                {
                    txt_jcno.Text = "1";
                }
            }
        }
        catch (Exception ex)
        { }

       
       

      
    }
    private void fillDetails1()
    {
        try
        {
            // string year = txt_jcyear.Text.Trim();
            string year = txt_jcyear.SelectedValue.ToString();

            string Branch = Session["Branch"].ToString();
            string Sale = Convert.ToString(Session["saletype"]);
            if (Session["saletype"] != null)
            {
                string param = "@action,@Sale,@Branch,@year";

                string paramvalue = "a" + "," + Sale + "," + Branch + "," + year;

                DataSet ds = smitaDbAccess.SPReturnDataSet("sp_fillJobcardEntry_Details", param, paramvalue);

                ddl_supervisor.DataSource = ds.Tables[0];
                ddl_supervisor.DataTextField = "Ms_Name";
                ddl_supervisor.DataValueField = "Ms_Id";
                ddl_supervisor.DataBind();
                ddl_supervisor.Items.Insert(0, "--Select One--");

                ddl_technisian.DataSource = ds.Tables[1];
                ddl_technisian.DataTextField = "Mt_Name";
                ddl_technisian.DataValueField = "Mt_Id";
                ddl_technisian.DataBind();
                ddl_technisian.Items.Insert(0, "--Select One--");

                ddl_customer.DataSource = ds.Tables[2];
                ddl_customer.DataTextField = "Mc_Name";
                ddl_customer.DataValueField = "Mc_Id";
                ddl_customer.DataBind();
                ddl_customer.Items.Insert(0, "--Select One--");

                ddl_Model.DataSource = ds.Tables[3];
                ddl_Model.DataTextField = "Mv_ModelName";
                ddl_Model.DataValueField = "Mv_Id";
                ddl_Model.DataBind();
                ddl_Model.Items.Insert(0, "--Select One--");


                txt_jcno.Text = "1";


            }
            else
            {
                string param = "@action,@Sale,@Branch,@year";

                string paramvalue = "ab" + "," + Sale + "," + Branch + "," + year;

                DataSet ds = smitaDbAccess.SPReturnDataSet("sp_fillJobcardEntry_Details", param, paramvalue);

                ddl_supervisor.DataSource = ds.Tables[0];
                ddl_supervisor.DataTextField = "Ms_Name";
                ddl_supervisor.DataValueField = "Ms_Id";
                ddl_supervisor.DataBind();
                ddl_supervisor.Items.Insert(0, "--Select One--");

                ddl_technisian.DataSource = ds.Tables[1];
                ddl_technisian.DataTextField = "Mt_Name";
                ddl_technisian.DataValueField = "Mt_Id";
                ddl_technisian.DataBind();
                ddl_technisian.Items.Insert(0, "--Select One--");

                ddl_customer.DataSource = ds.Tables[2];
                ddl_customer.DataTextField = "Mc_Name";
                ddl_customer.DataValueField = "Mc_Id";
                ddl_customer.DataBind();
                ddl_customer.Items.Insert(0, "--Select One--");

                ddl_Model.DataSource = ds.Tables[3];
                ddl_Model.DataTextField = "Mv_ModelName";
                ddl_Model.DataValueField = "Mv_Id";
                ddl_Model.DataBind();
                ddl_Model.Items.Insert(0, "--Select One--");

                txt_jcno.Text = "1";


            }
        }
        catch (Exception ex)
        { }

    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        cl.Clear_All(this);
    }

    protected void txt_SCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
           // string branch = Session["Branch"].ToString();
            //var v = from k in db.AME_Master_ServiceHead.ToList()
            //        where (k.Mh_ServiceCode.Equals(txt_SCode.Text) && k.Branch_Name==branch)
            //        select new
            //        {
            //            k.Mh_ServiceHead,
            //            k.Mh_ServiceCode,
            //            k.Mh_ServiceRate
            //        };
            //txt_SCode.Text = v.First().Mh_ServiceCode;
            //txt_SDescription.Text = Convert.ToString(v.First().Mh_ServiceHead);
            //txt_SRate.Text = Convert.ToString(v.First().Mh_ServiceRate);
            //txt_SQuantity.Focus();
            string branch = Session["Branch"].ToString();

            string param1 = "@partname,@branch";
            string paramobj1 = txt_SCode.Text + "," + Session["Branch"].ToString();

            DataTable ds1 = smitaDbAccess.SPReturnDataTable("sp_returndatatable", param1, paramobj1);

           // DataTable ds1 = smitaDbAccess.returndatatable("select Mh_ServiceHead AS Mh_ServiceHead , Mh_ServiceCode AS Mh_ServiceCode , Mh_ServiceRate AS Mh_ServiceRate FROM AME_Master_ServiceHead WHERE Mh_ServiceCode='" + txt_SCode.Text + "' AND Branch_Name='" + Session["Branch"].ToString() + "'  ");
            txt_SCode.Text = ds1.Rows[0].ItemArray[1].ToString();
            txt_SDescription.Text = ds1.Rows[0].ItemArray[0].ToString();
            txt_SRate.Text = ds1.Rows[0].ItemArray[2].ToString();
            txt_SQuantity.Focus();
          
        }
        catch(Exception ex)
        {
            txt_SCode.Text = "";
            txt_SDescription.Text = "";
            txt_SRate.Text = "";
            txt_SQuantity.Focus();
        }
    }
    protected void btn_ServiceAdd_Click(object sender, EventArgs e)
    {
        string msg = " Value ";
        try
        {
            Mandatoryfield();
      
        ////////////////////////////////

        //if (txt_SCode.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Service Code Should Not Be Blank..!!'); </script>", false);
        //    txt_SCode.Focus();
        //    return;
        //}
        //if (txt_SDescription.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Description Should Not Be Blank..!!'); </script>", false);
        //    txt_SDescription.Focus();
        //    return;
        //}

        //if (txt_SQuantity.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Quantity Should Not Be Blank..!!'); </script>", false);
        //    txt_SQuantity.Focus();
        //    return;
        //}

        //if (txt_SRate.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Rate Should Not Be Blank..!!'); </script>", false);
        //    txt_SRate.Focus();
        //    return;
        //}
        //if (txt_SAmount.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Amount Should Not Be Blank..!!'); </script>", false);
        //    txt_SAmount.Focus();
        //    return;
        //}
            string brnch=Session["Branch"].ToString();
            int mx=Convert.ToInt32(ViewState["maxs"].ToString());
            var chk = from c in SD.Where(t => t.Mh_ServiceCode == txt_SCode.Text.Trim() && t.Branch == brnch && t.maxslno==mx ) select c;
            if (Convert.ToInt32(chk.Count()) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('This Service Code Already. Exist Please Try Different..!!'); </script>", false);
                txt_SCode.Focus();
                return;
            }
           
        ServiceDetails pr1 = new ServiceDetails();
        pr1.Mh_ServiceCode = txt_SCode.Text;
        pr1.Mh_ServiceHead = txt_SDescription.Text;
        pr1.Mh_ServiceType = drp_labtype.SelectedItem.Text;
        pr1.Se_Quantity = Convert.ToDecimal(txt_SQuantity.Text);
        msg = " Rate ";
        pr1.Se_Rate = Convert.ToDecimal(txt_SRate.Text);
        msg = " Amount ";
        pr1.Se_Amount = Convert.ToDecimal(txt_SAmount.Text);
           
        pr1.UserId = Session["Uid"].ToString();
        pr1.Branch = brnch;
        pr1.maxslno = Convert.ToInt32(ViewState["maxs"].ToString());
        pr1.key = ViewState["ran_Key"].ToString();
        SD.Add(pr1);

        FillServiceGrid();

        txt_SCode.Text = "";
        txt_SDescription.Text = "";
        txt_SQuantity.Text = "";
        txt_SRate.Text = "";
        txt_SAmount.Text = "";
        drp_labtype.SelectedIndex = 0;
        txt_SCode.Focus();
        }
        catch(Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Enter valid " + msg + " ..!!'); </script>", false);
        }
    }
    decimal tots1 = 0;
    private void FillServiceGrid()
    {
        try
        {
            string Sale = Convert.ToString(Session["saletype"]);
            uname = Session["Uid"].ToString();
            int mx = Convert.ToInt32(ViewState["maxs"].ToString());
            string Branch = Session["Branch"].ToString();
            string key11 = ViewState["ran_Key"].ToString();
            var prd = (from c in SD.ToList()
                      // where c.UserId == uname && c.Branch == Branch && c.maxslno == mx
                       where c.key == key11
                       select c).ToList();
            GridView1.DataSource = prd.ToList();
            GridView1.DataBind();

            foreach (GridViewRow gr in GridView1.Rows)
            {
                Label lbl_Amount = (Label)gr.FindControl("Labels6");
                decimal TotAmt = Convert.ToDecimal(lbl_Amount.Text);

                Label lblgrandtotal = (Label)GridView1.FooterRow.FindControl("lblgrandtotal");


                tots1 = tots1 + TotAmt;
                lblgrandtotal.Text = Convert.ToString(SmitaClass.SignificantTruncate(tots1, 2));
                Label1.Text = Convert.ToString(SmitaClass.SignificantTruncate(tots1, 2));
            }
        }
        catch (Exception ex)
        { }
    
    }

    protected void imgbtn_SDelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton imgbtn_SDelete = (ImageButton)sender;
            string branch = Session["Branch"].ToString();
            int mxa = Convert.ToInt32(ViewState["maxs"].ToString());
            SD.RemoveAll(t => t.Mh_ServiceCode == imgbtn_SDelete.ToolTip && t.Branch == branch && t.maxslno == mxa);
           // SD.RemoveAll(t => t.Mh_ServiceCode == imgbtn_SDelete.ToolTip && t.Branch == branch);
            FillServiceGrid();
        }
        catch (Exception ex)
        { }
    }
  
    public class ServiceDetails
    {
        public string Mh_ServiceCode { get; set; }

        public string Mh_ServiceHead { get; set; }

        public string Mh_ServiceType { get; set; }


        public decimal Se_Quantity { get; set; }

        public decimal Se_Rate { get; set; }

        public decimal Se_Amount { get; set; }

        public string UserId { get; set; }

        public string Branch { get; set; }

        public int maxslno { get; set; }

        public string key { get; set; }
       

    }
    protected void ddl_customer_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_customer.SelectedIndex != 0)
        {
            int cid = Convert.ToInt32(ddl_customer.SelectedValue);
            var v = from c in db.AME_Master_Customer.Where(t => t.Mc_Id == cid) select c;
            txt_address.Text = v.First().Mc_Address + "," + v.First().Mc_Pinno;
            txt_phoneno.Text = v.First().Mc_Mobileno;
        }
        
    }
    public void Mandatoryfield()
    {
        //if (txt_jcno.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Voucher Number Should Not Be Blank..!!'); </script>", false);
        //    txt_jcno.Focus();
        //    return;
        //}
        //if (txt_date.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Date Should Not Be Blank ..!!'); </script>", false);
        //    txt_date.Focus();
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
        //if (ddl_Model.SelectedIndex == 0)
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Model Name ..!!'); </script>", false);
        //    ddl_Model.Focus();
        //    return;
        //}
        //if (txt_kcovered.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Km. Covered  Should Not Be Blank ..!!'); </script>", false);
        //    txt_kcovered.Focus();
        //    return;
        //}
        //if (ddl_servicetype.SelectedIndex == 0)
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Service Type ..!!'); </script>", false);
        //    ddl_servicetype.Focus();
        //    return;
        //}
        //if (ddl_supervisor.SelectedIndex == 0)
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Superviser Name ..!!'); </script>", false);
        //    ddl_supervisor.Focus();
        //    return;
        //}
        //if (ddl_technisian.SelectedIndex == 0)
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Technisian Name ..!!'); </script>", false);
        //    ddl_technisian.Focus();
        //    return;
        //}
        ////if (txt_time.Text == "")
        ////{
        ////    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Time  Should Not Be Blank..!!'); </script>", false);
        ////    txt_time.Focus();
        ////    return;
        ////}
        //if (ddl_technisian.SelectedIndex == 0)
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Technisian Name ..!!'); </script>", false);
        //    ddl_technisian.Focus();
        //    return;
        //}
        //if (ddl_customer.SelectedIndex == 0)
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Select Customer Name ..!!'); </script>", false);
        //    ddl_customer.Focus();
        //    return;
        //}
        //if (txt_address.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Address Shoul Not Be Blank ..!!'); </script>", false);
        //    txt_address.Focus();
        //    return;
        //}
        //if (txt_phoneno.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Phone No Shoul Not Be Blank ..!!'); </script>", false);
        //    txt_phoneno.Focus();
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
        if (!DateTime.TryParseExact(txt_deliverydate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
            txt_deliverydate.Focus();
            return;
        }
    } 
    decimal gtotal = 0;
    protected void btn_Submit_Click(object sender, EventArgs e)
    {

        string year = txt_jcyear.SelectedValue.ToString();

        try
        {

            Mandatoryfield();
            int jcno=Convert.ToInt32(txt_jcno.Text.Trim());
            string branch=Session["Branch"].ToString();
            //var chk = from c in db.AME_Service_JobCardEntry.Where(t => t.JC_No == jcno && t.Branch_Name == branch && t.JC_year== year) select c;
            //if (Convert.ToInt32(chk.Count()) > 0)
            //{
               // fillDetails();
              
         //  filldetailsumit();
            filljobcard11();
               // ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('New JC NO " + txt_jcno.Text  + "');", true);

               // return;
           // }

            if(GridView1.Rows.Count<=0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Please Add Service Details..!!');", true);
               
                return;
            }
            var chk = from c in db.AME_Service_JobCardEntry.Where(t => t.JC_No == jcno && t.Branch_Name == branch && t.JC_year == year) select c;

            if (Convert.ToInt32(chk.Count()) > 0)
            {

                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Please Reentry Again!!!!!!!!!!!');", true);

                return;
            }
            foreach (GridViewRow gr in GridView1.Rows)
            {
                Label Labels2 = (Label)gr.FindControl("Labels2");
                string scode = Labels2.Text;

                Label Labels3 = (Label)gr.FindControl("Labels3");
                string shead = Labels3.Text;

                Label labelltype = (Label)gr.FindControl("labelltype");
                string ltype = labelltype.Text;

                Label Labels4 = (Label)gr.FindControl("Labels4");
                decimal quantity = Convert.ToDecimal(Labels4.Text);

                Label Labels5 = (Label)gr.FindControl("Labels5");
                decimal rate = Convert.ToDecimal(Labels5.Text);

                 Label Labels6 = (Label)gr.FindControl("Labels6");
                decimal amount = Convert.ToDecimal(Labels6.Text);

                Label lblgrandtotal = (Label)GridView1.FooterRow.FindControl("lblgrandtotal");
                gtotal =gtotal+ Convert.ToDecimal(lblgrandtotal.Text);

                AME_Service_JobCardServiceDetails asj = new AME_Service_JobCardServiceDetails();
                asj.Branch_Name = branch;
                asj.Created_By = Session["Uid"].ToString();
                asj.Created_Date = SmitaClass.IndianTime();
                asj.JC_No = Convert.ToInt32(txt_jcno.Text);
                asj.Jc_year = year;
                asj.JCS_Amount = amount;
                asj.JCS_Description = shead;
                asj.JCS_SpareType = ltype;
                asj.JCS_Quantity = quantity;
                asj.JCS_Rate = rate;
                asj.JCS_Disper = 0;
                asj.JCS_DisAmu = 0;
                asj.JCS_Servicecode = scode;
              
                asj.JCS_Status = "OPEN";
                asj.JSC_Labour = 0;
                db.AddToAME_Service_JobCardServiceDetails(asj);
                db.SaveChanges();

            }
           // txt_jcyear.Text = "2017-18";
            AME_Service_JobCardEntry jce = new AME_Service_JobCardEntry();
            jce.Branch_Name = branch;
            jce.Created_By = Session["Uid"].ToString();
            jce.Created_Date = SmitaClass.IndianTime();
            jce.JC_Chassisno = txt_chassisno.Text;
            jce.JC_Date = Convert.ToDateTime(txt_date.Text, SmitaClass.dateformat());
            jce.JC_Deliverydate = Convert.ToDateTime(txt_deliverydate.Text, SmitaClass.dateformat());
            jce.JC_Engineno = txt_engineno.Text;
            jce.JC_Keyno = txt_keyno.Text;
            jce.JC_Kmcovered = txt_kcovered.Text;
            jce.JC_MobileNo = txt_phoneno.Text;
            jce.JC_Modelname = Convert.ToInt32(ddl_Model.SelectedValue);
            jce.JC_No = Convert.ToInt32(txt_jcno.Text);
            jce.JC_year = year;
          //  jce.Statecode = txt_statecode.Text.Trim();
            jce.Statecode = drp_state.SelectedValue;
            jce.placeofsupp = txt_supplay.Text;
            if (drp_state.SelectedValue.Equals("21"))
            {
                jce.scodeflag = false;
            }
            else
            {


                jce.scodeflag = true;
            }
            //if (txt_statecode.Text.Trim().Equals("21"))
            //{
            //    jce.scodeflag = false;
            //}
            //else
            //{


            //    jce.scodeflag = true;
            //}
            jce.gstflag = true;
            jce.JC_Phoneno = txt_phoneno.Text;
            jce.JC_Regno = txt_regdno.Text;
            jce.JC_Residenceno = txt_phoneno.Text;
            if (txt_saledate.Text == "")
            {
                jce.JC_SaleDate = null;
            }
            else
            {

                jce.JC_SaleDate = Convert.ToDateTime(txt_saledate.Text, SmitaClass.dateformat());
            }
            DateTime time = DateTime.Parse(string.Format("{0}:{1}:{2} {3}", TimeSelector1.Hour, TimeSelector1.Minute, TimeSelector1.Second, TimeSelector1.AmPm)).AddHours(5).AddMinutes(32);

            jce.JC_ServiceType = ddl_servicetype.SelectedItem.Text;
            jce.JC_SupervisorName = Convert.ToInt32(ddl_supervisor.SelectedValue);
            jce.JCTechnisianName = Convert.ToInt32(ddl_technisian.SelectedValue);
            jce.JC_Time = time.ToString("hh:mm:ss tt");
            jce.Ms_Status = "OPEN";
            jce.JC_Grandtotal = gtotal;
            jce.JC_Customername = Convert.ToInt32(ddl_customer.SelectedValue);
            jce.JC_Caddress = txt_address.Text;
            jce.CustomerComplain = txt_complain.Text;
            jce.hrmeter = txt_hrmet.Text;
            jce.RepairType = ddl_repair.SelectedItem.Text;
            db.AddToAME_Service_JobCardEntry(jce);
            db.SaveChanges();

            Session["Year"] = txt_jcyear.SelectedItem.Text;
            Session["sino"] = txt_jcno.Text;

            if (Session["Branch"].ToString() == "Cuttack")
            {
               
                SD.RemoveAll(t => t.UserId == Session["Uid"].ToString());
                
                Response.Redirect("Service_Print_Jobcard.aspx", false);        //write redirect
                HttpContext.Current.ApplicationInstance.CompleteRequest(); // end response
               // ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Data Added Sucessfuly)..!!');", true);
               // Response.Redirect("Service_Print_Jobcard.aspx");
            }
            else if (Session["Branch"].ToString() == "Paradeep")
            {
               // ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Data Added Sucessfuly)..!!');", true);
                SD.RemoveAll(t => t.UserId == Session["Uid"].ToString());
                Response.Redirect("Service_Print_Jobcard_Anugul.aspx", false);        //write redirect
                HttpContext.Current.ApplicationInstance.CompleteRequest(); // end response
               // Response.Redirect("Service_Print_Jobcard_Anugul.aspx");
            }
            else if (Session["Branch"].ToString() == "Berhampur")
            {
               // ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Data Added Sucessfuly)..!!');", true);
                SD.RemoveAll(t => t.UserId == Session["Uid"].ToString());
                Response.Redirect("Service_Print_Jobcard_Berhampur.aspx", false);        //write redirect
                HttpContext.Current.ApplicationInstance.CompleteRequest(); // end response
              //  Response.Redirect("Service_Print_Jobcard_Berhampur.aspx");
            }
            else
            {
               // ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Data Added Sucessfuly)..!!');", true);
                SD.RemoveAll(t => t.UserId == Session["Uid"].ToString());
                Response.Redirect("Service_Print_Jobcard_Phulnakhara.aspx", false);        //write redirect
                HttpContext.Current.ApplicationInstance.CompleteRequest(); // end response
              //  Response.Redirect("Service_Print_Jobcard_Phulnakhara.aspx");
            }
            
        }
        catch(Exception ex)
        {
          //  string str = ex.ToString();
        }
    }


    protected void txt_engineno_TextChanged(object sender, EventArgs e)
    {

        try
        {
            string branch = Session["Branch"].ToString();
            var v = from x in db.AME_Vehicle_SaleEntry
                    join y in db.AME_Vehicle_SaleEntryDetails on x.Vs_Billno equals y.Vs_Billno
                    //join z in db.AME_Master_Customer on y.Vq_PartyName equals z.Mc_Id
                    where x.Vp_Engineno == txt_engineno.Text && x.Branch_Name == branch

                    select new
                    {
                        keyno = x.Vp_Keyno,
                        chasisno = x.Vp_Chassisno,
                        custname = y.Vq_PartyName,
                        custadd = y.Vq_Address,
                        phone = y.Vq_Phone,
                        saledt = y.Vs_Billdate,
                        model = x.Mv_ModelName
                    };
            var vv = from x in db.AME_Service_JobCardEntry
                     //join y in db.AME_Vehicle_SaleEntryDetails on x.Vs_Billno equals y.Vs_Billno
                     //join z in db.AME_Master_Customer on y.Vq_PartyName equals z.Mc_Id
                     where x.JC_Engineno == txt_engineno.Text && x.Branch_Name == branch
                     select new
                     {
                         keyno = x.JC_Keyno,
                         chasisno = x.JC_Chassisno,
                         regno = x.JC_Regno,
                         custname = x.JC_Customername,
                         custadd = x.JC_Caddress,
                         phone = x.JC_Phoneno,
                         phone1 = x.JC_Residenceno,
                         phone2 = x.JC_MobileNo,
                         saledt = x.JC_SaleDate,
                         model = x.JC_Modelname
                     };
            if (Convert.ToInt32(v.Count()) > 0)
            {
                txt_keyno.Text = v.First().keyno;
                txt_chassisno.Text = v.First().chasisno;
                txt_saledate.Text = v.First().saledt.ToString("dd/MM/yyyy");
                ddl_customer.SelectedValue = Convert.ToString(v.First().custname);
                txt_address.Text = v.First().custadd;
                txt_phoneno.Text = v.First().phone.ToString();
                ddl_Model.SelectedValue = v.First().model.ToString();
            }
            else if (Convert.ToInt32(vv.Count()) > 0)
            {
                txt_keyno.Text = vv.First().keyno;
                txt_chassisno.Text = vv.First().chasisno;
                txt_saledate.Text = Convert.ToDateTime(vv.First().saledt).ToString("dd/MM/yyyy");
                ddl_customer.SelectedValue = Convert.ToString(vv.First().custname);
                txt_address.Text = vv.First().custadd;
                txt_phoneno.Text = vv.First().phone.ToString();
                //txt_phoneno0.Text = vv.First().phone1.ToString();
                //txt_phoneno1.Text = vv.First().phone2.ToString();
                txt_regdno.Text = vv.First().regno.ToString();
                ddl_Model.SelectedValue = vv.First().model.ToString();

            }
            else
            {

                //ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('This Vehicle Registered First Time)..!!');", true);
                txt_keyno.Text = "";
                ////txt_chassisno.Text = "";
                txt_saledate.Text = "";
                ddl_customer.SelectedIndex = 0;
                txt_address.Text = "";
                txt_phoneno.Text = "";
                //txt_phoneno0.Text = "";
                //txt_phoneno1.Text = "";
            }
        }
        catch (Exception ex)
        { }
    }
    protected void txt_chassisno_TextChanged(object sender, EventArgs e)
    {

        try
        {
            string branch = Session["Branch"].ToString();
            var v = from x in db.AME_Vehicle_SaleEntry
                    join y in db.AME_Vehicle_SaleEntryDetails on x.Vs_Billno equals y.Vs_Billno
                    //join z in db.AME_Master_Customer on y.Vq_PartyName equals z.Mc_Id
                    where x.Vp_Chassisno == txt_chassisno.Text && x.Branch_Name == branch
                    select new
                    {
                        keyno = x.Vp_Keyno,
                        engineeno = x.Vp_Engineno,
                        custname = y.Vq_PartyName,
                        custadd = y.Vq_Address,
                        phone = y.Vq_Phone,
                        saledt = y.Vs_Billdate,
                        model = x.Mv_ModelName
                    };
            var vv = from x in db.AME_Service_JobCardEntry
                     //join y in db.AME_Vehicle_SaleEntryDetails on x.Vs_Billno equals y.Vs_Billno
                     //join z in db.AME_Master_Customer on y.Vq_PartyName equals z.Mc_Id
                     where x.JC_Chassisno == txt_chassisno.Text && x.Branch_Name == branch
                     select new
                     {
                         keyno = x.JC_Keyno,
                         engineeno = x.JC_Engineno,
                         regno = x.JC_Regno,
                         custname = x.JC_Customername,
                         custadd = x.JC_Caddress,
                         phone = x.JC_Phoneno,
                         phone1 = x.JC_Residenceno,
                         phone2 = x.JC_MobileNo,
                         saledt = x.JC_SaleDate,
                         model = x.JC_Modelname
                     };
            if (Convert.ToInt32(v.Count()) > 0)
            {
                txt_keyno.Text = v.First().keyno;
                txt_engineno.Text = v.First().engineeno;
                txt_saledate.Text = Convert.ToDateTime(v.First().saledt).ToString("dd/MM/yyyy");
                ddl_customer.SelectedValue = Convert.ToString(v.First().custname);
                txt_address.Text = v.First().custadd;
                txt_phoneno.Text = v.First().phone.ToString();
                ddl_Model.SelectedValue = v.First().model.ToString();
            }
            else if (Convert.ToInt32(vv.Count()) > 0)
            {
                txt_keyno.Text = vv.First().keyno;
                txt_engineno.Text = vv.First().engineeno;
                txt_saledate.Text = Convert.ToDateTime(vv.First().saledt).ToString("dd/MM/yyyy");
                ddl_customer.SelectedValue = Convert.ToString(vv.First().custname);
                txt_address.Text = vv.First().custadd;
                txt_phoneno.Text = vv.First().phone.ToString();
                //txt_phoneno0.Text = vv.First().phone1.ToString();
                //txt_phoneno1.Text = vv.First().phone2.ToString();
                txt_regdno.Text = vv.First().regno.ToString();
                ddl_Model.SelectedValue = vv.First().model.ToString();
            }
            else
            {

                //ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('This Vehicle Registered First Time)..!!');", true);
                txt_keyno.Text = "";
                // txt_engineno.Text = "";
                txt_saledate.Text = "";
                ddl_customer.SelectedIndex = 0;
                txt_address.Text = "";
                txt_phoneno.Text = "";
                //txt_phoneno0.Text = "";
                //txt_phoneno1.Text = "";
            }
        }
        catch (Exception ex)
        { }
    }
    protected void txt_SDescription_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string branch = Session["Branch"].ToString();
            var v = from k in db.AME_Master_ServiceHead.ToList()
                    where (k.Mh_ServiceHead.Equals(txt_SDescription.Text) && k.Branch_Name == branch)
                    select new
                    {
                        k.Mh_ServiceHead,
                        k.Mh_ServiceCode,
                        k.Mh_ServiceRate
                    };

            txt_SCode.Text = v.First().Mh_ServiceCode;
            txt_SDescription.Text = Convert.ToString(v.First().Mh_ServiceHead);
            txt_SRate.Text = Convert.ToString(v.First().Mh_ServiceRate);
            txt_SQuantity.Focus();
        }
        catch(Exception ex)
        {
            txt_SCode.Text = "";
            txt_SDescription.Text = "";
            txt_SRate.Text = "";
            txt_SQuantity.Focus();
        }
    }
    protected void txt_regdno_TextChanged(object sender, EventArgs e)
    {

        try
        {
            if (txt_jcno.Text == "")
            {

                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Please Select Finacial Year..!!');", true);

                return;
            }

            string branch = Session["Branch"].ToString();

            var vv = from x in db.AME_Service_JobCardEntry
                     //join y in db.AME_Vehicle_SaleEntryDetails on x.Vs_Billno equals y.Vs_Billno
                     //join z in db.AME_Master_Customer on y.Vq_PartyName equals z.Mc_Id
                     where x.JC_Regno == txt_regdno.Text && x.Branch_Name == branch
                     select new
                     {
                         keyno = x.JC_Keyno,
                         engineeno = x.JC_Engineno,
                         chasisno = x.JC_Chassisno,
                         custname = x.JC_Customername,
                         custadd = x.JC_Caddress,
                         phone = x.JC_Phoneno,
                         phone1 = x.JC_Residenceno,
                         phone2 = x.JC_MobileNo,
                         saledt = x.JC_SaleDate,
                         model = x.JC_Modelname
                     };

            if (Convert.ToInt32(vv.Count()) > 0)
            {
                txt_keyno.Text = vv.First().keyno;
                txt_engineno.Text = vv.First().engineeno;
                txt_chassisno.Text = vv.First().chasisno;
                txt_saledate.Text = Convert.ToDateTime(vv.First().saledt).ToString("dd/MM/yyyy");
                ddl_customer.SelectedValue = Convert.ToString(vv.First().custname);
                txt_address.Text = vv.First().custadd;
                txt_phoneno.Text = vv.First().phone.ToString();
                //txt_phoneno0.Text = vv.First().phone1.ToString();
                //txt_phoneno1.Text = vv.First().phone2.ToString();
                ddl_Model.SelectedValue = vv.First().model.ToString();

            }
            else
            {

                //ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('This Vehicle Registered First Time)..!!');", true);
                txt_keyno.Text = "";
                // txt_engineno.Text = "";
                txt_saledate.Text = "";
                ddl_customer.SelectedIndex = 0;
                txt_address.Text = "";
                txt_phoneno.Text = "";
                //txt_phoneno0.Text = "";
                //txt_phoneno1.Text = "";
            }
        }
        catch (Exception ex)

        { }
    }
    protected void btn_new_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "window.open('Master_CustomerRegistration.aspx','Graph','height=700,width=700');", true);
            
    }
    protected void btn_refresh_Click(object sender, EventArgs e)
    {
      //  fillDetails();
        filljobcard();
    }



    //protected void txt_jcyear_TextChanged(object sender, EventArgs e)
    //{
    //    filljobcard12();

    //    SD.RemoveAll(t => t.UserId == Session["Uid"].ToString());
    //    FillServiceGrid();
    //    txt_date.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
    //    txt_saledate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
    //    txt_deliverydate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");

    //}
    protected void txt_jcyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            filljobcard12();

          //  SD.RemoveAll(t => t.UserId == Session["Uid"].ToString());
           // FillServiceGrid();
            txt_date.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
            txt_saledate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
            txt_deliverydate.Text = SmitaClass.IndianTime().ToString("dd/MM/yyyy");
        }
        catch (Exception ex)
        { 

        }
    }
    protected void drp_labtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (drp_labtype.SelectedItem.Text == "WARRANTY")
            {

                txt_SAmount.Text = "0.00";

            }
            else if (drp_labtype.SelectedItem.Text == "AMC")
            {

                txt_SAmount.Text = "0.00";

            }
            else if (drp_labtype.SelectedItem.Text == "FOC")
            {


                txt_SAmount.Text = "0.00";


            }
            else
            {

                decimal RAT = Convert.ToDecimal(txt_SRate.Text);

                decimal qty = Convert.ToDecimal(txt_SQuantity.Text);

                decimal amu1 = RAT * qty;
                txt_SAmount.Text = amu1.ToString("0.00");

            }

        }
        catch (Exception ex)
        { }
    }
    protected void txt_SQuantity_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (drp_labtype.SelectedItem.Text == "WARRANTY")
            {

                txt_SAmount.Text = "0.00";

            }
            else if (drp_labtype.SelectedItem.Text == "AMC")
            {

                txt_SAmount.Text = "0.00";

            }
            else if (drp_labtype.SelectedItem.Text == "FOC")
            {

                txt_SAmount.Text = "0.00";

            }
            else
            {
                if (txt_SRate.Text != "" && txt_SQuantity.Text != "")
                {

                    decimal RAT = Convert.ToDecimal(txt_SRate.Text);

                    decimal qty = Convert.ToDecimal(txt_SQuantity.Text);

                    decimal amu1 = RAT * qty;
                    txt_SAmount.Text = amu1.ToString("0.00");
                }
            }

        }
        catch (Exception ex)
        { }
    }
    protected void txt_SRate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (drp_labtype.SelectedItem.Text == "WARRANTY")
            {

                txt_SAmount.Text = "0.00";

            }
            else if (drp_labtype.SelectedItem.Text == "AMC")
            {

                txt_SAmount.Text = "0.00";

            }
            else if (drp_labtype.SelectedItem.Text == "FOC")
            {

                txt_SAmount.Text = "0.00";

            }
            else
            {
                if (txt_SRate.Text != "" && txt_SQuantity.Text != "")
                {

                    decimal RAT = Convert.ToDecimal(txt_SRate.Text);

                    decimal qty = Convert.ToDecimal(txt_SQuantity.Text);

                    decimal amu1 = RAT * qty;
                    txt_SAmount.Text = amu1.ToString("0.00");
                }
            }

        }
        catch (Exception ex)
        { }
    }
    protected void drp_labtype_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            if (drp_labtype.SelectedItem.Text == "WARRANTY")
            {

                txt_SAmount.Text = "0.00";

            }
            else if (drp_labtype.SelectedItem.Text == "AMC")
            {

                txt_SAmount.Text = "0.00";

            }
            else if (drp_labtype.SelectedItem.Text == "FOC")
            {


                txt_SAmount.Text = "0.00";


            }
            else if (drp_labtype.SelectedItem.Text == "PAID")
            {
                if(txt_SRate.Text!="" && txt_SQuantity.Text!="")
                {
                decimal RAT = Convert.ToDecimal(txt_SRate.Text);

                decimal qty = Convert.ToDecimal(txt_SQuantity.Text);

                decimal amu1 = RAT * qty;
                txt_SAmount.Text = amu1.ToString("0.00");
            }
            }
            else {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('You Selected a wrong Type..!!');", true);

                return;
            
            }

        }
        catch (Exception ex)
        { }
    }
    
}
