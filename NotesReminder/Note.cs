using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace NotesReminder
{
    public partial class Note : Form
    {
        public System.Timers.Timer noteTimer; 
        
        int Mx;int My;int Sw;int Sh;bool mov;

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        public string Id;
        public DateTimePicker dateTimePicker;
        public MainForm dad;

        public Note()
        {
            InitializeComponent();
            //EVENT
            this.FormClosing += new FormClosingEventHandler(form_close);
            //INI
            dateTimePicker = new DateTimePicker();
        }
        
        private void form_close(object sender, EventArgs e)
        {
            Form currentForm = Form.ActiveForm;
            currentForm.Hide();
        }

        //APAGAR
        private void trash_DoubleClick(object sender, EventArgs e){
            string fileToRemove = this.Id;
            fileToRemove = fileToRemove.Replace("/", "");
            fileToRemove = fileToRemove.Replace(":", "");
            fileToRemove = fileToRemove.Replace(" ", "");
            string path = @"C:\NotesReminderData\" + fileToRemove + ".json";

            File.Delete(path);
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

        //SAVE
        private void richTextBoxNote_TextChanged(object sender, EventArgs e)
        {
            noteSaveJson(); 
        }

        private async Task noteSaveJson()
        {
            NoteContent noteContent = new NoteContent();
            noteContent.id = this.Id;
            noteContent.text = richTextBoxNote.Text;
            noteContent.width = this.Width;
            noteContent.height = this.Height;
            noteContent.top = this.Top;
            noteContent.left = this.Left;
            
            string jsonString = JsonSerializer.Serialize(noteContent);

            var noteName = noteContent.id.Replace("/", "");
            noteName = noteName.Replace(":", "");
            noteName = noteName.Replace(" ", "");

            string path = @"C:\NotesReminderData\"+ noteName + ".json";
            File.WriteAllText(path, jsonString);
        }

        //CSS
        //close
        private void close_MouseLeave(object sender, EventArgs e)
        {
            close.BackColor = Color.PaleGoldenrod;
            closeHover.BackColor = Color.PaleGoldenrod;
        }
        private void close_MouseEnter(object sender, EventArgs e)
        {
            close.BackColor = Color.Transparent;
            closeHover.BackColor = Color.FromArgb(32, 0, 0, 0);
        }
        private void closeHover_MouseEnter(object sender, EventArgs e)
        {
            close.BackColor = Color.Transparent;
            closeHover.BackColor = Color.FromArgb(32, 0, 0, 0);
        }
        private void closeHover_MouseLeave(object sender, EventArgs e)
        {
            close.BackColor = Color.PaleGoldenrod;
            closeHover.BackColor = Color.PaleGoldenrod;
        }
        //trash
        private void trash_MouseEnter(object sender, EventArgs e)
        {
            trash.BackColor = Color.Transparent;
            trashHover.BackColor = Color.FromArgb(32, 255, 0, 0);
        }
        private void trash_MouseLeave(object sender, EventArgs e)
        {
            trash.BackColor = Color.PaleGoldenrod;
            trashHover.BackColor = Color.PaleGoldenrod;
        }
        private void trashHover_MouseEnter(object sender, EventArgs e)
        {
            trash.BackColor = Color.Transparent;
            trashHover.BackColor = Color.FromArgb(32, 255, 0, 0);
        }
        private void trashHover_MouseLeave(object sender, EventArgs e)
        {
            trash.BackColor = Color.PaleGoldenrod;
            trashHover.BackColor = Color.PaleGoldenrod;
        }
        
        //date
        private void date_MouseEnter(object sender, EventArgs e)
        {
            date.BackColor = Color.Transparent;
            dateHover.BackColor = Color.FromArgb(32, 0, 0, 0);
        }
        private void date_MouseLeave(object sender, EventArgs e)
        {
            date.BackColor = Color.PaleGoldenrod;
            dateHover.BackColor = Color.PaleGoldenrod;
        }
        private void dateHover_MouseEnter(object sender, EventArgs e)
        {
            date.BackColor = Color.Transparent;
            dateHover.BackColor = Color.FromArgb(32, 0, 0, 0);
        }
        private void dateHover_MouseLeave(object sender, EventArgs e)
        {
            date.BackColor = Color.PaleGoldenrod;
            dateHover.BackColor = Color.PaleGoldenrod;
        }
        
        //plus
        private void plusHover_MouseEnter(object sender, EventArgs e)
        {
            plus.BackColor = Color.Transparent;
            plusHover.BackColor = Color.FromArgb(32, 0, 255, 0);
        }
        private void plusHover_MouseLeave(object sender, EventArgs e)
        {
            plus.BackColor = Color.PaleGoldenrod;
            plusHover.BackColor = Color.PaleGoldenrod;
        }
        private void plus_MouseEnter(object sender, EventArgs e)
        {
            plus.BackColor = Color.Transparent;
            plusHover.BackColor = Color.FromArgb(32, 0, 255, 0);
        }
        private void plus_MouseLeave(object sender, EventArgs e)
        {
            plus.BackColor = Color.PaleGoldenrod;
            plusHover.BackColor = Color.PaleGoldenrod;
        }

        //EVENTS
        private void panelAdd_Click(object sender, EventArgs e)
        {
            this.dad.createNote();
        }

        private void Note_LocationChanged(object sender, EventArgs e)
        {
            noteSaveJson();
        }

        private void Note_SizeChanged(object sender, EventArgs e)
        {
            noteSaveJson();
        }
    }
}
