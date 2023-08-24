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
            Casa casita = new Casa(5, 5);
            CleanCode empresa = new CleanCode(10);
            Habitante pepe = new Habitante("pepe");

            empresa.menu(casita, pepe);
            /*Casa casita_1 = new Casa(5, 5);
            CleanCode empresa = new CleanCode(5);
            Habitacion cuarto = new Habitacion("Cuarto", 10);
            Habitante HabitanteMain = new Habitante("Lasso");
            Remodelador remodelador1 = new Remodelador("Remodelador1");
            

            Console.WriteLine($"El {cuarto.Nombre} tiene {cuarto.Area} metros cuadrados.");
            
            
            
            remodelador1.calcular_tiempo_nueva_habitacion(cuarto, HabitanteMain);
            
            
            Console.WriteLine(cuarto.lista_personas);
            Console.WriteLine(cuarto.verificar_ocupacion());
            Console.WriteLine($"Cantidad de personas en la habitación : {cuarto.Nombre}, {cuarto.lista_personas.Count}");


            remodelador1.añadir_habitacion(casita_1, HabitanteMain, "Cuarto", 0, 0, 10);
            casita_1.MostrarMatriz();
            

           
            
            
         
            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine(casita_1.Trabajar_trabajant(2, 0));
            empresa.get_lista_remodeladores()[0].añadir_habitacion("cuarto", casita_1, 10, 10, 15);
            casita_1.MostrarMatriz();
            empresa.get_lista_remodeladores()[0].añadir_habitacion("cuarto", casita_1, 10, 8, 25);
            casita_1.MostrarMatriz();
          


           
            Habitacion habitacion1 = new Habitacion("Sala", 20);
            Habitacion habitacion2 = new Habitacion("Dormitorio", 15);

            Persona persona2 = new Persona("Maradona");

            Lampara lampara = new Lampara("Lampara de mesa", 50000);
            Cama cama = new Cama("La mejor cama de todo el mundo", 100000);
            Sofa sofa = new Sofa("Sofa.", 40000);
            Lampara lampara2 = new Lampara("Lampara breve", 50000);
            Cama cama2 = new Cama("Media cama", 2000);
            Sofa sofa2 = new Sofa("Medio sofa sabroso", 2000);

            Remodelador remodelador = new Remodelador("Remodelador1");

            habitacion1.AgregarHabitante(HabitanteMain, habitacion1);
            Console.WriteLine("-----------------------------------------------------------------------");
            
            persona2.meter(habitacion1);

            Console.WriteLine("-----------------------------------------------------------------------");

            habitacion1.mostrar_personas();

            Console.WriteLine("-----------------------------------------------------------------------");


            habitacion1.AgregarMueble(lampara);

            Console.WriteLine("-----------------------------------------------------------------------");


            habitacion1.AgregarMueble(cama);

            Console.WriteLine("-----------------------------------------------------------------------");

            habitacion1.AgregarMueble(sofa);

            Console.WriteLine("-----------------------------------------------------------------------");

            habitacion1.AgregarMueble(lampara2);

            Console.WriteLine("-----------------------------------------------------------------------");

            habitacion1.AgregarMueble(cama2);

            Console.WriteLine("-----------------------------------------------------------------------");

            habitacion1.AgregarMueble(sofa2);
     
            Console.WriteLine("-----------------------------------------------------------------------");

            habitacion1.mostrar_muebles();

            Console.WriteLine("-----------------------------------------------------------------------");


            habitacion1.mostrar_personas();

            Console.WriteLine("-----------------------------------------------------------------------");

            remodelador.calcular_tiempo_arreglo_habitacion(habitacion1);

            Console.WriteLine("-----------------------------------------------------------------------");

            remodelador.reparar_habitacion(habitacion1, HabitanteMain);


            Console.WriteLine("-----------------------------------------------------------------------");


            habitacion1.mostrar_muebles();

            Console.WriteLine("-----------------------------------------------------------------------");

            remodelador.decorar_habitacion(habitacion1, HabitanteMain);
            remodelador.decorar_habitacion(habitacion1, HabitanteMain);

            Console.WriteLine("-----------------------------------------------------------------------");
            habitacion1.mostrar_muebles();


            persona2.quitar(habitacion1);*/

            
            
            
        }
    }

}