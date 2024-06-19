using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_department_accounting
{
    public class Employees
    {
        public int id_person;
        public string full_name;
        public string gender;
        public string date_of_birth;
        public Employees(int k, string s, string g, string db)
        {
            id_person = k;
            full_name = s;
            gender = g;
            date_of_birth = db;
        }
    }
    public class Post
    {
        public int id_post;
        public string post;
        public int salary;
        public Post(int k, string p, int sal)
        {
            id_post = k;
            post = p;
            salary = sal;
        }
    }
    public class Appointment
    {
        public int id_case;
        public string data_appointment;
        public int id_person;
        public int id_post;
        public Appointment(int k, string dn, int kp, int kdol)
        {
            id_case = k;
            data_appointment = dn;
            id_person = kp;
            id_post = kdol;
        }
    }
}
