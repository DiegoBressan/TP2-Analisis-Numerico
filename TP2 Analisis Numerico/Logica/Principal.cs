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
            double[] Resultado = new double[incognita];
            double coeficiente = 0;

            for (int x = 0; x <= incognita - 1; x++)
            {
                coeficiente = matrizcargada[x, x];

                for (int y = 0; y <= incognita; y++)
                {
                    matrizcargada[x, y] = matrizcargada[x, y] / coeficiente;
                }

                for (int z = 0; z <= incognita - 1; z++)
                {
                    if (x != z)
                    {
                        coeficiente = matrizcargada[z, x];

                        for (int t = 0; t <= incognita; t++)
                        {
                            matrizcargada[z, t] = matrizcargada[z, t] - (coeficiente * matrizcargada[x, t]);
                        }
                    }
                }
            }

            for (int i = 0; i < incognita; i++)
            {
                Resultado[i] = matrizcargada[i, incognita];
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
            
            while (ban == false && cont <= 100)
            {
                cont += 1;

                for (int i = 0; i <= incognita - 1; i++)
                {
                    double suma = 0;
                    vectorant[i] = vector[i];

                    for (int j = 0; j <= incognita - 1; j++)
                    {
                        if (j != i) 
                        {
                            suma += matrizcargada[i, j] * vector[j];
                        }
                    }

                    vector[i] = (matrizcargada[i, incognita] - suma) / matrizcargada[i, i];
                }

                ban = true;

                for (int i = 0; i <= incognita - 1; i++)
                {
                    double error = Math.Abs(vector[i] - vectorant[i]);

                    if (error > tolerancia)
                    {
                        ban = false;
                    }
                }
            }

            for (int i = 0; i <= incognita - 1; i++)
            {
                resultado[i] = vector[i];
            }

            return resultado;
        }
    }
}