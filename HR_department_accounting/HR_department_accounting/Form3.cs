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
    public partial class Form3 : Form
    {
        public static List<Post> postF3 = new List<Post>();
        public int nvs = 0;
        bool flag = false;
        char d = '~';

        public Form3(List<Post> a)
        {
            postF3 = a;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Fill_p();
        }

        private void Fill_p()
        {
            dataGridView1.Rows.Clear();
            foreach (Post a in postF3)
                dataGridView1.Rows.Add(a.id_post.ToString(), a.post, a.salary.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            postF3.RemoveAt(nvs);
            Fill_p();
            flag = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            button3.Visible = false;
            button4.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool n = int.TryParse(textBox3.Text, out int z);
            if (n && z >= 0)
            {
                int k = postF3[postF3.Count - 1].id_post + 1;
                postF3.Add(new Post(k, textBox2.Text, z));
                Fill_p();
                button3.Visible = true;
                button4.Visible = false;
                flag = true;
            }
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (flag)
            {
                int k = postF3.Count;
                string[] f = new string[k];
                for (int i = 0; i < k; i++)
                {
                    f[i] = postF3[i].id_post.ToString() + d + postF3[i].post + d + postF3[i].salary.ToString();
                }
                File.WriteAllLines("Post.txt", f);
            }
        }

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            nvs = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[nvs].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[nvs].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[nvs].Cells[2].Value.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bool n = int.TryParse(textBox3.Text, out int z);
            if (n && z >= 0)
            {
                postF3[nvs].post = textBox2.Text;
                postF3[nvs].salary = z;
                Fill_p();
                flag = true;
            }
        }
    }
}
