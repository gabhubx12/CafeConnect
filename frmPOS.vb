Imports System.Windows.Forms
Imports System.Drawing

Public Class frmPOS
    Inherits Form

    ' PANELES
    Private pnlIzquierdo As New Panel()
    Private pnlCentral As New Panel()
    Private pnlDerecho As New Panel()
    
    ' MENU IZQUIERDO
    Private lblLogo As New Label()
    Private lblUsuario As New Label()
    Private lblRol As New Label()
    Private btnInicio As New Button()
    Private btnVentas As New Button()
    Private btnInventario As New Button()
    Private btnClientes As New Button()
    Private btnPuntos As New Button()
    Private btnReportes As New Button()
    Private btnEmpleados As New Button()
    Private btnSucursales As New Button()
    Private btnConfiguracion As New Button()
    
    ' PANEL CENTRAL - VENTA
    Private pnlTopVenta As New Panel()
    Private txtBuscarProducto As New TextBox()
    Private btnBuscar As New Button()
    Private btnGridView As New Button()
    Private btnListView As New Button()
    
    Private flpProductos As New FlowLayoutPanel()
    Private pnlFiltros As New Panel()
    
    Private pnlTicket As New Panel()
    Private dgvTicket As New DataGridView()
    Private lblSubtotal As New Label()
    Private lblImpuesto As New Label()
    Private lblTotal As New Label()
    Private btnLimpiar As New Button()
    Private btnCobrar As New Button()
    
    ' PANEL DERECHO - CLIENTE
    Private pnlCliente As New Panel()
    Private picCliente As New PictureBox()
    Private lblNombreCliente As New Label()
    Private lblIDCliente As New Label()
    Private lblTelCliente As New Label()
    Private lblPuntosCliente As New Label()
    Private btnVerRecompensas As New Button()
    Private dgvUltimasCompras As New DataGridView()

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.Text = "CaféConnect - Punto de Venta"
        Me.Size = New Size(1400, 800)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.White
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False

        ' ===== PANEL IZQUIERDO (MENU) =====
        pnlIzquierdo.Dock = DockStyle.Left
        pnlIzquierdo.Width = 200
        pnlIzquierdo.BackColor = Color.FromArgb(40, 40, 40)
        pnlIzquierdo.Padding = New Padding(0)
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
        lblUsuario.Text = "¡Bienvenido!" & vbCrLf & "Eliud García"
        lblUsuario.Font = New Font("Arial", 9, FontStyle.Bold)
        lblUsuario.ForeColor = Color.White
        lblUsuario.TextAlign = ContentAlignment.MiddleCenter
        lblUsuario.Dock = DockStyle.Top
        lblUsuario.Height = 60
        pnlIzquierdo.Controls.Add(lblUsuario)

        lblRol.Text = "Administrador"
        lblRol.Font = New Font("Arial", 8)
        lblRol.ForeColor = Color.LightGray
        lblRol.TextAlign = ContentAlignment.TopCenter
        lblRol.Dock = DockStyle.Top
        lblRol.Height = 30
        pnlIzquierdo.Controls.Add(lblRol)

        ' Botones del menú
        Dim botones As String() = {"🏠 Inicio", "🛒 Ventas (POS)", "📦 Inventario", "�� Clientes", 
                                    "⭐ Puntos de Fidelización", "📊 Reportes", "👨‍💼 Empleados", 
                                    "🏢 Sucursales", "⚙️ Configuración", "🚪 Cerrar sesión"}
        
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
        Dim pnlContenedor As New Panel()
        pnlContenedor.Dock = DockStyle.Fill
        pnlContenedor.BackColor = Color.FromArgb(245, 245, 245)
        Me.Controls.Add(pnlContenedor)

        ' PANEL TOP VENTA
        pnlTopVenta.Dock = DockStyle.Top
        pnlTopVenta.Height = 60
        pnlTopVenta.BackColor = Color.White
        pnlTopVenta.BorderStyle = BorderStyle.FixedSingle
        pnlTopVenta.Padding = New Padding(10)
        pnlContenedor.Controls.Add(pnlTopVenta)

        Dim lblVenta As New Label()
        lblVenta.Text = "🛒 VENTA (PUNTO DE VENTA)"
        lblVenta.Font = New Font("Arial", 11, FontStyle.Bold)
        lblVenta.Location = New Point(10, 10)
        lblVenta.AutoSize = True
        pnlTopVenta.Controls.Add(lblVenta)

        txtBuscarProducto.Text = "Buscar producto..."
        txtBuscarProducto.Font = New Font("Arial", 10)
        txtBuscarProducto.Location = New Point(10, 32)
        txtBuscarProducto.Size = New Size(300, 25)
        pnlTopVenta.Controls.Add(txtBuscarProducto)

        btnBuscar.Text = "🔍"
        btnBuscar.Location = New Point(320, 32)
        btnBuscar.Size = New Size(35, 25)
        btnBuscar.BackColor = Color.FromArgb(100, 100, 100)
        btnBuscar.ForeColor = Color.White
        btnBuscar.FlatStyle = FlatStyle.Flat
        pnlTopVenta.Controls.Add(btnBuscar)

        btnGridView.Text = "⊞⊞"
        btnGridView.Location = New Point(360, 32)
        btnGridView.Size = New Size(35, 25)
        btnGridView.BackColor = Color.FromArgb(100, 100, 100)
        btnGridView.ForeColor = Color.White
        btnGridView.FlatStyle = FlatStyle.Flat
        pnlTopVenta.Controls.Add(btnGridView)

        btnListView.Text = "≡"
        btnListView.Location = New Point(400, 32)
        btnListView.Size = New Size(35, 25)
        btnListView.BackColor = Color.FromArgb(100, 100, 100)
        btnListView.ForeColor = Color.White
        btnListView.FlatStyle = FlatStyle.Flat
        pnlTopVenta.Controls.Add(btnListView)

        ' PANEL CON CONTENIDO
        Dim pnlMain As New Panel()
        pnlMain.Dock = DockStyle.Fill
        pnlMain.Padding = New Padding(10)
        pnlContenedor.Controls.Add(pnlMain)

        ' PANEL IZQUIERDO DEL MAIN (PRODUCTOS Y FILTROS)
        Dim pnlProductosArea As New Panel()
        pnlProductosArea.Dock = DockStyle.Left
        pnlProductosArea.Width = 600
        pnlProductosArea.BackColor = Color.FromArgb(245, 245, 245)
        pnlMain.Controls.Add(pnlProductosArea)

        ' Filtros
        pnlFiltros.Dock = DockStyle.Top
        pnlFiltros.Height = 50
        pnlFiltros.BackColor = Color.White
        pnlFiltros.Padding = New Padding(5)
        pnlProductosArea.Controls.Add(pnlFiltros)

        Dim btnBebidas As New Button()
        btnBebidas.Text = "Bebidas"
        btnBebidas.Location = New Point(5, 5)
        btnBebidas.Size = New Size(100, 35)
        btnBebidas.BackColor = Color.FromArgb(139, 69, 19)
        btnBebidas.ForeColor = Color.White
        btnBebidas.FlatStyle = FlatStyle.Flat
        pnlFiltros.Controls.Add(btnBebidas)

        Dim btnPostres As New Button()
        btnPostres.Text = "Postres"
        btnPostres.Location = New Point(115, 5)
        btnPostres.Size = New Size(100, 35)
        btnPostres.BackColor = Color.FromArgb(100, 100, 100)
        btnPostres.ForeColor = Color.White
        btnPostres.FlatStyle = FlatStyle.Flat
        pnlFiltros.Controls.Add(btnPostres)

        Dim btnPanaderia As New Button()
        btnPanaderia.Text = "Panadería"
        btnPanaderia.Location = New Point(225, 5)
        btnPanaderia.Size = New Size(100, 35)
        btnPanaderia.BackColor = Color.FromArgb(100, 100, 100)
        btnPanaderia.ForeColor = Color.White
        btnPanaderia.FlatStyle = FlatStyle.Flat
        pnlFiltros.Controls.Add(btnPanaderia)

        Dim btnSnacks As New Button()
        btnSnacks.Text = "Snacks"
        btnSnacks.Location = New Point(335, 5)
        btnSnacks.Size = New Size(100, 35)
        btnSnacks.BackColor = Color.FromArgb(100, 100, 100)
        btnSnacks.ForeColor = Color.White
        btnSnacks.FlatStyle = FlatStyle.Flat
        pnlFiltros.Controls.Add(btnSnacks)

        Dim btnTodos As New Button()
        btnTodos.Text = "Todos"
        btnTodos.Location = New Point(445, 5)
        btnTodos.Size = New Size(100, 35)
        btnTodos.BackColor = Color.FromArgb(100, 100, 100)
        btnTodos.ForeColor = Color.White
        btnTodos.FlatStyle = FlatStyle.Flat
        pnlFiltros.Controls.Add(btnTodos)

        ' FlowLayoutPanel para productos
        flpProductos.Dock = DockStyle.Fill
        flpProductos.AutoScroll = True
        flpProductos.BackColor = Color.FromArgb(245, 245, 245)
        pnlProductosArea.Controls.Add(flpProductos)

        ' Agregar productos de ejemplo
        AgregarProductoEjemplo("Café Americano", "L. 45.00", flpProductos)
        AgregarProductoEjemplo("Cappuccino", "L. 60.00", flpProductos)
        AgregarProductoEjemplo("Latte", "L. 65.00", flpProductos)
        AgregarProductoEjemplo("Frappé", "L. 75.00", flpProductos)
        AgregarProductoEjemplo("Pastel de Chocolate", "L. 60.00", flpProductos)
        AgregarProductoEjemplo("Cheesecake", "L. 70.00", flpProductos)
        AgregarProductoEjemplo("Croissant", "L. 50.00", flpProductos)
        AgregarProductoEjemplo("Galleta", "L. 25.00", flpProductos)
        AgregarProductoEjemplo("Muffin", "L. 45.00", flpProductos)

        ' PANEL CENTRAL DEL MAIN (TICKET)
        pnlTicket.Dock = DockStyle.Fill
        pnlTicket.BackColor = Color.White
        pnlTicket.Padding = New Padding(10)
        pnlTicket.Margin = New Padding(10, 0, 10, 0)
        pnlMain.Controls.Add(pnlTicket)

        Dim lblTicket As New Label()
        lblTicket.Text = "TICKET DE VENTA"
        lblTicket.Font = New Font("Arial", 11, FontStyle.Bold)
        lblTicket.Dock = DockStyle.Top
        lblTicket.Height = 25
        pnlTicket.Controls.Add(lblTicket)

        dgvTicket.Dock = DockStyle.Fill
        dgvTicket.AllowUserToAddRows = False
        dgvTicket.ReadOnly = True
        dgvTicket.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvTicket.BackgroundColor = Color.White
        dgvTicket.Columns.Add("Producto", "Producto")
        dgvTicket.Columns.Add("Cantidad", "Cant.")
        dgvTicket.Columns.Add("Precio", "Precio")
        dgvTicket.Columns.Add("Total", "Total")
        pnlTicket.Controls.Add(dgvTicket)

        Dim pnlTotales As New Panel()
        pnlTotales.Dock = DockStyle.Bottom
        pnlTotales.Height = 100
        pnlTotales.BackColor = Color.White
        pnlTicket.Controls.Add(pnlTotales)

        lblSubtotal.Text = "Subtotal: L. 0.00"
        lblSubtotal.Font = New Font("Arial", 10, FontStyle.Bold)
        lblSubtotal.Location = New Point(10, 10)
        lblSubtotal.AutoSize = True
        pnlTotales.Controls.Add(lblSubtotal)

        lblImpuesto.Text = "Impuesto (15%): L. 0.00"
        lblImpuesto.Font = New Font("Arial", 10, FontStyle.Bold)
        lblImpuesto.Location = New Point(10, 35)
        lblImpuesto.AutoSize = True
        pnlTotales.Controls.Add(lblImpuesto)

        lblTotal.Text = "TOTAL: L. 0.00"
        lblTotal.Font = New Font("Arial", 14, FontStyle.Bold)
        lblTotal.ForeColor = Color.FromArgb(34, 139, 34)
        lblTotal.Location = New Point(10, 60)
        lblTotal.AutoSize = True
        pnlTotales.Controls.Add(lblTotal)

        btnLimpiar.Text = "🗑️ Limpiar"
        btnLimpiar.Font = New Font("Arial", 10, FontStyle.Bold)
        btnLimpiar.Location = New Point(250, 15)
        btnLimpiar.Size = New Size(120, 40)
        btnLimpiar.BackColor = Color.FromArgb(255, 140, 0)
        btnLimpiar.ForeColor = Color.White
        btnLimpiar.FlatStyle = FlatStyle.Flat
        pnlTotales.Controls.Add(btnLimpiar)

        btnCobrar.Text = "💳 COBRAR (F3)"
        btnCobrar.Font = New Font("Arial", 11, FontStyle.Bold)
        btnCobrar.Location = New Point(380, 15)
        btnCobrar.Size = New Size(150, 40)
        btnCobrar.BackColor = Color.FromArgb(34, 139, 34)
        btnCobrar.ForeColor = Color.White
        btnCobrar.FlatStyle = FlatStyle.Flat
        pnlTotales.Controls.Add(btnCobrar)

        ' ===== PANEL DERECHO (CLIENTE) =====
        pnlDerecho.Dock = DockStyle.Right
        pnlDerecho.Width = 280
        pnlDerecho.BackColor = Color.White
        pnlDerecho.Padding = New Padding(10)
        pnlDerecho.BorderStyle = BorderStyle.FixedSingle
        pnlMain.Controls.Add(pnlDerecho)

        Dim lblClienteHeader As New Label()
        lblClienteHeader.Text = "👤 CLIENTE"
        lblClienteHeader.Font = New Font("Arial", 11, FontStyle.Bold)
        lblClienteHeader.Dock = DockStyle.Top
        lblClienteHeader.Height = 25
        pnlDerecho.Controls.Add(lblClienteHeader)

        Dim txtBuscarCliente As New TextBox()
        txtBuscarCliente.Text = "Buscar cliente (ID, nombre, teléfono)..."
        txtBuscarCliente.Font = New Font("Arial", 8)
        txtBuscarCliente.Dock = DockStyle.Top
        txtBuscarCliente.Height = 30
        pnlDerecho.Controls.Add(txtBuscarCliente)

        picCliente.Size = New Size(100, 100)
        picCliente.Location = New Point(90, 10)
        picCliente.BackColor = Color.FromArgb(200, 200, 200)
        picCliente.BorderStyle = BorderStyle.FixedSingle
        pnlDerecho.Controls.Add(picCliente)

        lblNombreCliente.Text = "Juan Pérez"
        lblNombreCliente.Font = New Font("Arial", 10, FontStyle.Bold)
        lblNombreCliente.Location = New Point(10, 115)
        lblNombreCliente.AutoSize = True
        pnlDerecho.Controls.Add(lblNombreCliente)

        lblIDCliente.Text = "ID: CLI00025"
        lblIDCliente.Font = New Font("Arial", 9)
        lblIDCliente.Location = New Point(10, 135)
        lblIDCliente.AutoSize = True
        pnlDerecho.Controls.Add(lblIDCliente)

        lblTelCliente.Text = "Tel: 9876-5432"
        lblTelCliente.Font = New Font("Arial", 9)
        lblTelCliente.Location = New Point(10, 155)
        lblTelCliente.AutoSize = True
        pnlDerecho.Controls.Add(lblTelCliente)

        lblPuntosCliente.Text = "Puntos: 850 pts"
        lblPuntosCliente.Font = New Font("Arial", 10, FontStyle.Bold)
        lblPuntosCliente.ForeColor = Color.FromArgb(34, 139, 34)
        lblPuntosCliente.Location = New Point(10, 180)
        lblPuntosCliente.AutoSize = True
        pnlDerecho.Controls.Add(lblPuntosCliente)

        btnVerRecompensas.Text = "Ver recompensas"
        btnVerRecompensas.Font = New Font("Arial", 9, FontStyle.Bold)
        btnVerRecompensas.Location = New Point(10, 205)
        btnVerRecompensas.Size = New Size(250, 30)
        btnVerRecompensas.BackColor = Color.FromArgb(100, 100, 100)
        btnVerRecompensas.ForeColor = Color.White
        btnVerRecompensas.FlatStyle = FlatStyle.Flat
        pnlDerecho.Controls.Add(btnVerRecompensas)

        Dim lblUltimasCompras As New Label()
        lblUltimasCompras.Text = "ÚLTIMAS COMPRAS"
        lblUltimasCompras.Font = New Font("Arial", 9, FontStyle.Bold)
        lblUltimasCompras.Location = New Point(10, 245)
        lblUltimasCompras.AutoSize = True
        pnlDerecho.Controls.Add(lblUltimasCompras)

        dgvUltimasCompras.Location = New Point(10, 265)
        dgvUltimasCompras.Size = New Size(250, 180)
        dgvUltimasCompras.AllowUserToAddRows = False
        dgvUltimasCompras.ReadOnly = True
        dgvUltimasCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvUltimasCompras.BackgroundColor = Color.White
        dgvUltimasCompras.Columns.Add("Fecha", "Fecha")
        dgvUltimasCompras.Columns.Add("Monto", "Monto")
        dgvUltimasCompras.Columns.Add("Puntos", "Puntos")
        pnlDerecho.Controls.Add(dgvUltimasCompras)

        ' Agregar datos de ejemplo
        dgvUltimasCompras.Rows.Add("15/05/2025", "L. 125.00", "+12 pts")
        dgvUltimasCompras.Rows.Add("14/05/2025", "L. 80.00", "+8 pts")
        dgvUltimasCompras.Rows.Add("13/05/2025", "L. 210.00", "+21 pts")

    End Sub

    Private Sub AgregarProductoEjemplo(nombre As String, precio As String, panel As FlowLayoutPanel)
        Dim pnlProducto As New Panel()
        pnlProducto.Size = New Size(150, 180)
        pnlProducto.BackColor = Color.White
        pnlProducto.BorderStyle = BorderStyle.FixedSingle
        pnlProducto.Cursor = Cursors.Hand
        pnlProducto.Margin = New Padding(5)

        Dim picProducto As New PictureBox()
        picProducto.Size = New Size(150, 100)
        picProducto.BackColor = Color.FromArgb(200, 200, 200)
        picProducto.Dock = DockStyle.Top
        pnlProducto.Controls.Add(picProducto)

        Dim lblNombre As New Label()
        lblNombre.Text = nombre
        lblNombre.Font = New Font("Arial", 9, FontStyle.Bold)
        lblNombre.Dock = DockStyle.Top
        lblNombre.Height = 30
        lblNombre.TextAlign = ContentAlignment.MiddleCenter
        pnlProducto.Controls.Add(lblNombre)

        Dim lblPrecio As New Label()
        lblPrecio.Text = precio
        lblPrecio.Font = New Font("Arial", 10, FontStyle.Bold)
        lblPrecio.ForeColor = Color.FromArgb(34, 139, 34)
        lblPrecio.Dock = DockStyle.Top
        lblPrecio.Height = 25
        lblPrecio.TextAlign = ContentAlignment.MiddleCenter
        pnlProducto.Controls.Add(lblPrecio)

        panel.Controls.Add(pnlProducto)
    End Sub

End Class
