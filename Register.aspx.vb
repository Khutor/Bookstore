Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient

'Tyler Clark

Partial Class Register
    Inherits System.Web.UI.Page

    'Registers a user into the database
    Protected Sub RegisterUser(sender As Object, e As EventArgs)
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Server.MapPath("~/Access/bookstore.accdb"))
        conn.Open()
        Dim sql As String = "INSERT INTO Customers(cName, cPass, cAmount) VALUES(@name, @pass, 0)"
        Dim cmd As New OleDb.OleDbCommand(sql, conn)
        If Not (txtName.Text = String.Empty Or txtPass.Text = String.Empty Or txtConfirmPass.Text = String.Empty) Then
            Try
                cmd.Parameters.AddWithValue("@cName", txtName.Text.Trim())
                cmd.Parameters.AddWithValue("@cPass", txtPass.Text)
                cmd.Parameters.AddWithValue("@cAmount", 0)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            Catch ex As OleDbException
                Message.Text = "Name already exists in the database"
            End Try
            conn.Close()
            txtName.Text = ""
            Message.Text = "Account successfully created. Please go back and login."
        End If
    End Sub

    'Back button clicked
    Protected Sub returnBtn_Click(sender As Object, e As EventArgs) Handles returnBtn.Click
        Response.Redirect("Login.aspx")
    End Sub
End Class
