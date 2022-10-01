namespace Proyecto_procesamiento_de_imagenes
{
    partial class MediaPonderadaParametros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MediaPonderadaParametros));
            this.btnAceptarFMP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValorFMP = new System.Windows.Forms.TextBox();
            this.tbFMP = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.tbFMP)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptarFMP
            // 
            this.btnAceptarFMP.BackColor = System.Drawing.Color.BlueViolet;
            this.btnAceptarFMP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAceptarFMP.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAceptarFMP.Location = new System.Drawing.Point(118, 92);
            this.btnAceptarFMP.Name = "btnAceptarFMP";
            this.btnAceptarFMP.Size = new System.Drawing.Size(75, 23);
            this.btnAceptarFMP.TabIndex = 0;
            this.btnAceptarFMP.Text = "Aceptar";
            this.btnAceptarFMP.UseVisualStyleBackColor = false;
            this.btnAceptarFMP.Click += new System.EventHandler(this.btnAceptarFMP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Valor de peso:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Radio kernel:";
            // 
            // txtValorFMP
            // 
            this.txtValorFMP.Location = new System.Drawing.Point(93, 15);
            this.txtValorFMP.Name = "txtValorFMP";
            this.txtValorFMP.Size = new System.Drawing.Size(100, 20);
            this.txtValorFMP.TabIndex = 3;
            // 
            // tbFMP
            // 
            this.tbFMP.Location = new System.Drawing.Point(88, 41);
            this.tbFMP.Maximum = 4;
            this.tbFMP.Name = "tbFMP";
            this.tbFMP.Size = new System.Drawing.Size(104, 45);
            this.tbFMP.TabIndex = 4;
            // 
            // MediaPonderadaParametros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(215, 129);
            this.Controls.Add(this.tbFMP);
            this.Controls.Add(this.txtValorFMP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAceptarFMP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MediaPonderadaParametros";
            this.Text = "Parametros";
            ((System.ComponentModel.ISupportInitialize)(this.tbFMP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptarFMP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValorFMP;
        private System.Windows.Forms.TrackBar tbFMP;
    }
}