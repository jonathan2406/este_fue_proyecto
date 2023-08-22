using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace este_fue_proyecto
{
    public class Persona
    {
        public string Nombre { get; set; }
        private Habitacion habitacionActual;
        public Habitacion HabitacionAsignada { get; private set; }

        public Persona(string nombre)
        {
            Nombre = nombre;
        }

        public void meter(Habitacion habitacion)
        {
            if (habitacionActual != null)
            {
                habitacionActual.QuitarPersona(this);
            }
            habitacion.AgregarPersona(this);
            habitacionActual = habitacion;
            Console.WriteLine($"{Nombre} ha sido agregado a: {habitacion.Nombre}");

        }

        public void quitar(Habitacion habitacion)
        {
            habitacion.QuitarPersona(this);
            Console.WriteLine($"{Nombre} se ha quitado de: {habitacion.Nombre}");
          
        }
    }
}
