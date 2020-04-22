using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace edusent_service.Models
{
    [Table("Ratings", Schema ="edusent")]
    public class Rating : EntityBase
    {
        [Required]
        public bool RateForTeacher { get; set; }

        [Required]
        public string SessionId { get; set; }
        [ForeignKey(nameof(SessionId))]
        public Session Session { get; set; }

        [Required]
        public byte Stars { get; set; }

        [EnumDataType(typeof(Reason))]
        public Reason Reason { get; set; }

    }
    public enum Reason
    {
        None,
        Late,
        Poor_communication,
        Unprofessional,
        Unprepared,
        Lacks_knowledge
    }
}
