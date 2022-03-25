using System.Text;

namespace NotesReminder
{
    public partial class Form1 : Form
    {
        private List<Form> forms = new List<Form>();
        public Form1()
        {
            InitializeComponent();
            createFile();
            initializeNotes();
            this.Resize += new EventHandler(Form1_Resize);
        }

        private void createNote(string data)
        {
            Form form1 = new Form();
            Panel panel = new Panel();
            RichTextBox textBoxContent = new RichTextBox();

            //CONTENT
            //textBoxContent.Size = new Size(227, 163);
            textBoxContent.ReadOnly = true;
            if (data.Equals(" "))
                textBoxContent.Text = richTextBoxContent.Text;
            else
                textBoxContent.Text = data;
            //textBoxContent.Location = new Point(0, 0);
            textBoxContent.BackColor = Color.FromArgb(253, 247, 226);
            textBoxContent.Dock = DockStyle.Fill;
            textBoxContent.BorderStyle = BorderStyle.None;

            //PANEL
            
            panel.Controls.Add(textBoxContent);
            panel.Padding = new Padding(10);
            panel.Dock = DockStyle.Fill;

            //FORM          
            form1.Size = new Size(250, 200);
            form1.Text = textBoxContent.Text.Split("\n")[0];
            //form1.FormBorderStyle = FormBorderStyle;
            form1.MaximizeBox = false;
            form1.MinimizeBox = false;
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.BackColor = Color.FromArgb(253, 247, 226);

            //ADD
            form1.Controls.Add(panel);

            //EVENTOS
            form1.FormClosing += new FormClosingEventHandler(form_close);

            //VIEW
            form1.Show();

            //LIST
            forms.Add(form1);
        }

        private void createNoteFromApp(){
            createNote(" ");
            saveData(richTextBoxContent.Text);
        }

        private void createNoteFromFile(string data)
        {
            createNote(data);
        }

        private void buttonAdd_Click(object sender, EventArgs e){
            createNoteFromApp();
        }

        void form_close(object sender, FormClosingEventArgs e)
        {
            Form form = (Form)sender;
            form.Hide();
            e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(Form form in forms){
                form.Show();
            }
        }

        private void initializeNotes(){
            if (File.Exists(@"C:\NotesReminderData\Data.txt")){
                foreach (string line in System.IO.File.ReadLines(@"C:\NotesReminderData\Data.txt"))
                {
                    createNoteFromFile(line);
                }
            }
        }

        private void createFile() {
            string path = @"C:\NotesReminderData\Data.txt";
            if (!File.Exists(path)){
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

        private static async Task saveData(string data){
            using StreamWriter file = new(@"C:\NotesReminderData\Data.txt", append: true);
            await file.WriteLineAsync(data);
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