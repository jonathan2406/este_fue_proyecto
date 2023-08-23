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

            Casa casita = new Casa(2,2);
            casita.MostrarMatriz();
            Habitante habitante_1 = new Habitante("pepe");
            Habitacion dungeon = casita.añadir_habitacion("dungeon", 7,7 ,45);
            habitante_1.meter(dungeon);
            Console.WriteLine(dungeon.lista_personas);
            casita.añadir_habitacion("salita", 6, 5, 55);
        }
    }

}