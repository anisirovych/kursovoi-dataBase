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
    public partial class InfoEdit : Form
    {

        int id;
        bool edit;
        string conn = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AvtoSalon.mdf;Integrated Security = True";

        public InfoEdit()
        {
            InitializeComponent();
            edit = false;
        }
        public InfoEdit(int id, int lenght, int wight, string seats, string weight, string maxspeed, string engine, string fuel)
        {
            InitializeComponent();
            edit = true;
            this.id = id;
            textBox1.Text = lenght.ToString();
            textBox2.Text = weight.ToString();
            textBox3.Text = seats;
            textBox4.Text = weight;
            textBox5.Text = maxspeed;
            textBox6.Text = engine;
            textBox7.Text = fuel;
        }


        private void InfoEdit_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int temp = 0;
            if (!edit && Int32.TryParse(textBox1.Text, out temp)  && Int32.TryParse(textBox2.Text, out temp)  && textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "" && textBox5.Text.Trim() != "" && textBox6.Text.Trim() != "" && textBox7.Text.Trim() != "")
            {
                {
                    SqlConnection sqlconn = new SqlConnection(conn);
                    sqlconn.Open();
                    SqlCommand query = new SqlCommand("Insert Into Info (Lenght, Width, Seats, Weight, MaxSpeed, TypeEngine, VolumeFuel) " + "Values (@Lenght, @Width, @Seats, @Weight, @MaxSpeed, @TypeEngine, @VolumeFuel)", sqlconn);

                    query.Parameters.Add("@Lenght", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);
                    query.Parameters.Add("@Width", SqlDbType.Int).Value = Convert.ToInt32(textBox2.Text);
                    query.Parameters.Add("@Seats", SqlDbType.NVarChar).Value = textBox3.Text;
                    query.Parameters.Add("@Weight", SqlDbType.NVarChar).Value = textBox4.Text;
                    query.Parameters.Add("@MaxSpeed", SqlDbType.NVarChar).Value = textBox5.Text;
                    query.Parameters.Add("@TypeEngine", SqlDbType.NVarChar).Value = textBox6.Text;
                    query.Parameters.Add("@VolumeFuel", SqlDbType.NVarChar).Value = textBox7.Text;
                    query.ExecuteNonQuery();
                    sqlconn.Close();
                    this.Close();
                }
            }
            else if (edit && Int32.TryParse(textBox1.Text, out temp) && Int32.TryParse(textBox2.Text, out temp) && textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "" && textBox5.Text.Trim() != "" && textBox6.Text.Trim() != "" && textBox7.Text.Trim() != "")
            {
                {

                    SqlConnection sqlconn = new SqlConnection(conn);
                    sqlconn.Open();
                    SqlCommand query = new SqlCommand(String.Format("UPDATE Info SET Lenght=@Lenght, Width=@Width, Seats=@Seats, Weight=@Weight, MaxSpeed=@MaxSpeed, TypeEngine=@TypeEngine, VolumeFuel=@VolumeFuel WHERE Id = {0}", id.ToString()), sqlconn);
                    query.Parameters.Add("@Lenght", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);
                    query.Parameters.Add("@Width", SqlDbType.Int).Value = Convert.ToInt32(textBox2.Text);
                    query.Parameters.Add("@Seats", SqlDbType.NVarChar).Value = textBox3.Text;
                    query.Parameters.Add("@Weight", SqlDbType.NVarChar).Value = textBox4.Text;
                    query.Parameters.Add("@MaxSpeed", SqlDbType.NVarChar).Value = textBox5.Text;
                    query.Parameters.Add("@TypeEngine", SqlDbType.NVarChar).Value = textBox6.Text;
                    query.Parameters.Add("@VolumeFuel", SqlDbType.NVarChar).Value = textBox7.Text;
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
