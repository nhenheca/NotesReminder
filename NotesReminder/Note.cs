using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotesReminder
{
    public partial class Note : Form
    {
        int Mx;int My;int Sw;int Sh;bool mov;

        //private const int cGrip = 16;      // Grip size
        //private const int cCaption = 32;   // Caption bar height;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        public string Id;
        public bool IsToRemove;
        public MonthCalendar monthCalendar;

        public Note()
        {
            InitializeComponent();
            //RESIZE
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.DoubleBuffered = true;
            //this.SetStyle(ControlStyles.ResizeRedraw, true);
            //EVENT
            this.FormClosing += new FormClosingEventHandler(form_close);
            //INI
            monthCalendar = new MonthCalendar();
            IsToRemove = false;
        }
        //ESCODER/MINIMIZAR
        void form_close(object sender, FormClosingEventArgs e)
        {
            Form form = (Form)sender;
            form.Hide();
            e.Cancel = true;
        }

        //APAGAR
        private void trash_DoubleClick(object sender, EventArgs e){
            var count = 0;

            StreamReader sr = new StreamReader(@"C:\NotesReminderData\Data.txt");
            string line = sr.ReadLine();
            while (line != null)
            {
                count++;
                if (line.Contains(this.Id))
                {
                    break;
                }
                line = sr.ReadLine();
            }
            sr.Close();

            string[] arrLine = File.ReadAllLines(@"C:\NotesReminderData\Data.txt");
            if (!((count - 1) < 0)) {
                arrLine[count - 1] = "";
                File.WriteAllLines(@"C:\NotesReminderData\Data.txt", arrLine);
            }
            this.IsToRemove = true;
            this.Close();
        }

        //DRAG
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        //RESIZE
        void SizerMouseDown(object sender, MouseEventArgs e){
            mov = true;
            My = MousePosition.Y;
            Mx = MousePosition.X;
            Sw = Width;
            Sh = Height;
        }
        void SizerMouseMove(object sender, MouseEventArgs e){
            if (mov == true){
                Width = MousePosition.X - Mx + Sw;
                Height = MousePosition.Y - My + Sh;
            }
        }
        void SizerMouseUp(object sender, MouseEventArgs e){
            mov = false;
        }

        /*protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            e.Graphics.FillRectangle(Brushes.DarkBlue, rc);
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }
            base.WndProc(ref m);
        }*/

    }
}
