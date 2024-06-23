using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
public partial class Admin_MasterPage : System.Web.UI.MasterPage
{
   public string MService, MSpareParts, MVehicleSales, MMaster, MAdmin, MReport;
   string id;
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session["Branch"] == null || Session["Uid"] == null || Session["Uname"] == null )
        {
            
            Response.Redirect("../SessionExpired.aspx");
        }
        
    
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                //if (Session["saletype"] != null)
                //{
                //    lbl_usertypesale.Text = Session["saletype"].ToString();
                //    showmenu();
                //}
                //else
                //{
                //    li_cupreg.Visible = false;
                //    li_serviceheadreg.Visible = false;
                //    li_vehiclemodelreg.Visible = false;
                //    li_superreg.Visible = false;
                //}
                if (Session["saletype"] != null)
                {
                    lbl_usertypesale.Text = Session["saletype"].ToString();

                    id = Session["id"].ToString();
                    showmenu();
                }
                else
                {
                    li_cupreg.Visible = false;
                    li_serviceheadreg.Visible = false;
                    li_vehiclemodelreg.Visible = false;
                    li_superreg.Visible = false;

                }
                lbl_uname.Text =Session["Uname"].ToString();
                lblbranch.Text = Session["Branch"].ToString();
               // lblusertype.Text = Session["Usertype"].ToString();
                if (Session["Usertype"].ToString() == "User")
                {

                    lblusertype.Text = Session["id"].ToString();
                }
                else
                {

                    lblusertype.Text = Session["Usertype"].ToString();
                }
            }
            catch
            {

            }
        }
    }
    public void showmenu()
    {
        string branch = Session["Branch"].ToString();
        if (Session["saletype"].ToString() == "VehiclesSale" && branch == "Cuttack")
        {
            Div1.Visible = false;
            Div2.Visible = false;
            Master.Visible = true;
            Service.Visible = false;
            SpareParts.Visible = false;
            Admin.Visible = false;
            Vehicle.Visible = true;
            Report.Visible = true;
            id65.Visible = false;
            id66.Visible = false;
            id67.Visible = false;
            id68.Visible = false;
            id69.Visible = false;
            id70.Visible = false;
            id71.Visible = false;
            id72.Visible = false;
            id73.Visible = false;
            id74.Visible = false;
            id75.Visible = false;
            id76.Visible = false;
            id77.Visible = false;
            li_status.Visible = false;
           
        }
        else if (Session["saletype"].ToString() == "VehiclesSale" && branch == "Phulnakhara")
        {
            Div1.Visible = false;
            Div2.Visible = false;
            Master.Visible = true;
            Service.Visible = false;
            SpareParts.Visible = false;
            Admin.Visible = false;
            Vehicle.Visible = true;
            Report.Visible = true;
            id65.Visible = false;
            id66.Visible = false;
            id67.Visible = false;
            id68.Visible = false;
            id69.Visible = false;
            id70.Visible = false;
            id71.Visible = false;
            id72.Visible = false;
            id73.Visible = false;
            id74.Visible = false;
            id75.Visible = false;
            id76.Visible = false;
            id77.Visible = false;
            li_status.Visible = false;

        }
        else if (Session["saletype"].ToString() == "VehiclesSale" && branch == "Paradeep")
        {
            Div1.Visible = false;
            Div2.Visible = false;
            Master.Visible = false;
            Service.Visible = false;
            SpareParts.Visible = false;
            Admin.Visible = false;
            Vehicle.Visible = false;
            Report.Visible = false;
            li_status.Visible = false;

        }
        else if (Session["saletype"].ToString() == "VehiclesSale" && branch == "Berhampur")
        {
            Div1.Visible = false;
            Div2.Visible = false;
            Master.Visible = false;
            Service.Visible = false;
            SpareParts.Visible = false;
            Admin.Visible = false;
            Vehicle.Visible = false;
            Report.Visible = false;
            li_status.Visible = false;

        }
        else if (Session["saletype"].ToString() == "Service_Spareparts" && branch == "Cuttack" && Session["id"].ToString() == "User1")
        {
            Master.Visible = true;
            Service.Visible = true;
            Label3.Visible = false;
            SpareParts.Visible = false;
            Admin.Visible = false;
            Vehicle.Visible = false;
            Report.Visible = true;
            id78.Visible = false;
            id79.Visible = false;
            id80.Visible = false;
            id81.Visible = false;
            id82.Visible = false;
            id83.Visible = false;
            id84.Visible = false;
            id85.Visible = false;
            id86.Visible = false;
            id32.Visible = false;
            li_adjust.Visible = false;
           // li18.Visible = false;
            li_itemadjust.Visible = false;
            li_receive.Visible = false;
            li_receivelist.Visible = false;
            li_status.Visible = false;

        }
        else if (Session["saletype"].ToString() == "Service_Spareparts" && branch == "Cuttack" && Session["id"].ToString() == "User2")
        {
            Master.Visible = true;
            Service.Visible = true;
            SpareParts.Visible = false;
            Label3.Visible = false;

            Admin.Visible = false;
            Vehicle.Visible = false;
            Report.Visible = true;
            id78.Visible = false;
            id79.Visible = false;
            id80.Visible = false;
            id81.Visible = false;
            id82.Visible = false;
            id83.Visible = false;
            id84.Visible = false;
            id85.Visible = false;
            id86.Visible = false;
            id32.Visible = false;
            li_adjust.Visible = false;
          //  li18.Visible = false;

            li_itemadjust.Visible = false;
            li_receive.Visible = false;
            li_receivelist.Visible = false;
            li_status.Visible = false;

        }
        else if (Session["saletype"].ToString() == "Service_Spareparts" && branch == "Cuttack" && Session["id"].ToString() == "User3")
        {
            Master.Visible = true;
            Service.Visible = false;
            SpareParts.Visible = true;
            Admin.Visible = false;
            Vehicle.Visible = false;
            Report.Visible = true;
            id78.Visible = false;
            id79.Visible = false;
            id80.Visible = false;
            id81.Visible = false;
            id82.Visible = false;
            id83.Visible = false;
            id84.Visible = false;
            id85.Visible = false;
            id86.Visible = false;
            id32.Visible = false;
            li_adjust.Visible = false;
          //  li18.Visible = false;

            li_itemadjust.Visible = false;
            li_receive.Visible = false;
            li_receivelist.Visible = false;
            li_status.Visible = false;

        }

        else if (Session["saletype"].ToString() == "Service_Spareparts" && branch == "Cuttack" && Session["id"].ToString() == "User4")
        {
            Master.Visible = true;
            Service.Visible = false;
            SpareParts.Visible = true;
            Admin.Visible = false;
            Vehicle.Visible = false;
            Report.Visible = true;
            id78.Visible = false;
            id79.Visible = false;
            id80.Visible = false;
            id81.Visible = false;
            id82.Visible = false;
            id83.Visible = false;
            id84.Visible = false;
            id85.Visible = false;
            id86.Visible = false;
            id32.Visible = false;
            li_adjust.Visible = false;
           // li18.Visible = false;

            li_itemadjust.Visible = false;
            li_receive.Visible = false;
            li_receivelist.Visible = false;
            li_status.Visible = false;

        }
        else if (Session["saletype"].ToString() == "Service_Spareparts" && branch == "Phulnakhara" && Session["id"].ToString() == "User1")
        {
            Master.Visible = true;
            Service.Visible = true;
            SpareParts.Visible = false;
            Label3.Visible = false;

            Admin.Visible = false;
            Vehicle.Visible = false;
            Report.Visible = true;
            id78.Visible = false;
            id79.Visible = false;
            id80.Visible = false;
            id81.Visible = false;
            id82.Visible = false;
            id83.Visible = false;
            id84.Visible = false;
            id85.Visible = false;
            id86.Visible = false;
            id32.Visible = false;
            li_adjust.Visible = false;
           // li18.Visible = false;

            li_itemadjust.Visible = false;
            li_receive.Visible = false;
            li_receivelist.Visible = false;
            //  li_receive.Visible = true;
            //  li_receivelist.Visible = true;
            li_status.Visible = false;

        }
        else if (Session["saletype"].ToString() == "Service_Spareparts" && branch == "Phulnakhara" && Session["id"].ToString() == "User2")
        {
            Master.Visible = true;
            Service.Visible = true;
            SpareParts.Visible = false;
            Label3.Visible = false;

            Admin.Visible = false;
            Vehicle.Visible = false;
            Report.Visible = true;
            id78.Visible = false;
            id79.Visible = false;
            id80.Visible = false;
            id81.Visible = false;
            id82.Visible = false;
            id83.Visible = false;
            id84.Visible = false;
            id85.Visible = false;
            id86.Visible = false;
            id32.Visible = false;
            li_adjust.Visible = false;
           // li18.Visible = false;

            li_itemadjust.Visible = false;
            li_receive.Visible = false;
            li_receivelist.Visible = false;
            //  li_receive.Visible = true;
            //  li_receivelist.Visible = true;
            li_status.Visible = false;

        }
        else if (lbl_usertypesale.Text == "Service_Spareparts" && branch == "Phulnakhara" && id == "User3")
        {
            Master.Visible = true;
            Service.Visible = false;
            SpareParts.Visible = true;
            Admin.Visible = false;
            Vehicle.Visible = false;
            Report.Visible = true;
            id78.Visible = false;
            id79.Visible = false;
            id80.Visible = false;
            id81.Visible = false;
            id82.Visible = false;
            id83.Visible = false;
            id84.Visible = false;
            id85.Visible = false;
            id86.Visible = false;
            id32.Visible = false;
            li_adjust.Visible = false;
          //  li18.Visible = false;

            li_itemadjust.Visible = false;
            li_receive.Visible = false;
            li_receivelist.Visible = false;
            li_status.Visible = false;


        }

        else if (Session["saletype"].ToString() == "Service_Spareparts" && branch == "Phulnakhara" && Session["id"].ToString() == "User4")
        {
            Master.Visible = true;
            Service.Visible = false;
            SpareParts.Visible = true;
            Admin.Visible = false;
            Vehicle.Visible = false;
            Report.Visible = true;
            id78.Visible = false;
            id79.Visible = false;
            id80.Visible = false;
            id81.Visible = false;
            id82.Visible = false;
            id83.Visible = false;
            id84.Visible = false;
            id85.Visible = false;
            id86.Visible = false;
            id32.Visible = false;
            li_adjust.Visible = false;
           // li18.Visible = false;

            li_itemadjust.Visible = false;
            li_receive.Visible = false;
            li_receivelist.Visible = false;
            li_status.Visible = false;


        }
        else if (Session["saletype"].ToString() == "Service_Spareparts" && branch == "Berhampur" && Session["id"].ToString() == "User1")
        {
            Master.Visible = true;
            Service.Visible = true;
            SpareParts.Visible = false;
            Label3.Visible = false;

            Admin.Visible = false;
            Vehicle.Visible = false;
            Report.Visible = true;
            id78.Visible = false;
            id79.Visible = false;
            id80.Visible = false;
            id81.Visible = false;
            id82.Visible = false;
            id83.Visible = false;
            id84.Visible = false;
            id85.Visible = false;
            id86.Visible = false;
            id32.Visible = false;
            li_adjust.Visible = false;
          //  li18.Visible = false;

            li_itemadjust.Visible = false;
            li_receive.Visible = false;
            li_receivelist.Visible = false;
            li_status.Visible = false;

        }

        else if (Session["saletype"].ToString() == "Service_Spareparts" && branch == "Berhampur" && Session["id"].ToString() == "User2")
        {
            Master.Visible = true;
            Service.Visible = true;
            SpareParts.Visible = false;
            Label3.Visible = false;

            Admin.Visible = false;
            Vehicle.Visible = false;
            Report.Visible = true;
            id78.Visible = false;
            id79.Visible = false;
            id80.Visible = false;
            id81.Visible = false;
            id82.Visible = false;
            id83.Visible = false;
            id84.Visible = false;
            id85.Visible = false;
            id86.Visible = false;
            id32.Visible = false;
            li_adjust.Visible = false;
          //  li18.Visible = false;

            li_itemadjust.Visible = false;
            li_receive.Visible = false;
            li_receivelist.Visible = false;
            li_status.Visible = false;

        }
        else if (Session["saletype"].ToString() == "Service_Spareparts" && branch == "Berhampur" && Session["id"].ToString() == "User3")
        {
            Master.Visible = true;
            Service.Visible = false;
            SpareParts.Visible = true;
            Admin.Visible = false;
            Vehicle.Visible = false;
            Report.Visible = true;
            id78.Visible = false;
            id79.Visible = false;
            id80.Visible = false;
            id81.Visible = false;
            id82.Visible = false;
            id83.Visible = false;
            id84.Visible = false;
            id85.Visible = false;
            id86.Visible = false;
            id32.Visible = false;
            li_adjust.Visible = false;
           // li18.Visible = false;

            li_itemadjust.Visible = false;
            li_receive.Visible = false;
            li_receivelist.Visible = false;
            li_status.Visible = false;


        }
        else if (Session["saletype"].ToString() == "Service_Spareparts" && branch == "Berhampur" && Session["id"].ToString() == "User4")
        {
            Master.Visible = true;
            Service.Visible = false;
            SpareParts.Visible = true;
            Admin.Visible = false;
            Vehicle.Visible = false;
            Report.Visible = true;
            id78.Visible = false;
            id79.Visible = false;
            id80.Visible = false;
            id81.Visible = false;
            id82.Visible = false;
            id83.Visible = false;
            id84.Visible = false;
            id85.Visible = false;
            id86.Visible = false;
            id32.Visible = false;
            li_adjust.Visible = false;
          //  li18.Visible = false;

            li_itemadjust.Visible = false;
            li_receive.Visible = false;
            li_receivelist.Visible = false;
            li_status.Visible = false;


        }
        //else if (Session["saletype"].ToString() == "Service_Spareparts" && branch == "Cuttack")
        //{
        //    Master.Visible = true;
        //    Service.Visible = true;
        //    SpareParts.Visible = true;
        //    Admin.Visible = false;
        //    Vehicle.Visible = false;
        //    Report.Visible = true;
        //    id78.Visible = false;
        //    id79.Visible = false;
        //    id80.Visible = false;
        //    id81.Visible = false;
        //    id82.Visible = false;
        //    id83.Visible = false;
        //    id84.Visible = false;
        //    id85.Visible = false;
        //    id86.Visible = false;
        //    id32.Visible = false;
        //    li_adjust.Visible = false;
        //    li_itemadjust.Visible = false;
        //    li_receive.Visible = false;
        //    li_receivelist.Visible = false;
        //}
        //else if (Session["saletype"].ToString() == "Service_Spareparts" && branch == "Phulnakhara")
        //{
        //    Master.Visible = true;
        //    Service.Visible = true;
        //    SpareParts.Visible = true;
        //    Admin.Visible = false;
        //    Vehicle.Visible = false;
        //    Report.Visible = true;
        //    id78.Visible = false;
        //    id79.Visible = false;
        //    id80.Visible = false;
        //    id81.Visible = false;
        //    id82.Visible = false;
        //    id83.Visible = false;
        //    id84.Visible = false;
        //    id85.Visible = false;
        //    id86.Visible = false;
        //    id32.Visible = false;
        //    li_adjust.Visible = false;
        //    li_itemadjust.Visible = false;
        //    li_receive.Visible = false;
        //    li_receivelist.Visible = false;
        //}
        //else if (Session["saletype"].ToString() == "Service_Spareparts" && branch == "Paradeep")
        //{
        //    Master.Visible = true;
        //    Service.Visible = true;
        //    SpareParts.Visible = true;
        //    Admin.Visible = false;
        //    Vehicle.Visible = false;
        //    Report.Visible = true;
        //    id78.Visible = false;
        //    id79.Visible = false;
        //    id80.Visible = false;
        //    id81.Visible = false;
        //    id82.Visible = false;
        //    id83.Visible = false;
        //    id84.Visible = false;
        //    id85.Visible = false;
        //    id86.Visible = false;
        //    id32.Visible = false;
        //    li_adjust.Visible = false;
        //    li_itemadjust.Visible = false;
        //    li_receive.Visible = false;
        //    li_receivelist.Visible = false;
        //    //  li_receive.Visible = true;
        //    //  li_receivelist.Visible = true;
        //    li_status.Visible = false;

        //}
        //else if (Session["saletype"].ToString() == "Service_Spareparts" && branch == "Berhampur")
        //{
        //    Master.Visible = true;
        //    Service.Visible = true;
        //    SpareParts.Visible = true;
        //    Admin.Visible = false;
        //    Vehicle.Visible = false;
        //    Report.Visible = true;
        //    id78.Visible = false;
        //    id79.Visible = false;
        //    id80.Visible = false;
        //    id81.Visible = false;
        //    id82.Visible = false;
        //    id83.Visible = false;
        //    id84.Visible = false;
        //    id85.Visible = false;
        //    id86.Visible = false;
        //    id32.Visible = false;
        //    li_adjust.Visible = false;
        //    li_itemadjust.Visible = false;
        //    li_receive.Visible = false;
        //    li_receivelist.Visible = false;

        //}
       



        //else if (Session["saletype"].ToString() == "Admin" || Session["Usertype"].ToString() == "SAdmin")
        //{
        //    Master.Visible = true;
        //    Service.Visible = true;
        //    SpareParts.Visible = true;
        //    Admin.Visible = true;
        //    Vehicle.Visible = true;
        //}



        else if (Session["saletype"].ToString() == "Service_Spareparts" && branch == "Paradeep" && Session["id"].ToString() == "User1")
        {
            Master.Visible = true;
            Service.Visible = true;
            SpareParts.Visible = false;
            Label3.Visible = false;

            Admin.Visible = false;
            Vehicle.Visible = false;
            Report.Visible = true;
            id78.Visible = false;
            id79.Visible = false;
            id80.Visible = false;
            id81.Visible = false;
            id82.Visible = false;
            id83.Visible = false;
            id84.Visible = false;
            id85.Visible = false;
            id86.Visible = false;
            id32.Visible = false;
            li_adjust.Visible = false;
            //  li18.Visible = false;

            li_itemadjust.Visible = false;
            li_receive.Visible = false;
            li_receivelist.Visible = false;
            li_status.Visible = false;

        }

        else if (Session["saletype"].ToString() == "Service_Spareparts" && branch == "Paradeep" && Session["id"].ToString() == "User2")
        {
            Master.Visible = true;
            Service.Visible = true;
            SpareParts.Visible = false;
            Label3.Visible = false;

            Admin.Visible = false;
            Vehicle.Visible = false;
            Report.Visible = true;
            id78.Visible = false;
            id79.Visible = false;
            id80.Visible = false;
            id81.Visible = false;
            id82.Visible = false;
            id83.Visible = false;
            id84.Visible = false;
            id85.Visible = false;
            id86.Visible = false;
            id32.Visible = false;
            li_adjust.Visible = false;
            //  li18.Visible = false;

            li_itemadjust.Visible = false;
            li_receive.Visible = false;
            li_receivelist.Visible = false;
            li_status.Visible = false;

        }
        else if (Session["saletype"].ToString() == "Service_Spareparts" && branch == "Paradeep" && Session["id"].ToString() == "User3")
        {
            Master.Visible = true;
            Service.Visible = false;
            SpareParts.Visible = true;
            Admin.Visible = false;
            Vehicle.Visible = false;
            Report.Visible = true;
            id78.Visible = false;
            id79.Visible = false;
            id80.Visible = false;
            id81.Visible = false;
            id82.Visible = false;
            id83.Visible = false;
            id84.Visible = false;
            id85.Visible = false;
            id86.Visible = false;
            id32.Visible = false;
            li_adjust.Visible = false;
            // li18.Visible = false;

            li_itemadjust.Visible = false;
            li_receive.Visible = false;
            li_receivelist.Visible = false;
            li_status.Visible = false;

        }
        else if (Session["saletype"].ToString() == "Service_Spareparts" && branch == "Paradeep" && Session["id"].ToString() == "User4")
        {
            Master.Visible = true;
            Service.Visible = false;
            SpareParts.Visible = true;
            Admin.Visible = false;
            Vehicle.Visible = false;
            Report.Visible = true;
            id78.Visible = false;
            id79.Visible = false;
            id80.Visible = false;
            id81.Visible = false;
            id82.Visible = false;
            id83.Visible = false;
            id84.Visible = false;
            id85.Visible = false;
            id86.Visible = false;
            id32.Visible = false;
            li_adjust.Visible = false;
            //  li18.Visible = false;

            li_itemadjust.Visible = false;
            li_receive.Visible = false;
            li_receivelist.Visible = false;
            li_status.Visible = false;

        }
      
    }
}
