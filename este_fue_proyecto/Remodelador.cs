using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace este_fue_proyecto
{
    internal class Remodelador
    {
        bool estado_ocupacion = true;
        int costo_hora = 50000;

        public bool get_estado_ocupacion()
        {
            return estado_ocupacion;
        }
        public int get_costo_hora()
        {
            return costo_hora;
        }
        void set_estado_ocupacion(bool nuevo_estado)
        {
            estado_ocupacion = nuevo_estado;
        }
        void set_costo_hora(int nuevo_valor)
        {
            costo_hora = nuevo_valor;
        }
        public void añadir_habitacion(string nombre_habitacion, Casa casa, int fila, int columna, int metros, bool verificador = true)
        {
            int metros_originales = metros;
            for (int i = 0; i < metros; i++)
            {
                if (metros > 0)
                {
                    if (casa.get_plano().GetLength(0) - 1 < fila || casa.get_plano().GetLength(1) - 1 < columna)
                    {
                        casa.expandir_plano(fila + i, columna + i);
                    }
                    try
                    {
                        if (casa.Trabajar_trabajant(fila, columna + i) == true && verificador == true)
                        {
                            metros = metros - 10;
                            verificador = false;
                            Habitacion nueva_habitacion = new Habitacion(nombre_habitacion, metros_originales);
                            casa.ModificarValor(fila, columna + i, nueva_habitacion);
                        }
                        else if (casa.Trabajar_trabajant(fila, columna + i) == true && verificador == false)
                        {
                            metros = metros - 10;
                            casa.ModificarValor(fila, columna + i, casa.get_plano()[fila, columna + i - 1]);
                        }
                        else
                        {
                            Console.WriteLine("error!!!, se detecto gente en una habitacion adyacente, porfavor muevalos antes de añadir una habitacion con sus especificaciones");
                            casa.matriz = casa.matriz_vieja;
                            casa.filas = casa.get_plano().GetLength(0);
                            casa.columnas = casa.get_plano().GetLength(1);
                            break;
                        }
                    }
                    catch
                    {
                        casa.expandir_plano(fila, columna + i);
                        i -= 1;
                    }

                }else
                {
                    casa.matriz_vieja = casa.matriz;
                }
            }
        }
    }
}
