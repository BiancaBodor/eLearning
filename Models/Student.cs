using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eLearning.Models
{
    public enum NivelStudii
    {
        Gimnaziu,
        Liceu,
        Facultate
    }
    public class Student
    {
        public Guid StudentId { get; set; }
        [MinLength(2),Required]
        public string NumeStudent { get; set; }
        [MinLength(2),Required]
        public string PrenumeStudent { get; set; }
        [Required]
        public NivelStudii NivelStudii { get; set; }
      
        public string Image { get; set; }

        public DateTime? PostatLa { get; set; }
        public virtual ICollection<Resurse> Resurses { get; set; }
    }
}