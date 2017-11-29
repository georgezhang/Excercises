using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Excercises.Models
{
    [Table("UserExam")]
    public class UserExam
    {
        public int UserExamID { get; set; }
        
        [Required]
        [Display(Name = "Start Exam Date")]
        public DateTime StartExamDateTime { get; set; }

        [Display(Name = "Latest Exam Date")]
        public DateTime LatestExamDateTime { get; set; }

        [Display(Name = "Final Score")]
        public int FinalScore { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Exam Exam { get; set; }
        public virtual ICollection<QuestionTaken> QuestionTakens { get; set; }
    }
}