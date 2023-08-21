using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace este_fue_proyecto
{
    internal class Remodelador
    {
        bool estado_ocupacion = true;
        int costo_hora = 50000;
        private int tiempo_arreglo_por_objeto = 10;

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
        void añadir_habitacion(Casa casa,int fila, int columna, int metros)
        {
            for (int i = 1; i < metros; i++)
            {
                if (casa.get_plano()[fila,columna] == null )
                    {
                        Console.WriteLine();
                    }
            }
        }

        public void reparar_habitacion(Habitacion habitacion)
        {
            List<Muebles> mueblesPorArreglar = new List<Muebles>();

            foreach (Muebles mueble in habitacion.GetMuebles())
            {
                if (!mueble.GetEstado())
                {
                    mueblesPorArreglar.Add(mueble);
                }
            }

            if (mueblesPorArreglar.Count == 0)
            {
                Console.WriteLine("Los muebles ya están reparados.");
                return;
            }

            Console.WriteLine($"Muebles para reparar en {habitacion.Nombre}:");
            for (int i = 0; i < mueblesPorArreglar.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {mueblesPorArreglar[i].Nombre}");
            }

            Console.WriteLine("Ingrese los números de los muebles que desea arreglar (separados por comas):");
            string input = Console.ReadLine();
            string[] seleccionados = input.Split(',');

            foreach (string seleccionado in seleccionados)
            {
                if (int.TryParse(seleccionado.Trim(), out int indice) && indice >= 1 && indice <= mueblesPorArreglar.Count)
                {
                    Muebles muebleSeleccionado = mueblesPorArreglar[indice - 1];
                    muebleSeleccionado.SetEstado(true);
                    Console.WriteLine($"Se ha arreglado el mueble: {muebleSeleccionado.Nombre}");
                }
            }
        }

        public TimeSpan calcular_tiempo_arreglo_habitacion(Habitacion habitacion)
        {
            TimeSpan tiempo_total = TimeSpan.Zero;

            foreach (Muebles mueble in habitacion.GetMuebles())
            {
                if (!mueble.GetEstado())
                {
                    tiempo_total += TimeSpan.FromSeconds(tiempo_arreglo_por_objeto);
                }
            }

            return tiempo_total;
        }

    }
}
