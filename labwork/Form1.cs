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
    public struct experiment:IComparable
    {
        public int number;
        public double sv;

        public int CompareTo(Object obj)
        {
            experiment arr = (experiment)obj;
            return this.sv.CompareTo(arr.sv);
        }
    }

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
            int count_b = 0;
            int count_exp = 0;
            double lam;
            double disp;
            double mean;
            double tmp;
            double mu;
           

            count_b = Convert.ToInt32(textBox1.Text);
            mean = Convert.ToDouble(textBox2.Text);
            disp = Convert.ToDouble(textBox3.Text);
            count_exp = Convert.ToInt32(textBox4.Text);
            lam = 1.0 / (Math.Sqrt(disp));
            mu = Math.Sqrt(disp) - mean;

            label5.Text = "lambda: " + Convert.ToString(lam);
            label6.Text = "mu: " + Convert.ToString(mu);

            if ((mu >= 0) && (lam>0))
            {
                experiment[] etta = new experiment[count_exp];


                for (int i = 0; i < count_exp; i++)
                {
                    etta[i].number = i;
                    etta[i].sv = 0;
                    for (int j = 0; j < count_b; j++)
                    {
                        tmp = Rand.NextDouble();
                        etta[i].sv += (mu - (Math.Log(tmp)/lam));
                    }
                }

                Array.Sort(etta);

                for (int i = 0; i < count_exp; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = Convert.ToString(etta[i].number);
                    dataGridView1.Rows[i].Cells[1].Value = Convert.ToString(etta[i].sv);
                }
            }
            else
            {
                var result = MessageBox.Show("Mu<0, попробуйте задать другое среднее или дисперсию.", "Ошибка", MessageBoxButtons.OK);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    // Closes the parent form.

                    this.Close();

                }
            }
        }
    }
}
