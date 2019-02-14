using cricarba.Aplicacion.Definicion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace cricarba.Aplicacion.Implementacion
{
    public class GenerarRuta : IGenerarRuta
    {
        private List<List<int>> rutas = new List<List<int>>();
        private int[,] _matriz;
        private int _limite;
        private readonly int _numeroSuperior = 15001;
        public List<List<int>> GenerarRutas(int[,] matriz)
        {
            _matriz = matriz;
            _limite = (int)Math.Sqrt(matriz.Length) - 1;
            var ruta = new List<int>();
            for (int i = 0; i <= _limite; i++)
            {
                for (int j = 0; j <= _limite; j++)
                {
                    ruta = new List<int>();
                    BuscarRuta(i, j, ruta, true);
                }
            }

            return rutas;
        }

        private bool BuscarRuta(int i, int j, List<int> ruta, bool puntiInicial = false)
        {
            var puntoSalida = _matriz[i, j];
            var finRuta = false;
            var rutainicial = new List<int>();
            ruta.Add(puntoSalida);
            rutainicial = Clonar(ruta);            

            var izquierda = j == 0 ? _numeroSuperior : _matriz[i, j - 1];
            if (izquierda < puntoSalida)
                finRuta = BuscarRuta(i, j - 1, ruta);

            if (finRuta && ruta.Count > 1)
            {
                rutas.Add(ruta);
                ruta = Clonar(rutainicial);
            }

            var derecha = j == _limite ? _numeroSuperior : _matriz[i, j + 1];
            if (derecha < puntoSalida)
                finRuta = BuscarRuta(i, j + 1, ruta);

            if (finRuta && ruta.Count > 1)
            {
                rutas.Add(ruta);
                ruta = Clonar(rutainicial);
            }

            var arriba = i == 0 ? _numeroSuperior : _matriz[i - 1, j];
            if (arriba < puntoSalida)
                finRuta = BuscarRuta(i - 1, j, ruta);

            if (finRuta && ruta.Count > 1)
            {
                rutas.Add(ruta);
                ruta = Clonar(rutainicial);
            }

            var abajo = i == _limite ? _numeroSuperior : _matriz[i + 1, j];
            if (abajo < puntoSalida)
                finRuta = BuscarRuta(i + 1, j, ruta);

            if (finRuta && ruta.Count > 1)
            {
                rutas.Add(ruta);
                ruta = Clonar(rutainicial);
            }
            return true;
        }

        private static List<int> Clonar(List<int> obj)
        {
            using (MemoryStream memory_stream = new MemoryStream())
            {
                // Serialize the object into the memory stream.
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memory_stream, obj);

                // Rewind the stream and use it to create a new object.
                memory_stream.Position = 0;
                return (List<int>)formatter.Deserialize(memory_stream);
            }
        }
    }
}
