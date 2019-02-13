
using System;
using Unity;

namespace cricarba.Contenedor
{
    public class FachadaContenedor
    {
        private static UnityContainer _contenedor;

        public static void RegistrarContenedor(UnityContainer contenedor)
        {
            if (contenedor == null)
            {
                throw new Exception("Container null");
            }

            _contenedor = contenedor;
        }

        public static T Resolver<T>()
        {
            return _contenedor.Resolve<T>();
        }
    }
}
