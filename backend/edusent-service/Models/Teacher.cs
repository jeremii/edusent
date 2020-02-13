using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace edusent_service.Models
{
    [Table("Teachers", Schema ="edusent")]
    public class Teacher : User
    {
        public Int64 MoneyMade { get; set; }

        [InverseProperty(nameof(Subject.Teacher))]
        public List<Subject> Subjects { get; set; } = new List<Subject>();

        [InverseProperty(nameof(Session.Teacher))]
        public List<Session> Sessions { get; set; } = new List<Session>();

    }
}
