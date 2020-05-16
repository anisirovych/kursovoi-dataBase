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
    public partial class EmpEdit : Form
    {
        int id;
        int pos = 0;
        bool edit;
        string conn = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AvtoSalon.mdf;Integrated Security = True";

        public EmpEdit()
        {
            InitializeComponent();
            edit = false;
        }

        public EmpEdit(int id, string fullname, int pos, DateTime birth, DateTime work, decimal salary)
        {
            InitializeComponent();
            edit = true;
            this.id = id;
            this.pos = pos;
            textBox1.Text = fullname;
            dateTimePicker1.Value = birth;
            dateTimePicker1.Value = work;
            textBox2.Text = salary.ToString();
        }

        private void EmpEdit_Load(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(conn);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Id, Name FROM Position", sqlconn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int temp = 0;
            foreach (DataRow x in dt.Rows)
            {
                comboBox1.Items.Add(x[0].ToString() + " " + x[1].ToString());
                if (Convert.ToInt32(x[0].ToString()) == pos)
                    temp = comboBox1.Items.Count - 1;
            }
            comboBox1.SelectedIndex = temp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!edit && textBox1.Text.Trim() != "")
            {
                {
                    SqlConnection sqlconn = new SqlConnection(conn);
                    sqlconn.Open();
                    SqlCommand query = new SqlCommand("Insert Into Employee (FullName, Position, DateBirth, DateWork, Salary) " + "Values (@FullName, @Position, @DateBirth, @DateWork, @Salary)", sqlconn);

                    query.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = textBox1.Text;
                    query.Parameters.Add("@Position", SqlDbType.Int).Value = Convert.ToInt32(comboBox1.SelectedItem.ToString().Substring(0, comboBox1.SelectedItem.ToString().IndexOf(" ")));
                    query.Parameters.Add("@DateBirth", SqlDbType.DateTime).Value = dateTimePicker1.Value;
                    query.Parameters.Add("@DateWork", SqlDbType.DateTime).Value = dateTimePicker2.Value;
                    query.Parameters.Add("@Salary", SqlDbType.Decimal).Value = Convert.ToDecimal(textBox2.Text);
                    query.ExecuteNonQuery();
                    sqlconn.Close();
                    this.Close();
                }
            }
            else if (edit && textBox1.Text.Trim() != "")
            {
                {

                    SqlConnection sqlconn = new SqlConnection(conn);
                    sqlconn.Open();
                    SqlCommand query = new SqlCommand(String.Format("UPDATE Employee SET FullName = @FullName, Position=@Position, DateBirth=@DateBirth, DateWork=@DateWork, Salary=@Salary WHERE Id = {0}", id.ToString()), sqlconn);
                    query.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = textBox1.Text;
                    query.Parameters.Add("@Position", SqlDbType.Int).Value = Convert.ToInt32(comboBox1.SelectedItem.ToString().Substring(0, comboBox1.SelectedItem.ToString().IndexOf(" ")));
                    query.Parameters.Add("@DateBirth", SqlDbType.DateTime).Value = dateTimePicker1.Value;
                    query.Parameters.Add("@DateWork", SqlDbType.DateTime).Value = dateTimePicker2.Value;
                    query.Parameters.Add("@Salary", SqlDbType.Decimal).Value = Convert.ToDecimal(textBox2.Text);
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

