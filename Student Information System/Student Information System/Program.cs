using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Information_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
         

            //application.run login

            Form1 f1 = new Form1();

            if(f1.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new studentbtn());
            }
            else
            {
                Application.Exit();
            }

        }
    }
}
