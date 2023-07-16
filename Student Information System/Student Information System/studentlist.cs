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
    public partial class studentlist : Form
    {
        public studentlist()
        {
            InitializeComponent();
        }







        Student student = new Student();
        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void studentlist_Load(object sender, EventArgs e)
        {

            MySqlCommand comm = new MySqlCommand("SELECT * FROM `student`");
            dataGridView2.ReadOnly = true;
            DataGridViewImageColumn pic1 = new DataGridViewImageColumn();
            dataGridView2.RowTemplate.Height = 150;
            dataGridView2.DataSource = student.getStudents(comm);

            pic1 = (DataGridViewImageColumn)dataGridView2.Columns[30];
            pic1.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView2.AllowUserToAddRows = false;

        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            Edit_RemoveForm erf = new Edit_RemoveForm();
            erf.textBoxId.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            erf.textBoxFname.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            erf.textBoxLname.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            erf.textBoxMi.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            erf.dateTimePicker1.Value = (DateTime)dataGridView2.CurrentRow.Cells[4].Value;
            erf.textBoxContact.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();

            if (dataGridView2.CurrentRow.Cells[6].Value.ToString() =="Female")
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



            erf.textBoxAdd.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            erf.comboBoxG.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
            erf.textBoxLrn.Text = dataGridView2.CurrentRow.Cells[9].Value.ToString();
            erf.textBoxGuardianFn.Text = dataGridView2.CurrentRow.Cells[10].Value.ToString();
            erf.textBoxGuardianLn.Text = dataGridView2.CurrentRow.Cells[11].Value.ToString();
            erf.textBoxGuardianMi.Text = dataGridView2.CurrentRow.Cells[12].Value.ToString();
            erf.textBoxGuardianContact.Text = dataGridView2.CurrentRow.Cells[13].Value.ToString();
            erf.textBoxGuardianEmail.Text = dataGridView2.CurrentRow.Cells[14].Value.ToString();

            erf.textBoxStuEmail.Text = dataGridView2.CurrentRow.Cells[15].Value.ToString();
            erf.textBoxBirthPlace.Text = dataGridView2.CurrentRow.Cells[16].Value.ToString();
            erf.textBoxAge.Text = dataGridView2.CurrentRow.Cells[17].Value.ToString();
            

            erf.textBoxFatherF.Text = dataGridView2.CurrentRow.Cells[18].Value.ToString();
            erf.textBoxFatherL.Text = dataGridView2.CurrentRow.Cells[19].Value.ToString();
            erf.textBoxFatherI.Text = dataGridView2.CurrentRow.Cells[20].Value.ToString();
            erf.textBoxFatherE.Text = dataGridView2.CurrentRow.Cells[21].Value.ToString();
            erf.textBoxFatherC.Text = dataGridView2.CurrentRow.Cells[22].Value.ToString();
            erf.textBoxFatherO.Text = dataGridView2.CurrentRow.Cells[23].Value.ToString();

            erf.textBoxMotherF.Text = dataGridView2.CurrentRow.Cells[24].Value.ToString();
            erf.textBoxMotherL.Text = dataGridView2.CurrentRow.Cells[25].Value.ToString();
            erf.textBoxMotherI.Text = dataGridView2.CurrentRow.Cells[26].Value.ToString();
            erf.textBoxMotherE.Text = dataGridView2.CurrentRow.Cells[27].Value.ToString();
            erf.textBoxMotherC.Text = dataGridView2.CurrentRow.Cells[28].Value.ToString();
            erf.textBoxMotherO.Text = dataGridView2.CurrentRow.Cells[29].Value.ToString();

            








            //@fn,@ln,@mn,@bdt,@cont,@gdr,@adr,@Grade,@Lrn,@GuardianFn,@GuardianLn,@GuardianMn,@GuradianCon,@GuardianEm,@pic  

            byte[] pic;
           
            pic = (byte[])dataGridView2.CurrentRow.Cells[30].Value;
            MemoryStream picture = new MemoryStream(pic);
            erf.pictureBox1.Image = Image.FromStream(picture);

            if (dataGridView2.CurrentRow.Cells[31].Value.ToString() == "Psa")
            {
                erf.checkBox1.Checked = true;
            }


            if (dataGridView2.CurrentRow.Cells[32].Value.ToString() == "Report Card")
            {
                erf.checkBox2.Checked = true;
            }


            if (dataGridView2.CurrentRow.Cells[33].Value.ToString() == "SF10")
            {
                erf.checkBox3.Checked = true;
            }


            if (dataGridView2.CurrentRow.Cells[34].Value.ToString() == "Good Moral")
            {
                erf.checkBox4.Checked = true;
            }



            erf.Show();





        }

        private void buttonR_Click(object sender, EventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MySqlCommand comm = new MySqlCommand("SELECT * FROM `student`");
            dataGridView2.ReadOnly = true;
            DataGridViewImageColumn pic1 = new DataGridViewImageColumn();
            dataGridView2.RowTemplate.Height = 150;
            dataGridView2.DataSource = student.getStudents(comm);

            pic1 = (DataGridViewImageColumn)dataGridView2.Columns[30];
            pic1.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView2.AllowUserToAddRows = false;
        }
    }
}
