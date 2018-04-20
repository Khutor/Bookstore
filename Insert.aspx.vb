Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient

'Tyler Clark

Partial Class Insert
    Inherits System.Web.UI.Page

    'When book is inserted
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Server.MapPath("~/Access/bookstore.accdb"))
        conn.Open()
        Dim sql As String = "INSERT INTO Books(ISBN , bTitle, bPrice ) VALUES( @ISBN, @title, @price )"
        Dim cmd As New OleDb.OleDbCommand(sql, conn)
        If Not (ISBN.Text = String.Empty Or title.Text = String.Empty Or price.Text = String.Empty) Then
            Try
                cmd.Parameters.AddWithValue("@ISBN", ISBN.Text.Trim())
                cmd.Parameters.AddWithValue("@bTitle", title.Text.Trim())
                cmd.Parameters.AddWithValue("@bPrice", price.Text)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                Message.Text = "The book " & title.Text & " (ISBN: " & ISBN.Text & ") was inserted into the database."
                ISBN.Text = ""
                title.Text = ""
                price.Text = ""
            Catch ex As OleDbException
                Message.Text = "Please verify you have entered data in the correct format or if data already exists."
            End Try
            conn.Close()
        Else
            Message.Text = "Please ensure all fields are filled and try again"
            conn.Close()
        End If
    End Sub

    'When back button pressed
    Protected Sub backBtn_Click(sender As Object, e As EventArgs) Handles backBtn.Click
        Response.Redirect("Backend.aspx")
    End Sub
End Class
