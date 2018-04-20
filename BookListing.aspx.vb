Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient

'Tyler Clark

Partial Class BookListing
    Inherits System.Web.UI.Page

    'On load, it will set the account link's url
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        welcomelbl.Text = "Welcome, " & Request.QueryString("cName")
        accntLink.NavigateUrl = String.Format(accntLink.NavigateUrl, Request.QueryString("CID"))
        accntLink.NavigateUrl &= "&cName=" & Request.QueryString("cName")

        If (Request.QueryString("cName") = "Admin") Then
            accntLink.Text = "Backend Access"
            accntLink.NavigateUrl = "~/Backend.aspx?CID=0&cName=Admin"
        End If
    End Sub

    'Sets which list is visible based on dropdownlist
    Protected Sub searchSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles searchSelect.SelectedIndexChanged
        If searchSelect.SelectedValue = "Rating" Then
            ratingList.Visible = True
            ratingList.Enabled = True
            priceList.Visible = False
            priceList.Enabled = False
            orderBtn.Visible = True

        ElseIf searchSelect.SelectedValue = "Price" Then
            priceList.Visible = True
            priceList.Enabled = True
            ratingList.Visible = False
            ratingList.Enabled = False
            orderBtn.Visible = True
        Else
            priceList.Visible = False
            ratingList.Visible = False
            priceList.Enabled = False
            ratingList.Enabled = False
            orderBtn.Visible = False
        End If
    End Sub

    'Binds the data to the repeater
    Sub searchResult_ItemDataBound(ByVal sender As Object, ByVal e As RepeaterItemEventArgs) Handles searchResult.ItemDataBound
        Dim ISBN As Label = CType(e.Item.FindControl("ISBN"), Label)
        If Not IsNothing(ISBN) Then
            ISBN.Text = e.Item.DataItem("ISBN")
        End If

        Dim bTitle As HyperLink = CType(e.Item.FindControl("bTitle"), HyperLink)
        If Not IsNothing(bTitle) Then
            bTitle.Text = e.Item.DataItem("bTitle")
            bTitle.NavigateUrl &= "&CID=" & Request.QueryString("CID") & "&cName=" & Request.QueryString("cName")
        End If

        Dim bPrice As Label = CType(e.Item.FindControl("bPrice"), Label)
        If Not IsNothing(ISBN) Then
            bPrice.Text = e.Item.DataItem("bPrice")
        End If

    End Sub

    'If rating list value is checked
    Protected Sub ratingList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ratingList.SelectedIndexChanged
        Dim rating As Integer = ratingList.SelectedValue
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Server.MapPath("~/Access/bookstore.accdb"))
        conn.Open()
        Dim sql As String = "SELECT ISBN, bTitle, bPrice FROM Books WHERE bRate >= @rating"
        Dim cmd As New OleDb.OleDbCommand(sql, conn)
        cmd.Parameters.AddWithValue("@bRate", rating)
        Dim dbread = cmd.ExecuteReader()
        searchResult.DataSource = dbread
        searchResult.DataBind()
        dbread.Close()
        cmd.Dispose()
        conn.Close()
    End Sub

    'If price list value is checked
    Protected Sub priceList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles priceList.SelectedIndexChanged
        Dim price As Integer = priceList.SelectedValue
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Server.MapPath("~/Access/bookstore.accdb"))
        conn.Open()
        Dim sql As String = "SELECT ISBN, bTitle, bPrice FROM Books WHERE bPrice >= @price"
        Dim cmd As New OleDb.OleDbCommand(sql, conn)
        cmd.Parameters.AddWithValue("@bPrice", price)
        Dim dbread = cmd.ExecuteReader()
        searchResult.DataSource = dbread
        searchResult.DataBind()
        dbread.Close()
        cmd.Dispose()
        conn.Close()
    End Sub

    'Submits an order
    Protected Sub orderBtn_Click(sender As Object, e As EventArgs) Handles orderBtn.Click
        Dim CheckBox1 As CheckBox
        Dim lblISBN As Label
        Dim lblQuant As TextBox
        Dim lblPrice As Label
        Dim calc As Double
        Dim totAmount As Double
        Dim ID As Integer = Request.QueryString("CID")
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Server.MapPath("~/Access/bookstore.accdb"))
        conn.Open()
        Dim currAmnt As Double
        'Loops through repeater, creating the orders
        Dim i As Integer
        For i = 0 To searchResult.Items.Count - 1
            CheckBox1 = searchResult.Items(i).FindControl("CheckBox1")
            lblISBN = searchResult.Items(i).FindControl("ISBN")
            lblQuant = searchResult.Items(i).FindControl("Quantity")
            lblPrice = searchResult.Items(i).FindControl("bPrice")
            'Inserts if checkbox checked
            If CheckBox1.Checked = True Then
                Try
                    Dim sql As String = "INSERT INTO Orders(ISBN, CID, Quantity) VALUES('" & lblISBN.Text & "', " & ID & ", " & Convert.ToInt32(lblQuant.Text) & ")"
                    Dim cmd As New OleDb.OleDbCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@ISBN", lblISBN.Text)
                    cmd.Parameters.AddWithValue("@CID", ID)
                    cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(lblQuant.Text))
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                    sql = "SELECT cAmount FROM Customers WHERE CID = @CID"
                    Dim cmd2 As New OleDb.OleDbCommand(sql, conn)
                    cmd2.Parameters.AddWithValue("@CID", ID)
                    Dim rd = cmd2.ExecuteReader()
                    While rd.Read
                        currAmnt = rd.Item("cAmount")
                    End While
                    rd.Dispose()
                    rd.Close()
                    cmd2.Dispose()
                    calc = Convert.ToDouble(lblPrice.Text) * Convert.ToDouble(lblQuant.Text)
                    totAmount += calc + currAmnt
                Catch ex As OleDbException
                    'If order already placed, quantity is updated
                    currAmnt = 0
                    Try
                        Dim sql As String = "UPDATE Orders SET Quantity = " & Convert.ToInt32(lblQuant.Text) & " WHERE CID = " & ID
                        Dim cmd As New OleDb.OleDbCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@CID", ID)
                        cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(lblQuant.Text))
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()
                        sql = "SELECT cAmount FROM Customers WHERE CID = @CID"
                        Dim cmd2 As New OleDb.OleDbCommand(sql, conn)
                        cmd2.Parameters.AddWithValue("@CID", ID)
                        Dim rd = cmd2.ExecuteReader()
                        While rd.Read
                            currAmnt = rd.Item("cAmount")
                        End While
                        rd.Dispose()
                        rd.Close()
                        cmd2.Dispose()
                        calc = Convert.ToDouble(lblPrice.Text) * Convert.ToDouble(lblQuant.Text)
                        totAmount += calc + currAmnt
                    Catch ex2 As OleDbException
                        msgLbl.Text = "An error has occurred; please try again"
                    End Try
                End Try
            End If
        Next
        Try
            'Updates the customers total amount ordered
            Dim sql2 As String = "UPDATE Customers SET cAmount = " & totAmount & " WHERE CID = " & ID
            Dim cmd2 As New OleDb.OleDbCommand(sql2, conn)
            cmd2.Parameters.AddWithValue("@CID", ID)
            cmd2.Parameters.AddWithValue("@cAmount", totAmount)
            cmd2.ExecuteNonQuery()
            cmd2.Dispose()
            msgLbl.Text = "Order(s) successfully placed; check your account to view order history"
        Catch ex As OleDbException
            msgLbl.Text = "An error has occurred; please try again"
        End Try
    End Sub
End Class
