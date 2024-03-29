using System.Text;
using System.Text.Json;

namespace NotesReminder
{
    public partial class MainForm : Form
    {
        private Color[] colors = { Color.Green, Color.LightGreen, Color.Yellow, Color.Orange, Color.Red };
        public List<Note> notes = new List<Note>();
        
        public MainForm()
        {
            InitializeComponent();
            initializeNotes();
            initializeListBox();
            this.Resize += new EventHandler(Form1_Resize);   
        }

        public void initializeListBox(){
            ListBox listBox = new ListBox();

            listBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)| System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            listBox.FormattingEnabled = true;
            listBox.ItemHeight = 15;
            listBox.Location = new System.Drawing.Point(12, 55);
            listBox.Name = "listBoxNotes";
            listBox.Size = new System.Drawing.Size(192, 274);
            listBox.DataSource = this.notes;
            listBox.DisplayMember = "noteText";

            this.Controls.Add(listBox);
        }

        public void initializeNotes()
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
                
            note.initialDate = date.ToShortDateString();

            notes.Add(note);
            note.Show();
        }
        private void initializeJsonNote(string path)
        {
            if (File.ReadAllText(path).Equals("")) {
                //vazio
            }else{
                Note note = new Note();

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
                note.dateTimePicker.Value = DateTime.ParseExact($"{noteContent.date}", "dd/MM/yyyy", null);
                note.initialDate = ($"{noteContent.initialDate}");

                Color tempColor = calculateBgBasedOnDate($"{noteContent.date}", $"{noteContent.initialDate}");
                note.BackColor = tempColor;

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

        private Color calculateBgBasedOnDate(string dateAux, string inidateAux)
        {
            DateTime date = DateTime.ParseExact(dateAux, "dd/MM/yyyy", null);
            DateTime inidate = DateTime.ParseExact(inidateAux, "dd/MM/yyyy", null);

            int thresholdHelper = date.Subtract(inidate).Days;
            int threshold = thresholdHelper / 5;

            if (DateTime.Now > inidate && DateTime.Now < date)
            {
                int numDays = date.Subtract(DateTime.Now).Days;
                if (numDays < threshold)
                {
                    return colors[4];
                }else if(numDays <= threshold*2){
                    return colors[3];
                }
                else if (numDays <= threshold *3)
                {
                    return colors[2];
                }
                else if (numDays <= threshold *4)
                {
                    return colors[1];
                }
                else
                {
                    return colors[0];
                }
            }
            else
            {
                return Color.Black;
            }
        }

    }
}