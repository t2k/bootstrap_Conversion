﻿using System;
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
public partial class KYC_CompRefMgr : System.Web.UI.Page
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            hfAbbrName.Value = DZUserProfile.GetUserProfile(Membership.GetUser().UserName).AbbrName;
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            gvGeneralFiles.AutoGenerateDeleteButton = true;
            gvGeneralFiles.AutoGenerateEditButton = true;
            gvWebsitesAll.AutoGenerateDeleteButton = true;
            gvWebsitesAll.AutoGenerateEditButton = true;

            WebUtil.MakeAccessible(gvGeneralFiles);
            WebUtil.MakeAccessible(gvWebsitesAll);
        }
    }


    protected void ondview(object sender, EventArgs e)
    {
        this.dview.Attributes.Add("class", "btn btn-pill active");
        this.wview.Attributes.Add("class", "btn btn-pill");

        mv1.ActiveViewIndex = 0;
    }

    protected void onwview(object sender, EventArgs e)
    {
        this.dview.Attributes.Add("class", "btn btn-pill");
        this.wview.Attributes.Add("class", "btn btn-pill active");
        mv1.ActiveViewIndex = 1;
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            

        }

    }


    

    protected void OnStoreWebsite(object sender, EventArgs e)
    {

        CustTableAdapters.ReferenceExternalGeneralTableAdapter ta1 = new CustTableAdapters.ReferenceExternalGeneralTableAdapter();
        Cust.ReferenceExternalGeneralDataTable dt1 = new Cust.ReferenceExternalGeneralDataTable();
        Cust.ReferenceExternalGeneralRow row1 = dt1.NewReferenceExternalGeneralRow();

        if (this.WebSiteDescription.Text.Length != 0) {
            row1.AcctID = 1;
	        row1.Link = this.WebSite.Text;
	        row1.UploadDate = System.DateTime.Now;
	        row1.UploadBy = hfAbbrName.Value;
	        row1.Description = this.WebSiteDescription.Text;
	        dt1.AddReferenceExternalGeneralRow(row1);
	        ta1.Update(dt1);
            this.gvWebsitesAll.DataBind();
            this.WebSiteDescription.Text = string.Empty;
            this.WebSite.Text = string.Empty;
            this.Label307.Text = string.Empty;
        } else {
	        this.Label307.Text = "Description Required";
	        return;
        }

    }


    protected void gvGeneralFiles_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // reference the Delete LinkButton
                LinkButton lb = (LinkButton)e.Row.Cells[0].Controls[2];
                lb.OnClientClick = string.Format("return confirm('Are you sure?')");
            }
        }
        catch (Exception)
        {
        }
    }


    protected void gvWebsitesAll_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // reference the Delete LinkButton
                LinkButton lb = (LinkButton)e.Row.Cells[0].Controls[2];
                lb.OnClientClick = string.Format("return confirm('Are you sure?')");
            }
        }
        catch (Exception)
        {
        }
    }
    

    /// <summary>
    /// preserve row values on edit
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvWebsitesAll_OnRowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        CustTableAdapters.ReferenceExternalGeneralTableAdapter ta1 = new CustTableAdapters.ReferenceExternalGeneralTableAdapter();
        Cust.ReferenceExternalGeneralDataTable dt1 = ta1.GetDataByUnique((int)(e.Keys["ID"]));
        Cust.ReferenceExternalGeneralRow row1 = dt1[0];
        e.NewValues["UploadDate"] = DateTime.Now;
        e.NewValues["UploadBy"] = hfAbbrName.Value;
        e.NewValues["Link"] = row1.Link;
    }

    /// <summary>
    /// preserve row values on edit
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvGeneralFiles_OnRowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        CustTableAdapters.ReferenceInternalGeneralTableAdapter ta1 = new CustTableAdapters.ReferenceInternalGeneralTableAdapter();
        Cust.ReferenceInternalGeneralDataTable dt1 = ta1.GetDataByUnique((int)(e.Keys["ID"]));
        Cust.ReferenceInternalGeneralRow row1 = dt1[0];
        e.NewValues["UploadDate"] = DateTime.Now;
        e.NewValues["UploadBy"] = hfAbbrName.Value;
        e.NewValues["Link"] = row1.Link;
    }

    //protected void gvGeneralFiles_OnDataBound(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    //{
    //    GridViewRow row = gvGeneralFiles.SelectedRow;
    //    CustTableAdapters.ReferenceInternalAcctTableAdapter ta1 = new CustTableAdapters.ReferenceInternalAcctTableAdapter();
    //    Cust.ReferenceInternalAcctDataTable dt1 = ta1.GetDataByUnique(this.hfID.Value, e.Keys["ID"]);
    //    Cust.ReferenceInternalAcctRow Row1 = default(Cust.ReferenceInternalAcctRow);
    //    Row1 = dt1(0);
    //    e.NewValues["UploadDate"] = System.DateTime.Today;
    //    e.NewValues["UploadBy"] = hfAbbrName.Value;
    //    e.NewValues["Link"] = Row1.Link;
    //}


    protected void OnUploadFile(object sender, EventArgs e)
    {

        DateTime myDate = DateTime.Now;

        string myDateTic = null;
        myDateTic = myDate.Ticks.ToString();
        string myFileName = null;

        try
        {
            if (this.FileUpload1.HasFile == true)
            {
                if (this.FileDescription.Text.Length != 0)
                {
                    string savePath = SiteGlobal.KYC_DOCS;
                    myFileName = "KYCGeneral" + myDateTic + "_" + this.FileUpload1.FileName;
                    FileUpload1.SaveAs(string.Format(string.Format("{0}{1}", savePath, myFileName)));

                    CustTableAdapters.ReferenceInternalGeneralTableAdapter ta2 = new CustTableAdapters.ReferenceInternalGeneralTableAdapter();
                    Cust.ReferenceInternalGeneralDataTable dt2 = new Cust.ReferenceInternalGeneralDataTable();
                    Cust.ReferenceInternalGeneralRow row2 = dt2.NewReferenceInternalGeneralRow();

                    row2.AcctID = 1;
                    row2.Link = myFileName;
                    row2.UploadDate = DateTime.Now;
                    row2.UploadBy = hfAbbrName.Value;
                    row2.Description = this.FileDescription.Text;
                    dt2.AddReferenceInternalGeneralRow(row2);
                    ta2.Update(dt2);
                    this.gvGeneralFiles.DataBind();
                    this.FileDescription.Text = string.Empty;
                    this.Label303.Attributes.Add("class", "text-success");
                    this.Label303.Text = "Upload complete.";
                }
                else
                {
                    this.Label303.Attributes.Add("class", "text-error");
                    this.Label303.Text = "File description required.";
                    return;
                }
            }
            else
            {
                Label303.Attributes.Add("class", "text-error");
                this.Label303.Text = "No file was selected to upload...";
            }

        }
        catch (Exception ex)
        {
            Label303.Attributes.Add("class", "text-error");
            this.Label303.Text = ex.Message;
        }

    }


   

    //protected void gvGeneralFiles_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    //{
    //    GridViewRow row = gvGeneralfiles.SelectedRow;
    //    CustTableAdapters.ReferenceInternalAcctTableAdapter ta1 = new CustTableAdapters.ReferenceInternalAcctTableAdapter();
    //    Cust.ReferenceInternalAcctDataTable dt1 = ta1.GetDataByUnique(this.hfID.Value, e.Keys["ID"]);
    //    Cust.ReferenceInternalAcctRow Row1 = default(Cust.ReferenceInternalAcctRow);
    //    Row1 = dt1(0);
    //    e.NewValues["UploadDate"] = System.DateTime.Today;
    //    e.NewValues["UploadBy"] = hfAbbrName.Value;
    //    e.NewValues["Link"] = Row1.Link;
    //}



    //protected void gvWebsitesByAcct_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            // reference the Delete LinkButton
    //            LinkButton lb = (LinkButton)e.Row.Cells[0].Controls[2];
    //            lb.OnClientClick = string.Format("return confirm('Are you sure?')");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

}