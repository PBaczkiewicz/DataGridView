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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            dataGridView.Rows.Add(0, 0, 0, 0);

            foreach (DataGridViewCell cell in dataGridView.Rows[0].Cells)
            {

                cell.ReadOnly = true;
            }
            dataGridView.Rows[0].DefaultCellStyle.BackColor = Color.Gray;
            dataGridView.Rows.Add(0, 0, 0, 0);


        }
        void buttonAddRow_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView.Rows[0];
            dataGridView.Rows.Add(0, 0, 0, 0);
            dataGridView.Rows.Remove(row);
            dataGridView.Rows.Insert(0, row);

        }
        void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = dataGridView.CurrentCell;
            if (cell == null)
            {
                return;
            }
            try
            {
                if (Convert.ToInt32(cell.Value) < 0 || Convert.ToInt32(cell.Value) > 1000)
                {
                    cell.Value = 0;
                    MessageBox.Show("Liczba nie może wynosić mniej niż 0 i więcej niż 1000", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch
            {
                cell.Value = 0;
            }
            UpdateSumRow();

        }
        void dataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            dataGridView.Rows[dataGridView.RowCount - 1].SetValues(0, 0, 0, 0);
        }
        void buttonDeleteRow_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = dataGridView.CurrentCell;
            try
            {
                if (cell == null || cell.RowIndex == 0)
                {
                    return;
                }
                dataGridView.Rows.RemoveAt(cell.RowIndex);
            }
            catch
            {
                return;
            }
        }
        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.E)
            {
                Form2 form2 = new Form2();
                DialogResult result = form2.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ApplyInput((int)form2.value);   
                }

            }
        }
        public void ApplyInput(int value)
        {
            foreach (DataGridViewCell cell in dataGridView.SelectedCells)
            {
                cell.Value = value;
            }
        }
        void UpdateSumRow()
        {
            int a = 0, b = 0, c = 0, d = 0;
            for (int i = 1; i < dataGridView.RowCount; i++)
            {
                a += Convert.ToInt32(dataGridView.Rows[i].Cells[0].Value);
                b += Convert.ToInt32(dataGridView.Rows[i].Cells[1].Value);
                c += Convert.ToInt32(dataGridView.Rows[i].Cells[2].Value);
                d += Convert.ToInt32(dataGridView.Rows[i].Cells[3].Value);
            }
            dataGridView.Rows[0].SetValues(a, b, c, d);
        }
    }
}
