
'Tyler Clark

Partial Class Backend
    Inherits System.Web.UI.Page

    Protected Sub manageBtn_Click(sender As Object, e As EventArgs) Handles manageBtn.Click
        Response.Redirect("Manage.aspx")
    End Sub

    Protected Sub insertBtn_Click(sender As Object, e As EventArgs) Handles insertBtn.Click
        Response.Redirect("Insert.aspx")
    End Sub

    Protected Sub homeBtn_Click(sender As Object, e As EventArgs) Handles homeBtn.Click
        Response.Redirect("Login.aspx")
    End Sub
End Class
