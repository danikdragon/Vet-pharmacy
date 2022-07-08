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
    public partial class Form5 : Form
    {
        string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=CatAndDog.mdb";
        private OleDbConnection Connection;
        OleDbCommand dbcom;
        public Form5()
        {
            InitializeComponent();
            Connection = new OleDbConnection(ConnectionString);
            Connection.Open();
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            this.dATableAdapter.Fill(this.catAndDogDataSet.DA);
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string CommandText = "INSERT INTO DA (тип, название, цена) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "')";
            OleDbCommand cmd = new OleDbCommand(CommandText, Connection);
            cmd.ExecuteNonQuery();
            UpdateGreed();
            ButtonCleer();
        }
        private void button3_Click(object sender, EventArgs e)
        {
           int index = dADataGridView.CurrentRow.Index;
           int meaning = Convert.ToInt32(dADataGridView[0, index].Value);
           string query = "DELETE FROM DA WHERE [Код] = " + meaning;
           OleDbCommand com = new OleDbCommand(query, Connection);
           com.ExecuteNonQuery();
            UpdateGreed();
            ButtonCleer();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)//sum
        {
            string CommandText = "SELECT SUM(цена) AS AllSum FROM DA";
            dbcom = new OleDbCommand(CommandText);//
            dbcom.Connection = Connection; // Отправка запроса
            OleDbDataReader summaryreader = dbcom.ExecuteReader();//
            if (summaryreader.Read())
            {
                toolStripLabel4.Text = "цена" + summaryreader["allSum"].ToString();
            }
            dADataGridView.Update();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)//searh
        {
            dABindingSource.Filter = "название LIKE '" + toolStripTextBox1.Text + "%'";
            toolStripTextBox1.Text = "";
        }
        public void ButtonCleer()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
        public void UpdateGreed()
        {
            Thread.Sleep(550);
            this.dATableAdapter.Fill(this.catAndDogDataSet.DA);
            dADataGridView.Update();
        }
    }
}
