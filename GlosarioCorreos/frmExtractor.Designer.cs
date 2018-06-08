using BrightIdeasSoftware;

namespace GlosarioCorreos
{
    partial class frmExtractor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExtractor));
            this.tabFiltros = new System.Windows.Forms.TabControl();
            this.tabP_General = new System.Windows.Forms.TabPage();
            this.chkBusquedaRapida = new System.Windows.Forms.CheckBox();
            this.chkUsarBDestinatarios = new System.Windows.Forms.CheckBox();
            this.chkUsarAdjuntos = new System.Windows.Forms.CheckBox();
            this.lblMaxResT = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numMaxResultados = new System.Windows.Forms.NumericUpDown();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabP_Fecha = new System.Windows.Forms.TabPage();
            this.lblErrorFF = new System.Windows.Forms.Label();
            this.chkHayErrorFF = new System.Windows.Forms.CheckBox();
            this.chkUsarFechas = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtFin = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtIni = new System.Windows.Forms.DateTimePicker();
            this.tabP_Tamanno = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDestinatarios = new System.Windows.Forms.TextBox();
            this.chkUsarDestinatarios = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRemitentes = new System.Windows.Forms.TextBox();
            this.chkUsarRemitentes = new System.Windows.Forms.CheckBox();
            this.tabP_Avanzado = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.txtExtensiones = new System.Windows.Forms.TextBox();
            this.chkUsarExtensiones = new System.Windows.Forms.CheckBox();
            this.pnlBuscar = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbrirBusqueda = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGuardarBusqueda = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuObtenerQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.status01 = new System.Windows.Forms.StatusStrip();
            this.lblEncontrados = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTamanno = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTiempo = new System.Windows.Forms.ToolStripStatusLabel();
            this.sfd01 = new System.Windows.Forms.SaveFileDialog();
            this.ofd01 = new System.Windows.Forms.OpenFileDialog();
            this.gbResultados = new System.Windows.Forms.GroupBox();
            this.gbVistaPrevia = new System.Windows.Forms.GroupBox();
            this.brw01 = new System.Windows.Forms.WebBrowser();
            this.lstArchivos = new BrightIdeasSoftware.FastDataListView();
            this.colRemitente = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colFecha = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colAsunto = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colHTML = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.pnlEngine = new System.Windows.Forms.Panel();
            this.pbEngine = new System.Windows.Forms.PictureBox();
            this.wkrBusqueda = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabFiltros.SuspendLayout();
            this.tabP_General.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxResultados)).BeginInit();
            this.tabP_Fecha.SuspendLayout();
            this.tabP_Tamanno.SuspendLayout();
            this.tabP_Avanzado.SuspendLayout();
            this.pnlBuscar.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.status01.SuspendLayout();
            this.gbResultados.SuspendLayout();
            this.gbVistaPrevia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstArchivos)).BeginInit();
            this.pnlEngine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEngine)).BeginInit();
            this.SuspendLayout();
            // 
            // tabFiltros
            // 
            this.tabFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabFiltros.Controls.Add(this.tabP_General);
            this.tabFiltros.Controls.Add(this.tabP_Fecha);
            this.tabFiltros.Controls.Add(this.tabP_Tamanno);
            this.tabFiltros.Controls.Add(this.tabP_Avanzado);
            this.tabFiltros.Location = new System.Drawing.Point(12, 27);
            this.tabFiltros.Name = "tabFiltros";
            this.tabFiltros.SelectedIndex = 0;
            this.tabFiltros.Size = new System.Drawing.Size(947, 155);
            this.tabFiltros.TabIndex = 2;
            // 
            // tabP_General
            // 
            this.tabP_General.BackColor = System.Drawing.Color.GhostWhite;
            this.tabP_General.Controls.Add(this.chkBusquedaRapida);
            this.tabP_General.Controls.Add(this.chkUsarBDestinatarios);
            this.tabP_General.Controls.Add(this.chkUsarAdjuntos);
            this.tabP_General.Controls.Add(this.lblMaxResT);
            this.tabP_General.Controls.Add(this.label9);
            this.tabP_General.Controls.Add(this.label8);
            this.tabP_General.Controls.Add(this.numMaxResultados);
            this.tabP_General.Controls.Add(this.txtKeywords);
            this.tabP_General.Controls.Add(this.label1);
            this.tabP_General.Location = new System.Drawing.Point(4, 23);
            this.tabP_General.Name = "tabP_General";
            this.tabP_General.Padding = new System.Windows.Forms.Padding(3);
            this.tabP_General.Size = new System.Drawing.Size(939, 128);
            this.tabP_General.TabIndex = 0;
            this.tabP_General.Text = "Búsqueda";
            // 
            // chkBusquedaRapida
            // 
            this.chkBusquedaRapida.AutoSize = true;
            this.chkBusquedaRapida.Checked = true;
            this.chkBusquedaRapida.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBusquedaRapida.Location = new System.Drawing.Point(9, 60);
            this.chkBusquedaRapida.Name = "chkBusquedaRapida";
            this.chkBusquedaRapida.Size = new System.Drawing.Size(162, 18);
            this.chkBusquedaRapida.TabIndex = 13;
            this.chkBusquedaRapida.Text = "Utilizar búsqueda rápida";
            this.chkBusquedaRapida.UseVisualStyleBackColor = true;
            // 
            // chkUsarBDestinatarios
            // 
            this.chkUsarBDestinatarios.AutoSize = true;
            this.chkUsarBDestinatarios.Location = new System.Drawing.Point(9, 108);
            this.chkUsarBDestinatarios.Name = "chkUsarBDestinatarios";
            this.chkUsarBDestinatarios.Size = new System.Drawing.Size(294, 18);
            this.chkUsarBDestinatarios.TabIndex = 12;
            this.chkUsarBDestinatarios.Text = "Incluir nombres de destinatarios en la búsqueda";
            this.chkUsarBDestinatarios.UseVisualStyleBackColor = true;
            // 
            // chkUsarAdjuntos
            // 
            this.chkUsarAdjuntos.AutoSize = true;
            this.chkUsarAdjuntos.Location = new System.Drawing.Point(9, 84);
            this.chkUsarAdjuntos.Name = "chkUsarAdjuntos";
            this.chkUsarAdjuntos.Size = new System.Drawing.Size(317, 18);
            this.chkUsarAdjuntos.TabIndex = 11;
            this.chkUsarAdjuntos.Text = "Incluir nombres de archivos adjuntos en la búsqueda";
            this.chkUsarAdjuntos.UseVisualStyleBackColor = true;
            // 
            // lblMaxResT
            // 
            this.lblMaxResT.BackColor = System.Drawing.Color.White;
            this.lblMaxResT.Location = new System.Drawing.Point(113, 36);
            this.lblMaxResT.Name = "lblMaxResT";
            this.lblMaxResT.Size = new System.Drawing.Size(96, 18);
            this.lblMaxResT.TabIndex = 10;
            this.lblMaxResT.Text = "Todos";
            this.lblMaxResT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMaxResT.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(235, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(333, 14);
            this.label9.TabIndex = 9;
            this.label9.Text = "(El valor cero indica que se mostrarán todos los resultados)";
            this.label9.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 14);
            this.label8.TabIndex = 8;
            this.label8.Text = "Max. resultados:";
            // 
            // numMaxResultados
            // 
            this.numMaxResultados.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMaxResultados.Location = new System.Drawing.Point(109, 34);
            this.numMaxResultados.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numMaxResultados.Name = "numMaxResultados";
            this.numMaxResultados.Size = new System.Drawing.Size(120, 22);
            this.numMaxResultados.TabIndex = 7;
            this.numMaxResultados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numMaxResultados.ThousandsSeparator = true;
            this.numMaxResultados.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMaxResultados.ValueChanged += new System.EventHandler(this.numMaxResultados_ValueChanged);
            // 
            // txtKeywords
            // 
            this.txtKeywords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeywords.Location = new System.Drawing.Point(109, 6);
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.Size = new System.Drawing.Size(487, 22);
            this.txtKeywords.TabIndex = 1;
            this.txtKeywords.Text = "*.*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Palabras clave:";
            // 
            // tabP_Fecha
            // 
            this.tabP_Fecha.BackColor = System.Drawing.Color.GhostWhite;
            this.tabP_Fecha.Controls.Add(this.lblErrorFF);
            this.tabP_Fecha.Controls.Add(this.chkHayErrorFF);
            this.tabP_Fecha.Controls.Add(this.chkUsarFechas);
            this.tabP_Fecha.Controls.Add(this.label3);
            this.tabP_Fecha.Controls.Add(this.dtFin);
            this.tabP_Fecha.Controls.Add(this.label4);
            this.tabP_Fecha.Controls.Add(this.dtIni);
            this.tabP_Fecha.Location = new System.Drawing.Point(4, 23);
            this.tabP_Fecha.Name = "tabP_Fecha";
            this.tabP_Fecha.Padding = new System.Windows.Forms.Padding(3);
            this.tabP_Fecha.Size = new System.Drawing.Size(939, 128);
            this.tabP_Fecha.TabIndex = 1;
            this.tabP_Fecha.Text = "Fitros por fecha";
            // 
            // lblErrorFF
            // 
            this.lblErrorFF.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorFF.ForeColor = System.Drawing.Color.DarkRed;
            this.lblErrorFF.Location = new System.Drawing.Point(6, 83);
            this.lblErrorFF.Name = "lblErrorFF";
            this.lblErrorFF.Size = new System.Drawing.Size(207, 18);
            this.lblErrorFF.TabIndex = 11;
            // 
            // chkHayErrorFF
            // 
            this.chkHayErrorFF.AutoSize = true;
            this.chkHayErrorFF.Location = new System.Drawing.Point(218, 8);
            this.chkHayErrorFF.Name = "chkHayErrorFF";
            this.chkHayErrorFF.Size = new System.Drawing.Size(15, 14);
            this.chkHayErrorFF.TabIndex = 10;
            this.chkHayErrorFF.UseVisualStyleBackColor = true;
            this.chkHayErrorFF.Visible = false;
            // 
            // chkUsarFechas
            // 
            this.chkUsarFechas.AutoSize = true;
            this.chkUsarFechas.Location = new System.Drawing.Point(8, 6);
            this.chkUsarFechas.Name = "chkUsarFechas";
            this.chkUsarFechas.Size = new System.Drawing.Size(204, 18);
            this.chkUsarFechas.TabIndex = 4;
            this.chkUsarFechas.Text = "Utilizar filtro por rango de fechas";
            this.chkUsarFechas.UseVisualStyleBackColor = true;
            this.chkUsarFechas.CheckedChanged += new System.EventHandler(this.chkUsarFechas_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "Fecha inicial:";
            // 
            // dtFin
            // 
            this.dtFin.CustomFormat = "dd/MM/yyyy";
            this.dtFin.Enabled = false;
            this.dtFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFin.Location = new System.Drawing.Point(103, 58);
            this.dtFin.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtFin.Name = "dtFin";
            this.dtFin.Size = new System.Drawing.Size(97, 22);
            this.dtFin.TabIndex = 3;
            this.dtFin.ValueChanged += new System.EventHandler(this.dtFin_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "Fecha final:";
            // 
            // dtIni
            // 
            this.dtIni.CustomFormat = "dd/MM/yyyy";
            this.dtIni.Enabled = false;
            this.dtIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtIni.Location = new System.Drawing.Point(103, 30);
            this.dtIni.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtIni.Name = "dtIni";
            this.dtIni.Size = new System.Drawing.Size(97, 22);
            this.dtIni.TabIndex = 1;
            this.dtIni.ValueChanged += new System.EventHandler(this.dtIni_ValueChanged);
            // 
            // tabP_Tamanno
            // 
            this.tabP_Tamanno.BackColor = System.Drawing.Color.GhostWhite;
            this.tabP_Tamanno.Controls.Add(this.label5);
            this.tabP_Tamanno.Controls.Add(this.txtDestinatarios);
            this.tabP_Tamanno.Controls.Add(this.chkUsarDestinatarios);
            this.tabP_Tamanno.Controls.Add(this.label2);
            this.tabP_Tamanno.Controls.Add(this.txtRemitentes);
            this.tabP_Tamanno.Controls.Add(this.chkUsarRemitentes);
            this.tabP_Tamanno.Location = new System.Drawing.Point(4, 23);
            this.tabP_Tamanno.Name = "tabP_Tamanno";
            this.tabP_Tamanno.Size = new System.Drawing.Size(939, 128);
            this.tabP_Tamanno.TabIndex = 2;
            this.tabP_Tamanno.Text = "Filtros por persona";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(473, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(265, 14);
            this.label5.TabIndex = 14;
            this.label5.Text = "(Se pueden colocar varios separados por coma)";
            // 
            // txtDestinatarios
            // 
            this.txtDestinatarios.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtDestinatarios.Enabled = false;
            this.txtDestinatarios.Location = new System.Drawing.Point(197, 33);
            this.txtDestinatarios.Name = "txtDestinatarios";
            this.txtDestinatarios.Size = new System.Drawing.Size(270, 22);
            this.txtDestinatarios.TabIndex = 13;
            // 
            // chkUsarDestinatarios
            // 
            this.chkUsarDestinatarios.AutoSize = true;
            this.chkUsarDestinatarios.Location = new System.Drawing.Point(8, 35);
            this.chkUsarDestinatarios.Name = "chkUsarDestinatarios";
            this.chkUsarDestinatarios.Size = new System.Drawing.Size(183, 18);
            this.chkUsarDestinatarios.TabIndex = 12;
            this.chkUsarDestinatarios.Text = "Utilizar filtro de destinatario:";
            this.chkUsarDestinatarios.UseVisualStyleBackColor = true;
            this.chkUsarDestinatarios.CheckedChanged += new System.EventHandler(this.chkUsarDestinatarios_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(473, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "(Se pueden colocar varios separados por coma)";
            // 
            // txtRemitentes
            // 
            this.txtRemitentes.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtRemitentes.Enabled = false;
            this.txtRemitentes.Location = new System.Drawing.Point(197, 5);
            this.txtRemitentes.Name = "txtRemitentes";
            this.txtRemitentes.Size = new System.Drawing.Size(270, 22);
            this.txtRemitentes.TabIndex = 10;
            // 
            // chkUsarRemitentes
            // 
            this.chkUsarRemitentes.AutoSize = true;
            this.chkUsarRemitentes.Location = new System.Drawing.Point(8, 7);
            this.chkUsarRemitentes.Name = "chkUsarRemitentes";
            this.chkUsarRemitentes.Size = new System.Drawing.Size(170, 18);
            this.chkUsarRemitentes.TabIndex = 9;
            this.chkUsarRemitentes.Text = "Utilizar filtro de remitente:";
            this.chkUsarRemitentes.UseVisualStyleBackColor = true;
            this.chkUsarRemitentes.CheckedChanged += new System.EventHandler(this.chkUsarRemitentes_CheckedChanged);
            // 
            // tabP_Avanzado
            // 
            this.tabP_Avanzado.BackColor = System.Drawing.Color.GhostWhite;
            this.tabP_Avanzado.Controls.Add(this.label7);
            this.tabP_Avanzado.Controls.Add(this.txtExtensiones);
            this.tabP_Avanzado.Controls.Add(this.chkUsarExtensiones);
            this.tabP_Avanzado.Location = new System.Drawing.Point(4, 23);
            this.tabP_Avanzado.Name = "tabP_Avanzado";
            this.tabP_Avanzado.Size = new System.Drawing.Size(939, 128);
            this.tabP_Avanzado.TabIndex = 3;
            this.tabP_Avanzado.Text = "Avanzado";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(333, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(265, 14);
            this.label7.TabIndex = 8;
            this.label7.Text = "(Se pueden colocar varias separadas por coma)";
            // 
            // txtExtensiones
            // 
            this.txtExtensiones.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtExtensiones.Enabled = false;
            this.txtExtensiones.Location = new System.Drawing.Point(192, 3);
            this.txtExtensiones.Name = "txtExtensiones";
            this.txtExtensiones.Size = new System.Drawing.Size(135, 22);
            this.txtExtensiones.TabIndex = 7;
            // 
            // chkUsarExtensiones
            // 
            this.chkUsarExtensiones.AutoSize = true;
            this.chkUsarExtensiones.Location = new System.Drawing.Point(3, 5);
            this.chkUsarExtensiones.Name = "chkUsarExtensiones";
            this.chkUsarExtensiones.Size = new System.Drawing.Size(183, 18);
            this.chkUsarExtensiones.TabIndex = 6;
            this.chkUsarExtensiones.Text = "Utilizar filtro de extensiones:";
            this.chkUsarExtensiones.UseVisualStyleBackColor = true;
            this.chkUsarExtensiones.CheckedChanged += new System.EventHandler(this.chkUsarExtensiones_CheckedChanged);
            // 
            // pnlBuscar
            // 
            this.pnlBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBuscar.BackColor = System.Drawing.Color.GhostWhite;
            this.pnlBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBuscar.Controls.Add(this.btnBuscar);
            this.pnlBuscar.Location = new System.Drawing.Point(965, 48);
            this.pnlBuscar.Name = "pnlBuscar";
            this.pnlBuscar.Size = new System.Drawing.Size(141, 134);
            this.pnlBuscar.TabIndex = 3;
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = global::GlosarioCorreos.Properties.Resources.Buscar_90;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscar.Location = new System.Drawing.Point(11, 6);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(117, 120);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.herramientasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1118, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbrirBusqueda,
            this.mnuGuardarBusqueda,
            this.mnuObtenerQuery,
            this.toolStripMenuItem1,
            this.mnuExit});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.herramientasToolStripMenuItem.Text = "&Herramientas";
            // 
            // mnuAbrirBusqueda
            // 
            this.mnuAbrirBusqueda.Name = "mnuAbrirBusqueda";
            this.mnuAbrirBusqueda.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuAbrirBusqueda.Size = new System.Drawing.Size(211, 22);
            this.mnuAbrirBusqueda.Text = "&Abrir búsqueda";
            this.mnuAbrirBusqueda.Click += new System.EventHandler(this.mnuAbrirBusqueda_Click);
            // 
            // mnuGuardarBusqueda
            // 
            this.mnuGuardarBusqueda.Name = "mnuGuardarBusqueda";
            this.mnuGuardarBusqueda.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuGuardarBusqueda.Size = new System.Drawing.Size(211, 22);
            this.mnuGuardarBusqueda.Text = "&Guardar búsqueda";
            this.mnuGuardarBusqueda.Click += new System.EventHandler(this.mnuGuardarBusqueda_Click);
            // 
            // mnuObtenerQuery
            // 
            this.mnuObtenerQuery.CheckOnClick = true;
            this.mnuObtenerQuery.Name = "mnuObtenerQuery";
            this.mnuObtenerQuery.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.mnuObtenerQuery.Size = new System.Drawing.Size(211, 22);
            this.mnuObtenerQuery.Text = "Obtener Query";
            this.mnuObtenerQuery.Click += new System.EventHandler(this.mnuObtenerQuery_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(208, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuExit.Size = new System.Drawing.Size(211, 22);
            this.mnuExit.Text = "&Salir";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // status01
            // 
            this.status01.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblEncontrados,
            this.lblTamanno,
            this.lblTiempo});
            this.status01.Location = new System.Drawing.Point(0, 575);
            this.status01.Name = "status01";
            this.status01.Size = new System.Drawing.Size(1118, 22);
            this.status01.TabIndex = 5;
            this.status01.Text = "statusStrip1";
            // 
            // lblEncontrados
            // 
            this.lblEncontrados.Font = new System.Drawing.Font("Calibri", 8F);
            this.lblEncontrados.Name = "lblEncontrados";
            this.lblEncontrados.Size = new System.Drawing.Size(367, 17);
            this.lblEncontrados.Spring = true;
            this.lblEncontrados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTamanno
            // 
            this.lblTamanno.Font = new System.Drawing.Font("Calibri", 8F);
            this.lblTamanno.Name = "lblTamanno";
            this.lblTamanno.Size = new System.Drawing.Size(367, 17);
            this.lblTamanno.Spring = true;
            this.lblTamanno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTiempo
            // 
            this.lblTiempo.Font = new System.Drawing.Font("Calibri", 8F);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(367, 17);
            this.lblTiempo.Spring = true;
            this.lblTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sfd01
            // 
            this.sfd01.DefaultExt = "rbg";
            this.sfd01.Filter = "Resultados de búsqueda|*.rbg";
            // 
            // ofd01
            // 
            this.ofd01.DefaultExt = "rbg";
            this.ofd01.Filter = "Resultados de búsqueda|*.rbg";
            // 
            // gbResultados
            // 
            this.gbResultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResultados.BackColor = System.Drawing.SystemColors.Control;
            this.gbResultados.Controls.Add(this.gbVistaPrevia);
            this.gbResultados.Controls.Add(this.lstArchivos);
            this.gbResultados.Location = new System.Drawing.Point(12, 188);
            this.gbResultados.Name = "gbResultados";
            this.gbResultados.Size = new System.Drawing.Size(1094, 384);
            this.gbResultados.TabIndex = 6;
            this.gbResultados.TabStop = false;
            this.gbResultados.Text = "Resultados";
            // 
            // gbVistaPrevia
            // 
            this.gbVistaPrevia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbVistaPrevia.Controls.Add(this.brw01);
            this.gbVistaPrevia.Location = new System.Drawing.Point(722, 21);
            this.gbVistaPrevia.Name = "gbVistaPrevia";
            this.gbVistaPrevia.Size = new System.Drawing.Size(366, 357);
            this.gbVistaPrevia.TabIndex = 1;
            this.gbVistaPrevia.TabStop = false;
            this.gbVistaPrevia.Text = "Vista previa:";
            // 
            // brw01
            // 
            this.brw01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.brw01.Location = new System.Drawing.Point(3, 18);
            this.brw01.MinimumSize = new System.Drawing.Size(20, 20);
            this.brw01.Name = "brw01";
            this.brw01.Size = new System.Drawing.Size(360, 336);
            this.brw01.TabIndex = 0;
            // 
            // lstArchivos
            // 
            this.lstArchivos.AllColumns.Add(this.colRemitente);
            this.lstArchivos.AllColumns.Add(this.colFecha);
            this.lstArchivos.AllColumns.Add(this.colAsunto);
            this.lstArchivos.AllColumns.Add(this.colID);
            this.lstArchivos.AllColumns.Add(this.colHTML);
            this.lstArchivos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstArchivos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRemitente,
            this.colFecha,
            this.colAsunto});
            this.lstArchivos.DataSource = null;
            this.lstArchivos.FullRowSelect = true;
            this.lstArchivos.GridLines = true;
            this.lstArchivos.Location = new System.Drawing.Point(6, 21);
            this.lstArchivos.Name = "lstArchivos";
            this.lstArchivos.ShowGroups = false;
            this.lstArchivos.ShowImagesOnSubItems = true;
            this.lstArchivos.Size = new System.Drawing.Size(710, 357);
            this.lstArchivos.TabIndex = 0;
            this.lstArchivos.UseCompatibleStateImageBehavior = false;
            this.lstArchivos.View = System.Windows.Forms.View.Details;
            this.lstArchivos.VirtualMode = true;
            this.lstArchivos.SelectedIndexChanged += new System.EventHandler(this.lstArchivos_SelectedIndexChanged);
            this.lstArchivos.DoubleClick += new System.EventHandler(this.lstArchivos_DoubleClick);
            // 
            // colRemitente
            // 
            this.colRemitente.AspectName = "Remitente";
            this.colRemitente.Text = "Remitente";
            this.colRemitente.Width = 167;
            // 
            // colFecha
            // 
            this.colFecha.AspectName = "Fecha";
            this.colFecha.Text = "Fecha";
            this.colFecha.Width = 111;
            // 
            // colAsunto
            // 
            this.colAsunto.AspectName = "Asunto";
            this.colAsunto.Text = "Asunto";
            this.colAsunto.Width = 424;
            // 
            // colID
            // 
            this.colID.IsEditable = false;
            this.colID.IsVisible = false;
            this.colID.Searchable = false;
            this.colID.ShowTextInHeader = false;
            this.colID.Sortable = false;
            // 
            // colHTML
            // 
            this.colHTML.IsEditable = false;
            this.colHTML.IsVisible = false;
            this.colHTML.Searchable = false;
            this.colHTML.ShowTextInHeader = false;
            this.colHTML.Sortable = false;
            // 
            // pnlEngine
            // 
            this.pnlEngine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEngine.Controls.Add(this.pbEngine);
            this.pnlEngine.Location = new System.Drawing.Point(1600, 188);
            this.pnlEngine.Name = "pnlEngine";
            this.pnlEngine.Size = new System.Drawing.Size(1090, 384);
            this.pnlEngine.TabIndex = 7;
            this.pnlEngine.Visible = false;
            // 
            // pbEngine
            // 
            this.pbEngine.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbEngine.Image = global::GlosarioCorreos.Properties.Resources.gears_animated_t;
            this.pbEngine.Location = new System.Drawing.Point(475, 122);
            this.pbEngine.Name = "pbEngine";
            this.pbEngine.Size = new System.Drawing.Size(141, 141);
            this.pbEngine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbEngine.TabIndex = 0;
            this.pbEngine.TabStop = false;
            // 
            // wkrBusqueda
            // 
            this.wkrBusqueda.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wkrBusqueda_DoWork);
            this.wkrBusqueda.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.wkrBusqueda_RunWorkerCompleted);
            // 
            // frmExtractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 597);
            this.Controls.Add(this.pnlEngine);
            this.Controls.Add(this.gbResultados);
            this.Controls.Add(this.status01);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pnlBuscar);
            this.Controls.Add(this.tabFiltros);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(680, 428);
            this.Name = "frmExtractor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extractor del glosario de correos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmExtractor_FormClosed);
            this.Load += new System.EventHandler(this.frmExtractor_Load);
            this.tabFiltros.ResumeLayout(false);
            this.tabP_General.ResumeLayout(false);
            this.tabP_General.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxResultados)).EndInit();
            this.tabP_Fecha.ResumeLayout(false);
            this.tabP_Fecha.PerformLayout();
            this.tabP_Tamanno.ResumeLayout(false);
            this.tabP_Tamanno.PerformLayout();
            this.tabP_Avanzado.ResumeLayout(false);
            this.tabP_Avanzado.PerformLayout();
            this.pnlBuscar.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.status01.ResumeLayout(false);
            this.status01.PerformLayout();
            this.gbResultados.ResumeLayout(false);
            this.gbVistaPrevia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstArchivos)).EndInit();
            this.pnlEngine.ResumeLayout(false);
            this.pnlEngine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEngine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabFiltros;
        private System.Windows.Forms.TabPage tabP_General;
        private System.Windows.Forms.Label lblMaxResT;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numMaxResultados;
        private System.Windows.Forms.TextBox txtKeywords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabP_Fecha;
        private System.Windows.Forms.CheckBox chkUsarFechas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtIni;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtFin;
        private System.Windows.Forms.TabPage tabP_Tamanno;
        private System.Windows.Forms.TabPage tabP_Avanzado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtExtensiones;
        private System.Windows.Forms.CheckBox chkUsarExtensiones;
        private System.Windows.Forms.Panel pnlBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAbrirBusqueda;
        private System.Windows.Forms.ToolStripMenuItem mnuGuardarBusqueda;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.StatusStrip status01;
        private System.Windows.Forms.ToolStripStatusLabel lblEncontrados;
        private System.Windows.Forms.ToolStripStatusLabel lblTamanno;
        private System.Windows.Forms.ToolStripStatusLabel lblTiempo;
        private System.Windows.Forms.SaveFileDialog sfd01;
        private System.Windows.Forms.OpenFileDialog ofd01;
        private System.Windows.Forms.GroupBox gbResultados;
        private BrightIdeasSoftware.FastDataListView lstArchivos;
        private BrightIdeasSoftware.OLVColumn colRemitente;
        private BrightIdeasSoftware.OLVColumn colFecha;
        private BrightIdeasSoftware.OLVColumn colAsunto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRemitentes;
        private System.Windows.Forms.CheckBox chkUsarRemitentes;
        private System.Windows.Forms.GroupBox gbVistaPrevia;
        private System.Windows.Forms.WebBrowser brw01;
        private BrightIdeasSoftware.OLVColumn colHTML;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDestinatarios;
        private System.Windows.Forms.CheckBox chkUsarDestinatarios;
        private System.Windows.Forms.Panel pnlEngine;
        private System.Windows.Forms.PictureBox pbEngine;
        private OLVColumn colID;
        private System.Windows.Forms.CheckBox chkHayErrorFF;
        private System.Windows.Forms.Label lblErrorFF;
        private System.ComponentModel.BackgroundWorker wkrBusqueda;
        private System.Windows.Forms.CheckBox chkUsarBDestinatarios;
        private System.Windows.Forms.CheckBox chkUsarAdjuntos;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkBusquedaRapida;
        private System.Windows.Forms.ToolStripMenuItem mnuObtenerQuery;
    }
}