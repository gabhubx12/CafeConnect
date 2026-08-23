Imports System.Windows.Forms
Imports System.Drawing

Public Class frmInventario
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
    
    ' GRILLA INVENTARIO
    Private dgvInventario As New DataGridView()
    
    ' PANEL FILTROS
    Private pnlFiltros As New Panel()

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.Text = "CaféConnect - Inventario"
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
        pnlTop.Dock = DockStyle.Top
        pnlTop.Height = 100
        pnlTop.BackColor = Color.White
        pnlTop.Padding = New Padding(10)
        pnlTop.BorderStyle = BorderStyle.FixedSingle
        pnlCentral.Controls.Add(pnlTop)

        Dim lblInventario As New Label()
        lblInventario.Text = "📦 INVENTARIO"
        lblInventario.Font = New Font("Arial", 14, FontStyle.Bold)
        lblInventario.Location = New Point(10, 5)
        lblInventario.AutoSize = True
        pnlTop.Controls.Add(lblInventario)

        Dim lblBuscar As New Label()
        lblBuscar.Text = "Buscar producto:"
        lblBuscar.Font = New Font("Arial", 10, FontStyle.Bold)
        lblBuscar.Location = New Point(10, 35)
        lblBuscar.AutoSize = True
        pnlTop.Controls.Add(lblBuscar)

        txtBuscar.Location = New Point(150, 32)
        txtBuscar.Size = New Size(250, 25)
        txtBuscar.Font = New Font("Arial", 10)
        pnlTop.Controls.Add(txtBuscar)

        btnBuscar.Text = "🔍 Buscar"
        btnBuscar.Location = New Point(410, 32)
        btnBuscar.Size = New Size(100, 25)
        btnBuscar.BackColor = Color.FromArgb(100, 100, 100)
        btnBuscar.ForeColor = Color.White
        btnBuscar.FlatStyle = FlatStyle.Flat
        btnBuscar.Cursor = Cursors.Hand
        pnlTop.Controls.Add(btnBuscar)

        btnAgregar.Text = "➕ Agregar"
        btnAgregar.Location = New Point(520, 32)
        btnAgregar.Size = New Size(100, 25)
        btnAgregar.BackColor = Color.FromArgb(34, 139, 34)
        btnAgregar.ForeColor = Color.White
        btnAgregar.FlatStyle = FlatStyle.Flat
        btnAgregar.Cursor = Cursors.Hand
        pnlTop.Controls.Add(btnAgregar)

        btnEditar.Text = "✏️ Editar"
        btnEditar.Location = New Point(630, 32)
        btnEditar.Size = New Size(100, 25)
        btnEditar.BackColor = Color.FromArgb(0, 100, 200)
        btnEditar.ForeColor = Color.White
        btnEditar.FlatStyle = FlatStyle.Flat
        btnEditar.Cursor = Cursors.Hand
        pnlTop.Controls.Add(btnEditar)

        btnEliminar.Text = "❌ Eliminar"
        btnEliminar.Location = New Point(740, 32)
        btnEliminar.Size = New Size(100, 25)
        btnEliminar.BackColor = Color.FromArgb(200, 0, 0)
        btnEliminar.ForeColor = Color.White
        btnEliminar.FlatStyle = FlatStyle.Flat
        btnEliminar.Cursor = Cursors.Hand
        pnlTop.Controls.Add(btnEliminar)

        ' PANEL FILTROS
        pnlFiltros.Dock = DockStyle.Top
        pnlFiltros.Height = 50
        pnlFiltros.BackColor = Color.White
        pnlFiltros.Padding = New Padding(10)
        pnlFiltros.BorderStyle = BorderStyle.FixedSingle
        pnlCentral.Controls.Add(pnlFiltros)

        Dim lblCategoria As New Label()
        lblCategoria.Text = "Categoría:"
        lblCategoria.Font = New Font("Arial", 9, FontStyle.Bold)
        lblCategoria.Location = New Point(10, 12)
        lblCategoria.AutoSize = True
        pnlFiltros.Controls.Add(lblCategoria)

        Dim cmbCategoria As New ComboBox()
        cmbCategoria.Items.AddRange({"Bebidas", "Postres", "Panadería", "Snacks", "Todos"})
        cmbCategoria.SelectedIndex = 4
        cmbCategoria.Location = New Point(90, 10)
        cmbCategoria.Size = New Size(120, 25)
        pnlFiltros.Controls.Add(cmbCategoria)

        Dim lblEstado As New Label()
        lblEstado.Text = "Estado:"
        lblEstado.Font = New Font("Arial", 9, FontStyle.Bold)
        lblEstado.Location = New Point(230, 12)
        lblEstado.AutoSize = True
        pnlFiltros.Controls.Add(lblEstado)

        Dim cmbEstado As New ComboBox()
        cmbEstado.Items.AddRange({"OK: Stock suficiente", "BAJO: Stock mínimo alcanzado", "Todos"})
        cmbEstado.SelectedIndex = 2
        cmbEstado.Location = New Point(290, 10)
        cmbEstado.Size = New Size(200, 25)
        pnlFiltros.Controls.Add(cmbEstado)

        ' GRILLA INVENTARIO
        dgvInventario.Dock = DockStyle.Fill
        dgvInventario.AllowUserToAddRows = False
        dgvInventario.ReadOnly = True
        dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvInventario.BackgroundColor = Color.White
        dgvInventario.BorderStyle = BorderStyle.FixedSingle
        dgvInventario.GridColor = Color.LightGray
        
        ' Columnas
        dgvInventario.Columns.Add("Producto", "Producto")
        dgvInventario.Columns.Add("Categoria", "Categoría")
        dgvInventario.Columns.Add("Stock", "Stock")
        dgvInventario.Columns.Add("Minimo", "Mínimo")
        dgvInventario.Columns.Add("Estado", "Estado")
        dgvInventario.Columns.Add("Precio", "Precio")
        
        pnlCentral.Controls.Add(dgvInventario)

        ' Agregar datos de ejemplo
        dgvInventario.Rows.Add("Café Americano", "Bebidas", 32, 10, "✅ OK", "L. 45.00")
        dgvInventario.Rows.Add("Cappuccino", "Bebidas", 18, 10, "✅ OK", "L. 60.00")
        dgvInventario.Rows.Add("Latte", "Bebidas", 14, 10, "✅ OK", "L. 65.00")
        dgvInventario.Rows.Add("Frappé", "Bebidas", 8, 10, "⚠️ BAJO", "L. 75.00")
        dgvInventario.Rows.Add("Pastel de Chocolate", "Postres", 15, 5, "✅ OK", "L. 60.00")
        dgvInventario.Rows.Add("Cheesecake", "Postres", 6, 5, "✅ OK", "L. 70.00")
        dgvInventario.Rows.Add("Croissant", "Panadería", 15, 5, "✅ OK", "L. 50.00")
        dgvInventario.Rows.Add("Galleta", "Snacks", 3, 5, "⚠️ BAJO", "L. 25.00")
        dgvInventario.Rows.Add("Muffin", "Snacks", 12, 10, "✅ OK", "L. 45.00")

    End Sub

End Class
