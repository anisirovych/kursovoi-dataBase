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
    public partial class AutoEdit : Form
    {
        int id;
        int provider = 0;
        int info = 0;
        bool edit;
        string conn = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AvtoSalon.mdf;Integrated Security = True";

        public AutoEdit()
        {
            InitializeComponent();
            edit = false;
        }

        public AutoEdit(int id, string mark, string color, DateTime datesup, decimal cost, int provider, int info)
        {
            InitializeComponent();
            edit = true;
            this.id = id;
            this.info = info;
            textBox1.Text = mark;
            textBox2.Text = color;
            textBox3.Text = cost.ToString();
            dateTimePicker1.Value = datesup;
        }

        private void AutoEdit_Load(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(conn);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT id, Name FROM Provider", sqlconn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int temp = 0;
            foreach (DataRow x in dt.Rows)
            {
                comboBox2.Items.Add(x[0].ToString() + " " + x[1].ToString());
                if (Convert.ToInt32(x[0].ToString()) == provider)
                    temp = comboBox2.Items.Count - 1;
            }
            comboBox2.SelectedIndex = temp;
    
            sda = new SqlDataAdapter("SELECT Id FROM Info", sqlconn);
            dt = new DataTable();
            sda.Fill(dt);
            temp = 0;
            foreach (DataRow x in dt.Rows)
            {
                comboBox3.Items.Add(x[0].ToString() + " " + x[0].ToString());
                if (Convert.ToInt32(x[0].ToString()) == info)
                    temp = comboBox3.Items.Count - 1;
            }
            comboBox3.SelectedIndex = temp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!edit && textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "")
            {
                {
                    SqlConnection sqlconn = new SqlConnection(conn);
                    sqlconn.Open();
                    SqlCommand query = new SqlCommand("Insert Into Auto (Mark, Color,DateSupply, Cost, Provider, Info) " + "Values (@Mark, @Color, @DateSupply, @Cost, @Provider, @Info)", sqlconn);

                    query.Parameters.Add("@Mark", SqlDbType.NVarChar).Value = textBox1.Text;
                    query.Parameters.Add("@Color", SqlDbType.NVarChar).Value = textBox2.Text;
                    query.Parameters.Add("@DateSupply", SqlDbType.DateTime).Value = dateTimePicker1.Value;
                    query.Parameters.Add("@Cost", SqlDbType.Decimal).Value = Convert.ToDecimal(textBox3.Text);
                    query.Parameters.Add("@Provider", SqlDbType.Int).Value = Convert.ToInt32(comboBox2.SelectedItem.ToString().Substring(0, comboBox2.SelectedItem.ToString().IndexOf(" ")));
                    query.Parameters.Add("@Info", SqlDbType.Int).Value = Convert.ToInt32(comboBox3.SelectedItem.ToString().Substring(0, comboBox3.SelectedItem.ToString().IndexOf(" ")));
                    query.ExecuteNonQuery();
                    sqlconn.Close();
                    this.Close();
                }
            }
            else if (edit && textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "")
            {
                {

                    SqlConnection sqlconn = new SqlConnection(conn);
                    sqlconn.Open();
                    SqlCommand query = new SqlCommand(String.Format("UPDATE Auto SET Mark = @Mark, Color = @Color, DateSupply = @DateSupply, Cost = @Cost, Client = Client, Provider = @Provider, Info = @Info WHERE Id = {0}", id.ToString()), sqlconn);
                    query.Parameters.Add("@Mark", SqlDbType.NVarChar).Value = textBox1.Text;
                    query.Parameters.Add("@Color", SqlDbType.NVarChar).Value = textBox2.Text;
                    query.Parameters.Add("@DateSupply", SqlDbType.DateTime).Value = dateTimePicker1.Value;
                    query.Parameters.Add("@Cost", SqlDbType.Decimal).Value = Convert.ToDecimal(textBox3.Text);
                    query.Parameters.Add("@Provider", SqlDbType.Int).Value = Convert.ToInt32(comboBox2.SelectedItem.ToString().Substring(0, comboBox2.SelectedItem.ToString().IndexOf(" ")));
                    query.Parameters.Add("@Info", SqlDbType.Int).Value = Convert.ToInt32(comboBox3.SelectedItem.ToString().Substring(0, comboBox3.SelectedItem.ToString().IndexOf(" ")));
                    query.ExecuteNonQuery();
                    sqlconn.Close();
                    this.Close();
                }
            }
            else MessageBox.Show("Проверьте данные", "Предупреждение", MessageBoxButtons.OK);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

