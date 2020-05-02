using System;
namespace edusent_service.Models.ViewModels
{
    public class TeacherOverviewViewModel
    {
        public string UserId { get; set; }
        public string FullName { get; set; }
        public float Rating { get; set; }
        public string Subjects { get; set; }
    }
}