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
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        static string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Ddd.mdb";
        private OleDbConnection Connection;
        
        public Form2()
        {
            InitializeComponent();
            Connection = new OleDbConnection(ConnectionString);
            Connection.Open();
            dataGridView1.Update();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.tabl1TableAdapter.Fill(this.dddDataSet.tabl1);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO tabl1 (Логин, Пароль, Уровень) VALUES ('" + textBoxLog.Text + "','" + textBoxPas.Text + "','" + Convert.ToInt32(comboBoxAcs.Text) + "')";
            OleDbCommand command = new OleDbCommand(query, Connection);
            command.ExecuteNonQuery();
            UpdateGreed(); 
            ButtonCleer();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index; 
            int meaning = Convert.ToInt32(dataGridView1[0, index].Value);    
            string query = "DELETE FROM tabl1 WHERE [Код] = " + meaning;
            OleDbCommand com = new OleDbCommand(query, Connection);
            com.ExecuteNonQuery();
            UpdateGreed(); 
            ButtonCleer();
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
        public void ButtonCleer()
        {
            textBoxLog.Text = "";
            textBoxPas.Text = "";
            comboBoxAcs.Text = "";
        }
        public void UpdateGreed()
        {
            Thread.Sleep(550);
            this.tabl1TableAdapter.Fill(this.dddDataSet.tabl1);
            dataGridView1.Update();
        }
    }
}
