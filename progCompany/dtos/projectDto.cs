namespace progCompany.dtos
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Deadline { get; set; }
        public AssignedDto Assigned { get; set; }
        public ProgressDto Progress { get; set; }
    }

    public class AssignedDto
    {
        public string TeamLead { get; set; }
        public List<string> Developers { get; set; }
    }

    public class ProgressDto
    {
        public int Percent { get; set; }
    }

    public class UpdateProgressDto
    {
        public int ProjectId { get; set; }
        public int DeveloperId { get; set; }
        public int ProgressPercent { get; set; }
    }

}
