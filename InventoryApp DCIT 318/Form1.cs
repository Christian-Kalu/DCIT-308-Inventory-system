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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Credentials");
                return;
            }
            MySqlConnection con = crud.con();
            MySqlCommand cmd = new MySqlCommand("select * from users where userid='" + textBox1.Text + "' and password='" + textBox2.Text + "'", con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            da.Fill(tbl);
            if (tbl.Rows.Count < 1)
            {
                this.Hide();
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();


            }
            else
            {
                MessageBox.Show("Incorrect password");
            }
            con.Close();
           
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
