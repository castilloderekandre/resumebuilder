using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeBuilder
{
    public class Section
    {
        public string Title { get; set; }
        public List<Entry> Entries { get; set; } = [];
    }
}
