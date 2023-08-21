using este_fue_proyecto;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace este_fue_proyecto
{
    class Program
    {
        static void Main()
        {
            Casa casita_1 = new Casa(5,5);
            CleanCode empresa = new CleanCode(5);
            Habitacion cuarto = new Habitacion("cuarto", 10);
            Habitante pepe = new Habitante("pepe");
            pepe.meter(cuarto);
            Console.WriteLine(cuarto.lista_personas);
            Console.WriteLine(cuarto.verificar_ocupacion());
            Console.WriteLine(cuarto.lista_personas.Count);
            casita_1.MostrarMatriz();
            casita_1.ModificarValor(0, 0, cuarto);
            casita_1.MostrarMatriz();
            Console.WriteLine(casita_1.Trabajar_trabajant(2,0));
            empresa.get_lista_remodeladores()[0].añadir_habitacion("cuarto", casita_1, 10,10,15);
            casita_1.MostrarMatriz();
            empresa.get_lista_remodeladores()[0].añadir_habitacion("cuarto", casita_1, 10,8, 25);
            casita_1.MostrarMatriz();


            /*
            Habitacion habitacion1 = new Habitacion("Sala", 20);
            Habitacion habitacion2 = new Habitacion("Dormitorio", 15);

            Persona persona1 = new Persona("Lasso");
            Persona persona2 = new Persona("Maradona");

            Lampara lampara = new Lampara("Lampara de mesa", 50);
            Cama cama = new Cama("La mejor cama de todo el mundo", 444);
            Sofa sofa = new Sofa("Sofa.", 4);

            habitacion1.AgregarMueble(lampara);

            Console.WriteLine("-----------------------------------");


            habitacion1.AgregarMueble(cama);

            Console.WriteLine("-----------------------------------");

            habitacion1.AgregarMueble(sofa);

            Console.WriteLine("-----------------------------------");
            

            habitacion1.mostrar_muebles();

            Console.WriteLine($"Estado de lámpara: {lampara.GetEstado()}");
            persona1.meter(habitacion1);

            Console.WriteLine("------------------------------------------");


            persona2.meter(habitacion2);

            Console.WriteLine("------------------------------------------");


            casa.MostrarMatriz();

            Console.WriteLine("------------------------------------------");

            persona2.meter(habitacion1);


            Console.WriteLine("--------------------------------------");


            habitacion1.mostrar_personas();

            Console.WriteLine("------------------------------------------");



                 habitacion2.mostrar_personas();

            Console.WriteLine("------------------------------------------");

            habitacion1.mostrar_muebles();
            */
        }
    }

}