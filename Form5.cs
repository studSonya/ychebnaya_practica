using System;
using System.Data.OleDb;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursovaya
{
    public partial class Form5 : Form
    {
        public static string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Софья\source\repos\kursovaya\kursovaya\bin\Debug\kanctovar.mdb;";
        private OleDbConnection myConnection;
        public Form5()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Пользователи WHERE Логин = '" + textBox1.Text + "'"; //Логин =" + "'" +  + "'";
            myConnection.Open();

            OleDbCommand command = new OleDbCommand(query, myConnection);

            if (Convert.ToString(command.ExecuteScalar()) == "" & textBox2.Text != "")
            {

                if (textBox3.Text == textBox4.Text & textBox4.Text != "" & textBox3.Text != "")
                {
                    query = "INSERT INTO Пользователи(Логин, Пароль) values('" + textBox2.Text + "', '" + textBox3.Text + "')"; //Логин =" + "'" +  + "'";

                    command = new OleDbCommand(query, myConnection);




                    command.ExecuteNonQuery();

                    MessageBox.Show("Пользователь создан!");
                }
                else
                {
                    MessageBox.Show("Разные!");
                }
            }
            else
            {
                textBox1.Text = Convert.ToString(command.ExecuteScalar());
                MessageBox.Show("Есть такой пользователь");
            }
            myConnection.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
