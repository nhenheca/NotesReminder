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
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        public string Id;
        public bool IsToRemove;
        public MonthCalendar monthCalendar;

        public Note()
        {
            InitializeComponent();
            monthCalendar = new MonthCalendar();
            IsToRemove = false;
            this.FormClosing += new FormClosingEventHandler(form_close);
            // ActiveForm will give you access to the current opened/activated Form1 instance
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
    }
}
