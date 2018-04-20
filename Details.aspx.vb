Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient

'Tyler Clark

Partial Class Details
    Inherits System.Web.UI.Page

    'On load, the page will get the data from the url and populate page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        'Determines to fill book info
        If (Request.QueryString("ISBN") IsNot Nothing) Then
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
                lbl3.Text = "Rate: " & rd.GetInt32(2)
                lbl4.Text = "Price: " & rd.GetDouble(3)
            End If
            cmd.Dispose()
            conn.Close()
            'Determines to fill customer info
        ElseIf (Request.QueryString("CID") IsNot Nothing) Then
            Dim CID As String = Request.QueryString("CID")
            Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Server.MapPath("~/Access/bookstore.accdb"))
            conn.Open()
            Dim sql As String = "SELECT * FROM Customers WHERE CID = @CID"
            Dim cmd As New OleDb.OleDbCommand(sql, conn)
            cmd.Parameters.AddWithValue("@CID", CID)
            Dim rd As OleDbDataReader
            rd = cmd.ExecuteReader()

            If rd.Read Then
                lbl1.Text = "CID: " & rd.GetInt32(0)
                lbl2.Text = "Name: " & rd.GetString(1)
                lbl3.Text = "Password: " & rd.GetString(2)
                lbl4.Text = "Amount: " & rd.GetDouble(3)
            End If
            cmd.Dispose()
            conn.Close()
        End If

    End Sub

    'Goes back to viewing database
    Protected Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        Response.Redirect("Manage.aspx")
    End Sub
End Class
