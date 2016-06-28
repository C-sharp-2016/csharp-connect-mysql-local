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

        }
 

        private void insert_click(object sender, EventArgs e)
        {
            try
            {

                MySqlConnection mcon = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
                 
                mcon.Open();
                 
                MySqlCommand comm = mcon.CreateCommand();
                 
                comm.CommandText = "INSERT INTO csharp_testing1.users(username, pass) VALUES(?username, ?pass) ";
                comm.Parameters.Add("?username", username.Text);
                comm.Parameters.Add("?pass", password.Text);
                comm.ExecuteNonQuery();

                Console.WriteLine("inserted to database csharp_testing1.users");




                MySqlDataAdapter mda = new MySqlDataAdapter("Select * from  csharp_testing1.users order by id desc", mcon);
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

        private void query_click(object sender, EventArgs e)
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
