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
    public partial class Viewer : Form
    {
        public Viewer()
        {
            InitializeComponent();

            
        }
        Student stu = new Student();
        ManageStudentForm manageStu = new ManageStudentForm();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           


        }
    }
}
