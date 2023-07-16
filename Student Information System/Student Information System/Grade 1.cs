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
    public partial class Grade1 : Form
    {
        public Grade1()
        {
            InitializeComponent();
        }

        //call the student class to generate list
        Student student = new Student();
        private void Grade1_Load(object sender, EventArgs e)
        {

            Student stu = new Student();
            double totalGrade1Students = Convert.ToDouble(stu.totalGrade1Students());
            labelTotalStudents.Text = "Total :" + totalGrade1Students.ToString();


            MySqlCommand comm = new MySqlCommand("SELECT * FROM `student` WHERE `Grade` = 'Grade 1'");
           
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn pic1 = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 150;
            dataGridView1.DataSource = student.getStudents(comm);

            pic1 = (DataGridViewImageColumn)dataGridView1.Columns[30];
            pic1.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;

        }

       
        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Edit_RemoveForm erf = new Edit_RemoveForm();
            erf.textBoxId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            erf.textBoxFname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            erf.textBoxLname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            erf.textBoxMi.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            erf.dateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[4].Value;
            erf.textBoxContact.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "Female")
            {
                erf.radioButtonF.Checked = true;
            }

            //textBoxFname.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            //textBoxLname.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            //textBoxMi.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            //dateTimePicker1.Value = (DateTime)dataGridView2.CurrentRow.Cells[4].Value;
            //textBoxContact.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();


            //textBoxAdd.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            //comboBoxG.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
            //textBoxLrn.Text = dataGridView2.CurrentRow.Cells[9].Value.ToString();
            //textBoxGuardianFn.Text = dataGridView2.CurrentRow.Cells[10].Value.ToString();
            //textBoxGuardianLn.Text = dataGridView2.CurrentRow.Cells[11].Value.ToString();
            //textBoxGuardianMi.Text = dataGridView2.CurrentRow.Cells[12].Value.ToString();
            //textBoxGuardianContact.Text = dataGridView2.CurrentRow.Cells[13].Value.ToString();
            //textBoxGuardianEmail.Text = dataGridView2.CurrentRow.Cells[14].Value.ToString();



            erf.textBoxAdd.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            erf.comboBoxG.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            erf.textBoxLrn.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            erf.textBoxGuardianFn.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            erf.textBoxGuardianLn.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            erf.textBoxGuardianMi.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            erf.textBoxGuardianContact.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            erf.textBoxGuardianEmail.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();

            erf.textBoxStuEmail.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
            erf.textBoxBirthPlace.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
            erf.textBoxAge.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();


            erf.textBoxFatherF.Text = dataGridView1.CurrentRow.Cells[18].Value.ToString();
            erf.textBoxFatherL.Text = dataGridView1.CurrentRow.Cells[19].Value.ToString();
            erf.textBoxFatherI.Text = dataGridView1.CurrentRow.Cells[20].Value.ToString();
            erf.textBoxFatherE.Text = dataGridView1.CurrentRow.Cells[21].Value.ToString();
            erf.textBoxFatherC.Text = dataGridView1.CurrentRow.Cells[22].Value.ToString();
            erf.textBoxFatherO.Text = dataGridView1.CurrentRow.Cells[23].Value.ToString();

            erf.textBoxMotherF.Text = dataGridView1.CurrentRow.Cells[24].Value.ToString();
            erf.textBoxMotherL.Text = dataGridView1.CurrentRow.Cells[25].Value.ToString();
            erf.textBoxMotherI.Text = dataGridView1.CurrentRow.Cells[26].Value.ToString();
            erf.textBoxMotherE.Text = dataGridView1.CurrentRow.Cells[27].Value.ToString();
            erf.textBoxMotherC.Text = dataGridView1.CurrentRow.Cells[28].Value.ToString();
            erf.textBoxMotherO.Text = dataGridView1.CurrentRow.Cells[29].Value.ToString();








            //@fn,@ln,@mn,@bdt,@cont,@gdr,@adr,@Grade,@Lrn,@GuardianFn,@GuardianLn,@GuardianMn,@GuradianCon,@GuardianEm,@pic  

            byte[] pic;

            pic = (byte[])dataGridView1.CurrentRow.Cells[30].Value;
            MemoryStream picture = new MemoryStream(pic);
            erf.pictureBox1.Image = Image.FromStream(picture);
            if (dataGridView1.CurrentRow.Cells[31].Value.ToString() == "Psa")
            {
                erf.checkBox1.Checked = true;
            }


            if (dataGridView1.CurrentRow.Cells[32].Value.ToString() == "Report Card")
            {
                erf.checkBox2.Checked = true;
            }


            if (dataGridView1.CurrentRow.Cells[33].Value.ToString() == "SF10")
            {
                erf.checkBox3.Checked = true;
            }


            if (dataGridView1.CurrentRow.Cells[34].Value.ToString() == "Good Moral")
            {
                erf.checkBox4.Checked = true;
            }

            erf.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBoxId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxFname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxLname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxMi.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[4].Value;
            textBoxContact.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "Female")
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
            textBoxStuEmail.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
            textBoxAge.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();

            byte[] pic;
            pic = (byte[])dataGridView1.CurrentRow.Cells[30].Value;
            MemoryStream picture = new MemoryStream(pic);
            pictureBox1.Image = Image.FromStream(picture);
        }

        private void buttonR_Click(object sender, EventArgs e)
        {
            MySqlCommand comm = new MySqlCommand("SELECT * FROM `student` WHERE `Grade` = 'Grade 1'");
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn pic1 = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 150;
            dataGridView1.DataSource = student.getStudents(comm);

            pic1 = (DataGridViewImageColumn)dataGridView1.Columns[30];
            pic1.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }
    }
}

  