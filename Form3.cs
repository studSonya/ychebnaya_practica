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
    public partial class Учётная_запись : Form
    {
        public static string connectString = (@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Софья\source\repos\kursovaya\kursovaya\bin\Debug\kanctovar.mdb;");
        private OleDbConnection myConnection;


        public Учётная_запись()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();

        }
        public void Form3_formclosing()
        {

            myConnection.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "SELECT Пароль FROM Пользователи WHERE Логин ='"+textBox1.Text+"'";
            OleDbCommand command = new OleDbCommand(str, myConnection);
            if (textBox2.Text == Convert.ToString(command.ExecuteScalar()) & textBox2.Text!="")
            {
                Form f1 = new Admin();
                f1.Show();
            }
            
            //int id = Convert.ToInt32(command.ExecuteScalar());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form F5 = new Form5();
            F5.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
