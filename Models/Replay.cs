using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eLearning.Models
{
    public class Replay
    {
        public Guid ReplayId { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime? PostatLa { get; set; }
        public Guid StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        public Guid CommentId { get; set; }
        [ForeignKey("CommentId")]
        public virtual Comment Comment { get; set; }

    }
}