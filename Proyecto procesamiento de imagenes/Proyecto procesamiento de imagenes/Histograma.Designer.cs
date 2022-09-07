namespace Proyecto_procesamiento_de_imagenes
{
    partial class Histograma
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Histograma));
            this.chHistograma = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chHistograma)).BeginInit();
            this.SuspendLayout();
            // 
            // chHistograma
            // 
            this.chHistograma.BackSecondaryColor = System.Drawing.Color.Transparent;
            this.chHistograma.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chHistograma.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chHistograma.Legends.Add(legend1);
            this.chHistograma.Location = new System.Drawing.Point(1, 1);
            this.chHistograma.Name = "chHistograma";
            this.chHistograma.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chHistograma.Series.Add(series1);
            this.chHistograma.Size = new System.Drawing.Size(543, 284);
            this.chHistograma.TabIndex = 0;
            this.chHistograma.Text = "Histograma";
            // 
            // Histograma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(544, 284);
            this.Controls.Add(this.chHistograma);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Histograma";
            this.Text = "Histograma";
            ((System.ComponentModel.ISupportInitialize)(this.chHistograma)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chHistograma;
    }
}