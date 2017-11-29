using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Excercises.Models
{
    public class MyAnswerViewModel
    {
        public int ExamID { get; set; }
        public int QuestionID { get; set; }

        [Display(Name = "My Answer")]
        [StringLength(4000)]
        public String MyAnswer { get; set; }
    }
}