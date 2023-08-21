using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace este_fue_proyecto
{
    public class Muebles
    {
        public string Nombre { get; set; }
        private bool estado;
        private double costo;

        public Muebles(string nombre, double precio)
        {
            Nombre = nombre;
            costo = precio;
            estado = true;
        }

        public bool GetEstado()
        {
            return estado;
        }

        public void SetEstado(bool nuevoEstado)
        {
            estado = nuevoEstado;
        }

        public void SetEstadoAleatorio()
        {
            Random random = new Random();
            estado = random.NextDouble() < 0.5;
        }

        public double GetCosto()
        {
            return costo;
        }

        public void SetCosto(double nuevoCosto)
        {
            costo = nuevoCosto;
        }
    }

}
