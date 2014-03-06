<%@ Page Language="VB" MasterPageFile="~/MasterPageTBS.master" AutoEventWireup="false"
    CodeFile="AcctOpenUniversal.aspx.vb" Inherits="AccountAddPage" Title="KYC - Universal Account Manager"
    StylesheetTheme="TBS" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cp2" runat="Server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="cp1" runat="Server">
    <div class="container-fluid">
        <div class="row-fluid">
            <h1>
                <abbr class="initialism" title="Know Your Customer!">
                    KYC</abbr><small> - Universal Account Manager</small></h1>
            <hr />
        </div>

        <div class="row-fluid">
            <asp:BulletedList ID="navPageBL" runat="server" CssClass="nav nav-tabs" Font-Bold=true DisplayMode="LinkButton">
                <asp:ListItem Text="Edit-Accounts"></asp:ListItem>
                <asp:ListItem Text="Create New-Account"></asp:ListItem>
            </asp:BulletedList>
        </div>
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="editView" runat="server">
            <div class=well>
                <div class="row-fluid" >
                    <div class=span12>
                        <div class="form-search well">
                            <asp:TextBox ID="Search" runat="server" CssClass="input-medium search-query" AutoPostBack="true" ToolTip="Input wildcard search then hit [Tab] or [Enter]"
                                    placeholder="account name"></asp:TextBox>
                            <button type="submit" class="btn btn-mini btn-primary">Search</button>
                        </div>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class=span12>
                        <asp:ListView ID="ListView1" runat="server" DataKeyNames="ID" InsertItemPosition="None"
                            DataSourceID="odsLast12">
                            <LayoutTemplate>
                                <table class='table table-bordered'>
                                    <thead>
                                         <tr id="layoutHeader" runat="server" >
                                            <th>
                                            </th>
                                            <th>
                                                <asp:LinkButton runat="server" ID="SortByOwner" CommandName="Sort" CommandArgument="Owner"
                                                    Text="Owner"></asp:LinkButton>
                                            </th>
                                            <th>
                                                <asp:LinkButton runat="server" ID="LinkButton1" CommandName="Sort" CommandArgument="FullName"
                                                    Text="Account Name"></asp:LinkButton>
                                            </th>
                                            <th>
                                                <asp:LinkButton runat="server" ID="LinkButton2" CommandName="Sort" CommandArgument="CustStatus"
                                                    Text="Account Status"></asp:LinkButton>
                                            </th>
                                            <th>
                                                <asp:LinkButton runat="server" ID="LinkButton3" CommandName="Sort" CommandArgument="KYCStatus"
                                                    Text="KYC"></asp:LinkButton>
                                            </th>
                                            <th>
                                                <asp:LinkButton runat="server" ID="LinkButton4" ToolTip="Credit Work-Flow System" CommandName="Sort" CommandArgument="CreditStatus"
                                                    Text="Credit"></asp:LinkButton>
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr id="itemPlaceholder" runat="server"></tr>
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td class="command">
                                        <asp:LinkButton ID="btnEdit" runat="server" CssClass="btn btn-info btn-mini" Text="Details" ToolTip="Edit details for this account"
                                            CommandName="Edit" />
                                    </td>
                                    <td>
                                        <asp:HiddenField ID="HF1" runat="server" Value='<%#Eval("ID")%>' />
                                        <%#Eval("Owner")%>
                                    </td>
                                    <td>
                                        <%#Eval("FullName")%>
                                    </td>
                                    <td>
                                        <span><%#Eval("CustStatus")%></span>
                                    </td>
                                    <td>
                                        <span><%#Eval("KYCStatus")%></span>
                                    </td>
                                    <td>
                                        <span><%#Eval("CreditStatus")%></span>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                            </EmptyDataTemplate>
                            <EditItemTemplate>
                                <tr>
                                    <td>
                                        <button class="btn btn-info btn-mini disabled">Details</button>
                                    </td>
                                    <td>
                                        <%#Eval("Owner")%>
                                    </td>
                                    <td>
                                        <%#Eval("FullName")%>
                                    </td>
                                    <td>
                                        <%#Eval("CustStatus")%>
                                    </td>
                                    <td>
                                        <%#Eval("KYCStatus")%>
                                    </td>
                                    <td>
                                        <%#Eval("CreditStatus")%>
                                    </td>
                                </tr>
                                <tr class=warning >
                                    <td colspan=6>
                                        <table class="table table-bordered">
                                                <tr>
                                                    <td>
                                                        <strong>ID</strong>
                                                    </td>
                                                    <td colspan=5>
                                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <strong>Account Name</strong>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="TextBoxFullName" runat="server" CssClass="input-block-level" Text='<%# Bind("FullName") %>' />
                                                        <asp:RequiredFieldValidator ID="EditAcctNameValidator" runat="server" ControlToValidate="TextBoxFullName"
                                                            ErrorMessage="<div>Account Name cannot be left blank.</div>" SetFocusOnError="true"
                                                            Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <strong>Owner</strong>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="LabelOwner" runat="server" Text='<%# Eval("Owner") %>' />
                                                    </td>
                                                    <td>
                                                        <strong>Account Status</strong>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="dlCustStatus" runat="server" SelectedValue='<%# Bind("CustStatus") %>'
                                                            CssClass=text-medium >
                                                            <asp:ListItem>Active</asp:ListItem>
                                                            <asp:ListItem>Inactive</asp:ListItem>
                                                            <asp:ListItem>Auto-Closed</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <strong>Open By</strong>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="OpenBy" runat="server" Text='<%# Eval("AcctOpenBy") %>' />
                                                    </td>
                                                    <td>
                                                        <strong>Open Date</strong>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="OpenDate" runat="server" Text='<%# Eval("AcctOpenDate", "{0:d}") %>' />
                                                    </td>
                                                    <td>
                                                        <strong>Edit By</strong>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="EditBy" runat="server" Text='<%# Eval("EditBy") %>' />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <strong>Edit Date</strong>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="EditDate" runat="server" Text='<%# Eval("EditDate", "{0:d}") %>' />
                                                    </td>
                                                    <td colspan=4>
                                                        <asp:Button ID="ButtonCompliance" runat="server" Visible=false Text="Open/Close" CssClass="btn btn-warning btn-small" OnClientClick="return confirm('Click OK to open/close acct.')" OnClick="btnOpenClose"></asp:Button>
                                                    </td>
                                                </tr>
                                            </table>
                                    </td>
                                </tr>
                                <tr class=info >
                                    <td colspan=6>
                                        <div class=form-inline >
                                            <asp:LinkButton ID=btnSyncBPName runat=server Text="Sync BPName" class="btn btn-mini btn-inverse" ToolTip="Copy/Sync SAP Account Name" CommandName=SyncBPName
                                                CommandArgument='<%# Eval("ID") %>' />
                                            <asp:LinkButton ID=btnSave runat=server Text=Save CssClass="btn btn-mini btn-success" CommandName=Update />
                                            
                                            <asp:LinkButton ID=btnCancel runat=server CommandName=Cancel CssClass="btn btn-mini btn-warning" Text=Cancel
                                                CausesValidation=false></asp:LinkButton>

                                            &nbsp;<asp:Label ID=editError runat=server></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                            </InsertItemTemplate>
                        </asp:ListView>
                    </div>
                </div>
            </div>
            </asp:View>
            <asp:View ID="createView" runat="server">
                <div class='well'>
                    <div class=row-fluid>
                        <div class=span12>
                            <h3 class=muted>KYC New Account</h3> 
                        </div>
                    </div>
                    <div class=row-fluid style="min-height: 12em;">
                        <div class=form-inline>
                            <div class=input-append>
                                <asp:TextBox ID="newAccountProposed" placeholder='Proposed account name...' runat="server" CssClass="input-large" />
                                <button id=btnLookup runat=server title="click here to validate proposed account name" onserverclick="OnAccountNameLookup" class='btn btn-warning'>Lookup</button>
                                <asp:DropDownList ID="ddlOwnerDept" runat="server" CssClass="input-small" ToolTip="Select Owner/Dept" AutoPostBack="true">
                                    <asp:ListItem>...</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="accountNameConflicts" runat="server" CssClass="input-xxlarge" Visible=false ToolTip="Conflicts (10 max)" >
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class=row-fluid>
                        <asp:panel ID=lookupSuccess runat=server Visible=false CssClass="alert alert-block alert-success">
                            <button type="button" class="close" data-dismiss="alert">&times;</button>
                            <h4>Lookup Success! </h4>
                            <span>The proposed account name does not conflict.  Press <span class="label label-important">Save Changes</span> to create account.</span>
                        </asp:panel>

                        <asp:panel ID=lookupWarning runat=server Visible=false CssClass="alert alert-block alert-warning">
                            <button type="button" class="close" data-dismiss="alert">&times;</button>
                            <h4>Warning! </h4>
                            <span> proposed account name has conflicts...</span>
                        </asp:panel>
                    </div>
                    <div class=row-fluid>
                        <div class="form-actions">
                            <asp:LinkButton ID="btnInsertNewAcct" runat="server" CssClass="btn btn-danger" Visible=false ToolTip="and open proposed account"
                                Text="Save Changes" ></asp:LinkButton>
                            <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn" 
                                Text="Cancel"></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </asp:View>
            <asp:View ID="cantCreateView" runat="server">
                <div class="alert alert-block">
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                    <h4>Warning!</h4>
                    New accounts can only be created by designated Account Managers
                </div>
            </asp:View>
            <asp:View ID="errorview" runat="server">
                <div class="alert alert-block alert-error">
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                    <h4>Error!</h4>
                    <asp:Label ID=labelError runat=server></asp:Label>
                </div>
            </asp:View>
            <asp:View ID="success" runat="server">
                <div class="alert alert-block alert-success">
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                    <h4>Success!</h4>
                    <asp:Label ID=labelSuccess runat=server></asp:Label>
                </div>
            </asp:View>
        </asp:MultiView>
        <span class="alert-info"><asp:Label ID="EditError" runat="server" ForeColor="Red" /></span>    
    </div>
    <asp:HiddenField ID="hfOwner" runat="server" />
    <asp:HiddenField ID="hfCustID" runat="server" />
    <asp:HiddenField ID="hfSearch" runat="server" />
    <asp:HiddenField ID="hfDeptEdit" runat="server" />
    <asp:HiddenField ID="hfDept" runat="server" />
    <asp:HiddenField ID="hfEditBy" runat="server" />
    <asp:HiddenField ID="hfID" runat="server" />
    <asp:ObjectDataSource ID=odsLast12 runat=server SelectMethod=GetDataByRecent TypeName="CustTableAdapters.CUSTUniversalTableAdapter"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete"
        InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByOwner"
        TypeName="CustTableAdapters.CUSTUniversalTableAdapter" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_ID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="FullName" Type="String" />
            <asp:Parameter Name="AcctOpenDate" Type="DateTime" />
            <asp:Parameter Name="AcctOpenBy" Type="String" />
            <asp:Parameter Name="Owner" Type="String" />
            <asp:Parameter Name="EditDate" Type="DateTime" />
            <asp:Parameter Name="EditBy" Type="String" />
            <asp:Parameter Name="KYCStatus" Type="String" />
            <asp:Parameter Name="CreditStatus" Type="String" />
            <asp:Parameter Name="CustStatus" Type="String" />
            <asp:Parameter Name="Original_ID" Type="Int32" />
        </UpdateParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="hfOwner" Name="hfOwner" PropertyName="Value" Type="String" />
            <asp:ControlParameter ControlID="hfSearch" Name="hfSearch" PropertyName="Value" Type="String" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="FullName" Type="String" />
            <asp:Parameter Name="AcctOpenDate" Type="DateTime" />
            <asp:Parameter Name="AcctOpenBy" Type="String" />
            <asp:Parameter Name="Owner" Type="String" />
            <asp:Parameter Name="EditDate" Type="DateTime" />
            <asp:Parameter Name="EditBy" Type="String" />
            <asp:Parameter Name="KYCStatus" Type="String" />
            <asp:Parameter Name="CreditStatus" Type="String" />
            <asp:Parameter Name="CustStatus" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>  
</asp:Content>
