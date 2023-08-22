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
            Casa casita_1 = new Casa(6,6);
            CleanCode empresa = new CleanCode(5);
            Habitacion cuarto = new Habitacion("cuarto", 10);
            Habitante pepe = new Habitante("pepe");
            Console.WriteLine(cuarto.lista_personas);
            Console.WriteLine(cuarto.verificar_ocupacion());
            Console.WriteLine(cuarto.lista_personas.Count);
            casita_1.MostrarMatriz();
            casita_1.ModificarValor(0, 0, cuarto);
            casita_1.MostrarMatriz();
            Console.WriteLine(casita_1.Trabajar_trabajant(2, 0));
            casita_1.MostrarMatriz();
            casita_1.MostrarMatriz();
            Console.WriteLine("-----------------------------");
            Habitacion cocina = new Habitacion("cocinaaaa", 15);
            Habitacion baño = new Habitacion("baño", 15);
            Habitacion vestier = new Habitacion("vestier", 15);
            casita_1.ModificarValor(0, 1, baño);
            pepe.meter(baño);
            casita_1.ampliar_habitacion(cuarto, 10);





        }
    }

}