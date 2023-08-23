using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace este_fue_proyecto
{
    public class Habitante : Persona
    {
        public double Dinero { get; private set; }
        public Habitacion HabitacionAsignada { get; set; } 

        public Habitante(string nombre) : base(nombre) 
        {
            Dinero = 1000000;
        }

        public bool Pagar(double cantidad)
        {
            if (Dinero >= cantidad)
            {
                Console.WriteLine("-----------------------------------------------------------------------");
                
                Console.WriteLine($"La cantidad de dinero que tienes es: {Dinero}");

                Console.WriteLine("-----------------------------------------------------------------------");

                Dinero -= cantidad;
                Console.WriteLine($"Se te ha descontado ({Nombre}) {cantidad} de tu dinero, tu dinero actual es: {Dinero}.");
                return true;
            }
            else
            {
                Console.WriteLine("No tienes suficiente dinero para pagar.");
                return false;
            }
        }

        void peticion_inicial()
        {

        }

    }

}
