using System.Text;
using System.Text.Json;

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
        }

        private void initializeNotes()
        {
            if (File.Exists(@"C:\NotesReminderData\Data.txt"))
            {
                initializeJsonNote();
            }
        }
        //CREATE
        public void createNote()
        {
            DateTime date = DateTime.Now;
            Note note = new Note();
            note.Id = date.ToString();
            note.dad = this;
 
            note.StartPosition = FormStartPosition.Manual;
            note.dateTimePicker = dateTimePickerMain;
                
            notes.Add(note);
            note.Show();
        }
        public void initializeJsonNote()
        {
            Note note = new Note();
            note.StartPosition = FormStartPosition.Manual;
            note.dad = this;

            string path = @"C:\NotesReminderData\Data.txt";
            string jsonString = File.ReadAllText(path);
            NoteContent noteContent = JsonSerializer.Deserialize<NoteContent>(jsonString)!;

            note.Id = $"{noteContent.id}";
            note.Controls.Find("richTextBoxNote", true)[0].Text = $"{noteContent.text}";
            note.Width = Int32.Parse($"{noteContent.width}");
            note.Height = Int32.Parse($"{noteContent.height}");
            note.Top = Int32.Parse($"{noteContent.top}");
            note.Left = Int32.Parse($"{noteContent.left}");
            note.Location = new Point(Int32.Parse($"{noteContent.left}"), 
                Int32.Parse($"{noteContent.top}"));

            notes.Add(note);
            note.Show();
        }
        //BUTTONS EVENTS
        private void buttonAdd_Click(object sender, EventArgs e){
            createNote();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach(Note note in notes){
                note.Show();
            }
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