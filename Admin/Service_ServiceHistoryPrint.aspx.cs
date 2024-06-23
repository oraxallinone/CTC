  using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMobileModel;
using System.Data;
public partial class Admin_Form21 : System.Web.UI.Page
{
    AutoMobileEntities db = new AutoMobileEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Session["Rgno"] == null && Session["enginee"] == null)
            {
                Response.Write("<script>alert('Your Session Time is Expired..!! Login to continue..!!')</script>");
                Response.Redirect("../SessionExpired.aspx");
            }
           
            string Branch = Session["Branch"].ToString();

            var branchnm = from c in db.AME_Branch_Creation.Where(t => t.Branch_Name == Branch) select c;
            lblbranchaddress.Text = branchnm.First().Branch_Address;
            lblphno.Text = branchnm.First().Branch_PhoneNo;
            lblemail.Text = branchnm.First().Branch_Email;
            lbltinno.Text = branchnm.First().Branch_TIN;
            fillpaymemtdetails();
            
            Session["Rgno"] = null;
            Session["enginee"] = null;
        }
    }

    

    public void fillpaymemtdetails()
    {
        if (Session["enginee"] != null)
        {
            try
            {
                string Branch = Session["Branch"].ToString();
                string registno = Session["enginee"].ToString();
                string param = "@enginee,@Branch";

                string paramvalue = registno + "," + Branch;

                DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_JCSpareServiceHistoryenginee", param, paramvalue);
                DataTable dtr_JCNO = smitaDbAccess.SPReturnDataTable("sp_JCSpareServiceHistory_enginee_Jobcard", param, paramvalue);
                if (Convert.ToInt32(dtr.Rows.Count) > 0)
                {
                    lblpartyname.Text = dtr.Rows[0]["Mc_Name"].ToString();
                    lblmodel.Text = dtr.Rows[0]["Mv_ModelName"].ToString();
                    lbladdress.Text = dtr.Rows[0]["Mc_Address"].ToString();
                    lblengno.Text = dtr.Rows[0]["JC_Engineno"].ToString();
                    lblregno.Text = dtr.Rows[0]["JC_Regno"].ToString();
                    lblchessno.Text = dtr.Rows[0]["JC_Chassisno"].ToString();
                    if (dtr.Rows[0]["JC_SaleDate"].ToString() == null || dtr.Rows[0]["JC_SaleDate"].ToString() == "")
                    {
                        lbldateofsale.Text = "";
                    }
                    else
                    {
                        lbldateofsale.Text = Convert.ToDateTime(dtr.Rows[0]["JC_SaleDate"]).ToString("dd/MM/yyyy");
                    }
                    var djc = (from r in dtr_JCNO.AsEnumerable()
                               select r["JC_No"]).Distinct().ToList();
                    int[] sjc = new int[djc.Count];
                    int ind = 0;
                    foreach (var d in djc)
                    {
                        sjc[ind] = Int32.Parse(d.ToString());
                        ind = ind + 1;
                    }
                    ViewState["jcno"] = dtr.Rows[0]["JC_No"].ToString();
                    int jc = Convert.ToInt32(ViewState["jcno"]);
                    grd_spare.DataSource = dtr;
                    grd_spare.DataBind();
                    var service = from x in db.AME_Service_JobCardServiceDetails
                                  //where x.JC_No == jc
                                  where sjc.Contains(x.JC_No) && x.Branch_Name.Equals(Branch)
                                  select x;
                    //var service = from x in db.AME_Service_JobCardServiceDetails
                    //              where x.JC_No == jc
                    //              select x;
                    GridView1.DataSource = service.ToList();
                    GridView1.DataBind();
                    int jcn = 0;
                    foreach (GridViewRow gr in grd_spare.Rows)
                    {
                        Label lbljno = (Label)gr.FindControl("lbljno");
                        Label lbljdate = (Label)gr.FindControl("lbljdate");
                        Label lblbillno = (Label)gr.FindControl("lblbillno");
                        Label lblkillms = (Label)gr.FindControl("lblkillms");
                        Label lblpartno = (Label)gr.FindControl("lblpartno");
                        int rankno= Convert.ToInt32(lbljno.ToolTip);
                        //if (rankno == 1)
                        if (jcn != Convert.ToInt32(lbljno.Text))
                        {
                            lbljno.Visible = true;
                            lbljdate.Visible = true;
                            lblbillno.Visible = true;
                            lblkillms.Visible = true;
                        }
                        else
                        {
                            lbljno.Visible = false;
                            lbljdate.Visible = false;
                            lblbillno.Visible = false;
                        }
                        jcn = Convert.ToInt32(lbljno.Text);
                    }
                }

                //var branchnm = from c in db.AME_Branch_Creation.Where(t => t.Branch_Name == Branch) select c;
                //lblbranchaddress.Text = branchnm.First().Branch_Address;
                //lblphno.Text = branchnm.First().Branch_PhoneNo;
                //lblemail.Text = branchnm.First().Branch_Email;
                //lbltinno.Text = branchnm.First().Branch_TIN;
            }
            catch
            {

            }
        }
        else
        {
            try
            {
                string Branch = Session["Branch"].ToString();
                string registno = Session["Rgno"].ToString();
                string param = "@VRegno,@Branch";

                string paramvalue = registno + "," + Branch;

                DataTable dtr = smitaDbAccess.SPReturnDataTable("sp_JCSpareServiceHistory", param, paramvalue);
                DataTable dtr_JCNO = smitaDbAccess.SPReturnDataTable("sp_JCSpareServiceHistory_Jobcard", param, paramvalue);
                if (Convert.ToInt32(dtr.Rows.Count) > 0)
                {
                    lblpartyname.Text = dtr.Rows[0]["Mc_Name"].ToString();
                    lblmodel.Text = dtr.Rows[0]["Mv_ModelName"].ToString();
                    lbladdress.Text = dtr.Rows[0]["Mc_Address"].ToString();
                    lblengno.Text = dtr.Rows[0]["JC_Engineno"].ToString();
                    lblregno.Text = dtr.Rows[0]["JC_Regno"].ToString();
                    lblchessno.Text = dtr.Rows[0]["JC_Chassisno"].ToString(); 
                    if (dtr.Rows[0]["JC_SaleDate"].ToString() == null || dtr.Rows[0]["JC_SaleDate"].ToString() == "")
                    {
                        lbldateofsale.Text = "";
                    }
                    else
                    {
                        lbldateofsale.Text = Convert.ToDateTime(dtr.Rows[0]["JC_SaleDate"]).ToString("dd/MM/yyyy");
                    }
                    var djc = (from r in dtr_JCNO.AsEnumerable()
                               select r["JC_No"]).Distinct().ToList();
                     int[] sjc = new int[djc.Count];
                    int ind = 0;
                    foreach(var d in djc)       
                    {
                    sjc[ind] = Int32.Parse(d.ToString());
                    ind = ind + 1;
                    }
                   
                    //List<object> temp = dtr.AsEnumerable().Distinct().ToList<object>();
                  
                    ViewState["jcno"] = dtr.Rows[0]["JC_No"].ToString();
                    int jc = Convert.ToInt32(ViewState["jcno"]);
                    grd_spare.DataSource = dtr;
                    grd_spare.DataBind();
                    var service = from x in db.AME_Service_JobCardServiceDetails
                                  //where x.JC_No == jc
                                  where sjc.Contains(x.JC_No) && x.Branch_Name.Equals(Branch)
                                  select x;
                    //var service = from x in db.AME_Service_JobCardServiceDetails
                    //              where x.JC_No == jc
                    //              select x;
                    GridView1.DataSource = service.ToList();
                    GridView1.DataBind();
                    int jcn = 0;
                    foreach (GridViewRow gr in grd_spare.Rows)
                    {

                        Label lbljno = (Label)gr.FindControl("lbljno");
                        Label lbljdate = (Label)gr.FindControl("lbljdate");
                        Label lblbillno = (Label)gr.FindControl("lblbillno");
                        Label lblkillms = (Label)gr.FindControl("lblkillms");
                        Label lblpartno = (Label)gr.FindControl("lblpartno");
                        
                        int rankno = Convert.ToInt32(lbljno.ToolTip);

                        if (jcn != Convert.ToInt32(lbljno.Text))
                        {
                            lbljno.Visible = true;
                            lbljdate.Visible = true;
                            lblbillno.Visible = true;
                            lblkillms.Visible = true;
                        }
                        else
                        {
                            lbljno.Visible = false;
                           // lbljdate.Visible = false;
                            lblbillno.Visible = false;
                        }
                        //if (rankno == 1)
                        //{
                        //    lbljno.Visible = true;
                        //    lbljdate.Visible = true;
                        //    lblbillno.Visible = true;
                        //    lblkillms.Visible = true;
                        //}
                        //else
                        //{
                        //    lbljno.Visible = false;
                        //    lbljdate.Visible = false;
                        //    lblbillno.Visible = false;
                        //}
                        jcn = Convert.ToInt32(lbljno.Text);

                    }
                }

                //var branchnm = from c in db.AME_Branch_Creation.Where(t => t.Branch_Name == Branch) select c;
                //lblbranchaddress.Text = branchnm.First().Branch_Address;
                //lblphno.Text = branchnm.First().Branch_PhoneNo;
                //lblemail.Text = branchnm.First().Branch_Email;
                //lbltinno.Text = branchnm.First().Branch_TIN;
            }
            catch
            {

            }
        }
    }
   
    
   
}