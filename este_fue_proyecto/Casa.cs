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
        public int columnas;
        public Habitacion[,] matriz;
        public Habitacion[,] matriz_vieja;

        public Casa(int filas, int columnas)
        {
            this.filas = filas;
            this.columnas = columnas;
            matriz = new Habitacion[filas, columnas];
            matriz_vieja = matriz;
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
                        Console.Write(matriz_vieja[i, j] + " ");
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
                for (int j = 0; j < vieja_matriz.GetLength(1); j++)
                {
                    nueva_matriz[i, j] = vieja_matriz[i, j];
                }
            }
            matriz = nueva_matriz;
            filas = nueva_matriz.GetLength(0);
            columnas = nueva_matriz.GetLength(1);
        }

        public void añadir_habitacion(string nombre_habitacion, int fila, int columna, int metros, bool verificador = true)
        {
            int metros_originales = metros;
            for (int i = 0; i < metros; i++)
            {
                if (metros > 0)
                {
                    if (get_plano().GetLength(0) - 1 < fila || get_plano().GetLength(1) - 1 < columna)
                    {
                        expandir_plano(fila + i, columna + i);
                    }
                    try
                    {
                        if (Trabajar_trabajant(fila, columna + i) == true && verificador == true)
                        {
                            metros = metros - 10;
                            verificador = false;
                            Habitacion nueva_habitacion = new Habitacion(nombre_habitacion, metros_originales);
                            if (ModificarValor(fila, columna + i, nueva_habitacion) == false)
                            {
                                return;
                            }
                        }
                        else if (Trabajar_trabajant(fila, columna + i) == true && verificador == false)
                        {
                            metros = metros - 10;
                            ModificarValor(fila, columna + i, get_plano()[fila, columna + i - 1]);
                        }
                        else
                        {
                            Console.WriteLine("error!!!, se detecto gente en una habitacion adyacente, porfavor muevalos antes de añadir una habitacion con sus especificaciones");
                            matriz = matriz_vieja;
                            filas = get_plano().GetLength(0);
                            columnas = get_plano().GetLength(1);
                            break;
                        }
                    }
                    catch
                    {
                        expandir_plano(fila, columna + i);
                        i -= 1;
                    }

                }
                else
                {
                    matriz_vieja = matriz;
                }
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

        public void ampliar_habitacion(Habitacion habitacion_amplear, double metros)
        {
            if (metros <= 0)
            {
                Console.WriteLine("ingrese un numero positivo plzzzzzzzzzzz");
                return;
            }
            double metros_viejos = habitacion_amplear.get_medidas();
            habitacion_amplear.set_medidas(metros);
            if (habitacion_amplear.verificar_ocupacion() == true)
            {
                (int fila_encontrada, int columna_encontrada) = posicion_habitacion(habitacion_amplear);
                if (matriz[fila_encontrada, columna_encontrada] == habitacion_amplear)
                {
                    Console.WriteLine("encontre ubicacion");
                    metros = metros / 10;
                    for (int j = 0; j < metros; j++)
                    {
                        Console.WriteLine($"iteracion {j}");
                        Console.WriteLine(metros);
                        Console.WriteLine(metros);
                        if (matriz.GetLength(1)-1 == columna_encontrada+j && Trabajar_trabajant(fila_encontrada, columna_encontrada+j) == true)
                        {
                            Console.WriteLine("se metio por el primer if");
                            añadir_nueva_columna(columna_encontrada + j);
                            matriz[fila_encontrada, columna_encontrada + j] = habitacion_amplear;
                            MostrarMatriz();
                        }
                        if (Trabajar_trabajant(fila_encontrada, columna_encontrada + j) == true && get_plano()[fila_encontrada, (columna_encontrada + j)+1] != null)
                        {
                            añadir_nueva_columna(columna_encontrada + j + 1);
                            Console.WriteLine("se metio por el segundo if");
                            MostrarMatriz();
                        }
                        if (Trabajar_trabajant(fila_encontrada, columna_encontrada + j) == true && get_plano()[fila_encontrada, (columna_encontrada) + 1 + j] == null)
                        {
                            Console.WriteLine("semetio por el tercer if");
                            matriz[fila_encontrada, columna_encontrada + j + 1] = habitacion_amplear;
                            MostrarMatriz();
                        }
                        else if (Trabajar_trabajant(fila_encontrada, columna_encontrada + j) == false)
                        {
                            Console.WriteLine("errorrrrrrrr no puedes amplear ya que en las ubicaciones adyacentes detectamos personas, porfavor retirelas para continuar");
                            matriz = matriz_vieja;
                            filas = matriz_vieja.GetLength(0);
                            columnas = matriz_vieja.GetLength(1);
                            habitacion_amplear.set_medidas(metros_viejos);
                            return;
                        }
                    }
                }
                Console.WriteLine("el plano viejo era:  ");
                MostrarMatriz_vieja();
                Console.WriteLine("el plano nuevo quedaria:  ");
                MostrarMatriz();
                matriz_vieja = matriz;
            }

            else
            {
                Console.WriteLine("desocupe la habitacion que desea ampliar.....");
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

                else if (columna == matriz.GetLength(1)-1)
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
            if (fila == matriz.GetLength(0)-1)
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

                else if (columna == matriz.GetLength(1)-1)
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

                else if (columna == matriz.GetLength(1)-1)
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


    }
}
