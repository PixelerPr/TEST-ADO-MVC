using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TEST_ADO_MVC.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        [DisplayName("last_name")]
        [Required]
        public string last_name { get; set; }
        [DisplayName("first_name")]
        [Required]
        public string first_name { get; set; }
    }
}
