﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesReminder
{
    public partial class TransparentPanel : Panel
    {
        private const int WS_EX_TRANSPARENT = 0x20;
        private int opacity = 0;
        public TransparentPanel()
        {
            InitializeComponent();
            SetStyle(ControlStyles.Opaque, true);

        }

        public TransparentPanel(IContainer con)
        {
            con.Add(this);
            InitializeComponent();
        }

        [DefaultValue(0)]
        public int Opacity
        {
            get{
                return this.opacity;
            }

            set{
                if (value < 0 || value > 100)
                    throw new ArgumentException("value must be between0 and 100");
                    this.opacity = value;
            }
        }

        protected override CreateParams CreateParams
        {
            get{
                CreateParams cpar = base.CreateParams;
                cpar.ExStyle = cpar.ExStyle | WS_EX_TRANSPARENT;
                return cpar;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (var brush = new SolidBrush(Color.FromArgb(this.opacity * 255 / 100, this.BackColor))){
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
            base.OnPaint(e);
        }
    }
}
