using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Student_Information_System
{
    public partial class Print_Preview : Form
    {
        private string Date;

        public Image img = null;
        public Print_Preview()
        {
            InitializeComponent();
            Date = DateTime.Now.ToString("M/d/yyyy");
        }

        private void Print(Panel pnl)
        {
            PrinterSettings ps = new PrinterSettings();
            panelPrint = pnl;
            getprintarea(pnl);
            printPreviewDialog2.Document = printDocument2;
            printDocument2.PrintPage += new PrintPageEventHandler(printDocument2_PrintPage);
            printPreviewDialog2.ShowDialog();

        }

        private Bitmap memoryimg;

        private void getprintarea(Panel pnl)
        {
            memoryimg = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(memoryimg, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }

        private void Print_MouseHover(object sender, EventArgs e)
        {
            toolTip2.SetToolTip(PictureBoxPrint, "Print");
        }

        private void Print_Preview_Load(object sender, EventArgs e)
        {
            labelDate.Text = Date;
         
        }

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagerea = e.PageBounds;
            e.Graphics.DrawImage(memoryimg, (pagerea.Width / 2) - (this.panelPrint.Width / 2), this.panelPrint.Location.Y);

        }

        private void PictureBoxPrint_Click(object sender, EventArgs e)
        {
            Print(this.panelPrint);
        }
    }
}
