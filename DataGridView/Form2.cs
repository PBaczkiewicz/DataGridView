using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridView
{
    public partial class Form2 : Form
    {
        public int value { get; set; }
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }


        private void buttonOk_Click(object sender, EventArgs e)
        {

            if (numericUpDown1.Value >= 0 && numericUpDown1.Value <= 1000)
            {
                value = (int)numericUpDown1.Value;
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            else
            {
                MessageBox.Show("Wartość musi być pomiędzy 0, a 1000.");
            }
        }
       
    }
}
