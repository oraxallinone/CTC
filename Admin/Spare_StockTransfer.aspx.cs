using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
using System.Data;
public partial class Admin_Default : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    static List<partdetails> modeldescription = new List<partdetails>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            filldata();

            modeldescription.RemoveAll(t => t.UserId == Session["Uid"].ToString());
        }

    }
    public void filldata()
    {
          string branchname = Session["Branch"].ToString();
          ddlfrombranch.Items.Insert(0,branchname);
          ddlfrombranch.Enabled = false;
          var branchdetails = from c in db.AME_Branch_Creation.Where(t => t.Branch_Name != branchname)
                              select new
                                  {
                                      id=c.Branch_Id,
                                      name=c.Branch_Name
                                  };
          ddltobranch.DataValueField = "id";
          ddltobranch.DataTextField = "name";
          ddltobranch.DataSource = branchdetails.ToList();
          ddltobranch.DataBind();

    }
    [System.Web.Services.WebMethod]
    public static string[] GetPartNo(string prefixText, int count)
    {
        string branch = HttpContext.Current.Session["Branch"].ToString();
        AutoMobileEntities db = new AutoMobileEntities();
        return db.AME_Master_Item.Where(n => n.Itm_Partno.Contains(prefixText) && n.Branch_Name == branch).OrderBy(n => n.Itm_Partno).Select(n => n.Itm_Partno).Distinct().Take(count).ToArray();
    }

    protected void btn_Show_Click(object sender, EventArgs e)
    {
        try
        {

            if (txt_PartNo.Text=="")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Part No Should Not Be Blank...!!!'); </script>", false);
                txt_PartNo.Focus();
                return;
            }
            if (lblpartdescription.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Part No Should Not Be Blank...!!!'); </script>", false);
                lblpartdescription.Focus();
                return;
            }
            if (Convert.ToDecimal(txttransferquantity.Text) <=0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Transfer Quantity Is Always Greter Than 0...!!!'); </script>", false);
                lblpartdescription.Focus();
                return;
            }
            if (Convert.ToDecimal(lblquantity.Text) < Convert.ToDecimal(txttransferquantity.Text))
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('You Dont Have More Stock,Your Available STock Is " + lblquantity.Text + "...!!!'); </script>", false);
                txttransferquantity.Focus();
                return;
            }

            if (txtdate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Transfer Date Shoud Not BeBlank...!!');", true);
                txtdate.Focus();
                return;
            }

            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy", "dd-MM-yyyy" };
            DateTime expectedDate;
            if (!DateTime.TryParseExact(txtdate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                txtdate.Focus();
                return;
            }
            string branchname = Session["Branch"].ToString();
            var vpartno = from c in modeldescription.Where(t => t.partno == txt_PartNo.Text && t.branch == branchname) select c;
            if (Convert.ToInt32(vpartno.Count()) > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('This Part No Already Exist..!!');</script>", false);

                return;
            }


            partdetails vd = new partdetails();
            vd.partno = txt_PartNo.Text;
            vd.partdescr = lblpartdescription.Text;
            vd.quantity =Convert.ToDecimal( txttransferquantity.Text);
            vd.UserId = Session["Uid"].ToString();
            vd.branch = Session["Branch"].ToString();

            modeldescription.Add(vd);
            fillgrid();
          
        //    ddlmodelname.Items.Clear();
        //    ddlchessisno.Items.Clear();
        //    ddl_VType.SelectedIndex = 0;

        //    Label2.Visible = false;
        //    Label3.Visible = false;
        //    Label3.Visible = false;
        //    Label4.Visible = false;
        //    Label5.Visible = false;
        //    Label6.Visible = false;
        //    lblengineno.Visible = false;
        //    lblcolor.Visible = false;
        //    lblkeyno.Visible = false;
        //    lblquantity.Visible = false;
        //    lblrate.Visible = false;
        //    lbl_engineno.Visible = false;
        //    transferquantity.Visible = false;
        //    lblmakers.Visible = false;
        //    Label7.Visible = false;
        }


        catch
        {

        }
    }


    public void fillgrid()
    {

        GridView2.DataSource = modeldescription.ToList();
        GridView2.DataBind();
    }
    public class partdetails
    {
     
        public string partno { get; set; }
        public string partdescr { get; set; }
        public decimal quantity { get; set; }
        public string UserId { get; set; }
        public string branch { get; set; }
    }
  
    protected void imgbtn_SBDelete_Click(object sender, ImageClickEventArgs e)
    {
       
     

    }
  
    protected void txt_PartNo_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string branchname = Session["Branch"].ToString();
         var v = from k in db.AME_Master_Item.ToList()
                    where (k.Itm_Partno.Equals(txt_PartNo.Text) && k.Branch_Name==branchname)
                    select new
                    {
                        k.Itm_Partno,
                        k.Itm_PartDescrption,
                       
                    };

            txt_PartNo.Text = v.First().Itm_Partno;
            lblpartdescription.Text = Convert.ToString(v.First().Itm_PartDescrption);
            

            DataSet ds = smitaDbAccess.returndataset("select SUM(Ss_NetQuantity) AS NetQuantity FROM AME_Spare_PurchaseEntry WHERE Itm_Partno='" + txt_PartNo.Text + "' AND Branch_Name='" + Session["Branch"].ToString() + "'");
            if (ds.Tables[0].Rows[0].ItemArray[0].ToString() != "")
            {
                lblquantity.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            else
            {
                lblquantity.Text = "0";
            }

            txttransferquantity.Focus();
        }
        catch
        {
            txt_PartNo.Text = "";
            lblpartdescription.Text = "";
            lblquantity.Text = "";
            txt_PartNo.Focus();
        }
    }
    protected void imgbtn_PartDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        string img1 = img.ToolTip;
        string branchname = Session["Branch"].ToString();
        modeldescription.RemoveAll(t => t.partno == img1 && t.branch==branchname);
        fillgrid();
    }
    protected void btn_assign_Click(object sender, EventArgs e)
    {
        var v = from c in modeldescription.OrderBy(t => t.partno) select c;
        if (Convert.ToInt32(v.Count()) <= 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Add The  Details..!!');</script>", false);

            return;
        }

        foreach (GridViewRow gr in GridView2.Rows)
        {
            Label Label10 = (Label)gr.FindControl("Label10");
            string partno = Label10.Text;

            Label PartDescription = (Label)gr.FindControl("Label12");
            string partdescription = PartDescription.Text;

            Label Label11 = (Label)gr.FindControl("Label11");
            decimal quantity =Convert.ToDecimal(Label11.Text);

            string branch = Session["Branch"].ToString();
            AME_SparepartsTransfer st = new AME_SparepartsTransfer();
            st.Branch_Name = branch;
            st.Created_By = Session["Uid"].ToString();
            st.Created_Date = Convert.ToDateTime(txtdate.Text, SmitaClass.dateformat());
            st.Itm_Partno = partno;
            st.St_FromBranch = ddlfrombranch.Text;
            st.St_ToBranch = ddltobranch.SelectedItem.Text;
            st.St_Transferdate = Convert.ToDateTime(txtdate.Text, SmitaClass.dateformat());
            st.St_TransferQuantity = quantity;
            st.Status = "Receive Transfer";
            db.AddToAME_SparepartsTransfer(st);
            db.SaveChanges();

            string CWParam1 = "@Branch,@Req_Qntity,@ItmPartno";
            string CWParamValue1 = branch + "," + quantity + "," + partno;
            smitaDbAccess.insertprocedure("Sp_StockdispatchInSpareIssue", CWParam1, CWParamValue1);

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Sparepart Transfer Sucessfully..!!');</script>", false);
            return;
        }

       
    }
}