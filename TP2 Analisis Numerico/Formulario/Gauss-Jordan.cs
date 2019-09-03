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

        public Gauss_Jordan(Matriz matriz)
        {
            InitializeComponent();
            CompletarDatosMetodo(matriz);                       
        }
        private void CompletarDatosMetodo(Matriz matriz)
        {
            this.textBox1.Text = Convert.ToString(matriz.CantFilasxColumnas);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "")
            {
                Matriz matriz = new Matriz();
                matriz.CantFilasxColumnas = Convert.ToInt32(this.textBox1.Text);

                int num = matriz.CantFilasxColumnas;
                int pointx = 30;
                int pointy = 40;
                this.panel1.Controls.Clear();
                for (int j = 0; j < num; j++)
                {
                    for (int i = 0; i < num; i++)
                    {
                        TextBox nuevo = new TextBox();
                        nuevo.Location = new Point(pointx, pointy);
                        panel1.Controls.Add(nuevo);
                        pointy += 30;
                    }
                    pointx += 110;
                    pointy = 40;
                }
            }

        }
    }
}
