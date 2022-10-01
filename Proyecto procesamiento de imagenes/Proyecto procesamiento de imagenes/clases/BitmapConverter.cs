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
        public Bitmap FilterMaximo(int radioKernel)
        {
            int sizeKernel = (2 * radioKernel + 1);
            NuevaData[,] nuevosPixeles = new NuevaData[this.imagen.Width, this.imagen.Height];
            if (this.imagen.Width >= sizeKernel && this.imagen.Height >= sizeKernel && radioKernel >= 0)
            {
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
                        int pixelRojo = kernelRojo[kernelRojo.Count - 1];
                        int pixelVerde = kernelVerde[kernelVerde.Count - 1];
                        int pixelAzul = kernelAzul[kernelAzul.Count - 1];
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
        public Bitmap FilterMinimo(int radioKernel)
        {
            int sizeKernel = (2 * radioKernel + 1);
            NuevaData[,] nuevosPixeles = new NuevaData[this.imagen.Width, this.imagen.Height];
            if (this.imagen.Width >= sizeKernel && this.imagen.Height >= sizeKernel && radioKernel >= 0)
            {
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
                        int pixelRojo = kernelRojo[0];
                        int pixelVerde = kernelVerde[0];
                        int pixelAzul = kernelAzul[0];
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
    }
}