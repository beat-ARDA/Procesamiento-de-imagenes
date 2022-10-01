namespace Proyecto_procesamiento_de_imagenes
{
    partial class FormPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.ofdCargarImagen = new System.Windows.Forms.OpenFileDialog();
            this.btnCargar = new System.Windows.Forms.Button();
            this.pbCargarImagen = new System.Windows.Forms.PictureBox();
            this.ofdCargarVideo = new System.Windows.Forms.OpenFileDialog();
            this.pbImagenFinal = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filtrosDeImagenesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtrosDeVideosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deteccionDeCamaraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDescargar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnFiltroMediaPonderada = new System.Windows.Forms.Button();
            this.lblFiltroGaussiano = new System.Windows.Forms.Label();
            this.tbFMAX = new System.Windows.Forms.TrackBar();
            this.btnHistograma = new System.Windows.Forms.Button();
            this.tbFiltroMedia = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFiltroMediana = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.wmpVideoFinal = new AxWMPLib.AxWindowsMediaPlayer();
            this.wmpCargarVideo = new AxWMPLib.AxWindowsMediaPlayer();
            this.tbFMIN = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCargarImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenFinal)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbFMAX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFiltroMedia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFiltroMediana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmpVideoFinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmpCargarVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFMIN)).BeginInit();
            this.SuspendLayout();
            // 
            // ofdCargarImagen
            // 
            this.ofdCargarImagen.FileName = "ofdCargarImagen";
            // 
            // btnCargar
            // 
            this.btnCargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnCargar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCargar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCargar.Location = new System.Drawing.Point(147, 483);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(442, 36);
            this.btnCargar.TabIndex = 0;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // pbCargarImagen
            // 
            this.pbCargarImagen.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pbCargarImagen.Location = new System.Drawing.Point(147, 64);
            this.pbCargarImagen.Name = "pbCargarImagen";
            this.pbCargarImagen.Size = new System.Drawing.Size(442, 413);
            this.pbCargarImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCargarImagen.TabIndex = 1;
            this.pbCargarImagen.TabStop = false;
            // 
            // ofdCargarVideo
            // 
            this.ofdCargarVideo.FileName = "openFileDialog1";
            // 
            // pbImagenFinal
            // 
            this.pbImagenFinal.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pbImagenFinal.Location = new System.Drawing.Point(595, 64);
            this.pbImagenFinal.Name = "pbImagenFinal";
            this.pbImagenFinal.Size = new System.Drawing.Size(442, 413);
            this.pbImagenFinal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImagenFinal.TabIndex = 5;
            this.pbImagenFinal.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.BlueViolet;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filtrosDeImagenesToolStripMenuItem,
            this.filtrosDeVideosToolStripMenuItem,
            this.deteccionDeCamaraToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1043, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filtrosDeImagenesToolStripMenuItem
            // 
            this.filtrosDeImagenesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.filtrosDeImagenesToolStripMenuItem.Name = "filtrosDeImagenesToolStripMenuItem";
            this.filtrosDeImagenesToolStripMenuItem.Size = new System.Drawing.Size(126, 20);
            this.filtrosDeImagenesToolStripMenuItem.Text = "Filtros de imagenes";
            this.filtrosDeImagenesToolStripMenuItem.Click += new System.EventHandler(this.filtrosDeImagenesToolStripMenuItem_Click);
            // 
            // filtrosDeVideosToolStripMenuItem
            // 
            this.filtrosDeVideosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.filtrosDeVideosToolStripMenuItem.Name = "filtrosDeVideosToolStripMenuItem";
            this.filtrosDeVideosToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.filtrosDeVideosToolStripMenuItem.Text = "Filtros de videos";
            this.filtrosDeVideosToolStripMenuItem.Click += new System.EventHandler(this.filtrosDeVideosToolStripMenuItem_Click);
            // 
            // deteccionDeCamaraToolStripMenuItem
            // 
            this.deteccionDeCamaraToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.deteccionDeCamaraToolStripMenuItem.Name = "deteccionDeCamaraToolStripMenuItem";
            this.deteccionDeCamaraToolStripMenuItem.Size = new System.Drawing.Size(136, 20);
            this.deteccionDeCamaraToolStripMenuItem.Text = "Deteccion de camara";
            this.deteccionDeCamaraToolStripMenuItem.Click += new System.EventHandler(this.deteccionDeCamaraToolStripMenuItem_Click);
            // 
            // btnDescargar
            // 
            this.btnDescargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnDescargar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDescargar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDescargar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescargar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDescargar.Location = new System.Drawing.Point(595, 483);
            this.btnDescargar.Name = "btnDescargar";
            this.btnDescargar.Size = new System.Drawing.Size(442, 36);
            this.btnDescargar.TabIndex = 9;
            this.btnDescargar.Text = "Descargar";
            this.btnDescargar.UseVisualStyleBackColor = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(466, 24);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(235, 26);
            this.lblTitulo.TabIndex = 10;
            this.lblTitulo.Text = "Filtrado de imagenes";
            // 
            // btnFiltroMediaPonderada
            // 
            this.btnFiltroMediaPonderada.BackColor = System.Drawing.Color.BlueViolet;
            this.btnFiltroMediaPonderada.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiltroMediaPonderada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltroMediaPonderada.ForeColor = System.Drawing.SystemColors.Control;
            this.btnFiltroMediaPonderada.Location = new System.Drawing.Point(12, 135);
            this.btnFiltroMediaPonderada.Name = "btnFiltroMediaPonderada";
            this.btnFiltroMediaPonderada.Size = new System.Drawing.Size(129, 36);
            this.btnFiltroMediaPonderada.TabIndex = 12;
            this.btnFiltroMediaPonderada.Text = "Filtro media ponderada";
            this.btnFiltroMediaPonderada.UseVisualStyleBackColor = false;
            this.btnFiltroMediaPonderada.Click += new System.EventHandler(this.btnFiltroMediaPonderada_Click);
            // 
            // lblFiltroGaussiano
            // 
            this.lblFiltroGaussiano.AutoSize = true;
            this.lblFiltroGaussiano.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroGaussiano.Location = new System.Drawing.Point(35, 246);
            this.lblFiltroGaussiano.Name = "lblFiltroGaussiano";
            this.lblFiltroGaussiano.Size = new System.Drawing.Size(80, 13);
            this.lblFiltroGaussiano.TabIndex = 13;
            this.lblFiltroGaussiano.Text = "Filtro maximo";
            // 
            // tbFMAX
            // 
            this.tbFMAX.Location = new System.Drawing.Point(12, 262);
            this.tbFMAX.Maximum = 4;
            this.tbFMAX.Name = "tbFMAX";
            this.tbFMAX.Size = new System.Drawing.Size(129, 45);
            this.tbFMAX.TabIndex = 14;
            this.tbFMAX.Scroll += new System.EventHandler(this.tbFMAX_Scroll);
            // 
            // btnHistograma
            // 
            this.btnHistograma.BackColor = System.Drawing.Color.BlueViolet;
            this.btnHistograma.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHistograma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistograma.ForeColor = System.Drawing.SystemColors.Control;
            this.btnHistograma.Location = new System.Drawing.Point(12, 483);
            this.btnHistograma.Name = "btnHistograma";
            this.btnHistograma.Size = new System.Drawing.Size(129, 36);
            this.btnHistograma.TabIndex = 16;
            this.btnHistograma.Text = "Histograma";
            this.btnHistograma.UseVisualStyleBackColor = false;
            this.btnHistograma.Click += new System.EventHandler(this.btnHistograma_Click);
            // 
            // tbFiltroMedia
            // 
            this.tbFiltroMedia.Location = new System.Drawing.Point(12, 42);
            this.tbFiltroMedia.Maximum = 4;
            this.tbFiltroMedia.Name = "tbFiltroMedia";
            this.tbFiltroMedia.Size = new System.Drawing.Size(129, 45);
            this.tbFiltroMedia.TabIndex = 20;
            this.tbFiltroMedia.Scroll += new System.EventHandler(this.tbFiltroMedia_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Filtro media";
            // 
            // tbFiltroMediana
            // 
            this.tbFiltroMediana.Location = new System.Drawing.Point(12, 93);
            this.tbFiltroMediana.Maximum = 4;
            this.tbFiltroMediana.Name = "tbFiltroMediana";
            this.tbFiltroMediana.Size = new System.Drawing.Size(129, 45);
            this.tbFiltroMediana.TabIndex = 22;
            this.tbFiltroMediana.Scroll += new System.EventHandler(this.tbFiltroMediana_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Filtro mediana";
            // 
            // wmpVideoFinal
            // 
            this.wmpVideoFinal.Enabled = true;
            this.wmpVideoFinal.Location = new System.Drawing.Point(595, 64);
            this.wmpVideoFinal.Name = "wmpVideoFinal";
            this.wmpVideoFinal.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmpVideoFinal.OcxState")));
            this.wmpVideoFinal.Size = new System.Drawing.Size(442, 413);
            this.wmpVideoFinal.TabIndex = 8;
            // 
            // wmpCargarVideo
            // 
            this.wmpCargarVideo.Enabled = true;
            this.wmpCargarVideo.Location = new System.Drawing.Point(147, 64);
            this.wmpCargarVideo.Name = "wmpCargarVideo";
            this.wmpCargarVideo.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmpCargarVideo.OcxState")));
            this.wmpCargarVideo.Size = new System.Drawing.Size(442, 413);
            this.wmpCargarVideo.TabIndex = 7;
            // 
            // tbFMIN
            // 
            this.tbFMIN.Location = new System.Drawing.Point(12, 198);
            this.tbFMIN.Maximum = 4;
            this.tbFMIN.Name = "tbFMIN";
            this.tbFMIN.Size = new System.Drawing.Size(129, 45);
            this.tbFMIN.TabIndex = 24;
            this.tbFMIN.Scroll += new System.EventHandler(this.tbFMIN_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Filtro minimo";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1043, 529);
            this.Controls.Add(this.tbFMIN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbFiltroMediana);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbFiltroMedia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHistograma);
            this.Controls.Add(this.tbFMAX);
            this.Controls.Add(this.lblFiltroGaussiano);
            this.Controls.Add(this.btnFiltroMediaPonderada);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnDescargar);
            this.Controls.Add(this.wmpVideoFinal);
            this.Controls.Add(this.wmpCargarVideo);
            this.Controls.Add(this.pbImagenFinal);
            this.Controls.Add(this.pbCargarImagen);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.Text = "Procesamiento de imagenes";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCargarImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenFinal)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbFMAX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFiltroMedia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFiltroMediana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmpVideoFinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmpCargarVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFMIN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdCargarImagen;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.PictureBox pbCargarImagen;
        private System.Windows.Forms.OpenFileDialog ofdCargarVideo;
        private System.Windows.Forms.PictureBox pbImagenFinal;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filtrosDeImagenesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtrosDeVideosToolStripMenuItem;
        private AxWMPLib.AxWindowsMediaPlayer wmpCargarVideo;
        private AxWMPLib.AxWindowsMediaPlayer wmpVideoFinal;
        private System.Windows.Forms.Button btnDescargar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ToolStripMenuItem deteccionDeCamaraToolStripMenuItem;
        private System.Windows.Forms.Button btnFiltroMediaPonderada;
        private System.Windows.Forms.Label lblFiltroGaussiano;
        private System.Windows.Forms.TrackBar tbFMAX;
        private System.Windows.Forms.Button btnHistograma;
        private System.Windows.Forms.TrackBar tbFiltroMedia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tbFiltroMediana;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar tbFMIN;
        private System.Windows.Forms.Label label3;
    }
}

