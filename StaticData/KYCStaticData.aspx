<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="KYCStaticData.aspx.vb" Inherits="Customer_StaticData_Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
        Width="1000px" Height="757px">
        <ajaxToolkit:TabPanel runat="server" HeaderText="Risk Categories/Items" ID="TabPanel1">
            <HeaderTemplate>
                Risk Categories/Items
            </HeaderTemplate>
            <ContentTemplate>
            <asp:Label ID="Label13" runat="server" Text="Label" Font-Bold="True"></asp:Label>
            <br />            
            <asp:Label ID="Label1" runat="server" Text="Risk Categories" Font-Bold="True"></asp:Label>
                <table style="border: thin solid #000000; width:41%;"><tr><td colspan="2"><asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" 
                                Text="Add New Risk Category"></asp:Label></td></tr><tr><td><asp:TextBox ID="TextBox1" runat="server" Height="22px" Width="270px"></asp:TextBox></td><td><asp:Button ID="Button1" runat="server" Font-Bold="True" ForeColor="Green" 
                                Text="Add Category" Height="26px" Width="127px" /></td></tr><tr><td colspan="2"><asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
                                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" 
                                DataSourceID="ObjectDataSource2" ForeColor="#333333"><AlternatingRowStyle BackColor="White" /><Columns><asp:CommandField ShowEditButton="True" /><asp:TemplateField HeaderText="Category" SortExpression="Category"><EditItemTemplate><asp:TextBox ID="TextBox1" runat="server" Height="18px" 
                                                Text='<%# Bind("Category") %>' Width="227px"></asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="Label1" runat="server" Text='<%# Bind("Category") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField><asp:TemplateField 
                            HeaderText="Status" SortExpression="Active"><EditItemTemplate><asp:DropDownList ID="DropDownList1" runat="server" Height="22px" 
                                                SelectedValue='<%# Bind("Active") %>' Width="100px"><asp:ListItem>Active</asp:ListItem><asp:ListItem>Inactive</asp:ListItem></asp:DropDownList></EditItemTemplate><ItemTemplate><asp:Label ID="Label2" runat="server" Text='<%# Bind("Active") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField><asp:TemplateField HeaderText="Edit By" SortExpression="EditBy"><EditItemTemplate><asp:Label ID="Label5" runat="server" Text='<%# Bind("EditBy") %>'></asp:Label></EditItemTemplate><ItemTemplate><asp:Label ID="Label3" runat="server" Text='<%# Bind("EditBy") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField><asp:TemplateField HeaderText="Edit Date" SortExpression="EditDate"><EditItemTemplate><asp:Label ID="Label6" runat="server" Text='<%# Bind("EditDate", "{0:d}") %>'></asp:Label></EditItemTemplate><ItemTemplate><asp:Label ID="Label4" runat="server" Text='<%# Bind("EditDate", "{0:d}") %>'></asp:Label></ItemTemplate><HeaderStyle HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField><asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                                        ReadOnly="True" SortExpression="ID"><HeaderStyle Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:BoundField></Columns><FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" /><HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" /><RowStyle BackColor="#FFFBD6" ForeColor="#333333" /><SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" /></asp:GridView></td></tr></table><br /><asp:Label ID="Label7" runat="server" Text="Risk Items" Font-Bold="True"></asp:Label><table style="border: thin solid #000000; width: 100%;"><tr>
                    <td class="style3"><asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Small" 
                                Text="Add New Risk Item"></asp:Label>&#160; &#160; &#160; </td></tr><tr><td valign="bottom">
                        <table style="width: 59%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Small" 
                                        Text="Category"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Small" 
                                        Text="Description"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="DropDownList5" runat="server" AppendDataBoundItems="True" 
                                        DataSourceID="ObjectDataSource3" DataTextField="Category" 
                                        DataValueField="Category" Height="16px" Width="275px">
                                        <asp:ListItem>Select Category</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="TextBox2" runat="server" Height="20px" Width="315px" 
                                        Wrap="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Small" 
                                        Text="Rating"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Small" 
                                        Text="Rating Override"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="DropDownList3" runat="server" Height="16px" Width="85px">
                                        <asp:ListItem Selected="True">NA</asp:ListItem>
                                        <asp:ListItem>Low</asp:ListItem>
                                        <asp:ListItem>Medium</asp:ListItem>
                                        <asp:ListItem>High</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownList4" runat="server" Height="16px" Width="85px">
                                        <asp:ListItem Selected="True">NA</asp:ListItem>
                                        <asp:ListItem>Low</asp:ListItem>
                                        <asp:ListItem>Medium</asp:ListItem>
                                        <asp:ListItem>High</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="text-align: right">
                                    <asp:Button ID="Button2" runat="server" Font-Bold="True" ForeColor="Green" 
                                        Height="26px" Text="Add Item" Width="127px" />
                                    <ajaxToolkit:ConfirmButtonExtender ID="Button2_ConfirmButtonExtender" runat="server" 
                                        ConfirmText="Add Risk Item?" Enabled="True" TargetControlID="Button2">
                                    </ajaxToolkit:ConfirmButtonExtender>
                                </td>
                            </tr>
                        </table>
                        </td></tr><tr><td>
                        <asp:GridView ID="GridView2" runat="server" AllowSorting="True" 
                            AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" 
                            DataSourceID="ObjectDataSource4" ForeColor="#333333">
                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowEditButton="True" />
                                <asp:BoundField DataField="Category" HeaderText="Category" ReadOnly="True" 
                                    SortExpression="Category">
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Status" SortExpression="Active">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownList66" runat="server" Height="22px" 
                                            SelectedValue='<%# Bind("Active") %>' Width="85px">
                                            <asp:ListItem>Active</asp:ListItem>
                                            <asp:ListItem>Inactive</asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label14" runat="server" Text='<%# Bind("Active") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description" SortExpression="Description">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox11" runat="server" Height="20px" 
                                            Text='<%# Bind("Description") %>' Width="265px"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Description") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Rating" SortExpression="Rating">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownList67" runat="server" 
                                            SelectedValue='<%# Bind("Rating") %>'>
                                            <asp:ListItem>NA</asp:ListItem>
                                            <asp:ListItem>Low</asp:ListItem>
                                            <asp:ListItem>Medium</asp:ListItem>
                                            <asp:ListItem>High</asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Rating") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Score" SortExpression="Score">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownList69" runat="server" 
                                            SelectedValue='<%# Bind("Score") %>'>
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>20</asp:ListItem>
                                            <asp:ListItem>30</asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Score") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Right" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Rating Override" SortExpression="AutoTo">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="DropDownList68" runat="server" 
                                            SelectedValue='<%# Bind("AutoTo") %>'>
                                            <asp:ListItem>NA</asp:ListItem>
                                            <asp:ListItem Selected="True">Low</asp:ListItem>
                                            <asp:ListItem>Medium</asp:ListItem>
                                            <asp:ListItem>High</asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("AutoTo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit Date" SortExpression="EditDate">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label17" runat="server" Text='<%# Bind("EditDate", "{0:d}") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label18" runat="server" Text='<%# Bind("EditDate", "{0:d}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit By" SortExpression="EditBy">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label15" runat="server" Text='<%# Bind("EditBy") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label16" runat="server" Text='<%# Bind("EditBy") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                                    ReadOnly="True" SortExpression="ID">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" 
                                VerticalAlign="Bottom" />
                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        </asp:GridView>
                        &nbsp; &nbsp; &nbsp;&nbsp;</td></tr></table><asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                    DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" 
                    SelectMethod="GetData" 
                    TypeName="CustTableAdapters.KYCStaticRiskCategoriesTableAdapter" 
                    UpdateMethod="Update" InsertMethod="Insert"><DeleteParameters><asp:Parameter Name="Original_ID" Type="Int32" /></DeleteParameters><InsertParameters><asp:Parameter Name="Category" Type="String" /><asp:Parameter Name="Active" Type="String" /><asp:Parameter Name="EditBy" Type="String" /><asp:Parameter Name="EditDate" Type="DateTime" /></InsertParameters><UpdateParameters><asp:Parameter Name="Category" Type="String" /><asp:Parameter Name="Active" Type="String" /><asp:Parameter Name="EditBy" Type="String" /><asp:Parameter Name="EditDate" Type="DateTime" /><asp:Parameter Name="Original_ID" Type="Int32" /></UpdateParameters></asp:ObjectDataSource><asp:HiddenField ID="hfEditBy" runat="server" /><asp:HiddenField 
                    ID="hfCatChange" runat="server" /><asp:HiddenField ID="hfStatChange" runat="server" /><asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
                    DeleteMethod="Delete" InsertMethod="Insert" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByActive" 
                    TypeName="CustTableAdapters.KYCStaticRiskCategoriesTableAdapter" 
                    UpdateMethod="Update"><DeleteParameters><asp:Parameter Name="Original_ID" Type="Int32" /></DeleteParameters><InsertParameters><asp:Parameter Name="Category" Type="String" /><asp:Parameter Name="Active" Type="String" /><asp:Parameter Name="EditBy" Type="String" /><asp:Parameter Name="EditDate" Type="DateTime" /></InsertParameters><UpdateParameters><asp:Parameter Name="Category" Type="String" /><asp:Parameter Name="Active" Type="String" /><asp:Parameter Name="EditBy" Type="String" /><asp:Parameter Name="EditDate" Type="DateTime" /><asp:Parameter Name="Original_ID" Type="Int32" /></UpdateParameters></asp:ObjectDataSource><asp:ObjectDataSource 
                    ID="ObjectDataSource4" runat="server" 
                    DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" 
                    SelectMethod="GetData" 
                    TypeName="CustTableAdapters.KYCStaticRiskTableAdapter" InsertMethod="Insert" 
                    UpdateMethod="Update"><DeleteParameters><asp:Parameter Name="Original_ID" Type="Int32" /></DeleteParameters><UpdateParameters><asp:Parameter 
                    Name="Category" Type="String" />
                <asp:Parameter Name="Rating" Type="String" />
                <asp:Parameter Name="Score" Type="Double" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="AutoTo" Type="String" />
                <asp:Parameter Name="EditBy" Type="String" />
                <asp:Parameter Name="EditDate" Type="DateTime" />
                <asp:Parameter Name="Active" Type="String" />
                <asp:Parameter Name="Original_ID" Type="Int32" />
                </UpdateParameters>
                <InsertParameters>
                    <asp:Parameter Name="Category" Type="String" />
                    <asp:Parameter Name="Rating" Type="String" />
                    <asp:Parameter Name="Score" Type="Double" />
                    <asp:Parameter Name="Description" Type="String" />
                    <asp:Parameter Name="AutoTo" Type="String" />
                    <asp:Parameter Name="EditBy" Type="String" />
                    <asp:Parameter Name="EditDate" Type="DateTime" />
                    <asp:Parameter Name="Active" Type="String" />
                </InsertParameters>
                </asp:ObjectDataSource><ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
        TargetControlID="Button1" ConfirmText="Add Risk Category?" Enabled="True"></ajaxToolkit:ConfirmButtonExtender></ContentTemplate>
        
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="GeoGraphic Risk Countries">
            <ContentTemplate>
                <asp:Label ID="Label19" runat="server" Font-Bold="True" Text="Label"></asp:Label>
                <br />
                <asp:Label ID="Label20" runat="server" Font-Bold="True" 
                    Text="Geographic Country Risk Ratings"></asp:Label>
                <table style="border: thin solid #000000; width:41%;">
                    <tr>
                        <td>
                            <asp:GridView ID="GridView3" runat="server" AllowSorting="True" 
                                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="GeoID" 
                                DataSourceID="ObjectDataSource5" ForeColor="#333333" 
                                AutoGenerateEditButton="True">
                                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Country" SortExpression="Country">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Country") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Country") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Risk Class US" SortExpression="RiskClassUS">
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="DropDownList70" runat="server" 
                                                SelectedValue='<%# Bind("RiskClassUS") %>'>
                                                <asp:ListItem>Low</asp:ListItem>
                                                <asp:ListItem>Medium</asp:ListItem>
                                                <asp:ListItem>High</asp:ListItem>
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("RiskClassUS") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rating Date" SortExpression="RatingDate">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("RatingDate", "{0:d}") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("RatingDate", "{0:d}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="GeoID" HeaderText="GeoID" 
                                        ReadOnly="True" SortExpression="GeoID">
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                </Columns>
                                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" 
                    DeleteMethod="Delete" InsertMethod="Insert" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
                    TypeName="CustTableAdapters.GeoRiskRatingsTableAdapter" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_GeoID" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Country" Type="String" />
                        <asp:Parameter Name="RiskClassUS" Type="String" />
                        <asp:Parameter Name="RatingDate" Type="DateTime" />
                        <asp:Parameter Name="Original_GeoID" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="GeoID" Type="Int32" />
                        <asp:Parameter Name="Country" Type="String" />
                        <asp:Parameter Name="RiskClassUS" Type="String" />
                        <asp:Parameter Name="RatingDate" Type="DateTime" />
                    </InsertParameters>
                </asp:ObjectDataSource>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
   
</asp:Content>

