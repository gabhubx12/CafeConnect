Imports System.Windows.Forms
Imports System.Drawing

Public Class frmReportes
    Inherits Form

    ' PANELES
    Private pnlIzquierdo As New Panel()
    Private pnlCentral As New Panel()
    
    ' MENU IZQUIERDO
    Private lblLogo As New Label()
    Private lblUsuario As New Label()
    
    ' PANEL SUPERIOR
    Private pnlTop As New Panel()
    Private cmbTipoReporte As New ComboBox()
    Private dtpFechaInicio As New DateTimePicker()
    Private dtpFechaFin As New DateTimePicker()
    Private btnGenerar As New Button()
    Private btnExportar As New Button()
    
    ' GRILLA REPORTES
    Private dgvReportes As New DataGridView()
    
    ' PANEL RESUMEN
    Private pnlResumen As New Panel()

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.Text = "CaféConnect - Reportes"
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

        ' PANEL TOP (FILTROS)
        pnlTop.Dock = DockStyle.Top
        pnlTop.Height = 120
        pnlTop.BackColor = Color.White
        pnlTop.Padding = New Padding(10)
        pnlTop.BorderStyle = BorderStyle.FixedSingle
        pnlCentral.Controls.Add(pnlTop)

        Dim lblReportes As New Label()
        lblReportes.Text = "📊 REPORTES"
        lblReportes.Font = New Font("Arial", 14, FontStyle.Bold)
        lblReportes.Location = New Point(10, 5)
        lblReportes.AutoSize = True
        pnlTop.Controls.Add(lblReportes)

        Dim lblTipo As New Label()
        lblTipo.Text = "Tipo de reporte:"
        lblTipo.Font = New Font("Arial", 10, FontStyle.Bold)
        lblTipo.Location = New Point(10, 35)
        lblTipo.AutoSize = True
        pnlTop.Controls.Add(lblTipo)

        cmbTipoReporte.Items.AddRange({"Ventas por sucursal", "Transacciones", "Ticket promedio", "Productos más vendidos"})
        cmbTipoReporte.SelectedIndex = 0
        cmbTipoReporte.Location = New Point(150, 32)
        cmbTipoReporte.Size = New Size(200, 25)
        pnlTop.Controls.Add(cmbTipoReporte)

        Dim lblRango As New Label()
        lblRango.Text = "Rango de fechas:"
        lblRango.Font = New Font("Arial", 10, FontStyle.Bold)
        lblRango.Location = New Point(10, 65)
        lblRango.AutoSize = True
        pnlTop.Controls.Add(lblRango)

        dtpFechaInicio.Location = New Point(150, 62)
        dtpFechaInicio.Size = New Size(150, 25)
        pnlTop.Controls.Add(dtpFechaInicio)

        Dim lblHasta As New Label()
        lblHasta.Text = "hasta"
        lblHasta.Font = New Font("Arial", 10)
        lblHasta.Location = New Point(310, 65)
        lblHasta.AutoSize = True
        pnlTop.Controls.Add(lblHasta)

        dtpFechaFin.Location = New Point(360, 62)
        dtpFechaFin.Size = New Size(150, 25)
        pnlTop.Controls.Add(dtpFechaFin)

        btnGenerar.Text = "📈 Generar"
        btnGenerar.Location = New Point(525, 32)
        btnGenerar.Size = New Size(110, 25)
        btnGenerar.BackColor = Color.FromArgb(34, 139, 34)
        btnGenerar.ForeColor = Color.White
        btnGenerar.FlatStyle = FlatStyle.Flat
        btnGenerar.Cursor = Cursors.Hand
        pnlTop.Controls.Add(btnGenerar)

        btnExportar.Text = "💾 Exportar"
        btnExportar.Location = New Point(525, 62)
        btnExportar.Size = New Size(110, 25)
        btnExportar.BackColor = Color.FromArgb(0, 100, 200)
        btnExportar.ForeColor = Color.White
        btnExportar.FlatStyle = FlatStyle.Flat
        btnExportar.Cursor = Cursors.Hand
        pnlTop.Controls.Add(btnExportar)

        ' ===== PANEL RESUMEN =====
        pnlResumen.Dock = DockStyle.Top
        pnlResumen.Height = 100
        pnlResumen.BackColor = Color.White
        pnlResumen.Padding = New Padding(10)
        pnlResumen.BorderStyle = BorderStyle.FixedSingle
        pnlCentral.Controls.Add(pnlResumen)

        ' Tarjetas resumen
        CrearTarjetaResumen(pnlResumen, "Ventas totales", "L. 28,560.00", Color.FromArgb(34, 139, 34), 10)
        CrearTarjetaResumen(pnlResumen, "Transacciones", "342", Color.FromArgb(0, 100, 200), 280)
        CrearTarjetaResumen(pnlResumen, "Ticket promedio", "L. 83.57", Color.FromArgb(255, 140, 0), 550)
        CrearTarjetaResumen(pnlResumen, "Producto Top", "Café Americano", Color.FromArgb(139, 69, 19), 750)

        ' ===== PANEL MAIN (REPORTES POR SUCURSAL) =====
        Dim pnlMain As New Panel()
        pnlMain.Dock = DockStyle.Fill
        pnlMain.BackColor = Color.FromArgb(245, 245, 245)
        pnlMain.Padding = New Padding(10, 0, 10, 10)
        pnlCentral.Controls.Add(pnlMain)

        Dim lblSucursales As New Label()
        lblSucursales.Text = "VENTAS POR SUCURSAL"
        lblSucursales.Font = New Font("Arial", 11, FontStyle.Bold)
        lblSucursales.Dock = DockStyle.Top
        lblSucursales.Height = 25
        pnlMain.Controls.Add(lblSucursales)

        dgvReportes.Dock = DockStyle.Fill
        dgvReportes.AllowUserToAddRows = False
        dgvReportes.ReadOnly = True
        dgvReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvReportes.BackgroundColor = Color.White
        dgvReportes.BorderStyle = BorderStyle.FixedSingle
        dgvReportes.GridColor = Color.LightGray
        
        ' Columnas
        dgvReportes.Columns.Add("Sucursal", "Sucursal")
        dgvReportes.Columns.Add("Ventas", "Ventas")
        dgvReportes.Columns.Add("Transacciones", "Transacciones")
        dgvReportes.Columns.Add("Porcentaje", "%")
        
        pnlMain.Controls.Add(dgvReportes)

        ' Agregar datos de ejemplo
        dgvReportes.Rows.Add("CaféConnect Centro", "L. 12,450.00", 150, "43.6%")
        dgvReportes.Rows.Add("CaféConnect Norte", "L. 9,850.00", 115, "34.5%")
        dgvReportes.Rows.Add("CaféConnect Sur", "L. 6,260.00", "77", "21.9%")

    End Sub

    Private Sub CrearTarjetaResumen(panel As Panel, titulo As String, valor As String, color As Color, posX As Integer)
        Dim pnlTarjeta As New Panel()
        pnlTarjeta.Location = New Point(posX, 10)
        pnlTarjeta.Size = New Size(260, 80)
        pnlTarjeta.BackColor = Color.FromArgb(240, 240, 240)
        pnlTarjeta.BorderStyle = BorderStyle.FixedSingle
        panel.Controls.Add(pnlTarjeta)

        Dim lblTitulo As New Label()
        lblTitulo.Text = titulo
        lblTitulo.Font = New Font("Arial", 9)
        lblTitulo.ForeColor = Color.Gray
        lblTitulo.Location = New Point(10, 10)
        lblTitulo.Width = 240
        pnlTarjeta.Controls.Add(lblTitulo)

        Dim lblValor As New Label()
        lblValor.Text = valor
        lblValor.Font = New Font("Arial", 14, FontStyle.Bold)
        lblValor.ForeColor = color
        lblValor.Location = New Point(10, 35)
        lblValor.Width = 240
        pnlTarjeta.Controls.Add(lblValor)
    End Sub

End Class
