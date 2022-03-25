using System.Text;

namespace NotesReminder
{
    public partial class MainForm : Form
    {
        public List<Note> notes = new List<Note>();
        public MainForm()
        {
            InitializeComponent();
            createFile();
            initializeNotes();
            this.Resize += new EventHandler(Form1_Resize);
            this.FormClosing += new FormClosingEventHandler(form_close);
        }

        private void initializeNotes()
        {
            if (File.Exists(@"C:\NotesReminderData\Data.txt"))
            {
                foreach (string line in System.IO.File.ReadLines(@"C:\NotesReminderData\Data.txt"))
                {
                    if(!line.Equals(""))
                        createNoteFromFile(line);
                }
            }
        }

        //SAVEDATA
        private static async Task saveDataTotal(string data)
        {
            //using StreamWriter file = new(@"C:\NotesReminderData\Data.txt", append: true);
            //await file.WriteLineAsync(data);
            await File.WriteAllTextAsync(@"C:\NotesReminderData\Data.txt", data);
        }

        //CREATE 
        private void createNoteFromFile(string data)
        {
            createNote(data);
        }
        private void createNote(string data)
        {
            DateTime date = DateTime.Now;
            Note note = new Note();
            note.Id = date.ToString();
            
            var box = note.Controls.Find("richTextBoxNote", true)[0];
            
            var text = ""; var w = "0"; var h = "0"; var t = "0"; var l = "0";
            note.StartPosition = FormStartPosition.Manual;
            note.monthCalendar = monthCalendarDate;

            if (data.Equals(" ")) {
                box.Text = richTextBoxContent.Text;
            }else{
                note.Id = data.Split(";")[2];
                text = data.Split(";")[0];
                var propreties = data.Split(";")[1];
                w = propreties.Split(",")[0];
                h = propreties.Split(",")[1];
                t = propreties.Split(",")[2];
                l = propreties.Split(",")[3];

                box.Text = text;
                note.Width = Int32.Parse(w);
                note.Height = Int32.Parse(h);
                note.Top = Int32.Parse(t);
                note.Left = Int32.Parse(l);
                note.Location = new Point(Int32.Parse(l), Int32.Parse(t));
            }
                
            notes.Add(note);
            note.Show();
        }

        //BUTTONS EVENTS
        private void buttonAdd_Click(object sender, EventArgs e){
            createNote(" ");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach(Note note in notes){
                note.Show();
            }
        }
        void form_close(object sender, FormClosingEventArgs e)
        {
            string dataToSave = "";
            var text=""; var w=0; var h=0; var t = 0; var l = 0;

            foreach (Note note in notes){
                if (note.IsToRemove == false){
                    text = note.Controls.Find("richTextBoxNote", true)[0].Text;
                    w = note.Width; h = note.Height; t = note.Top; l = note.Left;
                    dataToSave += text + ";" + w + "," + h + "," + t + "," + l + ";" + note.Id;
                    dataToSave += "\n";
                }
            }
            saveDataTotal(dataToSave);
        }

        //SYSTEM TRAY
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        //FILE HANDLER
        private void createFile()
        {
            string path = @"C:\NotesReminderData\Data.txt";
            if (!File.Exists(path))
            {
                try
                {
                    // Create the file, or overwrite if the file exists.
                    using (FileStream fs = File.Create(path))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes("");
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }

                    // Open the stream and read it back.
                    /*using (StreamReader sr = File.OpenText(path))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(s);
                        }
                    }*/
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}