using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeBuilder
{
    internal class Entry (string title, DateTime startDate, DateTime endDate, string? organization, string? address, string body)
    {
        public Section? Section { get; set; }
        public string Title { get; set; } = title;
        public DateTime StartDate { get; set; } = startDate;
        public DateTime EndDate { get; set; } = endDate;
        public bool IsReceivingDate { get; set; }
        public bool HasNoEndDate { get; set; }
        public string? Organization { get; set; } = organization;
        public string? Address { get; set; } = address;
        public bool HasAddress { get; set; }
        public string Body { get; set; } = body;
        
    }
}
