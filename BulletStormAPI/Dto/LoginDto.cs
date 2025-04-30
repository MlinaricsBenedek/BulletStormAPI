using System.ComponentModel.DataAnnotations;

namespace BulletStormAPI.Dto
{
    public class LoginDto
    {

        [Required, MinLength(4), MaxLength(20)]
        public string Name { get; set; } = null!;

        public string Password { get; set; } = null!;

    }
}
