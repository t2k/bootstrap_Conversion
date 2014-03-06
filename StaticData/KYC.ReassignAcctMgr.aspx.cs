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


/// <summary>
/// Server side code:  this pages presents 2 select lists of account managers
/// the user need to select one from each list and the click a button
/// </summary>
public partial class KYC_ChangeOwner : System.Web.UI.Page
{
    private KYCEntities ctx;
    private CS.UserProfileEntities ctx2;

    /// <summary>
    /// load all account managers in the first list and init the first item...
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            var qry = (from MembershipUser u in Membership.GetAllUsers() where u.IsApproved == true 
                       select new {
                           ID = u.UserName,
                           Last = DZUserProfile.GetUserProfile(u.UserName).LastName,
                           Name = string.Format("{0}, {1}", DZUserProfile.GetUserProfile(u.UserName).LastName, DZUserProfile.GetUserProfile(u.UserName).FirstName)
                       });

            var qry2 = from p in qry
                       orderby p.Last
                       select new
                       {
                           p.ID,
                           p.Name
                       };

            //lblSelect.Text = dpt;
            ddl_mgr.Items.Add("Select the old manager");
            ddl_mgr2.Items.Add("Select the new manager");
            ddl_mgr.DataSource = qry2;
            ddl_mgr.DataBind();
            ddl_mgr2.DataBind();
        }
    }


    /// <summary>
    /// handle manager select change event...
    /// when users selects, parse the selection for XN# and then filter the second list to only load those members in the same department
    /// as the manager selected from the first list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddl_mgr_SelectedIndexChanged(object sender, EventArgs e)
    {
        char[] c = new char[] { ',' };
        char[] c2 = new char[] { '=' };
        
        string selmgr = ddl_mgr.SelectedValue;
        // parse this  getting XN###
        // { ID = XN######, NAME= J JONES }

        string mgrID = selmgr.Split(c)[0].Split(c2)[1].Trim();

        string MgrDept = DZUserProfile.GetUserProfile(mgrID).Department;

        var qry = (from MembershipUser u in Membership.GetAllUsers() where u.IsApproved == true && DZUserProfile.GetUserProfile(u.UserName).Department == MgrDept 
                   select new {
                       ID = u.UserName,
                       Last = DZUserProfile.GetUserProfile(u.UserName).LastName,
                       Name = string.Format("{0}, {1}", DZUserProfile.GetUserProfile(u.UserName).LastName, DZUserProfile.GetUserProfile(u.UserName).FirstName)
                   });

        // sort by last name
        var qry2 = from p in qry
                   orderby p.Last
                   select new
                   {
                       p.ID,
                       p.Name
                   };
    
        ddl_mgr2.Items.Clear();
        ddl_mgr2.Items.Add(string.Format("[Select new {0} Account Manager]",MgrDept));
        ddl_mgr2.DataSource = qry2;
        ddl_mgr2.DataBind();
        

        // count the # of accounts found for the selected account manager
        ctx = new KYCEntities();
        int findCount = (from cd in ctx.CUSTDetails where cd.AccountMgr == mgrID select cd).Count();

        info.InnerText = string.Format("Found {0} accounts having {1} as account manager... ", findCount, DZUserProfile.GetUserProfile(mgrID).FullName);
        info.Visible = true;
        ButtonSave.Attributes["class"] = "btn btn-danger disabled";
        ButtonSave.Disabled= true;

    }


    /// <summary>
    /// Parse out new manager and owner from selected listboxes and update our data-store
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        // make sure the user has changed something..

        if (ddl_mgr.SelectedIndex > 0 && ddl_mgr2.SelectedIndex > 0)
        {
            char[] c = new char[] { ',' };
            char[] c2 = new char[] { '=' };


            bool result = true; 

            
            if (result)
            {
                string selmgr = ddl_mgr.SelectedValue;
                string selmgr2 = ddl_mgr2.SelectedValue;
                // parse this  getting XN###
                // { ID = XN######, NAME= J JONES }

                string mgrID = selmgr.Split(c)[0].Split(c2)[1].Trim();
                string mgrID2 = selmgr2.Split(c)[0].Split(c2)[1].Trim();

                // change custdetail records replace AccountMgr field replace mgrID with mgrID2
                try
                {
                    KYCEntities ctx = new KYCEntities();
                    var qry = from cd in ctx.CUSTDetails where cd.AccountMgr == mgrID select cd;

                    foreach (CUSTDetail row in qry)
                    {
                        row.AccountMgr = mgrID2;
                    }
                    ctx.SaveChanges();  // updates the database
                    

                    info.InnerText = string.Format("All {0} accounts were re-assigned to {1}.", DZUserProfile.GetUserProfile(mgrID).AbbrName, DZUserProfile.GetUserProfile(mgrID2).AbbrName);
                    ButtonSave.Disabled = true;  // hide the clicked button when completed successfully
                    ButtonSave.Attributes["class"] = "btn btn-danger disabled";
                    ddl_mgr.SelectedIndex = 0;
                    ddl_mgr2.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    info.InnerText = string.Format("Error {0}",ex.Message);
                }                
            }
        }

    }

    /// <summary>
    /// handle select change event in 2nd list box
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddl_mgr2_SelectedIndexChanged(object sender, EventArgs e)
    {
        ButtonSave.Disabled = true;
        if (ddl_mgr2.SelectedIndex > 0)
        {

            ButtonSave.Disabled = false;
            ButtonSave.Attributes["class"] = "btn btn-danger";

        }
    }



}