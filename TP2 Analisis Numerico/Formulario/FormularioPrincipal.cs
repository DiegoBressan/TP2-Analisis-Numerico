using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formulario
{
    interface FormularioPrincipal
    {
        //GAUSS-JORDAN
        double[] ObtenerGaussJordan(double[,] matrizcargada, int incognita);
    }
}
