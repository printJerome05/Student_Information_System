using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Information_System
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            studentbtn stu = new studentbtn();
            string lbl = "      Student Information System";
            stu.label1.Text = lbl;
         
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog opn = new OpenFileDialog();
            opn.Filter = "Select Image(*.jpg;* .png;* .gif)|*.jpg;* .png;* .gif";

            if(opn.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opn.FileName);
            }

        }

        private void buttonAddstd_Click(object sender, EventArgs e)
        {
            Student stu = new Student();
            string fname = textBoxFname.Text;
            string lname = textBoxLname.Text;
            string mname = textBoxMi.Text;
            DateTime bdate = dateTimePicker1.Value;
            string contact = textBoxContact.Text;
            string adress = textBoxAdd.Text;
            string Grade = comboBoxG.Text;
            string Lrn = textBoxLrn.Text;
            string GuardianFn = textBoxGuardianFn.Text;
            string GuardianLn = textBoxGuardianLn.Text;
            string GuardianMn = textBoxGuardianMi.Text;
            string GuardianCon = textBoxGuardianContact.Text;
            string GuardianEm = textBoxGuardianEmail.Text;

            // string StuEmail, string BirthPlace, string age, string FatherF, string FatherL, string FatherI, string FatherE, string FatherC, string FatherO, string MotherF, string MotherL, string MotherI, string MotherE, string MotherC, string MotherO 
            //newlyadded
            string StuEmail = textBoxStuEmail.Text;
            string BirthPlace = textBoxBirthPlace.Text;
            string age = textBoxAge.Text;

            //father textbox
            string FatherF = textBoxFatherF.Text;
            string FatherL = textBoxFatherL.Text;
            string FatherI = textBoxFatherI.Text;
            string FatherE = textBoxFatherE.Text;
            string FatherC = textBoxFatherC.Text;
            string FatherO = textBoxFatherO.Text;


            //mother textbox
            string MotherF = textBoxMotherF.Text;
            string MotherL = textBoxMotherL.Text;
            string MotherI = textBoxMotherI.Text;
            string MotherE = textBoxMotherE.Text;
            string MotherC = textBoxMotherC.Text;
            string MotherO = textBoxMotherO.Text;

            //psa reportcard sf10 goodmoral





            string psa = "N/a";
            if(checkBox1.Checked)
            {
                psa = "Psa";
            }

            string reportcard = "N/a";
            if (checkBox2.Checked)
            {
                reportcard = "Report Card";
            }

            string sf10 = "N/a";
            if (checkBox3.Checked)
            {
                sf10 = "SF10";
            }

            string goodmoral = "N/a";
            if (checkBox4.Checked)
            {
                goodmoral = "Good Moral";
            }















            //Lrn GuardianFn GuardianLn GuardianMn GuardianCon GuardianEm

            string gender = "Male";

            if(radioButtonF.Checked)
            {
                gender = "Female";
            }

            MemoryStream picture = new MemoryStream();


            //checking student age

            int borny = dateTimePicker1.Value.Year;
            int thisy = DateTime.Now.Year;

            if ((thisy - borny) < 5)
            {
                MessageBox.Show("The Student age must be above 5");
            }
            else if (verif())
            {

                pictureBox1.Image.Save(picture, pictureBox1.Image.RawFormat);

                if (stu.insertStudent(fname, lname, mname, bdate, contact, gender, adress,Grade, Lrn, GuardianFn, GuardianLn, GuardianMn, GuardianCon, GuardianEm, StuEmail, BirthPlace, age, FatherF, FatherL, FatherI, FatherE, FatherC, FatherO, MotherF, MotherL, MotherI, MotherE, MotherC, MotherO, picture, psa, reportcard, sf10, goodmoral))
                {
                    MessageBox.Show("New Student Added", " Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);

                  
                    textBoxFname.Text = "";
                    textBoxLname.Text = "";
                    textBoxMi.Text = "";
                    textBoxContact.Text = "";
                    textBoxAdd.Text = "";
                    dateTimePicker1.Value = DateTime.Now;
                    comboBoxG.Text = "";
                    textBoxLrn.Text = "";
                    textBoxGuardianFn.Text = "";
                    textBoxGuardianLn.Text = "";
                    textBoxGuardianMi.Text = "";
                    textBoxGuardianContact.Text = "";
                    textBoxGuardianEmail.Text = "";
                    textBoxAge.Text = "";
                    textBoxBirthPlace.Text = "";
                    textBoxStuEmail.Text = "";

                    textBoxFatherF.Text = "";
                    textBoxFatherL.Text = "";
                    textBoxFatherI.Text = "";
                    textBoxFatherE.Text = "";
                    textBoxFatherC.Text = "";
                    textBoxFatherO.Text = "";

                    textBoxMotherF.Text = "";
                    textBoxMotherL.Text = "";
                    textBoxMotherI.Text = "";
                    textBoxMotherE.Text = "";
                    textBoxMotherC.Text = "";
                    textBoxMotherO.Text = "";


                    pictureBox1.Image = null;
                }
                else
                {
                    MessageBox.Show("Error", " Add Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", " Add Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            
             

        }

        bool verif()
        {
            if (textBoxFname.Text.Trim() == "" ||
                textBoxLname.Text.Trim() == "" ||
               textBoxMi.Text.Trim() == "" ||
               textBoxContact.Text.Trim() == "" ||
               textBoxAdd.Text.Trim() == "" ||
                
               comboBoxG.Text.Trim() == "" ||
                textBoxLrn.Text.Trim() == "" ||
               textBoxAge.Text.Trim() == "" ||
            textBoxBirthPlace.Text.Trim() == "" ||
            textBoxStuEmail.Text.Trim() == "" ||

             textBoxFatherF.Text.Trim() == "" ||
              textBoxFatherL.Text.Trim() == "" ||
               textBoxFatherI.Text.Trim() == "" ||
                textBoxFatherE.Text.Trim() == "" ||
                 textBoxFatherC.Text.Trim() == "" ||
                  textBoxFatherO.Text.Trim() == "" ||

             textBoxMotherF.Text.Trim() == "" ||
              textBoxMotherL.Text.Trim() == "" ||
               textBoxMotherI.Text.Trim() == "" ||
                textBoxMotherE.Text.Trim() == "" ||
                 textBoxMotherC.Text.Trim() == "" ||
                  textBoxMotherO.Text.Trim() == "" ||



            pictureBox1.Image == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBoxLrn_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxLrn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxMotherC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxFatherC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxGuardianContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxGuardianFn_Click(object sender, EventArgs e)
        {
            textBoxGuardianFn.Clear();
        }

        private void textBoxGuardianLn_Click(object sender, EventArgs e)
        {
            textBoxGuardianLn.Clear();
        }

        private void textBoxGuardianMi_Click(object sender, EventArgs e)
        {
            textBoxGuardianMi.Clear();
        }

        private void textBoxGuardianEmail_Click(object sender, EventArgs e)
        {
            textBoxGuardianEmail.Clear();
        }

        private void textBoxGuardianContact_Click(object sender, EventArgs e)
        {
            textBoxGuardianContact.Clear();
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {

        }

        private void textBoxFname_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBoxFname_Leave(object sender, EventArgs e)
        {
            
        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
