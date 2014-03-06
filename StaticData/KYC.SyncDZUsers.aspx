<%@ Page Title="KYC Change Account Owner" Language="C#" MasterPageFile="~/MasterPageTBS.master"
    AutoEventWireup="true" CodeFile="KYC.SyncDZUsers.aspx.cs" Inherits="KYC_ChangeOwner" StylesheetTheme="TBS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cp2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp1" runat="Server">
    <div class="container-fluid">
        <div class="row-fluid form-search">
            <h1>
                <abbr class=initialism title = "Know Your Customer">KYC</abbr><small> - Sync BranchUser table w/.NET User data (for KYC reporting) </small> 
            </h1>
            <p>
                <button id="Button1" type="submit"  onserverclick=Button1_Click title="Ensure DZUsers table is synced with User profile database (Fixes when KYC AcctMgr/CreditMgr is not showing up on reports)" class="btn btn-primary" runat=server ><i class="icon-search icon-white"></i> Sync DZ Users Table</button>
            </p>
            
            <asp:Panel ID=msg runat=server CssClass="alert alert-block" Visible=false>
              <button type="button" class="close" data-dismiss="alert">&times;</button>
              <h4>Warning!</h4>
              <asp:Label ID=labelMsg runat=server></asp:Label>
            </asp:Panel>

        </div>

    </div>
    <asp:HiddenField ID="hfKYCID" runat="server" />
</asp:Content>
