using System.ComponentModel.DataAnnotations;

namespace BulletStormAPI.Model
{
    public class Result
    {
        [Key]
        public int Id { get; set; }

        public int Kill { get; set; } = 0;

        public int Assist { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Match> Results { get; set; } = new List<Match>();
    }
}
