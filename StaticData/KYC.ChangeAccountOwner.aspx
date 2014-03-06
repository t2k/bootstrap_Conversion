<%@ Page Title="KYC Change Account Owner" Language="C#" MasterPageFile="~/MasterPageTBS.master"
    AutoEventWireup="true" CodeFile="KYC.ChangeAccountOwner.aspx.cs" Inherits="KYC_ChangeOwner" StylesheetTheme="TBS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cp2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp1" runat="Server">
    <div class="container-fluid">
        <div class="row-fluid form-search">
            <h1>
                <abbr class=initialism title = "Know Your Customer">KYC</abbr><small> - Change Account Ownership</small> 
            </h1>
            <hr />
            <div class="input-append">
                <p>
                <input type="text" placeholder="KYCID" runat="server" id="tb_KYCID" autofocus class="input-mini search-query" />
                <button id="Button1" type="submit"  onserverclick=Button1_Click  class="btn btn-primary" runat=server ><i class="icon-search icon-white"></i> Search</button>
                </p>
            </div>
            <span class="label label-warning" id="lbl_Error" runat="server"  visible="false">
            </span>

        </div>
        <div id="Panel2" class="row-fluid" runat="server"  visible=false >
            <div class="row-fluid form-horizontal">
                <div class="well well-small span6">
                    <fieldset>
                        <legend><span class="label label-info">Existing Account Ownership</span></legend>
                        <div class="control-group">
                            <label class="control-label">
                                KYCID</label>
                            <div class="controls">
                                <asp:Label ID="kycid" CssClass="input-mini uneditable-input" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">
                                Customer</label>
                            <div class="controls">
                                <asp:Label ID="custname" CssClass="input uneditable-input" runat="server" ToolTip="Know your Customer!"></asp:Label>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">
                                Owner</label>
                            <div class="controls">
                                <asp:Label ID="owner" CssClass="input-mini uneditable-input" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">
                                Account Manager ID</label>
                            <div class="controls">

                                <asp:Label ID="accmgr" CssClass="input-mini uneditable-input" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">
                                Manager Name</label>
                            <div class="controls">
                                <asp:Label ID="mgrname" CssClass="input uneditable-input" runat="server"></asp:Label>
                            </div>
                        </div>
                    </fieldset>
                </div>
                <div class="well well-small span6">
                    <fieldset>
                        <legend><span class="label label-warning">New Account Ownership</span></legend>
                        <div class="control-group">
                            <label class="control-label">
                                <span class=label>Select Owner</span></label>
                            <div class="controls">
                                <div class="input-prepend">
                                    <span class="add-on"><i class="icon-tasks"></i> </span>
                                    <asp:DropDownList ID="ddl_dept" runat="server" CssClass="input-small" AutoPostBack="True"
                                        AppendDataBoundItems="true" OnSelectedIndexChanged="ddl_dept_SelectedIndexChanged" >
                                    </asp:DropDownList>

                                </div>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">
                            <span class=label>Select Manager</span></label>
                            <div class="controls">
                                <div class="input-prepend">
                                    <span class="add-on"><i class=" icon-question-sign"></i> </span>
                                    <asp:DropDownList ID="ddl_mgr" CssClass="input-xlarge" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
            <div class=row-fluid>
                <hr />
                <div class="span2 offset8">
                        <button id="ButtonSave" type="submit"  onserverclick=ButtonSave_Click value="Save" class="btn btn-danger btn-block" runat=server ><i class="icon-ok-sign icon-white"></i> Save</button>
                </div>

            </div>
            
        </div>
    </div>
    <asp:HiddenField ID="hfKYCID" runat="server" />
</asp:Content>
