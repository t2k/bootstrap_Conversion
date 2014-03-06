using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.Security;
using System.Web.UI;

using System.Web.UI.WebControls;
using VB;
using CS;



public partial class KYC_ChangeOwner : System.Web.UI.Page
{
    private KYCEntities ctx;
    private CS.UserProfileEntities ctx2;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            
        }
    }


    /// <summary>
    /// button1 click handles the Search data request
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        int id;

        bool result = int.TryParse(tb_KYCID.Value, out id);

        if (result)
        {
            hfKYCID.Value= id.ToString();

            ctx = new KYCEntities();
            ctx2 = new UserProfileEntities();


            var custDetail = (from p in ctx.CUSTDetails
                              where p.ID == id
                              select new
                              {
                                  p.ID,
                                  p.AccountMgr,  // xn####
                                  p.LName
                              }).FirstOrDefault();

            var custUniv = (from c in ctx.CUSTUniversals
                            where c.ID == id
                            select new
                            {
                                c.ID,
                                c.FullName,
                                c.Owner
                            }).FirstOrDefault();

            if (custUniv!=null && id == custUniv.ID)
            {

                kycid.Text= string.Format("{0}", id);
                custname.Text = string.Format("{0}", custUniv.FullName);
                owner.Text = string.Format("{0}", custUniv.Owner);
                accmgr.Text = string.Format("{0}", custDetail.AccountMgr);
                mgrname.Text = DZUserProfile.GetUserProfile(custDetail.AccountMgr).FullName;
                ddl_dept.Items.Clear();
                ddl_dept.Items.Add("[???]");
                ddl_dept.DataSource = from x in ctx2.Departments orderby x.DepartmentName select x.DepartmentName;
                ddl_dept.DataBind();
                ddl_mgr.Items.Clear();
                lbl_Error.Visible = false;
                Panel2.Visible = true;
            }
            else
            {
                Panel2.Visible = false;
                lbl_Error.InnerText = string.Format("KYCID: {0} was not found!", id);
                lbl_Error.Visible = true;
            }
            
        }

        else
        {
            Panel2.Visible = false;
        }
    }

    protected void ddl_dept_SelectedIndexChanged(object sender, EventArgs e)
    {
        string dpt = ddl_dept.SelectedValue;
        
        var qry = (from MembershipUser u in Membership.GetAllUsers() where u.IsApproved==true && DZUserProfile.GetUserProfile(u.UserName).Department== dpt select u);

        var qry2 = from p in qry select new {
            ID = p.UserName,
            Name = DZUserProfile.GetUserProfile(p.UserName).AbbrName
        };
        //lblSelect.Text = dpt;
        ddl_mgr.DataSource = qry2;
        ddl_mgr.DataBind();

    }

    /// <summary>
    /// Parse out new manager and owner from selected listboxes and update 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        // make sure the user has changed something..
        if (ddl_mgr.SelectedIndex >= 0)
        {

            char[] c = new char[] { ',' };
            char[] c2 = new char[] { '=' };

            int id;

            bool result = int.TryParse(hfKYCID.Value, out id);

            // parse the hiddenfield from the viewstate back into an integer, this should never fail...
            if (result)
            {
                string selmgr = ddl_mgr.SelectedValue;
                // parse this  getting XN###
                // { ID = XN######, NAME= J JONES }

                string mgrID = selmgr.Split(c)[0].Split(c2)[1].Trim();
                string owner = ddl_dept.SelectedValue;

                KYCEntities ctx = new KYCEntities();

                var recCUSTUNIV = (from r in ctx.CUSTUniversals
                                   where r.ID == id
                                   select r).First();

                recCUSTUNIV.Owner = owner;

                var recCUSTDET = (from r in ctx.CUSTDetails
                                  where r.ID == id
                                  select r).First();

                recCUSTDET.AccountMgr = mgrID;


                ctx.SaveChanges();


                lbl_Error.InnerText = string.Format("Updated: KYCID {0}, New OWNER {1},  NEW Account Manager {2}", id, owner, mgrID); // "Saved";
                lbl_Error.Visible = true;
                Panel2.Visible = false;
            }

        }
        else
        {
            lbl_Error.InnerText = "Select a New Account Manager"; // "Saved";
            lbl_Error.Visible = true;

        }

    }
}