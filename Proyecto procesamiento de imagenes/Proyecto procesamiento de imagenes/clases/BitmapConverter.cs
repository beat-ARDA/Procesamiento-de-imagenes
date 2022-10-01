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
        public Bitmap FilterMedia(int radioKernel)
        {
            int sizeKernel = (2 * radioKernel + 1);
            NuevaData[,] nuevosPixeles = new NuevaData[this.imagen.Width, this.imagen.Height];
            if (this.imagen.Width >= sizeKernel && this.imagen.Height >= sizeKernel && radioKernel >= 0)
            {
                /*Tamaño y creacion de kernel, definicion div*/
                Color[,] colores = new Color[sizeKernel, sizeKernel];
                int[,] kernel = new int[sizeKernel, sizeKernel];
                int[,] pixelesRojos = new int[sizeKernel, sizeKernel];
                int[,] pixelesVerdes = new int[sizeKernel, sizeKernel];
                int[,] pixelesAzules = new int[sizeKernel, sizeKernel];
                int div = sizeKernel * sizeKernel;
                /*Asignar elementos al kernel*/
                for (int j = 0; j < sizeKernel; j++)
                    for (int i = 0; i < sizeKernel; i++)
                        kernel[i, j] = 1;

                //Se omiten los bordes en los dos ciclos
                for (int j = radioKernel; j < this.imagen.Height - radioKernel; j++)
                {
                    for (int i = radioKernel; i < this.imagen.Width - radioKernel; i++)
                    {
                        //Obtener valores de cada pixel
                        int xPixel = i - radioKernel;
                        int yPixel = j - radioKernel;
                        for (int y = 0; y < sizeKernel; y++)
                            for (int x = 0; x < sizeKernel; x++)
                                colores[x, y] = this.imagen.GetPixel(xPixel + x, yPixel + y);

                        //Multiplicar por mascara
                        /////////////////////////////////
                        //      Rojo, Verde, Azul      //
                        /////////////////////////////////
                        for (int y = 0; y < sizeKernel; y++)
                            for (int x = 0; x < sizeKernel; x++)
                            {
                                pixelesRojos[x, y] = colores[x, y].R * kernel[x, y];
                                pixelesVerdes[x, y] = colores[x, y].G * kernel[x, y];
                                pixelesAzules[x, y] = colores[x, y].B * kernel[x, y];
                            }

                        //Sumar valores
                        /////////////////////////////////
                        //       Rojo, Verde, Azul     //
                        /////////////////////////////////
                        int sumaRojo = 0;
                        int sumaVerde = 0;
                        int sumaAzul = 0;
                        for (int y = 0; y < sizeKernel; y++)
                            for (int x = 0; x < sizeKernel; x++)
                            {
                                sumaRojo += pixelesRojos[x, y];
                                sumaVerde += pixelesVerdes[x, y];
                                sumaAzul += pixelesAzules[x, y];
                            }

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
                        nuevosPixeles[i, j] = nuevaData;

                        //this.imagen.SetPixel(nuevaData.x, nuevaData.y, nuevaData.color);
                    }
                }
            }

            for (int j = radioKernel; j < this.imagen.Height - radioKernel; j++)
                for (int i = radioKernel; i < this.imagen.Width - radioKernel; i++)
                    this.imagen.SetPixel(nuevosPixeles[i, j].x, nuevosPixeles[i, j].y, nuevosPixeles[i, j].color);

            return this.imagen;
        }
        public Bitmap FilterMediana(int radioKernel)
        {
            int sizeKernel = (2 * radioKernel + 1);
            NuevaData[,] nuevosPixeles = new NuevaData[this.imagen.Width, this.imagen.Height];
            if (this.imagen.Width >= sizeKernel && this.imagen.Height >= sizeKernel && radioKernel >= 0)
            {
                /*Tamaño y creacion de kernel, definicion div*/
                int valorCentralKernel = (((sizeKernel * sizeKernel) - 1) / 2);
                //Se omiten los bordes en los dos ciclos
                for (int j = radioKernel; j < this.imagen.Height - radioKernel; j++)
                {
                    for (int i = radioKernel; i < this.imagen.Width - radioKernel; i++)
                    {
                        //Obtener valores de cada pixel
                        List<int> kernelRojo = new List<int>();
                        List<int> kernelVerde = new List<int>();
                        List<int> kernelAzul = new List<int>();
                        int xPixel = i - radioKernel;
                        int yPixel = j - radioKernel;
                        for (int y = 0; y < sizeKernel; y++)
                            for (int x = 0; x < sizeKernel; x++)
                            {
                                kernelRojo.Add(this.imagen.GetPixel(xPixel + x, yPixel + y).R);
                                kernelVerde.Add(this.imagen.GetPixel(xPixel + x, yPixel + y).G);
                                kernelAzul.Add(this.imagen.GetPixel(xPixel + x, yPixel + y).B);
                            }

                        //Ordenar valores y sacar mediana
                        kernelRojo.Sort();
                        kernelVerde.Sort();
                        kernelAzul.Sort();
                        int pixelRojo = kernelRojo[valorCentralKernel];
                        int pixelVerde = kernelVerde[valorCentralKernel];
                        int pixelAzul = kernelAzul[valorCentralKernel];
                        kernelRojo.Clear();
                        kernelVerde.Clear();
                        kernelAzul.Clear();

                        /////////////////////////////////
                        //   Añadir color a la lista   //
                        /////////////////////////////////
                        Color color = Color.FromArgb(pixelRojo, pixelVerde, pixelAzul);
                        NuevaData nuevaData = new NuevaData(color, i, j);
                        nuevosPixeles[i, j] = nuevaData;

                        //this.imagen.SetPixel(nuevaData.x, nuevaData.y, nuevaData.color);
                    }
                }
            }

            for (int j = radioKernel; j < this.imagen.Height - radioKernel; j++)
                for (int i = radioKernel; i < this.imagen.Width - radioKernel; i++)
                    this.imagen.SetPixel(nuevosPixeles[i, j].x, nuevosPixeles[i, j].y, nuevosPixeles[i, j].color);

            return this.imagen;
        }
        public Bitmap FilterMediaPonderada(int radioKernel = 0, int valorCentral = 0)
        {
            int sizeKernel = (2 * radioKernel + 1);
            NuevaData[,] nuevosPixeles = new NuevaData[this.imagen.Width, this.imagen.Height];
            if (this.imagen.Width >= sizeKernel && this.imagen.Height >= sizeKernel && radioKernel >= 0)
            {
                int valorCentralKernel = (((sizeKernel * sizeKernel) - 1) / 2);
                /*Tamaño y creacion de kernel, definicion div*/
                Color[,] colores = new Color[sizeKernel, sizeKernel];
                int[,] kernel = new int[sizeKernel, sizeKernel];
                int[,] pixelesRojos = new int[sizeKernel, sizeKernel];
                int[,] pixelesVerdes = new int[sizeKernel, sizeKernel];
                int[,] pixelesAzules = new int[sizeKernel, sizeKernel];
                int div = ((sizeKernel * sizeKernel) + (valorCentral - 1));
                /*Asignar elementos al kernel*/
                int incrementalCentral = 0;
                for (int j = 0; j < sizeKernel; j++)
                    for (int i = 0; i < sizeKernel; i++)
                    {
                        if (incrementalCentral == valorCentralKernel)
                            kernel[i, j] = valorCentral;
                        else
                            kernel[i, j] = 1;
                        incrementalCentral++;
                    }
                //Se omiten los bordes en los dos ciclos
                for (int j = radioKernel; j < this.imagen.Height - radioKernel; j++)
                {
                    for (int i = radioKernel; i < this.imagen.Width - radioKernel; i++)
                    {
                        //Obtener valores de cada pixel
                        int xPixel = i - radioKernel;
                        int yPixel = j - radioKernel;
                        for (int y = 0; y < sizeKernel; y++)
                            for (int x = 0; x < sizeKernel; x++)
                                colores[x, y] = this.imagen.GetPixel(xPixel + x, yPixel + y);

                        //Multiplicar por mascara
                        /////////////////////////////////
                        //      Rojo, Verde, Azul      //
                        /////////////////////////////////
                        for (int y = 0; y < sizeKernel; y++)
                            for (int x = 0; x < sizeKernel; x++)
                            {
                                pixelesRojos[x, y] = colores[x, y].R * kernel[x, y];
                                pixelesVerdes[x, y] = colores[x, y].G * kernel[x, y];
                                pixelesAzules[x, y] = colores[x, y].B * kernel[x, y];
                            }

                        //Sumar valores
                        /////////////////////////////////
                        //       Rojo, Verde, Azul     //
                        /////////////////////////////////
                        int sumaRojo = 0;
                        int sumaVerde = 0;
                        int sumaAzul = 0;
                        for (int y = 0; y < sizeKernel; y++)
                            for (int x = 0; x < sizeKernel; x++)
                            {
                                sumaRojo += pixelesRojos[x, y];
                                sumaVerde += pixelesVerdes[x, y];
                                sumaAzul += pixelesAzules[x, y];
                            }

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
                        nuevosPixeles[i, j] = nuevaData;

                        //this.imagen.SetPixel(nuevaData.x, nuevaData.y, nuevaData.color);
                    }
                }
            }

            for (int j = radioKernel; j < this.imagen.Height - radioKernel; j++)
                for (int i = radioKernel; i < this.imagen.Width - radioKernel; i++)
                    this.imagen.SetPixel(nuevosPixeles[i, j].x, nuevosPixeles[i, j].y, nuevosPixeles[i, j].color);

            return this.imagen;
        }
        public Bitmap FilterGaussiano(double _sigma, int _W)
        {
            //1, //5
            double sigma = _sigma;
            int W = _W;
            double[,] kernel = new double[W, W];
            double mean = W / 2;
            double sum = 0.0;
            for (int x = 0; x < W; ++x)
                for (int y = 0; y < W; ++y)
                {
                    kernel[x, y] = Math.Exp(-0.5 * (Math.Pow((x - mean) / sigma, 2.0) + Math.Pow((y - mean) / sigma, 2.0)))
                        / (2 * 3.1416 * sigma * sigma);

                    sum += kernel[x, y];
                }

            for (int x = 0; x < W; ++x)
                for (int y = 0; y < W; ++y)
                    kernel[x, y] /= sum;

            //Poner mascara como parametro para el otro filtro
            List<int> mascara = new List<int>();
            //{ 1, 2, 1, 2, 8, 2, 1, 2, 1 };
            int div = 0;
            foreach (double kernelDato in kernel)
            {
                div += Convert.ToInt32(kernelDato * 255.0);
                mascara.Add(Convert.ToInt32(kernelDato * 255.0));
            }

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
                        //Color color = Color.FromArgb((int)sumaRojo, (int)sumaVerde, (int)sumaAzul);
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