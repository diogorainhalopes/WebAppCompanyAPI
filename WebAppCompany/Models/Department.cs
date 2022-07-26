using System.ComponentModel.DataAnnotations;

namespace WebAppCompany.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string Dname { get; set; }

    }
}
