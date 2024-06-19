using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR_department_accounting
{
    public partial class Form5 : Form
    {
        public static List<Employees> empF2 = new List<Employees>();
        public static List<Post> postF3 = new List<Post>();
        public static List<Appointment> appF4 = new List<Appointment>();
        public Form5(List<Employees> e, List<Post> p, List<Appointment> a)
        {
            empF2 = e;
            postF3 = p;
            appF4 = a;
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            foreach (Post x in postF3)
                dataGridView1.Rows.Add(x.id_post.ToString(), x.post);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            int id_a = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            foreach (var x in appF4)
            {
                if (x.id_post == id_a)
                {
                    dataGridView2.Rows.Add(x.id_person.ToString(), empF2[F_e(x.id_person)].full_name,
                        empF2[F_e(x.id_person)].gender, empF2[F_e(x.id_person)].date_of_birth);
                }
            }
            textBox1.Text = dataGridView2.Rows.Count.ToString();
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
    }
}
