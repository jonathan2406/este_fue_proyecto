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
            Casa casa = new Casa(2, 2);

            Habitacion habitacion1 = new Habitacion("Sala", 20);
            Habitacion habitacion2 = new Habitacion("Dormitorio", 15);

            Persona persona1 = new Persona("Lasso");
            Persona persona2 = new Persona("Maradona");

            persona1.meter(habitacion1);
            persona2.meter(habitacion2);

            casa.MostrarMatriz();

            persona2.meter(habitacion1);


            Console.WriteLine("--------------------------------------");


            habitacion1.mostrar_personas();


        }
    }

}