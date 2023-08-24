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
    internal class CleanCode
    {
        Habitacion[,] matriz_vieja_trabajador;
        Habitacion[,] backup_matriz;
        protected List<Remodelador> lista_remodeladores = new List<Remodelador> ();
        int numero_trabajadores;
        
        public CleanCode(int n_trabajadores)
        {
            this.numero_trabajadores = n_trabajadores;
            crear_trabajadores();
        }

        void meter_lista_trabajadores(Remodelador remodelador_a_meter)
        {
            lista_remodeladores.Add(remodelador_a_meter);
        }
        void crear_trabajadores()
        {
            for (int i = 0; i < numero_trabajadores; i++)
            {
                Remodelador remodelador_i = new Remodelador($"remodelador_{i}");
                remodelador_i.hora_ocupacion = DateTime.Now;
                meter_lista_trabajadores(remodelador_i);
            }
        }
        public List<Remodelador> get_lista_remodeladores()
        {
            return lista_remodeladores;
        }
        
        Remodelador coger_remodelador_desocupado()
        {
            foreach (Remodelador iteracion in lista_remodeladores)
            {
                if (DateTime.Compare(iteracion.hora_ocupacion,DateTime.Now) <  0)
                {
                    return iteracion;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        public void MostrarMatriz_trabajador()
        {
            for (int i = 0; i < matriz_vieja_trabajador.GetLength(0); i++)
            {
                for (int j = 0; j < matriz_vieja_trabajador.GetLength(1); j++)
                {
                    if (matriz_vieja_trabajador[i, j] != null)
                    {
                        Console.Write(matriz_vieja_trabajador[i, j].Nombre + " ");
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
        public void menu(Casa casa, Habitante persona_solicitante)
        {
            matriz_vieja_trabajador = casa.get_plano();
            MostrarMatriz_trabajador();
            int costo_trabajo = 0;
            double acumulador_horas = 0;
            Console.WriteLine("Bienvenido a intervenciones clean code");
            Console.WriteLine("--------------------------------------------");

            primer_while:
            while (true)
            {
                Console.WriteLine("Que servicio quiere realizar? \n ");
                Console.WriteLine("presione 1 para contruir una habitacion............" +
                    "\npresione 2 para ampliar una habitacion............" +
                    "\npresione 3 para decorar habitacion............" +
                    "\npresione 4 para reparar habitacion............" +
                    "\npresione 5 para salir----------------\n");
                string decision = Console.ReadLine();
                if (int.TryParse(decision, out int numero_decision) && numero_decision == 1 || numero_decision == 2 || numero_decision == 3 || numero_decision == 4 || numero_decision == 5)
                {
                    if (numero_decision == 5)
                    {
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("ingrese un numero valido porfavor");
                    goto primer_while;
                }
                if (numero_decision == 1)
                {
                    Console.WriteLine("nombre que desea poner a la habitacion:       ");
                    string nombre_habitacion = Console.ReadLine();
                    Console.WriteLine("\ningrese el numero de la fila donde desea poner:    ");
                    int fila = int.Parse(Console.ReadLine());
                    Console.WriteLine("\ningrese el numero de columna donde desea poner:    ");
                    int columna = int.Parse(Console.ReadLine());
                    Console.WriteLine("\ningrese el numero de metros que desea la habitacion:     ");
                    int metros = int.Parse(Console.ReadLine());

                    Habitacion nueva_habitacion = casa.añadir_habitacion(nombre_habitacion, fila, columna, metros);
                    Console.WriteLine("se contruyo");
                    MostrarMatriz_trabajador();
                    if (nueva_habitacion != null)
                    {
                        persona_solicitante.HabitacionAsignada = nueva_habitacion;
                    }
                    else
                    {
                        Console.WriteLine("no se puede hacer eso........");
                        goto primer_while;
                    }

                    //calculo costo y numero de trabajadores
                    double horasPorMetroCuadrado = 1.5;
                    double metrosCuadrados = metros;
                    double tiempoTotal = metrosCuadrados * horasPorMetroCuadrado;
                    int trabajadores = ((int)metrosCuadrados / 10) * 2;
                    tiempoTotal += trabajadores * horasPorMetroCuadrado;
                    double costoTotal = tiempoTotal * 40000;
                    List<Remodelador> remodeladores_para_construir = new List<Remodelador> { };
                    Console.WriteLine($"el valor de remodeladores despues de crearse es: {remodeladores_para_construir.Count}");
                    for (int i = 0; i < lista_remodeladores.Count; i++)
                    {
                        Remodelador resultado = coger_remodelador_desocupado();
                        Console.WriteLine($"el resultado de desocupado {resultado}");
                        if (resultado == null)
                        {
                            casa.set_matriz(matriz_vieja_trabajador);
                            casa.set_matriz_vieja(matriz_vieja_trabajador);
                            Console.WriteLine("nos faltan trabajadores para hacer esa accion, muchos ocupados ya");
                            goto primer_while;
                        }
                        else
                        {
                            remodeladores_para_construir.Add(resultado);
                        }
                    }
                    Console.WriteLine($"el valor de remodeladores listos es: {remodeladores_para_construir.Count}");
                    Console.WriteLine($"el valor de trabajadores es: {trabajadores}");
                    if (remodeladores_para_construir.Count <= trabajadores)
                    {
                        Console.WriteLine("tenemos todos los trabajadores para hacer esta peticion!!!!!");
                    }
                    else
                    {
                        casa.set_matriz(matriz_vieja_trabajador);
                        casa.set_matriz_vieja(matriz_vieja_trabajador);
                        Console.WriteLine("nos faltan trabajadores para hacer esa accion, muchos ocupados ya");
                        goto primer_while;

                    }
                    acumulador_horas += tiempoTotal;

                    // vamos a poner un tiempo ficticcio para que los trabajadores se puedan utilizar despues

                    int tiempo_simulacion = (metros/10) * 5;
                    foreach (Remodelador iteracion in remodeladores_para_construir)
                    {
                        Console.WriteLine($"la hora de antes de sumar es {iteracion.hora_ocupacion}");
                        iteracion.hora_ocupacion = iteracion.hora_ocupacion.AddSeconds(tiempo_simulacion);
                        Console.WriteLine($"la hora de despues de sumar es {iteracion.hora_ocupacion}");
                    }
                    Console.WriteLine("fin interaccionnnnnnnnnnnnnnnnnnnnnnnnnn");
                    

                    casa.MostrarMatriz();



                }
                else if (numero_decision == 2)
                {
                    Console.WriteLine("\ningrese el numero de la fila donde esta hubicada la habitacion:    ");
                    int fila = int.Parse(Console.ReadLine());
                    Console.WriteLine("\ningrese el numero de columna donde esta hubicada la habitacion:    ");
                    int columna = int.Parse(Console.ReadLine());
                    Console.WriteLine("\ningrese el numero de metros que desea ampliar:     ");
                    int metros = int.Parse(Console.ReadLine());

                    if (casa.ampliar_habitacion(casa.get_plano()[fila, columna], metros) == false)
                    {
                        Console.WriteLine("no se puede hacer esta accion .......");
                        goto primer_while;
                    }
                }
                else if (numero_decision == 3)
                {
                    Console.WriteLine("Seleccione la habitación que desea decorar:");
                    casa.MostrarMatriz();
                    Console.WriteLine("Ingrese el número de la fila:");
                    int fila = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese el número de la columna:");
                    int columna = int.Parse(Console.ReadLine());

                    Remodelador remodelador = coger_remodelador_desocupado();
                    if (remodelador != null)
                    {
                        Habitacion habitacionSeleccionada = casa.get_plano()[fila, columna];
                        remodelador.decorar_habitacion(habitacionSeleccionada, persona_solicitante);

                        matriz_vieja_trabajador = casa.get_plano();
                        MostrarMatriz_trabajador();
                    }
                    else
                    {
                        Console.WriteLine("No hay remodeladores disponibles en este momento.");
                    }

                }
                else if (numero_decision == 4)
                {
                    Console.WriteLine("\ningrese el numero de la fila donde está ubicada la habitación:    ");
                    int fila = int.Parse(Console.ReadLine());
                    Console.WriteLine("\ningrese el numero de columna donde está ubicada la habitación:    ");
                    int columna = int.Parse(Console.ReadLine());

                    Habitacion habitacionAReparar = casa.get_plano()[fila, columna];
                    if (habitacionAReparar != null)
                    {
                        Remodelador remodelador = new Remodelador("Remodelador 1");  
                        remodelador.reparar_habitacion(habitacionAReparar, persona_solicitante);  
                    }
                    else
                    {
                        Console.WriteLine("La habitación especificada no existe.");
                    }

                }
            }
        }
    }
}
