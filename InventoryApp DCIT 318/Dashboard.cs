using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryApp_DCIT_318
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crud.sql("INSERT INTO `users`( `UserID`, `Username`, `Password`, `Usertype`) " +
              "VALUES ('" + txtusername.Text + "','" + txtuserid.Text + "','" + txtpassword.Text + "','" + txtusertype.Text + "')");
            crud.display("select * from Users", dataGridView1);

        }

        private void add_manager_panel_Enter(object sender, EventArgs e)
        {
            crud.display("select * from Users", dataGridView1);
        }
    }
}
