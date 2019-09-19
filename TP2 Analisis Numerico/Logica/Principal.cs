using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Principal
    {
        //GAUSS-JORDAN
        public double[] ObtenerGaussJordan(double[,] matrizcargada, int incognita)
        {
            double[,] matrizaux = matrizcargada;
            double[] Resultado = new double[incognita];
            double coeficiente = 0;

            for (int x = 0; x <= incognita - 1; x++)
            {
                coeficiente = matrizcargada[x, x];

                for (int y = 0; y <= incognita; y++)
                {
                    matrizaux[x, y] = matrizaux[x, y] / coeficiente;
                }

                for (int z = 0; z <= incognita - 1; z++)
                {
                    if (x != z)
                    {
                        coeficiente = matrizaux[z, x];
                        for (int t = 0; t <= incognita; t++)
                        {
                            matrizaux[z, t] = matrizcargada[z, t] - (coeficiente * matrizcargada[x, t]);
                        }
                    }
                }
            }

            for (int i = 0; i <= incognita - 1; i++)
            {
                Resultado[i] = matrizaux[i, incognita];
            }

            return Resultado;
        }

        //GAUSS-SEIDEL
        public double[] ObtenerGaussSeidel(double[,] matrizcargada, int incognita)
        {
            double[,] matrizaux = matrizcargada;
            double[] Resultado = new double[incognita];
            double[] vector = new double[incognita];
            double[] vectorant = new double[incognita];
            double[] vectorecuaciones = new double[incognita];
            //double coeficiente = 0;
            bool ban = false;
            
            for (int i = 0; i <= incognita - 1; i++)
            {
                vector[i] = 1;
                vectorant[i] = 0;
            }
            
            while (ban == false)
            {
                for (int x = 0; x <= incognita - 1; x++)
                {
                    vectorecuaciones[x] = matrizaux[x, incognita];

                    for (int y = 0; y <= incognita - 1; y++)
                    {
                        if (y != x)
                        {
                            vectorecuaciones[x] = vectorecuaciones[x] - (matrizaux[x, y] * vector[y]);
                        }
                    }

                    vectorecuaciones[x] = vectorecuaciones[x] / vector[x];

                    vectorant[x] = vector[x];
                    vector[x] = vectorecuaciones[x];
                }

                if (vector == vectorant)
                {
                    ban = true;
                }
            }

            /*for (int x = 0; x <= incognita - 1; x++)
            {
                coeficiente = matrizcargada[x, x];

                for (int y = 0; y <= incognita; y++)
                {
                    matrizaux[x, y] = matrizaux[x, y] / coeficiente;
                }

                for (int z = 0; z <= incognita - 1; z++)
                {
                    if (x != z)
                    {
                        coeficiente = matrizaux[z, x];
                        for (int t = 0; t <= incognita; t++)
                        {
                            matrizaux[z, t] = matrizcargada[z, t] - (coeficiente * matrizcargada[x, t]);
                        }
                    }
                }
            }

            for (int i = 0; i <= incognita - 1; i++)
            {
                Resultado[i] = vector[i];
            }*/

            return vector;
        }
    }
}