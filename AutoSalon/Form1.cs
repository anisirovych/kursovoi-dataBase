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
    public partial class Main : Form
    {
        string conn = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AvtoSalon.mdf;Integrated Security = True";
        public Main()
        {
            InitializeComponent();
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            Auto();
        }
        public void Auto()
        {
            SqlConnection sqlconn = new SqlConnection(conn);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Auto", sqlconn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label1.Text = "Авто";
            dataGridView1.DataSource = dt;
            textBox1.Visible = true;
            button1.Visible = true;
            button1.Text = "Искать по марке";
            button2.Text = "Сортировать по цене";
            button3.Text = "Сортировать по дате прибытия";
            button3.Enabled = true;
        }

        public void Client()
        {
            SqlConnection sqlconn = new SqlConnection(conn);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Client", sqlconn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label1.Text = "Клиенты";
            dataGridView1.DataSource = dt;
            textBox1.Visible = true;
            button1.Visible = true;
            button1.Text = "Искать по фамилии";
            button2.Text = "Сортировать по алфавиту";
            button3.Visible = false;
        }

        public void Employee()
        {
            SqlConnection sqlconn = new SqlConnection(conn);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Employee", sqlconn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label1.Text = "Сотрудники";
            dataGridView1.DataSource = dt;
            textBox1.Visible = true;
            button1.Visible = true;
            button1.Text = "Искать по фамилии";
            button2.Text = "Сортировать по алфавиту";
            button3.Text = "Сортировать по зарплате";
            button3.Visible = true;
        }
        public void Position()
        {
            SqlConnection sqlconn = new SqlConnection(conn);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Position", sqlconn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label1.Text = "Должность";
            dataGridView1.DataSource = dt;
            textBox1.Visible = true;
            button1.Visible = true;
            button1.Text = "Искать";
            button2.Text = "Сортировать по алфавиту";
            button3.Visible = false;
        }
        public void Info()
        {
            SqlConnection sqlconn = new SqlConnection(conn);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Info", sqlconn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label1.Text = "Информация";
            dataGridView1.DataSource = dt;
            textBox1.Visible = true;
            button1.Visible = true;
            button1.Text = "Искать по типу кузова";
            button2.Text = "Сортировать по скорости";
            button3.Text = "Сортировать по объему двигателя";
            button3.Visible = true;
        }
        public void Provider()
        {
            SqlConnection sqlconn = new SqlConnection(conn);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Provider", sqlconn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label1.Text = "Поставщики";
            dataGridView1.DataSource = dt;
            textBox1.Visible = true;
            button1.Visible = true;
            button1.Text = "Искать по названию";
            button2.Text = "Сортировать по алфавиту";
            button3.Visible = false;
        }

        public void Selling()
        {
            SqlConnection sqlconn = new SqlConnection(conn);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Selling", sqlconn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label1.Text = "Продажи";
            dataGridView1.DataSource = dt;
            textBox1.Visible = false;
            button1.Visible = false;
            button1.Text = "";
            button2.Text = "Сортировать по дате";
            button3.Visible = false;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void автоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Auto();
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client();
        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee();
        }

        private void должностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Position();
        }

        private void информацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Info();
        }

        private void поставщикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Provider();
        }

        private void продажиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Selling();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (label1.Text)
            {
                case ("Авто"):
                    {
                        var ep = new AutoEdit();
                        ep.ShowDialog();
                        Auto();
                        avtoSalonDataSet.AcceptChanges();
                        break;
                    }
                case ("Клиенты"):
                    {
                        var ep = new ClientEdit();
                        ep.ShowDialog();
                        Client();
                        avtoSalonDataSet.AcceptChanges();
                        break;
                    }
                case ("Поставщики"):
                    {
                        var ep = new ProviderEdit();
                        ep.ShowDialog();
                        Provider();
                        avtoSalonDataSet.AcceptChanges();
                        break;
                    }
                case ("Информация"):
                    {
                        var ep = new InfoEdit();
                        ep.ShowDialog();
                        Info();
                        avtoSalonDataSet.AcceptChanges();
                        break;
                    }
                case ("Должность"):
                    {
                        var ep = new PosEdit();
                        ep.ShowDialog();
                        Position();
                        avtoSalonDataSet.AcceptChanges();
                        break;
                    }
                case ("Сотрудники"):
                    {
                        var ep = new EmpEdit();
                        ep.ShowDialog();
                        Employee();
                        avtoSalonDataSet.AcceptChanges();
                        break;
                    }
                case ("Продажи"):
                    {
                        var ep = new SellEdit();
                        ep.ShowDialog();
                        Selling();
                        avtoSalonDataSet.AcceptChanges();
                        break;
                    }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (label1.Text)
            {
                case ("Авто"):
                    {
                        DataGridViewRow temp = dataGridView1.SelectedRows[0];
                        var ep = new AutoEdit(Convert.ToInt32(temp.Cells[0].Value),
                            Convert.ToString(temp.Cells[1].Value),
                            Convert.ToString(temp.Cells[2].Value),
                            Convert.ToDateTime(temp.Cells[3].Value),
                            Convert.ToDecimal(temp.Cells[4].Value),
                            Convert.ToInt32(temp.Cells[5].Value),
                            Convert.ToInt32(temp.Cells[6].Value));
                        ep.ShowDialog();
                        Auto();
                        avtoSalonDataSet.AcceptChanges();
                        break;
                    }
                case ("Клиенты"):
                    {
                        DataGridViewRow temp = dataGridView1.SelectedRows[0];
                        var ep = new ClientEdit(Convert.ToInt32(temp.Cells[0].Value),
                            Convert.ToString(temp.Cells[1].Value),
                            Convert.ToString(temp.Cells[2].Value),
                            Convert.ToString(temp.Cells[3].Value));
                        ep.ShowDialog();
                        Client();
                        avtoSalonDataSet.AcceptChanges();
                        break;
                    }
                case ("Поставщики"):
                    {
                        DataGridViewRow temp = dataGridView1.SelectedRows[0];
                        var ep = new ProviderEdit(Convert.ToInt32(temp.Cells[0].Value),
                            Convert.ToString(temp.Cells[1].Value),
                            Convert.ToString(temp.Cells[2].Value),
                            Convert.ToString(temp.Cells[3].Value));
                        ep.ShowDialog();
                        Provider();
                        avtoSalonDataSet.AcceptChanges();
                        break;
                    }
                case ("Информация"):
                    {
                        DataGridViewRow temp = dataGridView1.SelectedRows[0];
                        var ep = new InfoEdit(Convert.ToInt32(temp.Cells[0].Value),
                           Convert.ToInt32(temp.Cells[1].Value),
                           Convert.ToInt32(temp.Cells[2].Value),
                           Convert.ToString(temp.Cells[3].Value),
                           Convert.ToString(temp.Cells[4].Value),
                           Convert.ToString(temp.Cells[5].Value),
                           Convert.ToString(temp.Cells[6].Value),
                           Convert.ToString(temp.Cells[7].Value));
                        ep.ShowDialog();
                        Info();
                        avtoSalonDataSet.AcceptChanges();
                        break;
                    }
                case ("Должность"):
                    {
                        DataGridViewRow temp = dataGridView1.SelectedRows[0];
                        var ep = new PosEdit(Convert.ToInt32(temp.Cells[0].Value),
                           Convert.ToString(temp.Cells[1].Value));
                        ep.ShowDialog();
                        Position();
                        avtoSalonDataSet.AcceptChanges();
                        break;
                    }
                case ("Сотрудники"):
                    {
                        DataGridViewRow temp = dataGridView1.SelectedRows[0];
                        var ep = new EmpEdit(Convert.ToInt32(temp.Cells[0].Value),
                           Convert.ToString(temp.Cells[1].Value),
                           Convert.ToInt32(temp.Cells[2].Value),
                           Convert.ToDateTime(temp.Cells[3].Value),
                           Convert.ToDateTime(temp.Cells[4].Value),
                           Convert.ToDecimal(temp.Cells[5].Value));
                        ep.ShowDialog();
                        Position();
                        avtoSalonDataSet.AcceptChanges();
                        break;
                    }
                case ("Продажи"):
                    {
                        DataGridViewRow temp = dataGridView1.SelectedRows[0];
                        var ep = new SellEdit(Convert.ToInt32(temp.Cells[0].Value),
                           Convert.ToInt32(temp.Cells[1].Value),
                           Convert.ToInt32(temp.Cells[2].Value),
                           Convert.ToInt32(temp.Cells[3].Value),
                           Convert.ToDateTime(temp.Cells[4].Value),
                           Convert.ToString(temp.Cells[5].Value));
                        ep.ShowDialog();
                        Position();
                        avtoSalonDataSet.AcceptChanges();
                        break;
                    }

            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (label1.Text)
            {
                case ("Авто"):
                    {
                        SqlConnection sqlconn = new SqlConnection(conn);
                        sqlconn.Open();
                        SqlCommand query = new SqlCommand("Delete From Auto Where Id =" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), sqlconn);
                        query.ExecuteNonQuery();
                        sqlconn.Close();
                        Auto();
                        avtoSalonDataSet.AcceptChanges();
                        break;
                    }
                case ("Клиенты"):
                    {
                        SqlConnection sqlconn = new SqlConnection(conn);
                        sqlconn.Open();
                        SqlCommand query = new SqlCommand("Delete From Client Where Id =" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), sqlconn);
                        query.ExecuteNonQuery();
                        sqlconn.Close();
                        Client();
                        avtoSalonDataSet.AcceptChanges();
                        break;
                    }
                case ("Поставщики"):
                    {
                        SqlConnection sqlconn = new SqlConnection(conn);
                        sqlconn.Open();
                        SqlCommand query = new SqlCommand("Delete From Provider Where Id =" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), sqlconn);
                        query.ExecuteNonQuery();
                        sqlconn.Close();
                        Provider();
                        avtoSalonDataSet.AcceptChanges();
                        break;
                    }
                case ("Информация"):
                    {
                        SqlConnection sqlconn = new SqlConnection(conn);
                        sqlconn.Open();
                        SqlCommand query = new SqlCommand("Delete From Info Where Id =" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), sqlconn);
                        query.ExecuteNonQuery();
                        sqlconn.Close();
                        Info();
                        avtoSalonDataSet.AcceptChanges();
                        break;
                    }
                case ("Должность"):
                    {
                        SqlConnection sqlconn = new SqlConnection(conn);
                        sqlconn.Open();
                        SqlCommand query = new SqlCommand("Delete From Position Where Id =" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), sqlconn);
                        query.ExecuteNonQuery();
                        sqlconn.Close();
                        Position();
                        avtoSalonDataSet.AcceptChanges();
                        break;
                    }
                case ("Сотрудники"):
                    {
                        SqlConnection sqlconn = new SqlConnection(conn);
                        sqlconn.Open();
                        SqlCommand query = new SqlCommand("Delete From Employee Where Id =" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), sqlconn);
                        query.ExecuteNonQuery();
                        sqlconn.Close();
                        Employee();
                        avtoSalonDataSet.AcceptChanges();
                        break;
                    }
                case ("Продажи"):
                    {
                        SqlConnection sqlconn = new SqlConnection(conn);
                        sqlconn.Open();
                        SqlCommand query = new SqlCommand("Delete From Selling Where Id =" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), sqlconn);
                        query.ExecuteNonQuery();
                        sqlconn.Close();
                        Selling();
                        avtoSalonDataSet.AcceptChanges();
                        break;
                    }

            }
        }

        private void randomQueriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var s = new SQL();
            s.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (label1.Text)
            {
                case ("Авто"):
                    {
                        try
                        {
                            string selectString =
                            "Mark Like '" + textBox1.Text.Trim() + "%'";

                            DataRowCollection allRows =
                            ((DataTable)dataGridView1.DataSource).Rows;

                            DataRow[] searchedRows =
                            ((DataTable)dataGridView1.DataSource).
                            Select(selectString);

                            int rowIndex = allRows.IndexOf(searchedRows[0]);

                            dataGridView1.CurrentCell =
                            dataGridView1[0, rowIndex];
                        }
                        catch (IndexOutOfRangeException t)
                        {
                            MessageBox.Show("Слово не найдено", "Предупреждение", MessageBoxButtons.OK);
                        }
                        break;
                    }
                case ("Информация"):
                    {
                        try
                        {
                            string selectString =
                            "TypeEngine Like '" + textBox1.Text.Trim() + "%'";

                            DataRowCollection allRows =
                            ((DataTable)dataGridView1.DataSource).Rows;

                            DataRow[] searchedRows =
                            ((DataTable)dataGridView1.DataSource).
                            Select(selectString);

                            int rowIndex = allRows.IndexOf(searchedRows[0]);

                            dataGridView1.CurrentCell =
                            dataGridView1[0, rowIndex];
                        }
                        catch (IndexOutOfRangeException t)
                        {
                            MessageBox.Show("Слово не найдено", "Предупреждение", MessageBoxButtons.OK);
                        }
                        break;
                    }
                case ("Сотрудники"):
                    {
                        try
                        {
                            string selectString =
                            "FullName Like '" + textBox1.Text.Trim() + "%'";

                            DataRowCollection allRows =
                            ((DataTable)dataGridView1.DataSource).Rows;

                            DataRow[] searchedRows =
                            ((DataTable)dataGridView1.DataSource).
                            Select(selectString);

                            int rowIndex = allRows.IndexOf(searchedRows[0]);

                            dataGridView1.CurrentCell =
                            dataGridView1[0, rowIndex];
                        }
                        catch (IndexOutOfRangeException t)
                        {
                            MessageBox.Show("Слово не найден", "Предупреждение", MessageBoxButtons.OK);
                        }
                        break;
                    }
                case ("Должность"):
                    {
                        try
                        {
                            string selectString =
                            "Name Like '" + textBox1.Text.Trim() + "%'";

                            DataRowCollection allRows =
                            ((DataTable)dataGridView1.DataSource).Rows;

                            DataRow[] searchedRows =
                            ((DataTable)dataGridView1.DataSource).
                            Select(selectString);

                            int rowIndex = allRows.IndexOf(searchedRows[0]);

                            dataGridView1.CurrentCell =
                            dataGridView1[0, rowIndex];
                        }
                        catch (IndexOutOfRangeException t)
                        {
                            MessageBox.Show("Слово не найдено", "Предупреждение", MessageBoxButtons.OK);
                        }
                        break;
                    }
                case ("Поставщики"):
                    {
                        try
                        {
                            string selectString =
                            "Name Like '" + textBox1.Text.Trim() + "%'";

                            DataRowCollection allRows =
                            ((DataTable)dataGridView1.DataSource).Rows;

                            DataRow[] searchedRows =
                            ((DataTable)dataGridView1.DataSource).
                            Select(selectString);

                            int rowIndex = allRows.IndexOf(searchedRows[0]);

                            dataGridView1.CurrentCell =
                            dataGridView1[0, rowIndex];
                        }
                        catch (IndexOutOfRangeException t)
                        {
                            MessageBox.Show("Слово не найдено", "Предупреждение", MessageBoxButtons.OK);
                        }
                        break;
                    }
                case ("Клиенты"):
                    {
                        try
                        {
                            string selectString =
                            "FullName Like '" + textBox1.Text.Trim() + "%'";

                            DataRowCollection allRows =
                            ((DataTable)dataGridView1.DataSource).Rows;

                            DataRow[] searchedRows =
                            ((DataTable)dataGridView1.DataSource).
                            Select(selectString);

                            int rowIndex = allRows.IndexOf(searchedRows[0]);

                            dataGridView1.CurrentCell =
                            dataGridView1[0, rowIndex];
                        }
                        catch (IndexOutOfRangeException t)
                        {
                            MessageBox.Show("Слово не найдено", "Предупреждение", MessageBoxButtons.OK);
                        }
                        break;
                    }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (label1.Text)
            {
                case ("Авто"):
                    {
                        SqlConnection sqlconn = new SqlConnection(conn);
                        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Auto ORDER BY Cost;", sqlconn);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                        break;
                    }
                case ("Информация"):
                    {
                        SqlConnection sqlconn = new SqlConnection(conn);
                        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Info ORDER BY MaxSpeed;", sqlconn);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                        break;
                    }
                case ("Сотрудники"):
                    {
                        SqlConnection sqlconn = new SqlConnection(conn);
                        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Employee ORDER BY FullName;", sqlconn);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                        break;
                    }
                case ("Должность"):
                    {
                        SqlConnection sqlconn = new SqlConnection(conn);
                        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Position ORDER BY Name;", sqlconn);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                        break;
                    }
                case ("Поставщики"):
                    {
                        SqlConnection sqlconn = new SqlConnection(conn);
                        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Provider ORDER BY Name;", sqlconn);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                        break;
                    }
                case ("Клиенты"):
                    {
                        SqlConnection sqlconn = new SqlConnection(conn);
                        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Client ORDER BY FullName;", sqlconn);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                        break;
                    }
                case ("Продажи"):
                    {
                        SqlConnection sqlconn = new SqlConnection(conn);
                        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Selling ORDER BY Date;", sqlconn);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                        break;
                    }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (label1.Text)
            {
                case ("Авто"):
                    {
                        SqlConnection sqlconn = new SqlConnection(conn);
                        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Auto ORDER BY DateSupply;", sqlconn);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                        break;
                    }
                case ("Сотрудники"):
                    {
                        SqlConnection sqlconn = new SqlConnection(conn);
                        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Employee ORDER BY Salary;", sqlconn);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                        break;
                    }
                case ("Информация"):
                    {
                        SqlConnection sqlconn = new SqlConnection(conn);
                        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Info ORDER BY VolumeFuel;", sqlconn);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                        break;
                    }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var s = new AutoFilter(this);
            s.Show();
        }

        private void quieriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
             var s = new Queries();
            s.Show();
        }
    }
}
    