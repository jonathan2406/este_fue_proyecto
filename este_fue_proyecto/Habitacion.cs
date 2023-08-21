using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace este_fue_proyecto
{
    public class Habitacion
    {
        public string Nombre { get; set; }
        public double Area { get; set; }
        private List<Muebles> lista_muebles;
        public List<Persona> lista_personas;
        private Habitante habitante_principal;
 
 

        public Habitacion(string nombre, double area)
        {
            Nombre = nombre;
            Area = area;
            lista_muebles = new List<Muebles>();
            lista_personas = new List<Persona>();

        }

        public void AgregarHabitante(Habitante habitante)
        {
            if (habitante_principal == null)
            {
                habitante_principal = habitante;
                Console.WriteLine($"{habitante.Nombre} es el habitante principal de la habitación {Nombre}.");

            }
            else
            {
                Console.WriteLine($"El habitante principal de la habitación es: {Nombre}.");
            }
        }

        public void mostrar_personas()
        {
            if (lista_personas.Count > 0)
            {
                Console.WriteLine($"Habitantes en {Nombre}:");
                foreach (Persona persona in lista_personas)
                {
                    Console.WriteLine($"-- {persona.Nombre}");
                }
            }
            else
            {
                Console.WriteLine($"No hay habitantes en {Nombre}.");
            }
        }
        public void AgregarMueble(Muebles mueble)
        {
            lista_muebles.Add(mueble);
            Console.WriteLine($"{mueble.Nombre} ha sido agregado a: {Nombre}.");

        }

        public void mostrar_muebles()
        {
            if (lista_muebles.Count > 0)
            {
                Console.WriteLine($"Muebles en {Nombre}:");
                foreach (Muebles mueble in lista_muebles)
                {
                    Console.WriteLine($"-- {mueble.Nombre}");
                }
            }
            else
            {
                Console.WriteLine($"No hay muebles en {Nombre}.");
            }

            foreach (Muebles mueble in lista_muebles)
            {
                
                Console.WriteLine($"-- {mueble.Nombre} - Estado: {(mueble.GetEstado() ? "Bueno" : "Malísimo")}");
            }
        }

        public List<Muebles> GetMuebles()
        {
            return lista_muebles;
        }

        public double get_medidas()
        {
            return Area;
        }

        public void set_medidas(double nuevasMedidas)
        {
            Area = nuevasMedidas;
        }

        public void AgregarPersona(Persona persona)
        {
            lista_personas.Add(persona);

        }

        public void QuitarPersona(Persona persona)
        {
            if (lista_personas.Contains(persona))
            {
                lista_personas.Remove(persona);
                Console.WriteLine($"{persona.Nombre} ha sido removido de la habitación: {Nombre}");

            }

            else
            {
                Console.WriteLine($"{persona.Nombre} no se encuentra en la habitación.");
            }
        }
        public bool verificar_ocupacion()
        {
            if (lista_personas.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}