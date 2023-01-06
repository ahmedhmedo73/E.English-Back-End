using Gp1.model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection;

namespace Gp1.model
{
    public class DB : IdentityDbContext<ApplicationUser, ApplicationRole, string,
        IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public DB(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            //builder.UseIdentityColumns();

         
            base.OnModelCreating(builder);


            builder.Entity<ApplicationUser>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(e => e.UserRoles)
               .WithOne(e => e.User)
                 .HasForeignKey(uc => uc.UserId)
                 .IsRequired();

               
            });

            builder.Entity<ApplicationRole>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                .WithOne(e => e.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
            });
        }

        //public DbSet<user> Users {get; set;}
        public DbSet<UsersAnswers> UsersAnswers { get; set; }
        public DbSet<Video> videos { get; set; }
        public DbSet<Questions> questions { get; set; }
        public DbSet<SpokenSentence> spokenSentences { get; set; }
        public DbSet<comment> comments { get; set; }
        public DbSet<Views> Views { get; set; }
        public DbSet<result> result { get; set; }
        public DbSet<Answers> Answers { get; set; }
        public DbSet<SentenceUsersAnswers> SentenceUsersAnswers { get; set; }
        public DbSet<Category> Categories { get; set; }
    }

    public class UsersAnswers
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public bool IsCorrectAnswer { get; set; }
        public string UserId { get; set; }
        public Questions? Question { get; set; }
        public Answers? Answer { get; set; }
        public ApplicationUser? User { get; set; }
        public DateTime CreationTime { get; set; }

    }

    public class SentenceUsersAnswers
    {
        public int Id { get; set; }
        public string UserAnswer { get; set; }
        public int SentenceId { get; set; }
        public bool IsCorrectAnswer { get; set; }
        public string UserId { get; set; }

        public SpokenSentence? Sentence { get; set; }
        public ApplicationUser? User { get; set; }
        public DateTime CreationTime { get; set; }

    }
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
        public ICollection<Video>? Videos { get; set; }

    } public class Answers
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrectAnswer { get; set; }
        public int QuestionId { get; set; }
        public Questions? Question { get; set; }
        public DateTime CreationTime { get; set; }

    }

    

    public class Video
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Link_Vid { get; set; }
        public int deleteState { get; set; }
        public int viewsCount { get; set; }
        public DateTime CreationTime { get; set; }
        public ICollection<Questions>? Questions { get; set; }
        public ICollection<SpokenSentence>? SpokenSentences { get; set; }
        public ICollection<comment>? Comments { get; set; }
        public ICollection<Views>? Views { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }

    public class Views
    {
        public int id { get; set; }
        public int VideoId { get; set; }
        public string UserId { get; set; }
        public Video? Video { get; set; }
        public ApplicationUser? User { get; set; }
    }
    public class Questions
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public int CorrectAnswer { get; set; }
        public DateTime CreationTime { get; set; }
        public int deleteState { get; set; }

        public int VideoId { get; set; }
        public Video? Video { get; set; }
        public ICollection<UsersAnswers>? UsersAnswers { get; set; }
        public ICollection<Answers>? Answers { get; set; }
    }
    public class SpokenSentence
    {
        public int Id { get; set; }
        public string Sentence { get; set; }
        public int deleteState { get; set; }
        public DateTime CreationTime { get; set; }
        public int VideoId { get; set; }
        public Video? Video { get; set; }
        public ICollection<SentenceUsersAnswers>? UsersAnswers { get; set; }
    }
    public class comment
    {
        public int Id { get; set; }
        public string comm { get; set; }
        public DateTime CreationTime { get; set; }
        public int deleteState { get; set; }
        public string UserId { get; set; }
        public int VideoId { get; set; }
        public ApplicationUser? User { get; set; }
        public Video? Video { get; set; }
    }

    public class result
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int videoId { get; set; }
        public ApplicationUser? User { get; set; }
        public Video? Video { get; set; }
        public DateTime CreationTime { get; set; }
        public int deleteState { get; set; }
    }
}