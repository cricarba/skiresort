using cricarba.Aplicacion.Definicion;
using cricarba.Contenedor;
using System;

namespace cricarba.skiresort.console
{
    public class Program
    {
        static void Main(string[] args)
        {
            FachadaContenedor.RegistrarContenedor(IoCContenedor.unityContainer);
            var contenidoArchivo = FachadaContenedor.Resolver<ICargarArchivo>().LeerArchivo(@"C:\Users\cristian.carvajal\Downloads\skirsesort.kitzbuehel\map.txt");
            var matriz = FachadaContenedor.Resolver<IProcesarArchivo<int>>().CargarMatrizDesdeArchivo(contenidoArchivo);
            var rutas = FachadaContenedor.Resolver<IGenerarRuta>().GenerarRutas(matriz);
            var mejorRuta = FachadaContenedor.Resolver<IEscogerRuta>().EscogerMejorRuta(rutas);
            Console.Read();

        }
    }
}
