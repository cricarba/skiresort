﻿using System.Collections.Generic;

namespace cricarba.Aplicacion.Definicion
{
    public interface IGenerarRuta
    {
        List<List<int>> GenerarRutas(int[,] matriz); 
    }
}
