using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace edusent_service.Models
{
    [Table("Sessions", Schema="edusent")]
    public class Session :EntityBase
    {
        // Requestor
        [Required]
        public string StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public User Student { get; set; }

        // Assigned Teacher
        public string TeacherId { get; set; }
        [ForeignKey(nameof(TeacherId))]
        public User Teacher { get; set; }

        [InverseProperty(nameof(Rating.Session))]
        public List<Rating> Ratings { get; set; } = new List<Rating>();

        // Session Status
        [EnumDataType(typeof(SessionStatus))]
        public SessionStatus Status { get; set; }

        // Date / Time
        [Required]
        [Range(30, 480, ErrorMessage = "Must be between 30 to 480 mins")]
        public int Duration { get; set; }

        [Required]
        public DateTime Start { get; set; }

        public DateTime? ActualStart { get; set; }

        public DateTime? AcutalEnd { get; set; }

        // Payment
        [Required]
        [Range(0, 1000, ErrorMessage = "Must be between $0 to $1,000")]
        public int Tip { get; set; }

        // Location
        [Required]
        [Range(-81.753534, -81.299198, ErrorMessage ="Must be within MOV region.")]
        public double Longitude { get; set; }

        [Required]
        [Range(39.141120, 39.508030, ErrorMessage ="Must be within MOV region")]
        public double Latitude { get; set; }
    }
    public enum SessionStatus
    {
        Requested,
        PendingTutor,
        Confirmed,
        Cancelled,
        InSession,
        Complete
    }
}
