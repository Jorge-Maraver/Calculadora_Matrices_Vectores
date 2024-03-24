using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Matriz
    {
        public int cantFilas;
        public int cantColumnas;

        public float[,] matriz;

        public Matriz()
        {
            Console.Write("\n\tNúmero de filas: ");
            cantFilas = LeerPorPantallaInt();

            Console.Write("\n\tNúmero de columnas: ");
            cantColumnas = LeerPorPantallaInt();

            matriz = new float[cantFilas, cantColumnas];
            Console.Write("\n");

            for (int i = 0; i < cantFilas; i++)
            {
                for (int e = 0; e < cantColumnas; e++)
                {
                    Console.Write("\tFila " + i + "; Columna " + e + ": ");
                    matriz[i, e] = LeerPorPantallaFloat();
                }
                Console.Write("\n");
            }

            Console.WriteLine("\n\tLa matriz es la siguiente:\n");

            for (int i = 0; i < cantFilas; i++)
            {
                Console.Write("\t");
                Console.Write("| ");
                for (int e = 0; e < cantColumnas; e++)
                {
                    Console.Write(matriz[i, e]);
                    Console.Write(" | ");
                }
                Console.Write("\n");
            }

            Console.Write("\n");
        }

        public Matriz(int cantColumnasF, int cantFilasF, float[,] matrizF)
        {
            cantFilas = cantFilasF;

            cantColumnas = cantColumnasF;

            matriz = new float[cantFilas, cantColumnas];

            for (int i = 0; i < cantFilas; i++)
            {
                for (int e = 0; e < cantColumnas; e++)
                {
                    matriz[i, e] = matrizF[i, e];
                }
            }
        }

        public float[,] Transpuesta()
        {
            float[,] transpuesta = new float[cantColumnas, cantFilas];

            for (int i = 0; i < cantColumnas; i++)
            {
                for (int e = 0; e < cantFilas; e++)
                {
                    transpuesta[i, e] = matriz[e, i];
                }
            }

            Console.WriteLine("\n\n\tSu matriz transpuesta es la siguiente:\n\n");

            for (int i = 0; i < cantColumnas; i++)
            {
                Console.Write("\t");
                Console.Write("| ");
                for (int e = 0; e < cantFilas; e++)
                {
                    Console.Write(transpuesta[i, e]);
                    Console.Write(" | ");
                }
                Console.Write("\n");
            }

            return transpuesta;
        }

        public float[,] Adjunta()
        {
            float[,] adjunta = new float[cantFilas, cantColumnas];
            float[,] temporal = new float[cantFilas - 1, cantColumnas - 1];

            for (int i = 0; i < cantFilas; i++)
            {
                for (int e = 0; e < cantColumnas; e++)
                {
                    int filaTemp;
                    int columTemp;

                    for (int o = 0; o < cantFilas - 1; o++)
                    {
                        for (int a = 0; a < cantColumnas - 1; a++)
                        {
                            if (o < i)
                            {
                                filaTemp = o;
                            }
                            else
                            {
                                filaTemp = o + 1;
                            }
                            if (a < e)
                            {
                                columTemp = a;
                            }
                            else
                            {
                                columTemp = a + 1;
                            }
                            temporal[o, a] = matriz[filaTemp, columTemp];
                        }
                    }

                    if ((e + i) % 2 == 0)
                    {
                        adjunta[i, e] = Determinante2x2(temporal);
                    }
                    else
                    {
                        adjunta[i, e] = -Determinante2x2(temporal);
                    }
                }
            }

            Console.WriteLine("\tSu matriz adjunta es la siguiente\n\n");

            for (int i = 0; i < cantColumnas; i++)
            {
                Console.Write("\t");
                Console.Write("| ");
                for (int e = 0; e < cantFilas; e++)
                {
                    Console.Write(adjunta[i, e]);
                    Console.Write(" | ");
                }
                Console.Write("\n");
            }

            return adjunta;
        }

        public float Determinante3x3()
        {
            if (cantFilas == cantColumnas)
            {
                float determinante = 0;
                float contenedor = 1;

                for (int i = 0; i < cantFilas; i++)
                {
                    int a = i;
                    int e = 0;
                    for (int o = 0; o < cantColumnas; o++)
                    {
                        if (a >= cantFilas)
                        {
                            a = 0;
                        }
                        contenedor *= matriz[a, e];
                        e++;
                        a++;
                    }
                    determinante += contenedor;
                    contenedor = 1;
                }

                for (int i = cantFilas; i > 0; i--)
                {
                    int a = i - 1;
                    int e = 0;
                    for (int o = 0; o < cantColumnas; o++)
                    {
                        if (a < 0)
                        {
                            a = cantFilas - 1;
                        }
                        contenedor *= matriz[a, e];
                        e++;
                        a--;
                    }
                    determinante -= contenedor;
                    contenedor = 1;
                }

                return determinante;

            }
            else
            {
                return -100000;
            }
        }

        public float Determinante2x2(float[,] M)
        {
            float determinante = M[0, 0] * M[1, 1] - M[0, 1] * M[1, 0];

            return determinante;
        }

        public float Determinante2x2()
        {
            float determinante = matriz[0, 0] * matriz[1, 1] - matriz[0, 1] * matriz[1, 0];

            return determinante;
        }

        public float[,] Suma(Matriz M)
        {
            float[,] devolver = new float[cantFilas, cantColumnas];
            for (int i = 0; i < cantFilas; i++)
            {
                for (int e = 0; e < cantColumnas; e++)
                {
                    devolver[i, e] = matriz[i, e] + M.matriz[i, e];
                }
            }

            return devolver;
        }

        public float[,] Multiplicacion(Matriz M)
        {
            float[,] devolver = new float[cantFilas, M.cantColumnas];
            float contenedor = 0;

            for (int i = 0; i < cantFilas; i++)
            {
                for (int e = 0; e < M.cantColumnas; e++)
                {
                    for (int o = 0; o < cantColumnas; o++)
                    {

                        contenedor += matriz[i, o] * M.matriz[o, e];
                    }
                    devolver[i, e] = contenedor;
                    contenedor = 0;
                }
            }

            return devolver;
        }

        static float LeerPorPantallaFloat()
        {
            Console.Write("\t");
            string lectura = Console.ReadLine();
            bool esValido = false;
            float num = 0;

            bool primeraIteracion = true;
            while (!esValido)
            {
                if (primeraIteracion)
                {
                    primeraIteracion = false;
                }
                else
                {
                    Console.WriteLine("El dato introducido no es válido, vuelva a escribirlo. Recuerde que debe ser un número.");
                    Console.Write("\t");
                    lectura = Console.ReadLine();
                }
                esValido = Single.TryParse(lectura, out num);
            }

            return num;
        }
        static int LeerPorPantallaInt()
        {
            return Convert.ToInt32(LeerPorPantallaFloat());
        }
    }
}
