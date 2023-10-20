using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_RH
{
    internal class Empleado
    {
        public string Cédula;
        public string Nombre;
        public string Dirección;
        public string Teléfono;
        public double Salario;

        public Empleado(string cédula, string nombre, string dirección, string teléfono, double salario)
        {
            Cédula = cédula;
            Nombre = nombre;
            Dirección = dirección;
            Teléfono = teléfono;
            Salario = salario;
        }

        public void MostrarInformación()
        {
            Console.WriteLine("Cédula: " + Cédula);
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Dirección: " + Dirección);
            Console.WriteLine("Teléfono: " + Teléfono);
            Console.WriteLine("Salario: " + Salario.ToString("C", CultureInfo.CurrentCulture));
        }
    }
}

