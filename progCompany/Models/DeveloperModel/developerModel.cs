using progCompany.Models.Project;
using progCompany.Models.UserModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace progCompany.Models.DeveloperModel
{
    public class developerModel
    {
        public developerModel()
        {
            ProjectDevelopers = new HashSet<ProjectDeveloper>(); // initialize collection
        }
        [Key]
        public int UserId { get; set; }
        public string skills { get; set; }
        public string experince { get; set; }
        public string GithubUrl { get; set; }
        public string Timezone { get; set; }

        public UserClass User { get; set; }

        // Add this navigation property
        public ICollection<ProjectDeveloper> ProjectDevelopers { get; set; }
    }
}
