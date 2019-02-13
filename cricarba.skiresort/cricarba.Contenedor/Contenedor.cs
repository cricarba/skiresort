
using cricarba.Aplicacion.Definicion;
using cricarba.Aplicacion.Implementacion;
using Unity;

namespace cricarba.Contenedor
{
    public class IoCContenedor
    {
        private static UnityContainer _unityContainer;

        public static UnityContainer unityContainer
        {
            get
            {

                if (_unityContainer != null)
                {
                    return _unityContainer;
                }

                _unityContainer = new UnityContainer();
                _unityContainer.RegisterType<ICargarArchivo, CargarArchivo>();
                _unityContainer.RegisterType<IProcesarArchivo<int>, ProcesarArchivo>();
                _unityContainer.RegisterType<IGenerarRuta, GenerarRuta>();

                return _unityContainer;
            }
        }
    }
}
