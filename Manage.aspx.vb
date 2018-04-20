Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient

'Tyler Clark

Partial Class _Manage
    Inherits System.Web.UI.Page

    'Book class
    Protected Sub GridView3_RowDeleted(
        ByVal sender As Object, ByVal e As GridViewDeletedEventArgs)
        If (Not e.Exception Is Nothing) Then
            MessageLabel.Text = "Failed to DELETE due to foreign key contstraint. "
            MessageLabel.Text += "You may only delete rows which have no related records."
            e.ExceptionHandled = True
        End If
        MessageLabel.Text = "Data deleted successfully"
    End Sub

    'Customer Class
    Protected Sub GridView1_RowDeleted(
        ByVal sender As Object, ByVal e As GridViewDeletedEventArgs)
        If (Not e.Exception Is Nothing) Then
            MessageLabel.Text = "Failed to DELETE due to foreign key contstraint. "
            MessageLabel.Text += "You may only delete rows which have no related records."
            e.ExceptionHandled = True
        End If
        MessageLabel.Text = "Data deleted successfully"
    End Sub

    'Go Home button
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("Backend.aspx")
    End Sub

    'Delete from database button
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Server.MapPath("~/Access/bookstore.accdb"))
        conn.Open()
        Dim sql As String = "DELETE * FROM Books"
        Dim sql2 As String = "DELETE * FROM Customers"
        Dim cmd As New OleDb.OleDbCommand(sql, conn)
        Dim cmd2 As New OleDb.OleDbCommand(sql2, conn)
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        cmd2.ExecuteNonQuery()
        cmd2.Dispose()
        conn.Close()
        Response.Redirect("Manage.aspx")
    End Sub
End Class