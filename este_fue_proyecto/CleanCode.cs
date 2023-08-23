using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace este_fue_proyecto
{
    internal class CleanCode
    {
        protected List<Remodelador> lista_remodeladores = new List<Remodelador> ();
        int numero_trabajadores;
        
        public CleanCode(int n_trabajadores)
        {
            this.numero_trabajadores = n_trabajadores;
            crear_trabajadores();
        }

        void meter_lista_trabajadores(Remodelador remodelador_a_meter)
        {
            lista_remodeladores.Add(remodelador_a_meter);
        }
        void crear_trabajadores()
        {
            for (int i = 1; i <= numero_trabajadores; i++)
            {
                Remodelador remodelador_i = new Remodelador($"remodelador_{i}");
                meter_lista_trabajadores(remodelador_i);
            }
        }
        public List<Remodelador> get_lista_remodeladores()
        {
            return lista_remodeladores;
        }
        public void menu(Casa casa, Habitante persona_solicitante)
        {
            int costo_trabajo = 0;
            Console.WriteLine("Bienvenido a intervenciones clean code");
            Console.WriteLine("--------------------------------------------");

            primer_while:
            while (true)
            {
                Console.WriteLine("Que servicio quiere realizar? \n ");
                Console.WriteLine("presione 1 para contruir una habitacion............" +
                    "\npresione 2 para ampliar una habitacion............" +
                    "\npresione 3 para decorar habitacion............" +
                    "\npresione 4 para reparar habitacion............" +
                    "\n presione 5 para salir----------------\n");
                string decision = Console.ReadLine();
                if (int.TryParse(decision, out int numero_decision) && numero_decision == 1 || numero_decision == 2 || numero_decision == 3 || numero_decision == 4 || numero_decision == 5)
                {
                    if (numero_decision == 5)
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("ingrese un numero valido porfavor");
                    goto primer_while;
                }
                if (numero_decision == 1)
                {

                }

            }
        }
    }
}
