using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Vector
    {
        public float[] coordenadas = new float[3];

        public Vector()
        {
            Console.WriteLine("\n\tIntroduzca el valor del vector\n\tEn X:");
            coordenadas[0] = LeerPorPantallaFloat();
            Console.WriteLine("\n\tEn Y:");
            coordenadas[1] = LeerPorPantallaFloat();
            Console.WriteLine("\n\tEn Z:");
            coordenadas[2] = LeerPorPantallaFloat();
        }

        public Vector(Punto primerPunto, Punto segundoPunto)
        {
            for (int i = 0; i < coordenadas.Length; i++)
            {
                coordenadas[i] = segundoPunto.coordenadas[i] - primerPunto.coordenadas[i];
            }
        }

        public Vector(float[] coord)
        {
            coordenadas[0] = coord[0];
            coordenadas[1] = coord[1];
            coordenadas[2] = coord[2];
        }

        public float ProductoVectorial(Vector multVector)
        {
            float producto = 0;

            for (int i = 0; i < coordenadas.Length; i++)
            {
                producto += coordenadas[i] * multVector.coordenadas[i];
            }

            return producto;
        }

        public Vector ProductoEscalar(Vector multVector)
        {
            float[,] matrizIArray = new float[2, 2];
            matrizIArray[0, 0] = coordenadas[1];
            matrizIArray[0, 1] = coordenadas[2];
            matrizIArray[1, 0] = multVector.coordenadas[1];
            matrizIArray[1, 1] = multVector.coordenadas[2];

            float[,] matrizJArray = new float[2, 2];
            matrizJArray[0, 0] = coordenadas[0];
            matrizJArray[0, 1] = coordenadas[2];
            matrizJArray[1, 0] = multVector.coordenadas[0];
            matrizJArray[1, 1] = multVector.coordenadas[2];

            float[,] matrizKArray = new float[2, 2];
            matrizKArray[0, 0] = coordenadas[0];
            matrizKArray[0, 1] = coordenadas[1];
            matrizKArray[1, 0] = multVector.coordenadas[0];
            matrizKArray[1, 1] = multVector.coordenadas[1];

            Matriz matrizI = new Matriz(2, 2, matrizIArray);
            Matriz matrizJ = new Matriz(2, 2, matrizJArray);
            Matriz matrizK = new Matriz(2, 2, matrizKArray);

            float[] vectorProductoArray = { matrizI.Determinante2x2(), matrizJ.Determinante2x2(), matrizK.Determinante2x2() };

            Vector vectorProducto = new Vector(vectorProductoArray);

            return vectorProducto;
        }

        public float ProductoMixto(Vector multVectorVect1, Vector multVectorVect2)
        {
            Vector productoVectorial = multVectorVect1.ProductoEscalar(multVectorVect2);

            float producto = ProductoVectorial(productoVectorial);

            return producto;
        }

        public float Modulo()
        {
            float modulo = Convert.ToSingle(Math.Sqrt(coordenadas[0] * coordenadas[0] + coordenadas[1] * coordenadas[1] + coordenadas[2] * coordenadas[2]));

            return modulo;
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
