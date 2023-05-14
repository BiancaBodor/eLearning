using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eLearning.Models
{
    public class Resurse
    {
        public Guid ResurseId { get; set; }
        public string Subiect { get; set; }
        public string Continut { get; set; }
        public string Comentarii { get; set; }

        public virtual Mentor Mentors { get; set; }
        public virtual Student Students { get; set; }
    }
}