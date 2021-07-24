using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncionesLINQ
{
    public class FuncionesLinq
    {
        public IEnumerable<string> ObtenerProvinciasQueEmpiezanConDeterminadasLetras(IEnumerable<string> provincias)
        {
            return provincias.Where(p => p.StartsWith("S") || p.StartsWith("T"));
        }

        public IEnumerable<int> ObtenerNumerosMayoresA20(IEnumerable<int> numeros)
        {
            return numeros.Where(n => n > 20);
        }

        public IEnumerable<int> ObtenerCodigoPostalDeCiudadesQueTenganEnSuNombreTresCarateresDeterminados(IEnumerable<Ciudad> ciudades, string ciudad)
        {
            return ciudades.Where(c => c.Nombre.ToLower().Contains(ciudad.ToLower())).Select(c => c.CodigoPostal);
        }

        public IEnumerable<Empleado> AgregarEmpleadoListaDevolviendolaOrdenadaPorSueldo(IEnumerable<Empleado> empleados, IEnumerable<Empleado> empleadosParaAgregar, string order)
        {
            var empleadosUpdated = empleados.Union(empleadosParaAgregar);

            return order == "ASC" ? empleadosUpdated.OrderBy(e => e.Sueldo) : empleadosUpdated.OrderByDescending(e => e.Sueldo);
        }
    }
}
