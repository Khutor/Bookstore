Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient

'Tyler Clark

Partial Class MyAccount
    Inherits System.Web.UI.Page

    'On load will get user's info from the url
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim CID As String = Request.QueryString("CID")
        SqlDataSource1.SelectCommand = "SELECT ISBN, Quantity FROM Orders WHERE CID = " & CID
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
            lbl3.Text = "Amount Spent: $" & rd.GetDouble(3)
        End If
        cmd.Dispose()
        conn.Close()
    End Sub

    'Back button pressed
    Protected Sub backBtn_Click(sender As Object, e As EventArgs) Handles backBtn.Click
        Dim name As String = Request.QueryString("cName")
        Dim url As String = "~/BookListing.aspx?CID=" & Request.QueryString("CID") & "&cName=" & name
        Response.Redirect(url)
    End Sub
End Class
