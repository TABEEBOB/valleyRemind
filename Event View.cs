using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace valleyRemind
{
    public partial class Event_View : Form
    {
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\tabe-ebob\Desktop\valleyRemind\EvenstLog.accdb");

        
       
        public Event_View()
        {
            InitializeComponent();
            
        }
       
       
       
        private void btnEvent_Click(object sender, EventArgs e)
        {
            this.Hide();
            New_Event newEvent = new New_Event();
        
            newEvent.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome welcome = new Welcome();
            
            welcome.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            String sDate = DateTime.Now.ToString();
            DateTime dateValue = (Convert.ToDateTime(sDate.ToString()));

            String day = dateValue.Day.ToString();
            String month = dateValue.Month.ToString();
            String year = dateValue.Year.ToString();


        }

        private void btnView_Click(object sender, EventArgs e)
        {
        

            connection.Open();
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                DateTime date = dateTimePicker1.Value;

                cmd.Connection = connection;
                String query = "SELECT * from Events where DOB = #" + date + "#";

                cmd.CommandText = query;
                    Console.WriteLine("" + query);
              
                OleDbDataAdapter oa = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                oa.Fill(dt);
                dataGridView1.DataSource = dt;

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("database not found" +ex);
            }

            connection.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            connection.Open();
            try
            {
                OleDbCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "Delete * from Events where FileNo = '"+txtDel.Text+"' ";
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
            connection.Close();
            TextClear();

        }
        void TextClear()
        {
            txtDel.Text = " ";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                String search = txtSearch.Text;

                cmd.Connection = connection;
                String query = "SELECT * from Events where FileNo ='"+search+"'";

                cmd.CommandText = query;
                Console.WriteLine("" + query);

                OleDbDataAdapter oa = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                oa.Fill(dt);
                dataGridView1.DataSource = dt;

             
            }
            catch (Exception ex)
            {
                MessageBox.Show("database not found" + ex);
            }

            connection.Close();
        }
    }
    }
    

