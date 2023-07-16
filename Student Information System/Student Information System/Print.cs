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
    public partial class Print : Form
    {
        private string Date;
        Student stu = new Student();

        
       
        public Print()
        {
            InitializeComponent();
            Date = DateTime.Now.ToString("M/d/yyyy");
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
            }
            catch
            {
                MessageBox.Show("Enter a valid student Id ", "Invalid Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Print_Preview prnt = new Print_Preview();

            prnt.label19.Text = textBoxFname.Text.ToString();
            prnt.label20.Text = textBoxLname.Text.ToString();
            prnt.label21.Text = textBoxMi.Text.ToString();


            prnt.label22.Text = comboBoxG.Text.ToString();
            prnt.label17.Text = textBoxLrn.Text.ToString();
            prnt.label43.Text = textBoxAge.Text.ToString();

            prnt.pictureBox1.Image = pictureBox1.Image;

            prnt.label41.Text = textBoxStuEmail.Text.ToString();
            prnt.label44.Text = textBoxContact.Text.ToString();

            prnt.label42.Text = dateTimePicker1.Value.ToString("dd/M/yyyy");
            prnt.label45.Text = textBoxBirthPlace.Text.ToString();
            prnt.label49.Text = textBoxAdd.Text.ToString();


            prnt.label23.Text = textBoxFatherF.Text.ToString();
            prnt.label25.Text = textBoxFatherL.Text.ToString();
            prnt.label26.Text = textBoxFatherI.Text.ToString();
            prnt.label27.Text = textBoxFatherC.Text.ToString();
            prnt.label28.Text = textBoxFatherE.Text.ToString();
            prnt.label46.Text = textBoxFatherO.Text.ToString();


            prnt.label34.Text = textBoxMotherF.Text.ToString();
            prnt.label33.Text = textBoxMotherL.Text.ToString();
            prnt.label32.Text = textBoxMotherI.Text.ToString();
            prnt.label31.Text = textBoxMotherC.Text.ToString();
            prnt.label30.Text = textBoxMotherE.Text.ToString();
            prnt.label48.Text = textBoxMotherO.Text.ToString();


            if (checkBox1.Checked)
            {
                prnt.checkBox1.Checked = true;
            }
            else
            {
                prnt.checkBox1.Checked = false;
            }



            if (checkBox2.Checked)
            {
                prnt.checkBox2.Checked = true;
            }
            else
            {
                prnt.checkBox2.Checked = false;
            }


            if (checkBox3.Checked)
            {
                prnt.checkBox3.Checked = true;
            }
            else
            {
                prnt.checkBox3.Checked = false;
            }



            if (checkBox4.Checked)
            {
                prnt.checkBox4.Checked = true;
            }
            else
            {
                prnt.checkBox4.Checked = false;
            }

            if(radioButtonF.Checked)
            {
                prnt.label40.Text = "Female";
            }
            else
            {
                prnt.label40.Text = "Male";
            }

            




            prnt.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Print_Load(object sender, EventArgs e)
        {

        }

        private void textBoxFatherF_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

