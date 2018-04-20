Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient

'Tyler Clark

Partial Class Login
    Inherits System.Web.UI.Page

    'When user logs in
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim uname As String = userTxt.Text
        Dim pass As String = passTxt.Text

        'checks to see if user is admin (pretty unsecure)
        If uname = "admin" And pass = "123" Then
            Response.Redirect("~\BookListing.aspx?CID=0&cName=Admin")
        Else
            'Gets user info from database
            Try
                Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Server.MapPath("~/Access/bookstore.accdb"))
                conn.Open()
                Dim sql As String = "SELECT * FROM Customers WHERE cName ='" & uname & "' AND cPass ='" & pass & "'"
                Dim cmd As New OleDb.OleDbCommand(sql, conn)
                cmd.Parameters.AddWithValue("@cName", uname)
                cmd.Parameters.AddWithValue("@cPass", pass)
                Dim rd As OleDbDataReader
                rd = cmd.ExecuteReader()
                If rd.Read Then
                    Response.Redirect("~\BookListing.aspx?CID=" & rd.GetInt32(0) & "&cName=" & rd.GetString(1))
                Else
                    Label4.Text = "Name/Password is incorrect"
                End If
                conn.Close()
            Catch ex As OleDbException
            End Try
        End If
    End Sub

    'Takes user to the registration page
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("Register.aspx")
    End Sub
End Class
