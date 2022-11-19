using System;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace kursovaya
{

    public partial class Admin : Form
    {
        OleDbDataAdapter sda;
        public static string connectString = (@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Софья\source\repos\kursovaya\kursovaya\bin\Debug\kanctovar.mdb;");
        private OleDbConnection myConnection;


        public Admin()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str="1";
            
            string str2 = "SELECT MAX(Код) FROM zzz";


            OleDbCommand command = new OleDbCommand(str2, myConnection);
           int z= Convert.ToInt32(command.ExecuteScalar());

            string str1 = "INCERT INTO (IDT, Категория, Наименование, 'Единицы измерения', 'Закупочная цена') VALUES ("+z+",1,1,1,1) ";
            command = new OleDbCommand(str2, myConnection);
            //textBox1.Text=Convert.ToString(command.ExecuteNonQuery());
            z = Convert.ToInt32(command.ExecuteScalar());
            using (OleDbConnection myConnection = new OleDbConnection(connectString))
            using (OleDbDataAdapter sda = new OleDbDataAdapter(str1, myConnection));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
               int i= dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(i);
            

            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int z = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (z == 1)
                    { break; }
                    if (Convert.ToString(dataGridView1.Rows[i].Cells[j].Value).Contains(textBox1.Text))
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[j];
                        z = 1;
                        break;
                    }
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin.ActiveForm.Close(); 
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {
          
            this.товарTableAdapter.Fill(this.db.Товар);

            
            DataTable dt = new DataTable();


            string str = "SELECT Категория FROM Товар GROUP BY Категория  ";
            OleDbCommand command = new OleDbCommand(str, myConnection);
            
            using (OleDbConnection myConnection = new OleDbConnection(connectString))
            using (OleDbDataAdapter sda = new OleDbDataAdapter(str, myConnection))
            {
                dt = new DataTable();
                sda.Fill(dt);


                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "Категория";

            }

            str = "SELECT ЕдиницыИзмерения FROM Товар GROUP BY ЕдиницыИзмерения  ";
            command = new OleDbCommand(str, myConnection);
            
            using (OleDbConnection myConnection = new OleDbConnection(connectString))
            using (OleDbDataAdapter sda = new OleDbDataAdapter(str, myConnection))
            {
                dt = new DataTable();
                sda.Fill(dt);
                //dataGridView1.DataSource = dt;
                comboBox3.DataSource = dt;
                comboBox3.DisplayMember = "ЕдиницыИзмерения";
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;

            DataTable dt = this.db.Товар;
            DataRow row = dt.NewRow();

            row[0] = dataGridView1.Rows.Count;
            row[1] = comboBox2.Text;
            row[2] = textBox2.Text;
            row[3] = comboBox3.Text;
            row[4] = textBox4.Text;

            dt.Rows.Add(row);
            dataGridView1.DataSource = dt;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
