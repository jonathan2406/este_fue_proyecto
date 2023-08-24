using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace este_fue_proyecto
{
    class Casa
    {
        int filas;
        int columnas;
        Habitacion[,] matriz;
        Habitacion[,] matriz_vieja;
        Habitacion[,] backup;

        public Casa(int filas, int columnas)
        {
            this.filas = filas;
            this.columnas = columnas;
            matriz = new Habitacion[filas, columnas];
            matriz_vieja = matriz;
        }
        public void set_matriz(Habitacion[,] matriz_a_poner)
        {
            matriz = matriz_a_poner;
            filas = matriz_a_poner.GetLength(0);
            columnas = matriz_a_poner.GetLength(1);
        }
        public void set_matriz_vieja(Habitacion[,] matriz_a_poner)
        {
            matriz_vieja = matriz_a_poner;
        }
        public void MostrarMatriz()
        {
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if (matriz[i, j] != null)
                    {
                        Console.Write(matriz[i, j].Nombre + " ");
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
        public void MostrarMatriz_vieja()
        {
            for (int i = 0; i < matriz_vieja.GetLength(0); i++)
            {
                for (int j = 0; j < matriz_vieja.GetLength(1); j++)
                {
                    if (matriz[i, j] != null)
                    {
                        Console.Write(matriz_vieja[i, j].get_nombre() + " ");
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

        public bool ModificarValor(int fila, int columna, Habitacion nuevoValor)
        {
            if (matriz[fila, columna] == null)
            {
                if (fila >= 0 && fila < filas && columna >= 0 && columna < columnas)
                {
                    this.matriz[fila, columna] = nuevoValor;
                    return true;
                }
                else
                {
                    Console.WriteLine("Posición fuera de los límites de la matriz.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("ya hay una habitacion en esa posicion.");
                return false;
            }
        }
        
        public void expandir_plano(int fila, int columna)
        {
            if (fila < filas)
            {
                fila =(filas)- 1;
            }
            if (columna < columnas)
            {
                columna =(columnas)- 1;
            }
            Habitacion[,] vieja_matriz = matriz;
            Habitacion[,] nueva_matriz = new Habitacion[fila+1, columna+1];
            for (int i = 0; i < vieja_matriz.GetLength(0); i++)
            {
                for (int j = 0; j < vieja_matriz.GetLength(1); j++)
                {
                    nueva_matriz[i, j] = vieja_matriz[i, j];
                }
            }
            matriz = nueva_matriz;
            filas = nueva_matriz.GetLength(0);
            columnas = nueva_matriz.GetLength(1);
        }

        public Habitacion añadir_habitacion(string nombre_habitacion, int fila, int columna, int metros)
        {
            if (matriz.GetLength(0)-1  < fila || matriz.GetLength(1)-1  < columna)
            {
                expandir_plano(fila, columna);
            }

            if (Trabajar_trabajant(fila, columna) == true)
            {
                Habitacion nueva_habitacion = new Habitacion(nombre_habitacion, metros);
                bool modificacion = ModificarValor(fila, columna, nueva_habitacion);
                if (modificacion == false)
                {
                    matriz = matriz_vieja;
                    return null;
                }
                else
                {
                    if (metros > 10)
                    {
                        bool ampliacion = ampliar_habitacion(nueva_habitacion, metros - 10);
                        if (ampliacion == true)
                        {
                            nueva_habitacion.set_medidas(nueva_habitacion.get_medidas() + 10);
                            return nueva_habitacion;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return nueva_habitacion;
                    }
                }
            }
            else
            {
                Console.WriteLine("errorrrrrrrrrrrrrrrrrrrr");
                return null;
            }
        }

        public void añadir_nueva_columna(int pocision)
        {
            Habitacion[,] nuevaMatriz = new Habitacion[filas, columnas + 1]; 

            for (int fila = 0; fila < filas; fila++)
            {
                for (int columnaNueva = 0, columnaOriginal = 0; columnaNueva < columnas + 1; columnaNueva++)
                {
                    if (columnaNueva == pocision)
                    {
                        nuevaMatriz[fila, columnaNueva] = null; 
                    }
                    else
                    {
                        nuevaMatriz[fila, columnaNueva] = matriz[fila, columnaOriginal];
                        columnaOriginal++;
                    }
                }
            }

            matriz = nuevaMatriz;
            columnas += 1;
        }

        public (int fila, int columna) posicion_habitacion(Habitacion habitacion_buscar)
        {
            for (int fila = (filas) - 1;  fila >= 0; fila--)
            {
                for (int columna = (columnas)-1; columna >= 0; columna--)
                {
                    if (matriz[fila, columna] == (habitacion_buscar))
                    {
                        return (fila, columna);
                    }
                }    
            }
            return (0, 0);
        }

        public bool ampliar_habitacion(Habitacion habitacion_amplear,  double metros)
        {
            if (metros <= 0)
            {
                Console.WriteLine("ingrese un numero positivo plzzzzzzzzzzz");
                return false;
            }
            double metros_viejos = habitacion_amplear.get_medidas();
            habitacion_amplear.set_medidas(metros);
            if (habitacion_amplear.verificar_ocupacion() == true)
            {
                (int fila_encontrada, int columna_encontrada) = posicion_habitacion(habitacion_amplear);
                if (matriz[fila_encontrada, columna_encontrada] == habitacion_amplear)
                {
                    metros = metros / 10;
                    for (int j = 0; j < metros; j++)
                    {
                        if (matriz.GetLength(1)-1 == columna_encontrada+j && Trabajar_trabajant(fila_encontrada, columna_encontrada+j) == true)
                        {
                            añadir_nueva_columna(columna_encontrada + j);
                            matriz[fila_encontrada, columna_encontrada + j] = habitacion_amplear;
                        }
                        else if (Trabajar_trabajant(fila_encontrada, columna_encontrada + j) == true && matriz[fila_encontrada, columna_encontrada + j + 1] == null)
                        {
                            matriz[fila_encontrada, columna_encontrada + j + 1] = habitacion_amplear;
                        }
                        else if (Trabajar_trabajant(fila_encontrada, columna_encontrada + j) == true && matriz[fila_encontrada, (columna_encontrada + j)+1] != null)
                        {
                            if (columna_encontrada + j + 1 == matriz.GetLength(1) - 1)
                            {
                                añadir_nueva_columna(columna_encontrada + j + 1);
                            }
                            else
                            {
                                bool verificador = false;
                                for (int ñ = columna_encontrada + j; ñ < matriz.GetLength(1); ñ++)
                                {
                                    if (matriz[fila_encontrada, ñ] == null)
                                    {
                                        List<Habitacion> contenedor = new List<Habitacion> { };
                                        for (int k = columna_encontrada + j + 1; k < ñ; k++)
                                        {
                                            contenedor.Add(matriz[fila_encontrada, k]);
                                        }
                                        for (int y = columna_encontrada + j + 2, pasador = 0; y <= ñ; y++, pasador++)
                                        {
                                            matriz[fila_encontrada, y] = contenedor[pasador];
                                        }
                                        matriz[fila_encontrada, columna_encontrada + j + 1] = null;
                                        verificador = true;
                                        break;
                                    }
                                }
                                if (verificador == false)
                                {
                                    añadir_nueva_columna(matriz.GetLength(1) - 1);
                                    j -= 1;
                                }
                            }
                        }
                        if (Trabajar_trabajant(fila_encontrada, columna_encontrada + j) == true && matriz[fila_encontrada, (columna_encontrada) + 1 + j] == null)
                        {
                            matriz[fila_encontrada, columna_encontrada + j + 1] = habitacion_amplear;
                        }
                        if (Trabajar_trabajant(fila_encontrada, columna_encontrada + j) == false)
                        {
                            Console.WriteLine("errorrrrrrrr no puedes amplear ya que en las ubicaciones adyacentes detectamos personas, porfavor retirelas para continuar");
                            matriz = matriz_vieja;
                            filas = matriz_vieja.GetLength(0);
                            columnas = matriz_vieja.GetLength(1);
                            habitacion_amplear.set_medidas(metros_viejos);
                            return false;
                        }
                    }
                }
                matriz_vieja = matriz;
                return true;
            }

            else
            {
                Console.WriteLine("desocupe la habitacion que desea ampliar.....");
                return false;
            }
        }


        public bool Trabajar_trabajant(int fila, int columna)
        {
            if (fila == 0)
            {
                if (columna == 0)
                {
                    if ((matriz[fila + 1, columna] == null || matriz[fila + 1, columna].verificar_ocupacion() == true) &&
                        (matriz[fila, columna + 1] == null || matriz[fila, columna + 1].verificar_ocupacion() == true))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

                else if (columna == matriz.GetLength(1) - 1)
                {
                    if ((matriz[fila + 1, columna] == null || matriz[fila + 1, columna].verificar_ocupacion() == true) &&
                        (matriz[fila, columna - 1] == null || matriz[fila, columna - 1].verificar_ocupacion() == true))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (columna > 0)
                {
                    if ((matriz[fila + 1, columna] == null || matriz[fila + 1, columna].verificar_ocupacion() == true) &&
                        (matriz[fila, columna + 1] == null || matriz[fila, columna + 1].verificar_ocupacion() == true) &&
                        (matriz[fila, columna - 1] == null || matriz[fila, columna - 1].verificar_ocupacion() == true))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            if (fila == matriz.GetLength(0) - 1)
            {
                if (columna == 0)
                {
                    if ((matriz[fila - 1, columna] == null || matriz[fila - 1, columna].verificar_ocupacion() == true) &&
                        (matriz[fila, columna + 1] == null || matriz[fila, columna + 1].verificar_ocupacion() == true))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

                else if (columna == matriz.GetLength(1) - 1)
                {
                    if ((matriz[fila - 1, columna] == null || matriz[fila - 1, columna].verificar_ocupacion() == true) &&
                        (matriz[fila, columna - 1] == null || matriz[fila, columna - 1].verificar_ocupacion() == true))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (columna > 0)
                {
                    if ((matriz[fila - 1, columna] == null || matriz[fila - 1, columna].verificar_ocupacion() == true) &&
                        (matriz[fila, columna + 1] == null || matriz[fila, columna + 1].verificar_ocupacion() == true) &&
                        (matriz[fila, columna - 1] == null || matriz[fila, columna - 1].verificar_ocupacion() == true))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else if (fila > 0)
            {
                if (columna == 0)
                {
                    if ((matriz[fila - 1, columna] == null || matriz[fila - 1, columna].verificar_ocupacion() == true) &&
                        (matriz[fila + 1, columna] == null || matriz[fila + 1, columna].verificar_ocupacion() == true) &&
                        (matriz[fila, columna + 1] == null || matriz[fila, columna + 1].verificar_ocupacion() == true))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

                else if (columna == matriz.GetLength(1) - 1)
                {
                    if ((matriz[fila - 1, columna] == null || matriz[fila - 1, columna].verificar_ocupacion() == true) &&
                        (matriz[fila + 1, columna] == null || matriz[fila + 1, columna].verificar_ocupacion() == true) &&
                        (matriz[fila, columna - 1] == null || matriz[fila, columna - 1].verificar_ocupacion() == true))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (columna > 0)
                {
                    if ((matriz[fila - 1, columna] == null || matriz[fila - 1, columna].verificar_ocupacion() == true) &&
                        (matriz[fila + 1, columna] == null || matriz[fila + 1, columna].verificar_ocupacion() == true) &&
                        (matriz[fila, columna + 1] == null || matriz[fila, columna + 1].verificar_ocupacion() == true) &&
                        (matriz[fila, columna - 1] == null || matriz[fila, columna - 1].verificar_ocupacion() == true))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public Habitacion[,] get_plano()
        {
            return matriz;
        }
    }
}