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

        private void update_click(object sender, EventArgs e)
        { 
            try  
            {  
                //This is my connection string i have assigned the database file address path  
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=";  
                //This is my update query in which i am taking input from the user through windows forms and update the record.  
                //string Query = "update student.studentinfo set idStudentInfo='" + this.IdTextBox.Text + "',Name='" + this.NameTextBox.Text + "',Father_Name='" + this.FnameTextBox.Text + "',Age='" + this.AgeTextBox.Text + "',Semester='" + this.SemesterTextBox.Text + "' where idStudentInfo='" + this.IdTextBox.Text + "';";  
                string Query = "update  csharp_testing1.users set username='my updated user name', pass='my updated password' where id > 0 ";
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);  
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);  
                MySqlDataReader MyReader2;  

                MyConn2.Open();  
                MyReader2 = MyCommand2.ExecuteReader();  
                MessageBox.Show("Data Updated");

                show_result();

                MyConn2.Close();//Connection closed here  
            }  
            catch (Exception ex)  
            {   
                MessageBox.Show(ex.Message);  
            }  
        }

        private void delete_click(object sender, EventArgs e)
        {
            try
            {
                //This is my connection string i have assigned the database file address path  
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=";
                //This is my update query in which i am taking input from the user through windows forms and update the record.  
                //string Query = "update student.studentinfo set idStudentInfo='" + this.IdTextBox.Text + "',Name='" + this.NameTextBox.Text + "',Father_Name='" + this.FnameTextBox.Text + "',Age='" + this.AgeTextBox.Text + "',Semester='" + this.SemesterTextBox.Text + "' where idStudentInfo='" + this.IdTextBox.Text + "';";  
                string Query = "delete from  csharp_testing1.users where id > 0 ";
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;

                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("All Data Deleted");

                show_result();

                MyConn2.Close();//Connection closed here  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void show_result()
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
