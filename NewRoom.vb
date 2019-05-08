'Description: to add a new room booking

Imports System.Data
Imports System.Data.SqlClient

Public Class NewRoom
    Dim con As New SqlConnection
    Dim da As New SqlDataAdapter
    Dim com As SqlCommand
    Dim ds As New DataSet
    'r means room
    'no means number
    'Button1 changed to button_insert
    'Function button_insert_Click() is to add the new room into the system
    'System.Object changed to Object, System.EventArgs changed to EventArgs

    Private Sub button_insert_Click(sender As Object, e As EventArgs) Handles button_insert.Click
        con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MS\Downloads\SEM project\HotelManagementSystemInVB\HotelManagementSystemInVB\HotelManagementSystemInVB\Database1.mdf;Integrated Security=True")
        com = New SqlCommand("insert into room(r_type,r_no,r_rate,no_person,no_bed)values('" & combo_r_type.Text & "','" & text_r_no.Text & "','" & text_r_rate.Text & "','" & combo_no_person.Text & "','" & combo_no_bed.Text & "')", con)
        con.Open()
        com.ExecuteNonQuery()
        MsgBox("Record inserted successfully..")
        Hide()
        con.Close()
    End Sub
    'Function button_reset_Click(): Reset the details that has been filled to the form
    'Button2 changed to button_reset
    'textbox and combobox has changed the name to be more precise

    Private Sub button_reset_Click(sender As Object, e As EventArgs) Handles button_reset.Click
        text_r_no.Text = ""
        text_r_rate.Text = ""
        combo_r_type.Text = "--Select Room--"
        combo_no_person.Text = "--Select Person--"
        combo_no_bed.Text = "--Select Bed--"
    End Sub

End Class