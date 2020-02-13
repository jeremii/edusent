using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace edusent_service.Models
{
    [Table("Users", Schema = "edusent")]
    public class User : IdentityUser
    {
        [DataType(DataType.Text), MaxLength(128)]
        public string FirstName { get; set; }

        [DataType(DataType.Text), MaxLength(128)]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [InverseProperty(nameof(Rating.RateFor))]
        public List<Rating> RateFors { get; set; } = new List<Rating>();

        [InverseProperty(nameof(Rating.RateBy))]
        public List<Rating> RateBys { get; set; } = new List<Rating>();
    }
}
