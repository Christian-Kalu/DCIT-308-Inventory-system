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
    public partial class frmManager : Form
    {
        public frmManager()
        {
            InitializeComponent();
        }
       

        private void make_unPaid_btn_Click(object sender, EventArgs e)
        {
         
           crud.sql("INSERT INTO `stockitems`(`Itemcode`, `Itemname`, `ItemSize`, `ItemColour`, `ItemCategory`, `ItemPrice`, `ItemQty`, `Reoderlevel`) " +
               "VALUES ('" + txtItemcode.Text + "','" + txtItemname.Text + "','" + txtSize.Text + "','" + txtColor.Text + "','" + cbCat.Text + "','" + txtPrice.Text + "','" + txtQty.Text + "','" + txtReoder.Text + "')");
            crud.display("select * from stockitems", dataGridView1);
        }

        private void cancel_order_btn_Click(object sender, EventArgs e)
        {
            crud.sql("DELETE FROM `stockitems` WHERE itemcode='" + txtItemcode.Text + "'");
            crud.display("select * from stockitems", dataGridView1);

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
           
            crud.sql("UPDATE `stockitems` SET `Itemname`='" + txtItemname.Text + "'," +
               "`ItemSize`='" + txtSize.Text + "',`ItemColour`='" + txtColor.Text + "',`ItemCategory`='" + cbCat.Text + "'," +
               "`ItemPrice`='" + txtPrice.Text + "',`ItemQty`='" + txtQty.Text + "',`Reoderlevel`='" + txtReoder.Text + "' " +
               "WHERE Itemcode='" + txtItemcode.Text + "'");
            crud.display("select * from stockitems", dataGridView1);
        }

        private void paid_orders_panel_Enter(object sender, EventArgs e)
        {
            crud.display("select * from stockitems", dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            string ukey = row.Cells["itemcode"].Value.ToString();
            MySqlConnection conn = crud.con();
            string query = "select * from stockitems where itemcode='" + ukey + "'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtItemcode.Text = dr.GetValue(0).ToString();
                txtItemname.Text = dr.GetValue(1).ToString();
                txtSize.Text = dr.GetValue(2).ToString();
                txtColor.Text = dr.GetValue(3).ToString();
                cbCat.Text = dr.GetValue(4).ToString();
                txtPrice.Text = dr.GetValue(5).ToString();
                txtQty.Text = dr.GetValue(6).ToString();
                txtReoder.Text = dr.GetValue(7).ToString();
            }
            conn.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }
    }
}
