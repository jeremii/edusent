using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace edusent_service.Models
{
    [Table("Students", Schema="edusent")]
    public class Student : User
    {
        [InverseProperty(nameof(Session.Student))]
        public List<Session> Sessions { get; set; } = new List<Session>();
    }
}
