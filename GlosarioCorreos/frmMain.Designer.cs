namespace GlosarioCorreos
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.fbd01 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.btnExplorar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlPST = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlPie = new System.Windows.Forms.Panel();
            this.lblRestante = new System.Windows.Forms.Label();
            this.pieProceso = new System.Drawing.PieChart.PieChartControl();
            this.wkrMain = new System.ComponentModel.BackgroundWorker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.tip01 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.pnlPie.SuspendLayout();
            this.SuspendLayout();
            // 
            // fbd01
            // 
            resources.ApplyResources(this.fbd01, "fbd01");
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtRuta
            // 
            resources.ApplyResources(this.txtRuta, "txtRuta");
            this.txtRuta.Name = "txtRuta";
            // 
            // btnExplorar
            // 
            this.btnExplorar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            resources.ApplyResources(this.btnExplorar, "btnExplorar");
            this.btnExplorar.Name = "btnExplorar";
            this.btnExplorar.UseVisualStyleBackColor = true;
            this.btnExplorar.Click += new System.EventHandler(this.btnExplorar_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // ddlPST
            // 
            this.ddlPST.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPST.FormattingEnabled = true;
            resources.ApplyResources(this.ddlPST, "ddlPST");
            this.ddlPST.Name = "ddlPST";
            this.ddlPST.SelectedIndexChanged += new System.EventHandler(this.ddlPST_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.herramientasToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAgregar,
            this.toolStripMenuItem1,
            this.mnuSalir});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            resources.ApplyResources(this.herramientasToolStripMenuItem, "herramientasToolStripMenuItem");
            // 
            // mnuAgregar
            // 
            this.mnuAgregar.Name = "mnuAgregar";
            resources.ApplyResources(this.mnuAgregar, "mnuAgregar");
            this.mnuAgregar.Click += new System.EventHandler(this.mnuAgregar_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // mnuSalir
            // 
            this.mnuSalir.Name = "mnuSalir";
            resources.ApplyResources(this.mnuSalir, "mnuSalir");
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // pnlPie
            // 
            this.pnlPie.Controls.Add(this.lblRestante);
            this.pnlPie.Controls.Add(this.pieProceso);
            resources.ApplyResources(this.pnlPie, "pnlPie");
            this.pnlPie.Name = "pnlPie";
            // 
            // lblRestante
            // 
            resources.ApplyResources(this.lblRestante, "lblRestante");
            this.lblRestante.Name = "lblRestante";
            // 
            // pieProceso
            // 
            resources.ApplyResources(this.pieProceso, "pieProceso");
            this.pieProceso.Name = "pieProceso";
            this.pieProceso.ToolTips = null;
            // 
            // wkrMain
            // 
            this.wkrMain.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wkrMain_DoWork);
            this.wkrMain.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.wkrMain_RunWorkerCompleted);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            resources.ApplyResources(this.btnBuscar, "btnBuscar");
            this.btnBuscar.Image = global::GlosarioCorreos.Properties.Resources.save_mail_90;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPie);
            this.Controls.Add(this.ddlPST);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnExplorar);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlPie.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fbd01;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Button btnExplorar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlPST;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAgregar;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;
        private System.Windows.Forms.Panel pnlPie;
        private System.Drawing.PieChart.PieChartControl pieProceso;
        private System.ComponentModel.BackgroundWorker wkrMain;
        private System.Windows.Forms.Label lblRestante;
        private System.Windows.Forms.ToolTip tip01;
    }
}

