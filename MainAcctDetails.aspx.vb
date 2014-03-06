
Partial Class Customer_Main
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.IsPostBack = False Then
            Me.hfDept.Value = Request.QueryString("Dept")
            Me.hfRating.Value = Request.QueryString("Rating")
            If Me.hfDept.Value = "%" Then
                Me.Label3.Text = "Department: All Departments"
            Else
                Me.Label3.Text = "Department: " + Me.hfDept.Value
            End If
            Me.Label4.Text = "Risk Rating: " + Me.hfRating.Value
            Me.Label5.Text = "Number of Accounts: " & Me.GridView3.Rows.Count
        End If
    End Sub

    Protected Sub GridView3_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView3.DataBound
      
        For i As Integer = 0 To GridView3.Rows.Count - 1
            Select Case GridView3.Rows(i).Cells(4).Text
                Case "Low"
                    GridView3.Rows(i).Cells(4).BackColor = Drawing.Color.Lime
                Case "Medium"
                    GridView3.Rows(i).Cells(4).BackColor = Drawing.Color.Yellow
                Case "High"
                    GridView3.Rows(i).Cells(4).BackColor = Drawing.Color.Red
            End Select
        Next
    End Sub
End Class
