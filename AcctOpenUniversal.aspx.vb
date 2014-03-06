Imports System.Web.Security
Imports System.Data
Imports System.Data.Entity
Imports System.Linq


Partial Class AccountAddPage
    Inherits System.Web.UI.Page


    Public Sub showMsg(ByRef msg As String, Optional visible As Boolean = True)
        'Label25.Text = msg
        'Label25.Visible = visible
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim dzUser As DZUserProfile = DZUserProfile.GetUserProfile(My.User.Name)

            hfEditBy.Value = dzUser.AbbrName
            hfDept.Value = dzUser.Department
            hfOwner.Value = "%"
            ' t. killilea new for Feb 7, 2011;  limit query results to top 12
            hfSearch.Value = String.Empty
            Search.Focus()
        End If
    End Sub


    ''' <summary>
    ''' clear/search button  / SAVE BUT NOT USED FOR NOW
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnMasterSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) ' Handles btnMasterSearch.Click
        ListView1.InsertItemPosition = InsertItemPosition.None
        Dim searchCount As Integer = 0

        If Me.Search.Text = String.Empty Then
            ListView1.DataSourceID = Nothing
            showMsg("Null Search")
        Else
            Dim thisSearch = Search.Text
            ListView1.DataSourceID = "ObjectDataSource1"
            Me.hfSearch.Value = String.Format("{0}{1}{2}", "%", thisSearch, "%")
            Me.Search.Text = String.Empty
            Dim taCount As New CustTableAdapters.CUSTUniversalTableAdapter
            searchCount = taCount.GetDataByOwner("%", Me.hfSearch.Value).Count()
            showMsg(String.Format("Search '{0}' found: {1} accounts", thisSearch, searchCount))
        End If

        Me.ListView1.DataBind()
    End Sub



    Protected Sub ListView1_ItemCanceling(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewCancelEventArgs) Handles ListView1.ItemCanceling
        ListView1.InsertItemPosition = InsertItemPosition.None
    End Sub


    Protected Sub ListView1_ItemEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewEditEventArgs) Handles ListView1.ItemEditing
        ListView1.InsertItemPosition = InsertItemPosition.None
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' There's alot going on here, read the code
    ''' </remarks>
    Protected Sub ListView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DataBound
        If ListView1.EditItem IsNot Nothing Then
            Dim ctx As New VB.KYCEntities
            Dim thisID = CInt(ListView1.DataKeys(ListView1.EditIndex).Value)  ' KataKeys(i).Value is the ID of CUSTUniversal entity: EditIndex is the itemview index for the selected row

            ' find the CUSTUniversal by ID in our datamodel
            Dim cust = (From c In ctx.CUSTUniversals Where c.ID = thisID Select c).FirstOrDefault()

            Me.hfID.Value = thisID
            Dim mybtnSave As LinkButton = TryCast(ListView1.EditItem.FindControl("btnSave"), LinkButton)
            Dim btnComplianceOpenClose As Button = TryCast(ListView1.EditItem.FindControl("ButtonCompliance"), Button) ' compliance/OCS open/close 
            If My.User.IsInRole("KYC-ADMIN") Then ' deplist.Contains(hfDept.Value) Then
                btnComplianceOpenClose.Visible = True
                btnComplianceOpenClose.ToolTip = "Account Open/Close status switch"
                btnComplianceOpenClose.Text = "Open/Close Account - Compliance Only"

                If cust.CustStatus = "Active" Then
                    btnComplianceOpenClose.Text = "Close Account - Compliance Only"
                End If

                If cust.CustStatus = "Auto-Closed" Then
                    btnComplianceOpenClose.Text = "Open Account - Compliance Only"
                End If
            Else
                btnComplianceOpenClose.Visible = False
            End If

            ' convention over configuration:  Create Roles in the user profile management system like KYC-TR, KYC-STF
            ' this allows multiple KYC users to edit/save changes  
            mybtnSave.Visible = My.User.IsInRole(String.Format("KYC-{0}", cust.Owner))

        End If

    End Sub


    ''' <summary>
    ''' fill in all default values for KYC.CUST entity:  
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>This brought in from QUEUE.ASPX.vb and converted to EF4 from datasets</remarks>
    Public Function InitKYCCust() As VB.CUST
        Dim row4 As New VB.CUST

        row4.OFAC = False
        row4.ZISLegalForm = "NA Not Assigned"
        row4.CountryCode = "NA Not Assigned"
        row4.UltCountryCode = "NA Not Assigned"
        row4.SpecType = "NA Not Assigned"
        row4.LegalEntity = "NA Not Assigned"
        row4.RiskSector = "NA Not Assigned"
        row4.Systematic = "NA Not Assigned"
        row4.SAPIndCode = "NA Not Assigned"
        row4.StatBusRelation = "NA Not Assigned"
        row4.CustGrp = "NA Not Assigned"
        row4.Relationship = "None"

        row4.BPRole = "Business Partner(General) (New)"
        row4.ContractPartner = "19"
        row4.SectorKey = "10"
        row4.CustComplianceStatus = "Pending Completion"
        row4.CustOpenStatus = "Pending Ref and FAX"
        row4.PrintStatus = "0"
        row4.CommentEditBy = Me.hfEditBy.Value
        row4.CommentEditDate = System.DateTime.Today
        row4.IDType = "NA Not Assigned"
        row4.CustOpenChange = "No"
        row4.CustType = "Legal Entity"
        row4.LegalEntityType = "Publicly Traded"
        row4.ExistingRelation = 0
        row4.SIC = "NA Not Assigned"
        row4.Syndications = 0
        row4.OtherLending = 0
        row4.FundsTransfer = 0
        row4.BookTransfer = 0
        row4.RevolvingCredit = 0
        row4.StandbyLC = 0
        row4.CommLC = 0
        row4.DemandDA = 0
        row4.TimeDA = 0
        row4.CommPaper = 0
        row4.FXTrading = 0
        row4.ProdOther = 0
        row4.FundMove1 = 0
        row4.FundMove2 = 0
        row4.FundMove3 = 0
        row4.FundMove4 = 0
        row4.FundMove5 = 0
        row4.FundMove6 = 0
        row4.InitDepositTransfer = 0
        row4.InitDepositCheck = 0
        row4.InitDeposit = 0
        row4.InMonthlyTransactions = 0
        row4.InMonthlyAmount = 0
        row4.OutMonthlyTransactions = 0
        row4.OutMonthlyAmount = 0
        row4.CustNotification = 0
        row4.TenK = 0
        row4.PrimeCertInc = 0
        row4.PrimeCertGoodStand = 0
        row4.PrimeSyndParticipant = 0
        row4.PrimeGovEntity = 0
        row4.PrimeOther = 0
        row4.MissingDocsPrim = 0
        row4.MissingDocsSec = 0
        row4.SecWorldCheck = 0
        row4.SecDB = 0
        row4.SecCertGoodStand = 0
        row4.SecOther = 0
        row4.FinInstType = "NA Not Assigned"
        row4.FinInstExchange = "NA Not Assigned"
        row4.FinInstSub = 0
        row4.FinInstGovUN = "NA"
        row4.FinInstPriviate = 0
        row4.FinInstGovPercent = 0
        row4.FinInstShellBank = 0
        row4.SP = "NA Not Assigned"
        row4.SPSL = "NA Not Assigned"
        row4.Moody = "NA Not Assigned"
        row4.MoodySL = "NA Not Assigned"
        row4.DL = 0
        row4.FXDerivatives = 0
        row4.IntRateDerivatives = 0
        row4.TradeFinance = 0
        row4.FinInstBankAlmanac = 0
        row4.FinInstPatriot = 0
        row4.FinInstKYC = 0
        row4.FinInstStatement = 0
        row4.ChecksIssued = 0
        row4.PrimeDriverLic = 0
        row4.PrimePassport = 0
        row4.PrimeStateID = 0
        row4.PrimeAlienReg = 0
        row4.PrimeResidentID = 0
        row4.PrimeUSSynd = 0
        row4.SecCreditReport = 0
        row4.SecUtilityBill = 0
        row4.SecReverseDirectory = 0
        row4.SecBankRef = 0
        row4.Score = 0
        row4.Rating = "Not Computed"
        row4.RiskCompDate = New Date(1900, 1, 1)
        row4.RiskCompBy = "NA"
        row4.OffEditBy = "NA"
        row4.CompEditBy = "NA"
        row4.TempScore = 0
        row4.TempRating = "NA"
        row4.BusHRForBanks = 0
        row4.BusHRCollection = 0
        row4.BusHROffShore = 0
        row4.BusHRImpExp = 0
        row4.BusHRCoun = 0
        row4.BusHRPIC = 0
        row4.BusHRLuxury = 0
        row4.BusHRGambling = 0
        row4.BusHRProfessionals = 0
        row4.BusHRInsurance = 0
        row4.BusHRBrokers = 0
        row4.BusHRREIT = 0
        row4.BusMRPublic = 0
        row4.BusMRPrivate = 0
        row4.BusMRForeignInd = 0
        row4.BusMRCoun = 0
        row4.BusMRUN = 0
        row4.BusLRBanks = 0
        row4.BusLRDomInd = 0
        row4.BusLRPublic = 0
        row4.BusLRCoun = 0
        row4.BusLRFCB = 0
        row4.TranHRCorrBanks = 0
        row4.TranHRIntlWire = 0
        row4.TranHRCash = 0
        row4.TranHRTrust = 0
        row4.TranHRFOREX = 0
        row4.TranMRChecks = 0
        row4.TranMRDomWire = 0
        row4.TranLRChecks = 0
        row4.TranLRMMKT = 0
        row4.TranLRDomWire = 0
        row4.TranLRCashMGMT = 0
        row4.TranLRCommPaper = 0
        row4.TranLRFOREX = 0
        row4.TranNR = 0
        row4.CreditHRLC = 0
        row4.CreditHRCashLoan = 0
        row4.CreditMRSyndLoan = 0
        row4.CreditLRCorpLoan = 0
        row4.CreditLRRevCredit = 0
        row4.CreditLRSyndLoan = 0
        row4.CreditLRCommLC = 0
        row4.CreditLRStandbyLC = 0
        row4.CreditLRCommMTG = 0
        row4.CreditNR = 0
        row4.GeoHRFAFT = 0
        row4.GeoHROFAC = 0
        row4.GeoHROther = 0
        row4.GeoHRAML = 0
        row4.GeoMRAML = 0
        row4.GeoLRAML = 0
        row4.GeoCountry1 = "NA Not Assigned"
        row4.GeoRisk1 = "Not Computed"
        row4.CustHR2 = 0
        row4.CustHRSAR = 0
        row4.CustHRBadPress = 0
        row4.CustMR2to5 = 0
        row4.CustLR5 = 0
        row4.CustLR5Parent = 0
        row4.CustHRBP = 0
        row4.CustMRBP = 0
        row4.CustLRBP = 0
        row4.CustHRSub = 0
        row4.CustNR = 0
        row4.EditBy = Me.hfEditBy.Value
        row4.EditDate = System.DateTime.Now
        Return row4
    End Function



    ''' <summary>
    ''' handle insert/creation of new CustUniversal and KYC accounts
    ''' no more multi-step approach  insert one and done
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnInsertNewAcct_Click(sender As Object, e As System.EventArgs) Handles btnInsertNewAcct.Click
        Dim ctx As New VB.KYCEntities
        Dim dzUser As DZUserProfile = DZUserProfile.GetUserProfile(My.User.Name)
        Dim custUniversal As New VB.CUSTUniversal()
        Dim cust As New VB.CUST()
        Dim custDetail As New VB.CUSTDetail()

        Dim newAccount = Server.HtmlEncode(newAccountProposed.Text)

        Try
            ' *** Key data from user input
            custUniversal.FullName = newAccount
            custUniversal.Owner = ddlOwnerDept.Text
            ' *****************************
            custUniversal.AcctOpenDate = System.DateTime.Today
            custUniversal.AcctOpenBy = Me.hfEditBy.Value
            custUniversal.EditBy = Me.hfEditBy.Value
            custUniversal.EditDate = System.DateTime.Now
            custUniversal.KYCStatus = "Submitted"
            custUniversal.CreditStatus = "Not Submitted"
            custUniversal.CustStatus = "Active"

            ' embedded CUSTDetail
            custDetail.Country = "NA Not Assigned"
            custDetail.AccountMgr = "NA Not Assigned"
            custDetail.CreditMgr = "NA Not Assigned"
            custDetail.CMNE = String.Empty
            custDetail.EditBy = Me.hfEditBy.Value
            custDetail.EditDate = System.DateTime.Now
            custDetail.AcctCloseDate = New Date(1900, 1, 1)
            custDetail.Comments = String.Empty

            custUniversal.CUSTDetail = custDetail
            custUniversal.CUST = InitKYCCust()  ' initialize default values for new CUST 
            ctx.AddToCUSTUniversals(custUniversal)
            ctx.SaveChanges()

            Dim custEvent As New VB.ChangeInfo
            With custEvent
                .CustID = custUniversal.ID
                .ChangeDate = Now
                .ChangeType = "KYC Submission"
                .Author = hfEditBy.Value
                .OldScore = 0
                .NewScore = 0
                .Comments = String.Format("Initial KYC submission by {0} on {1:d}.", hfEditBy.Value, System.DateTime.Today)
            End With
            ctx.AddToChangeInfoes(custEvent)
            labelSuccess.Text = String.Format("Well done {0}, a new KYC account was created for {1}, its assigned KYCID is {2}", dzUser.FirstName, custUniversal.FullName, custUniversal.ID)
            ctx.SaveChanges()  ' will asssign ID to all entities

        Catch ex As Exception
            MultiView1.ActiveViewIndex = 3
            labelError.Text = String.Format("Big Opps!   {0}", ex.Message)
        End Try
        MultiView1.ActiveViewIndex = 4
    End Sub


    ''' <summary>
    ''' button1: hidden on editItemTemplate (bottom row) toggle the OPEN/CLOSE status 
    ''' </summary>
    ''' <remarks>only enabled for compliance</remarks>
    Protected Sub btnOpenClose()
        Me.ListView1.EditIndex = -1 ' closeup the details
        Dim statusMsg As String = String.Empty

        Try
            Dim ctx As New VB.KYCEntities
            Dim cust = (From c In ctx.CUSTUniversals Where c.ID = CInt(hfID.Value) Select c).FirstOrDefault()
            Dim row5 = New VB.ChangeInfo ' status row
            If cust.CustStatus = "Active" Then  ' if active then make inactive ie CustStatus="Auto-Closed"
                cust.CUSTDetail.OPICSref = cust.CUSTDetail.CMNE
                cust.CUSTDetail.CMNE = "XXX"
                cust.CUSTDetail.AcctCloseDate = System.DateTime.Now
                cust.CUSTDetail.EditBy = Me.hfEditBy.Value
                cust.CUSTDetail.EditDate = System.DateTime.Now
                cust.CUST.EditBy = Me.hfEditBy.Value
                cust.CustStatus = "Auto-Closed"
                cust.EditDate = System.DateTime.Now
                cust.EditBy = Me.hfEditBy.Value

                ' post change status
                row5.CustID = Me.hfID.Value
                row5.ChangeDate = System.DateTime.Now
                row5.ChangeType = "Comment"
                row5.Author = Me.hfEditBy.Value
                row5.OldScore = cust.CUST.Score
                row5.NewScore = "0"
                row5.Comments = "SAP manual sync.  Account closure"

            ElseIf cust.CustStatus = "Auto-Closed" Then ' if in-active then make active
                cust.CUSTDetail.CMNE = cust.CUSTDetail.OPICSref
                cust.CUSTDetail.AcctCloseDate = New Date(1900, 1, 1)
                cust.CUSTDetail.EditDate = System.DateTime.Now
                cust.CUSTDetail.EditBy = Me.hfEditBy.Value

                cust.CUST.EditDate = System.DateTime.Now
                cust.CUST.EditBy = Me.hfEditBy.Value
                cust.CUST.ReviewDate = Today
                cust.CUST.CustComplianceStatus = "Pending Approval"
                cust.CUST.PrintStatus = "1"
                cust.CUST.RiskCompDate = New Date(1900, 1, 1) '1901 ensures compliance status shows at Pending CIP and Risk Approval in conjunction with PrintStatus = 1.  On Risk review page set 1901 Pending Approval Submitted dDate field display to NA through code
                cust.CustStatus = "Active"
                cust.EditDate = System.DateTime.Now
                cust.EditBy = Me.hfEditBy.Value

                row5.CustID = Me.hfID.Value
                row5.ChangeDate = System.DateTime.Now
                row5.ChangeType = "Comment"
                row5.Author = Me.hfEditBy.Value
                row5.OldScore = cust.CUST.Score
                row5.NewScore = "0"
                row5.Comments = "SAP manual sync. Account re-opening"

            End If
            statusMsg = String.Format("{0}-- custstatus switched to {1}", cust.FullName, cust.CustStatus)
            ctx.AddToChangeInfoes(row5)
            ctx.SaveChanges()
            Me.ListView1.DataBind()
            MultiView1.ActiveViewIndex = 4
            labelSuccess.Text = statusMsg

        Catch ex As Exception
            MultiView1.ActiveViewIndex = 3
            labelError.Text = ex.Message
        End Try

    End Sub



    ''' <summary>
    ''' MAIN SEARCH EVENT: handle text change event/  perform search when user moves off field
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Search_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Search.TextChanged
        Dim searchCount As Integer = 0
        Dim searchPhrase As String = String.Empty
        ListView1.DataSourceID = "Objectdatasource1"

        ListView1.InsertItemPosition = InsertItemPosition.None
        ListView1.EditIndex = -1 ' close up existing edit template

        If Me.Search.Text.Length > 0 Then
            searchPhrase = Search.Text
            Me.hfSearch.Value = "%" + Me.Search.Text + "%"  ' hfSearch.Value is objectDataSource Parameter wrapped in % is for wildcard search
            Dim taCount As New CustTableAdapters.CUSTUniversalTableAdapter
            searchCount = taCount.GetDataByOwner("%", Me.hfSearch.Value).Count()
            showMsg(String.Format("Search phrase '{0}' matched {1} existing account(s) by Fullname", searchPhrase, searchCount))
        Else
            showMsg(String.Format("NULL search phrase", searchPhrase, searchCount))
        End If
        ListView1.DataBind()  ' databind will refresh the listview control
    End Sub




    ''' <summary>
    ''' Handle custom "SyncBPName" command with Argument  t.killilea Jan/2013  lookup SAP.BPName via this linked KYCID
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' ID is passed in as the only Argument  when SyncBPName custom command if triggered:
    '''  1) find the FullName Textbox
    '''  2) grab syncID from e.CommandArgument
    '''  3) use LINQ to search the KYCID in the SAPBP entity model and grab the BPName
    '''  4) assign the BPName to Fullname and get out of Dodge...
    '''  
    '''  User still has to Save the form, this is just a utility/helper 
    ''' </remarks>
    ''' 
    Protected Sub ListView1_ItemCommand(sender As Object, e As System.Web.UI.WebControls.ListViewCommandEventArgs) Handles ListView1.ItemCommand
        If (e.CommandName = "SyncBPName") Then
            If e.Item.ItemType = ListViewItemType.DataItem Then
                ' server side control stuff  don't ask, I've forgotten this .net stuff years ago, googled ListView_ItemCommand
                Dim fullName As TextBox = CType(e.Item.FindControl("TextBoxFullName"), TextBox)
                Dim syncID As Integer = e.CommandArgument ' KYCID is passed in as an argument in the HTML markup's editItemTemplate from the ListView

                Dim ctx As New VB.KYCEntities
                Try
                    Dim syncName As String = (From bp In ctx.SAPBPs
                                    Where bp.KYCID = syncID
                                    Select bp.BPName).FirstOrDefault().ToString()

                    fullName.Text = syncName
                Catch ex As Exception
                    showMsg(String.Format("KYCID# {0} was not found in SAPBP table", syncID))
                Finally
                    ctx.Dispose()
                End Try
            End If
        End If
    End Sub

    ''' <summary>
    ''' Called from btnSave on ListView: Details
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ListView1_ItemUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewUpdateEventArgs) Handles ListView1.ItemUpdating
        Dim myLabelEdit As Label = TryCast(ListView1.EditItem.FindControl("EditError"), Label)
        'myLabelEdit.Text = "Hello"
        myLabelEdit.Text = "Account Edit Triggered!"
        ' ta/row = CUSTUNIVERSAL
        Dim ta As New CustTableAdapters.CUSTUniversalTableAdapter
        Dim row As CUST.CUSTUniversalRow = ta.GetDataByID(e.Keys(0)).Rows(0)
        Me.hfDeptEdit.Value = row.Owner

        ' ta4/row4 = CustDetail
        Dim ta4 As New CustTableAdapters.CUSTDetailTableAdapter
        Dim row4 As CUST.CUSTDetailRow = ta4.GetData(e.Keys(0)).Rows(0)


        Dim ta3 As New CustTableAdapters.CUSTUniversalTableAdapter
        Dim dt3 As CUST.CUSTUniversalDataTable = ta3.GetDataByFullName(e.NewValues("FullName"))
        Dim myCount As Integer = dt3.Count
        If e.OldValues("FullName") <> e.NewValues("FullName") Then
            If myCount >= 1 Then
                myLabelEdit.Text = "Account Name Already in use - Please revise your edit."
                e.Cancel = True
                Exit Sub
            End If
        End If

        'If Me.hfDept.Value = "OCS" Then
        '    If (e.OldValues("Owner") = "TR" And e.NewValues("Owner") = "STF") Or (e.OldValues("Owner") = "STF" And e.NewValues("Owner") = "TR") Then
        '        row.Owner = e.NewValues("Owner")
        '        row4.AccountMgr = "xn99999"
        '    End If
        'Else
        '    e.NewValues("Owner") = e.OldValues("Owner")
        'End If
        If e.NewValues("CustStatus") = "Auto-Closed" Then
            e.NewValues("CustStatus") = "Inactive"
        End If

        row.EditDate = System.DateTime.Now
        row.EditBy = Me.hfEditBy.Value




        ' SAVING INACTIVE STATUS


        ' row = CUSTUNIVERSAL
        If e.NewValues("CustStatus") = "Inactive" Then

            row.KYCStatus = "Not Submitted"
            row.CreditStatus = "Not Submitted"

            Dim myID As Integer = e.Keys("ID")

        End If

        For Each de As DictionaryEntry In e.NewValues
            Try
                If IsDBNull(row(de.Key)) And de.Value <> Nothing Then
                    row(de.Key) = de.Value
                ElseIf de.Value = Nothing Then
                    row(de.Key) = DBNull.Value
                ElseIf row(de.Key) <> de.Value Then
                    row(de.Key) = de.Value
                End If
            Catch ex As Exception

            End Try
        Next
        ta.Update(row)
        ta4.Update(row4)
        e.Cancel = True
        Me.ListView1.DataBind()
        Me.ListView1.EditIndex = -1
    End Sub


    ''' <summary>
    ''' Test users for KYC-ACCTMGR role to enable new account creation
    ''' Item Created Event fires when different views are created test the ListViewItemEventsArgs for
    ''' specific view type and then  use FindControl to customize
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ListView1_ItemCreated(sender As Object, e As System.Web.UI.WebControls.ListViewItemEventArgs) Handles ListView1.ItemCreated
        Select Case e.Item.ItemType
            Case ListViewItemType.DataItem ' data

            Case ListViewItemType.EmptyItem

            Case ListViewItemType.InsertItem
                ' hide the template header

        End Select
    End Sub


    ''' <summary>
    ''' handle view context switches
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub navPageBL_Click(sender As Object, e As System.Web.UI.WebControls.BulletedListEventArgs) Handles navPageBL.Click
        showMsg("navPageBL:Click")
        Select Case e.Index
            Case 0
                MultiView1.ActiveViewIndex = e.Index
                ListView1.EditIndex = -1  ' closeup
                Search.Focus()
            Case 1
                If My.User.IsInRole("KYC-ACCTMGR") Then
                    MultiView1.ActiveViewIndex = e.Index
                    lookupSuccess.Visible = False
                    lookupWarning.Visible = False
                    btnInsertNewAcct.Visible = False
                    Dim ddl = TryCast(MultiView1.FindControl("ddlOwnerDept"), DropDownList)
                    If ddl IsNot Nothing Then
                        Dim lst = From i In Roles.GetRolesForUser(My.User.Name) Where i.StartsWith("KYC-") And i.Length < 9 Select i.Split("-")(1)
                        ddl.DataSource = lst
                        ddl.DataBind()
                    End If
                    newAccountProposed.Focus()
                Else
                    MultiView1.ActiveViewIndex = 2
                End If
        End Select
    End Sub

    ''' <summary>
    ''' lookup users proposed entry
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub OnAccountNameLookup(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLookup.ServerClick
        Dim input = TryCast(MultiView1.FindControl("newAccountProposed"), TextBox)
        If input IsNot Nothing Then
            Dim cleanInput As String = Server.HtmlEncode(input.Text)
            If cleanInput = String.Empty Then
                newAccountProposed.Focus()
            Else
                lookupSuccess.Visible = False
                lookupWarning.Visible = False
                Dim ctx As New VB.KYCEntities
                Dim conflicts = (From c In ctx.CUSTUniversals Where c.FullName.StartsWith(cleanInput) Select c.FullName).Take(10)
                'showMsg(String.Format("{0} potential name conflicts.", conflicts.Count))
                Dim ddl = TryCast(MultiView1.FindControl("accountNameConflicts"), DropDownList)
                If conflicts.Count > 0 Then
                    If ddl IsNot Nothing Then
                        ddl.DataSource = conflicts
                        ddl.DataBind()
                        ddl.Visible = True
                        btnInsertNewAcct.Visible = False
                        btnInsertNewAcct.Attributes.Add("class", "btn btn-primary")
                        lookupWarning.Visible = True
                    End If
                Else
                    ddl.Visible = False
                    btnInsertNewAcct.Visible = True
                    btnInsertNewAcct.Attributes.Add("class", "btn btn-danger")
                    lookupSuccess.Visible = True
                End If
            End If
        End If
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        MultiView1.ActiveViewIndex = 0  ' get out of insert mode/ back to edit
    End Sub


End Class
