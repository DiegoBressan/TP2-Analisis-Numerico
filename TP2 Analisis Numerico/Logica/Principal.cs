using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Principal
    {
        public double[] ObtenerGaussJordan(double[,] matrizcargada, int incognita)
        {
            double[,] matrizaux = matrizcargada;
            double[] Resultado = new double[incognita];
            double coeficiente = 0;

            for (int x = 0; x < incognita - 1; x++)
            {
                coeficiente = matrizcargada[x, x];

                for (int y = 0; y < incognita; y++)
                {
                    matrizaux[x, y] = matrizaux[x, y] / coeficiente;
                   /* for (int z = 0; z < incognita - 1; z++)
                    {
                        if (x != z)
                        {
                            coeficiente = matrizaux[x, z];
                            for (int t = 0; t < incognita; t++)
                            {
                                matrizaux[y, t] = matrizcargada[y, t] - (coeficiente * matrizcargada[x, t]);
                            }
                        }
                    }*/
                }

                for (int z = 0; z < incognita - 1; z++)
                {
                    if (x != z)
                    {
                        coeficiente = matrizaux[z, x];
                        for (int t = 0; t < incognita; t++)
                        {
                            matrizaux[x, t] = matrizcargada[x, t] - (coeficiente * matrizcargada[x,t]);
                        }
                    }
                }
            }

            for (int i = 0; i < incognita - 1; i++)
            {
                Resultado[i] = matrizaux[i, incognita];
            }

            return Resultado;
        }
    }
}