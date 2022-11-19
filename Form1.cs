using System;
using System.Collections.Generic;
using System.Windows;
using System.Data.OleDb;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Reflection;


namespace kursovaya
{
    public partial class Website : Form
    {
        MySqlDataAdapter ms_data;
        int colvo = 1;
        int MaxColvo = 10;
        private SqlConnection sqlConnection = null;
        public static string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Софья\source\repos\kursovaya (2)\kursovaya\kanctovar.mdb;";
        private OleDbConnection myConnection;
        public Website()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
        }

        public MySqlConnection mycon;
        public MySqlCommand mycom;
        public string connect = "Server=localhost;Database=teach;Uid=root;pwd=123;charset=utf8;";
        public List<Button> buttons = new List<Button>();

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "db1.Магазин". При необходимости она может быть перемещена или удалена.
            this.магазинTableAdapter.Fill(this.db.Магазин);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "db.Товар". При необходимости она может быть перемещена или удалена.
            this.товарTableAdapter.Fill(this.db.Товар);

            foreach(Button b in buttons)
            {
                this.Controls.Remove(b);
            }
            List<string> arr = new List<string>();
            
            for (int i = 0; i < db.Товар.Rows.Count; i++)
            {
                if (i == 0)
                {
                    button5.Text = db.Товар.Rows[i].ItemArray[1].ToString();
                    arr.Add(db.Товар.Rows[i].ItemArray[1].ToString());
                }
                else
                {
                    int z = 0;
                    foreach (string elm in arr)
                    {
                        if (elm == (db.Товар.Rows[i].ItemArray[1].ToString()))
                        {
                            z = 1;
                        }
                    }
                    if (z != 1)
                    {
                        arr.Add(db.Товар.Rows[i].ItemArray[1].ToString());
                        newbutton(db.Товар.Rows[i].ItemArray[1].ToString());
                    }
                }
            }      
            


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Магазин;
            label1.Text = "Сотрудничество:";
            button5.Visible = false;
            button5.Enabled = false;
            foreach (Button b in buttons)
            {
                b.Visible = false;
                b.Enabled = false;
            }
            dataGridView1.Visible = true;
            dataGridView1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Товар;
            label1.Text = "Каталог товаров:";
            dataGridView1.Visible = false;
            dataGridView1.Enabled = false;
            button5.Visible = true;
            button5.Enabled = true;
            foreach (Button b in buttons)
            {
                this.Controls.Remove(b);
            }
            colvo = 1;
            List<string> arr = new List<string>();

            for (int i = 0; i < db.Товар.Rows.Count; i++)
            {
                if (i == 0)
                {
                    button5.Text = db.Товар.Rows[i].ItemArray[1].ToString();
                    arr.Add(db.Товар.Rows[i].ItemArray[1].ToString());
                }
                else
                {
                    int z = 0;
                    foreach (string elm in arr)
                    {
                        if (elm == (db.Товар.Rows[i].ItemArray[1].ToString()))
                        {
                            z = 1;
                        }
                    }
                    if (z != 1)
                    {
                        arr.Add(db.Товар.Rows[i].ItemArray[1].ToString());
                        newbutton(db.Товар.Rows[i].ItemArray[1].ToString());
                    }
                }
            }
        }
        int i1 = 0;
        int j1 = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            myConnection.Open();
            string str1 = "SELECT * FROM Товар";
            myConnection = new OleDbConnection(connectString);
            OleDbDataAdapter sda = new OleDbDataAdapter(str1, myConnection);
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            myConnection.Close();
            
            {
                int[] arr = search(i1,j1, textBox1.Text,dataGridView1);
                if (arr != null)
                {
                    i1 = arr[0];
                    if (arr[1] == 4)
                    {
                        if (arr[0] == dataGridView1.Rows.Count - 1)
                        {
                            i1 = 0;
                        }
                        else
                        {
                            i1++;
                        }
                        j1 = 0;
                    }
                    else
                    {
                        i1 = arr[0];
                        j1 = arr[1]+1;
                    }
                    
                }
                else
                {
                    search(i1, j1, textBox1.Text,dataGridView1);
                }
            }
            
        }
        public int[] search(int i2,int j2,string ser,DataGridView dataGridView1)
        {
            for (int i = i2; i < dataGridView1.RowCount; i++)
            {
                for (int j = j2; j < dataGridView1.ColumnCount; j++)
                {
                    if (Convert.ToString(dataGridView1.Rows[i].Cells[j].Value).Contains(ser))
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[j];
                        return new[] {i,j};

                    }
                }
                j2 = 0;
                j1 = 0;
            }
            i2 = 0;
            i1 = 0;
            return null;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form Website = new Учётная_запись();
            Website.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Visible = false;
            button5.Enabled = false;
            foreach (Button b in buttons)
            {
                b.Visible = false;
                b.Enabled = false;
            }
            dataGridView1.Visible = true;
            dataGridView1.Enabled = true;
            var btn = sender as Button;
            myConnection.Open();
            string str1 = "SELECT * FROM Товар WHERE Категория='" + btn.Text + "'";
            myConnection = new OleDbConnection(connectString);
            OleDbDataAdapter sda = new OleDbDataAdapter(str1, myConnection);
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            myConnection.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            mycon = new MySqlConnection(connect);
            mycon.Open();
            MessageBox.Show("DB CONNECT");
            mycon.Close();
            string script = "select * from tovars";
            mycon = new MySqlConnection(connect);
            mycon.Open();
            ms_data = new MySqlDataAdapter(script, connect);
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }
        public static T Clone<T>(T controlToClone) where T : Control
        {
            T instance = Activator.CreateInstance<T>();

            Type control = controlToClone.GetType();
            PropertyInfo[] info = control.GetProperties();
            object p = control.InvokeMember("", System.Reflection.BindingFlags.CreateInstance, null, controlToClone, null);
            foreach (PropertyInfo pi in info)
            {
                if ((pi.CanWrite) && !(pi.Name == "WindowTarget") && !(pi.Name == "Capture"))
                {
                    pi.SetValue(instance, pi.GetValue(controlToClone, null), null);
                }
            }
            return instance;

        }

        private void button21_Click(object sender, EventArgs e)
        {
            string[] arr = new string[]
            {
                "aaa",
                "bbb",
                "ccc"
            };
            for(int i=0;i<arr.Length;i++)
            {
                newbutton(arr[i]);
            }

        }
        public void newbutton(string text)
         {
                Button b = Clone(button5);
            b.Click += new System.EventHandler(this.button5_Click);
            b.Text = text;
                b.Left += (colvo % 5) * 200;
                b.Top += (colvo / 5) * 100;
                if (colvo != MaxColvo - 1)
                    colvo++;
            buttons.Add(b);
            }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void click1()
        {
            button5.Visible = false;
            button5.Enabled = false;
            foreach (Button b in buttons)
            {
                b.Visible = false;
                b.Enabled = false;
            }
            dataGridView1.Visible = true;
            dataGridView1.Enabled = true;
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
    }
