using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace este_fue_proyecto
{
    internal class Remodelador
    {
        bool estado_ocupacion = true;
        int costo_hora = 50000;

        public bool get_estado_ocupacion()
        {
            return estado_ocupacion;
        }
        public int get_costo_hora()
        {
            return costo_hora;
        }
        void set_estado_ocupacion(bool nuevo_estado)
        {
            estado_ocupacion = nuevo_estado;
        }
        void set_costo_hora(int nuevo_valor)
        {
            costo_hora = nuevo_valor;
        }
    }
}
