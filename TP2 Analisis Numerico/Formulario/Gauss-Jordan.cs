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
    public partial class Gauss_Jordan : Form
    {

        public Gauss_Jordan(int numero)
        {
            InitializeComponent();
            CompletarDatosMetodo(numero);                       
        }
        private void CompletarDatosMetodo(int numero)
        {
            this.textBox1.Text = Convert.ToString(numero);
        }
        private bool VerificarDatosMetodo(List<TextBox> lista)
        {
            bool variable = true;

            foreach (var item in lista)
            {
                if (item.Text == "")
                {
                    variable = false;
                }
            }
            return variable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "")
            {
                int numero = Convert.ToInt32(this.textBox1.Text);

                int num = numero;
                int pointx = 30;
                int pointy = 40;
                this.panel1.Controls.Clear();
                for (int j = 0; j < num + 1; j++)
                {
                    for (int i = 0; i < num; i++)
                    {
                        TextBox nuevo = new TextBox();
                        nuevo.Name = Convert.ToString((i + 1) + ( j + 1));
                        nuevo.Location = new Point(pointx, pointy);
                        panel1.Controls.Add(nuevo);
                        pointy += 30;
                    }
                    pointx += 110;
                    pointy = 40;
                    
                }
                
                pointy = 20;
                pointx -= 110;
                Label nuevo2 = new Label();
                nuevo2.Text = "Variable Independiente";
                nuevo2.Width = 200;
                nuevo2.Location = new Point(pointx, pointy);
                panel1.Controls.Add(nuevo2);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool var = true;

            int numero = Convert.ToInt32(this.textBox1.Text);

            int c = 0;

            double[,] matriz1 = new double[numero, numero + 1];

            List<TextBox> lista = panel1.Controls.OfType<TextBox>().ToList();
            
            if (VerificarDatosMetodo(lista) == true)
            {                
                for (int i = 0; i < numero + 1; i++)
                {
                    for (int j = 0; j < numero; j++)
                    {
                        matriz1[j, i] = Convert.ToDouble(lista.ElementAt(c).Text); 
                        c++;
                    }
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos");

                var = false;
            }
            if (var == true)
            {
                FormularioPrincipal formularioPrincipal = this.Owner as FormularioPrincipal;
                if (formularioPrincipal != null)
                {
                    string variable = "";

                    char[] vec = new char[5] { 'x', 'y' , 'z' , 't' , 'w' };

                    double[] vector = formularioPrincipal.ObtenerGaussJordan(matriz1, numero);

                    for (int i = 0; i < numero; i++)
                    {
                        variable = variable + Convert.ToString(vec[i] + ": " + vector[i] + " ");
                    }
                    MessageBox.Show(variable);
                }
            }

        }
    }
}
