using progCompany.Models.DeveloperModel;

namespace progCompany.Models.Project
{
    public class ProjectDeveloper
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; } 

        public int DeveloperId { get; set; }
        public developerModel Developer { get; set; }
    }
}
