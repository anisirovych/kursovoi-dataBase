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
    public partial class ClientEdit : Form
    {
        int id;
        bool edit;
        string conn = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AvtoSalon.mdf;Integrated Security = True";

        public ClientEdit()
        {
            InitializeComponent();
            edit = false;
        }

        public ClientEdit(int id, string fullname, string phone, string address)
        {
            InitializeComponent();
            edit = true;
            this.id = id;
            textBox1.Text = fullname;
            textBox2.Text = phone;
            textBox3.Text = address;
        }

        private void ClientEdit_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!edit && textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "")
            {
                {
                    SqlConnection sqlconn = new SqlConnection(conn);
                    sqlconn.Open();
                    SqlCommand query = new SqlCommand("Insert Into Client (FullName, Phone, Address) " + "Values (@FullName, @Phone, @Address)", sqlconn);

                    query.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = textBox1.Text;
                    query.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = textBox2.Text;
                    query.Parameters.Add("@Address", SqlDbType.NVarChar).Value = textBox3.Text;
                    query.ExecuteNonQuery();
                    sqlconn.Close();
                    this.Close();
                }
            }
            else if (edit && textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "")
            {
                {

                    SqlConnection sqlconn = new SqlConnection(conn);
                    sqlconn.Open();
                    SqlCommand query = new SqlCommand(String.Format("UPDATE Client SET FullName = @FullName, Phone = @Phone, Address = @Address WHERE Id = {0}", id.ToString()), sqlconn);
                    query.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = textBox1.Text;
                    query.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = textBox2.Text;
                    query.Parameters.Add("@Address", SqlDbType.NVarChar).Value = textBox3.Text;
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
