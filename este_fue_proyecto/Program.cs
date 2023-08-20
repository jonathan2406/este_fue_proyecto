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
            Console.WriteLine(empresa.lista_remodeladores[4].get_estado_ocupacion());

        }
    }

}