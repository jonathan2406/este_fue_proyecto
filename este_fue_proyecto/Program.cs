using este_fue_proyecto;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading;

namespace este_fue_proyecto
{
    class Program
    {
        static void Main()
        {
            /*
            Casa casita_1 = new Casa(5, 5);
            CleanCode empresa = new CleanCode(5);
            Habitacion cuarto = new Habitacion("cuarto", 10);
            Habitante pepe = new Habitante("pepe");
            Remodelador remodelador1 = new Remodelador();
            pepe.meter(cuarto);
            Console.WriteLine(cuarto.lista_personas);
            Console.WriteLine(cuarto.verificar_ocupacion());
            Console.WriteLine(cuarto.lista_personas.Count);
            casita_1.MostrarMatriz();
            casita_1.ModificarValor(0, 0, cuarto);
            casita_1.MostrarMatriz();

            TimeSpan tiempoNuevaHabitacion1 = remodelador1.calcular_tiempo_nueva_habitacion(cuarto);
            Console.WriteLine($"Tiempo estimado para añadir nueva habitación: {tiempoNuevaHabitacion1.TotalSeconds} segundos");
            

            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine(casita_1.Trabajar_trabajant(2, 0));
            empresa.get_lista_remodeladores()[0].añadir_habitacion("cuarto", casita_1, 10, 10, 15);
            casita_1.MostrarMatriz();
            empresa.get_lista_remodeladores()[0].añadir_habitacion("cuarto", casita_1, 10, 8, 25);
            casita_1.MostrarMatriz();
            */


           
            Habitacion habitacion1 = new Habitacion("Sala", 20);
            Habitacion habitacion2 = new Habitacion("Dormitorio", 15);

            Persona persona1 = new Persona("Lasso");
            Persona persona2 = new Persona("Maradona");

            Lampara lampara = new Lampara("Lampara de mesa", 50);
            Cama cama = new Cama("La mejor cama de todo el mundo", 444);
            Sofa sofa = new Sofa("Sofa.", 4);

            Remodelador remodelador = new Remodelador();
            /*
            TimeSpan tiempoNuevaHabitacion = remodelador.calcular_tiempo_nueva_habitacion(cuarto);
            Console.WriteLine($"Tiempo estimado para añadir nueva habitación: {tiempoNuevaHabitacion.TotalSeconds} segundos");
            */

           habitacion1.AgregarMueble(lampara);

            Console.WriteLine("-----------------------------------");


            habitacion1.AgregarMueble(cama);

            Console.WriteLine("-----------------------------------");

            habitacion1.AgregarMueble(sofa);

            Console.WriteLine("-----------------------------------");
           
          
            habitacion1.mostrar_muebles();

            Console.WriteLine("---------------------------------------------");


            Console.WriteLine("----------------------------------------------------");
                
            persona1.meter(habitacion1);

            Console.WriteLine("------------------------------------------");

            habitacion1.mostrar_personas();

            Console.WriteLine("---------------------------------------------------------");

            TimeSpan tiempo_reaccion = remodelador.calcular_tiempo_arreglo_habitacion(habitacion1);
            Console.WriteLine($"Tiempo estimado de reparación: {tiempo_reaccion.TotalSeconds} segundos.");

            remodelador.reparar_habitacion(habitacion1);


            Console.WriteLine("----------------------------------------------------------------");


            habitacion1.mostrar_muebles();

            Console.WriteLine("------------------------------------------------------------------");

            persona1.quitar(habitacion1);

            
            
            
        }
    }

}