using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TEST_ADO_MVC.Models
{
    public class Employee : Timesheets
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string last_name { get; set; }
        [Required]
        public string first_name { get; set; }
    }
}
