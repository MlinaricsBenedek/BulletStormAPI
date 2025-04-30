using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulletStormAPI.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required,MinLength(4), MaxLength(20)]
        public string Name { get; set; } = null!;

        [Required, MinLength(4), MaxLength(20)]
        public string Email { get; set; } = null!;

        [Required,PasswordPropertyText]
        public string Password { get; set; } = null!;

        public int ELO { get; set; } = 800;

        public ICollection<Match> Matches { get; set; } = new List<Match>();
    }
}
