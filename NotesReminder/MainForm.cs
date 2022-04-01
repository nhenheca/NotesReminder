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
            initializeNotes();
            initializeListBox();
            this.Resize += new EventHandler(Form1_Resize);   
        }

        private void initializeListBox(){
            ListBox listBoxNotes = new System.Windows.Forms.ListBox();
            listBoxNotes.FormattingEnabled = true;
            listBoxNotes.ItemHeight = 15;
            listBoxNotes.Location = new System.Drawing.Point(12, 51);
            listBoxNotes.Name = "listBoxNotes";
            listBoxNotes.Size = new System.Drawing.Size(192, 289);
            listBoxNotes.DataSource = notes;
            listBoxNotes.DisplayMember = "Name";

            this.Controls.Add(listBoxNotes);
        }

        private void initializeNotes()
        {
            string[] files = Directory.GetFiles(@"C:\NotesReminderData", "*.json");
            foreach (var file in files){
                initializeJsonNote(file.ToString());
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
                
            notes.Add(note);
            note.Show();
        }
        public void initializeJsonNote(string path)
        {
            if (File.ReadAllText(path).Equals("")) {
                //vazio
            }else{
                Note note = new Note();
                NoteContent noteContent = new NoteContent();

                note.StartPosition = FormStartPosition.Manual;
                note.dad = this;

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

    }
}