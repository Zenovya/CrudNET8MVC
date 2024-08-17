using System.ComponentModel.DataAnnotations;

namespace CrudNET8MVC.Models
{
    public class People
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El celular es obligatorio.")]
        public string CellPhone { get; set; }

        public DateTime CreatedAt { get; set; }
    }

}
