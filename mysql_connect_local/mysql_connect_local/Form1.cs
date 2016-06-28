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

namespace mysql_connect_local
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection mcon = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");

                MySqlDataAdapter mda = new MySqlDataAdapter("Select * from  csharp_testing1.users", mcon);

                mcon.Open();

                DataSet ds = new DataSet();

                mda.Fill(ds, "users");

                dataGridView1.DataSource = ds.Tables["users"];

                mcon.Close(); 

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
