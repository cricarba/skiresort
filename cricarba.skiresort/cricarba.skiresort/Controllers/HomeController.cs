using cricarba.Aplicacion.Definicion;
using cricarba.Contenedor;
using System.Web.Mvc;

namespace cricarba.skiresort.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var contenidoArchivo = FachadaContenedor.Resolver<ICargarArchivo>().LeerArchivo(@"C:\Users\cristian.carvajal\Downloads\skirsesort.kitzbuehel\map.txt");
            var matriz = FachadaContenedor.Resolver<IProcesarArchivo<int>>().CargarMatrizDesdeArchivo(contenidoArchivo);
            var rutas = FachadaContenedor.Resolver<IGenerarRuta>().GenerarRutas(matriz);
            var mejorRuta = FachadaContenedor.Resolver<IEscogerRuta>().EscogerMejorRuta(rutas);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}