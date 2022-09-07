using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_procesamiento_de_imagenes
{
    public partial class FormPrincipal : Form
    {
        static bool bandera = false;
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (!bandera)
            {
                try
                {
                    if (ofdCargarImagen.ShowDialog() == DialogResult.OK)
                    {
                        string imagen = ofdCargarImagen.FileName;
                        pbCargarImagen.Image = Image.FromFile(imagen);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
                }
            }
            if (bandera)
            {
                try
                {
                    if (ofdCargarVideo.ShowDialog() == DialogResult.OK)
                    {
                        string video = ofdCargarVideo.FileName;
                        wmpCargarVideo.URL = video;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("El archivo seleccionado no es un tipo de video válido");
                }
            }
        }
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            pbCargarImagen.Visible = true;
            pbCargarImagen.Enabled = true;
            pbImagenFinal.Visible = true;
            pbImagenFinal.Enabled = true;

            wmpCargarVideo.Visible = false;
            wmpCargarVideo.Enabled = false;
            wmpVideoFinal.Visible = false;
            wmpVideoFinal.Enabled = false;

            bandera = false;
            lblTitulo.Text = "Filtrado de imagenes";
        }

        private void filtrosDeVideosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pbCargarImagen.Visible = false;
            pbCargarImagen.Enabled = false;
            pbImagenFinal.Visible = false;
            pbImagenFinal.Enabled = false;

            wmpCargarVideo.Visible = true;
            wmpCargarVideo.Enabled = true;
            wmpVideoFinal.Visible = true;
            wmpVideoFinal.Enabled = true;

            bandera = true;
            lblTitulo.Text = "Filtrado de videos";
        }

        private void filtrosDeImagenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wmpCargarVideo.Visible = false;
            wmpCargarVideo.Enabled = false;
            wmpVideoFinal.Visible = false;
            wmpVideoFinal.Enabled = false;

            pbCargarImagen.Visible = true;
            pbCargarImagen.Enabled = true;
            pbImagenFinal.Visible = true;
            pbImagenFinal.Enabled = true;

            bandera = false;
            lblTitulo.Text = "Filtrado de imagenes";
        }

        private void btnHistograma_Click(object sender, EventArgs e)
        {
            Histograma histogramaForm = new Histograma();
            histogramaForm.Show();
        }

        private void deteccionDeCamaraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Deteccion_de_camara deteccionDeCamaraForm = new Deteccion_de_camara();
            deteccionDeCamaraForm.ShowDialog();
        }


        //private void btnCargarVideo_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ofdCargarVideo.ShowDialog() == DialogResult.OK)
        //        {
        //            string video = ofdCargarVideo.FileName;
        //            wmpCargarVideo.URL = video;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("El archivo seleccionado no es un tipo de video válido");
        //    }
        //}
    }
}
