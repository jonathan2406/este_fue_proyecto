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
            Consola consola = new Consola();

            consola.menu(casita, pepe, empresa);



            
            
            
        }
    }

}