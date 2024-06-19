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
    public partial class Form1 : Form
    {
        public static List<Employees> employees = new List<Employees>();
        public static List<Post> post = new List<Post>();
        public static List<Appointment> appointment = new List<Appointment>();
        char d = '~';
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Read_e();
            Read_p();
            Read_a();
        }

        private void Read_e()
        {
            string[] st = File.ReadAllLines("Employees.txt");
            foreach (string str in st)
            {
                string[] sl = str.Split(d);
                Employees t = new Employees(int.Parse(sl[0]), sl[1], sl[2], sl[3]);
                employees.Add(t);
            }
        }

        private void Read_p()
        {
            string[] st = File.ReadAllLines("Post.txt");
            foreach (string str in st)
            {
                string[] sl = str.Split(d);
                Post t = new Post(int.Parse(sl[0]), sl[1], int.Parse(sl[2]));
                post.Add(t);
            }
        }

        private void Read_a()
        {
            string[] st = File.ReadAllLines("Appointment.txt");
            foreach (string str in st)
            {
                string[] sl = str.Split(d);
                Appointment t = new Appointment(int.Parse(sl[0]), sl[1], int.Parse(sl[2]), int.Parse(sl[3]));
                appointment.Add(t);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(employees);
            f2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(post);
            f3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(employees, post, appointment);
            f4.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5(employees, post, appointment);
            f5.ShowDialog();
        }
    }
}
