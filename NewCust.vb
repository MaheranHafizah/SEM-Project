'Description: to add a new customer information

Imports System.Data
Imports System.Data.SqlClient

Public Class NewCust
    Dim con As New SqlConnection
    Dim da As New SqlDataAdapter
    Dim com As SqlCommand
    Dim ds As New DataSet
    Dim dr As SqlDataReader
    Dim getcust As String
    'Function button_insert_Click() is to add the new customer into the system
    'System.Object changed to Object, System.EventArgs changed to EventArgs
    'Button1 changed button_insert

    Private Sub button_insert_Click(sender As Object, e As EventArgs) Handles button_insert.Click
        con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MS\Downloads\SEM project\HotelManagementSystemInVB\HotelManagementSystemInVB\HotelManagementSystemInVB\Database1.mdf;Integrated Security=True")
        com = New SqlCommand("insert into customer(name,mobile,nation,gender,city,state)values('" & text_name.Text & "','" & text_mobile.Text & "','" & text_nation.Text & "','" & combo_gender.Text & "','" & text_city.Text & "','" & text_state.Text & "')", con)
        con.Open()
        com.ExecuteNonQuery()
        getcust = "select max(id) from customer"
        com = New SqlCommand(getcust, con)
        dr = com.ExecuteReader()
        If dr.Read() Then
            MsgBox("Record inserted successfully..Your id is '" & dr.GetInt32(0) & "'")
            Hide()
        End If
        con.Close()
    End Sub
    'Function button_reset_Click(): Reset the details that has been filled to the form
    'Button2 changed to button_reset
    'textbox and combobox has changed the name to be more precise

    Private Sub button_reset_Click(sender As Object, e As EventArgs) Handles button_reset.Click
        text_name.Text = ""
        text_mobile.Text = ""
        text_nation.Text = ""
        text_city.Text = ""
        text_state.Text = ""
        combo_gender.Text = "--Select--"
    End Sub

End Class