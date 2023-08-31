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
            Habitacion cuarto = new Habitacion("cuarto", 10);
            Consola consola = new Consola();

            Habitante habitante_1 = new Habitante("lasso");
            Habitante habitante_2 = new Habitante("jonathan");
            Habitante habitante_3 = new Habitante("ferederico");
            Habitante habitante_4 = new Habitante("jhon");

            Habitacion sala = casita.añadir_habitacion("sala", 0, 1, 10);
            Habitacion cocina = casita.añadir_habitacion("cocina", 1, 0, 10);
            Habitacion baño = casita.añadir_habitacion("baño", 0, 2, 10);
            Habitacion patio = casita.añadir_habitacion("patio", 3, 3, 10);
            // caso donde hay personas
            habitante_1.meter(sala);
            habitante_2.meter(cocina);
            habitante_3.meter(baño);
            //caso donde no hay
            habitante_1.quitar(sala);
            habitante_2.quitar(cocina);
            consola.menu(casita, pepe, empresa);

            Lampara lampara = new Lampara("Lampara mela", 2000);
            Sofa sofa = new Sofa("Sofa grande", 5000);
            Cama cama = new Cama("Cama grande", 10000);

            sala.AgregarMueble(lampara);










            
            
            
        }
    }

}