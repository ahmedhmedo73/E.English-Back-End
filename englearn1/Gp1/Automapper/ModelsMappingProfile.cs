using AutoMapper;
using Gp1.model;

namespace Gp1.Automapper
{
    public class ModelsMappingProfile : Profile
    {
        public ModelsMappingProfile()
        {
            CreateMap<Questions, QuestionDetails>()
            .ForMember(dest => dest.WrongCount, opt => opt.MapFrom(src =>  src.UsersAnswers.Where(c => !c.IsCorrectAnswer).Select(c=> c.IsCorrectAnswer).Count()))
            .ForMember(dest => dest.RightCount, opt => opt.MapFrom(src =>  src.UsersAnswers.Where(c => c.IsCorrectAnswer).Select(c => c.IsCorrectAnswer).Count() ))
            .ForMember(dest => dest.TotalCount, opt => opt.MapFrom(src =>  src.UsersAnswers.Select(c => c.IsCorrectAnswer).Count() ))
            .ForMember(dest => dest.Question, opt => opt.MapFrom(src => src.Question))
            .ForMember(dest => dest.QuestionAnswers, opt => opt.MapFrom(src => src.Answers))
            .ForMember(dest => dest.UsersAnswers, opt => opt.MapFrom(src => src.UsersAnswers))
            ;

            CreateMap<Answers, QuestionAnswersLight>()
            .ForMember(dest => dest.Answer, opt => opt.MapFrom(src => src.AnswerText))
            .ForMember(dest => dest.IsCorrect, opt => opt.MapFrom(src => src.IsCorrectAnswer))
            ;

            CreateMap<UsersAnswers, UsersAnswersLight>()
            .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => $"{src.User.Fname} {src.User.Lname}"))
            .ForMember(dest => dest.UserAnswer, opt => opt.MapFrom(src => src.Answer.AnswerText))
            .ForMember(dest => dest.IsCorrect, opt => opt.MapFrom(src => src.IsCorrectAnswer))
            .ForMember(dest => dest.AnswerTime, opt => opt.MapFrom(src => src.CreationTime))
            ;


            //-------------------------------------------------------------------
            CreateMap<SpokenSentence, SentenceDetails>()
           .ForMember(dest => dest.WrongCount, opt => opt.MapFrom(src =>  src.UsersAnswers.Where(c => !c.IsCorrectAnswer).Select(c => c.IsCorrectAnswer).Count()))
           .ForMember(dest => dest.RightCount, opt => opt.MapFrom(src =>  src.UsersAnswers.Where(c => c.IsCorrectAnswer).Select(c => c.IsCorrectAnswer).Count() ))
           .ForMember(dest => dest.TotalCount, opt => opt.MapFrom(src =>  src.UsersAnswers.Select(c => c.IsCorrectAnswer).Count()))
           .ForMember(dest => dest.Sentence, opt => opt.MapFrom(src => src.Sentence))
           .ForMember(dest => dest.UsersAnswers, opt => opt.MapFrom(src => src.UsersAnswers))
           ;

            CreateMap<Answers, QuestionAnswersLight>()
            .ForMember(dest => dest.Answer, opt => opt.MapFrom(src => src.AnswerText))
            .ForMember(dest => dest.IsCorrect, opt => opt.MapFrom(src => src.IsCorrectAnswer))
            ;

            CreateMap<UsersAnswers, UsersAnswersLight>()
            .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => $"{src.User.Fname} {src.User.Lname}"))
            .ForMember(dest => dest.UserAnswer, opt => opt.MapFrom(src => src.Answer.AnswerText))
            .ForMember(dest => dest.IsCorrect, opt => opt.MapFrom(src => src.IsCorrectAnswer))
            .ForMember(dest => dest.AnswerTime, opt => opt.MapFrom(src => src.CreationTime))
            ;

            CreateMap<SentenceUsersAnswers, UsersAnswersLight>()
            .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => $"{src.User.Fname} {src.User.Lname}"))
            .ForMember(dest => dest.UserAnswer, opt => opt.MapFrom(src => src.UserAnswer))
            .ForMember(dest => dest.IsCorrect, opt => opt.MapFrom(src => src.IsCorrectAnswer))
            .ForMember(dest => dest.AnswerTime, opt => opt.MapFrom(src => src.CreationTime))
            ;



            //-------------------------------------------------------------------
            CreateMap<ApplicationUser, UserAnswersForQusetions>()
               .ForMember(dest => dest.WrongCount, opt => opt.MapFrom(src =>  src.UsersAnswers.Where(c => !c.IsCorrectAnswer).Select(c=> c.IsCorrectAnswer).Count()) )
               .ForMember(dest => dest.RightCount, opt => opt.MapFrom(src =>  src.UsersAnswers.Where(c => c.IsCorrectAnswer).Select(c => c.IsCorrectAnswer).Count() ))
               .ForMember(dest => dest.TotalCount, opt => opt.MapFrom(src =>src.UsersAnswers.Select(c => c.IsCorrectAnswer).Count() ))
               .ForMember(dest => dest.QuestionsAnswers, opt => opt.MapFrom(src => src.UsersAnswers))
          ;
            CreateMap<UsersAnswers, UserQuestionAnswerVM>()
           .ForMember(dest => dest.Question, opt => opt.MapFrom(src =>src.Question.Question))
           .ForMember(dest => dest.CorrectAnswer, opt => opt.MapFrom(src =>src.Question.Answers.Where(c=> c.IsCorrectAnswer).Select(c=> c.AnswerText).FirstOrDefault()))
           .ForMember(dest => dest.UserAnswer, opt => opt.MapFrom(src => src.Answer.AnswerText))
           .ForMember(dest => dest.IsCorrect, opt => opt.MapFrom(src => src.IsCorrectAnswer))
           .ForMember(dest => dest.AnswerTime, opt => opt.MapFrom(src => src.CreationTime))
           ;

            CreateMap<ApplicationUser, UserAnswersForSentences>()
               .ForMember(dest => dest.WrongCount, opt => opt.MapFrom(src =>  src.SentenceUsersAnswers.Where(c => !c.IsCorrectAnswer).Select(c=> c.IsCorrectAnswer).Count() ))
               .ForMember(dest => dest.RightCount, opt => opt.MapFrom(src =>  src.SentenceUsersAnswers.Where(c => c.IsCorrectAnswer).Select(c => c.IsCorrectAnswer).Count() ))
               .ForMember(dest => dest.TotalCount, opt => opt.MapFrom(src =>  src.SentenceUsersAnswers.Select(c => c.IsCorrectAnswer).Count()))
               .ForMember(dest => dest.SentenceAnswers, opt => opt.MapFrom(src => src.SentenceUsersAnswers))
          ;

            CreateMap<SentenceUsersAnswers, UserSentencesAnswerVM>()
           .ForMember(dest => dest.sentence, opt => opt.MapFrom(src =>src.Sentence.Sentence))
           .ForMember(dest => dest.UserAnswer, opt => opt.MapFrom(src => src.UserAnswer))
           .ForMember(dest => dest.IsCorrect, opt => opt.MapFrom(src => src.IsCorrectAnswer))
           .ForMember(dest => dest.AnswerTime, opt => opt.MapFrom(src => src.CreationTime))
           ;
            
            CreateMap<ApplicationUser, UserInfoVM>()
           .ForMember(dest => dest.Fname, opt => opt.MapFrom(src =>src.Fname))
           .ForMember(dest => dest.Lname, opt => opt.MapFrom(src => src.Lname))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
           .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserName))
           .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
           .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age))
           ;

        }
    }
}
