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
using System.IO;
using System.Drawing.Imaging;


namespace Student_Information_System
{
    public partial class ManageStudentForm : Form
    {
        public ManageStudentForm()
        {
            InitializeComponent();
        }
        Student stu = new Student();
        
        private void ManageStudentForm_Load(object sender, EventArgs e)
        {
            dataGrid(new MySqlCommand("SELECT * FROM `student`"));
            
        }

        public void dataGrid(MySqlCommand comm)
        {
            

            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn pic1 = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 150;
            dataGridView1.DataSource = stu.getStudents(comm);

            pic1 = (DataGridViewImageColumn)dataGridView1.Columns[30];
            pic1.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;


            //total number of students
            labelTotalStudents.Text = "Number of Students:  " + dataGridView1.Rows.Count;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            

            textBoxId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxFname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxLname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxMi.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[4].Value;
            textBoxContact.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            if(dataGridView1.CurrentRow.Cells[6].Value.ToString() == "Female")
            {
                radioButtonF.Checked = true;
            }
            else
            {
                radioButtonM.Checked = true;
            }
            textBoxAdd.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            comboBoxG.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBoxLrn.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBoxGuardianFn.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBoxGuardianLn.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            textBoxGuardianMi.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            textBoxGuardianContact.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            textBoxGuardianEmail.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();


            textBoxStuEmail.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
            textBoxBirthPlace.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
            textBoxAge.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();


            textBoxFatherF.Text = dataGridView1.CurrentRow.Cells[18].Value.ToString();
            textBoxFatherL.Text = dataGridView1.CurrentRow.Cells[19].Value.ToString();
            textBoxFatherI.Text = dataGridView1.CurrentRow.Cells[20].Value.ToString();
            textBoxFatherE.Text = dataGridView1.CurrentRow.Cells[21].Value.ToString();
            textBoxFatherC.Text = dataGridView1.CurrentRow.Cells[22].Value.ToString();
            textBoxFatherO.Text = dataGridView1.CurrentRow.Cells[23].Value.ToString();


            textBoxMotherF.Text = dataGridView1.CurrentRow.Cells[24].Value.ToString();
            textBoxMotherL.Text = dataGridView1.CurrentRow.Cells[25].Value.ToString();
            textBoxMotherI.Text = dataGridView1.CurrentRow.Cells[26].Value.ToString();
            textBoxMotherE.Text = dataGridView1.CurrentRow.Cells[27].Value.ToString();
            textBoxMotherC.Text = dataGridView1.CurrentRow.Cells[28].Value.ToString();
            textBoxMotherO.Text = dataGridView1.CurrentRow.Cells[29].Value.ToString();









            byte[] pic;
            pic = (byte[])dataGridView1.CurrentRow.Cells[30].Value;
            MemoryStream picture = new MemoryStream(pic);
            pictureBox1.Image = Image.FromStream(picture);

            if (dataGridView1.CurrentRow.Cells[31].Value.ToString() == "Psa")
            {
                checkBox1.Checked = true;
            }


            if (dataGridView1.CurrentRow.Cells[32].Value.ToString() == "Report Card")
            {
                checkBox2.Checked = true;
            }


            if (dataGridView1.CurrentRow.Cells[33].Value.ToString() == "SF10")
            {
                checkBox3.Checked = true;
            }


            if (dataGridView1.CurrentRow.Cells[34].Value.ToString() == "Good Moral")
            {
                checkBox4.Checked = true;
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
           
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

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveImg = new SaveFileDialog();

            //picture Name
            saveImg.FileName = "Student_" + textBoxId.Text;

            //empty pIctureBox
            if(pictureBox1.Image == null)
            {
                MessageBox.Show("No image In the PictureBox");
                
            }
            else if(saveImg.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveImg.FileName + ("."+ ImageFormat.Jpeg.ToString()));
            }



        }

        private void button6_Click(object sender, EventArgs e)
        {

            //search
            string search = "SELECT * FROM `student` WHERE CONCAT(`first_name`,`last_name`,`middle_name`,`Lrn`,`contact`,`address`,`Guardian_FirstName`,`Guardian_LastName`,`Guardian_MiddleName`,`Guardian_Contact`,`Guardian_Email`)LIKE '%" + textBoxSearch.Text + "%'";
            MySqlCommand comm = new MySqlCommand(search);

            //call the viewgrid 
            dataGrid(comm);

        }

        bool verif()
        {

            if (
                textBoxFname.Text.Trim() == "" ||
                textBoxLname.Text.Trim() == "" ||
               textBoxMi.Text.Trim() == "" ||
               textBoxContact.Text.Trim() == "" ||
               textBoxAdd.Text.Trim() == "" ||

               comboBoxG.Text.Trim() == "" ||
                textBoxLrn.Text.Trim() == "" ||
              


               pictureBox1.Image == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //edit button
        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Viewer viewpic = new Viewer();
            byte[] pic;

            pic = (byte[])dataGridView1.CurrentRow.Cells[30].Value;
            MemoryStream picture = new MemoryStream(pic);
            viewpic.pictureBox1.Image = Image.FromStream(picture);
            viewpic.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Parent prnt = new Parent();
            prnt.textBoxGuardianFn.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            prnt.textBoxGuardianLn.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            prnt.textBoxGuardianMi.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            prnt.textBoxGuardianContact.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            prnt.textBoxGuardianEmail.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();


            prnt.textBoxFatherF.Text = dataGridView1.CurrentRow.Cells[18].Value.ToString();
            prnt.textBoxFatherL.Text = dataGridView1.CurrentRow.Cells[19].Value.ToString();
            prnt.textBoxFatherI.Text = dataGridView1.CurrentRow.Cells[20].Value.ToString();
            prnt.textBoxFatherE.Text = dataGridView1.CurrentRow.Cells[21].Value.ToString();
            prnt.textBoxFatherC.Text = dataGridView1.CurrentRow.Cells[22].Value.ToString();
            prnt.textBoxFatherO.Text = dataGridView1.CurrentRow.Cells[23].Value.ToString();

            prnt.textBoxMotherF.Text = dataGridView1.CurrentRow.Cells[24].Value.ToString();
            prnt.textBoxMotherL.Text = dataGridView1.CurrentRow.Cells[25].Value.ToString();
            prnt.textBoxMotherI.Text = dataGridView1.CurrentRow.Cells[26].Value.ToString();
            prnt.textBoxMotherE.Text = dataGridView1.CurrentRow.Cells[27].Value.ToString();
            prnt.textBoxMotherC.Text = dataGridView1.CurrentRow.Cells[28].Value.ToString();
            prnt.textBoxMotherO.Text = dataGridView1.CurrentRow.Cells[29].Value.ToString();

            
            prnt.Show();



        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
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

        private void labelTotalStudents_Click(object sender, EventArgs e)
        {

        }
    }
}
