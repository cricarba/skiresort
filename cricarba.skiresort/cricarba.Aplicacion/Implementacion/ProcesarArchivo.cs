using cricarba.Aplicacion.Definicion;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cricarba.Aplicacion.Implementacion
{
    public class ProcesarArchivo : IProcesarArchivo<int>
    {
        public int[,] CargarMatrizDesdeArchivo(string contenidoArchivo)
        {

            var arregloNumeros = contenidoArchivo.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
            int[] listaNumeros = Array.ConvertAll(arregloNumeros, num => int.Parse(num));
            if (listaNumeros.Any())
            {
                var ancho = listaNumeros.FirstOrDefault();
                var alto = listaNumeros.Skip(1)?.First();
                if (ancho > 0 && alto != null)
                    return ConvertirEnMatriz(ancho, alto.Value, listaNumeros.Skip(2));
            }
            return null;
        }

        private T[,] ConvertirEnMatriz<T>(int ancho, int alto, IEnumerable<T> listaNumeros)
        {
            if (ancho > 0 && alto > 0)
            {
                T[,] ret = new T[ancho, alto];
                Buffer.BlockCopy(listaNumeros.ToArray(), 0, ret, 0, (alto * ancho) * sizeof(int));
                return ret;
            }
            return null;
        }
    }
}
