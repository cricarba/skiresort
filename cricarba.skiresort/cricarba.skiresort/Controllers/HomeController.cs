using cricarba.Aplicacion.Definicion;
using cricarba.Contenedor;
using System.Web.Mvc;

namespace cricarba.skiresort.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var contenidoArchivo = FachadaContenedor.Resolver<ICargarArchivo>().LeerArchivo(@"C:\Users\cristian.carvajal\Downloads\skirsesort.kitzbuehel\4x4.txt");
            var matriz = FachadaContenedor.Resolver<IProcesarArchivo<int>>().CargarMatrizDesdeArchivo(contenidoArchivo);
            FachadaContenedor.Resolver<IGenerarRuta>().GenerarRutas(matriz);

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