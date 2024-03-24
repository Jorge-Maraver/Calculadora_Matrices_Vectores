using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Recta
    {
        public Punto punto;
        public Vector vectorDirector;

        float[] arrayPunto = new float[3];
        float[] arrayVectorDirector = new float[3];

        public Recta()
        {
            Console.WriteLine("\n\tIntroduzca los valores de los términos independientes/coordenadas del punto contenido en la recta:\n\tEn X:");
            arrayPunto[0] = LeerPorPantallaFloat();
            Console.WriteLine("\n\tEn Y:");
            arrayPunto[1] = LeerPorPantallaFloat();
            Console.WriteLine("\n\tEn Z:");
            arrayPunto[2] = LeerPorPantallaFloat();

            Console.WriteLine("\n\n\tIntroduzca los valores de landa/coordenadas del vector director:\n\tEn X:");
            arrayVectorDirector[0] = LeerPorPantallaFloat();
            Console.WriteLine("\n\tEn Y:");
            arrayVectorDirector[1] = LeerPorPantallaFloat();
            Console.WriteLine("\n\tEn Z:");
            arrayVectorDirector[2] = LeerPorPantallaFloat();

            punto = new Punto(arrayPunto);
            vectorDirector = new Vector(arrayVectorDirector);




            Console.WriteLine("\n\n\tLa recta es la siguiente:");

            for (int i = 0; i < punto.coordenadas.Length; i++)
            {
                Console.Write("\n\tX = " + punto.coordenadas[i] + " + " + vectorDirector.coordenadas[i] + "#");
            }
            Console.Write("\n");
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
