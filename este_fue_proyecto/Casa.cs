using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace este_fue_proyecto
{
    class Casa
    {
        public int filas;
        int columnas;
        public Habitacion[,] matriz;

        public Casa(int filas, int columnas)
        {
            this.filas = filas;
            this.columnas = columnas;
            matriz = new Habitacion[filas, columnas];
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
            if (matriz[fila, columna] == null)
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
        public Habitacion[,] get_plano()
        {
            return matriz;
        }
        public void expandir_plano(int fila, int columna)
        {
            Habitacion[,] vieja_matriz = matriz;
            Habitacion[,] nueva_matriz = new Habitacion[fila, columna];
            for (int i = 0; i < vieja_matriz.GetLength(0); i++)
            {
                for (int j = 0; j < vieja_matriz.GetLength(1);j ++)
                {
                    nueva_matriz[i, j] = vieja_matriz[i, j];
                }
            }
            matriz = nueva_matriz;
            filas = nueva_matriz.GetLength(0);
            columnas = nueva_matriz.GetLength(1);

        }
    }
}
