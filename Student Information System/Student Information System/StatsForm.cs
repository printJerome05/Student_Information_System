using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Information_System
{
    public partial class StatsForm : Form
    {
        public StatsForm()
        {
            InitializeComponent();
        }
        Color panelTotalColor;
       


        private void StatsForm_Load(object sender, EventArgs e)
        {
            panelTotalColor = panelTotal.BackColor;
            

            Student stu = new Student();
            double totalStudents = Convert.ToDouble(stu.totalStudents());
            double totalMaleStudents = Convert.ToDouble(stu.totalMaleStudents());
            double totalFemaleStudents = Convert.ToDouble(stu.totalFemaleStudents());
            double totalGrade1Students = Convert.ToDouble(stu.totalGrade1Students());
            double totalGrade2Students = Convert.ToDouble(stu.totalGrade2Students());
            double totalGrade3Students = Convert.ToDouble(stu.totalGrade3Students());
            double totalGrade4Students = Convert.ToDouble(stu.totalGrade4Students());
            double totalGrade5Students = Convert.ToDouble(stu.totalGrade5Students());
            double totalGrade6Students = Convert.ToDouble(stu.totalGrade6Students());


            double malePercentage = totalMaleStudents * 100 / totalStudents;
            double femalePercentage = totalFemaleStudents * 100 / totalStudents;

            labelTotal.Text = "Total Students:  " + totalStudents.ToString();
            labelMale.Text = "Male:   " + totalMaleStudents.ToString();
            labelFemale.Text = "Female:   " + totalFemaleStudents.ToString();
            labelG1.Text = "Grade 1:    " + totalGrade1Students.ToString();
            labelG2.Text = "Grade 2:    " + totalGrade2Students.ToString();
            labelG3.Text = "Grade 3:    " + totalGrade3Students.ToString();
            labelG4.Text = "Grade 4:    " + totalGrade4Students.ToString();
            labelG5.Text = "Grade 5:    " + totalGrade5Students.ToString();
            labelG6.Text = "Grade 6:    " + totalGrade6Students.ToString();

            labelMalePercentage.Text = "Percentage : " + malePercentage.ToString("0.00") +"%";
            labelFemalePercentage.Text = "Percentage : " + femalePercentage.ToString("0.00") + "%";

        }

        private void labelTotal_MouseEnter(object sender, EventArgs e)
        {
         

        }

        private void labelTotal_MouseLeave(object sender, EventArgs e)
        {
            panel10.BackColor = Color.Red;
            panel11.BackColor = Color.Red;
            panel12.BackColor = Color.Red;
            panel13.BackColor = Color.Red;
        }

        private void labelMale_MouseEnter(object sender, EventArgs e)
        {
            
          

        }

        private void labelMale_MouseLeave(object sender, EventArgs e)
        {
           
          
        }

        private void labelFemale_MouseEnter(object sender, EventArgs e)
        {
         
           
        }

        private void labelFemale_MouseLeave(object sender, EventArgs e)
        {
            
        
        }

        private void labelG1_Click(object sender, EventArgs e)
        {

        }

        private void labelTotal_MouseHover(object sender, EventArgs e)
        {
            panel10.BackColor = Color.WhiteSmoke;
            panel11.BackColor = Color.WhiteSmoke;
            panel12.BackColor = Color.WhiteSmoke;
            panel13.BackColor = Color.WhiteSmoke;
        }

        private void panelTotal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelG4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
