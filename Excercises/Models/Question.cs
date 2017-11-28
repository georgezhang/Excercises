using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Excercises.Models
{
    //QuestionID (PK), examId (FK), questionText, hints, answer, score
    [Table("Question")]
    public class Question
    {
        public int QuestionID { get; set; }

        [Required]
        [StringLength(4000)]
        [Display(Name = "Question")]
        public string QuestionText { get; set; }

        [StringLength(4000)]
        [Display(Name = "Hints")]
        public string Hints { get; set; }

        [StringLength(4000)]
        [Display(Name = "Answer")]
        public string Answer { get; set; }

        public int Score { get; set; }

        public virtual Exam Exam { get; set; }
    }
}