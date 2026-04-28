using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Entry (string title, DateTime? startDate, DateTime? endDate, bool hasOneDate, bool hasNoDate, string? organization, bool hasOrganization, string? address, bool hasAddress, string body)
    {
        public Section? Section { get; set; }
        public string Title { get; set; } = title;
        public DateTime? StartDate { get; set; } = startDate;
        public DateTime? EndDate { get; set; } = endDate;
        public bool HasOneDate { get; set; } = hasOneDate;
        public bool HasNoDate { get; set; } = hasNoDate;
        public string? Organization { get; set; } = organization;
        public bool HasOrganization { get; set; } = hasOrganization;
        public string? Address { get; set; } = address;
        public bool HasAddress { get; set; } = hasAddress;
        public string Body { get; set; } = body;
        
    }
}
