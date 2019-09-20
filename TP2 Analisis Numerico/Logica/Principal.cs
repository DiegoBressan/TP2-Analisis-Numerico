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
            double[] vector = new double[incognita];
            double[] vectorant = new double[incognita];
            double[] resultado = new double[incognita];
            bool ban = false;
            int cont = 0;
            double tolerancia = 0.0001;
            
            while (ban == false && cont < 100)
            {
                cont += 1;

                for (int i = 0; i < incognita; i++)
                {
                    double suma = 0;
                    vectorant[i] = vector[i];

                    for (int j = 0; j < incognita - 1; j++)
                    {
                        if (j == i) continue;
                        suma += matrizcargada[i, j] * vector[j];
                    }

                    vector[i] = (matrizcargada[i, incognita - 1] - suma) / matrizcargada[i, i];
                }

                ban = true;

                for (int i = 0; i < incognita - 1; i++)
                {
                    double resta = vector[i] - vectorant[i];

                    if (resta < 0)
                    {
                        resta = resta * -1;
                    }

                    if (resta > tolerancia)
                    {
                        ban = false;
                    }
                }
            }

            for (int i = 0; i < incognita; i++)
            {
                resultado[i] = vector[i];
            }

            return resultado;
        }
    }
}