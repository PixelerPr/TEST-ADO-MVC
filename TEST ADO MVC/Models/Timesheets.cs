using System.ComponentModel.DataAnnotations;

namespace TEST_ADO_MVC.Models
{
    //Основная модель записей об отсутствии. Поля как в БД.
    public class Timesheets
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int employee { get; set; }
        [Required]
        public int reason { get; set; }
        [Required]
        public DateTime start_date { get; set; }
        [Required]
        public int duration { get; set; }
        [Required]
        public bool discounted { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string name_employee { get; set; }
        [Required]
        public List<Employee> employees { get; set;}
    }
}
