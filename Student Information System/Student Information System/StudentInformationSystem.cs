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
    
    public partial class studentbtn : Form
    {
        
        public studentbtn()
        {
            InitializeComponent();
            customizeDesign();
            
        }

        
        private void  customizeDesign()
        {
            panel3.Visible = false;
            panel4.Visible = false;
            panel7.Visible = false;
            
        }

        private void hideSubmenu()
        {
            if (panel3.Visible == true)
                panel3.Visible = false;
           
            if (panel4.Visible == true)
                panel4.Visible = false;

            if (panel7.Visible == true)
                panel7.Visible = false;
        }
        
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubmenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showSubMenu(panel3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            openChildForm(new AddStudent());
            hideSubmenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new studentlist());
            hideSubmenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChildForm(new Edit_RemoveForm());
            hideSubmenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageStudentForm());
            hideSubmenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openChildForm(new StatsForm());

            hideSubmenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openChildForm(new Print());
            hideSubmenu();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            showSubMenu(panel4);
        }

        private void button13_Click(object sender, EventArgs e)
        {
           openChildForm(new Grade1());
            hideSubmenu();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            openChildForm(new Grade2());
            hideSubmenu();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            openChildForm(new Grade3());
            hideSubmenu();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            openChildForm(new Grade4());
            hideSubmenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openChildForm(new Grade5());
            hideSubmenu();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            openChildForm(new Grade6());
            hideSubmenu();
        }

        private Form activeForm = null;

       
        private void openChildForm(Form childForm )
        {
          
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel6.Controls.Add(childForm);
            panel6.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            label1.Text = childForm.Text;
           

          
           

        }

        private void button15_Click(object sender, EventArgs e)
        {
            showSubMenu(panel7);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            openChildForm(new Archive());
            hideSubmenu();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form1 fr1 = new Form1();
            fr1.Show();


            Application.Restart();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            label1.Text = "      Student Information System";
            
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button16_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button16, "Home");
        }

        private void button18_MouseHover(object sender, EventArgs e)
        {
            toolTip2.SetToolTip(button18, "Close");
        }

        private void button19_Click(object sender, EventArgs e)
        {
           
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Minimized;
            }
            else if(WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void button21_MouseHover(object sender, EventArgs e)
        {
            toolTip3.SetToolTip(button21, "Minimize");
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
