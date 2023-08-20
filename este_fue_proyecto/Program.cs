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
            CleanCode empresa = new CleanCode(4);
            Console.WriteLine(empresa.get_lista_remodeladores().Count);
            Casa casita = new Casa(1, 1);
            Habitacion eo = new Habitacion("sala", 10);
            casita.ModificarValor(3, 3, eo);

        }
    }

}