using Microsoft.AspNetCore.Identity;

namespace Gp1.model
{
    public class ApplicationUser : IdentityUser
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string? Picture { get; set; }
        public int LoginCount { get; set; }
        public int? CurrentVideoId { get; set; }
        public int? CurrentCategoryId { get; set; }
        public DateTime CreationTime { get; set; }
        public ICollection<ApplicationUserRole>? UserRoles { get; } = new List<ApplicationUserRole>();

        public ICollection<UsersAnswers>? UsersAnswers { get; set; }
        public ICollection<SentenceUsersAnswers>? SentenceUsersAnswers { get; set; }
        public ICollection<comment>? Comments { get; set; }
        public ICollection<Views>? Views { get; set; }
        public Video? CurrentVideo { get; set; }
        public Category? CurrentCategory { get; set; }
    }
    public class ApplicationRole : IdentityRole<string>
    {
        public ApplicationRole() { }

        public ApplicationRole(string roleName)
            : base(roleName)
        {
        }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; } = new List<ApplicationUserRole>();
    }
    public class ApplicationUserRole : IdentityUserRole<string>
    {

        public ApplicationUser User { get; set; }
        public ApplicationRole Role { get; set; }
    }
    public enum Roles
    {
        Admin,
        User,
    }
}
