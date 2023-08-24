using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace este_fue_proyecto
{
    internal class Consola
    {
        Habitacion[,] matriz_obtenida;

        public void menu(Casa casa, Habitante persona_solicitante, CleanCode empresa)
        {
            matriz_obtenida = casa.get_plano();
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
                    List<Remodelador> remodeladores_para_construir = empresa.coger_remodelador_desocupado();
                    if (remodeladores_para_construir.Count >= trabajadores)
                    {
                        Console.WriteLine("tenemos todos los trabajadores para hacer esta peticion!!!!!");
                    }
                    else
                    {
                        casa.set_matriz(matriz_obtenida);
                        casa.set_matriz_vieja(matriz_obtenida);
                        Console.WriteLine("nos faltan trabajadores para hacer esa accion, muchos ocupados ya");
                        goto primer_while;

                    }
                    acumulador_horas += tiempoTotal;

                    // vamos a poner un tiempo ficticcio para que los trabajadores se puedan utilizar despues

                    int tiempo_simulacion = 20;
                    for (int i = 0; i < trabajadores; i++)
                    {
                        remodeladores_para_construir[i].set_hora_ocupacion(DateTime.Now.AddSeconds(tiempo_simulacion));
                    }

                    Console.WriteLine("el plano antes era");
                    MostrarMatriz_trabajador();
                    Console.WriteLine("el plano quedo asi:");
                    casa.MostrarMatriz();
                    Console.WriteLine("----------------");
                    Console.WriteLine($"el tiempo necesario para realizar esta obra es de:  {tiempoTotal} horas" +
                        $"\nse necesitaron {trabajadores}" +
                        $"\nel costo total de esta obra es de {costoTotal}" +
                        $"\nquedan {remodeladores_para_construir.Count - trabajadores} para usar");

                }
                else if (numero_decision == 2)
                {
                    Console.WriteLine("\n-- Ingrese el número de la fila donde está ubicada la habitación:    ");
                    int fila = int.Parse(Console.ReadLine());
                    Console.WriteLine("\n-- Ingrese el número de columna donde está ubicada la habitación:    ");
                    int columna = int.Parse(Console.ReadLine());
                    Console.WriteLine("\n-- ingrese el numero de metros que desea ampliar:     ");
                    int metros = int.Parse(Console.ReadLine());

                    if (casa.ampliar_habitacion(casa.get_plano()[fila, columna], metros) == false)
                    {
                        Console.WriteLine("-- No se puede hacer esta acción .......");
                        goto primer_while;
                    }
                    // ---------------------------------------------------------------------------------------
                    //calculo costo y numero de trabajadores
                    double horasPorMetroCuadrado = 1;
                    double metrosCuadrados = metros;
                    double tiempoTotal = metrosCuadrados * horasPorMetroCuadrado;
                    int trabajadores = (int)metrosCuadrados / 10;
                    tiempoTotal += trabajadores * horasPorMetroCuadrado;
                    double costoTotal = tiempoTotal * 40000;
                    List<Remodelador> remodeladores_para_construir = empresa.coger_remodelador_desocupado();
                    if (remodeladores_para_construir.Count >= trabajadores)
                    {
                        Console.WriteLine("tenemos todos los trabajadores para hacer esta peticion!!!!!");
                    }
                    else
                    {
                        casa.set_matriz(matriz_obtenida);
                        casa.set_matriz_vieja(matriz_obtenida);
                        Console.WriteLine("nos faltan trabajadores para hacer esa accion, muchos ocupados ya");
                        goto primer_while;

                    }

                    // vamos a poner un tiempo ficticcio para que los trabajadores se puedan utilizar despues

                    int tiempo_simulacion = 20;
                    for (int i = 0; i < trabajadores; i++)
                    {
                        remodeladores_para_construir[i].set_hora_ocupacion(DateTime.Now.AddSeconds(tiempo_simulacion));
                    }

                    Console.WriteLine("el plano antes era");
                    MostrarMatriz_trabajador();
                    Console.WriteLine("el plano quedo asi:");
                    casa.MostrarMatriz();
                    Console.WriteLine("----------------");
                    Console.WriteLine($"el tiempo necesario para realizar esta obra es de:  {tiempoTotal} horas" +
                        $"\nse necesitaron {trabajadores}" +
                        $"\nel costo total de esta obra es de {costoTotal}" +
                        $"\nquedan {remodeladores_para_construir.Count - trabajadores} para usar");


                }
                else if (numero_decision == 3)
                {

                }
            }
        }

        public void MostrarMatriz_trabajador()
        {
            for (int i = 0; i < matriz_obtenida.GetLength(0); i++)
            {
                for (int j = 0; j < matriz_obtenida.GetLength(1); j++)
                {
                    if (matriz_obtenida[i, j] != null)
                    {
                        Console.Write(matriz_obtenida[i, j].Nombre + " ");
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
    }
}
