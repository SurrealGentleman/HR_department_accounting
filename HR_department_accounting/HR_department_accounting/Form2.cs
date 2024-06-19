using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR_department_accounting
{
    public partial class Form2 : Form
    {
        public static List<Employees> empF2 = new List<Employees>();
        public int nvs = 0;
        bool flag = false;
        char d = '~';

        public Form2(List<Employees> a)
        {
            empF2 = a;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Fill_e();
        }

        private void Fill_e()
        {
            dataGridView1.Rows.Clear();
            foreach (Employees a in empF2)
                dataGridView1.Rows.Add(a.id_person.ToString(), a.full_name, a.gender, a.date_of_birth);
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            nvs = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[nvs].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[nvs].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[nvs].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[nvs].Cells[3].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            empF2[nvs].full_name = textBox2.Text;
            empF2[nvs].gender = textBox3.Text;
            empF2[nvs].date_of_birth = textBox4.Text;
            Fill_e();
            flag = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            empF2.RemoveAt(nvs);
            Fill_e();
            flag = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int k = empF2[empF2.Count - 1].id_person + 1;
            textBox1.Text = k.ToString();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            button3.Visible = false;
            button4.Visible = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int k = empF2[empF2.Count - 1].id_person + 1;
            empF2.Add(new Employees(k, textBox2.Text, textBox3.Text, textBox4.Text));
            Fill_e();
            button3.Visible = true;
            button4.Visible = false;
            flag = true;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (flag)
            {
                int k = empF2.Count;
                string[] f = new string[k];
                for (int i = 0; i < k; i++)
                {
                    f[i] = empF2[i].id_person.ToString() + d + empF2[i].full_name + d + empF2[i].gender + d + empF2[i].date_of_birth;
                }
                File.WriteAllLines("Employees.txt", f);
            }
        }
    }
}
