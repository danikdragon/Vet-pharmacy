using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void dABindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dABindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.catAndDogDataSet);
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            this.dATableAdapter.Fill(this.catAndDogDataSet.DA);
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
