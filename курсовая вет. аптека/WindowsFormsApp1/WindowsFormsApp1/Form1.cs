using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Ddd.mdb";
        private OleDbConnection Connection;
        public Form1()
        {
            InitializeComponent();
            Connection = new OleDbConnection(ConnectionString);
            Connection.Open();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string query = "Select * From tabl1 WHERE Логин = '" + LoginTextBox.Text + "' AND Пароль = '" + PasswordTextBox.Text + "'";
            OleDbDataAdapter command = new OleDbDataAdapter(query, Connection);
            DataTable dt = new DataTable();
            command.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Class1.Dostup = Convert.ToInt32(dt.Rows[0][3]);
                if (Class1.Dostup == 1)
                {
                    Form2 fr2 = new Form2();
                    fr2.Show();
                    this.Hide();
                }
                if (Class1.Dostup == 0)
                {
                    Form5 fr5 = new Form5();
                    fr5.Show();
                    this.Hide();
                }
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void BuyerS_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://kotopes.kz/");
        }
    }
}
