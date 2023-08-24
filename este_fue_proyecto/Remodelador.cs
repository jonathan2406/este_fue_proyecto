using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace este_fue_proyecto
{
    internal class Remodelador : Persona
    {

        public DateTime hora_ocupacion;
        int costo_hora = 40000;
        bool estado_ocupacion = false;
        private double tiempo_arreglo_por_objeto = 1;

        public Remodelador(string nombre) : base(nombre) 
        {
            this.hora_ocupacion = DateTime.Now;
        }
        public bool verificar_disponibilidad_trabajador()
        {
            if (hora_ocupacion.CompareTo(DateTime.Now) < 0)
            {
                estado_ocupacion = true;
                return true;
            }
            else
            {
                estado_ocupacion = false;
                return false;
            }
        }
        public void set_hora_ocupacion(DateTime tiempo)
        {
            hora_ocupacion = tiempo;
        }
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
        public void añadir_habitacion(Casa casa, Habitante habitante, string nombreHabitacion, int fila, int columna, int metros)
        {
            double horasPorMetroCuadrado = 1.5;

            double metrosCuadrados = metros;

            double tiempoTotal = metrosCuadrados * horasPorMetroCuadrado;
            int trabajadores = ((int)metrosCuadrados / 10) * 2;
            tiempoTotal += trabajadores * horasPorMetroCuadrado;

            double costoTotal = tiempoTotal * 40000;

            if (habitante.Dinero < costoTotal)
            {
                Console.WriteLine($"El habitante {habitante.Nombre} no tiene suficiente dinero para pagar el trabajo de remodelación.");
                return;
            }
            

            DateTime localDate = DateTime.Now;
            DateTime newDate = localDate.AddHours(1.5 * metrosCuadrados);
            String[] cultureNames = { "es-CO" };

            foreach (var cultureName in cultureNames)
            {
                var culture = new CultureInfo(cultureName);
                Console.WriteLine("-----------------------------------------------------------------------");

                Console.WriteLine("{0}:", culture.NativeName);

                Console.WriteLine("-----------------------------------------------------------------------");

                Console.WriteLine($"Tiempo estimado para acabar de añadir habitación: {tiempoTotal} hora/s");

                Habitacion nuevaHabitacion = new Habitacion(nombreHabitacion, metros);
                casa.ModificarValor(fila, columna, nuevaHabitacion);

                habitante.Pagar(costoTotal);

                Console.WriteLine("-----------------------------------------------------------------------");

                Console.WriteLine($"Se añadió la habitación '{nombreHabitacion}' a la casa.");

                Console.WriteLine("-----------------------------------------------------------------------");

                Console.WriteLine("Los remodeladores terminaron de agregar la habitación a las: {0}, {1:G}",
                                      newDate.ToString(culture), newDate.Kind);
                Console.WriteLine("-----------------------------------------------------------------------");
                Console.WriteLine($"Saldo de {habitante.Nombre}: {habitante.Dinero}");
                Console.WriteLine($"TRABAJADORES: {trabajadores}");

            }

        }
    

        public void reparar_habitacion(Habitacion habitacion, Habitante habitante)
        {
            if (get_estado_ocupacion())
            {
                Console.WriteLine("El remodelador está ocupado en otra tarea");
                return;
            }
            estado_ocupacion = true;
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
            double costoTotalReparacion = 0;
            bool puedePagarTareas = true;

            foreach (string seleccionado in seleccionados)
            {
                if (int.TryParse(seleccionado.Trim(), out int indice) && indice >= 1 && indice <= mueblesPorArreglar.Count)
                {
                    Muebles muebleSeleccionado = mueblesPorArreglar[indice - 1];
                    double costoReparacion = muebleSeleccionado.GetCosto() * 0.3;
                    costoTotalReparacion += costoReparacion;

                    if (puedePagarTareas && habitante.Dinero >= costoReparacion)
                    {
                        habitante.Pagar(costoReparacion);
                        muebleSeleccionado.SetEstado(true);
                        Console.WriteLine($"Se está arreglando el mueble: {muebleSeleccionado.Nombre}");
                        totalMueblesSeleccionados++;
                    }

                    else
                    {
                        Console.WriteLine($"El habitante {habitante.Nombre} no tiene suficiente dinero para pagar la reparación.");
                        puedePagarTareas = false;
                    }

                }
                else
                {
                    Console.WriteLine("No se arreglo ningún mueble.");
                }
            }
            double tiempoTotalTrabajo = totalMueblesSeleccionados * 1;

            if (totalMueblesSeleccionados > 0)
            {
                double costoTotalTrabajo = tiempoTotalTrabajo * 40000;
                habitante.Pagar(costoTotalTrabajo);
                Console.WriteLine($"Habitante {habitante.Nombre} pagó {costoTotalTrabajo} por las horas de trabajo de los " +
                    $"remodeladores.");
            }

            if (puedePagarTareas)
            {
                DateTime localDate = DateTime.Now;
                DateTime newDate = localDate.AddHours(1 * totalMueblesSeleccionados);
                String[] cultureNames = { "es-CO" };

                foreach (var cultureName in cultureNames)
                {
                    var culture = new CultureInfo(cultureName);
                    Console.WriteLine("-----------------------------------------------------------------------");
                    Console.WriteLine("{0}:", culture.NativeName);
                    Console.WriteLine("Los remodeladores terminaron de reparar los muebles a las: {0}, {1:G}",
                                      newDate.ToString(culture), newDate.Kind);
                    Console.WriteLine($"Saldo de {habitante.Nombre}: ${habitante.Dinero}");
                }
            }
            estado_ocupacion = false;
        }

        public double calcular_tiempo_arreglo_habitacion(Habitacion habitacion)
        {
            double tiempo_total_horas = 0;

            foreach (Muebles mueble in habitacion.GetMuebles())
            {
                if (!mueble.GetEstado())
                {
                    tiempo_total_horas += tiempo_arreglo_por_objeto;
                }
            }
            Console.WriteLine($"Tiempo estimado de reparación: {tiempo_total_horas} hora/s");
            return tiempo_total_horas;



        }

        public void calcular_tiempo_nueva_habitacion(Habitacion habitacionExistente, Habitante habitante)
        {
            double horasPorMetroCuadrado = 1.5;

            double metrosCuadrados = habitacionExistente.Area;

            double tiempoTotal = metrosCuadrados * horasPorMetroCuadrado;
            int trabajadores = ((int)metrosCuadrados / 10) * 2;
            tiempoTotal += trabajadores * horasPorMetroCuadrado;

            double costoTotal = tiempoTotal * 40000;
            
            if ( habitante.Dinero < costoTotal)
            {
                Console.WriteLine($"El habitante {habitante.Nombre} no tiene suficiente dinero para pagar el trabajo de remodelación.");
                return;            
            }
            habitante.Pagar(costoTotal);
            
            DateTime localDate = DateTime.Now;
            DateTime newDate = localDate.AddHours(1.5 * metrosCuadrados);
            String[] cultureNames = { "es-CO" };

            foreach (var cultureName in cultureNames)
            {
                var culture = new CultureInfo(cultureName);
                Console.WriteLine("-----------------------------------------------------------------------");

                Console.WriteLine("{0}:", culture.NativeName);

                Console.WriteLine("-----------------------------------------------------------------------");

                Console.WriteLine($"Tiempo estimado para acabar de añadir habitación: {tiempoTotal} hora/s");

                Console.WriteLine("-----------------------------------------------------------------------");

                Console.WriteLine("Los remodeladores terminaron de agregar la habitación a las: {0}, {1:G}",
                                      newDate.ToString(culture), newDate.Kind);
                Console.WriteLine("-----------------------------------------------------------------------");
                Console.WriteLine($"Saldo de {habitante.Nombre}: {habitante.Dinero}");

            }

        }
        public void decorar_habitacion(Habitacion habitacion, Habitante habitante)
        {
            double costoTotalDecoracion = 0;
            List<Muebles> opcionesMuebles = new List<Muebles>
            {
                new Lampara("Lampara de techo", 5000),
                new Sofa("Sofa grande", 1500),
                new Cama("Cama de agua", 2000)
            };

            if (habitacion.GetMuebles().Count >= Habitacion.LimiteMuebles)
            {
                Console.WriteLine($"La habitación {habitacion.Nombre} ya está llena de muebles. No se pueden agregar más.");
                return;
            }
            Console.WriteLine("Opciones de muebles disponibles:");
            for (int i = 0; i < opcionesMuebles.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {opcionesMuebles[i].Nombre} - Precio: ${opcionesMuebles[i].GetCosto()}");
            }

            
            Console.WriteLine("Elija los números de los muebles que desea agregar (separados por comas):");
            string inputMuebles = Console.ReadLine();
            string[] numerosMuebles = inputMuebles.Split(',');

            foreach (string numeroMueble in numerosMuebles)
            {
                if (int.TryParse(numeroMueble.Trim(), out int indiceMueble) && indiceMueble >= 1 && indiceMueble <= opcionesMuebles.Count)
                {
                    Muebles muebleElegido = opcionesMuebles[indiceMueble - 1];
                    opcionesMuebles.Add(muebleElegido);
                    costoTotalDecoracion += muebleElegido.GetCosto();
                }
                else
                {
                    Console.WriteLine($"Opción inválida: {numeroMueble}");
                }
            }

            if (habitante.Pagar(costoTotalDecoracion))
            {
                foreach (Muebles muebleElegido in opcionesMuebles)
                {
                    habitacion.AgregarMueble(muebleElegido);
                }

                DateTime localDate = DateTime.Now;
                DateTime newDate = localDate.AddHours(0.5 * opcionesMuebles.Count);

                
                calcular_tiempo_decorar_habitacion(newDate, habitante);
            }
            else
            {
                Console.WriteLine($"El habitante {habitante.Nombre} no tiene suficiente dinero para decorar la habitación.");
            }
        }


        private static void calcular_tiempo_decorar_habitacion(DateTime newDate, Habitante habitante)
        {
            String[] cultureNames = { "es-CO" };

            foreach (var cultureName in cultureNames)
            {
                var culture = new CultureInfo(cultureName);
                Console.WriteLine("-----------------------------------------------------------------------");
                Console.WriteLine("{0}:", culture.NativeName);
                Console.WriteLine("Los remodeladores terminaron de decorar la habitación a las: {0}, {1:G}",
                                  newDate.ToString(culture), newDate.Kind);
                Console.WriteLine($"Saldo de {habitante.Nombre}: ${habitante.Dinero}");
            }
        }

    }
}

