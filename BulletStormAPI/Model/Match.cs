using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulletStormAPI.Model
{
    public class Match
    {
        [Key]
        public int Id { get; set; }

        public User User { get; set; } = null!;

        public Result Result { get; set; } = null!;

        public float MatchTime { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
