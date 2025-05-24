using System.ComponentModel.DataAnnotations;

namespace BulletStormAPI.Model
{
    public class Global
    {
        [Key]
        public int Id { get; set; } = 1;

        public int AggregatedKills { get; set; }

        public int AggregatedMatches { get; set; }

        public int AggregatedAssits { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
