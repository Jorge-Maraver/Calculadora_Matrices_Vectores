using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Plano
    {
        public Punto punto;
        public Vector vectorDirector1;
        public Vector vectorDirector2;

        public Vector vectorNormal;
        public float terminoIndependiente;

        float[] arrayPunto = new float[3];
        float[] arrayVectorDirector1 = new float[3];
        float[] arrayVectorDirector2 = new float[3];

        float[] vectorNormalArray = new float[3];

        public Plano(bool formaGeneral)
        {
            if (formaGeneral)
            {

                Console.WriteLine("\n\tIntroduzca el valor\n\tDe X:");
                vectorNormalArray[0] = LeerPorPantallaFloat();
                Console.WriteLine("\n\tDe Y:");
                vectorNormalArray[1] = LeerPorPantallaFloat();
                Console.WriteLine("\n\tDe Z:");
                vectorNormalArray[2] = LeerPorPantallaFloat();
                Console.WriteLine("\n\tDel término independiente:");
                terminoIndependiente = LeerPorPantallaFloat();

                vectorNormal = new Vector(vectorNormalArray);

                Console.WriteLine("\n\n\tEl plano es el siguiente:");
                Console.Write("\n\t" + vectorNormal.coordenadas[0] + "x + " + vectorNormal.coordenadas[1] + "y + " + vectorNormal.coordenadas[2] + "z + " + terminoIndependiente + " = 0");
                Console.Write("\n");
            }
            else
            {
                Console.WriteLine("\n\tIntroduzca los valores de los términos independientes/coordenadas del punto contenido en el plano:\n\tEn X:");
                arrayPunto[0] = LeerPorPantallaFloat();
                Console.WriteLine("\n\tEn Y:");
                arrayPunto[1] = LeerPorPantallaFloat();
                Console.WriteLine("\n\tEn Z:");
                arrayPunto[2] = LeerPorPantallaFloat();

                Console.WriteLine("\n\n\tIntroduzca los valores de landa/coordenadas del primer vector director:\n\tEn X:");
                arrayVectorDirector1[0] = LeerPorPantallaFloat();
                Console.WriteLine("\n\tEn Y:");
                arrayVectorDirector1[1] = LeerPorPantallaFloat();
                Console.WriteLine("\n\tEn Z:");
                arrayVectorDirector1[2] = LeerPorPantallaFloat();

                Console.WriteLine("\n\n\tIntroduzca los valores de landa/coordenadas del segundo vector director:\n\tEn X:");
                arrayVectorDirector2[0] = LeerPorPantallaFloat();
                Console.WriteLine("\n\tEn Y:");
                arrayVectorDirector2[1] = LeerPorPantallaFloat();
                Console.WriteLine("\n\tEn Z:");
                arrayVectorDirector2[2] = LeerPorPantallaFloat();

                punto = new Punto(arrayPunto);
                vectorDirector1 = new Vector(arrayVectorDirector1);
                vectorDirector2 = new Vector(arrayVectorDirector2);
            }
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
