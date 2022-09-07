using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;

namespace Proyecto_procesamiento_de_imagenes
{
    public partial class Deteccion_de_camara : Form
    {
        private bool HayDispositivos;
        private FilterInfoCollection MiDispositivos;
        private VideoCaptureDevice MiWebCam = null;

        public Deteccion_de_camara()
        {
            InitializeComponent();
        }

        private void Deteccion_de_camara_Load(object sender, EventArgs e)
        {
            CargaDispositivos();
        }

        public void CargaDispositivos()
        {
            MiDispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (MiDispositivos.Count > 0)
            {
                HayDispositivos = true;
                for (int i = 0; i < MiDispositivos.Count; i++)
                    cbDispositivos.Items.Add(MiDispositivos[i].Name.ToString());
                cbDispositivos.Text = MiDispositivos[0].ToString();
            }
            else
            {
                HayDispositivos = false;
            }
        }

        public void CerrarWebCam() 
        {
            if (MiWebCam != null && MiWebCam.IsRunning)
            {
                MiWebCam.SignalToStop();
                MiWebCam = null;
            }
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            CerrarWebCam();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            CerrarWebCam();
            int i = cbDispositivos.SelectedIndex;
            string NombreVideo = MiDispositivos[i].MonikerString;
            MiWebCam = new VideoCaptureDevice(NombreVideo);
            MiWebCam.NewFrame += new NewFrameEventHandler(Capturando);
            MiWebCam.Start();
        }

        public void Capturando(object sender, NewFrameEventArgs eventArgs)
        { 
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();
            pbCamara.Image = Imagen;
        }
    }
}
