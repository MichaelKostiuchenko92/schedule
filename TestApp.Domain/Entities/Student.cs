using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Domain.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        
        public DateTime? DateOfBirth { get; set; }

        public int? SpecialityId { get; set; }
        public Specialty Specialty { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }

        public Student()
        {
            Teachers = new List<Teacher>();
        }
    }
}
