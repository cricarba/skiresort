using System.Collections.Generic;

namespace cricarba.Aplicacion.Definicion
{
    public interface IEscogerRuta
    {
        List<int> EscogerMejorRuta(List<List<int>> rutas);
    }
}
