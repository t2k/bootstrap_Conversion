<%@ Page Title="KYC Account Statistics" Language="C#" MasterPageFile="~/MasterPageTBS.master"
    AutoEventWireup="true" CodeFile="KYC.AccountStatistic.aspx.cs" Inherits="KYC_AccountStatistics"
    StylesheetTheme="TBS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cp2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp1" runat="Server">
    <div class="container-fluid">
        <div class="row-fluid">
            <h1>
                <abbr class="initialism" title="Know Your Customer">
                    KYC</abbr><small> - Account Statistics</small></h1>
            <hr />
        </div>
        <div class="row-fluid">
            <div class="control-group">
                <label class="control-label">
                    <span class="label label-success">Department:</span>
                </label>
                <div class="controls">
                    <div class="input-prepend">
                        <span class="add-on"><i class=" icon-question-sign"></i></span>
                        <asp:DropDownList ID="ddl_mgr" AppendDataBoundItems="true" CssClass=" input-medium"
                            runat="server" OnSelectedIndexChanged="ddl_mgr_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem>ALL-Depts</asp:ListItem>
                            <asp:ListItem Value="ASG">ASG</asp:ListItem>
                            <asp:ListItem Value="FI">FI</asp:ListItem>
                            <asp:ListItem Value="SFLN">SFLN</asp:ListItem>
                            <asp:ListItem Value="SPF">SPF</asp:ListItem>
                            <asp:ListItem Value="STF">STF</asp:ListItem>
                            <asp:ListItem Value="TR">TR</asp:ListItem>
                            <asp:ListItem Value="%">Display-All</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <hr />
        </div>
        <div class="row-fluid">
            <ul class="thumbnails">
                <li>
                    <asp:Table ID="Risk" runat="server" CssClass="table table-bordered">
                        <asp:TableRow CssClass="info">
                            <asp:TableCell ColumnSpan="5"><strong>Risk Rating</strong></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Data</asp:TableCell>
                            <asp:TableCell>Not Computed</asp:TableCell>
                            <asp:TableCell>Low</asp:TableCell>
                            <asp:TableCell>Medium</asp:TableCell>
                            <asp:TableCell>High</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>#</asp:TableCell>
                            <asp:TableCell>1</asp:TableCell>
                            <asp:TableCell>1</asp:TableCell>
                            <asp:TableCell>1</asp:TableCell>
                            <asp:TableCell>1</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>%</asp:TableCell>
                            <asp:TableCell>2%</asp:TableCell>
                            <asp:TableCell>2%</asp:TableCell>
                            <asp:TableCell>2%</asp:TableCell>
                            <asp:TableCell>2%</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </li>
                <li>
                    <asp:Table ID="AcctOpening" runat="server" CssClass="table table-bordered">
                        <asp:TableRow CssClass="info">
                            <asp:TableCell ColumnSpan="5"><strong>Account Opening Status</strong></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Data</asp:TableCell>
                            <asp:TableCell>Pending Ref and FAX</asp:TableCell>
                            <asp:TableCell>Pending Ref</asp:TableCell>
                            <asp:TableCell>Pending FAX</asp:TableCell>
                            <asp:TableCell>Completed</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>#</asp:TableCell>
                            <asp:TableCell>1</asp:TableCell>
                            <asp:TableCell>1</asp:TableCell>
                            <asp:TableCell>1</asp:TableCell>
                            <asp:TableCell>1</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>%</asp:TableCell>
                            <asp:TableCell>2</asp:TableCell>
                            <asp:TableCell>2</asp:TableCell>
                            <asp:TableCell>2</asp:TableCell>
                            <asp:TableCell>2</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </li>
                <li>
                    <asp:Table ID="Compliance" runat="server" CssClass="table table-bordered">
                        <asp:TableRow CssClass="info">
                            <asp:TableCell ColumnSpan="8"><strong>Account Compliance Status</strong></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>Data</asp:TableCell>
                            <asp:TableCell>Pending Completion</asp:TableCell>
                            <asp:TableCell>Pending Approval</asp:TableCell>
                            <asp:TableCell>Rejected</asp:TableCell>
                            <asp:TableCell>Approved</asp:TableCell>
                            <asp:TableCell>KYC Not Reqd/SAP Only</asp:TableCell>
                            <asp:TableCell>Missing Docs</asp:TableCell>
                            <asp:TableCell>Risk Review 90 Days</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>#</asp:TableCell>
                            <asp:TableCell>1</asp:TableCell>
                            <asp:TableCell>1</asp:TableCell>
                            <asp:TableCell>1</asp:TableCell>
                            <asp:TableCell>1</asp:TableCell>
                            <asp:TableCell>1</asp:TableCell>
                            <asp:TableCell>1</asp:TableCell>
                            <asp:TableCell>1</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>%</asp:TableCell>
                            <asp:TableCell>2</asp:TableCell>
                            <asp:TableCell>2</asp:TableCell>
                            <asp:TableCell>2</asp:TableCell>
                            <asp:TableCell>2</asp:TableCell>
                            <asp:TableCell>2</asp:TableCell>
                            <asp:TableCell>2</asp:TableCell>
                            <asp:TableCell>2</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </li>
            </ul>
        </div>
        <div class="row-fluid">
            <hr />
            <span class="label label-warning" id="info" runat="server" visible="false"></span>
        </div>
    </div>
</asp:Content>
