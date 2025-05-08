using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonApp.Shared.Models
{
    public class Person
    {
        public int PersonId { get; set; }

        [Required(ErrorMessage ="กรุณาระบุชื่อ")]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
