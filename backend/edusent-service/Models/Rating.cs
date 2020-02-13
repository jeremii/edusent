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
        public string RateForId { get; set; }
        [ForeignKey(nameof(RateForId))]
        public User RateFor { get; set; }

        [Required]
        public string RateById { get; set; }
        [ForeignKey(nameof(RateById))]
        public User RateBy { get; set; }

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
        Late,
        Poor_communication,
        Unprofessional,
        Unprepared,
        Lacks_knowledge
    }
}
