using cricarba.Aplicacion.Definicion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace cricarba.Aplicacion.Implementacion
{
    public class CargarArchivo : ICargarArchivo
    {
        public string LeerArchivo(string ruta)
        {
            return File.ReadAllText(ruta);
        }
      
    }
}
