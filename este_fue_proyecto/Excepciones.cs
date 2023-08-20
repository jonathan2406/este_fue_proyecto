using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace este_fue_proyecto
{


    public class ExcepcionMatriz_valores_erroneos : Exception
    {
        public ExcepcionMatriz_valores_erroneos() 
        {
        }
    }
    internal class ExcepcionMatriz_espacio_ocupado : Exception
    {
        public ExcepcionMatriz_espacio_ocupado() 
        {
        }
    }
}
