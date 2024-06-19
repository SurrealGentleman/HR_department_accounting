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
    public partial class Form4 : Form
    {
        public static List<Employees> empF2 = new List<Employees>();
        public static List<Post> postF3 = new List<Post>();
        public static List<Appointment> appF4 = new List<Appointment>();
        public int nvs = 0;
        public Form4(List<Employees> e, List<Post> p, List<Appointment> a)
        {
            empF2 = e;
            postF3 = p;
            appF4 = a;
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            foreach (Employees ee in empF2)
                comboBox1.Items.Add(ee.full_name);
            foreach (Post pp in postF3)
                comboBox2.Items.Add(pp.post);
            Fill_a();
        }

        private void Fill_a()
        {
            dataGridView1.Rows.Clear();
            for (int k = 0; k < appF4.Count(); k++)
            {
                Appointment a = appF4[k];
                dataGridView1.Rows.Add(a.id_case.ToString(),
                    a.data_appointment, a.id_person.ToString(),
                    empF2[F_e(a.id_person)].full_name,
                    empF2[F_e(a.id_person)].gender,
                    empF2[F_e(a.id_person)].date_of_birth, a.id_post.ToString(),
                    postF3[F_p(a.id_post)].post, postF3[F_p(a.id_post)].salary);
            }
        }


        public int F_e(int ee)
        {
            int kee = 0;
            for (int k = 0; k < empF2.Count(); k++)
                if (empF2[k].id_person == ee)
                {
                    kee = k;
                    break;
                }
            return kee;
        }
        public int F_p(int pp)
        {
            int kpp = 0;
            for (int k = 0; k < postF3.Count(); k++)
                if (postF3[k].id_post == pp)
                {
                    kpp = k;
                    break;
                }
            return kpp;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            appF4[nvs].data_appointment = textBox2.Text;
            int i = comboBox1.SelectedIndex;
            appF4[nvs].id_person = empF2[i].id_person;
            int ii = comboBox2.SelectedIndex;
            appF4[nvs].id_post = postF3[ii].id_post;
            Fill_a();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            appF4.RemoveAt(nvs);
            Fill_a();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            button3.Visible = false;
            button4.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int nomer = appF4[appF4.Count - 1].id_case + 1;
            var eBD = textBox2.Text;
            int eID = empF2[comboBox1.SelectedIndex].id_person;
            int pID = postF3[comboBox2.SelectedIndex].id_post;
            appF4.Add(new Appointment(nomer, eBD, eID, pID));
            button3.Visible = true;
            button4.Visible = false;
            Fill_a();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            char d = '~';
            string[] f = new string[appF4.Count];
            for (int k = 0; k < appF4.Count; k++)
            {
                Appointment a = appF4[k];
                f[k] = a.id_case.ToString() + d + a.data_appointment.ToString() + d + a.id_person.ToString() + d + a.id_post.ToString();
            }
            File.WriteAllLines("Appointment.txt", f);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBox1.SelectedIndex;
            if (i >= 0)
            {
                textBox3.Text = empF2[i].id_person.ToString();
                textBox4.Text = empF2[i].gender.ToString();
                textBox5.Text = empF2[i].date_of_birth.ToString();

            }


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBox2.SelectedIndex;
            if (i > 0)
            {
                textBox6.Text = postF3[i].id_post.ToString();
                textBox7.Text = postF3[i].salary.ToString();

            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            nvs = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[nvs].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[nvs].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[nvs].Cells[2].Value.ToString();
            comboBox1.SelectedItem = dataGridView1.Rows[nvs].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[nvs].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[nvs].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[nvs].Cells[6].Value.ToString();
            comboBox2.SelectedItem = dataGridView1.Rows[nvs].Cells[7].Value.ToString();
            textBox7.Text = dataGridView1.Rows[nvs].Cells[8].Value.ToString();
        }
    }
}
