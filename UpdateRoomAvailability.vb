'Description: to update room availability

Imports System.Data
Imports System.Data.SqlClient

Public Class UpdateRoomAvailability
    Dim con As New SqlConnection
    Dim da As New SqlDataAdapter
    Dim com As SqlCommand
    Dim ds As New DataSet
    Dim getemp As String
    Dim dr As SqlDataReader
    'Function text_r_no_TextChanged() is to fill up the room number that want to be updated
    'TextBox1_TextChanged changed to text_r_no.TextChanged

    Private Sub text_r_no_TextChanged(sender As Object, e As EventArgs) Handles text_r_no.TextChanged
        con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MS\Downloads\SEM project\HotelManagementSystemInVB\HotelManagementSystemInVB\HotelManagementSystemInVB\Database1.mdf;Integrated Security=True")
        con.Open()

        Try
            getemp = "select r_type, r_rate, no_person, no_bed from room where r_no='" & text_r_no.Text & "'"
            com = New SqlCommand(getemp, con)
            dr = com.ExecuteReader()
            If dr.Read() Then
                label_r_type.Text = dr.GetValue(0).ToString()
                label_r_rate.Text = dr.GetValue(1).ToString()
                label_no_person.Text = dr.GetValue(2).ToString()
                label_no_bed.Text = dr.GetValue(3).ToString()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    'Function button_update_Click() is to update the room into the system
    'Function ComboBox1.Text is to choose whther the room is available or not into the system
    'Button1 changed to button_update
    'Combobox1 changed to combo_availability

    Private Sub button_update_Click(sender As Object, e As EventArgs) Handles button_update.Click
        con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MS\Downloads\SEM project\HotelManagementSystemInVB\HotelManagementSystemInVB\HotelManagementSystemInVB\Database1.mdf;Integrated Security=True")
        com = New SqlCommand(" update room set r_availability='" + combo_availability.Text + "' where r_no= '" & text_r_no.Text & "'", con)
        con.Open()
        com.ExecuteNonQuery()
        MsgBox("Check Out Data updated successfully..")
        Hide()
        con.Close()
    End Sub
    'Function button_reset_Click(): Reset the details that has been filled to the form
    'textbox and label has changed the name to be more precise

    Private Sub button_reset_Click(sender As Object, e As EventArgs) Handles button_reset.Click
        text_r_no.Text = ""
        label_r_type.Text = ""
        label_r_rate.Text = ""
        label_no_person.Text = ""
        label_no_bed.Text = ""
    End Sub
End Class