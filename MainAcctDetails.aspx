<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="MainAcctDetails.aspx.vb" Inherits="Customer_Main" Title="DZ Bank New York: KYC Compliance Reporting" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphClientScriptsHEAD" runat="Server">
    <script type="text/javascript">
        // fixup processing during updatepanel postbacks
        function ajaxhookup() {
            $(document).ready(function () {
                $("#dzform :button, #dzform :submit, #dzform a").button();
                $("input[id$='Date']").datepicker({ beforeShowDay: $.datepicker.noWeekends, minDate: new Date(), changeMonth: true,
                    changeYear: true,
                    yearRange: "-0:+40"
                });
            });
        }
        $(function () {
            ajaxhookup();
        });

    </script>
    <style type="text/css">
        #dzform table
        {
            font-size: 9pt;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="dzform" class="ui-widget" style="padding: 10px">
        <div class="ui-widget-header ui-corner-top">
            <h3>
                KYC - Compliance Detail Report
            </h3>
        </div>
        <div class="ui-widget-content ui-corner-bottom" style="padding: 10px">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Font-Bold="True"></asp:Label><br />
                        <asp:Label ID="Label4" runat="server" Font-Bold="True"></asp:Label><br />
                        <asp:Label ID="Label5" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView runat="server" AllowSorting="false" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
                            ID="GridView3" EmptyDataText="test" SkinID="jqueryUI">
                            <Columns>
                                <asp:HyperLinkField DataNavigateUrlFields="ID"  DataNavigateUrlFormatString="~/Customer/Manage/RiskDetails.aspx?hfID={0}"
                                    DataTextField="ID" DataTextFormatString="Risk Details">
                                    <ItemStyle Wrap="False"></ItemStyle>
                                </asp:HyperLinkField>
                                <asp:BoundField DataField="Owner" HeaderText="Department" SortExpression="Owner">
                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                    <ItemStyle Wrap="False"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="FullName" HeaderText="Full Name" SortExpression="FullName">
                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                    <ItemStyle Wrap="False"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Score" HeaderText="Score" SortExpression="Score">
                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                    <ItemStyle Wrap="False" Font-Bold="True"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Rating" HeaderText="Rating" SortExpression="Rating">
                                    <ItemStyle Wrap="False" Font-Bold="True"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" ReadOnly="True">
                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                    <ItemStyle Wrap="False"></ItemStyle>
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hfDept" runat="server" />
            <asp:HiddenField ID="hfRating" runat="server" />
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetData" TypeName="KYCGraphTableAdapters.KYCGraphRiskDetailTableAdapter">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfDept" Name="hfOwner" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="hfRating" Name="hfRating" PropertyName="Value" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        function EndRequestHandler(sender, args) {
            if (args.get_error() == undefined) {
                // update dom after UpdatePanel
                ajaxhookup();
            }
        }
    </script>
</asp:Content>
