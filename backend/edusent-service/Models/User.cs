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
        //public virtual ICollection<UserClaim> Claims { get; set; }
        //public virtual ICollection<UserLogin> Logins { get; set; }
        //public virtual ICollection<UserToken> Tokens { get; set; }
        //public virtual ICollection<UserRole> UserRoles { get; set; }


        [DataType(DataType.Text), MaxLength(128)]
        public string FirstName { get; set; }

        [DataType(DataType.Text), MaxLength(128)]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        
        public bool isTeacher { get; set; }

        public double MoneyMade { get; set; }

        public float Rating { get; set; }

        [InverseProperty(nameof(Subject.User))]
        public List<Subject> Subjects { get; set; } = new List<Subject>();

        //[InverseProperty(nameof(Rating.RateFor))]
        //public List<Rating> RateFors { get; set; } = new List<Rating>();

        //[InverseProperty(nameof(Rating.RateBy))]
        //public List<Rating> RateBys { get; set; } = new List<Rating>();
    }
}
