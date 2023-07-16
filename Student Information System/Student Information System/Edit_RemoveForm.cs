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
using MySql.Data.MySqlClient;

namespace Student_Information_System
{
    public partial class Edit_RemoveForm : Form
    {
        public Edit_RemoveForm()
        {
            InitializeComponent();
        }
        Student stu = new Student();
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog opn = new OpenFileDialog();
            opn.Filter = "Select Image(*.jpg;* .png;* .gif)|*.jpg;* .png;* .gif";

            if (opn.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opn.FileName);
            }
        }

        bool verif()
        {
            //@fn,@ln,@mn,@bdt,@cont,@gdr,@adr,@Grade,@Lrn,@GuardianFn,@GuardianLn,@GuardianMn,@GuradianCon,@GuardianEm,@pic  
            if (
                textBoxFname.Text.Trim() == "" ||
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

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxId.Text);
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
                if (checkBox1.Checked)
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

                //string psa,  string reportcard,  string sf10, string goodmoral



                string gender = "Male";

                if (radioButtonF.Checked)
                {
                    gender = "Female";
                }

                MemoryStream picture = new MemoryStream();

                int borny = dateTimePicker1.Value.Year;
                int thisy = DateTime.Now.Year;

                if ((thisy - borny) < 5)
                {
                    MessageBox.Show("The Student age must be above 5");
                }
                else if (verif())
                {

                    pictureBox1.Image.Save(picture, pictureBox1.Image.RawFormat);

                    if (stu.updateStudent(id, fname, lname, mname, bdate, contact, gender, adress, Grade, Lrn, GuardianFn, GuardianLn, GuardianMn, GuardianCon, GuardianEm, StuEmail, BirthPlace, age, FatherF, FatherL, FatherI, FatherE, FatherC, FatherO, MotherF, MotherL, MotherI, MotherE, MotherC, MotherO, picture, psa, reportcard, sf10, goodmoral))
                    {
                        MessageBox.Show("Student Updated", " Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", " Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", " Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
           catch 
            {
                MessageBox.Show("Please Enter a valid student Id ", "Invalid Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxId.Text);


                if (MessageBox.Show("Do you want to delete this student", "Delete Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (stu.deleteStudent(id))
                    {
                        MessageBox.Show("Student Deleted", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //@fn,@ln,@mn,@bdt,@cont,@gdr,@adr,@Grade,@Lrn,@GuardianFn,@GuardianLn,@GuardianMn,@GuradianCon,@GuardianEm,@pic  
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

                        textBoxStuEmail.Text = "";
                        textBoxBirthPlace.Text = "";
                        textBoxAge.Text = "";


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
                        MessageBox.Show("Student Not Deleted", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }catch
            {
                MessageBox.Show(" Please Enter a valid student Id ", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxId.Text);
                MySqlCommand comm = new MySqlCommand("SELECT `id`, `first_name`, `last_name`, `middle_name`, `bday`, `contact`, `gender`, `address` , `Grade`, `Lrn`, `Guardian_FirstName`, `Guardian_LastName`, `Guardian_MiddleName`, `Guardian_Contact`, `Guardian_Email`, `StuEmail`, `BirthPlace`, `age`, `FatherF`, `FatherL`, `FatherI`, `FatherE`, `FatherC`, `FatherO`, `MotherF`, `MotherL`, `MotherI`, `MotherE`, `MotherC`, `MotherO`, `picture`, `PSA`, `REPORTCARD`, `SF10`, `GOODMORAL` FROM `student` WHERE `id`=" + id);

                DataTable tbl = stu.getStudents(comm);

                if (tbl.Rows.Count > 0)
                {

                    //@fn,@ln,@mn,@bdt,@cont,@gdr,@adr,@Grade,@Lrn,@GuardianFn,@GuardianLn,@GuardianMn,@GuradianCon,@GuardianEm,@pic  
                   
                    textBoxFname.Text = tbl.Rows[0]["first_name"].ToString();
                    textBoxLname.Text = tbl.Rows[0]["last_name"].ToString();
                    textBoxMi.Text = tbl.Rows[0]["middle_name"].ToString();
                    textBoxContact.Text = tbl.Rows[0]["contact"].ToString();
                    textBoxAdd.Text = tbl.Rows[0]["address"].ToString();
                    comboBoxG.Text = tbl.Rows[0]["Grade"].ToString();
                    textBoxLrn.Text = tbl.Rows[0]["Lrn"].ToString();
                    textBoxGuardianFn.Text = tbl.Rows[0]["Guardian_FirstName"].ToString();
                    textBoxGuardianLn.Text = tbl.Rows[0]["Guardian_LastName"].ToString();
                    textBoxGuardianMi.Text = tbl.Rows[0]["Guardian_MiddleName"].ToString();
                    textBoxGuardianContact.Text = tbl.Rows[0]["Guardian_Contact"].ToString();
                    textBoxGuardianEmail.Text = tbl.Rows[0]["Guardian_Email"].ToString();

                    //`StuEmail`, `BirthPlace`, `age`, `FatherF`, `FatherL`, `FatherI`, `FatherE`, `FatherC`, `FatherO`, `MotherF`, `MotherL`, `MotherI`, `MotherE`, `MotherC`, `MotherO`
                    textBoxStuEmail.Text = tbl.Rows[0]["StuEmail"].ToString();
                    textBoxBirthPlace.Text = tbl.Rows[0]["BirthPlace"].ToString();
                    textBoxAge.Text = tbl.Rows[0]["age"].ToString();

                    textBoxFatherF.Text = tbl.Rows[0]["FatherF"].ToString();
                    textBoxFatherL.Text = tbl.Rows[0]["FatherL"].ToString();
                    textBoxFatherI.Text = tbl.Rows[0]["FatherI"].ToString();
                    textBoxFatherE.Text = tbl.Rows[0]["FatherE"].ToString();
                    textBoxFatherC.Text = tbl.Rows[0]["FatherC"].ToString();
                    
                    textBoxFatherO.Text = tbl.Rows[0]["FatherO"].ToString();

                    textBoxMotherF.Text = tbl.Rows[0]["MotherF"].ToString();
                    textBoxMotherL.Text = tbl.Rows[0]["MotherL"].ToString();
                    textBoxMotherI.Text = tbl.Rows[0]["MotherI"].ToString();
                    textBoxMotherE.Text = tbl.Rows[0]["MotherE"].ToString();
                    textBoxMotherC.Text = tbl.Rows[0]["MotherC"].ToString();
                    
                    textBoxMotherO.Text = tbl.Rows[0]["MotherO"].ToString();






                    dateTimePicker1.Value = (DateTime)tbl.Rows[0]["bday"];



                    if (tbl.Rows[0]["gender"].ToString() == "Female")
                    {
                        radioButtonF.Checked = true;
                    }
                    else
                    {
                        radioButtonM.Checked = true;
                    }

                    //`PSA`, `REPORTCARD`, `SF10`, `GOODMORAL`

                    if (tbl.Rows[0]["PSA"].ToString() == "Psa")
                    {
                        checkBox1.Checked = true;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                    }

                    if (tbl.Rows[0]["REPORTCARD"].ToString() == "Report Card")
                    {
                        checkBox2.Checked = true;
                    }
                    else
                    {
                        checkBox2.Checked = false;
                    }

                    if (tbl.Rows[0]["SF10"].ToString() == "SF10")
                    {
                        checkBox3.Checked = true;
                    }
                    else
                    {
                        checkBox3.Checked = false;
                    }

                    if (tbl.Rows[0]["GOODMORAL"].ToString() == "Good Moral")
                    {
                        checkBox4.Checked = true;
                    }
                    else
                    {
                        checkBox4.Checked = false;
                    }


                    byte[] pic = (byte[])tbl.Rows[0]["picture"];
                    MemoryStream picture = new MemoryStream(pic);
                    pictureBox1.Image = Image.FromStream(picture);

                }
            }catch
            {
                MessageBox.Show("Enter a valid student Id " , "Invalid Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Edit_RemoveForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonArchive_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxId.Text);


                if (MessageBox.Show("Do you want to Remove this student", "Student Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (stu.archiveStudent(id))
                    {
                        MessageBox.Show("Student Removed", "Student Remove", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        
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

                        textBoxStuEmail.Text = "";
                        textBoxBirthPlace.Text = "";
                        textBoxAge.Text = "";


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
                        MessageBox.Show("Student Removed ", "Student Remove", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                        textBoxStuEmail.Text = "";
                        textBoxBirthPlace.Text = "";
                        textBoxAge.Text = "";


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

                }
            }
            catch
            {
                MessageBox.Show(" Please Enter a valid student Id ", "Remove Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBoxPsa_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void textBoxLrn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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

        private void textBoxGuardianContact_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxMotherC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
