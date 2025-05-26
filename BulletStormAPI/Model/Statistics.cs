using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulletStormAPI.Model
{
    public class Statistics
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public int AggregatedKills { get; set; }

        public int AggregatedAssits { get; set; }

        public int AggregatedDeath { get; set; }

        public int AggregatedMatches { get; set; }

        public float ELO { get; set; } = 800;

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime Updated { get; set; } = DateTime.Now;
    }
}
