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

// System.Data.OleDb; imports the class
namespace LoginAndSignUpSystem
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb");
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter da = new OleDbDataAdapter();
            // connecting the database the the system

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            if (txtUsername.Text == "" && txtPassword.Text == "" && txtComPassword.Text == "")
            {
                MessageBox.Show("You did not enter a username or password try again","Registration Failed",MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           else if(txtPassword.Text == txtComPassword.Text)
            {

                con.Open();
                string register = "INSERT INTO tbl_users VALUES('"+ txtUsername.Text +"','"+ txtPassword.Text +"')";
                cmd = new OleDbCommand(register, con);
                cmd.ExecuteNonQuery();
                con.Close();
                // send information of username to the database

                clear();

                MessageBox.Show("You Have Successfully Registerd", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           else
            {
                MessageBox.Show("Password did not match try again", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtComPassword.Text = "";
                txtPassword.Focus();


            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("test", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if(checkbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtComPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*'; 
                txtComPassword.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
            txtUsername.Focus();

        }

        private void clear()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtComPassword.Text = "";
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }
    }
}
