using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_RH
{
    internal class Menú
    {
        private Empleado[] empleados;
        private int cantidadEmpleados;
        private int opción;
        private string respuesta;

        public Menú()
        {
            opción = 0;
        }

        public Menú(int maxEmpleados)
        {
            empleados = new Empleado[maxEmpleados];
            cantidadEmpleados = 0;
        }

        public void MostrarMenúPrincipal()
        {
            Console.WriteLine("Menú Principal:");
            Console.WriteLine("1- Agregar Empleados");
            Console.WriteLine("2- Consultar Empleados");
            Console.WriteLine("3- Modificar Empleados");
            Console.WriteLine("4- Borrar Empleados");
            Console.WriteLine("5- Inicializar Arreglos");
            Console.WriteLine("6- Reportes");
            Console.WriteLine("7- Salir");
        }

        public void EjecutarMenú()
        {
            do
            {
                MostrarMenúPrincipal();
                Console.Write("Seleccione una opción: ");
                if (int.TryParse(Console.ReadLine(), out opción))
                {
                    switch (opción)
                    {
                        case 1:
                            AgregarEmpleado();
                            break;
                        case 2:
                            ConsultarEmpleados();
                            break;
                        case 3:
                            ModificarEmpleado();
                            break;
                        case 4:
                            BorrarEmpleado();
                            break;
                        case 5:
                            InicializarArreglos();
                            break;
                        case 6:
                            MostrarMenúReportes();
                            break;
                        case 7:
                            Console.WriteLine("Saliendo del programa. ¡Hasta Pronto!");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
                }
            } while (opción != 7);
        }

        public void AgregarEmpleado()
        {
            do
            {
                if (cantidadEmpleados < empleados.Length)
                {
                    Console.Clear();
                    Console.WriteLine("Agregando un nuevo empleado:");
                    Console.Write("Ingrese la Cédula:");
                    string cedula = Console.ReadLine();
                    Console.Write("Ingrese el Nombre: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese la Dirección: ");
                    string direccion = Console.ReadLine();
                    Console.Write("Ingrese el Teléfono: ");
                    string telefono = Console.ReadLine();
                    double salario;

                    if (double.TryParse(Console.ReadLine(), out salario))
                    {
                        empleados[cantidadEmpleados] = new Empleado(cedula, nombre, direccion, telefono, salario);
                        cantidadEmpleados++;
                        Console.WriteLine("Empleado agregado con éxito.");
                    }
                    else
                    {
                        Console.WriteLine("Salario no válido. Por favor, ingrese un número válido.");
                    }
                    Console.Write("¿Desea agregar otro empleado? (s/n): ");
                    respuesta = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("No se pueden agregar más empleados. Se ha alcanzado el límite.");
                    respuesta = "n";
                }
            } while (respuesta.ToLower() == "s");
        }

        public void ConsultarEmpleados()
        {
            if (cantidadEmpleados == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
                return;
            }

            Console.WriteLine("Listado de Empleados:");
            for (int i = 0; i < cantidadEmpleados; i++)
            {
                Console.WriteLine("Empleado " + (i + 1) + ":");
                empleados[i].MostrarInformación();
            }
        }

        public void ModificarEmpleado()
        {
            if (cantidadEmpleados == 0)
            {
                Console.WriteLine("No hay empleados registrados para modificar.");
                return;
            }

            Console.Write("Ingrese la cédula del empleado que desea modificar: ");
            string cedulaBúsqueda = Console.ReadLine();
            var empleado = empleados.FirstOrDefault(e => e.Cédula == cedulaBúsqueda);

            if (empleado != null)
            {
                Console.WriteLine("Empleado encontrado. Por favor, ingrese los nuevos datos:");
                Console.Write("Nuevo nombre: ");
                string nuevoNombre = Console.ReadLine();
                Console.Write("Nueva dirección: ");
                string nuevaDireccion = Console.ReadLine();
                Console.Write("Nuevo teléfono: ");
                string nuevoTelefono = Console.ReadLine();
                double nuevoSalario;

                if (double.TryParse(Console.ReadLine(), out nuevoSalario))
                {
                    empleado.Nombre = nuevoNombre;
                    empleado.Dirección = nuevaDireccion;
                    empleado.Teléfono = nuevoTelefono;
                    empleado.Salario = nuevoSalario;
                    Console.WriteLine("Empleado modificado con éxito.");
                }
                else
                {
                    Console.WriteLine("Salario no válido. No se realizó la modificación.");
                }
            }
            else
            {
                Console.WriteLine("Empleado no encontrado. No se realizó la modificación.");
            }
        }

        public void BorrarEmpleado()
        {
            if (cantidadEmpleados == 0)
            {
                Console.WriteLine("No hay empleados registrados para borrar.");
                return;
            }

            Console.Write("Ingrese la cédula del empleado que desea borrar: ");
            string cedulaBúsqueda = Console.ReadLine();
            var empleado = empleados.FirstOrDefault(e => e.Cédula == cedulaBúsqueda);

            if (empleado != null)
            {
                for (int i = 0; i < cantidadEmpleados; i++)
                {
                    if (empleados[i] == empleado)
                    {
                        for (int j = i; j < cantidadEmpleados - 1; j++)
                        {
                            empleados[j] = empleados[j + 1];
                        }
                        cantidadEmpleados--;
                        break;
                    }
                }
                Console.WriteLine("Empleado borrado con éxito.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado. No se realizó la eliminación.");
            }
        }

        public void InicializarArreglos()
        {
            empleados = new Empleado[empleados.Length];
            cantidadEmpleados = 0;
            Console.WriteLine("Arreglos inicializados. Todos los datos se han eliminado.");
        }

        public void MostrarMenúReportes()
        {
            int opción;
            do
            {
                Console.WriteLine("Menú de Reportes:");
                Console.WriteLine("1- Consultar empleados con número de cédula.");
                Console.WriteLine("2- Listar todos los empleados ordenados por nombre.");
                Console.WriteLine("3- Calcular y mostrar el promedio de los salarios.");
                Console.WriteLine("4- Calcular y mostrar el salario más alto y el más bajo de todos los empleados.");
                Console.WriteLine("5- Volver al Menú Principal");
                Console.Write("Seleccione una opción: ");
                if (int.TryParse(Console.ReadLine(), out opción))
                {
                    switch (opción)
                    {
                        case 1:
                            ConsultarEmpleadosPorCedula();
                            break;
                        case 2:
                            ListarEmpleadosPorNombre();
                            break;
                        case 3:
                            CalcularPromedioSalarios();
                            break;
                        case 4:
                            CalcularSalariosExtremos();
                            break;
                        case 5:
                            Console.WriteLine("Volviendo al Menú Principal.");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
                }
            } while (opción != 5);
        }

        public void ConsultarEmpleadosPorCedula()
        {
            if (cantidadEmpleados == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
                return;
            }

            Console.Write("Ingrese el número de cédula a buscar: ");
            string cedulaBúsqueda = Console.ReadLine();
            bool encontrado = false;

            Console.WriteLine("Empleados con número de cédula " + cedulaBúsqueda + ":");
            for (int i = 0; i < cantidadEmpleados; i++)
            {
                if (empleados[i].Cédula == cedulaBúsqueda)
                {
                    empleados[i].MostrarInformación();
                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("No se encontró ningún empleado con el número de cédula " + cedulaBúsqueda);
            }
        }

        public void ListarEmpleadosPorNombre()
        {
            if (cantidadEmpleados == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
                return;
            }

            var empleadosOrdenados = empleados.Take(cantidadEmpleados).OrderBy(e => e.Nombre).ToArray();
            Console.WriteLine("Listado de Empleados Ordenados por Nombre:");
            for (int i = 0; i < cantidadEmpleados; i++)
            {
                empleadosOrdenados[i].MostrarInformación();
            }
        }

        public void CalcularPromedioSalarios()
        {
            if (cantidadEmpleados == 0)
            {
                Console.WriteLine("No hay empleados registrados para calcular el promedio de los salarios.");
                return;
            }

            double sumaSalarios = 0;
            for (int i = 0; i < cantidadEmpleados; i++)
            {
                sumaSalarios += empleados[i].Salario;
            }
            double promedioSalarios = sumaSalarios / cantidadEmpleados;
            Console.WriteLine("Promedio de los Salarios: " + promedioSalarios.ToString("C", CultureInfo.CurrentCulture));
        }

        public void CalcularSalariosExtremos()
        {
            if (cantidadEmpleados != 0)
            {
                double salarioMasAlto = empleados.Max(e => e.Salario);
                double salarioMasBajo = empleados.Min(e => e.Salario);

                Console.WriteLine("Salario más alto: " + salarioMasAlto.ToString("C", CultureInfo.CurrentCulture));
                Console.WriteLine("Salario más bajo: " + salarioMasBajo.ToString("C", CultureInfo.CurrentCulture));
            }
            else
            {
                Console.WriteLine("No hay empleados registrados para calcular los salarios extremos.");
            }
        }

    }
}
