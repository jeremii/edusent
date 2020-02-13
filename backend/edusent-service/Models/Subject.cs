using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace edusent_service.Models
{
    [Table("Subjects", Schema = "edusent")]
    public class Subject : EntityBase
    {
        
        [Required]
        public string TeacherId { get; set; }
        [ForeignKey(nameof(TeacherId))]
        public Teacher Teacher { get; set; }

        [DataType(DataType.Text), MaxLength(128)]
        public string Name { get; set; }
    }
}
