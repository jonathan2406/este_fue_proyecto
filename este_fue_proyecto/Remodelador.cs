using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace este_fue_proyecto
{
    internal class Remodelador : Persona
    {

        bool estado_ocupacion = false;
        int costo_hora = 50000;
        private int tiempo_arreglo_por_objeto = 10;

        public Remodelador(string nombre) : base(nombre) { }
        public bool get_estado_ocupacion()
        {
            return estado_ocupacion;
        }
        public int get_costo_hora()
        {
            return costo_hora;
        }
        public void set_estado_ocupacion(bool nuevo_estado)
        {
            estado_ocupacion = nuevo_estado;
        }
        public void set_costo_hora(int nuevo_valor)
        {
            costo_hora = nuevo_valor;
        }
        void trabajador_añadir_habitacion(Casa casa, string nombre_habitacion, int fila, int columna, int metros)
        {
            casa.añadir_habitacion(nombre_habitacion, fila, columna, metros);
        }
        void trabajador_amplear_habitacion(Casa casa, Habitacion habitacion, int metros)
        {
            casa.ampliar_habitacion(habitacion, metros);
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
            int totalMueblesSeleccionados = 0;
            

            foreach (string seleccionado in seleccionados)
            {
                if (int.TryParse(seleccionado.Trim(), out int indice) && indice >= 1 && indice <= mueblesPorArreglar.Count)
                {
                    Muebles muebleSeleccionado = mueblesPorArreglar[indice - 1];
                    muebleSeleccionado.SetEstado(true);
                    Console.WriteLine($"Se está arreglando el mueble: {muebleSeleccionado.Nombre}");
                    totalMueblesSeleccionados++;
                }
                else
                {
                    Console.WriteLine("No se arreglo ningún mueble.");
                }
            }
            int tiempoDeEsperaEnSegundos = totalMueblesSeleccionados * 10; 
            Console.WriteLine($"Esperando {tiempoDeEsperaEnSegundos} segundos...");
            Thread.Sleep(tiempoDeEsperaEnSegundos * 1000);
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

        public TimeSpan calcular_tiempo_nueva_habitacion(Habitacion habitacionExistente)
        {
            double segundosPorMetroCuadrado = 1.5;
            double segundosPorTrabajador = 1.5;

            double metrosCuadrados = habitacionExistente.Area;

            double tiempoTotal = metrosCuadrados * segundosPorMetroCuadrado;
            int trabajadores = ((int)metrosCuadrados / 10) * 2;
            tiempoTotal += trabajadores * segundosPorTrabajador;

            int tiempoDeEsperaEnSegundos = (int)Math.Ceiling(tiempoTotal);
            Console.WriteLine($"Esperando {tiempoDeEsperaEnSegundos} segundos para la nueva habitación...");
            Thread.Sleep(tiempoDeEsperaEnSegundos * 1000);

            return TimeSpan.FromSeconds(tiempoTotal);
        }



    }
}
