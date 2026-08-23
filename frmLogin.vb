Imports System.Windows.Forms

Public Class frmLogin
    Inherits Form

    Private lblUsuario As New Label()
    Private txtUsuario As New TextBox()
    Private lblPassword As New Label()
    Private txtPassword As New TextBox()
    Private btnEntrar As New Button()
    Private btnSalir As New Button()
    Private lblTitulo As New Label()

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        ' Configuración general del formulario
        Me.Text = "CaféConnect - Login"
        Me.Size = New Size(400, 300)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.FromArgb(34, 139, 34)
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False

        ' Label Título
        lblTitulo.Text = "🏪 CAFÉCONNECT"
        lblTitulo.Font = New Font("Arial", 18, FontStyle.Bold)
        lblTitulo.ForeColor = Color.White
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter
        lblTitulo.Location = New Point(0, 20)
        lblTitulo.Size = New Size(400, 40)
        Me.Controls.Add(lblTitulo)

        ' Label Usuario
        lblUsuario.Text = "Usuario:"
        lblUsuario.Font = New Font("Arial", 11, FontStyle.Bold)
        lblUsuario.ForeColor = Color.White
        lblUsuario.Location = New Point(50, 80)
        lblUsuario.AutoSize = True
        Me.Controls.Add(lblUsuario)

        ' TextBox Usuario
        txtUsuario.Location = New Point(50, 105)
        txtUsuario.Size = New Size(300, 30)
        txtUsuario.Font = New Font("Arial", 11)
        txtUsuario.Text = "admin"
        Me.Controls.Add(txtUsuario)

        ' Label Password
        lblPassword.Text = "Contraseña:"
        lblPassword.Font = New Font("Arial", 11, FontStyle.Bold)
        lblPassword.ForeColor = Color.White
        lblPassword.Location = New Point(50, 145)
        lblPassword.AutoSize = True
        Me.Controls.Add(lblPassword)

        ' TextBox Password
        txtPassword.Location = New Point(50, 170)
        txtPassword.Size = New Size(300, 30)
        txtPassword.Font = New Font("Arial", 11)
        txtPassword.UseSystemPasswordChar = True
        txtPassword.Text = "1234"
        Me.Controls.Add(txtPassword)

        ' Botón Entrar
        btnEntrar.Text = "✅ ENTRAR"
        btnEntrar.Location = New Point(50, 220)
        btnEntrar.Size = New Size(140, 40)
        btnEntrar.Font = New Font("Arial", 11, FontStyle.Bold)
        btnEntrar.BackColor = Color.FromArgb(0, 200, 0)
        btnEntrar.ForeColor = Color.White
        btnEntrar.FlatStyle = FlatStyle.Flat
        btnEntrar.Cursor = Cursors.Hand
        Me.Controls.Add(btnEntrar)

        ' Botón Salir
        btnSalir.Text = "❌ SALIR"
        btnSalir.Location = New Point(210, 220)
        btnSalir.Size = New Size(140, 40)
        btnSalir.Font = New Font("Arial", 11, FontStyle.Bold)
        btnSalir.BackColor = Color.FromArgb(200, 0, 0)
        btnSalir.ForeColor = Color.White
        btnSalir.FlatStyle = FlatStyle.Flat
        btnSalir.Cursor = Cursors.Hand
        Me.Controls.Add(btnSalir)

        ' Eventos
        AddHandler btnEntrar.Click, AddressOf btnEntrar_Click
        AddHandler btnSalir.Click, AddressOf btnSalir_Click
    End Sub

    Private Sub btnEntrar_Click(sender As Object, e As EventArgs)
        If txtUsuario.Text = "admin" AndAlso txtPassword.Text = "1234" Then
            MsgBox("✅ Bienvenido!", MsgBoxStyle.Information)
            ' Aquí se abre el formulario POS
            Me.Hide()
        Else
            MsgBox("�� Usuario o contraseña incorrectos", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub

End Class
