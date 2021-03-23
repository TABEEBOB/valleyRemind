using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace valleyRemind
{
    public partial class New_Event : Form
    {

        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\tabe-ebob\Desktop\valleyRemind\EvenstLog.accdb");

        public New_Event()
        {
            InitializeComponent();
            
        }

        private void btnDatabase_Click(object sender, EventArgs e)
        {
           if (txtFirstname.Text == " " || txtLastname.Text == ""
                || txtStreet.Text=="" || txtCity.Text=="" || txtState.Text==""
                || txtZipcode.Text=="" || txtEmail.Text=="" || txtPhone.Text=="")
            {
                MessageBox.Show("Please fill every option");
            }

            connection.Open();
            try
            {
               
                OleDbCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT into Events(FileNo, FirstName, LastName, Street, City, State, Zipcode,Email,DOB,Phone) values(" +txtFileNo.Text + "," +
                             "'" + txtFirstname.Text + "'," +
                             "'" + txtLastname.Text + "'," +
                            "'" + txtStreet.Text + "'," +
                            "'" + txtCity.Text + "'," +
                            "'" + txtState.Text + "'," +
                            "'" + txtZipcode.Text + "'," +
                            "'" + txtEmail.Text + "'," +
                            "'" + dateTimePicker1.Text + "'," +
                             "'" + txtPhone.Text + "')";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) {
                MessageBox.Show(" " + ex);
            }
            connection.Close();
            TextClear();

        }
        private void New_Event_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                TopMost = false;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            Event_View event_View = new Event_View();
            Size = new Size(1000, 900);
            event_View.Show();
        }

        private void New_Event_Load(object sender, EventArgs e)
        {

        }
        void TextClear()
        {
            txtFileNo.Text = " ";
            txtFirstname.Text = " ";
            txtLastname.Text = " ";
            txtStreet.Text = " ";
            txtCity.Text = " ";
            txtState.Text = " ";
            txtZipcode.Text = " ";
            txtEmail.Text = " ";
            txtPhone.Text = " ";
            

        }
        private void lblEvent_Click(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
           

           
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char chr = e.KeyChar;
            if (char.IsLetter(chr) || char.IsPunctuation(chr) && chr != 8 && chr != 45 && chr != 46)
            {
                e.Handled = true;
            }
        }

        private void txtFirstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            char chr = e.KeyChar;
            if (char.IsDigit(chr) || char.IsPunctuation(chr) && chr != 8 && chr != 45 && chr != 46)
            {
                e.Handled = true;
            }
        }

        private void txtLastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            char chr = e.KeyChar;
            if (char.IsDigit(chr) || char.IsPunctuation(chr) && chr != 8 && chr != 45 && chr != 46)
            {
                e.Handled = true;
            }
        }

        private void txtState_TextChanged(object sender, EventArgs e)
        {
            if (txtState.TextLength > 2)
            {
                MessageBox.Show("Please use only 2 letters for State.");
            }       
        }

        private void txtState_KeyPress(object sender, KeyPressEventArgs e)
        {
            char chr = e.KeyChar;
            if (char.IsDigit(chr) || char.IsPunctuation(chr) && chr != 8 && chr != 45 && chr != 46)
            {
                e.Handled = true;
            }
        }

        private void txtCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            char chr = e.KeyChar;
            if (char.IsDigit(chr) || char.IsPunctuation(chr) && chr != 8 && chr != 45 && chr != 46)
            {
                e.Handled = true;
            }
        }

        private void txtZipcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            char chr = e.KeyChar;
            if (char.IsLetter(chr) || char.IsPunctuation(chr) && chr != 8 && chr != 45 && chr != 46)
            {
                e.Handled = true;
            }
        }
    }
}
