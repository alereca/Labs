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
            throw new NotImplementedException();
        }

        public IEnumerable<int> ObtenerCodigoPostalDeCiudadesQueTenganEnSuNombreTresCarateresDeterminados(IEnumerable<Ciudad> ciudades, string ciudad)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Empleado> AgregarEmpleadoListaDevolviendolaOrdenadaPorSueldo(IEnumerable<Empleado> empleados, IEnumerable<Empleado> empleadosParaAgregar, string order)
        {
            throw new NotImplementedException();
        }
    }
}
