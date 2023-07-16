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
    public partial class Parent : Form
    {
        public Parent()
        {
            InitializeComponent();
        }
        
        private void Parent_Load(object sender, EventArgs e)
        {
            ManageStudentForm mng = new ManageStudentForm();

            
        
            this.Text = "Guardian/Parents of " + textBoxFatherL.Text  ;
        }
    }
}
