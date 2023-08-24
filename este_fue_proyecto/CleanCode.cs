using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
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
            for (int i = 0; i < numero_trabajadores; i++)
            {
                Remodelador remodelador_i = new Remodelador($"remodelador_{i}");
                meter_lista_trabajadores(remodelador_i);
            }
        }
        public List<Remodelador> get_lista_remodeladores()
        {
            return lista_remodeladores;
        }

        public void imprimir_lista_trabajadores()
        {
            foreach (Remodelador iteracion in lista_remodeladores)
            {
                Console.WriteLine($"remodelador imprimir = {iteracion.Nombre}");
            }
        }
        
        public List<Remodelador> coger_remodelador_desocupado()
        {
            List<Remodelador> lista_desocupados = new List<Remodelador> { };
            for (int i = 0; i < numero_trabajadores; i++)
            {
                if (lista_remodeladores[i].verificar_disponibilidad_trabajador() == true)
                {
                    lista_desocupados.Add(lista_remodeladores[i]);
                }
            }
            return lista_desocupados;
        }



    }
}
