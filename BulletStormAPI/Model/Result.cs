using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulletStormAPI.Model
{
    public class Result
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public int Kill { get; set; } = 0;

        public int Assist { get; set; } = 0;

        public int Deaths { get; set; } = 0;

        public bool Won { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
