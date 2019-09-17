using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;

namespace Formulario
{
    public partial class Form1 : Form, FormularioPrincipal
    {
        public Principal Principal { get; set; }

        public Form1()
        {
            Principal = new Principal();
            InitializeComponent();
        }

        public double[] ObtenerGaussJordan(double[,] matrizcargada, int incognita)
        {
            return Principal.ObtenerGaussJordan(matrizcargada, incognita);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gauss_Jordan nuevo = new Gauss_Jordan(new Matriz());
            nuevo.Owner = this;
            nuevo.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Gauss_Seidel nuevo = new Gauss_Seidel(new Matriz());
            nuevo.Owner = this;
            nuevo.ShowDialog();
        }
    }
}
