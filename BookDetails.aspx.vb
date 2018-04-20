Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient

'Tyler Clark

Partial Class BookDetails
    Inherits System.Web.UI.Page

    'On load it will get the details from the query string and populate the page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim ISBN As String = Request.QueryString("ISBN")
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Server.MapPath("~/Access/bookstore.accdb"))
        conn.Open()
        Dim sql As String = "SELECT * FROM Books WHERE ISBN = @ISBN"
        Dim cmd As New OleDb.OleDbCommand(sql, conn)
        cmd.Parameters.AddWithValue("@ISBN", ISBN)
        Dim rd As OleDbDataReader
        rd = cmd.ExecuteReader()

        If rd.Read Then
            lbl1.Text = "ISBN: " & rd.GetString(0)
            lbl2.Text = "Title: " & rd.GetString(1)
            If rd.GetInt32(2) = 0 Then
                rateLink.Text = String.Format("<img src='{0}'/>", "Resources/0star.gif")
            ElseIf rd.GetInt32(2) = 1 Then
                rateLink.Text = String.Format("<img src='{0}'/>", "Resources/1star.gif")
            ElseIf rd.GetInt32(2) = 2 Then
                rateLink.Text = String.Format("<img src='{0}'/>", "Resources/2star.gif")
            ElseIf rd.GetInt32(2) = 3 Then
                rateLink.Text = String.Format("<img src='{0}'/>", "Resources/3star.gif")
            ElseIf rd.GetInt32(2) = 4 Then
                rateLink.Text = String.Format("<img src='{0}'/>", "Resources/4star.gif")
            ElseIf rd.GetInt32(2) = 5 Then
                rateLink.Text = String.Format("<img src='{0}'/>", "Resources/5star.gif")
            End If
            totalLbl.Text += rd.GetInt32(4) & ")"
            rateLink.NavigateUrl &= "ISBN=" & Request.QueryString("ISBN") & "&CID=" & Request.QueryString("CID") & "&cName=" & Request.QueryString("cName") & "&tRates=" & rd.GetInt32(4).ToString
            lbl4.Text = "Price: " & rd.GetDouble(3)
        End If
        cmd.Dispose()
        conn.Close()
    End Sub

    'Back button
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim url As String = "~/BookListing.aspx?CID=" & Request.QueryString("CID") & "&cName=" & Request.QueryString("cName")
        Response.Redirect(url)
    End Sub
End Class
