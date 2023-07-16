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

namespace Student_Information_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {

            // calling class1 for connection
            Class1 my = new Class1();

            MySqlDataAdapter adptr = new MySqlDataAdapter();
            DataTable tbl = new DataTable();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `users` WHERE `username`= @usn AND`password` = @pass", my.GetConnection);

            com.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBoxUser.Text;
            com.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPass.Text;

            adptr.SelectCommand = com;

            adptr.Fill(tbl);

            if(tbl.Rows.Count > 0)
            {
                MessageBox.Show("   Welcome:   " + textBoxUser.Text);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Invalid Username or Password","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }







        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxUser_Click(object sender, EventArgs e)
        {
            textBoxUser.Clear();
            panel1.BackColor = Color.FromArgb(255, 37, 17);
            textBoxUser.ForeColor = Color.FromArgb(255, 255, 255);


            panel2.BackColor = Color.WhiteSmoke;
            textBoxPass.ForeColor = Color.WhiteSmoke;
        }

        private void textBoxPass_Click(object sender, EventArgs e)
        {
            textBoxPass.Clear();
            panel2.BackColor = Color.FromArgb(255, 37, 17);
            textBoxPass.ForeColor = Color.FromArgb(255, 255, 255);


            panel1.BackColor = Color.WhiteSmoke;
            textBoxUser.ForeColor = Color.WhiteSmoke;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBoxPass.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxPass.UseSystemPasswordChar = true;
            }
        }
    }
}
