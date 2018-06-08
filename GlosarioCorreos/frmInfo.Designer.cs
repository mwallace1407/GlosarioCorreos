namespace GlosarioCorreos
{
    partial class frmInfo
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
            this.lstInfo = new BrightIdeasSoftware.FastDataListView();
            this.colCampo = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colValor = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.lstInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // lstInfo
            // 
            this.lstInfo.AllColumns.Add(this.colCampo);
            this.lstInfo.AllColumns.Add(this.colValor);
            this.lstInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCampo,
            this.colValor});
            this.lstInfo.DataSource = null;
            this.lstInfo.FullRowSelect = true;
            this.lstInfo.GridLines = true;
            this.lstInfo.Location = new System.Drawing.Point(12, 12);
            this.lstInfo.Name = "lstInfo";
            this.lstInfo.ShowGroups = false;
            this.lstInfo.ShowImagesOnSubItems = true;
            this.lstInfo.Size = new System.Drawing.Size(454, 182);
            this.lstInfo.TabIndex = 1;
            this.lstInfo.UseCompatibleStateImageBehavior = false;
            this.lstInfo.View = System.Windows.Forms.View.Details;
            this.lstInfo.VirtualMode = true;
            // 
            // colCampo
            // 
            this.colCampo.AspectName = "Concepto";
            this.colCampo.Text = "";
            this.colCampo.Width = 75;
            // 
            // colValor
            // 
            this.colValor.AspectName = "Valor";
            this.colValor.Text = "";
            this.colValor.Width = 360;
            // 
            // frmInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 207);
            this.Controls.Add(this.lstInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Información del correo";
            this.Load += new System.EventHandler(this.frmInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lstInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.FastDataListView lstInfo;
        private BrightIdeasSoftware.OLVColumn colCampo;
        private BrightIdeasSoftware.OLVColumn colValor;
    }
}