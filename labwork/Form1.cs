using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace labwork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Random Rand = new Random();
            int n = 0;
            double lam;
            double disp;
            double mean;
            double tmp;
            double mu;

            n = Convert.ToInt32(textBox1.Text);
            mean = Convert.ToDouble(textBox2.Text);
            disp = Convert.ToDouble(textBox3.Text);
            lam = 1.0 / (Math.Sqrt(disp));
            mu = (1.0 / lam) - mean;

            double[] etta = new double[n];

            for (int i = 0; i < n; i++)
            {
                etta[i] = 0;
            }

            for (int i = 0; i < n; i++)
            {
                tmp = Rand.NextDouble();
                etta[i] = mu - (Math.Log(tmp) / lam) ;
            }

            Array.Sort(etta);

            for (int i = 0; i < n; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = Convert.ToString(i);
                dataGridView1.Rows[i].Cells[1].Value = Convert.ToString(etta[i]);
            }
        }
    }
}
