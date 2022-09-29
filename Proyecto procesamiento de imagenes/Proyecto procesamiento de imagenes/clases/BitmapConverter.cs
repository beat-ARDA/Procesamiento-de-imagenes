using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_procesamiento_de_imagenes.clases
{
    public class BitmapConverter
    {
        private Bitmap imagen;
        private struct NuevaData
        {
            public Color color;
            public int x;
            public int y;

            public NuevaData(Color _color, int _x, int _y)
            {
                this.color = _color;
                this.x = _x;
                this.y = _y;
            }
        }
        public BitmapConverter(Bitmap _imagen)
        {
            this.imagen = _imagen;
        }
        public Bitmap FilterMedia()
        {
            //Poner mascara como parametro para el otro filtro
            List<byte> mascara = new List<byte>()
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            int div = 9;
            List<NuevaData> nuevosColores = new List<NuevaData>();

            if (this.imagen.Width >= 2 && this.imagen.Height >= 2)
            {
                //Se omiten los bordes en los dos ciclos
                for (int j = 1; j < this.imagen.Height - 1; j++)
                {
                    for (int i = 1; i < this.imagen.Width - 1; i++)
                    {
                        //Obtener valores de cada pixel
                        Color color1 = this.imagen.GetPixel(i, j);
                        Color color2 = this.imagen.GetPixel(i - 1, j);
                        Color color3 = this.imagen.GetPixel(i + 1, j);
                        Color color4 = this.imagen.GetPixel(i, j - 1);
                        Color color5 = this.imagen.GetPixel(i - 1, j - 1);
                        Color color6 = this.imagen.GetPixel(i + 1, j - 1);
                        Color color7 = this.imagen.GetPixel(i, j + 1);
                        Color color8 = this.imagen.GetPixel(i - 1, j + 1);
                        Color color9 = this.imagen.GetPixel(i + 1, j + 1);

                        //Multiplicar por mascara
                        /////////////////////////////////
                        //            Rojo             //
                        /////////////////////////////////
                        int rojo1 = color1.R * mascara[4];
                        int rojo2 = color2.R * mascara[3];
                        int rojo3 = color3.R * mascara[5];
                        int rojo4 = color4.R * mascara[1];
                        int rojo5 = color5.R * mascara[0];
                        int rojo6 = color6.R * mascara[2];
                        int rojo7 = color7.R * mascara[7];
                        int rojo8 = color8.R * mascara[6];
                        int rojo9 = color9.R * mascara[8];

                        /////////////////////////////////
                        //            Verde            //
                        /////////////////////////////////
                        int verde1 = color1.G * mascara[4];
                        int verde2 = color2.G * mascara[3];
                        int verde3 = color3.G * mascara[5];
                        int verde4 = color4.G * mascara[1];
                        int verde5 = color5.G * mascara[0];
                        int verde6 = color6.G * mascara[2];
                        int verde7 = color7.G * mascara[7];
                        int verde8 = color8.G * mascara[6];
                        int verde9 = color9.G * mascara[8];

                        /////////////////////////////////
                        //             Azul            //
                        /////////////////////////////////
                        int azul1 = color1.B * mascara[4];
                        int azul2 = color2.B * mascara[3];
                        int azul3 = color3.B * mascara[5];
                        int azul4 = color4.B * mascara[1];
                        int azul5 = color5.B * mascara[0];
                        int azul6 = color6.B * mascara[2];
                        int azul7 = color7.B * mascara[7];
                        int azul8 = color8.B * mascara[6];
                        int azul9 = color9.B * mascara[8];

                        //Sumar valores
                        /////////////////////////////////
                        //       Rojo, Verde, Azul     //
                        /////////////////////////////////
                        int sumaRojo = rojo1 + rojo2 + rojo3 + rojo4 + rojo5 + rojo6 + rojo7 + rojo8 + rojo9;
                        int sumaVerde = verde1 + verde2 + verde3 + verde4 + verde5 + verde6 + verde7 + verde8 + verde9;
                        int sumaAzul = azul1 + azul2 + azul3 + azul4 + azul5 + azul6 + azul7 + azul8 + azul9;

                        //Dividir entre div
                        /////////////////////////////////
                        //    Nuevo Rojo, Verde, Azul  //
                        /////////////////////////////////
                        int nuevoRojo = sumaRojo / div;
                        int nuevoVerde = sumaVerde / div;
                        int nuevoAzul = sumaAzul / div;

                        /////////////////////////////////
                        //   Añadir color a la lista   //
                        /////////////////////////////////
                        Color color = Color.FromArgb(nuevoRojo, nuevoVerde, nuevoAzul);
                        NuevaData nuevaData = new NuevaData(color, i, j);
                        nuevosColores.Add(nuevaData);
                    }
                }
            }

            foreach (NuevaData nuevaData in nuevosColores)
            {
                this.imagen.SetPixel(nuevaData.x, nuevaData.y, nuevaData.color);
            }

            return this.imagen;
        }
        public Bitmap FilterMediaPonderada(byte valorCentral)
        {
            //Poner mascara como parametro para el otro filtro
            List<byte> mascara = new List<byte>()
            { 1, 1, 1, 1, valorCentral, 1, 1, 1, 1 };
            int div = valorCentral + 8;
            List<NuevaData> nuevosColores = new List<NuevaData>();

            if (this.imagen.Width >= 2 && this.imagen.Height >= 2)
            {
                //Se omiten los bordes en los dos ciclos
                for (int j = 1; j < this.imagen.Height - 1; j++)
                {
                    for (int i = 1; i < this.imagen.Width - 1; i++)
                    {
                        //Obtener valores de cada pixel
                        Color color1 = this.imagen.GetPixel(i, j);
                        Color color2 = this.imagen.GetPixel(i - 1, j);
                        Color color3 = this.imagen.GetPixel(i + 1, j);
                        Color color4 = this.imagen.GetPixel(i, j - 1);
                        Color color5 = this.imagen.GetPixel(i - 1, j - 1);
                        Color color6 = this.imagen.GetPixel(i + 1, j - 1);
                        Color color7 = this.imagen.GetPixel(i, j + 1);
                        Color color8 = this.imagen.GetPixel(i - 1, j + 1);
                        Color color9 = this.imagen.GetPixel(i + 1, j + 1);

                        //Multiplicar por mascara
                        /////////////////////////////////
                        //            Rojo             //
                        /////////////////////////////////
                        int rojo1 = color1.R * mascara[4];
                        int rojo2 = color2.R * mascara[3];
                        int rojo3 = color3.R * mascara[5];
                        int rojo4 = color4.R * mascara[1];
                        int rojo5 = color5.R * mascara[0];
                        int rojo6 = color6.R * mascara[2];
                        int rojo7 = color7.R * mascara[7];
                        int rojo8 = color8.R * mascara[6];
                        int rojo9 = color9.R * mascara[8];

                        /////////////////////////////////
                        //            Verde            //
                        /////////////////////////////////
                        int verde1 = color1.G * mascara[4];
                        int verde2 = color2.G * mascara[3];
                        int verde3 = color3.G * mascara[5];
                        int verde4 = color4.G * mascara[1];
                        int verde5 = color5.G * mascara[0];
                        int verde6 = color6.G * mascara[2];
                        int verde7 = color7.G * mascara[7];
                        int verde8 = color8.G * mascara[6];
                        int verde9 = color9.G * mascara[8];

                        /////////////////////////////////
                        //             Azul            //
                        /////////////////////////////////
                        int azul1 = color1.B * mascara[4];
                        int azul2 = color2.B * mascara[3];
                        int azul3 = color3.B * mascara[5];
                        int azul4 = color4.B * mascara[1];
                        int azul5 = color5.B * mascara[0];
                        int azul6 = color6.B * mascara[2];
                        int azul7 = color7.B * mascara[7];
                        int azul8 = color8.B * mascara[6];
                        int azul9 = color9.B * mascara[8];

                        //Sumar valores
                        /////////////////////////////////
                        //       Rojo, Verde, Azul     //
                        /////////////////////////////////
                        int sumaRojo = rojo1 + rojo2 + rojo3 + rojo4 + rojo5 + rojo6 + rojo7 + rojo8 + rojo9;
                        int sumaVerde = verde1 + verde2 + verde3 + verde4 + verde5 + verde6 + verde7 + verde8 + verde9;
                        int sumaAzul = azul1 + azul2 + azul3 + azul4 + azul5 + azul6 + azul7 + azul8 + azul9;

                        //Dividir entre div
                        /////////////////////////////////
                        //    Nuevo Rojo, Verde, Azul  //
                        /////////////////////////////////
                        int nuevoRojo = sumaRojo / div;
                        int nuevoVerde = sumaVerde / div;
                        int nuevoAzul = sumaAzul / div;

                        /////////////////////////////////
                        //   Añadir color a la lista   //
                        /////////////////////////////////
                        //if (nuevoRojo > 255)
                        //    nuevoRojo = 255;
                        //if (nuevoVerde > 255)
                        //    nuevoVerde = 255;
                        //if (nuevoAzul > 255)
                        //    nuevoAzul = 255;

                        Color color = Color.FromArgb(nuevoRojo, nuevoVerde, nuevoAzul);
                        NuevaData nuevaData = new NuevaData(color, i, j);
                        nuevosColores.Add(nuevaData);
                    }
                }
            }

            foreach (NuevaData nuevaData in nuevosColores)
            {
                this.imagen.SetPixel(nuevaData.x, nuevaData.y, nuevaData.color);
            }

            return this.imagen;
        }
        public Bitmap FilterMediana()
        {
            List<NuevaData> nuevosColores = new List<NuevaData>();

            if (this.imagen.Width >= 2 && this.imagen.Height >= 2)
            {
                //Se omiten los bordes en los dos ciclos
                for (int j = 1; j < this.imagen.Height - 1; j++)
                {
                    for (int i = 1; i < this.imagen.Width - 1; i++)
                    {
                        //Obtener valores de cada pixel
                        Color color1 = this.imagen.GetPixel(i, j);
                        Color color2 = this.imagen.GetPixel(i - 1, j);
                        Color color3 = this.imagen.GetPixel(i + 1, j);
                        Color color4 = this.imagen.GetPixel(i, j - 1);
                        Color color5 = this.imagen.GetPixel(i - 1, j - 1);
                        Color color6 = this.imagen.GetPixel(i + 1, j - 1);
                        Color color7 = this.imagen.GetPixel(i, j + 1);
                        Color color8 = this.imagen.GetPixel(i - 1, j + 1);
                        Color color9 = this.imagen.GetPixel(i + 1, j + 1);

                        ///////////////////////////////////////////////////////
                        //   Sacar la mediana de los Rojos, Verdes y Azules  //
                        ///////////////////////////////////////////////////////
                        List<int> RojosFilter = new List<int>()
                        { color1.R, color2.R,color3.R,color4.R,color5.R,color6.R,color7.R,color8.R,color9.R };
                        List<int> VerdesFilter = new List<int>()
                        { color1.G, color2.G,color3.G,color4.G,color5.G,color6.G,color7.G,color8.G,color9.G };
                        List<int> AzulesFilter = new List<int>()
                        { color1.B, color2.B,color3.B,color4.B,color5.B,color6.B,color7.B,color8.B,color9.B };

                        ///////////////////////////////////////////////////////
                        //   Ordenar de pequeño a mas grande                 //
                        ///////////////////////////////////////////////////////
                        RojosFilter.Sort();
                        VerdesFilter.Sort();
                        AzulesFilter.Sort();

                        ///////////////////////////////////////////////////////
                        //          Sacar mediana y asignar valor            //
                        ///////////////////////////////////////////////////////
                        int nuevoRojo = RojosFilter[4];
                        int nuevoVerde = VerdesFilter[4];
                        int nuevoAzul = AzulesFilter[4];

                        Color color = Color.FromArgb(nuevoRojo, nuevoVerde, nuevoAzul);
                        NuevaData nuevaData = new NuevaData(color, i, j);
                        nuevosColores.Add(nuevaData);
                    }
                }
            }

            foreach (NuevaData nuevaData in nuevosColores)
            {
                this.imagen.SetPixel(nuevaData.x, nuevaData.y, nuevaData.color);
            }

            return this.imagen;
        }
    }
}
