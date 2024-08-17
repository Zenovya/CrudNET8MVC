using System.ComponentModel.DataAnnotations;

namespace CrudNET8MVC.Models
{
    public class People
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Cellphone is required.")]
        public string CellPhone { get; set; }

        public DateTime CreatedAt { get; set; }
    }

}
