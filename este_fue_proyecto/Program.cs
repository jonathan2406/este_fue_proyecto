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
            CleanCode empresa = new CleanCode(10);
            Habitante pepe = new Habitante("pepe");
            Casa casita = new Casa(3, 3);
            empresa.menu(casita, pepe);
        }
    }

}