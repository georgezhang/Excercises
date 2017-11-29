using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Excercises.Models
{
    [Table("QuestionTaken")]
    public class QuestionTaken
    {
        public int QuestionTakenID { get; set; }

        [Display(Name = "My Answer")]
        [StringLength(4000)]
        public String MyAnswer { get; set; }

        public virtual UserExam UserExam { get; set; }
        public virtual Question Question { get; set; }
    }
}