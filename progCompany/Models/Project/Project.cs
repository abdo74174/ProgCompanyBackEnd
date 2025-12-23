using progCompany.Models.DeveloperModel;
using System;
using System.Collections.Generic;

namespace progCompany.Models.Project
{
    public class Project
    {
        public Project()
        {
            ProjectDevelopers = new HashSet<ProjectDeveloper>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // In Progress, Completed, Pending
        public DateTime Deadline { get; set; }
        public int ProgressPercent { get; set; }
        public DateTime LastUpdated { get; set; }

        public int TeamLeadId { get; set; }
        public developerModel TeamLead { get; set; }

        public ICollection<ProjectDeveloper> ProjectDevelopers { get; set; }
    }
}
