using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BulletStormAPI.Dto
{
    public class UserDto
    {
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

    }
}
