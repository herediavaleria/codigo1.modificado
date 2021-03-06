﻿Public Class FRM_CLIENTES_BUSCAR_B_M
    Dim datacontext As New DC_AdminDataContext
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_CLIE_BUS_SALIR.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub TB_CLIE_BUSCAR_DNI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_CLIE_BUSCAR_DNI.TextChanged
        Dim buscar As String
        If RB_CLIE_BUSCAR_DNI.Checked = True Then
            armargrilla()
            buscar = Me.TB_CLIE_BUSCAR_DNI.Text & "*"
            Dim consultaalu = From U In datacontext.CLIENTES Select U.ID_CLIENTE, U.CLI_NOMBRES, U.CLI_APELLIDO, U.CLI_DNI, U.CLI_DIRECCION, U.CLI_LOCALIDAD, U.CLI_TEL_1, U.CLI_TEL_2, U.CLI_MAIL Where CLI_DNI Like buscar.ToString
            DGV_CLIE_BUSCAR.DataSource = consultaalu
        End If
    End Sub

    Private Sub FMR_CLIENTES_BUSCAR_B_M_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        armargrilla()
        cargargrilla()

    End Sub

    Private Sub TB_CLIE_BUSCAR_APE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_CLIE_BUSCAR_APE.TextChanged
        Dim buscar As String
        If RB_CLIE_BUSCAR_APE.Checked = True Then
            armargrilla()
            buscar = "*" & Me.TB_CLIE_BUSCAR_APE.Text & "*"
            Dim consultaalu = From U In datacontext.CLIENTES Select U.ID_CLIENTE, U.CLI_NOMBRES, U.CLI_APELLIDO, U.CLI_DNI, U.CLI_DIRECCION, U.CLI_LOCALIDAD, U.CLI_TEL_1, U.CLI_TEL_2, U.CLI_MAIL Where CLI_APELLIDO Like buscar.ToString
            DGV_CLIE_BUSCAR.DataSource = consultaalu
        End If
    End Sub
    Private Sub armargrilla()
        DGV_CLIE_BUSCAR.Enabled = True
        DGV_CLIE_BUSCAR.AutoGenerateColumns = False
        DGV_CLIE_BUSCAR.Columns.Clear()

        DGV_CLIE_BUSCAR.Columns.Add("ID_CLIENTE", "ID_CLIENTE")
        DGV_CLIE_BUSCAR.Columns.Add("CLI_NOMBRES", "NOMBRES")
        DGV_CLIE_BUSCAR.Columns.Add("CLI_APELLIDO", "APELLIDO")
        DGV_CLIE_BUSCAR.Columns.Add("CLI_DNI", "DNI")
        DGV_CLIE_BUSCAR.Columns.Add("CLI_DIRECCION", "DIRECCION")
        DGV_CLIE_BUSCAR.Columns.Add("CLI_LOCALIDAD", "LOCALIDAD")
        DGV_CLIE_BUSCAR.Columns.Add("CLI_TEL_1", "TELEFONO 1")
        DGV_CLIE_BUSCAR.Columns.Add("CLI_TEL_2", "TELEFONO 2")
        DGV_CLIE_BUSCAR.Columns.Add("CLI_MAIL", "MAIL")

        DGV_CLIE_BUSCAR.Columns(0).DataPropertyName = "ID_CLIENTE"
        DGV_CLIE_BUSCAR.Columns(1).DataPropertyName = "CLI_NOMBRES"
        DGV_CLIE_BUSCAR.Columns(2).DataPropertyName = "CLI_APELLIDO"
        DGV_CLIE_BUSCAR.Columns(3).DataPropertyName = "CLI_DNI"
        DGV_CLIE_BUSCAR.Columns(4).DataPropertyName = "CLI_DIRECCION"
        DGV_CLIE_BUSCAR.Columns(5).DataPropertyName = "CLI_LOCALIDAD"
        DGV_CLIE_BUSCAR.Columns(6).DataPropertyName = "CLI_TEL_1"
        DGV_CLIE_BUSCAR.Columns(7).DataPropertyName = "CLI_TEL_2"
        DGV_CLIE_BUSCAR.Columns(8).DataPropertyName = "CLI_MAIL"

        DGV_CLIE_BUSCAR.ClearSelection()
       
    End Sub
    Public Sub cargargrilla()
        Dim consultaalu = From U In datacontext.CLIENTES Select U.ID_CLIENTE, U.CLI_NOMBRES, U.CLI_APELLIDO, U.CLI_DNI, U.CLI_DIRECCION, U.CLI_LOCALIDAD, U.CLI_TEL_1, U.CLI_TEL_2, U.CLI_MAIL
        DGV_CLIE_BUSCAR.DataSource = consultaalu
    End Sub

    Private Sub RB_CLIE_BUSCAR_DNI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_CLIE_BUSCAR_DNI.CheckedChanged
        TB_CLIE_BUSCAR_APE.Enabled = False
        TB_CLIE_BUSCAR_APE.Clear()
        TB_CLIE_BUSCAR_DNI.Enabled = True

    End Sub

    Private Sub RB_CLIE_BUSCAR_APE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_CLIE_BUSCAR_APE.CheckedChanged
        TB_CLIE_BUSCAR_DNI.Enabled = False
        TB_CLIE_BUSCAR_DNI.Clear()
        TB_CLIE_BUSCAR_APE.Enabled = True
    End Sub

    Private Sub BTN_CLIE_BUS_EDITAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_CLIE_BUS_EDITAR.Click
        If DGV_CLIE_BUSCAR.SelectedRows.Count > 0 Then
            FRM_CLIENTES_A_M.TB_CLIE_ID.Text = DGV_CLIE_BUSCAR.Item("ID_CLIENTE", DGV_CLIE_BUSCAR.SelectedRows(0).Index).Value
            FRM_CLIENTES_A_M.TB_CLIE_NOMBRES.Text = DGV_CLIE_BUSCAR.Item("CLI_NOMBRES", DGV_CLIE_BUSCAR.SelectedRows(0).Index).Value
            FRM_CLIENTES_A_M.TB_CLIE_APELLIDO.Text = DGV_CLIE_BUSCAR.Item("CLI_APELLIDO", DGV_CLIE_BUSCAR.SelectedRows(0).Index).Value
            FRM_CLIENTES_A_M.TB_CLIE_DNI.Text = DGV_CLIE_BUSCAR.Item("CLI_DNI", DGV_CLIE_BUSCAR.SelectedRows(0).Index).Value
            FRM_CLIENTES_A_M.TB_CLIE_DIRECCION.Text = DGV_CLIE_BUSCAR.Item("CLI_DIRECCION", DGV_CLIE_BUSCAR.SelectedRows(0).Index).Value
            FRM_CLIENTES_A_M.TB_CLIE_LOCALIDAD.Text = DGV_CLIE_BUSCAR.Item("CLI_LOCALIDAD", DGV_CLIE_BUSCAR.SelectedRows(0).Index).Value
            FRM_CLIENTES_A_M.TB_CLIE_TEL_1.Text = DGV_CLIE_BUSCAR.Item("CLI_TEL_1", DGV_CLIE_BUSCAR.SelectedRows(0).Index).Value
            FRM_CLIENTES_A_M.TB_CLIE_TEL_2.Text = DGV_CLIE_BUSCAR.Item("CLI_TEL_2", DGV_CLIE_BUSCAR.SelectedRows(0).Index).Value
            FRM_CLIENTES_A_M.TB_CLIE_MAIL.Text = DGV_CLIE_BUSCAR.Item("CLI_MAIL", DGV_CLIE_BUSCAR.SelectedRows(0).Index).Value

        End If
        FRM_CLIENTES_A_M.BTN_CLIE_GUARDAR.Visible = False
        FRM_CLIENTES_A_M.Show()
    End Sub

    Private Sub BTN_CLIE_BUS_ELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_CLIE_BUS_ELIMINAR.Click
        Dim eliminar = (From C In datacontext.CLIENTES Where C.ID_CLIENTE = CInt(DGV_CLIE_BUSCAR.Item("ID_CLIENTE", DGV_CLIE_BUSCAR.SelectedRows(0).Index).Value)).ToList()(0)

        'VALIDACIONES DE ELIMINAR CLIENTES
        'Dim comprobrar1 = (From C In datacontext.Alumno_x_curso Where C.id_alumno = CInt(txtidAlu.Text)).Any
        'Dim comprobrar2 = (From C In datacontext.Alumno_x_materia Where C.id_alumno = CInt(txtidAlu.Text)).Any

        'If comprobrar1 = True Or comprobrar2 = True Then
        'MsgBox("El registro no puede ser eliminado, posee inasistencia,notas y curso asociados!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Inicio de sesión")

        'Else
        Select Case MsgBox("Se eliminará el cliente seleccionado, desea continuar?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Eliminar cliente")
            Case MsgBoxResult.Yes
                datacontext.CLIENTES.DeleteOnSubmit(eliminar)
                datacontext.SubmitChanges()
                MsgBox("El cliente ha sido eliminado")
                Me.cargargrilla()
            'Case MsgBoxResult.No
            '    Me.cargargrilla()
        End Select
        

    End Sub
End Class