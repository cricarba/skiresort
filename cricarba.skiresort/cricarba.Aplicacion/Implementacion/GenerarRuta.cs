using cricarba.Aplicacion.Definicion;
using System.Collections.Generic;

namespace cricarba.Aplicacion.Implementacion
{
    public class GenerarRuta : IGenerarRuta
    {
        private readonly List<int[]> rutas = new List<int[]>();
        private int[,] _matriz;
        private int _limite;
        private readonly int _numeroSuperior = 15001;
        public void GenerarRutas(int[,] matriz)
        {
            _matriz = matriz;
            _limite = 4;
            ContinuarRuta(0, 0, new List<int>());

        }

        private void ContinuarRuta(int puntoInicialI, int puntoInicialJ, List<int> ruta)
        {
           
            for (int i = puntoInicialI; i < _matriz.Length; i++)
            {
                for (int j = puntoInicialJ; j < _matriz.Length; j++)
                {
                    var puntoSalida = _matriz[i, j];
                    var este = j == 0 ? _numeroSuperior : _matriz[i, j - 1];
                    if (este < puntoSalida)
                    {
                        ruta.Add(puntoSalida);
                        ContinuarRuta(i, j - 1, ruta);
                    }

                    var oeste = j == _limite ? _numeroSuperior : _matriz[i, j + 1];
                    if (oeste < puntoSalida)
                    {
                        ruta.Add(puntoSalida);

                        ContinuarRuta(i, j + 1, ruta);
                    }
                    var norte = i == 0 ? _numeroSuperior : _matriz[i - 1, j];
                    if (norte < puntoSalida)
                    {
                        ruta.Add(puntoSalida);

                        ContinuarRuta(i - 1, j, ruta);
                    }
                    var sur = i == _limite ? _numeroSuperior : _matriz[i + 1, j];
                    if (sur < puntoSalida)
                    {

                        ruta.Add(puntoSalida);

                        ContinuarRuta(i + 1, j, ruta);
                    }
                }
            }
        }
    }
}
