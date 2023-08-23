using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace este_fue_proyecto
{
    public class Habitante : Persona
    {
        public Habitacion HabitacionAsignada { get; set; } 

        public Habitante(string nombre) : base(nombre) 
        {

        }  

        void peticion_inicial()
        {

        }

    }

}
