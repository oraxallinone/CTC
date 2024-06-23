using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Globalization;
public partial class Admin_Default : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    static List<VechicleDetails> modeldescription = new List<VechicleDetails>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            filldata();
            string uid = Convert.ToString(Session["Uid"]);
            modeldescription.RemoveAll(t => t.userid == uid);
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
    protected void btn_Show_Click(object sender, EventArgs e)
    {
        try
        {

            if (ddl_VType.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Please Select Vehicle Type...!!');", true);
                ddl_VType.Focus();
                return;
            }
            if (ddlmodelname.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Please Select Model Name...!!');", true);
                ddlmodelname.Focus();
                return;
            }
            if (ddlchessisno.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Please Select Chessis No ...!!');", true);
                ddlchessisno.Focus();
                return;
            }
            if (txt_transferdate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Transfer Date Shoud Not BeBlank...!!');", true);
                txt_transferdate.Focus();
                return;
            }

            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MMM/yyyy", "dd-MM-yyyy" };
            DateTime expectedDate;
            if (!DateTime.TryParseExact(txt_transferdate.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out expectedDate))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('ENTER VALID DATE (DD/MMM/YYYY)..!!');", true);
                txt_transferdate.Focus();
                return;
            }
            var checkchessisno = modeldescription.Where(t => t.chessisno == ddlchessisno.SelectedItem.Text);
            if(Convert.ToInt32(checkchessisno.Count())>0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('This Chessis No Already Exist..!!');", true);
                ddlchessisno.Focus();
                return;
            }
            string branchname = Session["Branch"].ToString();
            string uid = Convert.ToString(Session["Uid"]);


            VechicleDetails vd = new VechicleDetails();
            vd.billno = Convert.ToInt32(ddlchessisno.ToolTip);
            vd.modelname = ddlmodelname.SelectedItem.Text;
            vd.vehicletype = ddl_VType.SelectedItem.Text;
            vd.userid = uid;
            vd.frombranch = ddlfrombranch.SelectedItem.Text;
            vd.tobranch = ddltobranch.SelectedItem.Text;
            vd.chessisno = ddlchessisno.SelectedItem.Text;
            vd.mvalue = Convert.ToInt32(ddlmodelname.SelectedValue);
            vd.color = lblcolor.Text;
            vd.engine = lblengineno.Text;
            vd.keyno = lblkeyno.Text;
            vd.rate = Convert.ToDecimal(lblrate.Text);
            vd.amount = Convert.ToDecimal(lblamount.Text);
            vd.quantity = Convert.ToDecimal(lblquantity.Text);
            vd.makersname = lblmakers.Text;
            modeldescription.Add(vd);
            fillgrid();
          
            ddlmodelname.Items.Clear();
            ddlchessisno.Items.Clear();
            ddl_VType.SelectedIndex = 0;

            Label2.Visible = false;
            Label3.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            lblengineno.Visible = false;
            lblcolor.Visible = false;
            lblkeyno.Visible = false;
            lblquantity.Visible = false;
            lblrate.Visible = false;
            lbl_engineno.Visible = false;
            lblamount.Visible = false;
            lblmakers.Visible = false;
            Label7.Visible = false;
        }


        catch
        {

        }
    }
    protected void ddl_VType_SelectedIndexChanged(object sender, EventArgs e)
    {
        string branchname = Session["Branch"].ToString();
        var vss = (from c in db.AME_Vehicle_PurchaseEntry.ToList()
                           join d in db.AME_Master_VehicleModel on c.Mv_ModelName equals d.Mv_Id
                           where c.Branch_Name == branchname && d.Mv_VehicleType == ddl_VType.SelectedItem.Text
                           select new
                           {
                               vid = d.Mv_Id,
                               vname = d.Mv_ModelName
                           }).Distinct().ToList();
        
        ddlmodelname.DataSource = vss.ToList();
        ddlmodelname.DataValueField = "vid";
        ddlmodelname.DataTextField = "vname";
       
        ddlmodelname.DataBind();
        ddlmodelname.Items.Insert(0, "...Select...");
    }
    protected void ddlmodelname_SelectedIndexChanged(object sender, EventArgs e)
    {
        string branchname = Session["Branch"].ToString();

        int modelname = Convert.ToInt32(ddlmodelname.SelectedValue);
        var vc = (from c in db.AME_Vehicle_PurchaseEntry
                           join d in db.AME_Master_VehicleModel on c.Mv_ModelName equals d.Mv_Id
                           where c.Branch_Name == branchname && c.Mv_VehicleType == ddl_VType.SelectedItem.Text
                           && c.Mv_ModelName == modelname && c.Vp_NetQuantity != 0

                           select new
                           {
                               id = c.Vp_Id,
                               name = c.Vp_Chassisno,
                               billno=c.Vpd_Id
                           }).Distinct().ToList();
        ddlchessisno.DataValueField = "id";
        ddlchessisno.DataTextField = "name";
        ddlchessisno.ToolTip =Convert.ToString(vc.First().billno);
        ddlchessisno.DataSource = vc.ToList();
        ddlchessisno.DataBind();
        ddlchessisno.Items.Insert(0, "...Select...");
    }
    public void fillgrid()
    {
        string uid = Convert.ToString(Session["Uid"]);
        GridView1.DataSource = modeldescription.ToList().Where(t => t.userid == uid);
        GridView1.DataBind();
    }
    public class VechicleDetails
    {
        public int billno { get; set; }
        public string vehicletype { get; set; }
        public string modelname { get; set; }
        public decimal quantity { get; set; }
        public decimal rate { get; set; }
        public decimal amount { get; set; }
        public int mvalue { get; set; }
        public string userid { get; set; }
        public string chessisno { get; set; }
        public string frombranch { get; set; }
        public string tobranch { get; set; }
        public string engine { get; set; }
        public string color { get; set; }
        public string keyno { get; set; }
        public string makersname { get; set; }
    }
  
    protected void imgbtn_SBDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        string img1 = img.ToolTip;
        modeldescription.RemoveAll(t => t.chessisno == img1);
        fillgrid();
     

    }
  
    protected void btn_assign_Click(object sender, EventArgs e)
    {
        var v = from c in modeldescription.OrderBy(t => t.chessisno) select c;
        if (Convert.ToInt32(v.Count()) <= 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Please Add The  Details..!!');</script>", false);
           
            return;
        }
       

        foreach (GridViewRow gr in GridView1.Rows)
        {
            Label lblbillno=(Label)gr.FindControl("lblbillno");
            int billno=Convert.ToInt32(lblbillno.Text);

            Label lblmakers = (Label)gr.FindControl("lblmakers");
            string makers = lblmakers.Text;

            Label lbltobranch = (Label)gr.FindControl("lbltobranch");
            string tobranch = lbltobranch.Text;

            Label lblfrombranch = (Label)gr.FindControl("lblfrombranch");
            string frombranch = lblfrombranch.Text;


            Label lblengno = (Label)gr.FindControl("lblengno");
            string engineno = lblengno.Text;

            Label lblcolor = (Label)gr.FindControl("lblcolor");
            string color = lblcolor.Text;

            Label lblvechiletype = (Label)gr.FindControl("lblvechiletype");
            string vehicletype = lblvechiletype.Text;

            Label lblmodelname = (Label)gr.FindControl("lblmodelname");
            int modelname =Convert.ToInt32(lblmodelname.ToolTip);

            Label lblchessisno = (Label)gr.FindControl("lblchessisno");
            string chessisno = lblchessisno.Text;

            Label lblkey = (Label)gr.FindControl("lblkey");
            string keyno = lblkey.Text;

            Label lblrate = (Label)gr.FindControl("lblrate");
            decimal rate =Convert.ToDecimal(lblrate.Text);

            Label lblquantity = (Label)gr.FindControl("lblquantity");
            decimal quantity = Convert.ToDecimal(lblquantity.Text);

            Label lblamount = (Label)gr.FindControl("lblamount");
            decimal amount = Convert.ToDecimal(lblamount.Text);



            AME_Vehicle_PurchaseEntry avp = db.AME_Vehicle_PurchaseEntry.First(t => t.Vp_Chassisno == chessisno);
            avp.Vp_NetQuantity = 0;
            avp.Status = "SendTransfer";
            avp.PendingStatus = "True";
            db.SaveChanges();

            //var v1 = from x1 in db.AME_Vehicle_PurchaseEntry.Where(t => t.Vp_Chassisno == chessisno) select x1;
            //int id = v1.First().Vpd_Id;

             //AME_Vehicle_PurchaseEntry Vp = new AME_Vehicle_PurchaseEntry();
             //Vp.Branch_Name =tobranch;
             //Vp.Created_By = Session["Uid"].ToString();
             //Vp.Created_Date = SmitaClass.IndianTime();
             //Vp.Mv_Makers = makers;
             //Vp.Mv_ModelName = modelname;
             //Vp.Vp_Amount = amount;
             //Vp.Vp_Chassisno = chessisno;
             //Vp.Vp_Color = color;
             //Vp.Vp_Engineno = engineno;
             //Vp.Vp_Keyno = keyno;
             //Vp.Vp_NetQuantity = quantity;
             //Vp.Vp_Quantity = quantity;
             //Vp.Vp_Rate = rate;
             //Vp.Vpd_Id = billno;
             //Vp.Mv_VehicleType = vehicletype;
             //Vp.Status = "PE";
             //db.AddToAME_Vehicle_PurchaseEntry(Vp);
             //db.SaveChanges();

        AME_VehicleTransfer vt = new AME_VehicleTransfer();
        vt.Branch_Name = Session["Branch"].ToString();
        vt.Created_By = Session["Uid"].ToString();
        vt.Created_Date = SmitaClass.IndianTime();
        vt.Mv_ModelName = modelname;
        vt.Mv_VehicleType = vehicletype;
        vt.St_FromBranch = frombranch;
        vt.St_ToBranch = tobranch;
        vt.St_Transferdate = Convert.ToDateTime(txt_transferdate.Text,SmitaClass.dateformat());
        vt.Vp_Chassisno = chessisno;
        vt.Vpd_Id = billno;
        vt.Status = "Send Transfer";
        vt.ReceiveStatus = "Pending";
        db.AddToAME_VehicleTransfer(vt);
        db.SaveChanges();
        }
       
        modeldescription.RemoveAll(t => t.modelname != "");
        GridView1.DataSource = null;
        GridView1.DataBind();
        txt_transferdate.Text = "";

        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MessagePopUp", "<script language='JavaScript'>alert('Stock Transfer Sucessfully..!!');</script>", false);
        return;
    }
    protected void ddlchessisno_SelectedIndexChanged(object sender, EventArgs e)
    {
        var details = from c in db.AME_Vehicle_PurchaseEntry.Where(t => t.Vp_Chassisno == ddlchessisno.SelectedItem.Text)
                      select
                          c;
        Label2.Visible = true;
        Label3.Visible = true;
        Label3.Visible = true;
        Label4.Visible = true;
        Label5.Visible = true;
        Label6.Visible = true;
        Label7.Visible = true;
        lbl_engineno.Visible = true;
        lblengineno.Visible = true;
        lblcolor.Visible = true;
        lblkeyno.Visible = true;
        lblquantity.Visible = true;
        lblrate.Visible = true;
        lbl_engineno.Visible = true;
        lblamount.Visible = true;
        lblmakers.Visible = true;
        lblengineno.Text = details.First().Vp_Engineno;
        lblcolor.Text = details.First().Vp_Color;
        lblamount.Text = Convert.ToString(details.First().Vp_Amount);
        lblkeyno.Text = details.First().Vp_Keyno;
        lblrate.Text = Convert.ToString(details.First().Vp_Rate);
        lblquantity.Text = Convert.ToString(details.First().Vp_Quantity);
        lblmakers.Text = details.First().Mv_Makers;
    }
}