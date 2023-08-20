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
        public List<Remodelador> lista_remodeladores = new List<Remodelador> ();
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
            for (int i = 0; i <= numero_trabajadores; i++)
            {
                Remodelador remodelador_i = new Remodelador();
                meter_lista_trabajadores(remodelador_i);
            }
        }
        public List<Remodelador> get_lista_remodeladores()
        {
            return lista_remodeladores;
        }
    }
}
