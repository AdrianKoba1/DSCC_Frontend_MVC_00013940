using System.ComponentModel.DataAnnotations;

namespace Frontend_MVC_00013940.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The title cannot be longer than 30 characters.")]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public int? TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}
