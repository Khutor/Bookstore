Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient

'Tyler Clark

Partial Class Reviews
    Inherits System.Web.UI.Page

    'On page load
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim book As String = Request.QueryString("ISBN")
        SqlDataSource1.SelectCommand = "SELECT ISBN, CID, rRate, rComment FROM Reviews WHERE ISBN = '" & book & "'"
    End Sub

    'When yes is checked
    Protected Sub yesRad_CheckedChanged(sender As Object, e As EventArgs) Handles yesRad.CheckedChanged
        ratingList.Visible = True
        reviewBtn.Visible = True
        commentBox.Visible = True
    End Sub

    'When no is checked
    Protected Sub noRad_CheckedChanged(sender As Object, e As EventArgs) Handles noRad.CheckedChanged
        ratingList.Visible = False
        reviewBtn.Visible = False
        commentBox.Visible = False
    End Sub

    'When user submits their review
    Protected Sub reviewBtn_Click(sender As Object, e As EventArgs) Handles reviewBtn.Click
        Dim rate As Integer = ratingList.SelectedValue
        Dim cmnt As String = commentBox.Text
        Dim ISBN As String = Request.QueryString("ISBN")
        Dim CID As String = Request.QueryString("CID")
        Dim totRates As Integer = Convert.ToInt32(Request.QueryString("tRates")) + 1

        'Places all the rates in the table into a list
        Dim rates As New List(Of Integer)
        Dim i As Integer = 0
        For Each gvrow As GridViewRow In GridView1.Rows
            gvrow = GridView1.Rows(i)
            rates.Add(GridView1.DataKeys(gvrow.RowIndex)("rRate"))
            i += 1
        Next

        'Gets the avereage rate
        Dim avgRate As Integer = 0
        i = 0
        For Each num In rates
            avgRate = avgRate + rates.Item(i)
            i += 1
        Next
        i += 1
        avgRate = (rate + avgRate) / i

        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Server.MapPath("~/Access/bookstore.accdb"))
        conn.Open()
        Dim sql As String
        If Not (commentBox.Text = String.Empty) Then
            'Inserts the review
            Try
                sql = "INSERT INTO Reviews(ISBN, CID, rRate, rComment) VALUES('" & ISBN & "', '" & CID & "', '" & rate & "', '" & cmnt & "')"
                Dim cmd As New OleDb.OleDbCommand(sql, conn)
                cmd.Parameters.AddWithValue("@ISBN", ISBN)
                cmd.Parameters.AddWithValue("@CID", CID)
                cmd.Parameters.AddWithValue("@rRate", rate)
                cmd.Parameters.AddWithValue("@rComment", cmnt)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                Message.Text = "Review successfully submitted"
                'Overrides previous review
            Catch ex As OleDbException
                Try
                    totRates -= 1
                    sql = "UPDATE Reviews SET rRate = '" & rate & "', rComment = '" & cmnt & "' WHERE ISBN = '" & ISBN & "' "
                    Dim cmd As New OleDb.OleDbCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@rRate", rate)
                    cmd.Parameters.AddWithValue("@rComment", cmnt)
                    cmd.Parameters.AddWithValue("@ISBN", ISBN)
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                Catch ex2 As OleDbException
                    Message.Text = "An error has occurred; please try again"
                End Try
            End Try
        Else
            Message.Text = "Please ensure all fields are filled and try again"

        End If
        sql = "UPDATE Books SET bRate = '" & avgRate & "',bTotRates = '" & totRates & "' WHERE ISBN = '" & ISBN & "'"
        Dim cmd2 As New OleDb.OleDbCommand(sql, conn)
        'Updates the book to the new average rate and the new total rates
        Try
            cmd2.Parameters.AddWithValue("@ISBN", ISBN)
            cmd2.Parameters.AddWithValue("@bRate", avgRate)
            cmd2.Parameters.AddWithValue("@bTotRates", totRates)
            cmd2.ExecuteNonQuery()
            cmd2.Dispose()
            Message.Text = "Review successfully submitted"
        Catch ex As OleDbException
            Message.Text = "An error has occurred; please try again"
        End Try
        conn.Close()
        GridView1.DataBind()

    End Sub

    'Back button
    Protected Sub backBtn_Click(sender As Object, e As EventArgs) Handles backBtn.Click
        Dim url As String = "~/BookDetails.aspx?ISBN=" & Request.QueryString("ISBN") & "&CID=" & Request.QueryString("CID") & "&cName=" & Request.QueryString("cName")
        Response.Redirect(url)
    End Sub
End Class
