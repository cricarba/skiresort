using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cricarba.Aplicacion.Definicion
{
    public interface IProcesarArchivo<Tout>
    {
        Tout[,] CargarMatrizDesdeArchivo(string contenidoArchivo);
    }
}
