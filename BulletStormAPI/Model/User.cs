using System.ComponentModel.DataAnnotations;

namespace BulletStormAPI.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MinLength(4), MaxLength(20)]
        public string Name { get; set; } = null!;

        [Required, MinLength(4), MaxLength(20)]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        public ICollection<Result> Results { get; set; } = new List<Result>();

        public ICollection<Statistics> Statistics { get; set; } = new List<Statistics>();
    }
}
