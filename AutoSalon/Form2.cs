using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace AutoSalon
{
    public partial class Queries : Form
    {
        string conn = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AvtoSalon.mdf;Integrated Security = True";

        public Queries()
        {
            InitializeComponent();
        }

        private void Queries_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + @"\temp.txt");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string query = "SELECT Auto.Mark, Auto.Color, Info.Seats, Info.MaxSpeed, TypeEngine, VolumeFuel, Auto.Cost  FROM Auto, Info WHERE Auto.Info=Info.Id";
            SqlConnection sqlconn = new SqlConnection(conn);
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlconn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            using (StreamWriter x = new StreamWriter(Directory.GetCurrentDirectory() + @"\temp.txt", false))
            {
                x.WriteLine("Информация про автомобили");
                x.WriteLine();
                foreach (DataRow y in dt.Rows)
                {
                    x.WriteLine("Марка: " + y[0].ToString());
                    x.WriteLine("Цвет: " + y[1].ToString());
                    x.WriteLine("Кол-во мест: " + y[2].ToString());
                    x.WriteLine("Макс. скорость: " + y[3].ToString());
                    x.WriteLine("Тип двигателя: " + y[4].ToString());
                    x.WriteLine("Объем топлива: " + y[5].ToString());
                    x.WriteLine("Стоимость: " + y[6].ToString());
                    x.WriteLine();
                }
            }
    }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT Employee.FullName, Count(Selling.Employee) AS Count FROM Selling, Employee WHERE Employee.id=Selling.Employee GROUP BY Employee.FullName ORDER BY Count(Selling.Employee) Desc";
            SqlConnection sqlconn = new SqlConnection(conn);
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlconn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            using (StreamWriter x = new StreamWriter(Directory.GetCurrentDirectory() + @"\temp.txt", false))
            {
                x.WriteLine("Рейтинг сотрудников");
                x.WriteLine();
                foreach (DataRow y in dt.Rows)
                {
                    x.WriteLine("ФИО: " + y[0].ToString());
                    x.WriteLine("Кол-во продаж: " + y[1].ToString());
                    x.WriteLine();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "SELECT Auto.Mark, Count(Selling.Auto) AS Count FROM Selling, Auto WHERE Auto.id=Selling.Auto GROUP BY Auto.Mark ORDER BY Count(Selling.Auto) DESC";
            SqlConnection sqlconn = new SqlConnection(conn);
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlconn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            using (StreamWriter x = new StreamWriter(Directory.GetCurrentDirectory() + @"\temp.txt", false))
            {
                x.WriteLine("Самые продаваемые автомобили");
                x.WriteLine();
                foreach (DataRow y in dt.Rows)
                {
                    x.WriteLine("Марка: " + y[0].ToString());
                    x.WriteLine("Кол-во продаж: " + y[1].ToString());
                    x.WriteLine();
                }
            }
        }
    }
    }

