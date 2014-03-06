<%@ Page Title="KYC Re-Assign Account Manager" Language="C#" MasterPageFile="~/MasterPageTBS.master"
    AutoEventWireup="true" CodeFile="KYC.ReassignAcctMgr.aspx.cs" Inherits="KYC_ChangeOwner" StylesheetTheme="TBS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cp2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp1" runat="Server">
    <div class="container-fluid">
        <div class=row-fluid>
            <h1><abbr class=initialism title="Know Your Customer">KYC</abbr><small> - Globally Re-assign Accounts Between Managers</small></h1>
            <hr />
        </div>
        <div class="row-fluid">
            <div class="span6">
                    <div class="control-group">
                        <label class="control-label">
                        <span class="label">Re-Assign Accounts From:</span>
                            </label>
                        <div class="controls">
                            <div class="input-prepend">
                                <span class="add-on"><i class=" icon-question-sign"></i> </span>
                                <asp:DropDownList ID="ddl_mgr"  AppendDataBoundItems=true CssClass=" input-xlarge" runat="server" OnSelectedIndexChanged="ddl_mgr_SelectedIndexChanged" AutoPostBack=true>
                                </asp:DropDownList>
                            </div>

                        </div>
                    </div>
            </div>
            <div class="span6">
                    <div class="control-group">
                        <label class="control-label">
                            <span class="label">Re-Assign Accounts To:</span></label>
                        <div class="controls">
                            <div class="input-prepend">
                                <span class="add-on"><i class=" icon-question-sign"></i> </span>
                                <asp:DropDownList ID="ddl_mgr2" AppendDataBoundItems=true CssClass="input-xlarge" runat="server" OnSelectedIndexChanged="ddl_mgr2_SelectedIndexChanged" AutoPostBack=true>
                                </asp:DropDownList>
                            </div>

                        </div>
                    </div>
            </div>
            <div class = row-fluid>
                <span class="label label-warning" id="info" runat="server" visible="false"></span>
            </div>
            <div class=row-fluid>
                <hr />
                <p class="span6 offset6">
                  <button id="ButtonSave" type="submit" disabled onserverclick=ButtonSave_Click value="Save" class="btn btn-danger disabled" runat=server ><i class="icon-ok-sign icon-white"></i> Re-assign Accounts</button>
                </p>
            </div>
        </div>

    </div>
</asp:Content>
