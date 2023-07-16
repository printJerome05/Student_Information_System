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
    public partial class Student_Form : Form
    {
        Student stu = new Student();
        public Student_Form()
        {
            InitializeComponent();
        }

        private void Student_Form_Load(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
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
            }
            catch
            {
                MessageBox.Show(" Please Enter a valid student Id ", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRecover_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxId.Text);


                if (MessageBox.Show("Do you want to Recover this student", "Recover Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (stu.recoverStudent(id))
                    {
                        MessageBox.Show("Student Recovered ", "Recover Student", MessageBoxButtons.OK, MessageBoxIcon.Information);


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
                        MessageBox.Show("Student Recovered ", "Recover Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show(" Please Enter a valid student Id ", "Recover Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxId.Text);
                MySqlCommand comm = new MySqlCommand("SELECT `id`, `first_name`, `last_name`, `middle_name`, `bday`, `contact`, `gender`, `address` , `Grade`, `Lrn`, `Guardian_FirstName`, `Guardian_LastName`, `Guardian_MiddleName`, `Guardian_Contact`, `Guardian_Email`, `StuEmail`, `BirthPlace`, `age`, `FatherF`, `FatherL`, `FatherI`, `FatherE`, `FatherC`, `FatherO`, `MotherF`, `MotherL`, `MotherI`, `MotherE`, `MotherC`, `MotherO`, `picture`, `PSA`, `REPORTCARD`, `SF10`, `GOODMORAL` FROM `archive` WHERE `id`=" + id);

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
            }
            catch
            {
                MessageBox.Show("Enter a valid student Id ", "Invalid Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }
    }
}
