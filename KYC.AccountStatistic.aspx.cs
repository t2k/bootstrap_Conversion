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
public partial class KYC_AccountStatistics : System.Web.UI.Page
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
            ddl_mgr.SelectedIndex =0;
            this.ddl_mgr_SelectedIndexChanged(this, e);
            //AccountStats("%");
            //showMsg(string.Format("all-departments. - {0:T}",System.DateTime.Now));
        }
        
    }

    protected void showMsg(string _msg)
    {
        info.InnerText = string.Format("KYC Statistics Report completed for {0}", _msg); //findCount, DZUserProfile.GetUserProfile(mgrID).FullName);
        info.Visible = true;
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
        if (ddl_mgr.SelectedIndex == 0)
        {
            AccountStats("%");
            showMsg(string.Format("{0}. - {1:f}","All Departments", DateTime.Now));

        } 
        else
        {
            AccountStats(ddl_mgr.SelectedValue);
            showMsg(string.Format("{0}. - {1:f}", ddl_mgr.SelectedItem.Text, DateTime.Now));
        }
    }


    protected void AccountStats(string _dept)
    {
        CustTableAdapters.CUSTCountTableAdapter taCount = new CustTableAdapters.CUSTCountTableAdapter();

        var rowCount1 = taCount.GetData(_dept).Count;

        var rowRatingDenominator = taCount.RatingDenominator(_dept).Count;

        var rowCount2 = taCount.Approval(_dept).Count;

        //this.Table1.Rows[2].Cells[6].Text = rowCount2.ToString();
        //dtCount2.Count
        if (rowCount1 > 0)
        {
            // compliance pending approval
            this.Compliance.Rows[3].Cells[2].Text = string.Format("{0:P1}", (double)rowCount2 / rowCount1);
            //this.Table1.Rows[3].Cells[6].Text = string.Format("{0:P1}",  (double)rowCount2 / rowCount1);
            //dtCount2.Count / dtCount1.Count)
        }
        else
        {
            this.Compliance.Rows[3].Cells[2].Text = string.Format("{0:P1}", 0);
            //this.Table1.Rows[3].Cells[6].Text = string.Format("{0:P1}", 0);
        }
       

        var rowCount3 = taCount.Approved(_dept).Count;
        //compliace approved count
        //this.Table1.Rows[2].Cells[8].Text = rowCount3.ToString();
        this.Compliance.Rows[2].Cells[4].Text = rowCount3.ToString();

        // dtCount3.Count
        // dtCount1.Count > 0 Then
        if (rowCount1 > 0)
        {
            // compliance approved %
            //this.Table1.Rows[3].Cells[8].Text = string.Format("{0:P1}", (double)rowCount3 / rowCount1);
            this.Compliance.Rows[3].Cells[4].Text = string.Format("{0:P1}", (double)rowCount3 / rowCount1);
        }
        else
        {
            // avoid div by zero
            //this.Table1.Rows[3].Cells[8].Text = string.Format("{0:P1}", 0);
            this.Compliance.Rows[3].Cells[4].Text = string.Format("{0:P1}", 0);
        }


        var rowCount4 = taCount.Complete(_dept).Count();
        // acct opening stat count
        //this.Table1.Rows[2].Cells[4].Text = rowCount4.ToString();
        this.AcctOpening.Rows[2].Cells[4].Text = rowCount4.ToString();

        if (rowCount1 > 0)
        {
            // acct opening count as %
            //this.Table1.Rows[3].Cells[4].Text = string.Format("{0:P1}", (double)rowCount4 / rowCount1);
            this.AcctOpening.Rows[3].Cells[4].Text = string.Format("{0:P1}", (double)rowCount4 / rowCount1);
        }
        else
        {
            //this.Table1.Rows[3].Cells[4].Text = string.Format("{0:P1}", 0);
            this.AcctOpening.Rows[3].Cells[4].Text = string.Format("{0:P1}", 0);
        }

        var rowCount5 = taCount.Completion(_dept).Count;
        //compliance pending completion count:
        //this.Table1.Rows[2].Cells[5].Text = rowCount5.ToString();
        this.Compliance.Rows[2].Cells[1].Text = rowCount5.ToString();
        if (rowCount1 > 0)
        {
            //this.Table1.Rows[3].Cells[5].Text = string.Format("{0:P1}", (double)rowCount5 / rowCount1);
            this.Compliance.Rows[3].Cells[1].Text = string.Format("{0:P1}", (double)rowCount5 / rowCount1);
        }
        else
        {
            //this.Table1.Rows[3].Cells[5].Text = string.Format("{0:P1}", 0);
            this.Compliance.Rows[3].Cells[1].Text = string.Format("{0:P1}", 0);
        }


        var rowCount6 = taCount.FAX(_dept).Count;
        // account opening pending fax count
        //this.Table1.Rows[2].Cells[3].Text = rowCount6.ToString();
        this.AcctOpening.Rows[2].Cells[3].Text = rowCount6.ToString();

        if (rowCount1 > 0)
        {
            // account opening pending fax %%%
            //this.Table1.Rows[3].Cells[3].Text = string.Format("{0:P1}", (double)rowCount6 / rowCount1);
            this.AcctOpening.Rows[3].Cells[3].Text = string.Format("{0:P1}", (double)rowCount6 / rowCount1);
        }
        else
        {
            //this.Table1.Rows[3].Cells[3].Text = string.Format("{0:P1}", 0);
            this.AcctOpening.Rows[3].Cells[3].Text = string.Format("{0:P1}", 0);
        }

        var rowCount7 = taCount.High(_dept).Count;
        // RR HIGH COUNT
        //this.Table1.Rows[2].Cells[15].Text = rowCount7.ToString();
        this.Risk.Rows[2].Cells[4].Text = rowCount7.ToString();
        if (rowRatingDenominator > 0)
        {
            //this.Table1.Rows[3].Cells[15].Text = string.Format("{0:P1}", (double)rowCount7 / rowRatingDenominator);
            this.Risk.Rows[3].Cells[4].Text = string.Format("{0:P1}", (double)rowCount7 / rowRatingDenominator);
        }
        else
        {
            //this.Table1.Rows[3].Cells[15].Text = string.Format("{0:P1}", 0);
            this.Risk.Rows[3].Cells[4].Text = string.Format("{0:P1}", 0);
        }

        var rowCount8 = taCount.Low(_dept).Count;
        // RR LOW COUNT
        //this.Table1.Rows[2].Cells[13].Text = rowCount8.ToString();
        this.Risk.Rows[2].Cells[2].Text = rowCount8.ToString();
        if (rowRatingDenominator > 0)
        {
            //this.Table1.Rows[3].Cells[13].Text = string.Format("{0:P1}", (double)rowCount8 / rowRatingDenominator);
            this.Risk.Rows[3].Cells[2].Text = string.Format("{0:P1}", (double)rowCount8 / rowRatingDenominator);
        }
        else
        {
            //this.Table1.Rows[3].Cells[13].Text = string.Format("{0:P1}", 0);
            this.Risk.Rows[3].Cells[2].Text = string.Format("{0:P1}", 0);
        }

        var rowCount9 = taCount.Medium(_dept).Count;
        // RR MED COUNT
        //this.Table1.Rows[2].Cells[14].Text = rowCount9.ToString();
        this.Risk.Rows[2].Cells[3].Text = rowCount9.ToString();
        if (rowRatingDenominator > 0)
        {
            //this.Table1.Rows[3].Cells[14].Text = string.Format("{0:P1}", (double)rowCount9 / rowRatingDenominator);
            this.Risk.Rows[3].Cells[3].Text = string.Format("{0:P1}", (double)rowCount9 / rowRatingDenominator);
        }
        else
        {
            //this.Table1.Rows[3].Cells[14].Text = string.Format("{0:P1}", 0);
            this.Risk.Rows[3].Cells[3].Text = string.Format("{0:P1}", 0);
        }

        var rowCount10 = taCount.MissingDocs(_dept).Count;
        // compliance missing docs count
        //this.Table1.Rows[2].Cells[10].Text = rowCount10.ToString();
        this.Compliance.Rows[2].Cells[6].Text = rowCount10.ToString();
        if (rowCount1 > 0)
        {
            //this.Table1.Rows[3].Cells[10].Text = string.Format("{0:P1}", (double)rowCount10 / rowCount1);
            this.Compliance.Rows[3].Cells[6].Text = string.Format("{0:P1}", (double)rowCount10 / rowCount1);
        }
        else
        {
            //this.Table1.Rows[3].Cells[10].Text = string.Format("{0:P1}", 0);
            this.Compliance.Rows[3].Cells[6].Text = string.Format("{0:P1}", 0);
        }

        
        var rowCount11 = taCount.NotComputed(_dept).Count;
        // RR not computed COUNT
        //this.Table1.Rows[2].Cells[12].Text = rowCount11.ToString();
        this.Risk.Rows[2].Cells[1].Text = rowCount11.ToString();
        if (rowRatingDenominator > 0)
        {
            //this.Table1.Rows[3].Cells[12].Text = string.Format("{0:P1}", (double)rowCount11 / rowRatingDenominator);
            this.Risk.Rows[3].Cells[1].Text = string.Format("{0:P1}", (double)rowCount11 / rowRatingDenominator);
        }
        else
        {
            //this.Table1.Rows[3].Cells[12].Text = string.Format("{0:P1}", 0);
            this.Risk.Rows[3].Cells[1].Text = string.Format("{0:P1}", 0);
        }


        var rowCount12 = taCount.Ref(_dept).Count;
        // Acct Opening Pending REF: COUNT
        //this.Table1.Rows[2].Cells[2].Text = rowCount12.ToString();
        this.AcctOpening.Rows[2].Cells[2].Text = rowCount12.ToString();
        if (rowCount1 > 0)
        {
            //this.Table1.Rows[3].Cells[2].Text = string.Format("{0:P1}", (double)rowCount12 / rowCount1);
            this.AcctOpening.Rows[3].Cells[2].Text = string.Format("{0:P1}", (double)rowCount12 / rowCount1);
        }
        else
        {
            //this.Table1.Rows[3].Cells[2].Text = string.Format("{0:P1}", 0);
            this.AcctOpening.Rows[3].Cells[2].Text = string.Format("{0:P1}", 0);
        }


        var rowCount13 = taCount.RefandFAX(_dept).Count;
        // pending ref and fax count
        //this.Table1.Rows[2].Cells[1].Text = rowCount13.ToString();
        this.AcctOpening.Rows[2].Cells[1].Text = rowCount13.ToString();
        if (rowCount1 > 0)
        {
            //this.Table1.Rows[3].Cells[1].Text = string.Format("{0:P1}", (double)rowCount13 / rowCount1);
            this.AcctOpening.Rows[3].Cells[1].Text = string.Format("{0:P1}", (double)rowCount13 / rowCount1);
        }
        else
        {
            //this.Table1.Rows[3].Cells[1].Text = string.Format("{0:P1}", 0);
            this.AcctOpening.Rows[3].Cells[1].Text = string.Format("{0:P1}", 0);
        }



        var rowCount14 = taCount.Rejected(_dept).Count;
        // Compliance REJECTED: COUNT
        //this.Table1.Rows[2].Cells[7].Text = rowCount14.ToString();
        this.Compliance.Rows[2].Cells[3].Text = rowCount14.ToString();
        if (rowCount1 > 0)
        {
            //this.Table1.Rows[3].Cells[7].Text = string.Format("{0:P1}", (double)rowCount14 / rowCount1);
            this.Compliance.Rows[3].Cells[3].Text = string.Format("{0:P1}", (double)rowCount14 / rowCount1);
        }
        else
        {
            //this.Table1.Rows[3].Cells[7].Text = string.Format("{0:P1}", 0);
            this.Compliance.Rows[3].Cells[3].Text = string.Format("{0:P1}", 0);
        }


        var rowCount15 = taCount.ReviewDate(_dept).Count;
        //  RR 90 days:COUNT
        //this.Table1.Rows[2].Cells[11].Text = rowCount15.ToString();
        this.Compliance.Rows[2].Cells[7].Text = rowCount15.ToString();
        if (rowCount1 > 0)
        {
            //this.Table1.Rows[3].Cells[11].Text = string.Format("{0:P1}", (double)rowCount15 / rowCount1);
            this.Compliance.Rows[3].Cells[7].Text = string.Format("{0:P1}", (double)rowCount15 / rowCount1);
        }
        else
        {
            //this.Table1.Rows[3].Cells[11].Text = string.Format("{0:P1}", 0);
            this.Compliance.Rows[3].Cells[7].Text = string.Format("{0:P1}", 0);
        }

        var rowCount16 = taCount.IssuerOnly(_dept).Count;
        //  Compliance SAP Only: COUNT
        //this.Table1.Rows[2].Cells[9].Text = rowCount16.ToString();
        this.Compliance.Rows[2].Cells[4].Text = rowCount16.ToString();
        if (rowCount1 > 0)
        {
            //this.Table1.Rows[3].Cells[9].Text = string.Format("{0:P1}", (double)rowCount16 / rowCount1);
            this.Compliance.Rows[3].Cells[4].Text = string.Format("{0:P1}", (double)rowCount16 / rowCount1);
            // dtCount16.Count / dtCount1.Count)
        }
        else
        {
            //this.Table1.Rows[3].Cells[9].Text = string.Format("{0:P1}", 0);
            this.Compliance.Rows[3].Cells[4].Text = string.Format("{0:P1}", 0);
        }


    }



}