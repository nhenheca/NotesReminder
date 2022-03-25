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
        public MonthCalendar monthCalendar;
        public string Id;
        public Note()
        {
            InitializeComponent();
            monthCalendar = new MonthCalendar();
            this.FormClosing += new FormClosingEventHandler(form_close);
            // ActiveForm will give you access to the current opened/activated Form1 instance
        }
        void form_close(object sender, FormClosingEventArgs e)
        {
            Form form = (Form)sender;
            form.Hide();
            e.Cancel = true;
        }

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
            arrLine[count - 1] = "";
            File.WriteAllLines(@"C:\NotesReminderData\Data.txt", arrLine);

            
        }
    }
}
