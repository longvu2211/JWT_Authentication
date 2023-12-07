using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Domain.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        public required string Email { get; set; }
        [MaxLength(50)]
        public required string Password { get; set; }
        [MaxLength(50)]
        public string? Country { get; set; }
    }
}
