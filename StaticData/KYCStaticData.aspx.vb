
Partial Class Customer_StaticData_Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.TextBox1.Text.Length > 0 Then
            Dim ta As New CustTableAdapters.KYCStaticRiskCategoriesTableAdapter
            Dim dt As Cust.KYCStaticRiskCategoriesDataTable = ta.GetDataByCategory(Me.TextBox1.Text)
            Dim row As Cust.KYCStaticRiskCategoriesRow
            Try
                row = dt(0)
            Catch
                Dim ta4 As New CustTableAdapters.KYCStaticRiskCategoriesTableAdapter
                Dim dt4 As New Cust.KYCStaticRiskCategoriesDataTable
                Dim row4 As Cust.KYCStaticRiskCategoriesRow = dt4.NewKYCStaticRiskCategoriesRow
                row4.Category = Me.TextBox1.Text
                row4.Active = "Active"
                row4.EditBy = Me.hfEditBy.Value
                row4.EditDate = System.DateTime.Now
                dt4.AddKYCStaticRiskCategoriesRow(row4)
                ta4.Update(dt4)
                Me.TextBox1.Text = ""
                Me.GridView1.DataBind()
                Me.DropDownList5.Items.Clear()
                Me.DropDownList5.DataBind()
            End Try
        Else
            Exit Sub
        End If
       
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then

            Dim dzUser As DZUserProfile = DZUserProfile.GetUserProfile(My.User.Name)

            Me.hfEditBy.Value = dzUser.AbbrName
            Dim MyPending As Integer = 0
            
            Dim ta1 As New CustTableAdapters.CUSTSelectTableAdapter
            Dim dt1 As Cust.CUSTSelectDataTable = ta1.GetDataByPendingApproval
            Try
                For Each row1 As Cust.CUSTSelectRow In dt1.Rows
                    If row1.RiskCompDate <> "01/01/1900" Then
                        MyPending = MyPending + 1
                    End If
                Next
                If MyPending > 0 Then
                    Me.Label13.Text = "Accounts are Pending Risk Approval.  Static data changes should NOT be made."
                    Me.Label13.ForeColor = Drawing.Color.Red
                    Me.Label19.Text = "Accounts are Pending Risk Approval.  Static data changes should NOT be made."
                    Me.Label19.ForeColor = Drawing.Color.Red
                Else
                    Me.Label13.Text = "No Accounts are Pending Risk Approval.  Static data changes can be made safely."
                    Me.Label13.ForeColor = Drawing.Color.Blue
                    Me.Label19.Text = "No Accounts are Pending Risk Approval.  Static data changes can be made safely."
                    Me.Label19.ForeColor = Drawing.Color.Blue
                End If
            Catch
                Me.Label13.Text = "No Accounts are Pending Risk Approval.  Static data changes can be made safely."
                Me.Label13.ForeColor = Drawing.Color.Blue
                Me.Label19.Text = "No Accounts are Pending Risk Approval.  Static data changes can be made safely."
                Me.Label19.ForeColor = Drawing.Color.Blue
            End Try
        End If
    End Sub

    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
        For i As Integer = 0 To GridView2.Rows.Count - 1
            Dim ta As New CustTableAdapters.KYCStaticRiskCategoriesTableAdapter
            Dim dt As Cust.KYCStaticRiskCategoriesDataTable = ta.GetDataByCategory(GridView2.Rows(i).Cells(1).Text)
            Dim row As Cust.KYCStaticRiskCategoriesRow
            Try
                row = dt(0)
                If row.Active = "Inactive" Then
                    GridView2.Rows(i).Enabled = False
                Else
                    GridView2.Rows(i).Enabled = True
                End If
            Catch ex As Exception
            End Try
        Next
    End Sub

    Protected Sub GridView1_RowUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdatedEventArgs) Handles GridView1.RowUpdated
        Me.DropDownList5.Items.Clear()
        Me.DropDownList5.DataBind()
        Me.hfCatChange.Value = e.OldValues("Category")
        Dim ta As New CustTableAdapters.KYCStaticRiskTableAdapter
        Dim dt As Cust.KYCStaticRiskDataTable = ta.GetDataByCategory(Me.hfCatChange.Value)
        For Each row As Cust.KYCStaticRiskRow In dt.Rows
            row.Category = e.NewValues("Category")
            row.Active = e.NewValues("Active")
        Next
        ta.Update(dt)
        Me.GridView2.DataBind()

    End Sub

    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        e.NewValues("EditDate") = System.DateTime.Now
        e.NewValues("EditBy") = Me.hfEditBy.Value
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Me.TextBox2.Text.Length > 0 And Me.DropDownList5.SelectedValue <> "Select Category" Then
            Dim ta As New CustTableAdapters.KYCStaticRiskTableAdapter
            Dim dt As Cust.KYCStaticRiskDataTable = ta.GetDataByCategoryDesc(Me.DropDownList5.SelectedValue, Me.TextBox2.Text)
            Dim row As Cust.KYCStaticRiskRow
            Try
                row = dt(0)
            Catch
                Dim ta4 As New CustTableAdapters.KYCStaticRiskTableAdapter
                Dim dt4 As New Cust.KYCStaticRiskDataTable
                Dim row4 As Cust.KYCStaticRiskRow = dt4.NewKYCStaticRiskRow
                row4.Category = Me.DropDownList5.SelectedValue
                row4.Rating = Me.DropDownList3.SelectedValue
                row4.Description = Me.TextBox2.Text
                Select Case row4.Rating
                    Case "NA"
                        row4.Score = 0
                    Case "Low"
                        row4.Score = 10
                    Case "Medium"
                        row4.Score = 20
                    Case "High"
                        row4.Score = 30
                End Select
                row4.AutoTo = Me.DropDownList4.SelectedValue
                row4.Active = "Active"
                row4.EditBy = Me.hfEditBy.Value
                row4.EditDate = System.DateTime.Now
                dt4.AddKYCStaticRiskRow(row4)
                ta4.Update(dt4)
                Me.TextBox2.Text = ""
                Me.GridView2.DataBind()
                Me.DropDownList5.SelectedIndex = -1
                Me.DropDownList3.SelectedIndex = -1
                Me.DropDownList4.SelectedIndex = -1
            End Try
        Else
            Exit Sub
        End If
    End Sub
    Protected Sub GridView2_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView2.RowUpdating
        If e.NewValues("Rating") = "NA" Then
            e.NewValues("Score") = 0
            e.NewValues("Description") = "Not Applicable"
        End If
        e.NewValues("Category") = e.OldValues("Category")
        e.NewValues("EditDate") = System.DateTime.Now
        e.NewValues("EditBy") = Me.hfEditBy.Value
    End Sub

    Protected Sub GridView3_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView3.RowUpdating
        e.NewValues("Country") = e.OldValues("Country")
        e.NewValues("RatingDate") = System.DateTime.Now
    End Sub
End Class
