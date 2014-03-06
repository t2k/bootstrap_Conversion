using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


/// <summary>
/// Masterpage built around Twitter Bootstrap CSS Framework/Scaffolding
/// </summary>
public partial class MasterPageTBS : System.Web.UI.MasterPage
{
    /// <summary>
    ///  implement WEBLOG
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // update anchor tag to show userprofile
            this.username.HRef = string.Format("/userprofile/{0}", HttpContext.Current.User.Identity.Name);
        }
    }


    /// <summary>
    /// dynamic sub-menu support
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void mainmenu_MenuItemDataBound(Object sender, MenuEventArgs e)
    {
        try
        {
            if (mainmenu.SelectedItem == null) 
            {
                if (IsNodeAncestor((SiteMapNode)e.Item.DataItem, SiteMap.CurrentNode))
                {
                    e.Item.Selected = true;
                }
            }
        }
        catch (Exception)
        {
        }
    }


    protected bool IsNodeAncestor(SiteMapNode ancestor, SiteMapNode child) {
        if (ancestor.ChildNodes != null && ancestor.ChildNodes.Contains(child)) {
            return true;
        }
        else
        {
            if (child.ParentNode != null && !object.ReferenceEquals(ancestor,child.RootNode)) {
                return IsNodeAncestor(ancestor,child.ParentNode);
            }
        }
        return false;
    }

}
