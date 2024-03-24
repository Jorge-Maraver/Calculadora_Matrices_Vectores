using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class SistemaDeEcuaciones3Incognitas
    {
        public int cantFilas;
        public int cantColumnas;

        public float[,] matrizAmpliadaArray;
        public float[,] matrizCoeficientesArray;
        public float[,] matrizTerminosIndependientesArray;

        public Matriz matrizAmpliada;
        public Matriz matrizCoeficientes;
        public Matriz matrizTerminosIndependientes;

        public SistemaDeEcuaciones3Incognitas()
        {
            cantFilas = 3;
            cantColumnas = 4;

            char variable = 'A';

            matrizAmpliadaArray = new float[cantFilas, cantColumnas];
            matrizCoeficientesArray = new float[cantFilas, cantColumnas - 1];
            matrizTerminosIndependientesArray = new float[cantFilas, 1];
            Console.Write("\n");

            for (int i = 0; i < cantFilas; i++)
            {
                for (int e = 0; e < cantColumnas; e++)
                {
                    switch (e)
                    {
                        case 0:
                            variable = 'x';
                            break;
                        case 1:
                            variable = 'y';
                            break;
                        case 2:
                            variable = 'z';
                            break;
                        case 3:
                            variable = ' ';
                            break;
                        default:
                            Console.WriteLine("ERROR");
                            break;
                    }
                    if (variable == ' ')
                    {
                        Console.Write("\tTérmino independiente de la ecuación " + (i + 1) + ": ");
                        matrizAmpliadaArray[i, e] = LeerPorPantallaFloat();
                        matrizTerminosIndependientesArray[i, 0] = matrizAmpliadaArray[i, e];
                    }
                    else
                    {
                        Console.Write("\tVariable " + variable + " de la ecuación " + (i + 1) + ": ");
                        matrizAmpliadaArray[i, e] = LeerPorPantallaFloat();
                        matrizCoeficientesArray[i, e] = matrizAmpliadaArray[i, e];
                    }
                }
                Console.Write("\n");
            }

            Console.WriteLine("\n\tEl sistema es el siguiente:\n");

            for (int i = 0; i < cantFilas; i++)
            {
                Console.Write("\t");
                for (int e = 0; e < cantColumnas; e++)
                {
                    switch (e)
                    {
                        case 0:
                            variable = 'x';
                            break;
                        case 1:
                            variable = 'y';
                            break;
                        case 2:
                            variable = 'z';
                            break;
                        case 3:
                            variable = ' ';
                            break;
                        default:
                            Console.WriteLine("ERROR");
                            break;
                    }
                    if (variable == ' ')
                    {
                        Console.Write("=  ");
                    }
                    Console.Write(matrizAmpliadaArray[i, e] /*+ variable + "  "*/);
                    Console.Write(variable + "  ");
                }
                Console.Write("\n");
            }

            Console.Write("\n"); Console.WriteLine("\n\tEl sistema de coeficientes es el siguiente:\n");

            for (int i = 0; i < cantFilas; i++)
            {
                Console.Write("\t");
                for (int e = 0; e < cantColumnas - 1; e++)
                {
                    switch (e)
                    {
                        case 0:
                            variable = 'x';
                            break;
                        case 1:
                            variable = 'y';
                            break;
                        case 2:
                            variable = 'z';
                            break;
                        default:
                            Console.WriteLine("ERROR");
                            break;
                    }
                    if (variable == ' ')
                    {
                        Console.Write("=  ");
                    }
                    Console.Write(matrizAmpliadaArray[i, e] /*+ variable + "  "*/);
                    Console.Write(variable + "  ");
                }
                Console.Write("\n");
            }

            Console.Write("\n"); Console.WriteLine("\n\tEl sistema de T.I. es el siguiente:\n");

            for (int i = 0; i < cantFilas; i++)
            {
                Console.Write("\t");
                for (int e = 0; e < 1; e++)
                {
                    Console.Write(matrizAmpliadaArray[i, e] /*+ variable + "  "*/);
                    Console.Write(variable + "  ");
                }
                Console.Write("\n");
            }

            Console.Write("\n");

            MatricesAsociadas();
        }

        public void MatricesAsociadas()
        {
            matrizAmpliada = new Matriz(cantColumnas, cantFilas, matrizAmpliadaArray);
            matrizCoeficientes = new Matriz(cantColumnas - 1, cantFilas, matrizCoeficientesArray);
            matrizTerminosIndependientes = new Matriz(1, cantFilas, matrizTerminosIndependientesArray);
        }

        public float HallarX()
        {
            float X;

            float detMatrizCoeficientes = matrizCoeficientes.Determinante3x3();
            Matriz matrizX = new Matriz(matrizCoeficientes.cantColumnas, matrizCoeficientes.cantFilas, matrizCoeficientes.matriz);


            for (int i = 0; i < cantFilas; i++)
            {
                matrizX.matriz[i, 0] = matrizTerminosIndependientes.matriz[i, 0];
            }

            float detMatrizX = matrizX.Determinante3x3();

            X = detMatrizX / detMatrizCoeficientes;

            return X;
        }

        public float HallarY()
        {
            float Y;

            float detMatrizCoeficientes = matrizCoeficientes.Determinante3x3();
            Matriz matrizY = new Matriz(matrizCoeficientes.cantColumnas, matrizCoeficientes.cantFilas, matrizCoeficientes.matriz);


            for (int i = 0; i < cantFilas; i++)
            {
                matrizY.matriz[i, 1] = matrizTerminosIndependientes.matriz[i, 0];
            }

            float detMatrizY = matrizY.Determinante3x3();

            Y = detMatrizY / detMatrizCoeficientes;

            return Y;
        }

        public float HallarZ()
        {
            float Z;

            float detMatrizCoeficientes = matrizCoeficientes.Determinante3x3();
            Matriz matrizZ = new Matriz(matrizCoeficientes.cantColumnas, matrizCoeficientes.cantFilas, matrizCoeficientes.matriz);


            for (int i = 0; i < cantFilas; i++)
            {
                matrizZ.matriz[i, 2] = matrizTerminosIndependientes.matriz[i, 0];
            }

            float detMatrizZ = matrizZ.Determinante3x3();

            Z = detMatrizZ / detMatrizCoeficientes;

            return Z;
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
