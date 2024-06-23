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
public partial class Admin_StockAdjustment : System.Web.UI.Page
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

    protected void FillGrid()
    {

        try
        {
            string Branch = Session["Branch"].ToString();
            //string param = "@Branch,@itempartno";
            string partno = txt_PartNo.Text.Trim();

            string[] param = { "@Branch", "@itempartno" };

            
            string[] paramvalue = { Branch, partno };
            //string paramvalue = Convert.ToDateTime(txt_FromDate.Text, SmitaClass.dateformat()).ToString("yyyy-MM-dd HH:mm:ss") + " , " + Convert.ToDateTime(txt_ToDate.Text, SmitaClass.dateformat()).ToString("yyyy-MM-dd HH:mm:ss") + "," + Branch;

         //   string paramvalue = Branch + "," + txt_PartNo.Text.Trim();

            DataTable dtr = smitaDbAccess.SPReturnDataTable1("sp_showitemmaster", param, paramvalue);

         

            if (Convert.ToInt32(dtr.Rows.Count) > 0)
            {
                GridView2.DataSource = dtr;
                GridView2.DataBind();

                var zzz = from c in db.AME_Branch_Creation.ToList() where c.Branch_Name == Session["Branch"].ToString() select c;
                lbl_BranchAddress.Text = zzz.First().Branch_Address + ", " + zzz.First().Branch_PhoneNo;

                //lbl_from.Text = txt_FromDate.Text;
                //lbl_to.Text = txt_ToDate.Text;
                Panel1.Visible = true;
            }
            else
            {
               
                //ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('" + txt_FromDate.Text + "  To  " + txt_ToDate.Text + "  No Quotation Are Entry..!!');", true);
                //Panel1.Visible = false;
                //txt_FromDate.Focus();
                //return;
            }
        }
        catch
        {

        }

    }

    protected void txt_PartNo_TextChanged(object sender, EventArgs e)
    {
        FillGrid();
    }


    protected void imgbtnedit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton Img_edit = (ImageButton)sender;
      //  int imgid = Convert.ToInt32(Img_edit.ToolTip);
        string imgid = Img_edit.ToolTip;

        foreach (GridViewRow gr in GridView2.Rows)
        {
            gr.BackColor = System.Drawing.Color.Transparent;
            ImageButton imgFc = (ImageButton)gr.FindControl("imgbtnedit");


            ImageButton imgFcc = (ImageButton)gr.FindControl("imgbtnupadte");



            imgFc.Visible = false;
            imgFcc.Visible = true;
        }
        GridViewRow row = Img_edit.NamingContainer as GridViewRow;
        row.BackColor = System.Drawing.Color.Pink;

    }

    protected void imgbtnupadte_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton img_update = (ImageButton)sender;
           // int imgid = Convert.ToInt32(img_update.ToolTip);
           string imgid = img_update.ToolTip;

            foreach (GridViewRow gr in GridView2.Rows)
            {
                ImageButton imgFc = (ImageButton)gr.FindControl("imgbtnupadte");
              //  int id = Convert.ToInt32(imgFc.ToolTip);
                string id = imgFc.ToolTip;

                if (imgid == id)
                {

                    TextBox txtadjustquantity = (TextBox)gr.FindControl("txt_adjustquntity");
                    if (txtadjustquantity.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "", "alert('Adjust Quantity should Not Be Blank.!!');", true);
                        txtadjustquantity.Focus();
                        return;
                    }
                    decimal adquantity = Convert.ToDecimal(txtadjustquantity.Text);

                   

                    Label lblnetquantity = (Label)gr.FindControl("lblnetquantity");
                    decimal lblnetquantity1 = Convert.ToDecimal(lblnetquantity.Text);

                   

                    Label lblpartno = (Label)gr.FindControl("lblpartno");
                    string lblpartno1 = lblpartno.Text;


                    Label lblpartdescrp = (Label)gr.FindControl("lblpartdescription");
                    string lblpartdescrp1 = lblpartdescrp.Text;

                    Label lblsale = (Label)gr.FindControl("lbl_sale");
                    decimal lblsaleprice = Convert.ToDecimal( lblsale.Text);



                    ImageButton imgFcc = (ImageButton)gr.FindControl("imgbtnedit");

                    string Branch = Session["Branch"].ToString();
                  //  string param = "@Branch,@Req_Qntity,@ItmPartno";

                    string [] param ={ "@Branch","@Req_Qntity","@ItmPartno"};

                    string [] paramvalue ={ Branch ,  adquantity.ToString() , lblpartno1};


                    //string paramvalue = Branch + "," + adquantity.ToString() + "," + lblpartno1;

                    DataTable dtr = smitaDbAccess.SPReturnDataTable1("sp_updateitemmaster", param, paramvalue);

                    //string Branch1 = Session["Branch"].ToString();
                    //string uid = Convert.ToString(Session["Uid"]);
                    //string param1 = "@Sp_VoucherNo,@Itm_Partno,@Itm_PartDescrption,@Ss_Quantity,@Ss_NetQuantity,@SSA_Adjustquantity,@Branch_Name,@Created_By,@Created_Date";
                    //string paramvalue1 = lblinvoiceno1 + "," + lblpartno1 + "," + lblpartdescrp1 + "," + lblquantity1 + "," + lblnetquantity1 + "," + adquantity + "," + Branch + "," + uid + "," + SmitaClass.IndianTime().ToString("dd/MM/yyyy HH:mm:ss");
                    //smitaDbAccess.insertprocedure("Sp_SpareStock_Insert", param, paramvalue);


                    //AME_Spare_PurchaseEntry ped = db.AME_Spare_PurchaseEntry.First(t => t.Itm_Partno == id);
                 
                    //ped.Ss_NetQuantity = Convert.ToDecimal(adquantity + lblnetquantity1);
                    //db.SaveChanges();

                    string Branch1 = Session["Branch"].ToString();
                    string uid = Convert.ToString(Session["Uid"]);
                 //   string param1 = "@Itm_Partno,@Itm_PartDescrption,@Ss_selprice,@Ss_NetQuantity,@SSA_Adjustquantity,@Branch_Name,@Created_By,@Created_Date";

                    string [] param1 = {"@Itm_Partno","@Itm_PartDescrption","@Ss_selprice","@Ss_NetQuantity","@SSA_Adjustquantity","@Branch_Name","@Created_By","@Created_Date"};

                    string[] paramvalue1 = { lblpartno1, lblpartdescrp1, lblsaleprice.ToString(), lblnetquantity1.ToString(), adquantity.ToString(), Branch, uid, SmitaClass.IndianTime().ToString("yyyy-MM-dd HH:mm:ss") };

                    //string paramvalue1 = lblpartno1 + "," + lblpartdescrp1 + "," + lblsaleprice + "," + lblnetquantity1.ToString() + "," + adquantity.ToString() + "," + Branch + "," + uid + "," + SmitaClass.IndianTime().ToString("yyyy-MM-dd HH:mm:ss");
                    smitaDbAccess.insertprocedurestockcoma("Sp_SpareStock_adj", param1, paramvalue1);


                    //imgFc.Visible = false;
                    //imgFcc.Visible = true;
                    FillGrid();
                }

            }
            GridViewRow row = img_update.NamingContainer as GridViewRow;
            row.BackColor = System.Drawing.Color.Green;
        }
        catch(Exception ex)
        {

        }
    }
}