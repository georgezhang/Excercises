using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Excercises.Models
{
    public class TakeExamViewModels
    {
        public Exam exam { get; set; }
        public UserExam userExam { get; set; }
        public Question question { get; set; }
        public QuestionTaken questionTaken { get; set; }
    }
}