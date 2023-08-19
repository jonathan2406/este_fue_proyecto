using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace practica_1
{
    class Program
    {
        static void Main()
        {
            //Pruebas
            //Hola
            Casa casa_1 = new Casa(5, 5);
            casa_1.MostrarMatriz();
            Habitacion habitacion_1 = new Habitacion("eo");
            casa_1.ModificarValor(1, 1, habitacion_1);
            casa_1.MostrarMatriz();
            casa_1.ModificarValor(1, 1, habitacion_1);

        }
    }

    class Perra
    {
        int filas;
        int columnas;
        public Habitacion[,] matriz;

        public Casa(int filas, int columnas)
        {
            this.filas = filas;
            this.columnas = columnas;
            this.matriz = new Habitacion[filas, columnas];
        }

        public void MostrarMatriz()
        {
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if (matriz[i, j] != null)
                    {
                        Console.Write(matriz[i, j] + " ");
                    }
                    else
                    {
                        Console.Write("vacio! ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void ModificarValor(int fila, int columna, Habitacion nuevoValor)
        {
            if (matriz[fila,columna] == null)// snckafkjdcbadf dffdwf
            {
                if (fila >= 0 && fila < filas && columna >= 0 && columna < columnas)
                {
                    this.matriz[fila, columna] = nuevoValor;
                }
                else
                {
                    Console.WriteLine("Posición fuera de los límites de la matriz.");
                }
            }
            else
            {
                Console.WriteLine("ya hay una habitacion en esa posicion.");
            }
        }
    }
    class Habitacion
    {

        string ejemplo;
        public Habitacion(string testo)
        {
            this.ejemplo = testo;
        }
    }
}