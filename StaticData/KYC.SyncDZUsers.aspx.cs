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
        Control c = (Control)(sender);
        c.Visible = false;

        var qry = (from MembershipUser u in Membership.GetAllUsers() where u.IsApproved == true select u);

        var secureUserList = (from p in qry
                   orderby p.UserName
                   select new
                   {
                       ID = p.UserName,
                       FirstName = DZUserProfile.GetUserProfile(p.UserName).FirstName,
                       LastName = DZUserProfile.GetUserProfile(p.UserName).LastName,
                       AbbrName = DZUserProfile.GetUserProfile(p.UserName).AbbrName,
                       Dept = DZUserProfile.GetUserProfile(p.UserName).Department,
                       Phone = p.Comment,
                       Email = p.Email,
                       Status = "1",
                       EmpType= "Employee"

                   }).ToList();


        var ctx = new DZUsersEntities();

        int i=0;
        int j=0;



        foreach (var validUser in secureUserList)
        {
            var dzUser = from item in ctx.BranchUsers where item.UserName == validUser.AbbrName select item;

            if (dzUser.Count() == 0)
            {
                j++;
                var newUser = new VB.BranchUser() { 
                    UserName = validUser.AbbrName,
                    FirstName = validUser.FirstName == null ? "N/A" : validUser.FirstName,
                    LastName = validUser.LastName == null ? "N/A" :validUser.LastName,
                    Dept = validUser.Dept == null ? "N/A" : validUser.Dept, 
                    XN = validUser.ID, 
                    Phone = validUser.Phone, 
                    Email = validUser.Email, 
                    Status = validUser.Status, 
                    EmpType = validUser.EmpType 
                };

                ctx.AddToBranchUsers(newUser);
            }
            else
            {
                var bUser = dzUser.First();

                i++;
                bUser.FirstName = validUser.FirstName == null ? "N/A" : validUser.FirstName;
                bUser.LastName = validUser.LastName == null ? "N/A" : validUser.LastName;
                bUser.Phone = validUser.Phone;
                bUser.Dept = validUser.Dept == null ? "N/A" : validUser.Dept;
                bUser.XN = validUser.ID.ToUpper();
                bUser.EmpType = validUser.EmpType;
                //ctx.SaveChanges();
            }
        }

        try
        {
            ctx.SaveChanges();
            this.labelMsg.Text = string.Format("DZUsers Sync was successful:  with {0} updates and {1} inserts.", i, j);
        }
        catch (Exception ex)
        {
            this.labelMsg.Text = string.Format("Error: {0}",ex.InnerException);
        }

        this.msg.Visible = true;
    }

}