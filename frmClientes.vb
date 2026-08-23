Imports System.Windows.Forms
Imports System.Drawing

Public Class frmClientes
    Inherits Form

    ' PANELES
    Private pnlIzquierdo As New Panel()
    Private pnlCentral As New Panel()
    
    ' MENU IZQUIERDO
    Private lblLogo As New Label()
    Private lblUsuario As New Label()
    
    ' PANEL SUPERIOR
    Private pnlTop As New Panel()
    Private txtBuscar As New TextBox()
    Private btnBuscar As New Button()
    Private btnAgregar As New Button()
    Private btnEditar As New Button()
    Private btnEliminar As New Button()
    
    ' GRILLA CLIENTES
    Private dgvClientes As New DataGridView()
    
    ' PANEL DETALLE CLIENTE
    Private pnlDetalle As New Panel()
    Private picCliente As New PictureBox()
    Private lblNombreDetalle As New Label()
    Private lblIDDetalle As New Label()
    Private lblTelDetalle As New Label()
    Private lblPuntosDetalle As New Label()
    Private dgvHistorial As New DataGridView()

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.Text = "CaféConnect - Clientes & Puntos de Fidelización"
        Me.Size = New Size(1400, 800)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.White
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False

        ' ===== PANEL IZQUIERDO (MENU) =====
        pnlIzquierdo.Dock = DockStyle.Left
        pnlIzquierdo.Width = 200
        pnlIzquierdo.BackColor = Color.FromArgb(40, 40, 40)
        Me.Controls.Add(pnlIzquierdo)

        ' Logo
        lblLogo.Text = "☕ CaféConnect" & vbCrLf & "Red de Cafeterías"
        lblLogo.Font = New Font("Arial", 10, FontStyle.Bold)
        lblLogo.ForeColor = Color.White
        lblLogo.TextAlign = ContentAlignment.TopCenter
        lblLogo.Dock = DockStyle.Top
        lblLogo.Height = 80
        lblLogo.BorderStyle = BorderStyle.FixedSingle
        pnlIzquierdo.Controls.Add(lblLogo)

        ' Info Usuario
        lblUsuario.Text = "Eliud García" & vbCrLf & "Administrador"
        lblUsuario.Font = New Font("Arial", 9, FontStyle.Bold)
        lblUsuario.ForeColor = Color.White
        lblUsuario.TextAlign = ContentAlignment.MiddleCenter
        lblUsuario.Dock = DockStyle.Top
        lblUsuario.Height = 60
        pnlIzquierdo.Controls.Add(lblUsuario)

        ' Botones del menú
        Dim botones As String() = {"🏠 Inicio", "🛒 Ventas (POS)", "📦 Inventario", "👥 Clientes", 
                                    "⭐ Puntos", "📊 Reportes", "👨‍💼 Empleados", "🏢 Sucursales", 
                                    "⚙️ Configuración", "🚪 Cerrar sesión"}
        
        For Each btn In botones
            Dim newBtn As New Button()
            newBtn.Text = btn
            newBtn.Dock = DockStyle.Top
            newBtn.Height = 50
            newBtn.Font = New Font("Arial", 9)
            newBtn.ForeColor = Color.White
            newBtn.BackColor = Color.FromArgb(60, 60, 60)
            newBtn.FlatStyle = FlatStyle.Flat
            newBtn.FlatAppearance.BorderSize = 0
            newBtn.Cursor = Cursors.Hand
            pnlIzquierdo.Controls.Add(newBtn)
        Next

        ' ===== PANEL CENTRAL =====
        pnlCentral.Dock = DockStyle.Fill
        pnlCentral.BackColor = Color.FromArgb(245, 245, 245)
        pnlCentral.Padding = New Padding(10)
        Me.Controls.Add(pnlCentral)

        ' PANEL TOP
        Dim pnlTop As New Panel()
        pnlTop.Dock = DockStyle.Top
        pnlTop.Height = 100
        pnlTop.BackColor = Color.White
        pnlTop.Padding = New Padding(10)
        pnlTop.BorderStyle = BorderStyle.FixedSingle
        pnlCentral.Controls.Add(pnlTop)

        Dim lblClientes As New Label()
        lblClientes.Text = "👥 CLIENTES - PUNTOS DE FIDELIZACIÓN"
        lblClientes.Font = New Font("Arial", 14, FontStyle.Bold)
        lblClientes.Location = New Point(10, 5)
        lblClientes.AutoSize = True
        pnlTop.Controls.Add(lblClientes)

        Dim lblBuscar As New Label()
        lblBuscar.Text = "Buscar cliente (ID, nombre, teléfono):"
        lblBuscar.Font = New Font("Arial", 10, FontStyle.Bold)
        lblBuscar.Location = New Point(10, 35)
        lblBuscar.AutoSize = True
        pnlTop.Controls.Add(lblBuscar)

        txtBuscar.Location = New Point(290, 32)
        txtBuscar.Size = New Size(250, 25)
        txtBuscar.Font = New Font("Arial", 10)
        pnlTop.Controls.Add(txtBuscar)

        btnBuscar.Text = "🔍 Buscar"
        btnBuscar.Location = New Point(550, 32)
        btnBuscar.Size = New Size(100, 25)
        btnBuscar.BackColor = Color.FromArgb(100, 100, 100)
        btnBuscar.ForeColor = Color.White
        btnBuscar.FlatStyle = FlatStyle.Flat
        btnBuscar.Cursor = Cursors.Hand
        pnlTop.Controls.Add(btnBuscar)

        btnAgregar.Text = "➕ Agregar"
        btnAgregar.Location = New Point(660, 32)
        btnAgregar.Size = New Size(100, 25)
        btnAgregar.BackColor = Color.FromArgb(34, 139, 34)
        btnAgregar.ForeColor = Color.White
        btnAgregar.FlatStyle = FlatStyle.Flat
        btnAgregar.Cursor = Cursors.Hand
        pnlTop.Controls.Add(btnAgregar)

        btnEditar.Text = "✏️ Editar"
        btnEditar.Location = New Point(770, 32)
        btnEditar.Size = New Size(100, 25)
        btnEditar.BackColor = Color.FromArgb(0, 100, 200)
        btnEditar.ForeColor = Color.White
        btnEditar.FlatStyle = FlatStyle.Flat
        btnEditar.Cursor = Cursors.Hand
        pnlTop.Controls.Add(btnEditar)

        btnEliminar.Text = "❌ Eliminar"
        btnEliminar.Location = New Point(880, 32)
        btnEliminar.Size = New Size(100, 25)
        btnEliminar.BackColor = Color.FromArgb(200, 0, 0)
        btnEliminar.ForeColor = Color.White
        btnEliminar.FlatStyle = FlatStyle.Flat
        btnEliminar.Cursor = Cursors.Hand
        pnlTop.Controls.Add(btnEliminar)

        ' PANEL MAIN CON DOS SECCIONES
        Dim pnlMain As New Panel()
        pnlMain.Dock = DockStyle.Fill
        pnlMain.BackColor = Color.FromArgb(245, 245, 245)
        pnlCentral.Controls.Add(pnlMain)

        ' ===== GRILLA CLIENTES (IZQUIERDA) =====
        Dim pnlGrilla As New Panel()
        pnlGrilla.Dock = DockStyle.Left
        pnlGrilla.Width = 700
        pnlGrilla.BackColor = Color.FromArgb(245, 245, 245)
        pnlGrilla.Padding = New Padding(0, 0, 5, 0)
        pnlMain.Controls.Add(pnlGrilla)

        dgvClientes.Dock = DockStyle.Fill
        dgvClientes.AllowUserToAddRows = False
        dgvClientes.ReadOnly = True
        dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvClientes.BackgroundColor = Color.White
        dgvClientes.BorderStyle = BorderStyle.FixedSingle
        dgvClientes.GridColor = Color.LightGray
        
        ' Columnas
        dgvClientes.Columns.Add("ID", "ID Cliente")
        dgvClientes.Columns.Add("Nombre", "Nombre")
        dgvClientes.Columns.Add("Puntos", "Puntos")
        dgvClientes.Columns.Add("Nivel", "Nivel")
        
        pnlGrilla.Controls.Add(dgvClientes)

        ' Agregar datos de ejemplo
        dgvClientes.Rows.Add("CLI00025", "Juan Pérez", 850, "🥇 Oro")
        dgvClientes.Rows.Add("CLI00017", "María López", 620, "🥈 Plata")
        dgvClientes.Rows.Add("CLI00033", "Carlos Martínez", 320, "🥉 Bronce")
        dgvClientes.Rows.Add("CLI00008", "Ana Gómez", 150, "🔵 Básico")
        dgvClientes.Rows.Add("CLI00041", "Luis Hernández", 90, "🔵 Básico")

        ' ===== PANEL DETALLE CLIENTE (DERECHA) =====
        pnlDetalle.Dock = DockStyle.Fill
        pnlDetalle.BackColor = Color.White
        pnlDetalle.Padding = New Padding(15)
        pnlDetalle.BorderStyle = BorderStyle.FixedSingle
        pnlMain.Controls.Add(pnlDetalle)

        ' Foto del cliente
        picCliente.Size = New Size(120, 120)
        picCliente.Location = New Point(40, 10)
        picCliente.BackColor = Color.FromArgb(200, 200, 200)
        picCliente.BorderStyle = BorderStyle.FixedSingle
        pnlDetalle.Controls.Add(picCliente)

        ' Info del cliente
        lblNombreDetalle.Text = "Juan Pérez"
        lblNombreDetalle.Font = New Font("Arial", 12, FontStyle.Bold)
        lblNombreDetalle.Location = New Point(15, 140)
        lblNombreDetalle.Width = 200
        pnlDetalle.Controls.Add(lblNombreDetalle)

        lblIDDetalle.Text = "ID: CLI00025"
        lblIDDetalle.Font = New Font("Arial", 9)
        lblIDDetalle.Location = New Point(15, 165)
        lblIDDetalle.Width = 200
        pnlDetalle.Controls.Add(lblIDDetalle)

        lblTelDetalle.Text = "Tel: 9876-5432"
        lblTelDetalle.Font = New Font("Arial", 9)
        lblTelDetalle.Location = New Point(15, 185)
        lblTelDetalle.Width = 200
        pnlDetalle.Controls.Add(lblTelDetalle)

        lblPuntosDetalle.Text = "Puntos Acumulados: 850"
        lblPuntosDetalle.Font = New Font("Arial", 11, FontStyle.Bold)
        lblPuntosDetalle.ForeColor = Color.FromArgb(34, 139, 34)
        lblPuntosDetalle.Location = New Point(15, 210)
        lblPuntosDetalle.Width = 200
        pnlDetalle.Controls.Add(lblPuntosDetalle)

        ' Niveles y Recompensas
        Dim lblNiveles As New Label()
        lblNiveles.Text = "NIVELES Y RECOMPENSAS"
        lblNiveles.Font = New Font("Arial", 10, FontStyle.Bold)
        lblNiveles.Location = New Point(15, 245)
        lblNiveles.AutoSize = True
        pnlDetalle.Controls.Add(lblNiveles)

        Dim dgvNiveles As New DataGridView()
        dgvNiveles.Location = New Point(15, 270)
        dgvNiveles.Size = New Size(260, 150)
        dgvNiveles.AllowUserToAddRows = False
        dgvNiveles.ReadOnly = True
        dgvNiveles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvNiveles.BackgroundColor = Color.White
        dgvNiveles.Columns.Add("Nivel", "Nivel")
        dgvNiveles.Columns.Add("Rango", "Rango Puntos")
        dgvNiveles.Columns.Add("Recompensa", "Recompensa")
        pnlDetalle.Controls.Add(dgvNiveles)

        dgvNiveles.Rows.Add("🔵 Básico", "0 - 249 pts", "Café gratis")
        dgvNiveles.Rows.Add("🥉 Bronce", "250 - 499 pts", "Pastel gratis")
        dgvNiveles.Rows.Add("🥈 Plata", "500 - 749 pts", "Café + Pastel")
        dgvNiveles.Rows.Add("🥇 Oro", "750+ pts", "Cambio gratis")

        ' Historial de compras
        Dim lblHistorial As New Label()
        lblHistorial.Text = "ÚLTIMAS COMPRAS"
        lblHistorial.Font = New Font("Arial", 10, FontStyle.Bold)
        lblHistorial.Location = New Point(15, 430)
        lblHistorial.AutoSize = True
        pnlDetalle.Controls.Add(lblHistorial)

        dgvHistorial.Location = New Point(15, 455)
        dgvHistorial.Size = New Size(260, 120)
        dgvHistorial.AllowUserToAddRows = False
        dgvHistorial.ReadOnly = True
        dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvHistorial.BackgroundColor = Color.White
        dgvHistorial.Columns.Add("Fecha", "Fecha")
        dgvHistorial.Columns.Add("Monto", "Monto")
        dgvHistorial.Columns.Add("Puntos", "Puntos")
        pnlDetalle.Controls.Add(dgvHistorial)

        dgvHistorial.Rows.Add("15/05/2025", "L. 125.00", "+12 pts")
        dgvHistorial.Rows.Add("14/05/2025", "L. 80.00", "+8 pts")
        dgvHistorial.Rows.Add("13/05/2025", "L. 210.00", "+21 pts")

    End Sub

End Class
