using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Matriz[] matrices = new Matriz[100];
            Punto[] puntos = new Punto[100];
            Vector[] vectores = new Vector[100];
            Recta[] rectas = new Recta[100];
            Plano[] planos = new Plano[100];
            SistemaDeEcuaciones3Incognitas Sistema;
            Punto punto;
            Recta recta;
            Plano plano;

            bool salir = false;

            int opcion;
            int posMatriz;
            int posMatriz1;
            int posMatriz2;
            int posVector1;
            int posVector2;

            while (!salir)
            {
                Console.WriteLine("\n\t¿Qué quieres hacer?\n\n\tMatrices y determinantes\n\t\t1.Crear matriz\n\t\t2.Determinante\n\t\t3.Sumar" +
                    "\n\t\t4.Multiplicar\n\t\t5.Inversa\n\tSistemas de ecuaciones\n\t\t6.Resolutor de SCD de 3 incógnitas" +
                    "\n\tÁlgebra vectorial\n\t\t7.Declarar un vector\n\t\t8.Producto vectorial" +
                    "\n\t\t9.Producto escalar\n\tGeometría analítica\n\t\t10.Distancia entre una recta y un plano\n\t\t11.Distancia entre un punto y un plano");

                opcion = LeerPorPantallaInt();

                float det;

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("\n\t¿Cuál quieres hacer?");
                        posMatriz = LeerPorPantallaInt();

                        if (posMatriz < matrices.Length && posMatriz >= 0)
                        {
                            matrices[posMatriz] = new Matriz();
                        }
                        else
                        {
                            Console.WriteLine("\n\tHay 99 disponibles, la posición no puede ser mayor");
                        }

                        break;

                    case 2:
                        Console.WriteLine("\n\t¿Cuál quieres hacer?");
                        posMatriz = LeerPorPantallaInt();

                        if (matrices[posMatriz] == null)
                        {
                            Console.WriteLine("\n\tLa matriz no ha sido creada");
                        }
                        else
                        {
                            if(matrices[posMatriz].cantFilas != matrices[posMatriz].cantColumnas)
                            {
                                Console.WriteLine("\n\tLa matriz no es cuadrada");
                                det = -100001;
                            }
                            else if (matrices[posMatriz].cantFilas == 1)
                            {
                                det = matrices[posMatriz].matriz[0, 0];
                            }
                            else if (matrices[posMatriz].cantFilas == 2)
                            {
                                det = matrices[posMatriz].Determinante2x2();
                            }
                            else if (matrices[posMatriz].cantFilas == 3)
                            {
                                det = matrices[posMatriz].Determinante3x3();
                            }
                            else
                            {
                                Console.WriteLine("\n\tLa matriz es demasiado grande");
                                det = -100001;
                            }


                            if (det > -100000)
                            {
                                Console.WriteLine("\n\tDeterminante: " + det);
                            }
                            else
                            {
                                Console.WriteLine("\n\tNo se puede");
                            }
                        }
                        break;

                    case 3:
                        Console.WriteLine("\n\t¿Cuáles quieres hacer?");
                        posMatriz1 = LeerPorPantallaInt();
                        posMatriz2 = LeerPorPantallaInt();

                        if (matrices[posMatriz1] == null || matrices[posMatriz2] == null)
                        {
                            Console.WriteLine("\n\tAlguna de las matrices no ha sido creada");
                        }
                        else
                        {

                            if (matrices[posMatriz1].cantColumnas == matrices[posMatriz2].cantColumnas && matrices[posMatriz1].cantFilas == matrices[posMatriz2].cantFilas)
                            {
                                float[,] matrizSuma = new float[matrices[posMatriz1].cantFilas, matrices[posMatriz2].cantColumnas];
                                matrizSuma = matrices[posMatriz1].Suma(matrices[posMatriz2]);

                                Console.WriteLine("\n\tEl resultado de la suma es: \n");

                                for (int i = 0; i < matrices[posMatriz1].cantFilas; i++)
                                {
                                    Console.Write("\t");
                                    Console.Write("| ");
                                    for (int e = 0; e < matrices[posMatriz1].cantColumnas; e++)
                                    {
                                        Console.Write(matrizSuma[i, e]);
                                        Console.Write(" | ");
                                    }
                                    Console.Write("\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\n\tNo se puede hacer porque no tienen la mismas dimensiones");
                            }
                        }
                        break;

                    case 4:
                        Console.WriteLine("\n\t¿Cuáles quieres hacer?");
                        posMatriz1 = LeerPorPantallaInt();
                        posMatriz2 = LeerPorPantallaInt();

                        if (matrices[posMatriz1] == null || matrices[posMatriz2] == null)
                        {
                            Console.WriteLine("\n\tAlguna de las matrices no ha sido creada");
                        }
                        else
                        {

                            if (matrices[posMatriz1].cantColumnas == matrices[posMatriz2].cantFilas)
                            {
                                float[,] matrizMultiplicacion = new float[matrices[posMatriz1].cantFilas, matrices[posMatriz2].cantColumnas];
                                matrizMultiplicacion = matrices[posMatriz1].Multiplicacion(matrices[posMatriz2]);

                                Console.WriteLine("\n\tEl resultado de la multiplicación es: \n");

                                for (int i = 0; i < matrices[posMatriz1].cantFilas; i++)
                                {
                                    Console.Write("\t");
                                    Console.Write("| ");
                                    for (int e = 0; e < matrices[posMatriz1].cantColumnas; e++)
                                    {
                                        Console.Write(matrizMultiplicacion[i, e]);
                                        Console.Write(" | ");
                                    }
                                    Console.Write("\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\n\tNo se puede hacer porque la primera no tiene la misma cantidad de columnas que filas la segunda");
                            }
                        }
                        break;

                    case 5:
                        Console.WriteLine("\n\t¿Cuál quieres hacer?");
                        posMatriz = LeerPorPantallaInt();


                        if (matrices[posMatriz] == null)
                        {
                            Console.WriteLine("\n\tLa matriz no ha sido creada");
                        }
                        else
                        {
                            det = matrices[posMatriz].Determinante3x3();

                            if (det == 0)
                            {
                                Console.WriteLine("\n\tNo existe");
                            }
                            else
                            {
                                Matriz inversa = new Matriz(matrices[posMatriz].cantColumnas, matrices[posMatriz].cantFilas, matrices[posMatriz].matriz);
                                inversa.matriz = inversa.Adjunta();
                                inversa.matriz = inversa.Transpuesta();

                                Console.WriteLine("\n\n\n\n\tLa matriz inversa es la siguiente:\n");

                                for (int i = 0; i < inversa.cantFilas; i++)
                                {
                                    for (int e = 0; e < inversa.cantColumnas; e++)
                                    {
                                        inversa.matriz[i, e] /= det;
                                    }
                                }



                                for (int i = 0; i < inversa.cantFilas; i++)
                                {
                                    Console.Write("\t");
                                    Console.Write("| ");
                                    for (int e = 0; e < inversa.cantColumnas; e++)
                                    {
                                        Console.Write(inversa.matriz[i, e]);
                                        Console.Write(" | ");
                                    }
                                    Console.Write("\n");
                                }

                            }
                        }
                        break;

                    case 6:
                        Console.WriteLine("\n\tDefina la matriz (recuerda que es de 3 incógnitas)");
                        Sistema = new SistemaDeEcuaciones3Incognitas();

                        float X = Sistema.HallarX();
                        float Y = Sistema.HallarY();
                        float Z = Sistema.HallarZ();

                        Console.WriteLine("\n\tX = " + X + "\n\tY = " + Y + "\n\tZ = " + Z);

                        break;

                    case 10:
                        Console.WriteLine("\n\tDefina la recta");
                        recta = new Recta();
                        Console.WriteLine("\n\tDefina el plano");
                        plano = new Plano(true);

                        Console.Write("\n\tDistancia: ");
                        float numerador = recta.punto.coordenadas[0] * plano.vectorNormal.coordenadas[0] + recta.punto.coordenadas[1] * plano.vectorNormal.coordenadas[1] + recta.punto.coordenadas[2] * plano.vectorNormal.coordenadas[2] + plano.terminoIndependiente;
                        if (numerador < 0)
                        {
                            numerador = -numerador;
                        }
                        Console.WriteLine((numerador / plano.vectorNormal.Modulo()) + " unidades");


                        break;

                    case 7:
                        Console.WriteLine("\n\t¿Cuál quieres hacer?");
                        posVector1 = LeerPorPantallaInt();

                        if (posVector1 < matrices.Length && posVector1 >= 0)
                        {
                            vectores[posVector1] = new Vector();
                        }
                        else
                        {
                            Console.WriteLine("\n\tHay 99 disponibles, la posición no puede ser mayor");
                        }
                        break;

                    case 8:
                        Console.WriteLine("\n\t¿Cuáles quieres multiplicar vectorialmente?");
                        posVector1 = LeerPorPantallaInt();
                        posVector2 = LeerPorPantallaInt();

                        if (vectores[posVector1] == null || vectores[posVector2] == null)
                        {
                            Console.WriteLine("\n\tAlguna de las matrices no ha sido creada");
                        }
                        else
                        {

                            Console.WriteLine("\n\tProducto vectorial: " + vectores[posVector1].ProductoVectorial(vectores[posVector2]));
                        }
                        break;

                    case 9:
                        Console.WriteLine("\n\t¿Cuáles quieres multiplicar escalarmente?");
                        posVector1 = LeerPorPantallaInt();
                        posVector2 = LeerPorPantallaInt();

                        if (vectores[posVector1] == null || vectores[posVector2] == null)
                        {
                            Console.WriteLine("\n\tAlguna de las matrices no ha sido creada");
                        }
                        else
                        {

                            Console.WriteLine("\n\tProducto escalar: " + vectores[posVector1].ProductoEscalar(vectores[posVector2]).coordenadas[0] + "i " + vectores[posVector1].ProductoEscalar(vectores[posVector2]).coordenadas[1] + "j " + vectores[posVector1].ProductoEscalar(vectores[posVector2]).coordenadas[2] + "k ");
                        }
                        break;

                    case 11:
                        Console.WriteLine("\n\tDefina la recta");
                        punto = new Punto();

                        Console.WriteLine("\n\tDefina el plano");
                        plano = new Plano(true);

                        Console.Write("\n\tDistancia: ");
                        float numerator = punto.coordenadas[0] * plano.vectorNormal.coordenadas[0] + punto.coordenadas[1] * plano.vectorNormal.coordenadas[1] + punto.coordenadas[2] * plano.vectorNormal.coordenadas[2] + plano.terminoIndependiente;
                        if (numerator < 0)
                        {
                            numerator = -numerator;
                        }
                        Console.WriteLine((numerator / plano.vectorNormal.Modulo()) + " unidades");
                        break;

                    default:
                        Console.WriteLine("Esa opción no está disponible");
                        break;
                }

                Console.ReadLine();
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
