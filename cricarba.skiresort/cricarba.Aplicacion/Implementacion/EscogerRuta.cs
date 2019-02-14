using cricarba.Aplicacion.Definicion;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cricarba.Aplicacion.Implementacion
{
    public class EscogerRuta : IEscogerRuta
    {
        public List<int> EscogerMejorRuta(List<List<int>> rutas)
        {
            var mejorRuta = rutas.FirstOrDefault();
            var largoMejorRuta = mejorRuta.Count;
            var descensoMejorRuta = mejorRuta.First() - mejorRuta.Last();
            foreach (var ruta in rutas.Skip(1))
            {

                var largoRutaActual = ruta.Count;
                if (largoRutaActual > largoMejorRuta)
                {
                    mejorRuta = ruta;
                    largoMejorRuta = largoRutaActual;
                }
                else if (largoRutaActual == largoMejorRuta)
                {
                    var descensoRuta = ruta.First() - ruta.Last();
                    if (descensoRuta > descensoMejorRuta)
                    {
                        mejorRuta = ruta;
                        largoMejorRuta = largoRutaActual;
                        descensoMejorRuta = descensoRuta;
                    }
                }

            }
            Console.WriteLine($"Length of calculated path: {largoMejorRuta}");
            Console.WriteLine($"Drop of calculated path: {descensoMejorRuta}");
            Console.WriteLine($"Calculated path: {string.Join("-", mejorRuta)}");

            return mejorRuta;
        }
    }
}
