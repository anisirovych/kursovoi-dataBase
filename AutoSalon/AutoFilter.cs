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

namespace AutoSalon
{
    public partial class AutoFilter : Form
    {
        Main main;
        string conn = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AvtoSalon.mdf;Integrated Security = True";

        public AutoFilter(Main main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void AutoFilter_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Info WHERE ";
                int t = 0;
                if (Int32.TryParse(textBox1.Text, out t))
                    query += " Lenght>" + textBox1.Text + " AND ";
                if (Int32.TryParse(textBox4.Text, out t))
                    query += " Lenght<" + textBox4.Text + " AND ";
                if (Int32.TryParse(textBox2.Text, out t))
                    query += "Width>" + textBox2.Text + " AND ";
                if (Int32.TryParse(textBox3.Text, out t))
                    query += "Width<" + textBox3.Text + " AND ";
                main.Auto();
                SqlConnection sqlconn = new SqlConnection(conn);
                SqlDataAdapter sda = new SqlDataAdapter(query.Substring(0, query.Length - 4), sqlconn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                main.dataGridView1.DataSource = dt;
            }
            catch (ArgumentOutOfRangeException t) { }
        }
    }
}
    