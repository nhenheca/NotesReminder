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
            this.divPanel = new System.Windows.Forms.Panel();
            this.richTextBoxNote = new System.Windows.Forms.RichTextBox();
            this.trash = new System.Windows.Forms.Panel();
            this.titlebarPanel = new System.Windows.Forms.Panel();
            this.dateHover = new System.Windows.Forms.Panel();
            this.date = new System.Windows.Forms.Panel();
            this.plusHover = new System.Windows.Forms.Panel();
            this.plus = new System.Windows.Forms.Panel();
            this.trashHover = new System.Windows.Forms.Panel();
            this.closeHover = new System.Windows.Forms.Panel();
            this.close = new System.Windows.Forms.Panel();
            this.divPanel.SuspendLayout();
            this.titlebarPanel.SuspendLayout();
            this.dateHover.SuspendLayout();
            this.plusHover.SuspendLayout();
            this.trashHover.SuspendLayout();
            this.closeHover.SuspendLayout();
            this.SuspendLayout();
            // 
            // divPanel
            // 
            this.divPanel.AutoSize = true;
            this.divPanel.Controls.Add(this.richTextBoxNote);
            this.divPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.divPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.divPanel.Location = new System.Drawing.Point(0, 0);
            this.divPanel.Margin = new System.Windows.Forms.Padding(0);
            this.divPanel.Name = "divPanel";
            this.divPanel.Padding = new System.Windows.Forms.Padding(10, 40, 10, 10);
            this.divPanel.Size = new System.Drawing.Size(298, 245);
            this.divPanel.TabIndex = 0;
            this.divPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SizerMouseDown);
            this.divPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SizerMouseMove);
            this.divPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SizerMouseUp);
            // 
            // richTextBoxNote
            // 
            this.richTextBoxNote.BackColor = System.Drawing.Color.LemonChiffon;
            this.richTextBoxNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBoxNote.Location = new System.Drawing.Point(10, 40);
            this.richTextBoxNote.Name = "richTextBoxNote";
            this.richTextBoxNote.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxNote.Size = new System.Drawing.Size(278, 195);
            this.richTextBoxNote.TabIndex = 0;
            this.richTextBoxNote.Text = "";
            // 
            // trash
            // 
            this.trash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trash.AutoScroll = true;
            this.trash.AutoSize = true;
            this.trash.BackColor = System.Drawing.Color.Transparent;
            this.trash.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("trash.BackgroundImage")));
            this.trash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.trash.Location = new System.Drawing.Point(5, 5);
            this.trash.Name = "trash";
            this.trash.Size = new System.Drawing.Size(20, 20);
            this.trash.TabIndex = 1;
            this.trash.DoubleClick += new System.EventHandler(this.trash_DoubleClick);
            this.trash.MouseEnter += new System.EventHandler(this.trash_MouseEnter);
            this.trash.MouseLeave += new System.EventHandler(this.trash_MouseLeave);
            // 
            // titlebarPanel
            // 
            this.titlebarPanel.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.titlebarPanel.Controls.Add(this.dateHover);
            this.titlebarPanel.Controls.Add(this.plusHover);
            this.titlebarPanel.Controls.Add(this.trashHover);
            this.titlebarPanel.Controls.Add(this.closeHover);
            this.titlebarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlebarPanel.Location = new System.Drawing.Point(0, 0);
            this.titlebarPanel.Name = "titlebarPanel";
            this.titlebarPanel.Size = new System.Drawing.Size(298, 30);
            this.titlebarPanel.TabIndex = 2;
            this.titlebarPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // dateHover
            // 
            this.dateHover.Controls.Add(this.date);
            this.dateHover.Location = new System.Drawing.Point(31, 0);
            this.dateHover.Name = "dateHover";
            this.dateHover.Size = new System.Drawing.Size(30, 30);
            this.dateHover.TabIndex = 8;
            this.dateHover.MouseEnter += new System.EventHandler(this.dateHover_MouseEnter);
            this.dateHover.MouseLeave += new System.EventHandler(this.dateHover_MouseLeave);
            // 
            // date
            // 
            this.date.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("date.BackgroundImage")));
            this.date.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.date.Location = new System.Drawing.Point(5, 5);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(20, 20);
            this.date.TabIndex = 4;
            this.date.MouseEnter += new System.EventHandler(this.date_MouseEnter);
            this.date.MouseLeave += new System.EventHandler(this.date_MouseLeave);
            // 
            // plusHover
            // 
            this.plusHover.Controls.Add(this.plus);
            this.plusHover.Location = new System.Drawing.Point(0, 0);
            this.plusHover.Name = "plusHover";
            this.plusHover.Size = new System.Drawing.Size(30, 30);
            this.plusHover.TabIndex = 7;
            this.plusHover.MouseEnter += new System.EventHandler(this.plusHover_MouseEnter);
            this.plusHover.MouseLeave += new System.EventHandler(this.plusHover_MouseLeave);
            // 
            // plus
            // 
            this.plus.AutoScroll = true;
            this.plus.AutoSize = true;
            this.plus.BackColor = System.Drawing.Color.Transparent;
            this.plus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("plus.BackgroundImage")));
            this.plus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.plus.Location = new System.Drawing.Point(5, 5);
            this.plus.Name = "plus";
            this.plus.Size = new System.Drawing.Size(20, 20);
            this.plus.TabIndex = 3;
            this.plus.Click += new System.EventHandler(this.panel4_Click);
            this.plus.MouseEnter += new System.EventHandler(this.plus_MouseEnter);
            this.plus.MouseLeave += new System.EventHandler(this.plus_MouseLeave);
            // 
            // trashHover
            // 
            this.trashHover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trashHover.Controls.Add(this.trash);
            this.trashHover.Location = new System.Drawing.Point(237, 0);
            this.trashHover.Name = "trashHover";
            this.trashHover.Size = new System.Drawing.Size(30, 30);
            this.trashHover.TabIndex = 6;
            this.trashHover.MouseEnter += new System.EventHandler(this.trashHover_MouseEnter);
            this.trashHover.MouseLeave += new System.EventHandler(this.trashHover_MouseLeave);
            // 
            // closeHover
            // 
            this.closeHover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeHover.Controls.Add(this.close);
            this.closeHover.Location = new System.Drawing.Point(268, 0);
            this.closeHover.Name = "closeHover";
            this.closeHover.Size = new System.Drawing.Size(30, 30);
            this.closeHover.TabIndex = 5;
            this.closeHover.MouseEnter += new System.EventHandler(this.closeHover_MouseEnter);
            this.closeHover.MouseLeave += new System.EventHandler(this.closeHover_MouseLeave);
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.close.AutoScroll = true;
            this.close.AutoSize = true;
            this.close.BackColor = System.Drawing.Color.Transparent;
            this.close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("close.BackgroundImage")));
            this.close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.close.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.close.ForeColor = System.Drawing.SystemColors.ControlText;
            this.close.Location = new System.Drawing.Point(5, 5);
            this.close.Margin = new System.Windows.Forms.Padding(10);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(20, 20);
            this.close.TabIndex = 2;
            this.close.Click += new System.EventHandler(this.form_close);
            this.close.MouseEnter += new System.EventHandler(this.close_MouseEnter);
            this.close.MouseLeave += new System.EventHandler(this.close_MouseLeave);
            // 
            // Note
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(298, 245);
            this.Controls.Add(this.titlebarPanel);
            this.Controls.Add(this.divPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(120, 0);
            this.Name = "Note";
            this.ShowInTaskbar = false;
            this.Text = "Note";
            this.TransparencyKey = System.Drawing.Color.White;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SizerMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SizerMouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SizerMouseUp);
            this.divPanel.ResumeLayout(false);
            this.titlebarPanel.ResumeLayout(false);
            this.dateHover.ResumeLayout(false);
            this.plusHover.ResumeLayout(false);
            this.plusHover.PerformLayout();
            this.trashHover.ResumeLayout(false);
            this.trashHover.PerformLayout();
            this.closeHover.ResumeLayout(false);
            this.closeHover.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel divPanel;
        private RichTextBox richTextBoxNote;
        private Panel trash;
        private Panel titlebarPanel;
        private Panel close;
        private Panel plus;
        private Panel date;
        private Panel closeHover;
        private Panel trashHover;
        private Panel plusHover;
        private Panel dateHover;
    }
}