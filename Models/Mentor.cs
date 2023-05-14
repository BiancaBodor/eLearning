using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eLearning.Models
{
    public enum Nivel
    {
        Incepator,
        Mediu,
        Avansat
    }
    public class Mentor
    {
        public Guid MentorId { get; set; }
        public string NumeMentor { get; set; }
        public string PrenumeMentor { get; set; }
        public Nivel Nivel { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Descriere { get; set; }

        public virtual ICollection<Resurse> Resurses { get; set; }
    }
}