namespace BulletStormAPI.Dto
{
    public class MatchResultDto
    { 
        public ResultDto Result { get; set; }

        public float AvarageElo { get; set; }

        public int AggregatedKills { get; set; }
    }
}
