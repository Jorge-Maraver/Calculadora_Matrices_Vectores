using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Punto
    {
        public float[] coordenadas = new float[3];

        public Punto()
        {
            Console.WriteLine("\n\tIntroduzca el valor de la coordenada del punto\n\tEn X:");
            coordenadas[0] = LeerPorPantallaFloat();
            Console.WriteLine("\n\tEn Y:");
            coordenadas[1] = LeerPorPantallaFloat();
            Console.WriteLine("\n\tEn Z:");
            coordenadas[2] = LeerPorPantallaFloat();
        }

        public Punto(float[] coord)
        {
            coordenadas[0] = coord[0];
            coordenadas[1] = coord[1];
            coordenadas[2] = coord[2];
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
