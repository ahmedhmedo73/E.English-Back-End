using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gp1.model
{
    public class LoginVM
    {
        public string username { get; set; }
        public string pass { get; set; }
    }
    public class JWT
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double DurationInDays { get; set; }
    }
    public class AuthModel
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string Token { get; set; }
        public int? CurrentVideoId { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
    public class RegisterModel
    {
        public string Fname { get; set; }

        public string Lname { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string Gender { get; set; }

        [DefaultValue(0)]
        public int Age { get; set; }
    }
    public class TokenRequestModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
    public class AddRoleModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Role { get; set; }
    }

    #region QuestionsDetails

    public class QuestionAnswersLight
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class UsersAnswersLight
    {
        public int Id { get; set; }
        public string UserFullName { get; set; }
        public string UserAnswer { get; set; }
        public bool IsCorrect { get; set; }
        public DateTime AnswerTime { get; set; }
    }

    public class QuestionDetails
    {
        public int WrongCount { get; set; }
        public int RightCount { get; set; }
        public int TotalCount { get; set; }
        public string Question { get; set; }
        public List<QuestionAnswersLight> QuestionAnswers { get; set; }
        public List<UsersAnswersLight> UsersAnswers { get; set; }
    }
    public class SentenceDetails
    {
        public int WrongCount { get; set; }
        public int RightCount { get; set; }
        public int TotalCount { get; set; }
        public string Sentence { get; set; }
        public List<UsersAnswersLight> UsersAnswers { get; set; }
    }
    #endregion

    public class QuestionWithAnswersLight
    {
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string UserAnswer { get; set; }
        public bool IsCorrect { get; set; }
        public DateTime AnswerTime { get; set; }
    }
    public class AllUsersQusetionsAnswers
    {
        public int WrongCount { get; set; }
        public int RightCount { get; set; }
        public int TotalCount { get; set; }
        public List<QuestionWithAnswersLight> QuestionAnswers { get; set; }
    }
    public class SentenceWithAnswersLight
    {
        public string AentenceAnswer { get; set; }
        public string UserSentenceAnswer { get; set; }
        public bool IsCorrect { get; set; }
        public DateTime AnswerTime { get; set; }
    }

    public class AllUsersSentencesAnswers
    {
        public int WrongCount { get; set; }
        public int RightCount { get; set; }
        public int TotalCount { get; set; }
        public List<SentenceWithAnswersLight> SentenceAnswers { get; set; }
    }


    public class UserAnswersForQusetions
    {
        public int WrongCount { get; set; }
        public int RightCount { get; set; }
        public int TotalCount { get; set; }
        public ICollection<UserQuestionAnswerVM> QuestionsAnswers { get; set; }


    }
    public class UserQuestionAnswerVM
    {
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string UserAnswer { get; set; }
        public bool IsCorrect { get; set; }
        public DateTime AnswerTime { get; set; }
    }

    public class UserAnswersForSentences
    {
        public int WrongCount { get; set; }
        public int RightCount { get; set; }
        public int TotalCount { get; set; }
        public ICollection<UserSentencesAnswerVM> SentenceAnswers { get; set; }


    }
    public class UserSentencesAnswerVM
    {
        public string sentence { get; set; }
        public string UserAnswer { get; set; }
        public bool IsCorrect { get; set; }
        public DateTime AnswerTime { get; set; }
    }

    public class ReportsVM
    {
        public int TotalUsers { get; set; }
        public int TotalVideos { get; set; }
        public int TotalCategories { get; set; }
        public int TotalQuestions { get; set; }
        public List<RegisterUserCountPerDay>? RegisterUserCountPerDay { get; set; }
        public List<ListItemVM>? RightQuestionsAnswers { get; set; }
        public List<ListItemVM>? WrongQuestionsAnswers { get; set; }
        public List<ListItemVM>? WrongSentenceAnswers { get; set; }
        public List<ListItemVM>? RightSentenceAnswers { get; set; }
    }
    public class ListItemVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class RegisterUserCountPerDay
    {
        public int Count { get; set; }
        public DateTime Day { get; set; }
    }

    public class UserInfoVM
    {
        public string? Fname { get; set; }

        public string? Lname { get; set; }

        public string? Username { get; set; }

        public string? Email { get; set; }
        public string? Gender { get; set; }
        public int? Age { get; set; }
        public string? Picture { get; set; }
    }
    public class ChangePasswordVM
    {
        public string CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }
    }
    public class AuthMessageSenderOptions
    {
        public string? SendGridKey { get; set; }
    }
}

