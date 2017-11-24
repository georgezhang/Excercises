using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Web.Mvc;

namespace Excercises.Models
{
    [Table("Exam")]
    public class Exam
    {
        public int ExamID { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Exam Name")]
        public string Name { get; set; }

        [StringLength(500)]
        [Display(Name = "Exam Description")]
        public string Description { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}