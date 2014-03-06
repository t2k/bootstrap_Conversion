<%@ Page Title="Compliance Reference Manager" Language="C#" MasterPageFile="~/MasterPageTBS.master"
    AutoEventWireup="true" CodeFile="KYC.ComplianceRefs.aspx.cs" Inherits="KYC_CompRefMgr"
    StylesheetTheme="TBS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cp2" runat="Server">
    <style>
        .btn.btn-pill
        {
            background-color: transparent;
            background-image: none;
            color: #0088cc;
            cursor: pointer;
            border-color: transparent;
            -webkit-box-shadow: none;
            -moz-box-shadow: none;
            box-shadow: none;
        }
        
        .btn.btn-pill:hover
        {
            color: #005580;
            background-color: #EEE;
        }
        
        .btn.btn-pill:active, .btn.btn-pill.active
        {
            background-color: #0088cc;
            color: #fff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp1" runat="Server">
    <div class="container-fluid">
        <div class="row-fluid">
            <h1>
                <abbr class="initialism muted" title="Know Your Customer">
                    KYC</abbr><small> - Compliance Reference Manager</small></h1>
            <hr />
        </div>
        <div class="row-fluid">
        </div>
        <div class="nav nav-pills">
            <button class="btn btn-pill active" id="dview" runat="server" onserverclick="ondview">
                Documents</button>
            <button class="btn btn-pill" id="wview" runat="server" data-toggle="pill" onserverclick="onwview">
                Websites</button>
        </div>
        <div class="row-fluid">
        </div>
        <div class="row-fluid">
            <asp:MultiView ID="mv1" runat="server" ActiveViewIndex="0">
                <asp:View ID="view1" runat="server">
                    <asp:UpdatePanel ID="udp1" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <div class=well>
                                <p class='lead muted'>
                                    <strong>Attach a file to the KYC general document register:</strong>
                                </p>
                                <p>
                                    <asp:TextBox ID="FileDescription" runat="server" placeholder="File description (required)" CssClass="input-large"></asp:TextBox>
                                </p>
                                <p>
                                    <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="Select a file to upload (1 at a time)" />
                                </p>
                                <p>
                                    <asp:LinkButton ID="UploadFile" OnClick=OnUploadFile runat="server" CssClass="btn btn-danger btn-small"
                                        PostBackUrl="" Text="Add File" ToolTip="Upload and attach selected document."
                                        UseSubmitBehavior="True" />
                                    &nbsp;<asp:Label ID="Label303" runat="server"></asp:Label>
                                </p>
                            </div>
                            <div>
                                <asp:GridView ID="gvGeneralFiles" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    DataKeyNames="ID" OnRowDataBound=gvGeneralFiles_OnRowDataBound OnRowUpdating=gvGeneralFiles_OnRowUpdating DataSourceID="ObjectDataSource13" GridLines="None" CssClass="table table-bordered table-hover">
                                    <Columns>
                                        <asp:BoundField ApplyFormatInEditMode="True" DataField="Description" HeaderText="Description"
                                            SortExpression="Description">
                                            <HeaderStyle Wrap="True" />
                                            <ItemStyle Wrap="True" />
                                        </asp:BoundField>
                                        <asp:HyperLinkField DataNavigateUrlFields="Link" DataNavigateUrlFormatString="Data\{0}"
                                            DataTextField="Link" DataTextFormatString="View" HeaderText="Link" SortExpression="Link"
                                            Target="_blank">
                                            <HeaderStyle Wrap="True" />
                                            <ItemStyle Wrap="True" />
                                        </asp:HyperLinkField>
                                        <asp:TemplateField HeaderText="Upload/Edit Date" SortExpression="UploadDate">
                                            <EditItemTemplate>
                                                <asp:Label ID="Label291" runat="server" Text='<%# Bind("UploadDate", "{0:d}" ) %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label292" runat="server" Text='<%# Bind("UploadDate", "{0:d}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="True" />
                                            <ItemStyle Wrap="True" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Upload/Edit By" SortExpression="UploadBy">
                                            <EditItemTemplate>
                                                <asp:Label ID="Label293" runat="server" Text='<%# Bind("UploadBy") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label294" runat="server" Text='<%# Bind("UploadBy") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="True" />
                                            <ItemStyle Wrap="True" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ID" InsertVisible="False" ReadOnly="True" ShowHeader="False"
                                            SortExpression="ID">
                                            <HeaderStyle Wrap="True" />
                                            <ItemStyle Wrap="True" />
                                        </asp:BoundField>
                                        <asp:TemplateField ShowHeader="False" SortExpression="AcctID">
                                            <EditItemTemplate>
                                                <asp:Label ID="Label295" runat="server" Text='<%# Bind("AcctID") %>'></asp:Label>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label296" runat="server" Text='<%# Bind("AcctID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="True" />
                                            <ItemStyle Wrap="True" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle Wrap="True" />
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="UploadFile" />
                            <asp:PostBackTrigger ControlID="storeWebSite" />
                        </Triggers>
                    </asp:UpdatePanel>
                </asp:View>
                <asp:View ID="view2" runat="server">
                    <div class=well>
                        <p class='lead muted'>
                            Add a <em>Website</em> to the KYC general document register:
                        </p>
                        <p>
                            <asp:TextBox ID="WebSite" runat="server" placeholder='http://website.com'></asp:TextBox>
                        </p>
                        <p>
                            <asp:TextBox ID="WebSiteDescription" runat="server" placeholder='(required)'></asp:TextBox>
                        </p>
                        <p>
                            <asp:LinkButton ID="storeWebSite" runat="server" OnClick=OnStoreWebsite CssClass="btn btn-small btn-danger"
                                PostBackUrl="" Text="Add Web Site" UseSubmitBehavior="True" />&nbsp;<asp:Label ID="Label307"
                                    runat="server"></asp:Label>
                        </p>
                    </div>
                    <div>
                        <asp:GridView ID="gvWebsitesAll" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            GridLines="None" CssClass="table table-bordered table-hover" DataKeyNames="ID"
                            DataSourceID="ObjectDataSource16" OnRowUpdating=gvWebsitesAll_OnRowUpdating OnRowDataBound=gvWebsitesAll_OnRowDataBound EmptyDataText="No References Provided">
                            <Columns>
                                <asp:BoundField ApplyFormatInEditMode="True" DataField="Description" HeaderText="Description"
                                    SortExpression="Description"></asp:BoundField>
                                <asp:HyperLinkField DataNavigateUrlFields="Link" DataNavigateUrlFormatString="http:\\{0}"
                                    DataTextField="Link" HeaderText="Website" SortExpression="Link" Target="_blank">
                                </asp:HyperLinkField>
                                <asp:TemplateField HeaderText="Upload/Edit Date" SortExpression="UploadDate">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label274" runat="server" Text='<%# Bind("UploadDate", "{0:d}" ) %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label275" runat="server" Text='<%# Bind("UploadDate", "{0:d}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Upload/Edit By" SortExpression="UploadBy">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label276" runat="server" Text='<%# Bind("UploadBy") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label277" runat="server" Text='<%# Bind("UploadBy") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID" InsertVisible="False" ReadOnly="True" ShowHeader="False"
                                    SortExpression="ID"></asp:BoundField>
                                <asp:TemplateField ShowHeader="False" SortExpression="AcctID">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label278" runat="server" Text='<%# Bind("AcctID") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label279" runat="server" Text='<%# Bind("AcctID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>

    <asp:HiddenField ID=hfAbbrName runat=server />

    <asp:ObjectDataSource ID="ObjectDataSource13" runat="server" DeleteMethod="Delete"
        InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData"
        TypeName="CustTableAdapters.ReferenceInternalGeneralTableAdapter" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_ID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="AcctID" Type="Int32" />
            <asp:Parameter Name="UploadDate" Type="DateTime" />
            <asp:Parameter Name="UploadBy" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="Link" Type="String" />
            <asp:Parameter Name="Original_ID" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="AcctID" Type="Int32" />
            <asp:Parameter Name="UploadDate" Type="DateTime" />
            <asp:Parameter Name="UploadBy" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="Link" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource16" runat="server" InsertMethod="Insert"
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="CustTableAdapters.ReferenceExternalGeneralTableAdapter"
        DeleteMethod="Delete" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_ID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="AcctID" Type="Int32" />
            <asp:Parameter Name="UploadDate" Type="DateTime" />
            <asp:Parameter Name="UploadBy" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="Link" Type="String" />
            <asp:Parameter Name="Original_ID" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="AcctID" Type="Int32" />
            <asp:Parameter Name="UploadDate" Type="DateTime" />
            <asp:Parameter Name="UploadBy" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="Link" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
</asp:Content>
