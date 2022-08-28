using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace InventoryApp_DCIT_318
{
    public partial class frmSales : Form
    {
        public frmSales()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                crud.sql("update stockitems set itemqty=itemqty - " + row.Cells[1].Value + " where itemcode='" + row.Cells[1].Value + "'");
                crud.sql("INSERT INTO `salestransaction`( `Itemname`, `Price`, `Qty`, `Amount`) " +
              "VALUES ('" + row.Cells[0].Value.ToString() + "','" + row.Cells[1].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "','" + row.Cells[3].Value.ToString() + "')");
            }
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();

            }

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(lblitemname.Text, txtPrice.Text, txtQty.Text, txtAmt.Text);
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            decimal amt = Convert.ToDecimal(txtPrice.Text) * Convert.ToDecimal(txtQty.Text);
            txtAmt.Text = amt.ToString();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double Total = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                Total += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                label6.Text = Total.ToString();

            }
        }

        private void frmSales_Load(object sender, EventArgs e)
        {
            crud.combofeed("select itemname from stockitems", comboBox1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = crud.con();
            MySqlCommand cmd = new MySqlCommand("select * from stockitems where itemname='" + comboBox1.Text + "'", conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtPrice.Text = dr.GetValue(5).ToString();
                lblitemname.Text = dr.GetValue(1).ToString();
            }
            else
            {
                MessageBox.Show("No such Item");
            }
            conn.Close();
        }
    }
}
