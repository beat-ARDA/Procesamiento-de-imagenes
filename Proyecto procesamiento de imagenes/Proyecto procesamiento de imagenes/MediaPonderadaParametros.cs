using Proyecto_procesamiento_de_imagenes.clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_procesamiento_de_imagenes
{
    public partial class MediaPonderadaParametros : Form
    {
        bool bandera;
        string fileName;
        PictureBox pbImagenFinal;
        public MediaPonderadaParametros(bool _bandera, string _fileName, PictureBox _pbImagenFinal)
        {
            this.bandera = _bandera;
            this.fileName = _fileName;
            this.pbImagenFinal = _pbImagenFinal;
            InitializeComponent();
        }

        private void btnAceptarFMP_Click(object sender, EventArgs e)
        {
            if (!bandera)
            {
                try
                {
                    string imagen = fileName;

                    Bitmap bitmapResultante = new Bitmap(imagen);
                    BitmapConverter bitmapConverter = new BitmapConverter(bitmapResultante);
                    Bitmap bitmapFiltrado = bitmapConverter.FilterMediaPonderada(tbFMP.Value, Convert.ToInt32(txtValorFMP.Text.ToString()));
                    pbImagenFinal.Image = bitmapFiltrado;

                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido " + ex);
                }
            }
        }
    }
}
