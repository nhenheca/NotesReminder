namespace NotesReminder
{
    partial class Note
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Note));
            this.panel1 = new System.Windows.Forms.Panel();
            this.trash = new System.Windows.Forms.Panel();
            this.richTextBoxNote = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.trash);
            this.panel1.Controls.Add(this.richTextBoxNote);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(234, 161);
            this.panel1.TabIndex = 0;
            // 
            // trash
            // 
            this.trash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trash.AutoScroll = true;
            this.trash.AutoSize = true;
            this.trash.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("trash.BackgroundImage")));
            this.trash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.trash.Location = new System.Drawing.Point(187, 123);
            this.trash.Name = "trash";
            this.trash.Size = new System.Drawing.Size(47, 38);
            this.trash.TabIndex = 1;
            this.trash.DoubleClick += new System.EventHandler(this.trash_DoubleClick);
            // 
            // richTextBoxNote
            // 
            this.richTextBoxNote.BackColor = System.Drawing.Color.LemonChiffon;
            this.richTextBoxNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxNote.Location = new System.Drawing.Point(10, 10);
            this.richTextBoxNote.Name = "richTextBoxNote";
            this.richTextBoxNote.Size = new System.Drawing.Size(214, 141);
            this.richTextBoxNote.TabIndex = 0;
            this.richTextBoxNote.Text = "";
            // 
            // Note
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(234, 161);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Note";
            this.Text = "Note";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private RichTextBox richTextBoxNote;
        private Panel trash;
    }
}