using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesReminder
{
    internal class NoteContent{
        public string id { get; set; }
        public string text { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int top { get; set; }
        public int left { get; set; }
    }
}
