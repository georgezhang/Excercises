using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Excercises.Models
{
    public class ExamViewModel
    {
        public int ExamID { get; set; }

        [Display(Name = "Exam Name")]
        public string Name { get; set; }

        [Display(Name = "Exam Description")]
        public string Description { get; set; }

        public string Owner { get; set; }
    }
}